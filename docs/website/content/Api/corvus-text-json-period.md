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

A [`Period`](/api/corvus-text-json-period.html) contains a set of properties such as [`Years`](/api/corvus-text-json-period.html), [`Months`](/api/corvus-text-json-period.html), and so on that return the number of each unit contained within this period. Note that these properties are not normalized in any way by default, and so a [`Period`](/api/corvus-text-json-period.html) may contain values such as "2 hours and 90 minutes". The [`Normalize`](/api/corvus-text-json-period.html) method will convert equivalent periods into a standard representation. Periods can contain negative units as well as positive units ("+2 hours, -43 minutes, +10 seconds"), but do not differentiate between properties that are zero and those that are absent (i.e. a period created as "10 years" and one created as "10 years, zero months" are equal periods; the [`Months`](/api/corvus-text-json-period.html) property returns zero in both cases). [`Period`](/api/corvus-text-json-period.html) equality is implemented by comparing each property's values individually, without any normalization. (For example, a period of "24 hours" is not considered equal to a period of "1 day".) The static [`NormalizingEqualityComparer`](/api/corvus-text-json-period.html) comparer provides an equality comparer which performs normalization before comparisons. There is no natural ordering for periods, but [`CreateComparer`](/api/corvus-text-json-period.html) can be used to create a comparer which orders periods according to a reference date, by adding each period to that date and comparing the results. Periods operate on calendar-related types such as `LocalDateTime` whereas `Duration` operates on instants on the time line. (Note that although `ZonedDateTime` includes both concepts, it only supports duration-based arithmetic.) The complexity of each method in this type is hard to document precisely, and often depends on the calendar system involved in performing the actual calculations. Operations do not depend on the magnitude of the units in the period, other than for optimizations for values of zero or occasionally for particularly small values. For example, adding 10,000 days to a date does not require greater algorithmic complexity than adding 1,000 days to the same date.

## Implements

[`IEquatable<Period>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `MaxValue` `static` | [`Period`](/api/corvus-text-json-period.html) | A period containing the maximum value for all properties. |
| `MinValue` `static` | [`Period`](/api/corvus-text-json-period.html) | A period containing the minimum value for all properties. |
| `Zero` `static` | [`Period`](/api/corvus-text-json-period.html) | Gets a period containing only zero-valued properties. |
| `NormalizingEqualityComparer` `static` | [`IEqualityComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1) | Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the [`Normalize`](/api/corvus-text-json-period.html) m... |
| `Nanoseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of nanoseconds within this period. |
| `Ticks` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of ticks within this period. |
| `Milliseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of milliseconds within this period. |
| `Seconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of seconds within this period. |
| `Minutes` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of minutes within this period. |
| `Hours` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets the number of hours within this period. |
| `Days` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of days within this period. |
| `Weeks` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of weeks within this period. |
| `Months` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of months within this period. |
| `Years` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of years within this period. |
| `HasTimeComponent` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower). |
| `HasDateComponent` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher). |

### MaxValue

```csharp
Period MaxValue { get; }
```

A period containing the maximum value for all properties.

**Value:** A period containing the maximum value for all properties.

### MinValue

```csharp
Period MinValue { get; }
```

A period containing the minimum value for all properties.

**Value:** A period containing the minimum value for all properties.

### NormalizingEqualityComparer

```csharp
IEqualityComparer<Period> NormalizingEqualityComparer { get; }
```

Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the [`Normalize`](/api/corvus-text-json-period.html) method, years and months are unchanged by normalization - so 12 months does not equal 1 year.

**Value:** An equality comparer which compares periods by first normalizing them.

### Nanoseconds

```csharp
long Nanoseconds { get; }
```

Gets the number of nanoseconds within this period.

**Value:** The number of nanoseconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Ticks

```csharp
long Ticks { get; }
```

Gets the number of ticks within this period.

**Value:** The number of ticks within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Milliseconds

```csharp
long Milliseconds { get; }
```

Gets the number of milliseconds within this period.

**Value:** The number of milliseconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Seconds

```csharp
long Seconds { get; }
```

Gets the number of seconds within this period.

**Value:** The number of seconds within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Minutes

```csharp
long Minutes { get; }
```

Gets the number of minutes within this period.

**Value:** The number of minutes within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Hours

```csharp
long Hours { get; }
```

Gets the number of hours within this period.

**Value:** The number of hours within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Days

```csharp
int Days { get; }
```

Gets the number of days within this period.

**Value:** The number of days within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Weeks

```csharp
int Weeks { get; }
```

Gets the number of weeks within this period.

**Value:** The number of weeks within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Months

```csharp
int Months { get; }
```

Gets the number of months within this period.

**Value:** The number of months within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### Years

```csharp
int Years { get; }
```

Gets the number of years within this period.

**Value:** The number of years within this period.

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

### HasTimeComponent

```csharp
bool HasTimeComponent { get; }
```

Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower).

**Value:** true if the period contains any non-zero-valued time-based properties (hours or lower); false otherwise.

### HasDateComponent

```csharp
bool HasDateComponent { get; }
```

Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher).

**Value:** true if this period contains any non-zero date-based properties (days or higher); false otherwise.

## Methods

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> value, ref Period result)
```

