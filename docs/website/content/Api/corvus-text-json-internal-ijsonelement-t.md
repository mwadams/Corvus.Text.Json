---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement<T> — Corvus.Text.Json.Internal"
---
```csharp
public interface IJsonElement<T> : IJsonElement
```

Implemented by JsonElement-derived types.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type implementing the interface. |

## Implements

[`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

## Implemented By

[`IMutableJsonElement<T>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`JsonElement`](/api/corvus-text-json-jsonelement.html), `JsonElement.Mutable`, [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html), `JsonElementForBooleanFalseSchema.Mutable`

## Methods

### CreateInstance `static` `abstract`

```csharp
T CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex)
```

Creates an instance of the element from the parent document and the handle of the element in the parent document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The handle of the element in the parent document. |

**Returns:** `T`

An instance of the implementing element type.

