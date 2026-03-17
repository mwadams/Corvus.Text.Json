---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.PushChildContext Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [PushChildContext(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-bool-bool-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, int, JsonSchemaPathProvider, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-bool-bool-int-jsonschemapathprovider-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, bool, bool, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](#pushchildcontext-ijsondocument-int-bool-bool-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Creates a new child context for schema evaluation with typed provider context for path generation. |
| [PushChildContext(IJsonDocument, int, bool, bool, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-bool-bool-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider) | Creates a new child context for schema evaluation with optional path providers. |

## PushChildContext(IJsonDocument, int, bool, bool, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-bool-bool-readonlyspan-byte-jsonschemapathprovider-jsonschemapathprovider}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L303)

```csharp
public JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## PushChildContext(IJsonDocument, int, bool, bool, int, JsonSchemaPathProvider, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-bool-bool-int-jsonschemapathprovider-jsonschemapathprovider}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L357)

```csharp
public JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, int itemIndex, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## PushChildContext(IJsonDocument, int, bool, bool, TProviderContext, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;) {#pushchildcontext-ijsondocument-int-bool-bool-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L34)

Creates a new child context for schema evaluation with typed provider context for path generation.

```csharp
public JsonSchemaContext PushChildContext<TProviderContext>(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> evaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context used for path generation. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent element in the document. |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated object properties. |
| `providerContext` | `TProviderContext` | The typed context object passed to path provider delegates. |
| `evaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the full schema evaluation path. *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the document instance path. *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

### Remarks

This overload provides strongly-typed context support for custom path providers. The `providerContext` is passed to each of the path provider delegates, allowing for stateful or computed path generation based on validation context. This is particularly useful for complex validation scenarios where path generation depends on runtime state, computed values, or external configuration.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## PushChildContext(IJsonDocument, int, bool, bool, JsonSchemaPathProvider, JsonSchemaPathProvider, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-bool-bool-jsonschemapathprovider-jsonschemapathprovider-jsonschemapathprovider}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L469)

Creates a new child context for schema evaluation with optional path providers.

```csharp
public JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent element in the document. |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated object properties. |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the full schema evaluation path. *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the document instance path. *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

### Remarks

This is the most flexible overload for child context creation, allowing custom path providers for all three path types: evaluation path, schema evaluation path, and document evaluation path. These paths are used for generating detailed validation error messages and tracing schema evaluation flow. Use this overload when you need full control over path generation without requiring a typed provider context object.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

