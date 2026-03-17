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
| [CloneElement(int)](#cloneelement-int) | Clones the element at the specified index. |
| [CloneElement(int)](#cloneelement-int) | Clones the element at the specified index. |

## CloneElement(int) {#cloneelement-int}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L559)

Clones the element at the specified index.

```csharp
public abstract JsonElement CloneElement(int index)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The cloned JSON element.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CloneElement(int) {#cloneelement-int}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L21)

Clones the element at the specified index.

```csharp
public abstract TElement CloneElement<TElement>(int index)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

