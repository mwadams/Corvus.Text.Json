---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseOffsetTime Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ParseOffsetTime {#parseoffsettime}

```csharp
public static OffsetTime ParseOffsetTime(ReadOnlySpan<byte> text)
```

Parse an offset time from a UTF-8 encoded string for the `time` format.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

### Returns

[`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html)

The resulting offset time.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid time. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

