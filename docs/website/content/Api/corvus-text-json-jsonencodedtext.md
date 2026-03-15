---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonEncodedText — Corvus.Text.Json"
---
```csharp
public readonly struct JsonEncodedText : IEquatable<JsonEncodedText>
```

Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON.

## Remarks

This can be used to cache and store known strings used for writing JSON ahead of time by pre-encoding them up front.

## Implements

[`IEquatable<JsonEncodedText>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `EncodedUtf8Bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Returns the UTF-8 encoded representation of the pre-encoded JSON text. |
| `Value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Returns the UTF-16 encoded representation of the pre-encoded JSON text as a `String`. |

## Methods

### Encode `static`

```csharp
JsonEncodedText Encode(string value, JavaScriptEncoder encoder)
```

Encodes the string text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown if value is null. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

### Encode `static`

```csharp
JsonEncodedText Encode(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
```

Encodes the text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-16 characters. |

### Encode `static`

```csharp
JsonEncodedText Encode(ReadOnlySpan<byte> utf8Value, JavaScriptEncoder encoder)
```

Encodes the UTF-8 text value as a JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be transformed as JSON encoded text. |
| `encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping the string, or `null` to use the default encoder. *(optional)* |

**Returns:** [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large or if it contains invalid UTF-8 bytes. |

### Equals

```csharp
bool Equals(JsonEncodedText other)
```

Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

Default instances of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) are treated as equal.

### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

If `obj` is null, the method returns false.

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Returns the hash code for this [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html).

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

Returns 0 on a default instance of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html).

### ToString `virtual`

```csharp
string ToString()
```

Converts the value of this instance to a `String`.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

Returns the underlying UTF-16 encoded string.

Returns an empty string on a default instance of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html).

