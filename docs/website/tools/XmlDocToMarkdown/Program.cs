using XmlDocToMarkdown;

string? xmlPath = null;
string? assemblyPath = null;
string? outputPath = null;
string? taxonomyOutputPath = null;

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
    }
}

if (xmlPath is null || assemblyPath is null || outputPath is null || taxonomyOutputPath is null)
{
    Console.Error.WriteLine("Usage: XmlDocToMarkdown --xml <path> --assembly <path> --output <path> --taxonomy-output <path>");
    Console.Error.WriteLine();
    Console.Error.WriteLine("  --xml              Path to the XML documentation file (e.g., Corvus.Text.Json.xml)");
    Console.Error.WriteLine("  --assembly         Path to the compiled DLL");
    Console.Error.WriteLine("  --output           Output directory for generated markdown files");
    Console.Error.WriteLine("  --taxonomy-output  Output directory for generated taxonomy YAML files");
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

Console.WriteLine($"Parsing XML documentation from: {xmlPath}");
XmlDocParser parser = new(xmlPath);
Dictionary<string, DocMember> members = parser.Parse();
Console.WriteLine($"  Found {members.Count} documented members.");

Console.WriteLine($"Inspecting assembly: {assemblyPath}");
AssemblyInspector inspector = new(assemblyPath);
Dictionary<string, NamespaceInfo> namespaces = inspector.Inspect(members);
Console.WriteLine($"  Found {namespaces.Count} namespace(s) with public types.");

foreach (KeyValuePair<string, NamespaceInfo> ns in namespaces)
{
    Console.WriteLine($"    {ns.Key}: {ns.Value.Types.Count} type(s)");
}

Directory.CreateDirectory(outputPath);
Directory.CreateDirectory(taxonomyOutputPath);

Console.WriteLine($"Generating markdown to: {outputPath}");
MarkdownGenerator markdownGen = new(outputPath);
markdownGen.Generate(namespaces);

Console.WriteLine($"Generating taxonomy to: {taxonomyOutputPath}");
TaxonomyGenerator taxonomyGen = new(taxonomyOutputPath, outputPath);
taxonomyGen.Generate(namespaces);

string searchIndexPath = Path.Combine(outputPath, "search-index.json");
Console.WriteLine($"Generating search index: {searchIndexPath}");
SearchIndexGenerator searchGen = new(searchIndexPath);
searchGen.Generate(namespaces);

Console.WriteLine("Done.");
return 0;
