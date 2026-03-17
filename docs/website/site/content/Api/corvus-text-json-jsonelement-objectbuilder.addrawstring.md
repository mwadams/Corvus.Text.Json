---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.AddRawString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [AddRawString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#addrawstring-readonlyspan-byte-readonlyspan-byte-bool-bool-bool) |  |
| [AddRawString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool)](#addrawstring-readonlyspan-char-readonlyspan-byte-bool) |  |

## AddRawString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool) {#addrawstring-readonlyspan-byte-readonlyspan-byte-bool-bool-bool}

**Source:** [JsonElement.ObjectBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.ObjectBuilder.cs#L126)

```csharp
public void AddRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddRawString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool) {#addrawstring-readonlyspan-char-readonlyspan-byte-bool}

**Source:** [JsonElement.ObjectBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.ObjectBuilder.cs#L720)

```csharp
public void AddRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

