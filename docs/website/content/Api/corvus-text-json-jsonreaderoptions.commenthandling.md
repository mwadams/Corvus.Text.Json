---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.CommentHandling Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CommentHandling {#commenthandling}

```csharp
JsonCommentHandling CommentHandling { get; set; }
```

Defines how the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should handle comments when reading through the JSON.

### Returns

[`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when the comment handling enum is set to a value that is not supported (i.e. not within the [`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html) enum range). |

### Remarks

By default is thrown if a comment is encountered.

