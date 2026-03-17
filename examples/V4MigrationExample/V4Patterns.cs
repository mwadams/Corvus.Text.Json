// This file demonstrates typical V4 Corvus.Json code patterns.
// With the migration analyzer installed, each pattern should produce a diagnostic
// guiding you toward the V5 equivalent.

using System;
using System.IO;
using System.Text.Json;                 // OK — not a V4 namespace
using System.Text.Json.Serialization;   // For JsonConverter attribute
using Corvus.Json;                      // CVJ001: should become Corvus.Text.Json
using Corvus.Json.Internal;             // CVJ001: for JsonValueConverter<T>

namespace V4MigrationExample;

/// <summary>
/// Demonstrates parsing, validation, property access, mutation, array operations,
/// serialization and type coercion patterns that change between V4 and V5.
/// </summary>
public static class V4Patterns
{
    // -----------------------------------------------------------------------
    // 1. Parsing with ParsedValue<T>  (CVJ002)
    // -----------------------------------------------------------------------
    public static void ParsingExample()
    {
        const string json = """{"name":"Alice","age":30}""";

        // CVJ002: ParsedValue<T> → ParsedJsonDocument<T>, .Instance → .RootElement
        using ParsedValue<JsonObject> parsed = ParsedValue<JsonObject>.Parse(json);
        JsonObject person = parsed.Instance;

        Console.WriteLine(person);
    }

    // -----------------------------------------------------------------------
    // 2. Schema validation  (CVJ003)
    // -----------------------------------------------------------------------
    public static void ValidationExample()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<JsonAny> parsed = ParsedValue<JsonAny>.Parse(json);
        JsonAny value = parsed.Instance;

        // CVJ003: .IsValid() → .EvaluateSchema()
        bool isValid = value.IsValid();

        // CVJ003: .Validate(context, level) → .EvaluateSchema(collector)
        ValidationContext result = value.Validate(
            ValidationContext.ValidContext,
            ValidationLevel.Detailed);

