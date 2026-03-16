---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement.EvaluateSchema Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## EvaluateSchema {#evaluateschema}

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the schema for this element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The results collector for schema evaluation (optional). *(optional)* |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the schema evaluation succeeded; otherwise, `false`.

