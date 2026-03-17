---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonReaderOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/JsonReaderOptions.cs#L16)

Provides the ability for the user to define custom behavior when reading JSON.

```csharp
public readonly struct JsonReaderOptions
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [AllowMultipleValues](/api/corvus-text-json-jsonreaderoptions.allowmultiplevalues.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should tolerate zero or more top-level JSON values that are whitespace separated. |
| [AllowTrailingCommas](/api/corvus-text-json-jsonreaderoptions.allowtrailingcommas.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read. |
| [CommentHandling](/api/corvus-text-json-jsonreaderoptions.commenthandling.html) | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON. |
| [MaxDepth](/api/corvus-text-json-jsonreaderoptions.maxdepth.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

