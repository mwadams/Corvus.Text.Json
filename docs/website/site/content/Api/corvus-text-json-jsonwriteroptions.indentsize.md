---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.IndentSize Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWriterOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/JsonWriterOptions.cs#L92)

## IndentSize {#indentsize}

Defines the indentation size used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is enabled. Defaults to two.

```csharp
public int IndentSize { get; set; }
```

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `value` is out of the allowed range. |

### Remarks

Allowed values are integers between 0 and 127, included.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

