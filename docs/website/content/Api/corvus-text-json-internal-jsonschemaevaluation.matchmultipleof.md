---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchMultipleOf Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#bool-matchmultipleof-readonlyspan-byte-integral-readonlyspan-byte-fractional-int-exponent-ulong-divisor-int-divisorexponent-string-divisorvalue-readonlyspan-byte-keyword-ref-jsonschemacontext-context) | Matches a JSON number as a multiple of the given divisor. |
| [MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#bool-matchmultipleof-readonlyspan-byte-integral-readonlyspan-byte-fractional-int-exponent-biginteger-divisor-int-divisorexponent-string-divisorvalue-readonlyspan-byte-keyword-ref-jsonschemacontext-context) | Matches a JSON number as a multiple of the given divisor. |

## MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The significand of the divisor represented as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string representation of the divisor. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

### Remarks

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

---

## MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The significand of the divisor represented as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string representation of the divisor. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

### Remarks

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

---

