---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "MetadataDb — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct MetadataDb : IDisposable
```

Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-metadatadb.dispose.html#dispose) | Releases resources used by the metadata database, returning rented arrays to the pool. |

