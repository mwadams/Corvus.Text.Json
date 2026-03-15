---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument — Corvus.Text.Json.Internal"
---
```csharp
public interface IMutableJsonDocument : IJsonDocument, IDisposable
```

Represents a mutable JSON document that supports editing and value storage operations.

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Implemented By

[`JsonDocumentBuilder<T>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Version` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | Gets the version of the document. |
| `ParentWorkspaceIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the index of the parent workspace. |
| `Workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | Gets the JSON workspace associated with this document. |

## Methods

### GetArrayIndexElement `abstract`

```csharp
JsonElement.Mutable GetArrayIndexElement(int currentIndex, int arrayIndex)
```

Gets the array element at the specified index as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index in the document. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index within the array. |

**Returns:** `JsonElement.Mutable`

The mutable JSON element at the specified array index.

### GetArrayIndexElement `abstract`

```csharp
void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IMutableJsonDocument parentDocument, ref int parentDocumentIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |
| `parentDocument` | [`ref IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) | Produces the parent document of the result. |
| `parentDocumentIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | Produces the parent document index. |

### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(ref MetadataDb parsedData, int startIndex, int endIndex, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parsedData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The parsed data. This is used in place of the document's own MetadataDb. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the first property name. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the last property value. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name to look up. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<char> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name to look up. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a UTF-8 byte span. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### StoreRawNumberValue `abstract`

```csharp
int StoreRawNumberValue(ReadOnlySpan<byte> value)
```

Stores a raw number value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw number value as a UTF-8 byte span. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreNullValue `abstract`

```csharp
int StoreNullValue()
```

Stores a null value in the document.

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreBooleanValue `abstract`

```csharp
int StoreBooleanValue(bool value)
```

Stores a boolean value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### EscapeAndStoreRawStringValue `abstract`

```csharp
int EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string value to escape and store. |
| `requiredEscaping` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Set to `true` if escaping was required. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### EscapeAndStoreRawStringValue `abstract`

```csharp
int EscapeAndStoreRawStringValue(ReadOnlySpan<byte> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 string value to escape and store. |
| `requiredEscaping` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Set to `true` if escaping was required. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreRawStringValue `abstract`

```csharp
int StoreRawStringValue(ReadOnlySpan<byte> value)
```

Stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 string value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(Guid value)
```

Stores a `Guid` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref DateTime value)
```

Stores a `DateTime` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref DateTimeOffset value)
```

Stores a `DateTimeOffset` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDateTime value)
```

Stores an `OffsetDateTime` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDate value)
```

Stores an `OffsetDate` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The `OffsetDate` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetTime value)
```

Stores an `OffsetTime` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The `OffsetTime` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref LocalDate value)
```

Stores a `LocalDate` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The `LocalDate` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref Period value)
```

Stores a [`Period`](/api/corvus-text-json-period.html) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(sbyte value)
```

Stores an `SByte` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(byte value)
```

Stores a `Byte` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(int value)
```

Stores an `Int32` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(uint value)
```

Stores a `UInt32` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(long value)
```

Stores a `Int64` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ulong value)
```

Stores a `UInt64` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(short value)
```

Stores a `Int16` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ushort value)
```

Stores a `UInt16` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(float value)
```

Stores a `Single` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(double value)
```

Stores a `Double` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(decimal value)
```

Stores a `Decimal` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref BigInteger value)
```

Stores a `BigInteger` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(ref BigNumber value)
```

Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(Int128 value)
```

Stores an `Int128` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(UInt128 value)
```

Stores a `UInt128` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### StoreValue `abstract`

```csharp
int StoreValue(Half value)
```

Stores a `Half` value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value to store. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

### RemoveRange `abstract`

```csharp
void RemoveRange(int complexObjectStartIndex, int startIndex, int endIndex, int membersToRemove)
```

Removes a range of values from the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to remove. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to remove. |
| `membersToRemove` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to remove. |

This is similar to [`OverwriteAndDispose`](/api/corvus-text-json-internal-imutablejsondocument.html), but it does not replace the values that are removed. Instead, it simply removes the specified range of members from the document, effectively shifting subsequent members up.

### SetAndDispose `abstract`

```csharp
void SetAndDispose(ref ComplexValueBuilder cvb)
```

Sets the value of the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to set and dispose. |

### InsertAndDispose `abstract`

```csharp
void InsertAndDispose(int complexObjectStartIndex, int index, ref ComplexValueBuilder cvb)
```

Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index at which to insert. |
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to insert and dispose. |

### OverwriteAndDispose `abstract`

```csharp
void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int membersToOverwrite, ref ComplexValueBuilder cvb)
```

Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to overwrite. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to overwrite. |
| `membersToOverwrite` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to overwrite. |
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to overwrite and dispose. |

