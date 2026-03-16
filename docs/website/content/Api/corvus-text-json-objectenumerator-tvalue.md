---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ObjectEnumerator<TValue> — Corvus.Text.Json"
---
```csharp
public readonly struct ObjectEnumerator<TValue> : IEnumerable<JsonProperty<TValue>>, IEnumerable, IEnumerator<JsonProperty<TValue>>, IEnumerator, IDisposable
```

An enumerable and enumerator for the properties of a JSON object.

## Implements

[`IEnumerable<JsonProperty<TValue>>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1), [`IEnumerable`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable), [`IEnumerator<JsonProperty<TValue>>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1), [`IEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerator), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Current](/api/corvus-text-json-objectenumerator-tvalue.current.html) | [`JsonProperty<TValue>`](/api/corvus-text-json-jsonproperty-tvalue.html) |  |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-objectenumerator-tvalue.dispose.html#dispose) |  |
| [GetEnumerator()](/api/corvus-text-json-objectenumerator-tvalue.getenumerator.html#getenumerator) | Returns an enumerator that iterates the properties of an object. |
| [MoveNext()](/api/corvus-text-json-objectenumerator-tvalue.movenext.html#movenext) |  |
| [Reset()](/api/corvus-text-json-objectenumerator-tvalue.reset.html#reset) |  |

