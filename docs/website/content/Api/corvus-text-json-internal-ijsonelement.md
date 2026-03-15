---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement — Corvus.Text.Json.Internal"
---
```csharp
public interface IJsonElement
```

Implemented by JsonElement-derived types.

## Implemented By

[`IJsonElement<T>`](/api/corvus-text-json-internal-ijsonelement.html), [`IMutableJsonElement<T>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`JsonElement`](/api/corvus-text-json-jsonelement.html), `JsonElement.Mutable`, [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html), `JsonElementForBooleanFalseSchema.Mutable`

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | Gets the parent document. |
| `ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the handle identifying the [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) in its parent document. |
| `TokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Gets the JSON Token type of the element. |
| `ValueKind` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Gets the JSON Value Kind of the element. |

## Methods

### CheckValidInstance `abstract`

```csharp
void CheckValidInstance()
```

Checks that this instance is valid.

### EvaluateSchema `abstract`

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the schema for this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The results collector for schema evaluation (optional). *(optional)* |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the schema evaluation succeeded; otherwise, `false`.

### WriteTo `abstract`

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Writes this element to the specified [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to which to write the element. |

