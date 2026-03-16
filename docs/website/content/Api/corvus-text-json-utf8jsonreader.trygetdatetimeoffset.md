---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetDateTimeOffset Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetDateTimeOffset {#trygetdatetimeoffset}

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

Parses the current JSON token value from the source as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |

