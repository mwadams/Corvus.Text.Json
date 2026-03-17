---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.CurrentDepth Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L132)

## CurrentDepth {#currentdepth}

Tracks the recursive depth of the nested objects / arrays within the JSON text written so far. This provides the depth of the current token.

```csharp
public int CurrentDepth { get; }
```

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

