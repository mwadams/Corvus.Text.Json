---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.ReturnWriterAndBuffer Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWorkspace.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonWorkspace.cs#L98)

## ReturnWriterAndBuffer {#returnwriterandbuffer}

Returns a rented UTF-8 JSON writer and buffer writer to the pool.

```csharp
public void ReturnWriterAndBuffer(Utf8JsonWriter writer, IByteBufferWriter bufferWriter)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to return to the pool. |
| `bufferWriter` | [`IByteBufferWriter`](/api/corvus-text-json-ibytebufferwriter.html) | The buffer writer to return to the pool. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

