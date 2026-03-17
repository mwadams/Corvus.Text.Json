---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatNumber Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormatNumber(ReadOnlySpan&lt;byte&gt;, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformatnumber-readonlyspan-byte-span-char-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormatNumber(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformatnumber-readonlyspan-byte-span-byte-ref-int-readonlyspan-char-iformatprovider) |  |

## TryFormatNumber(ReadOnlySpan&lt;byte&gt;, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformatnumber-readonlyspan-byte-span-char-ref-int-readonlyspan-char-iformatprovider}

```csharp
public static bool TryFormatNumber(ReadOnlySpan<byte> span, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormatNumber(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformatnumber-readonlyspan-byte-span-byte-ref-int-readonlyspan-char-iformatprovider}

```csharp
public static bool TryFormatNumber(ReadOnlySpan<byte> span, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

