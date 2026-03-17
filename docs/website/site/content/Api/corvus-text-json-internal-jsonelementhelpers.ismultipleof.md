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
| [IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int)](#ismultipleof-readonlyspan-byte-readonlyspan-byte-int-ulong-int) | Determines whether the normalized JSON number is an exact multiple of the given integer divisor. |
| [IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int)](#ismultipleof-readonlyspan-byte-readonlyspan-byte-int-biginteger-int) | Determines whether the normalized JSON number is an exact multiple of the given integer divisor. |

## IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int) {#ismultipleof-readonlyspan-byte-readonlyspan-byte-int-ulong-int}

**Source:** [JsonElementHelpers.Numeric.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.Numeric.cs#L194)

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

```csharp
public static bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## IsMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int) {#ismultipleof-readonlyspan-byte-readonlyspan-byte-int-biginteger-int}

**Source:** [JsonElementHelpers.Numeric.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.Numeric.cs#L267)

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

```csharp
public static bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

