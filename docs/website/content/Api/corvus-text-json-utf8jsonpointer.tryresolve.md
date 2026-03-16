---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonPointer.TryResolve Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryResolve {#tryresolve}

```csharp
bool TryResolve<T, TResult>(ref T jsonElement, ref TResult value)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the value at that path if it exists.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |
| `TResult` | The type of the element at the target. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `value` | `ref TResult` | The value at the target path if it exists. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was resolved successfully; otherwise, `false`.

