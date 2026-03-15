---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonTokenType — Corvus.Text.Json.Internal"
---
```csharp
public enum JsonTokenType : IComparable, ISpanFormattable, IFormattable, IConvertible
```

This enum defines the various JSON tokens that make up a JSON text and is used by the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) when moving from one token to the next. The [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) starts at 'None' by default. The 'Comment' enum value is only ever reached in a specific [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) mode and is not reachable by default.

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `None` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that there is no value (as distinct from [`Null`](/api/corvus-text-json-internal-jsontokentype.html)). |
| `StartObject` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the start of a JSON object. |
| `EndObject` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the end of a JSON object. |
| `StartArray` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the start of a JSON array. |
| `EndArray` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the end of a JSON array. |
| `PropertyName` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON property name. |
| `Comment` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the comment string. |
| `String` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON string. |
| `Number` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON number. |
| `True` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `true`. |
| `False` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `false`. |
| `Null` `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `null`. |

