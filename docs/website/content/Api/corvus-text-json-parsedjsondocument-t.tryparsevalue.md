---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.TryParseValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref ParsedJsonDocument<T> document)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |
| `document` | [`ref ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html) | Receives the parsed document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if a value was read and parsed into a ParsedJsonDocument, `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

### Remarks

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html#tokentype) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname) or [`None`](/api/corvus-text-json-internal-jsontokentype.html#none), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html#read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

