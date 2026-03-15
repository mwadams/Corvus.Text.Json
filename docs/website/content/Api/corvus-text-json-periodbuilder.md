---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PeriodBuilder — Corvus.Text.Json"
---
```csharp
public readonly struct PeriodBuilder
```

A mutable builder class for [`Period`](/api/corvus-text-json-period.html) values. Each property can be set independently, and then a Period can be created from the result using the [`BuildPeriod`](/api/corvus-text-json-periodbuilder.html#buildperiod) method.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Days](/api/corvus-text-json-periodbuilder.days.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of days within the period. |
| [Hours](/api/corvus-text-json-periodbuilder.hours.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of hours within the period. |
| [this\[PeriodUnits\]](/api/corvus-text-json-periodbuilder.item.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the value of a single unit. |
| [Milliseconds](/api/corvus-text-json-periodbuilder.milliseconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of milliseconds within the period. |
| [Minutes](/api/corvus-text-json-periodbuilder.minutes.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of minutes within the period. |
| [Months](/api/corvus-text-json-periodbuilder.months.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of months within the period. |
| [Nanoseconds](/api/corvus-text-json-periodbuilder.nanoseconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of nanoseconds within the period. |
| [Seconds](/api/corvus-text-json-periodbuilder.seconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of seconds within the period. |
| [Ticks](/api/corvus-text-json-periodbuilder.ticks.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of ticks within the period. |
| [Weeks](/api/corvus-text-json-periodbuilder.weeks.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of weeks within the period. |
| [Years](/api/corvus-text-json-periodbuilder.years.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of years within the period. |

## Methods

| Method | Description |
|--------|-------------|
| [BuildPeriod()](/api/corvus-text-json-periodbuilder.buildperiod.html#period-buildperiod) | Builds a period from the properties in this builder. |

