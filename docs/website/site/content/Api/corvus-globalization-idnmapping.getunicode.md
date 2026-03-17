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
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, ref int)](#getunicode-readonlyspan-byte-span-byte-ref-int) |  |
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, ref int)](#getunicode-readonlyspan-byte-span-byte-int-ref-int) |  |
| [GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, int, ref int)](#getunicode-readonlyspan-byte-span-byte-int-int-ref-int) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, ref int)](#getunicode-readonlyspan-char-span-char-ref-int) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, ref int)](#getunicode-readonlyspan-char-span-char-int-ref-int) |  |
| [GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, int, ref int)](#getunicode-readonlyspan-char-span-char-int-int-ref-int) |  |

## GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, ref int) {#getunicode-readonlyspan-byte-span-byte-ref-int}

**Source:** [IdnMapping.Unicode.UTF8.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.UTF8.cs#L36)

```csharp
public bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, ref int) {#getunicode-readonlyspan-byte-span-byte-int-ref-int}

**Source:** [IdnMapping.Unicode.UTF8.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.UTF8.cs#L41)

```csharp
public bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, ref int written)
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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetUnicode(ReadOnlySpan&lt;byte&gt;, Span&lt;byte&gt;, int, int, ref int) {#getunicode-readonlyspan-byte-span-byte-int-int-ref-int}

**Source:** [IdnMapping.Unicode.UTF8.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.UTF8.cs#L49)

```csharp
public bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, int count, ref int written)
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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, ref int) {#getunicode-readonlyspan-char-span-char-ref-int}

**Source:** [IdnMapping.Unicode.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.cs#L33)

```csharp
public bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, ref int) {#getunicode-readonlyspan-char-span-char-int-ref-int}

**Source:** [IdnMapping.Unicode.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.cs#L38)

```csharp
public bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, ref int written)
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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetUnicode(ReadOnlySpan&lt;char&gt;, Span&lt;char&gt;, int, int, ref int) {#getunicode-readonlyspan-char-span-char-int-int-ref-int}

**Source:** [IdnMapping.Unicode.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Globalization/IdnMapping.Unicode.cs#L46)

```csharp
public bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, int count, ref int written)
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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

