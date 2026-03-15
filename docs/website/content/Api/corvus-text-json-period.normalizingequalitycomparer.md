---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.NormalizingEqualityComparer Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## NormalizingEqualityComparer `static`

```csharp
IEqualityComparer<Period> NormalizingEqualityComparer { get; }
```

Gets an equality comparer which compares periods by first normalizing them - so 24 hours is deemed equal to 1 day, and so on. Note that as per the [`Normalize`](/api/corvus-text-json-period.html#normalize) method, years and months are unchanged by normalization - so 12 months does not equal 1 year.

### Returns

[`IEqualityComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1)

### Property Value

[`IEqualityComparer<Period>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1)

An equality comparer which compares periods by first normalizing them.

