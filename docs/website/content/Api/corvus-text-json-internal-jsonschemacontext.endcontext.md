---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.EndContext Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## EndContext {#endcontext}

```csharp
public void EndContext()
```

Ends the root evaluation context, committing any pending results to the results collector.

### Remarks

This method must be called after the root `Evaluate` completes to ensure that results written directly at the root level (e.g., `required` keyword failures) are committed to the results collector. Without this call, such results are orphaned because [`BeginContext`](/api/corvus-text-json-internal-jsonschemacontext.html#begincontext) opens a child context on the collector that is never otherwise committed.

