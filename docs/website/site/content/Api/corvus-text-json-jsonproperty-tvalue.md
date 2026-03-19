---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue> — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonProperty.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonProperty.cs#L20)

Represents a single property for a JSON object.

```csharp
public readonly struct JsonProperty<TValue>
```

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the value. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Name](/api/corvus-text-json-jsonproperty-tvalue.name.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of this property. |
| [Utf16NameSpan](/api/corvus-text-json-jsonproperty-tvalue.utf16namespan.html) | [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) | Gets the name as an unescaped UTF-16 JSON string. |
| [Utf8NameSpan](/api/corvus-text-json-jsonproperty-tvalue.utf8namespan.html) | [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) | Gets the name as an unescaped UTF-8 JSON string. |
| [Value](/api/corvus-text-json-jsonproperty-tvalue.value.html) | `TValue` | The value of this property. |

## Methods

| Method | Description |
|--------|-------------|
| [NameEquals](/api/corvus-text-json-jsonproperty-tvalue.nameequals.html) | Compares `text` to the name of this property. |
| [ToString()](/api/corvus-text-json-jsonproperty-tvalue.tostring.html#tostring) | Provides a [`String`](https://learn.microsoft.com/dotnet/api/system.string) representation of the property for debugging purposes. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonproperty-tvalue.writeto.html#writeto-utf8jsonwriter) | Write the property into the provided writer as a named JSON object property. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

