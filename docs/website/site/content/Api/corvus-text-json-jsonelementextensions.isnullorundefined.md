---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementExtensions.IsNullOrUndefined Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementExtensions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElementExtensions.cs#L18)

## IsNullOrUndefined {#isnullorundefined}

Gets a value indicating whether this value is null or undefined.

```csharp
public static bool IsNullOrUndefined<T>(T value)
```

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

`True` if the value is undefined.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

