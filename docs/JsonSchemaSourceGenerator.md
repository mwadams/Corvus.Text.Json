# JSON Schema Source Generator

## Overview

The Corvus.Text.Json.SourceGenerator automatically generates strongly-typed C# models from JSON Schema documents at compile time. These generated types implement `IJsonElement<T>` and provide type-safe access to JSON data with built-in schema validation, efficient memory usage via `ParsedJsonDocument`, and full IntelliSense support.

## Key Features

- **Compile-Time Code Generation**: Types are generated during build, catching errors early
- **Type-Safe Access**: Strongly-typed properties with compile-time checking
- **Built-in Schema Validation**: JSON Schema validation via `EvaluateSchema()` on every generated type
- **High Performance**: Struct-based types backed by `ParsedJsonDocument` for minimal allocations
- **IntelliSense Support**: Full IDE support with documentation from schema descriptions
- **Immutable by Default**: Generated types are immutable `readonly struct`s with optional mutable variants

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

// Access properties — each returns a strongly-typed entity struct
Console.WriteLine($"{person.Name} is {(int)person.Age} years old");

// Schema validation is built-in
bool isValid = person.EvaluateSchema();
Console.WriteLine($"Valid: {isValid}");
```

## Configuration

The source generator supports several MSBuild properties that control code generation behavior. Set these in your `.csproj` file:

### OptionalAsNullable

Controls how optional properties are typed. By default, optional properties return non-nullable entity structs that are `Undefined` when the property is absent:

```xml
<!-- Default (off) — optional properties return T -->
<!-- No property needed; this is the default behavior -->

<!-- Opt-in — optional properties return T? (nullable) -->
<PropertyGroup>
  <CorvusTextJsonOptionalAsNullable>NullOrUndefined</CorvusTextJsonOptionalAsNullable>
</PropertyGroup>
```

**Default (off):** Optional properties return the entity struct directly. When absent, the returned value is `Undefined` — check with `value.IsUndefined()` or `value.ValueKind == JsonValueKind.Undefined`:

```csharp
// Optional property returns non-nullable struct
Person.EmailEntity email = person.Email;

if (email.IsNotUndefined())
{
    Console.WriteLine($"Email: {email.GetString()}");
}
```

**NullOrUndefined (opt-in):** Optional properties return `T?` (nullable struct). When absent, the property returns `null`:

```csharp
// Optional property returns nullable struct
Person.EmailEntity? email = person.Email;

if (email is { } e)
{
    Console.WriteLine($"Email: {e.GetString()}");
}
```

> **Note:** Required properties are always non-nullable regardless of this setting. Setters and `Create()`/`Build()` factory methods are also unaffected.

## Working with Generated Types

### Parsing JSON

Generated types provide a static `ParseValue()` method. For document-lifetime management, use `ParsedJsonDocument<T>`:

```csharp
// ParseValue — returns the value directly (document is managed internally)
Person person1 = Person.ParseValue(jsonString);

// From UTF-8 bytes
ReadOnlySpan<byte> utf8Json = """{"name":"Alice","age":25}"""u8;
Person person2 = Person.ParseValue(utf8Json);

// ParsedJsonDocument — explicit lifetime control with using/Dispose
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(jsonString);
Person person3 = doc.RootElement;

// From a stream
using FileStream stream = File.OpenRead("person.json");
using ParsedJsonDocument<Person> streamDoc = ParsedJsonDocument<Person>.Parse(stream);
Person person4 = streamDoc.RootElement;
```

### Accessing Properties

Properties return strongly-typed entity structs. Required properties return the entity directly; optional properties return the entity as a non-nullable struct (see [Configuration](#configuration) for the nullable alternative):

```csharp
Person person = Person.ParseValue(json);

// Required properties — always present
// person.Name returns Person.PersonName, person.Age returns Person.AgeEntity
string firstName = person.Name.FirstName.GetString()!;
int age = (int)person.Age;  // AgeEntity has implicit conversion to int

