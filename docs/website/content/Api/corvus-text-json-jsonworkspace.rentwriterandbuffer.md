---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.RentWriterAndBuffer Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## RentWriterAndBuffer

```csharp
Utf8JsonWriter RentWriterAndBuffer(int defaultBufferSize, ref IByteBufferWriter bufferWriter)
```

Rents a UTF-8 JSON writer and associated buffer writer from the pool.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `defaultBufferSize` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The default buffer size to use for the buffer writer. |
| `bufferWriter` | [`ref IByteBufferWriter`](/api/corvus-text-json-ibytebufferwriter.html) | When this method returns, contains the rented buffer writer. |

### Returns

[`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html)

A rented UTF-8 JSON writer configured with the workspace options.

