using XmlDocToMarkdown;

string? xmlPath = null;
string? assemblyPath = null;
string? outputPath = null;
string? taxonomyOutputPath = null;
string? htmlOutputPath = null;
string? siteTitleArg = null;
string? apiViewsDir = null;

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
        case "--html-output":
            htmlOutputPath = args[++i];
            break;
        case "--site-title":
            siteTitleArg = args[++i];
            break;
        case "--api-views-dir":
            apiViewsDir = args[++i];
            break;
    }
}

if (xmlPath is null || assemblyPath is null || outputPath is null || taxonomyOutputPath is null)
{
    Console.Error.WriteLine("Usage: XmlDocToMarkdown --xml <path> --assembly <path> --output <path> --taxonomy-output <path> [--html-output <path>] [--site-title <title>]");
    Console.Error.WriteLine();
    Console.Error.WriteLine("  --xml              Path to the XML documentation file (e.g., Corvus.Text.Json.xml)");
    Console.Error.WriteLine("  --assembly         Path to the compiled DLL");
    Console.Error.WriteLine("  --output           Output directory for generated markdown files");
    Console.Error.WriteLine("  --taxonomy-output  Output directory for generated taxonomy YAML files");
    Console.Error.WriteLine("  --html-output      (Optional) Output directory for standalone per-type HTML pages");
    Console.Error.WriteLine("  --site-title       (Optional) Site title for standalone HTML pages");
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
XmlDocParser.TypeUrlMap = inspector.PreScanTypeUrls();
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

Directory.CreateDirectory(outputPath);
Directory.CreateDirectory(taxonomyOutputPath);

Console.WriteLine($"Generating namespace markdown to: {outputPath}");
MarkdownGenerator markdownGen = new(outputPath);
markdownGen.Generate(namespaces);
markdownGen.GeneratePerType(namespaces);

Console.WriteLine($"Generating namespace taxonomy to: {taxonomyOutputPath}");
TaxonomyGenerator taxonomyGen = new(taxonomyOutputPath, outputPath);
taxonomyGen.Generate(namespaces);

if (apiViewsDir is not null)
{
    Console.WriteLine($"Generating API views to: {apiViewsDir}");
    Directory.CreateDirectory(apiViewsDir);
    ApiViewGenerator.GenerateIndexView(apiViewsDir, namespaces);
    ApiViewGenerator.GenerateNamespaceViews(apiViewsDir, namespaces);
}

if (htmlOutputPath is not null)
{
    string title = siteTitleArg ?? "Corvus.Text.Json";
    Console.WriteLine($"Generating standalone HTML type pages to: {htmlOutputPath}");
    HtmlPageGenerator htmlGen = new(htmlOutputPath, title);

    // Try to load template from a Vellum-rendered namespace page
    string referencePagePath = Path.Combine(htmlOutputPath, "corvus-text-json.html");
    if (File.Exists(referencePagePath))
    {
        Console.WriteLine($"  Loading page template from: {referencePagePath}");
        htmlGen.LoadTemplate(referencePagePath);
    }
    else
    {
        Console.WriteLine("  Warning: No reference page found — using fallback template.");
    }

    htmlGen.Generate(namespaces);
}

string searchIndexPath = Path.Combine(outputPath, "search-index.json");
Console.WriteLine($"Generating search index: {searchIndexPath}");
SearchIndexGenerator searchGen = new(searchIndexPath);
searchGen.Generate(namespaces);

Console.WriteLine("Done.");
return 0;
