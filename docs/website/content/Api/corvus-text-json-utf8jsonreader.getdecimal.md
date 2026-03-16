---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetDecimal Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetDecimal {#getdecimal}

```csharp
public decimal GetDecimal()
```

Parses the current JSON token value from the source as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. Throws exceptions otherwise.

### Returns

[`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value represents a number less than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.decimal.minvalue#minvalue) or greater than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.decimal.maxvalue#maxvalue). |

