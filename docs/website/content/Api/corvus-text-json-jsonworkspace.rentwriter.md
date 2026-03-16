---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.RentWriter Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## RentWriter {#rentwriter}

```csharp
public Utf8JsonWriter RentWriter(IBufferWriter<byte> bufferWriter)
```

Rents a UTF-8 JSON writer from the pool that writes to the specified buffer writer.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | The buffer writer to write JSON data to. |

### Returns

[`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html)

A rented UTF-8 JSON writer configured with the workspace options.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

