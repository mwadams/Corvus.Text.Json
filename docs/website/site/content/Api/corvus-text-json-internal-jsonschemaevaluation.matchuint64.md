---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchUInt64 Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaEvaluation.Number.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.Number.cs#L1281)

## MatchUInt64 {#matchuint64}

Matches a JSON number against the UInt64 type constraint, validating it as a 64-bit unsigned integer.

```csharp
public static bool MatchUInt64(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid UInt64; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

