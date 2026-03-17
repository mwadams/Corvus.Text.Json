---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.GetProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetProperty(string)](#getproperty-string) |  |
| [GetProperty(ReadOnlySpan&lt;char&gt;)](#getproperty-readonlyspan-char) |  |
| [GetProperty(ReadOnlySpan&lt;byte&gt;)](#getproperty-readonlyspan-byte) |  |

## GetProperty(string) {#getproperty-string}

```csharp
public JsonElement.Mutable GetProperty(string propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Returns

[`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html)

---

## GetProperty(ReadOnlySpan&lt;char&gt;) {#getproperty-readonlyspan-char}

```csharp
public JsonElement.Mutable GetProperty(ReadOnlySpan<char> propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

### Returns

[`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html)

---

## GetProperty(ReadOnlySpan&lt;byte&gt;) {#getproperty-readonlyspan-byte}

```csharp
public JsonElement.Mutable GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

### Returns

[`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html)

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

