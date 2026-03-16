---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.TryGetDateTime Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetDateTime {#trygetdatetime}

```csharp
public bool TryGetDateTime(ref DateTime value)
```

Parses the current JSON token value from the source as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). Returns `true` if the entire UTF-8 encoded token value can be successfully parsed to a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. Returns `false` otherwise.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a [`String`](/api/corvus-text-json-internal-jsontokentype.html#string). |

