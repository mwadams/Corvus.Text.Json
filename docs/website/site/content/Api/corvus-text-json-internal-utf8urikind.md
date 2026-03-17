---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriKind — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8UriKind.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Uri/Utf8UriKind.cs#L14)

Defines the kind of URI, controlling whether absolute or relative URIs are used.

```csharp
public enum Utf8UriKind : IComparable, ISpanFormattable, IFormattable, IConvertible
```

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [RelativeOrAbsolute](/api/corvus-text-json-internal-utf8urikind.relativeorabsolute.html) `static` | [`Utf8UriKind`](/api/corvus-text-json-internal-utf8urikind.html) | The kind of URI is indeterminate. The URI can be either relative or absolute. |
| [Absolute](/api/corvus-text-json-internal-utf8urikind.absolute.html) `static` | [`Utf8UriKind`](/api/corvus-text-json-internal-utf8urikind.html) | The URI is an absolute URI. |
| [Relative](/api/corvus-text-json-internal-utf8urikind.relative.html) `static` | [`Utf8UriKind`](/api/corvus-text-json-internal-utf8urikind.html) | The URI is a relative URI. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

