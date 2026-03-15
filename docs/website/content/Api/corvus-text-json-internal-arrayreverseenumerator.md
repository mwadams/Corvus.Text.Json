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

### ArrayReverseEnumerator

```csharp
ArrayReverseEnumerator(IJsonDocument targetDocument, int arrayDocumentIndex)
```

Initializes a new instance of the [`ArrayReverseEnumerator`](/api/corvus-text-json-internal-arrayreverseenumerator.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The document containing the array to enumerate. |
| `arrayDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial index of the array element in the document. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current index within the JSON array. |
| `CurrentEndIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current end index of the item within the JSON array. |

## Methods

### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element in the collection.

