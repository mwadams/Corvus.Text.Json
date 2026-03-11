# JSON Schema Patterns in .NET - Polymorphism with Discriminator Properties

This recipe demonstrates how to use JSON Schema `oneOf` with `const` properties to create polymorphic types with discriminators - a pattern similar to OpenAPI's polymorphism feature and `System.Text.Json`'s polymorphic serialization.

## The Pattern

In the [previous recipe (012-PatternMatching)](../012-PatternMatching/), we looked at discriminated unions where types were discriminated by their fundamental structure (string vs. integer vs. object vs. array).

In this recipe, we examine a more specific pattern: a discriminated union where all variants are objects, but each has a discriminator property with a unique constant value that identifies its type.

This is the pattern used by:
- [OpenAPI's discriminator](https://swagger.io/docs/specification/data-models/inheritance-and-polymorphism/)
- [System.Text.Json's polymorphic serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism)
- Many API design patterns where a `type` field indicates which variant you're dealing with

## The Schema

File: `shape.json`

```json
{
  "oneOf": [
    {
      "type": "object",
      "required": ["type", "radius"],
      "properties": {
        "type": { "const": "circle" },
        "radius": { "type": "number" }
      }
    },
    {
      "type": "object",
      "required": ["type", "width", "height"],
      "properties": {
        "type": { "const": "rectangle" },
        "width": { "type": "number" },
        "height": { "type": "number" }
      }
    }
  ]
}
```

Each variant in the `oneOf`:
- Is an object type
- Has a `type` property with a `const` value unique to that variant
- Has additional properties specific to that variant

The discriminator (`type` property) ensures that exactly one schema in the `oneOf` matches any given instance.

## Generated Code Usage

### Parsing polymorphic types

```csharp
// Parse a circle
string circleJson = """
    {
      "type": "circle",
      "radius": 5.0
    }
    """;

using var parsedCircle = ParsedJsonDocument<Shape>.Parse(circleJson);
Shape circle = parsedCircle.RootElement;
Console.WriteLine($"Circle: {circle}");
// Output: Circle: {"type":"circle","radius":5}
```

### Accessing discriminated variant properties

Once you have a `Shape`, convert it to the specific variant type to access its properties:

```csharp
// Access circle properties
Shape.OneOf0Entity circleEntity = Shape.OneOf0Entity.From(circle);
Console.WriteLine($"Circle radius: {circleEntity.Radius}");
// Output: Circle radius: 5

// Parse a rectangle
string rectangleJson = """
    {
      "type": "rectangle",
      "width": 10.0,
      "height": 20.0
    }
    """;

using var parsedRectangle = ParsedJsonDocument<Shape>.Parse(rectangleJson);
Shape rectangle = parsedRectangle.RootElement;

// Access rectangle properties
Shape.OneOf1Entity rectangleEntity = Shape.OneOf1Entity.From(rectangle);
Console.WriteLine($"Rectangle width: {rectangleEntity.Width}, height: {rectangleEntity.Height}");
// Output: Rectangle width: 10, height: 20
```

### Pattern matching with discriminators

While this recipe demonstrates direct variant access, you can also use the `Match()` method for exhaustive pattern matching:

```csharp
string DescribeShape(in Shape shape)
{
    return shape.Match(
        matchRequiredRadiusAndType: static (in Shape.RequiredRadiusAndType circle) => 
            $"A circle with radius {circle.Radius}",
        matchRequiredHeightAndTypeAndWidth: static (in Shape.RequiredHeightAndTypeAndWidth rectangle) => 
            $"A rectangle {rectangle.Width}x{rectangle.Height}",
        defaultMatch: static (in Shape unknownShape) => 
            throw new InvalidOperationException($"Unknown shape: {unknownShape}"));
}
```

Note that the match handlers use named parameters (`matchRequiredRadiusAndType`, `matchRequiredHeightAndTypeAndWidth`) generated from the required properties in each discriminated variant.

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Create instances directly
Circle circle = Circle.Create(radius: 5.0);
Rectangle rectangle = Rectangle.Create(width: 10.0, height: 20.0);

// Implicit conversion to discriminated union
Shape shapeFromCircle = circle;
Shape shapeFromRectangle = rectangle;

// Pattern matching with implicit type detection
string desc = shape.Match(
    (in Circle c) => $"Circle with radius {c.Radius}",
    (in Rectangle r) => $"Rectangle {r.Width}x{r.Height}");
```

### V5 (Corvus.Text.Json)
```csharp
// Parse from JSON
using var parsedCircle = ParsedJsonDocument<Shape>.Parse(circleJson);
Shape circle = parsedCircle.RootElement;

// Explicit conversion to variant entity
Shape.OneOf0Entity circleEntity = Shape.OneOf0Entity.From(circle);
double radius = circleEntity.Radius;

// Pattern matching with entity types
string desc = shape.Match(
    (in Shape.OneOf0Entity c) => $"Circle with radius {c.Radius}",
    (in Shape.OneOf1Entity r) => $"Rectangle {r.Width}x{r.Height}",
    (in Shape unknown) => throw new InvalidOperationException());
```

**Key differences:**
- V5 parses from JSON rather than providing `Create()` methods for discriminated types
- V5 uses entity wrappers (`OneOf0Entity`, `OneOf1Entity`) to represent variants
- V5 requires explicit `From()` conversion to access variant-specific properties
- V5 pattern matching uses entity types instead of the original schema types

## Running the Example

```bash
cd docs/ExampleRecipes/013-PolymorphismWithDiscriminators
dotnet run
```

## Related Patterns

- [012-PatternMatching](../012-PatternMatching/) - Discriminated unions with heterogeneous types
- [014-StringEnumerations](../014-StringEnumerations/) - Enumerations and pattern matching
- [015-NumericEnumerations](../015-NumericEnumerations/) - Documented numeric enums with `const`
