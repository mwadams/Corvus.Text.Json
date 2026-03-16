---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseOffsetDateTime Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ParseOffsetDateTime {#parseoffsetdatetime}

```csharp
OffsetDateTime ParseOffsetDateTime(ReadOnlySpan<byte> text)
```

Parse an offset date time from a UTF-8 encoded string for the `date-time` format.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

### Returns

[`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html)

The resulting offset date time.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid date time. |

