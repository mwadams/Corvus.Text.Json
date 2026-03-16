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

[`IJsonElement<T>`](/api/corvus-text-json-internal-ijsonelement.html), [`IMutableJsonElement<T>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`JsonElement`](/api/corvus-text-json-jsonelement.html), [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html), [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html), [`JsonElementForBooleanFalseSchema.Mutable`](/api/corvus-text-json-jsonelementforbooleanfalseschema-mutable.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [ParentDocument](/api/corvus-text-json-internal-ijsonelement.parentdocument.html) | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | Gets the parent document. |
| [ParentDocumentIndex](/api/corvus-text-json-internal-ijsonelement.parentdocumentindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the handle identifying the [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) in its parent document. |
| [TokenType](/api/corvus-text-json-internal-ijsonelement.tokentype.html) | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Gets the JSON Token type of the element. |
| [ValueKind](/api/corvus-text-json-internal-ijsonelement.valuekind.html) | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | Gets the JSON Value Kind of the element. |

## Methods

| Method | Description |
|--------|-------------|
| [CheckValidInstance()](/api/corvus-text-json-internal-ijsonelement.checkvalidinstance.html#checkvalidinstance) | Checks that this instance is valid. |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-internal-ijsonelement.evaluateschema.html#evaluateschema-ijsonschemaresultscollector) | Evaluates the schema for this element. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-internal-ijsonelement.writeto.html#writeto-utf8jsonwriter) | Writes this element to the specified [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html). |

