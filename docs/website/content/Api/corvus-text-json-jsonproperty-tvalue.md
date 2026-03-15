---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue> — Corvus.Text.Json"
---
```csharp
public readonly struct JsonProperty<TValue>
```

Represents a single property for a JSON object.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the value. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Name](/api/corvus-text-json-jsonproperty-tvalue.name.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of this property. |
| [NameSpan](/api/corvus-text-json-jsonproperty-tvalue.namespan.html) | [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) | Gets the name as an unescaped UTF-8 JSON string. |
| [Value](/api/corvus-text-json-jsonproperty-tvalue.value.html) | `TValue` | The value of this property. |

## Methods

| Method | Description |
|--------|-------------|
| [NameEquals(string)](/api/corvus-text-json-jsonproperty-tvalue.nameequals.html#bool-nameequals-string-text) | Compares `text` to the name of this property. |
| [NameEquals(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonproperty-tvalue.nameequals.html#bool-nameequals-readonlyspan-byte-utf8text) | Compares the text represented by `utf8Text` to the name of this property. |
| [NameEquals(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonproperty-tvalue.nameequals.html#bool-nameequals-readonlyspan-char-text) | Compares `text` to the name of this property. |
| [ToString()](/api/corvus-text-json-jsonproperty-tvalue.tostring.html#string-tostring) | Provides a [`String`](https://learn.microsoft.com/dotnet/api/system.string) representation of the property for debugging purposes. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonproperty-tvalue.writeto.html#void-writeto-utf8jsonwriter-writer) | Write the property into the provided writer as a named JSON object property. |

