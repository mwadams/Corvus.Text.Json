---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryFormat Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-int-span-char-ref-int-readonlyspan-char-iformatprovider) | Formats the value to the provided destination span according to the specified format and format provider. |
| [TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-int-span-byte-ref-int-readonlyspan-char-iformatprovider) | Formats the value to the provided destination UTF-8 span according to the specified format and format provider. |

## TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-int-span-char-ref-int-readonlyspan-char-iformatprovider}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L622)

Formats the value to the provided destination span according to the specified format and format provider.

```csharp
public abstract bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span to write the formatted value to. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written to the destination span. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the formatting was successful; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-int-span-byte-ref-int-readonlyspan-char-iformatprovider}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L622)

Formats the value to the provided destination UTF-8 span according to the specified format and format provider.

```csharp
public abstract bool TryFormat(int index, Span<byte> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span to write the UTF-8 formatted value to. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the formatting was successful; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

