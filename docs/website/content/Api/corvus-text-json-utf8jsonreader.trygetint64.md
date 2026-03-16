---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetInt64 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetInt64 {#trygetint64}

```csharp
public bool TryGetInt64(ref long value)
```

Parses the current JSON token value from the source as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`Number`](/api/corvus-text-json-internal-jsontokentype.html#number). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

