---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.RemoveWhereUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.cs#L29)

## RemoveWhereUnsafe {#removewhereunsafe}

Removes a items from an array element which match a predicate.

```csharp
public static void RemoveWhereUnsafe<TArray, T>(TArray arrayElement, JsonPredicate<T> predicate)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `predicate` | [`JsonPredicate<T>`](/api/corvus-text-json-jsonpredicate-t.html) | The predicate to apply to each element to determine if it should be removed. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html#array), or the element reference is stale due to document mutations. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

