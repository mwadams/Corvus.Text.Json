---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.Dispose Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Dispose {#dispose}

```csharp
void Dispose()
```

Commits any left over JSON text that has not yet been flushed and releases all resources used by the current instance.

### Remarks

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it. The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance cannot be re-used after disposing.

