---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonCommentHandling.Disallow Field — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonCommentHandling.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Common/JsonCommentHandling.cs#L8)

## Disallow {#disallow}

By default, do no allow comments within the JSON input. Comments are treated as invalid JSON if found and a [`JsonException`](/api/corvus-text-json-jsonexception.html) is thrown.

```csharp
JsonCommentHandling Disallow
```

### Returns

[`JsonCommentHandling`](/api/corvus-text-json-jsoncommenthandling.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

