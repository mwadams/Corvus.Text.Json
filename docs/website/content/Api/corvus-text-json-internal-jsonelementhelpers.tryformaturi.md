---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatUri Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormatUri(Utf8Uri, bool, ref string)](#tryformaturi-utf8uri-bool-ref-string) |  |
| [TryFormatUri(Utf8Uri, bool, Span&lt;char&gt;, ref int)](#tryformaturi-utf8uri-bool-span-char-ref-int) |  |

## TryFormatUri(Utf8Uri, bool, ref string) {#tryformaturi-utf8uri-bool-ref-string}

```csharp
public static bool TryFormatUri(Utf8Uri uri, bool isDisplay, ref string result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormatUri(Utf8Uri, bool, Span&lt;char&gt;, ref int) {#tryformaturi-utf8uri-bool-span-char-ref-int}

```csharp
public static bool TryFormatUri(Utf8Uri uri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

