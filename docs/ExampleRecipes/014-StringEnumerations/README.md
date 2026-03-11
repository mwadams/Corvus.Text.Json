# JSON Schema Patterns in .NET - String Enumerations and Pattern Matching

This recipe demonstrates how to use JSON Schema `enum` keyword with string values to create type-safe enumerations with pattern matching support.

## The Pattern

String enumerations are one of the most common patterns in API design. They provide:
- **Type safety** - only valid values are accepted
- **Self-documentation** - the allowed values are clearly defined in the schema
- **Pattern matching** - exhaustive handling of all possible values

JSON Schema's `enum` keyword defines a fixed set of allowed values.

## The Schema

File: `color.json`

```json
{
  "enum": ["red", "green", "blue"]
}
```

This simple schema constrains values to exactly one of the three strings: `"red"`, `"green"`, or `"blue"`.

## Generated Code Usage

### Parsing enumeration values

```csharp
// Parse red color
string redJson = """
    "red"
    """;
using var parsedRed = ParsedJsonDocument<Color>.Parse(redJson);
Color red = parsedRed.RootElement;
Console.WriteLine($"Color: {red}");
// Output: Color: "red"
```

### Extracting string values

```csharp
// Get the underlying string value
if (red.TryGetValue(out string? redStr))
{
    Console.WriteLine($"String value: {redStr}");
    // Output: String value: red
}
```

### Converting to specific enum entities

The generated code creates entity types for each enum value, allowing type-safe pattern matching:

```csharp
// Parse each color
using var parsedRed = ParsedJsonDocument<Color>.Parse("\"red\"");
using var parsedGreen = ParsedJsonDocument<Color>.Parse("\"green\"");
using var parsedBlue = ParsedJsonDocument<Color>.Parse("\"blue\"");

Color red = parsedRed.RootElement;
Color green = parsedGreen.RootElement;
Color blue = parsedBlue.RootElement;
```

### Pattern matching over enum values

Use the `Match()` method for exhaustive pattern matching:

```csharp
string DescribeColor(in Color color)
{
    return color.Match(
        matchRed: static () => "The color of fire and passion",
        matchGreen: static () => "The color of nature and growth",
        matchBlue: static () => "The color of sky and ocean",
        defaultMatch: static () => throw new InvalidOperationException("Unknown color"));
}

Console.WriteLine(DescribeColor(red));    // Output: The color of fire and passion
Console.WriteLine(DescribeColor(green));  // Output: The color of nature and growth
Console.WriteLine(DescribeColor(blue));   // Output: The color of sky and ocean
```

The compiler ensures you handle all possible enum values. If you add a new value to the schema and regenerate the code, any incomplete pattern matching will be caught at compile time.

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Parse enum
Color red = Color.Parse("\"red\"");

// Direct string comparison
if (red == "red")
{
    Console.WriteLine("It's red!");
}

// Pattern matching with string literals
string desc = red.Match(
    "red" => "The color of fire",
    "green" => "The color of grass",
    "blue" => "The color of sky");
```

### V5 (Corvus.Text.Json)
```csharp
// Parse with document wrapper
using var parsedRed = ParsedJsonDocument<Color>.Parse("\"red\"");
Color red = parsedRed.RootElement;

// Extract string value
if (red.TryGetValue(out string? redStr) && redStr == "red")
{
    Console.WriteLine("It's red!");
}

// Pattern matching with named parameters
string desc = red.Match(
    matchRed: static () => "The color of fire",
    matchGreen: static () => "The color of grass",
    matchBlue: static () => "The color of sky");
```

**Key differences:**
- V5 uses `ParsedJsonDocument<T>` for parsing with proper resource management
- V5 uses `TryGetValue(out string?)` to extract the underlying string value
- V5 pattern matching uses named parameters based on enum values (`matchRed`, `matchGreen`, `matchBlue`)
- V5 provides better performance through workspace-pooled allocations
- V5 pattern matching uses entity types instead of string literals

## Running the Example

```bash
cd docs/ExampleRecipes/014-StringEnumerations
dotnet run
```

## Related Patterns

- [012-PatternMatching](../012-PatternMatching/) - Discriminated unions with `oneOf`
- [013-PolymorphismWithDiscriminators](../013-PolymorphismWithDiscriminators/) - Using `const` for discrimination
- [015-NumericEnumerations](../015-NumericEnumerations/) - Enumerations with numeric values and documentation
