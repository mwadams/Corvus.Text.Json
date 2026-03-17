---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Milliseconds Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L164)

## Milliseconds {#milliseconds}

Gets the number of milliseconds within this period.

```csharp
public long Milliseconds { get; }
```

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

### Property Value

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

The number of milliseconds within this period.

### Remarks

This property returns zero both when the property has been explicitly set to zero and when the period does not contain this property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

