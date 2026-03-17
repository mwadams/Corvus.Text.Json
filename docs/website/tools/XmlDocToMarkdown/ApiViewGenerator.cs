using System.Text;
using System.Web;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates the Razor view for the API landing page with a hierarchical sidebar.
/// </summary>
internal static class ApiViewGenerator
{
    /// <summary>
    /// Writes <c>api/index.cshtml</c> — the API landing page with a hierarchical
    /// namespace sidebar and namespace cards in the main content area.
    /// </summary>
    public static void GenerateIndexView(string viewsDir, Dictionary<string, NamespaceInfo> namespaces, string baseUrl, string? nsDescriptionsDir = null)
    {
        StringBuilder sb = new();

        sb.AppendLine("@model SiteViewModel");
        sb.AppendLine("@{");
        sb.AppendLine("    Layout = \"../Shared/_Layout.cshtml\";");
        sb.AppendLine("}");
        sb.AppendLine("<div class=\"layout-docs container\">");

        // Use the shared sidebar partial (generated separately)
        sb.AppendLine("    @await Html.PartialAsync(\"_ApiSidebar\").ConfigureAwait(false)");

        sb.AppendLine("    <main id=\"main-content\" class=\"layout-docs__main\">");
        sb.AppendLine("        <div class=\"doc__content\">");
        sb.AppendLine("            <h1>API Reference</h1>");
        sb.AppendLine("            <p>Browse the public API by namespace. Each namespace section in the sidebar lists its types.</p>");

        // Search / filter UI
        sb.AppendLine("            <div class=\"api-browser\">");
        sb.AppendLine("                <input id=\"api-browser-input\" class=\"api-browser__input\" type=\"search\"");
        sb.AppendLine("                       placeholder=\"Search types and members\u2026\" autocomplete=\"off\" />");
        sb.AppendLine("                <div id=\"api-browser-status\" class=\"api-browser__status\"></div>");
        sb.AppendLine("            </div>");
        sb.AppendLine("            <div id=\"api-browser-results\" class=\"api-browser__results\" hidden></div>");

        sb.AppendLine("            <div id=\"api-browser-default\" class=\"card-grid\" style=\"margin-top:var(--space-lg)\">");

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);
            int typeCount = kvp.Value.Types.Count;
            string description = GetNamespaceDescription(ns, nsDescriptionsDir);

            sb.AppendLine($"                <a class=\"card card--link\" href=\"{baseUrl}/{nsSlug}.html\">");
            sb.AppendLine($"                    <h3 class=\"card__title\">{HttpUtility.HtmlEncode(ns)}</h3>");
            sb.AppendLine($"                    <p class=\"card__body\">{HttpUtility.HtmlEncode(description)}</p>");
            sb.AppendLine($"                    <div class=\"card__meta\"><span class=\"card__tag\">{typeCount} type{(typeCount == 1 ? "" : "s")}</span></div>");
            sb.AppendLine("                </a>");
        }

        sb.AppendLine("            </div>");
        sb.AppendLine("        </div>");
        sb.AppendLine("    </main>");
        sb.AppendLine("</div>");
        sb.AppendLine("@section scripts {");
        sb.AppendLine("    <script src=\"/assets/js/api-browser.js\" defer></script>");
        sb.AppendLine("}");

        string outputPath = Path.Combine(viewsDir, "index.cshtml");
        File.WriteAllText(outputPath, sb.ToString());
        Console.WriteLine($"  Written: {outputPath}");
    }

    /// <summary>
    /// Generates the <c>_ApiSidebar.cshtml</c> Razor partial containing the
    /// hierarchical API sidebar tree. This is referenced by the static
    /// <c>api-page.cshtml</c> view via <c>Html.PartialAsync("_ApiSidebar")</c>.
    /// </summary>
    public static void GenerateApiSidebar(string sharedViewsDir, Dictionary<string, NamespaceInfo> namespaces, string baseUrl)
    {
        StringBuilder sb = new();

        // Sidebar with no active state — JS sets active link based on URL
        SidebarBuilder.AppendSidebar(sb, namespaces, currentNsSlug: null, currentTypeFileBase: null, baseUrl);

        string outputPath = Path.Combine(sharedViewsDir, "_ApiSidebar.cshtml");
        File.WriteAllText(outputPath, sb.ToString());
        Console.WriteLine($"  Written: {outputPath}");
    }

    internal static string GetNamespaceDescription(string ns, string? nsDescriptionsDir)
    {
        if (nsDescriptionsDir is not null)
        {
            string descPath = Path.Combine(nsDescriptionsDir, ns + ".md");
            if (File.Exists(descPath))
            {
                string content = File.ReadAllText(descPath).Trim();
                // Extract first sentence as short description
                int dotIdx = content.IndexOf(". ", StringComparison.Ordinal);
                if (dotIdx >= 0 && dotIdx < 200)
                {
                    return content[..(dotIdx + 1)];
                }
                // If no period found, use first line truncated
                int newlineIdx = content.IndexOfAny(['\r', '\n']);
                if (newlineIdx >= 0)
                {
                    content = content[..newlineIdx];
                }
                return content.Length > 200 ? content[..197] + "..." : content;
            }
        }

        // Fallback for unknown namespaces
        return $"Types in the {ns} namespace";
    }
}
