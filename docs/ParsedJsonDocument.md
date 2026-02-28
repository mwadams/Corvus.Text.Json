# ParsedJsonDocument Usage Guide

## Overview

`ParsedJsonDocument<T>` is a lightweight, read-only representation of a JSON value that utilizes pooled memory to minimize garbage collector impact. It provides an efficient way to parse and navigate JSON documents with minimal allocations.

## Key Features

- **Memory Efficient**: Uses pooled memory from `ArrayPool<byte>` to reduce GC pressure
- **Read-Only**: Provides immutable access to parsed JSON data
- **Multiple Input Sources**: Supports parsing from strings, byte arrays, streams, and sequences
- **IDisposable**: Must be disposed to return pooled memory

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
