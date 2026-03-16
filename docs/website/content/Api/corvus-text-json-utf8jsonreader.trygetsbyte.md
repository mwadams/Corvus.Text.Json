---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetSByte Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetSByte {#trygetsbyte}

```csharp
public bool TryGetSByte(ref sbyte value)
```

Parses the current JSON token value from the source as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

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

