using XmlDocToMarkdown;

string? xmlPath = null;
string? assemblyPath = null;
string? outputPath = null;
string? taxonomyOutputPath = null;
string? apiViewsDir = null;
string? sharedViewsDir = null;
string? repoUrl = null;
string? nsDescriptionsDir = null;
string? ns20AssemblyPath = null;
string? apiBaseUrl = null;

for (int i = 0; i < args.Length - 1; i++)
{
    switch (args[i])
    {
        case "--xml":
            xmlPath = args[++i];
            break;
        case "--assembly":
            assemblyPath = args[++i];
            break;
        case "--output":
            outputPath = args[++i];
            break;
        case "--taxonomy-output":
            taxonomyOutputPath = args[++i];
            break;
        case "--api-views-dir":
            apiViewsDir = args[++i];
            break;
        case "--shared-views-dir":
            sharedViewsDir = args[++i];
            break;
        case "--repo-url":
            repoUrl = args[++i];
            break;
        case "--ns-descriptions":
            nsDescriptionsDir = args[++i];
            break;
        case "--ns20-assembly":
            ns20AssemblyPath = args[++i];
            break;
        case "--api-base-url":
            apiBaseUrl = args[++i];
            break;
    }
}

string resolvedBaseUrl = (apiBaseUrl ?? "/api").TrimEnd('/');

if (xmlPath is null || assemblyPath is null)
{
    Console.Error.WriteLine("Usage: XmlDocToMarkdown --xml <path> --assembly <path> [--output <path>] [--taxonomy-output <path>] [--repo-url <url>]");
    Console.Error.WriteLine();
    Console.Error.WriteLine("  --xml              Path to the XML documentation file (e.g., Corvus.Text.Json.xml)");
    Console.Error.WriteLine("  --assembly         Path to the compiled DLL");
    Console.Error.WriteLine("  --output           Output directory for generated markdown files");
    Console.Error.WriteLine("  --taxonomy-output  Output directory for generated taxonomy YAML files");
    Console.Error.WriteLine("  --api-views-dir    (Optional) Directory for the generated API index view");
    Console.Error.WriteLine("  --shared-views-dir (Optional) Directory for generated shared Razor partials (e.g. _ApiSidebar.cshtml)");
    Console.Error.WriteLine("  --repo-url         (Optional) GitHub repository URL for source links (auto-detected from git if omitted)");
    Console.Error.WriteLine("  --ns-descriptions  (Optional) Directory containing {Namespace}.md files with namespace descriptions");
    Console.Error.WriteLine("  --api-base-url     (Optional) Base URL path for API pages (default: /api)");
    return 1;
}

if (!File.Exists(xmlPath))
{
    Console.Error.WriteLine($"XML documentation file not found: {xmlPath}");
    return 1;
}

if (!File.Exists(assemblyPath))
{
    Console.Error.WriteLine($"Assembly file not found: {assemblyPath}");
    return 1;
}

// Pre-scan assembly for type names to build the URL map before parsing XML
Console.WriteLine($"Pre-scanning assembly: {assemblyPath}");
AssemblyInspector inspector = new(assemblyPath);
XmlDocParser.TypeUrlMap = inspector.PreScanTypeUrls(resolvedBaseUrl);
Console.WriteLine($"  Built type URL map with {XmlDocParser.TypeUrlMap.Count} entries.");

Console.WriteLine($"Parsing XML documentation from: {xmlPath}");
XmlDocParser parser = new(xmlPath);
Dictionary<string, DocMember> members = parser.Parse();
Console.WriteLine($"  Found {members.Count} documented members.");

Console.WriteLine($"Inspecting assembly: {assemblyPath}");
Dictionary<string, NamespaceInfo> namespaces = inspector.Inspect(members);
Console.WriteLine($"  Found {namespaces.Count} namespace(s) with public types.");

// Build implementedBy reverse map: for each interface, collect which types implement it
Dictionary<string, TypeInfo> typesByFullName = new(StringComparer.Ordinal);
List<TypeInfo> allTypes = new();
foreach (NamespaceInfo nsInfo in namespaces.Values)
{
    foreach (TypeInfo typeInfo in nsInfo.Types)
    {
        typesByFullName[typeInfo.FullName] = typeInfo;
        allTypes.Add(typeInfo);
    }
}

foreach (TypeInfo typeInfo in allTypes)
{
    foreach ((string displayName, string? fullName) in typeInfo.InterfacesWithFullNames)
    {
        if (fullName is not null && typesByFullName.TryGetValue(fullName, out TypeInfo? ifaceInfo) && ifaceInfo.Kind == "interface")
        {
            ifaceInfo.ImplementedBy.Add((typeInfo.Name, typeInfo.FullName));
        }
    }
}

// Sort ImplementedBy lists alphabetically
foreach (TypeInfo typeInfo in allTypes)
{
    if (typeInfo.ImplementedBy.Count > 1)
    {
        typeInfo.ImplementedBy.Sort((a, b) => string.Compare(a.DisplayName, b.DisplayName, StringComparison.Ordinal));
    }
}

foreach (KeyValuePair<string, NamespaceInfo> ns in namespaces)
{
    Console.WriteLine($"    {ns.Key}: {ns.Value.Types.Count} type(s)");
}

