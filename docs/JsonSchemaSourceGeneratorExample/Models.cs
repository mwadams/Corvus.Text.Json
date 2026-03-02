using Corvus.Text.Json;

namespace JsonSchemaSourceGeneratorExample.Models;

/// <summary>
/// A person entity with contact information.
/// Generated from person-schema.json.
/// </summary>
[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;

/// <summary>
/// A physical address.
/// Generated from person-schema.json#/$defs/Address.
/// </summary>
[JsonSchemaTypeGenerator("person-schema.json#/$defs/Address")]
public readonly partial struct Address;
