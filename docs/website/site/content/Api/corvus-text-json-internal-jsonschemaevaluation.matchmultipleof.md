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
| [MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#matchmultipleof-readonlyspan-byte-readonlyspan-byte-int-ulong-int-string-readonlyspan-byte-ref-jsonschemacontext) | Matches a JSON number as a multiple of the given divisor. |
| [MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#matchmultipleof-readonlyspan-byte-readonlyspan-byte-int-biginteger-int-string-readonlyspan-byte-ref-jsonschemacontext) | Matches a JSON number as a multiple of the given divisor. |

## MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, ulong, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext) {#matchmultipleof-readonlyspan-byte-readonlyspan-byte-int-ulong-int-string-readonlyspan-byte-ref-jsonschemacontext}

**Source:** [JsonSchemaEvaluation.Number.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.Number.cs#L322)

Matches a JSON number as a multiple of the given divisor.

```csharp
public static bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## MatchMultipleOf(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, BigInteger, int, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext) {#matchmultipleof-readonlyspan-byte-readonlyspan-byte-int-biginteger-int-string-readonlyspan-byte-ref-jsonschemacontext}

**Source:** [JsonSchemaEvaluation.Number.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.Number.cs#L564)

Matches a JSON number as a multiple of the given divisor.

```csharp
public static bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

