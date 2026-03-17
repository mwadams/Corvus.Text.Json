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
| [TryGetProperty(string, ref JsonElement.Mutable)](#trygetproperty-string-ref-jsonelement-mutable) |  |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](#trygetproperty-readonlyspan-char-ref-jsonelement-mutable) |  |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](#trygetproperty-readonlyspan-byte-ref-jsonelement-mutable) |  |

## TryGetProperty(string, ref JsonElement.Mutable) {#trygetproperty-string-ref-jsonelement-mutable}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L2532)

```csharp
public bool TryGetProperty(string propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable) {#trygetproperty-readonlyspan-char-ref-jsonelement-mutable}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L2566)

```csharp
public bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable) {#trygetproperty-readonlyspan-byte-ref-jsonelement-mutable}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L2602)

```csharp
public bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

