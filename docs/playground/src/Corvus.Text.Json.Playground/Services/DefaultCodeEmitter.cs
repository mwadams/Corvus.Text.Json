using System.Text;
using Corvus.Text.Json.Playground.Models;

namespace Corvus.Text.Json.Playground.Services;

/// <summary>
/// Generates default user code based on the generated type map.
/// This gives users a starting point for experimenting with the generated types.
/// </summary>
public static class DefaultCodeEmitter
{
    /// <summary>
    /// Emit default C# code that uses the root generated type.
    /// </summary>
    public static string Emit(IReadOnlyList<TypeMapEntry> typeMap)
    {
        if (typeMap.Count == 0)
        {
            return "// No types were generated. Check the schema for errors.\n";
        }

        TypeMapEntry rootType = typeMap[0];
        var sb = new StringBuilder();

        sb.AppendLine("using System.Text.Json;");
        sb.AppendLine();

        // Build a sample JSON instance from the type map
        string sampleJson = BuildSampleJson(rootType, typeMap);

        sb.AppendLine($"// Parse a JSON instance as a {rootType.TypeName}");
        sb.AppendLine("string json = \"\"\"");
        sb.AppendLine($"    {sampleJson}");
        sb.AppendLine("    \"\"\";");
        sb.AppendLine();
        sb.AppendLine("using var document = JsonDocument.Parse(json);");
        sb.AppendLine($"var value = {rootType.FullTypeName}.FromJson(document.RootElement);");
        sb.AppendLine();

        // Print properties
        if (rootType.Properties.Count > 0)
        {
            sb.AppendLine("// Access properties");
            foreach (TypeMapProperty prop in rootType.Properties)
            {
                string accessor = ToPascalCase(prop.Name);
                sb.AppendLine($"Console.WriteLine($\"{prop.Name}: {{value.{accessor}}}\");");
            }

            sb.AppendLine();
        }

        sb.AppendLine("// Serialize back to JSON");
        sb.AppendLine("Console.WriteLine(value.Serialize());");

        return sb.ToString();
    }

    private static string BuildSampleJson(TypeMapEntry type, IReadOnlyList<TypeMapEntry> allTypes)
    {
        if (type.Kind != "object" || type.Properties.Count == 0)
        {
            return "{}";
        }

        var parts = new List<string>();
        foreach (TypeMapProperty prop in type.Properties)
        {
            string sampleValue = GetSampleValue(prop, allTypes);
            parts.Add($"\"{prop.Name}\": {sampleValue}");
        }

        return "{ " + string.Join(", ", parts) + " }";
    }

    private static string GetSampleValue(TypeMapProperty prop, IReadOnlyList<TypeMapEntry> allTypes)
    {
        // Check if property type is a known complex type in the map
        TypeMapEntry? complexType = allTypes
            .FirstOrDefault(t => t.TypeName == prop.TypeName || t.FullTypeName == prop.TypeName);

        if (complexType is not null && complexType.Kind == "object")
        {
            return BuildSampleJson(complexType, allTypes);
        }

        return prop.TypeName.ToLowerInvariant() switch
        {
            "jsonstring" or "string" => "\"example\"",
            "jsoninteger" or "jsonint32" or "jsonint64" or "integer" => "0",
            "jsonnumber" or "jsondouble" or "jsonsingle" or "number" => "0.0",
            "jsonboolean" or "boolean" => "true",
            _ => "null",
        };
    }

    private static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        return char.ToUpperInvariant(name[0]) + name[1..];
    }
}
