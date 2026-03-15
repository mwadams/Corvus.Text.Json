---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TokenStartIndex Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TokenStartIndex

```csharp
long TokenStartIndex { get; set; }
```

Returns the index that the last processed JSON token starts at within the given UTF-8 encoded input text, skipping any white space.

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

### Remarks

For JSON strings (including property names), this points to before the start quote. For comments, this points to before the first comment delimiter (i.e. '/').

