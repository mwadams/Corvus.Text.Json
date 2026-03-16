---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.TryCopyMessage Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryCopyMessage {#trycopymessage}

```csharp
bool TryCopyMessage(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy a message to the specified buffer.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The message to copy. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to copy the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the copy succeeded; otherwise, `false`.

