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
| [BeginChildContext(int, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#beginchildcontext-int-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context. |
| [BeginChildContext(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#beginchildcontext-int-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for a property evaluation. |
| [BeginChildContext(int, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#beginchildcontext-int-int-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for an item evaluation. |
| [BeginChildContext(int, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html#beginchildcontext-int-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Begin a child context. |
| [BeginChildContextUnescaped(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontextunescaped.html#beginchildcontextunescaped-int-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for a property evaluation. |
| [CommitChildContext(int, bool, bool, JsonSchemaMessageProvider)](/api/corvus-text-json-ijsonschemaresultscollector.commitchildcontext.html#commitchildcontext-int-bool-bool-jsonschemamessageprovider) | Commits the last child context. |
| [CommitChildContext(int, bool, bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.commitchildcontext.html#commitchildcontext-int-bool-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext) | Commits the last child context. |
| [EvaluatedBooleanSchema(bool, JsonSchemaMessageProvider)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedbooleanschema.html#evaluatedbooleanschema-bool-jsonschemamessageprovider) | Indicates that a boolean schema was evaluated. |
| [EvaluatedBooleanSchema(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedbooleanschema.html#evaluatedbooleanschema-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext) | Indicates that a boolean schema was evaluated. |
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeyword.html#evaluatedkeyword-bool-jsonschemamessageprovider-readonlyspan-byte) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeyword.html#evaluatedkeyword-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordforproperty.html#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordforproperty.html#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordpath.html#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordpath.html#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Updates the match state for the given evaluated keyword. |
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.ignoredkeyword.html#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte) | Indicates that a schema keyword was ignored. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-ijsonschemaresultscollector.ignoredkeyword.html#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Indicates that a schema keyword was ignored. |
| [PopChildContext(int)](/api/corvus-text-json-ijsonschemaresultscollector.popchildcontext.html#popchildcontext-int) | Abandons the last child context. |

