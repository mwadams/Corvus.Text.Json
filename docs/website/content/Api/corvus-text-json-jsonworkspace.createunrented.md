---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.CreateUnrented Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateUnrented {#createunrented}

```csharp
public static JsonWorkspace CreateUnrented(int initialDocumentCapacity, Nullable<JsonWriterOptions> options)
```

Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `initialDocumentCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial document capacity for the workspace. *(optional)* |
| `options` | [`Nullable<JsonWriterOptions>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The ambient [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html). *(optional)* |

### Returns

[`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html)

The [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

