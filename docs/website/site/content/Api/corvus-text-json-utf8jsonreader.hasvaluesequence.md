---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.HasValueSequence Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L154)

## HasValueSequence {#hasvaluesequence}

Lets the caller know which of the two 'Value' properties to read to get the token value. For input data within a ReadOnlySpan<byte> this will always return false. For input data within a ReadOnlySequence<byte>, this will only return true if the token value straddles more than a single segment and hence couldn't be represented as a span.

```csharp
public bool HasValueSequence { get; set; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

