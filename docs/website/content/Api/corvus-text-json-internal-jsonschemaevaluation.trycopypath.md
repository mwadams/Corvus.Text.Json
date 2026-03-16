---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.TryCopyPath Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryCopyPath {#trycopypath}

```csharp
bool TryCopyPath(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy the path to the output buffer.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

The path must be a fully canonical URI.

