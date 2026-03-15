---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Polyfills.Parse Method — Corvus.Text.Json.Compatibility"
---
## Definition

**Namespace:** Corvus.Text.Json.Compatibility  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Parse(string, JsonDocumentOptions)](#t-parse-t-string-value-jsondocumentoptions-options) |  |
| [Parse(Stream, JsonDocumentOptions)](#t-parse-t-stream-value-jsondocumentoptions-options) |  |
| [Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions)](#t-parse-t-readonlymemory-byte-value-jsondocumentoptions-options) |  |
| [Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions)](#t-parse-t-readonlymemory-char-value-jsondocumentoptions-options) |  |

## Parse `static`

```csharp
T Parse<T>(string value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse `static`

```csharp
T Parse<T>(Stream value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

