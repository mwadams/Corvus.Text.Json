using System.Text;
using System.Web;

namespace XmlDocToMarkdown;

/// <summary>
/// Builds the hierarchical API sidebar used by both the Vellum view generator
/// and the standalone HTML page generator. Matches the .NET reference docs
/// pattern: Namespace → Type → Member categories → Individual members.
/// </summary>
internal static class SidebarBuilder
{
    /// <summary>
    /// Appends the full hierarchical sidebar markup to <paramref name="sb"/>.
    /// Each namespace becomes a collapsible section; types are listed beneath
    /// the namespace. The active type expands to show its members grouped by
    /// category (Constructors, Properties, Methods, Operators, Fields, Events).
    /// </summary>
    public static void AppendSidebar(
        StringBuilder sb,
        Dictionary<string, NamespaceInfo> namespaces,
        string? currentNsSlug,
        string? currentTypeFileBase,
        string? currentMemberFileBase = null)
    {
        // Mobile toggle button and backdrop — matches the docs page structure
        sb.AppendLine("    <button class=\"sidebar-toggle\" aria-label=\"Toggle navigation\" aria-expanded=\"false\"></button>");
        sb.AppendLine("    <div class=\"sidebar-backdrop\"></div>");
        sb.AppendLine("    <aside class=\"sidebar\" data-has-member-nav>");
        sb.AppendLine("        <div class=\"sidebar__inner\">");

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);
            bool isCurrentNs = nsSlug == currentNsSlug;

            sb.AppendLine("            <div class=\"sidebar__section\">");
            sb.AppendLine($"                <button class=\"sidebar__heading{(isCurrentNs ? "" : " is-collapsed")}\">{HtmlEncode(ns)}</button>");
            sb.AppendLine($"                <div class=\"sidebar__body{(isCurrentNs ? "" : " is-collapsed")}\">");
            sb.AppendLine("                    <ul class=\"sidebar__list\">");

            // Namespace overview link
            string nsActive = (isCurrentNs && currentTypeFileBase is null) ? " is-active" : "";
            sb.AppendLine($"                        <li class=\"sidebar__item\"><a class=\"sidebar__link{nsActive}\" href=\"/api/{nsSlug}.html\"><strong>Overview</strong></a></li>");

            // Type links — active type expands to show members
            foreach (TypeInfo type in kvp.Value.Types.OrderBy(t => t.Name))
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                bool isActiveType = fileBase == currentTypeFileBase;

                // Type link: on the type page it's is-active; on a member page
                // it's is-current (visually highlighted but not "active")
                string typeClass = isActiveType
                    ? (currentMemberFileBase is null ? " is-active" : " is-current")
                    : "";
                sb.AppendLine($"                        <li class=\"sidebar__item\">");
                sb.AppendLine($"                            <a class=\"sidebar__link sidebar__link--type{typeClass}\" href=\"/api/{fileBase}.html\">{HtmlEncode(type.Name)}</a>");

                // Expand member tree for the active type
                if (isActiveType)
                {
                    AppendMemberTree(sb, type, nsSlug, typeSlug, currentMemberFileBase);
                }

