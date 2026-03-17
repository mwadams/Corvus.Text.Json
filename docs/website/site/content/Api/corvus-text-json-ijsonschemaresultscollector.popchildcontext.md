---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.PopChildContext Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L346)

## PopChildContext {#popchildcontext}

Abandons the last child context.

```csharp
public abstract void PopChildContext(int sequenceNumber)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |

### Remarks

This will not update the match state, and allows the collector to release any resources associated with the child context.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

