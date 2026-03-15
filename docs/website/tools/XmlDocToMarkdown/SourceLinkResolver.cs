using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace XmlDocToMarkdown;

/// <summary>
/// Reads a portable PDB to extract source file paths and line numbers for types and members.
/// Maps local file paths to GitHub URLs using a repository root prefix and branch.
/// </summary>
public sealed class SourceLinkResolver : IDisposable
{
    private readonly MetadataReaderProvider _pdbProvider;
    private readonly MetadataReader _pdbReader;
    private readonly PEReader _peReader;
    private readonly MetadataReader _peMetadata;

    /// <summary>
    /// Key: type or member identifier matching the patterns used in the doc model.
    /// Value: GitHub URL with line number fragment.
    /// </summary>
    private readonly Dictionary<string, string> _sourceUrls = new(StringComparer.Ordinal);

    private readonly string _repoBaseUrl;
    private readonly string _localPathPrefix;

    /// <summary>
    /// Creates a new resolver by reading the PDB and PE metadata.
    /// </summary>
    /// <param name="pdbPath">Path to the portable PDB file.</param>
    /// <param name="assemblyPath">Path to the corresponding assembly DLL.</param>
    /// <param name="repoUrl">GitHub repository URL (e.g. "https://github.com/mwadams/Corvus.Text.Json").</param>
    /// <param name="branch">Branch name for source links (e.g. "main").</param>
    /// <param name="repoRoot">Local repository root path. File paths in the PDB that start with this
    /// prefix are converted to relative paths for the GitHub URL.</param>
    public SourceLinkResolver(string pdbPath, string assemblyPath, string repoUrl, string branch, string repoRoot)
    {
        _repoBaseUrl = $"{repoUrl.TrimEnd('/')}/blob/{branch}/";

        // Normalise the local path prefix: ensure trailing separator, use forward slashes for matching
        _localPathPrefix = repoRoot.TrimEnd('\\', '/').Replace('\\', '/') + "/";

        // Open PDB
        using FileStream pdbStream = File.OpenRead(pdbPath);
        _pdbProvider = MetadataReaderProvider.FromPortablePdbStream(pdbStream, MetadataStreamOptions.PrefetchMetadata);
        _pdbReader = _pdbProvider.GetMetadataReader();

        // Open PE (assembly) via PEReader for type/method metadata
        FileStream peStream = File.OpenRead(assemblyPath);
        _peReader = new PEReader(peStream);
        _peMetadata = _peReader.GetMetadataReader();
    }

