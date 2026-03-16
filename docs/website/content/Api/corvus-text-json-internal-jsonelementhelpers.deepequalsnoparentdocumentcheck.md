---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.DeepEqualsNoParentDocumentCheck Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [DeepEqualsNoParentDocumentCheck(ref TLeft, JsonTokenType, IJsonDocument, int)](#deepequalsnoparentdocumentcheck-ref-tleft-jsontokentype-ijsondocument-int) | Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements. |
| [DeepEqualsNoParentDocumentCheck(IJsonDocument, int, IJsonDocument, int)](#deepequalsnoparentdocumentcheck-ijsondocument-int-ijsondocument-int) | Compares the values of two JSON values for equality, including the values of all descendant elements. |

## DeepEqualsNoParentDocumentCheck(ref TLeft, JsonTokenType, IJsonDocument, int) {#deepequalsnoparentdocumentcheck-ref-tleft-jsontokentype-ijsondocument-int}

```csharp
bool DeepEqualsNoParentDocumentCheck<TLeft>(ref TLeft element1, JsonTokenType element2TokenType, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |
| `element2TokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The token type of the second JSON element. |
| `element2ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the second JSON element within its parent document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

### Remarks

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

---

## DeepEqualsNoParentDocumentCheck(IJsonDocument, int, IJsonDocument, int) {#deepequalsnoparentdocumentcheck-ijsondocument-int-ijsondocument-int}

```csharp
bool DeepEqualsNoParentDocumentCheck(IJsonDocument element1ParentDocument, int element1ParentDocumentIndex, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two JSON values for equality, including the values of all descendant elements.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `element1ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the first JSON element. |
| `element1ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the first JSON element within its parent document. |
| `element2ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the second JSON element within its parent document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

### Remarks

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

---

