---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.BytesCommitted Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## BytesCommitted

```csharp
long BytesCommitted { get; set; }
```

Returns the amount of bytes committed to the output by the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) so far.

### Returns

[`long`](https://learn.microsoft.com/dotnet/api/system.int64)

### Remarks

In the case of IBufferwriter, this is how much the IBufferWriter has advanced. In the case of Stream, this is how much data has been written to the stream.

