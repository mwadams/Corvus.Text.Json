---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8IriValue : IDisposable
```

A UTF-8 IRI value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Iri` | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) | Gets the UTF-8 IRI value. |

## Methods

### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8IriValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html) | The [`Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html) value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the IRI value.

