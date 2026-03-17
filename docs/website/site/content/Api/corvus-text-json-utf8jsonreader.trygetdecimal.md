---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetDecimal Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.TryGet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.TryGet.cs#L625)

## TryGetDecimal {#trygetdecimal}

Parses the current JSON token value from the source as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. Returns `false` otherwise.

```csharp
public bool TryGetDecimal(ref decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

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

