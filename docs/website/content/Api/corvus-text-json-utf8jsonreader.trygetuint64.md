---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetUInt64 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetUInt64 {#trygetuint64}

```csharp
bool TryGetUInt64(ref ulong value)
```

Parses the current JSON token value from the source as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |

