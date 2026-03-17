---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.BeginContext Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## BeginContext {#begincontext}

```csharp
public static JsonSchemaContext BeginContext<T>(T parentDocument, int parentDocumentIndex, bool usingEvaluatedItems, bool usingEvaluatedProperties, IJsonSchemaResultsCollector resultsCollector)
```

Begins a new JSON schema evaluation context for the specified document.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON document. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `T` | The parent JSON document to evaluate. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index within the parent document. |
| `usingEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether to track evaluated items. |
| `usingEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether to track evaluated properties. |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | An optional results collector for gathering evaluation results. *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) for the evaluation.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

