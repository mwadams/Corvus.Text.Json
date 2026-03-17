---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.FromWeeks Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L401)

## FromWeeks {#fromweeks}

Creates a period representing the specified number of weeks.

```csharp
public static Period FromWeeks(int weeks)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `weeks` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of weeks in the new period. |

### Returns

[`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of weeks.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

