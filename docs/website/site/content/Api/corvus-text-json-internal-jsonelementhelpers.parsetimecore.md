---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseTimeCore Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.DateTime.Core.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.DateTime.Core.cs#L173)

## ParseTimeCore {#parsetimecore}

Parses a time string in ISO 8601 format (HH:MM:SS[.nnnnnnnnn]) and extracts the time components.

```csharp
public static bool ParseTimeCore(ReadOnlySpan<byte> text, ref int hours, ref int minutes, ref int seconds, ref int milliseconds, ref int microseconds, ref int nanoseconds)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the time string to parse. |
| `hours` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the hours component of the time (0-23). |
| `minutes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the minutes component of the time (0-59). |
| `seconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the seconds component of the time (0-59). |
| `milliseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the milliseconds component of the time (0-999). |
| `microseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the microseconds component of the time (0-999). |
| `nanoseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the nanoseconds component of the time (0-999). |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the time was successfully parsed; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

