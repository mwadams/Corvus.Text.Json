---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter — Corvus.Text.Json"
---
```csharp
public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
```

Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text.

## Remarks

It writes the text sequentially with no caching and adheres to the JSON RFC by default (https:// tools.ietf.org/html/rfc8259), with the exception of writing comments. When the user attempts to write invalid JSON and validation is enabled, it throws an `InvalidOperationException` with a context specific error message. To be able to format the output with indentation and whitespace OR to skip validation, create an instance of [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) and pass that in to the writer.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **Utf8JsonWriter**

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable), [`IAsyncDisposable`](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

## Constructors

### Utf8JsonWriter

```csharp
Utf8JsonWriter(IBufferWriter<byte> bufferWriter, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `bufferWriter`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | An instance of `IBufferWriter` used as a destination for writing JSON text into. |
| `options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Defines the customized behavior of the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) By default, the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of `IBufferWriter` that is passed in is null. |

### Utf8JsonWriter

```csharp
Utf8JsonWriter(Stream utf8Json, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `utf8Json`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | An instance of `Stream` used as a destination for writing JSON text into. |
| `options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Defines the customized behavior of the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) By default, the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of `Stream` that is passed in is null. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `BytesPending` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Returns the amount of bytes written by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far that have not yet been flushed to the output and committed. |
| `BytesCommitted` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far. |
| `Options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Gets the custom behavior when writing JSON using the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) which indicates whether to format the output while writing and whether to skip str... |
| `CurrentDepth` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Tracks the recursive depth of the nested objects / arrays within the JSON text written so far. This provides the depth of the current token. |

### BytesCommitted

```csharp
long BytesCommitted { get; set; }
```

Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far.

In the case of IBufferwriter, this is how much the IBufferWriter has advanced. In the case of Stream, this is how much data has been written to the stream.

## Methods

### WriteBase64StringSegment

```csharp
void WriteBase64StringSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

Writes the input bytes as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The bytes to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

### WriteStringValueSegment

```csharp
void WriteStringValueSegment(ReadOnlySpan<char> value, bool isFinalSegment)
```

Writes the text value segment as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

The value is escaped before writing.

### WriteStringValueSegment

```csharp
void WriteStringValueSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

Writes the UTF-8 text value segment as a partial JSON string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

The value is escaped before writing.

### Reset

```csharp
void Reset()
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options and the original output as the destination (either `IBufferWriter` or `Stream`).

### Reset

```csharp
void Reset(Stream utf8Json)
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of `Stream`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | An instance of `Stream` used as a destination for writing JSON text into. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of `Stream` that is passed in is null. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options but now write to the passed in `Stream` as the new destination.

### Reset

```csharp
void Reset(IBufferWriter<byte> bufferWriter)
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of `IBufferWriter`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | An instance of `IBufferWriter` used as a destination for writing JSON text into. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of `IBufferWriter` that is passed in is null. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options but now write to the passed in `IBufferWriter` as the new destination.

### Flush

```csharp
void Flush()
```

Commits the JSON text written so far which makes it visible to the output destination.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

In the case of IBufferWriter, this advances the underlying `IBufferWriter` based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it.

### Dispose

```csharp
void Dispose()
```

Commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance.

In the case of IBufferWriter, this advances the underlying `IBufferWriter` based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it. The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance cannot be re-used after disposing.

### DisposeAsync

```csharp
ValueTask DisposeAsync()
```

Asynchronously commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance.

**Returns:** [`ValueTask`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)

In the case of IBufferWriter, this advances the underlying `IBufferWriter` based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it. The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance cannot be re-used after disposing.

### FlushAsync

```csharp
Task FlushAsync(CancellationToken cancellationToken)
```

Asynchronously commits the JSON text written so far which makes it visible to the output destination.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `cancellationToken` | [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) |  *(optional)* |

