# JSON Schema Patterns in .NET - Pattern matching and discriminated unions

This recipe demonstrates how to use JSON Schema `oneOf` to create discriminated unions that support pattern matching in .NET.

## The Pattern

One of the *most* requested features in .NET is [sum types or discriminated unions](https://en.wikipedia.org/wiki/Tagged_union).

Generally speaking, the request is for a value that can take on several different, but fixed types. There is some tag or other mechanism which uniquely discriminates between instances of the types, allowing pattern matching to dispatch the value to the correct handler for its type, from an exhaustive list.

One way to achieve a form of this in C# is via inheritance - through a base class (which represents the discriminated union type) and its derived classes, which represent the different types that could be dispatched:

```csharp
public class UnionType { }

public class FirstType : UnionType { }
public class SecondType : UnionType { }

string Process(UnionType type)
{
    return type switch
    {
        FirstType f => "The first type",
        SecondType s => "The second type",
        _ => "I don't know this type",
    };
}

Console.WriteLine(Process(new SneakyThirdTypeYouDidNotKnowAbout()));

public class SneakyThirdTypeYouDidNotKnowAbout : UnionType { }
```

However, this has two issues:

1. **It is invasive** - you have to implement the base class (or interface).
2. **There is no "exhaustive list"** - our `Process()` function has no way of knowing it has dealt with all the available cases. Someone might have added another type without us looking - like `SneakyThirdTypeYouDidNotKnowAbout`.

The good news is that we can achieve a more flexible sum type using JSON Schema, with the `oneOf` keyword.

This defines a list of schemas, and asserts that an instance is valid for _exactly_ one of those possible schemas.

This addresses the two issues above:

1. The schemas in the list do not _need_ to have anything in common. It is just a list of arbitrary schemas. Specifically, the schemas in the union do not _need_ to know that the union exists. Therefore it is not invasive in that sense. However, they _must_ have something which uniquely discriminates them such that only _one_ of the schemas in the `oneOf` array is valid for the instance. It is the responsibility of the person defining the `oneOf` union schema to ensure that is the case.

2. The `oneOf` keyword exhaustively lists the types in the union, so pattern matching guarantees that it will cover all valid cases.

## The Schemas

In our example, we are discriminating between a `string`, an `int32`, an `object` (conforming to the `person-open` schema) and an `array` of items (that also conform to the `person-open` schema).

### discriminated-union-by-type.json

```json
{
    "oneOf": [
        { "type": "string" },
        {
            "type": "integer",
            "format": "int32"
        },
        { "$ref": "./person-open.json" },
        { "$ref": "#/$defs/people" }
    ],
    "$defs": {
        "people": {
            "type": "array",
            "items": { "$ref": "./person-open.json" }
        }
    }
}
```

### person-open.json

```json
{
    "title": "The person schema https://schema.org/Person",
    "type": "object",
    "required": [ "familyName", "givenName", "birthDate" ],
    "properties": {
        "familyName": { "$ref": "#/$defs/constrainedString" },
        "givenName": { "$ref": "#/$defs/constrainedString" },
        "otherNames": { "$ref": "#/$defs/constrainedString" },
        "birthDate": {
            "type": "string",
            "format": "date"
        },
        "height": {
            "type": "number",
            "format": "double",
            "exclusiveMinimum": 0.0,
            "maximum": 3.0
        }
    },

    "$defs": {
        "constrainedString": {
            "type": "string",
            "minLength": 1,
            "maxLength": 256
        }
    }
}
```

In this example, we have an entirely heterogeneous set of schemas in our discriminated union.

In the [next recipe (013-PolymorphismWithDiscriminators)](../013-PolymorphismWithDiscriminators/), we will look at a tagged union of schemas, discriminated by a property that indicates type, similar to that found in [OpenAPI's polymorphism feature](https://swagger.io/docs/specification/data-models/inheritance-and-polymorphism/), and `System.Text.Json`'s [polymorphic serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism?pivots=dotnet-8-0).

## Generated Code

The code generator produces:
- **`DiscriminatedUnionByType`** - the union type with a `Match()` method
- **`DiscriminatedUnionByType.OneOf0Entity`** - wrapper for string variant
- **`DiscriminatedUnionByType.OneOf1Entity`** - wrapper for int32 variant
- **`PersonOpen`** - the object type
- **`DiscriminatedUnionByType.People`** - the array type

## Pattern Matching

The `Match()` method provides exhaustive pattern matching over all possible types in the union:

```csharp
string ProcessDiscriminatedUnion(in DiscriminatedUnionByType value)
{
    // Pattern matching requires you to deal with all known types 
    // and the fallback (failure) case
    return value.Match(
        (in DiscriminatedUnionByType.OneOf0Entity value) => $"It was a string: {value}",
        (in DiscriminatedUnionByType.OneOf1Entity value) => $"It was an int32: {value}",
        (in PersonOpen value) => $"It was a person. {value.FamilyName}, {value.GivenName}",
        (in DiscriminatedUnionByType.People value) => $"It was an array of people. {value.GetArrayLength()}",
        (in DiscriminatedUnionByType unknownValue) => throw new InvalidOperationException($"Unexpected instance {unknownValue}"));
}
```

### Creating instances

Parse JSON directly into the union type:

```csharp
// Parse a person
string personJson = """
    {
      "familyName": "Brontë",
      "givenName": "Anne",
      "birthDate": "1820-01-17"
    }
    """;

using var parsedPerson = ParsedJsonDocument<PersonOpen>.Parse(personJson);
PersonOpen person = parsedPerson.RootElement;

// Use From() to convert to the union type
DiscriminatedUnionByType union1 = DiscriminatedUnionByType.From(person);

Console.WriteLine(ProcessDiscriminatedUnion(union1));
// Output: It was a person. Brontë, Anne
```

Or parse other types:

```csharp
// Parse a string
using var parsedString = ParsedJsonDocument<DiscriminatedUnionByType>.Parse("\"Hello\"");
DiscriminatedUnionByType union2 = parsedString.RootElement;

Console.WriteLine(ProcessDiscriminatedUnion(union2));
// Output: It was a string: Hello

// Parse an integer
using var parsedInt = ParsedJsonDocument<DiscriminatedUnionByType>.Parse("42");
DiscriminatedUnionByType union3 = parsedInt.RootElement;

Console.WriteLine(ProcessDiscriminatedUnion(union3));
// Output: It was an int32: 42

// Parse an array
string arrayJson = """[{"familyName": "Brontë", "givenName": "Anne", "birthDate": "1820-01-17"}]""";
using var parsedArray = ParsedJsonDocument<DiscriminatedUnionByType>.Parse(arrayJson);
DiscriminatedUnionByType union4 = parsedArray.RootElement;

Console.WriteLine(ProcessDiscriminatedUnion(union4));
// Output: It was an array of people. 1
```

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Implicit conversion from constituent types
Console.WriteLine(ProcessDiscriminatedUnion(personForDiscriminatedUnion));
Console.WriteLine(ProcessDiscriminatedUnion("Hello from the pattern matching"));
Console.WriteLine(ProcessDiscriminatedUnion(32));

// Match with built-in types (JsonString, JsonInt32)
return value.Match(
    (in JsonString value) => $"It was a string. {value}",
    (in JsonInt32 value) => $"It was an int32. {value}",
    (in PersonOpen value) => $"It was a person. {value.FamilyName}, {value.GivenName}",
    (in People value) => $"It was an array of people. {value.GetArrayLength()}",
    (in DiscriminatedUnionByType unknownValue) => throw new InvalidOperationException($"Unexpected instance {unknownValue}"));
```

### V5 (Corvus.Text.Json)
```csharp
// Explicit conversion using From()
DiscriminatedUnionByType union = DiscriminatedUnionByType.From(person);
Console.WriteLine(ProcessDiscriminatedUnion(union));

// Match with entity wrappers (OneOf0Entity, OneOf1Entity)
return value.Match(
    (in DiscriminatedUnionByType.OneOf0Entity value) => $"It was a string: {value}",
    (in DiscriminatedUnionByType.OneOf1Entity value) => $"It was an int32: {value}",
    (in PersonOpen value) => $"It was a person. {value.FamilyName}, {value.GivenName}",
    (in DiscriminatedUnionByType.People value) => $"It was an array of people. {value.GetArrayLength()}",
    (in DiscriminatedUnionByType unknownValue) => throw new InvalidOperationException($"Unexpected instance {unknownValue}"));
```

**Key differences:**
- V5 wraps simple types (string, integer) in entity types (`OneOf0Entity`, `OneOf1Entity`) instead of using `JsonString`, `JsonInt32`
- V5 uses explicit `From()` conversion instead of implicit conversion
- V5 entity types support formatting directly in string templates (no need to extract values)

## Running the Example

```bash
cd docs/ExampleRecipes/012-PatternMatching
dotnet run
```

## Related Patterns

- [011-InterfacesAndMixInTypes](../011-InterfacesAndMixInTypes/) - Composition with `allOf`
- [013-PolymorphismWithDiscriminators](../013-PolymorphismWithDiscriminators/) - Discriminated unions with type properties
- [014-StringEnumerations](../014-StringEnumerations/) - Pattern matching over string enums
