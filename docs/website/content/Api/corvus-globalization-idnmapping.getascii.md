---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IdnMapping.GetAscii Method — Corvus.Globalization"
---
## Definition

**Namespace:** Corvus.Globalization  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, ref int)](#getascii-readonlyspan-char-span-char-ref-int) |  |
| [GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, ref int)](#getascii-readonlyspan-char-span-char-int-ref-int) |  |
| [GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, int, ref int)](#getascii-readonlyspan-char-span-char-int-int-ref-int) |  |

## GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, ref int) {#getascii-readonlyspan-char-span-char-ref-int}

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, ref int) {#getascii-readonlyspan-char-span-char-int-ref-int}

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetAscii(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, int, ref int) {#getascii-readonlyspan-char-span-char-int-int-ref-int}

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, int count, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

