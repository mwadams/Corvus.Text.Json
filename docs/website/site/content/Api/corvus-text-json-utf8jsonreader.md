---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L27)

Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default (https:// tools.ietf.org/html/rfc8259). When it encounters invalid JSON, it throws a JsonException with basic error information like line number and byte position on the line. Since this type is a ref struct, it does not directly support async. However, it does provide support for reentrancy to read incomplete data, and continue reading once more data is presented. To be able to set max depth while reading OR allow skipping comments, create an instance of [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) and pass that in to the reader.

```csharp
public readonly struct Utf8JsonReader
```

## Constructors

| Constructor | Description |
|-------------|-------------|
| [Utf8JsonReader(...)](/api/corvus-text-json-utf8jsonreader.ctor.html) | Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [BytesConsumed](/api/corvus-text-json-utf8jsonreader.bytesconsumed.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the total amount of bytes consumed by the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) so far for the current instance of the \[`Utf8JsonReader`\](/api/corvus-text-json-utf8j... |
| [CurrentDepth](/api/corvus-text-json-utf8jsonreader.currentdepth.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Tracks the recursive depth of the nested objects / arrays within the JSON text processed so far. This provides the depth of the current token. |
| [CurrentState](/api/corvus-text-json-utf8jsonreader.currentstate.html) | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | Returns the current snapshot of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) state which must be captured by the caller and passed back in to the \[`Utf8JsonReader`\](/api/corvus... |
| [HasValueSequence](/api/corvus-text-json-utf8jsonreader.hasvaluesequence.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Lets the caller know which of the two 'Value' properties to read to get the token value. For input data within a ReadOnlySpan<byte> this will always return false. For input data within a ReadOnlySe... |
| [IsFinalBlock](/api/corvus-text-json-utf8jsonreader.isfinalblock.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Returns the mode of this instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html). True when the reader was constructed with the input span containing the entire data to proces... |
| [Position](/api/corvus-text-json-utf8jsonreader.position.html) | [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition) | Returns the current [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition) within the provided UTF-8 encoded input ReadOnlySequence<byte>. If the \[`Utf8JsonReader`\](/a... |
| [TokenStartIndex](/api/corvus-text-json-utf8jsonreader.tokenstartindex.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space. |
| [TokenType](/api/corvus-text-json-utf8jsonreader.tokentype.html) | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | Gets the type of the last processed JSON token in the UTF-8 encoded JSON text. |
| [ValueIsEscaped](/api/corvus-text-json-utf8jsonreader.valueisescaped.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Lets the caller know whether the current [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html#valuespan) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html#valuesequence) properties ... |
| [ValueSequence](/api/corvus-text-json-utf8jsonreader.valuesequence.html) | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) |  |
| [ValueSpan](/api/corvus-text-json-utf8jsonreader.valuespan.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

## Methods

| Method | Description |
|--------|-------------|
| [CopyString](/api/corvus-text-json-utf8jsonreader.copystring.html) | Copies the current JSON token value from the source, unescaped as a UTF-8 string to the destination buffer. |
| [GetBoolean()](/api/corvus-text-json-utf8jsonreader.getboolean.html#getboolean) | Parses the current JSON token value from the source as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean). Returns `true` if the TokenType is JsonTokenType.True and `false` if the... |
| [GetByte()](/api/corvus-text-json-utf8jsonreader.getbyte.html#getbyte) | Parses the current JSON token value from the source as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). Returns the value if the entire UTF-8 encoded token value can be successfully ... |
| [GetBytesFromBase64()](/api/corvus-text-json-utf8jsonreader.getbytesfrombase64.html#getbytesfrombase64) | Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes. |
| [GetComment()](/api/corvus-text-json-utf8jsonreader.getcomment.html#getcomment) | Parses the current JSON token value from the source as a comment, transcoded as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetDateTime()](/api/corvus-text-json-utf8jsonreader.getdatetime.html#getdatetime) | Parses the current JSON token value from the source as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). Returns the value if the entire UTF-8 encoded token value can be succe... |
| [GetDateTimeOffset()](/api/corvus-text-json-utf8jsonreader.getdatetimeoffset.html#getdatetimeoffset) | Parses the current JSON token value from the source as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). Returns the value if the entire UTF-8 encoded token value ... |
| [GetDecimal()](/api/corvus-text-json-utf8jsonreader.getdecimal.html#getdecimal) | Parses the current JSON token value from the source as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). Returns the value if the entire UTF-8 encoded token value can be success... |
| [GetDouble()](/api/corvus-text-json-utf8jsonreader.getdouble.html#getdouble) | Parses the current JSON token value from the source as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). Returns the value if the entire UTF-8 encoded token value can be successfu... |
| [GetGuid()](/api/corvus-text-json-utf8jsonreader.getguid.html#getguid) | Parses the current JSON token value from the source as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). Returns the value if the entire UTF-8 encoded token value can be successfully ... |
| [GetInt16()](/api/corvus-text-json-utf8jsonreader.getint16.html#getint16) | Parses the current JSON token value from the source as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). Returns the value if the entire UTF-8 encoded token value can be successfull... |
| [GetInt32()](/api/corvus-text-json-utf8jsonreader.getint32.html#getint32) | Parses the current JSON token value from the source as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). Returns the value if the entire UTF-8 encoded token value can be successful... |
| [GetInt64()](/api/corvus-text-json-utf8jsonreader.getint64.html#getint64) | Parses the current JSON token value from the source as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). Returns the value if the entire UTF-8 encoded token value can be successfull... |
| [GetSByte()](/api/corvus-text-json-utf8jsonreader.getsbyte.html#getsbyte) | Parses the current JSON token value from the source as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). Returns the value if the entire UTF-8 encoded token value can be successful... |
| [GetSingle()](/api/corvus-text-json-utf8jsonreader.getsingle.html#getsingle) | Parses the current JSON token value from the source as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). Returns the value if the entire UTF-8 encoded token value can be successfu... |
| [GetString()](/api/corvus-text-json-utf8jsonreader.getstring.html#getstring) | Parses the current JSON token value from the source, unescaped, and transcoded as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetUInt16()](/api/corvus-text-json-utf8jsonreader.getuint16.html#getuint16) | Parses the current JSON token value from the source as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). Returns the value if the entire UTF-8 encoded token value can be successfu... |
| [GetUInt32()](/api/corvus-text-json-utf8jsonreader.getuint32.html#getuint32) | Parses the current JSON token value from the source as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). Returns the value if the entire UTF-8 encoded token value can be successfu... |
| [GetUInt64()](/api/corvus-text-json-utf8jsonreader.getuint64.html#getuint64) | Parses the current JSON token value from the source as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). Returns the value if the entire UTF-8 encoded token value can be successfu... |
| [Read()](/api/corvus-text-json-utf8jsonreader.read.html#read) | Read the next JSON token from input source. |
| [Skip()](/api/corvus-text-json-utf8jsonreader.skip.html#skip) | Skips the children of the current JSON token. |
| [TryGetByte(ref byte)](/api/corvus-text-json-utf8jsonreader.trygetbyte.html#trygetbyte-ref-byte) | Parses the current JSON token value from the source as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). Returns `true` if the entire UTF-8 encoded token value can be successfully par... |
| [TryGetBytesFromBase64(ref byte\[\])](/api/corvus-text-json-utf8jsonreader.trygetbytesfrombase64.html#trygetbytesfrombase64-ref-byte) | Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes. Returns `true` if the entire token value is encoded as valid Base64 text and can be successf... |
| [TryGetDateTime(ref DateTime)](/api/corvus-text-json-utf8jsonreader.trygetdatetime.html#trygetdatetime-ref-datetime) | Parses the current JSON token value from the source as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). Returns `true` if the entire UTF-8 encoded token value can be successf... |
| [TryGetDateTimeOffset(ref DateTimeOffset)](/api/corvus-text-json-utf8jsonreader.trygetdatetimeoffset.html#trygetdatetimeoffset-ref-datetimeoffset) | Parses the current JSON token value from the source as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). Returns `true` if the entire UTF-8 encoded token value can... |
| [TryGetDecimal(ref decimal)](/api/corvus-text-json-utf8jsonreader.trygetdecimal.html#trygetdecimal-ref-decimal) | Parses the current JSON token value from the source as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). Returns `true` if the entire UTF-8 encoded token value can be successful... |
| [TryGetDouble(ref double)](/api/corvus-text-json-utf8jsonreader.trygetdouble.html#trygetdouble-ref-double) | Parses the current JSON token value from the source as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). Returns `true` if the entire UTF-8 encoded token value can be successfully... |
| [TryGetGuid(ref Guid)](/api/corvus-text-json-utf8jsonreader.trygetguid.html#trygetguid-ref-guid) | Parses the current JSON token value from the source as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). Returns `true` if the entire UTF-8 encoded token value can be successfully par... |
| [TryGetInt16(ref short)](/api/corvus-text-json-utf8jsonreader.trygetint16.html#trygetint16-ref-short) | Parses the current JSON token value from the source as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). Returns `true` if the entire UTF-8 encoded token value can be successfully p... |
| [TryGetInt32(ref int)](/api/corvus-text-json-utf8jsonreader.trygetint32.html#trygetint32-ref-int) | Parses the current JSON token value from the source as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). Returns `true` if the entire UTF-8 encoded token value can be successfully ... |
| [TryGetInt64(ref long)](/api/corvus-text-json-utf8jsonreader.trygetint64.html#trygetint64-ref-long) | Parses the current JSON token value from the source as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). Returns `true` if the entire UTF-8 encoded token value can be successfully p... |
| [TryGetSByte(ref sbyte)](/api/corvus-text-json-utf8jsonreader.trygetsbyte.html#trygetsbyte-ref-sbyte) | Parses the current JSON token value from the source as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). Returns `true` if the entire UTF-8 encoded token value can be successfully ... |
| [TryGetSingle(ref float)](/api/corvus-text-json-utf8jsonreader.trygetsingle.html#trygetsingle-ref-float) | Parses the current JSON token value from the source as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). Returns `true` if the entire UTF-8 encoded token value can be successfully... |
| [TryGetUInt16(ref ushort)](/api/corvus-text-json-utf8jsonreader.trygetuint16.html#trygetuint16-ref-ushort) | Parses the current JSON token value from the source as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). Returns `true` if the entire UTF-8 encoded token value can be successfully... |
| [TryGetUInt32(ref uint)](/api/corvus-text-json-utf8jsonreader.trygetuint32.html#trygetuint32-ref-uint) | Parses the current JSON token value from the source as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). Returns `true` if the entire UTF-8 encoded token value can be successfully... |
| [TryGetUInt64(ref ulong)](/api/corvus-text-json-utf8jsonreader.trygetuint64.html#trygetuint64-ref-ulong) | Parses the current JSON token value from the source as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). Returns `true` if the entire UTF-8 encoded token value can be successfully... |
| [TrySkip()](/api/corvus-text-json-utf8jsonreader.tryskip.html#tryskip) | Tries to skip the children of the current JSON token. |
| [ValueTextEquals](/api/corvus-text-json-utf8jsonreader.valuetextequals.html) | Compares the UTF-8 encoded text to the unescaped JSON token value in the source and returns true if they match. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

