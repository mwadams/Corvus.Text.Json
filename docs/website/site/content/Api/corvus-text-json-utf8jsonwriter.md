---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L39)

Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text.

```csharp
public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
```

## Remarks

It writes the text sequentially with no caching and adheres to the JSON RFC by default (https:// tools.ietf.org/html/rfc8259), with the exception of writing comments. When the user attempts to write invalid JSON and validation is enabled, it throws an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) with a context specific error message. To be able to format the output with indentation and whitespace OR to skip validation, create an instance of [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) and pass that in to the writer.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **Utf8JsonWriter**

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable), [`IAsyncDisposable`](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [Utf8JsonWriter(...)](/api/corvus-text-json-utf8jsonwriter.ctor.html) | Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `bufferWriter`. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [BytesCommitted](/api/corvus-text-json-utf8jsonwriter.bytescommitted.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far. |
| [BytesPending](/api/corvus-text-json-utf8jsonwriter.bytespending.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Returns the amount of bytes written by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far that have not yet been flushed to the output and committed. |
| [CurrentDepth](/api/corvus-text-json-utf8jsonwriter.currentdepth.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Tracks the recursive depth of the nested objects / arrays within the JSON text written so far. This provides the depth of the current token. |
| [Options](/api/corvus-text-json-utf8jsonwriter.options.html) | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Gets the custom behavior when writing JSON using the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) which indicates whether to format the output while writing and whether to skip str... |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-utf8jsonwriter.dispose.html#dispose) | Commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance. |
| [DisposeAsync()](/api/corvus-text-json-utf8jsonwriter.disposeasync.html#disposeasync) | Asynchronously commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance. |
| [Flush()](/api/corvus-text-json-utf8jsonwriter.flush.html#flush) | Commits the JSON text written so far which makes it visible to the output destination. |
| [FlushAsync(CancellationToken)](/api/corvus-text-json-utf8jsonwriter.flushasync.html#flushasync-cancellationtoken) | Asynchronously commits the JSON text written so far which makes it visible to the output destination. |
| [Reset](/api/corvus-text-json-utf8jsonwriter.reset.html) | Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used. |
| [WriteBase64String](/api/corvus-text-json-utf8jsonwriter.writebase64string.html) | Writes the pre-encoded property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object. |
| [WriteBase64StringSegment(ReadOnlySpan&lt;byte&gt;, bool)](/api/corvus-text-json-utf8jsonwriter.writebase64stringsegment.html#writebase64stringsegment-readonlyspan-byte-bool) | Writes the input bytes as a partial JSON string. |
| [WriteBase64StringValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-utf8jsonwriter.writebase64stringvalue.html#writebase64stringvalue-readonlyspan-byte) | Writes the raw bytes value as a Base64 encoded JSON string as an element of a JSON array. |
| [WriteBoolean](/api/corvus-text-json-utf8jsonwriter.writeboolean.html) | Writes the pre-encoded property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object. |
| [WriteBooleanValue(bool)](/api/corvus-text-json-utf8jsonwriter.writebooleanvalue.html#writebooleanvalue-bool) | Writes the [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as an element of a JSON array. |
| [WriteCommentValue](/api/corvus-text-json-utf8jsonwriter.writecommentvalue.html) | Writes the string text value (as a JSON comment). |
| [WriteEndArray()](/api/corvus-text-json-utf8jsonwriter.writeendarray.html#writeendarray) | Writes the end of a JSON array. |
| [WriteEndObject()](/api/corvus-text-json-utf8jsonwriter.writeendobject.html#writeendobject) | Writes the end of a JSON object. |
| [WriteNull](/api/corvus-text-json-utf8jsonwriter.writenull.html) | Writes the pre-encoded property name and the JSON literal "null" as part of a name/value pair of a JSON object. |
| [WriteNullValue()](/api/corvus-text-json-utf8jsonwriter.writenullvalue.html#writenullvalue) | Writes the JSON literal "null" as an element of a JSON array. |
| [WriteNumber](/api/corvus-text-json-utf8jsonwriter.writenumber.html) | Writes the pre-encoded property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumberValue](/api/corvus-text-json-utf8jsonwriter.writenumbervalue.html) | Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as an element of a JSON array. |
| [WritePropertyName](/api/corvus-text-json-utf8jsonwriter.writepropertyname.html) | Writes the pre-encoded property name (as a JSON string) as the first part of a name/value pair of a JSON object. |
| [WriteRawValue](/api/corvus-text-json-utf8jsonwriter.writerawvalue.html) | Writes the input as JSON content. It is expected that the input content is a single complete JSON value. |
| [WriteStartArray](/api/corvus-text-json-utf8jsonwriter.writestartarray.html) | Writes the beginning of a JSON array. |
| [WriteStartObject](/api/corvus-text-json-utf8jsonwriter.writestartobject.html) | Writes the beginning of a JSON object. |
| [WriteString](/api/corvus-text-json-utf8jsonwriter.writestring.html) | Writes the pre-encoded property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteStringValue](/api/corvus-text-json-utf8jsonwriter.writestringvalue.html) | Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValueSegment](/api/corvus-text-json-utf8jsonwriter.writestringvaluesegment.html) | Writes the text value segment as a partial JSON string. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