                sb.AppendLine($"                        </li>");
            }

            sb.AppendLine("                    </ul>");
            sb.AppendLine("                </div>");
            sb.AppendLine("            </div>");
        }

        sb.AppendLine("        </div>");
        sb.AppendLine("    </aside>");
    }

    /// <summary>
    /// Renders the member sub-tree for a type: category headers with
    /// individual member links beneath each.
    /// </summary>
    private static void AppendMemberTree(
        StringBuilder sb,
        TypeInfo type,
        string nsSlug,
        string typeSlug,
        string? currentMemberFileBase)
    {
        sb.AppendLine("                            <ul class=\"sidebar__members\">");

        // Constructors
        if (type.Constructors.Count > 0)
        {
            string ctorFileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, "ctor");
            string ctorActive = ctorFileBase == currentMemberFileBase ? " is-active" : "";
            sb.AppendLine("                                <li class=\"sidebar__category\">Constructors</li>");
            sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{ctorActive}\" href=\"/api/{ctorFileBase}.html\">{HtmlEncode(type.Constructors[0].Name)}(…)</a></li>");
        }

        // Properties (one entry per overload group — indexers share a name)
        if (type.Properties.Count > 0)
        {
            sb.AppendLine("                                <li class=\"sidebar__category\">Properties</li>");
            foreach (IGrouping<string, MemberInfo> group in type.Properties.GroupBy(p => p.GroupKey).OrderBy(g => g.Key))
            {
                string memberSlug = MarkdownGenerator.MemberToSlug(group.Key);
                string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
                string active = fileBase == currentMemberFileBase ? " is-active" : "";
                // For indexers (multiple overloads sharing "Item"), show "Item[]"
                string displayName = group.Count() > 1 && group.Key == "Item" ? "Item[]" : group.First().Name;
                sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{active}\" href=\"/api/{fileBase}.html\">{HtmlEncode(displayName)}</a></li>");
            }
        }

        // Methods (one entry per overload group)
        if (type.Methods.Count > 0)
        {
            sb.AppendLine("                                <li class=\"sidebar__category\">Methods</li>");
            foreach (IGrouping<string, MemberInfo> group in type.Methods.GroupBy(m => m.GroupKey).OrderBy(g => g.Key))
            {
                string memberSlug = MarkdownGenerator.MemberToSlug(group.Key);
                string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
                string active = fileBase == currentMemberFileBase ? " is-active" : "";
                sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{active}\" href=\"/api/{fileBase}.html\">{HtmlEncode(group.Key)}</a></li>");
            }
        }

        // Operators (one entry per operator kind)
        if (type.Operators.Count > 0)
        {
            sb.AppendLine("                                <li class=\"sidebar__category\">Operators</li>");
            foreach (IGrouping<string, MemberInfo> group in type.Operators.GroupBy(m => m.GroupKey).OrderBy(g => g.Key))
            {
                string memberSlug = MarkdownGenerator.MemberToSlug(group.Key);
                string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
                string active = fileBase == currentMemberFileBase ? " is-active" : "";
                string displayName = GetOperatorGroupDisplayName(group.Key);
                sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{active}\" href=\"/api/{fileBase}.html\">{HtmlEncode(displayName)}</a></li>");
            }
        }

        // Fields
        if (type.Fields.Count > 0)
        {
            sb.AppendLine("                                <li class=\"sidebar__category\">Fields</li>");
            foreach (MemberInfo field in type.Fields.OrderBy(f => f.Name))
            {
                string memberSlug = MarkdownGenerator.MemberToSlug(field.GroupKey);
                string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
                string active = fileBase == currentMemberFileBase ? " is-active" : "";
                sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{active}\" href=\"/api/{fileBase}.html\">{HtmlEncode(field.Name)}</a></li>");
            }
        }

        // Events
        if (type.Events.Count > 0)
        {
            sb.AppendLine("                                <li class=\"sidebar__category\">Events</li>");
            foreach (MemberInfo evt in type.Events.OrderBy(e => e.Name))
            {
                string memberSlug = MarkdownGenerator.MemberToSlug(evt.GroupKey);
                string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
                string active = fileBase == currentMemberFileBase ? " is-active" : "";
                sb.AppendLine($"                                <li class=\"sidebar__member\"><a class=\"sidebar__link sidebar__link--member{active}\" href=\"/api/{fileBase}.html\">{HtmlEncode(evt.Name)}</a></li>");
            }
        }

        sb.AppendLine("                            </ul>");
    }

    private static string GetOperatorGroupDisplayName(string clrName) => clrName switch
    {
        "op_Implicit" => "Implicit",
        "op_Explicit" => "Explicit",
        _ => clrName.Replace("op_", ""),
    };

    /// <summary>
    /// Builds the sidebar as a self-contained HTML string (for embedding in Razor views).
    /// </summary>
    public static string Build(
        Dictionary<string, NamespaceInfo> namespaces,
        string? currentNsSlug = null,
        string? currentTypeFileBase = null,
        string? currentMemberFileBase = null)
    {
        StringBuilder sb = new();
        AppendSidebar(sb, namespaces, currentNsSlug, currentTypeFileBase, currentMemberFileBase);
        return sb.ToString();
    }

    private static string HtmlEncode(string text) => HttpUtility.HtmlEncode(text);
}
