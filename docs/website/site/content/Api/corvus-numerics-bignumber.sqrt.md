---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Sqrt Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Sqrt {#sqrt}

```csharp
public static BigNumber Sqrt(BigNumber value, int precision)
```

Computes the square root of a BigNumber using Newton's method.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to find the square root of. |
| `precision` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places of precision. |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The square root.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when value is negative. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when precision is negative. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

