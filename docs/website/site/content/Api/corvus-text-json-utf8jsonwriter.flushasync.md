---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.FlushAsync Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L512)

## FlushAsync {#flushasync}

Asynchronously commits the JSON text written so far which makes it visible to the output destination.

```csharp
public Task FlushAsync(CancellationToken cancellationToken)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `cancellationToken` | [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) |  *(optional)* |

### Returns

[`Task`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

### Remarks

In the case of IBufferWriter, this advances the underlying [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) based on what has been written so far. In the case of Stream, this writes the data to the stream and flushes it asynchronously, while monitoring cancellation requests.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

