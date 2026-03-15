---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T> — Corvus.Text.Json"
---
```csharp
public sealed class ParsedJsonDocument<T> : JsonDocument, IJsonDocument, IDisposable
```

Represents the structure of a JSON value in a lightweight, read-only form.

## Remarks

This class utilizes resources from pooled memory to minimize the garbage collector (GC) impact in high-usage scenarios. Failure to properly Dispose this object will result in the memory not being returned to the pool, which will cause an increase in GC impact across various parts of the framework.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) → **ParsedJsonDocument<T>**

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [False](/api/corvus-text-json-parsedjsondocument-t.false.html) `static` | `T` | Gets the False instance. |
| [Null](/api/corvus-text-json-parsedjsondocument-t.null.html) `static` | `T` | Gets the null instance. |
| [RootElement](/api/corvus-text-json-parsedjsondocument-t.rootelement.html) | `T` | The [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) representing the value of the document. |
| [True](/api/corvus-text-json-parsedjsondocument-t.true.html) `static` | `T` | Gets the True instance. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-parsedjsondocument-t.dispose.html#void-dispose) |  |
| [NumberConstant(byte\[\])](/api/corvus-text-json-parsedjsondocument-t.numberconstant.html#t-numberconstant-byte-utf8number) `static` | Creates a constant number instance that does not require disposal. |
| [Parse(ReadOnlyMemory&lt;byte&gt;, JsonDocumentOptions)](/api/corvus-text-json-parsedjsondocument-t.parse.html#parsedjsondocument-t-parse-readonlymemory-byte-utf8json-jsondocumentoptions-options) `static` | Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(ReadOnlySequence&lt;byte&gt;, JsonDocumentOptions)](/api/corvus-text-json-parsedjsondocument-t.parse.html#parsedjsondocument-t-parse-readonlysequence-byte-utf8json-jsondocumentoptions-options) `static` | Parse a sequence as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(Stream, JsonDocumentOptions)](/api/corvus-text-json-parsedjsondocument-t.parse.html#parsedjsondocument-t-parse-stream-utf8json-jsondocumentoptions-options) `static` | Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion. |
| [Parse(ReadOnlyMemory&lt;char&gt;, JsonDocumentOptions)](/api/corvus-text-json-parsedjsondocument-t.parse.html#parsedjsondocument-t-parse-readonlymemory-char-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a ParsedJsonDocument. |
| [Parse(string, JsonDocumentOptions)](/api/corvus-text-json-parsedjsondocument-t.parse.html#parsedjsondocument-t-parse-string-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a ParsedJsonDocument. |
| [ParseAsync(Stream, JsonDocumentOptions, CancellationToken)](/api/corvus-text-json-parsedjsondocument-t.parseasync.html#task-parsedjsondocument-t-parseasync-stream-utf8json-jsondocumentoptions-options-cancellationtoken-cancellationtoken) `static` | Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion. |
| [ParseValue(ref Utf8JsonReader)](/api/corvus-text-json-parsedjsondocument-t.parsevalue.html#parsedjsondocument-t-parsevalue-ref-utf8jsonreader-reader) `static` | Parses one JSON value (including objects or arrays) from the provided reader. |
| [StringConstant(byte\[\])](/api/corvus-text-json-parsedjsondocument-t.stringconstant.html#t-stringconstant-byte-quotedutf8string) `static` | Creates a constant string instance that does not require disposal. |
| [TryParseValue(ref Utf8JsonReader, ref ParsedJsonDocument&lt;T&gt;)](/api/corvus-text-json-parsedjsondocument-t.tryparsevalue.html#bool-tryparsevalue-ref-utf8jsonreader-reader-ref-parsedjsondocument-t-document) `static` | Attempts to parse one JSON value (including objects or arrays) from the provided reader. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-parsedjsondocument-t.writeto.html#void-writeto-utf8jsonwriter-writer) | Write the document into the provided writer as a JSON value. |

