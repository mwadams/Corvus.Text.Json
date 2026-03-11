# Getting Started with Code Generation

Generate strongly-typed C# from JSON Schema using the Corvus.Text.Json source generator or the `generatejsonschematypes` CLI tool.

## Table of Contents

- [Setup](#setup)
- [Define a Schema](#define-a-schema)
  - [Understanding the Schema](#understanding-the-schema)
- [Generate a Type](#generate-a-type)
  - [How Generated Types Work](#how-generated-types-work)
- [Parsing](#parsing)
- [Property Access](#property-access)
  - [Converting to .NET Types](#converting-to-net-types)
  - [Values, Null, and Undefined](#values-null-and-undefined)
  - [Additional Properties](#additional-properties)
  - [JSON Property Names](#json-property-names)
  - [Enumerating Properties](#enumerating-properties)
- [Serialization](#serialization)
- [Formatting](#formatting)
- [Equality and Comparison](#equality-and-comparison)
- [Validation](#validation)
- [Creating Objects from Scratch](#creating-objects-from-scratch)
- [Mutating Properties](#mutating-properties)
- [Removing Properties](#removing-properties)
- [Default Property Values](#default-property-values)
- [Arrays](#arrays)
- [Tuples](#tuples)
- [Composition Types](#composition-types)
- [Enum Types](#enum-types)
- [Schema References](#schema-references)
- [Configuration](#configuration)
- [CLI Tool](#cli-tool)
- [Memory Management](#memory-management)
- [Troubleshooting](#troubleshooting)

---

## Setup

### Source generator (recommended)

Add the source generator and runtime packages to your `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="Corvus.Text.Json.SourceGenerator" Version="5.0.0">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Corvus.Text.Json" Version="5.0.0" />
</ItemGroup>
```

Register your JSON Schema files as `AdditionalFiles`:

```xml
<ItemGroup>
  <AdditionalFiles Include="Schemas\person.json" />
</ItemGroup>
```

### CLI tool

Install the `generatejsonschematypes` .NET tool globally:

```bash
dotnet tool install --global Corvus.Text.Json.CodeGenerator
```

Generate code from a schema:

```bash
generatejsonschematypes \
  --rootNamespace MyApp.Models \
  --outputPath Generated/ \
  Schemas/person.json
```

The CLI tool and the source generator share the same code generation engine and produce identical output.

---

## Define a Schema

Create a JSON Schema file, for example `Schemas/person.json`:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "title": "Person",
    "$defs": {
        "PersonName": {
            "type": "object",
            "description": "A name of a person.",
            "required": ["familyName"],
            "properties": {
                "givenName": {
                    "$ref": "#/$defs/PersonNameElement",
                    "description": "The person's given name."
                },
                "familyName": {
                    "$ref": "#/$defs/PersonNameElement",
                    "description": "The person's family name."
                },
                "otherNames": {
                    "$ref": "#/$defs/OtherNames",
                    "description": "Other (middle) names."
                }
            }
        },
        "OtherNames": {
            "oneOf": [
                { "$ref": "#/$defs/PersonNameElement" },
                { "$ref": "#/$defs/PersonNameElementArray" }
            ]
        },
        "PersonNameElementArray": {
            "type": "array",
            "items": { "$ref": "#/$defs/PersonNameElement" }
        },
        "PersonNameElement": {
            "type": "string",
            "minLength": 1,
            "maxLength": 256
        },
        "Address": {
            "type": "object",
            "properties": {
                "street": { "type": "string" },
                "city": { "type": "string" },
                "zipCode": { "type": "string" }
            }
        }
    },
    "type": "object",
    "required": ["name"],
    "properties": {
        "name": { "$ref": "#/$defs/PersonName" },
        "dateOfBirth": {
            "type": "string",
            "format": "date"
        },
        "age": {
            "type": "integer",
            "format": "int32",
            "minimum": 0,
            "maximum": 150
        },
        "email": {
            "type": "string",
            "format": "email"
        },
        "address": { "$ref": "#/$defs/Address" },
        "hobbies": {
            "type": "array",
            "items": { "type": "string" }
        }
    }
}
```

Both draft 2020-12 and draft 2019-09 are supported. If your schema does not declare a `$schema` keyword, you can set the fallback vocabulary via [MSBuild properties](#configuration).

### Understanding the schema

Let's walk through this schema to understand how it maps to generated C#.

The `Person` type is an object with a required `name` property and several optional properties: `dateOfBirth` (a formatted date string), `age` (an integer from 0 to 150), `email`, `address` (a nested object with `street`, `city`, and `zipCode`), and `hobbies` (an array of strings). The `name` property references a `PersonName` definition via `$ref`.

`PersonName` has a required `familyName` and optional `givenName` — both constrained to 1–256 character strings via the `PersonNameElement` definition. The `otherNames` property uses `oneOf` to accept *either* a single string *or* an array of strings. This is a common JSON Schema pattern for backwards-compatible API evolution — a union type (sometimes called a [discriminated union](https://en.wikipedia.org/wiki/Tagged_union)) that lets the same property accept multiple shapes:

```json
// A single string
{ "familyName": "Oldroyd", "givenName": "Michael", "otherNames": "Francis James" }

// Or an array of strings
{ "familyName": "Oldroyd", "givenName": "Michael", "otherNames": ["Francis", "James"] }
```

> C# developers may not have encountered this pattern naturally — *either-this-or-that* is not a language-supported idiom. But in JSON Schema, union types via `oneOf`/`anyOf` are everywhere. The code generator handles them by producing [composition types](#composition-types) with `TryGetAs*()` and `Match()` methods for type-safe discrimination.

The code generator walks the schema tree from the root type and generates C# for every schema it encounters. Unreferenced definitions (like a `Link` type that exists in `$defs` but isn't referenced by `Person`) are *not* generated — only reachable schema elements produce types.

Each schema element typically produces multiple partial-class files by concern (e.g., `Person.cs`, `Person.JsonSchema.cs`, `Person.Mutable.cs`). Nested entity types like `PersonName` become nested structs within the parent type (e.g., `Person.PersonNameEntity`), keeping the namespace clean and minimizing type name clashes.

---

## Generate a Type

Declare a `partial struct` annotated with `JsonSchemaTypeGenerator`:

```csharp
using Corvus.Text.Json;

namespace MyApp.Models;

[JsonSchemaTypeGenerator("Schemas/person.json")]
public readonly partial struct Person;
```

Build the project. The generator produces the full implementation, deriving the **namespace**, **accessibility**, and **type name** from this declaration.

### How generated types work

Generated types are `readonly struct` values that act as thin wrappers over the underlying JSON data. When you parse a JSON document, the data is stored as UTF-8 bytes in pooled memory. The generated struct is essentially an index into that data — it doesn't copy or deserialize the JSON upfront.

Values are converted to .NET primitives like `string`, `int`, or `LocalDate` only at the point of use, when you access a property or perform a cast. This "just-in-time" model means:

- **No allocation on construction** — creating a `Person` from a parsed document is essentially free (a small struct on the stack).
- **No redundant copying** — the underlying UTF-8 bytes are shared, not cloned.
- **Conversion cost is deferred** — you only pay for what you access.

This is particularly powerful when processing large JSON payloads where you only need a few fields, or when passing JSON data through a pipeline where intermediate stages don't need to inspect every property.

---

## Parsing

### ParsedJsonDocument (preferred)

`ParsedJsonDocument<T>` manages a pooled-memory document. Dispose it when you're done:

```csharp
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse(
        """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
Person person = doc.RootElement;
```

### ParseValue (convenience)

Returns a self-owned value — no explicit disposal needed, but the backing memory is not shared:

```csharp
Person person = Person.ParseValue(
    """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
```

### Other sources

```csharp
// From UTF-8 bytes
Person person = Person.ParseValue(
    """{"name":{"familyName":"Oldroyd"},"age":30}"""u8);

// From a stream
using FileStream stream = File.OpenRead("person.json");
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(stream);
```

---

## Property Access

Each schema property generates a typed accessor returning a nested entity struct:

```csharp
Person person = doc.RootElement;

// Required property — name is a nested PersonName object
string familyName = (string)person.Name.FamilyName;

// Optional properties — may be Undefined when absent
if (person.Age.IsNotUndefined())
{
    int age = (int)person.Age;
}

if (person.Email.IsNotUndefined())
{
    string email = (string)person.Email;
}
```

### Property indexers

Access properties dynamically by name, returning a `JsonElement`:

```csharp
// UTF-8 string literal (preferred — avoids transcoding)
JsonElement name = person["name"u8];

// String overload also available (transcodes to UTF-8 internally)
JsonElement age = person["age"];
```

### TryGetProperty

```csharp
if (person.TryGetProperty("email"u8, out JsonElement email))
{
    Console.WriteLine((string)email);
}
```

### Converting to .NET Types

Generated entity types provide multiple ways to extract the underlying .NET value.

#### Explicit cast operators

The most concise approach — cast directly to the target primitive:

```csharp
string familyName = (string)person.Name.FamilyName;
int age = (int)person.Age;
```

#### TryGetValue

A safe, non-throwing alternative that returns `false` if the value is absent or cannot be converted:

```csharp
if (person.Age.TryGetValue(out int age)) { ... }
if (person.Name.FamilyName.TryGetValue(out string? name)) { ... }
```

#### GetString and GetUtf8String

For string-valued properties:

```csharp
// As a .NET string
string familyName = person.Name.FamilyName.GetString();

// As an UnescapedUtf8JsonString (avoids allocation — always dispose)
using UnescapedUtf8JsonString utf8Name = person.Name.FamilyName.GetUtf8String();
ReadOnlySpan<byte> bytes = utf8Name.Span;
```

#### Numeric types

Numeric properties (with or without a `format` keyword) support a range of .NET numeric types:

| Format | Primary access | .NET type |
|---|---|---|
| *(none / `"type": "number"`)* | `TryGetValue(out double)`, `GetDouble()` | `double` |
| *(none / `"type": "integer"`)* | `TryGetValue(out long)`, `GetInt64()` | `long` |
| `int32` | `TryGetValue(out int)`, `GetInt32()` | `int` |
| `int64` | `TryGetValue(out long)`, `GetInt64()` | `long` |
| `int128` | `TryGetValue(out Int128)` | `Int128` |
| `double` | `TryGetValue(out double)`, `GetDouble()` | `double` |
| `single` | `TryGetValue(out float)` | `float` |
| `half` | `TryGetValue(out Half)` | `Half` |
| `decimal` | `TryGetValue(out decimal)` | `decimal` |
| `byte` | `TryGetValue(out byte)` | `byte` |
| `sbyte` | `TryGetValue(out sbyte)` | `sbyte` |
| `int16` | `TryGetValue(out short)` | `short` |
| `uint16` | `TryGetValue(out ushort)` | `ushort` |
| `uint32` | `TryGetValue(out uint)` | `uint` |
| `uint64` | `TryGetValue(out ulong)` | `ulong` |
| `uint128` | `TryGetValue(out UInt128)` | `UInt128` |

Arbitrary-precision types are also available:

```csharp
if (value.TryGetValue(out BigNumber bn)) { ... }  // Corvus.Numerics.BigNumber
if (value.TryGetValue(out BigInteger bi)) { ... }  // System.Numerics.BigInteger
```

#### String format types

String properties with a recognized `format` keyword map to specific .NET types:

| Format | Access | .NET type |
|---|---|---|
| *(plain string)* | `GetString()`, `GetUtf8String()`, `TryGetValue(out string?)` | `string` / `UnescapedUtf8JsonString` |
| `date` | `TryGetValue(out LocalDate)` | `LocalDate` (NodaTime) |
| `date-time` | `TryGetValue(out OffsetDateTime)` or `TryGetDateTimeOffset(out DateTimeOffset)` | `OffsetDateTime` (NodaTime) / `DateTimeOffset` |
| `time` | `TryGetValue(out OffsetTime)` | `OffsetTime` (NodaTime) |
| `duration` | `TryGetValue(out Period)` | `Period` (NodaTime) |
| `uuid` | `TryGetGuid(out Guid)` | `Guid` |
| `uri` | `TryGetValue(out Utf8UriValue)` | `Utf8UriValue` |
| `uri-reference` | `TryGetValue(out Utf8UriReferenceValue)` | `Utf8UriReferenceValue` |
| `iri` | `TryGetValue(out Utf8IriValue)` | `Utf8IriValue` |
| `iri-reference` | `TryGetValue(out Utf8IriReferenceValue)` | `Utf8IriReferenceValue` |

> **Note**: URI/IRI types (`Utf8UriValue`, etc.) are `readonly struct` types that hold the parsed value as UTF-8 bytes, avoiding UTF-16 string allocations. NodaTime types provide correct calendar and timezone handling beyond what `DateTime`/`DateTimeOffset` offer.

#### Type coercion between entity types

An instance of any generated type can be converted to any other generated type. This is possible because all generated types are views over the same underlying JSON data. In V5, this is done via `TargetType.From(source)`:

```csharp
Person.PersonNameEntity nameEntity = person.Name;
JsonElement element = (JsonElement)nameEntity;
OtherType.NameEntity other = OtherType.NameEntity.From(element);
```

Converting between types doesn't validate the data — it just reinterprets the JSON through a different type's lens. The resulting instance may or may not be valid according to the target schema. Always call `EvaluateSchema()` if you need to verify validity after a conversion.

### Values, Null, and Undefined

JSON values exist in three states, which is subtly different from the .NET model where values are either present or `null`:

```json
{ "foo": 3.14 }   // Present with a value
{ "foo": null }    // Present but null
{}                 // Not present ("undefined")
```

Generated types expose this three-state model through `ValueKind` and helper methods:

```csharp
// Check the state of an optional property
if (person.Email.IsNotUndefined())
{
    // The property exists in the JSON (may still be null)
    string email = (string)person.Email;
}

// Other state checks
person.Email.IsUndefined()       // true if the property is absent from the JSON
person.Email.IsNull()            // true if the property is present but null
person.Email.IsNullOrUndefined() // true if null or absent
person.Email.IsNotNullOrUndefined() // true if present with a non-null value
```

When you attempt to cast an undefined or null value to a .NET type (e.g., `(string)person.Email` when `email` is absent), it throws an `InvalidOperationException`. Always check before casting optional properties.

> **Tip:** If you prefer the .NET nullable idiom, you can configure the generator to emit optional properties as `T?` — see [OptionalAsNullable](#optionalAsnullable) in the Configuration section:
> ```csharp
> if (person.Email is { } email)
> {
>     Console.WriteLine((string)email);
> }
> ```

### Additional properties

By default, JSON Schema allows additional properties on an object — properties beyond those declared in the schema. You can access these dynamically:

```csharp
// Access a known additional property by name
if (person.TryGetProperty("occupation"u8, out JsonElement occupation))
{
    if (occupation.ValueKind == JsonValueKind.String)
    {
        Console.WriteLine((string)occupation);
    }
}
```

### JSON Property Names

Generated types include a `JsonPropertyNames` class with constants for each schema property:

```csharp
// String constant
string nameKey = Person.JsonPropertyNames.Name;          // "name"

// UTF-8 span (zero-allocation)
ReadOnlySpan<byte> nameUtf8 = Person.JsonPropertyNames.NameUtf8;
```

### Enumerating properties

You can enumerate all properties on an object — both schema-declared and additional:

```csharp
foreach (JsonObjectProperty property in person.EnumerateObject())
{
    Console.WriteLine($"{property.Name}: {property.Value}");
}
```

To filter out well-known properties and work only with additional ones, use the `JsonPropertyNames` constants:

```csharp
foreach (JsonObjectProperty property in person.EnumerateObject())
{
    if (property.NameEquals(Person.JsonPropertyNames.NameUtf8) ||
        property.NameEquals(Person.JsonPropertyNames.DateOfBirthUtf8))
    {
        continue; // Skip declared properties
    }

    Console.WriteLine($"{property.Name}: {property.Value}");
}
```

> Using the `NameEquals()` method with the pre-encoded `*Utf8` property names avoids allocating strings for comparison.

---

## Serialization

```csharp
// To a JSON string
string json = person.ToString();

// To a Corvus.Text.Json.Utf8JsonWriter (not System.Text.Json!)
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
person.WriteTo(writer);
```

---

## Formatting

Where the schema includes a recognized `format` keyword (e.g., `date-time`, `date`, `time`, `uri`, `uuid`) or a numeric type (with or without a `format` keyword), the generated entity type implements `IFormattable`, `ISpanFormattable`, and `IUtf8SpanFormattable`:

```csharp
// IFormattable
string formatted = person.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

// ISpanFormattable
Span<char> charBuffer = stackalloc char[64];
person.DateOfBirth.TryFormat(charBuffer, out int charsWritten, "O", CultureInfo.InvariantCulture);

// IUtf8SpanFormattable
Span<byte> utf8Buffer = stackalloc byte[64];
person.DateOfBirth.TryFormat(utf8Buffer, out int bytesWritten, "O", CultureInfo.InvariantCulture);
```

---

## Equality and Comparison

Generated types support value equality:

```csharp
Person a = Person.ParseValue(json);
Person b = Person.ParseValue(json);

bool equal = a.Equals(b);  // true — deep JSON equality
bool same  = a == b;        // operator overload
```

---

## Validation

JSON Schema uses a [duck-typing](https://en.wikipedia.org/wiki/Duck_typing) model rather than a rigid type system. It describes the *shape* of valid data with constraints like "it must have these properties", "it must match one of these shapes", or "this value must be between 0 and 150". When you construct a generated type from JSON data, you can safely use it through that type **if and only if** the data is valid according to the schema.

Importantly, constructing a generated type from invalid JSON does **not** throw — the type is permissive. You can still access the parts of the data that *are* present. This is valuable for error reporting, diagnostics, and self-healing systems where you need to inspect malformed data rather than have the library explode in your face.

### Basic validation

```csharp
bool isValid = person.EvaluateSchema();
```

### Detailed results

Pass a `JsonSchemaResultsCollector` to collect error messages and locations:

```csharp
using JsonSchemaResultsCollector collector =
    JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.Detailed);

bool isValid = person.EvaluateSchema(collector);

if (!isValid)
{
    foreach (JsonSchemaResultsCollector.Result r in collector.EnumerateResults())
    {
        if (!r.IsMatch)
        {
            Console.WriteLine(
                $"Error at {r.GetDocumentEvaluationLocationText()}: {r.GetMessageText()}");
        }
    }
}
```

### Validation levels

| Level | Description |
|---|---|
| *(no collector)* | Fastest — returns only `bool` |
| `JsonSchemaResultsLevel.Basic` | Failure messages only |
| `JsonSchemaResultsLevel.Detailed` | Failure messages with schema and document locations |
| `JsonSchemaResultsLevel.Verbose` | All events including successful validations |

---

## Creating Objects from Scratch

Use `CreateBuilder()` with `Build()` and `Create()` for zero-allocation construction:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var builder = Person.CreateBuilder(
    workspace,
    (ref b) => b.Create(
        name: Person.PersonNameEntity.Build(
            (ref nb) => nb.Create(familyName: "Oldroyd"u8, givenName: "Michael"u8)),
        age: 30,
        email: "michael@example.com"u8));

Console.WriteLine(builder.RootElement.ToString());
// {"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30,"email":"michael@example.com"}
```

Required parameters must be provided; optional ones can be omitted.

### Nested objects

Use `NestedType.Build()` to compose nested values:

```csharp
using var builder = Person.CreateBuilder(
    workspace,
    (ref b) => b.Create(
        name: Person.PersonNameEntity.Build(
            (ref nb) => nb.Create(familyName: "Oldroyd"u8, givenName: "Michael"u8)),
        age: 30,
        address: Person.AddressEntity.Build((ref ab) => ab.Create(
            street: "123 Main St"u8,
            city: "Springfield"u8))));
```

### Array properties

```csharp
hobbies: Person.HobbiesEntity.Build((ref hb) =>
{
    hb.Add("reading"u8);
    hb.Add("hiking"u8);
})
```

### Deeply nested example

```csharp
using var builder = Person.CreateBuilder(
    workspace,
    (ref b) => b.Create(
        name: Person.PersonNameEntity.Build(
            (ref nb) => nb.Create(familyName: "Hopper"u8, givenName: "Grace"u8)),
        age: 42,
        address: Person.AddressEntity.Build((ref ab) => ab.Create(
            street: "123 Navy Yard"u8,
            city: "Washington"u8,
            zipCode: "20001"u8)),
        hobbies: Person.HobbiesEntity.Build((ref hb) =>
        {
            hb.Add("reading"u8);
            hb.Add("coding"u8);
        })));
```

---

## Mutating Properties

Generated types are immutable by default. To mutate, create a `JsonDocumentBuilder` via a `JsonWorkspace`:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse(
        """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
using var builder = doc.RootElement.CreateBuilder(workspace);

Person.Mutable root = builder.RootElement;
root.SetAge(31);
root.SetEmail("michael@example.com"u8);

Console.WriteLine(root.ToString());
// {"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":31,"email":"michael@example.com"}
```

### Version tracking

The builder tracks a version number, and every `Mutable` element reference records the version at which it was obtained. If the document structure changes after you captured a reference (e.g., adding or removing a property on a *different* element), attempting to use that stale reference throws an `InvalidOperationException` — protecting you from silently working with outdated data.

However, you can make multiple modifications to the *same* entity without re-obtaining it:

```csharp
Person.Mutable root = builder.RootElement;

// These are fine — modifying properties on the same element
root.SetAge(31);
root.SetEmail("michael@example.com"u8);

// Navigating into a nested element and mutating it is also fine
root.Address.SetCity("London"u8); // in-place; no need to rebuild root
```

If a structural change invalidates your reference, re-obtain it from `builder.RootElement`:

```csharp
Person.Mutable root = builder.RootElement;
Person.PersonNameEntity.Mutable name = root.Name; // cache a nested reference

root.RemoveEmail();              // structural change
root = builder.RootElement;      // re-obtain root after structural change
name = root.Name;                // re-obtain nested references too
int age = (int)root.Age;         // safe to use again
```

The standard mutation workflow is:

1. Parse JSON into a `ParsedJsonDocument<T>`
2. Create a `JsonDocumentBuilder<T.Mutable>` via `.CreateBuilder(workspace)`
3. Get the `Mutable` root element from the builder
4. Call `Set*()` / `Remove*()` methods on the mutable element
5. Serialize via `root.WriteTo(writer)`, `root.ToString()`, or convert to immutable via `.Clone()`

---

## Removing Properties

Optional properties can be removed from mutable instances:

```csharp
root.RemoveEmail();
```

---

## Default Property Values

When a schema defines `"default"`, the immutable property getter returns that default for absent properties:

```json
{
    "properties": {
        "status": { "type": "string", "default": "active" },
        "count": { "type": "integer", "format": "int32", "default": 0 }
    }
}
```

```csharp
// "status" and "count" are absent from the JSON
string status = (string)config.Status; // "active"
int count = (int)config.Count;         // 0
```

Each property entity type exposes a `DefaultInstance` static property initialized at class load time.

---

## Arrays

### Indexing and enumeration

```csharp
// Get length
int length = items.GetArrayLength();

// Index access
var first = items[0];

// Enumerate
foreach (var item in items.EnumerateArray())
{
    Console.WriteLine(item.ToString());
}
```

### Mutation

Array types include `InsertItem()`, `RemoveAt()`, and `SetItem()`:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<NumberArray> doc =
    ParsedJsonDocument<NumberArray>.Parse("[1,2,3]");
using var builder = doc.RootElement.CreateBuilder(workspace);

NumberArray.Mutable root = builder.RootElement;
root.InsertItem(1, 99);  // [1,99,2,3]
root.RemoveAt(3);      // [1,99,2]
root.SetItem(0, 42);     // [42,99,2]
```

### Creating arrays from scratch

```csharp
using var builder = NumberArray.CreateBuilder(
    workspace,
    NumberArray.Build((ref b) =>
    {
        b.Add(10);
        b.Add(20);
        b.Add(30);
    }));
```

---

## Tuples

Schemas using `prefixItems` generate tuple-like types with positional accessors:

```json
{
    "prefixItems": [
        { "type": "string" },
        { "type": "integer", "format": "int32" },
        { "type": "boolean" }
    ],
    "items": false
}
```

```csharp
// Positional access via Item1, Item2, Item3 etc.
string first = (string)tuple.Item1;
int second = (int)tuple.Item2;
bool third = (bool)tuple.Item3;

// Index access (returns JsonElement)
JsonElement element = tuple[0];
```

### Creating tuples

```csharp
using var builder = MyTuple.CreateBuilder(
    workspace,
    MyTuple.Build(
        static (ref b) => b.CreateTuple(
            item1: "hello"u8,
            item2: 42,
            item3: true)));
```

---

## Composition Types

### `oneOf` / `anyOf` — TryGetAs

Check which variant matches:

```csharp
if (value.TryGetAsRequiredKindAndMessage(out var textVariant))
{
    Console.WriteLine((string)textVariant.Message);
}
else if (value.TryGetAsRequiredCodeAndKind(out var codeVariant))
{
    Console.WriteLine((int)codeVariant.Code);
}
```

### `oneOf` / `anyOf` — exhaustive Match

`Match()` provides type-safe discrimination with a delegate per variant:

```csharp
string result = notification.Match(
    matchRequiredKindAndMessage: static (in Notification.RequiredKindAndMessage v) =>
        $"Text: {v.Message}",
    matchRequiredCodeAndKind: static (in Notification.RequiredCodeAndKind v) =>
        $"Code: {(int)v.Code}",
    defaultMatch: static (in Notification _) =>
        "Unknown");
```

A context-passing overload avoids closure allocations:

```csharp
string result = notification.Match(
    myContext,
    matchRequiredKindAndMessage: static (in MyContext ctx, in Notification.RequiredKindAndMessage v) =>
        $"{ctx.Prefix}: {v.Message}",
    ...);
```

### `allOf` / `anyOf` / `oneOf` — Apply

Mutable types include `Apply()` methods that merge properties from a composed type:

```csharp
root.Apply(contactInfo);
```

---

## Enum Types

Schemas using `enum` generate types with exhaustive `Match()`:

```json
{
    "type": "string",
    "enum": ["active", "inactive", "pending"]
}
```

```csharp
string label = status.Match(
    matchActive: static () => "Active",
    matchInactive: static () => "Inactive",
    matchPending: static () => "Pending",
    defaultMatch: static () => "Unknown");
```

### EnumValues

Iterate all enum values:

```csharp
foreach (var value in StatusEnum.EnumValues)
{
    Console.WriteLine((string)value);
}
```

---

## Schema References

### `$ref` and `$defs`

Reference definitions within the same file:

```json
{
    "$defs": {
        "Address": {
            "type": "object",
            "properties": {
                "street": { "type": "string" },
                "city": { "type": "string" }
            }
        }
    },
    "type": "object",
    "properties": {
        "home": { "$ref": "#/$defs/Address" },
        "work": { "$ref": "#/$defs/Address" }
    }
}
```

Generate from a specific definition using a JSON Pointer in the attribute:

```csharp
[JsonSchemaTypeGenerator("schema.json#/$defs/Person")]
public readonly partial struct Person;
```

### External file references

Schemas can reference other files by filename or by `$id`. If the referenced file declares an `$id`, you can use that URI in `$ref` instead of the relative file path:

```json
// address.json
{
    "$id": "https://example.com/schemas/address",
    "type": "object",
    "properties": {
        "street": { "type": "string" },
        "city": { "type": "string" }
    }
}
```

```json
// person.json — reference by $id
{
    "properties": {
        "home": { "$ref": "https://example.com/schemas/address" }
    }
}
```

```json
// person.json — or reference by filename
{
    "properties": {
        "home": { "$ref": "address.json" }
    }
}
```

Ensure all referenced files are registered as `AdditionalFiles`, regardless of whether they are referenced by `$id` or filename:

```xml
<ItemGroup>
  <AdditionalFiles Include="Schemas/person.json" />
  <AdditionalFiles Include="Schemas/address.json" />
</ItemGroup>
```

---

## Configuration

### MSBuild properties

Set these in your `.csproj` to control code generation:

#### OptionalAsNullable

```xml
<PropertyGroup>
  <CorvusTextJsonOptionalAsNullable>NullOrUndefined</CorvusTextJsonOptionalAsNullable>
</PropertyGroup>
```

**Default (off):** Optional properties return the entity struct directly. Check `IsNotUndefined()` when absent:

```csharp
if (person.Email.IsNotUndefined()) { ... }
```

**NullOrUndefined:** Optional properties return `T?`:

```csharp
if (person.Email is { } email) { ... }
```

#### FallbackVocabulary

Specifies the default schema vocabulary for files that omit `$schema`:

```xml
<PropertyGroup>
  <CorvusTextJsonFallbackVocabulary>draft2020-12</CorvusTextJsonFallbackVocabulary>
</PropertyGroup>
```

### Viewing generated code

Write generated files to `obj/` for inspection:

```xml
<PropertyGroup>
  <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
</PropertyGroup>
```

---

## CLI Tool

The `generatejsonschematypes` CLI tool shares the same engine as the source generator:

```bash
generatejsonschematypes \
  --rootNamespace MyApp.Models \
  --outputPath Generated/ \
  --outputRootTypeName Person \
  Schemas/person.json
```

Key options:

| Option | Description |
|---|---|
| `--rootNamespace` | C# namespace for generated types |
| `--outputPath` | Directory for generated `.cs` files |
| `--outputRootTypeName` | Name for the root type |
| `--optionalAsNullable` | Treat optional properties as nullable |

---

## Memory Management

### Disposal hierarchy

```
JsonWorkspace                     (scoped container for mutation)
  └─ JsonDocumentBuilder<T>       (mutable document — dispose when done)

ParsedJsonDocument<T>             (independent — for read-only parsing)
  └─ T                            (lightweight index, no disposal needed)
```

- **Always dispose** `ParsedJsonDocument<T>` and `JsonDocumentBuilder<T>` — they use pooled memory.
- **`JsonWorkspace`** must outlive all builders created from it. Use a `using` block.
- **Element values** (`Person`, `JsonElement`, etc.) are lightweight struct indexes — no disposal needed.
- After mutation, re-obtain element references from `builder.RootElement`.

---

## Troubleshooting

### Generated code not appearing

1. Clean and rebuild: `dotnet clean && dotnet build`
2. Verify schema files are registered as `<AdditionalFiles>`
3. Enable `<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>` to inspect output

### Compilation errors in generated code

1. Validate your schema with an online JSON Schema validator
2. Ensure you're using a supported draft (draft 4, draft 6, draft 7, 2019-09, or 2020-12)
3. Check build output for source generator diagnostics

### Performance tips

1. Use `ParsedJsonDocument<T>` for explicit lifetime control in production
2. Prefer UTF-8 property access (`"key"u8`) to avoid transcoding
3. Call `EvaluateSchema()` selectively — it walks the entire document

---

## Further Reading

- [Migrating from V4 to V5](./MigratingFromV4ToV5.md)
- [ParsedJsonDocument Guide](./ParsedJsonDocument.md)
- [JsonDocumentBuilder Guide](./JsonDocumentBuilder.md)
- [JSON Schema Specification](https://json-schema.org/)
