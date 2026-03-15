---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct ComplexValueBuilder
```

Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html).

## Remarks

[`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) is a ref struct designed for use in stack-based scenarios, enabling efficient construction of JSON objects and arrays by directly manipulating the underlying metadata database. This builder supports adding properties and items of various types, including primitives, strings, numbers, booleans, nulls, and complex/nested values. It also provides methods for starting and ending JSON objects and arrays, as well as for integrating with [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) for document mutation. Typical usage involves creating a builder via [`Create`](/api/corvus-text-json-internal-complexvaluebuilder.html), using [`AddProperty`](/api/corvus-text-json-internal-complexvaluebuilder.html) and [`AddItem`](/api/corvus-text-json-internal-complexvaluebuilder.html) methods to populate the structure, and then finalizing with [`EndObject`](/api/corvus-text-json-internal-complexvaluebuilder.html) or [`EndArray`](/api/corvus-text-json-internal-complexvaluebuilder.html). This type is not thread-safe and must not be stored on the heap.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `MemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of members (properties or items) added to the current object or array. |

## Methods

### Create `static`

```csharp
ComplexValueBuilder Create(IMutableJsonDocument parentDocument, int initialElementCount)
```

Creates a new [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) for the specified parent document, pre-allocating space for the given number of elements.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) | The parent [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) to build into. |
| `initialElementCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of elements to allocate space for. |

**Returns:** [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html)

A new [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) instance.

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
```

Adds a property with a string value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Adds a property with a string value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool escapeValue, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping the value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(string propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-16 span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

### AddPropertyRawString

```csharp
void AddPropertyRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a raw string value to the current object, with control over escaping and unescaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

### AddPropertyRawString

```csharp
void AddPropertyRawString(string propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### AddPropertyRawString

```csharp
void AddPropertyRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName)
```

Adds a property with a null value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |

### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a null value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<char> propertyName)
```

Adds a property with a null value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a boolean value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, ref T value)
```

Adds a property with a JSON element value to the current object.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref T` | The JSON element value. |

### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a JSON element value to the current object, with control over escaping.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `T` | The JSON element value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

Adds a property with a JSON element value to the current object.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `T` | The JSON element value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
```

Adds a property with a `Guid` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Guid` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

Adds a property with a `Guid` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value)
```

Adds a property with a `DateTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `DateTime` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

Adds a property with a `DateTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value)
```

Adds a property with a `DateTimeOffset` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `DateTimeOffset` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

Adds a property with a `DateTimeOffset` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value)
```

Adds a property with a `OffsetDateTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `OffsetDateTime` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

Adds a property with a `OffsetDateTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value)
```

Adds a property with a `OffsetTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetTime` | The `OffsetTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `OffsetTime` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetTime` | The `OffsetTime` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

Adds a property with a `OffsetTime` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `ref OffsetTime` | The `OffsetTime` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value)
```

Adds a property with a `OffsetDate` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDate` | The `OffsetDate` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `OffsetDate` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDate` | The `OffsetDate` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

Adds a property with a `OffsetDate` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `ref OffsetDate` | The `OffsetDate` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value)
```

Adds a property with a `LocalDate` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref LocalDate` | The `LocalDate` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `LocalDate` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref LocalDate` | The `LocalDate` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

Adds a property with a `LocalDate` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `ref LocalDate` | The `LocalDate` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value)
```

Adds a property with a `Period` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The `Period` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Period` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The `Period` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

Adds a property with a `Period` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The `Period` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
```

Adds a property with an `SByte` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an `SByte` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

Adds a property with an `SByte` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
```

Adds a property with a `Byte` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Byte` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

Adds a property with a `Byte` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value)
```

Adds a property with an `Int32` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an `Int32` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

Adds a property with an `Int32` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
```

Adds a property with a `UInt32` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `UInt32` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

Adds a property with a `UInt32` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value)
```

Adds a property with a `Int64` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Int64` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

Adds a property with a `Int64` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
```

Adds a property with a `UInt64` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `UInt64` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

Adds a property with a `UInt64` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value)
```

Adds a property with a `Int16` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Int16` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

Adds a property with a `Int16` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
```

Adds a property with a `UInt16` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `UInt16` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

Adds a property with a `UInt16` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value)
```

Adds a property with a `Single` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Single` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

Adds a property with a `Single` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value)
```

Adds a property with a `Double` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Double` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

Adds a property with a `Double` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
```

Adds a property with a `Decimal` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Decimal` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

Adds a property with a `Decimal` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value)
```

Adds a property with a `BigInteger` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `BigInteger` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

Adds a property with a `BigInteger` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
```

Adds a property with an `Int128` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an `Int128` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

Adds a property with an `Int128` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
```

Adds a property with a `UInt128` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `UInt128` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

Adds a property with a `UInt128` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
```

Adds a property with a `Half` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a `Half` value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

Adds a property with a `Half` value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<long> array)
```

Adds a property with an array of `Int64` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int64` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<int> array)
```

Adds a property with an array of `Int32` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int32` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<short> array)
```

