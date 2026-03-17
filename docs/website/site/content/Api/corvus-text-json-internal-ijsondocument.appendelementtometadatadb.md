---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.AppendElementToMetadataDb Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L600)

## AppendElementToMetadataDb {#appendelementtometadatadb}

Appends the element at the specified index to the metadata database.

```csharp
public abstract void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace. |
| `db` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The metadata database. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

