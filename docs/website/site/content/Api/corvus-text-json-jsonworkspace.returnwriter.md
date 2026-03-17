---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace.ReturnWriter Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWorkspace.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonWorkspace.cs#L107)

## ReturnWriter {#returnwriter}

Returns a rented UTF-8 JSON writer to the pool.

```csharp
public void ReturnWriter(Utf8JsonWriter writer)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to return to the pool. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

