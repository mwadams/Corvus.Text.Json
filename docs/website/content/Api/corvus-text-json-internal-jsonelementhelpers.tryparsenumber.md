---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryParseNumber Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryParseNumber `static`

```csharp
bool TryParseNumber(ReadOnlySpan<byte> span, ref bool isNegative, ref ReadOnlySpan<byte> integral, ref ReadOnlySpan<byte> fractional, ref int exponent)
```

Parses a JSON number into its component parts using normal-form decimal representation.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded span containing the JSON number to parse. |
| `isNegative` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | When this method returns, indicates whether the number is negative. |
| `integral` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the integral part of the number without leading zeros. |
| `fractional` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the fractional part of the number without trailing zeros. |
| `exponent` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the exponent value for scientific notation. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was parsed successfully, otherwise `false`.

### Remarks

The returned components use a normal-form decimal representation: Number := sign * <integral + fractional> * 10^exponent where integral and fractional are sequences of digits whose concatenation represents the significand of the number without leading or trailing zeros. Two such normal-form numbers are treated as equal if and only if they have equal signs, significands, and exponents.

