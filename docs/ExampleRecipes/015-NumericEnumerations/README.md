# JSON Schema Patterns in .NET - Numeric Enumerations

This recipe demonstrates how to use JSON Schema `enum` keyword with numeric values to create type-safe numeric enumerations.

## The Pattern

While string enumerations are common, sometimes you need numeric enumerations - perhaps for:
- Integration with existing systems that use numeric codes
- Compact wire format
- Bitwise operations

JSON Schema supports numeric `enum` values just like string values.

## The Pattern

Using `oneOf` with `const` to create documented numeric enumerations.

While you could use a simple `enum` array (`{"enum": [1, 2, 3]}`), that approach loses documentation context. The `oneOf` + `const` pattern provides:
- Named definitions for each value
- Title and description for each option
- Better IDE support and documentation generation

## The Schema

File: `status.json`

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
      "description": "The operation is currently running",
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

This creates a numeric enumeration with three documented values. Each `const` defines a specific numeric value (1, 2, or 3), and the `title` and `description` provide context that will appear in generated documentation.

## Generated Code Usage

### Using static const instances

The generator creates a static const instance for each `oneOf` variant:

```csharp
// Use predefined const instances - zero allocation
Status pending = Status.Pending.ConstInstance;      // value: 1
Status active = Status.Active.ConstInstance;        // value: 2
Status complete = Status.Complete.ConstInstance;    // value: 3

Console.WriteLine($"Active status: {active}");
// Output: Active status: 2
```

**Benefits of const instances:**
- Zero allocation - reuses the same immutable instance
- Type-safe - compile-time correctness prevents invalid values
- Self-documenting - named instances (Pending, Active, Complete) instead of magic numbers
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

### Validating enumeration values

You can use `EvaluateSchema()` to check whether a parsed value matches one of the defined enum constants:

```csharp
using var invalidDoc = ParsedJsonDocument<Status>.Parse("99");
Status invalid = invalidDoc.RootElement;
Console.WriteLine($"Status {invalid} is valid: {invalid.EvaluateSchema()}");
// Output: Status 99 is valid: False
```

### Pattern matching with documented variants

With the `oneOf` + `const` pattern, you get named pattern matching based on the variant types:

```csharp
string DescribeStatus(in Status status)
{
    return status.Match(
        matchPending: static (in Status.Pending _) => "Pending - waiting to start",
        matchActive: static (in Status.Active _) => "Active - currently running",
        matchComplete: static (in Status.Complete _) => "Complete - finished",
        defaultMatch: static (in Status _) => "Unknown status");
}
```

The match parameters use the names from your `$defs` (Pending, Active, Complete), making the code self-documenting. Each variant is a distinct type, providing full type safety.

### Pattern matching with context

You can pass additional state through the match:

```csharp
string ProcessStatus(in Status status, int requestCount)
{
    return status.Match(
        requestCount,  // context parameter
        matchPending: static (in Status.Pending _, in int count) => 
            $"Queued {count} requests - system pending",
        matchActive: static (in Status.Active _, in int count) => 
            $"Processing {count} requests on active system",
        matchComplete: static (in Status.Complete _, in int count) => 
            $"Cannot process {count} requests - system complete",
        defaultMatch: static (in Status _, in int count) => 
            throw new InvalidOperationException($"Unknown status cannot process {count} requests"));
}
```

## Why Use oneOf + const Instead of enum?

The simple `enum` approach (`{"enum": [1, 2, 3]}`) works but has limitations:

```json
{
    "enum": [1, 2, 3]
}
```

**Limitations:**
- No documentation for each value
- Generic generated names (EnumValues.NumberOne, NumberTwo, NumberThree)
- No semantic meaning attached to the numbers

The `oneOf` + `const` pattern shown in this recipe provides:
- Meaningful names for each numeric value (`Pending`, `Active`, `Complete`)
- Rich documentation via `title` and `description`
- Separate types for each value (Status.Pending, Status.Active, Status.Complete)
- Type-safe pattern matching with named parameters
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
    matchPending: static (in Status.Pending _) => "Pending",
    matchActive: static (in Status.Active _) => "Active",
    matchComplete: static (in Status.Complete _) => "Complete",
    defaultMatch: static (in Status _) => "Unknown");
```

**Key differences:**
- V5 uses `ParsedJsonDocument<T>` for parsing
- V5 uses `TryGetValue(out int)` to extract numeric values
- V5 pattern matching uses named parameters based on schema definition names (`matchPending`, `matchActive`, `matchComplete`)
- V5's `oneOf`+`const` pattern generates `ConstInstance` properties on each variant type

## Running the Example

```bash
cd docs/ExampleRecipes/015-NumericEnumerations
dotnet run
```

## Related Patterns

- [014-StringEnumerations](../014-StringEnumerations/) - String-based enumerations
- [013-PolymorphismWithDiscriminators](../013-PolymorphismWithDiscriminators/) - Using `const` for discrimination
- [012-PatternMatching](../012-PatternMatching/) - Discriminated unions with `oneOf`
