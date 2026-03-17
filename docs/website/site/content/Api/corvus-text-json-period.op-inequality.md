---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Inequality Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L362)

## operator != {#operator}

Implements the operator != (inequality). See the type documentation for a description of equality semantics.

```csharp
public static bool operator !=(Period left, Period right)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`Period`](/api/corvus-text-json-period.html) | The left hand side of the operator. |
| `right` | [`Period`](/api/corvus-text-json-period.html) | The right hand side of the operator. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if values are not equal to each other, otherwise `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