Adds a property with an array of `Int16` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int16` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of `SByte` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `SByte` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of `UInt64` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt64` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<uint> array)
```

Adds a property with an array of `UInt32` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt32` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of `UInt16` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt16` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<byte> array)
```

Adds a property with an array of `Byte` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Byte` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of `Decimal` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Decimal` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<double> array)
```

Adds a property with an array of `Double` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Double` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<float> array)
```

Adds a property with an array of `Single` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Single` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of `Int128` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int128` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of `UInt128` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt128` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Half> array)
```

Adds a property with an array of `Half` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Half` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<long> array)
```

Adds a property with an array of `Int64` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int64` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<int> array)
```

Adds a property with an array of `Int32` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int32` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<short> array)
```

Adds a property with an array of `Int16` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int16` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of `SByte` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `SByte` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of `UInt64` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt64` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<uint> array)
```

Adds a property with an array of `UInt32` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt32` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of `UInt16` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt16` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<byte> array)
```

Adds a property with an array of `Byte` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Byte` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of `Decimal` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Decimal` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<double> array)
```

Adds a property with an array of `Double` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Double` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<float> array)
```

Adds a property with an array of `Single` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Single` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of `Int128` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int128` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of `UInt128` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt128` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Half> array)
```

Adds a property with an array of `Half` values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Half` values. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Int64` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int64` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Int32` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int32` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Int16` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int16` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `SByte` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `SByte` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `UInt64` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt64` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `UInt32` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt32` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `UInt16` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt16` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Byte` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Byte` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Decimal` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Decimal` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Double` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Double` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Single` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Single` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Int128` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int128` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `UInt128` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt128` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of `Half` values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Half` values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

Adds an item to the current array as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |

### AddItem

```csharp
void AddItem(string value)
```

Adds an item to the current array as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The item value as a string. |

### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue, bool requiresUnescaping)
```

Adds an item to the current array as a UTF-8 string with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the value. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

### AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

Adds an item to the current array as a character span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a character span. |

### AddItemRawString

```csharp
void AddItemRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

Adds an item to the current array as a raw string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

### AddItem

```csharp
void AddItem(ComplexValueBuilder.ValueBuilderAction createValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `createValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

### AddItem

```csharp
void AddItem<TContext>(ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `createValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

### AddItemNull

```csharp
void AddItemNull()
```

Adds a null item to the current array.

### AddItem

```csharp
void AddItem(bool value)
```

Adds a boolean item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

### AddItemFormattedNumber

```csharp
void AddItemFormattedNumber(ReadOnlySpan<byte> value)
```

Adds a formatted number item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

### AddItem

```csharp
void AddItem<T>(ref T value)
```

Adds a JSON element item to the current array.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The JSON element value. |

### AddItem

```csharp
void AddItem(Guid value)
```

Adds a `Guid` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The `Guid` value. |

### AddItem

```csharp
void AddItem(ref DateTime value)
```

Adds a `DateTime` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The `DateTime` value. |

### AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

Adds a `DateTimeOffset` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The `DateTimeOffset` value. |

### AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

Adds an `OffsetDateTime` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The `OffsetDateTime` value. |

### AddItem

```csharp
void AddItem(ref OffsetDate value)
```

Adds an `OffsetDate` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The `OffsetDate` value. |

### AddItem

```csharp
void AddItem(ref OffsetTime value)
```

Adds an `OffsetTime` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The `OffsetTime` value. |

### AddItem

```csharp
void AddItem(ref LocalDate value)
```

Adds a `LocalDate` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The `LocalDate` value. |

### AddItem

```csharp
void AddItem(ref Period value)
```

Adds a [`Period`](/api/corvus-text-json-period.html) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value. |

### AddItem

```csharp
void AddItem(sbyte value)
```

Adds an `SByte` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The `SByte` value. |

### AddItem

```csharp
void AddItem(byte value)
```

Adds a `Byte` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The `Byte` value. |

### AddItem

```csharp
void AddItem(int value)
```

Adds an `Int32` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The `Int32` value. |

### AddItem

```csharp
void AddItem(uint value)
```

Adds a `UInt32` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The `UInt32` value. |

### AddItem

```csharp
void AddItem(long value)
```

Adds a `Int64` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The `Int64` value. |

### AddItem

```csharp
void AddItem(ulong value)
```

Adds a `UInt64` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The `UInt64` value. |

### AddItem

```csharp
void AddItem(short value)
```

Adds a `Int16` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The `Int16` value. |

### AddItem

```csharp
void AddItem(ushort value)
```

Adds a `UInt16` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The `UInt16` value. |

### AddItem

```csharp
void AddItem(float value)
```

Adds a `Single` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The `Single` value. |

### AddItem

```csharp
void AddItem(double value)
```

Adds a `Double` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The `Double` value. |

### AddItem

```csharp
void AddItem(decimal value)
```

Adds a `Decimal` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The `Decimal` value. |

### AddItem

```csharp
void AddItem(ref BigNumber value)
```

Adds a [`BigNumber`](/api/corvus-numerics-bignumber.html) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

### AddItem

```csharp
void AddItem(ref BigInteger value)
```

