---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "FixedStringJsonDocument<T> — Corvus.Text.Json.Internal"
---
```csharp
public sealed class FixedStringJsonDocument<T> : IJsonDocument, IDisposable
```

Represents a JSON document based on a fixed string value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the root element in the document. |

## Remarks

This type uses an internal cache to avoid allocations for evaluatoin of string values that have not originated in a regular JSON document (e.g. property names, or external strings.)

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **FixedStringJsonDocument<T>**

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [RootElement](/api/corvus-text-json-internal-fixedstringjsondocument-t.rootelement.html) | `T` |  |

## Methods

| Method | Description |
|--------|-------------|
| [Parse(ReadOnlyMemory&lt;byte&gt;, bool)](/api/corvus-text-json-internal-fixedstringjsondocument-t.parse.html#parse-readonlymemory-byte-bool) `static` | Parse an instance of the fixed string to a document, using caching. |
| [ToString(int, string, IFormatProvider)](/api/corvus-text-json-internal-fixedstringjsondocument-t.tostring.html#tostring-int-string-iformatprovider) |  |
| [TryFormat](/api/corvus-text-json-internal-fixedstringjsondocument-t.tryformat.html) |  |

