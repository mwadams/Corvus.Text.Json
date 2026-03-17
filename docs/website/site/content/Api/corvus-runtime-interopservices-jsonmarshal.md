---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonMarshal — Corvus.Runtime.InteropServices"
---
```csharp
public static class JsonMarshal
```

An unsafe class that provides a set of methods to access the underlying data representations of JSON types.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonMarshal**

## Methods

| Method | Description |
|--------|-------------|
| [GetRawUtf8PropertyName(JsonProperty&lt;T&gt;)](/api/corvus-runtime-interopservices-jsonmarshal.getrawutf8propertyname.html#getrawutf8propertyname-jsonproperty-t) `static` | Gets a [`ReadOnlySpan`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) view over the raw JSON data of the given `JsonProperty` name. |
| [GetRawUtf8Value(T)](/api/corvus-runtime-interopservices-jsonmarshal.getrawutf8value.html#getrawutf8value-t) `static` | Gets a [`ReadOnlySpan`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) view over the raw JSON data of the given JSON element. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

