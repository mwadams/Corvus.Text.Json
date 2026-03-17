---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.AllowTrailingCommas Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonReaderOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/JsonReaderOptions.cs#L40)

## AllowTrailingCommas {#allowtrailingcommas}

Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read.

```csharp
public bool AllowTrailingCommas { get; set; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

By default, it's set to false, and a [`JsonException`](/api/corvus-text-json-jsonexception.html) is thrown if a trailing comma is encountered.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

