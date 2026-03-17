---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.HasDateComponent Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Period.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/NodaTimeExtensions/Period.cs#L246)

## HasDateComponent {#hasdatecomponent}

Gets a value indicating whether or not this period contains any non-zero date-based properties (days or higher).

```csharp
public bool HasDateComponent { get; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Property Value

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

true if this period contains any non-zero date-based properties (days or higher); false otherwise.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

