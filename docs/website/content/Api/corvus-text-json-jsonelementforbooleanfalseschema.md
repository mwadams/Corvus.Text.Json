---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElementForBooleanFalseSchema : IJsonElement<JsonElementForBooleanFalseSchema>, IJsonElement
```

Represents a specific JSON value within a [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

## Implements

[`IJsonElement<JsonElementForBooleanFalseSchema>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is. |

## Methods

### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates this element against the boolean false schema.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The optional results collector for schema evaluation. *(optional)* |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`false` because this represents a boolean false schema.

### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether the specified object is equal to the current instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with the current instance. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified object is equal to the current instance; otherwise, `false`.

### Equals

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified JSON element is equal to the current instance; otherwise, `false`.

### From `static`

```csharp
JsonElementForBooleanFalseSchema From<T>(ref T instance)
```

Creates a new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) from the specified JSON element instance.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` | The JSON element instance to create from. |

**Returns:** [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instance.

### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ReadOnlySpan<byte> utf8Json, JsonDocumentOptions options)
```

Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ReadOnlySpan<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `json` is `null`. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElementForBooleanFalseSchema ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

**Returns:** [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A JsonElement representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html) or [`None`](/api/corvus-text-json-internal-jsontokentype.html), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref Nullable<JsonElementForBooleanFalseSchema> element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) |  |
| `element` | [`ref Nullable<JsonElementForBooleanFalseSchema>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### CreateDocument `static`

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity)
```

Creates a JSON document containing the specified integer value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The integer value to include in the document. |
| `initialCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial capacity for the document builder. *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the specified value.

### CreateDocument

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace)
```

Creates a JSON document from the current instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |

**Returns:** [`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the current instance.

### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the element into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) is [`Undefined`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### ToString `virtual`

```csharp
string ToString()
```

Gets a string representation for the current value appropriate to the value type.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation for the current value appropriate to the value type.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

For JsonElement built from [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html): For [`Null`](/api/corvus-text-json-jsonvaluekind.html), `Empty` is returned. For [`True`](/api/corvus-text-json-jsonvaluekind.html), `TrueString` is returned. For [`False`](/api/corvus-text-json-jsonvaluekind.html), `FalseString` is returned. For [`String`](/api/corvus-text-json-jsonvaluekind.html), the value of `GetString`() is returned. For other types, the value of `GetRawText`() is returned.

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Gets the hash code for the current instance.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

A hash code for the current instance.


### JsonElementForBooleanFalseSchema.JsonSchema (class)

```csharp
public static class JsonElementForBooleanFalseSchema.JsonSchema
```

#### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElementForBooleanFalseSchema.JsonSchema**

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `SchemaLocationUtf8` `static` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

#### Methods

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext<TContext>(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, TContext providerContext, JsonSchemaPathProvider<TContext> schemaEvaluationPath, JsonSchemaPathProvider<TContext> documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `providerContext` | `TContext` |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, int itemIndex, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContextUnescaped `static`

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### Evaluate `static`

```csharp
void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |

##### Evaluate `static`

```csharp
bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Fields

| Field | Type | Description |
|-------|------|-------------|
| `SchemaLocationProvider` `static` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  |
| `SchemaLocation` `static` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

### JsonElementForBooleanFalseSchema.Mutable (struct)

```csharp
public readonly struct JsonElementForBooleanFalseSchema.Mutable : IMutableJsonElement<JsonElementForBooleanFalseSchema.Mutable>, IJsonElement<JsonElementForBooleanFalseSchema.Mutable>, IJsonElement
```

#### Implements

[`IMutableJsonElement<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`IJsonElement<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) |  |
| `Item` | `JsonElementForBooleanFalseSchema.Mutable` |  |

#### Methods

##### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### Equals

```csharp
bool Equals<T>(T other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateBuilder(JsonWorkspace workspace)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |

**Returns:** [`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

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
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) |  |

##### ToString `virtual`

```csharp
string ToString()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

##### Clone

```csharp
JsonElement Clone()
```

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

##### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  *(optional)* |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

