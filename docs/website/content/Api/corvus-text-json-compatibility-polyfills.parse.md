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
| [Parse(string, JsonDocumentOptions)](#parse-string-jsondocumentoptions) |  |
| [Parse(Stream, JsonDocumentOptions)](#parse-stream-jsondocumentoptions) |  |
| [Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions)](#parse-readonlymemory-byte-jsondocumentoptions) |  |
| [Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions)](#parse-readonlymemory-char-jsondocumentoptions) |  |

## Parse(string, JsonDocumentOptions) {#parse-string-jsondocumentoptions}

```csharp
public static T Parse<T>(string value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse(Stream, JsonDocumentOptions) {#parse-stream-jsondocumentoptions}

```csharp
public static T Parse<T>(Stream value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions) {#parse-readonlymemory-byte-jsondocumentoptions}

```csharp
public static T Parse<T>(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

## Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions) {#parse-readonlymemory-char-jsondocumentoptions}

```csharp
public static T Parse<T>(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

### Returns

`T`

---

