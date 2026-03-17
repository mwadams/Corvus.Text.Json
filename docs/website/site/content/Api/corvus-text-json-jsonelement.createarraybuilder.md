---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.CreateArrayBuilder Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1585)

## CreateArrayBuilder {#createarraybuilder}

Creates an empty mutable array document builder.

```csharp
public static JsonDocumentBuilder<JsonElement.Mutable> CreateArrayBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of members in the document. *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing an empty array.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

