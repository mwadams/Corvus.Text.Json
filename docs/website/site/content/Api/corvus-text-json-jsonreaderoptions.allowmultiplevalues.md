---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.AllowMultipleValues Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonReaderOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/JsonReaderOptions.cs#L31)

## AllowMultipleValues {#allowmultiplevalues}

Defines whether the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should tolerate zero or more top-level JSON values that are whitespace separated.

```csharp
public bool AllowMultipleValues { get; set; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

By default, it's set to false, and a [`JsonException`](/api/corvus-text-json-jsonexception.html) is thrown if trailing content is encountered after the first top-level JSON value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

