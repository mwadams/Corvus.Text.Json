---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatPeriod Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryFormatPeriod `static`

```csharp
bool TryFormatPeriod(ref Period value, Span<byte> output, ref int bytesWritten)
```

Format a period as a UTF-8 string for the `duration` format.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the period was formatted successfully.