**Returns:** [`Task`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

In the case of IBufferWriter, this advances the underlying `IBufferWriter` based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it asynchronously, while monitoring cancellation requests.

### WriteStartArray

```csharp
void WriteStartArray()
```

Writes the beginning of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### WriteStartObject

```csharp
void WriteStartObject()
```

Writes the beginning of a JSON object.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### WriteStartArray

```csharp
void WriteStartArray(JsonEncodedText propertyName)
```

Writes the beginning of a JSON array with a pre-encoded property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### WriteStartObject

```csharp
void WriteStartObject(JsonEncodedText propertyName)
```

Writes the beginning of a JSON object with a pre-encoded property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON array to be written. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteStartObject

```csharp
void WriteStartObject(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON object to be written. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteStartArray

```csharp
void WriteStartArray(string propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteStartObject

```csharp
void WriteStartObject(string propertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<char> propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteStartObject

```csharp
void WriteStartObject(ReadOnlySpan<char> propertyName)
```

Writes the beginning of a JSON object with a property name as the key.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteEndArray

```csharp
void WriteEndArray()
```

Writes the end of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteEndObject

```csharp
void WriteEndObject()
```

Writes the end of a JSON object.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteBase64String

```csharp
void WriteBase64String(JsonEncodedText propertyName, ReadOnlySpan<byte> bytes)
```

Writes the pre-encoded property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteBase64String

```csharp
void WriteBase64String(string propertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteBase64String

```csharp
void WriteBase64String(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteBase64String

```csharp
void WriteBase64String(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
```

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTime value)
```

Writes the pre-encoded property name and `DateTime` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTime` using the round-trip ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000. The property name should already be escaped when the instance of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) was created.

### WriteString

```csharp
void WriteString(string propertyName, DateTime value)
```

Writes the property name and `DateTime` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTime` using the round-trip ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTime value)
```

Writes the property name and `DateTime` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTime` using the round-trip ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
```

Writes the property name and `DateTime` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTime` using the round-trip ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTimeOffset value)
```

Writes the pre-encoded property name and `DateTimeOffset` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTimeOffset` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000-07:00.

### WriteString

```csharp
void WriteString(string propertyName, DateTimeOffset value)
```

Writes the property name and `DateTimeOffset` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTimeOffset` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTimeOffset value)
```

Writes the property name and `DateTimeOffset` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTimeOffset` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
```

Writes the property name and `DateTimeOffset` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON object to be written. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTimeOffset` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, decimal value)
```

Writes the pre-encoded property name and `Decimal` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Decimal` using the default `StandardFormat` (that is, 'G').

### WriteNumber

```csharp
void WriteNumber(string propertyName, decimal value)
```

Writes the property name and `Decimal` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Decimal` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, decimal value)
```

Writes the property name and `Decimal` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Decimal` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, decimal value)
```

Writes the property name and `Decimal` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Decimal` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, double value)
```

Writes the pre-encoded property name and `Double` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Double` using the default `StandardFormat` (that is, 'G').

### WriteNumber

```csharp
void WriteNumber(string propertyName, double value)
```

Writes the property name and `Double` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Double` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, double value)
```

Writes the property name and `Double` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Double` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, double value)
```

Writes the property name and `Double` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Double` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, float value)
```

