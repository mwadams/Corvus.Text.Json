# JSON Schema Source Generator

## Overview

The Corvus.Text.Json.SourceGenerator automatically generates strongly-typed C# models from JSON Schema documents at compile time. These generated types implement `IJsonValue<T>` and provide type-safe access to JSON data with built-in validation, efficient memory usage, and full IntelliSense support.

## Key Features

- **Compile-Time Code Generation**: Types are generated during build, catching errors early
- **Type-Safe Access**: Strongly-typed properties with compile-time checking
- **Built-in Validation**: JSON Schema validation built into the generated types
- **High Performance**: Optimized for minimal allocations and fast parsing
- **IntelliSense Support**: Full IDE support with documentation from schema descriptions
- **Multiple Backing Stores**: Efficient JsonElement backing or .NET object backing
- **Immutable by Default**: Generated types are immutable structs

## Quick Start

### 1. Add the Source Generator Package

Add the `Corvus.Text.Json.SourceGenerator` package to your project:

```xml
<ItemGroup>
  <ProjectReference Include="path/to/Corvus.Text.Json.SourceGenerator.csproj" 
                    PrivateAssets="all" 
                    ReferenceOutputAssembly="false" 
                    OutputItemType="Analyzer" />
  <ProjectReference Include="path/to/Corvus.Text.Json.csproj" />
</ItemGroup>
```

Or via NuGet:

```xml
<ItemGroup>
  <PackageReference Include="Corvus.Text.Json.SourceGenerator" Version="x.x.x" 
                    PrivateAssets="all" 
                    ReferenceOutputAssembly="false" 
                    OutputItemType="Analyzer" />
  <PackageReference Include="Corvus.Text.Json" Version="x.x.x" />
</ItemGroup>
```

### 2. Add Your JSON Schema

Create a JSON Schema file in your project (e.g., `person-schema.json`):

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "title": "Person",
    "type": "object",
    "required": ["name", "age"],
    "properties": {
        "name": {
            "type": "string",
            "description": "The person's full name"
        },
        "age": {
            "type": "number",
            "minimum": 0,
            "maximum": 130,
            "description": "The person's age in years"
        },
        "email": {
            "type": "string",
            "format": "email",
            "description": "The person's email address"
        }
    }
}
```

### 3. Register the Schema as an Additional File

In your `.csproj` file, add the schema as an AdditionalFile:

```xml
<ItemGroup>
  <AdditionalFiles Include="person-schema.json" />
</ItemGroup>
```

### 4. Create a Partial Struct with the Attribute

Create a C# file with a partial struct annotated with `JsonSchemaTypeGenerator`:

```csharp
using Corvus.Text.Json;

namespace MyApp.Models;

[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;
```

### 5. Build and Use

Build your project. The source generator will create the full implementation:

```csharp
using MyApp.Models;
using Corvus.Text.Json;

// Parse JSON into strongly-typed model
string json = """
    {
        "name": "John Smith",
        "age": 30,
        "email": "john@example.com"
    }
    """;

Person person = Person.ParseValue(json);

// Access properties with full type safety
string name = person.Name.GetString()!;
int age = person.Age.GetInt32();
string? email = person.Email.GetString();

Console.WriteLine($"{name} is {age} years old");

// Validation is built-in
bool isValid = person.IsValid();
Console.WriteLine($"Valid: {isValid}");
```

## Working with Generated Types

### Parsing JSON

Generated types provide multiple parsing methods:

```csharp
// From string
Person person1 = Person.ParseValue(jsonString);

// From UTF-8 bytes
ReadOnlySpan<byte> utf8Json = """{"name":"Alice","age":25}"""u8;
Person person2 = Person.ParseValue(utf8Json);

// From stream
using FileStream stream = File.OpenRead("person.json");
Person person3 = Person.Parse(stream);

// From JsonElement
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(jsonString);
Person person4 = Person.FromJson(doc.RootElement);
```

### Accessing Properties

Properties are accessed using strongly-typed getters:

```csharp
Person person = Person.ParseValue(json);

// Required properties
string name = person.Name.GetString()!;
int age = person.Age.GetInt32();

// Optional properties - check if present
if (person.Email.ValueKind != JsonValueKind.Undefined)
{
    string email = person.Email.GetString()!;
    Console.WriteLine($"Email: {email}");
}
```

### Working with Nested Objects

For nested schemas, the generator creates corresponding nested types:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "name": {
            "type": "object",
            "required": ["firstName", "lastName"],
            "properties": {
                "firstName": { "type": "string" },
                "lastName": { "type": "string" },
                "middleName": { "type": "string" }
            }
        },
        "age": { "type": "number" }
    }
}
```

```csharp
[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;

// Use the generated nested types
Person person = Person.ParseValue(json);

// Access nested properties
string firstName = person.Name.FirstName.GetString()!;
string lastName = person.Name.LastName.GetString()!;

// Optional nested property
if (person.Name.MiddleName.ValueKind != JsonValueKind.Undefined)
{
    string middleName = person.Name.MiddleName.GetString()!;
}
```

### Working with Arrays

Array properties are strongly-typed and enumerable:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "name": { "type": "string" },
        "hobbies": {
            "type": "array",
            "items": { "type": "string" }
        }
    }
}
```

```csharp
Person person = Person.ParseValue(json);

