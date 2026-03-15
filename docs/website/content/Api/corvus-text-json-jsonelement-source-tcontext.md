---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Source<TContext> — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElement.Source<TContext>
```

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonElement.Source(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;)](/api/corvus-text-json-jsonelement-source-tcontext.ctor.html#jsonelement-source-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-value) |  |
| [JsonElement.Source(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;)](/api/corvus-text-json-jsonelement-source-tcontext.ctor.html#jsonelement-source-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-value) |  |
| [JsonElement.Source(JsonElement.Source)](/api/corvus-text-json-jsonelement-source-tcontext.ctor.html#jsonelement-source-jsonelement-source-source) |  |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsUndefined](/api/corvus-text-json-jsonelement-source-tcontext.isundefined.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Methods

| Method | Description |
|--------|-------------|
| [AddAsItem(ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source-tcontext.addasitem.html#void-addasitem-ref-complexvaluebuilder-valuebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool)](/api/corvus-text-json-jsonelement-source-tcontext.addasproperty.html#void-addasproperty-readonlyspan-byte-utf8name-ref-complexvaluebuilder-valuebuilder-bool-escapename-bool-namerequiresunescaping) |  |
| [AddAsProperty(string, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source-tcontext.addasproperty.html#void-addasproperty-string-name-ref-complexvaluebuilder-valuebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source-tcontext.addasproperty.html#void-addasproperty-readonlyspan-char-name-ref-complexvaluebuilder-valuebuilder) |  |

## Operators

| Operator | Description |
|----------|-------------|
| [implicit operator JsonElement.Source&lt;TContext&gt;(JsonElement.Source)](/api/corvus-text-json-jsonelement-source-tcontext.op-implicit.html#static-implicit-operator-jsonelement-source-tcontext-jsonelement-source-source) |  |

