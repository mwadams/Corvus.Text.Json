---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchContainsCountLessThan Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## MatchContainsCountLessThan {#matchcontainscountlessthan}

```csharp
bool MatchContainsCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is less than the given value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than the given value; otherwise, `false`.

