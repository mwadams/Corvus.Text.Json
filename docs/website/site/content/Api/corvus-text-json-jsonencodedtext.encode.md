---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonEncodedText.Encode Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Encode(string, JavaScriptEncoder)](#encode-string-javascriptencoder) | Encodes the string text value as a JSON string. |
| [Encode(ReadOnlySpan&lt;char&gt;, JavaScriptEncoder)](#encode-readonlyspan-char-javascriptencoder) | Encodes the text value as a JSON string. |
| [Encode(ReadOnlySpan&lt;byte&gt;, JavaScriptEncoder)](#encode-readonlyspan-byte-javascriptencoder) | Encodes the UTF-8 text value as a JSON string. |

## Encode(string, JavaScriptEncoder) {#encode-string-javascriptencoder}

**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L59)

Encodes the string text value as a JSON string.

```csharp
public static JsonEncodedText Encode(string value, JavaScriptEncoder encoder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

### Returns

[`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown if value is null. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Encode(ReadOnlySpan&lt;char&gt;, JavaScriptEncoder) {#encode-readonlyspan-char-javascriptencoder}

**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L74)

Encodes the text value as a JSON string.

```csharp
public static JsonEncodedText Encode(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

### Returns

[`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Encode(ReadOnlySpan&lt;byte&gt;, JavaScriptEncoder) {#encode-readonlyspan-byte-javascriptencoder}

**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L92)

Encodes the UTF-8 text value as a JSON string.

```csharp
public static JsonEncodedText Encode(ReadOnlySpan<byte> utf8Value, JavaScriptEncoder encoder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

### Returns

[`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-8 bytes. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

