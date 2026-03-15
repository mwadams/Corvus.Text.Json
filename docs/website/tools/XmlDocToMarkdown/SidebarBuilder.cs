using System.Text;
using System.Web;

namespace XmlDocToMarkdown;

/// <summary>
/// Builds the hierarchical API sidebar used by both the Vellum view generator
/// and the standalone HTML page generator.
/// </summary>
internal static class SidebarBuilder
{
    /// <summary>
    /// Appends the full hierarchical sidebar markup to <paramref name="sb"/>.
    /// Each namespace becomes a collapsible section; types are listed beneath
    /// the namespace they belong to, with the current type/namespace highlighted.
    /// </summary>
    public static void AppendSidebar(
        StringBuilder sb,
        Dictionary<string, NamespaceInfo> namespaces,
        string? currentNsSlug,
        string? currentTypeFileBase)
    {
        sb.AppendLine("    <aside class=\"sidebar\">");

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);
            bool isCurrentNs = nsSlug == currentNsSlug;

            sb.AppendLine("        <div class=\"sidebar__section\">");
            sb.AppendLine($"            <button class=\"sidebar__heading{(isCurrentNs ? "" : " is-collapsed")}\">{HtmlEncode(ns)}</button>");
            sb.AppendLine($"            <div class=\"sidebar__body{(isCurrentNs ? "" : " is-collapsed")}\">");
            sb.AppendLine("                <ul class=\"sidebar__list\">");

            // Namespace link
            string nsActive = (isCurrentNs && currentTypeFileBase is null) ? " is-active" : "";
            sb.AppendLine($"                    <li class=\"sidebar__item\"><a class=\"sidebar__link{nsActive}\" href=\"/api/{nsSlug}.html\"><strong>Overview</strong></a></li>");

            // Type links
            foreach (TypeInfo type in kvp.Value.Types.OrderBy(t => t.Name))
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                string typeActive = fileBase == currentTypeFileBase ? " is-active" : "";
                sb.AppendLine($"                    <li class=\"sidebar__item\"><a class=\"sidebar__link sidebar__link--toc{typeActive}\" href=\"/api/{fileBase}.html\">{HtmlEncode(type.Name)}</a></li>");
            }

            sb.AppendLine("                </ul>");
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
        }

        sb.AppendLine("    </aside>");
    }

    /// <summary>
    /// Builds the sidebar as a self-contained HTML string (for embedding in Razor views).
    /// </summary>
    public static string Build(
        Dictionary<string, NamespaceInfo> namespaces,
        string? currentNsSlug = null,
        string? currentTypeFileBase = null)
    {
        StringBuilder sb = new();
        AppendSidebar(sb, namespaces, currentNsSlug, currentTypeFileBase);
        return sb.ToString();
    }

    private static string HtmlEncode(string text) => HttpUtility.HtmlEncode(text);
}