Writes the pre-encoded property name and `Single` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Single` using the default `StandardFormat` (that is, 'G').

### WriteNumber

```csharp
void WriteNumber(string propertyName, float value)
```

Writes the property name and `Single` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Single` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, float value)
```

Writes the property name and `Single` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Single` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, float value)
```

Writes the property name and `Single` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Single` using the default `StandardFormat` (that is, 'G'). The property name is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, Guid value)
```

Writes the pre-encoded property name and `Guid` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Guid` using the default `StandardFormat` (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

### WriteString

```csharp
void WriteString(string propertyName, Guid value)
```

Writes the property name and `Guid` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Guid` using the default `StandardFormat` (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, Guid value)
```

Writes the property name and `Guid` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Guid` using the default `StandardFormat` (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, Guid value)
```

Writes the property name and `Guid` value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Guid` using the default `StandardFormat` (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

### WriteBoolean

```csharp
void WriteBoolean(JsonEncodedText propertyName, bool value)
```

Writes the pre-encoded property name and `Boolean` value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteBoolean

```csharp
void WriteBoolean(string propertyName, bool value)
```

Writes the property name and `Boolean` value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<char> propertyName, bool value)
```

Writes the property name and `Boolean` value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<byte> utf8PropertyName, bool value)
```

Writes the property name and `Boolean` value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteNull

```csharp
void WriteNull(JsonEncodedText propertyName)
```

Writes the pre-encoded property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteNull

```csharp
void WriteNull(string propertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteNull

```csharp
void WriteNull(ReadOnlySpan<char> propertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteNull

```csharp
void WriteNull(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the property name and the JSON literal "null" as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, long value)
```

Writes the pre-encoded property name and `Int64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int64` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumber

```csharp
void WriteNumber(string propertyName, long value)
```

Writes the property name and `Int64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, long value)
```

Writes the property name and `Int64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, long value)
```

Writes the property name and `Int64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, int value)
```

Writes the pre-encoded property name and `Int32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int32` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumber

```csharp
void WriteNumber(string propertyName, int value)
```

Writes the property name and `Int32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int32` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, int value)
```

Writes the property name and `Int32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int32` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, int value)
```

Writes the property name and `Int32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int32` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WritePropertyName

```csharp
void WritePropertyName(JsonEncodedText propertyName)
```

Writes the pre-encoded property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WritePropertyName

```csharp
void WritePropertyName(string propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WritePropertyName

```csharp
void WritePropertyName(ReadOnlySpan<char> propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WritePropertyName

```csharp
void WritePropertyName(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the UTF-8 property name (as a JSON string) as the first part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, JsonEncodedText value)
```

Writes the pre-encoded property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteString

```csharp
void WriteString(string propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The JSON-encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteString

```csharp
void WriteString(string propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html) were called.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, string value)
```

Writes the pre-encoded property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html) was called.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<char> value)
```

Writes the pre-encoded property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

### WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
```

Writes the UTF-8 property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the pre-encoded property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

### WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html) was called.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, JsonEncodedText value)
```

Writes the UTF-8 property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name is escaped before writing.

### WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, string value)
```

Writes the UTF-8 property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html) was called.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, ulong value)
```

Writes the pre-encoded property name and `UInt64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt64` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumber

```csharp
void WriteNumber(string propertyName, ulong value)
```

Writes the property name and `UInt64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, ulong value)
```

Writes the property name and `UInt64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ulong value)
```

Writes the property name and `UInt64` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt64` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, uint value)
```

Writes the pre-encoded property name and `UInt32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt32` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumber

```csharp
void WriteNumber(string propertyName, uint value)
```

Writes the property name and `UInt32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt32` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, uint value)
```

Writes the property name and `UInt32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt32` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, uint value)
```

Writes the property name and `UInt32` value (as a JSON number) as part of a name/value pair of a JSON object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt32` using the default `StandardFormat` (that is, 'G'), for example: 32767. The property name is escaped before writing.

### WriteBase64StringValue

```csharp
void WriteBase64StringValue(ReadOnlySpan<byte> bytes)
```

Writes the raw bytes value as a Base64 encoded JSON string as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The bytes are encoded before writing.

### WriteCommentValue

```csharp
void WriteCommentValue(string value)
```

Writes the string text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given string text value contains a comment delimiter (that is, */). |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `value` parameter is `null`. |

The comment value is not escaped before writing.

### WriteCommentValue

```csharp
void WriteCommentValue(ReadOnlySpan<char> value)
```

Writes the text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given text value contains a comment delimiter (that is, */). |

The comment value is not escaped before writing.

### WriteCommentValue

```csharp
void WriteCommentValue(ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 text value (as a JSON comment).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON comment within /*..*/. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given UTF-8 text value contains a comment delimiter (that is, */). |

The comment value is not escaped before writing.

### WriteStringValue

```csharp
void WriteStringValue(DateTime value)
```

Writes the `DateTime` value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTime` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000.

