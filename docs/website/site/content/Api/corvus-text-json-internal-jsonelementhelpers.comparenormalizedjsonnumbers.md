---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.CompareNormalizedJsonNumbers Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.Numeric.Core.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.Numeric.Core.cs#L304)

## CompareNormalizedJsonNumbers {#comparenormalizedjsonnumbers}

Compares two normalized JSON numbers for equality.

```csharp
public static int CompareNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True if the LHS is negative. |
| `leftIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `leftFractional` produces the significand of the LHS number without leading or trailing zeros. |
| `leftFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `leftIntegral` produces the significand of the LHS number without leading or trailing zeros. |
| `leftExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The LHS exponent. |
| `rightIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True if the RHS is negative. |
| `rightIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `rightFractional` produces the significand of the RHS number without leading or trailing zeros. |
| `rightFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `rightIntegral` produces the significand of the RHS number without leading or trailing zeros. |
| `rightExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The RHS exponent. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

-1 if the LHS is less than the RHS, 0 if the are equal, and 1 if the LHS is greater than the RHS.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

