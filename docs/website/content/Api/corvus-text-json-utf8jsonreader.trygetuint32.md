---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetUInt32 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetUInt32 {#trygetuint32}

```csharp
public bool TryGetUInt32(ref uint value)
```

Parses the current JSON token value from the source as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |

