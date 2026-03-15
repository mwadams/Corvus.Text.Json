---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8JsonReader
```

Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default (https:// tools.ietf.org/html/rfc8259). When it encounters invalid JSON, it throws a JsonException with basic error information like line number and byte position on the line. Since this type is a ref struct, it does not directly support async. However, it does provide support for reentrancy to read incomplete data, and continue reading once more data is presented. To be able to set max depth while reading OR allow skipping comments, create an instance of [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) and pass that in to the reader.

## Constructors

### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySpan<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) and pass that back. |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html).

### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySpan<byte> jsonData, JsonReaderOptions options)
```

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Defines the customized behavior of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](/api/corvus-text-json-utf8jsonreader.html)= true)

### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySequence<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) and pass that back. |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html).

### Utf8JsonReader

```csharp
Utf8JsonReader(ReadOnlySequence<byte> jsonData, JsonReaderOptions options)
```

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Defines the customized behavior of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](/api/corvus-text-json-utf8jsonreader.html)= true)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueSpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `BytesConsumed` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the total amount of bytes consumed by the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) so far for the current instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8j... |
| `TokenStartIndex` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space. |
| `CurrentDepth` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Tracks the recursive depth of the nested objects / arrays within the JSON text processed so far. This provides the depth of the current token. |
| `TokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Gets the type of the last processed JSON token in the UTF-8 encoded JSON text. |
| `HasValueSequence` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Lets the caller know which of the two 'Value' properties to read to get the token value. For input data within a ReadOnlySpan<byte> this will always return false. For input data within a ReadOnlySe... |
| `ValueIsEscaped` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Lets the caller know whether the current [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html) properties contain escape sequences... |
| `IsFinalBlock` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Returns the mode of this instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html). True when the reader was constructed with the input span containing the entire data to proces... |
| `ValueSequence` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) |  |
| `Position` | [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition) | Returns the current `SequencePosition` within the provided UTF-8 encoded input ReadOnlySequence<byte>. If the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) was constructed with a Re... |
| `CurrentState` | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | Returns the current snapshot of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) state which must be captured by the caller and passed back in to the [`Utf8JsonReader`](/api/corvus... |

### TokenStartIndex

```csharp
long TokenStartIndex { get; set; }
```

Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space.

For JSON strings (including property names), this points to before the start quote. For comments, this points to before the first comment delimiter (i.e. '/').

## Methods

### Read

```csharp
bool Read()
```

Read the next JSON token from input source.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the token was read successfully, else false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown when an invalid JSON token is encountered according to the JSON RFC or if the current depth exceeds the recursive limit set by the max depth. |

### Skip

```csharp
void Skip()
```

Skips the children of the current JSON token.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the reader was given partial data with more data to follow (i.e. [`IsFinalBlock`](/api/corvus-text-json-utf8jsonreader.html) is false). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown when an invalid JSON token is encountered while skipping, according to the JSON RFC, or if the current depth exceeds the recursive limit set by the max depth. |

When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html), the reader first moves to the property value. When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) (originally, or after advancing) is [`StartObject`](/api/corvus-text-json-internal-jsontokentype.html) or [`StartArray`](/api/corvus-text-json-internal-jsontokentype.html), the reader advances to the matching [`EndObject`](/api/corvus-text-json-internal-jsontokentype.html) or [`EndArray`](/api/corvus-text-json-internal-jsontokentype.html). For all other token types, the reader does not move. After the next call to [`Read`](/api/corvus-text-json-utf8jsonreader.html), the reader will be at the next value (when in an array), the next property name (when in an object), or the end array/object token.

### TrySkip

```csharp
bool TrySkip()
```

Tries to skip the children of the current JSON token.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if there was enough data for the children to be skipped successfully, else false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown when an invalid JSON token is encountered while skipping, according to the JSON RFC, or if the current depth exceeds the recursive limit set by the max depth. |

If the reader did not have enough data to completely skip the children of the current token, it will be reset to the state it was in before the method was called. When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html), the reader first moves to the property value. When [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) (originally, or after advancing) is [`StartObject`](/api/corvus-text-json-internal-jsontokentype.html) or [`StartArray`](/api/corvus-text-json-internal-jsontokentype.html), the reader advances to the matching [`EndObject`](/api/corvus-text-json-internal-jsontokentype.html) or [`EndArray`](/api/corvus-text-json-internal-jsontokentype.html). For all other token types, the reader does not move. After the next call to [`Read`](/api/corvus-text-json-utf8jsonreader.html), the reader will be at the next value (when in an array), the next property name (when in an object), or the end array/object token.

### ValueTextEquals

```csharp
bool ValueTextEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the UTF-8 encoded text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the UTF-8 encoded look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html)). |

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

