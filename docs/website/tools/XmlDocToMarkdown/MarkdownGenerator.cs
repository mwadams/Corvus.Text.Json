using System.Text;

namespace XmlDocToMarkdown;

/// <summary>
/// Generates one Vellum markdown file per namespace containing all public types.
/// </summary>
public sealed class MarkdownGenerator(string outputDir)
{
    private const string FrontmatterDate = "2026-03-15T00:00:00.0+00:00";

    public void Generate(Dictionary<string, NamespaceInfo> namespaces)
    {
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            NamespaceInfo nsInfo = kvp.Value;
            string fileName = NamespaceToFileName(ns) + ".md";
            string filePath = Path.Combine(outputDir, fileName);

            StringBuilder sb = new();
            WriteFrontmatter(sb, $"{ns} Namespace");
            WriteNamespaceContent(sb, nsInfo);

            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine($"  Written: {filePath}");
        }
    }

    private static void WriteFrontmatter(StringBuilder sb, string title)
    {
        sb.AppendLine("---");
        sb.AppendLine("ContentType: \"application/vnd.endjin.ssg.content+md\"");
        sb.AppendLine("PublicationStatus: Published");
        sb.AppendLine($"Date: {FrontmatterDate}");
        sb.AppendLine($"Title: \"{EscapeYamlString(title)}\"");
        sb.AppendLine("---");
    }

    /// <summary>
    /// Generates one markdown file per type, placed flat in the output directory.
    /// File names use the pattern: {nsSlug}-{typeSlug}.md
    /// </summary>
    public void GeneratePerType(Dictionary<string, NamespaceInfo> namespaces)
    {
        foreach (KeyValuePair<string, NamespaceInfo> kvp in namespaces.OrderBy(n => n.Key))
        {
            string ns = kvp.Key;
            string nsSlug = NamespaceToFileName(ns);

            foreach (TypeInfo type in kvp.Value.Types)
            {
                string typeSlug = TypeToSlug(type.Name);
                string fileName = $"{nsSlug}-{typeSlug}.md";
                string filePath = Path.Combine(outputDir, fileName);

                StringBuilder sb = new();
                WriteFrontmatter(sb, $"{type.Name} \u2014 {ns}");
                WriteTypeBody(sb, type);

                File.WriteAllText(filePath, sb.ToString());
                Console.WriteLine($"  Written: {filePath}");
            }
        }
    }

    private static void WriteNamespaceContent(StringBuilder sb, NamespaceInfo nsInfo)
    {
        string nsSlug = NamespaceToFileName(nsInfo.Name);

        sb.AppendLine("| Type | Kind | Description |");
        sb.AppendLine("|------|------|-------------|");
        foreach (TypeInfo type in nsInfo.Types)
        {
            string summary = TruncateSummary(type.Documentation?.Summary ?? string.Empty);
            string typeSlug = TypeToSlug(type.Name);
            string typeUrl = $"/api/{nsSlug}-{typeSlug}.html";
            sb.AppendLine($"| [{type.Name}]({typeUrl}) | {type.Kind} | {summary} |");
        }

        sb.AppendLine();
    }

    /// <summary>
    /// Writes the full body of a type page (no top heading; the view template provides it).
    /// </summary>
    internal static void WriteTypeBody(StringBuilder sb, TypeInfo type)
    {
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
            {
                sb.AppendLine($"| `{tp.Name}` | {tp.Description} |");
            }
            sb.AppendLine();
        }

        if (!string.IsNullOrEmpty(type.Documentation?.Remarks))
        {
            sb.AppendLine("## Remarks");
            sb.AppendLine();
            sb.AppendLine(type.Documentation!.Remarks);
            sb.AppendLine();
        }

        // Inheritance chain (for classes with a base type)
        if (type.BaseType is not null && type.Kind == "class")
        {
            sb.AppendLine("## Inheritance");
            sb.AppendLine();
            StringBuilder chain = new();
            chain.Append(ResolveTypeLink("Object", "System.Object"));
            chain.Append(" \u2192 ");
            chain.Append(ResolveTypeLink(type.BaseType, type.BaseTypeFullName));
            chain.Append(" \u2192 ");
            chain.Append($"**{type.Name}**");
            sb.AppendLine(chain.ToString());
            sb.AppendLine();
        }
        else if (type.Kind == "class")
        {
            sb.AppendLine("## Inheritance");
            sb.AppendLine();
            sb.AppendLine($"{ResolveTypeLink("Object", "System.Object")} \u2192 **{type.Name}**");
            sb.AppendLine();
        }

        // Implements
        if (type.InterfacesWithFullNames.Count > 0)
        {
            sb.AppendLine("## Implements");
            sb.AppendLine();
            string ifaceList = string.Join(", ", type.InterfacesWithFullNames.Select(
                i => ResolveTypeLink(i.DisplayName, i.FullName)));
            sb.AppendLine(ifaceList);
            sb.AppendLine();
        }

        // Implemented By (for interfaces)
        if (type.ImplementedBy.Count > 0)
        {
            sb.AppendLine("## Implemented By");
            sb.AppendLine();
            string implList = string.Join(", ", type.ImplementedBy.Select(
                i => ResolveTypeLink(i.DisplayName, i.FullName)));
            sb.AppendLine(implList);
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
                sb.AppendLine($"| `{prop.Name}`{staticBadge} | {ResolveTypeLink(prop.ReturnType, prop.ReturnTypeFullName)} | {summary} |");
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

        if (type.Operators.Count > 0)
        {
            sb.AppendLine("## Operators");
            sb.AppendLine();
            foreach (MemberInfo op in type.Operators)
                WriteMemberSection(sb, op, 3);
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
                sb.AppendLine($"| `{field.Name}`{staticBadge} | {ResolveTypeLink(field.ReturnType, field.ReturnTypeFullName)} | {summary} |");
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
                sb.AppendLine($"| `{evt.Name}` | {ResolveTypeLink(evt.ReturnType, evt.ReturnTypeFullName)} | {summary} |");
            }
            sb.AppendLine();
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
                string? url = XmlDocParser.ResolveTypeUrl(seeAlso);
                if (url is not null)
                    sb.AppendLine($"- [`{shortName}`]({url})");
                else
                    sb.AppendLine($"- `{shortName}`");
            }
            sb.AppendLine();
        }
    }

    private static void WriteTypeSection(StringBuilder sb, TypeInfo type, int headingLevel)
    {
        string heading = new('#', headingLevel);

        sb.AppendLine($"{heading} {type.Name} ({type.Kind})");
        sb.AppendLine();

        // Type declaration
        sb.AppendLine("```csharp");
        sb.AppendLine(BuildTypeDeclaration(type));
        sb.AppendLine("```");
        sb.AppendLine();

        // Summary
        if (!string.IsNullOrEmpty(type.Documentation?.Summary))
        {
            sb.AppendLine(type.Documentation!.Summary);
            sb.AppendLine();
        }

        // Type parameters
        if (type.GenericParameters.Count > 0 && type.Documentation?.TypeParams.Count > 0)
        {
            sb.AppendLine($"{heading}# Type Parameters");
            sb.AppendLine();
            sb.AppendLine("| Parameter | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocParam tp in type.Documentation!.TypeParams)
            {
                sb.AppendLine($"| `{tp.Name}` | {tp.Description} |");
            }

            sb.AppendLine();
        }

        // Remarks
        if (!string.IsNullOrEmpty(type.Documentation?.Remarks))
        {
            sb.AppendLine($"{heading}# Remarks");
            sb.AppendLine();
            sb.AppendLine(type.Documentation!.Remarks);
            sb.AppendLine();
        }

        // Inheritance and interfaces
        if (type.BaseType is not null && type.Kind == "class")
        {
            sb.AppendLine($"{heading}# Inheritance");
            sb.AppendLine();
            StringBuilder chain = new();
            chain.Append(ResolveTypeLink("Object", "System.Object"));
            chain.Append(" \u2192 ");
            chain.Append(ResolveTypeLink(type.BaseType, type.BaseTypeFullName));
            chain.Append(" \u2192 ");
            chain.Append($"**{type.Name}**");
            sb.AppendLine(chain.ToString());
            sb.AppendLine();
        }
        else if (type.Kind == "class")
        {
            sb.AppendLine($"{heading}# Inheritance");
            sb.AppendLine();
            sb.AppendLine($"{ResolveTypeLink("Object", "System.Object")} \u2192 **{type.Name}**");
            sb.AppendLine();
        }

        // Implements
        if (type.InterfacesWithFullNames.Count > 0)
        {
            sb.AppendLine($"{heading}# Implements");
            sb.AppendLine();
            string ifaceList = string.Join(", ", type.InterfacesWithFullNames.Select(
                i => ResolveTypeLink(i.DisplayName, i.FullName)));
            sb.AppendLine(ifaceList);
            sb.AppendLine();
        }

        // Implemented By (for interfaces)
        if (type.ImplementedBy.Count > 0)
        {
            sb.AppendLine($"{heading}# Implemented By");
            sb.AppendLine();
            string implList = string.Join(", ", type.ImplementedBy.Select(
                i => ResolveTypeLink(i.DisplayName, i.FullName)));
            sb.AppendLine(implList);
            sb.AppendLine();
        }

        // Constructors
        if (type.Constructors.Count > 0)
        {
            sb.AppendLine($"{heading}# Constructors");
            sb.AppendLine();
            foreach (MemberInfo ctor in type.Constructors)
            {
                WriteMemberSection(sb, ctor, headingLevel + 2);
            }
        }

        // Properties
        if (type.Properties.Count > 0)
        {
            sb.AppendLine($"{heading}# Properties");
            sb.AppendLine();
            sb.AppendLine("| Property | Type | Description |");
            sb.AppendLine("|----------|------|-------------|");
            foreach (MemberInfo prop in type.Properties)
            {
                string summary = TruncateSummary(prop.Documentation?.Summary ?? string.Empty);
                string staticBadge = prop.IsStatic ? " `static`" : "";
                sb.AppendLine($"| `{prop.Name}`{staticBadge} | {ResolveTypeLink(prop.ReturnType, prop.ReturnTypeFullName)} | {summary} |");
            }

            sb.AppendLine();

            // Detailed property docs
            foreach (MemberInfo prop in type.Properties)
            {
                if (!string.IsNullOrEmpty(prop.Documentation?.Remarks) ||
                    !string.IsNullOrEmpty(prop.Documentation?.Value))
                {
                    sb.AppendLine($"{heading}## {prop.Name}");
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

        // Methods
        if (type.Methods.Count > 0)
        {
            sb.AppendLine($"{heading}# Methods");
            sb.AppendLine();
            foreach (MemberInfo method in type.Methods)
            {
                WriteMemberSection(sb, method, headingLevel + 2);
            }
        }

        // Operators
        if (type.Operators.Count > 0)
        {
            sb.AppendLine($"{heading}# Operators");
            sb.AppendLine();
            foreach (MemberInfo op in type.Operators)
            {
                WriteMemberSection(sb, op, headingLevel + 2);
            }
        }

        // Fields
        if (type.Fields.Count > 0)
        {
            sb.AppendLine($"{heading}# Fields");
            sb.AppendLine();
            sb.AppendLine("| Field | Type | Description |");
            sb.AppendLine("|-------|------|-------------|");
            foreach (MemberInfo field in type.Fields)
            {
                string summary = TruncateSummary(field.Documentation?.Summary ?? string.Empty);
                string staticBadge = field.IsStatic ? " `static`" : "";
                sb.AppendLine($"| `{field.Name}`{staticBadge} | {ResolveTypeLink(field.ReturnType, field.ReturnTypeFullName)} | {summary} |");
            }

            sb.AppendLine();
        }

        // Events
        if (type.Events.Count > 0)
        {
            sb.AppendLine($"{heading}# Events");
            sb.AppendLine();
            sb.AppendLine("| Event | Type | Description |");
            sb.AppendLine("|-------|------|-------------|");
            foreach (MemberInfo evt in type.Events)
            {
                string summary = TruncateSummary(evt.Documentation?.Summary ?? string.Empty);
                sb.AppendLine($"| `{evt.Name}` | {ResolveTypeLink(evt.ReturnType, evt.ReturnTypeFullName)} | {summary} |");
            }

            sb.AppendLine();
        }

        // Nested types
        if (type.NestedTypes.Count > 0)
        {
            sb.AppendLine($"{heading}# Nested Types");
            sb.AppendLine();
            foreach (TypeInfo nested in type.NestedTypes)
            {
                WriteTypeSection(sb, nested, headingLevel + 1);
            }
        }

        // Example
        if (!string.IsNullOrEmpty(type.Documentation?.Example))
        {
            sb.AppendLine($"{heading}# Example");
            sb.AppendLine();
            sb.AppendLine(type.Documentation!.Example);
            sb.AppendLine();
        }

        // See Also
        if (type.Documentation?.SeeAlso.Count > 0)
        {
            sb.AppendLine($"{heading}# See Also");
            sb.AppendLine();
            foreach (string seeAlso in type.Documentation!.SeeAlso)
            {
                string shortName = XmlDocParser.GetShortTypeName(seeAlso);
                string? url = XmlDocParser.ResolveTypeUrl(seeAlso);
                if (url is not null)
                    sb.AppendLine($"- [`{shortName}`]({url})");
                else
                    sb.AppendLine($"- `{shortName}`");
            }

            sb.AppendLine();
        }

        sb.AppendLine("---");
        sb.AppendLine();
    }

    private static void WriteMemberSection(StringBuilder sb, MemberInfo member, int headingLevel)
    {
        string heading = new('#', headingLevel);

        string modifiers = "";
        if (member.IsStatic)
        {
            modifiers += " `static`";
        }

        if (member.IsAbstract)
        {
            modifiers += " `abstract`";
        }

        if (member.IsVirtual && !member.IsAbstract)
        {
            modifiers += " `virtual`";
        }

        if (member.IsOverride)
        {
            modifiers += " `override`";
        }

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

        // Type parameters
        if (member.Documentation?.TypeParams.Count > 0)
        {
            sb.AppendLine("**Type Parameters:**");
            sb.AppendLine();
            sb.AppendLine("| Parameter | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocParam tp in member.Documentation!.TypeParams)
            {
                sb.AppendLine($"| `{tp.Name}` | {tp.Description} |");
            }

            sb.AppendLine();
        }

        // Parameters table
        if (member.Parameters.Count > 0)
        {
            sb.AppendLine("**Parameters:**");
            sb.AppendLine();
            sb.AppendLine("| Name | Type | Description |");
            sb.AppendLine("|------|------|-------------|");
            foreach (ParameterInfo param in member.Parameters)
            {
                // Look up the doc param description
                string desc = member.Documentation?.Params
                    .FirstOrDefault(p => p.Name == param.Name)?.Description ?? string.Empty;
                string optionalSuffix = param.IsOptional ? " *(optional)*" : "";
                sb.AppendLine($"| `{param.Name}` | {ResolveTypeLink(param.Type, param.TypeFullName)} | {desc}{optionalSuffix} |");
            }

            sb.AppendLine();
        }

        // Returns
        if (!string.IsNullOrEmpty(member.ReturnType) && member.ReturnType != "void")
        {
            string returnsDesc = member.Documentation?.Returns ?? string.Empty;
            sb.AppendLine($"**Returns:** {ResolveTypeLink(member.ReturnType, member.ReturnTypeFullName)}");
            if (!string.IsNullOrEmpty(returnsDesc))
            {
                sb.AppendLine();
                sb.AppendLine(returnsDesc);
            }

            sb.AppendLine();
        }

        // Exceptions
        if (member.Documentation?.Exceptions.Count > 0)
        {
            sb.AppendLine("**Exceptions:**");
            sb.AppendLine();
            sb.AppendLine("| Exception | Description |");
            sb.AppendLine("|-----------|-------------|");
            foreach (DocException ex in member.Documentation!.Exceptions)
            {
                string exShortName = XmlDocParser.GetShortTypeName(ex.Type);
                sb.AppendLine($"| {ResolveTypeLink(exShortName, ex.Type)} | {ex.Description} |");
            }

            sb.AppendLine();
        }

        // Remarks
        if (!string.IsNullOrEmpty(member.Documentation?.Remarks))
        {
            sb.AppendLine(member.Documentation!.Remarks);
            sb.AppendLine();
        }
    }

    private static string BuildTypeDeclaration(TypeInfo type)
    {
        StringBuilder sb = new();

        if (type.IsStatic)
        {
            sb.Append("public static ");
        }
        else if (type.IsAbstract && type.Kind == "class")
        {
            sb.Append("public abstract ");
        }
        else if (type.IsSealed && type.Kind == "class")
        {
            sb.Append("public sealed ");
        }
        else
        {
            sb.Append("public ");
        }

        // readonly struct
        if (type.Kind == "struct")
        {
            sb.Append("readonly ");
        }

        sb.Append(type.Kind);
        sb.Append(' ');
        sb.Append(type.Name);

        // Base type and interfaces
        List<string> baseList = [];
        if (type.BaseType is not null)
        {
            baseList.Add(type.BaseType);
        }

        baseList.AddRange(type.Interfaces);

        if (baseList.Count > 0)
        {
            sb.Append(" : ");
            sb.Append(string.Join(", ", baseList));
        }

        return sb.ToString();
    }

    internal static string NamespaceToFileName(string ns)
    {
        return ns.Replace('.', '-').ToLowerInvariant();
    }

    internal static string TypeToSlug(string typeName)
    {
        return typeName
            .Replace('.', '-')
            .Replace('<', '-')
            .Replace(">", "")
            .Replace(", ", "-")
            .Replace(",", "-")
            .Replace(' ', '-')
            .ToLowerInvariant()
            .TrimEnd('-');
    }

    private static string Anchor(string name)
    {
        // GitHub-style anchor: lowercase, replace non-alphanumeric with hyphens
        return name
            .Replace('.', '-')
            .Replace('<', '-')
            .Replace('>', '-')
            .Replace(' ', '-')
            .ToLowerInvariant()
            .TrimEnd('-');
    }

    private static string TruncateSummary(string summary)
    {
        if (summary.Length <= 200)
        {
            return summary.Replace("|", "\\|");
        }

        return summary[..197].Replace("|", "\\|") + "...";
    }

    private static string EscapeYamlString(string value)
    {
        return value.Replace("\"", "\\\"");
    }

    /// <summary>
    /// Creates a markdown link for a type reference, using local URLs for Corvus types,
    /// learn.microsoft.com for BCL types, or plain code formatting as a fallback.
    /// </summary>
    private static string ResolveTypeLink(string displayName, string? fullName)
    {
        string escaped = displayName.Replace("|", "\\|");

        if (fullName is not null)
        {
            // Try local type URL first
            string? localUrl = XmlDocParser.ResolveTypeUrl(fullName);
            if (localUrl is not null)
            {
                return $"[`{escaped}`]({localUrl})";
            }

            // Try BCL URL for System.* and Microsoft.* types
            if (fullName.StartsWith("System.", StringComparison.Ordinal) ||
                fullName.StartsWith("Microsoft.", StringComparison.Ordinal))
            {
                string bclUrl = GetBclTypeUrl(fullName);
                return $"[`{escaped}`]({bclUrl})";
            }

            // Try NodaTime URL
            if (fullName.StartsWith("NodaTime.", StringComparison.Ordinal))
            {
                string nodaUrl = GetNodaTimeTypeUrl(fullName);
                return $"[`{escaped}`]({nodaUrl})";
            }
        }

        return $"`{escaped}`";
    }

    /// <summary>
    /// Generates a learn.microsoft.com URL for a BCL type.
    /// </summary>
    private static string GetBclTypeUrl(string fullName)
    {
        // System.Collections.Generic.List`1 → system.collections.generic.list-1
        string urlName = fullName.ToLowerInvariant().Replace('`', '-');
        return $"https://learn.microsoft.com/dotnet/api/{urlName}";
    }

    /// <summary>
    /// Generates a nodatime.org API URL for a NodaTime type.
    /// </summary>
    private static string GetNodaTimeTypeUrl(string fullName)
    {
        // NodaTime.Period → NodaTime.Period.html
        // NodaTime.Text.OffsetDateTimePattern → NodaTime.Text.OffsetDateTimePattern.html
        // Strip generic arity suffix if present: NodaTime.SomeType`1 → NodaTime.SomeType
        int backtick = fullName.IndexOf('`');
        string cleanName = backtick >= 0 ? fullName[..backtick] : fullName;
        return $"https://www.nodatime.org/3.3.x/api/{cleanName}.html";
    }
}
