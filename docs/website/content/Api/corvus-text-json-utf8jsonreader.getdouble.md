---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetDouble Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetDouble {#getdouble}

```csharp
public double GetDouble()
```

Parses the current JSON token value from the source as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. Throws exceptions otherwise.

### Returns

[`double`](https://learn.microsoft.com/dotnet/api/system.double)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | On any framework that is not .NET Core 3.0 or higher, thrown if the JSON token value represents a number less than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.double.minvalue#minvalue) or greater than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.double.maxvalue#maxvalue). |

