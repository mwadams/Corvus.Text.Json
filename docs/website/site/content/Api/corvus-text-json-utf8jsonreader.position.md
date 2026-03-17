---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.Position Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L193)

## Position {#position}

Returns the current [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition) within the provided UTF-8 encoded input ReadOnlySequence<byte>. If the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) was constructed with a ReadOnlySpan<byte> instead, this will always return a default [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition).

```csharp
public SequencePosition Position { get; }
```

### Returns

[`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

