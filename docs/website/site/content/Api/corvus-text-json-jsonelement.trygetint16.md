---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetInt16 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L801)

## TryGetInt16 {#trygetint16}

Attempts to represent the current JSON number as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16).

```csharp
public bool TryGetInt16(ref short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) | Receives the value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16), `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html#number). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

