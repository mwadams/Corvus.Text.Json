using System.Text;
using Markdig;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates standalone HTML pages for each type, bypassing Vellum's taxonomy system.
/// These are complete HTML files that use the same CSS as the Vellum-generated site.
/// </summary>
public sealed class HtmlPageGenerator(string htmlOutputDir, string siteTitle, SourceLinkResolver? sourceResolver = null)
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
                    typeName: type.Name,
                    typeFullName: type.FullName);

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
                memberCategory: category,
                members: members);

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
        string memberCategory,
        List<MemberInfo> members)
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

        if (members.Count == 1)
        {
            // Single member: source link right after h1
            AppendSourceLink(sb, sourceResolver?.GetMemberSourceUrl(members[0].XmlDocKey));
            sb.AppendLine(bodyHtml);
        }
        else
        {
            // Multiple overloads: inject per-overload source links into the body HTML
            sb.AppendLine(InjectPerOverloadSourceLinks(bodyHtml, members));
        }
        sb.AppendLine("        </div>");
        AppendFeedbackSection(sb);
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
        string typeName,
        string typeFullName)
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
        AppendSourceLink(sb, sourceResolver?.GetTypeSourceUrl(typeFullName));
        sb.AppendLine(bodyHtml);
        sb.AppendLine("        </div>");
        AppendFeedbackSection(sb);
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

    private static void AppendSourceLink(StringBuilder sb, string? sourceUrl)
    {
        if (sourceUrl is null)
        {
            return;
        }

        sb.AppendLine($"            <p class=\"api-source\">Source: <a href=\"{HtmlEncode(sourceUrl)}\" target=\"_blank\" rel=\"noopener noreferrer\">{HtmlEncode(GetSourceDisplayPath(sourceUrl))}</a></p>");
    }

    private static string BuildSourceLinkHtml(string sourceUrl)
    {
        return $"<p class=\"api-source\">Source: <a href=\"{HtmlEncode(sourceUrl)}\" target=\"_blank\" rel=\"noopener noreferrer\">{HtmlEncode(GetSourceDisplayPath(sourceUrl))}</a></p>";
    }

    /// <summary>
    /// For pages with multiple overloads, injects a source link after each overload's
    /// heading (the h2 tags that follow the Overloads summary table).
    /// Overloads are matched to members by position.
    /// </summary>
    private string InjectPerOverloadSourceLinks(string bodyHtml, List<MemberInfo> members)
    {
        if (sourceResolver is null)
        {
            return bodyHtml;
        }

        // Find the overloads heading marker
        const string overloadsHeading = "<h2 id=\"overloads\">";
        int overloadsIdx = bodyHtml.IndexOf(overloadsHeading, StringComparison.OrdinalIgnoreCase);
        if (overloadsIdx < 0)
        {
            return bodyHtml;
        }

        // Work through the HTML after the overloads heading, injecting source links
        // after each subsequent <h2> tag (each represents one overload)
        StringBuilder result = new(bodyHtml.Length + members.Count * 200);
        result.Append(bodyHtml[..overloadsIdx]);

        string remaining = bodyHtml[overloadsIdx..];
        int memberIdx = 0;
        int searchFrom = 0;

        // Skip the "Overloads" heading itself
        int firstH2End = remaining.IndexOf("</h2>", searchFrom, StringComparison.OrdinalIgnoreCase);
        if (firstH2End >= 0)
        {
            firstH2End += "</h2>".Length;
            result.Append(remaining[..firstH2End]);
            searchFrom = firstH2End;
        }

        // Now find each subsequent <h2> (one per overload)
        while (searchFrom < remaining.Length)
        {
            int nextH2 = remaining.IndexOf("<h2 ", searchFrom, StringComparison.OrdinalIgnoreCase);
            if (nextH2 < 0)
            {
                nextH2 = remaining.IndexOf("<h2>", searchFrom, StringComparison.OrdinalIgnoreCase);
            }

            if (nextH2 < 0)
            {
                // No more h2 tags — append the rest
                result.Append(remaining[searchFrom..]);
                break;
            }

            // Find the closing </h2>
            int h2End = remaining.IndexOf("</h2>", nextH2, StringComparison.OrdinalIgnoreCase);
            if (h2End < 0)
            {
                result.Append(remaining[searchFrom..]);
                break;
            }

            h2End += "</h2>".Length;

            // Append everything up to and including this </h2>
            result.Append(remaining[searchFrom..h2End]);

            // Inject source link for this overload
            if (memberIdx < members.Count)
            {
                string? url = sourceResolver.GetMemberSourceUrl(members[memberIdx].XmlDocKey);
                if (url is not null)
                {
                    result.AppendLine();
                    result.Append(BuildSourceLinkHtml(url));
                }

                memberIdx++;
            }

            searchFrom = h2End;
        }

        return result.ToString();
    }

    private static string GetSourceDisplayPath(string url)
    {
        // Extract just the file name from a GitHub blob URL like:
        // https://github.com/.../blob/main/src/.../JsonElement.cs#L42
        // Display text should be just "JsonElement.cs" (matching .NET reference docs style)
        int hashIdx = url.IndexOf('#');
        string urlWithoutFragment = hashIdx >= 0 ? url[..hashIdx] : url;
        int lastSlash = urlWithoutFragment.LastIndexOf('/');
        return lastSlash >= 0 ? urlWithoutFragment[(lastSlash + 1)..] : urlWithoutFragment;
    }

    private static void AppendFeedbackSection(StringBuilder sb)
    {
        sb.AppendLine("        <div class=\"api-feedback\">");
        sb.AppendLine("            <div class=\"api-feedback__inner\">");
        sb.AppendLine("                <img src=\"/assets/images/logo-corvus.svg\" alt=\"Corvus\" class=\"api-feedback__logo\" />");
        sb.AppendLine("                <div class=\"api-feedback__text\">");
        sb.AppendLine("                    <h3>Collaborate with us on GitHub</h3>");
        sb.AppendLine("                    <p>The source for this content can be found on <a href=\"https://github.com/mwadams/Corvus.Text.Json\" target=\"_blank\" rel=\"noopener noreferrer\">GitHub</a>, where you can also create and review issues and pull requests.</p>");
        sb.AppendLine("                    <a class=\"api-feedback__link\" href=\"https://github.com/mwadams/Corvus.Text.Json/issues/new\" target=\"_blank\" rel=\"noopener noreferrer\">");
        sb.AppendLine("                        <svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 16 16\" width=\"16\" height=\"16\" fill=\"currentColor\"><path d=\"M8 0c4.42 0 8 3.58 8 8a8.013 8.013 0 0 1-5.45 7.59c-.4.08-.55-.17-.55-.38 0-.27.01-1.13.01-2.2 0-.75-.25-1.23-.54-1.48 1.78-.2 3.65-.88 3.65-3.95 0-.88-.31-1.59-.82-2.15.08-.2.36-1.02-.08-2.12 0 0-.67-.22-2.2.82-.64-.18-1.32-.27-2-.27-.68 0-1.36.09-2 .27-1.53-1.03-2.2-.82-2.2-.82-.44 1.1-.16 1.92-.08 2.12-.51.56-.82 1.28-.82 2.15 0 3.06 1.86 3.75 3.64 3.95-.23.2-.44.55-.51 1.07-.46.21-1.61.55-2.33-.66-.15-.24-.6-.83-1.23-.82-.67.01-.27.38.01.53.34.19.73.9.82 1.13.16.45.68 1.31 2.69.94 0 .67.01 1.3.01 1.49 0 .21-.15.45-.55.38A7.995 7.995 0 0 1 0 8c0-4.42 3.58-8 8-8Z\"/></svg>");
        sb.AppendLine("                        Open an issue");
        sb.AppendLine("                    </a>");
        sb.AppendLine("                </div>");
        sb.AppendLine("            </div>");
        sb.AppendLine("        </div>");
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
