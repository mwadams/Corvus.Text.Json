---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetBigInteger Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L1504)

## TryGetBigInteger {#trygetbiginteger}

Attempts to represent the current JSON number as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger).

```csharp
public bool TryGetBigInteger(ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | Receives the value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger), `false` otherwise.

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

