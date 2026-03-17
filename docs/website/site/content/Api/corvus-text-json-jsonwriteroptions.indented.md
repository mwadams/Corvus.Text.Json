---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.Indented Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Indented {#indented}

```csharp
public bool Indented { get; set; }
```

Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should pretty print the JSON which includes: indenting nested JSON tokens, adding new lines, and adding white space between property names and values. By default, the JSON is written without any extra white space.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

