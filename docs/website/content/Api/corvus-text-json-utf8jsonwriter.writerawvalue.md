---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteRawValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteRawValue(string, bool)](#void-writerawvalue-string-json-bool-skipinputvalidation) | Writes the input as JSON content. It is expected that the input content is a single complete JSON value. |
| [WriteRawValue(ReadOnlySpan&lt;char&gt;, bool)](#void-writerawvalue-readonlyspan-char-json-bool-skipinputvalidation) | Writes the input as JSON content. It is expected that the input content is a single complete JSON value. |
| [WriteRawValue(ReadOnlySpan&lt;byte&gt;, bool)](#void-writerawvalue-readonlyspan-byte-utf8json-bool-skipinputvalidation) | Writes the input as JSON content. It is expected that the input content is a single complete JSON value. |
| [WriteRawValue(ReadOnlySequence&lt;byte&gt;, bool)](#void-writerawvalue-readonlysequence-byte-utf8json-bool-skipinputvalidation) | Writes the input as JSON content. It is expected that the input content is a single complete JSON value. |

## WriteRawValue

```csharp
void WriteRawValue(string json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown if `json` is `null`. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than 715,827,882 ([`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int32.maxvalue#maxvalue) / 3). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

### Remarks

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html#skipvalidation) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html#encoder) values for the writer instance are not applied when using this method.

---

## WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<char> json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than 715,827,882 ([`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int32.maxvalue#maxvalue) / 3). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

### Remarks

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html#skipvalidation) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html#encoder) values for the writer instance are not applied when using this method.

---

## WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than or equal to [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int32.maxvalue#maxvalue). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

### Remarks

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html#skipvalidation) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html#encoder) values for the writer instance are not applied when using this method.

---

## WriteRawValue

```csharp
void WriteRawValue(ReadOnlySequence<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or equal to [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int32.maxvalue#maxvalue). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

### Remarks

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html#skipvalidation) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html#encoder) values for the writer instance are not applied when using this method.

---

