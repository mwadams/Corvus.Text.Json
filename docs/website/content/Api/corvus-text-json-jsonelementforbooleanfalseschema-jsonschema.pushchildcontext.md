---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.JsonSchema.PushChildContext Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, JsonSchemaPathProvider, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-jsonschemapathprovider-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, TContext, JsonSchemaPathProvider&lt;TContext&gt;, JsonSchemaPathProvider&lt;TContext&gt;)](#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-tcontext-jsonschemapathprovider-tcontext-jsonschemapathprovider-tcontext) |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-readonlyspan-byte-jsonschemapathprovider) |  |
| [PushChildContext(IJsonDocument, int, ref JsonSchemaContext, int, JsonSchemaPathProvider)](#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-int-jsonschemapathprovider) |  |

## PushChildContext(IJsonDocument, int, ref JsonSchemaContext, JsonSchemaPathProvider, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-jsonschemapathprovider-jsonschemapathprovider}

```csharp
public static JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

---

## PushChildContext(IJsonDocument, int, ref JsonSchemaContext, TContext, JsonSchemaPathProvider&lt;TContext&gt;, JsonSchemaPathProvider&lt;TContext&gt;) {#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-tcontext-jsonschemapathprovider-tcontext-jsonschemapathprovider-tcontext}

```csharp
public static JsonSchemaContext PushChildContext<TContext>(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, TContext providerContext, JsonSchemaPathProvider<TContext> schemaEvaluationPath, JsonSchemaPathProvider<TContext> documentEvaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `providerContext` | `TContext` |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

---

## PushChildContext(IJsonDocument, int, ref JsonSchemaContext, ReadOnlySpan&lt;byte&gt;, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-readonlyspan-byte-jsonschemapathprovider}

```csharp
public static JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

---

## PushChildContext(IJsonDocument, int, ref JsonSchemaContext, int, JsonSchemaPathProvider) {#pushchildcontext-ijsondocument-int-ref-jsonschemacontext-int-jsonschemapathprovider}

```csharp
public static JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, int itemIndex, JsonSchemaPathProvider evaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

---

