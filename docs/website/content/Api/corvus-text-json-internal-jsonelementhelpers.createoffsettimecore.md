---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.CreateOffsetTimeCore Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CreateOffsetTimeCore(int, int, int, int, int, int, int)](#offsettime-createoffsettimecore-int-hours-int-minutes-int-seconds-int-milliseconds-int-microseconds-int-nanoseconds-int-offsetseconds) | Creates an offset time from its individual components including nanosecond precision. |
| [CreateOffsetTimeCore(int, int, int, int, int)](#offsettime-createoffsettimecore-int-hours-int-minutes-int-seconds-int-milliseconds-int-offsetseconds) | Creates an offset time from its individual components with millisecond precision. |

## CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset time from its individual components including nanosecond precision.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `microseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The microseconds component (0-999). |
| `nanoseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The nanoseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

### Returns

[`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html)

The constructed offset time.

---

## CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset time from its individual components with millisecond precision.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

### Returns

[`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html)

The constructed offset time.

---

