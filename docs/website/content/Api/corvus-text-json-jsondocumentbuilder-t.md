---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentBuilder<T> — Corvus.Text.Json"
---
```csharp
public sealed class JsonDocumentBuilder<T> : JsonDocument, IMutableJsonDocument, IJsonDocument, IDisposable
```

A mutable JSON document builder that provides functionality to construct and modify JSON documents.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of mutable JSON element this builder works with. |

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) → **JsonDocumentBuilder<T>**

## Implements

[`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html), [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` | Gets the root element of the JSON document. |

### RootElement

```csharp
T RootElement { get; }
```

Gets the root element of the JSON document.

**Value:** The mutable root element of the document.

## Methods

### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the document into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) |  |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This [`RootElement`](/api/corvus-text-json-jsondocumentbuilder-t.html)'s [`ValueKind`](/api/corvus-text-json-jsonelement.html) would result in an invalid JSON. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Dispose

```csharp
void Dispose()
```

