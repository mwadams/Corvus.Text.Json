---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.SkipValidation Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## SkipValidation {#skipvalidation}

```csharp
bool SkipValidation { get; set; }
```

Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any attempts to write invalid JSON will result in an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) to be thrown.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

If the JSON being written is known to be correct, then skipping validation (by setting it to true) could improve performance. An example of invalid JSON where the writer will throw (when SkipValidation is set to false) is when you write a value within a JSON object without a property name.

