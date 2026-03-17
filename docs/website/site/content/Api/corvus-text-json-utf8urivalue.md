---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriValue — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8UriValue.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Utf8UriValue.cs#L20)

A UTF-8 URI value that has been parsed from a JSON document.

```csharp
public readonly struct Utf8UriValue : IDisposable
```

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Uri](/api/corvus-text-json-utf8urivalue.uri.html) | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) | Gets the UTF-8 URI value. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-utf8urivalue.dispose.html#dispose) | Disposes the underlying resources used to store the UTF-8 string backing the URI value. |
| [TryGetValue(ref T, int, ref Utf8UriValue)](/api/corvus-text-json-utf8urivalue.trygetvalue.html#trygetvalue-ref-t-int-ref-utf8urivalue) `static` | Tries to get the value of the element at the specified index as a [`Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

