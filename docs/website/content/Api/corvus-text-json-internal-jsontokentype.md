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
| [None](/api/corvus-text-json-internal-jsontokentype.none.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that there is no value (as distinct from [`Null`](/api/corvus-text-json-internal-jsontokentype.html#null)). |
| [StartObject](/api/corvus-text-json-internal-jsontokentype.startobject.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the start of a JSON object. |
| [EndObject](/api/corvus-text-json-internal-jsontokentype.endobject.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the end of a JSON object. |
| [StartArray](/api/corvus-text-json-internal-jsontokentype.startarray.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the start of a JSON array. |
| [EndArray](/api/corvus-text-json-internal-jsontokentype.endarray.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the end of a JSON array. |
| [PropertyName](/api/corvus-text-json-internal-jsontokentype.propertyname.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON property name. |
| [Comment](/api/corvus-text-json-internal-jsontokentype.comment.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the comment string. |
| [String](/api/corvus-text-json-internal-jsontokentype.string.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON string. |
| [Number](/api/corvus-text-json-internal-jsontokentype.number.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is a JSON number. |
| [True](/api/corvus-text-json-internal-jsontokentype.true.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `true`. |
| [False](/api/corvus-text-json-internal-jsontokentype.false.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `false`. |
| [Null](/api/corvus-text-json-internal-jsontokentype.null.html) `static` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Indicates that the token type is the JSON literal `null`. |