    /// <summary>
    /// Scans all method debug information in the PDB and builds the source URL map.
    /// Call this once after construction, before querying.
    /// </summary>
    public void Build()
    {
        // Build a cache of document handles → file paths
        Dictionary<DocumentHandle, string> documentPaths = [];
        foreach (DocumentHandle docHandle in _pdbReader.Documents)
        {
            Document doc = _pdbReader.GetDocument(docHandle);
            if (doc.Name.IsNil)
            {
                continue;
            }

            string path = _pdbReader.GetString(doc.Name);
            documentPaths[docHandle] = path;
        }

        // Build a map of TypeDefinition token → type full name (from PE)
        Dictionary<int, string> typeTokenToName = [];
        foreach (TypeDefinitionHandle typeHandle in _peMetadata.TypeDefinitions)
        {
            TypeDefinition typeDef = _peMetadata.GetTypeDefinition(typeHandle);
            string ns = typeDef.Namespace.IsNil ? "" : _peMetadata.GetString(typeDef.Namespace);
            string name = _peMetadata.GetString(typeDef.Name);

            if (name.StartsWith('<') || name.Contains('$'))
            {
                continue;
            }

            // Handle nested types: walk DeclaringType chain
            string fullName = BuildFullTypeName(typeDef, ns, name);
            typeTokenToName[MetadataTokens.GetToken(typeHandle)] = fullName;
        }

        // For each type, track the first (lowest line number) source location we find
        // Key: type full name, Value: (filePath, lineNumber)
        Dictionary<string, (string File, int Line)> typeLocations = new(StringComparer.Ordinal);

        // Walk all MethodDebugInformation entries in the PDB
        foreach (MethodDebugInformationHandle mdiHandle in _pdbReader.MethodDebugInformation)
        {
            MethodDebugInformation mdi = _pdbReader.GetMethodDebugInformation(mdiHandle);
            if (mdi.Document.IsNil)
            {
                continue;
            }

            if (!documentPaths.TryGetValue(mdi.Document, out string? filePath))
            {
                continue;
            }

            // Get the first sequence point with a real line number
            int firstLine = int.MaxValue;
            foreach (SequencePoint sp in mdi.GetSequencePoints())
            {
                if (!sp.IsHidden && sp.StartLine < firstLine)
                {
                    firstLine = sp.StartLine;
                }
            }

            if (firstLine == int.MaxValue)
            {
                continue;
            }

            // Map this debug info back to the corresponding MethodDefinition in the PE
            // The method token for MethodDebugInformation N corresponds to MethodDefinition N
            MethodDefinitionHandle methodHandle = MetadataTokens.MethodDefinitionHandle(
                MetadataTokens.GetRowNumber(mdiHandle));

            if (methodHandle.IsNil)
            {
                continue;
            }

            MethodDefinition methodDef = _peMetadata.GetMethodDefinition(methodHandle);
            TypeDefinitionHandle declaringTypeHandle = methodDef.GetDeclaringType();
            int typeToken = MetadataTokens.GetToken(declaringTypeHandle);

            if (!typeTokenToName.TryGetValue(typeToken, out string? typeName))
            {
                continue;
            }

            // Build the member key: "TypeFullName.MethodName" (matching XmlDocKey minus prefix)
            string methodName = _peMetadata.GetString(methodDef.Name);

            // Store member-level source URL
            string memberKey = methodName == ".ctor"
                ? $"{typeName}.#ctor"
                : $"{typeName}.{methodName}";

            if (!_sourceUrls.ContainsKey(memberKey))
            {
                string? url = BuildGitHubUrl(filePath, firstLine);
                if (url is not null)
                {
                    _sourceUrls[memberKey] = url;
                }
            }

            // Track the earliest line for the type itself (the type page links to the primary file)
            if (!typeLocations.TryGetValue(typeName, out (string File, int Line) existing) ||
                IsPreferredTypeLocation(filePath, firstLine, existing.File, existing.Line, typeName))
            {
                typeLocations[typeName] = (filePath, firstLine);
            }
        }

        // Store type-level source URLs
        foreach (KeyValuePair<string, (string File, int Line)> kvp in typeLocations)
        {
            string? url = BuildGitHubUrl(kvp.Value.File, kvp.Value.Line);
            if (url is not null)
            {
                _sourceUrls[kvp.Key] = url;
            }
        }

        // For types with no method debug info (enums, static-field-only types),
        // try to match by file name against the PDB document list
        Dictionary<string, string> fileNameToPath = [];
        foreach (string docPath in documentPaths.Values)
        {
            string fileName = Path.GetFileNameWithoutExtension(docPath);
            // Only store the first match per filename (prefer primary files)
            fileNameToPath.TryAdd(fileName, docPath);
        }

        foreach (KeyValuePair<int, string> kvp in typeTokenToName)
        {
            if (_sourceUrls.ContainsKey(kvp.Value))
            {
                continue;
            }

            // Extract the short type name (without namespace, without generic arity)
            string shortName = kvp.Value;
            int lastDot = shortName.LastIndexOf('.');
            if (lastDot >= 0)
            {
                shortName = shortName[(lastDot + 1)..];
            }

            // Try exact filename match (e.g. "ValidationLevel" → ValidationLevel.cs)
            if (fileNameToPath.TryGetValue(shortName, out string? matchedPath))
            {
                string? url = BuildGitHubUrl(matchedPath, 1);
                if (url is not null)
                {
                    _sourceUrls[kvp.Value] = url;
                }
            }
        }

        Console.WriteLine($"  Built source URL map with {_sourceUrls.Count} entries.");
    }

    /// <summary>
    /// Returns the GitHub source URL for a type, or null if not found.
    /// </summary>
    /// <param name="typeFullName">Full type name using '+' or '.' for nested types.</param>
    public string? GetTypeSourceUrl(string typeFullName)
    {
        // Try as-is, then with '+' replaced by '.'
        if (_sourceUrls.TryGetValue(typeFullName, out string? url))
        {
            return url;
        }

        string dotForm = typeFullName.Replace('+', '.');
        if (_sourceUrls.TryGetValue(dotForm, out url))
        {
            return url;
        }

        // Try with generic arity variants (e.g. ArrayEnumerator → ArrayEnumerator`1)
        string nameWithoutArity = dotForm;
        int backtick = nameWithoutArity.IndexOf('`');
        if (backtick >= 0)
        {
            nameWithoutArity = nameWithoutArity[..backtick];
        }

        for (int arity = 1; arity <= 4; arity++)
        {
            if (_sourceUrls.TryGetValue($"{nameWithoutArity}`{arity}", out url))
            {
                return url;
            }
        }

        return null;
    }

