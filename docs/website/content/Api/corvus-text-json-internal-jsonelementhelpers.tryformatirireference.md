---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatIriReference Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormatIriReference(Utf8IriReference, bool, ref string)](#tryformatirireference-utf8irireference-bool-ref-string) |  |
| [TryFormatIriReference(Utf8IriReference, bool, Span&lt;char&gt;, ref int)](#tryformatirireference-utf8irireference-bool-span-char-ref-int) |  |

## TryFormatIriReference(Utf8IriReference, bool, ref string) {#tryformatirireference-utf8irireference-bool-ref-string}

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, ref string result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormatIriReference(Utf8IriReference, bool, Span&lt;char&gt;, ref int) {#tryformatirireference-utf8irireference-bool-span-char-ref-int}

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

