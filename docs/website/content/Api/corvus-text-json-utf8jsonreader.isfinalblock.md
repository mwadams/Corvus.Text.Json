---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.IsFinalBlock Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## IsFinalBlock {#isfinalblock}

```csharp
public bool IsFinalBlock { get; }
```

Returns the mode of this instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html). True when the reader was constructed with the input span containing the entire data to process. False when the reader was constructed knowing that the input span may contain partial data with more data to follow.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

