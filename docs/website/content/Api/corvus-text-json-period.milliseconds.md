---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Milliseconds Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Milliseconds

```csharp
long Milliseconds { get; }
```

Gets the number of milliseconds within this period.

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

### Property Value

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

The number of milliseconds within this period.

### Remarks

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

