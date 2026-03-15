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

### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

Begin a child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path taken through the schema(s). *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path. *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path in the JSON document instance. *(optional)* |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html). In DEBUG builds, the sequence number returned by the call to [`BeginChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) is passed to the commit or pop methods and validated to ensure that completion operations are carried out in the expected order.

### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `escapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The escaped name of the property for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html).

### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, int itemIndex, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for an item evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html).

### BeginChildContext `abstract`

```csharp
int BeginChildContext<TProviderContext>(int parentSequenceNumber, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> reducedEvaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

Begin a child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `providerContext` | `TProviderContext` | The context to be passed to the path provider. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path taken through the schema(s) at which the child context is being evaluated. |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path. |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path in the JSON document instance at which the child context is being evaluated. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html). A child context operates like a stack. You *must* pop/commit child contexts in *reverse order* of that in which you Begin() a child context. The sequence number returned by [`BeginChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) and passed in to [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) is used to enforce this

### BeginChildContextUnescaped `abstract`

```csharp
int BeginChildContextUnescaped(int parentSequenceNumber, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the parent context. |
| `unescapedPropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `reducedEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The schema evaluation path of the target schema. *(optional)* |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html) or abandoned with [`PopChildContext`](/api/corvus-text-json-ijsonschemaresultscollector.html).

### CommitChildContext `abstract`

```csharp
void CommitChildContext(int sequenceNumber, bool parentIsMatch, bool childIsMatch, JsonSchemaMessageProvider messageProvider)
```

Commits the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |
| `parentIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the commit indicates that the child produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON validation message. |

This allows the collector to update the match state, and commit any resources associated with the child context.

### CommitChildContext `abstract`

```csharp
void CommitChildContext<TProviderContext>(int sequenceNumber, bool parentIsMatch, bool childIsMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Commits the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |
| `parentIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the commit indicates that the child produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

This allows the collector to update the match state, and commit any resources associated with the child context.

### EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider messageProvider)
```

Indicates that a boolean schema was evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

This is used when evaluating a schema of the form `true` or `false`.

### EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Indicates that a boolean schema was evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

This is used when evaluating a schema of the form `true` or `false`.

### EvaluatedKeyword `abstract`

```csharp
void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

### EvaluatedKeyword `abstract`

```csharp
void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

### EvaluatedKeywordForProperty `abstract`

```csharp
void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given keyword evaluated against the given property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

### EvaluatedKeywordForProperty `abstract`

```csharp
void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given keyword evaluated against the given property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

### EvaluatedKeywordPath `abstract`

```csharp
void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The keyword and its sub-path that was evaluated. |

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

### EvaluatedKeywordPath `abstract`

```csharp
void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The keyword and its sub-path that was evaluated. |

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

### IgnoredKeyword `abstract`

```csharp
void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that is ignored. |

### IgnoredKeyword `abstract`

```csharp
void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that is ignored. |

### PopChildContext `abstract`

```csharp
void PopChildContext(int sequenceNumber)
```

Abandons the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |

This will not update the match state, and allows the collector to release any resources associated with the child context.

