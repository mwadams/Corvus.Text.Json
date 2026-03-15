---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetBytesFromBase64 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes.

### Returns

[`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The JSON string contains data outside of the expected Base64 range, or if it contains invalid/more than two padding characters, or is incomplete (i.e. the JSON string length is not a multiple of 4). |

