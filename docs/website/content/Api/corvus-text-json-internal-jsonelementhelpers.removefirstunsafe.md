---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.RemoveFirstUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## RemoveFirstUnsafe `static`

```csharp
bool RemoveFirstUnsafe<TArray, T>(TArray arrayElement, ref T item)
```

Removes the first array element that equals the specified item.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |
| `T` | The type of the item to find and remove. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `item` | `ref T` | The item to find and remove. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if an element was found and removed; otherwise, `false`.

