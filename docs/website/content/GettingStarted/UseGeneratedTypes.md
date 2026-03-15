---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Using Generated Types"
---
## Parsing

### ParsedJsonDocument (preferred)

`ParsedJsonDocument<T>` manages a pooled-memory document. Dispose it when you're done:

```csharp
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse(
        """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
Person person = doc.RootElement;
```

### ParseValue (convenience)

Returns a self-owned value — no explicit disposal needed, but the backing memory is not shared:

```csharp
Person person = Person.ParseValue(
    """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
```

### Other sources

```csharp
// From UTF-8 bytes
Person person = Person.ParseValue(
    """{"name":{"familyName":"Oldroyd"},"age":30}"""u8);

// From a stream
using FileStream stream = File.OpenRead("person.json");
using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(stream);
```

## Property access

Each schema property generates a typed accessor returning a nested entity struct:

```csharp
Person person = doc.RootElement;

// Required property — name is a nested PersonName object
string familyName = (string)person.Name.FamilyName;

// Optional properties — may be Undefined when absent
if (person.Age.IsNotUndefined())
{
    int age = (int)person.Age;
}

if (person.Email.IsNotUndefined())
{
    string email = (string)person.Email;
}
```

### Property indexers

Access properties dynamically by name, returning a `JsonElement`:

```csharp
// UTF-8 string literal (preferred — avoids transcoding)
JsonElement name = person["name"u8];

// String overload also available (transcodes to UTF-8 internally)
JsonElement age = person["age"];
```

### TryGetProperty

```csharp
if (person.TryGetProperty("email"u8, out JsonElement email))
{
    Console.WriteLine((string)email);
}
```

## Converting to .NET types

### Implicit conversions (value types)

For .NET value types (`int`, `double`, `bool`, `DateTime`, etc.), the generated types support **implicit** conversion — no cast syntax needed:

```csharp
int age = person.Age;
double score = person.Score;
bool isActive = person.IsActive;
```

This is the most concise approach and works for all value types.

### Explicit cast (strings)

`string` requires an **explicit** cast by default, because every conversion allocates a new `string`:

```csharp
string familyName = (string)person.Name.FamilyName;
```

> **Tip:** You can opt in to implicit `string` conversion via the `--optionalStringImplicit` flag on the CLI tool, or the `OptionalStringImplicit` property on the source generator attribute. This trades allocation safety for convenience — use it when you know you need the string and are not in a hot path.

### TryGetValue

A safe, non-throwing alternative that returns `false` if the value is absent or cannot be converted:

```csharp
if (person.Age.TryGetValue(out int age)) { ... }
if (person.Name.FamilyName.TryGetValue(out string? name)) { ... }
```

### GetString, GetUtf8String, and GetUtf16String

For string-valued properties:

```csharp
// As a .NET string (allocates)
string familyName = person.Name.FamilyName.GetString();

// As an UnescapedUtf8JsonString (avoids allocation — always dispose)
using UnescapedUtf8JsonString utf8Name = person.Name.FamilyName.GetUtf8String();
ReadOnlySpan<byte> bytes = utf8Name.Span;

// As an UnescapedUtf16JsonString (avoids allocation — always dispose)
using UnescapedUtf16JsonString utf16Name = person.Name.FamilyName.GetUtf16String();
ReadOnlySpan<char> chars = utf16Name.Span;
```

`GetUtf8String()` gives you the raw UTF-8 bytes without allocating a `string`. `GetUtf16String()` gives you a `char` span — useful when you need to interop with APIs that expect `ReadOnlySpan<char>` without paying for a `string` allocation. Both return disposable types that must be disposed to return their buffers to the pool.

## Values, Null, and Undefined

JSON values exist in three states:

```json
{ "foo": 3.14 }   // Present with a value
{ "foo": null }    // Present but null
{}                 // Not present ("undefined")
```

Generated types expose this three-state model:

```csharp
if (person.Email.IsNotUndefined())
{
    // The property exists in the JSON (may still be null)
    string email = (string)person.Email;
}

person.Email.IsUndefined()          // true if the property is absent
person.Email.IsNull()               // true if the property is present but null
person.Email.IsNullOrUndefined()    // true if null or absent
person.Email.IsNotNullOrUndefined() // true if present with a non-null value
```

When you attempt to cast an undefined or null value to a .NET type, it throws an `InvalidOperationException`. Always check before casting optional properties.

## Serialization

```csharp
// To a JSON string
string json = person.ToString();

// To a Corvus.Text.Json.Utf8JsonWriter (not System.Text.Json!)
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
person.WriteTo(writer);
```

## Equality and comparison

Generated types support value equality:

```csharp
Person a = Person.ParseValue(json);
Person b = Person.ParseValue(json);

bool equal = a.Equals(b);  // true — deep JSON equality
bool same  = a == b;        // operator overload
```
