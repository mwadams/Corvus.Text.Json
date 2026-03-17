---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryFormat Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider) | Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided character span. |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider) | Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided UTF-8 byte span. |
| [TryFormat(Span&lt;char&gt;, ref int)](#tryformat-span-char-ref-int) | Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided character span using default formatting. |
| [TryFormat(Span&lt;byte&gt;, ref int)](#tryformat-span-byte-ref-int) | Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided UTF-8 byte span using default formatting. |

## TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L974)

Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided character span.

```csharp
public bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written to the destination. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

### Implements

[`ISpanFormattable.TryFormat`](https://learn.microsoft.com/dotnet/api/system.ispanformattable.tryformat)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L988)

Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided UTF-8 byte span.

```csharp
public bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination UTF-8 byte span. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the destination. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

### Implements

[`IUtf8SpanFormattable.TryFormat`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable.tryformat)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## TryFormat(Span&lt;char&gt;, ref int) {#tryformat-span-char-ref-int}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L1001)

Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided character span using default formatting.

```csharp
public bool TryFormat(Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written to the destination. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryFormat(Span&lt;byte&gt;, ref int) {#tryformat-span-byte-ref-int}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L1013)

Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided UTF-8 byte span using default formatting.

```csharp
public bool TryFormat(Span<byte> destination, ref int bytesWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination UTF-8 byte span. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the destination. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

