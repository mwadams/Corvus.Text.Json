---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.CreateBuilder Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CreateBuilder(TElement)](#createbuilder-telement) | Creates a document builder for building mutable JSON documents from an existing element. |
| [CreateBuilder(int, int)](#createbuilder-int-int) | Creates a document builder for building mutable JSON documents. |

## CreateBuilder(TElement) {#createbuilder-telement}

```csharp
public JsonDocumentBuilder<TMutableElement> CreateBuilder<TElement, TMutableElement>(TElement sourceElement)
```

Creates a document builder for building mutable JSON documents from an existing element.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the source JSON element. |
| `TMutableElement` | The type of the mutable JSON element to build. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `sourceElement` | `TElement` | The source element to build from. |

### Returns

[`JsonDocumentBuilder<TMutableElement>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A document builder for the mutable element type.

---

## CreateBuilder(int, int) {#createbuilder-int-int}

```csharp
public JsonDocumentBuilder<TElement> CreateBuilder<TElement>(int initialCapacity, int initialValueBufferSize)
```

Creates a document builder for building mutable JSON documents.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the mutable JSON element to build. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `initialCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial capacity for the document builder. *(optional)* |
| `initialValueBufferSize` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial size of the value buffer. *(optional)* |

### Returns

[`JsonDocumentBuilder<TElement>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A document builder for the specified element type.

---

