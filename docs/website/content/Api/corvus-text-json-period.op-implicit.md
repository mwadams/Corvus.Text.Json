---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Implicit Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Operator | Description |
|----------|-------------|
| [implicit operator Period(ref Period)](#implicit-operator-period-ref-period) | Convert to a NodaTime.Period. |
| [implicit operator Period(Period)](#implicit-operator-period-period) | Convert to a NodaTime.Period. |

## implicit operator Period(ref Period) {#implicit-operator-period-ref-period}

```csharp
public static implicit operator Period(ref Period value)
```

Convert to a NodaTime.Period.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The value to convert. |

### Returns

[`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html)

---

## implicit operator Period(Period) {#implicit-operator-period-period}

```csharp
public static implicit operator Period(Period value)
```

Convert to a NodaTime.Period.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) | The value to convert. |

### Returns

[`Period`](/api/corvus-text-json-period.html)

---

