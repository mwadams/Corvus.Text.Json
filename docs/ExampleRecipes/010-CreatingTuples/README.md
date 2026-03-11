# JSON Schema Patterns in .NET - Creating tuples

This recipe demonstrates how to use JSON Schema `prefixItems` and `unevaluatedItems` to create strongly-typed tuple representations in .NET.

## The Pattern

.NET has the concept of a [`ValueTuple<T1,...TN>`](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple) - a lightweight type that can represent a small, strongly typed collection of values.

We typically encounter it through the special C# syntax available to define and instantiate them:

```csharp
(int, string, bool) value = (3, "hello", true);

Console.WriteLine($"{value.Item1}, {value.Item2}, {value.Item3}");
```

JSON Schema allows us to define an array whose items are constrained to a specific ordered list of schemas using the `prefixItems` keyword.

To ensure that no other items are permitted than those in the ordered list, we also add `unevaluatedItems: false`.

> **Note:** This is an area of divergence between draft 2020-12 and prior drafts. In those versions, you should use the array form of `items` and `additionalItems`.

Notice that a tuple is in effect a *closed type* - you cannot add additional items to it. Just as `unevaluatedProperties: false` closes an `object` type, `unevaluatedItems: false` closes an array type.

## The Schema

File: `three-tuple.json`

```json
{
    "title":  "A tuple of int32, string, boolean",
    "type": "array",
    "prefixItems": [
        {
            "type": "integer",
            "format": "int32"
        },
        {
            "type": "string"
        },
        {
            "type": "boolean"
        }
    ],
    "unevaluatedItems": false
}
```

## Generated Code Usage

The generated `ThreeTuple` type provides:
- **`Item1`, `Item2`, `Item3` properties** for accessing tuple elements by position
- **`CreateTuple(T1, T2, T3)` method** on the builder for creating tuples
- **Parse and equality support** like other generated types

### Parsing a tuple from JSON

```csharp
string threeTupleJson = """
    [3, "Hello", false]
    """;

using var parsedTuple = ParsedJsonDocument<ThreeTuple>.Parse(threeTupleJson);
ThreeTuple threeTuple = parsedTuple.RootElement;

Console.WriteLine(threeTuple);
// Output: [3,"Hello",false]
```

### Accessing tuple items

```csharp
Console.WriteLine($"Item1: {threeTuple.Item1}");  // Output: Item1: 3
Console.WriteLine($"Item2: {threeTuple.Item2}");  // Output: Item2: Hello
Console.WriteLine($"Item3: {threeTuple.Item3}");  // Output: Item3: False
```

### Creating a tuple with the builder

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using var builtDoc = ThreeTuple.CreateBuilder(workspace, ThreeTuple.Build(static (ref ThreeTuple.Builder b) =>
{
    b.CreateTuple(42, "World", true);
}));
ThreeTuple threeTuple2 = builtDoc.RootElement;

Console.WriteLine(threeTuple2);
// Output: [42,"World",true]
```

### Comparing tuples

```csharp
if (threeTuple.Equals(threeTuple2))
{
    Console.WriteLine("The tuples are equal");
}
else
{
    Console.WriteLine("The tuples are not equal");
}
```

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Create from .NET tuple (implicit conversion)
(int, string, bool) dotnetTuple = (3, "Hello", false);
ThreeTuple threeTuple = dotnetTuple;

// Create directly
ThreeTuple threeTuple2 = ThreeTuple.Create(3, "Hello", false);

// Convert to .NET tuple (implicit conversion)
(int, JsonString, bool) dotnetTupleFromThreeTuple = threeTuple;
```

### V5 (Corvus.Text.Json)
```csharp
// Create via builder
using JsonWorkspace workspace = JsonWorkspace.Create();
using var doc = ThreeTuple.CreateBuilder(workspace, ThreeTuple.Build(static (ref ThreeTuple.Builder b) =>
{
    b.CreateTuple(42, "World", true);
}));
ThreeTuple threeTuple = doc.RootElement;

// Access items (same as V4)
int item1 = threeTuple.Item1;
string item2 = threeTuple.Item2;  // Formatting support - no explicit cast needed
bool item3 = threeTuple.Item3;
```

**Important:** V5 does not provide implicit conversions to/from `ValueTuple`. This is by design - the generated types support direct formatting and property access, eliminating the need for tuple conversions in most scenarios.

## Running the Example

```bash
cd docs/ExampleRecipes/010-CreatingTuples
dotnet run
```

## Related Patterns

- [007-CreatingAStronglyTypedArray](../007-CreatingAStronglyTypedArray/) - Arrays with uniform item types
- [008-CreatingAnArrayOfHigherRank](../008-CreatingAnArrayOfHigherRank/) - Multi-dimensional arrays
- [011-InterfacesAndMixInTypes](../011-InterfacesAndMixInTypes/) - Composing types with `allOf`
