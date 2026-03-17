---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.BytesConsumed Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L107)

## BytesConsumed {#bytesconsumed}

Returns the total amount of bytes consumed by the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) so far for the current instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) with the given UTF-8 encoded input text.

```csharp
public long BytesConsumed { get; }
```

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

