---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.CloneElement Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CloneElement(int)](#jsonelement-cloneelement-int-index) | Clones the element at the specified index. |
| [CloneElement(int)](#telement-cloneelement-telement-int-index) | Clones the element at the specified index. |

## CloneElement `abstract`

```csharp
JsonElement CloneElement(int index)
```

Clones the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The cloned JSON element.

---

## CloneElement `abstract`

```csharp
TElement CloneElement<TElement>(int index)
```

Clones the element at the specified index.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

`TElement`

The cloned JSON element.

---

