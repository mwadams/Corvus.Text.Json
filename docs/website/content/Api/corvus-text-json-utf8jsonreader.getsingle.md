---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetSingle Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetSingle {#getsingle}

```csharp
float GetSingle()
```

Parses the current JSON token value from the source as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. Throws exceptions otherwise.

### Returns

[`float`](https://learn.microsoft.com/dotnet/api/system.single)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.single.minvalue#minvalue) or greater than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.single.maxvalue#maxvalue). |

