---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement.WriteTo Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonElement.cs#L53)

## WriteTo {#writeto}

Writes this element to the specified [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html).

```csharp
public abstract void WriteTo(Utf8JsonWriter writer)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to which to write the element. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