// Enumerate array elements
foreach (JsonString hobby in person.Hobbies.EnumerateArray())
{
    Console.WriteLine(hobby.GetString());
}

// Get array length
int count = person.Hobbies.GetArrayLength();

// Access by index
JsonString firstHobby = person.Hobbies[0];
```

### Validation

Generated types include built-in validation based on the JSON Schema:

```csharp
Person person = Person.ParseValue(json);

// Simple validation
bool isValid = person.IsValid();

// Detailed validation with error information
ValidationContext context = ValidationContext.Create();
bool isValid = person.TryValidate(context, out var errors);

if (!isValid)
{
    foreach (var error in errors)
    {
        Console.WriteLine($"Validation error: {error.Message}");
    }
}
```

## Schema References

### Using $ref

The generator supports JSON Schema `$ref` to reference definitions within the same file or across files:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "$defs": {
        "Address": {
            "type": "object",
            "properties": {
                "street": { "type": "string" },
                "city": { "type": "string" },
                "zipCode": { "type": "string" }
            }
        },
        "Person": {
            "type": "object",
            "properties": {
                "name": { "type": "string" },
                "homeAddress": { "$ref": "#/$defs/Address" },
                "workAddress": { "$ref": "#/$defs/Address" }
            }
        }
    }
}
```

```csharp
// Generate from a specific definition using a JSON Pointer
[JsonSchemaTypeGenerator("schema.json#/$defs/Person")]
public readonly partial struct Person;

// Use the generated types
Person person = Person.ParseValue(json);
Address home = person.HomeAddress;
Address work = person.WorkAddress;

string homeCity = home.City.GetString()!;
```

### External References

Reference schemas in other files:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "address": { "$ref": "address-schema.json" }
    }
}
```

Ensure both files are added as AdditionalFiles:

```xml
<ItemGroup>
  <AdditionalFiles Include="person-schema.json" />
  <AdditionalFiles Include="address-schema.json" />
</ItemGroup>
```

## Advanced Scenarios

### oneOf / anyOf / allOf

The generator handles schema composition keywords:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "identifier": {
            "oneOf": [
                { "type": "string" },
                { "type": "number" }
            ]
        }
    }
}
```

```csharp
Person person = Person.ParseValue(json);

// Check which variant is present
if (person.Identifier.ValueKind == JsonValueKind.String)
{
    string id = person.Identifier.GetString()!;
}
else if (person.Identifier.ValueKind == JsonValueKind.Number)
{
    int id = person.Identifier.GetInt32();
}
```

### Pattern Properties

The generator supports pattern properties for dynamic keys:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "patternProperties": {
        "^[A-Z]+$": { "type": "number" }
    }
}
```

### Enums

JSON Schema enums become type-safe in generated code:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "status": {
            "type": "string",
            "enum": ["active", "inactive", "pending"]
        }
    }
}
```

```csharp
Person person = Person.ParseValue(json);
string status = person.Status.GetString()!;

// Validation ensures it's one of the enum values
bool isValid = person.IsValid(); // false if status is not in enum
```

### Formats

The generator recognizes and validates standard JSON Schema formats:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "properties": {
        "email": { "type": "string", "format": "email" },
        "website": { "type": "string", "format": "uri" },
        "created": { "type": "string", "format": "date-time" },
        "id": { "type": "string", "format": "uuid" }
    }
}
```

## Serialization

Generated types can be serialized back to JSON:

```csharp
Person person = CreatePerson();

// To string
string json = person.ToString();

// To UTF-8 bytes
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
person.WriteTo(writer);
byte[] utf8Json = stream.ToArray();

