---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaResultsLevel — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaResultsLevel.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/JsonSchemaResultsLevel.cs#L14)

The level of result to collect for an [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html).

```csharp
public enum JsonSchemaResultsLevel : IComparable, ISpanFormattable, IFormattable, IConvertible
```

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [Basic](/api/corvus-text-json-jsonschemaresultslevel.basic.html) `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes basic location and message information about schema matching failures. |
| [Detailed](/api/corvus-text-json-jsonschemaresultslevel.detailed.html) `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes detailed location and message information about schema matching failures. |
| [Verbose](/api/corvus-text-json-jsonschemaresultslevel.verbose.html) `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes full location and message information for schema matching. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

