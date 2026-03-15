---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument — Corvus.Text.Json.Internal"
---
```csharp
public interface IJsonDocument : IDisposable
```

The interface explicitly implemented by JSON Document providers for internal use only.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Implemented By

[`FixedStringJsonDocument<T>`](/api/corvus-text-json-internal-fixedstringjsondocument-t.html), [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html), [`JsonDocumentBuilder<T>`](/api/corvus-text-json-jsondocumentbuilder-t.html), [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsDisposable` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the document is disposable. |
| `IsImmutable` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the document is immutable. |

## Methods

### EnsurePropertyMap `abstract`

```csharp
void EnsurePropertyMap(int index)
```

Ensures the property map is available for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### GetHashCode `abstract`

```csharp
int GetHashCode(int index)
```

Gets the hash code for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The hash code.

### ToString `abstract`

```csharp
string ToString(int index)
```

Converts the element at the specified index to a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The string representation of the element.

### GetJsonTokenType `abstract`

```csharp
JsonTokenType GetJsonTokenType(int index)
```

Gets the JSON token type for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html)

The JSON token type.

### GetArrayIndexElement `abstract`

```csharp
JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

The JSON element.

### GetArrayIndexElement `abstract`

```csharp
TElement GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex)
```

Gets the element at the specified array index within the current index.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

**Returns:** `TElement`

The JSON element.

### GetArrayIndexElement `abstract`

```csharp
void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IJsonDocument parentDocument, ref int parentDocumentIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |
| `parentDocument` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | Produces the parent document of the result. |
| `parentDocumentIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | Produces the parent document index. |

### GetArrayInsertionIndex `abstract`

```csharp
int GetArrayInsertionIndex(int currentIndex, int arrayIndex)
```

Gets DB index of the item at the array index within the array that starts at `currentIndex`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

Note that this is the DB index in the current document. Contrast with [`GetArrayIndexElement`](/api/corvus-text-json-internal-ijsondocument.html) overloads which return the document and index of the actual element value.

### GetArrayLength `abstract`

```csharp
int GetArrayLength(int index)
```

Gets the length of the array at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the array. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The length of the array.

### GetPropertyCount `abstract`

```csharp
int GetPropertyCount(int index)
```

Gets the number of properties for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of properties.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement value)
```

Tries to get the value of a named property as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | The value of the property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement value)
```

Tries to get the value of a named property as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | The value of the property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, ref TElement value)
```

Tries to get the value of a named property as a JSON element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<char> propertyName, ref TElement value)
```

Tries to get the value of a named property as a JSON element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

Tries to get the value of a named property as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `elementParent` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the retrieved value. |
| `elementIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the retrieved value in the parent document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

Tries to get the value of a named property as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `elementParent` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the retrieved value. |
| `elementIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the retrieved value in the parent document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

### GetString `abstract`

```csharp
string GetString(int index, JsonTokenType expectedType)
```

Gets the string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The string value.

### TryGetString `abstract`

```csharp
bool TryGetString(int index, JsonTokenType expectedType, ref string result)
```

Tries to get the string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | The string value, or `null` if the value was not retrieved. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### GetUtf8JsonString `abstract`

```csharp
UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType)
```

Gets the UTF-8 JSON string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |

**Returns:** [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The UTF-8 JSON string value.

You are permitted to pass [`None`](/api/corvus-text-json-internal-jsontokentype.html) as the `expectedType` which will check both String and PropertyName as valid types.

### GetUtf16JsonString `abstract`

```csharp
UnescapedUtf16JsonString GetUtf16JsonString(int index, JsonTokenType expectedType)
```

Gets the UTF-16 JSON string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |

**Returns:** [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

The UTF-16 JSON string value.

You are permitted to pass [`None`](/api/corvus-text-json-internal-jsontokentype.html) as the `expectedType` which will check both String and PropertyName as valid types.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte[] value)
```

Tries to get the value of the element at the specified index as a byte array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The byte array value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref sbyte value)
```

Tries to get the value of the element at the specified index as an `SByte`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte value)
```

Tries to get the value of the element at the specified index as a `Byte`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref short value)
```

