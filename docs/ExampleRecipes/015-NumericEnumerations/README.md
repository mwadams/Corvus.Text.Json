# JSON Schema Patterns in .NET - Numeric Enumerations

This recipe demonstrates how to use JSON Schema `enum` keyword with numeric values to create type-safe numeric enumerations.

## The Pattern

While string enumerations are common, sometimes you need numeric enumerations - perhaps for:
- Integration with existing systems that use numeric codes
- Compact wire format
- Bitwise operations

JSON Schema supports numeric `enum` values just like string values.

## The Schema

File: `status.json`

```json
{
  "enum": [1, 2, 3]
}
```

This constrains values to exactly one of the three numbers: `1`, `2`, or `3`.

## Generated Code Usage

### Using static const instances

The generator creates static const instances for each enum value, accessible via the `EnumValues` class:

```csharp
// Use predefined const instances instead of parsing JSON
Status active = Status.EnumValues.NumberOne;     // value: 1
Status inactive = Status.EnumValues.NumberTwo;   // value: 2  
Status pending = Status.EnumValues.NumberThree;  // value: 3

Console.WriteLine($"Active status: {active}");
// Output: Active status: 1
```

**Benefits of const instances:**
- Zero allocation - reuses the same immutable instance
- Type-safe - no need to parse or validate
- Compile-time correctness - impossible to create invalid enum values
- Performance - no parsing overhead

### Parsing numeric enumeration values

You can also parse from JSON:

```csharp
string json = "1";
using var parsed = ParsedJsonDocument<Status>.Parse(json);
Status status = parsed.RootElement;
Console.WriteLine($"Status: {status}");
// Output: Status: 1
```

### Extracting numeric values

```csharp
// Get the underlying numeric value
if (status.TryGetValue(out int value))
{
    Console.WriteLine($"Numeric value: {value}");
    // Output: Numeric value: 1
}
```

### Pattern matching with numeric enums

Like string enumerations, you can use pattern matching:

```csharp
string DescribeStatus(in Status status)
{
    return status.Match(
        matchNumberOne: static () => "Active - system is running",
        matchNumberTwo: static () => "Inactive - system is stopped",
        matchNumberThree: static () => "Pending - system is starting",
        defaultMatch: static () => throw new InvalidOperationException("Unknown status"));
}
```

## Documented Numeric Enumerations (Advanced Pattern)

The simple `enum` approach above doesn't provide documentation for each value. For better documentation, consider using `oneOf` with `const`:

```json
{
    "oneOf": [
        { "$ref": "#/$defs/Pending" },
        { "$ref": "#/$defs/Active" },
        { "$ref": "#/$defs/Complete" }
    ],
    "$defs": {
        "Pending": {
            "title": "Pending status",
            "description": "The operation is waiting to start",
            "const": 1
        },
        "Active": {
            "title": "Active status",
            "description": "The operation is currently processing",
            "const": 2
        },
        "Complete": {
            "title": "Complete status",
            "description": "The operation has finished",
            "const": 3
        }
    }
}
```

This pattern:
- Provides meaningful names for each numeric value (`Pending`, `Active`, `Complete`)
- Allows rich documentation via `title` and `description`
- Generates separate types for each value instead of generic `EnumNEntity` types
- Prevents implicit numeric conversions, improving type safety

For more details on this pattern, see the [blog post](https://endjin.com/blog/2024/05/json-schema-patterns-dotnet-numeric-enumerations-and-pattern-matching).

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// With the documented pattern (oneOf + const):
// Access constant instances directly
NumericOptions status = NumericOptions.Pending.ConstInstance;

// No implicit numeric conversions (type safe)
// NumericOptions status = 1; // Does not compile

// Explicit conversion allowed but may create invalid values
NumericOptions maybeInvalid = (NumericOptions)19;
if (!maybeInvalid.IsValid())
{
    Console.WriteLine("Invalid!");
}
```

### V5 (Corvus.Text.Json)
```csharp
// Parse from JSON
using var parsed = ParsedJsonDocument<Status>.Parse("1");
Status status = parsed.RootElement;

// Extract numeric value
if (status.TryGetValue(out int value))
{
    Console.WriteLine($"Value: {value}");
}

// Pattern matching with named parameters
string desc = status.Match(
    matchNumberOne: static () => "Pending",
    matchNumberTwo: static () => "Active",
    matchNumberThree: static () => "Complete");
```

**Key differences:**
- V5 uses `ParsedJsonDocument<T>` for parsing
- V5 uses `TryGetValue(out int)` to extract numeric values
- V5 pattern matching uses named parameters based on enum values (`matchNumberOne`, `matchNumberTwo`, `matchNumberThree`)
- V4's `ConstInstance` pattern (for documented enums with `oneOf`+`const`) is not shown in this simple V5 example

## Running the Example

```bash
cd docs/ExampleRecipes/015-NumericEnumerations
dotnet run
```

## Related Patterns

- [014-StringEnumerations](../014-StringEnumerations/) - String-based enumerations
- [013-PolymorphismWithDiscriminators](../013-PolymorphismWithDiscriminators/) - Using `const` for discrimination
- [012-PatternMatching](../012-PatternMatching/) - Discriminated unions with `oneOf`
