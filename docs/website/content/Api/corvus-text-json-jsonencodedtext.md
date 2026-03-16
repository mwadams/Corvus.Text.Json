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
| [Encode](/api/corvus-text-json-jsonencodedtext.encode.html) `static` | Encodes the string text value as a JSON string. |
| [Equals](/api/corvus-text-json-jsonencodedtext.equals.html) | Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value. |
| [GetHashCode()](/api/corvus-text-json-jsonencodedtext.gethashcode.html#gethashcode) | Returns the hash code for this [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html). |
| [ToString()](/api/corvus-text-json-jsonencodedtext.tostring.html#tostring) | Converts the value of this instance to a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |

