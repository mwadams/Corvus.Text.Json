---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions)](#parsevalue-readonlyspan-byte-jsondocumentoptions) | Parses one JSON value (including objects or arrays) from the provided span. |
| [ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions)](#parsevalue-readonlyspan-char-jsondocumentoptions) | Parses one JSON value (including objects or arrays) from the provided span. |
| [ParseValue(string, JsonDocumentOptions)](#parsevalue-string-jsondocumentoptions) | Parses one JSON value (including objects or arrays) from the provided text. |
| [ParseValue(ref Utf8JsonReader)](#parsevalue-ref-utf8jsonreader) | Parses one JSON value (including objects or arrays) from the provided reader. |

## ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions) {#parsevalue-readonlyspan-byte-jsondocumentoptions}

```csharp
public static T ParseValue<T>(ReadOnlySpan<byte> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

### Returns

`T`

A [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) representing the value (and nested values) read from the span.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the span. |

### Remarks

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

---

## ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions) {#parsevalue-readonlyspan-char-jsondocumentoptions}

```csharp
public static T ParseValue<T>(ReadOnlySpan<char> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

### Returns

`T`

A JsonElement representing the value (and nested values) read from the span.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

### Remarks

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

---

## ParseValue(string, JsonDocumentOptions) {#parsevalue-string-jsondocumentoptions}

```csharp
public static T ParseValue<T>(string text, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided text.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

### Returns

`T`

A JsonElement representing the value (and nested values) read from the text.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the text. |

### Remarks

This method makes a copy of the data, so there is no caller requirement to maintain data integrity beyond the return of this method.

---

## ParseValue(ref Utf8JsonReader) {#parsevalue-ref-utf8jsonreader}

```csharp
public static T ParseValue<T>(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

### Returns

`T`

A JsonElement representing the value (and nested values) read from the reader.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

### Remarks

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html#tokentype) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname) or [`None`](/api/corvus-text-json-internal-jsontokentype.html#none), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html#read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

