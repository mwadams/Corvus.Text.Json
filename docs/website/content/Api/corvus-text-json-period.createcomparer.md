---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.CreateComparer Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateComparer {#createcomparer}

```csharp
public static IComparer<Period> CreateComparer(LocalDateTime baseDateTime)
```

Creates an [`IComparer`](https://learn.microsoft.com/dotnet/api/system.collections.generic.icomparer-1) for periods, using the given "base" local date/time.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `baseDateTime` | [`LocalDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDateTime.html) | The base local date/time to use for comparisons. |

### Returns

[`IComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.icomparer-1)

The new comparer.

### Remarks

Certain periods can't naturally be compared without more context - how "one month" compares to "30 days" depends on where you start. In order to compare two periods, the returned comparer effectively adds both periods to the "base" specified by `baseDateTime` and compares the results. In some cases this arithmetic isn't actually required - when two periods can be converted to durations, the comparer uses that conversion for efficiency.

