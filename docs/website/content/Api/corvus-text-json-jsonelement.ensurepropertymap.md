---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.EnsurePropertyMap Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## EnsurePropertyMap {#ensurepropertymap}

```csharp
void EnsurePropertyMap()
```

Ensures that a fast-lookup property map is created for this element.

### Remarks

This enables dictionary-based lookup of property values in the element. If the cost of lookups exceeds the cost of building the map, this can provide substantial performance improvements. It is a zero-allocation operation.

