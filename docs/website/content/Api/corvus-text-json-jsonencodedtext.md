---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonEncodedText — Corvus.Text.Json"
---
```csharp
public readonly struct JsonEncodedText : IEquatable<JsonEncodedText>
```

Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON.

## Remarks

This can be used to cache and store known strings used for writing JSON ahead of time by pre-encoding them up front.

## Implements

[`IEquatable<JsonEncodedText>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [EncodedUtf8Bytes](/api/corvus-text-json-jsonencodedtext.encodedutf8bytes.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Returns the UTF-8 encoded representation of the pre-encoded JSON text. |
| [Value](/api/corvus-text-json-jsonencodedtext.value.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Returns the UTF-16 encoded representation of the pre-encoded JSON text as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |

## Methods

| Method | Description |
|--------|-------------|
| [Encode(string, JavaScriptEncoder)](/api/corvus-text-json-jsonencodedtext.encode.html#encode-string-javascriptencoder) `static` | Encodes the string text value as a JSON string. |
| [Encode(ReadOnlySpan&lt;char&gt;, JavaScriptEncoder)](/api/corvus-text-json-jsonencodedtext.encode.html#encode-readonlyspan-char-javascriptencoder) `static` | Encodes the text value as a JSON string. |
| [Encode(ReadOnlySpan&lt;byte&gt;, JavaScriptEncoder)](/api/corvus-text-json-jsonencodedtext.encode.html#encode-readonlyspan-byte-javascriptencoder) `static` | Encodes the UTF-8 text value as a JSON string. |
| [Equals(JsonEncodedText)](/api/corvus-text-json-jsonencodedtext.equals.html#equals-jsonencodedtext) | Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value. |
| [Equals(object)](/api/corvus-text-json-jsonencodedtext.equals.html#equals-object) | Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value. |
| [GetHashCode()](/api/corvus-text-json-jsonencodedtext.gethashcode.html#gethashcode) | Returns the hash code for this [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html). |
| [ToString()](/api/corvus-text-json-jsonencodedtext.tostring.html#tostring) | Converts the value of this instance to a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |

