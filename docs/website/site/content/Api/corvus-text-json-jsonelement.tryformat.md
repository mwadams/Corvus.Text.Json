---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryFormat Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider) |  |

## TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2296)

```csharp
public bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Implements

[`ISpanFormattable.TryFormat`](https://learn.microsoft.com/dotnet/api/system.ispanformattable.tryformat)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2304)

```csharp
public bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Implements

[`IUtf8SpanFormattable.TryFormat`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable.tryformat)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

