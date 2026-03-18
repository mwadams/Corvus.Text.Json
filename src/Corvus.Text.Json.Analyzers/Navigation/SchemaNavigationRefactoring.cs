// <copyright file="SchemaNavigationRefactoring.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Corvus.Text.Json.Analyzers;

/// <summary>
/// CTJ-NAV: Provides a "Go to Schema Definition" refactoring for types generated
/// from JSON Schema via <c>JsonSchemaTypeGeneratorAttribute</c>.
/// </summary>
/// <remarks>
/// <para>
/// When the cursor is on an identifier that resolves to a schema-generated type
/// (or to a variable/property/parameter of such a type, including those typed as
/// <c>IJsonElement&lt;T&gt;</c> or <c>IMutableJsonElement&lt;T&gt;</c>), this
/// refactoring offers a "Go to schema" action that opens the source JSON Schema file.
/// </para>
/// <para>
/// If the generated type has a <c>SchemaLocation</c> const containing a JSON pointer
/// fragment (e.g., <c>"person.json#/properties/name"</c>), the action navigates to
/// the corresponding line within the schema file.
/// </para>
/// </remarks>
[ExportCodeRefactoringProvider(LanguageNames.CSharp, Name = nameof(SchemaNavigationRefactoring))]
[Shared]
public sealed class SchemaNavigationRefactoring : CodeRefactoringProvider
{
    private const string GeneratorAttributeName = "JsonSchemaTypeGeneratorAttribute";
    private const string GeneratorAttributeShortName = "JsonSchemaTypeGenerator";
    private const string JsonSchemaNestedClassName = "JsonSchema";
    private const string SchemaLocationFieldName = "SchemaLocation";

    /// <inheritdoc/>
    public override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
    {
        SyntaxNode? root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return;
        }

        // Find the node under the cursor.
        SyntaxNode? node = root.FindNode(context.Span);
        if (node is null)
        {
            return;
        }

        SemanticModel? semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
        if (semanticModel is null)
        {
            return;
        }

        ITypeSymbol? typeSymbol = null;
        IPropertySymbol? accessedProperty = null;

        if (node is VariableDeclaratorSyntax variableDeclarator)
        {
            // Handle cursor on variable name in declarations: Order order = ...
            ISymbol? declared = semanticModel.GetDeclaredSymbol(variableDeclarator, context.CancellationToken);
            typeSymbol = (declared as ILocalSymbol)?.Type;
        }
        else if (node is ParameterSyntax parameterSyntax)
        {
            // Handle cursor on parameter name: void Method(Order order)
            ISymbol? declared = semanticModel.GetDeclaredSymbol(parameterSyntax, context.CancellationToken);
            typeSymbol = (declared as IParameterSymbol)?.Type;
        }
        else
        {
            // We're looking for type name identifiers.
            IdentifierNameSyntax? identifier = node as IdentifierNameSyntax
                ?? node.Parent as IdentifierNameSyntax;

            // Also handle GenericNameSyntax (e.g., IJsonElement<Widget>).
            GenericNameSyntax? genericName = null;

            if (identifier is null)
            {
                // Also handle qualified names like V5Example.Model.Person
                if (node is QualifiedNameSyntax qualifiedName)
                {
                    identifier = qualifiedName.Right as IdentifierNameSyntax;
                    genericName = qualifiedName.Right as GenericNameSyntax;
                }
                else if (node is GenericNameSyntax gns)
                {
                    genericName = gns;
                }
                else if (node.Parent is GenericNameSyntax parentGns)
                {
                    genericName = parentGns;
                }
            }

            if (identifier is null && genericName is null)
            {
                return;
            }

            SyntaxNode nodeForSymbol = (SyntaxNode?)identifier ?? genericName!;

            // Resolve the symbol.
            SymbolInfo symbolInfo = semanticModel.GetSymbolInfo(nodeForSymbol, context.CancellationToken);
            ISymbol? symbol = symbolInfo.Symbol ?? symbolInfo.CandidateSymbols.FirstOrDefault();

            // If the symbol is a local/parameter/field of a generated type, get the type.
            typeSymbol = symbol switch
            {
                ITypeSymbol t => t,
                ILocalSymbol l => l.Type,
                IParameterSymbol p => p.Type,
                IFieldSymbol f => f.Type,
                IPropertySymbol prop => prop.Type,
                IMethodSymbol m => m.ReturnType,
                _ => null,
            };

            // Track property access for fallback to containing type.
            if (symbol is IPropertySymbol accessedProp)
            {
                accessedProperty = accessedProp;
            }
        }

