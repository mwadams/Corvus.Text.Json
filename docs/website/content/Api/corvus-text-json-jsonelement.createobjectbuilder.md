---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.CreateObjectBuilder Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateObjectBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateObjectBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

Creates an empty mutable object document builder.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of members in the document. *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing an empty object.

