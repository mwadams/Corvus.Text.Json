---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElement : IJsonElement<JsonElement>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

Represents a specific JSON value within a [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

## Implements

[`IJsonElement<JsonElement>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is. |
| `Item` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |
| `Item` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |
| `Item` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |
| `Item` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |

## Methods

### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> builder, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `context` | `ref TContext` |  |
| `builder` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

### CreateBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> builder, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `context` | `ref TContext` |  |
| `builder` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

### CreateArrayBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateArrayBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

Creates an empty mutable array document builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of members in the document. *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing an empty array.

### CreateObjectBuilder `static`

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateObjectBuilder(JsonWorkspace workspace, int estimatedMemberCount)
```

Creates an empty mutable object document builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for the document builder. |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of members in the document. *(optional)* |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing an empty object.

### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the JSON Schema for this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) | The (optional) results collector for schema validation. *(optional)* |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the element is valid according to its schema; otherwise, `false`.

### Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether the specified object is equal to the current JsonElement.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with the current JsonElement. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified object is equal to the current JsonElement; otherwise, `false`.

### Equals

```csharp
bool Equals<T>(T other)
```

Determines whether the current JsonElement is equal to another JsonElement-like value through deep comparison.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the other JSON element that implements IJsonElement. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` | The JSON element to compare with this JsonElement. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the current JsonElement is equal to the other parameter; otherwise, `false`.

### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace)
```

Creates a mutable document builder from this JsonElement using the specified workspace.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JsonWorkspace to use for creating the document builder. |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JsonDocumentBuilder configured for mutable operations on this JsonElement.

### From `static`

```csharp
JsonElement From<T>(ref T instance)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` |  |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

### GetArrayLength

```csharp
int GetArrayLength()
```

Get the number of values contained within the current array value.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of values contained within the current array value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### GetPropertyCount

```csharp
int GetPropertyCount()
```

Get the number of properties contained within the current object value.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of properties contained within the current object value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### GetProperty

```csharp
JsonElement GetProperty(string propertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Name of the property whose value to return. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `propertyName` is `null`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### GetProperty

```csharp
JsonElement GetProperty(ReadOnlySpan<char> propertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Name of the property whose value to return. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### GetProperty

```csharp
JsonElement GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `utf8PropertyName`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### TryGetProperty

```csharp
bool TryGetProperty(string propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Name of the property to find. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `propertyName` is `null`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Name of the property to find. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement value)
```

Looks for a property named `utf8PropertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

### TryGetBoolean

```csharp
bool TryGetBoolean(ref bool value)
```

Tries to get the value as a boolean

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Provides the boolean value if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was a boolean, otherwise false.

### GetBoolean

```csharp
bool GetBoolean()
```

Gets the value of the element as a `Boolean`.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

The value of the element as a `Boolean`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is neither [`True`](/api/corvus-text-json-jsonvaluekind.html) or [`False`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetString

```csharp
string GetString()
```

Gets the value of the element as a `String`.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The value of the element as a `String`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is neither [`String`](/api/corvus-text-json-jsonvaluekind.html) nor [`Null`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a string representation of values other than JSON strings.

### GetUtf8String

```csharp
UnescapedUtf8JsonString GetUtf8String()
```

Gets the value of the element as a [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html).

**Returns:** [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The value of the element as an [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is neither [`String`](/api/corvus-text-json-jsonvaluekind.html) nor [`Null`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

The [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) should be disposed when it is finished with, as it may have rented storage to provide the unescaped value. It is only valid for as long as the source [`JsonElement`](/api/corvus-text-json-jsonelement.html) is valid.

### GetUtf16String

```csharp
UnescapedUtf16JsonString GetUtf16String()
```

Gets the value of the element as a [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html).

**Returns:** [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

The value of the element as an [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is neither [`String`](/api/corvus-text-json-jsonvaluekind.html) nor [`Null`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

The [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) should be disposed when it is finished with, as it may have rented storage to provide the unescaped value. It is only valid for as long as the source [`JsonElement`](/api/corvus-text-json-jsonelement.html) is valid.

### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

Attempts to represent the current JSON string as bytes assuming it is Base64 encoded.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes. `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a byte[] representation of values other than base 64 encoded JSON strings.

### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

Gets the value of the element as bytes.

**Returns:** [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte)

The value decode to bytes.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value is not encoded as Base64 text and hence cannot be decoded to bytes. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a byte[] representation of values other than Base64 encoded JSON strings.

### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

Attempts to represent the current JSON number as an `SByte`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as an `SByte`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetSByte

```csharp
sbyte GetSByte()
```

Gets the current JSON number as an `SByte`.

**Returns:** [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte)

The current JSON number as an `SByte`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as an `SByte`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

Attempts to represent the current JSON number as a `Byte`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte`](https://learn.microsoft.com/dotnet/api/system.byte) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `Byte`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetByte

```csharp
byte GetByte()
```

Gets the current JSON number as a `Byte`.

**Returns:** [`byte`](https://learn.microsoft.com/dotnet/api/system.byte)

The current JSON number as a `Byte`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Byte`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

Attempts to represent the current JSON number as an `Int16`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as an `Int16`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetInt16

```csharp
short GetInt16()
```

Gets the current JSON number as an `Int16`.

**Returns:** [`short`](https://learn.microsoft.com/dotnet/api/system.int16)

The current JSON number as an `Int16`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as an `Int16`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

Attempts to represent the current JSON number as a `UInt16`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `UInt16`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetUInt16

```csharp
ushort GetUInt16()
```

Gets the current JSON number as a `UInt16`.

**Returns:** [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16)

The current JSON number as a `UInt16`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `UInt16`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

Attempts to represent the current JSON number as an `Int32`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as an `Int32`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetInt32

```csharp
int GetInt32()
```

Gets the current JSON number as an `Int32`.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The current JSON number as an `Int32`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as an `Int32`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

Attempts to represent the current JSON number as a `UInt32`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `UInt32`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetUInt32

```csharp
uint GetUInt32()
```

Gets the current JSON number as a `UInt32`.

**Returns:** [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32)

The current JSON number as a `UInt32`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `UInt32`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

Attempts to represent the current JSON number as a `Int64`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `Int64`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetInt64

```csharp
long GetInt64()
```

Gets the current JSON number as a `Int64`.

**Returns:** [`long`](https://learn.microsoft.com/dotnet/api/system.int64)

The current JSON number as a `Int64`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Int64`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

Attempts to represent the current JSON number as a `UInt64`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `UInt64`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetUInt64

```csharp
ulong GetUInt64()
```

Gets the current JSON number as a `UInt64`.

**Returns:** [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64)

The current JSON number as a `UInt64`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `UInt64`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

Attempts to represent the current JSON number as a `Double`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `Double`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than `MaxValue` (or smaller than `MinValue`), instead `true` is returned and `PositiveInfinity` (or `NegativeInfinity`) is emitted.

### GetDouble

```csharp
double GetDouble()
```

Gets the current JSON number as a `Double`.

**Returns:** [`double`](https://learn.microsoft.com/dotnet/api/system.double)

The current JSON number as a `Double`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Double`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method returns `PositiveInfinity` (or `NegativeInfinity`) for values larger than `MaxValue` (or smaller than `MinValue`).

### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

Attempts to represent the current JSON number as a `Single`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `Single`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method does not return `false` for values larger than `MaxValue` (or smaller than `MinValue`), instead `true` is returned and `PositiveInfinity` (or `NegativeInfinity`) is emitted.

### GetSingle

```csharp
float GetSingle()
```

Gets the current JSON number as a `Single`.

**Returns:** [`float`](https://learn.microsoft.com/dotnet/api/system.single)

The current JSON number as a `Single`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Single`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value. On .NET Core this method returns `PositiveInfinity` (or `NegativeInfinity`) for values larger than `MaxValue` (or smaller than `MinValue`).

### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

Attempts to represent the current JSON number as a `Decimal`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `Decimal`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetDecimal

```csharp
decimal GetDecimal()
```

Gets the current JSON number as a `Decimal`.

**Returns:** [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal)

The current JSON number as a `Decimal`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Decimal`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetBigNumber

```csharp
bool TryGetBigNumber(ref BigNumber value)
```

Attempts to represent the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a [`BigNumber`](/api/corvus-numerics-bignumber.html), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetBigNumber

```csharp
BigNumber GetBigNumber()
```

Gets the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetBigInteger

```csharp
bool TryGetBigInteger(ref BigInteger value)
```

Attempts to represent the current JSON number as a `BigInteger`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the number can be represented as a `BigInteger`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### GetBigInteger

```csharp
BigInteger GetBigInteger()
```

Gets the current JSON number as a `BigInteger`.

**Returns:** [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger)

The current JSON number as a `BigInteger`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `BigInteger`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not parse the contents of a JSON string value.

### TryGetLocalDate

```csharp
bool TryGetLocalDate(ref LocalDate value)
```

Attempts to represent the current JSON string as a `LocalDate`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `LocalDate`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a LocalDate representation of values other than JSON strings.

### GetLocalDate

```csharp
LocalDate GetLocalDate()
```

Gets the value of the element as a `LocalDate`.

**Returns:** `LocalDate`

The value of the element as a `LocalDate`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a LocalDate representation of values other than JSON strings.

### TryGetOffsetTime

```csharp
bool TryGetOffsetTime(ref OffsetTime value)
```

Attempts to represent the current JSON string as a `OffsetTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `OffsetTime`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetTime representation of values other than JSON strings.

### GetOffsetTime

```csharp
OffsetTime GetOffsetTime()
```

Gets the value of the element as a `OffsetTime`.

**Returns:** `OffsetTime`

The value of the element as a `OffsetTime`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetTime representation of values other than JSON strings.

### TryGetOffsetDateTime

```csharp
bool TryGetOffsetDateTime(ref OffsetDateTime value)
```

Attempts to represent the current JSON string as a `OffsetDateTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `OffsetDateTime`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetDateTime representation of values other than JSON strings.

### TryGetOffsetDate

```csharp
bool TryGetOffsetDate(ref OffsetDate value)
```

Attempts to represent the current JSON string as a `OffsetDate`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `OffsetDate`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetDate representation of values other than JSON strings.

### GetOffsetDate

```csharp
OffsetDate GetOffsetDate()
```

Gets the value of the element as a `OffsetDate`.

**Returns:** `OffsetDate`

The value of the element as a `OffsetDate`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetDate representation of values other than JSON strings.

### GetOffsetDateTime

```csharp
OffsetDateTime GetOffsetDateTime()
```

Gets the value of the element as a `OffsetDateTime`.

**Returns:** `OffsetDateTime`

The value of the element as a `OffsetDateTime`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a OffsetDateTime representation of values other than JSON strings.

### TryGetPeriod

```csharp
bool TryGetPeriod(ref Period value)
```

Attempts to represent the current JSON string as a [`Period`](/api/corvus-text-json-period.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a [`Period`](/api/corvus-text-json-period.html), `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a Period representation of values other than JSON strings.

### GetPeriod

```csharp
Period GetPeriod()
```

Gets the value of the element as a [`Period`](/api/corvus-text-json-period.html).

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The value of the element as a [`Period`](/api/corvus-text-json-period.html).

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a Period representation of values other than JSON strings.

### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

Attempts to represent the current JSON string as a `DateTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `DateTime`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a DateTime representation of values other than JSON strings.

### GetDateTime

```csharp
DateTime GetDateTime()
```

Gets the value of the element as a `DateTime`.

**Returns:** [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime)

The value of the element as a `DateTime`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTime`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a DateTime representation of values other than JSON strings.

### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

Attempts to represent the current JSON string as a `DateTimeOffset`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `DateTimeOffset`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a DateTimeOffset representation of values other than JSON strings.

### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

Gets the value of the element as a `DateTimeOffset`.

**Returns:** [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

The value of the element as a `DateTimeOffset`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `DateTimeOffset`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a DateTimeOffset representation of values other than JSON strings.

### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

Attempts to represent the current JSON string as a `Guid`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | Receives the value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a `Guid`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a Guid representation of values other than JSON strings.

### GetGuid

```csharp
Guid GetGuid()
```

Gets the value of the element as a `Guid`.

**Returns:** [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid)

The value of the element as a `Guid`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a `Guid`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

This method does not create a Guid representation of values other than JSON strings.

### GetRawText

```csharp
string GetRawText()
```

Gets the original input data backing this value, returning it as a `String`.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The original input data backing this value, returning it as a `String`.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

Note that this method allocates.

### EnsurePropertyMap

```csharp
void EnsurePropertyMap()
```

Ensures that a fast-lookup property map is created for this element.

This enables dictionary-based lookup of property values in the element. If the cost of lookups exceeds the cost of building the map, this can provide substantial performance improvements. It is a zero-allocation operation.

### ValueEquals

```csharp
bool ValueEquals(string text)
```

Compares `text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html), but avoids creating the string instance.

### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |

This method is functionally equal to doing an ordinal comparison of the string produced by UTF-8 decoding `utf8Text` with the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html), but avoids creating the string instances.

### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<char> text)
```

Compares `text` to the string value of this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`String`](/api/corvus-text-json-jsonvaluekind.html). |

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html), but avoids creating the string instance.

### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the element into the provided writer as a JSON value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is [`Undefined`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### EnumerateArray

```csharp
ArrayEnumerator<JsonElement> EnumerateArray()
```

Get an enumerator to enumerate the values in the JSON array represented by this JsonElement.

**Returns:** [`ArrayEnumerator<JsonElement>`](/api/corvus-text-json-arrayenumerator-titem.html)

An enumerator to enumerate the values in the JSON array represented by this JsonElement.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### EnumerateObject

```csharp
ObjectEnumerator<JsonElement> EnumerateObject()
```

Get an enumerator to enumerate the properties in the JSON object represented by this JsonElement.

**Returns:** [`ObjectEnumerator<JsonElement>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An enumerator to enumerate the properties in the JSON object represented by this JsonElement.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### ToString `virtual`

```csharp
string ToString()
```

Gets a string representation for the current value appropriate to the value type.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation for the current value appropriate to the value type.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

For JsonElement built from [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html): For [`Null`](/api/corvus-text-json-jsonvaluekind.html), `Empty` is returned. For [`True`](/api/corvus-text-json-jsonvaluekind.html), `TrueString` is returned. For [`False`](/api/corvus-text-json-jsonvaluekind.html), `FalseString` is returned. For [`String`](/api/corvus-text-json-jsonvaluekind.html), the value of [`GetString`](/api/corvus-text-json-jsonelement.html)() is returned. For other types, the value of [`GetRawText`](/api/corvus-text-json-jsonelement.html)() is returned.

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Clone

```csharp
JsonElement Clone()
```

Get a JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

If this JsonElement is itself the output of a previous call to Clone, or a value contained within another JsonElement which was the output of a previous call to Clone, this method results in no additional memory allocation.

### ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormat

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ParseValue `static`

```csharp
JsonElement ParseValue(ReadOnlySpan<byte> utf8Json, JsonDocumentOptions options)
```

Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElement ParseValue(ReadOnlySpan<char> json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElement ParseValue(string json, JsonDocumentOptions options)
```

Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `json` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The JSON text to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representation of the JSON value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `json` is `null`. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

### ParseValue `static`

```csharp
JsonElement ParseValue(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

A JsonElement representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `reader` is using unsupported options. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The current `reader` token does not start or represent a value. |
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

If the [`TokenType`](/api/corvus-text-json-utf8jsonreader.html) property of `reader` is [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html) or [`None`](/api/corvus-text-json-internal-jsontokentype.html), the reader will be advanced by one call to [`Read`](/api/corvus-text-json-utf8jsonreader.html) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

### TryParseValue `static`

```csharp
bool TryParseValue(ref Utf8JsonReader reader, ref Nullable<JsonElement> element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) |  |
| `element` | [`ref Nullable<JsonElement>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset)
```

Tries to get the 1-based line number and character offset of this element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset, ref long lineByteOffset)
```

Tries to get the 1-based line number, character offset, and byte offset of this element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

### TryGetLine

```csharp
bool TryGetLine(int lineNumber, ref ReadOnlyMemory<byte> line)
```

Tries to get the specified line from the original source document as UTF-8 bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The 1-based line number to retrieve. |
| `line` | [`ref ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | When this method returns, contains the UTF-8 bytes of the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line was successfully retrieved; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.

### TryGetLine

```csharp
bool TryGetLine(int lineNumber, ref string line)
```

Tries to get the specified line from the original source document as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The 1-based line number to retrieve. |
| `line` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | When this method returns, contains the line text if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line was successfully retrieved; otherwise, `false`.

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.


### JsonElement.ArrayBuilder (struct)

```csharp
public readonly struct JsonElement.ArrayBuilder
```

#### Constructors

##### JsonElement.ArrayBuilder

```csharp
JsonElement.ArrayBuilder()
```

#### Methods

##### BuildValue `static`

```csharp
void BuildValue(JsonElement.ArrayBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### BuildValue `static`

```csharp
void BuildValue<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddItem

```csharp
void AddItem(JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |

##### AddItem

```csharp
void AddItem(JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### AddItem

```csharp
void AddItem(string value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

##### AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

##### AddItemNull

```csharp
void AddItemNull()
```

##### AddItem

```csharp
void AddItem(bool value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

##### AddItem

```csharp
void AddItem<T>(T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |

##### AddItem

```csharp
void AddItem(Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

##### AddItem

```csharp
void AddItem(ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

##### AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

##### AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` |  |

##### AddItem

```csharp
void AddItem(ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` |  |

##### AddItem

```csharp
void AddItem(ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` |  |

##### AddItem

```csharp
void AddItem(ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` |  |

##### AddItem

```csharp
void AddItem(ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

##### AddItem

```csharp
void AddItem(sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

##### AddItem

```csharp
void AddItem(byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

##### AddItem

```csharp
void AddItem(int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### AddItem

```csharp
void AddItem(uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

##### AddItem

```csharp
void AddItem(long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

##### AddItem

```csharp
void AddItem(ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

##### AddItem

```csharp
void AddItem(short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

##### AddItem

```csharp
void AddItem(ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

##### AddItem

```csharp
void AddItem(float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

##### AddItem

```csharp
void AddItem(double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

##### AddItem

```csharp
void AddItem(decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

##### AddItem

```csharp
void AddItem(ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

##### AddItem

```csharp
void AddItem(ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

##### AddItem

```csharp
void AddItem(Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

##### AddItem

```csharp
void AddItem(UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

##### AddItem

```csharp
void AddItem(Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRange

```csharp
void AddRange(ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

#### Nested Types

#### JsonElement.ArrayBuilder.Build (delegate)

```csharp
public delegate JsonElement.ArrayBuilder.Build : MulticastDelegate, ICloneable, ISerializable
```

##### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

##### Constructors

###### JsonElement.ArrayBuilder.Build

```csharp
JsonElement.ArrayBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref JsonElement.ArrayBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref JsonElement.ArrayBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonElement.ArrayBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

#### JsonElement.ArrayBuilder.Build<T> (delegate)

```csharp
public delegate JsonElement.ArrayBuilder.Build<T> : MulticastDelegate, ICloneable, ISerializable
```

##### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

##### Constructors

###### JsonElement.ArrayBuilder.Build

```csharp
JsonElement.ArrayBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref T context, ref JsonElement.ArrayBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T context, ref JsonElement.ArrayBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref T context, ref JsonElement.ArrayBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ArrayBuilder` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

---

### JsonElement.JsonSchema (class)

```csharp
public static class JsonElement.JsonSchema
```

#### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElement.JsonSchema**

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `SchemaLocationUtf8` `static` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

#### Methods

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext<TContext>(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, TContext providerContext, JsonSchemaPathProvider<TContext> schemaEvaluationPath, JsonSchemaPathProvider<TContext> documentEvaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `providerContext` | `TContext` |  |
| `schemaEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |
| `documentEvaluationPath` | [`JsonSchemaPathProvider<TContext>`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContext `static`

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, int itemIndex, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### PushChildContextUnescaped `static`

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

**Returns:** [`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

##### Evaluate `static`

```csharp
void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |

##### Evaluate `static`

```csharp
bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Fields

| Field | Type | Description |
|-------|------|-------------|
| `SchemaLocationProvider` `static` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  |
| `SchemaLocation` `static` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

### JsonElement.Mutable (struct)

```csharp
public readonly struct JsonElement.Mutable : IMutableJsonElement<JsonElement.Mutable>, IJsonElement<JsonElement.Mutable>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

#### Implements

[`IMutableJsonElement<JsonElement.Mutable>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`IJsonElement<JsonElement.Mutable>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable)

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ValueKind` | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |
| `Item` | `JsonElement.Mutable` |  |

#### Methods

##### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### Equals

```csharp
bool Equals<T>(T other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### CreateBuilder

```csharp
JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |

**Returns:** [`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

##### From `static`

```csharp
JsonElement.Mutable From<T>(ref T instance)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` |  |

**Returns:** `JsonElement.Mutable`

##### GetArrayLength

```csharp
int GetArrayLength()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

##### GetPropertyCount

```csharp
int GetPropertyCount()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** `JsonElement.Mutable`

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** `JsonElement.Mutable`

##### GetProperty

```csharp
JsonElement.Mutable GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** `JsonElement.Mutable`

##### TryGetProperty

```csharp
bool TryGetProperty(string propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### TryGetProperty

```csharp
bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetBoolean

```csharp
bool GetBoolean()
```

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetString

```csharp
string GetString()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetUtf8String

```csharp
UnescapedUtf8JsonString GetUtf8String()
```

**Returns:** [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

##### GetUtf16String

```csharp
UnescapedUtf16JsonString GetUtf16String()
```

**Returns:** [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

##### TryGetBytesFromBase64

```csharp
bool TryGetBytesFromBase64(ref byte[] value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetBytesFromBase64

```csharp
byte[] GetBytesFromBase64()
```

**Returns:** [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte)

##### TryGetSByte

```csharp
bool TryGetSByte(ref sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetSByte

```csharp
sbyte GetSByte()
```

**Returns:** [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte)

##### TryGetByte

```csharp
bool TryGetByte(ref byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetByte

```csharp
byte GetByte()
```

**Returns:** [`byte`](https://learn.microsoft.com/dotnet/api/system.byte)

##### TryGetInt16

```csharp
bool TryGetInt16(ref short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetInt16

```csharp
short GetInt16()
```

**Returns:** [`short`](https://learn.microsoft.com/dotnet/api/system.int16)

##### TryGetUInt16

```csharp
bool TryGetUInt16(ref ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetUInt16

```csharp
ushort GetUInt16()
```

**Returns:** [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16)

##### TryGetInt32

```csharp
bool TryGetInt32(ref int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetInt32

```csharp
int GetInt32()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

##### TryGetUInt32

```csharp
bool TryGetUInt32(ref uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetUInt32

```csharp
uint GetUInt32()
```

**Returns:** [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32)

##### TryGetInt64

```csharp
bool TryGetInt64(ref long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetInt64

```csharp
long GetInt64()
```

**Returns:** [`long`](https://learn.microsoft.com/dotnet/api/system.int64)

##### TryGetUInt64

```csharp
bool TryGetUInt64(ref ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetUInt64

```csharp
ulong GetUInt64()
```

**Returns:** [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64)

##### TryGetDouble

```csharp
bool TryGetDouble(ref double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetDouble

```csharp
double GetDouble()
```

**Returns:** [`double`](https://learn.microsoft.com/dotnet/api/system.double)

##### TryGetSingle

```csharp
bool TryGetSingle(ref float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetSingle

```csharp
float GetSingle()
```

**Returns:** [`float`](https://learn.microsoft.com/dotnet/api/system.single)

##### TryGetDecimal

```csharp
bool TryGetDecimal(ref decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetDecimal

```csharp
decimal GetDecimal()
```

**Returns:** [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal)

##### TryGetInt128

```csharp
bool TryGetInt128(ref Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetInt128

```csharp
Int128 GetInt128()
```

**Returns:** [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128)

##### TryGetUInt128

```csharp
bool TryGetUInt128(ref UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetUInt128

```csharp
UInt128 GetUInt128()
```

**Returns:** [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128)

##### TryGetHalf

```csharp
bool TryGetHalf(ref Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetHalf

```csharp
Half GetHalf()
```

**Returns:** [`Half`](https://learn.microsoft.com/dotnet/api/system.half)

##### TryGetBigNumber

```csharp
bool TryGetBigNumber(ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetBigNumber

```csharp
BigNumber GetBigNumber()
```

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

##### TryGetBigInteger

```csharp
bool TryGetBigInteger(ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetBigInteger

```csharp
BigInteger GetBigInteger()
```

**Returns:** [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger)

##### TryGetLocalDate

```csharp
bool TryGetLocalDate(ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetLocalDate

```csharp
LocalDate GetLocalDate()
```

**Returns:** `LocalDate`

##### TryGetOffsetTime

```csharp
bool TryGetOffsetTime(ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetOffsetTime

```csharp
OffsetTime GetOffsetTime()
```

**Returns:** `OffsetTime`

##### TryGetOffsetDateTime

```csharp
bool TryGetOffsetDateTime(ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetOffsetDateTime

```csharp
OffsetDateTime GetOffsetDateTime()
```

**Returns:** `OffsetDateTime`

##### TryGetOffsetDate

```csharp
bool TryGetOffsetDate(ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetOffsetDate

```csharp
OffsetDate GetOffsetDate()
```

**Returns:** `OffsetDate`

##### TryGetPeriod

```csharp
bool TryGetPeriod(ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetPeriod

```csharp
Period GetPeriod()
```

**Returns:** [`Period`](/api/corvus-text-json-period.html)

##### TryGetDateTime

```csharp
bool TryGetDateTime(ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetDateTime

```csharp
DateTime GetDateTime()
```

**Returns:** [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime)

##### TryGetDateTimeOffset

```csharp
bool TryGetDateTimeOffset(ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetDateTimeOffset

```csharp
DateTimeOffset GetDateTimeOffset()
```

**Returns:** [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

##### TryGetGuid

```csharp
bool TryGetGuid(ref Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetGuid

```csharp
Guid GetGuid()
```

**Returns:** [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid)

##### GetRawText

```csharp
string GetRawText()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### EnsurePropertyMap `static`

```csharp
void EnsurePropertyMap(ref JsonElement.Mutable element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `ref JsonElement.Mutable` |  |

##### ValueEquals

```csharp
bool ValueEquals(string text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### ValueEquals

```csharp
bool ValueEquals(ReadOnlySpan<char> text)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) |  |

##### EnumerateArray

```csharp
ArrayEnumerator<JsonElement.Mutable> EnumerateArray()
```

**Returns:** [`ArrayEnumerator<JsonElement.Mutable>`](/api/corvus-text-json-arrayenumerator-titem.html)

##### EnumerateObject

```csharp
ObjectEnumerator<JsonElement.Mutable> EnumerateObject()
```

**Returns:** [`ObjectEnumerator<JsonElement.Mutable>`](/api/corvus-text-json-objectenumerator-tvalue.html)

##### ToString `virtual`

```csharp
string ToString()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

##### ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### TryFormat

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### Clone

```csharp
JsonElement Clone()
```

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

##### SetProperty

```csharp
void SetProperty(string propertyName, ref JsonElement.Source source)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `source` | `ref JsonElement.Source` |  |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetPropertyNull

```csharp
void SetPropertyNull(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

##### SetPropertyNull

```csharp
void SetPropertyNull(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### SetPropertyNull

```csharp
void SetPropertyNull(ReadOnlySpan<byte> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### RemoveProperty

```csharp
bool RemoveProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### RemoveProperty

```csharp
bool RemoveProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### RemoveProperty

```csharp
bool RemoveProperty(ReadOnlySpan<byte> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### SetItem

```csharp
void SetItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### SetItemNull

```csharp
void SetItemNull(int itemIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### InsertItem

```csharp
void InsertItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### InsertItem

```csharp
void InsertItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### InsertItem

```csharp
void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### InsertItem

```csharp
void InsertItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### InsertItem

```csharp
void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### InsertItemNull

```csharp
void InsertItemNull(int itemIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### AddItem

```csharp
void AddItem(ref JsonElement.Source source, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `source` | `ref JsonElement.Source` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### AddItem

```csharp
void AddItem(JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `objectValue` | `JsonElement.ObjectBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `objectValue` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### AddItem

```csharp
void AddItem(JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arrayValue` | `JsonElement.ArrayBuilder.Build` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `arrayValue` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

##### AddItemNull

```csharp
void AddItemNull()
```

##### RemoveRange

```csharp
void RemoveRange(int startIndex, int count)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### RemoveAt

```csharp
void RemoveAt(int index)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### Remove

```csharp
bool Remove(ref JsonElement item)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### Replace

```csharp
bool Replace(ref JsonElement oldItem, ref JsonElement.Source newItem)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `oldItem` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) |  |
| `newItem` | `ref JsonElement.Source` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### RemoveWhere

```csharp
void RemoveWhere<T>(JsonPredicate<T> predicate)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `predicate` | [`JsonPredicate<T>`](/api/corvus-text-json-jsonpredicate-t.html) |  |

##### RemoveWhere

```csharp
void RemoveWhere(JsonPredicate<JsonElement> predicate)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `predicate` | [`JsonPredicate<JsonElement>`](/api/corvus-text-json-jsonpredicate-t.html) |  |

##### Apply

```csharp
void Apply<T>(ref T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` |  |

##### EvaluateSchema

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  *(optional)* |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

### JsonElement.ObjectBuilder (struct)

```csharp
public readonly struct JsonElement.ObjectBuilder
```

#### Constructors

##### JsonElement.ObjectBuilder

```csharp
JsonElement.ObjectBuilder()
```

#### Methods

##### BuildValue `static`

```csharp
void BuildValue(JsonElement.ObjectBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### BuildValue `static`

```csharp
void BuildValue<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `JsonElement.ObjectBuilder.Build` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `JsonElement.ArrayBuilder.Build` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(string propertyName, string value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, string value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetDateTime` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetDate` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetTime` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref LocalDate` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddFormattedNumber

```csharp
void AddFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddRawString

```csharp
void AddRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `JsonElement.ObjectBuilder.Build` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8String, bool escapeValue, bool valueRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

##### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

##### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetDateTime` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetDate` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref OffsetTime` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref LocalDate` |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

##### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<long> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<int> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<short> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<sbyte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ulong> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<uint> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ushort> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<decimal> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<double> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<float> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Int128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<UInt128> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Half> array)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<char> propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

##### RemoveProperty

```csharp
void RemoveProperty(string propertyName)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

##### TryApply

```csharp
bool TryApply<TApplicator>(ref TApplicator value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref TApplicator` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

#### Nested Types

#### JsonElement.ObjectBuilder.Build (delegate)

```csharp
public delegate JsonElement.ObjectBuilder.Build : MulticastDelegate, ICloneable, ISerializable
```

##### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

##### Constructors

###### JsonElement.ObjectBuilder.Build

```csharp
JsonElement.ObjectBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref JsonElement.ObjectBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref JsonElement.ObjectBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonElement.ObjectBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

#### JsonElement.ObjectBuilder.Build<T> (delegate)

```csharp
public delegate JsonElement.ObjectBuilder.Build<T> : MulticastDelegate, ICloneable, ISerializable
```

##### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

##### Constructors

###### JsonElement.ObjectBuilder.Build

```csharp
JsonElement.ObjectBuilder.Build(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

##### Methods

###### Invoke `virtual`

```csharp
void Invoke(ref T context, ref JsonElement.ObjectBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |

###### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T context, ref JsonElement.ObjectBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

###### EndInvoke `virtual`

```csharp
void EndInvoke(ref T context, ref JsonElement.ObjectBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref T` |  |
| `builder` | `ref JsonElement.ObjectBuilder` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

---

### JsonElement.Source (struct)

```csharp
public readonly struct JsonElement.Source
```

#### Constructors

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.ArrayBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ArrayBuilder.Build` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.ObjectBuilder.Build value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `JsonElement.ObjectBuilder.Build` |  |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsUndefined` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

#### Methods

##### Null `static`

```csharp
JsonElement.Source Null()
```

**Returns:** `JsonElement.Source`

##### RawString `static`

```csharp
JsonElement.Source RawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

**Returns:** `JsonElement.Source`

##### FormattedNumber `static`

```csharp
JsonElement.Source FormattedNumber(ReadOnlySpan<byte> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

**Returns:** `JsonElement.Source`

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddAsProperty

```csharp
void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddAsItem

```csharp
void AddAsItem(ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

### JsonElement.Source<TContext> (struct)

```csharp
public readonly struct JsonElement.Source<TContext>
```

#### Constructors

##### JsonElement.Source

```csharp
JsonElement.Source(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ArrayBuilder.Build<TContext>` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | `JsonElement.ObjectBuilder.Build<TContext>` |  |

##### JsonElement.Source

```csharp
JsonElement.Source(JsonElement.Source source)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `source` | `JsonElement.Source` |  |

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsUndefined` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

#### Methods

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

##### AddAsProperty

```csharp
void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### AddAsItem

```csharp
void AddAsItem(ref ComplexValueBuilder valueBuilder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

