# JSON Schema Source Generator Example

This example demonstrates how to use the Corvus.Text.Json.SourceGenerator to create strongly-typed C# models from JSON Schema documents with nested objects and arrays.

## What This Example Shows

1. **Parsing Nested Objects** - Parse JSON with nested PersonName objects
2. **Parsing Arrays** - Parse and access array elements (hobbies)
3. **Schema Validation** - Validate JSON against schema constraints at runtime
4. **Building Nested Objects** - Use Build() callbacks to create nested structures
5. **Building Arrays** - Use Build() callbacks to populate arrays
6. **Complex Document Building** - Combine nested objects and arrays
7. **Modifying Documents** - Make documents mutable and update simple properties
8. **Modifying Nested Properties** - Update nested objects and arrays

## Project Structure

- `person-schema.json` - JSON Schema with nested PersonName, Address objects and hobbies array
- `Models.cs` - Partial struct declarations with `JsonSchemaTypeGenerator` attributes
- `Program.cs` - 8 comprehensive examples demonstrating the generated API

## Schema Structure

The schema defines a Person with:
- **name** (PersonName): Nested object with firstName, lastName, middleName
- **age**: Number with validation (0-130)
- **email**: String with email format validation
- **phoneNumber**: String with pattern validation  
- **address** (Address): Nested object with street, city, state, zipCode, country
- **hobbies**: Array of strings
- **isActive**: Boolean

## How It Works

### 1. Define Your Schema with Nested Types

`person-schema.json` defines nested objects and arrays:

```json
{
    "$schema": "https://json-schema.org/draft/2020-12/schema",
    "type": "object",
    "required": ["name", "age"],
    "properties": {
        "name": { "$ref": "#/$defs/PersonName" },
        "age": { "type": "number", "minimum": 0, "maximum": 130 },
        "hobbies": {
            "type": "array",
            "items": { "type": "string" }
        }
    },
    "$defs": {
        "PersonName": {
            "type": "object",
            "required": ["firstName", "lastName"],
            "properties": {
                "firstName": { "type": "string" },
                "lastName": { "type": "string" },
                "middleName": { "type": "string" }
            }
        }
    }
}
```

### 2. Declare Types for Nested Objects

```csharp
[JsonSchemaTypeGenerator("person-schema.json")]
public readonly partial struct Person;

[JsonSchemaTypeGenerator("person-schema.json#/$defs/PersonName")]
public readonly partial struct PersonName;
```

### 3. Parse and Access Nested Objects

```csharp
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
Person person = doc.RootElement;

// Access nested name object
string firstName = person.Name.FirstName;
string lastName = person.Name.LastName;

// Access array using EnumerateArray()
if (person.Hobbies is not null)
{
    foreach (var hobby in person.Hobbies.Value.EnumerateArray())
    {
        Console.WriteLine((string)hobby);
    }
    
    // Or access by index
    var firstHobby = (string)person.Hobbies.Value[0];
}
```

### 4. Build Documents with Nested Objects

Use the `Build()` method with callbacks:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
    workspace,
    (ref b) => b.Create(
        age: 45,
        // Build nested name object
        name: Person.PersonName.Build((ref nameBuilder) =>
        {
            nameBuilder.Create(
                firstName: "Eve",
                lastName: "Martinez",
                middleName: "Sofia");
        })));
```

### 5. Build Arrays with Callbacks

```csharp
using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
    workspace,
    (ref b) => b.Create(
        age: 28,
        name: Person.PersonName.Build((ref nb) => 
            nb.Create(firstName: "Frank", lastName: "Wilson")),
        // Build hobbies array
        hobbies: Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
        {
            hobbiesBuilder.Add("guitar");
            hobbiesBuilder.Add("gaming");
            hobbiesBuilder.Add("travel");
        })));
```

### 6. Modify Nested Properties

```csharp
Person.Mutable mutablePerson = builder.RootElement;

// Replace nested name object
mutablePerson.SetName(Person.PersonName.Build((ref nameBuilder) =>
{
    nameBuilder.Create(
        firstName: "Ida",
        lastName: "Wells-Barnett",
        middleName: "Bell");
}));

// Replace hobbies array
mutablePerson.SetHobbies(Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
{
    hobbiesBuilder.Add("journalism");
    hobbiesBuilder.Add("activism");
    hobbiesBuilder.Add("writing");
}));
```

## Running the Example

```bash
cd docs/JsonSchemaSourceGeneratorExample
dotnet run
```

## Key Patterns Demonstrated

- **Nested Type References**: `Person.PersonName`, `Person.Address`, `Person.HobbiesEntityArray`
- **Build Callbacks**: Using `ref` parameters to build nested structures efficiently
- **Array Enumeration**: Using `EnumerateArray()` to iterate over array elements
- **Array Building**: Using `hobbiesBuilder.Add()` to populate arrays
- **Mutable Operations**: Converting to mutable for modifications, then back to immutable
- **Type Safety**: Compile-time checking for all nested properties and array elements

## Generated Code Structure

The source generator creates:
- **Person** struct with properties for name (PersonName), age, hobbies array, etc.
- **Person.PersonName** nested struct with firstName, lastName, middleName
- **Person.Address** nested struct with street, city, state, etc.
- **Person.HobbiesEntityArray** for the hobbies array
- **Mutable** counterparts for all types (Person.Mutable, Person.PersonName.Mutable, etc.)
- **Build()** methods for constructing documents
- **EvaluateSchema()** methods for validation

## Further Reading

- [JSON Schema Source Generator Documentation](../JsonSchemaSourceGenerator.md)
- [ParsedJsonDocument Guide](../ParsedJsonDocument.md)
- [JsonDocumentBuilder Guide](../JsonDocumentBuilder.md)
- [Sandbox Program](../../src/Sandbox/Program.cs) - Additional complex examples
