---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.AddFormattedNumber Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [AddFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addformattednumber-readonlyspan-byte-readonlyspan-byte-bool-bool) |  |
| [AddFormattedNumber(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#addformattednumber-readonlyspan-char-readonlyspan-byte) |  |

## AddFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addformattednumber-readonlyspan-byte-readonlyspan-byte-bool-bool}

**Source:** [JsonElement.ObjectBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.ObjectBuilder.cs#L108)

```csharp
public void AddFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddFormattedNumber(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#addformattednumber-readonlyspan-char-readonlyspan-byte}

**Source:** [JsonElement.ObjectBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.ObjectBuilder.cs#L707)

```csharp
public void AddFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

