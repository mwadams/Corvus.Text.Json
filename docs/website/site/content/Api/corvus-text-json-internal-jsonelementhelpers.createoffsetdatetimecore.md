---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.CreateOffsetDateTimeCore Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CreateOffsetDateTimeCore(int, int, int, int, int, int, int, int, int, int)](#createoffsetdatetimecore-int-int-int-int-int-int-int-int-int-int) | Creates an offset date time from its individual components including nanosecond precision. |
| [CreateOffsetDateTimeCore(int, int, int, int, int, int, int, int)](#createoffsetdatetimecore-int-int-int-int-int-int-int-int) | Creates an offset date time from its individual components with millisecond precision. |

## CreateOffsetDateTimeCore(int, int, int, int, int, int, int, int, int, int) {#createoffsetdatetimecore-int-int-int-int-int-int-int-int-int-int}

```csharp
public static OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset date time from its individual components including nanosecond precision.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The year component. |
| `month` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The month component (1-12). |
| `day` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The day component (1-31). |
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `microseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The microseconds component (0-999). |
| `nanoseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The nanoseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

### Returns

[`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html)

The constructed offset date time.

---

## CreateOffsetDateTimeCore(int, int, int, int, int, int, int, int) {#createoffsetdatetimecore-int-int-int-int-int-int-int-int}

```csharp
public static OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset date time from its individual components with millisecond precision.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The year component. |
| `month` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The month component (1-12). |
| `day` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The day component (1-31). |
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

### Returns

[`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html)

The constructed offset date time.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

