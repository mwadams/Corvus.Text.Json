---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.EvaluateSchema Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## EvaluateSchema {#evaluateschema}

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the JSON Schema for this element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The (optional) results collector for schema validation. *(optional)* |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the element is valid according to its schema; otherwise, `false`.

