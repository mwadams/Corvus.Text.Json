---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.BeginChildContextUnescaped Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## BeginChildContextUnescaped `abstract`

```csharp
int BeginChildContextUnescaped(int parentSequenceNumber, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `unescapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

### Remarks

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext).

