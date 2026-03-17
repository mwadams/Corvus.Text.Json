---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.Read Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L302)

## Read {#read}

Read the next JSON token from input source.

```csharp
public bool Read()
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the token was read successfully, else false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | Thrown when an invalid JSON token is encountered according to the JSON RFC or if the current depth exceeds the recursive limit set by the max depth. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

