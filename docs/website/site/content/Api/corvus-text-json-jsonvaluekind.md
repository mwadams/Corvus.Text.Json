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
| [Undefined](/api/corvus-text-json-jsonvaluekind.undefined.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that there is no value (as distinct from [`Null`](/api/corvus-text-json-jsonvaluekind.html#null)). |
| [Object](/api/corvus-text-json-jsonvaluekind.object.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON object. |
| [Array](/api/corvus-text-json-jsonvaluekind.array.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON array. |
| [String](/api/corvus-text-json-jsonvaluekind.string.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON string. |
| [Number](/api/corvus-text-json-jsonvaluekind.number.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is a JSON number. |
| [True](/api/corvus-text-json-jsonvaluekind.true.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `true`. |
| [False](/api/corvus-text-json-jsonvaluekind.false.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `false`. |
| [Null](/api/corvus-text-json-jsonvaluekind.null.html) `static` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Indicates that a value is the JSON value `null`. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

