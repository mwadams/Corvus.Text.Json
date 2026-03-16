---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.DaysBetween Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## DaysBetween {#daysbetween}

```csharp
public static int DaysBetween(LocalDate start, LocalDate end)
```

Returns the number of days between two [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) objects.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `start` | [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | Start date/time. |
| `end` | [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | End date/time. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of days between the given dates.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `start` and `end` use different calendars. |

