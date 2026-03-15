using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates a search-index.json file for Lunr-based search integration.
/// </summary>
public sealed class SearchIndexGenerator(string outputPath)
{
    public void Generate(Dictionary<string, NamespaceInfo> namespaces)
    {
        List<SearchEntry> entries = [];

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string pageFileName = MarkdownGenerator.NamespaceToFileName(ns);
            string pageUrl = $"/api/{pageFileName}.html";

            foreach (TypeInfo type in kvp.Value.Types)
            {
                AddTypeEntries(entries, type, ns, pageUrl);
            }
        }

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        string json = JsonSerializer.Serialize(entries, options);
        File.WriteAllText(outputPath, json);
        Console.WriteLine($"  Written: {outputPath} ({entries.Count} entries)");
    }

    private static void AddTypeEntries(List<SearchEntry> entries, TypeInfo type, string ns, string pageUrl)
    {
        string anchor = type.Name.Replace('.', '-').Replace('<', '-').Replace('>', '-').ToLowerInvariant().TrimEnd('-');

        // Build keywords from the type
        List<string> keywords = [type.Name, type.Kind, ns];
        keywords.AddRange(type.GenericParameters);

        // Build body from all member summaries
        StringBuilder body = new();
        if (!string.IsNullOrEmpty(type.Documentation?.Summary))
        {
            body.AppendLine(type.Documentation!.Summary);
        }

        if (!string.IsNullOrEmpty(type.Documentation?.Remarks))
        {
            body.AppendLine(type.Documentation!.Remarks);
        }

        foreach (MemberInfo prop in type.Properties)
        {
            if (!string.IsNullOrEmpty(prop.Documentation?.Summary))
            {
                body.AppendLine($"{prop.Name}: {prop.Documentation!.Summary}");
            }
        }

        foreach (MemberInfo method in type.Methods)
        {
            if (!string.IsNullOrEmpty(method.Documentation?.Summary))
            {
                body.AppendLine($"{method.Name}: {method.Documentation!.Summary}");
            }
        }

        entries.Add(new SearchEntry
        {
            Url = $"{pageUrl}#{anchor}",
            Title = type.Name,
            Description = type.Documentation?.Summary ?? string.Empty,
            Keywords = string.Join(" ", keywords),
            Body = body.ToString().Trim(),
        });

        // Add entries for each nested type
        foreach (TypeInfo nested in type.NestedTypes)
        {
            AddTypeEntries(entries, nested, ns, pageUrl);
        }
    }

    private sealed class SearchEntry
    {
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
