# JSON Schema Patterns in .NET - Interfaces and mix-in types

This recipe demonstrates how to compose multiple JSON Schema definitions using `allOf`, creating types that behave like .NET interfaces or mix-ins.

## The Pattern

.NET does not support the concept of multiple-inheritance or [mix-ins](https://en.wikipedia.org/wiki/Mixin).

However, you can implement multiple interfaces on a type.

While interfaces don't (generally) provide implementation ([though that has changed!](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interface-implementation/default-interface-methods-versions)), they do provide structure and semantic intent. This gives us the ability to define functions that operate on a particular interface, without having to know the details of the specific instance.

The equivalent in JSON Schema is to compose multiple schemas using the `allOf` keyword.

`allOf` lets us provide an array of schemas. As the name implies, *all* of the schema constraints are applied: both our local constraints, and those in each of the schemas in the `allOf` array.

You have to take care to ensure that they are mutually compatible, or you can get unexpected validation failures. (We can't be `allOf` a `{"type": "string"}` and a `{"type": "object"}`!).

## The Schemas

### composite-type.json

```json
{
    "title": "A composition of multiple different schema",
    "type": "object",
    "allOf": [
        { "$ref": "./countable.json" },
        { "$ref": "./documentation.json" }
    ],
    "required": [ "budget" ],
    "properties": {
        "budget": { "$ref": "#/$defs/currencyValue" }
    },
    "$defs": {
        "currencyValue": {
            "type": "number",
            "format": "decimal"
        }
    }
}
```

### documentation.json

```json
{
    "type": "object",
    "required": [ "title" ],
    "properties": {
        "description": { "type": "string" },
        "title": { "type": "string" }
    }
}
```

### countable.json

```json
{
    "type": "object",
    "required": [ "count" ],
    "properties": {
        "count": { "$ref": "#/$defs/positiveInt32" }
    },
    "$defs": {
        "positiveInt32": {
            "type": "integer",
            "format": "int32"
        }
    }
}
```

In this example, the composed schema conforms to both the `countable` and `documentation` schemas. These are represented as externally provided schema documents. As always, if they are under your control, you might choose to embed them locally in a single document.

The composite type adds its own additional constraint - a required property called `budget`.

## Generated Code

The code generator produces three types:
- **`Documentation`** - has `title` (required) and `description` (optional) properties
- **`Countable`** - has `count` (required) property
- **`CompositeType`** - combines both via `allOf` and adds `budget` (required)

Note that `CurrencyValue` is not generated. The code generator detected that the final definition reduces to a built-in type (`decimal`), avoiding unnecessary code.

## Usage Examples

### Parsing a composite type

```csharp
string compositeJson = """
    {
      "budget": 123.7,
      "count": 4,
      "title": "Greeting",
      "description": "Hello world"
    }
    """;

using var parsedComposite = ParsedJsonDocument<CompositeType>.Parse(compositeJson);
CompositeType composite = parsedComposite.RootElement;

Console.WriteLine(composite);
```

### Converting to composed types

Like implementing multiple interfaces, you can implicitly convert the composite type to any of its `allOf` constituents:

```csharp
// Implicit conversion to the composed types
Documentation documentation = composite;
Countable countable = composite;

// Access properties from each "interface"
Console.WriteLine($"Title: {documentation.Title}");
Console.WriteLine($"Count: {countable.Count}");
Console.WriteLine($"Budget: {composite.Budget}");
```

### Working with optional properties

```csharp
if (documentation.TryGetProperty("description"u8, out var description))
{
    Console.WriteLine($"Description: {description.GetString()}");
}
```

### Functions operating on composed types

You can write functions that accept any type conforming to a particular schema, similar to working with interfaces:

```csharp
void ProcessDocumentation(in Documentation doc)
{
    Console.WriteLine($"Title: {doc.Title}");
    if (doc.TryGetProperty("description"u8, out var desc))
    {
        Console.WriteLine($"Description: {desc.GetString()}");
    }
}

void ProcessCountable(in Countable c)
{
    Console.WriteLine($"Count: {c.Count}");
}

// Call with composite type
ProcessDocumentation(documentation);
ProcessCountable(countable);
```

Note the use of the `in` modifier to avoid unnecessary copying of the struct values.

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Create directly
CompositeType composite = CompositeType.Create(123.7m, 4, "Greeting", "Hello world");

// Implicit conversion to composed types
Documentation documentation = composite;
Countable countable = composite;

// Check optional properties
if (documentation.Description.IsNotUndefined())
{
    Console.WriteLine($"Description: {documentation.Description}");
}
```

### V5 (Corvus.Text.Json)
```csharp
// Parse from JSON (no direct Create method)
using var parsedComposite = ParsedJsonDocument<CompositeType>.Parse(compositeJson);
CompositeType composite = parsedComposite.RootElement;

// Implicit conversion to composed types (same as V4)
Documentation documentation = composite;
Countable countable = composite;

// Check optional properties with generated property (not TryGetProperty)
if (!documentation.Description.IsUndefined())
{
    Console.WriteLine($"Description: {documentation.Description}");
}
```

**Key differences:**
- V5 uses the generated `Description` property with `IsUndefined()` instead of V4's `IsNotUndefined()`
- V5 doesn't generate static `Create()` methods for complex compositions (use `CreateBuilder()` instead)
- Implicit conversion to `allOf` constituents works the same in both versions

## Running the Example

```bash
cd docs/ExampleRecipes/011-InterfacesAndMixInTypes
dotnet run
```

## Related Patterns

- [003-ReusingCommonTypes](../003-ReusingCommonTypes/) - Using `$ref` and `$defs` for shared types
- [005-ExtendingABaseType](../005-ExtendingABaseType/) - Inheritance via `allOf` with a single base
- [012-PatternMatching](../012-PatternMatching/) - Discriminated unions with `oneOf`
