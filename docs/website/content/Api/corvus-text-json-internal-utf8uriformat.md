---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriFormat — Corvus.Text.Json.Internal"
---
```csharp
public enum Utf8UriFormat : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the format options for URI string representation.

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [UriEscaped](/api/corvus-text-json-internal-utf8uriformat.uriescaped.html) `static` | [`Utf8UriFormat`](/api/corvus-text-json-internal-utf8uriformat.html) | The URI is represented with URI escaping applied. |
| [Unescaped](/api/corvus-text-json-internal-utf8uriformat.unescaped.html) `static` | [`Utf8UriFormat`](/api/corvus-text-json-internal-utf8uriformat.html) | The URI is completely unescaped. |
| [SafeUnescaped](/api/corvus-text-json-internal-utf8uriformat.safeunescaped.html) `static` | [`Utf8UriFormat`](/api/corvus-text-json-internal-utf8uriformat.html) | The URI is canonically unescaped, allowing the same URI to be reconstructed from the output. If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

