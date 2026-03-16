---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementExtensions.IsNotNullOrUndefined Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## IsNotNullOrUndefined {#isnotnullorundefined}

```csharp
public static bool IsNotNullOrUndefined<T>(T value)
```

Gets a value indicating whether this value is neither null nor undefined.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is neither null nor undefined.

