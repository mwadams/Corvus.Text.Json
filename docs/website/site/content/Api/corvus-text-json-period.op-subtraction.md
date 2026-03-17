---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Subtraction Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L333)

## operator - {#operator}

Subtracts one period from another, by simply subtracting each property value.

```csharp
public static Period operator -(Period minuend, Period subtrahend)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `minuend` | [`Period`](/api/corvus-text-json-period.html) | The period to subtract the second operand from. |
| `subtrahend` | [`Period`](/api/corvus-text-json-period.html) | The period to subtract the first operand from. |

### Returns

[`Period`](/api/corvus-text-json-period.html)

The result of subtracting all the values in the second operand from the values in the first. The units of the result will be the union of both periods, even if the subtraction caused some properties to become zero (so "2 weeks, 1 days" minus "2 weeks" is "zero weeks, 1 days", not "1 days").

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

