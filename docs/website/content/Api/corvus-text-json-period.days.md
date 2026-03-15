---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Days Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Days

```csharp
int Days { get; }
```

Gets the number of days within this period.

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Property Value

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of days within this period.

### Remarks

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

