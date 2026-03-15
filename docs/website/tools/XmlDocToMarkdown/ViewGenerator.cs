using System.Text;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates Vellum Razor view (.cshtml) stubs for each per-type API page.
/// </summary>
public sealed class ViewGenerator(string viewsOutputDir)
{
    /// <summary>
    /// Generates one .cshtml view file per type in subdirectories per namespace.
    /// All views share the same template; only the file path differs.
    /// </summary>
    public void Generate(Dictionary<string, NamespaceInfo> namespaces)
    {
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                string viewPath = Path.Combine(viewsOutputDir, fileBase + ".cshtml");
                string content = BuildTypeView(namespaces, nsSlug, ns, fileBase, type.Kind);
                File.WriteAllText(viewPath, content);
                Console.WriteLine($"  Written: {viewPath}");
            }
        }
    }

    private static string BuildTypeView(
        Dictionary<string, NamespaceInfo> namespaces,
        string currentNsSlug,
        string currentNsName,
        string currentTypeFileBase,
        string typeKind)
    {
        StringBuilder sb = new();
        sb.AppendLine("@model SiteViewModel");
        sb.AppendLine("@{");
        sb.AppendLine("    Layout = \"../Shared/_Layout.cshtml\";");
        sb.AppendLine("}");
        sb.AppendLine("<div class=\"layout-docs container\">");
        SidebarBuilder.AppendSidebar(sb, namespaces, currentNsSlug, currentTypeFileBase);
        sb.AppendLine("    <main id=\"main-content\" class=\"layout-docs__main\">");
        sb.AppendLine("        <div class=\"doc__content\">");
        sb.AppendLine("            <p class=\"doc__breadcrumb\">");
        sb.AppendLine($"                <a href=\"/api/index.html\">API</a> &rsaquo;");
        sb.AppendLine($"                <a href=\"/api/{currentNsSlug}.html\">{currentNsName}</a> &rsaquo;");
        sb.AppendLine($"                <span class=\"doc__kind-badge\">{typeKind}</span>");
        sb.AppendLine("            </p>");
        sb.AppendLine("            <h1>@Model.PageContext.Title</h1>");
        sb.AppendLine("            @foreach (var contentFragment in Model.PageContext.GetAllMarkdownContent())");
        sb.AppendLine("            {");
        sb.AppendLine("                @Html.Raw(contentFragment.Body)");
        sb.AppendLine("            }");
        sb.AppendLine("        </div>");
        sb.AppendLine("    </main>");
        sb.AppendLine("</div>");

        return sb.ToString();
    }
}