Parses a string into a Period.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `result` | [`ref Period`](/api/corvus-text-json-period.html) | The resulting period. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the period could be parsed from the string.

### FromYears `static`

```csharp
Period FromYears(int years)
```

Creates a period representing the specified number of years.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `years` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of years in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of years.

### FromMonths `static`

```csharp
Period FromMonths(int months)
```

Creates a period representing the specified number of months.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `months` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of months in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of months.

### FromWeeks `static`

```csharp
Period FromWeeks(int weeks)
```

Creates a period representing the specified number of weeks.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `weeks` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of weeks in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of weeks.

### FromDays `static`

```csharp
Period FromDays(int days)
```

Creates a period representing the specified number of days.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `days` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of days in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of days.

### FromHours `static`

```csharp
Period FromHours(long hours)
```

Creates a period representing the specified number of hours.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of hours in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of hours.

### FromMinutes `static`

```csharp
Period FromMinutes(long minutes)
```

Creates a period representing the specified number of minutes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minutes` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of minutes in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of minutes.

### FromSeconds `static`

```csharp
Period FromSeconds(long seconds)
```

Creates a period representing the specified number of seconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `seconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of seconds in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of seconds.

### FromMilliseconds `static`

```csharp
Period FromMilliseconds(long milliseconds)
```

Creates a period representing the specified number of milliseconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `milliseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of milliseconds in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of milliseconds.

### FromTicks `static`

```csharp
Period FromTicks(long ticks)
```

Creates a period representing the specified number of ticks.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ticks` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of ticks in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of ticks.

### FromNanoseconds `static`

```csharp
Period FromNanoseconds(long nanoseconds)
```

Creates a period representing the specified number of nanoseconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `nanoseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The number of nanoseconds in the new period. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

A period consisting of the given number of nanoseconds.

### Add `static`

```csharp
Period Add(Period left, Period right)
```

Adds two periods together, by simply adding the values for each property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `left` | [`Period`](/api/corvus-text-json-period.html) | The first period to add. |
| `right` | [`Period`](/api/corvus-text-json-period.html) | The second period to add. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The sum of the two periods. The units of the result will be the union of those in both periods.

### CreateComparer `static`

```csharp
IComparer<Period> CreateComparer(LocalDateTime baseDateTime)
```

Creates an `IComparer` for periods, using the given "base" local date/time.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `baseDateTime` | `LocalDateTime` | The base local date/time to use for comparisons. |

**Returns:** [`IComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.icomparer-1)

The new comparer.

