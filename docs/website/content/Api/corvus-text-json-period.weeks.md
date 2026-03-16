---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Weeks Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Weeks {#weeks}

```csharp
int Weeks { get; }
```

Gets the number of weeks within this period.

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Property Value

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of weeks within this period.

### Remarks

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

