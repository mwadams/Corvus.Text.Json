---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector — Corvus.Text.Json"
---
```csharp
public interface IJsonSchemaResultsCollector : IDisposable
```

Implemented by types that accumulate the results of a JSON Schema evaluation.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Implemented By

[`JsonSchemaResultsCollector`](/api/corvus-text-json-jsonschemaresultscollector.html)

## Methods

| Method | Description |
|--------|-------------|
| [BeginChildContext(int, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#int-beginchildcontext-int-parentsequencenumber-jsonschemapathprovider-reducedevaluationpath-jsonschemapathprovider-schemaevaluationpath-jsonschemapathprovider-documentevaluationpath) | Begin a child context. |
| [BeginChildContext(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#int-beginchildcontext-int-parentsequencenumber-readonlyspan-byte-escapedpropertyname-jsonschemapathprovider-reducedevaluationpath-jsonschemapathprovider-schemaevaluationpath) | Begin a child context for a property evaluation. |
| [BeginChildContext(int, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#int-beginchildcontext-int-parentsequencenumber-int-itemindex-jsonschemapathprovider-reducedevaluationpath-jsonschemapathprovider-schemaevaluationpath) | Begin a child context for an item evaluation. |
| [BeginChildContext(int, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#int-beginchildcontext-tprovidercontext-int-parentsequencenumber-tprovidercontext-providercontext-jsonschemapathprovider-tprovidercontext-reducedevaluationpath-jsonschemapathprovider-tprovidercontext-schemaevaluationpath-jsonschemapathprovider-tprovidercontext-documentevaluationpath) | Begin a child context. |
| [BeginChildContextUnescaped(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontextunescaped.html#int-beginchildcontextunescaped-int-parentsequencenumber-readonlyspan-byte-unescapedpropertyname-jsonschemapathprovider-reducedevaluationpath-jsonschemapathprovider-schemaevaluationpath) | Begin a child context for a property evaluation. |
| [CommitChildContext(int, bool, bool, JsonSchemaMessageProvider)](/api/corvus-text-json-ijsonschemaresultscollector.commitchildcontext.html#void-commitchildcontext-int-sequencenumber-bool-parentismatch-bool-childismatch-jsonschemamessageprovider-messageprovider) | Commits the last child context. |
| [CommitChildContext(int, bool, bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.commitchildcontext.html#void-commitchildcontext-tprovidercontext-int-sequencenumber-bool-parentismatch-bool-childismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider) | Commits the last child context. |
| [EvaluatedBooleanSchema(bool, JsonSchemaMessageProvider)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedbooleanschema.html#void-evaluatedbooleanschema-bool-ismatch-jsonschemamessageprovider-messageprovider) | Indicates that a boolean schema was evaluated. |
| [EvaluatedBooleanSchema(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedbooleanschema.html#void-evaluatedbooleanschema-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider) | Indicates that a boolean schema was evaluated. |
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeyword.html#void-evaluatedkeyword-bool-ismatch-jsonschemamessageprovider-messageprovider-readonlyspan-byte-encodedkeyword) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeyword.html#void-evaluatedkeyword-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-encodedkeyword) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordforproperty.html#void-evaluatedkeywordforproperty-bool-ismatch-jsonschemamessageprovider-messageprovider-readonlyspan-byte-propertyname-readonlyspan-byte-encodedkeyword) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordforproperty.html#void-evaluatedkeywordforproperty-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-propertyname-readonlyspan-byte-encodedkeyword) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordpath.html#void-evaluatedkeywordpath-bool-ismatch-jsonschemamessageprovider-messageprovider-jsonschemapathprovider-encodedkeywordpath) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordpath.html#void-evaluatedkeywordpath-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-jsonschemapathprovider-tprovidercontext-encodedkeywordpath) | Updates the match state for the given evaluated keyword. |
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.ignoredkeyword.html#void-ignoredkeyword-jsonschemamessageprovider-messageprovider-readonlyspan-byte-encodedkeyword) | Indicates that a schema keyword was ignored. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.ignoredkeyword.html#void-ignoredkeyword-tprovidercontext-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-encodedkeyword) | Indicates that a schema keyword was ignored. |
| [PopChildContext(int)](/api/corvus-text-json-ijsonschemaresultscollector.popchildcontext.html#void-popchildcontext-int-sequencenumber) | Abandons the last child context. |

