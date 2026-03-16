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
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormat(Span&lt;char&gt;, ref int)](#tryformat-span-char-ref-int) |  |
| [TryFormat(Span&lt;byte&gt;, ref int)](#tryformat-span-byte-ref-int) |  |

## TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider}

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
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

---

## TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider) {#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider}

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
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

---

## TryFormat(Span&lt;char&gt;, ref int) {#tryformat-span-char-ref-int}

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormat(Span&lt;byte&gt;, ref int) {#tryformat-span-byte-ref-int}

```csharp
bool TryFormat(Span<byte> destination, ref int bytesWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

