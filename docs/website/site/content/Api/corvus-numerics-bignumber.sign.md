---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Sign Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L2056)

## Sign {#sign}

Returns the sign of the number.

```csharp
public static int Sign(BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

-1 for negative, 0 for zero, 1 for positive.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

