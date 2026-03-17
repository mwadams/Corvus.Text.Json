---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.BuildRentedMetadataDb Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L592)

## BuildRentedMetadataDb {#buildrentedmetadatadb}

Builds a rented metadata database for the specified parent document index.

```csharp
public abstract int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[] rentedBacking)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent document. |
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace. |
| `rentedBacking` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The rented backing array. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The size of the metadata database.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

