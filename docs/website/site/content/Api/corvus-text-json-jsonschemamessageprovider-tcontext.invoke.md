---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMessageProvider<TContext>.Invoke Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L23)

## Invoke {#invoke}

```csharp
public virtual bool Invoke(TContext context, Span<byte> buffer, ref int written)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

