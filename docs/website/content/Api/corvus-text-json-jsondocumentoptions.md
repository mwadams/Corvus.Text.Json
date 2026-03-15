---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentOptions — Corvus.Text.Json"
---
```csharp
public readonly struct JsonDocumentOptions
```

Provides the ability for the user to define custom behavior when parsing JSON to create a `JsonDocument`.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [AllowTrailingCommas](/api/corvus-text-json-jsondocumentoptions.allowtrailingcommas.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read. |
| [CommentHandling](/api/corvus-text-json-jsondocumentoptions.commenthandling.html) | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON. |
| [MaxDepth](/api/corvus-text-json-jsondocumentoptions.maxdepth.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64. |