    /// <summary>
    /// Returns the GitHub source URL for a member, or null if not found.
    /// </summary>
    /// <param name="xmlDocKey">The XmlDocKey from MemberInfo (e.g. "M:Corvus.Text.Json.JsonElement.Parse(...)").</param>
    public string? GetMemberSourceUrl(string xmlDocKey)
    {
        // Strip the prefix (M:, P:, F:, E:)
        string key = xmlDocKey.Length > 2 && xmlDocKey[1] == ':'
            ? xmlDocKey[2..]
            : xmlDocKey;

        // Strip parameters for lookup
        int parenIdx = key.IndexOf('(');
        if (parenIdx >= 0)
        {
            key = key[..parenIdx];
        }

        // Replace '+' with '.' for nested types
        key = key.Replace('+', '.');

        // Try with full key first (preserves generic arity)
        if (_sourceUrls.TryGetValue(key, out string? url))
        {
            return url;
        }

        // Strip generic arity and try again
        int backtickIdx = key.IndexOf('`');
        string keyWithoutArity = backtickIdx >= 0 ? key[..backtickIdx] : key;

        if (backtickIdx >= 0 && _sourceUrls.TryGetValue(keyWithoutArity, out url))
        {
            return url;
        }

        // Extract the member name (last segment) and parent type
        int lastDot = keyWithoutArity.LastIndexOf('.');
        if (lastDot < 0)
        {
            return null;
        }

        string parentKey = keyWithoutArity[..lastDot];
        string memberName = keyWithoutArity[(lastDot + 1)..];

        // Try with generic arity variants on the parent type
        // e.g. ArrayEnumerator.Dispose → ArrayEnumerator`1.Dispose
        for (int arity = 1; arity <= 4; arity++)
        {
            if (_sourceUrls.TryGetValue($"{parentKey}`{arity}.{memberName}", out url))
            {
                return url;
            }
        }

        // For properties, try get_/set_ accessor names
        string getterKey = $"{parentKey}.get_{memberName}";
        if (_sourceUrls.TryGetValue(getterKey, out url))
        {
            return url;
        }

        string setterKey = $"{parentKey}.set_{memberName}";
        if (_sourceUrls.TryGetValue(setterKey, out url))
        {
            return url;
        }

        // Try get_/set_ with arity too
        for (int arity = 1; arity <= 4; arity++)
        {
            if (_sourceUrls.TryGetValue($"{parentKey}`{arity}.get_{memberName}", out url))
            {
                return url;
            }

            if (_sourceUrls.TryGetValue($"{parentKey}`{arity}.set_{memberName}", out url))
            {
                return url;
            }
        }

        // Fall back to the declaring type's source URL
        // Try parentKey with arity from the original key
        int origLastDot = key.LastIndexOf('.');
        string parentFromOrig = origLastDot >= 0 ? key[..origLastDot] : parentKey;
        return GetTypeSourceUrl(parentFromOrig);
    }

    private string? BuildGitHubUrl(string localPath, int lineNumber)
    {
        // Normalise to forward slashes for matching
        string normalised = localPath.Replace('\\', '/');

        if (!normalised.StartsWith(_localPathPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        string relativePath = normalised[_localPathPrefix.Length..];
        return $"{_repoBaseUrl}{relativePath}#L{lineNumber}";
    }

    /// <summary>
    /// Prefers the "primary" partial file for a type: the file whose name matches the type name
    /// (without dot-separated concern suffixes like ".Parse.cs", ".Mutable.cs").
    /// </summary>
    private static bool IsPreferredTypeLocation(string newFile, int newLine, string existingFile, int existingLine, string typeName)
    {
        // Extract the short type name (last segment after dots, without generic arity)
        string shortName = typeName;
        int lastDot = shortName.LastIndexOf('.');
        if (lastDot >= 0)
        {
            shortName = shortName[(lastDot + 1)..];
        }

        int backtick = shortName.IndexOf('`');
        if (backtick >= 0)
        {
            shortName = shortName[..backtick];
        }

        // Check if the new file is the "primary" file (TypeName.cs, not TypeName.Something.cs)
        string newFileName = Path.GetFileNameWithoutExtension(newFile);
        string existingFileName = Path.GetFileNameWithoutExtension(existingFile);

        bool newIsPrimary = string.Equals(newFileName, shortName, StringComparison.OrdinalIgnoreCase);
        bool existingIsPrimary = string.Equals(existingFileName, shortName, StringComparison.OrdinalIgnoreCase);

        if (newIsPrimary && !existingIsPrimary)
        {
            return true;
        }

        if (!newIsPrimary && existingIsPrimary)
        {
            return false;
        }

        // Both primary or both non-primary: prefer the one with the lower line number
        return newLine < existingLine;
    }

    private string BuildFullTypeName(TypeDefinition typeDef, string ns, string name)
    {
        if (!typeDef.GetDeclaringType().IsNil)
        {
            TypeDefinition parent = _peMetadata.GetTypeDefinition(typeDef.GetDeclaringType());
            string parentNs = parent.Namespace.IsNil ? "" : _peMetadata.GetString(parent.Namespace);
            string parentName = _peMetadata.GetString(parent.Name);
            string parentFull = BuildFullTypeName(parent, parentNs, parentName);
            return $"{parentFull}.{name}";
        }

        return string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
    }

    public void Dispose()
    {
        _pdbProvider.Dispose();
        _peReader.Dispose();
    }
}
