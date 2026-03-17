---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.MatchRegularExpression Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#matchregularexpression-readonlyspan-byte-regex-string-readonlyspan-byte-ref-jsonschemacontext) | Validates that a string length equals the given value. |
| [MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex)](#matchregularexpression-readonlyspan-byte-regex) | Validates that a string length equals the given value. |

## MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext) {#matchregularexpression-readonlyspan-byte-regex-string-readonlyspan-byte-ref-jsonschemacontext}

**Source:** [JsonSchemaEvaluation.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.String.cs#L139)

Validates that a string length equals the given value.

```csharp
public static bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression, string originalExpressionString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `regularExpression` | [`Regex`](https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex) |  |
| `originalExpressionString` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
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

---

## MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex) {#matchregularexpression-readonlyspan-byte-regex}

**Source:** [JsonSchemaEvaluation.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaEvaluation.String.cs#L188)

Validates that a string length equals the given value.

```csharp
public static bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `regularExpression` | [`Regex`](https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

