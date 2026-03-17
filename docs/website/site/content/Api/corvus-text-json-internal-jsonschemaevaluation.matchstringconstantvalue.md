---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchStringConstantValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaEvaluation.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.String.cs#L225)

## MatchStringConstantValue {#matchstringconstantvalue}

Validates that a string equals the given value.

```csharp
public static bool MatchStringConstantValue(ReadOnlySpan<byte> actual, ReadOnlySpan<byte> expected, string expectedString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `actual` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `expected` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value expected. |
| `expectedString` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

