---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaResultsLevel — Corvus.Text.Json"
---
```csharp
public enum JsonSchemaResultsLevel : IComparable, ISpanFormattable, IFormattable, IConvertible
```

The level of result to collect for an [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html).

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `Basic` `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes basic location and message information about schema matching failures. |
| `Detailed` `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes detailed location and message information about schema matching failures. |
| `Verbose` `static` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) | Includes full location and message information for schema matching. |

