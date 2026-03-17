---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.GetArrayIndexElement Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [GetArrayIndexElement(int, int)](#getarrayindexelement-int-int) | Gets the array element at the specified index as a mutable JSON element. |
| [GetArrayIndexElement(int, int, ref IMutableJsonDocument, ref int)](#getarrayindexelement-int-int-ref-imutablejsondocument-ref-int) | Gets the element at the specified array index within the current index. |

## GetArrayIndexElement(int, int) {#getarrayindexelement-int-int}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L32)

Gets the array element at the specified index as a mutable JSON element.

```csharp
public abstract JsonElement.Mutable GetArrayIndexElement(int currentIndex, int arrayIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index in the document. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index within the array. |

### Returns

[`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html)

The mutable JSON element at the specified array index.

### Implements

[`IJsonDocument.GetArrayIndexElement`](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html)

[`IJsonDocument.GetArrayIndexElement`](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## GetArrayIndexElement(int, int, ref IMutableJsonDocument, ref int) {#getarrayindexelement-int-int-ref-imutablejsondocument-ref-int}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L32)

Gets the element at the specified array index within the current index.

```csharp
public abstract void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IMutableJsonDocument parentDocument, ref int parentDocumentIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |
| `parentDocument` | [`ref IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) | Produces the parent document of the result. |
| `parentDocumentIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | Produces the parent document index. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

