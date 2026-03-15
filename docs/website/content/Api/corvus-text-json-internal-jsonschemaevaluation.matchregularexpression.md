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
| [MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex, string, ReadOnlySpan&lt;byte&gt;, ref JsonSchemaContext)](#bool-matchregularexpression-readonlyspan-byte-value-regex-regularexpression-string-originalexpressionstring-readonlyspan-byte-keyword-ref-jsonschemacontext-context) | Validates that a string length equals the given value. |
| [MatchRegularExpression(ReadOnlySpan&lt;byte&gt;, Regex)](#bool-matchregularexpression-readonlyspan-byte-value-regex-regularexpression) | Validates that a string length equals the given value. |

## MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression, string originalExpressionString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length equals the given value.

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

---

## MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression)
```

Validates that a string length equals the given value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `regularExpression` | [`Regex`](https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

---

