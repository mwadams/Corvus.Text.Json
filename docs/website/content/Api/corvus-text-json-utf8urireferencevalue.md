---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReferenceValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8UriReferenceValue : IDisposable
```

A UTF-8 URI reference value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [UriReference](/api/corvus-text-json-utf8urireferencevalue.urireference.html) | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | Gets the UTF-8 URI reference value. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-utf8urireferencevalue.dispose.html#void-dispose) | Disposes the underlying resources used to store the UTF-8 string backing the URI reference value. |
| [TryGetValue(ref T, int, ref Utf8UriReferenceValue)](/api/corvus-text-json-utf8urireferencevalue.trygetvalue.html#bool-trygetvalue-t-ref-t-jsondocument-int-index-ref-utf8urireferencevalue-value) `static` | Tries to get the value of the element at the specified index as a [`Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html). |

