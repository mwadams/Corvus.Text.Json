---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.InsertAndDispose Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## InsertAndDispose {#insertanddispose}

```csharp
public void InsertAndDispose(int complexObjectStartIndex, int targetIndex, ref MetadataDb targetData)
```

Inserts the built data into the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) at the given index and disposes this builder.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object in the target database. |
| `targetIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index at which to insert the data. |
| `targetData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The target metadata database to receive the data. |

