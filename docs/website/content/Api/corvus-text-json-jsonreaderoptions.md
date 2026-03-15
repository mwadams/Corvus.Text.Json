---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions — Corvus.Text.Json"
---
```csharp
public readonly struct JsonReaderOptions
```

Provides the ability for the user to define custom behavior when reading JSON.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `AllowMultipleValues` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should tolerate zero or more top-level JSON values that are whitespace separated. |
| `AllowTrailingCommas` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read. |
| `CommentHandling` | [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) | Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON. |
| `MaxDepth` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64. |

### AllowMultipleValues

```csharp
bool AllowMultipleValues { get; set; }
```

Defines whether the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should tolerate zero or more top-level JSON values that are whitespace separated.

By default, it's set to false, and is thrown if trailing content is encountered after the first top-level JSON value.

### AllowTrailingCommas

```csharp
bool AllowTrailingCommas { get; set; }
```

Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read.

By default, it's set to false, and is thrown if a trailing comma is encountered.

### CommentHandling

```csharp
JsonCommentHandling CommentHandling { get; set; }
```

Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON.

By default is thrown if a comment is encountered.

### MaxDepth

```csharp
int MaxDepth { get; set; }
```

Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64.

Reading past this depth will throw a .

