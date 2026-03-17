---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriReferenceValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8IriReferenceValue : IDisposable
```

A UTF-8 IRI reference value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IriReference](/api/corvus-text-json-utf8irireferencevalue.irireference.html) | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | Gets the UTF-8 IRI reference value. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-utf8irireferencevalue.dispose.html#dispose) | Disposes the underlying resources used to store the UTF-8 string backing the IRI reference value. |
| [TryGetValue(ref T, int, ref Utf8IriReferenceValue)](/api/corvus-text-json-utf8irireferencevalue.trygetvalue.html#trygetvalue-ref-t-int-ref-utf8irireferencevalue) `static` | Tries to get the value of the element at the specified index as a [`Utf8IriReferenceValue`](/api/corvus-text-json-utf8irireferencevalue.html). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

