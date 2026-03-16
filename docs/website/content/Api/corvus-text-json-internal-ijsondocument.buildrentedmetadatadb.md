---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.BuildRentedMetadataDb Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## BuildRentedMetadataDb {#buildrentedmetadatadb}

```csharp
int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[] rentedBacking)
```

Builds a rented metadata database for the specified parent document index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent document. |
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace. |
| `rentedBacking` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The rented backing array. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The size of the metadata database.

