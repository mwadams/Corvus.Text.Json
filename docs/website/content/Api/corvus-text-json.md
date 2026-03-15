---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json Namespace"
---
# Corvus.Text.Json Namespace

| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator<TItem>](#arrayenumerator-titem) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [IByteBufferWriter](#ibytebufferwriter) | interface |  |
| [IJsonSchemaResultsCollector](#ijsonschemaresultscollector) | interface | Implemented by types that accumulate the results of a JSON Schema evaluation. |
| [JsonCommentHandling](#jsoncommenthandling) | enum | This enum defines the various ways the [`Utf8JsonReader`](#Utf8JsonReader) can deal with comments. |
| [JsonDocumentBuilder<T>](#jsondocumentbuilder-t) | class | A mutable JSON document builder that provides functionality to construct and modify JSON documents. |
| [JsonDocumentOptions](#jsondocumentoptions) | struct | Provides the ability for the user to define custom behavior when parsing JSON to create a [`JsonDocument`](#JsonDocument). |
| [JsonElement](#jsonelement) | struct | Represents a specific JSON value within a [`JsonDocument`](#JsonDocument). |
| [JsonElementExtensions](#jsonelementextensions) | class | Extension methods for [`IJsonElement`](#IJsonElement). |
| [JsonElementForBooleanFalseSchema](#jsonelementforbooleanfalseschema) | struct | Represents a specific JSON value within a [`JsonDocument`](#JsonDocument). |
| [JsonEncodedText](#jsonencodedtext) | struct | Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON. |
| [JsonException](#jsonexception) | class | Represents errors that occur during JSON parsing, reading, or writing operations. This exception is thrown when invalid JSON text is encountered, when the defined maximum depth is exceeded, or when... |
| [JsonPredicate<T>](#jsonpredicate-t) | delegate | A predicate for a JSON value. |
| [JsonProperty<TValue>](#jsonproperty-tvalue) | struct | Represents a single property for a JSON object. |
| [JsonReaderOptions](#jsonreaderoptions) | struct | Provides the ability for the user to define custom behavior when reading JSON. |
| [JsonReaderState](#jsonreaderstate) | struct | Defines an opaque type that holds and saves all the relevant state information which must be provided to the [`Utf8JsonReader`](#Utf8JsonReader) to continue reading after processing incomplete data... |
| [JsonSchemaMessageProvider](#jsonschemamessageprovider) | delegate | Provides a message for a JSON Schema validation result. |
| [JsonSchemaMessageProvider<TContext>](#jsonschemamessageprovider-tcontext) | delegate | Provides a message for a JSON Schema validation result, using a context value. |
| [JsonSchemaPathProvider](#jsonschemapathprovider) | delegate | Provides a path segment for a JSON Schema location or instance path. |
| [JsonSchemaPathProvider<TContext>](#jsonschemapathprovider-tcontext) | delegate | Provides a path segment for a JSON Schema location or instance path, using a context value. |
| [JsonSchemaResultsCollector](#jsonschemaresultscollector) | class | Collects and manages results from JSON schema validation operations with high-performance memory management, stack-based evaluation tracking, and configurable verbosity levels. |
| [JsonSchemaResultsLevel](#jsonschemaresultslevel) | enum | The level of result to collect for an [`IJsonSchemaResultsCollector`](#IJsonSchemaResultsCollector). |
| [JsonValueKind](#jsonvaluekind) | enum | Specifies the data type of a JSON value. |
| [JsonWorkspace](#jsonworkspace) | class | A workspace for manipulating JSON documents. |
| [JsonWriterOptions](#jsonwriteroptions) | struct | Provides the ability for the user to define custom behavior when writing JSON using the [`Utf8JsonWriter`](#Utf8JsonWriter). By default, the JSON is written without any indentation or extra white s... |
| [Matcher<TMatch, TContext, TResult>](#matcher-tmatch,-tcontext,-tresult) | delegate | A callback for a pattern match method. |
| [Matcher<TMatch, TOut>](#matcher-tmatch,-tout) | delegate | A callback for a pattern match method. |
| [ObjectEnumerator<TValue>](#objectenumerator-tvalue) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [ParsedJsonDocument<T>](#parsedjsondocument-t) | class | Represents the structure of a JSON value in a lightweight, read-only form. |
| [Period](#period) | struct | Represents a period of time expressed in human chronological terms: hours, days, weeks, months and so on. |
| [PeriodBuilder](#periodbuilder) | struct | A mutable builder class for [`Period`](#Period) values. Each property can be set independently, and then a Period can be created from the result using the [`BuildPeriod`](#BuildPeriod) method. |
| [RawUtf8JsonString](#rawutf8jsonstring) | struct | Represents a raw UTF-8 JSON string. |
| [UnescapedUtf16JsonString](#unescapedutf16jsonstring) | struct | Represents an Unescaped UTF-16 JSON string. |
| [UnescapedUtf8JsonString](#unescapedutf8jsonstring) | struct | Represents an Unescaped UTF-8 JSON string. |
| [Utf8Iri](#utf8iri) | struct | A UTF-8 IRI. |
| [Utf8IriReference](#utf8irireference) | struct | A UTF-8 IRI Reference. |
| [Utf8IriReferenceValue](#utf8irireferencevalue) | struct | A UTF-8 IRI reference value that has been parsed from a JSON document. |
| [Utf8IriValue](#utf8irivalue) | struct | A UTF-8 IRI value that has been parsed from a JSON document. |
| [Utf8JsonPointer](#utf8jsonpointer) | struct |  |
| [Utf8JsonReader](#utf8jsonreader) | struct | Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default... |
| [Utf8JsonWriter](#utf8jsonwriter) | class | Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text. |
| [Utf8Uri](#utf8uri) | struct | A UTF-8 URI. |
| [Utf8UriReference](#utf8urireference) | struct | A UTF-8 URI Reference. |
| [Utf8UriReferenceValue](#utf8urireferencevalue) | struct | A UTF-8 URI reference value that has been parsed from a JSON document. |
| [Utf8UriValue](#utf8urivalue) | struct | A UTF-8 URI value that has been parsed from a JSON document. |

## ArrayEnumerator<TItem> (struct)

```csharp
public readonly struct ArrayEnumerator<TItem> : IEnumerable<TItem>, IEnumerable, IEnumerator<TItem>, IEnumerator, IDisposable
```

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TItem` | The type of the JSON element to enumerate, which must implement [`IJsonElement`](#IJsonElement). |

### Inheritance

- Implements: `IEnumerable<TItem>`
- Implements: `IEnumerable`
- Implements: `IEnumerator<TItem>`
- Implements: `IEnumerator`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Current` | `TItem` | Gets the current element in the collection. |

### Methods

#### GetEnumerator

```csharp
ArrayEnumerator<TItem> GetEnumerator()
```

Returns an enumerator that iterates through the JSON array.

**Returns:** `ArrayEnumerator<TItem>`

An [`ArrayEnumerator`](#ArrayEnumerator) value that can be used to iterate through the array.

#### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

#### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element in the collection.

#### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** `bool`

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

---

## IByteBufferWriter (interface)

```csharp
public interface IByteBufferWriter : IBufferWriter<byte>, IDisposable
```

### Inheritance

- Implements: `IBufferWriter<byte>`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Capacity` | `int` |  |
| `WrittenMemory` | `ReadOnlyMemory<byte>` |  |
| `WrittenSpan` | `ReadOnlySpan<byte>` |  |

### Methods

#### ClearAndReturnBuffers `abstract`

```csharp
void ClearAndReturnBuffers()
```

---

## IJsonSchemaResultsCollector (interface)

```csharp
public interface IJsonSchemaResultsCollector : IDisposable
```

Implemented by types that accumulate the results of a JSON Schema evaluation.

### Inheritance

- Implements: `IDisposable`

### Methods

#### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

Begin a child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | `int` | The sequence number of the parent context. |
| `reducedEvaluationPath` | `JsonSchemaPathProvider` | The path taken through the schema(s). *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | The schema evaluation path. *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider` | The path in the JSON document instance. *(optional)* |

**Returns:** `int`

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](#CommitChildContext) or abandoned with [`PopChildContext`](#PopChildContext). In DEBUG builds, the sequence number returned by the call to [`BeginChildContext`](#BeginChildContext) is passed to the commit or pop methods and validated to ensure that completion operations are carried out in the expected order.

#### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | `int` | The sequence number of the parent context. |
| `escapedPropertyName` | `ReadOnlySpan<byte>` | The escaped name of the property for which to begin a child context. |
| `reducedEvaluationPath` | `JsonSchemaPathProvider` | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | The schema evaluation path of the target schema. *(optional)* |

**Returns:** `int`

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](#CommitChildContext) or abandoned with [`PopChildContext`](#PopChildContext).

#### BeginChildContext `abstract`

```csharp
int BeginChildContext(int parentSequenceNumber, int itemIndex, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for an item evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | `int` | The sequence number of the parent context. |
| `itemIndex` | `int` | The index of the item for which to begin a child context. |
| `reducedEvaluationPath` | `JsonSchemaPathProvider` | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | The schema evaluation path of the target schema. *(optional)* |

**Returns:** `int`

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](#CommitChildContext) or abandoned with [`PopChildContext`](#PopChildContext).

#### BeginChildContext `abstract`

```csharp
int BeginChildContext<TProviderContext>(int parentSequenceNumber, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> reducedEvaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

Begin a child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | `int` | The sequence number of the parent context. |
| `providerContext` | `TProviderContext` | The context to be passed to the path provider. |
| `reducedEvaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | The path taken through the schema(s) at which the child context is being evaluated. |
| `schemaEvaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | The schema evaluation path. |
| `documentEvaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | The path in the JSON document instance at which the child context is being evaluated. |

**Returns:** `int`

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](#CommitChildContext) or abandoned with [`PopChildContext`](#PopChildContext). A child context operates like a stack. You *must* pop/commit child contexts in *reverse order* of that in which you Begin() a child context. The sequence number returned by [`BeginChildContext`](#BeginChildContext) and passed in to [`CommitChildContext`](#CommitChildContext) or [`PopChildContext`](#PopChildContext) is used to enforce this

#### BeginChildContextUnescaped `abstract`

```csharp
int BeginChildContextUnescaped(int parentSequenceNumber, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Begin a child context for a property evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentSequenceNumber` | `int` | The sequence number of the parent context. |
| `unescapedPropertyName` | `ReadOnlySpan<byte>` | The name of the property for which to begin a child context. |
| `reducedEvaluationPath` | `JsonSchemaPathProvider` | The fully reduced evaluation path for the keyword. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | The schema evaluation path of the target schema. *(optional)* |

**Returns:** `int`

The sequence number of the child context.

Begins evaluation of a schema in a child context. The context may later be committed with [`CommitChildContext`](#CommitChildContext) or abandoned with [`PopChildContext`](#PopChildContext).

#### CommitChildContext `abstract`

```csharp
void CommitChildContext(int sequenceNumber, bool parentIsMatch, bool childIsMatch, JsonSchemaMessageProvider messageProvider)
```

Commits the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | `int` | The sequence number of the child context to commit. |
| `parentIsMatch` | `bool` | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | `bool` | If `true` then the commit indicates that the child produced a successful match. |
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON validation message. |

This allows the collector to update the match state, and commit any resources associated with the child context.

#### CommitChildContext `abstract`

```csharp
void CommitChildContext<TProviderContext>(int sequenceNumber, bool parentIsMatch, bool childIsMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Commits the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | `int` | The sequence number of the child context to commit. |
| `parentIsMatch` | `bool` | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | `bool` | If `true` then the commit indicates that the child produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |

This allows the collector to update the match state, and commit any resources associated with the child context.

#### EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider messageProvider)
```

Indicates that a boolean schema was evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON schema evaluation message. |

This is used when evaluating a schema of the form `true` or `false`.

#### EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Indicates that a boolean schema was evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |

This is used when evaluating a schema of the form `true` or `false`.

#### EvaluatedKeyword `abstract`

```csharp
void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that was evaluated. |

#### EvaluatedKeyword `abstract`

```csharp
void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that was evaluated. |

#### EvaluatedKeywordForProperty `abstract`

```csharp
void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given keyword evaluated against the given property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property for which to begin a child context. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that was evaluated. |

#### EvaluatedKeywordForProperty `abstract`

```csharp
void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

Updates the match state for the given keyword evaluated against the given property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property for which to begin a child context. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that was evaluated. |

#### EvaluatedKeywordPath `abstract`

```csharp
void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | `JsonSchemaPathProvider` | The keyword and its sub-path that was evaluated. |

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

#### EvaluatedKeywordPath `abstract`

```csharp
void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | `JsonSchemaPathProvider<TProviderContext>` | The keyword and its sub-path that was evaluated. |

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

#### IgnoredKeyword `abstract`

```csharp
void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | `JsonSchemaMessageProvider` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that is ignored. |

#### IgnoredKeyword `abstract`

```csharp
void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The keyword that is ignored. |

#### PopChildContext `abstract`

```csharp
void PopChildContext(int sequenceNumber)
```

Abandons the last child context.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | `int` | The sequence number of the child context to commit. |

This will not update the match state, and allows the collector to release any resources associated with the child context.

---

## JsonCommentHandling (enum)

```csharp
public enum JsonCommentHandling : IComparable, ISpanFormattable, IFormattable, IConvertible
```

This enum defines the various ways the [`Utf8JsonReader`](#Utf8JsonReader) can deal with comments.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Disallow` `static` | `JsonCommentHandling` | By default, do no allow comments within the JSON input. Comments are treated as invalid JSON if found and a [`JsonException`](#JsonException) is thrown. |
| `Skip` `static` | `JsonCommentHandling` | Allow comments within the JSON input and ignore them. The [`Utf8JsonReader`](#Utf8JsonReader) will behave as if no comments were present. |
| `Allow` `static` | `JsonCommentHandling` | Allow comments within the JSON input and treat them as valid tokens. While reading, the caller will be able to access the comment values. |

---

## JsonDocumentBuilder<T> (class)

```csharp
public sealed class JsonDocumentBuilder<T> : JsonDocument, IMutableJsonDocument, IJsonDocument, IDisposable
```

A mutable JSON document builder that provides functionality to construct and modify JSON documents.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of mutable JSON element this builder works with. |

### Inheritance

- Inherits from: `JsonDocument`
- Implements: `IMutableJsonDocument`
- Implements: `IJsonDocument`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` | Gets the root element of the JSON document. |

#### RootElement

```csharp
T RootElement { get; }
```

Gets the root element of the JSON document.

**Value:** The mutable root element of the document.

### Methods

#### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the document into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` |  |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | The `writer` parameter is `null`. |
| `System.InvalidOperationException` | This [`RootElement`](#RootElement)'s [`ValueKind`](#ValueKind) would result in an invalid JSON. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### Dispose

```csharp
void Dispose()
```

---

## JsonDocumentOptions (struct)

```csharp
public readonly struct JsonDocumentOptions
```

Provides the ability for the user to define custom behavior when parsing JSON to create a [`JsonDocument`](#JsonDocument).

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `AllowTrailingCommas` | `bool` | Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read. |
| `CommentHandling` | `JsonCommentHandling` | Defines how the [`Utf8JsonReader`](#Utf8JsonReader) should handle comments when reading through the JSON. |
| `MaxDepth` | `int` | Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64. |

#### AllowTrailingCommas

```csharp
bool AllowTrailingCommas { get; set; }
```

Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read.

By default, it's set to false, and is thrown if a trailing comma is encountered.

#### CommentHandling

```csharp
JsonCommentHandling CommentHandling { get; set; }
```

Defines how the [`Utf8JsonReader`](#Utf8JsonReader) should handle comments when reading through the JSON.

By default is thrown if a comment is encountered.

#### MaxDepth

```csharp
int MaxDepth { get; set; }
```

Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64.

Reading past this depth will throw a .

---

## JsonElement (struct)

```csharp
public readonly struct JsonElement : IJsonElement<JsonElement>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

Represents a specific JSON value within a [`JsonDocument`](#JsonDocument).

### Inheritance

- Implements: `IJsonElement<JsonElement>`
- Implements: `IJsonElement`
- Implements: `IFormattable`
- Implements: `ISpanFormattable`
- Implements: `IUtf8SpanFormattable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | `JsonValueKind` | The [`JsonValueKind`](#JsonValueKind) that the value is. |
| `Item` | `JsonElement` |  |
| `Item` | `JsonElement` |  |
| `Item` | `JsonElement` |  |
| `Item` | `JsonElement` |  |

### Methods

#### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

#### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> builder, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` |  |
| `context` | `ref TContext` |  |
| `builder` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

#### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> builder, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` |  |
| `context` | `ref TContext` |  |
| `builder` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

#### CreateArrayBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateArrayBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

Creates an empty mutable array document builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | `int` | The estimated number of members in the document. *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

A JSON document builder containing an empty array.

#### CreateObjectBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateObjectBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

Creates an empty mutable object document builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | `int` | The estimated number of members in the document. *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

A JSON document builder containing an empty object.

#### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the JSON Schema for this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | `IJsonSchemaResultsCollector` | The (optional) results collector for schema validation. *(optional)* |

**Returns:** `bool`

`true` if the element is valid according to its schema; otherwise, `false`.

#### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether the specified object is equal to the current JsonElement.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` | The object to compare with the current JsonElement. |

**Returns:** `bool`

`true` if the specified object is equal to the current JsonElement; otherwise, `false`.

#### Equals

```csharp
bool Equals<T>(T other)
```

Determines whether the current JsonElement is equal to another JsonElement-like value through deep comparison.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the other JSON element that implements IJsonElement. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` | The JSON element to compare with this JsonElement. |

**Returns:** `bool`

`true` if the current JsonElement is equal to the other parameter; otherwise, `false`.

#### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace)
```

Creates a mutable document builder from this JsonElement using the specified workspace.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` | The JsonWorkspace to use for creating the document builder. |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

A JsonDocumentBuilder configured for mutable operations on this JsonElement.

#### From `static`

```csharp
JsonElement From<T>(ref T instance)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` |  |

**Returns:** `JsonElement`

#### GetArrayLength

```csharp
int GetArrayLength()
```

Get the number of values contained within the current array value.

**Returns:** `int`

The number of values contained within the current array value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Array`](#Array). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### GetPropertyCount

```csharp
int GetPropertyCount()
```

Get the number of properties contained within the current object value.

**Returns:** `int`

The number of properties contained within the current object value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### GetProperty

```csharp
JsonElement GetProperty(string propertyName)
```

Gets a [`JsonElement`](#JsonElement) representing the value of a required property identified by `propertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | Name of the property whose value to return. |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.Collections.Generic.KeyNotFoundException` | No property was found with the requested name. |
| `System.ArgumentNullException` | `propertyName` is `null`. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### GetProperty

```csharp
JsonElement GetProperty(ReadOnlySpan<char> propertyName)
```

Gets a [`JsonElement`](#JsonElement) representing the value of a required property identified by `propertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | Name of the property whose value to return. |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.Collections.Generic.KeyNotFoundException` | No property was found with the requested name. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### GetProperty

```csharp
JsonElement GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

Gets a [`JsonElement`](#JsonElement) representing the value of a required property identified by `utf8PropertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.Collections.Generic.KeyNotFoundException` | No property was found with the requested name. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### TryGetProperty

```csharp
bool TryGetProperty(string propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | Name of the property to find. |
| `value` | `ref JsonElement` | Receives the value of the located property. |

**Returns:** `bool`

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.ArgumentNullException` | `propertyName` is `null`. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | Name of the property to find. |
| `value` | `ref JsonElement` | Receives the value of the located property. |

**Returns:** `bool`

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement value)
```

Looks for a property named `utf8PropertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |
| `value` | `ref JsonElement` | Receives the value of the located property. |

**Returns:** `bool`

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

#### TryGetBoolean

```csharp
bool TryGetBoolean(ref bool value)
```

Tries to get the value as a boolean

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref bool` | Provides the boolean value if successful. |

**Returns:** `bool`

`true` if the value was a boolean, otherwise false.

#### GetBoolean

```csharp
bool GetBoolean()
```

Gets the value of the element as a [`Boolean`](#Boolean).

**Returns:** `bool`

The value of the element as a [`Boolean`](#Boolean).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is neither [`True`](#True) or [`False`](#False). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetString

```csharp
string GetString()
```

Gets the value of the element as a [`String`](#String).

**Returns:** `string`

The value of the element as a [`String`](#String).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is neither [`String`](#String) nor [`Null`](#Null). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a string representation of values other than JSON strings.

#### GetUtf8String

```csharp
UnescapedUtf8JsonString GetUtf8String()
```

Gets the value of the element as a [`UnescapedUtf8JsonString`](#UnescapedUtf8JsonString).

**Returns:** `UnescapedUtf8JsonString`

The value of the element as an [`UnescapedUtf8JsonString`](#UnescapedUtf8JsonString).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is neither [`String`](#String) nor [`Null`](#Null). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

The [`UnescapedUtf8JsonString`](#UnescapedUtf8JsonString) should be disposed when it is finished with, as it may have rented storage to provide the unescaped value. It is only valid for as long as the source [`JsonElement`](#JsonElement) is valid.

#### GetUtf16String

```csharp
UnescapedUtf16JsonString GetUtf16String()
```

Gets the value of the element as a [`UnescapedUtf16JsonString`](#UnescapedUtf16JsonString).

**Returns:** `UnescapedUtf16JsonString`

The value of the element as an [`UnescapedUtf16JsonString`](#UnescapedUtf16JsonString).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is neither [`String`](#String) nor [`Null`](#Null). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

The [`UnescapedUtf16JsonString`](#UnescapedUtf16JsonString) should be disposed when it is finished with, as it may have rented storage to provide the unescaped value. It is only valid for as long as the source [`JsonElement`](#JsonElement) is valid.

#### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

Attempts to represent the current JSON string as bytes assuming it is Base64 encoded.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte[]` | Receives the value. |

**Returns:** `bool`

`true` if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes. `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a byte[] representation of values other than base 64 encoded JSON strings.

#### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

Gets the value of the element as bytes.

**Returns:** `byte[]`

The value decode to bytes.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value is not encoded as Base64 text and hence cannot be decoded to bytes. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a byte[] representation of values other than Base64 encoded JSON strings.

#### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

Attempts to represent the current JSON number as an [`SByte`](#SByte).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref sbyte` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as an [`SByte`](#SByte), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetSByte

```csharp
sbyte GetSByte()
```

Gets the current JSON number as an [`SByte`](#SByte).

**Returns:** `sbyte`

The current JSON number as an [`SByte`](#SByte).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as an [`SByte`](#SByte). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

Attempts to represent the current JSON number as a [`Byte`](#Byte).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`Byte`](#Byte), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetByte

```csharp
byte GetByte()
```

Gets the current JSON number as a [`Byte`](#Byte).

**Returns:** `byte`

The current JSON number as a [`Byte`](#Byte).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`Byte`](#Byte). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

Attempts to represent the current JSON number as an [`Int16`](#Int16).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref short` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as an [`Int16`](#Int16), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetInt16

```csharp
short GetInt16()
```

Gets the current JSON number as an [`Int16`](#Int16).

**Returns:** `short`

The current JSON number as an [`Int16`](#Int16).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as an [`Int16`](#Int16). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

Attempts to represent the current JSON number as a [`UInt16`](#UInt16).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ushort` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`UInt16`](#UInt16), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetUInt16

```csharp
ushort GetUInt16()
```

Gets the current JSON number as a [`UInt16`](#UInt16).

**Returns:** `ushort`

The current JSON number as a [`UInt16`](#UInt16).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`UInt16`](#UInt16). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

Attempts to represent the current JSON number as an [`Int32`](#Int32).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref int` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as an [`Int32`](#Int32), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetInt32

```csharp
int GetInt32()
```

Gets the current JSON number as an [`Int32`](#Int32).

**Returns:** `int`

The current JSON number as an [`Int32`](#Int32).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as an [`Int32`](#Int32). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

Attempts to represent the current JSON number as a [`UInt32`](#UInt32).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref uint` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`UInt32`](#UInt32), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetUInt32

```csharp
uint GetUInt32()
```

Gets the current JSON number as a [`UInt32`](#UInt32).

**Returns:** `uint`

The current JSON number as a [`UInt32`](#UInt32).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`UInt32`](#UInt32). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

Attempts to represent the current JSON number as a [`Int64`](#Int64).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref long` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`Int64`](#Int64), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetInt64

```csharp
long GetInt64()
```

Gets the current JSON number as a [`Int64`](#Int64).

**Returns:** `long`

The current JSON number as a [`Int64`](#Int64).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`Int64`](#Int64). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

Attempts to represent the current JSON number as a [`UInt64`](#UInt64).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ulong` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`UInt64`](#UInt64), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetUInt64

```csharp
ulong GetUInt64()
```

Gets the current JSON number as a [`UInt64`](#UInt64).

**Returns:** `ulong`

The current JSON number as a [`UInt64`](#UInt64).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`UInt64`](#UInt64). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

Attempts to represent the current JSON number as a [`Double`](#Double).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref double` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`Double`](#Double), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than [`MaxValue`](#MaxValue) (or smaller than [`MinValue`](#MinValue)), instead `true` is returned and [`PositiveInfinity`](#PositiveInfinity) (or [`NegativeInfinity`](#NegativeInfinity)) is emitted.

#### GetDouble

```csharp
double GetDouble()
```

Gets the current JSON number as a [`Double`](#Double).

**Returns:** `double`

The current JSON number as a [`Double`](#Double).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`Double`](#Double). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method returns [`PositiveInfinity`](#PositiveInfinity) (or [`NegativeInfinity`](#NegativeInfinity)) for values larger than [`MaxValue`](#MaxValue) (or smaller than [`MinValue`](#MinValue)).

#### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

Attempts to represent the current JSON number as a [`Single`](#Single).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref float` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`Single`](#Single), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than [`MaxValue`](#MaxValue) (or smaller than [`MinValue`](#MinValue)), instead `true` is returned and [`PositiveInfinity`](#PositiveInfinity) (or [`NegativeInfinity`](#NegativeInfinity)) is emitted.

#### GetSingle

```csharp
float GetSingle()
```

Gets the current JSON number as a [`Single`](#Single).

**Returns:** `float`

The current JSON number as a [`Single`](#Single).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`Single`](#Single). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method returns [`PositiveInfinity`](#PositiveInfinity) (or [`NegativeInfinity`](#NegativeInfinity)) for values larger than [`MaxValue`](#MaxValue) (or smaller than [`MinValue`](#MinValue)).

#### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

Attempts to represent the current JSON number as a [`Decimal`](#Decimal).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref decimal` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`Decimal`](#Decimal), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetDecimal

```csharp
decimal GetDecimal()
```

Gets the current JSON number as a [`Decimal`](#Decimal).

**Returns:** `decimal`

The current JSON number as a [`Decimal`](#Decimal).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`Decimal`](#Decimal). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetBigNumber

```csharp
bool TryGetBigNumber(ref BigNumber value)
```

Attempts to represent the current JSON number as a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigNumber` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`BigNumber`](#BigNumber), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetBigNumber

```csharp
BigNumber GetBigNumber()
```

Gets the current JSON number as a [`BigNumber`](#BigNumber).

**Returns:** `BigNumber`

The current JSON number as a [`BigNumber`](#BigNumber).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`BigNumber`](#BigNumber). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetBigInteger

```csharp
bool TryGetBigInteger(ref BigInteger value)
```

Attempts to represent the current JSON number as a [`BigInteger`](#BigInteger).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` | Receives the value. |

**Returns:** `bool`

`true` if the number can be represented as a [`BigInteger`](#BigInteger), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### GetBigInteger

```csharp
BigInteger GetBigInteger()
```

Gets the current JSON number as a [`BigInteger`](#BigInteger).

**Returns:** `BigInteger`

The current JSON number as a [`BigInteger`](#BigInteger).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Number`](#Number). |
| `System.FormatException` | The value cannot be represented as a [`BigInteger`](#BigInteger). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not parse the contents of a JSON string value.

#### TryGetLocalDate

```csharp
bool TryGetLocalDate(ref LocalDate value)
```

Attempts to represent the current JSON string as a [`LocalDate`](#LocalDate).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`LocalDate`](#LocalDate), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a LocalDate representation of values other than JSON strings.

#### GetLocalDate

```csharp
LocalDate GetLocalDate()
```

Gets the value of the element as a [`LocalDate`](#LocalDate).

**Returns:** `LocalDate`

The value of the element as a [`LocalDate`](#LocalDate).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a LocalDate representation of values other than JSON strings.

#### TryGetOffsetTime

```csharp
bool TryGetOffsetTime(ref OffsetTime value)
```

Attempts to represent the current JSON string as a [`OffsetTime`](#OffsetTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`OffsetTime`](#OffsetTime), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetTime representation of values other than JSON strings.

#### GetOffsetTime

```csharp
OffsetTime GetOffsetTime()
```

Gets the value of the element as a [`OffsetTime`](#OffsetTime).

**Returns:** `OffsetTime`

The value of the element as a [`OffsetTime`](#OffsetTime).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetTime representation of values other than JSON strings.

#### TryGetOffsetDateTime

```csharp
bool TryGetOffsetDateTime(ref OffsetDateTime value)
```

Attempts to represent the current JSON string as a [`OffsetDateTime`](#OffsetDateTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`OffsetDateTime`](#OffsetDateTime), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetDateTime representation of values other than JSON strings.

#### TryGetOffsetDate

```csharp
bool TryGetOffsetDate(ref OffsetDate value)
```

Attempts to represent the current JSON string as a [`OffsetDate`](#OffsetDate).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`OffsetDate`](#OffsetDate), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetDate representation of values other than JSON strings.

#### GetOffsetDate

```csharp
OffsetDate GetOffsetDate()
```

Gets the value of the element as a [`OffsetDate`](#OffsetDate).

**Returns:** `OffsetDate`

The value of the element as a [`OffsetDate`](#OffsetDate).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetDate representation of values other than JSON strings.

#### GetOffsetDateTime

```csharp
OffsetDateTime GetOffsetDateTime()
```

Gets the value of the element as a [`OffsetDateTime`](#OffsetDateTime).

**Returns:** `OffsetDateTime`

The value of the element as a [`OffsetDateTime`](#OffsetDateTime).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a OffsetDateTime representation of values other than JSON strings.

#### TryGetPeriod

```csharp
bool TryGetPeriod(ref Period value)
```

Attempts to represent the current JSON string as a [`Period`](#Period).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`Period`](#Period), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a Period representation of values other than JSON strings.

#### GetPeriod

```csharp
Period GetPeriod()
```

Gets the value of the element as a [`Period`](#Period).

**Returns:** `Period`

The value of the element as a [`Period`](#Period).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a Period representation of values other than JSON strings.

#### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

Attempts to represent the current JSON string as a [`DateTime`](#DateTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`DateTime`](#DateTime), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a DateTime representation of values other than JSON strings.

#### GetDateTime

```csharp
DateTime GetDateTime()
```

Gets the value of the element as a [`DateTime`](#DateTime).

**Returns:** `DateTime`

The value of the element as a [`DateTime`](#DateTime).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTime`](#DateTime). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a DateTime representation of values other than JSON strings.

#### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

Attempts to represent the current JSON string as a [`DateTimeOffset`](#DateTimeOffset).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`DateTimeOffset`](#DateTimeOffset), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a DateTimeOffset representation of values other than JSON strings.

#### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

Gets the value of the element as a [`DateTimeOffset`](#DateTimeOffset).

**Returns:** `DateTimeOffset`

The value of the element as a [`DateTimeOffset`](#DateTimeOffset).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`DateTimeOffset`](#DateTimeOffset). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a DateTimeOffset representation of values other than JSON strings.

#### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

Attempts to represent the current JSON string as a [`Guid`](#Guid).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Guid` | Receives the value. |

**Returns:** `bool`

`true` if the string can be represented as a [`Guid`](#Guid), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a Guid representation of values other than JSON strings.

#### GetGuid

```csharp
Guid GetGuid()
```

Gets the value of the element as a [`Guid`](#Guid).

**Returns:** `Guid`

The value of the element as a [`Guid`](#Guid).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |
| `System.FormatException` | The value cannot be represented as a [`Guid`](#Guid). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

This method does not create a Guid representation of values other than JSON strings.

#### GetRawText

```csharp
string GetRawText()
```

Gets the original input data backing this value, returning it as a [`String`](#String).

**Returns:** `string`

The original input data backing this value, returning it as a [`String`](#String).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

Note that this method allocates.

#### EnsurePropertyMap

```csharp
void EnsurePropertyMap()
```

Ensures that a fast-lookup property map is created for this element.

This enables dictionary-based lookup of property values in the element. If the cost of lookups exceeds the cost of building the map, this can provide substantial performance improvements. It is a zero-allocation operation.

#### ValueEquals

```csharp
bool ValueEquals(string text)
```

Compares `text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `string` | The text to compare against. |

**Returns:** `bool`

`true` if the string value of this element matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](#GetString), but avoids creating the string instance.

#### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text to compare against. |

**Returns:** `bool`

`true` if the string value of this element has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |

This method is functionally equal to doing an ordinal comparison of the string produced by UTF-8 decoding `utf8Text` with the result of calling [`GetString`](#GetString), but avoids creating the string instances.

#### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<char> text)
```

Compares `text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<char>` | The text to compare against. |

**Returns:** `bool`

`true` if the string value of this element matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`String`](#String). |

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](#GetString), but avoids creating the string instance.

#### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the element into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | The `writer` parameter is `null`. |
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is [`Undefined`](#Undefined). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### EnumerateArray

```csharp
ArrayEnumerator<JsonElement> EnumerateArray()
```

Get an enumerator to enumerate the values in the JSON array represented by this JsonElement.

**Returns:** `ArrayEnumerator<JsonElement>`

An enumerator to enumerate the values in the JSON array represented by this JsonElement.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Array`](#Array). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### EnumerateObject

```csharp
ObjectEnumerator<JsonElement> EnumerateObject()
```

Get an enumerator to enumerate the properties in the JSON object represented by this JsonElement.

**Returns:** `ObjectEnumerator<JsonElement>`

An enumerator to enumerate the properties in the JSON object represented by this JsonElement.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is not [`Object`](#Object). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### ToString `virtual`

```csharp
string ToString()
```

Gets a string representation for the current value appropriate to the value type.

**Returns:** `string`

A string representation for the current value appropriate to the value type.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

For JsonElement built from [`JsonDocument`](#JsonDocument): For [`Null`](#Null), [`Empty`](#Empty) is returned. For [`True`](#True), [`TrueString`](#TrueString) is returned. For [`False`](#False), [`FalseString`](#FalseString) is returned. For [`String`](#String), the value of [`GetString`](#GetString)() is returned. For other types, the value of [`GetRawText`](#GetRawText)() is returned.

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** `int`

#### Clone

```csharp
JsonElement Clone()
```

Get a JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](#JsonDocument).

**Returns:** `JsonElement`

A JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](#JsonDocument).

If this JsonElement is itself the output of a previous call to Clone, or a value contained within another JsonElement which was the output of a previous call to Clone, this method results in no additional memory allocation.

#### ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `format` | `string` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `string`

#### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormat

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### ParseValue `static`

```csharp
JsonElement ParseValue(ReadOnlySpan<byte> utf8Json, JsonDocumentOptions options)
```

Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlySpan<byte>` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElement ParseValue(ReadOnlySpan<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `ReadOnlySpan<char>` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElement ParseValue(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `string` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElement`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | `json` is `null`. |
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElement ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |

**Returns:** `JsonElement`

A JsonElement representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref Nullable<JsonElement> element)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |
| `element` | `ref Nullable<JsonElement>` | Receives the parsed element. |

**Returns:** `bool`

`true` if a value was read and parsed into a JsonElement; `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset)
```

Tries to get the 1-based line number and character offset of this element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `line` | `ref int` | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | `ref int` | When this method returns, contains the 1-based character offset within the line if successful. |

**Returns:** `bool`

`true` if the line and offset were successfully determined; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

#### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset, ref long lineByteOffset)
```

Tries to get the 1-based line number, character offset, and byte offset of this element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `line` | `ref int` | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | `ref int` | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | `ref long` | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** `bool`

`true` if the line and offset were successfully determined; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

#### TryGetLine

```csharp
bool TryGetLine(int lineNumber, ref ReadOnlyMemory<byte> line)
```

Tries to get the specified line from the original source document as UTF-8 bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | `int` | The 1-based line number to retrieve. |
| `line` | `ref ReadOnlyMemory<byte>` | When this method returns, contains the UTF-8 bytes of the line if successful. |

**Returns:** `bool`

`true` if the line was successfully retrieved; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.

#### TryGetLine

```csharp
bool TryGetLine(int lineNumber, ref string line)
```

Tries to get the specified line from the original source document as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | `int` | The 1-based line number to retrieve. |
| `line` | `ref string` | When this method returns, contains the line text if successful. |

**Returns:** `bool`

`true` if the line was successfully retrieved; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.

### Nested Types

### JsonElement.ArrayBuilder (struct)

```csharp
public readonly struct JsonElement.ArrayBuilder
```

#### Constructors

##### JsonElement.ArrayBuilder

```csharp
JsonElement.ArrayBuilder()
```

#### Methods

##### BuildValue `static`

```csharp
void BuildValue(JsonElement.ArrayBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### BuildValue `static`

```csharp
void BuildValue<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddItem

```csharp
void AddItem(JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |

##### AddItem

```csharp
void AddItem(JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### AddItem

```csharp
void AddItem(string value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` |  |

##### AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` |  |

##### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | `ReadOnlySpan<byte>` |  |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` |  |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` |  |
| `requiresUnescaping` | `bool` |  |

##### AddItemNull

```csharp
void AddItemNull()
```

##### AddItem

```csharp
void AddItem(bool value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `bool` |  |

##### AddItem

```csharp
void AddItem<T>(T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |

##### AddItem

```csharp
void AddItem(Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Guid` |  |

##### AddItem

```csharp
void AddItem(ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` |  |

##### AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` |  |

##### AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` |  |

##### AddItem

```csharp
void AddItem(ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` |  |

##### AddItem

```csharp
void AddItem(ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` |  |

##### AddItem

```csharp
void AddItem(ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` |  |

##### AddItem

```csharp
void AddItem(ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` |  |

##### AddItem

```csharp
void AddItem(sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `sbyte` |  |

##### AddItem

```csharp
void AddItem(byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `byte` |  |

##### AddItem

```csharp
void AddItem(int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |

##### AddItem

```csharp
void AddItem(uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `uint` |  |

##### AddItem

```csharp
void AddItem(long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `long` |  |

##### AddItem

```csharp
void AddItem(ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ulong` |  |

##### AddItem

```csharp
void AddItem(short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `short` |  |

##### AddItem

```csharp
void AddItem(ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ushort` |  |

##### AddItem

```csharp
void AddItem(float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `float` |  |

##### AddItem

```csharp
void AddItem(double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `double` |  |

##### AddItem

```csharp
void AddItem(decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `decimal` |  |

##### AddItem

```csharp
void AddItem(ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` |  |

##### AddItem

```csharp
void AddItem(ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigNumber` |  |

##### AddItem

```csharp
void AddItem(Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Int128` |  |

##### AddItem

```csharp
void AddItem(UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `UInt128` |  |

##### AddItem

```csharp
void AddItem(Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Half` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<long>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<int>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<short>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<sbyte>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<ulong>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<uint>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<ushort>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<byte>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<decimal>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<double>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<float>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<Int128>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<UInt128>` |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<Half>` |  |

#### Nested Types

#### JsonElement.ArrayBuilder.Build (delegate)

```csharp
public delegate JsonElement.ArrayBuilder.Build : MulticastDelegate, ICloneable, ISerializable
```

##### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

##### Constructors

###### JsonElement.ArrayBuilder.Build

```csharp
JsonElement.ArrayBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref JsonElement.ArrayBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref JsonElement.ArrayBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonElement.ArrayBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `result` | `IAsyncResult` |  |

---

#### JsonElement.ArrayBuilder.Build<T> (delegate)

```csharp
public delegate JsonElement.ArrayBuilder.Build<T> : MulticastDelegate, ICloneable, ISerializable
```

##### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

##### Constructors

###### JsonElement.ArrayBuilder.Build

```csharp
JsonElement.ArrayBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref T context, ref JsonElement.ArrayBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T context, ref JsonElement.ArrayBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref T context, ref JsonElement.ArrayBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `result` | `IAsyncResult` |  |

---

---

### JsonElement.JsonSchema (class)

```csharp
public static class JsonElement.JsonSchema
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `SchemaLocationUtf8` `static` | `ReadOnlySpan<byte>` |  |

#### Methods

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext<TContext>(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, TContext providerContext, JsonSchemaPathProvider<TContext> schemaEvaluationPath, JsonSchemaPathProvider<TContext> documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `providerContext` | `TContext` |  |
| `schemaEvaluationPath` | `JsonSchemaPathProvider<TContext>` |  *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider<TContext>` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, int itemIndex, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `itemIndex` | `int` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContextUnescaped `static`

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### Evaluate `static`

```csharp
void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |

##### Evaluate `static`

```csharp
bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentIndex` | `int` |  |
| `resultsCollector` | `IJsonSchemaResultsCollector` |  |

**Returns:** `bool`

#### Fields

| Field | Type | Description |
|-------|------|-------------|
| `SchemaLocationProvider` `static` | `JsonSchemaPathProvider` |  |
| `SchemaLocation` `static` | `string` |  |

---

### JsonElement.Mutable (struct)

```csharp
public readonly struct JsonElement.Mutable : IMutableJsonElement<JsonElement.Mutable>, IJsonElement<JsonElement.Mutable>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

#### Inheritance

- Implements: `IMutableJsonElement<JsonElement.Mutable>`
- Implements: `IJsonElement<JsonElement.Mutable>`
- Implements: `IJsonElement`
- Implements: `IFormattable`
- Implements: `ISpanFormattable`
- Implements: `IUtf8SpanFormattable`

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | `JsonValueKind` |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |

#### Methods

##### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `bool`

##### Equals

```csharp
bool Equals<T>(T other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` |  |

**Returns:** `bool`

##### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` |  |

**Returns:** `JsonDocumentBuilder<JsonElement.Mutable>`

##### From `static`

```csharp
JsonElement.Mutable From<T>(ref T instance)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` |  |

**Returns:** `JsonElement.Mutable`

##### GetArrayLength

```csharp
int GetArrayLength()
```

**Returns:** `int`

##### GetPropertyCount

```csharp
int GetPropertyCount()
```

**Returns:** `int`

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |

**Returns:** `JsonElement.Mutable`

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |

**Returns:** `JsonElement.Mutable`

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` |  |

**Returns:** `JsonElement.Mutable`

##### TryGetProperty

```csharp
bool TryGetProperty(string propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** `bool`

##### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** `bool`

##### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** `bool`

##### GetBoolean

```csharp
bool GetBoolean()
```

**Returns:** `bool`

##### GetString

```csharp
string GetString()
```

**Returns:** `string`

##### GetUtf8String

```csharp
UnescapedUtf8JsonString GetUtf8String()
```

**Returns:** `UnescapedUtf8JsonString`

##### GetUtf16String

```csharp
UnescapedUtf16JsonString GetUtf16String()
```

**Returns:** `UnescapedUtf16JsonString`

##### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte[]` |  |

**Returns:** `bool`

##### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

**Returns:** `byte[]`

##### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref sbyte` |  |

**Returns:** `bool`

##### GetSByte

```csharp
sbyte GetSByte()
```

**Returns:** `sbyte`

##### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte` |  |

**Returns:** `bool`

##### GetByte

```csharp
byte GetByte()
```

**Returns:** `byte`

##### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref short` |  |

**Returns:** `bool`

##### GetInt16

```csharp
short GetInt16()
```

**Returns:** `short`

##### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ushort` |  |

**Returns:** `bool`

##### GetUInt16

```csharp
ushort GetUInt16()
```

**Returns:** `ushort`

##### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref int` |  |

**Returns:** `bool`

##### GetInt32

```csharp
int GetInt32()
```

**Returns:** `int`

##### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref uint` |  |

**Returns:** `bool`

##### GetUInt32

```csharp
uint GetUInt32()
```

**Returns:** `uint`

##### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref long` |  |

**Returns:** `bool`

##### GetInt64

```csharp
long GetInt64()
```

**Returns:** `long`

##### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ulong` |  |

**Returns:** `bool`

##### GetUInt64

```csharp
ulong GetUInt64()
```

**Returns:** `ulong`

##### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref double` |  |

**Returns:** `bool`

##### GetDouble

```csharp
double GetDouble()
```

**Returns:** `double`

##### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref float` |  |

**Returns:** `bool`

##### GetSingle

```csharp
float GetSingle()
```

**Returns:** `float`

##### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref decimal` |  |

**Returns:** `bool`

##### GetDecimal

```csharp
decimal GetDecimal()
```

**Returns:** `decimal`

##### TryGetInt128

```csharp
bool TryGetInt128(ref Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Int128` |  |

**Returns:** `bool`

##### GetInt128

```csharp
Int128 GetInt128()
```

**Returns:** `Int128`

##### TryGetUInt128

```csharp
bool TryGetUInt128(ref UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref UInt128` |  |

**Returns:** `bool`

##### GetUInt128

```csharp
UInt128 GetUInt128()
```

**Returns:** `UInt128`

##### TryGetHalf

```csharp
bool TryGetHalf(ref Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Half` |  |

**Returns:** `bool`

##### GetHalf

```csharp
Half GetHalf()
```

**Returns:** `Half`

##### TryGetBigNumber

```csharp
bool TryGetBigNumber(ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigNumber` |  |

**Returns:** `bool`

##### GetBigNumber

```csharp
BigNumber GetBigNumber()
```

**Returns:** `BigNumber`

##### TryGetBigInteger

```csharp
bool TryGetBigInteger(ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` |  |

**Returns:** `bool`

##### GetBigInteger

```csharp
BigInteger GetBigInteger()
```

**Returns:** `BigInteger`

##### TryGetLocalDate

```csharp
bool TryGetLocalDate(ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` |  |

**Returns:** `bool`

##### GetLocalDate

```csharp
LocalDate GetLocalDate()
```

**Returns:** `LocalDate`

##### TryGetOffsetTime

```csharp
bool TryGetOffsetTime(ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` |  |

**Returns:** `bool`

##### GetOffsetTime

```csharp
OffsetTime GetOffsetTime()
```

**Returns:** `OffsetTime`

##### TryGetOffsetDateTime

```csharp
bool TryGetOffsetDateTime(ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` |  |

**Returns:** `bool`

##### GetOffsetDateTime

```csharp
OffsetDateTime GetOffsetDateTime()
```

**Returns:** `OffsetDateTime`

##### TryGetOffsetDate

```csharp
bool TryGetOffsetDate(ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` |  |

**Returns:** `bool`

##### GetOffsetDate

```csharp
OffsetDate GetOffsetDate()
```

**Returns:** `OffsetDate`

##### TryGetPeriod

```csharp
bool TryGetPeriod(ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` |  |

**Returns:** `bool`

##### GetPeriod

```csharp
Period GetPeriod()
```

**Returns:** `Period`

##### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` |  |

**Returns:** `bool`

##### GetDateTime

```csharp
DateTime GetDateTime()
```

**Returns:** `DateTime`

##### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` |  |

**Returns:** `bool`

##### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

**Returns:** `DateTimeOffset`

##### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Guid` |  |

**Returns:** `bool`

##### GetGuid

```csharp
Guid GetGuid()
```

**Returns:** `Guid`

##### GetRawText

```csharp
string GetRawText()
```

**Returns:** `string`

##### EnsurePropertyMap `static`

```csharp
void EnsurePropertyMap(ref JsonElement.Mutable element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `ref JsonElement.Mutable` |  |

##### ValueEquals

```csharp
bool ValueEquals(string text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `string` |  |

**Returns:** `bool`

##### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` |  |

**Returns:** `bool`

##### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<char> text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<char>` |  |

**Returns:** `bool`

##### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` |  |

##### EnumerateArray

```csharp
ArrayEnumerator<JsonElement.Mutable> EnumerateArray()
```

**Returns:** `ArrayEnumerator<JsonElement.Mutable>`

##### EnumerateObject

```csharp
ObjectEnumerator<JsonElement.Mutable> EnumerateObject()
```

**Returns:** `ObjectEnumerator<JsonElement.Mutable>`

##### ToString `virtual`

```csharp
string ToString()
```

**Returns:** `string`

##### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** `int`

##### ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `format` | `string` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `string`

##### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

##### TryFormat

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

##### Clone

```csharp
JsonElement Clone()
```

**Returns:** `JsonElement`

##### SetProperty

```csharp
void SetProperty(string propertyName, ref JsonElement.Source source)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `source` | `ref JsonElement.Source` |  |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `context` | `TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetPropertyNull

```csharp
void SetPropertyNull(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |

##### SetPropertyNull

```csharp
void SetPropertyNull(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |

##### SetPropertyNull

```csharp
void SetPropertyNull(ReadOnlySpan<byte> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |

##### RemoveProperty

```csharp
bool RemoveProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |

**Returns:** `bool`

##### RemoveProperty

```csharp
bool RemoveProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |

**Returns:** `bool`

##### RemoveProperty

```csharp
bool RemoveProperty(ReadOnlySpan<byte> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |

**Returns:** `bool`

##### SetItem

```csharp
void SetItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### SetItemNull

```csharp
void SetItemNull(int itemIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |

##### InsertItem

```csharp
void InsertItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### InsertItem

```csharp
void InsertItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### InsertItem

```csharp
void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### InsertItem

```csharp
void InsertItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### InsertItem

```csharp
void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### InsertItemNull

```csharp
void InsertItemNull(int itemIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | `int` |  |

##### AddItem

```csharp
void AddItem(ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### AddItem

```csharp
void AddItem(JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### AddItem

```csharp
void AddItem(JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | `int` |  *(optional)* |

##### AddItemNull

```csharp
void AddItemNull()
```

##### RemoveRange

```csharp
void RemoveRange(int startIndex, int count)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `startIndex` | `int` |  |
| `count` | `int` |  |

##### RemoveAt

```csharp
void RemoveAt(int index)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |

##### Remove

```csharp
bool Remove(ref JsonElement item)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref JsonElement` |  |

**Returns:** `bool`

##### Replace

```csharp
bool Replace(ref JsonElement oldItem, ref JsonElement.Source newItem)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `oldItem` | `ref JsonElement` |  |
| `newItem` | `ref JsonElement.Source` |  |

**Returns:** `bool`

##### RemoveWhere

```csharp
void RemoveWhere<T>(JsonPredicate<T> predicate)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `predicate` | `JsonPredicate<T>` |  |

##### RemoveWhere

```csharp
void RemoveWhere(JsonPredicate<JsonElement> predicate)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `predicate` | `JsonPredicate<JsonElement>` |  |

##### Apply

```csharp
void Apply<T>(ref T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` |  |

##### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | `IJsonSchemaResultsCollector` |  *(optional)* |

**Returns:** `bool`

---

### JsonElement.ObjectBuilder (struct)

```csharp
public readonly struct JsonElement.ObjectBuilder
```

#### Constructors

##### JsonElement.ObjectBuilder

```csharp
JsonElement.ObjectBuilder()
```

#### Methods

##### BuildValue `static`

```csharp
void BuildValue(JsonElement.ObjectBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### BuildValue `static`

```csharp
void BuildValue<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ReadOnlySpan<byte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ReadOnlySpan<byte>` |  |
| `valueRequiresUnescaping` | `bool` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `JsonElement.ObjectBuilder.Build` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `JsonElement.ArrayBuilder.Build` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `utf8String` | `ReadOnlySpan<byte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(string propertyName, string value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `value` | `string` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ReadOnlySpan<char>` |  |

##### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `bool` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `T` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, string value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `string` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ReadOnlySpan<char>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `Guid` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref DateTime` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref DateTimeOffset` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref OffsetDateTime` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref OffsetDate` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref OffsetTime` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref LocalDate` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref Period` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `sbyte` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `byte` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `int` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `uint` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `long` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ulong` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `short` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ushort` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `float` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `double` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `decimal` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref BigInteger` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref BigNumber` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ReadOnlySpan<byte>` |  |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ReadOnlySpan<byte>` |  |
| `valueRequiresUnescaping` | `bool` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `JsonElement.ObjectBuilder.Build` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8String, bool escapeValue, bool valueRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `utf8String` | `ReadOnlySpan<byte>` |  |
| `escapeValue` | `bool` |  |
| `valueRequiresUnescaping` | `bool` |  |

##### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `bool` |  |

##### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `T` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `Guid` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref DateTime` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref DateTimeOffset` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref OffsetDateTime` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref OffsetDate` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref OffsetTime` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref LocalDate` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref Period` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `sbyte` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `byte` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `int` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `uint` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `long` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ulong` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `short` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ushort` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `float` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `double` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `decimal` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref BigInteger` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref BigNumber` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `Int128` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `UInt128` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `Half` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `Int128` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `UInt128` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `Half` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<long>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<int>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<short>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<sbyte>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<ulong>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<uint>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<ushort>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<byte>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<decimal>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<double>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<float>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<Int128>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<UInt128>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |
| `array` | `ReadOnlySpan<Half>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<long>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<int>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<short>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<sbyte>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<ulong>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<uint>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<ushort>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<byte>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<decimal>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<double>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<float>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<Int128>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<UInt128>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `array` | `ReadOnlySpan<Half>` |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<long>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<int>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<short>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<sbyte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<ulong>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<uint>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<ushort>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<byte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<decimal>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<double>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<float>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |

##### RemoveProperty

```csharp
void RemoveProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` |  |

##### TryApply

```csharp
bool TryApply<TApplicator>(ref TApplicator value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref TApplicator` |  |

**Returns:** `bool`

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<Int128>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<UInt128>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `array` | `ReadOnlySpan<Half>` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

#### Nested Types

#### JsonElement.ObjectBuilder.Build (delegate)

```csharp
public delegate JsonElement.ObjectBuilder.Build : MulticastDelegate, ICloneable, ISerializable
```

##### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

##### Constructors

###### JsonElement.ObjectBuilder.Build

```csharp
JsonElement.ObjectBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref JsonElement.ObjectBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref JsonElement.ObjectBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonElement.ObjectBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `result` | `IAsyncResult` |  |

---

#### JsonElement.ObjectBuilder.Build<T> (delegate)

```csharp
public delegate JsonElement.ObjectBuilder.Build<T> : MulticastDelegate, ICloneable, ISerializable
```

##### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

##### Constructors

###### JsonElement.ObjectBuilder.Build

```csharp
JsonElement.ObjectBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref T context, ref JsonElement.ObjectBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T context, ref JsonElement.ObjectBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref T context, ref JsonElement.ObjectBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `result` | `IAsyncResult` |  |

---

---

### JsonElement.Source (struct)

```csharp
public readonly struct JsonElement.Source
```

#### Constructors

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsUndefined` | `bool` |  |

#### Methods

##### Null `static`

```csharp
JsonElement.Source Null()
```

**Returns:** `JsonElement.Source`

##### RawString `static`

```csharp
JsonElement.Source RawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` |  |
| `requiresUnescaping` | `bool` |  |

**Returns:** `JsonElement.Source`

##### FormattedNumber `static`

```csharp
JsonElement.Source FormattedNumber(ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` |  |

**Returns:** `JsonElement.Source`

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddAsProperty

```csharp
void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddAsItem

```csharp
void AddAsItem(ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueBuilder` | `ref ComplexValueBuilder` |  |

---

### JsonElement.Source<TContext> (struct)

```csharp
public readonly struct JsonElement.Source<TContext>
```

#### Constructors

##### JsonElement.Source

```csharp
JsonElement.Source(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.Source source)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `source` | `JsonElement.Source` |  |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsUndefined` | `bool` |  |

#### Methods

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |
| `escapeName` | `bool` |  *(optional)* |
| `nameRequiresUnescaping` | `bool` |  *(optional)* |

##### AddAsProperty

```csharp
void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` |  |
| `valueBuilder` | `ref ComplexValueBuilder` |  |

##### AddAsItem

```csharp
void AddAsItem(ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueBuilder` | `ref ComplexValueBuilder` |  |

---

---

## JsonElementExtensions (class)

```csharp
public static class JsonElementExtensions
```

Extension methods for [`IJsonElement`](#IJsonElement).

### Methods

#### IsNotNull `static`

```csharp
bool IsNotNull<T>(T value)
```

Gets a value indicating whether this value is not null.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is not null.

#### IsNotNullOrUndefined `static`

```csharp
bool IsNotNullOrUndefined<T>(T value)
```

Gets a value indicating whether this value is neither null nor undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is neither null nor undefined.

#### IsNotUndefined `static`

```csharp
bool IsNotUndefined<T>(T value)
```

Gets a value indicating whether this value is not undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is not undefined.

#### IsNull `static`

```csharp
bool IsNull<T>(T value)
```

Gets a value indicating whether this value is null.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is null.

#### IsNullOrUndefined `static`

```csharp
bool IsNullOrUndefined<T>(T value)
```

Gets a value indicating whether this value is null or undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is undefined.

#### IsUndefined `static`

```csharp
bool IsUndefined<T>(T value)
```

Gets a value indicating whether this value is undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** `bool`

`True` if the value is undefined.

---

## JsonElementForBooleanFalseSchema (struct)

```csharp
public readonly struct JsonElementForBooleanFalseSchema : IJsonElement<JsonElementForBooleanFalseSchema>, IJsonElement
```

Represents a specific JSON value within a [`JsonDocument`](#JsonDocument).

### Inheritance

- Implements: `IJsonElement<JsonElementForBooleanFalseSchema>`
- Implements: `IJsonElement`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | `JsonValueKind` | The [`JsonValueKind`](#JsonValueKind) that the value is. |

### Methods

#### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates this element against the boolean false schema.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | `IJsonSchemaResultsCollector` | The optional results collector for schema evaluation. *(optional)* |

**Returns:** `bool`

`false` because this represents a boolean false schema.

#### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether the specified object is equal to the current instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` | The object to compare with the current instance. |

**Returns:** `bool`

`true` if the specified object is equal to the current instance; otherwise, `false`.

#### Equals

```csharp
bool Equals<T>(T other)
```

Determines whether the specified JSON element is equal to the current instance.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element to compare. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` | The JSON element to compare with the current instance. |

**Returns:** `bool`

`true` if the specified JSON element is equal to the current instance; otherwise, `false`.

#### From `static`

```csharp
JsonElementForBooleanFalseSchema From<T>(ref T instance)
```

Creates a new [`JsonElementForBooleanFalseSchema`](#JsonElementForBooleanFalseSchema) from the specified JSON element instance.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` | The JSON element instance to create from. |

**Returns:** `JsonElementForBooleanFalseSchema`

A new [`JsonElementForBooleanFalseSchema`](#JsonElementForBooleanFalseSchema) instance.

#### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ReadOnlySpan<byte> utf8Json, JsonDocumentOptions options)
```

Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlySpan<byte>` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElementForBooleanFalseSchema`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ReadOnlySpan<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `ReadOnlySpan<char>` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElementForBooleanFalseSchema`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](#JsonElement).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `string` | The JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `JsonElementForBooleanFalseSchema`

A [`JsonElement`](#JsonElement) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | `json` is `null`. |
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |

**Returns:** `JsonElementForBooleanFalseSchema`

A JsonElement representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref Nullable<JsonElementForBooleanFalseSchema> element)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |
| `element` | `ref Nullable<JsonElementForBooleanFalseSchema>` | Receives the parsed element. |

**Returns:** `bool`

`true` if a value was read and parsed into a JsonElement; `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### CreateDocument `static`

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity)
```

Creates a JSON document containing the specified integer value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` | The JSON workspace to use for document creation. |
| `year` | `int` | The integer value to include in the document. |
| `initialCapacity` | `int` | The initial capacity for the document builder. *(optional)* |

**Returns:** `JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`

A JSON document builder containing the specified value.

#### CreateDocument

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace)
```

Creates a JSON document from the current instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` | The JSON workspace to use for document creation. |

**Returns:** `JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`

A JSON document builder containing the current instance.

#### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the element into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | The `writer` parameter is `null`. |
| `System.InvalidOperationException` | This value's [`ValueKind`](#ValueKind) is [`Undefined`](#Undefined). |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### ToString `virtual`

```csharp
string ToString()
```

Gets a string representation for the current value appropriate to the value type.

**Returns:** `string`

A string representation for the current value appropriate to the value type.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

For JsonElement built from [`JsonDocument`](#JsonDocument): For [`Null`](#Null), [`Empty`](#Empty) is returned. For [`True`](#True), [`TrueString`](#TrueString) is returned. For [`False`](#False), [`FalseString`](#FalseString) is returned. For [`String`](#String), the value of [`GetString`](#GetString)() is returned. For other types, the value of [`GetRawText`](#GetRawText)() is returned.

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Gets the hash code for the current instance.

**Returns:** `int`

A hash code for the current instance.

### Nested Types

### JsonElementForBooleanFalseSchema.JsonSchema (class)

```csharp
public static class JsonElementForBooleanFalseSchema.JsonSchema
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `SchemaLocationUtf8` `static` | `ReadOnlySpan<byte>` |  |

#### Methods

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext<TContext>(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, TContext providerContext, JsonSchemaPathProvider<TContext> schemaEvaluationPath, JsonSchemaPathProvider<TContext> documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `providerContext` | `TContext` |  |
| `schemaEvaluationPath` | `JsonSchemaPathProvider<TContext>` |  *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider<TContext>` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, int itemIndex, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `itemIndex` | `int` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### PushChildContextUnescaped `static`

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `evaluationPath` | `JsonSchemaPathProvider` |  *(optional)* |

**Returns:** `JsonSchemaContext`

##### Evaluate `static`

```csharp
void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |

##### Evaluate `static`

```csharp
bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentIndex` | `int` |  |
| `resultsCollector` | `IJsonSchemaResultsCollector` |  |

**Returns:** `bool`

#### Fields

| Field | Type | Description |
|-------|------|-------------|
| `SchemaLocationProvider` `static` | `JsonSchemaPathProvider` |  |
| `SchemaLocation` `static` | `string` |  |

---

### JsonElementForBooleanFalseSchema.Mutable (struct)

```csharp
public readonly struct JsonElementForBooleanFalseSchema.Mutable : IMutableJsonElement<JsonElementForBooleanFalseSchema.Mutable>, IJsonElement<JsonElementForBooleanFalseSchema.Mutable>, IJsonElement
```

#### Inheritance

- Implements: `IMutableJsonElement<JsonElementForBooleanFalseSchema.Mutable>`
- Implements: `IJsonElement<JsonElementForBooleanFalseSchema.Mutable>`
- Implements: `IJsonElement`

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | `JsonValueKind` |  |
| `Item` | `JsonElementForBooleanFalseSchema.Mutable` |  |

#### Methods

##### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `bool`

##### Equals

```csharp
bool Equals<T>(T other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` |  |

**Returns:** `bool`

##### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateBuilder(JsonWorkspace workspace)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | `JsonWorkspace` |  |

**Returns:** `JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`

##### From `static`

```csharp
JsonElementForBooleanFalseSchema.Mutable From<T>(ref T instance)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` |  |

**Returns:** `JsonElementForBooleanFalseSchema.Mutable`

##### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` |  |

##### ToString `virtual`

```csharp
string ToString()
```

**Returns:** `string`

##### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** `int`

##### Clone

```csharp
JsonElement Clone()
```

**Returns:** `JsonElement`

##### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | `IJsonSchemaResultsCollector` |  *(optional)* |

**Returns:** `bool`

---

---

## JsonEncodedText (struct)

```csharp
public readonly struct JsonEncodedText : IEquatable<JsonEncodedText>
```

Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON.

### Remarks

This can be used to cache and store known strings used for writing JSON ahead of time by pre-encoding them up front.

### Inheritance

- Implements: `IEquatable<JsonEncodedText>`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `EncodedUtf8Bytes` | `ReadOnlySpan<byte>` | Returns the UTF-8 encoded representation of the pre-encoded JSON text. |
| `Value` | `string` | Returns the UTF-16 encoded representation of the pre-encoded JSON text as a [`String`](#String). |

### Methods

#### Encode `static`

```csharp
JsonEncodedText Encode(string value, JavaScriptEncoder encoder)
```

Encodes the string text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` | The value to be transformed as JSON encoded text. |
| `encoder` | `JavaScriptEncoder` | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** `JsonEncodedText`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown if value is null. |
| `System.ArgumentException` | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

#### Encode `static`

```csharp
JsonEncodedText Encode(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
```

Encodes the text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The value to be transformed as JSON encoded text. |
| `encoder` | `JavaScriptEncoder` | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** `JsonEncodedText`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

#### Encode `static`

```csharp
JsonEncodedText Encode(ReadOnlySpan<byte> utf8Value, JavaScriptEncoder encoder)
```

Encodes the UTF-8 text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to be transformed as JSON encoded text. |
| `encoder` | `JavaScriptEncoder` | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** `JsonEncodedText`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large or if it contains invalid UTF-8 bytes. |

#### Equals

```csharp
bool Equals(JsonEncodedText other)
```

Determines whether this instance and another specified [`JsonEncodedText`](#JsonEncodedText) instance have the same value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `JsonEncodedText` |  |

**Returns:** `bool`

Default instances of [`JsonEncodedText`](#JsonEncodedText) are treated as equal.

#### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](#JsonEncodedText) instance, have the same value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `bool`

If `obj` is null, the method returns false.

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Returns the hash code for this [`JsonEncodedText`](#JsonEncodedText).

**Returns:** `int`

Returns 0 on a default instance of [`JsonEncodedText`](#JsonEncodedText).

#### ToString `virtual`

```csharp
string ToString()
```

Converts the value of this instance to a [`String`](#String).

**Returns:** `string`

Returns the underlying UTF-16 encoded string.

Returns an empty string on a default instance of [`JsonEncodedText`](#JsonEncodedText).

---

## JsonException (class)

```csharp
public class JsonException : Exception, ISerializable
```

Represents errors that occur during JSON parsing, reading, or writing operations. This exception is thrown when invalid JSON text is encountered, when the defined maximum depth is exceeded, or when the JSON text is not compatible with the type of a property on an object.

### Inheritance

- Inherits from: `Exception`
- Implements: `ISerializable`

### Constructors

#### JsonException

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine, Exception innerException)
```

Initializes a new instance of the [`JsonException`](#JsonException) class with a specified error message, path, line number, byte position, and a reference to the inner exception that is the cause of this exception.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | `string` | The context specific error message. |
| `path` | `string` | The path where the invalid JSON was encountered. |
| `lineNumber` | `Nullable<long>` | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | `Nullable<long>` | The byte count within the current line where the invalid JSON was encountered (starting at 0). |
| `innerException` | `Exception` | The exception that caused the current exception. |

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

#### JsonException

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine)
```

Initializes a new instance of the [`JsonException`](#JsonException) class with a specified error message, path, line number, and byte position.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | `string` | The context specific error message. |
| `path` | `string` | The path where the invalid JSON was encountered. |
| `lineNumber` | `Nullable<long>` | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | `Nullable<long>` | The byte count within the current line where the invalid JSON was encountered (starting at 0). |

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

#### JsonException

```csharp
JsonException(string message, Exception innerException)
```

Initializes a new instance of the [`JsonException`](#JsonException) class with a specified error message and a reference to the inner exception that is the cause of this exception.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | `string` | The context specific error message. |
| `innerException` | `Exception` | The exception that caused the current exception. |

#### JsonException

```csharp
JsonException(string message)
```

Initializes a new instance of the [`JsonException`](#JsonException) class with a specified error message.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | `string` | The context specific error message. |

#### JsonException

```csharp
JsonException()
```

Initializes a new instance of the [`JsonException`](#JsonException) class.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `BytePositionInLine` | `Nullable<long>` | Gets the number of bytes read within the current line before the exception (starting at 0). |
| `LineNumber` | `Nullable<long>` | Gets the number of lines read so far before the exception (starting at 0). |
| `Message` | `string` | Gets a message that describes the current exception. |
| `Path` | `string` | Gets the path within the JSON where the exception was encountered. |

---

## JsonPredicate<T> (delegate)

```csharp
public delegate JsonPredicate<T> : MulticastDelegate, ICloneable, ISerializable
```

A predicate for a JSON value.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON value. |

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonPredicate

```csharp
JsonPredicate(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
bool Invoke(ref T item)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |

**Returns:** `bool`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T item, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
bool EndInvoke(ref T item, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `bool`

---

## JsonProperty<TValue> (struct)

```csharp
public readonly struct JsonProperty<TValue>
```

Represents a single property for a JSON object.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the value. |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | The name of this property. |
| `NameSpan` | `UnescapedUtf8JsonString` | Gets the name as an unescaped UTF-8 JSON string. |
| `Value` | `TValue` | The value of this property. |

#### Name

```csharp
string Name { get; }
```

The name of this property.

Note that this allocates.

#### NameSpan

```csharp
UnescapedUtf8JsonString NameSpan { get; }
```

Gets the name as an unescaped UTF-8 JSON string.

Note that this does not allocate. The result should be disposed when it is no longer needed, as it may use a rented buffer to back the string. It is only valid for the lifetime of the document that contains this property.

### Methods

#### NameEquals

```csharp
bool NameEquals(string text)
```

Compares `text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `string` | The text to compare against. |

**Returns:** `bool`

`true` if the name of this property matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`Type`](#Type) is not [`PropertyName`](#PropertyName). |

This method is functionally equal to doing an ordinal comparison of `text` and [`Name`](#Name), but can avoid creating the string instance.

#### NameEquals

```csharp
bool NameEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text to compare against. |

**Returns:** `bool`

`true` if the name of this property has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`Type`](#Type) is not [`PropertyName`](#PropertyName). |

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`NameSpan`](#NameSpan), but can avoid creating the UTF8 string instance.

#### NameEquals

```csharp
bool NameEquals(ReadOnlySpan<char> text)
```

Compares `text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<char>` | The text to compare against. |

**Returns:** `bool`

`true` if the name of this property matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | This value's [`Type`](#Type) is not [`PropertyName`](#PropertyName). |

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`NameSpan`](#NameSpan), but can avoid creating the UTF-8 string instance.

#### ToString `virtual`

```csharp
string ToString()
```

Provides a [`String`](#String) representation of the property for debugging purposes.

**Returns:** `string`

A string containing the un-interpreted value of the property, beginning at the declaring open-quote and ending at the last character that is part of the value.

#### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the property into the provided writer as a named JSON object property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | The `writer` parameter is `null`. |
| `System.ArgumentException` | This [`Name`](#Name)'s length is too large to be a JSON object property. |
| `System.InvalidOperationException` | This [`Value`](#Value)'s [`ValueKind`](#ValueKind) would result in an invalid JSON. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

---

## JsonReaderOptions (struct)

```csharp
public readonly struct JsonReaderOptions
```

Provides the ability for the user to define custom behavior when reading JSON.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `AllowMultipleValues` | `bool` | Defines whether the [`Utf8JsonReader`](#Utf8JsonReader) should tolerate zero or more top-level JSON values that are whitespace separated. |
| `AllowTrailingCommas` | `bool` | Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read. |
| `CommentHandling` | `JsonCommentHandling` | Defines how the [`Utf8JsonReader`](#Utf8JsonReader) should handle comments when reading through the JSON. |
| `MaxDepth` | `int` | Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64. |

#### AllowMultipleValues

```csharp
bool AllowMultipleValues { get; set; }
```

Defines whether the [`Utf8JsonReader`](#Utf8JsonReader) should tolerate zero or more top-level JSON values that are whitespace separated.

By default, it's set to false, and is thrown if trailing content is encountered after the first top-level JSON value.

#### AllowTrailingCommas

```csharp
bool AllowTrailingCommas { get; set; }
```

Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read.

By default, it's set to false, and is thrown if a trailing comma is encountered.

#### CommentHandling

```csharp
JsonCommentHandling CommentHandling { get; set; }
```

Defines how the [`Utf8JsonReader`](#Utf8JsonReader) should handle comments when reading through the JSON.

By default is thrown if a comment is encountered.

#### MaxDepth

```csharp
int MaxDepth { get; set; }
```

Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64.

Reading past this depth will throw a .

---

## JsonReaderState (struct)

```csharp
public readonly struct JsonReaderState
```

Defines an opaque type that holds and saves all the relevant state information which must be provided to the [`Utf8JsonReader`](#Utf8JsonReader) to continue reading after processing incomplete data. This type is required to support reentrancy when reading incomplete data, and to continue reading once more data is available. Unlike the [`Utf8JsonReader`](#Utf8JsonReader), which is a ref struct, this type can survive across async/await boundaries and hence this type is required to provide support for reading in more data asynchronously before continuing with a new instance of the [`Utf8JsonReader`](#Utf8JsonReader).

### Constructors

#### JsonReaderState

```csharp
JsonReaderState(JsonReaderOptions options)
```

Constructs a new [`JsonReaderState`](#JsonReaderState) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `options` | `JsonReaderOptions` | Defines the customized behavior of the [`Utf8JsonReader`](#Utf8JsonReader) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](#Utf8JsonReader) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

An instance of this state must be passed to the [`Utf8JsonReader`](#Utf8JsonReader) ctor with the JSON data. Unlike the [`Utf8JsonReader`](#Utf8JsonReader), which is a ref struct, the state can survive across async/await boundaries and hence this type is required to provide support for reading in more data asynchronously before continuing with a new instance of the [`Utf8JsonReader`](#Utf8JsonReader).

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Options` | `JsonReaderOptions` | Gets the custom behavior when reading JSON using the [`Utf8JsonReader`](#Utf8JsonReader) that may deviate from strict adherence to the JSON specification, which is the default behavior. |

---

## JsonSchemaMessageProvider (delegate)

```csharp
public delegate JsonSchemaMessageProvider : MulticastDelegate, ICloneable, ISerializable
```

Provides a message for a JSON Schema validation result.

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaMessageProvider

```csharp
JsonSchemaMessageProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
bool Invoke(Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
bool EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `bool`

---

## JsonSchemaMessageProvider<TContext> (delegate)

```csharp
public delegate JsonSchemaMessageProvider<TContext> : MulticastDelegate, ICloneable, ISerializable
```

Provides a message for a JSON Schema validation result, using a context value.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TContext` | The type of the context value. |

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaMessageProvider

```csharp
JsonSchemaMessageProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
bool Invoke(TContext context, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(TContext context, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
bool EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `bool`

---

## JsonSchemaPathProvider (delegate)

```csharp
public delegate JsonSchemaPathProvider : MulticastDelegate, ICloneable, ISerializable
```

Provides a path segment for a JSON Schema location or instance path.

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaPathProvider

```csharp
JsonSchemaPathProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
bool Invoke(Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
bool EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `bool`

---

## JsonSchemaPathProvider<TContext> (delegate)

```csharp
public delegate JsonSchemaPathProvider<TContext> : MulticastDelegate, ICloneable, ISerializable
```

Provides a path segment for a JSON Schema location or instance path, using a context value.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TContext` | The type of the context value. |

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaPathProvider

```csharp
JsonSchemaPathProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
bool Invoke(TContext context, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(TContext context, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
bool EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `bool`

---

## JsonSchemaResultsCollector (class)

```csharp
public sealed class JsonSchemaResultsCollector : IJsonSchemaResultsCollector, IDisposable
```

Collects and manages results from JSON schema validation operations with high-performance memory management, stack-based evaluation tracking, and configurable verbosity levels.

### Remarks

Core Architecture: The [`JsonSchemaResultsCollector`](#JsonSchemaResultsCollector) provides a sophisticated result collection system optimized for JSON schema validation workflows. It manages multiple evaluation paths simultaneously and supports hierarchical validation contexts through a stack-based approach. - Multi-Path Tracking: Maintains evaluation, schema, and document paths separately for precise error reporting - Stack-Based Contexts: Hierarchical validation contexts with proper nesting and cleanup - Pooled Memory Management: Thread-local pooling for high-throughput validation scenarios - Configurable Verbosity: Three levels from basic failures to comprehensive validation logs - UTF-8 Optimized: Direct UTF-8 processing for reduced encoding overhead Lifecycle Management: The collector follows a strict lifecycle pattern designed for efficient resource management: - Creation: Use [`Create`](#Create) for pooled instances or [`CreateUnrented`](#CreateUnrented) for standalone use - Configuration: Set verbosity level and capacity estimates during creation - Collection: Use context methods to track validation hierarchy and results - Enumeration: Access results through [`EnumerateResults`](#EnumerateResults) after validation completion - Disposal: Always dispose to return pooled resources and clear sensitive data Memory Management: Designed for high-performance scenarios with minimal garbage collection pressure: - Pooled Instances: Thread-local caching reduces allocation overhead in high-throughput scenarios - ArrayPool Integration: Uses shared array pools for internal buffers with proper cleanup - Stack Allocation: ValueStack structures minimize heap allocations for context management - Capacity Estimation: Pre-sizing based on expected result count prevents reallocations - Security Clearing: Sensitive data is explicitly cleared on disposal Performance Characteristics: - Time Complexity: O(1) result insertion, O(n) enumeration where n is result count - Space Complexity: O(d + r) where d is max validation depth, r is result count - Memory Overhead: ~32 bytes per path segment, ~128 bytes per message (configurable) - Thread Safety: Not thread-safe; use separate instances per thread Verbosity Level Guidance: - Basic: Failure messages only - minimal overhead, use for production validation - Detailed: Failure messages with detailed context - moderate overhead, use for debugging - Verbose: All validation events including successes - high overhead, use for comprehensive analysis Usage Patterns: - High-Throughput: Use pooled instances with accurate capacity estimation - One-Off Validation: Use unpooled instances for occasional validation - Debugging: Use Detailed or Verbose levels with comprehensive result analysis - Production: Use Basic level with pooled instances for optimal performance Context Hierarchy: The collector maintains a stack-based context system where each validation step creates a child context. Contexts must be completed in reverse order (stack discipline) using either commit or pop operations. This enables precise error location tracking and efficient resource cleanup. Thread Safety: This class is not thread-safe. Each thread must use its own collector instance. The internal thread-local pooling system handles concurrent access to the cache safely.

### Inheritance

- Implements: `IJsonSchemaResultsCollector`
- Implements: `IDisposable`

### Methods

#### Create `static`

```csharp
JsonSchemaResultsCollector Create(JsonSchemaResultsLevel level, int estimatedCapacity)
```

Creates a JSON schema results collector from the thread-local pool with optimal memory management.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `level` | `JsonSchemaResultsLevel` | Controls result verbosity and collection overhead: - [`Basic`](#Basic): Failure messages only (lowest overhead) - [`Detailed`](#Detailed): Detailed failure context (moderate overhead) - [`Verbose`](#Verbose): All validation events (highest overhead) |
| `estimatedCapacity` | `int` | Expected number of validation results to optimize internal buffer sizing. Accurate estimation prevents reallocations and improves performance. Use 0 for unknown capacity (defaults to 30). *(optional)* |

**Returns:** `JsonSchemaResultsCollector`

A pooled [`JsonSchemaResultsCollector`](#JsonSchemaResultsCollector) instance ready for validation result collection. Must be disposed to return resources to the pool.

Pooling Behavior: This method leverages thread-local pooling for optimal performance in high-throughput scenarios. The first call per thread returns a cached instance; subsequent concurrent calls create new instances. Always dispose the returned collector to ensure proper pool management. Memory Pre-allocation: - Path Buffers: (estimatedCapacity × 32 bytes) + 1024 bytes for path segments - Message Buffer: Varies by level - Basic: minimal, Verbose: (estimatedCapacity × 128 bytes) - Schema Path Buffer: Additional 4096 bytes for URI base length Performance Guidelines: - High Throughput: Use accurate capacity estimation to minimize allocations - Memory Constrained: Use lower verbosity levels and conservative capacity estimates - Debugging: Use Verbose level with generous capacity estimates for complete information

#### CreateUnrented `static`

```csharp
JsonSchemaResultsCollector CreateUnrented(JsonSchemaResultsLevel level, int estimatedCapacity)
```

Creates a non-pooled JSON schema results collector for standalone or specialized usage scenarios.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `level` | `JsonSchemaResultsLevel` | Controls result verbosity and collection overhead. |
| `estimatedCapacity` | `int` | Expected number of validation results for buffer pre-sizing. *(optional)* |

**Returns:** `JsonSchemaResultsCollector`

A standalone [`JsonSchemaResultsCollector`](#JsonSchemaResultsCollector) instance that is not managed by the thread-local pool. Resources are released directly on disposal without pool interaction.

Use Cases: - Long-lived Instances: When the collector lifetime exceeds typical validation scope - Memory Isolation: When pool interaction is undesirable for security or debugging - Testing: When predictable memory behavior is required for unit tests - Single-use: When validation frequency doesn't justify pooling overhead Performance Considerations: Non-pooled instances have higher allocation overhead but provide complete memory isolation. Each instance allocates fresh buffers from ArrayPool and returns them directly on disposal. Use when pool interaction is problematic or when instance lifetime is unpredictable.

#### EnumerateResults

```csharp
JsonSchemaResultsCollector.ResultsEnumerator EnumerateResults()
```

Enumerates validation results in collection order with efficient memory access patterns.

**Returns:** `JsonSchemaResultsCollector.ResultsEnumerator`

A [`ResultsEnumerator`](#ResultsEnumerator) that provides forward-only iteration over committed validation results. The enumerator is a value type optimized for minimal allocation overhead.

Enumeration Characteristics: - Order: Results are returned in the order they were committed to the collector - Stability: Result order and content remain stable until collector disposal - Performance: O(1) per result access with minimal memory allocation - Thread Safety: Not thread-safe; do not enumerate concurrently with result collection Memory Access Pattern: The enumerator provides direct access to UTF-8 result data stored in internal buffers. Result strings are accessed as ReadOnlySpan<byte> for optimal performance, with helper methods available for string conversion when needed. Usage Guidelines: - Performance Critical: Use UTF-8 span accessors (e.g., [`Message`](#Message)) when possible - Convenience: Use string accessors (e.g., [`GetMessageText`](#GetMessageText)) for display purposes - Filtering: Check [`IsMatch`](#IsMatch) early to optimize result processing

#### GetResultCount

```csharp
int GetResultCount()
```

Gets the total count of committed validation results with O(1) performance.

**Returns:** `int`

The number of validation results that have been committed and are available for enumeration. This count includes both successful and failed validation results based on the configured verbosity level.

Result Counting by Verbosity Level: - Basic: Counts failure results only - Detailed: Counts failure results with enhanced context - Verbose: Counts all validation events (successes and failures) Performance: This operation is O(1) as it returns the length of the committed results stack without enumeration. Use this method to determine if enumeration is necessary or to pre-size result processing structures.

#### Dispose

```csharp
void Dispose()
```

Releases all resources and returns the collector to the pool if rented, ensuring proper cleanup of sensitive data.

Resource Cleanup Process: - Pooled Instances: Resets state and returns to thread-local cache for reuse - Non-pooled Instances: Clears sensitive data and returns buffers to ArrayPool - Security: All internal buffers containing validation data are explicitly cleared - Stack Cleanup: Internal stacks are disposed and their resources released Security Considerations: The disposal process explicitly clears all internal buffers that may contain sensitive validation data, including validation messages, document paths, and schema paths. This ensures that sensitive information does not persist in memory after validation completion. Performance Impact: Disposal is designed to be efficient, with O(1) pool return for rented instances and O(n) buffer clearing for non-pooled instances where n is the total buffer usage. The explicit clearing overhead is necessary for security but minimal in typical usage scenarios. Important: Always dispose collector instances to ensure proper resource management. Failure to dispose rented instances can lead to pool exhaustion, while failure to dispose non-pooled instances can lead to memory leaks and security concerns.

### Nested Types

### JsonSchemaResultsCollector.Result (struct)

```csharp
public readonly struct JsonSchemaResultsCollector.Result
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsMatch` | `bool` |  |
| `Message` | `ReadOnlySpan<byte>` |  |
| `EvaluationLocation` | `ReadOnlySpan<byte>` |  |
| `SchemaEvaluationLocation` | `ReadOnlySpan<byte>` |  |
| `DocumentEvaluationLocation` | `ReadOnlySpan<byte>` |  |

#### Methods

##### GetMessageText

```csharp
string GetMessageText()
```

**Returns:** `string`

##### GetEvaluationLocationText

```csharp
string GetEvaluationLocationText()
```

**Returns:** `string`

##### GetSchemaEvaluationLocationText

```csharp
string GetSchemaEvaluationLocationText()
```

**Returns:** `string`

##### GetDocumentEvaluationLocationText

```csharp
string GetDocumentEvaluationLocationText()
```

**Returns:** `string`

---

### JsonSchemaResultsCollector.ResultsEnumerator (struct)

```csharp
public readonly struct JsonSchemaResultsCollector.ResultsEnumerator : IEnumerable<JsonSchemaResultsCollector.Result>, IEnumerable, IEnumerator<JsonSchemaResultsCollector.Result>, IEnumerator, IDisposable
```

#### Inheritance

- Implements: `IEnumerable<JsonSchemaResultsCollector.Result>`
- Implements: `IEnumerable`
- Implements: `IEnumerator<JsonSchemaResultsCollector.Result>`
- Implements: `IEnumerator`
- Implements: `IDisposable`

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Current` | `JsonSchemaResultsCollector.Result` |  |

#### Methods

##### Dispose

```csharp
void Dispose()
```

##### Reset

```csharp
void Reset()
```

##### MoveNext

```csharp
bool MoveNext()
```

**Returns:** `bool`

##### GetEnumerator

```csharp
IEnumerator<JsonSchemaResultsCollector.Result> GetEnumerator()
```

**Returns:** `IEnumerator<JsonSchemaResultsCollector.Result>`

---

### Example

Basic validation with pooled collector: ```csharp using var collector = JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.Basic, estimatedCapacity: 50); // Perform validation operations... int context = collector.BeginChildContext(0, evaluationPath, schemaPath, documentPath); collector.CommitChildContext(context, parentMatch: true, childMatch: false, messageProvider); // Enumerate results foreach (var result in collector.EnumerateResults()) { if (!result.IsMatch) { Console.WriteLine($"Validation failed: {result.GetMessageText()}"); Console.WriteLine($" Location: {result.GetDocumentEvaluationLocationText()}"); } } ```

---

## JsonSchemaResultsLevel (enum)

```csharp
public enum JsonSchemaResultsLevel : IComparable, ISpanFormattable, IFormattable, IConvertible
```

The level of result to collect for an [`IJsonSchemaResultsCollector`](#IJsonSchemaResultsCollector).

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Basic` `static` | `JsonSchemaResultsLevel` | Includes basic location and message information about schema matching failures. |
| `Detailed` `static` | `JsonSchemaResultsLevel` | Includes detailed location and message information about schema matching failures. |
| `Verbose` `static` | `JsonSchemaResultsLevel` | Includes full location and message information for schema matching. |

---

## JsonValueKind (enum)

```csharp
public enum JsonValueKind : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the data type of a JSON value.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Undefined` `static` | `JsonValueKind` | Indicates that there is no value (as distinct from [`Null`](#Null)). |
| `Object` `static` | `JsonValueKind` | Indicates that a value is a JSON object. |
| `Array` `static` | `JsonValueKind` | Indicates that a value is a JSON array. |
| `String` `static` | `JsonValueKind` | Indicates that a value is a JSON string. |
| `Number` `static` | `JsonValueKind` | Indicates that a value is a JSON number. |
| `True` `static` | `JsonValueKind` | Indicates that a value is the JSON value `true`. |
| `False` `static` | `JsonValueKind` | Indicates that a value is the JSON value `false`. |
| `Null` `static` | `JsonValueKind` | Indicates that a value is the JSON value `null`. |

---

## JsonWorkspace (class)

```csharp
public class JsonWorkspace : IDisposable
```

A workspace for manipulating JSON documents.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Options` | `JsonWriterOptions` | Gets the JsonWriterOptions |

### Methods

#### Create `static`

```csharp
JsonWorkspace Create(int initialDocumentCapacity, Nullable<JsonWriterOptions> options)
```

Creates an instance of a [`JsonWorkspace`](#JsonWorkspace).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialDocumentCapacity` | `int` | The initial document capacity for the workspace. *(optional)* |
| `options` | `Nullable<JsonWriterOptions>` | The ambient [`JsonWriterOptions`](#JsonWriterOptions). *(optional)* |

**Returns:** `JsonWorkspace`

The [`JsonWorkspace`](#JsonWorkspace).

#### CreateUnrented `static`

```csharp
JsonWorkspace CreateUnrented(int initialDocumentCapacity, Nullable<JsonWriterOptions> options)
```

Creates an instance of a [`JsonWorkspace`](#JsonWorkspace).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialDocumentCapacity` | `int` | The initial document capacity for the workspace. *(optional)* |
| `options` | `Nullable<JsonWriterOptions>` | The ambient [`JsonWriterOptions`](#JsonWriterOptions). *(optional)* |

**Returns:** `JsonWorkspace`

The [`JsonWorkspace`](#JsonWorkspace).

#### RentWriterAndBuffer

```csharp
Utf8JsonWriter RentWriterAndBuffer(int defaultBufferSize, ref IByteBufferWriter bufferWriter)
```

Rents a UTF-8 JSON writer and associated buffer writer from the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `defaultBufferSize` | `int` | The default buffer size to use for the buffer writer. |
| `bufferWriter` | `ref IByteBufferWriter` | When this method returns, contains the rented buffer writer. |

**Returns:** `Utf8JsonWriter`

A rented UTF-8 JSON writer configured with the workspace options.

#### RentWriter

```csharp
Utf8JsonWriter RentWriter(IBufferWriter<byte> bufferWriter)
```

Rents a UTF-8 JSON writer from the pool that writes to the specified buffer writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | `IBufferWriter<byte>` | The buffer writer to write JSON data to. |

**Returns:** `Utf8JsonWriter`

A rented UTF-8 JSON writer configured with the workspace options.

#### ReturnWriterAndBuffer

```csharp
void ReturnWriterAndBuffer(Utf8JsonWriter writer, IByteBufferWriter bufferWriter)
```

Returns a rented UTF-8 JSON writer and buffer writer to the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer to return to the pool. |
| `bufferWriter` | `IByteBufferWriter` | The buffer writer to return to the pool. |

#### ReturnWriter

```csharp
void ReturnWriter(Utf8JsonWriter writer)
```

Returns a rented UTF-8 JSON writer to the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer to return to the pool. |

#### Dispose

```csharp
void Dispose()
```

#### CreateBuilder

```csharp
JsonDocumentBuilder<TMutableElement> CreateBuilder<TElement, TMutableElement>(TElement sourceElement)
```

Creates a document builder for building mutable JSON documents from an existing element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the source JSON element. |
| `TMutableElement` | The type of the mutable JSON element to build. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sourceElement` | `TElement` | The source element to build from. |

**Returns:** `JsonDocumentBuilder<TMutableElement>`

A document builder for the mutable element type.

#### CreateBuilder

```csharp
JsonDocumentBuilder<TElement> CreateBuilder<TElement>(int initialCapacity, int initialValueBufferSize)
```

Creates a document builder for building mutable JSON documents.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the mutable JSON element to build. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialCapacity` | `int` | The initial capacity for the document builder. *(optional)* |
| `initialValueBufferSize` | `int` | The initial size of the value buffer. *(optional)* |

**Returns:** `JsonDocumentBuilder<TElement>`

A document builder for the specified element type.

---

## JsonWriterOptions (struct)

```csharp
public readonly struct JsonWriterOptions
```

Provides the ability for the user to define custom behavior when writing JSON using the [`Utf8JsonWriter`](#Utf8JsonWriter). By default, the JSON is written without any indentation or extra white space. Also, the [`Utf8JsonWriter`](#Utf8JsonWriter) will throw an exception if the user attempts to write structurally invalid JSON.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Encoder` | `JavaScriptEncoder` | The encoder to use when escaping strings, or `null` to use the default encoder. |
| `IndentCharacter` | `char` | Defines the indentation character used by [`Utf8JsonWriter`](#Utf8JsonWriter) when [`Indented`](#Indented) is enabled. Defaults to the space character. |
| `Indented` | `bool` | Defines whether the [`Utf8JsonWriter`](#Utf8JsonWriter) should pretty print the JSON which includes: indenting nested JSON tokens, adding new lines, and adding white space between property names an... |
| `IndentSize` | `int` | Defines the indentation size used by [`Utf8JsonWriter`](#Utf8JsonWriter) when [`Indented`](#Indented) is enabled. Defaults to two. |
| `MaxDepth` | `int` | Gets or sets the maximum depth allowed when writing JSON, with the default (i.e. 0) indicating a max depth of 1000. |
| `NewLine` | `string` | Gets or sets the new line string to use when [`Indented`](#Indented) is `true`. The default is the value of [`NewLine`](#NewLine). |
| `SkipValidation` | `bool` | Defines whether the [`Utf8JsonWriter`](#Utf8JsonWriter) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any attempts to write invalid ... |

#### IndentCharacter

```csharp
char IndentCharacter { get; set; }
```

Defines the indentation character used by [`Utf8JsonWriter`](#Utf8JsonWriter) when [`Indented`](#Indented) is enabled. Defaults to the space character.

Allowed characters are space and horizontal tab.

#### IndentSize

```csharp
int IndentSize { get; set; }
```

Defines the indentation size used by [`Utf8JsonWriter`](#Utf8JsonWriter) when [`Indented`](#Indented) is enabled. Defaults to two.

Allowed values are integers between 0 and 127, included.

#### MaxDepth

```csharp
int MaxDepth { get; set; }
```

Gets or sets the maximum depth allowed when writing JSON, with the default (i.e. 0) indicating a max depth of 1000.

Reading past this depth will throw a .

#### SkipValidation

```csharp
bool SkipValidation { get; set; }
```

Defines whether the [`Utf8JsonWriter`](#Utf8JsonWriter) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any attempts to write invalid JSON will result in a to be thrown.

If the JSON being written is known to be correct, then skipping validation (by setting it to true) could improve performance. An example of invalid JSON where the writer will throw (when SkipValidation is set to false) is when you write a value within a JSON object without a property name.

---

## Matcher<TMatch, TContext, TResult> (delegate)

```csharp
public delegate Matcher<TMatch, TContext, TResult> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TContext` | The context of the match. |
| `TResult` | The result of the match operation. |

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### Matcher

```csharp
Matcher(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
TResult Invoke(ref TMatch match, ref TContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |

**Returns:** `TResult`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TMatch match, ref TContext context, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
TResult EndInvoke(ref TMatch match, ref TContext context, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `TResult`

---

## Matcher<TMatch, TOut> (delegate)

```csharp
public delegate Matcher<TMatch, TOut> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TOut` | The result of the match operation. |

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### Matcher

```csharp
Matcher(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
TOut Invoke(ref TMatch match)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |

**Returns:** `TOut`

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TMatch match, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
TOut EndInvoke(ref TMatch match, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `result` | `IAsyncResult` |  |

**Returns:** `TOut`

---

## ObjectEnumerator<TValue> (struct)

```csharp
public readonly struct ObjectEnumerator<TValue> : IEnumerable<JsonProperty<TValue>>, IEnumerable, IEnumerator<JsonProperty<TValue>>, IEnumerator, IDisposable
```

An enumerable and enumerator for the properties of a JSON object.

### Inheritance

- Implements: `IEnumerable<JsonProperty<TValue>>`
- Implements: `IEnumerable`
- Implements: `IEnumerator<JsonProperty<TValue>>`
- Implements: `IEnumerator`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Current` | `JsonProperty<TValue>` |  |

### Methods

#### GetEnumerator

```csharp
ObjectEnumerator<TValue> GetEnumerator()
```

Returns an enumerator that iterates the properties of an object.

**Returns:** `ObjectEnumerator<TValue>`

An [`ObjectEnumerator`](#ObjectEnumerator) value that can be used to iterate through the object.

The enumerator will enumerate the properties in the order they are declared, and when an object has multiple definitions of a single property they will all individually be returned (each in the order they appear in the content).

#### Dispose

```csharp
void Dispose()
```

#### Reset

```csharp
void Reset()
```

#### MoveNext

```csharp
bool MoveNext()
```

**Returns:** `bool`

---

## ParsedJsonDocument<T> (class)

```csharp
public sealed class ParsedJsonDocument<T> : JsonDocument, IJsonDocument, IDisposable
```

Represents the structure of a JSON value in a lightweight, read-only form.

### Remarks

This class utilizes resources from pooled memory to minimize the garbage collector (GC) impact in high-usage scenarios. Failure to properly Dispose this object will result in the memory not being returned to the pool, which will cause an increase in GC impact across various parts of the framework.

### Inheritance

- Inherits from: `JsonDocument`
- Implements: `IJsonDocument`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` | The [`IJsonElement`](#IJsonElement) representing the value of the document. |
| `Null` `static` | `T` | Gets the null instance. |
| `True` `static` | `T` | Gets the True instance. |
| `False` `static` | `T` | Gets the False instance. |

### Methods

#### Dispose

```csharp
void Dispose()
```

#### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the document into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | The `writer` parameter is `null`. |
| `System.InvalidOperationException` | This [`RootElement`](#RootElement)'s [`ValueKind`](#ValueKind) would result in an invalid JSON. |
| `System.ObjectDisposedException` | The parent [`JsonDocument`](#JsonDocument) has been disposed. |

#### StringConstant `static`

```csharp
T StringConstant(byte[] quotedUtf8String)
```

Creates a constant string instance that does not require disposal.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `quotedUtf8String` | `byte[]` | The quoted UTF-8 string constant value. |

**Returns:** `T`

The instance.

This is used for fast initialization for a static value.

#### NumberConstant `static`

```csharp
T NumberConstant(byte[] utf8Number)
```

Creates a constant number instance that does not require disposal.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Number` | `byte[]` | The UTF-8 number constant value. |

**Returns:** `T`

The instance.

This is used for fast initialization for a static value.

#### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlyMemory<byte> utf8Json, JsonDocumentOptions options)
```

Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlyMemory<byte>` | JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

The [`ReadOnlyMemory`](#ReadOnlyMemory) value will be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

#### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlySequence<byte> utf8Json, JsonDocumentOptions options)
```

Parse a sequence as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlySequence<byte>` | JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

The [`ReadOnlySequence`](#ReadOnlySequence) may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime. Because the input is considered to be text, a UTF-8 Byte-Order-Mark (BOM) must not be present.

#### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(Stream utf8Json, JsonDocumentOptions options)
```

Parse a [`Stream`](#Stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `Stream` | JSON data to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### ParseAsync `static`

```csharp
Task<ParsedJsonDocument<T>> ParseAsync(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
```

Parse a [`Stream`](#Stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `Stream` | JSON data to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |
| `cancellationToken` | `CancellationToken` | The token to monitor for cancellation requests. *(optional)* |

**Returns:** `Task<ParsedJsonDocument<T>>`

A Task to produce a ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `utf8Json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(ReadOnlyMemory<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `ReadOnlyMemory<char>` | JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

The [`ReadOnlyMemory`](#ReadOnlyMemory) value may be used for the entire lifetime of the ParsedJsonDocument{T} object, and the caller must ensure that the data therein does not change during the object lifetime.

#### Parse `static`

```csharp
ParsedJsonDocument<T> Parse(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a ParsedJsonDocument.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `string` | JSON text to parse. |
| `options` | `JsonDocumentOptions` | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | `json` does not represent a valid single JSON value. |
| `System.ArgumentException` | `options` contains unsupported options. |

#### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref ParsedJsonDocument<T> document)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |
| `document` | `ref ParsedJsonDocument<T>` | Receives the parsed document. |

**Returns:** `bool`

`true` if a value was read and parsed into a ParsedJsonDocument, `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### ParseValue `static`

```csharp
ParsedJsonDocument<T> ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |

**Returns:** `ParsedJsonDocument<T>`

A ParsedJsonDocument{T} representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

---

## Period (struct)

```csharp
public readonly struct Period : IEquatable<Period>
```

Represents a period of time expressed in human chronological terms: hours, days, weeks, months and so on.

### Remarks

A [`Period`](#Period) contains a set of properties such as [`Years`](#Years), [`Months`](#Months), and so on that return the number of each unit contained within this period. Note that these properties are not normalized in any way by default, and so a [`Period`](#Period) may contain values such as "2 hours and 90 minutes". The [`Normalize`](#Normalize) method will convert equivalent periods into a standard representation. Periods can contain negative units as well as positive units ("+2 hours, -43 minutes, +10 seconds"), but do not differentiate between properties that are zero and those that are absent (i.e. a period created as "10 years" and one created as "10 years, zero months" are equal periods; the [`Months`](#Months) property returns zero in both cases). [`Period`](#Period) equality is implemented by comparing each property's values individually, without any normalization. (For example, a period of "24 hours" is not considered equal to a period of "1 day".) The static [`NormalizingEqualityComparer`](#NormalizingEqualityComparer) comparer provides an equality comparer which performs normalization before comparisons. There is no natural ordering for periods, but [`CreateComparer`](#CreateComparer) can be used to create a comparer which orders periods according to a reference date, by adding each period to that date and comparing the results. Periods operate on calendar-related types such as [`LocalDateTime`](#LocalDateTime) whereas [`Duration`](#Duration) operates on instants on the time line. (Note that although [`ZonedDateTime`](#ZonedDateTime) includes both concepts, it only supports duration-based arithmetic.) The complexity of each method in this type is hard to document precisely, and often depends on the calendar system involved in performing the actual calculations. Operations do not depend on the magnitude of the units in the period, other than for optimizations for values of zero or occasionally for particularly small values. For example, adding 10,000 days to a date does not require greater algorithmic complexity than adding 1,000 days to the same date.

### Inheritance

- Implements: `IEquatable<Period>`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `MaxValue` `static` | `Period` | A period containing the maximum value for all properties. |
| `MinValue` `static` | `Period` | A period containing the minimum value for all properties. |
| `Zero` `static` | `Period` | Gets a period containing only zero-valued properties. |
| `NormalizingEqualityComparer` `static` | `IEqualityComparer<Period>` | Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the [`Normalize`](#Normalize) method, years and months... |
| `Nanoseconds` | `long` | Gets the number of nanoseconds within this period. |
| `Ticks` | `long` | Gets the number of ticks within this period. |
| `Milliseconds` | `long` | Gets the number of milliseconds within this period. |
| `Seconds` | `long` | Gets the number of seconds within this period. |
| `Minutes` | `long` | Gets the number of minutes within this period. |
| `Hours` | `long` | Gets the number of hours within this period. |
| `Days` | `int` | Gets the number of days within this period. |
| `Weeks` | `int` | Gets the number of weeks within this period. |
| `Months` | `int` | Gets the number of months within this period. |
| `Years` | `int` | Gets the number of years within this period. |
| `HasTimeComponent` | `bool` | Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower). |
| `HasDateComponent` | `bool` | Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher). |

#### MaxValue

```csharp
Period MaxValue { get; }
```

A period containing the maximum value for all properties.

**Value:** A period containing the maximum value for all properties.

#### MinValue

```csharp
Period MinValue { get; }
```

A period containing the minimum value for all properties.

**Value:** A period containing the minimum value for all properties.

#### NormalizingEqualityComparer

```csharp
IEqualityComparer<Period> NormalizingEqualityComparer { get; }
```

Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the [`Normalize`](#Normalize) method, years and months are unchanged by normalization - so 12 months does not equal 1 year.

**Value:** An equality comparer which compares periods by first normalizing them.

#### Nanoseconds

```csharp
long Nanoseconds { get; }
```

Gets the number of nanoseconds within this period.

**Value:** The number of nanoseconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Ticks

```csharp
long Ticks { get; }
```

Gets the number of ticks within this period.

**Value:** The number of ticks within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Milliseconds

```csharp
long Milliseconds { get; }
```

Gets the number of milliseconds within this period.

**Value:** The number of milliseconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Seconds

```csharp
long Seconds { get; }
```

Gets the number of seconds within this period.

**Value:** The number of seconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Minutes

```csharp
long Minutes { get; }
```

Gets the number of minutes within this period.

**Value:** The number of minutes within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Hours

```csharp
long Hours { get; }
```

Gets the number of hours within this period.

**Value:** The number of hours within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Days

```csharp
int Days { get; }
```

Gets the number of days within this period.

**Value:** The number of days within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Weeks

```csharp
int Weeks { get; }
```

Gets the number of weeks within this period.

**Value:** The number of weeks within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Months

```csharp
int Months { get; }
```

Gets the number of months within this period.

**Value:** The number of months within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### Years

```csharp
int Years { get; }
```

Gets the number of years within this period.

**Value:** The number of years within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

#### HasTimeComponent

```csharp
bool HasTimeComponent { get; }
```

Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower).

**Value:** true if the period contains any non-zero-valued time-based properties (hours or lower); false otherwise.

#### HasDateComponent

```csharp
bool HasDateComponent { get; }
```

Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher).

**Value:** true if this period contains any non-zero date-based properties (days or higher); false otherwise.

### Methods

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> value, ref Period result)
```

Parses a string into a Period.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The string to parse. |
| `result` | `ref Period` | The resulting period. |

**Returns:** `bool`

`true` if the period could be parsed from the string.

#### FromYears `static`

```csharp
Period FromYears(int years)
```

Creates a period representing the specified number of years.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `years` | `int` | The number of years in the new period. |

**Returns:** `Period`

A period consisting of the given number of years.

#### FromMonths `static`

```csharp
Period FromMonths(int months)
```

Creates a period representing the specified number of months.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `months` | `int` | The number of months in the new period. |

**Returns:** `Period`

A period consisting of the given number of months.

#### FromWeeks `static`

```csharp
Period FromWeeks(int weeks)
```

Creates a period representing the specified number of weeks.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `weeks` | `int` | The number of weeks in the new period. |

**Returns:** `Period`

A period consisting of the given number of weeks.

#### FromDays `static`

```csharp
Period FromDays(int days)
```

Creates a period representing the specified number of days.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `days` | `int` | The number of days in the new period. |

**Returns:** `Period`

A period consisting of the given number of days.

#### FromHours `static`

```csharp
Period FromHours(long hours)
```

Creates a period representing the specified number of hours.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | `long` | The number of hours in the new period. |

**Returns:** `Period`

A period consisting of the given number of hours.

#### FromMinutes `static`

```csharp
Period FromMinutes(long minutes)
```

Creates a period representing the specified number of minutes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minutes` | `long` | The number of minutes in the new period. |

**Returns:** `Period`

A period consisting of the given number of minutes.

#### FromSeconds `static`

```csharp
Period FromSeconds(long seconds)
```

Creates a period representing the specified number of seconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `seconds` | `long` | The number of seconds in the new period. |

**Returns:** `Period`

A period consisting of the given number of seconds.

#### FromMilliseconds `static`

```csharp
Period FromMilliseconds(long milliseconds)
```

Creates a period representing the specified number of milliseconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `milliseconds` | `long` | The number of milliseconds in the new period. |

**Returns:** `Period`

A period consisting of the given number of milliseconds.

#### FromTicks `static`

```csharp
Period FromTicks(long ticks)
```

Creates a period representing the specified number of ticks.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ticks` | `long` | The number of ticks in the new period. |

**Returns:** `Period`

A period consisting of the given number of ticks.

#### FromNanoseconds `static`

```csharp
Period FromNanoseconds(long nanoseconds)
```

Creates a period representing the specified number of nanoseconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `nanoseconds` | `long` | The number of nanoseconds in the new period. |

**Returns:** `Period`

A period consisting of the given number of nanoseconds.

#### Add `static`

```csharp
Period Add(Period left, Period right)
```

Adds two periods together, by simply adding the values for each property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `left` | `Period` | The first period to add. |
| `right` | `Period` | The second period to add. |

**Returns:** `Period`

The sum of the two periods. The units of the result will be the union of those in both periods.

#### CreateComparer `static`

```csharp
IComparer<Period> CreateComparer(LocalDateTime baseDateTime)
```

Creates an [`IComparer`](#IComparer) for periods, using the given "base" local date/time.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `baseDateTime` | `LocalDateTime` | The base local date/time to use for comparisons. |

**Returns:** `IComparer<Period>`

The new comparer.

Certain periods can't naturally be compared without more context - how "one month" compares to "30 days" depends on where you start. In order to compare two periods, the returned comparer effectively adds both periods to the "base" specified by `baseDateTime` and compares the results. In some cases this arithmetic isn't actually required - when two periods can be converted to durations, the comparer uses that conversion for efficiency.

#### Subtract `static`

```csharp
Period Subtract(Period minuend, Period subtrahend)
```

Subtracts one period from another, by simply subtracting each property value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minuend` | `Period` | The period to subtract the second operand from. |
| `subtrahend` | `Period` | The period to subtract the first operand from. |

**Returns:** `Period`

The result of subtracting all the values in the second operand from the values in the first. The units of the result will be the union of both periods, even if the subtraction caused some properties to become zero (so "2 weeks, 1 days" minus "2 weeks" is "zero weeks, 1 days", not "1 days").

#### DaysBetween `static`

```csharp
int DaysBetween(LocalDate start, LocalDate end)
```

Returns the number of days between two [`LocalDate`](#LocalDate) objects.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `start` | `LocalDate` | Start date/time. |
| `end` | `LocalDate` | End date/time. |

**Returns:** `int`

The number of days between the given dates.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `start` and `end` use different calendars. |

#### PeriodParser `static`

```csharp
bool PeriodParser(ReadOnlySpan<byte> text, ref PeriodBuilder builder)
```

A parser for a json period.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The text to parse. |
| `builder` | `ref PeriodBuilder` | The resulting period builder. |

**Returns:** `bool`

A period builder parsed from the read only span.

#### ToDuration

```csharp
Duration ToDuration()
```

For periods that do not contain a non-zero number of years or months, returns a duration for this period assuming a standard 7-day week, 24-hour day, 60-minute hour etc.

**Returns:** `Duration`

The duration of the period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The month or year property in the period is non-zero. |
| `System.OverflowException` | The period doesn't have years or months, but the calculation overflows the bounds of [`Duration`](#Duration). In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this - in realistic periods, it shouldn't be a problem. |

#### Normalize

```csharp
Period Normalize()
```

Returns a normalized version of this period, such that equivalent (but potentially non-equal) periods are changed to the same representation.

**Returns:** `Period`

The normalized period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.OverflowException` | The period doesn't have years or months, but it contains more than [`MaxValue`](#MaxValue) nanoseconds when the combined weeks/days/time portions are considered. This is over 292 years, so unlikely to be a problem in normal usage. In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this. |

Months and years are unchanged (as they can vary in length), but weeks are multiplied by 7 and added to the Days property, and all time properties are normalized to their natural range. Sub-second values are normalized to millisecond and "nanosecond within millisecond" values. So for example, a period of 25 hours becomes a period of 1 day and 1 hour. A period of 1,500,750,000 nanoseconds becomes 1 second, 500 milliseconds and 750,000 nanoseconds. Aside from months and years, either all the properties end up positive, or they all end up negative. "Week" and "tick" units in the returned period are always 0.

#### ToString `virtual`

```csharp
string ToString()
```

Returns this string formatted according to the ISO8601 duration specification used by JSON schema.

**Returns:** `string`

A formatted representation of this period.

#### Equals `virtual`

```csharp
bool Equals(object other)
```

Compares the given object for equality with this one, as per [`Equals`](#Equals). See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `object` | The value to compare this one with. |

**Returns:** `bool`

true if the other object is a period equal to this one, consistent with [`Equals`](#Equals).

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Returns the hash code for this period, consistent with [`Equals`](#Equals). See the type documentation for a description of equality semantics.

**Returns:** `int`

The hash code for this period.

#### Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `Period` | The period to compare this one with. |

**Returns:** `bool`

True if this period has the same values for the same properties as the one specified.

#### Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `Period` | The period to compare this one with. |

**Returns:** `bool`

True if this period has the same values for the same properties as the one specified.

---

## PeriodBuilder (struct)

```csharp
public readonly struct PeriodBuilder
```

A mutable builder class for [`Period`](#Period) values. Each property can be set independently, and then a Period can be created from the result using the [`BuildPeriod`](#BuildPeriod) method.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Days` | `int` | Gets or sets the number of days within the period. |
| `Hours` | `long` | Gets or sets the number of hours within the period. |
| `Milliseconds` | `long` | Gets or sets the number of milliseconds within the period. |
| `Minutes` | `long` | Gets or sets the number of minutes within the period. |
| `Months` | `int` | Gets or sets the number of months within the period. |
| `Nanoseconds` | `long` | Gets or sets the number of nanoseconds within the period. |
| `Seconds` | `long` | Gets or sets the number of seconds within the period. |
| `Ticks` | `long` | Gets or sets the number of ticks within the period. |
| `Weeks` | `int` | Gets or sets the number of weeks within the period. |
| `Years` | `int` | Gets or sets the number of years within the period. |
| `Item` | `long` |  |

#### Days

```csharp
int Days { get; set; }
```

Gets or sets the number of days within the period.

**Value:** The number of days within the period.

#### Hours

```csharp
long Hours { get; set; }
```

Gets or sets the number of hours within the period.

**Value:** The number of hours within the period.

#### Milliseconds

```csharp
long Milliseconds { get; set; }
```

Gets or sets the number of milliseconds within the period.

**Value:** The number of milliseconds within the period.

#### Minutes

```csharp
long Minutes { get; set; }
```

Gets or sets the number of minutes within the period.

**Value:** The number of minutes within the period.

#### Months

```csharp
int Months { get; set; }
```

Gets or sets the number of months within the period.

**Value:** The number of months within the period.

#### Nanoseconds

```csharp
long Nanoseconds { get; set; }
```

Gets or sets the number of nanoseconds within the period.

**Value:** The number of nanoseconds within the period.

#### Seconds

```csharp
long Seconds { get; set; }
```

Gets or sets the number of seconds within the period.

**Value:** The number of seconds within the period.

#### Ticks

```csharp
long Ticks { get; set; }
```

Gets or sets the number of ticks within the period.

**Value:** The number of ticks within the period.

#### Weeks

```csharp
int Weeks { get; set; }
```

Gets or sets the number of weeks within the period.

**Value:** The number of weeks within the period.

#### Years

```csharp
int Years { get; set; }
```

Gets or sets the number of years within the period.

**Value:** The number of years within the period.

### Methods

#### BuildPeriod

```csharp
Period BuildPeriod()
```

Builds a period from the properties in this builder.

**Returns:** `Period`

The total number of nanoseconds in the period.

---

## RawUtf8JsonString (struct)

```csharp
public readonly struct RawUtf8JsonString : IDisposable
```

Represents a raw UTF-8 JSON string.

### Remarks

This may use a rented buffer to back the string, so it is disposable.

### Inheritance

- Implements: `IDisposable`

### Constructors

#### RawUtf8JsonString

```csharp
RawUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

Initializes a new instance of the [`RawUtf8JsonString`](#RawUtf8JsonString) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | `ReadOnlyMemory<byte>` | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | `byte[]` | Additional rented bytes from the array pool, if any. *(optional)* |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | `ReadOnlyMemory<byte>` | Gets the underlying UTF-8 bytes as a [`ReadOnlyMemory`](#ReadOnlyMemory). |
| `Span` | `ReadOnlySpan<byte>` | Gets the underlying UTF-8 bytes as a [`ReadOnlySpan`](#ReadOnlySpan). |

### Methods

#### TakeOwnership

```csharp
ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

Takes ownership of the underlying memory and any extra rented array pool bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | `ref byte[]` | When this method returns, contains the extra rented array pool bytes, if any. |

**Returns:** `ReadOnlyMemory<byte>`

The underlying UTF-8 bytes memory.

#### Dispose

```csharp
void Dispose()
```

Releases any rented array pool bytes and clears sensitive data.

---

## UnescapedUtf16JsonString (struct)

```csharp
public readonly struct UnescapedUtf16JsonString : IDisposable
```

Represents an Unescaped UTF-16 JSON string.

### Remarks

This uses a rented buffer to back the string, so it is disposable.

### Inheritance

- Implements: `IDisposable`

### Constructors

#### UnescapedUtf16JsonString

```csharp
UnescapedUtf16JsonString(ReadOnlyMemory<char> chars, char[] extraRentedArrayPoolChars)
```

Initializes a new instance of the [`UnescapedUtf16JsonString`](#UnescapedUtf16JsonString) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `chars` | `ReadOnlyMemory<char>` | The UTF-16 characters representing the JSON string. |
| `extraRentedArrayPoolChars` | `char[]` | Optional rented array pool characters. *(optional)* |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | `ReadOnlyMemory<char>` | Gets the UTF-16 characters as a read-only memory. |
| `Span` | `ReadOnlySpan<char>` | Gets the UTF-16 characters as a read-only span. |

### Methods

#### TakeOwnership

```csharp
ReadOnlyMemory<char> TakeOwnership(ref char[] extraRentedArrayPoolChars)
```

Take ownership of the [`Shared`](#Shared) characters, if any.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolChars` | `ref char[]` | The rented characters, or null if there are no rented characters. |

**Returns:** `ReadOnlyMemory<char>`

The UTF-16 memory representing the rented characters.

#### Dispose

```csharp
void Dispose()
```

Disposes the unescaped UTF-16 JSON string, returning any rented array pool characters.

---

## UnescapedUtf8JsonString (struct)

```csharp
public readonly struct UnescapedUtf8JsonString : IDisposable
```

Represents an Unescaped UTF-8 JSON string.

### Remarks

This may use a rented buffer to back the string, so it is disposable.

### Inheritance

- Implements: `IDisposable`

### Constructors

#### UnescapedUtf8JsonString

```csharp
UnescapedUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

Initializes a new instance of the [`UnescapedUtf8JsonString`](#UnescapedUtf8JsonString) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | `ReadOnlyMemory<byte>` | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | `byte[]` | Optional rented array pool bytes. *(optional)* |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | `ReadOnlyMemory<byte>` | Gets the UTF-8 bytes as a read-only memory. |
| `Span` | `ReadOnlySpan<byte>` | Gets the UTF-8 bytes as a read-only span. |

### Methods

#### TakeOwnership

```csharp
ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

Take ownership of the [`Shared`](#Shared) bytes, if any.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | `ref byte[]` | The rented bytes, or null if there are no rented bytes. |

**Returns:** `ReadOnlyMemory<byte>`

The UTF-8 memory representing the rented bytes.

#### Dispose

```csharp
void Dispose()
```

Disposes the unescaped UTF-8 JSON string, returning any rented array pool bytes.

---

## Utf8Iri (struct)

```csharp
public readonly struct Utf8Iri
```

A UTF-8 IRI.

### Remarks

```csharp foo://user@example.com:8042/over/there?name=ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Authority` | `ReadOnlySpan<byte>` | Gets the authority component of the reference. |
| `Fragment` | `ReadOnlySpan<byte>` | Gets the fragment component of the reference. |
| `HasAuthority` | `bool` | Gets a value indicating whether this reference has an authority. |
| `HasFragment` | `bool` | Gets a value indicating whether this reference has a fragment. |
| `HasHost` | `bool` | Gets a value indicating whether this reference has a host. |
| `HasPath` | `bool` | Gets a value indicating whether this reference has a path. |
| `HasPort` | `bool` | Gets a value indicating whether this reference has a port. |
| `HasQuery` | `bool` | Gets a value indicating whether this reference has a query. |
| `HasScheme` | `bool` | Gets a value indicating whether this reference has a scheme. |
| `HasUser` | `bool` | Gets a value indicating whether this reference has a user. |
| `Host` | `ReadOnlySpan<byte>` | Gets the host component of the reference (includes both host and port). |
| `IsDefaultPort` | `bool` | Gets a value indicating whether this is the default port for the scheme. |
| `IsRelative` | `bool` | Gets a value indicating whether this is a relative IRI. |
| `IsValid` | `bool` | Gets a value indicating whether this is a valid IRI. |
| `OriginalIri` | `ReadOnlySpan<byte>` | Gets the original (fully encoded) string. |
| `Path` | `ReadOnlySpan<byte>` | Gets the path component of the IRI. |
| `Port` | `ReadOnlySpan<byte>` | Gets the port component of the IRI as a byte span. |
| `PortValue` | `int` | Gets the port value as an integer. |
| `Query` | `ReadOnlySpan<byte>` | Gets the query component of the IRI. |
| `Scheme` | `ReadOnlySpan<byte>` | Gets the scheme component of the IRI. |
| `User` | `ReadOnlySpan<byte>` | Gets the user component of the IRI. |

### Methods

#### CreateIri `static`

```csharp
Utf8Iri CreateIri(ReadOnlySpan<byte> iri)
```

Creates a new UTF-8 IRI from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ReadOnlySpan<byte>` | The IRI bytes from which to create the UTF-8 IRI. |

**Returns:** `Utf8Iri`

A new UTF-8 IRI.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the IRI is invalid. |

#### TryCreateIri `static`

```csharp
bool TryCreateIri(ReadOnlySpan<byte> iri, ref Utf8Iri utf8Iri)
```

Tries to create a new UTF-8 IRI from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ReadOnlySpan<byte>` | The IRI bytes from which to create the UTF-8 IRI. |
| `utf8Iri` | `ref Utf8Iri` | When this method returns, contains the created UTF-8 IRI if successful; otherwise, the default value. |

**Returns:** `bool`

`true` if the UTF-8 IRI was created successfully; otherwise, `false`.

#### GetUri

```csharp
Uri GetUri()
```

Gets the value as a [`Uri`](#Uri).

**Returns:** `Uri`

The URI representation of the UTF-8 IRI.

#### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the IRI in canonical form for display.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryFormatCanonical

```csharp
bool TryFormatCanonical(Span<byte> buffer, ref int writtenBytes)
```

Gets the IRI in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Iri iri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ref Utf8Iri` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8IriReference iriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | `ref Utf8IriReference` | The IRI reference to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `ref Utf8UriReference` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ref Utf8Uri` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryMakeRelative

```csharp
bool TryMakeRelative(ref Utf8Iri targetIri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target IRI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target IRI is returned.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetIri` | `ref Utf8Iri` | The target IRI to make relative. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8IriReference` | The resulting IRI reference (relative or absolute). |

**Returns:** `bool`

`true` if the result was successfully written; otherwise, `false`.

#### TryMakeRelative

```csharp
bool TryMakeRelative(ref Utf8Uri targetUri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetUri` | `ref Utf8Uri` | The target URI to make relative. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8IriReference` | The resulting IRI reference (relative or absolute). |

**Returns:** `bool`

`true` if the result was successfully written; otherwise, `false`.

#### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the IRI in display format.

**Returns:** `string`

A string representation of the IRI.

---

## Utf8IriReference (struct)

```csharp
public readonly struct Utf8IriReference
```

A UTF-8 IRI Reference.

### Remarks

```csharp foo://user@example.com:8042/over/there?name=ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Authority` | `ReadOnlySpan<byte>` | Gets the authority component of the reference. |
| `Fragment` | `ReadOnlySpan<byte>` | Gets the fragment component of the reference. |
| `HasAuthority` | `bool` | Gets a value indicating whether this reference has an authority. |
| `HasFragment` | `bool` | Gets a value indicating whether this reference has a fragment. |
| `HasHost` | `bool` | Gets a value indicating whether this reference has a host. |
| `HasPath` | `bool` | Gets a value indicating whether this reference has a path. |
| `HasPort` | `bool` | Gets a value indicating whether this reference has a port. |
| `HasQuery` | `bool` | Gets a value indicating whether this reference has a query. |
| `HasScheme` | `bool` | Gets a value indicating whether this reference has a scheme. |
| `HasUser` | `bool` | Gets a value indicating whether this reference has a user. |
| `Host` | `ReadOnlySpan<byte>` | Gets the host component of the reference (includes both host and port). |
| `IsDefaultPort` | `bool` | Gets a value indicating whether this is the default port for the scheme. |
| `IsRelative` | `bool` | Gets a value indicating whether this is a relative reference. |
| `IsValid` | `bool` | Gets a value indicating whether this is a valid reference. |
| `OriginalIriReference` | `ReadOnlySpan<byte>` | Gets the original string. |
| `Path` | `ReadOnlySpan<byte>` | Gets the path component of the reference. |
| `Port` | `ReadOnlySpan<byte>` | Gets the port component of the reference as a byte span. |
| `PortValue` | `int` | Gets the port value as an integer. |
| `Query` | `ReadOnlySpan<byte>` | Gets the query component of the reference. |
| `Scheme` | `ReadOnlySpan<byte>` | Gets the scheme component of the reference. |
| `User` | `ReadOnlySpan<byte>` | Gets the user component of the reference. |

### Methods

#### CreateIriReference `static`

```csharp
Utf8IriReference CreateIriReference(ReadOnlySpan<byte> iri)
```

Creates a new UTF-8 IRI Reference from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ReadOnlySpan<byte>` | The IRI bytes to create the reference from. |

**Returns:** `Utf8IriReference`

A new UTF-8 IRI Reference.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the IRI is invalid. |

#### TryCreateIriReference `static`

```csharp
bool TryCreateIriReference(ReadOnlySpan<byte> iri, ref Utf8IriReference utf8Iri)
```

Tries to create a new UTF-8 IRI Reference from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ReadOnlySpan<byte>` | The IRI bytes from which to create the UTF-8 IRI from. |
| `utf8Iri` | `ref Utf8IriReference` | When this method returns, contains the created UTF-8 IRI reference if successful; otherwise, the default value. |

**Returns:** `bool`

`true` if the UTF-8 IRI Reference was created successfully; otherwise, `false`.

#### GetUri

```csharp
Uri GetUri()
```

Gets the value as a [`Uri`](#Uri).

**Returns:** `Uri`

The URI representation of the reference.

#### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the IRI reference in canonical form for display.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryFormatCanonical

```csharp
bool TryFormatCanonical(Span<byte> buffer, ref int writtenBytes)
```

Gets the IRI reference in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Iri iri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `ref Utf8Iri` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8IriReference iriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | `ref Utf8IriReference` | The IRI reference to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `ref Utf8UriReference` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ref Utf8Uri` | The IRI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Iri` | The resulting IRI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

#### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the IRI reference in display format.

**Returns:** `string`

A string representation of the IRI reference.

---

## Utf8IriReferenceValue (struct)

```csharp
public readonly struct Utf8IriReferenceValue : IDisposable
```

A UTF-8 IRI reference value that has been parsed from a JSON document.

### Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IriReference` | `Utf8IriReference` | Gets the UTF-8 IRI reference value. |

### Methods

#### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8IriReferenceValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8IriReferenceValue`](#Utf8IriReferenceValue).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | `int` | The index of the element. |
| `value` | `ref Utf8IriReferenceValue` | The [`Utf8IriReferenceValue`](#Utf8IriReferenceValue) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the IRI reference value.

---

## Utf8IriValue (struct)

```csharp
public readonly struct Utf8IriValue : IDisposable
```

A UTF-8 IRI value that has been parsed from a JSON document.

### Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Iri` | `Utf8Iri` | Gets the UTF-8 IRI value. |

### Methods

#### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8IriValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8IriValue`](#Utf8IriValue).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | `int` | The index of the element. |
| `value` | `ref Utf8IriValue` | The [`Utf8IriValue`](#Utf8IriValue) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the IRI value.

---

## Utf8JsonPointer (struct)

```csharp
public readonly struct Utf8JsonPointer
```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsValid` | `bool` | Gets a value indicating whether this is a valid IRI. |

### Methods

#### TryCreateJsonPointer `static`

```csharp
bool TryCreateJsonPointer(ReadOnlySpan<byte> jsonPointer, ref Utf8JsonPointer utf8JsonPointer)
```

Tries to create a new UTF-8 JSON Pointer from the specified UTF-8 bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | `ReadOnlySpan<byte>` | The UTF-8 bytes from which to create the UTF-8 JSON Pointer. |
| `utf8JsonPointer` | `ref Utf8JsonPointer` | When this method returns, contains the created UTF-8 JSON Pointer if successful; otherwise, the default value. |

**Returns:** `bool`

`true` if the UTF-8 JSON Pointer was created successfully; otherwise, `false`.

#### TryResolve

```csharp
bool TryResolve<T, TResult>(ref T jsonElement, ref TResult value)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the value at that path if it exists.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |
| `TResult` | The type of the element at the target. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `value` | `ref TResult` | The value at the target path if it exists. |

**Returns:** `bool`

`true` if the value was resolved successfully; otherwise, `false`.

#### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset<T>(ref T jsonElement, ref int line, ref int charOffset, ref long lineByteOffset)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the 1-based line number and character offset of the target element in the original source document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `line` | `ref int` | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | `ref int` | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | `ref long` | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** `bool`

`true` if the pointer was resolved and the line and offset were determined; otherwise, `false`.

---

## Utf8JsonReader (struct)

```csharp
public readonly struct Utf8JsonReader
```

Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default (https://tools.ietf.org/html/rfc8259). When it encounters invalid JSON, it throws a JsonException with basic error information like line number and byte position on the line. Since this type is a ref struct, it does not directly support async. However, it does provide support for reentrancy to read incomplete data, and continue reading once more data is presented. To be able to set max depth while reading OR allow skipping comments, create an instance of [`JsonReaderState`](#JsonReaderState) and pass that in to the reader.

### Constructors

#### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySpan<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

Constructs a new [`Utf8JsonReader`](#Utf8JsonReader) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | `ReadOnlySpan<byte>` | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | `bool` | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | `JsonReaderState` | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](#Utf8JsonReader) and pass that back. |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](#JsonReaderState).

#### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySpan<byte> jsonData, JsonReaderOptions options)
```

Constructs a new [`Utf8JsonReader`](#Utf8JsonReader) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | `ReadOnlySpan<byte>` | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | `JsonReaderOptions` | Defines the customized behavior of the [`Utf8JsonReader`](#Utf8JsonReader) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](#Utf8JsonReader) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](#IsFinalBlock) = true)

#### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySequence<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

Constructs a new [`Utf8JsonReader`](#Utf8JsonReader) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | `ReadOnlySequence<byte>` | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | `bool` | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | `JsonReaderState` | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](#Utf8JsonReader) and pass that back. |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](#JsonReaderState).

#### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySequence<byte> jsonData, JsonReaderOptions options)
```

Constructs a new [`Utf8JsonReader`](#Utf8JsonReader) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | `ReadOnlySequence<byte>` | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | `JsonReaderOptions` | Defines the customized behavior of the [`Utf8JsonReader`](#Utf8JsonReader) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](#Utf8JsonReader) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](#IsFinalBlock) = true)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueSpan` | `ReadOnlySpan<byte>` | Gets the value of the last processed token as a ReadOnlySpan<byte> slice of the input payload. If the JSON is provided within a ReadOnlySequence<byte> and the slice that represents the token value ... |
| `BytesConsumed` | `long` | Returns the total amount of bytes consumed by the [`Utf8JsonReader`](#Utf8JsonReader) so far for the current instance of the [`Utf8JsonReader`](#Utf8JsonReader) with the given UTF-8 encoded input t... |
| `TokenStartIndex` | `long` | Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space. |
| `CurrentDepth` | `int` | Tracks the recursive depth of the nested objects / arrays within the JSON text processed so far. This provides the depth of the current token. |
| `TokenType` | `JsonTokenType` | Gets the type of the last processed JSON token in the UTF-8 encoded JSON text. |
| `HasValueSequence` | `bool` | Lets the caller know which of the two 'Value' properties to read to get the token value. For input data within a ReadOnlySpan<byte> this will always return false. For input data within a ReadOnlySe... |
| `ValueIsEscaped` | `bool` | Lets the caller know whether the current [`ValueSpan`](#ValueSpan) or [`ValueSequence`](#ValueSequence) properties contain escape sequences per RFC 8259 section 7, and therefore require unescaping ... |
| `IsFinalBlock` | `bool` | Returns the mode of this instance of the [`Utf8JsonReader`](#Utf8JsonReader). True when the reader was constructed with the input span containing the entire data to process. False when the reader w... |
| `ValueSequence` | `ReadOnlySequence<byte>` | Gets the value of the last processed token as a ReadOnlySpan<byte> slice of the input payload. If the JSON is provided within a ReadOnlySequence<byte> and the slice that represents the token value ... |
| `Position` | `SequencePosition` | Returns the current [`SequencePosition`](#SequencePosition) within the provided UTF-8 encoded input ReadOnlySequence<byte>. If the [`Utf8JsonReader`](#Utf8JsonReader) was constructed with a ReadOnl... |
| `CurrentState` | `JsonReaderState` | Returns the current snapshot of the [`Utf8JsonReader`](#Utf8JsonReader) state which must be captured by the caller and passed back in to the [`Utf8JsonReader`](#Utf8JsonReader) ctor with more data.... |

#### ValueSpan

```csharp
ReadOnlySpan<byte> ValueSpan { get; set; }
```

Gets the value of the last processed token as a ReadOnlySpan<byte> slice of the input payload. If the JSON is provided within a ReadOnlySequence<byte> and the slice that represents the token value fits in a single segment, then [`ValueSpan`](#ValueSpan) will contain the sliced value since it can be represented as a span. Otherwise, the [`ValueSequence`](#ValueSequence) will contain the token value.

If [`HasValueSequence`](#HasValueSequence) is true, [`ValueSpan`](#ValueSpan) contains useless data, likely for a previous single-segment token. Therefore, only access [`ValueSpan`](#ValueSpan) if [`HasValueSequence`](#HasValueSequence) is false. Otherwise, the token value must be accessed from [`ValueSequence`](#ValueSequence).

#### TokenStartIndex

```csharp
long TokenStartIndex { get; set; }
```

Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space.

For JSON strings (including property names), this points to before the start quote. For comments, this points to before the first comment delimiter (i.e. '/').

#### ValueSequence

```csharp
ReadOnlySequence<byte> ValueSequence { get; set; }
```

Gets the value of the last processed token as a ReadOnlySpan<byte> slice of the input payload. If the JSON is provided within a ReadOnlySequence<byte> and the slice that represents the token value fits in a single segment, then [`ValueSpan`](#ValueSpan) will contain the sliced value since it can be represented as a span. Otherwise, the [`ValueSequence`](#ValueSequence) will contain the token value.

If [`HasValueSequence`](#HasValueSequence) is false, [`ValueSequence`](#ValueSequence) contains useless data, likely for a previous multi-segment token. Therefore, only access [`ValueSequence`](#ValueSequence) if [`HasValueSequence`](#HasValueSequence) is true. Otherwise, the token value must be accessed from [`ValueSpan`](#ValueSpan).

### Methods

#### Read

```csharp
bool Read()
```

Read the next JSON token from input source.

**Returns:** `bool`

True if the token was read successfully, else false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | Thrown when an invalid JSON token is encountered according to the JSON RFC or if the current depth exceeds the recursive limit set by the max depth. |

#### Skip

```csharp
void Skip()
```

Skips the children of the current JSON token.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown when the reader was given partial data with more data to follow (i.e. [`IsFinalBlock`](#IsFinalBlock) is false). |
| `Corvus.Text.Json.JsonException` | Thrown when an invalid JSON token is encountered while skipping, according to the JSON RFC, or if the current depth exceeds the recursive limit set by the max depth. |

When [`TokenType`](#TokenType) is [`PropertyName`](#PropertyName), the reader first moves to the property value. When [`TokenType`](#TokenType) (originally, or after advancing) is [`StartObject`](#StartObject) or [`StartArray`](#StartArray), the reader advances to the matching [`EndObject`](#EndObject) or [`EndArray`](#EndArray). For all other token types, the reader does not move. After the next call to [`Read`](#Read), the reader will be at the next value (when in an array), the next property name (when in an object), or the end array/object token.

#### TrySkip

```csharp
bool TrySkip()
```

Tries to skip the children of the current JSON token.

**Returns:** `bool`

True if there was enough data for the children to be skipped successfully, else false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | Thrown when an invalid JSON token is encountered while skipping, according to the JSON RFC, or if the current depth exceeds the recursive limit set by the max depth. |

If the reader did not have enough data to completely skip the children of the current token, it will be reset to the state it was in before the method was called. When [`TokenType`](#TokenType) is [`PropertyName`](#PropertyName), the reader first moves to the property value. When [`TokenType`](#TokenType) (originally, or after advancing) is [`StartObject`](#StartObject) or [`StartArray`](#StartArray), the reader advances to the matching [`EndObject`](#EndObject) or [`EndArray`](#EndArray). For all other token types, the reader does not move. After the next call to [`Read`](#Read), the reader will be at the next value (when in an array), the next property name (when in an object), or the end array/object token.

#### ValueTextEquals

```csharp
bool ValueTextEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the UTF-8 encoded text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text to compare against. |

**Returns:** `bool`

True if the JSON token value in the source matches the UTF-8 encoded look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](#String) or [`PropertyName`](#PropertyName)). |

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

#### ValueTextEquals

```csharp
bool ValueTextEquals(string text)
```

Compares the string text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `string` | The text to compare against. |

**Returns:** `bool`

True if the JSON token value in the source matches the look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](#String) or [`PropertyName`](#PropertyName)). |

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

#### ValueTextEquals

```csharp
bool ValueTextEquals(ReadOnlySpan<char> text)
```

Compares the text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<char>` | The text to compare against. |

**Returns:** `bool`

True if the JSON token value in the source matches the look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](#String) or [`PropertyName`](#PropertyName)). |

If the look up text is invalid or incomplete UTF-16 text (i.e. unpaired surrogates), the method will return false since you cannot have invalid UTF-16 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

#### CopyString

```csharp
int CopyString(Span<byte> utf8Destination)
```

Copies the current JSON token value from the source, unescaped as a UTF-8 string to the destination buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | `Span<byte>` | A buffer to write the unescaped UTF-8 bytes into. |

**Returns:** `int`

The number of bytes written to `utf8Destination`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](#String) or [`PropertyName`](#PropertyName). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| `System.ArgumentException` | The destination buffer is too small to hold the unescaped value. |

Unlike [`GetString`](#GetString), this method does not support [`Null`](#Null). This method will throw [`ArgumentException`](#ArgumentException) if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](#ValueSpan) or [`ValueSequence`](#ValueSequence), since the unescaped result is always less than or equal to the length of the encoded strings.

#### CopyString

```csharp
int CopyString(Span<char> destination)
```

Copies the current JSON token value from the source, unescaped, and transcoded as a UTF-16 char buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` | A buffer to write the transcoded UTF-16 characters into. |

**Returns:** `int`

The number of characters written to `destination`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](#String) or [`PropertyName`](#PropertyName). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| `System.ArgumentException` | The destination buffer is too small to hold the unescaped value. |

Unlike [`GetString`](#GetString), this method does not support [`Null`](#Null). This method will throw [`ArgumentException`](#ArgumentException) if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](#ValueSpan) or [`ValueSequence`](#ValueSequence), since the unescaped result is always less than or equal to the length of the encoded strings.

#### GetBoolean

```csharp
bool GetBoolean()
```

Parses the current JSON token value from the source as a [`Boolean`](#Boolean). Returns `true` if the TokenType is JsonTokenType.True and `false` if the TokenType is JsonTokenType.False.

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a boolean (i.e. [`True`](#True) or [`False`](#False)). |

#### GetByte

```csharp
byte GetByte()
```

Parses the current JSON token value from the source as a [`Byte`](#Byte). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Byte`](#Byte) value. Throws exceptions otherwise.

**Returns:** `byte`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes.

**Returns:** `byte[]`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |
| `System.FormatException` | The JSON string contains data outside of the expected Base64 range, or if it contains invalid/more than two padding characters, or is incomplete (i.e. the JSON string length is not a multiple of 4). |

#### GetComment

```csharp
string GetComment()
```

Parses the current JSON token value from the source as a comment, transcoded as a [`String`](#String).

**Returns:** `string`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of the JSON token that is not a comment. |

#### GetDateTime

```csharp
DateTime GetDateTime()
```

Parses the current JSON token value from the source as a [`DateTime`](#DateTime). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTime`](#DateTime) value. Throws exceptions otherwise.

**Returns:** `DateTime`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |
| `System.FormatException` | Thrown if the JSON token value is of an unsupported format. Only a subset of ISO 8601 formats are supported. |

#### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

Parses the current JSON token value from the source as a [`DateTimeOffset`](#DateTimeOffset). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTimeOffset`](#DateTimeOffset) value. Throws exceptions otherwise.

**Returns:** `DateTimeOffset`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |
| `System.FormatException` | Thrown if the JSON token value is of an unsupported format. Only a subset of ISO 8601 formats are supported. |

#### GetDecimal

```csharp
decimal GetDecimal()
```

Parses the current JSON token value from the source as a [`Decimal`](#Decimal). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Decimal`](#Decimal) value. Throws exceptions otherwise.

**Returns:** `decimal`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetDouble

```csharp
double GetDouble()
```

Parses the current JSON token value from the source as a [`Double`](#Double). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Double`](#Double) value. Throws exceptions otherwise.

**Returns:** `double`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetGuid

```csharp
Guid GetGuid()
```

Parses the current JSON token value from the source as a [`Guid`](#Guid). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Guid`](#Guid) value. Throws exceptions otherwise.

**Returns:** `Guid`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |
| `System.FormatException` | Thrown if the JSON token value is of an unsupported format for a Guid. |

#### GetInt16

```csharp
short GetInt16()
```

Parses the current JSON token value from the source as a [`Int16`](#Int16). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Int16`](#Int16) value. Throws exceptions otherwise.

**Returns:** `short`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetInt32

```csharp
int GetInt32()
```

Parses the current JSON token value from the source as an [`Int32`](#Int32). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to an [`Int32`](#Int32) value. Throws exceptions otherwise.

**Returns:** `int`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetInt64

```csharp
long GetInt64()
```

Parses the current JSON token value from the source as a [`Int64`](#Int64). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Int64`](#Int64) value. Throws exceptions otherwise.

**Returns:** `long`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetSByte

```csharp
sbyte GetSByte()
```

Parses the current JSON token value from the source as an [`SByte`](#SByte). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to an [`SByte`](#SByte) value. Throws exceptions otherwise.

**Returns:** `sbyte`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetSingle

```csharp
float GetSingle()
```

Parses the current JSON token value from the source as a [`Single`](#Single). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Single`](#Single) value. Throws exceptions otherwise.

**Returns:** `float`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetString

```csharp
string GetString()
```

Parses the current JSON token value from the source, unescaped, and transcoded as a [`String`](#String).

**Returns:** `string`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](#String), [`PropertyName`](#PropertyName) or [`Null`](#Null)). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |

Returns `null` when [`TokenType`](#TokenType) is [`Null`](#Null).

#### GetUInt16

```csharp
ushort GetUInt16()
```

Parses the current JSON token value from the source as a [`UInt16`](#UInt16). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt16`](#UInt16) value. Throws exceptions otherwise.

**Returns:** `ushort`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetUInt32

```csharp
uint GetUInt32()
```

Parses the current JSON token value from the source as a [`UInt32`](#UInt32). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt32`](#UInt32) value. Throws exceptions otherwise.

**Returns:** `uint`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### GetUInt64

```csharp
ulong GetUInt64()
```

Parses the current JSON token value from the source as a [`UInt64`](#UInt64). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt64`](#UInt64) value. Throws exceptions otherwise.

**Returns:** `ulong`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |
| `System.FormatException` | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](#MinValue) or greater than [`MaxValue`](#MaxValue). |

#### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

Parses the current JSON token value from the source as a [`Byte`](#Byte). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Byte`](#Byte) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes. Returns `true` if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref byte[]` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |

#### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

Parses the current JSON token value from the source as a [`DateTime`](#DateTime). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTime`](#DateTime) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |

#### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

Parses the current JSON token value from the source as a [`DateTimeOffset`](#DateTimeOffset). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTimeOffset`](#DateTimeOffset) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |

#### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

Parses the current JSON token value from the source as a [`Decimal`](#Decimal). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Decimal`](#Decimal) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref decimal` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

Parses the current JSON token value from the source as a [`Double`](#Double). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Double`](#Double) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref double` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

Parses the current JSON token value from the source as a [`Guid`](#Guid). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Guid`](#Guid) value. Only supports [`Guid`](#Guid) values with hyphens and without any surrounding decorations. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Guid` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`String`](#String). |

#### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

Parses the current JSON token value from the source as a [`Int16`](#Int16). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Int16`](#Int16) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref short` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

Parses the current JSON token value from the source as an [`Int32`](#Int32). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to an [`Int32`](#Int32) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref int` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

Parses the current JSON token value from the source as a [`Int64`](#Int64). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Int64`](#Int64) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref long` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

Parses the current JSON token value from the source as an [`SByte`](#SByte). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to an [`SByte`](#SByte) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref sbyte` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

Parses the current JSON token value from the source as a [`Single`](#Single). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Single`](#Single) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref float` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

Parses the current JSON token value from the source as a [`UInt16`](#UInt16). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt16`](#UInt16) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ushort` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

Parses the current JSON token value from the source as a [`UInt32`](#UInt32). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt32`](#UInt32) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref uint` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

#### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

Parses the current JSON token value from the source as a [`UInt64`](#UInt64). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt64`](#UInt64) value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref ulong` |  |

**Returns:** `bool`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if trying to get the value of a JSON token that is not a [`Number`](#Number). |

---

## Utf8JsonWriter (class)

```csharp
public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
```

Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text.

### Remarks

It writes the text sequentially with no caching and adheres to the JSON RFC by default (https://tools.ietf.org/html/rfc8259), with the exception of writing comments. When the user attempts to write invalid JSON and validation is enabled, it throws an [`InvalidOperationException`](#InvalidOperationException) with a context specific error message. To be able to format the output with indentation and whitespace OR to skip validation, create an instance of [`JsonWriterOptions`](#JsonWriterOptions) and pass that in to the writer.

### Inheritance

- Implements: `IDisposable`
- Implements: `IAsyncDisposable`

### Constructors

#### Utf8JsonWriter

```csharp
Utf8JsonWriter(IBufferWriter<byte> bufferWriter, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](#Utf8JsonWriter) instance with a specified `bufferWriter`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | `IBufferWriter<byte>` | An instance of [`IBufferWriter`](#IBufferWriter) used as a destination for writing JSON text into. |
| `options` | `JsonWriterOptions` | Defines the customized behavior of the [`Utf8JsonWriter`](#Utf8JsonWriter) By default, the [`Utf8JsonWriter`](#Utf8JsonWriter) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown when the instance of [`IBufferWriter`](#IBufferWriter) that is passed in is null. |

#### Utf8JsonWriter

```csharp
Utf8JsonWriter(Stream utf8Json, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](#Utf8JsonWriter) instance with a specified `utf8Json`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `Stream` | An instance of [`Stream`](#Stream) used as a destination for writing JSON text into. |
| `options` | `JsonWriterOptions` | Defines the customized behavior of the [`Utf8JsonWriter`](#Utf8JsonWriter) By default, the [`Utf8JsonWriter`](#Utf8JsonWriter) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown when the instance of [`Stream`](#Stream) that is passed in is null. |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `BytesPending` | `int` | Returns the amount of bytes written by the [`Utf8JsonWriter`](#Utf8JsonWriter) so far that have not yet been flushed to the output and committed. |
| `BytesCommitted` | `long` | Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](#Utf8JsonWriter) so far. |
| `Options` | `JsonWriterOptions` | Gets the custom behavior when writing JSON using the [`Utf8JsonWriter`](#Utf8JsonWriter) which indicates whether to format the output while writing and whether to skip structural JSON validation or... |
| `CurrentDepth` | `int` | Tracks the recursive depth of the nested objects / arrays within the JSON text written so far. This provides the depth of the current token. |

#### BytesCommitted

```csharp
long BytesCommitted { get; set; }
```

Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](#Utf8JsonWriter) so far.

In the case of IBufferwriter, this is how much the IBufferWriter has advanced. In the case of Stream, this is how much data has been written to the stream.

### Methods

#### WriteBase64StringSegment

```csharp
void WriteBase64StringSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

Writes the input bytes as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The bytes to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | `bool` | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

#### WriteStringValueSegment

```csharp
void WriteStringValueSegment(ReadOnlySpan<char> value, bool isFinalSegment)
```

Writes the text value segment as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The value to write. |
| `isFinalSegment` | `bool` | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

The value is escaped before writing.

#### WriteStringValueSegment

```csharp
void WriteStringValueSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

Writes the UTF-8 text value segment as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | `bool` | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

The value is escaped before writing.

#### Reset

```csharp
void Reset()
```

Resets the [`Utf8JsonWriter`](#Utf8JsonWriter) internal state so that it can be re-used.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The instance of [`Utf8JsonWriter`](#Utf8JsonWriter) has been disposed. |

The [`Utf8JsonWriter`](#Utf8JsonWriter) will continue to use the original writer options and the original output as the destination (either [`IBufferWriter`](#IBufferWriter) or [`Stream`](#Stream)).

#### Reset

```csharp
void Reset(Stream utf8Json)
```

Resets the [`Utf8JsonWriter`](#Utf8JsonWriter) internal state so that it can be re-used with the new instance of [`Stream`](#Stream).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `Stream` | An instance of [`Stream`](#Stream) used as a destination for writing JSON text into. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown when the instance of [`Stream`](#Stream) that is passed in is null. |
| `System.ObjectDisposedException` | The instance of [`Utf8JsonWriter`](#Utf8JsonWriter) has been disposed. |

The [`Utf8JsonWriter`](#Utf8JsonWriter) will continue to use the original writer options but now write to the passed in [`Stream`](#Stream) as the new destination.

#### Reset

```csharp
void Reset(IBufferWriter<byte> bufferWriter)
```

Resets the [`Utf8JsonWriter`](#Utf8JsonWriter) internal state so that it can be re-used with the new instance of [`IBufferWriter`](#IBufferWriter).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | `IBufferWriter<byte>` | An instance of [`IBufferWriter`](#IBufferWriter) used as a destination for writing JSON text into. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown when the instance of [`IBufferWriter`](#IBufferWriter) that is passed in is null. |
| `System.ObjectDisposedException` | The instance of [`Utf8JsonWriter`](#Utf8JsonWriter) has been disposed. |

The [`Utf8JsonWriter`](#Utf8JsonWriter) will continue to use the original writer options but now write to the passed in [`IBufferWriter`](#IBufferWriter) as the new destination.

#### Flush

```csharp
void Flush()
```

Commits the JSON text written so far which makes it visible to the output destination.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The instance of [`Utf8JsonWriter`](#Utf8JsonWriter) has been disposed. |

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](#IBufferWriter) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it.

#### Dispose

```csharp
void Dispose()
```

Commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance.

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](#IBufferWriter) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it. The [`Utf8JsonWriter`](#Utf8JsonWriter) instance cannot be re-used after disposing.

#### DisposeAsync

```csharp
ValueTask DisposeAsync()
```

Asynchronously commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance.

**Returns:** `ValueTask`

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](#IBufferWriter) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it. The [`Utf8JsonWriter`](#Utf8JsonWriter) instance cannot be re-used after disposing.

#### FlushAsync

```csharp
Task FlushAsync(CancellationToken cancellationToken)
```

Asynchronously commits the JSON text written so far which makes it visible to the output destination.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `cancellationToken` | `CancellationToken` |  *(optional)* |

**Returns:** `Task`

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ObjectDisposedException` | The instance of [`Utf8JsonWriter`](#Utf8JsonWriter) has been disposed. |

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](#IBufferWriter) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it asynchronously, while monitoring cancellation requests.

#### WriteStartArray

```csharp
void WriteStartArray()
```

Writes the beginning of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

#### WriteStartObject

```csharp
void WriteStartObject()
```

Writes the beginning of a JSON object.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

#### WriteStartArray

```csharp
void WriteStartArray(JsonEncodedText propertyName)
```

Writes the beginning of a JSON array with a pre-encoded property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

#### WriteStartObject

```csharp
void WriteStartObject(JsonEncodedText propertyName)
```

Writes the beginning of a JSON object with a pre-encoded property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

#### WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded property name of the JSON array to be written. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteStartObject

```csharp
void WriteStartObject(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded property name of the JSON object to be written. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteStartArray

```csharp
void WriteStartArray(string propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteStartObject

```csharp
void WriteStartObject(string propertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<char> propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteStartObject

```csharp
void WriteStartObject(ReadOnlySpan<char> propertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteEndArray

```csharp
void WriteEndArray()
```

Writes the end of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteEndObject

```csharp
void WriteEndObject()
```

Writes the end of a JSON object.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteBase64String

```csharp
void WriteBase64String(JsonEncodedText propertyName, ReadOnlySpan<byte> bytes)
```

Writes the pre-encoded property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `bytes` | `ReadOnlySpan<byte>` | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteBase64String

```csharp
void WriteBase64String(string propertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `bytes` | `ReadOnlySpan<byte>` | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteBase64String

```csharp
void WriteBase64String(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `bytes` | `ReadOnlySpan<byte>` | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteBase64String

```csharp
void WriteBase64String(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `bytes` | `ReadOnlySpan<byte>` | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTime value)
```

Writes the pre-encoded property name and [`DateTime`](#DateTime) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `DateTime` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTime`](#DateTime) using the round-trip ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000. The property name should already be escaped when the instance of [`JsonEncodedText`](#JsonEncodedText) was created.

#### WriteString

```csharp
void WriteString(string propertyName, DateTime value)
```

Writes the property name and [`DateTime`](#DateTime) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `DateTime` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTime`](#DateTime) using the round-trip ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTime value)
```

Writes the property name and [`DateTime`](#DateTime) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `DateTime` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTime`](#DateTime) using the round-trip ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
```

Writes the property name and [`DateTime`](#DateTime) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `DateTime` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTime`](#DateTime) using the round-trip ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTimeOffset value)
```

Writes the pre-encoded property name and [`DateTimeOffset`](#DateTimeOffset) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `DateTimeOffset` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTimeOffset`](#DateTimeOffset) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000-07:00.

#### WriteString

```csharp
void WriteString(string propertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](#DateTimeOffset) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `DateTimeOffset` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTimeOffset`](#DateTimeOffset) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](#DateTimeOffset) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `DateTimeOffset` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTimeOffset`](#DateTimeOffset) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](#DateTimeOffset) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded property name of the JSON object to be written. |
| `value` | `DateTimeOffset` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTimeOffset`](#DateTimeOffset) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, decimal value)
```

Writes the pre-encoded property name and [`Decimal`](#Decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `decimal` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Decimal`](#Decimal) using the default [`StandardFormat`](#StandardFormat) (that is, 'G').

#### WriteNumber

```csharp
void WriteNumber(string propertyName, decimal value)
```

Writes the property name and [`Decimal`](#Decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `decimal` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Decimal`](#Decimal) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, decimal value)
```

Writes the property name and [`Decimal`](#Decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `decimal` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Decimal`](#Decimal) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, decimal value)
```

Writes the property name and [`Decimal`](#Decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `decimal` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Decimal`](#Decimal) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, double value)
```

Writes the pre-encoded property name and [`Double`](#Double) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `double` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Double`](#Double) using the default [`StandardFormat`](#StandardFormat) (that is, 'G').

#### WriteNumber

```csharp
void WriteNumber(string propertyName, double value)
```

Writes the property name and [`Double`](#Double) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `double` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Double`](#Double) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, double value)
```

Writes the property name and [`Double`](#Double) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `double` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Double`](#Double) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, double value)
```

Writes the property name and [`Double`](#Double) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `double` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Double`](#Double) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, float value)
```

Writes the pre-encoded property name and [`Single`](#Single) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write.. |
| `value` | `float` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Single`](#Single) using the default [`StandardFormat`](#StandardFormat) (that is, 'G').

#### WriteNumber

```csharp
void WriteNumber(string propertyName, float value)
```

Writes the property name and [`Single`](#Single) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write.. |
| `value` | `float` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Single`](#Single) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, float value)
```

Writes the property name and [`Single`](#Single) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write.. |
| `value` | `float` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Single`](#Single) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, float value)
```

Writes the property name and [`Single`](#Single) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write |
| `value` | `float` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Single`](#Single) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'). The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, Guid value)
```

Writes the pre-encoded property name and [`Guid`](#Guid) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `Guid` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Guid`](#Guid) using the default [`StandardFormat`](#StandardFormat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

#### WriteString

```csharp
void WriteString(string propertyName, Guid value)
```

Writes the property name and [`Guid`](#Guid) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `Guid` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Guid`](#Guid) using the default [`StandardFormat`](#StandardFormat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, Guid value)
```

Writes the property name and [`Guid`](#Guid) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `Guid` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Guid`](#Guid) using the default [`StandardFormat`](#StandardFormat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, Guid value)
```

Writes the property name and [`Guid`](#Guid) value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `Guid` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Guid`](#Guid) using the default [`StandardFormat`](#StandardFormat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

#### WriteBoolean

```csharp
void WriteBoolean(JsonEncodedText propertyName, bool value)
```

Writes the pre-encoded property name and [`Boolean`](#Boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `bool` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteBoolean

```csharp
void WriteBoolean(string propertyName, bool value)
```

Writes the property name and [`Boolean`](#Boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `bool` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<char> propertyName, bool value)
```

Writes the property name and [`Boolean`](#Boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `bool` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<byte> utf8PropertyName, bool value)
```

Writes the property name and [`Boolean`](#Boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `bool` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteNull

```csharp
void WriteNull(JsonEncodedText propertyName)
```

Writes the pre-encoded property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteNull

```csharp
void WriteNull(string propertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteNull

```csharp
void WriteNull(ReadOnlySpan<char> propertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteNull

```csharp
void WriteNull(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, long value)
```

Writes the pre-encoded property name and [`Int64`](#Int64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `long` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int64`](#Int64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumber

```csharp
void WriteNumber(string propertyName, long value)
```

Writes the property name and [`Int64`](#Int64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `long` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int64`](#Int64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, long value)
```

Writes the property name and [`Int64`](#Int64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `long` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int64`](#Int64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, long value)
```

Writes the property name and [`Int64`](#Int64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `long` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int64`](#Int64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, int value)
```

Writes the pre-encoded property name and [`Int32`](#Int32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `int` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int32`](#Int32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumber

```csharp
void WriteNumber(string propertyName, int value)
```

Writes the property name and [`Int32`](#Int32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `int` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int32`](#Int32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, int value)
```

Writes the property name and [`Int32`](#Int32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `int` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int32`](#Int32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, int value)
```

Writes the property name and [`Int32`](#Int32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `int` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int32`](#Int32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WritePropertyName

```csharp
void WritePropertyName(JsonEncodedText propertyName)
```

Writes the pre-encoded property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WritePropertyName

```csharp
void WritePropertyName(string propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WritePropertyName

```csharp
void WritePropertyName(ReadOnlySpan<char> propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WritePropertyName

```csharp
void WritePropertyName(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the UTF-8 property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, JsonEncodedText value)
```

Writes the pre-encoded property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `JsonEncodedText` | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteString

```csharp
void WriteString(string propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The JSON-encoded name of the property to write. |
| `value` | `JsonEncodedText` | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(string propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `string` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](#WriteNull) were called.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `ReadOnlySpan<char>` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, string value)
```

Writes the pre-encoded property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `string` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](#WriteNull) was called.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<char> value)
```

Writes the pre-encoded property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `ReadOnlySpan<char>` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

#### WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `ReadOnlySpan<char>` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
```

Writes the UTF-8 property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `ReadOnlySpan<char>` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the pre-encoded property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

#### WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `JsonEncodedText` | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `string` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](#WriteNull) was called.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, JsonEncodedText value)
```

Writes the UTF-8 property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `JsonEncodedText` | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

#### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, string value)
```

Writes the UTF-8 property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `string` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name or value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](#WriteNull) was called.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, ulong value)
```

Writes the pre-encoded property name and [`UInt64`](#UInt64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `ulong` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt64`](#UInt64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumber

```csharp
void WriteNumber(string propertyName, ulong value)
```

Writes the property name and [`UInt64`](#UInt64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `ulong` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt64`](#UInt64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, ulong value)
```

Writes the property name and [`UInt64`](#UInt64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `ulong` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt64`](#UInt64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ulong value)
```

Writes the property name and [`UInt64`](#UInt64) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `ulong` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt64`](#UInt64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, uint value)
```

Writes the pre-encoded property name and [`UInt32`](#UInt32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `JsonEncodedText` | The JSON-encoded name of the property to write. |
| `value` | `uint` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt32`](#UInt32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumber

```csharp
void WriteNumber(string propertyName, uint value)
```

Writes the property name and [`UInt32`](#UInt32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property to write. |
| `value` | `uint` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.ArgumentNullException` | The `propertyName` parameter is `null`. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt32`](#UInt32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, uint value)
```

Writes the property name and [`UInt32`](#UInt32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to write. |
| `value` | `uint` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt32`](#UInt32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, uint value)
```

Writes the property name and [`UInt32`](#UInt32) value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | `ReadOnlySpan<byte>` | The UTF-8 encoded name of the property to write. |
| `value` | `uint` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified property name is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt32`](#UInt32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

#### WriteBase64StringValue

```csharp
void WriteBase64StringValue(ReadOnlySpan<byte> bytes)
```

Writes the raw bytes value as a Base64 encoded JSON string as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bytes` | `ReadOnlySpan<byte>` | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The bytes are encoded before writing.

#### WriteCommentValue

```csharp
void WriteCommentValue(string value)
```

Writes the string text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` | The value to write as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large OR if the given string text value contains a comment delimiter (that is, */). |
| `System.ArgumentNullException` | The `value` parameter is `null`. |

The comment value is not escaped before writing.

#### WriteCommentValue

```csharp
void WriteCommentValue(ReadOnlySpan<char> value)
```

Writes the text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The value to write as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large OR if the given text value contains a comment delimiter (that is, */). |

The comment value is not escaped before writing.

#### WriteCommentValue

```csharp
void WriteCommentValue(ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to be written as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large OR if the given UTF-8 text value contains a comment delimiter (that is, */). |

The comment value is not escaped before writing.

#### WriteStringValue

```csharp
void WriteStringValue(DateTime value)
```

Writes the [`DateTime`](#DateTime) value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `DateTime` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTime`](#DateTime) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000.

#### WriteStringValue

```csharp
void WriteStringValue(DateTimeOffset value)
```

Writes the [`DateTimeOffset`](#DateTimeOffset) value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `DateTimeOffset` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`DateTimeOffset`](#DateTimeOffset) using the round-trippable ('O') [`StandardFormat`](#StandardFormat) , for example: 2017-06-12T05:30:45.7680000-07:00.

#### WriteNumberValue

```csharp
void WriteNumberValue(decimal value)
```

Writes the [`Decimal`](#Decimal) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `decimal` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Decimal`](#Decimal) using the default [`StandardFormat`](#StandardFormat) (that is, 'G').

#### WriteNumberValue

```csharp
void WriteNumberValue(double value)
```

Writes the [`Double`](#Double) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `double` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Double`](#Double) using the default [`StandardFormat`](#StandardFormat) on .NET Core 3 or higher and 'G17' on any other framework.

#### WriteNumberValue

```csharp
void WriteNumberValue(float value)
```

Writes the [`Single`](#Single) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `float` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Single`](#Single) using the default [`StandardFormat`](#StandardFormat) on .NET Core 3 or higher and 'G9' on any other framework.

#### WriteStringValue

```csharp
void WriteStringValue(Guid value)
```

Writes the [`Guid`](#Guid) value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Guid` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Guid`](#Guid) using the default [`StandardFormat`](#StandardFormat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

#### WriteBooleanValue

```csharp
void WriteBooleanValue(bool value)
```

Writes the [`Boolean`](#Boolean) value (as a JSON literal "true" or "false") as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `bool` | The value write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteNullValue

```csharp
void WriteNullValue()
```

Writes the JSON literal "null" as an element of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteRawValue

```csharp
void WriteRawValue(string json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `string` | The raw JSON content to write. |
| `skipInputValidation` | `bool` | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentNullException` | Thrown if `json` is `null`. |
| `System.ArgumentException` | Thrown if the length of the input is zero or greater than 715,827,882 ([`MaxValue`](#MaxValue) / 3). |
| `Corvus.Text.Json.JsonException` | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https://tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](#SkipValidation) value for the writer instance is honored when using this method. The [`Indented`](#Indented) and [`Encoder`](#Encoder) values for the writer instance are not applied when using this method.

#### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<char> json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | `ReadOnlySpan<char>` | The raw JSON content to write. |
| `skipInputValidation` | `bool` | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown if the length of the input is zero or greater than 715,827,882 ([`MaxValue`](#MaxValue) / 3). |
| `Corvus.Text.Json.JsonException` | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https://tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](#SkipValidation) value for the writer instance is honored when using this method. The [`Indented`](#Indented) and [`Encoder`](#Encoder) values for the writer instance are not applied when using this method.

#### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlySpan<byte>` | The raw JSON content to write. |
| `skipInputValidation` | `bool` | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown if the length of the input is zero or greater than or equal to [`MaxValue`](#MaxValue). |
| `Corvus.Text.Json.JsonException` | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https://tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](#SkipValidation) value for the writer instance is honored when using this method. The [`Indented`](#Indented) and [`Encoder`](#Encoder) values for the writer instance are not applied when using this method.

#### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySequence<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | `ReadOnlySequence<byte>` | The raw JSON content to write. |
| `skipInputValidation` | `bool` | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown if the length of the input is zero or equal to [`MaxValue`](#MaxValue). |
| `Corvus.Text.Json.JsonException` | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https://tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](#SkipValidation) value for the writer instance is honored when using this method. The [`Indented`](#Indented) and [`Encoder`](#Encoder) values for the writer instance are not applied when using this method.

#### WriteNumberValue

```csharp
void WriteNumberValue(int value)
```

Writes the [`Int32`](#Int32) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int32`](#Int32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumberValue

```csharp
void WriteNumberValue(long value)
```

Writes the [`Int64`](#Int64) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `long` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`Int64`](#Int64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteStringValue

```csharp
void WriteStringValue(JsonEncodedText value)
```

Writes the pre-encoded text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonEncodedText` | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

#### WriteStringValue

```csharp
void WriteStringValue(string value)
```

Writes the string text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNullValue`](#WriteNullValue) was called.

#### WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<char> value)
```

Writes the text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

#### WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | `ReadOnlySpan<byte>` | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the specified value is too large. |
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

#### WriteNumberValue

```csharp
void WriteNumberValue(uint value)
```

Writes the [`UInt32`](#UInt32) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `uint` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt32`](#UInt32) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

#### WriteNumberValue

```csharp
void WriteNumberValue(ulong value)
```

Writes the [`UInt64`](#UInt64) value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ulong` | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the [`UInt64`](#UInt64) using the default [`StandardFormat`](#StandardFormat) (that is, 'G'), for example: 32767.

---

## Utf8Uri (struct)

```csharp
public readonly struct Utf8Uri
```

A UTF-8 URI.

### Remarks

```csharp foo://user@example.com:8042/over/there?name=ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Authority` | `ReadOnlySpan<byte>` | Gets the authority component of the reference. |
| `Fragment` | `ReadOnlySpan<byte>` | Gets the fragment component of the reference. |
| `HasAuthority` | `bool` | Gets a value indicating whether this reference has an authority. |
| `HasFragment` | `bool` | Gets a value indicating whether this reference has a fragment. |
| `HasHost` | `bool` | Gets a value indicating whether this reference has a host. |
| `HasPath` | `bool` | Gets a value indicating whether this reference has a path. |
| `HasPort` | `bool` | Gets a value indicating whether this reference has a port. |
| `HasQuery` | `bool` | Gets a value indicating whether this reference has a query. |
| `HasScheme` | `bool` | Gets a value indicating whether this reference has a scheme. |
| `HasUser` | `bool` | Gets a value indicating whether this reference has a user. |
| `Host` | `ReadOnlySpan<byte>` | Gets the host component of the reference (includes both host and port). |
| `IsDefaultPort` | `bool` | Gets a value indicating whether this is the default port for the scheme. |
| `IsRelative` | `bool` | Gets a value indicating whether this is a relative URI. |
| `IsValid` | `bool` | Gets a value indicating whether this is a valid URI. |
| `OriginalUri` | `ReadOnlySpan<byte>` | Gets the original (fully encoded) string. |
| `Path` | `ReadOnlySpan<byte>` | Gets the path component of the URI. |
| `Port` | `ReadOnlySpan<byte>` | Gets the port component of the URI as a byte span. |
| `PortValue` | `int` | Gets the port value as an integer. |
| `Query` | `ReadOnlySpan<byte>` | Gets the query component of the URI. |
| `Scheme` | `ReadOnlySpan<byte>` | Gets the scheme component of the URI. |
| `User` | `ReadOnlySpan<byte>` | Gets the user component of the URI. |

### Methods

#### CreateUri `static`

```csharp
Utf8Uri CreateUri(ReadOnlySpan<byte> uri)
```

Creates a new UTF-8 URI from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ReadOnlySpan<byte>` | The URI bytes from which to create the UTF-8 URI. |

**Returns:** `Utf8Uri`

A new UTF-8 URI.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the URI is invalid. |

#### TryCreateUri `static`

```csharp
bool TryCreateUri(ReadOnlySpan<byte> uri, ref Utf8Uri utf8Uri)
```

Tries to create a new UTF-8 URI from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ReadOnlySpan<byte>` | The URI bytes from which to create the UTF-8 URI. |
| `utf8Uri` | `ref Utf8Uri` | When this method returns, contains the created UTF-8 URI if successful; otherwise, the default value. |

**Returns:** `bool`

`true` if the UTF-8 URI was created successfully; otherwise, `false`.

#### GetUri

```csharp
Uri GetUri()
```

Gets the value as a [`Uri`](#Uri).

**Returns:** `Uri`

The URI representation of the UTF-8 URI.

#### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI in canonical form for display.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryFormatCanonical

```csharp
bool TryFormatCanonical(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `ref Utf8UriReference` | The URI reference to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Uri` | The resulting URI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ref Utf8Uri` | The URI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Uri` | The resulting URI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

#### TryMakeRelative

```csharp
bool TryMakeRelative(ref Utf8Uri targetUri, Span<byte> buffer, ref Utf8UriReference result)
```

Makes a relative URI reference from the current (base) URI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetUri` | `ref Utf8Uri` | The target URI to make relative. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8UriReference` | The resulting URI reference (relative or absolute). |

**Returns:** `bool`

`true` if the result was successfully written; otherwise, `false`.

#### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the URI in display format.

**Returns:** `string`

A string representation of the URI.

---

## Utf8UriReference (struct)

```csharp
public readonly struct Utf8UriReference
```

A UTF-8 URI Reference.

### Remarks

```csharp foo://user@example.com:8042/over/there?name=ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Authority` | `ReadOnlySpan<byte>` | Gets the authority component of the reference. |
| `Fragment` | `ReadOnlySpan<byte>` | Gets the fragment component of the reference. |
| `HasAuthority` | `bool` | Gets a value indicating whether this reference has an authority. |
| `HasFragment` | `bool` | Gets a value indicating whether this reference has a fragment. |
| `HasHost` | `bool` | Gets a value indicating whether this reference has a host. |
| `HasPath` | `bool` | Gets a value indicating whether this reference has a path. |
| `HasPort` | `bool` | Gets a value indicating whether this reference has a port. |
| `HasQuery` | `bool` | Gets a value indicating whether this reference has a query. |
| `HasScheme` | `bool` | Gets a value indicating whether this reference has a scheme. |
| `HasUser` | `bool` | Gets a value indicating whether this reference has a user. |
| `Host` | `ReadOnlySpan<byte>` | Gets the host component of the reference (includes both host and port). |
| `IsDefaultPort` | `bool` | Gets a value indicating whether this is the default port for the scheme. |
| `IsRelative` | `bool` | Gets a value indicating whether this is a relative reference. |
| `IsValid` | `bool` | Gets a value indicating whether this is a valid reference. |
| `OriginalUriReference` | `ReadOnlySpan<byte>` | Gets the original string. |
| `Path` | `ReadOnlySpan<byte>` | Gets the path component of the reference. |
| `Port` | `ReadOnlySpan<byte>` | Gets the port component of the reference as a byte span. |
| `PortValue` | `int` | Gets the port value as an integer. |
| `Query` | `ReadOnlySpan<byte>` | Gets the query component of the reference. |
| `Scheme` | `ReadOnlySpan<byte>` | Gets the scheme component of the reference. |
| `User` | `ReadOnlySpan<byte>` | Gets the user component of the reference. |

### Methods

#### CreateUriReference `static`

```csharp
Utf8UriReference CreateUriReference(ReadOnlySpan<byte> uri)
```

Creates a new UTF-8 URI Reference from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ReadOnlySpan<byte>` | The URI bytes to create the reference from. |

**Returns:** `Utf8UriReference`

A new UTF-8 URI Reference.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the URI is invalid. |

#### TryCreateUriReference `static`

```csharp
bool TryCreateUriReference(ReadOnlySpan<byte> uri, ref Utf8UriReference utf8UriReference)
```

Tries to create a new UTF-8 URI Reference from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ReadOnlySpan<byte>` | The URI bytes from which to create the UTF-8 URI from. |
| `utf8UriReference` | `ref Utf8UriReference` | When this method returns, contains the created UTF-8 URI reference if successful; otherwise, the default value. |

**Returns:** `bool`

`true` if the UTF-8 URI Reference was created successfully; otherwise, `false`.

#### GetUri

```csharp
Uri GetUri()
```

Gets the value as a [`Uri`](#Uri).

**Returns:** `Uri`

The URI representation of the reference.

#### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI reference in canonical form for display.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryFormatCanonical

```csharp
bool TryFormatCanonical(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI reference in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | `ref int` | The number of bytes written. |

**Returns:** `bool`

`true` if the result was successfully written to the buffer; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `ref Utf8UriReference` | The URI reference to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Uri` | The resulting URI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

#### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `ref Utf8Uri` | The URI to apply. |
| `buffer` | `Span<byte>` | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | `ref Utf8Uri` | The resulting URI. |

**Returns:** `bool`

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

#### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the URI reference in display format.

**Returns:** `string`

A string representation of the URI reference.

---

## Utf8UriReferenceValue (struct)

```csharp
public readonly struct Utf8UriReferenceValue : IDisposable
```

A UTF-8 URI reference value that has been parsed from a JSON document.

### Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `UriReference` | `Utf8UriReference` | Gets the UTF-8 URI reference value. |

### Methods

#### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriReferenceValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8UriReferenceValue`](#Utf8UriReferenceValue).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | `int` | The index of the element. |
| `value` | `ref Utf8UriReferenceValue` | The [`Utf8UriReferenceValue`](#Utf8UriReferenceValue) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the URI reference value.

---

## Utf8UriValue (struct)

```csharp
public readonly struct Utf8UriValue : IDisposable
```

A UTF-8 URI value that has been parsed from a JSON document.

### Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Uri` | `Utf8Uri` | Gets the UTF-8 URI value. |

### Methods

#### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8UriValue`](#Utf8UriValue).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | `int` | The index of the element. |
| `value` | `ref Utf8UriValue` | The [`Utf8UriValue`](#Utf8UriValue) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the URI value.

---