### ValueTextEquals

```csharp
bool ValueTextEquals(string text)
```

Compares the string text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html)). |

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

### ValueTextEquals

```csharp
bool ValueTextEquals(ReadOnlySpan<char> text)
```

Compares the text to the unescaped JSON token value in the source and returns true if they match.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the look up text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html)). |

If the look up text is invalid or incomplete UTF-16 text (i.e. unpaired surrogates), the method will return false since you cannot have invalid UTF-16 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

### CopyString

```csharp
int CopyString(Span<byte> utf8Destination)
```

Copies the current JSON token value from the source, unescaped as a UTF-8 string to the destination buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A buffer to write the unescaped UTF-8 bytes into. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of bytes written to `utf8Destination`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The destination buffer is too small to hold the unescaped value. |

Unlike [`GetString`](/api/corvus-text-json-utf8jsonreader.html), this method does not support [`Null`](/api/corvus-text-json-internal-jsontokentype.html). This method will throw `ArgumentException` if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html), since the unescaped result is always less than or equal to the length of the encoded strings.

### CopyString

```csharp
int CopyString(Span<char> destination)
```

Copies the current JSON token value from the source, unescaped, and transcoded as a UTF-16 char buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A buffer to write the transcoded UTF-16 characters into. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of characters written to `destination`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The destination buffer is too small to hold the unescaped value. |

Unlike [`GetString`](/api/corvus-text-json-utf8jsonreader.html), this method does not support [`Null`](/api/corvus-text-json-internal-jsontokentype.html). This method will throw `ArgumentException` if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html), since the unescaped result is always less than or equal to the length of the encoded strings.

### GetBoolean

```csharp
bool GetBoolean()
```

Parses the current JSON token value from the source as a `Boolean`. Returns `true` if the TokenType is JsonTokenType.True and `false` if the TokenType is JsonTokenType.False.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a boolean (i.e. [`True`](/api/corvus-text-json-internal-jsontokentype.html) or [`False`](/api/corvus-text-json-internal-jsontokentype.html)). |

### GetByte

```csharp
byte GetByte()
```

Parses the current JSON token value from the source as a `Byte`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Byte` value. Throws exceptions otherwise.

**Returns:** [`byte`](https://learn.microsoft.com/dotnet/api/system.byte)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes.

**Returns:** [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The JSON string contains data outside of the expected Base64 range, or if it contains invalid/more than two padding characters, or is incomplete (i.e. the JSON string length is not a multiple of 4). |

### GetComment

```csharp
string GetComment()
```

Parses the current JSON token value from the source as a comment, transcoded as a `String`.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a comment. |

### GetDateTime

```csharp
DateTime GetDateTime()
```

Parses the current JSON token value from the source as a `DateTime`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `DateTime` value. Throws exceptions otherwise.

**Returns:** [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format. Only a subset of ISO 8601 formats are supported. |

### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

Parses the current JSON token value from the source as a `DateTimeOffset`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `DateTimeOffset` value. Throws exceptions otherwise.

**Returns:** [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format. Only a subset of ISO 8601 formats are supported. |

### GetDecimal

```csharp
decimal GetDecimal()
```

Parses the current JSON token value from the source as a `Decimal`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Decimal` value. Throws exceptions otherwise.

