# JSON Schema Source Generator Example

This example demonstrates how to use the Corvus.Text.Json.SourceGenerator to create strongly-typed C# models from JSON Schema documents.

## What This Example Shows

1. **Parsing JSON** - Parse JSON strings into strongly-typed models
2. **Schema Validation** - Validate JSON against schema constraints at runtime
3. **Property Access** - Access JSON properties with compile-time type safety
4. **Building Documents** - Create JSON documents programmatically
5. **Modifying Documents** - Make documents mutable and update them
6. **Serialization** - Convert back to JSON strings

## Project Structure

- `person-schema.json` - JSON Schema definition for a Person
- `Models.cs` - Partial struct declarations with `JsonSchemaTypeGenerator` attributes
- `Program.cs` - Example code demonstrating the generated API

## How It Works

### 1. Define Your Schema

`person-schema.json` defines the structure and validation rules:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "required": ["name", "age"],
    "properties": {
        "name": { "type": "string", "minLength": 1 },
        "age": { "type": "number", "minimum": 0, "maximum": 130 },
        "email": { "type": "string", "format": "email" }
    }
}
```

### 2. Register the Schema

In the `.csproj` file:

```xml
<ItemGroup>
  <AdditionalFiles Include="person-schema.json" />
</ItemGroup>
```

### 3. Declare the Type

Create a partial struct with the attribute:

```csharp
[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;
```

### 4. Build and Use

The source generator creates the full implementation at compile time:

```csharp
// Parse JSON
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
Person person = doc.RootElement;

// Access properties
string? name = person.Name;
int? age = person.Age;

// Validate
bool isValid = person.EvaluateSchema();
```

## Running the Example

```bash
cd docs/JsonSchemaSourceGeneratorExample
dotnet run
```

## Key Features Demonstrated

- **Compile-time safety**: Properties are checked at compile time
- **Built-in validation**: Schema validation is generated automatically
- **Efficient parsing**: Uses pooled memory for minimal allocations
- **Mutable documents**: Can convert to mutable for modifications
- **Full IntelliSense**: IDE support for all generated properties

## Generated Code

The source generator creates:
- Immutable struct types for each schema definition
- Mutable counterparts for document modification
- Property accessors with correct types
- JSON Schema validation methods
- Parsing and serialization methods

To see the generated code, check `obj/Debug/net9.0/generated/Corvus.Text.Json.SourceGenerator/`

## Further Reading

- [JSON Schema Source Generator Documentation](../JsonSchemaSourceGenerator.md)
- [ParsedJsonDocument Guide](../ParsedJsonDocument.md)
- [JsonDocumentBuilder Guide](../JsonDocumentBuilder.md)
