---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ParseValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions)](#parsevalue-readonlyspan-byte-jsondocumentoptions) | Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions)](#parsevalue-readonlyspan-char-jsondocumentoptions) | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(string, JsonDocumentOptions)](#parsevalue-string-jsondocumentoptions) | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ref Utf8JsonReader)](#parsevalue-ref-utf8jsonreader) | Parses one JSON value (including objects or arrays) from the provided reader. |

## ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions) {#parsevalue-readonlyspan-byte-jsondocumentoptions}

```csharp
JsonElement ParseValue(ReadOnlySpan<byte> utf8Json, JsonDocumentOptions options)
```

Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

---

## ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions) {#parsevalue-readonlyspan-char-jsondocumentoptions}

```csharp
JsonElement ParseValue(ReadOnlySpan<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

---

## ParseValue(string, JsonDocumentOptions) {#parsevalue-string-jsondocumentoptions}

```csharp
JsonElement ParseValue(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `json` is `null`. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

---

## ParseValue(ref Utf8JsonReader) {#parsevalue-ref-utf8jsonreader}

```csharp
JsonElement ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

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

