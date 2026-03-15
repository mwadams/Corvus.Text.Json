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
| `Current` | `TItem` | Gets the current element in the collection. |

## Methods

### GetEnumerator

```csharp
ArrayEnumerator<TItem> GetEnumerator()
```

Returns an enumerator that iterates through the JSON array.

**Returns:** [`ArrayEnumerator<TItem>`](/api/corvus-text-json-arrayenumerator-titem.html)

An [`ArrayEnumerator`](/api/corvus-text-json-arrayenumerator-titem.html) value that can be used to iterate through the array.

### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element in the collection.

### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

