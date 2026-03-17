---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseOffsetCore Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ParseOffsetCore {#parseoffsetcore}

```csharp
public static bool ParseOffsetCore(ReadOnlySpan<byte> text, ref int offsetSeconds)
```

Parses a timezone offset string in ISO 8601 format (±HH:MM or Z) and extracts the offset in seconds.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the offset string to parse. |
| `offsetSeconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the timezone offset in seconds from UTC. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the offset was successfully parsed; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

