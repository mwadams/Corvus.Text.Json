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
| `Current` | [`JsonProperty<TValue>`](/api/corvus-text-json-jsonproperty-tvalue.html) |  |

## Methods

### GetEnumerator

```csharp
ObjectEnumerator<TValue> GetEnumerator()
```

Returns an enumerator that iterates the properties of an object.

**Returns:** [`ObjectEnumerator<TValue>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An [`ObjectEnumerator`](/api/corvus-text-json-internal-objectenumerator.html) value that can be used to iterate through the object.

The enumerator will enumerate the properties in the order they are declared, and when an object has multiple definitions of a single property they will all individually be returned (each in the order they appear in the content).

### Dispose

```csharp
void Dispose()
```

### Reset

```csharp
void Reset()
```

### MoveNext

```csharp
bool MoveNext()
```

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

