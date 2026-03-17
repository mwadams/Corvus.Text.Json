---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TrySkip Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L398)

## TrySkip {#tryskip}

Tries to skip the children of the current JSON token.

```csharp
public bool TrySkip()
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if there was enough data for the children to be skipped successfully, else false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown when an invalid JSON token is encountered while skipping, according to the JSON RFC, or if the current depth exceeds the recursive limit set by the max depth. |

### Remarks

If the reader did not have enough data to completely skip the children of the current token, it will be reset to the state it was in before the method was called. When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html#tokentype) is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname), the reader first moves to the property value. When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html#tokentype) (originally, or after advancing) is [`StartObject`](/api/corvus-text-json-internal-jsontokentype.html#startobject) or [`StartArray`](/api/corvus-text-json-internal-jsontokentype.html#startarray), the reader advances to the matching [`EndObject`](/api/corvus-text-json-internal-jsontokentype.html#endobject) or [`EndArray`](/api/corvus-text-json-internal-jsontokentype.html#endarray). For all other token types, the reader does not move. After the next call to [`Read`](/api/corvus-text-json-utf8jsonreader.html#read), the reader will be at the next value (when in an array), the next property name (when in an object), or the end array/object token.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

