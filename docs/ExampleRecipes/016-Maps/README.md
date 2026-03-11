# JSON Schema Patterns in .NET - Maps of Strings to Strongly Typed Values

This recipe demonstrates how to use JSON Schema `additionalProperties` to create strongly-typed map/dictionary structures with string keys and typed values.

## The Pattern

In .NET, we often use `IDictionary<string, T>` or `IReadOnlyDictionary<string, T>` to represent collections of key-value pairs where the keys are strings and the values are of a specific type.

JSON Schema provides the `additionalProperties` keyword (or `unevaluatedProperties` in draft 2020-12 with composition) to define the schema for values in such a map.

This is especially useful for:
- Configuration objects with arbitrary keys
- Flexible data structures where property names aren't known at design time
- API responses with dynamic property sets

## The Schema

File: `string-to-int-map.json`

```json
{
  "type": "object",
  "additionalProperties": {
    "type": "integer"
  }
}
```

This schema:
- Defines an object type
- Allows any property names (string keys)
- Constrains all property values to be integers

You could make this more complex by using a schema reference for the value type:

```json
{
  "type": "object",
  "additionalProperties": {
    "$ref": "./person.json"
  }
}
```

## Generated Code Usage

### Parsing a map

```csharp
string json = """
    {
      "foo": 1,
      "bar": 2,
      "baz": 3
    }
    """;

using var parsed = ParsedJsonDocument<StringToIntMap>.Parse(json);
StringToIntMap map = parsed.RootElement;
Console.WriteLine($"Map: {map}");
// Output: Map: {"foo":1,"bar":2,"baz":3}
```

### Accessing map values

Use `TryGetProperty()` with UTF-8 byte literals for zero-allocation property access:

```csharp
// Access values using UTF-8 property names (zero allocation)
if (map.TryGetProperty("foo"u8, out var fooValue))
{
    Console.WriteLine($"foo = {fooValue.GetInt32()}");
    // Output: foo = 1
}

if (map.TryGetProperty("bar"u8, out var barValue))
{
    Console.WriteLine($"bar = {barValue.GetInt32()}");
    // Output: bar = 2
}

if (map.TryGetProperty("baz"u8, out var bazValue))
{
    Console.WriteLine($"baz = {bazValue.GetInt32()}");
    // Output: baz = 3
}
```

### Enumerating all entries

```csharp
// Enumerate all key-value pairs
Console.WriteLine("All entries:");
foreach (var property in map.EnumerateObject())
{
    Console.WriteLine($"{property.Name.GetString()} = {property.Value.GetInt32()}");
}
// Output:
// All entries:
// foo = 1
// bar = 2
// baz = 3
```

### Building a map (mutable)

While this simple example shows readonly access, you can create maps using the mutable builder pattern:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using var doc = StringToIntMap.CreateBuilder(workspace, StringToIntMap.Build((ref StringToIntMap.Builder b) =>
{
    b.SetProperty("alpha"u8, 10);
    b.SetProperty("beta"u8, 20);
    b.SetProperty("gamma"u8, 30);
}));
StringToIntMap newMap = doc.RootElement;
Console.WriteLine(newMap);
// Output: {"alpha":10,"beta":20,"gamma":30}
```

## UTF-8 String Literals for Performance

Notice the use of `"foo"u8` syntax. The `u8` suffix creates a UTF-8 encoded `ReadOnlySpan<byte>` at compile time, avoiding:
- String allocation
- UTF-16 to UTF-8 transcoding at runtime

This is the preferred way to access properties in performance-sensitive code.

For compatibility or convenience, you can also use regular strings:

```csharp
string key = GetKeyFromSomewhere();
if (map.TryGetProperty(key, out var value))
{
    // ...
}
```

But be aware this will allocate and transcode the string.

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Create from property collection
StringToIntMap map = StringToIntMap.FromProperties(
    ("foo", 1),
    ("bar", 2),
    ("baz", 3));

// Access with indexer
int fooValue = map["foo"];

// LINQ support
var keys = map.Keys;
var values = map.Values;
int sum = map.Values.Sum();

// IReadOnlyDictionary interface
foreach (var kvp in map)
{
    Console.WriteLine($"{kvp.Key} = {kvp.Value}");
}
```

### V5 (Corvus.Text.Json)
```csharp
// Parse from JSON or build with mutable pattern
using var parsed = ParsedJsonDocument<StringToIntMap>.Parse(json);
StringToIntMap map = parsed.RootElement;

// Or build with workspace
using JsonWorkspace workspace = JsonWorkspace.Create();
using var doc = StringToIntMap.CreateBuilder(workspace, 
    StringToIntMap.Build((ref StringToIntMap.Builder b) =>
    {
        b.SetProperty("foo"u8, 1);
        b.SetProperty("bar"u8, 2);
        b.SetProperty("baz"u8, 3);
    }));

// Access with TryGetProperty (UTF-8 preferred)
if (map.TryGetProperty("foo"u8, out var fooValue))
{
    int value = fooValue.GetInt32();
}

// Enumerate with EnumerateObject()
foreach (var property in map.EnumerateObject())
{
    Console.WriteLine($"{property.Name.GetString()} = {property.Value.GetInt32()}");
}
```

**Key differences:**
- V5 uses builder pattern instead of `FromProperties()` static method
- V5 uses `TryGetProperty()` instead of indexer access
- V5 emphasizes UTF-8 byte spans (`"foo"u8`) for performance
- V5 uses `EnumerateObject()` instead of implementing `IReadOnlyDictionary<,>`
- V5 provides lower-level control with better performance characteristics

## Running the Example

```bash
cd docs/ExampleRecipes/016-Maps
dotnet run
```

## Related Patterns

- [004-OpenVersusClosedTypes](../004-OpenVersusClosedTypes/) - Objects with `unevaluatedProperties: false`
- [011-InterfacesAndMixInTypes](../011-InterfacesAndMixInTypes/) - Composing object types
- [017-MappingInputAndOutputValues](../017-MappingInputAndOutputValues/) - Converting between different schemas