        if (typeSymbol is not INamedTypeSymbol namedType)
        {
            return;
        }

        // Unwrap IJsonElement<T> / IMutableJsonElement<T> to get the concrete type T.
        namedType = UnwrapJsonElementInterface(namedType);

        // Find the JsonSchemaTypeGeneratorAttribute on the type.
        SchemaInfo? schemaInfo = FindSchemaInfo(namedType, context.Document.Project, context.CancellationToken);

        // Read the SchemaLocation const to get the JSON pointer fragment.
        string? schemaLocation = GetSchemaLocation(namedType);
        string? jsonPointer = ExtractJsonPointer(schemaLocation);

        // If the type's SchemaLocation contains a full URL with $id, resolve the
        // schema file by matching $id in AdditionalDocuments.
        if (schemaInfo is null && schemaLocation is not null && schemaLocation.Length > 0)
        {
            string? baseUrl = ExtractBaseUrl(schemaLocation);
            if (baseUrl is not null)
            {
                schemaInfo = await FindSchemaByIdAsync(baseUrl, context.Document.Project, context.CancellationToken).ConfigureAwait(false);
            }
        }

        // If the property's own type is not schema-generated (e.g. a project-global
        // type like JsonString), fall back to the containing type's schema and append
        // /properties/{jsonPropName} to the pointer.
        string? propertyPointerSuffix = null;
        if (schemaInfo is null && accessedProperty is not null)
        {
            INamedTypeSymbol? containingType = accessedProperty.ContainingType;
            if (containingType is not null)
            {
                containingType = UnwrapJsonElementInterface(containingType);
                schemaInfo = FindSchemaInfo(containingType, context.Document.Project, context.CancellationToken);

                string? containingSchemaLocation = GetSchemaLocation(containingType);

                // Also try $id-based lookup for the containing type.
                if (schemaInfo is null && containingSchemaLocation is not null && containingSchemaLocation.Length > 0)
                {
                    string? baseUrl = ExtractBaseUrl(containingSchemaLocation);
                    if (baseUrl is not null)
                    {
                        schemaInfo = await FindSchemaByIdAsync(baseUrl, context.Document.Project, context.CancellationToken).ConfigureAwait(false);
                    }
                }

                if (schemaInfo is not null)
                {
                    // Use the containing type's pointer as a base, and append
                    // the property path.
                    jsonPointer = ExtractJsonPointer(containingSchemaLocation);
                    propertyPointerSuffix = "/properties/" + ToCamelCase(accessedProperty.Name);
                }
            }
        }

        if (schemaInfo is null)
        {
            return;
        }

        // If we resolved via a property on a schema-generated containing type,
        // append the property path to the pointer.
        if (propertyPointerSuffix is not null)
        {
            jsonPointer = (jsonPointer ?? string.Empty) + propertyPointerSuffix;
        }

        // Pre-resolve the pointer to a target line by reading the schema file text.
        int? targetLine = null;
        if (jsonPointer is not null && schemaInfo.Value.DocumentId is not null)
        {
            TextDocument? schemaDoc = context.Document.Project.GetAdditionalDocument(schemaInfo.Value.DocumentId);
            if (schemaDoc is not null)
            {
                SourceText? schemaText = await schemaDoc.GetTextAsync(context.CancellationToken).ConfigureAwait(false);
                if (schemaText is not null)
                {
                    targetLine = ResolveJsonPointerToLine(schemaText.ToString(), jsonPointer);
                }
            }
        }

