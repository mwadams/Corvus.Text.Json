---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetDouble Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetDouble {#getdouble}

```csharp
double GetDouble()
```

Gets the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double).

### Returns

[`double`](https://learn.microsoft.com/dotnet/api/system.double)

The current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value. On .NET Core this method returns [`PositiveInfinity`](https://learn.microsoft.com/dotnet/api/system.double.positiveinfinity#positiveinfinity) (or [`NegativeInfinity`](https://learn.microsoft.com/dotnet/api/system.double.negativeinfinity#negativeinfinity)) for values larger than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.double.maxvalue#maxvalue) (or smaller than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.double.minvalue#minvalue)).