// Scan netstandard2.0 assembly to determine TFM-specific member availability
if (ns20AssemblyPath is not null && File.Exists(ns20AssemblyPath))
{
    Console.WriteLine($"Scanning netstandard2.0 assembly: {ns20AssemblyPath}");
    HashSet<string> ns20Keys = AssemblyInspector.ScanMemberKeys(ns20AssemblyPath);
    Console.WriteLine($"  Found {ns20Keys.Count} members in netstandard2.0 build.");

    // Mark types and members not present in the ns2.0 assembly
    foreach (TypeInfo typeInfo in allTypes)
    {
        if (!ns20Keys.Contains($"T:{typeInfo.FullName}"))
        {
            typeInfo.AvailableOnNetStandard20 = false;
        }

        foreach (MemberInfo m in typeInfo.Constructors.Concat(typeInfo.Properties)
            .Concat(typeInfo.Methods).Concat(typeInfo.Operators)
            .Concat(typeInfo.Fields).Concat(typeInfo.Events))
        {
            if (!ns20Keys.Contains(m.XmlDocKey))
            {
                m.AvailableOnNetStandard20 = false;
            }
        }
    }
}

// Build source URL map from PDB if possible
SourceLinkResolver? sourceResolver = null;
string pdbPath = Path.ChangeExtension(Path.GetFullPath(assemblyPath), ".pdb");
if (File.Exists(pdbPath))
{
    Console.WriteLine($"Reading PDB for source links: {pdbPath}");

    // Auto-detect repo root from git
    string repoRoot = RunGit("rev-parse --show-toplevel")?.Trim() ?? "";
    string branch = "main";

    // Auto-detect repo URL from git remote if not provided
    if (repoUrl is null)
    {
        string? remoteUrl = RunGit("remote get-url origin")?.Trim();
        if (remoteUrl is not null)
        {
            // Normalise SSH → HTTPS and strip .git suffix
            if (remoteUrl.StartsWith("git@github.com:", StringComparison.OrdinalIgnoreCase))
            {
                remoteUrl = "https://github.com/" + remoteUrl["git@github.com:".Length..];
            }

            if (remoteUrl.EndsWith(".git", StringComparison.OrdinalIgnoreCase))
            {
                remoteUrl = remoteUrl[..^4];
            }

            repoUrl = remoteUrl;
        }
    }

    if (!string.IsNullOrEmpty(repoRoot) && !string.IsNullOrEmpty(repoUrl))
    {
        Console.WriteLine($"  Repo URL: {repoUrl}");
        Console.WriteLine($"  Branch: {branch}");
        sourceResolver = new SourceLinkResolver(pdbPath, Path.GetFullPath(assemblyPath), repoUrl, branch, repoRoot);
        sourceResolver.Build();
    }
    else
    {
        Console.WriteLine("  Warning: Could not detect git repo root or URL — source links disabled.");
    }
}
else
{
    Console.WriteLine("  No PDB found — source links disabled.");
}

if (outputPath is not null)
{
    Directory.CreateDirectory(outputPath);

    Console.WriteLine($"Generating namespace markdown to: {outputPath}");
    MarkdownGenerator markdownGen = new(outputPath, resolvedBaseUrl, nsDescriptionsDir, sourceResolver);
    markdownGen.Generate(namespaces);
    markdownGen.GeneratePerType(namespaces);
    markdownGen.GenerateMemberPages(namespaces);
}

if (taxonomyOutputPath is not null)
{
    Directory.CreateDirectory(taxonomyOutputPath);

    // Derive template name from base URL (e.g., "/api" → "api/api-page")
    string templateName = resolvedBaseUrl.TrimStart('/') + "/api-page";

    Console.WriteLine($"Generating API taxonomy to: {taxonomyOutputPath}");
    TaxonomyGenerator taxonomyGen = new(taxonomyOutputPath, outputPath!, resolvedBaseUrl, templateName);
    taxonomyGen.Generate(namespaces);
    taxonomyGen.GeneratePerType(namespaces);
    taxonomyGen.GeneratePerMember(namespaces);
}

if (apiViewsDir is not null)
{
    Console.WriteLine($"Generating API views to: {apiViewsDir}");
    Directory.CreateDirectory(apiViewsDir);
    ApiViewGenerator.GenerateIndexView(apiViewsDir, namespaces, resolvedBaseUrl, nsDescriptionsDir);
}

if (sharedViewsDir is not null)
{
    Console.WriteLine($"Generating API sidebar partial to: {sharedViewsDir}");
    Directory.CreateDirectory(sharedViewsDir);
    ApiViewGenerator.GenerateApiSidebar(sharedViewsDir, namespaces, resolvedBaseUrl);
}

if (outputPath is not null)
{
    string searchIndexPath = Path.Combine(outputPath, "search-index.json");
    Console.WriteLine($"Generating search index: {searchIndexPath}");
    SearchIndexGenerator searchGen = new(searchIndexPath, resolvedBaseUrl);
    searchGen.Generate(namespaces);
}

Console.WriteLine("Done.");
sourceResolver?.Dispose();
return 0;

static string? RunGit(string arguments)
{
    try
    {
        using System.Diagnostics.Process proc = new()
        {
            StartInfo = new()
            {
                FileName = "git",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            },
        };
        proc.Start();
        string output = proc.StandardOutput.ReadToEnd();
        proc.WaitForExit(5000);
        return proc.ExitCode == 0 ? output : null;
    }
    catch
    {
        return null;
    }
}
