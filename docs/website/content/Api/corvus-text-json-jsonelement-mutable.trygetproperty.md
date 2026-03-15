---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.TryGetProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetProperty(string, ref JsonElement.Mutable)](#bool-trygetproperty-string-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](#bool-trygetproperty-readonlyspan-char-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](#bool-trygetproperty-readonlyspan-byte-utf8propertyname-ref-jsonelement-mutable-value) |  |

## TryGetProperty

```csharp
bool TryGetProperty(string propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

