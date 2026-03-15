---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T> — Corvus.Text.Json"
---
```csharp
public sealed class ParsedJsonDocument<T> : JsonDocument, IJsonDocument, IDisposable
```

Represents the structure of a JSON value in a lightweight, read-only form.

## Remarks

This class utilizes resources from pooled memory to minimize the garbage collector (GC) impact in high-usage scenarios. Failure to properly Dispose this object will result in the memory not being returned to the pool, which will cause an increase in GC impact across various parts of the framework.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) → **ParsedJsonDocument<T>**

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` | The [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) representing the value of the document. |
| `Null` `static` | `T` | Gets the null instance. |
| `True` `static` | `T` | Gets the True instance. |
| `False` `static` | `T` | Gets the False instance. |

## Methods

### Dispose

```csharp
void Dispose()
```

### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the document into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This [`RootElement`](/api/corvus-text-json-parsedjsondocument-t.html)'s [`ValueKind`](/api/corvus-text-json-jsonelement.html) would result in an invalid JSON. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### StringConstant `static`

```csharp
T StringConstant(byte[] quotedUtf8String)
```

Creates a constant string instance that does not require disposal.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `quotedUtf8String` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The quoted UTF-8 string constant value. |

**Returns:** `T`

The instance.

This is used for fast initialization for a static value.

### NumberConstant `static`

```csharp
T NumberConstant(byte[] utf8Number)
```

Creates a constant number instance that does not require disposal.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Number` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The UTF-8 number constant value. |

**Returns:** `T`

The instance.

This is used for fast initialization for a static value.

### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlyMemory<byte> utf8Json, JsonDocumentOptions options)
```

Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

The `ReadOnlyMemory` value will be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlySequence<byte> utf8Json, JsonDocumentOptions options)
```

Parse a sequence as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

The `ReadOnlySequence` may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(Stream utf8Json, JsonDocumentOptions options)
```

Parse a `Stream` as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | JSON data to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseAsync `static`

```csharp
Task<ParsedJsonDocument<T>> ParseAsync(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
```

Parse a `Stream` as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | JSON data to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |
| `cancellationToken` | [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) | The token to monitor for cancellation requests. *(optional)* |

**Returns:** [`Task<ParsedJsonDocument<T>>`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)

A Task to produce a ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlyMemory<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

The `ReadOnlyMemory` value may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime.

### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref ParsedJsonDocument<T> document)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |
| `document` | [`ref ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html) | Receives the parsed document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if a value was read and parsed into a ParsedJsonDocument, `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html) or [`None`](/api/corvus-text-json-internal-jsontokentype.html), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

### ParseValue `static`

```csharp
ParsedJsonDocument<T> ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

**Returns:** [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html) or [`None`](/api/corvus-text-json-internal-jsontokentype.html), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