// With System.Text.Json
string json = JsonSerializer.Serialize(person);
```

## Comparison with Other Approaches

### vs. Manual POCOs

| Feature | Manual POCOs | Generated Types |
|---------|--------------|-----------------|
| **Type Safety** | Manual properties | Auto-generated from schema |
| **Validation** | Manual or FluentValidation | Built-in from schema |
| **Schema Sync** | Manual sync required | Always in sync |
| **Memory** | Allocates objects | Efficient struct-based |
| **Maintenance** | High - manual updates | Low - regenerates on build |

### vs. System.Text.Json JsonNode

| Feature | JsonNode | Generated Types |
|---------|----------|-----------------|
| **Type Safety** | Weak typing | Strong typing |
| **Validation** | Manual | Built-in |
| **Performance** | Object allocations | Struct-based, minimal allocations |
| **IntelliSense** | Limited | Full property support |
| **Schema Enforcement** | None | Compile-time + runtime |

### vs. NJsonSchema Code Generator

| Feature | NJsonSchema | Corvus SourceGenerator |
|---------|-------------|------------------------|
| **Generation Time** | Pre-build tool | Compile-time (Roslyn) |
| **Integration** | External tool | MSBuild integrated |
| **Memory Model** | Class-based | Struct-based |
| **Validation** | DataAnnotations | Schema-native |
| **Performance** | Standard | Optimized for high-throughput |

## Best Practices

### 1. Use Descriptive Schema Titles and Descriptions

These become XML documentation comments in generated code:

```json
{
    "type": "object",
    "title": "User Profile",
    "description": "Represents a user's profile information",
    "properties": {
        "username": {
            "type": "string",
            "description": "The unique username for the user"
        }
    }
}
```

### 2. Leverage $defs for Reusability

Define common types once and reference them:

```json
{
    "$defs": {
        "Address": { /* ... */ },
        "PhoneNumber": { /* ... */ }
    },
    "type": "object",
    "properties": {
        "home": { "$ref": "#/$defs/Address" },
        "work": { "$ref": "#/$defs/Address" },
        "mobile": { "$ref": "#/$defs/PhoneNumber" }
    }
}
```

### 3. Use Specific Types and Formats

Be as specific as possible in your schema:

```json
{
    "properties": {
        "age": { "type": "number", "format": "int32", "minimum": 0 },
        "email": { "type": "string", "format": "email" },
        "website": { "type": "string", "format": "uri" }
    }
}
```

### 4. Add Validation Constraints

Use JSON Schema validation keywords:

```json
{
    "properties": {
        "username": {
            "type": "string",
            "minLength": 3,
            "maxLength": 20,
            "pattern": "^[a-zA-Z0-9_]+$"
        },
        "age": {
            "type": "number",
            "minimum": 0,
            "maximum": 130
        }
    }
}
```

### 5. Organize Schemas by Domain

Keep related schemas together:

```
schemas/
  ├── user/
  │   ├── user-profile.json
  │   ├── user-settings.json
  │   └── user-preferences.json
  ├── product/
  │   ├── product.json
  │   └── product-category.json
  └── common/
      ├── address.json
      └── contact-info.json
```

## Troubleshooting

### Generated Code Not Appearing

1. **Clean and rebuild**: `dotnet clean && dotnet build`
2. **Check AdditionalFiles**: Ensure schema files are marked as `<AdditionalFiles>`
3. **View generated code**: Enable `<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>`

### Compilation Errors in Generated Code

1. **Validate your schema**: Use an online JSON Schema validator
2. **Check schema version**: Ensure you're using a supported draft (2019-09 or 2020-12)
3. **Review error messages**: Source generator errors appear in build output

### IntelliSense Not Working

1. **Restart IDE**: Sometimes Roslyn needs a restart
2. **Rebuild solution**: `dotnet build`
3. **Check project references**: Ensure SourceGenerator project is properly referenced

### Performance Issues

1. **Use ParseValue for simple values**: Faster than Parse for in-memory JSON
2. **Minimize allocations**: Prefer struct-backed types over conversions
3. **Enable validation selectively**: Only validate when necessary

## Examples

See the complete working example in the `/docs/JsonSchemaSourceGeneratorExample` directory.

## Further Reading

- [JSON Schema Specification](https://json-schema.org/)
- [Corvus.Text.Json Documentation](./README.md)
- [ParsedJsonDocument Guide](./ParsedJsonDocument.md)
- [JsonDocumentBuilder Guide](./JsonDocumentBuilder.md)
