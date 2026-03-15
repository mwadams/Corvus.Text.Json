---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation — Corvus.Text.Json.Internal"
---
```csharp
public static class JsonSchemaEvaluation
```

Support for JSON Schema matching implementations.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonSchemaEvaluation**

## Methods

### MatchTypeNull `static`

```csharp
bool MatchTypeNull(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "null" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is null; otherwise, `false`.

### MatchTypeBoolean `static`

```csharp
bool MatchTypeBoolean(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "boolean" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a boolean; otherwise, `false`.

### MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression, string originalExpressionString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `regularExpression` | [`Regex`](https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex) |  |
| `originalExpressionString` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `regularExpression` | [`Regex`](https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchStringConstantValue `static`

```csharp
bool MatchStringConstantValue(ReadOnlySpan<byte> actual, ReadOnlySpan<byte> expected, string expectedString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `actual` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `expected` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value expected. |
| `expectedString` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchLengthEquals `static`

```csharp
bool MatchLengthEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchLengthNotEquals `static`

```csharp
bool MatchLengthNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is not equal to the given value; otherwise, `false`.

### MatchLengthGreaterThan `static`

```csharp
bool MatchLengthGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than the given value; otherwise, `false`.

### MatchLengthGreaterThanOrEquals `static`

```csharp
bool MatchLengthGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than or equal to the given value; otherwise, `false`.

### MatchLengthLessThan `static`

```csharp
bool MatchLengthLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than the given value; otherwise, `false`.

### MatchLengthLessThanOrEquals `static`

```csharp
bool MatchLengthLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than or equal to the given value; otherwise, `false`.

### MatchDate `static`

```csharp
bool MatchDate(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 date format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid ISO 8601 date; otherwise, `false`.

### MatchDateTime `static`

```csharp
bool MatchDateTime(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 offset date-time format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid ISO 8601 offset date-time; otherwise, `false`.

### MatchDuration `static`

```csharp
bool MatchDuration(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 duration format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid ISO 8601 duration; otherwise, `false`.

### MatchEmail `static`

```csharp
bool MatchEmail(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid email address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid email address; otherwise, `false`.

### MatchHostname `static`

```csharp
bool MatchHostname(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid hostname format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid hostname; otherwise, `false`.

### MatchIdnEmail `static`

```csharp
bool MatchIdnEmail(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid internationalized domain name (IDN) email address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IDN email address; otherwise, `false`.

### MatchIdnHostname `static`

```csharp
bool MatchIdnHostname(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid internationalized domain name (IDN) hostname format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IDN hostname; otherwise, `false`.

### MatchIPV4 `static`

```csharp
bool MatchIPV4(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid IPv4 address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IPv4 address; otherwise, `false`.

### MatchIPV6 `static`

```csharp
bool MatchIPV6(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid IPv6 address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IPv6 address; otherwise, `false`.

### MatchIri `static`

```csharp
bool MatchIri(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Internationalized Resource Identifier (IRI) format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IRI; otherwise, `false`.

### MatchIriReference `static`

```csharp
bool MatchIriReference(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Internationalized Resource Identifier (IRI) reference format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid IRI reference; otherwise, `false`.

### MatchJsonPointer `static`

```csharp
bool MatchJsonPointer(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid JSON Pointer format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid JSON Pointer; otherwise, `false`.

### MatchRegex `static`

```csharp
bool MatchRegex(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid ECMAScript regular expression format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid regex; otherwise, `false`.

### MatchRelativeJsonPointer `static`

```csharp
bool MatchRelativeJsonPointer(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid relative JSON Pointer format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid relative JSON Pointer; otherwise, `false`.

### MatchTime `static`

```csharp
bool MatchTime(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 offset time format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid ISO 8601 offset time; otherwise, `false`.

### MatchTypeString `static`

```csharp
bool MatchTypeString(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the string type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type matches the string type constraint; otherwise, `false`.

### MatchUri `static`

```csharp
bool MatchUri(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid URI; otherwise, `false`.

### MatchUriReference `static`

```csharp
bool MatchUriReference(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI reference format (absolute or relative URI).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid URI reference; otherwise, `false`.

### MatchUriTemplate `static`

```csharp
bool MatchUriTemplate(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI template format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid URI template; otherwise, `false`.

### MatchUuid `static`

```csharp
bool MatchUuid(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid UUID format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid UUID; otherwise, `false`.

### MatchBase64String `static`

```csharp
bool MatchBase64String(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Base64-encoded string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid Base64-encoded string; otherwise, `false`.

### MatchJsonContent `static`

```csharp
bool MatchJsonContent(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value contains valid JSON content.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is valid JSON content; otherwise, `false`.

### MatchBase64Content `static`

```csharp
bool MatchBase64Content(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Base64-encoded JSON document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string value to validate. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is a valid Base64-encoded JSON document; otherwise, `false`.

### SchemaLocationForIndexedKeyword `static`

```csharp
bool SchemaLocationForIndexedKeyword(ReadOnlySpan<byte> keywordSchemaLocation, int index, Span<byte> buffer, ref int written)
```

Creates a schema location for an indexed keyword by appending the index to the base location.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `keywordSchemaLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The base schema location for the keyword. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index to append to the location. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the resulting location to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### SchemaLocationForIndexedKeywordWithDependency `static`

```csharp
bool SchemaLocationForIndexedKeywordWithDependency(ReadOnlySpan<byte> keywordSchemaLocation, ReadOnlySpan<byte> dependencyName, int index, Span<byte> buffer, ref int written)
```

Creates a schema location for an indexed keyword by appending the index to the base location and dependency.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `keywordSchemaLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The base schema location for the keyword. |
| `dependencyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the dependency. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index to append to the location. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the resulting location to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### TryCopyMessage `static`

```csharp
bool TryCopyMessage(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy a message to the specified buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The message to copy. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to copy the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the copy succeeded; otherwise, `false`.

### TryCopyPath `static`

```csharp
bool TryCopyPath(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy the path to the output buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

The path must be a fully canonical URI.

### ExpectedType `static`

```csharp
bool ExpectedType(ReadOnlySpan<byte> typeName, Span<byte> buffer, ref int written)
```

Tries to write a message indicating the expected type for a value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `typeName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the expected type. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### ExpectedMultipleOfDivisor `static`

```csharp
bool ExpectedMultipleOfDivisor(string divisor, Span<byte> buffer, ref int written)
```

Tries to write a message indicating the expected type for a value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `divisor` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The integral part of the divisor. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### IgnoredUnrecognizedFormat `static`

```csharp
bool IgnoredUnrecognizedFormat(Span<byte> buffer, ref int written)
```

Tries to write a message indicating that the format was not recognized.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### IgnoredFormatNotAsserted `static`

```csharp
bool IgnoredFormatNotAsserted(Span<byte> buffer, ref int written)
```

Tries to write a message indicating that the format was not asserted.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### MatchTypeArray `static`

```csharp
bool MatchTypeArray(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "array" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a start array; otherwise, `false`.

### SchemaLocationForItemIndex `static`

```csharp
bool SchemaLocationForItemIndex(ReadOnlySpan<byte> arraySchemaLocation, int itemIndex, Span<byte> buffer, ref int written)
```

Writes the schema location for an item at a specific index in an array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arraySchemaLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The base schema location for the array. |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the item within the array. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the schema location to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the schema location was successfully written; otherwise, `false`.

### ExpectedItemCountEqualsValue `static`

```csharp
bool ExpectedItemCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedItemCountNotEqualsValue `static`

```csharp
bool ExpectedItemCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedItemCountGreaterThanValue `static`

```csharp
bool ExpectedItemCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedItemCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedItemCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedItemCountLessThanValue `static`

```csharp
bool ExpectedItemCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedItemCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedItemCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### MatchItemCountEquals `static`

```csharp
bool MatchItemCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchItemCountNotEquals `static`

```csharp
bool MatchItemCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is not equal to the given value; otherwise, `false`.

### MatchItemCountGreaterThan `static`

```csharp
bool MatchItemCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than the given value; otherwise, `false`.

### MatchItemCountGreaterThanOrEquals `static`

```csharp
bool MatchItemCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than or equal to the given value; otherwise, `false`.

### MatchItemCountLessThan `static`

```csharp
bool MatchItemCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than the given value; otherwise, `false`.

### MatchItemCountLessThanOrEquals `static`

```csharp
bool MatchItemCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than or equal to the given value; otherwise, `false`.

### ExpectedContainsCountEqualsValue `static`

```csharp
bool ExpectedContainsCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedContainsCountNotEqualsValue `static`

```csharp
bool ExpectedContainsCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedContainsCountGreaterThanValue `static`

```csharp
bool ExpectedContainsCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedContainsCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedContainsCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedContainsCountLessThanValue `static`

```csharp
bool ExpectedContainsCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedContainsCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedContainsCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### MatchContainsCountEquals `static`

```csharp
bool MatchContainsCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchContainsCountNotEquals `static`

```csharp
bool MatchContainsCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is not equal to the given value; otherwise, `false`.

### MatchContainsCountGreaterThan `static`

```csharp
bool MatchContainsCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than the given value; otherwise, `false`.

### MatchContainsCountGreaterThanOrEquals `static`

```csharp
bool MatchContainsCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than or equal to the given value; otherwise, `false`.

### MatchContainsCountLessThan `static`

```csharp
bool MatchContainsCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than the given value; otherwise, `false`.

### MatchContainsCountLessThanOrEquals `static`

```csharp
bool MatchContainsCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than or equal to the given value; otherwise, `false`.

### MatchTypeObject `static`

```csharp
bool MatchTypeObject(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "object" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a start object; otherwise, `false`.

### MatchPropertyCountEquals `static`

```csharp
bool MatchPropertyCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is equal to the given value; otherwise, `false`.

### MatchPropertyCountNotEquals `static`

```csharp
bool MatchPropertyCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is not equal to the given value; otherwise, `false`.

### MatchPropertyCountGreaterThan `static`

```csharp
bool MatchPropertyCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than the given value; otherwise, `false`.

### MatchPropertyCountGreaterThanOrEquals `static`

```csharp
bool MatchPropertyCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is greater than or equal to the given value; otherwise, `false`.

### MatchPropertyCountLessThan `static`

```csharp
bool MatchPropertyCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than the given value; otherwise, `false`.

### MatchPropertyCountLessThanOrEquals `static`

```csharp
bool MatchPropertyCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `actual` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The JSON schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is less than or equal to the given value; otherwise, `false`.

### ExpectedPropertyCountEqualsValue `static`

```csharp
bool ExpectedPropertyCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedPropertyCountNotEqualsValue `static`

```csharp
bool ExpectedPropertyCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedPropertyCountGreaterThanValue `static`

```csharp
bool ExpectedPropertyCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedPropertyCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedPropertyCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedPropertyCountLessThanValue `static`

```csharp
bool ExpectedPropertyCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedPropertyCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedPropertyCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ExpectedMatchPatternPropertySchemaValue `static`

```csharp
bool ExpectedMatchPatternPropertySchemaValue(string expression, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a property name was intended to match a regular expression.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expression` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The regular expression that should be matched. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### ExpectedPropertyNameMatchesRegularExpressionValue `static`

```csharp
bool ExpectedPropertyNameMatchesRegularExpressionValue(string expression, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a property name was intended to match a regular expression.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expression` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The regular expression that should be matched. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### ExpectedMatchesDependentSchemaValue `static`

```csharp
bool ExpectedMatchesDependentSchemaValue(string propertyName, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a value was expected to match a schema becaused it contained a specific named property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property that caused the schema to mat. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

### RequiredPropertyNotPresent `static`

```csharp
bool RequiredPropertyNotPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, ref int written)
```

Creates a message indicating that a required property is not present.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the missing required property. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the message was successfully written; otherwise, `false`.

### RequiredPropertyPresent `static`

```csharp
bool RequiredPropertyPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, ref int written)
```

Creates a message indicating that a required property is present.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the required property that is present. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the message was successfully written; otherwise, `false`.

### MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The significand of the divisor represented as a `UInt64`. |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string representation of the divisor. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

### MatchEquals `static`

```csharp
bool MatchEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number equals.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side equals the right hand side.

### MatchNotEquals `static`

```csharp
bool MatchNotEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number not equals.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side does not equal the right hand side.

### MatchLessThan `static`

```csharp
bool MatchLessThan(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number less than.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side is less than the right hand side.

### MatchLessThanOrEquals `static`

```csharp
bool MatchLessThanOrEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number less than or equals.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side is less than or equal to the right hand side.

### MatchGreaterThan `static`

```csharp
bool MatchGreaterThan(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number greater than.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side is less than the right hand side.

### MatchGreaterThanOrEquals `static`

```csharp
bool MatchGreaterThanOrEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number greater than or equals.

**Parameters:**

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the left hand side is less than or equal to the right hand side.

### MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The significand of the divisor represented as a `UInt64`. |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string representation of the divisor. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

### MatchByte `static`

```csharp
bool MatchByte(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Byte type constraint, validating it as an 8-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Byte; otherwise, `false`.

### MatchDecimal `static`

```csharp
bool MatchDecimal(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Decimal type constraint, validating it as a decimal floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Decimal; otherwise, `false`.

### MatchDouble `static`

```csharp
bool MatchDouble(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Double type constraint, validating it as a double-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Double; otherwise, `false`.

### MatchHalf `static`

```csharp
bool MatchHalf(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Half type constraint, validating it as a half-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Half; otherwise, `false`.

### MatchInt128 `static`

```csharp
bool MatchInt128(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int128 type constraint, validating it as a 128-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Int128; otherwise, `false`.

### MatchInt16 `static`

```csharp
bool MatchInt16(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int16 type constraint, validating it as a 16-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Int16; otherwise, `false`.

### MatchInt32 `static`

```csharp
bool MatchInt32(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int32 type constraint, validating it as a 32-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Int32; otherwise, `false`.

### MatchInt64 `static`

```csharp
bool MatchInt64(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int64 type constraint, validating it as a 64-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Int64; otherwise, `false`.

### MatchSByte `static`

```csharp
bool MatchSByte(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the SByte type constraint, validating it as an 8-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid SByte; otherwise, `false`.

### MatchSingle `static`

```csharp
bool MatchSingle(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Single type constraint, validating it as a single-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid Single; otherwise, `false`.

### MatchTypeNumber `static`

```csharp
bool MatchTypeNumber(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "number" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a number; otherwise, `false`.

### MatchTypeInteger `static`

```csharp
bool MatchTypeInteger(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, int exponent, ref JsonSchemaContext context)
```

Matches a JSON token type against the "number" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The JSON token type to validate. |
| `typeKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The type keyword being evaluated. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the token type is a number; otherwise, `false`.

### MatchUInt128 `static`

```csharp
bool MatchUInt128(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt128 type constraint, validating it as a 128-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid UInt128; otherwise, `false`.

### MatchUInt16 `static`

```csharp
bool MatchUInt16(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt16 type constraint, validating it as a 16-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid UInt16; otherwise, `false`.

### MatchUInt32 `static`

```csharp
bool MatchUInt32(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt32 type constraint, validating it as a 32-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid UInt32; otherwise, `false`.

### MatchUInt64 `static`

```csharp
bool MatchUInt64(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt64 type constraint, validating it as a 64-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the number. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the number. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `keyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword being evaluated. |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The schema validation context. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number is a valid UInt64; otherwise, `false`.

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `IgnoredNotTypeNull` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedTypeNull` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedNull` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeBoolean` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedTypeBoolean` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedBooleanTrue` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedBooleanFalse` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeString` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | A message provider for ignored non-string type validation. |
| `ExpectedTypeString` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | A message provider for expected string type validation. |
| `ExpectedStringEquals` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) | A message provider for expected string constant validation. |
| `MatchedMoreThanOneSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when more than one schema matches in a composition constraint. |
| `MatchedNoSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when no schema matches in a composition constraint. |
| `MatchedAllSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when all schemas match in a composition constraint. |
| `DidNotMatchAllSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when all schemas do not match in a composition constraint. |
| `MatchedAtLeastOneSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when at least one schema matches in a composition constraint. |
| `MatchedExactlyOneSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when at least one schema matches in a composition constraint. |
| `DidNotMatchAtLeastOneSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when no schemas matched in a composition constraint. |
| `MatchedAtLeastOneConstantValue` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when at least one constant value matches in a composition constraint. |
| `DidNotMatchAtLeastOneConstantValue` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when no constant values matched in a composition constraint. |
| `DidNotMatchNotSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value (correctly) did not match a not schema in a composition constraint. |
| `MatchedNotSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value (incorrectly) matched a not schema in a composition constraint. |
| `MatchedIfForThen` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value matches a binary or ternary if to go on to match a then clause. |
| `DidNotMatchThen` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value did not match the then clause for a binary or ternary if. |
| `MatchedThen` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value matches the corresponding then clause for a binary or ternary if. |
| `MatchedIfForElse` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value does not match a ternary if and so goes on to match an else clause. |
| `DidNotMatchElse` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value does not match a ternary if and then did not match the corresponding else clause. |
| `MatchedElse` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for validation errors when a value matches the corresponding then clause for a binary or ternary if. |
| `ExpectedConstant` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `EvaluatedSubschema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeArray` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for ignored "not array type" validation messages. |
| `ItemIndex` `static` | [`JsonSchemaPathProvider<int>`](/api/corvus-text-json-jsonschemapathprovider.html) | Provides a path provider for array item indices in JSON schema validation. |
| `ExpectedTypeArray` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Message provider for expected "array type" validation messages. |
| `ExpectedUniqueItems` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountNotEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountGreaterThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountGreaterThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountLessThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedItemCountLessThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountNotEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountGreaterThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountGreaterThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountLessThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedContainsCountLessThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeObject` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedTypeObject` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountNotEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountGreaterThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountGreaterThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountLessThan` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyCountLessThanOrEquals` `static` | [`JsonSchemaMessageProvider<int>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedMatchPatternPropertySchema` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyNameMatchesRegularExpression` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyNameMatchesSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedPropertyMatchesFallbackSchema` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedMatchesDependentSchema` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeNumber` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `IgnoredNotTypeInteger` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedTypeNumber` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedTypeInteger` `static` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedMultipleOf` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |
| `ExpectedEquals` `static` | [`JsonSchemaMessageProvider<string>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  |

