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
| `IsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the context represents a match. |
| `HasCollector` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this context has a [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html). |
| `RequiresEvaluationTracking` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this context requires evaluation tracking. |

## Methods

### BeginContext `static`

```csharp
JsonSchemaContext BeginContext<T>(T parentDocument, int parentDocumentIndex, bool usingEvaluatedItems, bool usingEvaluatedProperties, IJsonSchemaResultsCollector resultsCollector)
```

Begins a new JSON schema evaluation context for the specified document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `T` | The parent JSON document to evaluate. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index within the parent document. |
| `usingEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether to track evaluated items. |
| `usingEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether to track evaluated properties. |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | An optional results collector for gathering evaluation results. *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) for the evaluation.

### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, int itemIndex, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

### PushChildContextUnescaped

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Creates a new child context for schema evaluation with unescaped property name tracking.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent element in the document. |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated object properties. |
| `unescapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name for path tracking in validation results. |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the full schema evaluation path. *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

This is the unescaped variant of [`PushChildContext`](/api/corvus-text-json-internal-jsonschemacontext.html). Use this method when the property name is already in unescaped form to avoid unnecessary processing overhead. The context lifecycle and buffer management behavior is identical to the escaped variant. The only difference is that the property name is passed directly to the results collector without additional escaping processing.

### PushChildContext

```csharp
JsonSchemaContext PushChildContext<TProviderContext>(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> evaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

Creates a new child context for schema evaluation with typed provider context for path generation.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context used for path generation. |

**Parameters:**

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

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

This overload provides strongly-typed context support for custom path providers. The `providerContext` is passed to each of the path provider delegates, allowing for stateful or computed path generation based on validation context. This is particularly useful for complex validation scenarios where path generation depends on runtime state, computed values, or external configuration.

### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

Creates a new child context for schema evaluation with optional path providers.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent element in the document. |
| `useEvaluatedItems` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether this child context should track evaluated object properties. |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the full schema evaluation path. *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | Optional provider for the document instance path. *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

A new child context initialized for the specified element.

This is the most flexible overload for child context creation, allowing custom path providers for all three path types: evaluation path, schema evaluation path, and document evaluation path. These paths are used for generating detailed validation error messages and tracing schema evaluation flow. Use this overload when you need full control over path generation without requiring a typed provider context object.

### CommitChildContext

```csharp
void CommitChildContext<TProviderContext>(bool isMatch, ref JsonSchemaContext childContext, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `providerContext` | `TProviderContext` |  |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  *(optional)* |

### CommitChildContext

```csharp
void CommitChildContext(bool isMatch, ref JsonSchemaContext childContext, JsonSchemaMessageProvider messageProvider)
```

Commits a child context back to its parent, merging validation results and cleaning up resources.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the parent validation succeeded. |
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The child context to commit (passed by readonly reference for performance). |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Optional provider for generating validation messages. *(optional)* |

This is the non-generic overload of [`CommitChildContext`](/api/corvus-text-json-internal-jsonschemacontext.html). Use this method when you don't need typed provider context for message generation. The lifecycle management behavior is identical to the generic overload: - Validation results are merged into the results collector - Buffer ownership is transferred from child to parent - Parent match status is updated based on the provided `isMatch` value Typical Usage: Use this overload for simple validation scenarios where error messages don't require additional context beyond the standard validation paths.

### EndContext

```csharp
void EndContext()
```

Ends the root evaluation context, committing any pending results to the results collector.

This method must be called after the root `Evaluate` completes to ensure that results written directly at the root level (e.g., `required` keyword failures) are committed to the results collector. Without this call, such results are orphaned because [`BeginContext`](/api/corvus-text-json-internal-jsonschemacontext.html) opens a child context on the collector that is never otherwise committed.

### EvaluatedBooleanSchema

```csharp
void EvaluatedBooleanSchema(bool isMatch)
```

Records the evaluation of a boolean schema.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the boolean schema matched. |

### EvaluatedKeyword

```csharp
void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

### EvaluatedKeyword

```csharp
void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

### EvaluatedKeywordForProperty

```csharp
void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword for a specific property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property being evaluated. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

### EvaluatedKeywordForProperty

```csharp
void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword for a specific property with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property being evaluated. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

### EvaluatedKeywordPath

```csharp
void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The message provider for generating evaluation messages. |
| `keywordPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path provider for the keyword being evaluated. |

### EvaluatedKeywordPath

```csharp
void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The message provider for generating evaluation messages. |
| `keywordPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path provider for the keyword being evaluated. |

### IgnoredKeyword

```csharp
void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Records that a keyword was ignored during schema evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The encoded keyword that was ignored. |

### IgnoredKeyword

```csharp
void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records that a keyword was ignored during schema evaluation with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was ignored. |

### PopChildContext

```csharp
void PopChildContext(ref JsonSchemaContext childContext)
```

Pops the most recently pushed child context without committing changes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |

### HasLocalEvaluatedItem

```csharp
bool HasLocalEvaluatedItem(int index)
```

Determines whether a specific item at the given index has been locally evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the item at the specified index has been locally evaluated; otherwise, `false`.

### HasLocalEvaluatedProperty

```csharp
bool HasLocalEvaluatedProperty(int index)
```

Determines whether a specific property at the given index has been locally evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property at the specified index has been locally evaluated; otherwise, `false`.

### HasLocalOrAppliedEvaluatedItem

```csharp
bool HasLocalOrAppliedEvaluatedItem(int index)
```

Determines whether a specific item at the given index has been either locally or applied evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the item at the specified index has been locally or applied evaluated; otherwise, `false`.

### HasLocalOrAppliedEvaluatedProperty

```csharp
bool HasLocalOrAppliedEvaluatedProperty(int index)
```

Determines whether a specific property at the given index has been either locally or applied evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property at the specified index has been locally or applied evaluated; otherwise, `false`.

### ApplyEvaluated

```csharp
void ApplyEvaluated(ref JsonSchemaContext childContext)
```

Applies the evaluated properties/items from the child context to this (parent) context, if appropriate.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The child context from which to apply evaluated properties/items |

### Dispose

```csharp
void Dispose()
```

### AddLocalEvaluatedItem

```csharp
void AddLocalEvaluatedItem(int index)
```

Adds an item at the specified index to the local evaluated items collection.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item to mark as locally evaluated. |

### AddLocalEvaluatedProperty

```csharp
void AddLocalEvaluatedProperty(int index)
```

Adds a property at the specified index to the local evaluated properties collection.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property to mark as locally evaluated. |


### JsonSchemaContext.EvaluatedIndexBuffer (struct)

```csharp
public readonly struct JsonSchemaContext.EvaluatedIndexBuffer
```

---

