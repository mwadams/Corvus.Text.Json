---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetUInt16 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetUInt16 {#getuint16}

```csharp
ushort GetUInt16()
```

Parses the current JSON token value from the source as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). Returns the value if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. Throws exceptions otherwise.

### Returns

[`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown if the JSON token value is either of incorrect numeric format (for example if it contains a decimal or is written in scientific notation) or, it represents a number less than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.uint16.minvalue#minvalue) or greater than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.uint16.maxvalue#maxvalue). |

