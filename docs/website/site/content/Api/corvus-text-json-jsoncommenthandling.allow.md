---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonCommentHandling.Allow Field — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonCommentHandling.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Common/JsonCommentHandling.cs#L8)

## Allow {#allow}

Allow comments within the JSON input and treat them as valid tokens. While reading, the caller will be able to access the comment values.

```csharp
JsonCommentHandling Allow
```

### Returns

[`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