Certain periods can't naturally be compared without more context - how "one month" compares to "30 days" depends on where you start. In order to compare two periods, the returned comparer effectively adds both periods to the "base" specified by `baseDateTime` and compares the results. In some cases this arithmetic isn't actually required - when two periods can be converted to durations, the comparer uses that conversion for efficiency.

### Subtract `static`

```csharp
Period Subtract(Period minuend, Period subtrahend)
```

Subtracts one period from another, by simply subtracting each property value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minuend` | [`Period`](/api/corvus-text-json-period.html) | The period to subtract the second operand from. |
| `subtrahend` | [`Period`](/api/corvus-text-json-period.html) | The period to subtract the first operand from. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The result of subtracting all the values in the second operand from the values in the first. The units of the result will be the union of both periods, even if the subtraction caused some properties to become zero (so "2 weeks, 1 days" minus "2 weeks" is "zero weeks, 1 days", not "1 days").

### DaysBetween `static`

```csharp
int DaysBetween(LocalDate start, LocalDate end)
```

Returns the number of days between two `LocalDate` objects.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `start` | `LocalDate` | Start date/time. |
| `end` | `LocalDate` | End date/time. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of days between the given dates.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `start` and `end` use different calendars. |

### PeriodParser `static`

```csharp
bool PeriodParser(ReadOnlySpan<byte> text, ref PeriodBuilder builder)
```

A parser for a json period.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to parse. |
| `builder` | [`ref PeriodBuilder`](/api/corvus-text-json-periodbuilder.html) | The resulting period builder. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

A period builder parsed from the read only span.

### ToDuration

```csharp
Duration ToDuration()
```

For periods that do not contain a non-zero number of years or months, returns a duration for this period assuming a standard 7-day week, 24-hour day, 60-minute hour etc.

**Returns:** `Duration`

The duration of the period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The month or year property in the period is non-zero. |
| [`OverflowException`](https://learn.microsoft.com/dotnet/api/system.overflowexception) | The period doesn't have years or months, but the calculation overflows the bounds of `Duration`. In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this - in realistic periods, it shouldn't be a problem. |

### Normalize

```csharp
Period Normalize()
```

Returns a normalized version of this period, such that equivalent (but potentially non-equal) periods are changed to the same representation.

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The normalized period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`OverflowException`](https://learn.microsoft.com/dotnet/api/system.overflowexception) | The period doesn't have years or months, but it contains more than `MaxValue` nanoseconds when the combined weeks/days/time portions are considered. This is over 292 years, so unlikely to be a problem in normal usage. In some cases this may occur even though the theoretical result would be valid due to balancing positive and negative values, but for simplicity there is no attempt to work around this. |

Months and years are unchanged (as they can vary in length), but weeks are multiplied by 7 and added to the Days property, and all time properties are normalized to their natural range. Sub-second values are normalized to millisecond and "nanosecond within millisecond" values. So for example, a period of 25 hours becomes a period of 1 day and 1 hour. A period of 1,500,750,000 nanoseconds becomes 1 second, 500 milliseconds and 750,000 nanoseconds. Aside from months and years, either all the properties end up positive, or they all end up negative. "Week" and "tick" units in the returned period are always 0.

### ToString `virtual`

```csharp
string ToString()
```

Returns this string formatted according to the ISO8601 duration specification used by JSON schema.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A formatted representation of this period.

### Equals `virtual`

```csharp
bool Equals(object other)
```

Compares the given object for equality with this one, as per [`Equals`](/api/corvus-text-json-period.html). See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The value to compare this one with. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

true if the other object is a period equal to this one, consistent with [`Equals`](/api/corvus-text-json-period.html).

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

Returns the hash code for this period, consistent with [`Equals`](/api/corvus-text-json-period.html). See the type documentation for a description of equality semantics.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The hash code for this period.

### Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | [`Period`](/api/corvus-text-json-period.html) | The period to compare this one with. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if this period has the same values for the same properties as the one specified.

### Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `Period` | The period to compare this one with. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if this period has the same values for the same properties as the one specified.

