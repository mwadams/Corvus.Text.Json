---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.EndContext Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L586)

## EndContext {#endcontext}

Ends the root evaluation context, committing any pending results to the results collector.

```csharp
public void EndContext()
```

### Remarks

This method must be called after the root `Evaluate` completes to ensure that results written directly at the root level (e.g., `required` keyword failures) are committed to the results collector. Without this call, such results are orphaned because [`BeginContext`](/api/corvus-text-json-internal-jsonschemacontext.html#begincontext) opens a child context on the collector that is never otherwise committed.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

