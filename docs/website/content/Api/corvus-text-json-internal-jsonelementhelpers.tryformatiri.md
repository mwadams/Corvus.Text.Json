---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatIri Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormatIri(Utf8Iri, bool, ref string)](#tryformatiri-utf8iri-bool-ref-string) |  |
| [TryFormatIri(Utf8Iri, bool, Span&lt;char&gt;, ref int)](#tryformatiri-utf8iri-bool-span-char-ref-int) |  |

## TryFormatIri(Utf8Iri, bool, ref string) {#tryformatiri-utf8iri-bool-ref-string}

```csharp
public static bool TryFormatIri(Utf8Iri iri, bool isDisplay, ref string result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormatIri(Utf8Iri, bool, Span&lt;char&gt;, ref int) {#tryformatiri-utf8iri-bool-span-char-ref-int}

```csharp
public static bool TryFormatIri(Utf8Iri iri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

