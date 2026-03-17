---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentBuilder<T>.WriteTo Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonDocumentBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonDocumentBuilder.cs#L89)

## WriteTo {#writeto}

Write the document into the provided writer as a JSON value.

```csharp
public void WriteTo(Utf8JsonWriter writer)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) |  |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This [`JsonDocumentBuilder`](/api/corvus-text-json-jsondocumentbuilder-t.html#jsondocumentbuilder)'s [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) would result in an invalid JSON. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

