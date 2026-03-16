---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period — Corvus.Text.Json"
---
```csharp
public readonly struct Period : IEquatable<Period>
```

Represents a period of time expressed in human chronological terms: hours, days, weeks, months and so on.

## Remarks

A [`Period`](/api/corvus-text-json-period.html) contains a set of properties such as [`Years`](/api/corvus-text-json-period.html#years), [`Months`](/api/corvus-text-json-period.html#months), and so on that return the number of each unit contained within this period. Note that these properties are not normalized in any way by default, and so a [`Period`](/api/corvus-text-json-period.html) may contain values such as "2 hours and 90 minutes". The [`Normalize`](/api/corvus-text-json-period.html#normalize) method will convert equivalent periods into a standard representation. Periods can contain negative units as well as positive units ("+2 hours, -43 minutes, +10 seconds"), but do not differentiate between properties that are zero and those that are absent (i.e. a period created as "10 years" and one created as "10 years, zero months" are equal periods; the [`Months`](/api/corvus-text-json-period.html#months) property returns zero in both cases). [`Period`](/api/corvus-text-json-period.html) equality is implemented by comparing each property's values individually, without any normalization. (For example, a period of "24 hours" is not considered equal to a period of "1 day".) The static [`NormalizingEqualityComparer`](/api/corvus-text-json-period.html#normalizingequalitycomparer) comparer provides an equality comparer which performs normalization before comparisons. There is no natural ordering for periods, but [`CreateComparer`](/api/corvus-text-json-period.html#createcomparer) can be used to create a comparer which orders periods according to a reference date, by adding each period to that date and comparing the results. Periods operate on calendar-related types such as [`LocalDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDateTime.html) whereas [`Duration`](https://www.nodatime.org/3.3.x/api/NodaTime.Duration.html) operates on instants on the time line. (Note that although [`ZonedDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.ZonedDateTime.html) includes both concepts, it only supports duration-based arithmetic.) The complexity of each method in this type is hard to document precisely, and often depends on the calendar system involved in performing the actual calculations. Operations do not depend on the magnitude of the units in the period, other than for optimizations for values of zero or occasionally for particularly small values. For example, adding 10,000 days to a date does not require greater algorithmic complexity than adding 1,000 days to the same date.

## Implements

[`IEquatable<Period>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Days](/api/corvus-text-json-period.days.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of days within this period. |
| [HasDateComponent](/api/corvus-text-json-period.hasdatecomponent.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher). |
| [HasTimeComponent](/api/corvus-text-json-period.hastimecomponent.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower). |
| [Hours](/api/corvus-text-json-period.hours.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of hours within this period. |
| [MaxValue](/api/corvus-text-json-period.maxvalue.html) `static` | [`Period`](/api/corvus-text-json-period.html) | A period containing the maximum value for all properties. |
| [Milliseconds](/api/corvus-text-json-period.milliseconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of milliseconds within this period. |
| [Minutes](/api/corvus-text-json-period.minutes.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of minutes within this period. |
| [MinValue](/api/corvus-text-json-period.minvalue.html) `static` | [`Period`](/api/corvus-text-json-period.html) | A period containing the minimum value for all properties. |
| [Months](/api/corvus-text-json-period.months.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of months within this period. |
| [Nanoseconds](/api/corvus-text-json-period.nanoseconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of nanoseconds within this period. |
| [NormalizingEqualityComparer](/api/corvus-text-json-period.normalizingequalitycomparer.html) `static` | [`IEqualityComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1) | Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the \[`Normalize`\](/api/corvus-text-json-period.html#no... |
| [Seconds](/api/corvus-text-json-period.seconds.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of seconds within this period. |
| [Ticks](/api/corvus-text-json-period.ticks.html) | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of ticks within this period. |
| [Weeks](/api/corvus-text-json-period.weeks.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of weeks within this period. |
| [Years](/api/corvus-text-json-period.years.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of years within this period. |
| [Zero](/api/corvus-text-json-period.zero.html) `static` | [`Period`](/api/corvus-text-json-period.html) | Gets a period containing only zero-valued properties. |

## Methods

| Method | Description |
|--------|-------------|
| [Add(Period, Period)](/api/corvus-text-json-period.add.html#add-period-period) `static` | Adds two periods together, by simply adding the values for each property. |
| [CreateComparer(LocalDateTime)](/api/corvus-text-json-period.createcomparer.html#createcomparer-localdatetime) `static` | Creates an [`IComparer`](https://learn.microsoft.com/dotnet/api/system.collections.generic.icomparer-1) for periods, using the given "base" local date/time. |
| [DaysBetween(LocalDate, LocalDate)](/api/corvus-text-json-period.daysbetween.html#daysbetween-localdate-localdate) `static` | Returns the number of days between two [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) objects. |
| [Equals](/api/corvus-text-json-period.equals.html) | Compares the given object for equality with this one, as per [`Equals`](/api/corvus-text-json-period.html#equals). See the type documentation for a description of equality semantics. |
| [FromDays(int)](/api/corvus-text-json-period.fromdays.html#fromdays-int) `static` | Creates a period representing the specified number of days. |
| [FromHours(long)](/api/corvus-text-json-period.fromhours.html#fromhours-long) `static` | Creates a period representing the specified number of hours. |
| [FromMilliseconds(long)](/api/corvus-text-json-period.frommilliseconds.html#frommilliseconds-long) `static` | Creates a period representing the specified number of milliseconds. |
| [FromMinutes(long)](/api/corvus-text-json-period.fromminutes.html#fromminutes-long) `static` | Creates a period representing the specified number of minutes. |
| [FromMonths(int)](/api/corvus-text-json-period.frommonths.html#frommonths-int) `static` | Creates a period representing the specified number of months. |
| [FromNanoseconds(long)](/api/corvus-text-json-period.fromnanoseconds.html#fromnanoseconds-long) `static` | Creates a period representing the specified number of nanoseconds. |
| [FromSeconds(long)](/api/corvus-text-json-period.fromseconds.html#fromseconds-long) `static` | Creates a period representing the specified number of seconds. |
| [FromTicks(long)](/api/corvus-text-json-period.fromticks.html#fromticks-long) `static` | Creates a period representing the specified number of ticks. |
| [FromWeeks(int)](/api/corvus-text-json-period.fromweeks.html#fromweeks-int) `static` | Creates a period representing the specified number of weeks. |
| [FromYears(int)](/api/corvus-text-json-period.fromyears.html#fromyears-int) `static` | Creates a period representing the specified number of years. |
| [GetHashCode()](/api/corvus-text-json-period.gethashcode.html#gethashcode) | Returns the hash code for this period, consistent with [`Equals`](/api/corvus-text-json-period.html#equals). See the type documentation for a description of equality semantics. |
| [Normalize()](/api/corvus-text-json-period.normalize.html#normalize) | Returns a normalized version of this period, such that equivalent (but potentially non-equal) periods are changed to the same representation. |
| [PeriodParser(ReadOnlySpan&lt;byte&gt;, ref PeriodBuilder)](/api/corvus-text-json-period.periodparser.html#periodparser-readonlyspan-byte-ref-periodbuilder) `static` | A parser for a json period. |
| [Subtract(Period, Period)](/api/corvus-text-json-period.subtract.html#subtract-period-period) `static` | Subtracts one period from another, by simply subtracting each property value. |
| [ToDuration()](/api/corvus-text-json-period.toduration.html#toduration) | For periods that do not contain a non-zero number of years or months, returns a duration for this period assuming a standard 7-day week, 24-hour day, 60-minute hour etc. |
| [ToString()](/api/corvus-text-json-period.tostring.html#tostring) | Returns this string formatted according to the ISO8601 duration specification used by JSON schema. |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref Period)](/api/corvus-text-json-period.tryparse.html#tryparse-readonlyspan-byte-ref-period) `static` | Parses a string into a Period. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator +(Period, Period)](/api/corvus-text-json-period.op-addition.html#operator-period-period) | Adds two periods together, by simply adding the values for each property. |
| [operator ==(Period, Period)](/api/corvus-text-json-period.op-equality.html#operator-period-period) | Implements the operator == (equality). See the type documentation for a description of equality semantics. |
| [Implicit](/api/corvus-text-json-period.op-implicit.html) | Convert to a NodaTime.Period. |
| [operator !=(Period, Period)](/api/corvus-text-json-period.op-inequality.html#operator-period-period) | Implements the operator != (inequality). See the type documentation for a description of equality semantics. |
| [operator -(Period, Period)](/api/corvus-text-json-period.op-subtraction.html#operator-period-period) | Subtracts one period from another, by simply subtracting each property value. |

