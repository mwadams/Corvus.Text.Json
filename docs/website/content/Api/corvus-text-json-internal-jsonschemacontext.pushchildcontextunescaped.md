---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.PushChildContextUnescaped Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## PushChildContextUnescaped {#pushchildcontextunescaped}

```csharp
public JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Creates a new child context for schema evaluation with unescaped property name tracking.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent element in the document. |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated object properties. |
| `unescapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name for path tracking in validation results. |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the full schema evaluation path. *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

### Remarks

This is the unescaped variant of [`PushChildContext`](/api/corvus-text-json-internal-jsonschemacontext.html#pushchildcontext). Use this method when the property name is already in unescaped form to avoid unnecessary processing overhead. The context lifecycle and buffer management behavior is identical to the escaped variant. The only difference is that the property name is passed directly to the results collector without additional escaping processing.

