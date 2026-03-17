---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayReverseEnumerator — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ArrayReverseEnumerator.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/ArrayReverseEnumerator.cs#L18)

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

```csharp
public readonly struct ArrayReverseEnumerator
```

## Constructors

| Constructor | Description |
|-------------|-------------|
| [ArrayReverseEnumerator(IJsonDocument, int)](/api/corvus-text-json-internal-arrayreverseenumerator.ctor.html#arrayreverseenumerator-ijsondocument-int) | Initializes a new instance of the [`ArrayReverseEnumerator`](/api/corvus-text-json-internal-arrayreverseenumerator.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [CurrentEndIndex](/api/corvus-text-json-internal-arrayreverseenumerator.currentendindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current end index of the item within the JSON array. |
| [CurrentIndex](/api/corvus-text-json-internal-arrayreverseenumerator.currentindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current index within the JSON array. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-arrayreverseenumerator.dispose.html#dispose) | Releases resources used by the enumerator. |
| [MoveNext()](/api/corvus-text-json-internal-arrayreverseenumerator.movenext.html#movenext) | Advances the enumerator to the next element of the collection. |
| [Reset()](/api/corvus-text-json-internal-arrayreverseenumerator.reset.html#reset) | Sets the enumerator to its initial position, which is before the first element in the collection. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

