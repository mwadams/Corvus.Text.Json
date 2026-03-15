---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReferenceValue — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8UriReferenceValue : IDisposable
```

A UTF-8 URI reference value that has been parsed from a JSON document.

## Remarks

This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `UriReference` | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | Gets the UTF-8 URI reference value. |

## Methods

### TryGetValue `static`

```csharp
bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriReferenceValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html).

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html) | The [`Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html) value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### Dispose

```csharp
void Dispose()
```

Disposes the underlying resources used to store the UTF-8 string backing the URI reference value.