Tries to get the value of the element at the specified index as a `Int16`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ushort value)
```

Tries to get the value of the element at the specified index as a `UInt16`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref int value)
```

Tries to get the value of the element at the specified index as an `Int32`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref uint value)
```

Tries to get the value of the element at the specified index as a `UInt32`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref long value)
```

Tries to get the value of the element at the specified index as a `Int64`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ulong value)
```

Tries to get the value of the element at the specified index as a `UInt64`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref double value)
```

Tries to get the value of the element at the specified index as a `Double`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref float value)
```

Tries to get the value of the element at the specified index as a `Single`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref decimal value)
```

Tries to get the value of the element at the specified index as a `Decimal`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigInteger value)
```

Tries to get the value of the element at the specified index as a `BigInteger`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigNumber value)
```

Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTime value)
```

Tries to get the value of the element at the specified index as a `DateTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTimeOffset value)
```

Tries to get the value of the element at the specified index as a `DateTimeOffset`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDateTime value)
```

Tries to get the value of the element at the specified index as an `OffsetDateTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDate value)
```

Tries to get the value of the element at the specified index as an `OffsetDate`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref OffsetDate` | The `OffsetDate` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetTime value)
```

Tries to get the value of the element at the specified index as an `OffsetTime`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref OffsetTime` | The `OffsetTime` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref LocalDate value)
```

Tries to get the value of the element at the specified index as a `LocalDate`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref LocalDate` | The `LocalDate` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Period value)
```

Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Guid value)
```

Tries to get the value of the element at the specified index as a `Guid`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Int128 value)
```

Tries to get the value of the element at the specified index as an `Int128`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref UInt128 value)
```

Tries to get the value of the element at the specified index as a `UInt128`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Half value)
```

Tries to get the value of the element at the specified index as a `Half`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateOnly value)
```

Tries to get the value of the element at the specified index as a `DateOnly`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly) | The `DateOnly` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref TimeOnly value)
```

Tries to get the value of the element at the specified index as a `TimeOnly`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly) | The `TimeOnly` value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

### GetNameOfPropertyValue `abstract`

```csharp
string GetNameOfPropertyValue(int index)
```

Gets the name of the property value at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The name of the property value.

### GetPropertyNameRaw `abstract`

```csharp
ReadOnlySpan<byte> GetPropertyNameRaw(int index)
```

Gets the raw property name as a byte span for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The raw property name as a byte span.

### GetPropertyNameRaw `abstract`

```csharp
ReadOnlyMemory<byte> GetPropertyNameRaw(int index, bool includeQuotes)
```

Gets the raw property name as a byte span for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw property name. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw property name as a byte span.

### GetPropertyName `abstract`

```csharp
JsonElement GetPropertyName(int index)
```

Gets the property name as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

The raw property name as a byte span.

### GetPropertyNameUnescaped `abstract`

```csharp
UnescapedUtf8JsonString GetPropertyNameUnescaped(int index)
```

Gets the property name as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

