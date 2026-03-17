---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "MetadataDb — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [MetadataDb.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/MetadataDb.cs#L106)

Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements.

```csharp
public readonly struct MetadataDb : IDisposable
```

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-metadatadb.dispose.html#dispose) | Releases resources used by the metadata database, returning rented arrays to the pool. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

