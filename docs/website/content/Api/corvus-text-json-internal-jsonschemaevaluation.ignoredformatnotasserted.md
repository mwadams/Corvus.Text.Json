---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.IgnoredFormatNotAsserted Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## IgnoredFormatNotAsserted {#ignoredformatnotasserted}

```csharp
public static bool IgnoredFormatNotAsserted(Span<byte> buffer, ref int written)
```

Tries to write a message indicating that the format was not asserted.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the message to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

