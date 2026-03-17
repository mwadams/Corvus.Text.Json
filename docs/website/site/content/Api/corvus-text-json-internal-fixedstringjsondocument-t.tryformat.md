---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "FixedStringJsonDocument<T>.TryFormat Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-int-span-char-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-int-span-byte-ref-int-readonlyspan-char-iformatprovider) |  |

## TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-int-span-char-ref-int-readonlyspan-char-iformatprovider}

```csharp
public bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Implements

[`IJsonDocument.TryFormat`](/api/corvus-text-json-internal-ijsondocument.tryformat.html)

---

## TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-int-span-byte-ref-int-readonlyspan-char-iformatprovider}

```csharp
public bool TryFormat(int index, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Implements

[`IJsonDocument.TryFormat`](/api/corvus-text-json-internal-ijsondocument.tryformat.html)

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

