---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Years Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Years {#years}

```csharp
public int Years { get; }
```

Gets the number of years within this period.

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Property Value

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of years within this period.

### Remarks

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

