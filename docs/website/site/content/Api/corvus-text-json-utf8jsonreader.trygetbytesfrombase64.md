---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetBytesFromBase64 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.TryGet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.TryGet.cs#L557)

## TryGetBytesFromBase64 {#trygetbytesfrombase64}

Parses the current JSON token value from the source and decodes the Base64 encoded JSON string as bytes. Returns `true` if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes. Returns `false` otherwise.

```csharp
public bool TryGetBytesFromBase64(ref byte[] value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

