---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.Position Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Position {#position}

```csharp
SequencePosition Position { get; }
```

Returns the current [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition) within the provided UTF-8 encoded input ReadOnlySequence<byte>. If the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) was constructed with a ReadOnlySpan<byte> instead, this will always return a default [`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition).

### Returns

[`SequencePosition`](https://learn.microsoft.com/dotnet/api/system.sequenceposition)

