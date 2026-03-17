---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentOptions.CommentHandling Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonDocumentOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonDocumentOptions.cs#L44)

## CommentHandling {#commenthandling}

Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON.

```csharp
public JsonCommentHandling CommentHandling { get; set; }
```

### Returns

[`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when the comment handling enum is set to a value that is not supported (or not within the [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) enum range). |

### Remarks

By default a [`JsonException`](/api/corvus-text-json-jsonexception.html) is thrown if a comment is encountered.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

