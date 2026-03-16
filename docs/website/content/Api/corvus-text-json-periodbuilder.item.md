---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PeriodBuilder.Item Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## this[PeriodUnits] {#this-periodunits}

```csharp
public long this[PeriodUnits unit] { get; set; }
```

Gets or sets the value of a single unit.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `unit` | [`PeriodUnits`](https://www.nodatime.org/3.3.x/api/NodaTime.PeriodUnits.html) | A single value within the [`PeriodUnits`](https://www.nodatime.org/3.3.x/api/NodaTime.PeriodUnits.html) enumeration. |

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

### Property Value

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

The value of the given unit within this period builder, or zero if the unit is unset.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `unit` is not a single unit, or a value is provided for a date unit which is outside the range of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |

### Remarks

The type of this indexer is [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) for uniformity, but any date unit (year, month, week, day) will only ever have a value in the range of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). For the [`Nanoseconds`](https://www.nodatime.org/3.3.x/api/NodaTime.PeriodUnits.Nanoseconds.html#nanoseconds) unit, the value is converted to `Int64` when reading from the indexer, causing it to fail if the value is out of range (around 250 years). To access the values of very large numbers of nanoseconds, use the [`Nanoseconds`](/api/corvus-text-json-periodbuilder.html#nanoseconds) property directly.

