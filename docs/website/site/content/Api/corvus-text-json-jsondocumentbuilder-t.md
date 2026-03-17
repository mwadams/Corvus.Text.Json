---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentBuilder<T> — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonDocumentBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonDocumentBuilder.cs#L26)

A mutable JSON document builder that provides functionality to construct and modify JSON documents.

```csharp
public sealed class JsonDocumentBuilder<T> : JsonDocument, IMutableJsonDocument, IJsonDocument, IDisposable
```

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of mutable JSON element this builder works with. |

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) → **JsonDocumentBuilder<T>**

## Implements

[`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html), [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [RootElement](/api/corvus-text-json-jsondocumentbuilder-t.rootelement.html) | `T` | Gets the root element of the JSON document. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-jsondocumentbuilder-t.dispose.html#dispose) |  |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsondocumentbuilder-t.writeto.html#writeto-utf8jsonwriter) | Write the document into the provided writer as a JSON value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

