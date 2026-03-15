---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayReverseEnumerator — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct ArrayReverseEnumerator
```

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

## Constructors

| Constructor | Description |
|-------------|-------------|
| [ArrayReverseEnumerator(IJsonDocument, int)](/api/corvus-text-json-internal-arrayreverseenumerator.ctor.html#arrayreverseenumerator-ijsondocument-targetdocument-int-arraydocumentindex) | Initializes a new instance of the [`ArrayReverseEnumerator`](/api/corvus-text-json-internal-arrayreverseenumerator.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [CurrentEndIndex](/api/corvus-text-json-internal-arrayreverseenumerator.currentendindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current end index of the item within the JSON array. |
| [CurrentIndex](/api/corvus-text-json-internal-arrayreverseenumerator.currentindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current index within the JSON array. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-arrayreverseenumerator.dispose.html#void-dispose) | Releases resources used by the enumerator. |
| [MoveNext()](/api/corvus-text-json-internal-arrayreverseenumerator.movenext.html#bool-movenext) | Advances the enumerator to the next element of the collection. |
| [Reset()](/api/corvus-text-json-internal-arrayreverseenumerator.reset.html#void-reset) | Sets the enumerator to its initial position, which is before the first element in the collection. |

