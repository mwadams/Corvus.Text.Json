---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T> — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ParsedJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.cs#L33)

Represents the structure of a JSON value in a lightweight, read-only form.

```csharp
public sealed class ParsedJsonDocument<T> : JsonDocument, IJsonDocument, IDisposable
```

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
| [Dispose()](/api/corvus-text-json-parsedjsondocument-t.dispose.html#dispose) |  |
| [NumberConstant(byte\[\])](/api/corvus-text-json-parsedjsondocument-t.numberconstant.html#numberconstant-byte) `static` | Creates a constant number instance that does not require disposal. |
| [Parse](/api/corvus-text-json-parsedjsondocument-t.parse.html) `static` | Parse memory as UTF-8 encoded text representing a single JSON value into a ParsedJsonDocument. |
| [ParseAsync(Stream, JsonDocumentOptions, CancellationToken)](/api/corvus-text-json-parsedjsondocument-t.parseasync.html#parseasync-stream-jsondocumentoptions-cancellationtoken) `static` | Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion. |
| [ParseValue(ref Utf8JsonReader)](/api/corvus-text-json-parsedjsondocument-t.parsevalue.html#parsevalue-ref-utf8jsonreader) `static` | Parses one JSON value (including objects or arrays) from the provided reader. |
| [StringConstant(byte\[\])](/api/corvus-text-json-parsedjsondocument-t.stringconstant.html#stringconstant-byte) `static` | Creates a constant string instance that does not require disposal. |
| [TryParseValue(ref Utf8JsonReader, ref ParsedJsonDocument&lt;T&gt;)](/api/corvus-text-json-parsedjsondocument-t.tryparsevalue.html#tryparsevalue-ref-utf8jsonreader-ref-parsedjsondocument-t) `static` | Attempts to parse one JSON value (including objects or arrays) from the provided reader. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-parsedjsondocument-t.writeto.html#writeto-utf8jsonwriter) | Write the document into the provided writer as a JSON value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

