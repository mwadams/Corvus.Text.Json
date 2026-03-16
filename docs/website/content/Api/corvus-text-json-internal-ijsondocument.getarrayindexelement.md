---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetArrayIndexElement Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetArrayIndexElement(int, int)](#getarrayindexelement-int-int) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int)](#getarrayindexelement-int-int) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int, ref IJsonDocument, ref int)](#getarrayindexelement-int-int-ref-ijsondocument-ref-int) | Gets the element at the specified array index within the current index. |

## GetArrayIndexElement(int, int) {#getarrayindexelement-int-int}

```csharp
public abstract JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex)
```

Gets the element at the specified array index within the current index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The JSON element.

---

## GetArrayIndexElement(int, int) {#getarrayindexelement-int-int}

```csharp
public abstract TElement GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex)
```

Gets the element at the specified array index within the current index.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

### Returns

`TElement`

The JSON element.

---

## GetArrayIndexElement(int, int, ref IJsonDocument, ref int) {#getarrayindexelement-int-int-ref-ijsondocument-ref-int}

```csharp
public abstract void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IJsonDocument parentDocument, ref int parentDocumentIndex)
```

Gets the element at the specified array index within the current index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |
| `parentDocument` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | Produces the parent document of the result. |
| `parentDocumentIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | Produces the parent document index. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

