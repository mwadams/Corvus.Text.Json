---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IdnMapping.GetUnicode Method — Corvus.Globalization"
---
## Definition

**Namespace:** Corvus.Globalization  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, ref int)](#bool-getunicode-readonlyspan-byte-ascii-span-byte-outputbuffer-ref-int-written) |  |
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, ref int)](#bool-getunicode-readonlyspan-byte-ascii-span-byte-outputbuffer-int-index-ref-int-written) |  |
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, int, ref int)](#bool-getunicode-readonlyspan-byte-ascii-span-byte-outputbuffer-int-index-int-count-ref-int-written) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, ref int)](#bool-getunicode-readonlyspan-char-ascii-span-char-outputbuffer-ref-int-written) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, ref int)](#bool-getunicode-readonlyspan-char-ascii-span-char-outputbuffer-int-index-ref-int-written) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, int, ref int)](#bool-getunicode-readonlyspan-char-ascii-span-char-outputbuffer-int-index-int-count-ref-int-written) |  |

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, int count, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, int count, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

