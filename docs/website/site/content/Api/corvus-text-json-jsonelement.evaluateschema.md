---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.EvaluateSchema Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.JsonSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.JsonSchema.cs#L28)

## EvaluateSchema {#evaluateschema}

Evaluates the JSON Schema for this element.

```csharp
public bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The (optional) results collector for schema validation. *(optional)* |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the element is valid according to its schema; otherwise, `false`.

### Implements

[`IJsonElement.EvaluateSchema`](/api/corvus-text-json-internal-ijsonelement.evaluateschema.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

