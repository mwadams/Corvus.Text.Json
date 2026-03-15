---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.DeepEquals Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## DeepEquals `static`

```csharp
bool DeepEquals<TLeft, TRight>(ref TLeft element1, ref TRight element2)
```

Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |
| `TRight` | The type of the second [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |
| `element2` | `ref TRight` | The second [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

### Remarks

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

