---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue>.WriteTo Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## WriteTo {#writeto}

```csharp
public void WriteTo(Utf8JsonWriter writer)
```

Write the property into the provided writer as a named JSON object property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | This [`JsonProperty`](/api/corvus-text-json-jsonproperty-tvalue.html#jsonproperty)'s length is too large to be a JSON object property. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This [`JsonProperty`](/api/corvus-text-json-jsonproperty-tvalue.html#jsonproperty)'s [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) would result in an invalid JSON. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

