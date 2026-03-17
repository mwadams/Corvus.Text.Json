---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonRegexOptions.NonBacktracking Field — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonRegexOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Regex/JsonRegexOptions.cs#L12)

## NonBacktracking {#nonbacktracking}

Enable matching using an approach that avoids backtracking and guarantees linear-time processing in the length of the input.

```csharp
JsonRegexOptions NonBacktracking
```

### Returns

[`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html)

### Remarks

Certain features aren't available when this option is set, including balancing groups, backreferences, positive and negative lookaheads and lookbehinds, and atomic groups. Capture groups are also ignored, such that the only capture available is that for the top-level match.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

