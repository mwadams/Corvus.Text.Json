---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaPathProvider.BeginInvoke Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L53)

## BeginInvoke {#begininvoke}

```csharp
public virtual IAsyncResult BeginInvoke(Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

