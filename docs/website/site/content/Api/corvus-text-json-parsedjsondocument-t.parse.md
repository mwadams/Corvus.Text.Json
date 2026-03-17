---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.Parse Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions)](#parse-readonlymemory-byte-jsondocumentoptions) | Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(ReadOnlySequence&lt;byte&gt;, JsonDocumentOptions)](#parse-readonlysequence-byte-jsondocumentoptions) | Parse a sequence as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(Stream, JsonDocumentOptions)](#parse-stream-jsondocumentoptions) | Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion. |
| [Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions)](#parse-readonlymemory-char-jsondocumentoptions) | Parses text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(string, JsonDocumentOptions)](#parse-string-jsondocumentoptions) | Parses text representing a single JSON value into a ParsedJsonDocument. |

## Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions) {#parse-readonlymemory-byte-jsondocumentoptions}

**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L90)

Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

```csharp
public static ParsedJsonDocument<T> Parse(ReadOnlyMemory<byte> utf8Json, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### Remarks

The [`ReadOnlyMemory`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) value will be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(ReadOnlySequence&lt;byte&gt;, JsonDocumentOptions) {#parse-readonlysequence-byte-jsondocumentoptions}

**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L120)

Parse a sequence as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

```csharp
public static ParsedJsonDocument<T> Parse(ReadOnlySequence<byte> utf8Json, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### Remarks

The [`ReadOnlySequence`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(Stream, JsonDocumentOptions) {#parse-stream-jsondocumentoptions}

**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L161)

Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

```csharp
public static ParsedJsonDocument<T> Parse(Stream utf8Json, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | JSON data to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions) {#parse-readonlymemory-char-jsondocumentoptions}

**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L276)

Parses text representing a single JSON value into a ParsedJsonDocument.

```csharp
public static ParsedJsonDocument<T> Parse(ReadOnlyMemory<char> json, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### Remarks

The [`ReadOnlyMemory`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) value may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(string, JsonDocumentOptions) {#parse-string-jsondocumentoptions}

**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L339)

Parses text representing a single JSON value into a ParsedJsonDocument.

```csharp
public static ParsedJsonDocument<T> Parse(string json, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

### Returns

[`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

A ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

