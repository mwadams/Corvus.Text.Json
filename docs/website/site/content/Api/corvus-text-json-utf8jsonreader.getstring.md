---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.TryGet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.TryGet.cs#L425)

## GetString {#getstring}

Parses the current JSON token value from the source, unescaped, and transcoded as a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

```csharp
public string GetString()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string), [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname) or [`Null`](/api/corvus-text-json-internal-jsontokentype.html#null)). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |

### Remarks

Returns `null` when [`TokenType`](/api/corvus-text-json-utf8jsonreader.html#tokentype) is [`Null`](/api/corvus-text-json-internal-jsontokentype.html#null).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

