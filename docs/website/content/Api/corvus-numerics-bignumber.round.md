---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Round Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Round {#round}

```csharp
public static BigNumber Round(BigNumber value, int decimals, MidpointRounding mode)
```

Rounds a value to a specified number of decimal places.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to round. |
| `decimals` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places. |
| `mode` | [`MidpointRounding`](https://learn.microsoft.com/dotnet/api/system.midpointrounding) | The rounding mode. *(optional)* |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The rounded value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when decimals is negative. |

