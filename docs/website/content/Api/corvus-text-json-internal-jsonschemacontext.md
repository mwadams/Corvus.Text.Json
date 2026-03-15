---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct JsonSchemaContext : IDisposable
```

The context for a JSON schema evaluation.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [HasCollector](/api/corvus-text-json-internal-jsonschemacontext.hascollector.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this context has a [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html). |
| [IsMatch](/api/corvus-text-json-internal-jsonschemacontext.ismatch.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the context represents a match. |
| [RequiresEvaluationTracking](/api/corvus-text-json-internal-jsonschemacontext.requiresevaluationtracking.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this context requires evaluation tracking. |

## Methods

| Method | Description |
|--------|-------------|
| [AddLocalEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.addlocalevaluateditem.html#void-addlocalevaluateditem-int-index) | Adds an item at the specified index to the local evaluated items collection. |
| [AddLocalEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.addlocalevaluatedproperty.html#void-addlocalevaluatedproperty-int-index) | Adds a property at the specified index to the local evaluated properties collection. |
| [ApplyEvaluated(ref JsonSchemaContext)](/api/corvus-text-json-internal-jsonschemacontext.applyevaluated.html#void-applyevaluated-ref-jsonschemacontext-childcontext) | Applies the evaluated properties/items from the child context to this (parent) context, if appropriate. |
| [BeginContext(T, int, bool, bool, IJsonSchemaResultsCollector)](/api/corvus-text-json-internal-jsonschemacontext.begincontext.html#jsonschemacontext-begincontext-t-t-parentdocument-int-parentdocumentindex-bool-usingevaluateditems-bool-usingevaluatedproperties-ijsonschemaresultscollector-resultscollector) `static` | Begins a new JSON schema evaluation context for the specified document. |
| [CommitChildContext(bool, ref JsonSchemaContext, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.commitchildcontext.html#void-commitchildcontext-tprovidercontext-bool-ismatch-ref-jsonschemacontext-childcontext-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider) |  |
| [CommitChildContext(bool, ref JsonSchemaContext, JsonSchemaMessageProvider)](/api/corvus-text-json-internal-jsonschemacontext.commitchildcontext.html#void-commitchildcontext-bool-ismatch-ref-jsonschemacontext-childcontext-jsonschemamessageprovider-messageprovider) | Commits a child context back to its parent, merging validation results and cleaning up resources. |
| [Dispose()](/api/corvus-text-json-internal-jsonschemacontext.dispose.html#void-dispose) |  |
| [EndContext()](/api/corvus-text-json-internal-jsonschemacontext.endcontext.html#void-endcontext) | Ends the root evaluation context, committing any pending results to the results collector. |
| [EvaluatedBooleanSchema(bool)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedbooleanschema.html#void-evaluatedbooleanschema-bool-ismatch) | Records the evaluation of a boolean schema. |
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeyword.html#void-evaluatedkeyword-bool-ismatch-jsonschemamessageprovider-messageprovider-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeyword.html#void-evaluatedkeyword-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword with a provider context. |
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordforproperty.html#void-evaluatedkeywordforproperty-bool-ismatch-jsonschemamessageprovider-messageprovider-readonlyspan-byte-propertyname-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword for a specific property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordforproperty.html#void-evaluatedkeywordforproperty-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-propertyname-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword for a specific property with a provider context. |
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordpath.html#void-evaluatedkeywordpath-bool-ismatch-jsonschemamessageprovider-messageprovider-jsonschemapathprovider-keywordpath) | Records the evaluation of a schema keyword using a path-based approach. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordpath.html#void-evaluatedkeywordpath-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-jsonschemapathprovider-tprovidercontext-keywordpath) | Records the evaluation of a schema keyword using a path-based approach with a provider context. |
| [HasLocalEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalevaluateditem.html#bool-haslocalevaluateditem-int-index) | Determines whether a specific item at the given index has been locally evaluated. |
| [HasLocalEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalevaluatedproperty.html#bool-haslocalevaluatedproperty-int-index) | Determines whether a specific property at the given index has been locally evaluated. |
| [HasLocalOrAppliedEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalorappliedevaluateditem.html#bool-haslocalorappliedevaluateditem-int-index) | Determines whether a specific item at the given index has been either locally or applied evaluated. |
| [HasLocalOrAppliedEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalorappliedevaluatedproperty.html#bool-haslocalorappliedevaluatedproperty-int-index) | Determines whether a specific property at the given index has been either locally or applied evaluated. |
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.ignoredkeyword.html#void-ignoredkeyword-jsonschemamessageprovider-messageprovider-readonlyspan-byte-encodedkeyword) | Records that a keyword was ignored during schema evaluation. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.ignoredkeyword.html#void-ignoredkeyword-tprovidercontext-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-unescapedkeyword) | Records that a keyword was ignored during schema evaluation with a provider context. |
| [PopChildContext(ref JsonSchemaContext)](/api/corvus-text-json-internal-jsonschemacontext.popchildcontext.html#void-popchildcontext-ref-jsonschemacontext-childcontext) | Pops the most recently pushed child context without committing changes. |
| [PushChildContext(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-bool-useevaluateditems-bool-useevaluatedproperties-readonlyspan-byte-escapedpropertyname-jsonschemapathprovider-evaluationpath-jsonschemapathprovider-schemaevaluationpath) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-bool-useevaluateditems-bool-useevaluatedproperties-int-itemindex-jsonschemapathprovider-evaluationpath-jsonschemapathprovider-schemaevaluationpath) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#jsonschemacontext-pushchildcontext-tprovidercontext-ijsondocument-parentdocument-int-parentdocumentindex-bool-useevaluateditems-bool-useevaluatedproperties-tprovidercontext-providercontext-jsonschemapathprovider-tprovidercontext-evaluationpath-jsonschemapathprovider-tprovidercontext-schemaevaluationpath-jsonschemapathprovider-tprovidercontext-documentevaluationpath) | Creates a new child context for schema evaluation with typed provider context for path generation. |
| [PushChildContext(IJsonDocument, int, bool, bool, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#jsonschemacontext-pushchildcontext-ijsondocument-parentdocument-int-parentdocumentindex-bool-useevaluateditems-bool-useevaluatedproperties-jsonschemapathprovider-evaluationpath-jsonschemapathprovider-schemaevaluationpath-jsonschemapathprovider-documentevaluationpath) | Creates a new child context for schema evaluation with optional path providers. |
| [PushChildContextUnescaped(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontextunescaped.html#jsonschemacontext-pushchildcontextunescaped-ijsondocument-parentdocument-int-parentdocumentindex-bool-useevaluateditems-bool-useevaluatedproperties-readonlyspan-byte-unescapedpropertyname-jsonschemapathprovider-evaluationpath-jsonschemapathprovider-schemaevaluationpath) | Creates a new child context for schema evaluation with unescaped property name tracking. |