// Optional properties — check for undefined before accessing
if (person.Email.IsNotUndefined())
{
    Console.WriteLine($"Email: {person.Email.GetString()}");
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

// Access nested properties — each returns its own entity type
string firstName = person.Name.FirstName.GetString()!;
string lastName = person.Name.LastName.GetString()!;

// Optional nested property — check for undefined
if (person.Name.MiddleName.IsNotUndefined())
{
    Console.WriteLine($"Middle: {person.Name.MiddleName.GetString()}");
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

// Enumerate array elements — each element is a typed entity
foreach (var hobby in person.Hobbies.EnumerateArray())
{
    Console.WriteLine(hobby.GetString());
}

// Get array length
int count = person.Hobbies.GetArrayLength();

// Access by index — returns the array item entity type
var firstHobby = person.Hobbies[0];
Console.WriteLine(firstHobby.GetString());
```

### Validation

Generated types include built-in validation based on the JSON Schema via `EvaluateSchema()`:

```csharp
Person person = Person.ParseValue(json);

// Validate against the schema
bool isValid = person.EvaluateSchema();

Console.WriteLine($"Schema evaluation: {isValid}");
```

> **Tip:** Generated types are immutable by default. For mutation operations like setting properties, removing properties, and modifying arrays, see [Mutating Generated Types](#mutating-generated-types) below.

### Building Documents

In addition to parsing JSON, you can build documents from scratch using `BuildDocument()` and the generated `Build()` / `Create()` API. This uses a callback pattern with `ref struct` builders for zero-allocation construction.

#### Building a complete document

`BuildDocument()` takes a `JsonWorkspace` and a builder callback. The callback receives a `ref Builder` on which you call `Create()` with named parameters for each property:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

// Build a Person from scratch — no JSON parsing needed
using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
    workspace,
    (ref b) => b.Create(
        age: 30,
        email: "alice@example.com",
        name: Person.PersonName.Build((ref nameBuilder) =>
        {
            nameBuilder.Create(
                firstName: "Alice",
                lastName: "Smith");
        })));

Console.WriteLine(docBuilder.RootElement.ToString());
// Output: {"name":{"firstName":"Alice","lastName":"Smith"},"age":30,"email":"alice@example.com"}
```

#### Nested objects with Build()

For nested object properties, call `NestedType.Build()` to create a `Source` value from a builder callback. `Build()` returns a lightweight `Source` ref struct that is consumed by the parent `Create()` call:

```csharp
// Build nested PersonName with required and optional properties
name: Person.PersonName.Build((ref nameBuilder) =>
{
    nameBuilder.Create(
        firstName: "Grace",
        lastName: "Hopper",
        middleName: "Brewster");  // Optional parameter — omit to leave undefined
})
```

Required parameters must be provided; optional ones have `default` values and can be omitted.

#### Array properties with Build()

Array properties use the same `Build()` pattern. The callback receives a builder with `Add()` methods:

```csharp
// Build an array of hobbies
hobbies: Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
{
    hobbiesBuilder.Add("reading");
    hobbiesBuilder.Add("hiking");
    hobbiesBuilder.Add("photography");
})
```

#### Putting it all together

Here is a complete document with nested objects and arrays:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
    workspace,
    (ref b) => b.Create(
        age: 42,
        email: "grace.hopper@navy.mil",
        phoneNumber: "+15555551234",
        isActive: true,
        name: Person.PersonName.Build((ref nameBuilder) =>
        {
            nameBuilder.Create(
                firstName: "Grace",
                lastName: "Hopper",
                middleName: "Brewster");
        }),
        address: Person.Address.Build((ref addressBuilder) =>
        {
            addressBuilder.Create(
                street: "123 Navy Yard",
                city: "Washington",
                state: "DC",
                zipCode: "20001",
                country: "USA");
        }),
        hobbies: Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
        {
            hobbiesBuilder.Add("reading");
            hobbiesBuilder.Add("coding");
            hobbiesBuilder.Add("teaching");
        })));

Person.Mutable mutablePerson = docBuilder.RootElement;
Console.WriteLine(mutablePerson.ToString());
```

> **Note:** `Build()` returns a `Source` ref struct, not a document. It is only materialised into a document when passed to `BuildDocument()` or a `Set*()` method. You can also pass an existing immutable instance anywhere a `Source` is expected — the generated `Source` type has an implicit conversion from the corresponding entity type.

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
    string id = (string)person.Identifier;
}
else if (person.Identifier.ValueKind == JsonValueKind.Number)
{
    double id = (double)person.Identifier;
}
```

