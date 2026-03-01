# ParsedJsonDocument Usage Guide

## Overview

`ParsedJsonDocument<T>` is a lightweight, read-only representation of a JSON value that utilizes pooled memory to minimize garbage collector impact. It provides an efficient way to parse and navigate JSON documents with minimal allocations.

Built on top of `Corvus.Text.Json`, which is derived from `System.Text.Json`, `ParsedJsonDocument<T>` extends the functionality while maintaining a high degree of source compatibility with the familiar `System.Text.Json.JsonElement` API.

## Key Features

- **Memory Efficient**: Uses pooled memory from `ArrayPool<byte>` to reduce GC pressure
- **Read-Only**: Provides immutable access to parsed JSON data
- **Multiple Input Sources**: Supports parsing from strings, byte arrays, streams, and sequences
- **IDisposable**: Must be disposed to return pooled memory
- **System.Text.Json Compatible**: Works with familiar `System.Text.Json` patterns

## Comparison with System.Text.Json

`ParsedJsonDocument<T>` is based on `System.Text.Json.JsonDocument` but provides several enhancements:

| Feature | System.Text.Json (`JsonDocument`) | Corvus.Text.Json (`ParsedJsonDocument<T>`) |
|---------|-----------------------------------|-------------------------------------------|
| **Generic Support** | Fixed to `JsonElement` | Generic over `IJsonElement<T>` for extensibility |
| **Property Access** | Sequential searc-based property lookup | Optionally uses a property map with O(1) performance for repeated access |
| **Additional Types** | Standard .NET types | Includes `BigNumber`, `BigInteger`, NodaTime types (`LocalDate`, `OffsetDateTime`, `Period`) |
| **Mutability** | Read-only | Read-only by default, with mutable variant (`JsonElement.Mutable`) available via `JsonDocumentBuilder` |
| **UTF-8 Support** | Good | Enhanced with direct UTF-8 property access methods |

### When to Use ParsedJsonDocument

- ✅ When you need JSON schema support
- ✅ When you need mutability support
- ✅ When you want to create custom JSON element types
- ✅ When you need extended type support (BigInteger, BigNumber, NodaTime types)

## Basic Usage

### Parsing JSON from a String

```csharp
using Corvus.Text.Json;

string json = """
    {
        "name": "John",
        "age": 30
    }
    """;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

JsonElement root = doc.RootElement;
string name = root.GetProperty("name").GetString();
int age = root.GetProperty("age").GetInt32();

Console.WriteLine($"Name: {name}, Age: {age}");
```

### Parsing JSON from UTF-8 Bytes

```csharp
ReadOnlySpan<byte> utf8Json = """
    {
        "message": "Hello, World!"
    }
    """u8;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(utf8Json.ToArray().AsMemory());

JsonElement root = doc.RootElement;
string message = root.GetProperty("message").GetString();

Console.WriteLine(message); // Output: Hello, World!
```

### Parsing JSON from a Stream

```csharp
using FileStream fileStream = File.OpenRead("data.json");
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(fileStream);

JsonElement root = doc.RootElement;
// Process the JSON data...
```

### Async Stream Parsing

Asynchronous parsing is ideal for large files or network streams:

```csharp
using FileStream fileStream = File.OpenRead("large-data.json");
using ParsedJsonDocument<JsonElement> doc = await ParsedJsonDocument<JsonElement>.ParseAsync(fileStream);

JsonElement root = doc.RootElement;
// Process the JSON data...
```

### Parsing from Memory Stream

```csharp
ReadOnlySpan<byte> utf8Json = """
    {
        "message": "Hello from stream"
    }
    """u8;
using var stream = new MemoryStream(utf8Json.ToArray());
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(stream);

JsonElement root = doc.RootElement;
string message = root.GetProperty("message").GetString();
```

## Working with JSON Arrays

```csharp
string json = """
    [
        1,
        2,
        3,
        4,
        5
    ]
    """;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

JsonElement root = doc.RootElement;

// Using foreach with EnumerateArray()
foreach (JsonElement element in root.EnumerateArray())
{
    int value = element.GetInt32();
    Console.WriteLine(value);
}

// Or using indexed access
// Note that indexed access is *not* as efficient as enumeration.
int length = root.GetArrayLength();
for (int i = 0; i < length; i++)
{
    int value = root[i].GetInt32();
    Console.WriteLine(value);
}
```

## Working with Nested Objects