### WriteStringValue

```csharp
void WriteStringValue(DateTimeOffset value)
```

Writes the `DateTimeOffset` value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `DateTimeOffset` using the round-trippable ('O') `StandardFormat`, for example: 2017-06-12T05:30:45.7680000-07:00.

### WriteNumberValue

```csharp
void WriteNumberValue(decimal value)
```

Writes the `Decimal` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Decimal` using the default `StandardFormat` (that is, 'G').

### WriteNumberValue

```csharp
void WriteNumberValue(double value)
```

Writes the `Double` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Double` using the default `StandardFormat` on .NET Core 3 or higher and 'G17' on any other framework.

### WriteNumberValue

```csharp
void WriteNumberValue(float value)
```

Writes the `Single` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Single` using the default `StandardFormat` on .NET Core 3 or higher and 'G9' on any other framework.

### WriteStringValue

```csharp
void WriteStringValue(Guid value)
```

Writes the `Guid` value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Guid` using the default `StandardFormat` (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

### WriteBooleanValue

```csharp
void WriteBooleanValue(bool value)
```

Writes the `Boolean` value (as a JSON literal "true" or "false") as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteNullValue

```csharp
void WriteNullValue()
```

Writes the JSON literal "null" as an element of a JSON array.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteRawValue

```csharp
void WriteRawValue(string json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown if `json` is `null`. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than 715,827,882 (`MaxValue` / 3). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html) values for the writer instance are not applied when using this method.

### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<char> json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than 715,827,882 (`MaxValue` / 3). |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html) values for the writer instance are not applied when using this method.

### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySpan<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or greater than or equal to `MaxValue`. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html) values for the writer instance are not applied when using this method.

### WriteRawValue

```csharp
void WriteRawValue(ReadOnlySequence<byte> utf8Json, bool skipInputValidation)
```

Writes the input as JSON content. It is expected that the input content is a single complete JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The raw JSON content to write. |
| `skipInputValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to validate if the input is an RFC 8259-compliant JSON payload. *(optional)* |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown if the length of the input is zero or equal to `MaxValue`. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown if `skipInputValidation` is `false`, and the input is not a valid, complete, single JSON value according to the JSON RFC (https:// tools.ietf.org/html/rfc8259) or the input JSON exceeds a recursive depth of 64. |

When writing untrused JSON values, do not set `skipInputValidation` to `true` as this can result in invalid JSON being written, and/or the overall payload being written to the writer instance being invalid. When using this method, the input content will be written to the writer destination as-is, unless validation fails (when it is enabled). The [`SkipValidation`](/api/corvus-text-json-jsonwriteroptions.html) value for the writer instance is honored when using this method. The [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) and [`Encoder`](/api/corvus-text-json-jsonwriteroptions.html) values for the writer instance are not applied when using this method.

### WriteNumberValue

```csharp
void WriteNumberValue(int value)
```

Writes the `Int32` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int32` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumberValue

```csharp
void WriteNumberValue(long value)
```

Writes the `Int64` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `Int64` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteStringValue

```csharp
void WriteStringValue(JsonEncodedText value)
```

Writes the pre-encoded text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### WriteStringValue

```csharp
void WriteStringValue(string value)
```

Writes the string text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNullValue`](/api/corvus-text-json-utf8jsonwriter.html) was called.

### WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<char> value)
```

Writes the text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

### WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 text value (as a JSON string) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

The value is escaped before writing.

### WriteNumberValue

```csharp
void WriteNumberValue(uint value)
```

Writes the `UInt32` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt32` using the default `StandardFormat` (that is, 'G'), for example: 32767.

### WriteNumberValue

```csharp
void WriteNumberValue(ulong value)
```

Writes the `UInt64` value (as a JSON number) as an element of a JSON array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

Writes the `UInt64` using the default `StandardFormat` (that is, 'G'), for example: 32767.

