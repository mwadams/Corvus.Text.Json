---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.ToDuration Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## ToDuration {#toduration}

```csharp
public Duration ToDuration()
```

For periods that do not contain a non-zero number of years or months, returns a duration for this period assuming a standard 7-day week, 24-hour day, 60-minute hour etc.

### Returns

[`Duration`](https://www.nodatime.org/3.3.x/api/NodaTime.Duration.html)

The duration of the period.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The month or year property in the period is non-zero. |
| [`OverflowException`](https://learn.microsoft.com/dotnet/api/system.overflowexception) | The period doesn't have years or months, but the calculation overflows the bounds of [`Duration`](https://www.nodatime.org/3.3.x/api/NodaTime.Duration.html). In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this - in realistic periods, it shouldn't be a problem. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

