---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8IriValue : IDisposable
```

A UTF-8 IRI value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Iri](/api/corvus-text-json-utf8irivalue.iri.html) | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) | Gets the UTF-8 IRI value. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-utf8irivalue.dispose.html#dispose) | Disposes the underlying resources used to store the UTF-8 string backing the IRI value. |
| [TryGetValue(ref T, int, ref Utf8IriValue)](/api/corvus-text-json-utf8irivalue.trygetvalue.html#trygetvalue-ref-t-int-ref-utf8irivalue) `static` | Tries to get the value of the element at the specified index as a [`Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

