---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace — Corvus.Text.Json"
---
```csharp
public class JsonWorkspace : IDisposable
```

A workspace for manipulating JSON documents.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonWorkspace**

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Options](/api/corvus-text-json-jsonworkspace.options.html) | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Gets the JsonWriterOptions |

## Methods

| Method | Description |
|--------|-------------|
| [Create(int, Nullable&lt;JsonWriterOptions&gt;)](/api/corvus-text-json-jsonworkspace.create.html#jsonworkspace-create-int-initialdocumentcapacity-nullable-jsonwriteroptions-options) `static` | Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html). |
| [CreateBuilder(TElement)](/api/corvus-text-json-jsonworkspace.createbuilder.html#jsondocumentbuilder-tmutableelement-createbuilder-telement-tmutableelement-telement-sourceelement) | Creates a document builder for building mutable JSON documents from an existing element. |
| [CreateBuilder(int, int)](/api/corvus-text-json-jsonworkspace.createbuilder.html#jsondocumentbuilder-telement-createbuilder-telement-int-initialcapacity-int-initialvaluebuffersize) | Creates a document builder for building mutable JSON documents. |
| [CreateUnrented(int, Nullable&lt;JsonWriterOptions&gt;)](/api/corvus-text-json-jsonworkspace.createunrented.html#jsonworkspace-createunrented-int-initialdocumentcapacity-nullable-jsonwriteroptions-options) `static` | Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html). |
| [Dispose()](/api/corvus-text-json-jsonworkspace.dispose.html#void-dispose) |  |
| [RentWriter(IBufferWriter&lt;byte&gt;)](/api/corvus-text-json-jsonworkspace.rentwriter.html#utf8jsonwriter-rentwriter-ibufferwriter-byte-bufferwriter) | Rents a UTF-8 JSON writer from the pool that writes to the specified buffer writer. |
| [RentWriterAndBuffer(int, ref IByteBufferWriter)](/api/corvus-text-json-jsonworkspace.rentwriterandbuffer.html#utf8jsonwriter-rentwriterandbuffer-int-defaultbuffersize-ref-ibytebufferwriter-bufferwriter) | Rents a UTF-8 JSON writer and associated buffer writer from the pool. |
| [ReturnWriter(Utf8JsonWriter)](/api/corvus-text-json-jsonworkspace.returnwriter.html#void-returnwriter-utf8jsonwriter-writer) | Returns a rented UTF-8 JSON writer to the pool. |
| [ReturnWriterAndBuffer(Utf8JsonWriter, IByteBufferWriter)](/api/corvus-text-json-jsonworkspace.returnwriterandbuffer.html#void-returnwriterandbuffer-utf8jsonwriter-writer-ibytebufferwriter-bufferwriter) | Returns a rented UTF-8 JSON writer and buffer writer to the pool. |

