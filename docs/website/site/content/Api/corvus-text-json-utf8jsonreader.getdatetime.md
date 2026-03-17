---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetDateTime Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetDateTime {#getdatetime}

```csharp
public DateTime GetDateTime()
```

Parses the current JSON token value from the source as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. Throws exceptions otherwise.

### Returns

[`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format. Only a subset of ISO 8601 formats are supported. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

