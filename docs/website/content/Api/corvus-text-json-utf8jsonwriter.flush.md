---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.Flush Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Flush {#flush}

```csharp
void Flush()
```

Commits the JSON text written so far which makes it visible to the output destination.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

### Remarks

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it.

