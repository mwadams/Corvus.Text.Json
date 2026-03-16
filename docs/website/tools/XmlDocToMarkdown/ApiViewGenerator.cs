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
    public static void GenerateIndexView(string viewsDir, Dictionary<string, NamespaceInfo> namespaces)
    {
        StringBuilder sb = new();

        sb.AppendLine("@model SiteViewModel");
        sb.AppendLine("@{");
        sb.AppendLine("    Layout = \"../Shared/_Layout.cshtml\";");
        sb.AppendLine("}");
        sb.AppendLine("<div class=\"layout-docs container\">");

        // Hierarchical sidebar — no type highlighted, no namespace highlighted (landing page)
        SidebarBuilder.AppendSidebar(sb, namespaces, currentNsSlug: null, currentTypeFileBase: null);

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
            string description = GetNamespaceDescription(ns);

            sb.AppendLine($"                <a class=\"card card--link\" href=\"/api/{nsSlug}.html\">");
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
    /// Writes one <c>{ns-slug}.cshtml</c> per namespace — the namespace overview pages
    /// with the hierarchical sidebar (current namespace expanded, "Overview" highlighted).
    /// </summary>
    public static void GenerateNamespaceViews(string viewsDir, Dictionary<string, NamespaceInfo> namespaces)
    {
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            StringBuilder sb = new();
            sb.AppendLine("@model SiteViewModel");
            sb.AppendLine("@{");
            sb.AppendLine("    Layout = \"../Shared/_Layout.cshtml\";");
            sb.AppendLine("}");
            sb.AppendLine("<div class=\"layout-docs container\">");

            // Hierarchical sidebar — current namespace expanded, "Overview" link active
            SidebarBuilder.AppendSidebar(sb, namespaces, currentNsSlug: nsSlug, currentTypeFileBase: null);

            sb.AppendLine("    <main id=\"main-content\" class=\"layout-docs__main\">");
            sb.AppendLine("        <div class=\"doc__content\">");
            sb.AppendLine("            <h1>@Model.PageContext.Title</h1>");
            sb.AppendLine("            @foreach (var contentFragment in Model.PageContext.GetAllMarkdownContent())");
            sb.AppendLine("            {");
            sb.AppendLine("                @Html.Raw(contentFragment.Body)");
            sb.AppendLine("            }");
            sb.AppendLine("        </div>");
            sb.AppendLine("    </main>");
            sb.AppendLine("</div>");

            string outputPath = Path.Combine(viewsDir, nsSlug + ".cshtml");
            File.WriteAllText(outputPath, sb.ToString());
            Console.WriteLine($"  Written: {outputPath}");
        }
    }

    private static string GetNamespaceDescription(string ns) => ns switch
    {
        "Corvus.Text.Json" => "Core public API \u2014 JsonElement, ParsedJsonDocument, JsonDocumentBuilder, JsonWorkspace, and more",
        "Corvus.Text.Json.Internal" => "Internal helpers, enumerators, and metadata types",
        "Corvus.Numerics" => "BigNumber and BigInteger arbitrary-precision numeric types",
        "Corvus.Text.Json.Compatibility" => "System.Text.Json interop and compatibility types",
        "Corvus.Globalization" => "Globalization helpers and culture-sensitive formatting",
        "Corvus.Runtime.InteropServices" => "Low-level memory and interop utilities",
        _ => $"Types in the {ns} namespace",
    };
}
