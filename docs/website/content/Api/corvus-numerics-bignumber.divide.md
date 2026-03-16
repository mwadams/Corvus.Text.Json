---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Divide Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Divide {#divide}

```csharp
BigNumber Divide(BigNumber dividend, BigNumber divisor, int precision)
```

Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with specified precision.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `dividend` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The dividend. |
| `divisor` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The divisor. |
| `precision` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places of precision. |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The quotient.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`DivideByZeroException`](https://learn.microsoft.com/dotnet/api/system.dividebyzeroexception) | Thrown when divisor is zero. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when precision is negative. |

