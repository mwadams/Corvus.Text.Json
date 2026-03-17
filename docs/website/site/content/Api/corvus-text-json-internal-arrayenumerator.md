---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayEnumerator — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ArrayEnumerator.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/ArrayEnumerator.cs#L18)

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

```csharp
public readonly struct ArrayEnumerator
```

## Constructors

| Constructor | Description |
|-------------|-------------|
| [ArrayEnumerator(IJsonDocument, int)](/api/corvus-text-json-internal-arrayenumerator.ctor.html#arrayenumerator-ijsondocument-int) | Initializes a new instance of the [`ArrayEnumerator`](/api/corvus-text-json-internal-arrayenumerator.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [CurrentIndex](/api/corvus-text-json-internal-arrayenumerator.currentindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current index within the JSON array. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-arrayenumerator.dispose.html#dispose) | Releases resources used by the enumerator. |
| [MoveNext()](/api/corvus-text-json-internal-arrayenumerator.movenext.html#movenext) | Advances the enumerator to the next element of the collection. |
| [Reset()](/api/corvus-text-json-internal-arrayenumerator.reset.html#reset) | Sets the enumerator to its initial position, which is before the first element in the collection. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

