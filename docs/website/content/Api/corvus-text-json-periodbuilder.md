---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PeriodBuilder — Corvus.Text.Json"
---
```csharp
public readonly struct PeriodBuilder
```

A mutable builder class for [`Period`](/api/corvus-text-json-period.html) values. Each property can be set independently, and then a Period can be created from the result using the [`BuildPeriod`](/api/corvus-text-json-periodbuilder.html) method.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Days` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of days within the period. |
| `Hours` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of hours within the period. |
| `Milliseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of milliseconds within the period. |
| `Minutes` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of minutes within the period. |
| `Months` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of months within the period. |
| `Nanoseconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of nanoseconds within the period. |
| `Seconds` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of seconds within the period. |
| `Ticks` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | Gets or sets the number of ticks within the period. |
| `Weeks` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of weeks within the period. |
| `Years` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the number of years within the period. |
| `Item` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

### Days

```csharp
int Days { get; set; }
```

Gets or sets the number of days within the period.

**Value:** The number of days within the period.

### Hours

```csharp
long Hours { get; set; }
```

Gets or sets the number of hours within the period.

**Value:** The number of hours within the period.

### Milliseconds

```csharp
long Milliseconds { get; set; }
```

Gets or sets the number of milliseconds within the period.

**Value:** The number of milliseconds within the period.

### Minutes

```csharp
long Minutes { get; set; }
```

Gets or sets the number of minutes within the period.

**Value:** The number of minutes within the period.

### Months

```csharp
int Months { get; set; }
```

Gets or sets the number of months within the period.

**Value:** The number of months within the period.

### Nanoseconds

```csharp
long Nanoseconds { get; set; }
```

Gets or sets the number of nanoseconds within the period.

**Value:** The number of nanoseconds within the period.

### Seconds

```csharp
long Seconds { get; set; }
```

Gets or sets the number of seconds within the period.

**Value:** The number of seconds within the period.

### Ticks

```csharp
long Ticks { get; set; }
```

Gets or sets the number of ticks within the period.

**Value:** The number of ticks within the period.

### Weeks

```csharp
int Weeks { get; set; }
```

Gets or sets the number of weeks within the period.

**Value:** The number of weeks within the period.

### Years

```csharp
int Years { get; set; }
```

Gets or sets the number of years within the period.

**Value:** The number of years within the period.

## Methods

### BuildPeriod

```csharp
Period BuildPeriod()
```

Builds a period from the properties in this builder.

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The total number of nanoseconds in the period.