**Returns:** [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The unescaped property name.

### GetRawValueAsString `abstract`

```csharp
string GetRawValueAsString(int index)
```

Gets the raw value of the element at the specified index as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The raw value as a string.

### GetPropertyRawValueAsString `abstract`

```csharp
string GetPropertyRawValueAsString(int valueIndex)
```

Gets the raw value of the property at the specified index as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property value. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The raw value as a string.

### GetRawValue `abstract`

```csharp
RawUtf8JsonString GetRawValue(int index, bool includeQuotes)
```

Gets the raw value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw value. |

**Returns:** [`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html)

The raw value.

### GetRawSimpleValue `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes)
```

Gets the raw simple value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw value. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

### GetRawSimpleValue `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index)
```

Gets the raw simple value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

### GetRawSimpleValueUnsafe `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index)
```

Gets the raw simple value of the element at the specified index, without checking if the document has been disposed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

### ValueIsEscaped `abstract`

```csharp
bool ValueIsEscaped(int index, bool isPropertyName)
```

Determines whether the value at the specified index is escaped.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value is a property name. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is escaped; otherwise, `false`.

### TextEquals `abstract`

```csharp
bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
```

Determines whether the text at the specified index equals the specified text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the text. |
| `otherText` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text is a property name. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the text equals the specified text; otherwise, `false`.

### TextEquals `abstract`

```csharp
bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
```

Determines whether the UTF-8 text at the specified index equals the specified text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the text. |
| `otherUtf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 text to compare. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text is a property name. |
| `shouldUnescape` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the text should be unescaped. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the text equals the specified text; otherwise, `false`.

### WriteElementTo `abstract`

```csharp
void WriteElementTo(int index, Utf8JsonWriter writer)
```

Writes the element at the specified index to the provided JSON writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The JSON writer. |

### WritePropertyName `abstract`

```csharp
void WritePropertyName(int index, Utf8JsonWriter writer)
```

Writes the property name at the specified index to the provided JSON writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property name. |
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The JSON writer. |

### CloneElement `abstract`

```csharp
JsonElement CloneElement(int index)
```

Clones the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

The cloned JSON element.

### CloneElement `abstract`

```csharp
TElement CloneElement<TElement>(int index)
```

Clones the element at the specified index.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

**Returns:** `TElement`

The cloned JSON element.

### GetDbSize `abstract`

```csharp
int GetDbSize(int index, bool includeEndElement)
```

Gets the size of the database for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeEndElement` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include the end element in the size. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The size of the database.

### GetStartIndex `abstract`

```csharp
int GetStartIndex(int endIndex)
```

Gets the start index of the element from the end index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the element. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The start index of the element.

### BuildRentedMetadataDb `abstract`

```csharp
int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[] rentedBacking)
```

Builds a rented metadata database for the specified parent document index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the parent document. |
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace. |
| `rentedBacking` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The rented backing array. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The size of the metadata database.

### AppendElementToMetadataDb `abstract`

```csharp
void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db)
```

Appends the element at the specified index to the metadata database.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace. |
| `db` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The metadata database. |

### TryResolveJsonPointer `abstract`

```csharp
bool TryResolveJsonPointer<TValue>(ReadOnlySpan<byte> jsonPointer, int index, ref TValue value)
```

Try to resolve the given JSON pointer.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the target value. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON pointer to resolve. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref TValue` | Providers the resolved value, if the pointer could be resolved. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer could be resolved, otherwise `false`.

### TryFormat `abstract`

```csharp
bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

Formats the value to the provided destination span according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span to write the formatted value to. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written to the destination span. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the formatting was successful; otherwise, `false`.

### TryFormat `abstract`

```csharp
bool TryFormat(int index, Span<byte> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

Formats the value to the provided destination UTF-8 span according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span to write the UTF-8 formatted value to. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the formatting was successful; otherwise, `false`.

### ToString `abstract`

```csharp
string ToString(int index, string format, IFormatProvider formatProvider)
```

Gets the display string representation of the element at the specified index according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

The display string representation of the element.

### TryGetLineAndOffset `abstract`

```csharp
bool TryGetLineAndOffset(int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

Tries to get the line number and character offset in the original source document for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

### TryGetLineAndOffsetForPointer `abstract`

```csharp
bool TryGetLineAndOffsetForPointer(ReadOnlySpan<byte> jsonPointer, int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON pointer to resolve. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element at the root of the pointer resolution. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer was resolved and the line and offset were successfully determined; otherwise, `false`.

### TryGetLine `abstract`

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

### TryGetLine `abstract`

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