        Console.WriteLine($"Valid: {isValid}, Result valid: {result.IsValid}");
    }

    // -----------------------------------------------------------------------
    // 3. Type coercion with As<T>()  (CVJ004)
    // -----------------------------------------------------------------------
    public static void TypeCoercionExample()
    {
        const string json = """{"name":"Alice"}""";
        using ParsedValue<JsonAny> parsed = ParsedValue<JsonAny>.Parse(json);
        JsonAny value = parsed.Instance;

        // CVJ004: value.As<JsonObject>() → JsonObject.From(value)
        JsonObject obj = value.As<JsonObject>();

        // CVJ004: nested coercion
        JsonString name = obj["name"].As<JsonString>();

        Console.WriteLine($"Name: {name}");
    }

    // -----------------------------------------------------------------------
    // 4. As* accessor properties  (CVJ010)
    // -----------------------------------------------------------------------
    public static void AsAccessorExample()
    {
        const string json = """{"x":42,"label":"hello","items":[1,2,3],"flag":true}""";
        using ParsedValue<JsonAny> parsed = ParsedValue<JsonAny>.Parse(json);
        JsonAny value = parsed.Instance;

        // CVJ010: V4 As* accessors removed in V5
        JsonObject obj = value.AsObject;
        JsonString label = obj["label"].AsString;
        JsonNumber x = obj["x"].AsNumber;
        JsonArray items = obj["items"].AsArray;
        JsonBoolean flag = obj["flag"].AsBoolean;
        JsonAny any = value.AsAny;

        Console.WriteLine($"{label}, {x}, {items}, {flag}, {any}");
    }

    // -----------------------------------------------------------------------
    // 5. Property count  (CVJ005)
    // -----------------------------------------------------------------------
    public static void CountExample()
    {
        const string json = """{"a":1,"b":2,"c":3}""";
        using ParsedValue<JsonObject> parsed = ParsedValue<JsonObject>.Parse(json);
        JsonObject obj = parsed.Instance;

        // CVJ005: .Count → .GetPropertyCount()
        int count = obj.Count;

        Console.WriteLine($"Property count: {count}");
    }

    // -----------------------------------------------------------------------
    // 6. FromJson static factory  (CVJ006)
    // -----------------------------------------------------------------------
    public static void FromJsonExample()
    {
        const string json = """{"message":"hello"}""";
        using JsonDocument doc = JsonDocument.Parse(json);

        // CVJ006: .FromJson() → .From()
        JsonObject obj = JsonObject.FromJson(doc.RootElement);
        JsonString str = JsonString.FromJson(doc.RootElement.GetProperty("message"));

        Console.WriteLine($"Obj: {obj}, Str: {str}");
    }

    // -----------------------------------------------------------------------
    // 7. Immutable property mutation with SetProperty  (CVJ011)
    // -----------------------------------------------------------------------
    public static void PropertyMutationExample()
    {
        const string json = """{"name":"Alice","age":30}""";
        using ParsedValue<JsonObject> parsed = ParsedValue<JsonObject>.Parse(json);
        JsonObject person = parsed.Instance;

        // CVJ011: V4 immutable SetProperty returns new instance;
        // V5 uses JsonWorkspace + builder + .SetProperty() on Mutable
        JsonObject updated = person
            .SetProperty("age", (JsonNumber)31)
            .SetProperty("email", (JsonString)"alice@example.com");

        // Nested property mutation — set a property on a child object
        const string nestedJson = """{"address":{"city":"London","postcode":"SW1A"}}""";
        using ParsedValue<JsonObject> nestedParsed = ParsedValue<JsonObject>.Parse(nestedJson);
        JsonObject root = nestedParsed.Instance;

        JsonObject address = root["address"].As<JsonObject>();
        JsonObject updatedAddress = address.SetProperty("city", (JsonString)"Manchester");
        JsonObject updatedRoot = root.SetProperty("address", updatedAddress.AsAny);

        Console.WriteLine($"Updated: {updated}");
        Console.WriteLine($"Updated nested: {updatedRoot}");
    }

    // -----------------------------------------------------------------------
    // 8. Functional array operations  (CVJ012)
    // -----------------------------------------------------------------------
    public static void ArrayOperationsExample()
    {
        const string json = """[1, 2, 3]""";
        using ParsedValue<JsonArray> parsed = ParsedValue<JsonArray>.Parse(json);
        JsonArray arr = parsed.Instance;

        // CVJ012: V4 functional array ops → V5 mutable builder
        JsonArray withFour = arr.Add((JsonNumber)4);
        JsonArray inserted = arr.Insert(0, (JsonNumber)0);
        JsonArray replaced = arr.SetItem(1, (JsonNumber)99);
        JsonArray removed = arr.RemoveAt(0);

        // Array item count
        int length = arr.GetArrayLength();

        Console.WriteLine($"Added: {withFour}, Inserted: {inserted}");
        Console.WriteLine($"Replaced: {replaced}, Removed: {removed}, Length: {length}");
    }

    // -----------------------------------------------------------------------
    // 9. FromItems / Create / FromValues static factories  (CVJ013-015)
    // -----------------------------------------------------------------------
    public static void ArrayFactoryExample()
    {
        // CVJ014: FromItems → CreateBuilder pattern
        JsonArray fromItems = JsonArray.FromItems(
            (JsonNumber)1,
            (JsonNumber)2,
            (JsonNumber)3);

        // CVJ013: Create → CreateBuilder
        ReadOnlySpan<JsonAny> items = [(JsonNumber)10, (JsonNumber)20];
        JsonArray created = JsonArray.Create(items);

        Console.WriteLine($"FromItems: {fromItems}, Created: {created}");
    }

    // -----------------------------------------------------------------------
    // 10. WriteTo with System.Text.Json.Utf8JsonWriter  (CVJ016)
    // -----------------------------------------------------------------------
    public static void WriteToExample()
    {
        const string json = """{"key":"value"}""";
        using ParsedValue<JsonObject> parsed = ParsedValue<JsonObject>.Parse(json);
        JsonObject obj = parsed.Instance;

        using var stream = new MemoryStream();

        // CVJ016: V5 uses Corvus.Text.Json.Utf8JsonWriter, not System.Text.Json.Utf8JsonWriter
        using var writer = new Utf8JsonWriter(stream);
        obj.WriteTo(writer);
        writer.Flush();

        Console.WriteLine($"Wrote {stream.Length} bytes");
    }

    // -----------------------------------------------------------------------
    // 11. TryGetString  (CVJ018)
    // -----------------------------------------------------------------------
    public static void TryGetStringExample()
    {
        const string json = "\"hello world\"";
        using ParsedValue<JsonString> parsed = ParsedValue<JsonString>.Parse(json);
        JsonString str = parsed.Instance;

        // CVJ018: .TryGetString() → .TryGetValue()
        if (str.TryGetString(out string? value))
        {
            Console.WriteLine($"Got string: {value}");
        }
    }

    // -----------------------------------------------------------------------
    // 12. Backing model APIs  (CVJ019)
    // -----------------------------------------------------------------------
    public static void BackingModelExample()
    {
        const string json = """{"data":42}""";
        using ParsedValue<JsonAny> parsed = ParsedValue<JsonAny>.Parse(json);
        JsonAny value = parsed.Instance;

        // CVJ019: backing model APIs removed in V5
        bool hasJsonBacking = value.HasJsonElementBacking;
        bool hasDotnetBacking = value.HasDotnetBacking;

        Console.WriteLine($"JsonElement: {hasJsonBacking}, DotNet: {hasDotnetBacking}");
    }

    // -----------------------------------------------------------------------
    // 13. Null/Undefined checks  (CVJ020)
    // -----------------------------------------------------------------------
    public static void NullUndefinedExample()
    {
        JsonAny nullValue = JsonAny.Null;
        JsonAny undefinedValue = JsonAny.Undefined;

        // CVJ020: extension methods changed in V5
        bool isNull = nullValue.IsNull();
        bool isUndefined = undefinedValue.IsUndefined();
        bool isNullOrUndefined = nullValue.IsNullOrUndefined();
        bool isNotNull = undefinedValue.IsNotNull();

        Console.WriteLine($"Null: {isNull}, Undefined: {isUndefined}");
        Console.WriteLine($"NullOrUndefined: {isNullOrUndefined}, NotNull: {isNotNull}");
    }

    // -----------------------------------------------------------------------
    // 13b. JsonValueConverter attribute  (CVJ017)
    // -----------------------------------------------------------------------

    // CVJ017: JsonValueConverter<T> attribute is a V4 pattern not needed in V5
    [JsonConverter(typeof(JsonValueConverter<JsonString>))]
    public struct MyCustomString
    {
        public string Value { get; set; }
    }

    // -----------------------------------------------------------------------
    // 14. Pattern matching over value kinds
    // -----------------------------------------------------------------------
    public static void PatternMatchingExample()
    {
        const string json = """[1, "two", true, null, {"nested": "obj"}, [3,4]]""";
        using ParsedValue<JsonArray> parsed = ParsedValue<JsonArray>.Parse(json);
        JsonArray arr = parsed.Instance;

        foreach (JsonAny item in arr.EnumerateArray())
        {
            // Pattern matching on ValueKind is the same in V4 and V5,
            // but accessing the typed values uses V4 As* accessors (CVJ010)
            switch (item.ValueKind)
            {
                case JsonValueKind.Number:
                    JsonNumber n = item.AsNumber;    // CVJ010
                    Console.WriteLine($"  Number: {n}");
                    break;
                case JsonValueKind.String:
                    JsonString s = item.AsString;    // CVJ010
                    Console.WriteLine($"  String: {s}");
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    JsonBoolean b = item.AsBoolean;  // CVJ010
                    Console.WriteLine($"  Boolean: {b}");
                    break;
                case JsonValueKind.Null:
                    Console.WriteLine("  Null");
                    break;
                case JsonValueKind.Object:
                    JsonObject o = item.AsObject;    // CVJ010
                    Console.WriteLine($"  Object with {o.Count} properties"); // CVJ005
                    break;
                case JsonValueKind.Array:
                    JsonArray a = item.AsArray;       // CVJ010
                    Console.WriteLine($"  Array with {a.GetArrayLength()} items");
                    break;
            }
        }
    }

    // -----------------------------------------------------------------------
    // 15. Complex nested mutation scenario
    // -----------------------------------------------------------------------
    public static void ComplexNestedMutationExample()
    {
        const string json = """
        {
            "users": [
                {"name": "Alice", "roles": ["admin", "user"]},
                {"name": "Bob", "roles": ["user"]}
            ],
            "metadata": {"version": 1}
        }
        """;

        using ParsedValue<JsonObject> parsed = ParsedValue<JsonObject>.Parse(json);
        JsonObject root = parsed.Instance;

        // Navigate to nested array, modify, and reconstruct
        // This chain of As<T>, SetProperty, and functional array ops
        // is the pattern that changes most dramatically in V5
        JsonArray users = root["users"].As<JsonArray>();               // CVJ004
        JsonObject alice = users[0].As<JsonObject>();                  // CVJ004
        JsonArray aliceRoles = alice["roles"].As<JsonArray>();         // CVJ004

        // Add a role to Alice
        JsonArray updatedRoles = aliceRoles.Add((JsonString)"superadmin"); // CVJ012
        JsonObject updatedAlice = alice.SetProperty("roles", updatedRoles.AsAny); // CVJ011
        JsonArray updatedUsers = users.SetItem(0, updatedAlice.AsAny);     // CVJ012

        // Update metadata version
        JsonObject metadata = root["metadata"].As<JsonObject>();       // CVJ004
        JsonObject updatedMetadata = metadata.SetProperty("version", (JsonNumber)2); // CVJ011

        // Reassemble the root
        JsonObject result = root
            .SetProperty("users", updatedUsers.AsAny)     // CVJ011
            .SetProperty("metadata", updatedMetadata.AsAny); // CVJ011

        // Validate the result
        bool valid = result.IsValid();  // CVJ003

        Console.WriteLine($"Result (valid={valid}):");
        Console.WriteLine(result);
    }
}
