---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Pow Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Pow {#pow}

```csharp
BigNumber Pow(BigNumber value, int exponent)
```

Raises a BigNumber to an integer power.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The base value. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The integer exponent. |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The value raised to the specified power.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when exponent is negative. |

