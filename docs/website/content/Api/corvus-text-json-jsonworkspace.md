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
| [Create(int, Nullable&lt;JsonWriterOptions&gt;)](/api/corvus-text-json-jsonworkspace.create.html#create-int-nullable-jsonwriteroptions) `static` | Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html). |
| [CreateBuilder](/api/corvus-text-json-jsonworkspace.createbuilder.html) | Creates a document builder for building mutable JSON documents from an existing element. |
| [CreateUnrented(int, Nullable&lt;JsonWriterOptions&gt;)](/api/corvus-text-json-jsonworkspace.createunrented.html#createunrented-int-nullable-jsonwriteroptions) `static` | Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html). |
| [Dispose()](/api/corvus-text-json-jsonworkspace.dispose.html#dispose) | Disposes the workspace. If the workspace was rented from the cache, returns it; otherwise disposes all child documents and returns the backing array to the pool. |
| [RentWriter(IBufferWriter&lt;byte&gt;)](/api/corvus-text-json-jsonworkspace.rentwriter.html#rentwriter-ibufferwriter-byte) | Rents a UTF-8 JSON writer from the pool that writes to the specified buffer writer. |
| [RentWriterAndBuffer(int, ref IByteBufferWriter)](/api/corvus-text-json-jsonworkspace.rentwriterandbuffer.html#rentwriterandbuffer-int-ref-ibytebufferwriter) | Rents a UTF-8 JSON writer and associated buffer writer from the pool. |
| [ReturnWriter(Utf8JsonWriter)](/api/corvus-text-json-jsonworkspace.returnwriter.html#returnwriter-utf8jsonwriter) | Returns a rented UTF-8 JSON writer to the pool. |
| [ReturnWriterAndBuffer(Utf8JsonWriter, IByteBufferWriter)](/api/corvus-text-json-jsonworkspace.returnwriterandbuffer.html#returnwriterandbuffer-utf8jsonwriter-ibytebufferwriter) | Returns a rented UTF-8 JSON writer and buffer writer to the pool. |

