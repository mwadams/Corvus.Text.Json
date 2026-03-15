---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IByteBufferWriter — Corvus.Text.Json"
---
```csharp
public interface IByteBufferWriter : IBufferWriter<byte>, IDisposable
```

## Implements

[`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Capacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `WrittenMemory` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `WrittenSpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

## Methods

### ClearAndReturnBuffers `abstract`

```csharp
void ClearAndReturnBuffers()
```

