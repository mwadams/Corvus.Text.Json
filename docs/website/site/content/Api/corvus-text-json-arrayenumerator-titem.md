---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayEnumerator<TItem> — Corvus.Text.Json"
---
```csharp
public readonly struct ArrayEnumerator<TItem> : IEnumerable<TItem>, IEnumerable, IEnumerator<TItem>, IEnumerator, IDisposable
```

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TItem` | The type of the JSON element to enumerate, which must implement [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

## Implements

[`IEnumerable<TItem>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1), [`IEnumerable`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable), [`IEnumerator<TItem>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1), [`IEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerator), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Current](/api/corvus-text-json-arrayenumerator-titem.current.html) | `TItem` | Gets the current element in the collection. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-arrayenumerator-titem.dispose.html#dispose) | Releases resources used by the enumerator. |
| [GetEnumerator()](/api/corvus-text-json-arrayenumerator-titem.getenumerator.html#getenumerator) | Returns an enumerator that iterates through the JSON array. |
| [MoveNext()](/api/corvus-text-json-arrayenumerator-titem.movenext.html#movenext) | Advances the enumerator to the next element of the collection. |
| [Reset()](/api/corvus-text-json-arrayenumerator-titem.reset.html#reset) | Sets the enumerator to its initial position, which is before the first element in the collection. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

