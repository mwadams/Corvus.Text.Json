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
        // Build the list of all namespaces for the sidebar
        List<(string nsSlug, string nsName)> allNamespaces = namespaces
            .OrderBy(n => n.Key)
            .Select(n => (MarkdownGenerator.NamespaceToFileName(n.Key), n.Key))
            .ToList();

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                string viewPath = Path.Combine(viewsOutputDir, fileBase + ".cshtml");
                string content = BuildTypeView(allNamespaces, nsSlug, ns, type.Kind);
                File.WriteAllText(viewPath, content);
                Console.WriteLine($"  Written: {viewPath}");
            }
        }
    }

    private static string BuildTypeView(
        List<(string nsSlug, string nsName)> allNamespaces,
        string currentNsSlug,
        string currentNsName,
        string typeKind)
    {
        StringBuilder sb = new();
        sb.AppendLine("@model SiteViewModel");
        sb.AppendLine("@{");
        sb.AppendLine("    Layout = \"../Shared/_Layout.cshtml\";");
        sb.AppendLine("}");
        sb.AppendLine("<div class=\"layout-docs container\">");
        sb.AppendLine("    <aside class=\"sidebar\">");
        sb.AppendLine("        <div class=\"sidebar__section\">");
        sb.AppendLine("            <button class=\"sidebar__heading\">Namespaces</button>");
        sb.AppendLine("            <div class=\"sidebar__body\">");
        sb.AppendLine("                <ul class=\"sidebar__list\">");
        foreach ((string nsSlug, string nsName) in allNamespaces)
        {
            string activeClass = nsSlug == currentNsSlug ? " is-active" : "";
            sb.AppendLine($"                    <li class=\"sidebar__item\"><a class=\"sidebar__link{activeClass}\" href=\"/api/{nsSlug}.html\">{nsName}</a></li>");
        }

        sb.AppendLine("                </ul>");
        sb.AppendLine("            </div>");
        sb.AppendLine("        </div>");
        sb.AppendLine("    </aside>");
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