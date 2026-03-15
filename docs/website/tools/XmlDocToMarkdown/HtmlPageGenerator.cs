using System.Text;
using Markdig;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates standalone HTML pages for each type, bypassing Vellum's taxonomy system.
/// These are complete HTML files that use the same CSS as the Vellum-generated site.
/// </summary>
public sealed class HtmlPageGenerator(string htmlOutputDir, string siteTitle)
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .Build();

    private string? _templateBefore;
    private string? _templateAfter;

    /// <summary>
    /// Loads the page template by splitting a Vellum-rendered reference page.
    /// The reference page is split at the inner content div, so we can inject
    /// our own sidebar + content while keeping the exact same head, header, footer, scripts.
    /// </summary>
    public void LoadTemplate(string referenceHtmlPath)
    {
        string html = File.ReadAllText(referenceHtmlPath);

        // Split at the layout-docs div — we'll provide our own
        int layoutDocsIndex = html.IndexOf("<div class=\"layout-docs", StringComparison.Ordinal);
        if (layoutDocsIndex < 0)
            throw new InvalidOperationException($"Could not find layout-docs div in {referenceHtmlPath}");

        _templateBefore = html[..layoutDocsIndex];

        // Find the closing </main></div> that ends the layout-docs section, then the footer
        int footerIndex = html.IndexOf("<footer class=\"site-footer\"", StringComparison.Ordinal);
        if (footerIndex < 0)
            throw new InvalidOperationException($"Could not find site-footer in {referenceHtmlPath}");

        _templateAfter = html[footerIndex..];

        Console.WriteLine($"  Template loaded from: {referenceHtmlPath}");
        Console.WriteLine($"    Before: {_templateBefore.Length} chars, After: {_templateAfter.Length} chars");
    }

    /// <summary>
    /// Generates one HTML file per type, placed flat in the output directory.
    /// File names use the pattern: {nsSlug}-{typeSlug}.html
    /// </summary>
    public void Generate(Dictionary<string, NamespaceInfo> namespaces)
    {
        Directory.CreateDirectory(htmlOutputDir);

        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                string fileBase = $"{nsSlug}-{typeSlug}";
                string htmlPath = Path.Combine(htmlOutputDir, fileBase + ".html");

                string markdownBody = GenerateTypeMarkdown(type, nsSlug, typeSlug);
                string bodyHtml = Markdig.Markdown.ToHtml(markdownBody, Pipeline);

                string fullHtml = BuildFullPage(
                    title: $"{type.Name} \u2014 {ns}",
                    bodyHtml: bodyHtml,
                    namespaces: namespaces,
                    currentNsSlug: nsSlug,
                    currentNsName: ns,
                    currentTypeFileBase: fileBase,
                    typeKind: type.Kind,
                    typeName: type.Name);

                File.WriteAllText(htmlPath, fullHtml);
                Console.WriteLine($"  Written: {htmlPath}");
            }
        }
    }

    /// <summary>
    /// Generates one HTML file per member group (method overloads, property, etc.).
    /// File names use: {nsSlug}-{typeSlug}.{memberSlug}.html
    /// </summary>
    public void GenerateMemberPages(Dictionary<string, NamespaceInfo> namespaces)
    {
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);

            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = MarkdownGenerator.TypeToSlug(type.Name);
                GenerateMemberPagesForType(namespaces, ns, nsSlug, type, typeSlug);
            }
        }
    }

    private void GenerateMemberPagesForType(
        Dictionary<string, NamespaceInfo> namespaces,
        string ns, string nsSlug, TypeInfo type, string typeSlug)
    {
        string typeFileBase = $"{nsSlug}-{typeSlug}";

        void EmitMemberPage(string memberDisplayName, string memberSlug, string category, List<MemberInfo> members)
        {
            string fileBase = MarkdownGenerator.GetMemberPageFileBase(nsSlug, typeSlug, memberSlug);
            string htmlPath = Path.Combine(htmlOutputDir, fileBase + ".html");

            StringBuilder sb = new();
            MarkdownGenerator.WriteMemberPageBody(sb, ns, nsSlug, type, typeSlug, memberDisplayName, category, members);
            string bodyHtml = Markdig.Markdown.ToHtml(sb.ToString(), Pipeline);

            string fullHtml = BuildMemberPage(
                title: $"{type.Name}.{memberDisplayName} {category}",
                bodyHtml: bodyHtml,
                namespaces: namespaces,
                ns: ns,
                nsSlug: nsSlug,
                type: type,
                typeSlug: typeSlug,
                typeFileBase: typeFileBase,
                memberFileBase: fileBase,
                memberDisplayName: memberDisplayName,
                memberCategory: category);

            File.WriteAllText(htmlPath, fullHtml);
        }

        // Constructors
        if (type.Constructors.Count > 0)
        {
            EmitMemberPage(type.Name, "ctor", "Constructor", type.Constructors);
        }

        // Properties (grouped by name — indexer overloads share one page)
        foreach (IGrouping<string, MemberInfo> group in type.Properties.GroupBy(p => p.GroupKey))
        {
            EmitMemberPage(group.First().Name, MarkdownGenerator.MemberToSlug(group.Key), "Property", group.ToList());
        }

        // Methods (grouped by name)
        foreach (IGrouping<string, MemberInfo> group in type.Methods.GroupBy(m => m.GroupKey))
        {
            EmitMemberPage(group.Key, MarkdownGenerator.MemberToSlug(group.Key), "Method", group.ToList());
        }

        // Operators (grouped by CLR name)
        foreach (IGrouping<string, MemberInfo> group in type.Operators.GroupBy(m => m.GroupKey))
        {
            string displayName = GetOperatorGroupDisplayName(group.Key);
            EmitMemberPage(displayName, MarkdownGenerator.MemberToSlug(group.Key), "Operator", group.ToList());
        }

        // Fields
        foreach (MemberInfo field in type.Fields)
        {
            EmitMemberPage(field.Name, MarkdownGenerator.MemberToSlug(field.GroupKey), "Field", [field]);
        }

        // Events
        foreach (MemberInfo evt in type.Events)
        {
            EmitMemberPage(evt.Name, MarkdownGenerator.MemberToSlug(evt.GroupKey), "Event", [evt]);
        }
    }

    private static string GetOperatorGroupDisplayName(string clrName) => clrName switch
    {
        "op_Implicit" => "Implicit",
        "op_Explicit" => "Explicit",
        _ => clrName.Replace("op_", ""),
    };

    private static string GenerateTypeMarkdown(TypeInfo type, string nsSlug, string typeSlug)
    {
        StringBuilder sb = new();
        MarkdownGenerator.WriteTypeBody(sb, type, nsSlug, typeSlug);
        return sb.ToString();
    }

    private string BuildMemberPage(
        string title,
        string bodyHtml,
        Dictionary<string, NamespaceInfo> namespaces,
        string ns,
        string nsSlug,
        TypeInfo type,
        string typeSlug,
        string typeFileBase,
        string memberFileBase,
        string memberDisplayName,
        string memberCategory)
    {
        StringBuilder sb = new();

        if (_templateBefore is not null)
        {
            string before = _templateBefore;
            before = System.Text.RegularExpressions.Regex.Replace(
                before,
                @"<title>[^<]*</title>",
                $"<title>{HtmlEncode(title)} \u2014 {HtmlEncode(siteTitle)}</title>");
            before = System.Text.RegularExpressions.Regex.Replace(
                before,
                @"<meta name=""description"" content=""[^""]*""",
                $"<meta name=\"description\" content=\"{HtmlEncode(memberCategory)} documentation for {HtmlEncode(type.Name)}.{HtmlEncode(memberDisplayName)}\"");
            sb.Append(before);
        }
        else
        {
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset=\"UTF-8\" />");
            sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />");
            sb.AppendLine($"    <title>{HtmlEncode(title)} \u2014 {HtmlEncode(siteTitle)}</title>");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"/main.css\" />");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
        }

        sb.AppendLine("<div class=\"layout-docs container\">");
        SidebarBuilder.AppendSidebar(sb, namespaces, nsSlug, typeFileBase, memberFileBase);
        sb.AppendLine("    <main id=\"main-content\" class=\"layout-docs__main\">");
        sb.AppendLine("        <div class=\"doc__content\">");
        sb.AppendLine("            <p class=\"doc__breadcrumb\">");
        sb.AppendLine($"                <a href=\"/api/index.html\">API</a> &rsaquo;");
        sb.AppendLine($"                <a href=\"/api/{nsSlug}.html\">{HtmlEncode(ns)}</a> &rsaquo;");
        sb.AppendLine($"                <a href=\"/api/{typeFileBase}.html\">{HtmlEncode(type.Name)}</a> &rsaquo;");
        sb.AppendLine($"                <span class=\"doc__kind-badge\">{HtmlEncode(memberCategory)}</span> {HtmlEncode(memberDisplayName)}");
        sb.AppendLine("            </p>");
        sb.AppendLine($"            <h1>{HtmlEncode(type.Name)}.{HtmlEncode(memberDisplayName)}</h1>");
        sb.AppendLine(bodyHtml);
        sb.AppendLine("        </div>");
        sb.AppendLine("    </main>");
        sb.AppendLine("</div>");

        if (_templateAfter is not null)
        {
            sb.Append(_templateAfter);
        }
        else
        {
            sb.AppendLine("<footer class=\"site-footer\">");
            sb.AppendLine("    <div class=\"site-footer__inner\">");
            sb.AppendLine("        <div class=\"site-footer__sponsor\">Sponsored by <a href=\"https://endjin.com\" target=\"_blank\">endjin</a></div>");
            sb.AppendLine("    </div>");
            sb.AppendLine("</footer>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
        }

        return sb.ToString();
    }

    private string BuildFullPage(
        string title,
        string bodyHtml,
        Dictionary<string, NamespaceInfo> namespaces,
        string currentNsSlug,
        string currentNsName,
        string currentTypeFileBase,
        string typeKind,
        string typeName)
    {
        StringBuilder sb = new();

        if (_templateBefore is not null)
        {
            // Use template-based rendering: inject our title into the head
            string before = _templateBefore;
            // Replace the <title> tag
            before = System.Text.RegularExpressions.Regex.Replace(
                before,
                @"<title>[^<]*</title>",
                $"<title>{HtmlEncode(title)} \u2014 {HtmlEncode(siteTitle)}</title>");
            // Replace meta description
            before = System.Text.RegularExpressions.Regex.Replace(
                before,
                @"<meta name=""description"" content=""[^""]*""",
                $"<meta name=\"description\" content=\"API documentation for {HtmlEncode(typeName)} in {HtmlEncode(currentNsName)}\"");
            sb.Append(before);
        }
        else
        {
            // Fallback: generate a self-contained page
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("    <meta charset=\"UTF-8\" />");
            sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />");
            sb.AppendLine("    <meta name=\"theme-color\" content=\"#1C1D21\" />");
            sb.AppendLine($"    <meta name=\"description\" content=\"API documentation for {HtmlEncode(typeName)} in {HtmlEncode(currentNsName)}\" />");
            sb.AppendLine($"    <title>{HtmlEncode(title)} \u2014 {HtmlEncode(siteTitle)}</title>");
            sb.AppendLine("    <link rel=\"preconnect\" href=\"https://fonts.googleapis.com\" />");
            sb.AppendLine("    <link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin />");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css2?family=Inter:wght@400;500&family=JetBrains+Mono:wght@400;500&display=swap\" />");
            sb.AppendLine("    <link rel=\"stylesheet\" href=\"/main.css\" />");
            sb.AppendLine("    <link rel=\"icon\" type=\"image/svg+xml\" href=\"/assets/images/favicon.svg\" />");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
        }

        // Main content with sidebar — hierarchical namespace → type navigation
        sb.AppendLine("<div class=\"layout-docs container\">");
        SidebarBuilder.AppendSidebar(sb, namespaces, currentNsSlug, currentTypeFileBase);
        sb.AppendLine("    <main id=\"main-content\" class=\"layout-docs__main\">");
        sb.AppendLine("        <div class=\"doc__content\">");
        sb.AppendLine("            <p class=\"doc__breadcrumb\">");
        sb.AppendLine($"                <a href=\"/api/index.html\">API</a> &rsaquo;");
        sb.AppendLine($"                <a href=\"/api/{currentNsSlug}.html\">{HtmlEncode(currentNsName)}</a> &rsaquo;");
        sb.AppendLine($"                <span class=\"doc__kind-badge\">{HtmlEncode(typeKind)}</span> {HtmlEncode(typeName)}");
        sb.AppendLine("            </p>");
        sb.AppendLine($"            <h1>{HtmlEncode(typeName)}</h1>");
        sb.AppendLine(bodyHtml);
        sb.AppendLine("        </div>");
        sb.AppendLine("    </main>");
        sb.AppendLine("</div>");

        if (_templateAfter is not null)
        {
            sb.Append(_templateAfter);
        }
        else
        {
            // Fallback footer + scripts
            sb.AppendLine("<footer class=\"site-footer\">");
            sb.AppendLine("    <div class=\"site-footer__inner\">");
            sb.AppendLine("        <div class=\"site-footer__sponsor\">Sponsored by <a href=\"https://endjin.com\" target=\"_blank\" rel=\"noopener noreferrer\">endjin</a></div>");
            sb.AppendLine($"        <p class=\"site-footer__copyright\">&copy; {DateTime.UtcNow.Year} endjin Ltd &amp; contributors. Released under the MIT License.</p>");
            sb.AppendLine("    </div>");
            sb.AppendLine("</footer>");
            sb.AppendLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/highlight.min.js\" defer></script>");
            sb.AppendLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/languages/csharp.min.js\" defer></script>");
            sb.AppendLine("<script>document.addEventListener('DOMContentLoaded',()=>hljs.highlightAll())</script>");
            sb.AppendLine("<script src=\"/assets/js/main.js\" defer></script>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
        }

        return sb.ToString();
    }

    private static string HtmlEncode(string value)
    {
        return value
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;");
    }
}
