---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetSingle Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetSingle {#trygetsingle}

```csharp
public bool TryGetSingle(ref float value)
```

Attempts to represent the current JSON number as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) | Receives the value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single), `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html#number). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than [`MaxValue`](https://learn.microsoft.com/dotnet/api/system.single.maxvalue#maxvalue) (or smaller than [`MinValue`](https://learn.microsoft.com/dotnet/api/system.single.minvalue#minvalue)), instead `true` is returned and [`PositiveInfinity`](https://learn.microsoft.com/dotnet/api/system.single.positiveinfinity#positiveinfinity) (or [`NegativeInfinity`](https://learn.microsoft.com/dotnet/api/system.single.negativeinfinity#negativeinfinity)) is emitted.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

