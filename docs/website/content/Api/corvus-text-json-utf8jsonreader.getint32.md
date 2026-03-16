---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetInt32 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetInt32 {#getint32}

```csharp
public int GetInt32()
```

Parses the current JSON token value from the source as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. Throws exceptions otherwise.

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.int32.minvalue#minvalue) or greater than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.int32.maxvalue#maxvalue). |

