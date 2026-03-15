---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonValueKind — Corvus.Text.Json"
---
```csharp
public enum JsonValueKind : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the data type of a JSON value.

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `Undefined` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that there is no value (as distinct from [`Null`](/api/corvus-text-json-jsonvaluekind.html)). |
| `Object` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON object. |
| `Array` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON array. |
| `String` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON string. |
| `Number` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON number. |
| `True` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `true`. |
| `False` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `false`. |
| `Null` `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `null`. |

