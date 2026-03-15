---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.JsonSchema — Corvus.Text.Json"
---
```csharp
public static class JsonElement.JsonSchema
```

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElement.JsonSchema**

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [SchemaLocationUtf8](/api/corvus-text-json-jsonelement-jsonschema.schemalocationutf8.html) `static` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

## Methods

| Method | Description |
|--------|-------------|
| [Evaluate(IJsonDocument, int, ref JsonSchemaContext)](/api/corvus-text-json-jsonelement-jsonschema.evaluate.html#void-evaluate-ijsondocument-parentdocument-int-parentindex-ref-jsonschemacontext-context) `static` |  |
| [Evaluate(IJsonDocument, int, IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelement-jsonschema.evaluate.html#bool-evaluate-ijsondocument-parentdocument-int-parentindex-ijsonschemaresultscollector-resultscollector) `static` |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-jsonelement-jsonschema.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-ref-jsonschemacontext-context-jsonschemapathprovider-schemaevaluationpath-jsonschemapathprovider-documentevaluationpath) `static` |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, TContext, JsonSchemaPathProvider&lt;TContext&gt;, JsonSchemaPathProvider&lt;TContext&gt;)](/api/corvus-text-json-jsonelement-jsonschema.pushchildcontext.html#jsonschemacontext-pushchildcontext-tcontext-ijsondocument-parentdocument-int-parentdocumentindex-ref-jsonschemacontext-context-tcontext-providercontext-jsonschemapathprovider-tcontext-schemaevaluationpath-jsonschemapathprovider-tcontext-documentevaluationpath) `static` |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider)](/api/corvus-text-json-jsonelement-jsonschema.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-ref-jsonschemacontext-context-readonlyspan-byte-propertyname-jsonschemapathprovider-evaluationpath) `static` |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, int, JsonSchemaPathProvider)](/api/corvus-text-json-jsonelement-jsonschema.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-ref-jsonschemacontext-context-int-itemindex-jsonschemapathprovider-evaluationpath) `static` |  |
| [PushChildContextUnescaped(IJsonDocument, int, ref JsonSchemaContext, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider)](/api/corvus-text-json-jsonelement-jsonschema.pushchildcontextunescaped.html#jsonschemacontext-pushchildcontextunescaped-ijsondocument-parentdocument-int-parentdocumentindex-ref-jsonschemacontext-context-readonlyspan-byte-propertyname-jsonschemapathprovider-evaluationpath) `static` |  |

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [SchemaLocationProvider](/api/corvus-text-json-jsonelement-jsonschema.schemalocationprovider.html) `static` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  |
| [SchemaLocation](/api/corvus-text-json-jsonelement-jsonschema.schemalocation.html) `static` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

