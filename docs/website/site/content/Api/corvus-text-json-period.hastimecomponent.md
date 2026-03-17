---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.HasTimeComponent Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L240)

## HasTimeComponent {#hastimecomponent}

Gets a value indicating whether or not this period contains any non-zero-valued time-based properties (hours or lower).

```csharp
public bool HasTimeComponent { get; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Property Value

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

true if the period contains any non-zero-valued time-based properties (hours or lower); false otherwise.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

