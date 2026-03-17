---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.FromMilliseconds Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L436)

## FromMilliseconds {#frommilliseconds}

Creates a period representing the specified number of milliseconds.

```csharp
public static Period FromMilliseconds(long milliseconds)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `milliseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of milliseconds in the new period. |

### Returns

[`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of milliseconds.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

