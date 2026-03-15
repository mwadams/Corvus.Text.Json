---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.AllowTrailingCommas Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## AllowTrailingCommas

```csharp
bool AllowTrailingCommas { get; set; }
```

Defines whether an extra comma at the end of a list of JSON values in an object or array is allowed (and ignored) within the JSON payload being read.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

By default, it's set to false, and is thrown if a trailing comma is encountered.