> **Note:** `ValueKind` checking works well for primitive type discrimination (string vs. number). For discriminating between **object** variants with distinct property shapes, the generated `Match()` method provides a type-safe alternative — see [Composition Patterns: Match and Apply](#composition-patterns-match-and-apply).

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
bool isValid = person.EvaluateSchema(); // false if status is not in enum
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

## Mutating Generated Types

Generated types are immutable by default — each is a `readonly struct` backed by a `ParsedJsonDocument`. To make changes, you create a mutable copy via a `JsonWorkspace`, which manages pooled memory for in-place edits and tracks a version number so that stale element references are detected at runtime.

For full details on workspaces and the builder pattern, see [JsonDocumentBuilder](./JsonDocumentBuilder.md).

### Setting Properties

For object types, generated mutable types include `SetProperty()` methods for each defined property:

```csharp
// Given a schema with properties: name (string), age (int32), email (string)
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse("""{"name":"Alice","age":30}""");
using JsonDocumentBuilder<Person.Mutable> builder = doc.RootElement.BuildDocument(workspace);

Person.Mutable root = builder.RootElement;
root.SetAge(31);
root.SetEmail("alice@example.com"u8);

Console.WriteLine(root.ToString());
// Output: {"name":"Alice","age":31,"email":"alice@example.com"}
```

You can also set nested object and array properties using the `Build()` pattern:

```csharp
// Replace a nested object property using Build()
root.SetName(Person.PersonName.Build((ref nameBuilder) =>
{
    nameBuilder.Create(
        firstName: "Alice",
        lastName: "Johnson",       // Changed last name
        middleName: "Marie");      // Added middle name
}));

// Replace an array property using Build()
root.SetHobbies(Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
{
    hobbiesBuilder.Add("painting");
    hobbiesBuilder.Add("gardening");
}));

// Re-obtain reference after mutation
root = builder.RootElement;
Console.WriteLine(root.ToString());
```

### Removing Properties

Optional properties can be removed from mutable instances:

```csharp
Person.Mutable root = builder.RootElement;
root.RemoveEmail();

Console.WriteLine(root.ToString());
// Output: {"name":"Alice","age":30}
```

### Array Mutation

For array types, generated mutable types include methods like `InsertItem()`, `RemoveItem()`, and `SetItem()`:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<NumberArray> doc =
    ParsedJsonDocument<NumberArray>.Parse("[1,2,3]");
using JsonDocumentBuilder<NumberArray.Mutable> builder = doc.RootElement.BuildDocument(workspace);

NumberArray.Mutable root = builder.RootElement;
root.InsertItem(1, 99); // Insert 99 at index 1
root.RemoveItem(3);     // Remove item at index 3

Console.WriteLine(root.ToString());
// Output: [1,99,2]
```

> **Important:** After any mutation, re-obtain element references from `builder.RootElement` — previous references are invalidated by version tracking.

## Default Property Values

When a schema defines a `"default"` value for a property, the generated immutable type's property getter returns that default when the property is absent from the JSON document:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "required": ["name"],
    "properties": {
        "name": { "type": "string" },
        "status": { "type": "string", "default": "active" },
        "count": { "type": "integer", "format": "int32", "default": 0 }
    }
}
```

```csharp
using ParsedJsonDocument<Config> doc =
    ParsedJsonDocument<Config>.Parse("""{"name":"myapp"}""");

Config config = doc.RootElement;

// Required property — always present
string name = config.Name.ToString();     // "myapp"

// Optional with default — returns DefaultInstance when missing
string status = config.Status.ToString(); // "active" (from schema default)
int count = (int)config.Count;            // 0 (from schema default)
```

The `DefaultInstance` static property is generated on the property type and initialized at class load time. Mutable property getters always return `default` (not the schema default) when a property is absent.

## Property Indexers

Generated types support indexed property access using string, UTF-8, or UTF-16 property names. These return `JsonElement`-typed values for flexible access.

```csharp
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse("""{"name":"Alice","age":30}""");
Person person = doc.RootElement;

// UTF-8 property name (most efficient — no transcoding)
JsonElement name = person["name"u8];

// String property name
JsonElement age = person["age"];
```

On `JsonElement` and `JsonElement.Mutable`, the same indexer patterns work:

```csharp
using ParsedJsonDocument<JsonElement> doc =
    ParsedJsonDocument<JsonElement>.Parse("""{"name":"Alice"}""");

// All three forms work
JsonElement byUtf8 = doc.RootElement["name"u8];
JsonElement byString = doc.RootElement["name"];
```

## Composition Patterns: Match and Apply

### Match — Type-Safe Discrimination

For `anyOf` and `oneOf` schemas with object variants, the generated type includes a `Match()` method for type-safe discrimination:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "anyOf": [
        {
            "type": "object",
            "required": ["kind", "message"],
            "properties": {
                "kind": { "const": "text" },
                "message": { "type": "string" }
            }
        },
        {
            "type": "object",
            "required": ["kind", "code"],
            "properties": {
                "kind": { "const": "numeric" },
                "code": { "type": "number", "format": "int32" }
            }
        }
    ]
}
```

```csharp
using ParsedJsonDocument<Notification> doc =
    ParsedJsonDocument<Notification>.Parse("""{"kind":"text","message":"hello"}""");

