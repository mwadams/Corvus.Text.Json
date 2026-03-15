---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ObjectEnumerator — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct ObjectEnumerator
```

An enumerable and enumerator for the properties of a JSON object.

## Constructors

### ObjectEnumerator

```csharp
ObjectEnumerator(IJsonDocument targetDocument, int initialIndex)
```

Initializes a new instance of the [`ObjectEnumerator`](/api/corvus-text-json-internal-objectenumerator.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The target document containing the object to enumerate. |
| `initialIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial index of the object in the document. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the current index in the document. |

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element.