Adds a `BigInteger` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The `BigInteger` value. |

### AddItem

```csharp
void AddItem(Int128 value)
```

Adds an `Int128` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The `Int128` value. |

### AddItem

```csharp
void AddItem(UInt128 value)
```

Adds a `UInt128` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The `UInt128` value. |

### AddItem

```csharp
void AddItem(Half value)
```

Adds a `Half` item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The `Half` value. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<long> array)
```

Adds an array of `Int64` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int64` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<int> array)
```

Adds an array of `Int32` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int32` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<short> array)
```

Adds an array of `Int16` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int16` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<sbyte> array)
```

Adds an array of `SByte` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `SByte` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<ulong> array)
```

Adds an array of `UInt64` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt64` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<uint> array)
```

Adds an array of `UInt32` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt32` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<ushort> array)
```

Adds an array of `UInt16` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt16` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<byte> array)
```

Adds an array of `Byte` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Byte` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<decimal> array)
```

Adds an array of `Decimal` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Decimal` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<double> array)
```

Adds an array of `Double` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Double` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<float> array)
```

Adds an array of `Single` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Single` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<Int128> array)
```

Adds an array of `Int128` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Int128` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<UInt128> array)
```

Adds an array of `UInt128` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `UInt128` values. |

### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<Half> array)
```

Adds an array of `Half` values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of `Half` values. |

### StartObject

```csharp
void StartObject()
```

Starts a new JSON object in the builder.

### StartArray

```csharp
void StartArray()
```

Starts a new JSON array in the builder.

### EndObject

```csharp
void EndObject()
```

Ends the current JSON object, finalizing its structure in the builder.

### RemoveProperty

```csharp
void RemoveProperty(string name)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

### Apply

```csharp
void Apply<T>(ref T value)
```

Apply an object instance value to the document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the `value`. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The value to apply. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if the `value` is not a JSON object. |

The value must be a JSON object. Its properties will be set on the current document, replacing any existing values if present.

### TryApply

```csharp
bool TryApply<T>(ref T value)
```

Tries to apply an object instance value to the document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the `value`. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The value to apply. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was applied.

If the value is a JSON object, its properties (if any) will be set on the current document, replacing any existing values if present, and the method returns `true`. Otherwise, no changes are made, and the method returns `false`.

### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<char> name)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a character span. |

### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<byte> utf8Name, bool escapeName, bool nameRequiresUnescaping)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 name of the property. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the name requires escaping. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If the name does not require escaping, indicates whether the name requires unescaping. |

### EndArray

```csharp
void EndArray()
```

Ends the current JSON array, finalizing its structure in the builder.

### SetAndDispose

```csharp
void SetAndDispose(ref MetadataDb targetData)
```

Transfers the built data to the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The target metadata database to receive the data. |

### InsertAndDispose

```csharp
void InsertAndDispose(int complexObjectStartIndex, int targetIndex, ref MetadataDb targetData)
```

Inserts the built data into the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) at the given index and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object in the target database. |
| `targetIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index at which to insert the data. |
| `targetData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The target metadata database to receive the data. |

### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<byte> stringValue, bool escape, bool ifNotEscapeRequiresUenscaping)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `stringValue` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escape` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether to escape the property name. |
| `ifNotEscapeRequiresUenscaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the property name needs unescaping if it is not to be escaped. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<char> propertyName)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(string propertyName)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

### EndProperty

```csharp
void EndProperty(ref ComplexValueBuilder.ComplexValueHandle handle)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `handle` | `ref ComplexValueBuilder.ComplexValueHandle` |  |

### StartItem

```csharp
ComplexValueBuilder.ComplexValueHandle StartItem()
```

Start an array item.

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

### EndItem

```csharp
void EndItem(ref ComplexValueBuilder.ComplexValueHandle handle)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `handle` | `ref ComplexValueBuilder.ComplexValueHandle` |  |

### OverwriteAndDispose

```csharp
void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, ref MetadataDb targetData)
```

Overwrites a range of data in the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) with the built data and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object in the target database. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to overwrite. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to overwrite. |
| `memberCountToReplace` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to replace. |
| `targetData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The target metadata database to receive the data. |


### ComplexValueBuilder.ComplexValueHandle (struct)

```csharp
public readonly struct ComplexValueBuilder.ComplexValueHandle
```

---

### ComplexValueBuilder.ValueBuilderAction (delegate)

```csharp
public delegate ComplexValueBuilder.ValueBuilderAction : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### ComplexValueBuilder.ValueBuilderAction

```csharp
ComplexValueBuilder.ValueBuilderAction(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(ref ComplexValueBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref ComplexValueBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref ComplexValueBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

### ComplexValueBuilder.ValueBuilderAction<TContext> (delegate)

```csharp
public delegate ComplexValueBuilder.ValueBuilderAction<TContext> : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### ComplexValueBuilder.ValueBuilderAction

```csharp
ComplexValueBuilder.ValueBuilderAction(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(ref TContext context, ref ComplexValueBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TContext context, ref ComplexValueBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref TContext context, ref ComplexValueBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

