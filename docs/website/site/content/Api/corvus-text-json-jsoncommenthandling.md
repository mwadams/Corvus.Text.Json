---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonCommentHandling — Corvus.Text.Json"
---
```csharp
public enum JsonCommentHandling : IComparable, ISpanFormattable, IFormattable, IConvertible
```

This enum defines the various ways the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) can deal with comments.

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [Disallow](/api/corvus-text-json-jsoncommenthandling.disallow.html) `static` | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | By default, do no allow comments within the JSON input. Comments are treated as invalid JSON if found and a [`JsonException`](/api/corvus-text-json-jsonexception.html) is thrown. |
| [Skip](/api/corvus-text-json-jsoncommenthandling.skip.html) `static` | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | Allow comments within the JSON input and ignore them. The [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) will behave as if no comments were present. |
| [Allow](/api/corvus-text-json-jsoncommenthandling.allow.html) `static` | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | Allow comments within the JSON input and treat them as valid tokens. While reading, the caller will be able to access the comment values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

