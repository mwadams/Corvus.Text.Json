---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchItemCountGreaterThanOrEquals Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaEvaluation.Array.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.Array.cs#L301)

## MatchItemCountGreaterThanOrEquals {#matchitemcountgreaterthanorequals}

Validates that a item count is greater than or equal to the given value.

```csharp
public static bool MatchItemCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than or equal to the given value; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

