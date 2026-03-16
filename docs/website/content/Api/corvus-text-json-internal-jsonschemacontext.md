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
| [AddLocalEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.addlocalevaluateditem.html#addlocalevaluateditem-int) | Adds an item at the specified index to the local evaluated items collection. |
| [AddLocalEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.addlocalevaluatedproperty.html#addlocalevaluatedproperty-int) | Adds a property at the specified index to the local evaluated properties collection. |
| [ApplyEvaluated(ref JsonSchemaContext)](/api/corvus-text-json-internal-jsonschemacontext.applyevaluated.html#applyevaluated-ref-jsonschemacontext) | Applies the evaluated properties/items from the child context to this (parent) context, if appropriate. |
| [BeginContext(T, int, bool, bool, IJsonSchemaResultsCollector)](/api/corvus-text-json-internal-jsonschemacontext.begincontext.html#begincontext-t-int-bool-bool-ijsonschemaresultscollector) `static` | Begins a new JSON schema evaluation context for the specified document. |
| [CommitChildContext(bool, ref JsonSchemaContext, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.commitchildcontext.html#commitchildcontext-bool-ref-jsonschemacontext-tprovidercontext-jsonschemamessageprovider-tprovidercontext) |  |
| [CommitChildContext(bool, ref JsonSchemaContext, JsonSchemaMessageProvider)](/api/corvus-text-json-internal-jsonschemacontext.commitchildcontext.html#commitchildcontext-bool-ref-jsonschemacontext-jsonschemamessageprovider) | Commits a child context back to its parent, merging validation results and cleaning up resources. |
| [Dispose()](/api/corvus-text-json-internal-jsonschemacontext.dispose.html#dispose) |  |
| [EndContext()](/api/corvus-text-json-internal-jsonschemacontext.endcontext.html#endcontext) | Ends the root evaluation context, committing any pending results to the results collector. |
| [EvaluatedBooleanSchema(bool)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedbooleanschema.html#evaluatedbooleanschema-bool) | Records the evaluation of a boolean schema. |
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeyword.html#evaluatedkeyword-bool-jsonschemamessageprovider-readonlyspan-byte) | Records the evaluation of a schema keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeyword.html#evaluatedkeyword-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Records the evaluation of a schema keyword with a provider context. |
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordforproperty.html#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte) | Records the evaluation of a schema keyword for a specific property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordforproperty.html#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte) | Records the evaluation of a schema keyword for a specific property with a provider context. |
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordpath.html#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider) | Records the evaluation of a schema keyword using a path-based approach. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.evaluatedkeywordpath.html#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Records the evaluation of a schema keyword using a path-based approach with a provider context. |
| [HasLocalEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalevaluateditem.html#haslocalevaluateditem-int) | Determines whether a specific item at the given index has been locally evaluated. |
| [HasLocalEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalevaluatedproperty.html#haslocalevaluatedproperty-int) | Determines whether a specific property at the given index has been locally evaluated. |
| [HasLocalOrAppliedEvaluatedItem(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalorappliedevaluateditem.html#haslocalorappliedevaluateditem-int) | Determines whether a specific item at the given index has been either locally or applied evaluated. |
| [HasLocalOrAppliedEvaluatedProperty(int)](/api/corvus-text-json-internal-jsonschemacontext.haslocalorappliedevaluatedproperty.html#haslocalorappliedevaluatedproperty-int) | Determines whether a specific property at the given index has been either locally or applied evaluated. |
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.ignoredkeyword.html#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte) | Records that a keyword was ignored during schema evaluation. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonschemacontext.ignoredkeyword.html#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Records that a keyword was ignored during schema evaluation with a provider context. |
| [PopChildContext(ref JsonSchemaContext)](/api/corvus-text-json-internal-jsonschemacontext.popchildcontext.html#popchildcontext-ref-jsonschemacontext) | Pops the most recently pushed child context without committing changes. |
| [PushChildContext(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#pushchildcontext-ijsondocument-int-bool-bool-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#pushchildcontext-ijsondocument-int-bool-bool-int-jsonschemapathprovider-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#pushchildcontext-ijsondocument-int-bool-bool-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Creates a new child context for schema evaluation with typed provider context for path generation. |
| [PushChildContext(IJsonDocument, int, bool, bool, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontext.html#pushchildcontext-ijsondocument-int-bool-bool-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider) | Creates a new child context for schema evaluation with optional path providers. |
| [PushChildContextUnescaped(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-internal-jsonschemacontext.pushchildcontextunescaped.html#pushchildcontextunescaped-ijsondocument-int-bool-bool-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) | Creates a new child context for schema evaluation with unescaped property name tracking. |

