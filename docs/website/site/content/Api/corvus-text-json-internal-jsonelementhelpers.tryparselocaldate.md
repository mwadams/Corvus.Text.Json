---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryParseLocalDate Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.DateTime.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.DateTime.cs#L142)

## TryParseLocalDate {#tryparselocaldate}

Parse a date from a string for the `date` format.

```csharp
public static bool TryParseLocalDate(ReadOnlySpan<byte> text, ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The resulting date. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date could be parsed.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

