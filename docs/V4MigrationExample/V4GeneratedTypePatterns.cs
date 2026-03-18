// This file demonstrates V4 patterns using a generated schema type (Person).
// These patterns should trigger migration analyzers for the generated-code scenario.

using System;
using Corvus.Json;                      // CVJ001
using V4MigrationExample.Model;

namespace V4MigrationExample;

/// <summary>
/// V4 patterns exercised on a source-generated Person type.
/// </summary>
public static class V4GeneratedTypePatterns
{
    // -----------------------------------------------------------------------
    // 1. Parsing a generated type with ParsedValue<T>  (CVJ002)
    // -----------------------------------------------------------------------
    public static void ParseGeneratedType()
    {
        const string json = """{"name":"Alice","age":30,"email":"alice@example.com"}""";

        // CVJ002: ParsedValue<T> → ParsedJsonDocument<T>
        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        Console.WriteLine(person);
    }

    // -----------------------------------------------------------------------
    // 2. Strongly-typed With*() property mutation  (CVJ011)
    //    Code fix: rewrites Person → Person.Mutable, unchains to
    //    separate Set*() calls
    // -----------------------------------------------------------------------
    public static void MutateGeneratedType()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        // CVJ011: With*() → V5 Set*() on .Mutable variable
        // Code fix: Person.Mutable person = ...; person.SetName("Bob"); person.SetAge(25);
        Person updated = person
            .WithName("Bob")
            .WithAge(25);

        Console.WriteLine(updated);
    }

    // -----------------------------------------------------------------------
    // 3. Create() factory  (CVJ013)
    //    CreateBuilder returns JsonDocumentBuilder<T>, not T.
    //    Use var for the declaration and .RootElement to access the value.
    // -----------------------------------------------------------------------
    public static void CreateGeneratedType()
    {
        // CVJ013: Person.Create() → var builder = Person.CreateBuilder(workspace, ...)
        //         then use builder.RootElement for operations
        Person person = Person.Create(
            name: "Charlie",
            age: 42);

        Console.WriteLine(person);
    }

    // -----------------------------------------------------------------------
    // 4. Validate a generated type  (CVJ003)
    // -----------------------------------------------------------------------
    public static void ValidateGeneratedType()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        // CVJ003: .IsValid() → .EvaluateSchema()
        bool isValid = person.IsValid();

        // CVJ003: Validate with detailed output
        ValidationContext result = person.Validate(
            ValidationContext.ValidContext,
            ValidationLevel.Detailed);

        Console.WriteLine($"Valid: {isValid}, Detail valid: {result.IsValid}");
    }

    // -----------------------------------------------------------------------
    // 5. As<T>() coercion on generated types  (CVJ004)
    // -----------------------------------------------------------------------
    public static void CoerceGeneratedType()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<JsonAny> parsed = ParsedValue<JsonAny>.Parse(json);
        JsonAny value = parsed.Instance;

        // CVJ004: value.As<Person>() → Person.From(value)
        Person person = value.As<Person>();

        Console.WriteLine(person);
    }

    // -----------------------------------------------------------------------
    // 6. FromJson on generated type  (CVJ006) + JsonDocument.Parse  (CVJ008)
    // -----------------------------------------------------------------------
    public static void FromJsonGeneratedType()
    {
        const string json = """{"name":"Alice","age":30}""";

        // CVJ008 + CVJ006: JsonDocument.Parse followed by FromJson
        // Code fix collapses into: using var doc = ParsedJsonDocument<Person>.Parse(json);
        //                          Person person = doc.RootElement;
        using System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(json);
        Person person = Person.FromJson(doc.RootElement);

        Console.WriteLine(person);
    }

    // -----------------------------------------------------------------------
    // 7. Accessing typed properties and nested mutation  (CVJ011)
    // -----------------------------------------------------------------------
    public static void NestedMutationOnGeneratedType()
    {
        const string json = """
        {
            "name": "Alice",
            "age": 30,
            "address": {"city": "London", "postcode": "SW1A"},
            "tags": ["admin", "user"]
        }
        """;

        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        // Access the nested Address via the generated property
        Person.Address address = person.AddressValue;

        // CVJ011: Mutate nested generated type with With*()
        // Code fix: Person.Address.Mutable updatedAddress = ...;
        Person.Address updatedAddress = address.WithCity("Manchester");

        // CVJ011: Set the updated address back on the person
        // Code fix: person.SetAddressValue(updatedAddress);
        Person updatedPerson = person.WithAddressValue(updatedAddress);

        Console.WriteLine(updatedPerson);
    }

    // -----------------------------------------------------------------------
    // 8. Array property manipulation  (CVJ012)
    // -----------------------------------------------------------------------
    public static void ArrayPropertyOnGeneratedType()
    {
        const string json = """
        {
            "name": "Alice",
            "age": 30,
            "tags": ["admin"]
        }
        """;

        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        // Get the tags array
        Person.TagsArray tags = person.Tags;

        // CVJ012: Functional array add
        // Code fix: Person.TagsArray.Mutable updatedTags = ...; updatedTags.AddItem(...);
        Person.TagsArray updatedTags = tags.Add((JsonString)"superadmin");

        // CVJ011: Set the updated array back
        Person updatedPerson = person.WithTags(updatedTags);

        Console.WriteLine(updatedPerson);
    }

    // -----------------------------------------------------------------------
    // 9. Backing model checks on generated type  (CVJ019)
    // -----------------------------------------------------------------------
    public static void BackingModelOnGeneratedType()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<Person> parsed = ParsedValue<Person>.Parse(json);
        Person person = parsed.Instance;

        // CVJ019: backing model APIs removed in V5
        bool hasJsonBacking = person.HasJsonElementBacking;
        bool hasDotnetBacking = person.HasDotnetBacking;

        Console.WriteLine($"JsonElement: {hasJsonBacking}, DotNet: {hasDotnetBacking}");
    }

}
