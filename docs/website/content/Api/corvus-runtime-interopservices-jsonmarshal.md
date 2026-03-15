---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonMarshal — Corvus.Runtime.InteropServices"
---
```csharp
public static class JsonMarshal
```

An unsafe class that provides a set of methods to access the underlying data representations of JSON types.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonMarshal**

## Methods

### GetRawUtf8PropertyName `static`

```csharp
ReadOnlySpan<byte> GetRawUtf8PropertyName<T>(JsonProperty<T> property)
```

Gets a `ReadOnlySpan` view over the raw JSON data of the given `JsonProperty` name.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `property` | [`JsonProperty<T>`](/api/corvus-text-json-jsonproperty-tvalue.html) | The JSON property from which to extract the span. |

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The span containing the raw JSON data of the `property` name. This will not include the enclosing quotes.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

While the method itself does check for disposal of the underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html), it is possible that it could be disposed after the method returns, which would result in the span pointing to a buffer that has been returned to the shared pool. Callers should take extra care to make sure that such a scenario isn't possible to avoid potential data corruption.

### GetRawUtf8Value `static`

```csharp
RawUtf8JsonString GetRawUtf8Value<T>(T element)
```

Gets a `ReadOnlySpan` view over the raw JSON data of the given JSON element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` | The JSON element from which to extract the span. |

**Returns:** [`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html)

The span containing the raw JSON data of`element`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

While the method itself does check for disposal of the underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html), it is possible that it could be disposed after the method returns, which would result in the span pointing to a buffer that has been returned to the shared pool. Callers should take extra care to make sure that such a scenario isn't possible to avoid potential data corruption.

