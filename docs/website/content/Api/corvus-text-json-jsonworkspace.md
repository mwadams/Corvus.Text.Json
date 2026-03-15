---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWorkspace — Corvus.Text.Json"
---
```csharp
public class JsonWorkspace : IDisposable
```

A workspace for manipulating JSON documents.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonWorkspace**

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Gets the JsonWriterOptions |

## Methods

### Create `static`

```csharp
JsonWorkspace Create(int initialDocumentCapacity, Nullable<JsonWriterOptions> options)
```

Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialDocumentCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial document capacity for the workspace. *(optional)* |
| `options` | [`Nullable<JsonWriterOptions>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The ambient [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html). *(optional)* |

**Returns:** [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html)

The [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

### CreateUnrented `static`

```csharp
JsonWorkspace CreateUnrented(int initialDocumentCapacity, Nullable<JsonWriterOptions> options)
```

Creates an instance of a [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialDocumentCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial document capacity for the workspace. *(optional)* |
| `options` | [`Nullable<JsonWriterOptions>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The ambient [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html). *(optional)* |

**Returns:** [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html)

The [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html).

### RentWriterAndBuffer

```csharp
Utf8JsonWriter RentWriterAndBuffer(int defaultBufferSize, ref IByteBufferWriter bufferWriter)
```

Rents a UTF-8 JSON writer and associated buffer writer from the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `defaultBufferSize` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The default buffer size to use for the buffer writer. |
| `bufferWriter` | [`ref IByteBufferWriter`](/api/corvus-text-json-ibytebufferwriter.html) | When this method returns, contains the rented buffer writer. |

**Returns:** [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html)

A rented UTF-8 JSON writer configured with the workspace options.

### RentWriter

```csharp
Utf8JsonWriter RentWriter(IBufferWriter<byte> bufferWriter)
```

Rents a UTF-8 JSON writer from the pool that writes to the specified buffer writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | The buffer writer to write JSON data to. |

**Returns:** [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html)

A rented UTF-8 JSON writer configured with the workspace options.

### ReturnWriterAndBuffer

```csharp
void ReturnWriterAndBuffer(Utf8JsonWriter writer, IByteBufferWriter bufferWriter)
```

Returns a rented UTF-8 JSON writer and buffer writer to the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to return to the pool. |
| `bufferWriter` | [`IByteBufferWriter`](/api/corvus-text-json-ibytebufferwriter.html) | The buffer writer to return to the pool. |

### ReturnWriter

```csharp
void ReturnWriter(Utf8JsonWriter writer)
```

Returns a rented UTF-8 JSON writer to the pool.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer to return to the pool. |

### Dispose

```csharp
void Dispose()
```

### CreateBuilder

```csharp
JsonDocumentBuilder<TMutableElement> CreateBuilder<TElement, TMutableElement>(TElement sourceElement)
```

Creates a document builder for building mutable JSON documents from an existing element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the source JSON element. |
| `TMutableElement` | The type of the mutable JSON element to build. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `sourceElement` | `TElement` | The source element to build from. |

**Returns:** [`JsonDocumentBuilder<TMutableElement>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A document builder for the mutable element type.

### CreateBuilder

```csharp
JsonDocumentBuilder<TElement> CreateBuilder<TElement>(int initialCapacity, int initialValueBufferSize)
```

Creates a document builder for building mutable JSON documents.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the mutable JSON element to build. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `initialCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial capacity for the document builder. *(optional)* |
| `initialValueBufferSize` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial size of the value buffer. *(optional)* |

**Returns:** [`JsonDocumentBuilder<TElement>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A document builder for the specified element type.

