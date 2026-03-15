---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.IsMultipleOf Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int)](#bool-ismultipleof-readonlyspan-byte-integral-readonlyspan-byte-fractional-int-exponent-ulong-divisor-int-divisorexponent) | Determines whether the normalized JSON number is an exact multiple of the given integer divisor. |
| [IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int)](#bool-ismultipleof-readonlyspan-byte-integral-readonlyspan-byte-fractional-int-exponent-biginteger-divisor-int-divisorexponent) | Determines whether the normalized JSON number is an exact multiple of the given integer divisor. |

## IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The significand of the divisor represented as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

### Remarks

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

---

## IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The significand of the divisor represented as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

### Remarks

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

---

