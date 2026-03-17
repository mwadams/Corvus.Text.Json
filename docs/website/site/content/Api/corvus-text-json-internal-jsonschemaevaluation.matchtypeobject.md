---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchTypeObject Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaEvaluation.Object.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.Object.cs#L54)

## MatchTypeObject {#matchtypeobject}

Matches a JSON token type against the "object" type constraint.

```csharp
public static bool MatchTypeObject(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a start object; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

