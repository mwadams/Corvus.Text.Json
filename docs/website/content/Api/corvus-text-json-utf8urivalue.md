---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8UriValue : IDisposable
```

A UTF-8 URI value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Uri` | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) | Gets the UTF-8 URI value. |

## Methods

### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html) | The [`Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html) value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the URI value.

