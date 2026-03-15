using System.Text;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates Vellum taxonomy YAML files for each namespace page.
/// </summary>
public sealed class TaxonomyGenerator(string taxonomyOutputDir, string contentOutputDir)
{
    public void Generate(Dictionary<string, NamespaceInfo> namespaces)
    {
        int rank = 1;
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string fileName = MarkdownGenerator.NamespaceToFileName(ns);
            string yamlPath = Path.Combine(taxonomyOutputDir, fileName + ".yml");

            // Compute the relative path from taxonomy to content
            string taxonomyDir = Path.GetFullPath(taxonomyOutputDir);
            string contentDir = Path.GetFullPath(contentOutputDir);
            string relativePath = Path.GetRelativePath(taxonomyDir, contentDir).Replace('\\', '/');
            string contentRelativePath = $"{relativePath}/{fileName}.md";

            StringBuilder sb = new();
            sb.AppendLine($"ContentType: application/vnd.endjin.ssg.page+yaml");
            sb.AppendLine($"Title: \"{EscapeYaml(ns)} Namespace\"");
            sb.AppendLine($"Navigation:");
            sb.AppendLine($"  Title: {ns}");
            sb.AppendLine($"  Description: \"API reference for the {ns} namespace\"");
            sb.AppendLine($"  Parent: /api");
            sb.AppendLine($"  Url: /api/{fileName}.html");
            sb.AppendLine($"  Rank: {rank}");
            sb.AppendLine($"MetaData:");
            sb.AppendLine($"  Title: \"{EscapeYaml(ns)} Namespace — API Reference\"");
            sb.AppendLine($"  Description: \"API documentation for the {ns} namespace\"");
            sb.AppendLine($"  Keywords: [API, reference, {ns}]");
            sb.AppendLine($"OpenGraph:");
            sb.AppendLine($"  Title: \"{EscapeYaml(ns)} Namespace\"");
            sb.AppendLine($"  Description: \"API reference for the {ns} namespace\"");
            sb.AppendLine($"  Image:");
            sb.AppendLine($"ContentBlocks:");
            sb.AppendLine($"  - ContentType: application/vnd.endjin.ssg.content+md");
            sb.AppendLine($"    Spec:");
            sb.AppendLine($"      Path: {contentRelativePath}");

            File.WriteAllText(yamlPath, sb.ToString());
            Console.WriteLine($"  Written: {yamlPath}");

            rank++;
        }
    }

    public void GeneratePerType(Dictionary<string, NamespaceInfo> namespaces)
    {
        string taxonomyDir = Path.GetFullPath(taxonomyOutputDir);
        string contentDir = Path.GetFullPath(contentOutputDir);
        string relativePath = Path.GetRelativePath(taxonomyDir, contentDir).Replace('\\', '/');

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            int rank = 1;
            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                string yamlPath = Path.Combine(taxonomyOutputDir, fileBase + ".yml");
                string contentRelativePath = $"{relativePath}/{fileBase}.md";

                string summary = type.Documentation?.Summary ?? $"{type.Name} {type.Kind}";
                if (summary.Length > 200) summary = summary[..197] + "...";

                StringBuilder sb = new();
                sb.AppendLine($"ContentType: application/vnd.endjin.ssg.page+yaml");
                sb.AppendLine($"Title: \"{EscapeYaml(type.Name)}\"");
                sb.AppendLine($"Navigation:");
                sb.AppendLine($"  Title: \"{EscapeYaml(type.Name)}\"");
                sb.AppendLine($"  Description: \"{EscapeYaml(summary)}\"");
                sb.AppendLine($"  Parent: /api");
                sb.AppendLine($"  Url: /api/{fileBase}.html");
                sb.AppendLine($"  Rank: {100 + rank}");
                sb.AppendLine($"MetaData:");
                sb.AppendLine($"  Title: \"{EscapeYaml(type.Name)} \u2014 {ns}\"");
                sb.AppendLine($"  Description: \"API documentation for {EscapeYaml(type.Name)} in {ns}\"");
                sb.AppendLine($"  Keywords: [API, {type.Kind}, \"{EscapeYaml(type.Name)}\", {ns}]");
                sb.AppendLine($"OpenGraph:");
                sb.AppendLine($"  Title: \"{EscapeYaml(type.Name)} \u2014 {ns}\"");
                sb.AppendLine($"  Description: \"API documentation for {EscapeYaml(type.Name)}\"");
                sb.AppendLine($"  Image:");
                sb.AppendLine($"ContentBlocks:");
                sb.AppendLine($"  - ContentType: application/vnd.endjin.ssg.content+md");
                sb.AppendLine($"    Spec:");
                sb.AppendLine($"      Path: {contentRelativePath}");

                File.WriteAllText(yamlPath, sb.ToString());
                Console.WriteLine($"  Written: {yamlPath}");
                rank++;
            }
        }
    }

    private static string EscapeYaml(string value)
    {
        return value
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\n", " ")
            .Replace("\r", "");
    }
}
