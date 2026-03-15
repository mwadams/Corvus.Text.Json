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

                string markdownBody = GenerateTypeMarkdown(type);
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

    private static string GenerateTypeMarkdown(TypeInfo type)
    {
        StringBuilder sb = new();

        // Type declaration
        sb.AppendLine("```csharp");
        sb.AppendLine(BuildTypeDeclaration(type));
        sb.AppendLine("```");
        sb.AppendLine();

        if (!string.IsNullOrEmpty(type.Documentation?.Summary))
        {
            sb.AppendLine(type.Documentation!.Summary);
            sb.AppendLine();
        }

        if (type.GenericParameters.Count > 0 && type.Documentation?.TypeParams.Count > 0)
        {
            sb.AppendLine("## Type Parameters");
            sb.AppendLine();
            sb.AppendLine("| Parameter | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocParam tp in type.Documentation!.TypeParams)
                sb.AppendLine($"| `{tp.Name}` | {tp.Description} |");
            sb.AppendLine();
        }

        if (!string.IsNullOrEmpty(type.Documentation?.Remarks))
        {
            sb.AppendLine("## Remarks");
            sb.AppendLine();
            sb.AppendLine(type.Documentation!.Remarks);
            sb.AppendLine();
        }

        if (type.BaseType is not null || type.Interfaces.Count > 0)
        {
            sb.AppendLine("## Inheritance");
            sb.AppendLine();
            if (type.BaseType is not null)
                sb.AppendLine($"- Inherits from: `{type.BaseType}`");
            foreach (string iface in type.Interfaces)
                sb.AppendLine($"- Implements: `{iface}`");
            sb.AppendLine();
        }

        if (type.Constructors.Count > 0)
        {
            sb.AppendLine("## Constructors");
            sb.AppendLine();
            foreach (MemberInfo ctor in type.Constructors)
                WriteMemberSection(sb, ctor, 3);
        }

        if (type.Properties.Count > 0)
        {
            sb.AppendLine("## Properties");
            sb.AppendLine();
            sb.AppendLine("| Property | Type | Description |");
            sb.AppendLine("|----------|------|-------------|");
            foreach (MemberInfo prop in type.Properties)
            {
                string summary = TruncateSummary(prop.Documentation?.Summary ?? string.Empty);
                string staticBadge = prop.IsStatic ? " `static`" : "";
                sb.AppendLine($"| `{prop.Name}`{staticBadge} | `{prop.ReturnType}` | {summary} |");
            }
            sb.AppendLine();

            foreach (MemberInfo prop in type.Properties)
            {
                if (!string.IsNullOrEmpty(prop.Documentation?.Remarks) || !string.IsNullOrEmpty(prop.Documentation?.Value))
                {
                    sb.AppendLine($"### {prop.Name}");
                    sb.AppendLine();
                    sb.AppendLine("```csharp");
                    sb.AppendLine(prop.Signature);
                    sb.AppendLine("```");
                    sb.AppendLine();
                    if (!string.IsNullOrEmpty(prop.Documentation?.Summary))
                    {
                        sb.AppendLine(prop.Documentation!.Summary);
                        sb.AppendLine();
                    }
                    if (!string.IsNullOrEmpty(prop.Documentation?.Value))
                    {
                        sb.AppendLine($"**Value:** {prop.Documentation!.Value}");
                        sb.AppendLine();
                    }
                    if (!string.IsNullOrEmpty(prop.Documentation?.Remarks))
                    {
                        sb.AppendLine(prop.Documentation!.Remarks);
                        sb.AppendLine();
                    }
                }
            }
        }

        if (type.Methods.Count > 0)
        {
            sb.AppendLine("## Methods");
            sb.AppendLine();
            foreach (MemberInfo method in type.Methods)
                WriteMemberSection(sb, method, 3);
        }

        if (type.Fields.Count > 0)
        {
            sb.AppendLine("## Fields");
            sb.AppendLine();
            sb.AppendLine("| Field | Type | Description |");
            sb.AppendLine("|-------|------|-------------|");
            foreach (MemberInfo field in type.Fields)
            {
                string summary = TruncateSummary(field.Documentation?.Summary ?? string.Empty);
                string staticBadge = field.IsStatic ? " `static`" : "";
                sb.AppendLine($"| `{field.Name}`{staticBadge} | `{field.ReturnType}` | {summary} |");
            }
            sb.AppendLine();
        }

        if (type.Events.Count > 0)
        {
            sb.AppendLine("## Events");
            sb.AppendLine();
            sb.AppendLine("| Event | Type | Description |");
            sb.AppendLine("|-------|------|-------------|");
            foreach (MemberInfo evt in type.Events)
            {
                string summary = TruncateSummary(evt.Documentation?.Summary ?? string.Empty);
                sb.AppendLine($"| `{evt.Name}` | `{evt.ReturnType}` | {summary} |");
            }
            sb.AppendLine();
        }

        if (type.NestedTypes.Count > 0)
        {
            sb.AppendLine("## Nested Types");
            sb.AppendLine();
            foreach (TypeInfo nested in type.NestedTypes)
                WriteNestedTypeSection(sb, nested, 3);
        }

        if (!string.IsNullOrEmpty(type.Documentation?.Example))
        {
            sb.AppendLine("## Example");
            sb.AppendLine();
            sb.AppendLine(type.Documentation!.Example);
            sb.AppendLine();
        }

        if (type.Documentation?.SeeAlso.Count > 0)
        {
            sb.AppendLine("## See Also");
            sb.AppendLine();
            foreach (string seeAlso in type.Documentation!.SeeAlso)
            {
                string shortName = XmlDocParser.GetShortTypeName(seeAlso);
                sb.AppendLine($"- `{shortName}`");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static void WriteNestedTypeSection(StringBuilder sb, TypeInfo type, int headingLevel)
    {
        string heading = new('#', headingLevel);
        sb.AppendLine($"{heading} {type.Name} ({type.Kind})");
        sb.AppendLine();
        sb.AppendLine("```csharp");
        sb.AppendLine(BuildTypeDeclaration(type));
        sb.AppendLine("```");
        sb.AppendLine();

        if (!string.IsNullOrEmpty(type.Documentation?.Summary))
        {
            sb.AppendLine(type.Documentation!.Summary);
            sb.AppendLine();
        }

        if (type.Properties.Count > 0)
        {
            sb.AppendLine($"{heading}# Properties");
            sb.AppendLine();
            sb.AppendLine("| Property | Type | Description |");
            sb.AppendLine("|----------|------|-------------|");
            foreach (MemberInfo prop in type.Properties)
            {
                string summary = TruncateSummary(prop.Documentation?.Summary ?? string.Empty);
                sb.AppendLine($"| `{prop.Name}` | `{prop.ReturnType}` | {summary} |");
            }
            sb.AppendLine();
        }

        if (type.Methods.Count > 0)
        {
            sb.AppendLine($"{heading}# Methods");
            sb.AppendLine();
            foreach (MemberInfo method in type.Methods)
                WriteMemberSection(sb, method, headingLevel + 2);
        }

        if (type.NestedTypes.Count > 0)
        {
            foreach (TypeInfo nested in type.NestedTypes)
                WriteNestedTypeSection(sb, nested, headingLevel + 1);
        }
    }

    private static void WriteMemberSection(StringBuilder sb, MemberInfo member, int headingLevel)
    {
        string heading = new('#', headingLevel);
        string modifiers = "";
        if (member.IsStatic) modifiers += " `static`";
        if (member.IsAbstract) modifiers += " `abstract`";
        if (member.IsVirtual && !member.IsAbstract) modifiers += " `virtual`";
        if (member.IsOverride) modifiers += " `override`";

        sb.AppendLine($"{heading} {member.Name}{modifiers}");
        sb.AppendLine();
        sb.AppendLine("```csharp");
        sb.AppendLine(member.Signature);
        sb.AppendLine("```");
        sb.AppendLine();

        if (!string.IsNullOrEmpty(member.Documentation?.Summary))
        {
            sb.AppendLine(member.Documentation!.Summary);
            sb.AppendLine();
        }

        if (member.Documentation?.TypeParams.Count > 0)
        {
            sb.AppendLine("**Type Parameters:**");
            sb.AppendLine();
            sb.AppendLine("| Parameter | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocParam tp in member.Documentation!.TypeParams)
                sb.AppendLine($"| `{tp.Name}` | {tp.Description} |");
            sb.AppendLine();
        }

        if (member.Parameters.Count > 0)
        {
            sb.AppendLine("**Parameters:**");
            sb.AppendLine();
            sb.AppendLine("| Name | Type | Description |");
            sb.AppendLine("|------|------|-------------|");
            foreach (ParameterInfo param in member.Parameters)
            {
                string desc = member.Documentation?.Params
                    .FirstOrDefault(p => p.Name == param.Name)?.Description ?? string.Empty;
                string optionalSuffix = param.IsOptional ? " *(optional)*" : "";
                sb.AppendLine($"| `{param.Name}` | `{param.Type}` | {desc}{optionalSuffix} |");
            }
            sb.AppendLine();
        }

        if (!string.IsNullOrEmpty(member.ReturnType) && member.ReturnType != "void")
        {
            string returnsDesc = member.Documentation?.Returns ?? string.Empty;
            sb.AppendLine($"**Returns:** `{member.ReturnType}`");
            if (!string.IsNullOrEmpty(returnsDesc))
            {
                sb.AppendLine();
                sb.AppendLine(returnsDesc);
            }
            sb.AppendLine();
        }

        if (member.Documentation?.Exceptions.Count > 0)
        {
            sb.AppendLine("**Exceptions:**");
            sb.AppendLine();
            sb.AppendLine("| Exception | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocException ex in member.Documentation!.Exceptions)
                sb.AppendLine($"| `{ex.Type}` | {ex.Description} |");
            sb.AppendLine();
        }

        if (!string.IsNullOrEmpty(member.Documentation?.Remarks))
        {
            sb.AppendLine(member.Documentation!.Remarks);
            sb.AppendLine();
        }
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

    private static string BuildTypeDeclaration(TypeInfo type)
    {
        StringBuilder sb = new();
        if (type.IsStatic) sb.Append("public static ");
        else if (type.IsAbstract && type.Kind == "class") sb.Append("public abstract ");
        else if (type.IsSealed && type.Kind == "class") sb.Append("public sealed ");
        else sb.Append("public ");

        if (type.Kind == "struct") sb.Append("readonly ");

        sb.Append(type.Kind);
        sb.Append(' ');
        sb.Append(type.Name);

        List<string> baseList = [];
        if (type.BaseType is not null) baseList.Add(type.BaseType);
        baseList.AddRange(type.Interfaces);
        if (baseList.Count > 0)
        {
            sb.Append(" : ");
            sb.Append(string.Join(", ", baseList));
        }

        return sb.ToString();
    }

    private static string TruncateSummary(string summary)
    {
        if (summary.Length <= 200) return summary.Replace("|", "\\|");
        return summary[..197].Replace("|", "\\|") + "...";
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
