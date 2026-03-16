---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.Dispose Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Dispose {#dispose}

```csharp
public void Dispose()
```

Disposes the workspace. If the workspace was rented from the cache, returns it; otherwise disposes all child documents and returns the backing array to the pool.

### Implements

[`IDisposable.Dispose`](https://learn.microsoft.com/dotnet/api/system.idisposable.dispose)

