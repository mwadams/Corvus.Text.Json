using Corvus.Text.Json;

namespace JsonSchemaSourceGeneratorExample.Models;

/// <summary>
/// A person entity with contact information.
/// Generated from person-schema.json.
/// </summary>
[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;