        string displayName = jsonPointer is not null
            ? $"{Path.GetFileName(schemaInfo.Value.FilePath)}#{jsonPointer}"
            : Path.GetFileName(schemaInfo.Value.FilePath);

        string title = $"Go to schema: {displayName}";

        context.RegisterRefactoring(
            new NavigateToSchemaAction(
                title,
                schemaInfo.Value.FilePath,
                schemaInfo.Value.DocumentId,
                targetLine));
    }

    /// <summary>
    /// If the type is <c>IJsonElement&lt;T&gt;</c> or <c>IMutableJsonElement&lt;T&gt;</c>,
    /// returns the <c>T</c> type argument. Otherwise returns the original type.
    /// </summary>
    private static INamedTypeSymbol UnwrapJsonElementInterface(INamedTypeSymbol namedType)
    {
        if (namedType.IsGenericType && namedType.TypeArguments.Length == 1)
        {
            string typeName = namedType.OriginalDefinition.Name;
            string? ns = namedType.OriginalDefinition.ContainingNamespace?.ToDisplayString();

            if (ns == "Corvus.Text.Json.Internal" &&
                (typeName == "IJsonElement" || typeName == "IMutableJsonElement"))
            {
                if (namedType.TypeArguments[0] is INamedTypeSymbol concreteType)
                {
                    return concreteType;
                }
            }
        }

        // Also check if the type implements IJsonElement<T> but doesn't have the attribute itself.
        // In the CRTP pattern (T : struct, IJsonElement<T>), the type IS T, so this is already
        // handled by the existing ContainingType walk in FindSchemaInfo.
        return namedType;
    }

    /// <summary>
    /// Reads the <c>SchemaLocation</c> const from the type's nested <c>JsonSchema</c> static class.
    /// </summary>
    private static string? GetSchemaLocation(INamedTypeSymbol typeSymbol)
    {
        // Look for a nested type called "JsonSchema" containing a const "SchemaLocation".
        foreach (INamedTypeSymbol nestedType in typeSymbol.GetTypeMembers())
        {
            if (nestedType.Name == JsonSchemaNestedClassName)
            {
                foreach (ISymbol member in nestedType.GetMembers(SchemaLocationFieldName))
                {
                    if (member is IFieldSymbol { IsConst: true, ConstantValue: string location } &&
                        !string.IsNullOrEmpty(location))
                    {
                        return location;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Extracts the JSON pointer fragment from a SchemaLocation value.
    /// Returns <c>null</c> if no pointer is present.
    /// </summary>
    private static string? ExtractJsonPointer(string? schemaLocation)
    {
        if (schemaLocation is null)
        {
            return null;
        }

        int hashIndex = schemaLocation.IndexOf('#');
        if (hashIndex >= 0 && hashIndex < schemaLocation.Length - 1)
        {
            return schemaLocation.Substring(hashIndex + 1);
        }

        return null;
    }

    /// <summary>
    /// Extracts the base URL (everything before <c>#</c>) from a SchemaLocation value.
    /// Returns <c>null</c> if the value doesn't look like a URL.
    /// </summary>
    private static string? ExtractBaseUrl(string schemaLocation)
    {
        int hashIndex = schemaLocation.IndexOf('#');
        string baseUrl = hashIndex >= 0
            ? schemaLocation.Substring(0, hashIndex)
            : schemaLocation;

        // Only treat as a URL if it contains "://"
        if (baseUrl.Contains("://"))
        {
            return baseUrl;
        }

        return null;
    }

    /// <summary>
    /// Finds an AdditionalDocument whose JSON content contains a <c>$id</c> matching
    /// the given URL.
    /// </summary>
    private static async Task<SchemaInfo?> FindSchemaByIdAsync(
        string idUrl,
        Project project,
        CancellationToken cancellationToken)
    {
        string idPattern = "\"$id\"";

        foreach (TextDocument doc in project.AdditionalDocuments)
        {
            if (doc.FilePath is null)
            {
                continue;
            }

            // Only check .json files.
            if (!doc.FilePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            SourceText? text = await doc.GetTextAsync(cancellationToken).ConfigureAwait(false);
            if (text is null)
            {
                continue;
            }

            string content = text.ToString();

            // Quick check: does the file contain "$id" at all?
            if (content.IndexOf(idPattern, StringComparison.Ordinal) < 0)
            {
                continue;
            }

            // Look for "$id": "<idUrl>" (with flexible whitespace).
            if (content.Contains(idUrl))
            {
                return new SchemaInfo(doc.FilePath, doc.Id);
            }
        }

        return null;
    }

    /// <summary>
    /// Converts a PascalCase property name to camelCase for JSON property name matching.
    /// </summary>
    private static string ToCamelCase(string name)
    {
        if (string.IsNullOrEmpty(name) || char.IsLower(name[0]))
        {
            return name;
        }

        return char.ToLowerInvariant(name[0]) + name.Substring(1);
    }

    private static SchemaInfo? FindSchemaInfo(
        INamedTypeSymbol typeSymbol,
        Project project,
        CancellationToken cancellationToken)
    {
        // Walk up through containing types to find the one with the attribute.
        INamedTypeSymbol? current = typeSymbol;
        while (current is not null)
        {
            string? schemaPath = GetSchemaPathFromAttribute(current);
            if (schemaPath is not null)
            {
                string? resolvedPath = ResolveSchemaPath(current, schemaPath, project);
                if (resolvedPath is not null)
                {
                    // Find matching additional document.
                    DocumentId? docId = FindAdditionalDocument(project, resolvedPath);
                    return new SchemaInfo(resolvedPath, docId);
                }
            }

            current = current.ContainingType;
        }

        return null;
    }

    private static string? GetSchemaPathFromAttribute(INamedTypeSymbol typeSymbol)
    {
        foreach (AttributeData attribute in typeSymbol.GetAttributes())
        {
            string? attrName = attribute.AttributeClass?.Name;
            if (attrName == GeneratorAttributeName || attrName == GeneratorAttributeShortName)
            {
                if (attribute.ConstructorArguments.Length > 0 &&
                    attribute.ConstructorArguments[0].Value is string path)
                {
                    return path;
                }
            }
        }

        return null;
    }

    private static string? ResolveSchemaPath(
        INamedTypeSymbol typeSymbol,
        string schemaRelativePath,
        Project project)
    {
        string normalizedRelative = schemaRelativePath.Replace('\\', '/');

        // Resolve relative to the source file containing the attribute declaration.
        foreach (SyntaxReference syntaxRef in typeSymbol.DeclaringSyntaxReferences)
        {
            string? sourceFilePath = syntaxRef.SyntaxTree.FilePath;
            if (string.IsNullOrEmpty(sourceFilePath))
            {
                continue;
            }

            string? sourceDir = Path.GetDirectoryName(sourceFilePath);
            if (sourceDir is null)
            {
                continue;
            }

            string resolved = Path.GetFullPath(Path.Combine(sourceDir, schemaRelativePath));

            // Verify the resolved path matches an AdditionalDocument.
            foreach (TextDocument doc in project.AdditionalDocuments)
            {
                if (doc.FilePath is not null &&
                    Path.GetFullPath(doc.FilePath).Equals(resolved, StringComparison.OrdinalIgnoreCase))
                {
                    return resolved;
                }
            }
        }

        // Fallback: search additional documents whose path ends with the schema path.
        foreach (TextDocument doc in project.AdditionalDocuments)
        {
            if (doc.FilePath is null)
            {
                continue;
            }

            string docPathNormalized = doc.FilePath.Replace('\\', '/');
            if (docPathNormalized.EndsWith(normalizedRelative, StringComparison.OrdinalIgnoreCase) ||
                Path.GetFileName(doc.FilePath).Equals(
                    Path.GetFileName(schemaRelativePath), StringComparison.OrdinalIgnoreCase))
            {
                return doc.FilePath;
            }
        }

        return null;
    }

    private static DocumentId? FindAdditionalDocument(Project project, string filePath)
    {
        string normalizedPath = Path.GetFullPath(filePath);

        foreach (TextDocument doc in project.AdditionalDocuments)
        {
            if (doc.FilePath is not null &&
                Path.GetFullPath(doc.FilePath).Equals(normalizedPath, StringComparison.OrdinalIgnoreCase))
            {
                return doc.Id;
            }
        }

        return null;
    }

    private readonly struct SchemaInfo
    {
        public SchemaInfo(string filePath, DocumentId? documentId)
        {
            this.FilePath = filePath;
            this.DocumentId = documentId;
        }

        public string FilePath { get; }

        public DocumentId? DocumentId { get; }
    }

    /// <summary>
    /// A code action that navigates to the JSON Schema file. In Visual Studio,
    /// this opens the file in the editor. In other environments, the action title
    /// shows the schema path for reference.
    /// </summary>
    private sealed class NavigateToSchemaAction : CodeAction
    {
        private readonly string title;
        private readonly string filePath;
        private readonly DocumentId? documentId;
        private readonly int? targetLine;

        public NavigateToSchemaAction(string title, string filePath, DocumentId? documentId, int? targetLine)
        {
            this.title = title;
            this.filePath = filePath;
            this.documentId = documentId;
            this.targetLine = targetLine;
        }

        /// <inheritdoc/>
        public override string Title => this.title;

        /// <inheritdoc/>
        public override string? EquivalenceKey => "CTJ-NAV";

        /// <inheritdoc/>
        protected override Task<IEnumerable<CodeActionOperation>> ComputeOperationsAsync(
            CancellationToken cancellationToken)
        {
            var operations = new List<CodeActionOperation>
            {
                new OpenSchemaFileOperation(this.filePath, this.documentId, this.targetLine),
            };

            return Task.FromResult<IEnumerable<CodeActionOperation>>(operations);
        }
    }

    /// <summary>
    /// A <see cref="CodeActionOperation"/> that attempts to open a schema file
    /// in the host workspace. In Visual Studio this opens the document in the editor.
    /// If a JSON pointer is provided, the operation attempts to navigate to the
    /// corresponding line within the file.
    /// </summary>
    private sealed class OpenSchemaFileOperation : CodeActionOperation
    {
        private readonly string filePath;
        private readonly DocumentId? documentId;
        private readonly int? targetLine;

        public OpenSchemaFileOperation(string filePath, DocumentId? documentId, int? targetLine)
        {
            this.filePath = filePath;
            this.documentId = documentId;
            this.targetLine = targetLine;
        }

        /// <inheritdoc/>
        public override string Title => $"Open {Path.GetFileName(this.filePath)}";

        /// <inheritdoc/>
        public override void Apply(Workspace workspace, CancellationToken cancellationToken)
        {
            // Try DTE-based open + navigate first.
            // This avoids timing issues with workspace.OpenDocument not immediately
            // making the document active. DTE.ItemOperations.OpenFile is synchronous.
            if (TryOpenAndNavigateViaDte(workspace))
            {
                return;
            }

            // Fall back to Roslyn workspace API (no line navigation available).
            if (this.documentId is not null)
            {
                try
                {
                    workspace.OpenDocument(this.documentId);
                }
                catch (NotSupportedException)
                {
                    // Not all workspace implementations support OpenDocument.
                }
                catch (InvalidOperationException)
                {
                    // Document not found in the solution.
                }
            }
        }

        /// <summary>
        /// Attempts to open the schema file and navigate to the target line using the
        /// Visual Studio DTE automation model. Uses reflection to avoid hard dependencies
        /// on VS assemblies. Returns <c>false</c> if DTE is not available.
        /// </summary>
        private bool TryOpenAndNavigateViaDte(Workspace workspace)
        {
            try
            {
                // Find the EnvDTE.DTE type from loaded assemblies.
                Type? dteType = FindTypeInLoadedAssemblies("EnvDTE.DTE");
                if (dteType is null)
                {
                    return false;
                }

                // Try multiple strategies to get the DTE instance.
                object? dte = GetDteViaMethods(workspace, dteType);
                if (dte is null)
                {
                    return false;
                }

                // Use DTE.ItemOperations.OpenFile(filePath, viewKind) to open the file
                // synchronously. This ensures the document IS the active document when
                // we call GotoLine, avoiding the timing issue with workspace.OpenDocument.
                object? itemOperations = dte.GetType()
                    .GetProperty("ItemOperations")
                    ?.GetValue(dte);

                if (itemOperations is null)
                {
                    return false;
                }

                // EnvDTE.Constants.vsViewKindTextView
                const string vsViewKindTextView = "{7651A703-06E5-11D1-8EBD-00A0C90F26EA}";

                bool fileOpened = false;
                foreach (System.Reflection.MethodInfo method in itemOperations.GetType().GetMethods())
                {
                    if (method.Name != "OpenFile")
                    {
                        continue;
                    }

                    System.Reflection.ParameterInfo[] parms = method.GetParameters();
                    if (parms.Length == 2)
                    {
                        method.Invoke(itemOperations, new object[] { this.filePath, vsViewKindTextView });
                        fileOpened = true;
                        break;
                    }

                    if (parms.Length == 1)
                    {
                        method.Invoke(itemOperations, new object[] { this.filePath });
                        fileOpened = true;
                        break;
                    }
                }

                if (!fileOpened)
                {
                    return false;
                }

                // Navigate to the target line in the now-active document.
                if (this.targetLine.HasValue)
                {
                    object? activeDoc = dte.GetType()
                        .GetProperty("ActiveDocument")
                        ?.GetValue(dte);

                    object? selection = activeDoc?.GetType()
                        .GetProperty("Selection")
                        ?.GetValue(activeDoc);

                    if (selection is not null)
                    {
                        // DTE lines are 1-based; our targetLine is 0-based.
                        foreach (System.Reflection.MethodInfo method in selection.GetType().GetMethods())
                        {
                            if (method.Name == "GotoLine" && method.GetParameters().Length == 2)
                            {
                                method.Invoke(selection, new object[] { this.targetLine.Value + 1, false });
                                break;
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                // DTE not available — fall back to workspace API.
                return false;
            }
        }

        /// <summary>
        /// Tries multiple strategies to obtain the VS DTE automation object.
        /// </summary>
        private static object? GetDteViaMethods(Workspace workspace, Type dteType)
        {
            // Strategy 1: Package.GetGlobalService(typeof(DTE))
            // This is the standard VS Shell approach.
            Type? packageType = FindTypeInLoadedAssemblies("Microsoft.VisualStudio.Shell.Package");
            if (packageType is not null)
            {
                System.Reflection.MethodInfo? getGlobalService = packageType.GetMethod(
                    "GetGlobalService",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static,
                    null,
                    new[] { typeof(Type) },
                    null);

                object? dte = getGlobalService?.Invoke(null, new object[] { dteType });
                if (dte is not null)
                {
                    return dte;
                }
            }

            // Strategy 2: ServiceProvider.GlobalProvider.GetService(typeof(DTE))
            Type? spType = FindTypeInLoadedAssemblies("Microsoft.VisualStudio.Shell.ServiceProvider");
            if (spType is not null)
            {
                object? globalProvider = spType.GetProperty(
                    "GlobalProvider",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                    ?.GetValue(null);

                if (globalProvider is IServiceProvider sp)
                {
                    object? dte = sp.GetService(dteType);
                    if (dte is not null)
                    {
                        return dte;
                    }
                }
            }

            // Strategy 3: Workspace's internal service provider (last resort).
            object? workspaceSp = workspace.GetType().GetProperty(
                "ServiceProvider",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Public)
                ?.GetValue(workspace);

            if (workspaceSp is not null)
            {
                object? dte = workspaceSp.GetType()
                    .GetMethod("GetService", new[] { typeof(Type) })
                    ?.Invoke(workspaceSp, new object[] { dteType });

                if (dte is not null)
                {
                    return dte;
                }
            }

            return null;
        }

        private static Type? FindTypeInLoadedAssemblies(string fullName)
        {
            foreach (System.Reflection.Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type? t = asm.GetType(fullName);
                if (t is not null)
                {
                    return t;
                }
            }

            return null;
        }
    }

    /// <summary>
    /// Resolves a JSON pointer (e.g., <c>/properties/name</c>) to a line number
    /// within the given schema text. Returns <c>null</c> if the pointer cannot be resolved.
    /// </summary>
    /// <remarks>
    /// This is a lightweight text-based resolver that walks the JSON text line-by-line,
    /// matching property keys against pointer segments. It does not perform a full JSON
    /// parse, which keeps it suitable for use in an analyzer context.
    /// </remarks>
    internal static int? ResolveJsonPointerToLine(string schemaText, string jsonPointer)
    {
        if (string.IsNullOrEmpty(jsonPointer) || jsonPointer == "/")
        {
            return null;
        }

        // Split the pointer into segments: "/properties/name" → ["properties", "name"]
        string[] segments = jsonPointer.TrimStart('/').Split('/');
        if (segments.Length == 0)
        {
            return null;
        }

        // Unescape JSON Pointer encoding (~1 → /, ~0 → ~)
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i] = segments[i].Replace("~1", "/").Replace("~0", "~");
        }

        string[] lines = schemaText.Split('\n');
        int currentSegmentIndex = 0;
        int targetLine = 0;
        int depth = 0;

        // We want to look for segments at increasing depths.
        // The root object is depth 1, so the first segment should be at depth 1.
        int targetDepth = 1;

        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            string line = lines[lineIndex].Trim();

            // Depth at the start of this line (before this line's braces).
            int startOfLineDepth = depth;

            // Update depth by counting braces on this line.
            foreach (char c in line)
            {
                if (c == '{' || c == '[')
                {
                    depth++;
                }
                else if (c == '}' || c == ']')
                {
                    depth--;
                }
            }

            if (currentSegmentIndex >= segments.Length)
            {
                break;
            }

            string segment = segments[currentSegmentIndex];

            // Check if this line contains a JSON property key matching the current segment
            // at the expected nesting depth.
            string keyPattern = $"\"{segment}\"";
            int keyIndex = line.IndexOf(keyPattern, StringComparison.Ordinal);

            if (keyIndex >= 0 && IsPropertyKey(line, keyIndex, keyPattern.Length))
            {
                if (startOfLineDepth == targetDepth)
                {
                    targetLine = lineIndex;
                    currentSegmentIndex++;

                    // Next segment should be one level deeper.
                    targetDepth = startOfLineDepth + 1;

                    if (currentSegmentIndex >= segments.Length)
                    {
                        return targetLine;
                    }
                }
            }

            // Handle array indices: if the segment is a number, count array elements
            // at the target depth.
            if (int.TryParse(segment, out int arrayIndex) && startOfLineDepth == targetDepth)
            {
                if (line.StartsWith("{", StringComparison.Ordinal) ||
                    line.StartsWith("[", StringComparison.Ordinal) ||
                    line.StartsWith("\"", StringComparison.Ordinal))
                {
                    if (arrayIndex == 0)
                    {
                        targetLine = lineIndex;
                        currentSegmentIndex++;
                        targetDepth = startOfLineDepth + 1;

                        if (currentSegmentIndex >= segments.Length)
                        {
                            return targetLine;
                        }
                    }
                }
            }
        }

        // If we matched all segments, return the last matched line.
        if (currentSegmentIndex >= segments.Length)
        {
            return targetLine;
        }

        // Could not resolve the full pointer.
        return null;
    }

    /// <summary>
    /// Checks whether the matched key pattern at the given position is actually
    /// a property key (followed by a colon) rather than a string value.
    /// </summary>
    private static bool IsPropertyKey(string line, int keyIndex, int keyLength)
    {
        int afterKey = keyIndex + keyLength;
        for (int i = afterKey; i < line.Length; i++)
        {
            char c = line[i];
            if (c == ' ' || c == '\t')
            {
                continue;
            }

            return c == ':';
        }

        return false;
    }
}
