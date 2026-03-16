---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Uri.TryFormatDisplay Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryFormatDisplay {#tryformatdisplay}

```csharp
public bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI in canonical form for display.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written to the buffer; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

