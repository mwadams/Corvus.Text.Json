---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.TryParse Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L372)

## TryParse {#tryparse}

Parses a string into a Period.

```csharp
public static bool TryParse(ReadOnlySpan<byte> value, ref Period result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `result` | [`ref Period`](/api/corvus-text-json-period.html) | The resulting period. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the period could be parsed from the string.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