**Returns:** [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value represents a number less than `MinValue` or greater than `MaxValue`. |

### GetDouble

```csharp
double GetDouble()
```

Parses the current JSON token value from the source as a `Double`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Double` value. Throws exceptions otherwise.

**Returns:** [`double`](https://learn.microsoft.com/dotnet/api/system.double)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than `MinValue` or greater than `MaxValue`. |

### GetGuid

```csharp
Guid GetGuid()
```

Parses the current JSON token value from the source as a `Guid`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Guid` value. Throws exceptions otherwise.

**Returns:** [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format for a Guid. |

### GetInt16

```csharp
short GetInt16()
```

Parses the current JSON token value from the source as a `Int16`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Int16` value. Throws exceptions otherwise.

**Returns:** [`short`](https://learn.microsoft.com/dotnet/api/system.int16)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetInt32

```csharp
int GetInt32()
```

Parses the current JSON token value from the source as an `Int32`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to an `Int32` value. Throws exceptions otherwise.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetInt64

```csharp
long GetInt64()
```

Parses the current JSON token value from the source as a `Int64`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Int64` value. Throws exceptions otherwise.

**Returns:** [`long`](https://learn.microsoft.com/dotnet/api/system.int64)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetSByte

```csharp
sbyte GetSByte()
```

Parses the current JSON token value from the source as an `SByte`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to an `SByte` value. Throws exceptions otherwise.

**Returns:** [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetSingle

```csharp
float GetSingle()
```

Parses the current JSON token value from the source as a `Single`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `Single` value. Throws exceptions otherwise.

**Returns:** [`float`](https://learn.microsoft.com/dotnet/api/system.single)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than `MinValue` or greater than `MaxValue`. |

### GetString

```csharp
string GetString()
```

Parses the current JSON token value from the source, unescaped, and transcoded as a `String`.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html), [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html) or [`Null`](/api/corvus-text-json-internal-jsontokentype.html)). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |

Returns `null` when [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) is [`Null`](/api/corvus-text-json-internal-jsontokentype.html).

### GetUInt16

```csharp
ushort GetUInt16()
```

Parses the current JSON token value from the source as a `UInt16`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `UInt16` value. Throws exceptions otherwise.

**Returns:** [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetUInt32

```csharp
uint GetUInt32()
```

Parses the current JSON token value from the source as a `UInt32`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `UInt32` value. Throws exceptions otherwise.

**Returns:** [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### GetUInt64

```csharp
ulong GetUInt64()
```

Parses the current JSON token value from the source as a `UInt64`. Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a `UInt64` value. Throws exceptions otherwise.

**Returns:** [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than `MinValue` or greater than `MaxValue`. |

### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

Parses the current JSON token value from the source as a `Byte`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Byte` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes. Returns `true` if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

Parses the current JSON token value from the source as a `DateTime`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `DateTime` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

Parses the current JSON token value from the source as a `DateTimeOffset`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `DateTimeOffset` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

Parses the current JSON token value from the source as a `Decimal`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Decimal` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

Parses the current JSON token value from the source as a `Double`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Double` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

Parses the current JSON token value from the source as a `Guid`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Guid` value. Only supports `Guid` values with hyphens and without any surrounding decorations. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

Parses the current JSON token value from the source as a `Int16`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Int16` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

Parses the current JSON token value from the source as an `Int32`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to an `Int32` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

Parses the current JSON token value from the source as a `Int64`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Int64` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

Parses the current JSON token value from the source as an `SByte`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to an `SByte` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

Parses the current JSON token value from the source as a `Single`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `Single` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

Parses the current JSON token value from the source as a `UInt16`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `UInt16` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

Parses the current JSON token value from the source as a `UInt32`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `UInt32` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

Parses the current JSON token value from the source as a `UInt64`. Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a `UInt64` value. Returns `false` otherwise.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html). |

