---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.TryGetNamedPropertyValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement-mutable) |  |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement-mutable) |  |

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable) {#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement-mutable}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L79)

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
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

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable) {#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement-mutable}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L79)

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement.Mutable value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

