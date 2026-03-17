---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.ApplyEvaluated Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L853)

## ApplyEvaluated {#applyevaluated}

Applies the evaluated properties/items from the child context to this (parent) context, if appropriate.

```csharp
public void ApplyEvaluated(ref JsonSchemaContext childContext)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The child context from which to apply evaluated properties/items |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

