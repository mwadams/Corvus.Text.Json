---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.HasLocalOrAppliedEvaluatedProperty Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## HasLocalOrAppliedEvaluatedProperty {#haslocalorappliedevaluatedproperty}

```csharp
public bool HasLocalOrAppliedEvaluatedProperty(int index)
```

Determines whether a specific property at the given index has been either locally or applied evaluated.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property to check. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property at the specified index has been locally or applied evaluated; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

