---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.Build<T>.BeginInvoke Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## BeginInvoke {#begininvoke}

```csharp
public virtual IAsyncResult BeginInvoke(ref T context, ref JsonElement.ObjectBuilder builder, AsyncCallback callback, object object)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | [`ref JsonElement.ObjectBuilder`](/api/corvus-text-json-jsonelement-objectbuilder.html) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

