---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.CurrentState Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CurrentState

```csharp
JsonReaderState CurrentState { get; }
```

Returns the current snapshot of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) state which must be captured by the caller and passed back in to the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) ctor with more data. Unlike the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html), which is a ref struct, the state can survive across async/await boundaries and hence this type is required to provide support for reading in more data asynchronously before continuing with a new instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html).

### Returns

[`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html)

