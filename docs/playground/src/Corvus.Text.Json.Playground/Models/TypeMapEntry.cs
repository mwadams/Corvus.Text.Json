namespace Corvus.Text.Json.Playground.Models;

/// <summary>
/// Represents a type in the generated type map.
/// </summary>
/// <param name="TypeName">Short type name (e.g. "Person").</param>
/// <param name="FullTypeName">Fully qualified type name (e.g. "MyNamespace.Person").</param>
/// <param name="Kind">Schema type kind: object, array, string, number, integer, boolean, enum, oneOf, anyOf, allOf, or unknown.</param>
/// <param name="SchemaPointer">JSON Pointer into the source schema (e.g. "#/properties/name").</param>
/// <param name="Properties">Child properties/members for object types.</param>
public record TypeMapEntry(
    string TypeName,
    string FullTypeName,
    string Kind,
    string? SchemaPointer,
    IReadOnlyList<TypeMapProperty> Properties);

/// <summary>
/// Represents a property within a generated type.
/// </summary>
/// <param name="Name">Property name in C# (e.g. "Name").</param>
/// <param name="TypeName">Property type name (e.g. "JsonString").</param>
/// <param name="SchemaPointer">JSON Pointer for this property in the schema.</param>
/// <param name="IsRequired">Whether the property is required by the schema.</param>
public record TypeMapProperty(
    string Name,
    string TypeName,
    string? SchemaPointer,
    bool IsRequired);
