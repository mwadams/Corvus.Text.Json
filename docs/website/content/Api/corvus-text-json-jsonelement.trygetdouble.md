---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetDouble Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetDouble {#trygetdouble}

```csharp
public bool TryGetDouble(ref double value)
```

Attempts to represent the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) | Receives the value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double), `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html#number). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.double.maxvalue#maxvalue) (or smaller than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.double.minvalue#minvalue)), instead `true` is returned and [`PositiveInfinity`](https://learn.microsoft.com/dotnet/api/system.double.positiveinfinity#positiveinfinity) (or [`NegativeInfinity`](https://learn.microsoft.com/dotnet/api/system.double.negativeinfinity#negativeinfinity)) is emitted.

