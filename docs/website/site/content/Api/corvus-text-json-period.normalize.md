---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Normalize Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Normalize {#normalize}

```csharp
public Period Normalize()
```

Returns a normalized version of this period, such that equivalent (but potentially non-equal) periods are changed to the same representation.

### Returns

[`Period`](/api/corvus-text-json-period.html)

The normalized period.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`OverflowException`](https://learn.microsoft.com/dotnet/api/system.overflowexception) | The period doesn't have years or months, but it contains more than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int64.maxvalue#maxvalue) nanoseconds when the combined weeks/days/time portions are considered. This is over 292 years, so unlikely to be a problem in normal usage. In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this. |

### Remarks

Months and years are unchanged (as they can vary in length), but weeks are multiplied by 7 and added to the Days property, and all time properties are normalized to their natural range. Sub-second values are normalized to millisecond and "nanosecond within millisecond" values. So for example, a period of 25 hours becomes a period of 1 day and 1 hour. A period of 1,500,750,000 nanoseconds becomes 1 second, 500 milliseconds and 750,000 nanoseconds. Aside from months and years, either all the properties end up positive, or they all end up negative. "Week" and "tick" units in the returned period are always 0.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

