---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.AreEqualNormalizedJsonNumbers Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## AreEqualNormalizedJsonNumbers `static`

```csharp
bool AreEqualNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

Compares two valid normalized JSON numbers for decimal equality.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the left number is negative. |
| `leftIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the left number without leading zeros. |
| `leftFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the left number without trailing zeros. |
| `leftExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the left number. |
| `rightIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the right number is negative. |
| `rightIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the right number without leading zeros. |
| `rightFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the right number without trailing zeros. |
| `rightExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the right number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two normalized JSON numbers are equal; otherwise, `false`.

