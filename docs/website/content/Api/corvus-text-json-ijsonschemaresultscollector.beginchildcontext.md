---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.BeginChildContext Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [BeginChildContext(int, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](#beginchildcontext-int-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context. |
| [BeginChildContext(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](#beginchildcontext-int-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for a property evaluation. |
| [BeginChildContext(int, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](#beginchildcontext-int-int-jsonschemapathprovider-jsonschemapathprovider) | Begin a child context for an item evaluation. |
| [BeginChildContext(int, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](#beginchildcontext-int-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Begin a child context. |

## BeginChildContext(int, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider) {#beginchildcontext-int-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider}

```csharp
public abstract int BeginChildContext(int parentSequenceNumber, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

Begin a child context.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path taken through the schema(s). *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path. *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path in the JSON document instance. *(optional)* |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

### Remarks

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext). In DEBUG builds, the sequence number returned by the call to [`BeginChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#beginchildcontext) is passed to the commit or pop methods and validated to ensure that completion operations are carried out in the expected order.

---

## BeginChildContext(int, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider) {#beginchildcontext-int-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider}

```csharp
public abstract int BeginChildContext(int parentSequenceNumber, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `escapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The escaped name of the property for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

### Remarks

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext).

---

## BeginChildContext(int, int, JsonSchemaPathProvider, JsonSchemaPathProvider) {#beginchildcontext-int-int-jsonschemapathprovider-jsonschemapathprovider}

```csharp
public abstract int BeginChildContext(int parentSequenceNumber, int itemIndex, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for an item evaluation.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

### Remarks

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext).

---

## BeginChildContext(int, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;) {#beginchildcontext-int-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext}

```csharp
public abstract int BeginChildContext<TProviderContext>(int parentSequenceNumber, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> reducedEvaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

Begin a child context.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `providerContext` | `TProviderContext` | The context to be passed to the path provider. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path taken through the schema(s) at which the child context is being evaluated. |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path. |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path in the JSON document instance at which the child context is being evaluated. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

### Remarks

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext). A child context operates like a stack. You *must* pop/commit child contexts in *reverse order* of that in which you Begin() a child context. The sequence number returned by [`BeginChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#beginchildcontext) and passed in to [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#commitchildcontext) or [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html#popchildcontext) is used to enforce this

---

