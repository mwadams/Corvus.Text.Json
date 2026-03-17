---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Addition Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## operator + {#operator}

```csharp
public static Period operator +(Period left, Period right)
```

Adds two periods together, by simply adding the values for each property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`Period`](/api/corvus-text-json-period.html) | The first period to add. |
| `right` | [`Period`](/api/corvus-text-json-period.html) | The second period to add. |

### Returns

[`Period`](/api/corvus-text-json-period.html)

The sum of the two periods. The units of the result will be the union of those in both periods.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

