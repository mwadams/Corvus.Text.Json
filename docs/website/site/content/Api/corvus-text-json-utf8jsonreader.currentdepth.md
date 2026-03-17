---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.CurrentDepth Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L129)

## CurrentDepth {#currentdepth}

Tracks the recursive depth of the nested objects / arrays within the JSON text processed so far. This provides the depth of the current token.

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