string result = doc.RootElement.Match(
    matchRequiredKindAndMessage: static (in Notification.RequiredKindAndMessage v) =>
        $"Text: {v.Message}",
    matchRequiredCodeAndKind: static (in Notification.RequiredCodeAndKind v) =>
        $"Code: {(int)v.Code}",
    defaultMatch: static (in Notification _) =>
        "Unknown");

Console.WriteLine(result); // "Text: hello"
```

### Apply — Merging Composed Object Properties

For `allOf`, `anyOf`, and `oneOf` schemas with object components, mutable types include `Apply()` methods that merge properties from a composed type into the mutable document:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<ComposedPerson> doc =
    ParsedJsonDocument<ComposedPerson>.Parse("""{"firstName":"Alice"}""");
using JsonDocumentBuilder<ComposedPerson.Mutable> builder =
    doc.RootElement.BuildDocument(workspace);

// Apply properties from an allOf component
using ParsedJsonDocument<ComposedPerson.ContactInfo> contactDoc =
    ParsedJsonDocument<ComposedPerson.ContactInfo>.Parse("""{"email":"alice@example.com"}""");

ComposedPerson.Mutable root = builder.RootElement;
root.Apply(contactDoc.RootElement);

Console.WriteLine(root.ToString());
// Output: {"firstName":"Alice","email":"alice@example.com"}
```

`Apply()` overwrites properties that already exist and adds new ones. Properties not present in the applied value are left unchanged.

## Serialization

Generated types can be serialized back to JSON:

```csharp
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
Person person = doc.RootElement;

// To string
string output = person.ToString();

// To a Utf8JsonWriter
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
person.WriteTo(writer);
writer.Flush();
byte[] utf8Json = stream.ToArray();
```

## Comparison with Other Approaches

### vs. Manual POCOs

| Feature | Manual POCOs | Generated Types |
|---------|--------------|-----------------|
| **Type Safety** | Manual properties | Auto-generated from schema |
| **Validation** | Manual or FluentValidation | Built-in from schema |
| **Schema Sync** | Manual sync required | Always in sync |
| **Memory Model** | Class-based, allocates objects | Struct-based, minimal allocations |
| **Maintenance** | High — manual updates | Low — regenerates on build |
| **IntelliSense** | Manual doc comments | Auto-generated from schema descriptions |

### vs. System.Text.Json JsonNode

| Feature | JsonNode | Generated Types |
|---------|----------|-----------------|
| **Type Safety** | Weak typing | Strong typing |
| **Validation** | Manual | Built-in from schema |
| **Schema Sync** | N/A | Always in sync |
| **Memory Model** | Class-based, allocates objects | Struct-based, minimal allocations |
| **Maintenance** | N/A | Low — regenerates on build |
| **IntelliSense** | Limited | Auto-generated from schema descriptions |

### vs. NJsonSchema Code Generator

| Feature | NJsonSchema | Corvus SourceGenerator |
|---------|-------------|------------------------|
| **Type Safety** | Strong typing | Strong typing |
| **Validation** | DataAnnotations | Built-in from schema |
| **Schema Sync** | Pre-build tool | Always in sync (compile-time Roslyn) |
| **Memory Model** | Class-based, allocates objects | Struct-based, minimal allocations |
| **Maintenance** | Low — regenerates on demand | Low — regenerates on build |
| **IntelliSense** | Auto-generated | Auto-generated from schema descriptions |

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

1. **Use `ParseValue` for in-memory JSON**: Convenient for short-lived values without explicit document management
2. **Prefer UTF-8 property access**: Use `"key"u8` indexers and UTF-8 overloads to avoid transcoding
3. **Validate selectively**: Only call `EvaluateSchema()` when necessary — it walks the entire document

## Examples

See the complete working example in the `/docs/JsonSchemaSourceGeneratorExample` directory.

## Further Reading

- [JSON Schema Specification](https://json-schema.org/)
- [Corvus.Text.Json Documentation](./README.md)
- [ParsedJsonDocument Guide](./ParsedJsonDocument.md)
- [JsonDocumentBuilder Guide](./JsonDocumentBuilder.md)
