---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchTypeArray Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## MatchTypeArray {#matchtypearray}

```csharp
public static bool MatchTypeArray(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "array" type constraint.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a start array; otherwise, `false`.

