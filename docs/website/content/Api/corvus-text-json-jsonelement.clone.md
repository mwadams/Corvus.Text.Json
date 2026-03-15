---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Clone Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Clone

```csharp
JsonElement Clone()
```

Get a JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

### Remarks

If this JsonElement is itself the output of a previous call to Clone, or a value contained within another JsonElement which was the output of a previous call to Clone, this method results in no additional memory allocation.

