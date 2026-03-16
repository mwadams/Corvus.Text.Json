---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TextEquals Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TextEquals(int, ReadOnlySpan&lt;char&gt;, bool)](#textequals-int-readonlyspan-char-bool) | Determines whether the text at the specified index equals the specified text. |
| [TextEquals(int, ReadOnlySpan&lt;byte&gt;, bool, bool)](#textequals-int-readonlyspan-byte-bool-bool) | Determines whether the UTF-8 text at the specified index equals the specified text. |

## TextEquals(int, ReadOnlySpan&lt;char&gt;, bool) {#textequals-int-readonlyspan-char-bool}

```csharp
public abstract bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
```

Determines whether the text at the specified index equals the specified text.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the text. |
| `otherText` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text is a property name. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the text equals the specified text; otherwise, `false`.

---

## TextEquals(int, ReadOnlySpan&lt;byte&gt;, bool, bool) {#textequals-int-readonlyspan-byte-bool-bool}

```csharp
public abstract bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
```

Determines whether the UTF-8 text at the specified index equals the specified text.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the text. |
| `otherUtf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 text to compare. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text is a property name. |
| `shouldUnescape` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text should be unescaped. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the text equals the specified text; otherwise, `false`.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

