---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.OverwriteAndDispose Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## OverwriteAndDispose {#overwriteanddispose}

```csharp
public void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, ref MetadataDb targetData)
```

Overwrites a range of data in the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) with the built data and disposes this builder.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object in the target database. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to overwrite. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to overwrite. |
| `memberCountToReplace` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to replace. |
| `targetData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The target metadata database to receive the data. |

