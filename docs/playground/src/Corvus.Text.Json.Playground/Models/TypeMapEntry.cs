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
/// <param name="Name">JSON property name (e.g. "firstName").</param>
/// <param name="DotnetPropertyName">C# property accessor name (e.g. "FirstName").</param>
/// <param name="TypeName">Property type short name (e.g. "JsonString").</param>
/// <param name="FullTypeName">Property type fully qualified name (e.g. "Playground.JsonString").</param>
/// <param name="SchemaPointer">JSON Pointer for this property in the schema.</param>
/// <param name="IsRequired">Whether the property is required by the schema.</param>
public record TypeMapProperty(
    string Name,
    string DotnetPropertyName,
    string TypeName,
    string FullTypeName,
    string? SchemaPointer,
    bool IsRequired);
