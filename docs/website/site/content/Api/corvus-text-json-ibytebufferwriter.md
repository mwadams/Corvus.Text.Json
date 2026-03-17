---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IByteBufferWriter — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IByteBufferWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/Common/src/System/Text/Json/IByteBufferWriter.cs#L7)

```csharp
public interface IByteBufferWriter : IBufferWriter<byte>, IDisposable
```

## Implements

[`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Capacity](/api/corvus-text-json-ibytebufferwriter.capacity.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| [WrittenMemory](/api/corvus-text-json-ibytebufferwriter.writtenmemory.html) | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| [WrittenSpan](/api/corvus-text-json-ibytebufferwriter.writtenspan.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

## Methods

| Method | Description |
|--------|-------------|
| [ClearAndReturnBuffers()](/api/corvus-text-json-ibytebufferwriter.clearandreturnbuffers.html#clearandreturnbuffers) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

