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
| [BeginChildContext](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontext.html) | Begin a child context. |
| [BeginChildContextUnescaped(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](/api/corvus-text-json-ijsonschemaresultscollector.beginchildcontextunescaped.html#beginchildcontextunescaped-int-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for a property evaluation. |
| [CommitChildContext](/api/corvus-text-json-ijsonschemaresultscollector.commitchildcontext.html) | Commits the last child context. |
| [EvaluatedBooleanSchema](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedbooleanschema.html) | Indicates that a boolean schema was evaluated. |
| [EvaluatedKeyword](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeyword.html) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordForProperty](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordforproperty.html) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordPath](/api/corvus-text-json-ijsonschemaresultscollector.evaluatedkeywordpath.html) | Updates the match state for the given evaluated keyword. |
| [IgnoredKeyword](/api/corvus-text-json-ijsonschemaresultscollector.ignoredkeyword.html) | Indicates that a schema keyword was ignored. |
| [PopChildContext(int)](/api/corvus-text-json-ijsonschemaresultscollector.popchildcontext.html#popchildcontext-int) | Abandons the last child context. |