```csharp
string json = """
    {
        "person": {
            "name": "Alice",
            "address": {
                "city": "Seattle",
                "zip": "98101"
            }
        }
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

JsonElement root = doc.RootElement;
JsonElement person = root.GetProperty("person");
JsonElement address = person.GetProperty("address");

string name = person.GetProperty("name").GetString();
string city = address.GetProperty("city").GetString();
string zip = address.GetProperty("zip").GetString();

Console.WriteLine($"{name} lives in {city}, {zip}");
```

## Getting Strongly-Typed Values

`JsonElement` provides methods to extract strongly-typed values from JSON. This is similar to System.Text.Json, but with additional types supported.

### Numeric Types

```csharp
string json = """
    {
        "byteValue": 255,
        "sbyteValue": -128,
        "shortValue": -32768,
        "ushortValue": 65535,
        "intValue": -2147483648,
        "uintValue": 4294967295,
        "longValue": -9223372036854775808,
        "ulongValue": 18446744073709551615,
        "floatValue": 3.14159,
        "doubleValue": 2.718281828459045,
        "decimalValue": 79228162514264337593543950335
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

// Integer types
byte byteVal = root.GetProperty("byteValue").GetByte();
sbyte sbyteVal = root.GetProperty("sbyteValue").GetSByte();
short shortVal = root.GetProperty("shortValue").GetInt16();
ushort ushortVal = root.GetProperty("ushortValue").GetUInt16();
int intVal = root.GetProperty("intValue").GetInt32();
uint uintVal = root.GetProperty("uintValue").GetUInt32();
long longVal = root.GetProperty("longValue").GetInt64();
ulong ulongVal = root.GetProperty("ulongValue").GetUInt64();

// Floating-point types
float floatVal = root.GetProperty("floatValue").GetSingle();
double doubleVal = root.GetProperty("doubleValue").GetDouble();
decimal decimalVal = root.GetProperty("decimalValue").GetDecimal();
```

### Boolean Values

```csharp
string json = """
    {
        "isActive": true,
        "isDeleted": false
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

bool isActive = root.GetProperty("isActive").GetBoolean();
bool isDeleted = root.GetProperty("isDeleted").GetBoolean();
```

### String Values

```csharp
string json = """
    {
        "name": "John Doe",
        "email": "john.doe@example.com",
        "description": null
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

string? name = root.GetProperty("name").GetString();
string? email = root.GetProperty("email").GetString();
string? description = root.GetProperty("description").GetString(); // Returns null
```

### Date and Time Values

```csharp
string json = """
    {
        "createdAt": "2024-01-15T10:30:00Z",
        "updatedAt": "2024-02-28T14:45:30.123+05:00",
        "timestamp": "2024-03-01T00:00:00-08:00"
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

// DateTime values
DateTime createdAt = root.GetProperty("createdAt").GetDateTime();

// DateTimeOffset values (preserves timezone information)
DateTimeOffset updatedAt = root.GetProperty("updatedAt").GetDateTimeOffset();
DateTimeOffset timestamp = root.GetProperty("timestamp").GetDateTimeOffset();
```

### Guid Values

```csharp
string json = """
    {
        "userId": "550e8400-e29b-41d4-a716-446655440000",
        "sessionId": "12345678-1234-1234-1234-123456789012"
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

Guid userId = root.GetProperty("userId").GetGuid();
Guid sessionId = root.GetProperty("sessionId").GetGuid();
```

### Binary Data (Base64)

```csharp
string json = """
    {
        "data": "SGVsbG8gV29ybGQh",
        "signature": "AQIDBA=="
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

// Decode base64 strings to byte arrays
byte[] data = root.GetProperty("data").GetBytesFromBase64();
byte[] signature = root.GetProperty("signature").GetBytesFromBase64();

// data contains: "Hello World!" as bytes
// signature contains: [1, 2, 3, 4]
```

### Extended Numeric Types (Beyond System.Text.Json)

Corvus.Text.Json provides additional numeric types not available in System.Text.Json:

```csharp
using System.Numerics;

string json = """
    {
        "largeInteger": 12345678901234567890,
        "preciseNumber": 123.456
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

// BigInteger for large integers beyond long range
BigInteger largeNum = root.GetProperty("largeInteger").GetBigInteger();

// BigNumber for high-precision arithmetic with scale tracking
BigNumber preciseNum = root.GetProperty("preciseNumber").GetBigNumber();
```

### NodaTime Types (Beyond System.Text.Json)

For applications using NodaTime, Corvus.Text.Json provides direct support:

```csharp
using NodaTime;

string json = """
    {
        "localDate": "2024-02-28",
        "offsetTime": "14:30:00+05:00",
        "offsetDate": "2024-02-28+00:00",
        "offsetDateTime": "2024-02-28T14:30:00+05:00",
        "period": "P1Y2M3DT4H5M6S"
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

LocalDate localDate = root.GetProperty("localDate").GetLocalDate();
OffsetTime offsetTime = root.GetProperty("offsetTime").GetOffsetTime();
OffsetDate offsetDate = root.GetProperty("offsetDate").GetOffsetDate();
OffsetDateTime offsetDateTime = root.GetProperty("offsetDateTime").GetOffsetDateTime();
Period period = root.GetProperty("period").GetPeriod();
```

### Type Checking and Safe Conversion

Always check the `ValueKind` before calling Get methods to avoid exceptions:

```csharp
string json = """
    {
        "maybeNumber": "not a number",
        "actualNumber": 42
    }
    """;

using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonElement root = doc.RootElement;

JsonElement maybeNumber = root.GetProperty("maybeNumber");
if (maybeNumber.ValueKind == JsonValueKind.Number)
{
    int value = maybeNumber.GetInt32(); // Safe
}
else
{
    Console.WriteLine("Not a number!"); // This will execute
}

// Use TryGet methods for safer conversion
if (root.GetProperty("actualNumber").TryGetInt32(out int actualValue))
{
    Console.WriteLine($"Value: {actualValue}"); // This will execute
}
```

## Enumerating Object Properties

```csharp
string json = """
    {
        "first": "John",
        "last": "Smith",
        "age": 30
    }
    """;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

JsonElement root = doc.RootElement;
foreach (JsonProperty<JsonElement> property in root.EnumerateObject())
{
    Console.WriteLine($"{property.Name}: {property.Value}");
}
```

## Parsing with Options

```csharp
var options = new JsonDocumentOptions
{
    AllowTrailingCommas = true,
    CommentHandling = JsonCommentHandling.Skip,
    MaxDepth = 64
};

string json = """
    {
        "name": "John", /* comment */
    }
    """;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json, options);

JsonElement root = doc.RootElement;
// Process the JSON data...
```

## Writing JSON from ParsedJsonDocument

```csharp
ReadOnlySpan<byte> utf8Json = """
    {
        "message": "Hello"
    }
    """u8;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(utf8Json.ToArray().AsMemory());

using var stream = new MemoryStream();
using (var writer = new Utf8JsonWriter(stream))
{
    doc.WriteTo(writer);
}

string outputJson = Encoding.UTF8.GetString(stream.ToArray());
Console.WriteLine(outputJson);
```

## Important Notes

### Memory Management

`ParsedJsonDocument<T>` uses pooled memory and **must be disposed** to return memory to the pool. Failure to dispose will result in increased GC pressure.

```csharp
// ❌ Bad - memory leak
var doc = ParsedJsonDocument<JsonElement>.Parse(json);
// Missing dispose!

// ✅ Good - proper disposal
using var doc = ParsedJsonDocument<JsonElement>.Parse(json);
// Automatically disposed at end of scope

// ✅ Also good - explicit disposal
var doc = ParsedJsonDocument<JsonElement>.Parse(json);
try
{
    // Use doc
}
finally
{
    doc.Dispose();
}
```

### Data Lifetime

When parsing from `ReadOnlyMemory<byte>` or `ReadOnlySequence<byte>`, the memory must remain valid for the entire lifetime of the document. The parser does not make a copy of the input data.

### Thread Safety

While `ParsedJsonDocument<T>` itself is thread-safe for read operations after parsing, the underlying JSON data should not be modified during the document's lifetime.

## Static Constants

For common literal values, use the static properties to avoid allocations:

```csharp
JsonElement nullValue = ParsedJsonDocument<JsonElement>.Null;
JsonElement trueValue = ParsedJsonDocument<JsonElement>.True;
JsonElement falseValue = ParsedJsonDocument<JsonElement>.False;
```

## Error Handling

```csharp
try
{
    string invalidJson = """
        {
            invalid json
        }
        """;
    using var doc = ParsedJsonDocument<JsonElement>.Parse(invalidJson);
}
catch (JsonException ex)
{
    Console.WriteLine($"Invalid JSON: {ex.Message}");
}
```

## Performance Tips

1. **Use async for large streams**: When parsing large files or network streams, use `ParseAsync` to avoid blocking
2. **Reuse streams**: When parsing multiple documents, reuse stream objects when possible
3. **Use UTF-8 directly**: Parsing from `ReadOnlyMemory<byte>` is more efficient than parsing from strings
4. **Dispose properly**: Always dispose documents to return memory to the pool
5. **Avoid unnecessary copies**: When working with byte data, use `ReadOnlyMemory<byte>` directly instead of converting to strings
6. **Seekable vs non-seekable streams**: The parser handles both types efficiently, but seekable streams (like FileStream) can be slightly faster
