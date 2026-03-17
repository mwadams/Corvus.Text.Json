---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseDateCore Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ParseDateCore {#parsedatecore}

```csharp
public static bool ParseDateCore(ReadOnlySpan<byte> text, ref int year, ref int month, ref int day)
```

Parses a date string in ISO 8601 format (YYYY-MM-DD) and extracts the year, month, and day components.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the date string to parse. |
| `year` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the year component of the date. |
| `month` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the month component of the date (1-12). |
| `day` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the day component of the date (1-31). |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was successfully parsed; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

