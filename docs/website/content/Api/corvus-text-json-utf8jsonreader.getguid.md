---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetGuid Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetGuid {#getguid}

```csharp
public Guid GetGuid()
```

Parses the current JSON token value from the source as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. Throws exceptions otherwise.

### Returns

[`Guid`](https://learn.microsoft.com/dotnet/api/system.guid)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format for a Guid. |

