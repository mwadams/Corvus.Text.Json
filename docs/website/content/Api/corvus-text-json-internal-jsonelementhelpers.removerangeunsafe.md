---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.RemoveRangeUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## RemoveRangeUnsafe {#removerangeunsafe}

```csharp
void RemoveRangeUnsafe<TArray>(TArray arrayElement, int startIndex, int count)
```

Removes a range of items from an array element.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The zero-based index at which to begin removing items. |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of items to remove. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html#array), or the element reference is stale due to document mutations. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

