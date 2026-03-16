---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatUriReference Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryFormatUriReference(Utf8UriReference, bool, ref string)](#tryformaturireference-utf8urireference-bool-ref-string) |  |
| [TryFormatUriReference(Utf8UriReference, bool, Span&lt;char&gt;, ref int)](#tryformaturireference-utf8urireference-bool-span-char-ref-int) |  |

## TryFormatUriReference(Utf8UriReference, bool, ref string) {#tryformaturireference-utf8urireference-bool-ref-string}

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, ref string result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

## TryFormatUriReference(Utf8UriReference, bool, Span&lt;char&gt;, ref int) {#tryformaturireference-utf8urireference-bool-span-char-ref-int}

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

