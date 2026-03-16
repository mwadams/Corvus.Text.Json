---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatOffsetDateTime Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryFormatOffsetDateTime {#tryformatoffsetdatetime}

```csharp
bool TryFormatOffsetDateTime(ref OffsetDateTime value, Span<byte> output, ref int bytesWritten)
```

Format an offset date time as a UTF-8 string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was formatted successfully.

