---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetGuid Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.TryGet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.TryGet.cs#L277)

## GetGuid {#getguid}

Parses the current JSON token value from the source as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. Throws exceptions otherwise.

```csharp
public Guid GetGuid()
```

### Returns

[`Guid`](https://learn.microsoft.com/dotnet/api/system.guid)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is of an unsupported format for a Guid. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

