---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.BytesPending Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L106)

## BytesPending {#bytespending}

Returns the amount of bytes written by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far that have not yet been flushed to the output and committed.

```csharp
public int BytesPending { get; set; }
```

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

