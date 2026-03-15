---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.AllowMultipleValues Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## AllowMultipleValues

```csharp
bool AllowMultipleValues { get; set; }
```

Defines whether the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) should tolerate zero or more top-level JSON values that are whitespace separated.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

By default, it's set to false, and is thrown if trailing content is encountered after the first top-level JSON value.

