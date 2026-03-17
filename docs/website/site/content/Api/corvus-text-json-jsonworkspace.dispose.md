---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.Dispose Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWorkspace.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonWorkspace.cs#L120)

## Dispose {#dispose}

Disposes the workspace. If the workspace was rented from the cache, returns it; otherwise disposes all child documents and returns the backing array to the pool.

```csharp
public void Dispose()
```

### Implements

[`IDisposable.Dispose`](https://learn.microsoft.com/dotnet/api/system.idisposable.dispose)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

