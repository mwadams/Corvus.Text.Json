---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchGreaterThan Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## MatchGreaterThan {#matchgreaterthan}

```csharp
public static bool MatchGreaterThan(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number greater than.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the left hand side is negative. |
| `leftIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the left hand side. |
| `leftFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the left hand side. |
| `leftExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the left hand side. |
| `rightIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the right hand side is negative. |
| `rightIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the right hand side. |
| `rightFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the right hand side. |
| `rightExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the right hand side. |
| `rightValue` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string representation of the right hand side. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side is less than the right hand side.

