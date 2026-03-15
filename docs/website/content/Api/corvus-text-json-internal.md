---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json.Internal Namespace"
---
# Corvus.Text.Json.Internal Namespace

| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator](#arrayenumerator) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [ArrayReverseEnumerator](#arrayreverseenumerator) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [BigIntegerPolyfills](#bigintegerpolyfills) | class | Polyfills for [`BigInteger`](#BigInteger) methods that are not available in all target frameworks. |
| [BuildWithContext](#buildwithcontext) | class |  |
| [BuildWithContext<TContext, TBuilder>](#buildwithcontext-tcontext,-tbuilder) | struct |  |
| [CodeGenDataType](#codegendatatype) | enum | Specifies the data type used in code generation scenarios. |
| [CodeGenNumericType](#codegennumerictype) | enum | Specifies the numeric type used in code generation scenarios. |
| [CodeGenThrowHelper](#codegenthrowhelper) | class | Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json. This class centralizes exception creation and throwing logic to ensure consistent erro... |
| [ComplexValueBuilder](#complexvaluebuilder) | struct | Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an [`IMutableJsonDocument`](#IMutableJsonDocument). |
| [EnumeratorCreator](#enumeratorcreator) | class |  |
| [FixedStringJsonDocument<T>](#fixedstringjsondocument-t) | class | Represents a JSON document based on a fixed string value. |
| [IJsonDocument](#ijsondocument) | interface | The interface explicitly implemented by JSON Document providers for internal use only. |
| [IJsonElement](#ijsonelement) | interface | Implemented by JsonElement-derived types. |
| [IJsonElement<T>](#ijsonelement-t) | interface | Implemented by JsonElement-derived types. |
| [IMutableJsonDocument](#imutablejsondocument) | interface | Represents a mutable JSON document that supports editing and value storage operations. |
| [IMutableJsonElement<T>](#imutablejsonelement-t) | interface | Represents a mutable JSON element of type `T`. |
| [JsonDocument](#jsondocument) | class | Base class for JSON document implementations providing common functionality for parsing and accessing JSON data. |
| [JsonElementHelpers](#jsonelementhelpers) | class | Core helper methods for parsing and processing JSON numeric values into their component parts. |
| [JsonElementTensorHelpers](#jsonelementtensorhelpers) | class | Helper methods for JSON element for conversion to tensors. |
| [JsonRegexOptions](#jsonregexoptions) | enum |  |
| [JsonSchemaContext](#jsonschemacontext) | struct | The context for a JSON schema evaluation. |
| [JsonSchemaEvaluation](#jsonschemaevaluation) | class | Support for JSON Schema matching implementations. |
| [JsonSchemaMatcher](#jsonschemamatcher) | delegate | A matcher for a JSON schema. |
| [JsonSchemaMatcherWithRequiredBitBuffer](#jsonschemamatcherwithrequiredbitbuffer) | delegate | A matcher for a JSON schema that requires a bit buffer for tracking required properties. |
| [JsonTokenType](#jsontokentype) | enum | This enum defines the various JSON tokens that make up a JSON text and is used by the [`Utf8JsonReader`](#Utf8JsonReader) when moving from one token to the next. The [`Utf8JsonReader`](#Utf8JsonRea... |
| [MetadataDb](#metadatadb) | struct | Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements. |
| [NormalizedJsonNumber](#normalizedjsonnumber) | struct | Represents a normalized JSON number. |
| [ObjectEnumerator](#objectenumerator) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [PropertySchemaMatchers<T>](#propertyschemamatchers-t) | class | A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance. |
| [RentedBacking](#rentedbacking) | struct | Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](#SimpleTypesBacking). |
| [SimpleTypesBacking](#simpletypesbacking) | struct | Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](#IJsonElement) creation. |
| [UniqueItemsHashSet](#uniqueitemshashset) | struct | A map that can be built |
| [Utf8UriComponents](#utf8uricomponents) | enum | Specifies the parts of a URI that should be included when retrieving URI components. |
| [Utf8UriFormat](#utf8uriformat) | enum | Specifies the format options for URI string representation. |
| [Utf8UriKind](#utf8urikind) | enum | Defines the kind of URI, controlling whether absolute or relative URIs are used. |

## ArrayEnumerator (struct)

```csharp
public readonly struct ArrayEnumerator
```

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

### Constructors

#### ArrayEnumerator

```csharp
ArrayEnumerator(IJsonDocument targetDocument, int initialIndex)
```

Initializes a new instance of the [`ArrayEnumerator`](#ArrayEnumerator) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | `IJsonDocument` | The document containing the array to enumerate. |
| `initialIndex` | `int` | The initial index of the array element in the document. |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentIndex` | `int` | Gets the current index within the JSON array. |

### Methods

#### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

#### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** `bool`

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

#### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element in the collection.

---

## ArrayReverseEnumerator (struct)

```csharp
public readonly struct ArrayReverseEnumerator
```

Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document.

### Constructors

#### ArrayReverseEnumerator

```csharp
ArrayReverseEnumerator(IJsonDocument targetDocument, int arrayDocumentIndex)
```

Initializes a new instance of the [`ArrayReverseEnumerator`](#ArrayReverseEnumerator) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | `IJsonDocument` | The document containing the array to enumerate. |
| `arrayDocumentIndex` | `int` | The initial index of the array element in the document. |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentIndex` | `int` | Gets the current index within the JSON array. |
| `CurrentEndIndex` | `int` | Gets the current end index of the item within the JSON array. |

### Methods

#### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

#### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** `bool`

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

#### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element in the collection.

---

## BigIntegerPolyfills (class)

```csharp
public static class BigIntegerPolyfills
```

Polyfills for [`BigInteger`](#BigInteger) methods that are not available in all target frameworks.

### Methods

#### TryGetMinimumFormatBufferLength `static`

```csharp
bool TryGetMinimumFormatBufferLength(ref BigInteger bigInteger, ref int minimumLength)
```

Gets the minimum format buffer length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bigInteger` | `ref BigInteger` | The value for which to get the format buffer length. |
| `minimumLength` | `ref int` | The minimum length for a text buffer to format the number. |

**Returns:** `bool`

`true` if the buffer length required for the number can be safely allocated.

#### TryFormat `static`

```csharp
bool TryFormat(ref BigInteger value, Span<byte> destination, ref int bytesWritten)
```

Tries to format the value of the current [`BigInteger`](#BigInteger) instance into the provided span of bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` | The value to format. |
| `destination` | `Span<byte>` | The span in which to write the formatted value as UTF-8. |
| `bytesWritten` | `ref int` | When this method returns, contains the number of bytes that were written to the destination. |

**Returns:** `bool`

`true` if the operation was successful; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> segment, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `segment` | `ReadOnlySpan<byte>` |  |
| `value` | `ref BigInteger` |  |

**Returns:** `bool`

### Nested Types

### BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A (class)

```csharp
public sealed class BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A
```

#### Methods

##### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> segment, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `segment` | `ReadOnlySpan<byte>` |  |
| `value` | `ref BigInteger` |  |

**Returns:** `bool`

#### Nested Types

#### BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A.<M>$AF85D49F289E4CC5D0A674052B53552E (class)

```csharp
public static class BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A.<M>$AF85D49F289E4CC5D0A674052B53552E
```

---

---

---

## BuildWithContext (class)

```csharp
public static class BuildWithContext
```

### Methods

#### Create `static`

```csharp
BuildWithContext<TContext, TBuilder> Create<TContext, TBuilder>(ref TContext context, TBuilder build)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `build` | `TBuilder` |  |

**Returns:** `BuildWithContext<TContext, TBuilder>`

---

## BuildWithContext<TContext, TBuilder> (struct)

```csharp
public readonly struct BuildWithContext<TContext, TBuilder>
```

### Constructors

#### BuildWithContext

```csharp
BuildWithContext(TContext context, TBuilder build)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `build` | `TBuilder` |  |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Context` | `TContext` |  |
| `Build` | `TBuilder` |  |

---

## CodeGenDataType (enum)

```csharp
public enum CodeGenDataType : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the data type used in code generation scenarios.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Boolean` `static` | `CodeGenDataType` | Represents a boolean value. |
| `DateOnly` `static` | `CodeGenDataType` | Represents a date-only value. |
| `DateTime` `static` | `CodeGenDataType` | Represents a date and time value. |
| `DateTimeOffset` `static` | `CodeGenDataType` | Represents a date and time with offset value. |
| `TimeOnly` `static` | `CodeGenDataType` | Represents a time-only value. |
| `TimeSpan` `static` | `CodeGenDataType` | Represents a time span value. |
| `Base64String` `static` | `CodeGenDataType` | Represents a base64-encoded string. |
| `Guid` `static` | `CodeGenDataType` | Represents a GUID value. |
| `Version` `static` | `CodeGenDataType` | Represents a version value. |

---

## CodeGenNumericType (enum)

```csharp
public enum CodeGenNumericType : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the numeric type used in code generation scenarios.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Byte` `static` | `CodeGenNumericType` | Represents an 8-bit unsigned integer. |
| `SByte` `static` | `CodeGenNumericType` | Represents an 8-bit signed integer. |
| `Int16` `static` | `CodeGenNumericType` | Represents a 16-bit signed integer. |
| `Int32` `static` | `CodeGenNumericType` | Represents a 32-bit signed integer. |
| `Int64` `static` | `CodeGenNumericType` | Represents a 64-bit signed integer. |
| `Int128` `static` | `CodeGenNumericType` | Represents a 128-bit signed integer. |
| `UInt16` `static` | `CodeGenNumericType` | Represents a 16-bit unsigned integer. |
| `UInt32` `static` | `CodeGenNumericType` | Represents a 32-bit unsigned integer. |
| `UInt64` `static` | `CodeGenNumericType` | Represents a 64-bit unsigned integer. |
| `UInt128` `static` | `CodeGenNumericType` | Represents a 128-bit unsigned integer. |
| `Half` `static` | `CodeGenNumericType` | Represents a 16-bit floating point number. |
| `Single` `static` | `CodeGenNumericType` | Represents a 32-bit floating point number. |
| `Double` `static` | `CodeGenNumericType` | Represents a 64-bit floating point number. |
| `Decimal` `static` | `CodeGenNumericType` | Represents a 128-bit decimal number. |

---

## CodeGenThrowHelper (class)

```csharp
public static class CodeGenThrowHelper
```

Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json. This class centralizes exception creation and throwing logic to ensure consistent error handling and messaging.

### Methods

#### ThrowArgumentException_ArrayBufferLength `static`

```csharp
void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
```

Throws an [`ArgumentException`](#ArgumentException) when an array buffer has an incorrect length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `paramName` | `string` | The name of the parameter that caused the exception. |
| `expectedLength` | `int` | The expected length of the array buffer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Always thrown. |

#### ThrowFormatException `static`

```csharp
void ThrowFormatException()
```

Throws a generic [`FormatException`](#FormatException) for format-related errors.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Always thrown. |

#### ThrowFormatException `static`

```csharp
void ThrowFormatException(CodeGenNumericType numericType)
```

Throws a [`FormatException`](#FormatException) for numeric type formatting errors.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `numericType` | `CodeGenNumericType` | The numeric type that failed to format. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Always thrown. |

#### ThrowInvalidOperationException_SetRequiredPropertyToUndefined `static`

```csharp
void ThrowInvalidOperationException_SetRequiredPropertyToUndefined(string propertyName)
```

Throws an [`InvalidOperationException`](#InvalidOperationException) when attempting to set a required property to an undefined value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the required property. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Always thrown. |

#### ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst `static`

```csharp
void ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst()
```

Throws an [`InvalidOperationException`](#InvalidOperationException) when attempting to set a required property to an undefined value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | Always thrown. |

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `ExceptionSourceValueToRethrowAsJsonException` `static` | `string` |  |

---

## ComplexValueBuilder (struct)

```csharp
public readonly struct ComplexValueBuilder
```

Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an [`IMutableJsonDocument`](#IMutableJsonDocument).

### Remarks

[`ComplexValueBuilder`](#ComplexValueBuilder) is a ref struct designed for use in stack-based scenarios, enabling efficient construction of JSON objects and arrays by directly manipulating the underlying metadata database. This builder supports adding properties and items of various types, including primitives, strings, numbers, booleans, nulls, and complex/nested values. It also provides methods for starting and ending JSON objects and arrays, as well as for integrating with [`IMutableJsonDocument`](#IMutableJsonDocument) for document mutation. Typical usage involves creating a builder via [`Create`](#Create), using [`AddProperty`](#AddProperty) and [`AddItem`](#AddItem) methods to populate the structure, and then finalizing with [`EndObject`](#EndObject) or [`EndArray`](#EndArray). This type is not thread-safe and must not be stored on the heap.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `MemberCount` | `int` | Gets the number of members (properties or items) added to the current object or array. |

### Methods

#### Create `static`

```csharp
ComplexValueBuilder Create(IMutableJsonDocument parentDocument, int initialElementCount)
```

Creates a new [`ComplexValueBuilder`](#ComplexValueBuilder) for the specified parent document, pre-allocating space for the given number of elements.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IMutableJsonDocument` | The parent [`IMutableJsonDocument`](#IMutableJsonDocument) to build into. |
| `initialElementCount` | `int` | The estimated number of elements to allocate space for. |

**Returns:** `ComplexValueBuilder`

A new [`ComplexValueBuilder`](#ComplexValueBuilder) instance.

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

#### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |
| `escapeName` | `bool` |  |
| `nameRequiresUnescaping` | `bool` |  |

#### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |
| `escapeName` | `bool` |  |
| `nameRequiresUnescaping` | `bool` |  |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

#### AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
```

Adds a property with a string value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `utf8String` | `ReadOnlySpan<byte>` | The property value as a UTF-8 byte span. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `utf8String` | `ReadOnlySpan<byte>` | The property value as a UTF-8 byte span. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `escapeValue` | `bool` | Whether to escape the property value. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | `bool` | Whether the property value requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ReadOnlySpan<char>` | The property value as a character span. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Adds a property with a string value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ReadOnlySpan<char>` | The property value as a character span. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool escapeValue, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping the value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ReadOnlySpan<byte>` | The property value as a UTF-8 byte span. |
| `escapeValue` | `bool` | Whether to escape the property value. |
| `valueRequiresUnescaping` | `bool` | Whether the property value requires unescaping. |

#### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ReadOnlySpan<byte>` | The number value as a UTF-8 byte span. |

#### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ReadOnlySpan<byte>` | The number value as a UTF-8 byte span. |
| `escapeName` | `bool` |  |
| `nameRequiresUnescaping` | `bool` |  |

#### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(string propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The property name as a string. |
| `value` | `ReadOnlySpan<byte>` | The number value as a UTF-8 byte span. |

#### AddPropertyFormattedNumber

```csharp
void AddPropertyFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

Adds a property with a formatted number value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a UTF-16 span. |
| `value` | `ReadOnlySpan<byte>` | The number value as a UTF-8 byte span. |

#### AddPropertyRawString

```csharp
void AddPropertyRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a raw string value to the current object, with control over escaping and unescaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ReadOnlySpan<byte>` | The value as a UTF-8 byte span. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | `bool` | Whether the value requires unescaping. |

#### AddPropertyRawString

```csharp
void AddPropertyRawString(string propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The property name as a string. |
| `value` | `ReadOnlySpan<byte>` | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | `bool` |  |

#### AddPropertyRawString

```csharp
void AddPropertyRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a string. |
| `value` | `ReadOnlySpan<byte>` | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | `bool` |  |

#### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName)
```

Adds a property with a null value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |

#### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a null value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyNull

```csharp
void AddPropertyNull(ReadOnlySpan<char> propertyName)
```

Adds a property with a null value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `bool` | The boolean value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a boolean value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `bool` | The boolean value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `bool` | The boolean value. |

#### AddProperty

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
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref T` | The JSON element value. |

#### AddProperty

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
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `T` | The JSON element value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

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
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `T` | The JSON element value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
```

Adds a property with a [`Guid`](#Guid) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Guid` | The [`Guid`](#Guid) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Guid`](#Guid) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Guid` | The [`Guid`](#Guid) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

Adds a property with a [`Guid`](#Guid) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `Guid` | The [`Guid`](#Guid) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](#DateTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`DateTime`](#DateTime) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](#DateTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](#DateTimeOffset) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`DateTimeOffset`](#DateTimeOffset) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](#DateTimeOffset) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](#OffsetDateTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetDateTime`](#OffsetDateTime) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](#OffsetDateTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](#OffsetTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetTime`](#OffsetTime) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](#OffsetTime) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](#OffsetDate) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetDate`](#OffsetDate) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](#OffsetDate) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](#LocalDate) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`LocalDate`](#LocalDate) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](#LocalDate) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value)
```

Adds a property with a [`Period`](#Period) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref Period` | The [`Period`](#Period) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Period`](#Period) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref Period` | The [`Period`](#Period) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

Adds a property with a [`Period`](#Period) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref Period` | The [`Period`](#Period) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
```

Adds a property with an [`SByte`](#SByte) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `sbyte` | The [`SByte`](#SByte) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`SByte`](#SByte) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `sbyte` | The [`SByte`](#SByte) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

Adds a property with an [`SByte`](#SByte) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `sbyte` | The [`SByte`](#SByte) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
```

Adds a property with a [`Byte`](#Byte) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `byte` | The [`Byte`](#Byte) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Byte`](#Byte) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `byte` | The [`Byte`](#Byte) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

Adds a property with a [`Byte`](#Byte) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `byte` | The [`Byte`](#Byte) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value)
```

Adds a property with an [`Int32`](#Int32) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `int` | The [`Int32`](#Int32) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`Int32`](#Int32) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `int` | The [`Int32`](#Int32) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

Adds a property with an [`Int32`](#Int32) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `int` | The [`Int32`](#Int32) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
```

Adds a property with a [`UInt32`](#UInt32) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `uint` | The [`UInt32`](#UInt32) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt32`](#UInt32) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `uint` | The [`UInt32`](#UInt32) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

Adds a property with a [`UInt32`](#UInt32) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `uint` | The [`UInt32`](#UInt32) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value)
```

Adds a property with a [`Int64`](#Int64) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `long` | The [`Int64`](#Int64) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Int64`](#Int64) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `long` | The [`Int64`](#Int64) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

Adds a property with a [`Int64`](#Int64) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `long` | The [`Int64`](#Int64) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
```

Adds a property with a [`UInt64`](#UInt64) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ulong` | The [`UInt64`](#UInt64) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt64`](#UInt64) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ulong` | The [`UInt64`](#UInt64) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

Adds a property with a [`UInt64`](#UInt64) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ulong` | The [`UInt64`](#UInt64) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value)
```

Adds a property with a [`Int16`](#Int16) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `short` | The [`Int16`](#Int16) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Int16`](#Int16) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `short` | The [`Int16`](#Int16) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

Adds a property with a [`Int16`](#Int16) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `short` | The [`Int16`](#Int16) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
```

Adds a property with a [`UInt16`](#UInt16) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ushort` | The [`UInt16`](#UInt16) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt16`](#UInt16) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ushort` | The [`UInt16`](#UInt16) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

Adds a property with a [`UInt16`](#UInt16) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ushort` | The [`UInt16`](#UInt16) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value)
```

Adds a property with a [`Single`](#Single) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `float` | The [`Single`](#Single) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Single`](#Single) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `float` | The [`Single`](#Single) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

Adds a property with a [`Single`](#Single) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `float` | The [`Single`](#Single) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value)
```

Adds a property with a [`Double`](#Double) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `double` | The [`Double`](#Double) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Double`](#Double) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `double` | The [`Double`](#Double) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

Adds a property with a [`Double`](#Double) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `double` | The [`Double`](#Double) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
```

Adds a property with a [`Decimal`](#Decimal) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `decimal` | The [`Decimal`](#Decimal) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Decimal`](#Decimal) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `decimal` | The [`Decimal`](#Decimal) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

Adds a property with a [`Decimal`](#Decimal) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `decimal` | The [`Decimal`](#Decimal) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](#BigInteger) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`BigInteger`](#BigInteger) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](#BigInteger) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](#BigNumber) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`BigNumber`](#BigNumber) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](#BigNumber) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
```

Adds a property with an [`Int128`](#Int128) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Int128` | The [`Int128`](#Int128) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`Int128`](#Int128) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Int128` | The [`Int128`](#Int128) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

Adds a property with an [`Int128`](#Int128) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `Int128` | The [`Int128`](#Int128) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](#UInt128) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `UInt128` | The [`UInt128`](#UInt128) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt128`](#UInt128) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `UInt128` | The [`UInt128`](#UInt128) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](#UInt128) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `UInt128` | The [`UInt128`](#UInt128) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
```

Adds a property with a [`Half`](#Half) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Half` | The [`Half`](#Half) value. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Half`](#Half) value to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `value` | `Half` | The [`Half`](#Half) value. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

Adds a property with a [`Half`](#Half) value to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |
| `value` | `Half` | The [`Half`](#Half) value. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<long> array)
```

Adds a property with an array of [`Int64`](#Int64) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<long>` | The array of [`Int64`](#Int64) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<int> array)
```

Adds a property with an array of [`Int32`](#Int32) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<int>` | The array of [`Int32`](#Int32) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<short> array)
```

Adds a property with an array of [`Int16`](#Int16) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<short>` | The array of [`Int16`](#Int16) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of [`SByte`](#SByte) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<sbyte>` | The array of [`SByte`](#SByte) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of [`UInt64`](#UInt64) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<ulong>` | The array of [`UInt64`](#UInt64) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<uint> array)
```

Adds a property with an array of [`UInt32`](#UInt32) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<uint>` | The array of [`UInt32`](#UInt32) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of [`UInt16`](#UInt16) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<ushort>` | The array of [`UInt16`](#UInt16) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<byte> array)
```

Adds a property with an array of [`Byte`](#Byte) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<byte>` | The array of [`Byte`](#Byte) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of [`Decimal`](#Decimal) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<decimal>` | The array of [`Decimal`](#Decimal) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<double> array)
```

Adds a property with an array of [`Double`](#Double) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<double>` | The array of [`Double`](#Double) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<float> array)
```

Adds a property with an array of [`Single`](#Single) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<float>` | The array of [`Single`](#Single) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of [`Int128`](#Int128) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<Int128>` | The array of [`Int128`](#Int128) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of [`UInt128`](#UInt128) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<UInt128>` | The array of [`UInt128`](#UInt128) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Half> array)
```

Adds a property with an array of [`Half`](#Half) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` | The property name. |
| `array` | `ReadOnlySpan<Half>` | The array of [`Half`](#Half) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<long> array)
```

Adds a property with an array of [`Int64`](#Int64) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<long>` | The array of [`Int64`](#Int64) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<int> array)
```

Adds a property with an array of [`Int32`](#Int32) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<int>` | The array of [`Int32`](#Int32) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<short> array)
```

Adds a property with an array of [`Int16`](#Int16) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<short>` | The array of [`Int16`](#Int16) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of [`SByte`](#SByte) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<sbyte>` | The array of [`SByte`](#SByte) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of [`UInt64`](#UInt64) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<ulong>` | The array of [`UInt64`](#UInt64) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<uint> array)
```

Adds a property with an array of [`UInt32`](#UInt32) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<uint>` | The array of [`UInt32`](#UInt32) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of [`UInt16`](#UInt16) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<ushort>` | The array of [`UInt16`](#UInt16) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<byte> array)
```

Adds a property with an array of [`Byte`](#Byte) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<byte>` | The array of [`Byte`](#Byte) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of [`Decimal`](#Decimal) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<decimal>` | The array of [`Decimal`](#Decimal) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<double> array)
```

Adds a property with an array of [`Double`](#Double) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<double>` | The array of [`Double`](#Double) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<float> array)
```

Adds a property with an array of [`Single`](#Single) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<float>` | The array of [`Single`](#Single) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of [`Int128`](#Int128) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<Int128>` | The array of [`Int128`](#Int128) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of [`UInt128`](#UInt128) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<UInt128>` | The array of [`UInt128`](#UInt128) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Half> array)
```

Adds a property with an array of [`Half`](#Half) values to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The property name as a character span. |
| `array` | `ReadOnlySpan<Half>` | The array of [`Half`](#Half) values. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int64`](#Int64) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<long>` | The array of [`Int64`](#Int64) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int32`](#Int32) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<int>` | The array of [`Int32`](#Int32) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int16`](#Int16) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<short>` | The array of [`Int16`](#Int16) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`SByte`](#SByte) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<sbyte>` | The array of [`SByte`](#SByte) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt64`](#UInt64) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<ulong>` | The array of [`UInt64`](#UInt64) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt32`](#UInt32) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<uint>` | The array of [`UInt32`](#UInt32) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt16`](#UInt16) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<ushort>` | The array of [`UInt16`](#UInt16) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Byte`](#Byte) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<byte>` | The array of [`Byte`](#Byte) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Decimal`](#Decimal) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<decimal>` | The array of [`Decimal`](#Decimal) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Double`](#Double) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<double>` | The array of [`Double`](#Double) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Single`](#Single) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<float>` | The array of [`Single`](#Single) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int128`](#Int128) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<Int128>` | The array of [`Int128`](#Int128) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt128`](#UInt128) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<UInt128>` | The array of [`UInt128`](#UInt128) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Half`](#Half) values to the current object, with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The property name as a UTF-8 byte span. |
| `array` | `ReadOnlySpan<Half>` | The array of [`Half`](#Half) values. |
| `escapeName` | `bool` | Whether to escape the property name. |
| `nameRequiresUnescaping` | `bool` | Whether the property name requires unescaping. |

#### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

Adds an item to the current array as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | `ReadOnlySpan<byte>` | The item value as a UTF-8 byte span. |

#### AddItem

```csharp
void AddItem(string value)
```

Adds an item to the current array as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` | The item value as a string. |

#### AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue, bool requiresUnescaping)
```

Adds an item to the current array as a UTF-8 string with control over escaping.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | `ReadOnlySpan<byte>` | The item value as a UTF-8 byte span. |
| `escapeValue` | `bool` | Whether to escape the value. |
| `requiresUnescaping` | `bool` | Whether the value requires unescaping. |

#### AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

Adds an item to the current array as a character span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The item value as a character span. |

#### AddItemRawString

```csharp
void AddItemRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
```

Adds an item to the current array as a raw string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The item value as a UTF-8 byte span. |
| `requiresUnescaping` | `bool` | Whether the value requires unescaping. |

#### AddItem

```csharp
void AddItem(ComplexValueBuilder.ValueBuilderAction createValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `createValue` | `ComplexValueBuilder.ValueBuilderAction` |  |

#### AddItem

```csharp
void AddItem<TContext>(ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createValue)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `createValue` | `ComplexValueBuilder.ValueBuilderAction<TContext>` |  |

#### AddItemNull

```csharp
void AddItemNull()
```

Adds a null item to the current array.

#### AddItem

```csharp
void AddItem(bool value)
```

Adds a boolean item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `bool` | The boolean value. |

#### AddItemFormattedNumber

```csharp
void AddItemFormattedNumber(ReadOnlySpan<byte> value)
```

Adds a formatted number item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The number value as a UTF-8 byte span. |

#### AddItem

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

#### AddItem

```csharp
void AddItem(Guid value)
```

Adds a [`Guid`](#Guid) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Guid` | The [`Guid`](#Guid) value. |

#### AddItem

```csharp
void AddItem(ref DateTime value)
```

Adds a [`DateTime`](#DateTime) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value. |

#### AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

Adds a [`DateTimeOffset`](#DateTimeOffset) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value. |

#### AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

Adds an [`OffsetDateTime`](#OffsetDateTime) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value. |

#### AddItem

```csharp
void AddItem(ref OffsetDate value)
```

Adds an [`OffsetDate`](#OffsetDate) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value. |

#### AddItem

```csharp
void AddItem(ref OffsetTime value)
```

Adds an [`OffsetTime`](#OffsetTime) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value. |

#### AddItem

```csharp
void AddItem(ref LocalDate value)
```

Adds a [`LocalDate`](#LocalDate) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value. |

#### AddItem

```csharp
void AddItem(ref Period value)
```

Adds a [`Period`](#Period) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` | The [`Period`](#Period) value. |

#### AddItem

```csharp
void AddItem(sbyte value)
```

Adds an [`SByte`](#SByte) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `sbyte` | The [`SByte`](#SByte) value. |

#### AddItem

```csharp
void AddItem(byte value)
```

Adds a [`Byte`](#Byte) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `byte` | The [`Byte`](#Byte) value. |

#### AddItem

```csharp
void AddItem(int value)
```

Adds an [`Int32`](#Int32) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` | The [`Int32`](#Int32) value. |

#### AddItem

```csharp
void AddItem(uint value)
```

Adds a [`UInt32`](#UInt32) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `uint` | The [`UInt32`](#UInt32) value. |

#### AddItem

```csharp
void AddItem(long value)
```

Adds a [`Int64`](#Int64) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `long` | The [`Int64`](#Int64) value. |

#### AddItem

```csharp
void AddItem(ulong value)
```

Adds a [`UInt64`](#UInt64) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ulong` | The [`UInt64`](#UInt64) value. |

#### AddItem

```csharp
void AddItem(short value)
```

Adds a [`Int16`](#Int16) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `short` | The [`Int16`](#Int16) value. |

#### AddItem

```csharp
void AddItem(ushort value)
```

Adds a [`UInt16`](#UInt16) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ushort` | The [`UInt16`](#UInt16) value. |

#### AddItem

```csharp
void AddItem(float value)
```

Adds a [`Single`](#Single) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `float` | The [`Single`](#Single) value. |

#### AddItem

```csharp
void AddItem(double value)
```

Adds a [`Double`](#Double) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `double` | The [`Double`](#Double) value. |

#### AddItem

```csharp
void AddItem(decimal value)
```

Adds a [`Decimal`](#Decimal) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `decimal` | The [`Decimal`](#Decimal) value. |

#### AddItem

```csharp
void AddItem(ref BigNumber value)
```

Adds a [`BigNumber`](#BigNumber) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value. |

#### AddItem

```csharp
void AddItem(ref BigInteger value)
```

Adds a [`BigInteger`](#BigInteger) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value. |

#### AddItem

```csharp
void AddItem(Int128 value)
```

Adds an [`Int128`](#Int128) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Int128` | The [`Int128`](#Int128) value. |

#### AddItem

```csharp
void AddItem(UInt128 value)
```

Adds a [`UInt128`](#UInt128) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `UInt128` | The [`UInt128`](#UInt128) value. |

#### AddItem

```csharp
void AddItem(Half value)
```

Adds a [`Half`](#Half) item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Half` | The [`Half`](#Half) value. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<long> array)
```

Adds an array of [`Int64`](#Int64) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<long>` | The array of [`Int64`](#Int64) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<int> array)
```

Adds an array of [`Int32`](#Int32) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<int>` | The array of [`Int32`](#Int32) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<short> array)
```

Adds an array of [`Int16`](#Int16) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<short>` | The array of [`Int16`](#Int16) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<sbyte> array)
```

Adds an array of [`SByte`](#SByte) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<sbyte>` | The array of [`SByte`](#SByte) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<ulong> array)
```

Adds an array of [`UInt64`](#UInt64) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<ulong>` | The array of [`UInt64`](#UInt64) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<uint> array)
```

Adds an array of [`UInt32`](#UInt32) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<uint>` | The array of [`UInt32`](#UInt32) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<ushort> array)
```

Adds an array of [`UInt16`](#UInt16) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<ushort>` | The array of [`UInt16`](#UInt16) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<byte> array)
```

Adds an array of [`Byte`](#Byte) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<byte>` | The array of [`Byte`](#Byte) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<decimal> array)
```

Adds an array of [`Decimal`](#Decimal) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<decimal>` | The array of [`Decimal`](#Decimal) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<double> array)
```

Adds an array of [`Double`](#Double) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<double>` | The array of [`Double`](#Double) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<float> array)
```

Adds an array of [`Single`](#Single) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<float>` | The array of [`Single`](#Single) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<Int128> array)
```

Adds an array of [`Int128`](#Int128) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<Int128>` | The array of [`Int128`](#Int128) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<UInt128> array)
```

Adds an array of [`UInt128`](#UInt128) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<UInt128>` | The array of [`UInt128`](#UInt128) values. |

#### AddItemArrayValue

```csharp
void AddItemArrayValue(ReadOnlySpan<Half> array)
```

Adds an array of [`Half`](#Half) values as an item to the current array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `array` | `ReadOnlySpan<Half>` | The array of [`Half`](#Half) values. |

#### StartObject

```csharp
void StartObject()
```

Starts a new JSON object in the builder.

#### StartArray

```csharp
void StartArray()
```

Starts a new JSON array in the builder.

#### EndObject

```csharp
void EndObject()
```

Ends the current JSON object, finalizing its structure in the builder.

#### RemoveProperty

```csharp
void RemoveProperty(string name)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `string` |  |

#### Apply

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
| `System.InvalidOperationException` | Thrown if the `value` is not a JSON object. |

The value must be a JSON object. Its properties will be set on the current document, replacing any existing values if present.

#### TryApply

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

**Returns:** `bool`

`true` if the value was applied.

If the value is a JSON object, its properties (if any) will be set on the current document, replacing any existing values if present, and the method returns `true`. Otherwise, no changes are made, and the method returns `false`.

#### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<char> name)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `name` | `ReadOnlySpan<char>` | The name of the property as a character span. |

#### RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<byte> utf8Name, bool escapeName, bool nameRequiresUnescaping)
```

Removes a property from the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | `ReadOnlySpan<byte>` | The UTF-8 name of the property. |
| `escapeName` | `bool` | Indicates whether the name requires escaping. |
| `nameRequiresUnescaping` | `bool` | If the name does not require escaping, indicates whether the name requires unescaping. |

#### EndArray

```csharp
void EndArray()
```

Ends the current JSON array, finalizing its structure in the builder.

#### SetAndDispose

```csharp
void SetAndDispose(ref MetadataDb targetData)
```

Transfers the built data to the specified [`MetadataDb`](#MetadataDb) and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetData` | `ref MetadataDb` | The target metadata database to receive the data. |

#### InsertAndDispose

```csharp
void InsertAndDispose(int complexObjectStartIndex, int targetIndex, ref MetadataDb targetData)
```

Inserts the built data into the specified [`MetadataDb`](#MetadataDb) at the given index and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | `int` | The start index of the complex object in the target database. |
| `targetIndex` | `int` | The index at which to insert the data. |
| `targetData` | `ref MetadataDb` | The target metadata database to receive the data. |

#### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<byte> stringValue, bool escape, bool ifNotEscapeRequiresUenscaping)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `stringValue` | `ReadOnlySpan<byte>` |  |
| `escape` | `bool` | Indicates whether to escape the property name. |
| `ifNotEscapeRequiresUenscaping` | `bool` | Indicates whether the property name needs unescaping if it is not to be escaped. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

#### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<char> propertyName)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<char>` | The property name as a character span. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

#### StartProperty

```csharp
ComplexValueBuilder.ComplexValueHandle StartProperty(string propertyName)
```

Add a property name to the current object.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The property name. |

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

#### EndProperty

```csharp
void EndProperty(ref ComplexValueBuilder.ComplexValueHandle handle)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `handle` | `ref ComplexValueBuilder.ComplexValueHandle` |  |

#### StartItem

```csharp
ComplexValueBuilder.ComplexValueHandle StartItem()
```

Start an array item.

**Returns:** `ComplexValueBuilder.ComplexValueHandle`

The handle for the property.

#### EndItem

```csharp
void EndItem(ref ComplexValueBuilder.ComplexValueHandle handle)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `handle` | `ref ComplexValueBuilder.ComplexValueHandle` |  |

#### OverwriteAndDispose

```csharp
void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, ref MetadataDb targetData)
```

Overwrites a range of data in the specified [`MetadataDb`](#MetadataDb) with the built data and disposes this builder.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | `int` | The start index of the complex object in the target database. |
| `startIndex` | `int` | The start index of the range to overwrite. |
| `endIndex` | `int` | The end index of the range to overwrite. |
| `memberCountToReplace` | `int` | The number of members to replace. |
| `targetData` | `ref MetadataDb` | The target metadata database to receive the data. |

### Nested Types

### ComplexValueBuilder.ComplexValueHandle (struct)

```csharp
public readonly struct ComplexValueBuilder.ComplexValueHandle
```

---

### ComplexValueBuilder.ValueBuilderAction (delegate)

```csharp
public delegate ComplexValueBuilder.ValueBuilderAction : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### ComplexValueBuilder.ValueBuilderAction

```csharp
ComplexValueBuilder.ValueBuilderAction(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(ref ComplexValueBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref ComplexValueBuilder` |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref ComplexValueBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref ComplexValueBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref ComplexValueBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `builder` | `ref ComplexValueBuilder` |  |
| `result` | `IAsyncResult` |  |

---

### ComplexValueBuilder.ValueBuilderAction<TContext> (delegate)

```csharp
public delegate ComplexValueBuilder.ValueBuilderAction<TContext> : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### ComplexValueBuilder.ValueBuilderAction

```csharp
ComplexValueBuilder.ValueBuilderAction(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(ref TContext context, ref ComplexValueBuilder builder)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | `ref ComplexValueBuilder` |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TContext context, ref ComplexValueBuilder builder, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | `ref ComplexValueBuilder` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref TContext context, ref ComplexValueBuilder builder, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `builder` | `ref ComplexValueBuilder` |  |
| `result` | `IAsyncResult` |  |

---

---

## EnumeratorCreator (class)

```csharp
public static class EnumeratorCreator
```

### Methods

#### CreateArrayEnumerator `static`

```csharp
ArrayEnumerator<T> CreateArrayEnumerator<T>(IJsonDocument parent, int index)
```

Creates an enumerator for the items of a JSON array.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parent` | `IJsonDocument` | The parent JSON document. |
| `index` | `int` | The index of the array in the document. |

**Returns:** `ArrayEnumerator<T>`

An [`ArrayEnumerator`](#ArrayEnumerator) for the array.

#### CreateObjectEnumerator `static`

```csharp
ObjectEnumerator<T> CreateObjectEnumerator<T>(IJsonDocument parent, int index)
```

Creates an enumerator for the properties of a JSON object.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parent` | `IJsonDocument` | The parent JSON document. |
| `index` | `int` | The index of the object in the document. |

**Returns:** `ObjectEnumerator<T>`

An [`ObjectEnumerator`](#ObjectEnumerator) for the object.

---

## FixedStringJsonDocument<T> (class)

```csharp
public sealed class FixedStringJsonDocument<T> : IJsonDocument, IDisposable
```

Represents a JSON document based on a fixed string value.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the root element in the document. |

### Remarks

This type uses an internal cache to avoid allocations for evaluatoin of string values that have not originated in a regular JSON document (e.g. property names, or external strings.)

### Inheritance

- Implements: `IJsonDocument`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` |  |

### Methods

#### Parse `static`

```csharp
FixedStringJsonDocument<T> Parse(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
```

Parse an instance of the fixed string to a document, using caching.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `rawJsonStringValue` | `ReadOnlyMemory<byte>` | The raw JSON string value, including quotes. |
| `requiresUnescaping` | `bool` |  |

**Returns:** `FixedStringJsonDocument<T>`

A fixed string document representing the value, from the cache.

#### TryFormat

```csharp
bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormat

```csharp
bool TryFormat(int index, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |
| `destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `bool`

#### ToString

```csharp
string ToString(int index, string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |
| `format` | `string` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `string`

---

## IJsonDocument (interface)

```csharp
public interface IJsonDocument : IDisposable
```

The interface explicitly implemented by JSON Document providers for internal use only.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsDisposable` | `bool` | Gets a value indicating whether the document is disposable. |
| `IsImmutable` | `bool` | Gets a value indicating whether the document is immutable. |

### Methods

#### EnsurePropertyMap `abstract`

```csharp
void EnsurePropertyMap(int index)
```

Ensures the property map is available for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

#### GetHashCode `abstract`

```csharp
int GetHashCode(int index)
```

Gets the hash code for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `int`

The hash code.

#### ToString `abstract`

```csharp
string ToString(int index)
```

Converts the element at the specified index to a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `string`

The string representation of the element.

#### GetJsonTokenType `abstract`

```csharp
JsonTokenType GetJsonTokenType(int index)
```

Gets the JSON token type for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `JsonTokenType`

The JSON token type.

#### GetArrayIndexElement `abstract`

```csharp
JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | `int` | The current index. |
| `arrayIndex` | `int` | The array index. |

**Returns:** `JsonElement`

The JSON element.

#### GetArrayIndexElement `abstract`

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
| `currentIndex` | `int` | The current index. |
| `arrayIndex` | `int` | The array index. |

**Returns:** `TElement`

The JSON element.

#### GetArrayIndexElement `abstract`

```csharp
void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IJsonDocument parentDocument, ref int parentDocumentIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | `int` | The current index. |
| `arrayIndex` | `int` | The array index. |
| `parentDocument` | `ref IJsonDocument` | Produces the parent document of the result. |
| `parentDocumentIndex` | `ref int` | Produces the parent document index. |

#### GetArrayInsertionIndex `abstract`

```csharp
int GetArrayInsertionIndex(int currentIndex, int arrayIndex)
```

Gets DB index of the item at the array index within the array that starts at `currentIndex`.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | `int` | The current index. |
| `arrayIndex` | `int` | The array index. |

**Returns:** `int`

Note that this is the DB index in the current document. Contrast with [`GetArrayIndexElement`](#GetArrayIndexElement) overloads which return the document and index of the actual element value.

#### GetArrayLength `abstract`

```csharp
int GetArrayLength(int index)
```

Gets the length of the array at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the array. |

**Returns:** `int`

The length of the array.

#### GetPropertyCount `abstract`

```csharp
int GetPropertyCount(int index)
```

Gets the number of properties for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `int`

The number of properties.

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement value)
```

Tries to get the value of a named property as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<char>` | The name of the property. |
| `value` | `ref JsonElement` | The value of the property. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement value)
```

Tries to get the value of a named property as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property. |
| `value` | `ref JsonElement` | The value of the property. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### TryGetNamedPropertyValue `abstract`

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
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### TryGetNamedPropertyValue `abstract`

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
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<char>` | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

Tries to get the value of a named property as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<char>` | The name of the property. |
| `elementParent` | `ref IJsonDocument` | The parent document of the retrieved value. |
| `elementIndex` | `ref int` | The index of the retrieved value in the parent document. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

Tries to get the value of a named property as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property. |
| `elementParent` | `ref IJsonDocument` | The parent document of the retrieved value. |
| `elementIndex` | `ref int` | The index of the retrieved value in the parent document. |

**Returns:** `bool`

`true` if the property value was retrieved; otherwise, `false`.

#### GetString `abstract`

```csharp
string GetString(int index, JsonTokenType expectedType)
```

Gets the string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `expectedType` | `JsonTokenType` | The expected JSON token type. |

**Returns:** `string`

The string value.

#### TryGetString `abstract`

```csharp
bool TryGetString(int index, JsonTokenType expectedType, ref string result)
```

Tries to get the string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `expectedType` | `JsonTokenType` | The expected JSON token type. |
| `result` | `ref string` | The string value, or `null` if the value was not retrieved. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### GetUtf8JsonString `abstract`

```csharp
UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType)
```

Gets the UTF-8 JSON string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `expectedType` | `JsonTokenType` | The expected JSON token type. |

**Returns:** `UnescapedUtf8JsonString`

The UTF-8 JSON string value.

You are permitted to pass [`None`](#None) as the `expectedType` which will check both String and PropertyName as valid types.

#### GetUtf16JsonString `abstract`

```csharp
UnescapedUtf16JsonString GetUtf16JsonString(int index, JsonTokenType expectedType)
```

Gets the UTF-16 JSON string value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `expectedType` | `JsonTokenType` | The expected JSON token type. |

**Returns:** `UnescapedUtf16JsonString`

The UTF-16 JSON string value.

You are permitted to pass [`None`](#None) as the `expectedType` which will check both String and PropertyName as valid types.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte[] value)
```

Tries to get the value of the element at the specified index as a byte array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref byte[]` | The byte array value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref sbyte value)
```

Tries to get the value of the element at the specified index as an [`SByte`](#SByte).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref sbyte` | The [`SByte`](#SByte) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte value)
```

Tries to get the value of the element at the specified index as a [`Byte`](#Byte).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref byte` | The [`Byte`](#Byte) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref short value)
```

Tries to get the value of the element at the specified index as a [`Int16`](#Int16).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref short` | The [`Int16`](#Int16) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ushort value)
```

Tries to get the value of the element at the specified index as a [`UInt16`](#UInt16).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref ushort` | The [`UInt16`](#UInt16) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref int value)
```

Tries to get the value of the element at the specified index as an [`Int32`](#Int32).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref int` | The [`Int32`](#Int32) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref uint value)
```

Tries to get the value of the element at the specified index as a [`UInt32`](#UInt32).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref uint` | The [`UInt32`](#UInt32) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref long value)
```

Tries to get the value of the element at the specified index as a [`Int64`](#Int64).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref long` | The [`Int64`](#Int64) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ulong value)
```

Tries to get the value of the element at the specified index as a [`UInt64`](#UInt64).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref ulong` | The [`UInt64`](#UInt64) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref double value)
```

Tries to get the value of the element at the specified index as a [`Double`](#Double).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref double` | The [`Double`](#Double) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref float value)
```

Tries to get the value of the element at the specified index as a [`Single`](#Single).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref float` | The [`Single`](#Single) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref decimal value)
```

Tries to get the value of the element at the specified index as a [`Decimal`](#Decimal).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref decimal` | The [`Decimal`](#Decimal) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigInteger value)
```

Tries to get the value of the element at the specified index as a [`BigInteger`](#BigInteger).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigNumber value)
```

Tries to get the value of the element at the specified index as a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTime value)
```

Tries to get the value of the element at the specified index as a [`DateTime`](#DateTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTimeOffset value)
```

Tries to get the value of the element at the specified index as a [`DateTimeOffset`](#DateTimeOffset).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDateTime value)
```

Tries to get the value of the element at the specified index as an [`OffsetDateTime`](#OffsetDateTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDate value)
```

Tries to get the value of the element at the specified index as an [`OffsetDate`](#OffsetDate).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetTime value)
```

Tries to get the value of the element at the specified index as an [`OffsetTime`](#OffsetTime).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref LocalDate value)
```

Tries to get the value of the element at the specified index as a [`LocalDate`](#LocalDate).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Period value)
```

Tries to get the value of the element at the specified index as a [`Period`](#Period).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref Period` | The [`Period`](#Period) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Guid value)
```

Tries to get the value of the element at the specified index as a [`Guid`](#Guid).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref Guid` | The [`Guid`](#Guid) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Int128 value)
```

Tries to get the value of the element at the specified index as an [`Int128`](#Int128).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref Int128` | The [`Int128`](#Int128) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref UInt128 value)
```

Tries to get the value of the element at the specified index as a [`UInt128`](#UInt128).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref UInt128` | The [`UInt128`](#UInt128) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Half value)
```

Tries to get the value of the element at the specified index as a [`Half`](#Half).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref Half` | The [`Half`](#Half) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateOnly value)
```

Tries to get the value of the element at the specified index as a [`DateOnly`](#DateOnly).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref DateOnly` | The [`DateOnly`](#DateOnly) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref TimeOnly value)
```

Tries to get the value of the element at the specified index as a [`TimeOnly`](#TimeOnly).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `value` | `ref TimeOnly` | The [`TimeOnly`](#TimeOnly) value. |

**Returns:** `bool`

`true` if the value was retrieved; otherwise, `false`.

#### GetNameOfPropertyValue `abstract`

```csharp
string GetNameOfPropertyValue(int index)
```

Gets the name of the property value at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property. |

**Returns:** `string`

The name of the property value.

#### GetPropertyNameRaw `abstract`

```csharp
ReadOnlySpan<byte> GetPropertyNameRaw(int index)
```

Gets the raw property name as a byte span for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property. |

**Returns:** `ReadOnlySpan<byte>`

The raw property name as a byte span.

#### GetPropertyNameRaw `abstract`

```csharp
ReadOnlyMemory<byte> GetPropertyNameRaw(int index, bool includeQuotes)
```

Gets the raw property name as a byte span for the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property. |
| `includeQuotes` | `bool` | Whether to include quotes in the raw property name. |

**Returns:** `ReadOnlyMemory<byte>`

The raw property name as a byte span.

#### GetPropertyName `abstract`

```csharp
JsonElement GetPropertyName(int index)
```

Gets the property name as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property. |

**Returns:** `JsonElement`

The raw property name as a byte span.

#### GetPropertyNameUnescaped `abstract`

```csharp
UnescapedUtf8JsonString GetPropertyNameUnescaped(int index)
```

Gets the property name as a JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property. |

**Returns:** `UnescapedUtf8JsonString`

The unescaped property name.

#### GetRawValueAsString `abstract`

```csharp
string GetRawValueAsString(int index)
```

Gets the raw value of the element at the specified index as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `string`

The raw value as a string.

#### GetPropertyRawValueAsString `abstract`

```csharp
string GetPropertyRawValueAsString(int valueIndex)
```

Gets the raw value of the property at the specified index as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `valueIndex` | `int` | The index of the property value. |

**Returns:** `string`

The raw value as a string.

#### GetRawValue `abstract`

```csharp
RawUtf8JsonString GetRawValue(int index, bool includeQuotes)
```

Gets the raw value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `includeQuotes` | `bool` | Whether to include quotes in the raw value. |

**Returns:** `RawUtf8JsonString`

The raw value.

#### GetRawSimpleValue `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes)
```

Gets the raw simple value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `includeQuotes` | `bool` | Whether to include quotes in the raw value. |

**Returns:** `ReadOnlyMemory<byte>`

The raw simple value.

#### GetRawSimpleValue `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index)
```

Gets the raw simple value of the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `ReadOnlyMemory<byte>`

The raw simple value.

#### GetRawSimpleValueUnsafe `abstract`

```csharp
ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index)
```

Gets the raw simple value of the element at the specified index, without checking if the document has been disposed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `ReadOnlyMemory<byte>`

The raw simple value.

#### ValueIsEscaped `abstract`

```csharp
bool ValueIsEscaped(int index, bool isPropertyName)
```

Determines whether the value at the specified index is escaped.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the value. |
| `isPropertyName` | `bool` | Whether the value is a property name. |

**Returns:** `bool`

`true` if the value is escaped; otherwise, `false`.

#### TextEquals `abstract`

```csharp
bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
```

Determines whether the text at the specified index equals the specified text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the text. |
| `otherText` | `ReadOnlySpan<char>` | The text to compare. |
| `isPropertyName` | `bool` | Whether the text is a property name. |

**Returns:** `bool`

`true` if the text equals the specified text; otherwise, `false`.

#### TextEquals `abstract`

```csharp
bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
```

Determines whether the UTF-8 text at the specified index equals the specified text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the text. |
| `otherUtf8Text` | `ReadOnlySpan<byte>` | The UTF-8 text to compare. |
| `isPropertyName` | `bool` | Whether the text is a property name. |
| `shouldUnescape` | `bool` | Whether the text should be unescaped. |

**Returns:** `bool`

`true` if the text equals the specified text; otherwise, `false`.

#### WriteElementTo `abstract`

```csharp
void WriteElementTo(int index, Utf8JsonWriter writer)
```

Writes the element at the specified index to the provided JSON writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `writer` | `Utf8JsonWriter` | The JSON writer. |

#### WritePropertyName `abstract`

```csharp
void WritePropertyName(int index, Utf8JsonWriter writer)
```

Writes the property name at the specified index to the provided JSON writer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property name. |
| `writer` | `Utf8JsonWriter` | The JSON writer. |

#### CloneElement `abstract`

```csharp
JsonElement CloneElement(int index)
```

Clones the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |

**Returns:** `JsonElement`

The cloned JSON element.

#### CloneElement `abstract`

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
| `index` | `int` | The index of the element. |

**Returns:** `TElement`

The cloned JSON element.

#### GetDbSize `abstract`

```csharp
int GetDbSize(int index, bool includeEndElement)
```

Gets the size of the database for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `includeEndElement` | `bool` | Whether to include the end element in the size. |

**Returns:** `int`

The size of the database.

#### GetStartIndex `abstract`

```csharp
int GetStartIndex(int endIndex)
```

Gets the start index of the element from the end index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `endIndex` | `int` | The end index of the element. |

**Returns:** `int`

The start index of the element.

#### BuildRentedMetadataDb `abstract`

```csharp
int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[] rentedBacking)
```

Builds a rented metadata database for the specified parent document index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | `int` | The index of the parent document. |
| `workspace` | `JsonWorkspace` | The JSON workspace. |
| `rentedBacking` | `ref byte[]` | The rented backing array. |

**Returns:** `int`

The size of the metadata database.

#### AppendElementToMetadataDb `abstract`

```csharp
void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db)
```

Appends the element at the specified index to the metadata database.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `workspace` | `JsonWorkspace` | The JSON workspace. |
| `db` | `ref MetadataDb` | The metadata database. |

#### TryResolveJsonPointer `abstract`

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
| `jsonPointer` | `ReadOnlySpan<byte>` | The JSON pointer to resolve. |
| `index` | `int` | The index of the element. |
| `value` | `ref TValue` | Providers the resolved value, if the pointer could be resolved. |

**Returns:** `bool`

`true` if the pointer could be resolved, otherwise `false`.

#### TryFormat `abstract`

```csharp
bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

Formats the value to the provided destination span according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `destination` | `Span<char>` | The destination span to write the formatted value to. |
| `charsWritten` | `ref int` | The number of characters written to the destination span. |
| `format` | `ReadOnlySpan<char>` | The format string. |
| `formatProvider` | `IFormatProvider` | The format provider. |

**Returns:** `bool`

`true` if the formatting was successful; otherwise, `false`.

#### TryFormat `abstract`

```csharp
bool TryFormat(int index, Span<byte> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

Formats the value to the provided destination UTF-8 span according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `destination` | `Span<byte>` | The destination span to write the UTF-8 formatted value to. |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` | The format string. |
| `formatProvider` | `IFormatProvider` | The format provider. |

**Returns:** `bool`

`true` if the formatting was successful; otherwise, `false`.

#### ToString `abstract`

```csharp
string ToString(int index, string format, IFormatProvider formatProvider)
```

Gets the display string representation of the element at the specified index according to the specified format and format provider.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `format` | `string` | The format string. |
| `formatProvider` | `IFormatProvider` | The format provider. |

**Returns:** `string`

The display string representation of the element.

#### TryGetLineAndOffset `abstract`

```csharp
bool TryGetLineAndOffset(int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

Tries to get the line number and character offset in the original source document for the element at the specified index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `line` | `ref int` | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | `ref int` | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | `ref long` | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** `bool`

`true` if the line and offset were successfully determined; otherwise, `false`.

#### TryGetLineAndOffsetForPointer `abstract`

```csharp
bool TryGetLineAndOffsetForPointer(ReadOnlySpan<byte> jsonPointer, int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | `ReadOnlySpan<byte>` | The JSON pointer to resolve. |
| `index` | `int` | The index of the element at the root of the pointer resolution. |
| `line` | `ref int` | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | `ref int` | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | `ref long` | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** `bool`

`true` if the pointer was resolved and the line and offset were successfully determined; otherwise, `false`.

#### TryGetLine `abstract`

```csharp
bool TryGetLine(int lineNumber, ref ReadOnlyMemory<byte> line)
```

Tries to get the specified line from the original source document as UTF-8 bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | `int` | The 1-based line number to retrieve. |
| `line` | `ref ReadOnlyMemory<byte>` | When this method returns, contains the UTF-8 bytes of the line if successful. |

**Returns:** `bool`

`true` if the line was successfully retrieved; otherwise, `false`.

#### TryGetLine `abstract`

```csharp
bool TryGetLine(int lineNumber, ref string line)
```

Tries to get the specified line from the original source document as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | `int` | The 1-based line number to retrieve. |
| `line` | `ref string` | When this method returns, contains the line text if successful. |

**Returns:** `bool`

`true` if the line was successfully retrieved; otherwise, `false`.

---

## IJsonElement (interface)

```csharp
public interface IJsonElement
```

Implemented by JsonElement-derived types.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `ParentDocument` | `IJsonDocument` | Gets the parent document. |
| `ParentDocumentIndex` | `int` | Gets the handle identifying the [`IJsonElement`](#IJsonElement) in its parent document. |
| `TokenType` | `JsonTokenType` | Gets the JSON Token type of the element. |
| `ValueKind` | `JsonValueKind` | Gets the JSON Value Kind of the element. |

### Methods

#### CheckValidInstance `abstract`

```csharp
void CheckValidInstance()
```

Checks that this instance is valid.

#### EvaluateSchema `abstract`

```csharp
bool EvaluateSchema(IJsonSchemaResultsCollector resultsCollector)
```

Evaluates the schema for this element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `resultsCollector` | `IJsonSchemaResultsCollector` | The results collector for schema evaluation (optional). *(optional)* |

**Returns:** `bool`

`true` if the schema evaluation succeeded; otherwise, `false`.

#### WriteTo `abstract`

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Writes this element to the specified [`Utf8JsonWriter`](#Utf8JsonWriter).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | `Utf8JsonWriter` | The writer to which to write the element. |

---

## IJsonElement<T> (interface)

```csharp
public interface IJsonElement<T> : IJsonElement
```

Implemented by JsonElement-derived types.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type implementing the interface. |

### Inheritance

- Implements: `IJsonElement`

### Methods

#### CreateInstance `static` `abstract`

```csharp
T CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex)
```

Creates an instance of the element from the parent document and the handle of the element in the parent document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document instance. |
| `parentDocumentIndex` | `int` | The handle of the element in the parent document. |

**Returns:** `T`

An instance of the implementing element type.

---

## IMutableJsonDocument (interface)

```csharp
public interface IMutableJsonDocument : IJsonDocument, IDisposable
```

Represents a mutable JSON document that supports editing and value storage operations.

### Inheritance

- Implements: `IJsonDocument`
- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Version` | `ulong` | Gets the version of the document. |
| `ParentWorkspaceIndex` | `int` | Gets the index of the parent workspace. |
| `Workspace` | `JsonWorkspace` | Gets the JSON workspace associated with this document. |

### Methods

#### GetArrayIndexElement `abstract`

```csharp
JsonElement.Mutable GetArrayIndexElement(int currentIndex, int arrayIndex)
```

Gets the array element at the specified index as a mutable JSON element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | `int` | The current index in the document. |
| `arrayIndex` | `int` | The index within the array. |

**Returns:** `JsonElement.Mutable`

The mutable JSON element at the specified array index.

#### GetArrayIndexElement `abstract`

```csharp
void GetArrayIndexElement(int currentIndex, int arrayIndex, ref IMutableJsonDocument parentDocument, ref int parentDocumentIndex)
```

Gets the element at the specified array index within the current index.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | `int` | The current index. |
| `arrayIndex` | `int` | The array index. |
| `parentDocument` | `ref IMutableJsonDocument` | Produces the parent document of the result. |
| `parentDocumentIndex` | `ref int` | Produces the parent document index. |

#### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(ref MetadataDb parsedData, int startIndex, int endIndex, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](#MetadataDb).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parsedData` | `ref MetadataDb` | The parsed data. This is used in place of the document's own MetadataDb. |
| `startIndex` | `int` | The index of the first property name. |
| `endIndex` | `int` | The index of the last property value. |
| `propertyName` | `ReadOnlySpan<byte>` | The unescaped property name to look up. |
| `valueIndex` | `ref int` | The index of the value corresponding to the given property name. |

**Returns:** `bool`

`true` if the property with the given name is found.

#### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<char> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](#MetadataDb).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<char>` | The unescaped property name to look up. |
| `valueIndex` | `ref int` | The index of the value corresponding to the given property name. |

**Returns:** `bool`

`true` if the property with the given name is found.

#### TryGetNamedPropertyValueIndex `abstract`

```csharp
bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](#MetadataDb).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the element. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property as a UTF-8 byte span. |
| `valueIndex` | `ref int` | The index of the value corresponding to the given property name. |

**Returns:** `bool`

`true` if the property with the given name is found.

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |
| `propertyName` | `ReadOnlySpan<char>` |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** `bool`

#### TryGetNamedPropertyValue `abstract`

```csharp
bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement.Mutable value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` |  |
| `propertyName` | `ReadOnlySpan<byte>` |  |
| `value` | `ref JsonElement.Mutable` |  |

**Returns:** `bool`

#### StoreRawNumberValue `abstract`

```csharp
int StoreRawNumberValue(ReadOnlySpan<byte> value)
```

Stores a raw number value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The raw number value as a UTF-8 byte span. |

**Returns:** `int`

The index of the stored value.

#### StoreNullValue `abstract`

```csharp
int StoreNullValue()
```

Stores a null value in the document.

**Returns:** `int`

The index of the stored value.

#### StoreBooleanValue `abstract`

```csharp
int StoreBooleanValue(bool value)
```

Stores a boolean value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `bool` | The boolean value. |

**Returns:** `int`

The index of the stored value.

#### EscapeAndStoreRawStringValue `abstract`

```csharp
int EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<char>` | The string value to escape and store. |
| `requiredEscaping` | `ref bool` | Set to `true` if escaping was required. |

**Returns:** `int`

The index of the stored value.

#### EscapeAndStoreRawStringValue `abstract`

```csharp
int EscapeAndStoreRawStringValue(ReadOnlySpan<byte> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 string value to escape and store. |
| `requiredEscaping` | `ref bool` | Set to `true` if escaping was required. |

**Returns:** `int`

The index of the stored value.

#### StoreRawStringValue `abstract`

```csharp
int StoreRawStringValue(ReadOnlySpan<byte> value)
```

Stores a raw string value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 string value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(Guid value)
```

Stores a [`Guid`](#Guid) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Guid` | The [`Guid`](#Guid) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref DateTime value)
```

Stores a [`DateTime`](#DateTime) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTime` | The [`DateTime`](#DateTime) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref DateTimeOffset value)
```

Stores a [`DateTimeOffset`](#DateTimeOffset) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref DateTimeOffset` | The [`DateTimeOffset`](#DateTimeOffset) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDateTime value)
```

Stores an [`OffsetDateTime`](#OffsetDateTime) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The [`OffsetDateTime`](#OffsetDateTime) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDate value)
```

Stores an [`OffsetDate`](#OffsetDate) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The [`OffsetDate`](#OffsetDate) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref OffsetTime value)
```

Stores an [`OffsetTime`](#OffsetTime) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The [`OffsetTime`](#OffsetTime) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref LocalDate value)
```

Stores a [`LocalDate`](#LocalDate) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The [`LocalDate`](#LocalDate) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref Period value)
```

Stores a [`Period`](#Period) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` | The [`Period`](#Period) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(sbyte value)
```

Stores an [`SByte`](#SByte) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `sbyte` | The [`SByte`](#SByte) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(byte value)
```

Stores a [`Byte`](#Byte) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `byte` | The [`Byte`](#Byte) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(int value)
```

Stores an [`Int32`](#Int32) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` | The [`Int32`](#Int32) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(uint value)
```

Stores a [`UInt32`](#UInt32) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `uint` | The [`UInt32`](#UInt32) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(long value)
```

Stores a [`Int64`](#Int64) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `long` | The [`Int64`](#Int64) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ulong value)
```

Stores a [`UInt64`](#UInt64) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ulong` | The [`UInt64`](#UInt64) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(short value)
```

Stores a [`Int16`](#Int16) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `short` | The [`Int16`](#Int16) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ushort value)
```

Stores a [`UInt16`](#UInt16) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ushort` | The [`UInt16`](#UInt16) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(float value)
```

Stores a [`Single`](#Single) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `float` | The [`Single`](#Single) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(double value)
```

Stores a [`Double`](#Double) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `double` | The [`Double`](#Double) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(decimal value)
```

Stores a [`Decimal`](#Decimal) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `decimal` | The [`Decimal`](#Decimal) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref BigInteger value)
```

Stores a [`BigInteger`](#BigInteger) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigInteger` | The [`BigInteger`](#BigInteger) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(ref BigNumber value)
```

Stores a [`BigNumber`](#BigNumber) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref BigNumber` | The [`BigNumber`](#BigNumber) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(Int128 value)
```

Stores an [`Int128`](#Int128) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Int128` | The [`Int128`](#Int128) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(UInt128 value)
```

Stores a [`UInt128`](#UInt128) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `UInt128` | The [`UInt128`](#UInt128) value to store. |

**Returns:** `int`

The index of the stored value.

#### StoreValue `abstract`

```csharp
int StoreValue(Half value)
```

Stores a [`Half`](#Half) value in the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Half` | The [`Half`](#Half) value to store. |

**Returns:** `int`

The index of the stored value.

#### RemoveRange `abstract`

```csharp
void RemoveRange(int complexObjectStartIndex, int startIndex, int endIndex, int membersToRemove)
```

Removes a range of values from the document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | `int` | The start index of the complex object. |
| `startIndex` | `int` | The start index of the range to remove. |
| `endIndex` | `int` | The end index of the range to remove. |
| `membersToRemove` | `int` | The number of members to remove. |

This is similar to [`OverwriteAndDispose`](#OverwriteAndDispose), but it does not replace the values that are removed. Instead, it simply removes the specified range of members from the document, effectively shifting subsequent members up.

#### SetAndDispose `abstract`

```csharp
void SetAndDispose(ref ComplexValueBuilder cvb)
```

Sets the value of the document and disposes the provided [`ComplexValueBuilder`](#ComplexValueBuilder).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `cvb` | `ref ComplexValueBuilder` | The [`ComplexValueBuilder`](#ComplexValueBuilder) to set and dispose. |

#### InsertAndDispose `abstract`

```csharp
void InsertAndDispose(int complexObjectStartIndex, int index, ref ComplexValueBuilder cvb)
```

Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](#ComplexValueBuilder).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | `int` | The start index of the complex object. |
| `index` | `int` | The index at which to insert. |
| `cvb` | `ref ComplexValueBuilder` | The [`ComplexValueBuilder`](#ComplexValueBuilder) to insert and dispose. |

#### OverwriteAndDispose `abstract`

```csharp
void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int membersToOverwrite, ref ComplexValueBuilder cvb)
```

Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](#ComplexValueBuilder).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | `int` | The start index of the complex object. |
| `startIndex` | `int` | The start index of the range to overwrite. |
| `endIndex` | `int` | The end index of the range to overwrite. |
| `membersToOverwrite` | `int` | The number of members to overwrite. |
| `cvb` | `ref ComplexValueBuilder` | The [`ComplexValueBuilder`](#ComplexValueBuilder) to overwrite and dispose. |

---

## IMutableJsonElement<T> (interface)

```csharp
public interface IMutableJsonElement<T> : IJsonElement<T>, IJsonElement
```

Represents a mutable JSON element of type `T`.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type implementing the interface. |

### Remarks

Note that mutable elements are ephemeral. If their underlying document is modified, they may no longer be valid, and their behaviour is undefined.

### Inheritance

- Implements: `IJsonElement<T>`
- Implements: `IJsonElement`

---

## JsonDocument (class)

```csharp
public abstract class JsonDocument
```

Base class for JSON document implementations providing common functionality for parsing and accessing JSON data.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsImmutable` | `bool` | Gets a value indicating whether the document is immutable. |

### Methods

#### Freeze

```csharp
void Freeze()
```

Makes the document immutable.

You can only create a new document from this document once it is frozen. Immutable documents (like [`ParsedJsonDocument`](#ParsedJsonDocument) are frozen once they are created, and there is no need to call freeze on them. Mutable documents (like [`JsonDocumentBuilder`](#JsonDocumentBuilder) must be frozen before you can create a child document from one of its elements. Once a mutable document is frozen, any methods that would modify the document will throw.

---

## JsonElementHelpers (class)

```csharp
public static class JsonElementHelpers
```

Core helper methods for parsing and processing JSON numeric values into their component parts.

### Methods

#### ParseNumber `static`

```csharp
void ParseNumber(ReadOnlySpan<byte> span, ref bool isNegative, ref ReadOnlySpan<byte> integral, ref ReadOnlySpan<byte> fractional, ref int exponent)
```

Parses a JSON number into its component parts using normal-form decimal representation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` | The UTF-8 encoded span containing the JSON number to parse. |
| `isNegative` | `ref bool` | When this method returns, indicates whether the number is negative. |
| `integral` | `ref ReadOnlySpan<byte>` | When this method returns, contains the integral part of the number without leading zeros. |
| `fractional` | `ref ReadOnlySpan<byte>` | When this method returns, contains the fractional part of the number without trailing zeros. |
| `exponent` | `ref int` | When this method returns, contains the exponent value for scientific notation. |

The returned components use a normal-form decimal representation: Number := sign * <integral + fractional> * 10^exponent where integral and fractional are sequences of digits whose concatenation represents the significand of the number without leading or trailing zeros. Two such normal-form numbers are treated as equal if and only if they have equal signs, significands, and exponents.

#### TryParseNumber `static`

```csharp
bool TryParseNumber(ReadOnlySpan<byte> span, ref bool isNegative, ref ReadOnlySpan<byte> integral, ref ReadOnlySpan<byte> fractional, ref int exponent)
```

Parses a JSON number into its component parts using normal-form decimal representation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` | The UTF-8 encoded span containing the JSON number to parse. |
| `isNegative` | `ref bool` | When this method returns, indicates whether the number is negative. |
| `integral` | `ref ReadOnlySpan<byte>` | When this method returns, contains the integral part of the number without leading zeros. |
| `fractional` | `ref ReadOnlySpan<byte>` | When this method returns, contains the fractional part of the number without trailing zeros. |
| `exponent` | `ref int` | When this method returns, contains the exponent value for scientific notation. |

**Returns:** `bool`

`true` if the value was parsed successfully, otherwise `false`.

The returned components use a normal-form decimal representation: Number := sign * <integral + fractional> * 10^exponent where integral and fractional are sequences of digits whose concatenation represents the significand of the number without leading or trailing zeros. Two such normal-form numbers are treated as equal if and only if they have equal signs, significands, and exponents.

#### CompareNormalizedJsonNumbers `static`

```csharp
int CompareNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

Compares two normalized JSON numbers for equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | True if the LHS is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | When concatenated with `leftFractional` produces the significand of the LHS number without leading or trailing zeros. |
| `leftFractional` | `ReadOnlySpan<byte>` | When concatenated with `leftIntegral` produces the significand of the LHS number without leading or trailing zeros. |
| `leftExponent` | `int` | The LHS exponent. |
| `rightIsNegative` | `bool` | True if the RHS is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | When concatenated with `rightFractional` produces the significand of the RHS number without leading or trailing zeros. |
| `rightFractional` | `ReadOnlySpan<byte>` | When concatenated with `rightIntegral` produces the significand of the RHS number without leading or trailing zeros. |
| `rightExponent` | `int` | The RHS exponent. |

**Returns:** `int`

-1 if the LHS is less than the RHS, 0 if the are equal, and 1 if the LHS is greater than the RHS.

#### ParseValue `static`

```csharp
T ParseValue<T>(ReadOnlySpan<byte> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` | The span to read. |
| `options` | `JsonDocumentOptions` | The [`JsonDocumentOptions`](#JsonDocumentOptions) for reading. *(optional)* |

**Returns:** `T`

A [`IJsonElement`](#IJsonElement) representing the value (and nested values) read from the span.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | A value could not be read from the span. |

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### ParseValue `static`

```csharp
T ParseValue<T>(ReadOnlySpan<char> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<char>` | The span to read. |
| `options` | `JsonDocumentOptions` | The [`JsonDocumentOptions`](#JsonDocumentOptions) for reading. *(optional)* |

**Returns:** `T`

A JsonElement representing the value (and nested values) read from the span.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### ParseValue `static`

```csharp
T ParseValue<T>(string text, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `string` | The text to read. |
| `options` | `JsonDocumentOptions` | The [`JsonDocumentOptions`](#JsonDocumentOptions) for reading. *(optional)* |

**Returns:** `T`

A JsonElement representing the value (and nested values) read from the text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `Corvus.Text.Json.JsonException` | A value could not be read from the text. |

This method makes a copy of the data, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### ParseValue `static`

```csharp
T ParseValue<T>(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |

**Returns:** `T`

A JsonElement representing the value (and nested values) read from the reader.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### TryParseValue `static`

```csharp
bool TryParseValue<T>(ref Utf8JsonReader reader, ref Nullable<T> element)
```

Attempts to parse one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | `ref Utf8JsonReader` | The reader to read. |
| `element` | `ref Nullable<T>` | Receives the parsed element. |

**Returns:** `bool`

`true` if a value was read and parsed into a JsonElement; `false` if the reader ran out of data while parsing. All other situations result in an exception being thrown.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | `reader` is using unsupported options. |
| `System.ArgumentException` | The current `reader` token does not start or represent a value. |
| `Corvus.Text.Json.JsonException` | A value could not be read from the reader. |

If the [`TokenType`](#TokenType) property of `reader` is [`PropertyName`](#PropertyName) or [`None`](#None), the reader will be advanced by one call to [`Read`](#Read) to determine the start of the value. Upon completion of this method, `reader` will be positioned at the final token in the JSON value. If an exception is thrown, or `false` is returned, the reader is reset to the state it was in when the method was called. This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

#### CountRunes `static`

```csharp
int CountRunes(ReadOnlySpan<byte> utf8String)
```

Count the runes in a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | `ReadOnlySpan<byte>` | The UTF-8 string for which to count the runes. |

**Returns:** `int`

The number of runes in the UTF-8 string.

#### ParseDateCore `static`

```csharp
bool ParseDateCore(ReadOnlySpan<byte> text, ref int year, ref int month, ref int day)
```

Parses a date string in ISO 8601 format (YYYY-MM-DD) and extracts the year, month, and day components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text containing the date string to parse. |
| `year` | `ref int` | When this method returns, contains the year component of the date. |
| `month` | `ref int` | When this method returns, contains the month component of the date (1-12). |
| `day` | `ref int` | When this method returns, contains the day component of the date (1-31). |

**Returns:** `bool`

`true` if the date was successfully parsed; otherwise, `false`.

#### ParseOffsetTimeCore `static`

```csharp
bool ParseOffsetTimeCore(ReadOnlySpan<byte> text, ref int hours, ref int minutes, ref int seconds, ref int milliseconds, ref int microseconds, ref int nanoseconds, ref int offsetSeconds)
```

Parses a time string with optional offset in ISO 8601 format and extracts the time and offset components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text containing the time string to parse. |
| `hours` | `ref int` | When this method returns, contains the hours component of the time (0-23). |
| `minutes` | `ref int` | When this method returns, contains the minutes component of the time (0-59). |
| `seconds` | `ref int` | When this method returns, contains the seconds component of the time (0-59). |
| `milliseconds` | `ref int` | When this method returns, contains the milliseconds component of the time (0-999). |
| `microseconds` | `ref int` | When this method returns, contains the microseconds component of the time (0-999). |
| `nanoseconds` | `ref int` | When this method returns, contains the nanoseconds component of the time (0-999). |
| `offsetSeconds` | `ref int` | When this method returns, contains the timezone offset in seconds from UTC. |

**Returns:** `bool`

`true` if the time was successfully parsed; otherwise, `false`.

#### ParseOffsetCore `static`

```csharp
bool ParseOffsetCore(ReadOnlySpan<byte> text, ref int offsetSeconds)
```

Parses a timezone offset string in ISO 8601 format (±HH:MM or Z) and extracts the offset in seconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text containing the offset string to parse. |
| `offsetSeconds` | `ref int` | When this method returns, contains the timezone offset in seconds from UTC. |

**Returns:** `bool`

`true` if the offset was successfully parsed; otherwise, `false`.

#### ParseTimeCore `static`

```csharp
bool ParseTimeCore(ReadOnlySpan<byte> text, ref int hours, ref int minutes, ref int seconds, ref int milliseconds, ref int microseconds, ref int nanoseconds)
```

Parses a time string in ISO 8601 format (HH:MM:SS[.nnnnnnnnn]) and extracts the time components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded text containing the time string to parse. |
| `hours` | `ref int` | When this method returns, contains the hours component of the time (0-23). |
| `minutes` | `ref int` | When this method returns, contains the minutes component of the time (0-59). |
| `seconds` | `ref int` | When this method returns, contains the seconds component of the time (0-59). |
| `milliseconds` | `ref int` | When this method returns, contains the milliseconds component of the time (0-999). |
| `microseconds` | `ref int` | When this method returns, contains the microseconds component of the time (0-999). |
| `nanoseconds` | `ref int` | When this method returns, contains the nanoseconds component of the time (0-999). |

**Returns:** `bool`

`true` if the time was successfully parsed; otherwise, `false`.

#### SetPropertyUnsafe `static`

```csharp
void SetPropertyUnsafe<TTarget, TValue>(TTarget targetElement, JsonProperty<TValue> property)
```

Sets a property value on a target element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TTarget` | The type of the target element. |
| `TValue` | The type of the value. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetElement` | `TTarget` | The target element instance. |
| `property` | `JsonProperty<TValue>` | The property to set. |

#### RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<char> propertyName)
```

Removes a property value from a target element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IMutableJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `propertyName` | `ReadOnlySpan<char>` | The name of the property to remove. |

**Returns:** `bool`

`true` if the property was found and removed; otherwise, `false`.

#### RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<byte> propertyName)
```

Removes a property value from a target element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IMutableJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property to remove. |

**Returns:** `bool`

`true` if the property was found and removed; otherwise, `false`.

#### RemoveRangeUnsafe `static`

```csharp
void RemoveRangeUnsafe<TArray>(TArray arrayElement, int startIndex, int count)
```

Removes a range of items from an array element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `startIndex` | `int` | The zero-based index at which to begin removing items. |
| `count` | `int` | The number of items to remove. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element's [`JsonValueKind`](#JsonValueKind) is not [`Array`](#Array), or the element reference is stale due to document mutations. |
| `System.ArgumentOutOfRangeException` | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

#### RemoveFirstUnsafe `static`

```csharp
bool RemoveFirstUnsafe<TArray, T>(TArray arrayElement, ref T item)
```

Removes the first array element that equals the specified item.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |
| `T` | The type of the item to find and remove. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `item` | `ref T` | The item to find and remove. |

**Returns:** `bool`

`true` if an element was found and removed; otherwise, `false`.

#### RemoveWhereUnsafe `static`

```csharp
void RemoveWhereUnsafe<TArray, T>(TArray arrayElement, JsonPredicate<T> predicate)
```

Removes a items from an array element which match a predicate.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TArray` | The type of the array element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arrayElement` | `TArray` | The array element instance. |
| `predicate` | `JsonPredicate<T>` | The predicate to apply to each element to determine if it should be removed. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element's [`JsonValueKind`](#JsonValueKind) is not [`Array`](#Array), or the element reference is stale due to document mutations. |
| `System.ArgumentOutOfRangeException` | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

#### ApplyUnsafe `static`

```csharp
void ApplyUnsafe<TTarget, TSource>(TTarget targetElement, ref TSource sourceElement)
```

Applies all properties from a source JSON object element to a target JSON object element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TTarget` | The type of the target element implementing [`IMutableJsonElement`](#IMutableJsonElement). |
| `TSource` | The type of the source element implementing [`IJsonElement`](#IJsonElement). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetElement` | `TTarget` | The target JSON object element to which properties will be applied. |
| `sourceElement` | `ref TSource` | The source JSON object element from which properties will be copied. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The source element's [`JsonValueKind`](#JsonValueKind) is not [`Object`](#Object). |

This method performs a merge of properties from the source JSON object to the target JSON object. Each property from the source object is copied to the target object, replacing any existing properties with the same name. The source element must be a JSON object element. The target element is assumed to be valid and is not validated by this method. This method is not CLS-compliant due to its generic constraint requirements.

#### ToValueKind `static`

```csharp
JsonValueKind ToValueKind(JsonTokenType tokenType)
```

Converts a [`JsonTokenType`](#JsonTokenType) to its corresponding [`JsonValueKind`](#JsonValueKind).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The token type to convert. |

**Returns:** `JsonValueKind`

The corresponding value kind.

#### GetUtf8StringLength `static`

```csharp
int GetUtf8StringLength(ReadOnlySpan<byte> span)
```

Gets the length of a UTF-8 encoded string in characters (not bytes).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` | The UTF-8 encoded byte span. |

**Returns:** `int`

The number of Unicode characters in the string.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when the span contains invalid UTF-8 sequences. |

#### GetParentDocumentAndIndex `static`

```csharp
ValueTuple<IJsonDocument, int> GetParentDocumentAndIndex<TElement>(TElement value)
```

Gets the parent document and document index for a JSON element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `TElement` | The JSON element value. |

**Returns:** `ValueTuple<IJsonDocument, int>`

A tuple containing the parent document and the document index.

#### AreEqualJsonNumbers `static`

```csharp
bool AreEqualJsonNumbers(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
```

Compares two valid UTF-8 encoded JSON numbers for decimal equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `left` | `ReadOnlySpan<byte>` | The UTF-8 encoded bytes representing the left JSON number. |
| `right` | `ReadOnlySpan<byte>` | The UTF-8 encoded bytes representing the right JSON number. |

**Returns:** `bool`

`true` if the two JSON numbers are equal; otherwise, `false`.

#### AreEqualNormalizedJsonNumbers `static`

```csharp
bool AreEqualNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

Compares two valid normalized JSON numbers for decimal equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left number is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left number without leading zeros. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left number without trailing zeros. |
| `leftExponent` | `int` | The exponent of the left number. |
| `rightIsNegative` | `bool` | Indicates whether the right number is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right number without leading zeros. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right number without trailing zeros. |
| `rightExponent` | `int` | The exponent of the right number. |

**Returns:** `bool`

`true` if the two normalized JSON numbers are equal; otherwise, `false`.

#### IsIntegerNormalizedJsonNumber `static`

```csharp
bool IsIntegerNormalizedJsonNumber(int exponent)
```

Determines if a JSON number is an integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `exponent` | `int` | The exponent. |

**Returns:** `bool`

True if the normalized JSON number represents an integer.

#### IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | `ReadOnlySpan<byte>` | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | `ReadOnlySpan<byte>` | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | `int` | The exponent of the number. |
| `divisor` | `ulong` | The significand of the divisor represented as a [`UInt64`](#UInt64). |
| `divisorExponent` | `int` | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

**Returns:** `bool`

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

#### IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | `ReadOnlySpan<byte>` | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | `ReadOnlySpan<byte>` | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | `int` | The exponent of the number. |
| `divisor` | `BigInteger` | The significand of the divisor represented as a [`BigInteger`](#BigInteger). |
| `divisorExponent` | `int` | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

**Returns:** `bool`

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

#### TryFormatNumberAsString `static`

```csharp
bool TryFormatNumberAsString(ReadOnlySpan<byte> span, ReadOnlySpan<char> format, IFormatProvider provider, ref string value)
```

Format the number as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` | The UTF-8 representation of the number. |
| `format` | `ReadOnlySpan<char>` | The format to apply. |
| `provider` | `IFormatProvider` | The (optional) format provider. |
| `value` | `ref string` | The result if formatting succeeds, otherwise `null`. |

**Returns:** `bool`

`true` if formatting succeeds, otherwise `false`.

This will always return `false` if the formatted result exceeds 2048 characters in size.

#### TryFormatNumber `static`

```csharp
bool TryFormatNumber(ReadOnlySpan<byte> span, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` |  |
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormatNumber `static`

```csharp
bool TryFormatNumber(ReadOnlySpan<byte> span, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | `ReadOnlySpan<byte>` |  |
| `destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormatUri `static`

```csharp
bool TryFormatUri(Utf8Uri uri, bool isDisplay, ref string result)
```

Tries to format a [`Utf8Uri`](#Utf8Uri) as a display (human-readable) or canonical (percent-encoded) string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `Utf8Uri` | The URI to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `result` | `ref string` | The formatted string, or `null` if formatting failed. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatUri `static`

```csharp
bool TryFormatUri(Utf8Uri uri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

Tries to format a [`Utf8Uri`](#Utf8Uri) as a display (human-readable) or canonical (percent-encoded) string into a [`Span`](#Span) of [`Char`](#Char).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | `Utf8Uri` | The URI to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `destination` | `Span<char>` | The destination buffer. |
| `charsWritten` | `ref int` | The number of characters written. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatUriReference `static`

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, ref string result)
```

Tries to format a [`Utf8UriReference`](#Utf8UriReference) as a display (human-readable) or canonical (percent-encoded) string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `Utf8UriReference` | The URI reference to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `result` | `ref string` | The formatted string, or `null` if formatting failed. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatUriReference `static`

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

Tries to format a [`Utf8UriReference`](#Utf8UriReference) as a display (human-readable) or canonical (percent-encoded) string into a [`Span`](#Span) of [`Char`](#Char).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | `Utf8UriReference` | The URI reference to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `destination` | `Span<char>` | The destination buffer. |
| `charsWritten` | `ref int` | The number of characters written. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatIri `static`

```csharp
bool TryFormatIri(Utf8Iri iri, bool isDisplay, ref string result)
```

Tries to format a [`Utf8Iri`](#Utf8Iri) as a display (human-readable) or canonical (percent-encoded) string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `Utf8Iri` | The IRI to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `result` | `ref string` | The formatted string, or `null` if formatting failed. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatIri `static`

```csharp
bool TryFormatIri(Utf8Iri iri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

Tries to format a [`Utf8Iri`](#Utf8Iri) as a display (human-readable) or canonical (percent-encoded) string into a [`Span`](#Span) of [`Char`](#Char).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | `Utf8Iri` | The IRI to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `destination` | `Span<char>` | The destination buffer. |
| `charsWritten` | `ref int` | The number of characters written. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatIriReference `static`

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, ref string result)
```

Tries to format a [`Utf8IriReference`](#Utf8IriReference) as a display (human-readable) or canonical (percent-encoded) string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | `Utf8IriReference` | The IRI reference to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `result` | `ref string` | The formatted string, or `null` if formatting failed. |

**Returns:** `bool`

`true` if formatting succeeded.

#### TryFormatIriReference `static`

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

Tries to format a [`Utf8IriReference`](#Utf8IriReference) as a display (human-readable) or canonical (percent-encoded) string into a [`Span`](#Span) of [`Char`](#Char).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | `Utf8IriReference` | The IRI reference to format. |
| `isDisplay` | `bool` | `true` to produce the display form with percent-encoded sequences decoded; `false` to produce the canonical form with all required characters percent-encoded. |
| `destination` | `Span<char>` | The destination buffer. |
| `charsWritten` | `ref int` | The number of characters written. |

**Returns:** `bool`

`true` if formatting succeeded.

#### DeepEquals `static`

```csharp
bool DeepEquals<TLeft, TRight>(ref TLeft element1, ref TRight element2)
```

Compares the values of two [`IJsonElement`](#IJsonElement) values for equality, including the values of all descendant elements.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](#IJsonElement). |
| `TRight` | The type of the second [`IJsonElement`](#IJsonElement). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](#IJsonElement) to compare. |
| `element2` | `ref TRight` | The second [`IJsonElement`](#IJsonElement) to compare. |

**Returns:** `bool`

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

#### DeepEqualsNoParentDocumentCheck `static`

```csharp
bool DeepEqualsNoParentDocumentCheck<TLeft>(ref TLeft element1, JsonTokenType element2TokenType, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two [`IJsonElement`](#IJsonElement) values for equality, including the values of all descendant elements.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](#IJsonElement). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](#IJsonElement) to compare. |
| `element2TokenType` | `JsonTokenType` | The token type of the second JSON element. |
| `element2ParentDocument` | `IJsonDocument` | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | `int` | The index of the second JSON element within its parent document. |

**Returns:** `bool`

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

#### DeepEqualsNoParentDocumentCheck `static`

```csharp
bool DeepEqualsNoParentDocumentCheck(IJsonDocument element1ParentDocument, int element1ParentDocumentIndex, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two JSON values for equality, including the values of all descendant elements.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1ParentDocument` | `IJsonDocument` | The parent document containing the first JSON element. |
| `element1ParentDocumentIndex` | `int` | The index of the first JSON element within its parent document. |
| `element2ParentDocument` | `IJsonDocument` | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | `int` | The index of the second JSON element within its parent document. |

**Returns:** `bool`

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

#### TryFormatLocalDate `static`

```csharp
bool TryFormatLocalDate(ref LocalDate value, Span<byte> output, ref int bytesWritten)
```

Format a date as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The value to format. |
| `output` | `Span<byte>` | The output buffer. |
| `bytesWritten` | `ref int` | The number of bytes written to the output buffer. |

**Returns:** `bool`

`true` if the date was formatted successfully.

#### TryFormatOffsetDate `static`

```csharp
bool TryFormatOffsetDate(ref OffsetDate value, Span<byte> output, ref int bytesWritten)
```

Format a date as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The value to format. |
| `output` | `Span<byte>` | The output buffer. |
| `bytesWritten` | `ref int` | The number of bytes written to the output buffer. |

**Returns:** `bool`

`true` if the date was formatted successfully.

#### TryFormatOffsetDateTime `static`

```csharp
bool TryFormatOffsetDateTime(ref OffsetDateTime value, Span<byte> output, ref int bytesWritten)
```

Format an offset date time as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The value to format. |
| `output` | `Span<byte>` | The output buffer. |
| `bytesWritten` | `ref int` | The number of bytes written to the output buffer. |

**Returns:** `bool`

`true` if the date was formatted successfully.

#### TryFormatOffsetTime `static`

```csharp
bool TryFormatOffsetTime(ref OffsetTime value, Span<byte> output, ref int bytesWritten)
```

Format a time as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The value to format. |
| `output` | `Span<byte>` | The output buffer. |
| `bytesWritten` | `ref int` | The number of bytes written to the output buffer. |

**Returns:** `bool`

`true` if the time was formatted successfully.

#### TryFormatPeriod `static`

```csharp
bool TryFormatPeriod(ref Period value, Span<byte> output, ref int bytesWritten)
```

Format a period as a UTF-8 string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref Period` | The value to format. |
| `output` | `Span<byte>` | The output buffer. |
| `bytesWritten` | `ref int` | The number of bytes written to the output buffer. |

**Returns:** `bool`

`true` if the period was formatted successfully.

#### ParsePeriod `static`

```csharp
Period ParsePeriod(ReadOnlySpan<byte> text)
```

Parse a period from a UTF-8 encoded string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded string to parse. |

**Returns:** `Period`

The resulting period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Thrown when the text cannot be parsed as a valid period. |

#### TryParsePeriod `static`

```csharp
bool TryParsePeriod(ReadOnlySpan<byte> text, ref Period value)
```

Parse a period from a string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The string to parse. |
| `value` | `ref Period` | The resulting duration. |

**Returns:** `bool`

`true` if the duration could be parsed.

#### ParseLocalDate `static`

```csharp
LocalDate ParseLocalDate(ReadOnlySpan<byte> text)
```

Parse a local date from a UTF-8 encoded string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded string to parse. |

**Returns:** `LocalDate`

The resulting local date.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Thrown when the text cannot be parsed as a valid date. |

#### TryParseLocalDate `static`

```csharp
bool TryParseLocalDate(ReadOnlySpan<byte> text, ref LocalDate value)
```

Parse a date from a string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The string to parse. |
| `value` | `ref LocalDate` | The resulting date. |

**Returns:** `bool`

`true` if the date could be parsed.

#### ParseOffsetTime `static`

```csharp
OffsetTime ParseOffsetTime(ReadOnlySpan<byte> text)
```

Parse an offset time from a UTF-8 encoded string for the `time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded string to parse. |

**Returns:** `OffsetTime`

The resulting offset time.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Thrown when the text cannot be parsed as a valid time. |

#### TryParseOffsetTime `static`

```csharp
bool TryParseOffsetTime(ReadOnlySpan<byte> text, ref OffsetTime value)
```

Parse a time from a string for the `time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The string to parse. |
| `value` | `ref OffsetTime` | The resulting time. |

**Returns:** `bool`

`true` if the time could be parsed.

#### CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset time from its individual components including nanosecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | `int` | The hours component (0-23). |
| `minutes` | `int` | The minutes component (0-59). |
| `seconds` | `int` | The seconds component (0-59). |
| `milliseconds` | `int` | The milliseconds component (0-999). |
| `microseconds` | `int` | The microseconds component (0-999). |
| `nanoseconds` | `int` | The nanoseconds component (0-999). |
| `offsetSeconds` | `int` | The offset from UTC in seconds. |

**Returns:** `OffsetTime`

The constructed offset time.

#### CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset time from its individual components with millisecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | `int` | The hours component (0-23). |
| `minutes` | `int` | The minutes component (0-59). |
| `seconds` | `int` | The seconds component (0-59). |
| `milliseconds` | `int` | The milliseconds component (0-999). |
| `offsetSeconds` | `int` | The offset from UTC in seconds. |

**Returns:** `OffsetTime`

The constructed offset time.

#### ParseOffsetDateTime `static`

```csharp
OffsetDateTime ParseOffsetDateTime(ReadOnlySpan<byte> text)
```

Parse an offset date time from a UTF-8 encoded string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded string to parse. |

**Returns:** `OffsetDateTime`

The resulting offset date time.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Thrown when the text cannot be parsed as a valid date time. |

#### TryParseOffsetDateTime `static`

```csharp
bool TryParseOffsetDateTime(ReadOnlySpan<byte> text, ref OffsetDateTime value)
```

Parse a date time from a string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The string to parse. |
| `value` | `ref OffsetDateTime` | The resulting date time. |

**Returns:** `bool`

`true` if the date could be parsed.

#### CreateOffsetDateTimeCore `static`

```csharp
OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset date time from its individual components including nanosecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `year` | `int` | The year component. |
| `month` | `int` | The month component (1-12). |
| `day` | `int` | The day component (1-31). |
| `hours` | `int` | The hours component (0-23). |
| `minutes` | `int` | The minutes component (0-59). |
| `seconds` | `int` | The seconds component (0-59). |
| `milliseconds` | `int` | The milliseconds component (0-999). |
| `microseconds` | `int` | The microseconds component (0-999). |
| `nanoseconds` | `int` | The nanoseconds component (0-999). |
| `offsetSeconds` | `int` | The offset from UTC in seconds. |

**Returns:** `OffsetDateTime`

The constructed offset date time.

#### CreateOffsetDateTimeCore `static`

```csharp
OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset date time from its individual components with millisecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `year` | `int` | The year component. |
| `month` | `int` | The month component (1-12). |
| `day` | `int` | The day component (1-31). |
| `hours` | `int` | The hours component (0-23). |
| `minutes` | `int` | The minutes component (0-59). |
| `seconds` | `int` | The seconds component (0-59). |
| `milliseconds` | `int` | The milliseconds component (0-999). |
| `offsetSeconds` | `int` | The offset from UTC in seconds. |

**Returns:** `OffsetDateTime`

The constructed offset date time.

#### ParseOffsetDate `static`

```csharp
OffsetDate ParseOffsetDate(ReadOnlySpan<byte> text)
```

Parse an offset date from a UTF-8 encoded string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The UTF-8 encoded string to parse. |

**Returns:** `OffsetDate`

The resulting offset date.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.FormatException` | Thrown when the text cannot be parsed as a valid date. |

#### TryParseOffsetDate `static`

```csharp
bool TryParseOffsetDate(ReadOnlySpan<byte> text, ref OffsetDate value)
```

Parse a date time from a string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | `ReadOnlySpan<byte>` | The string to parse. |
| `value` | `ref OffsetDate` | The resulting date time. |

**Returns:** `bool`

`true` if the date could be parsed.

---

## JsonElementTensorHelpers (class)

```csharp
public static class JsonElementTensorHelpers
```

Helper methods for JSON element for conversion to tensors.

### Methods

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<long> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<long>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<long> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<long>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ulong> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<ulong>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ulong> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<ulong>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<int> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<int>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<int> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<int>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<uint> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<uint>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<uint> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<uint>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<short> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<short>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<short> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<short>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ushort> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<ushort>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ushort> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<ushort>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<sbyte> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<sbyte>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<sbyte> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<sbyte>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<byte> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<byte>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<byte> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<byte>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<double> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<double>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<double> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<double>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<float> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<float>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<float> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<float>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<decimal> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<decimal>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<decimal> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<decimal>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Int128> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<Int128>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Int128> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<Int128>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<UInt128> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<UInt128>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<UInt128> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<UInt128>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Half> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<Half>` |  |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

#### TryCopyArrayOfRankTo `static`

```csharp
bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Half> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document of the JSON array instance. |
| `parentDocumentIndex` | `int` | The parent document index of the JSON array instance. |
| `array` | `Span<Half>` | The target array. |
| `rank` | `int` | The rank of the array (e.g. [,] == rank 2, [,,,] == rank 3 etc.) |
| `written` | `ref int` | The number of values written. |

**Returns:** `bool`

`true` if it was able to copy the values to the target array, otherwise false.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.InvalidOperationException` | The element was not a JSON array of the target type and rank. |
| `System.FormatException` | An item in the array was not of the target numeric format. |

---

## JsonRegexOptions (enum)

```csharp
public enum JsonRegexOptions : IComparable, ISpanFormattable, IFormattable, IConvertible
```

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `None` `static` | `JsonRegexOptions` | Use default behavior. |
| `IgnoreCase` `static` | `JsonRegexOptions` | Use case-insensitive matching. |
| `Multiline` `static` | `JsonRegexOptions` | Use multiline mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string). |
| `ExplicitCapture` `static` | `JsonRegexOptions` | Do not capture unnamed groups. The only valid captures are explicitly named or numbered groups of the form (?<name> subexpression). |
| `Compiled` `static` | `JsonRegexOptions` | Compile the regular expression to Microsoft intermediate language (MSIL). |
| `Singleline` `static` | `JsonRegexOptions` | Use single-line mode, where the period (.) matches every character (instead of every character except \n). |
| `IgnorePatternWhitespace` `static` | `JsonRegexOptions` | Exclude unescaped white space from the pattern, and enable comments after a number sign (#). |
| `RightToLeft` `static` | `JsonRegexOptions` | Change the search direction. Search moves from right to left instead of from left to right. |
| `ECMAScript` `static` | `JsonRegexOptions` | Enable ECMAScript-compliant behavior for the expression. |
| `CultureInvariant` `static` | `JsonRegexOptions` | Ignore cultural differences in language. |
| `NonBacktracking` `static` | `JsonRegexOptions` | Enable matching using an approach that avoids backtracking and guarantees linear-time processing in the length of the input. |

---

## JsonSchemaContext (struct)

```csharp
public readonly struct JsonSchemaContext : IDisposable
```

The context for a JSON schema evaluation.

### Inheritance

- Implements: `IDisposable`

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsMatch` | `bool` | Gets a value indicating whether the context represents a match. |
| `HasCollector` | `bool` | Gets a value indicating whether this context has a [`IJsonSchemaResultsCollector`](#IJsonSchemaResultsCollector). |
| `RequiresEvaluationTracking` | `bool` | Gets a value indicating whether this context requires evaluation tracking. |

### Methods

#### BeginContext `static`

```csharp
JsonSchemaContext BeginContext<T>(T parentDocument, int parentDocumentIndex, bool usingEvaluatedItems, bool usingEvaluatedProperties, IJsonSchemaResultsCollector resultsCollector)
```

Begins a new JSON schema evaluation context for the specified document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON document. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `T` | The parent JSON document to evaluate. |
| `parentDocumentIndex` | `int` | The index within the parent document. |
| `usingEvaluatedItems` | `bool` | A value indicating whether to track evaluated items. |
| `usingEvaluatedProperties` | `bool` | A value indicating whether to track evaluated properties. |
| `resultsCollector` | `IJsonSchemaResultsCollector` | An optional results collector for gathering evaluation results. *(optional)* |

**Returns:** `JsonSchemaContext`

A new [`JsonSchemaContext`](#JsonSchemaContext) for the evaluation.

#### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Creates a new child context for schema evaluation with escaped property name tracking.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | `int` | The index of the parent element in the document. |
| `useEvaluatedItems` | `bool` | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | `bool` | Whether this child context should track evaluated object properties. |
| `escapedPropertyName` | `ReadOnlySpan<byte>` | The escaped property name for path tracking in validation results. |
| `evaluationPath` | `JsonSchemaPathProvider` | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | Optional provider for the full schema evaluation path. *(optional)* |

**Returns:** `JsonSchemaContext`

A new child context initialized for the specified element.

This method is part of the context lifecycle management system for JSON Schema validation. Child contexts inherit buffer space and configuration from their parent but maintain separate tracking for evaluated properties and items. The child context shares the same underlying buffer as the parent but uses a different offset to avoid conflicts. When the child context is committed via [`CommitChildContext`](#CommitChildContext), its results are merged back into the parent's validation results. Usage Pattern: ```csharp // Push child context for validating a property JsonSchemaContext childContext = parentContext.PushChildContext( document, propertyIndex, useItems: false, useProperties: true, propertyName); // Perform validation using child context bool isValid = ValidateProperty(ref childContext); // Commit results back to parent parentContext.CommitChildContext(isValid, ref childContext); ```

#### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, int itemIndex, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Creates a new child context for schema evaluation with item index tracking.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | `int` | The index of the parent element in the document. |
| `useEvaluatedItems` | `bool` | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | `bool` | Whether this child context should track evaluated object properties. |
| `itemIndex` | `int` | The item index for path tracking in validation results. |
| `evaluationPath` | `JsonSchemaPathProvider` | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | Optional provider for the full schema evaluation path. *(optional)* |

**Returns:** `JsonSchemaContext`

A new child context initialized for the specified element.

This method is part of the context lifecycle management system for JSON Schema validation. Child contexts inherit buffer space and configuration from their parent but maintain separate tracking for evaluated properties and items. The child context shares the same underlying buffer as the parent but uses a different offset to avoid conflicts. When the child context is committed via [`CommitChildContext`](#CommitChildContext), its results are merged back into the parent's validation results. Usage Pattern: ```csharp // Push child context for validating a property JsonSchemaContext childContext = parentContext.PushChildContext( document, propertyIndex, useItems: false, useProperties: true, propertyName); // Perform validation using child context bool isValid = ValidateProperty(ref childContext); // Commit results back to parent parentContext.CommitChildContext(isValid, ref childContext); ```

#### PushChildContextUnescaped

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath)
```

Creates a new child context for schema evaluation with unescaped property name tracking.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | `int` | The index of the parent element in the document. |
| `useEvaluatedItems` | `bool` | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | `bool` | Whether this child context should track evaluated object properties. |
| `unescapedPropertyName` | `ReadOnlySpan<byte>` | The unescaped property name for path tracking in validation results. |
| `evaluationPath` | `JsonSchemaPathProvider` | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | Optional provider for the full schema evaluation path. *(optional)* |

**Returns:** `JsonSchemaContext`

A new child context initialized for the specified element.

This is the unescaped variant of [`PushChildContext`](#PushChildContext). Use this method when the property name is already in unescaped form to avoid unnecessary processing overhead. The context lifecycle and buffer management behavior is identical to the escaped variant. The only difference is that the property name is passed directly to the results collector without additional escaping processing.

#### PushChildContext

```csharp
JsonSchemaContext PushChildContext<TProviderContext>(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> evaluationPath, JsonSchemaPathProvider<TProviderContext> schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath)
```

Creates a new child context for schema evaluation with typed provider context for path generation.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context used for path generation. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | `int` | The index of the parent element in the document. |
| `useEvaluatedItems` | `bool` | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | `bool` | Whether this child context should track evaluated object properties. |
| `providerContext` | `TProviderContext` | The typed context object passed to path provider delegates. |
| `evaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | Optional provider for the full schema evaluation path. *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider<TProviderContext>` | Optional provider for the document instance path. *(optional)* |

**Returns:** `JsonSchemaContext`

A new child context initialized for the specified element.

This overload provides strongly-typed context support for custom path providers. The `providerContext` is passed to each of the path provider delegates, allowing for stateful or computed path generation based on validation context. This is particularly useful for complex validation scenarios where path generation depends on runtime state, computed values, or external configuration.

#### PushChildContext

```csharp
JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties, JsonSchemaPathProvider evaluationPath, JsonSchemaPathProvider schemaEvaluationPath, JsonSchemaPathProvider documentEvaluationPath)
```

Creates a new child context for schema evaluation with optional path providers.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The JSON document containing the element being evaluated. |
| `parentDocumentIndex` | `int` | The index of the parent element in the document. |
| `useEvaluatedItems` | `bool` | Whether this child context should track evaluated array items. |
| `useEvaluatedProperties` | `bool` | Whether this child context should track evaluated object properties. |
| `evaluationPath` | `JsonSchemaPathProvider` | Optional provider for the reduced evaluation path in the schema. *(optional)* |
| `schemaEvaluationPath` | `JsonSchemaPathProvider` | Optional provider for the full schema evaluation path. *(optional)* |
| `documentEvaluationPath` | `JsonSchemaPathProvider` | Optional provider for the document instance path. *(optional)* |

**Returns:** `JsonSchemaContext`

A new child context initialized for the specified element.

This is the most flexible overload for child context creation, allowing custom path providers for all three path types: evaluation path, schema evaluation path, and document evaluation path. These paths are used for generating detailed validation error messages and tracing schema evaluation flow. Use this overload when you need full control over path generation without requiring a typed provider context object.

#### CommitChildContext

```csharp
void CommitChildContext<TProviderContext>(bool isMatch, ref JsonSchemaContext childContext, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Commits a child context back to its parent, merging validation results and cleaning up resources.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context used for message generation. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | Whether the parent validation succeeded. |
| `childContext` | `ref JsonSchemaContext` | The child context to commit (passed by readonly reference for performance). |
| `providerContext` | `TProviderContext` | The typed context object passed to the message provider. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | Optional provider for generating validation messages. *(optional)* |

This method completes the child context lifecycle by: - Merging validation results from the child into the results collector - Transferring ownership of shared buffer resources from child to parent - Updating the parent's match status based on both parent and child results - Generating validation messages using the provided message provider Important: This method does NOT automatically apply evaluated properties/items from the child context to the parent. Use [`ApplyEvaluated`](#ApplyEvaluated) separately if you need to merge evaluated tracking information. Performance Note: The child context is passed by readonly reference to avoid copying the entire struct. The buffer ownership transfer ensures proper resource management without requiring explicit disposal of the child context. Usage Pattern: ```csharp // After validation with child context bool childIsValid = ValidateWithChild(ref childContext); bool parentIsValid = parentContext.IsMatch && childIsValid; // Commit the child results parentContext.CommitChildContext(parentIsValid, ref childContext, contextData, messageProvider); // Optionally merge evaluated tracking if (needsEvaluatedTracking) { parentContext.ApplyEvaluated(ref childContext); } ```

#### CommitChildContext

```csharp
void CommitChildContext(bool isMatch, ref JsonSchemaContext childContext, JsonSchemaMessageProvider messageProvider)
```

Commits a child context back to its parent, merging validation results and cleaning up resources.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | Whether the parent validation succeeded. |
| `childContext` | `ref JsonSchemaContext` | The child context to commit (passed by readonly reference for performance). |
| `messageProvider` | `JsonSchemaMessageProvider` | Optional provider for generating validation messages. *(optional)* |

This is the non-generic overload of [`CommitChildContext`](#CommitChildContext). Use this method when you don't need typed provider context for message generation. The lifecycle management behavior is identical to the generic overload: - Validation results are merged into the results collector - Buffer ownership is transferred from child to parent - Parent match status is updated based on the provided `isMatch` value Typical Usage: Use this overload for simple validation scenarios where error messages don't require additional context beyond the standard validation paths.

#### EndContext

```csharp
void EndContext()
```

Ends the root evaluation context, committing any pending results to the results collector.

This method must be called after the root `Evaluate` completes to ensure that results written directly at the root level (e.g., `required` keyword failures) are committed to the results collector. Without this call, such results are orphaned because [`BeginContext`](#BeginContext) opens a child context on the collector that is never otherwise committed.

#### EvaluatedBooleanSchema

```csharp
void EvaluatedBooleanSchema(bool isMatch)
```

Records the evaluation of a boolean schema.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the boolean schema matched. |

#### EvaluatedKeyword

```csharp
void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | `JsonSchemaMessageProvider` | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | `ReadOnlySpan<byte>` | The unescaped keyword that was evaluated. |

#### EvaluatedKeyword

```csharp
void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | `ReadOnlySpan<byte>` | The unescaped keyword that was evaluated. |

#### EvaluatedKeywordForProperty

```csharp
void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword for a specific property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | `JsonSchemaMessageProvider` | An optional message provider for generating evaluation messages. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property being evaluated. |
| `unescapedKeyword` | `ReadOnlySpan<byte>` | The unescaped keyword that was evaluated. |

#### EvaluatedKeywordForProperty

```csharp
void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword for a specific property with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | An optional message provider for generating evaluation messages. |
| `propertyName` | `ReadOnlySpan<byte>` | The name of the property being evaluated. |
| `unescapedKeyword` | `ReadOnlySpan<byte>` | The unescaped keyword that was evaluated. |

#### EvaluatedKeywordPath

```csharp
void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | `JsonSchemaMessageProvider` | The message provider for generating evaluation messages. |
| `keywordPath` | `JsonSchemaPathProvider` | The path provider for the keyword being evaluated. |

#### EvaluatedKeywordPath

```csharp
void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | `bool` | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | The message provider for generating evaluation messages. |
| `keywordPath` | `JsonSchemaPathProvider<TProviderContext>` | The path provider for the keyword being evaluated. |

#### IgnoredKeyword

```csharp
void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Records that a keyword was ignored during schema evaluation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | `JsonSchemaMessageProvider` | An optional message provider for generating evaluation messages. |
| `encodedKeyword` | `ReadOnlySpan<byte>` | The encoded keyword that was ignored. |

#### IgnoredKeyword

```csharp
void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records that a keyword was ignored during schema evaluation with a provider context.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | `JsonSchemaMessageProvider<TProviderContext>` | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | `ReadOnlySpan<byte>` | The unescaped keyword that was ignored. |

#### PopChildContext

```csharp
void PopChildContext(ref JsonSchemaContext childContext)
```

Pops the most recently pushed child context without committing changes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `childContext` | `ref JsonSchemaContext` |  |

#### HasLocalEvaluatedItem

```csharp
bool HasLocalEvaluatedItem(int index)
```

Determines whether a specific item at the given index has been locally evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the item to check. |

**Returns:** `bool`

`true` if the item at the specified index has been locally evaluated; otherwise, `false`.

#### HasLocalEvaluatedProperty

```csharp
bool HasLocalEvaluatedProperty(int index)
```

Determines whether a specific property at the given index has been locally evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property to check. |

**Returns:** `bool`

`true` if the property at the specified index has been locally evaluated; otherwise, `false`.

#### HasLocalOrAppliedEvaluatedItem

```csharp
bool HasLocalOrAppliedEvaluatedItem(int index)
```

Determines whether a specific item at the given index has been either locally or applied evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the item to check. |

**Returns:** `bool`

`true` if the item at the specified index has been locally or applied evaluated; otherwise, `false`.

#### HasLocalOrAppliedEvaluatedProperty

```csharp
bool HasLocalOrAppliedEvaluatedProperty(int index)
```

Determines whether a specific property at the given index has been either locally or applied evaluated.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property to check. |

**Returns:** `bool`

`true` if the property at the specified index has been locally or applied evaluated; otherwise, `false`.

#### ApplyEvaluated

```csharp
void ApplyEvaluated(ref JsonSchemaContext childContext)
```

Applies the evaluated properties/items from the child context to this (parent) context, if appropriate.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `childContext` | `ref JsonSchemaContext` | The child context from which to apply evaluated properties/items |

#### Dispose

```csharp
void Dispose()
```

#### AddLocalEvaluatedItem

```csharp
void AddLocalEvaluatedItem(int index)
```

Adds an item at the specified index to the local evaluated items collection.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the item to mark as locally evaluated. |

#### AddLocalEvaluatedProperty

```csharp
void AddLocalEvaluatedProperty(int index)
```

Adds a property at the specified index to the local evaluated properties collection.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | `int` | The index of the property to mark as locally evaluated. |

### Nested Types

### JsonSchemaContext.EvaluatedIndexBuffer (struct)

```csharp
public readonly struct JsonSchemaContext.EvaluatedIndexBuffer
```

---

---

## JsonSchemaEvaluation (class)

```csharp
public static class JsonSchemaEvaluation
```

Support for JSON Schema matching implementations.

### Methods

#### MatchTypeNull `static`

```csharp
bool MatchTypeNull(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "null" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is null; otherwise, `false`.

#### MatchTypeBoolean `static`

```csharp
bool MatchTypeBoolean(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "boolean" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is a boolean; otherwise, `false`.

#### MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression, string originalExpressionString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `regularExpression` | `Regex` |  |
| `originalExpressionString` | `string` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchRegularExpression `static`

```csharp
bool MatchRegularExpression(ReadOnlySpan<byte> value, Regex regularExpression)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `regularExpression` | `Regex` |  |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchStringConstantValue `static`

```csharp
bool MatchStringConstantValue(ReadOnlySpan<byte> actual, ReadOnlySpan<byte> expected, string expectedString, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `actual` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `expected` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value expected. |
| `expectedString` | `string` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchLengthEquals `static`

```csharp
bool MatchLengthEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchLengthNotEquals `static`

```csharp
bool MatchLengthNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is not equal to the given value; otherwise, `false`.

#### MatchLengthGreaterThan `static`

```csharp
bool MatchLengthGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than the given value; otherwise, `false`.

#### MatchLengthGreaterThanOrEquals `static`

```csharp
bool MatchLengthGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than or equal to the given value; otherwise, `false`.

#### MatchLengthLessThan `static`

```csharp
bool MatchLengthLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than the given value; otherwise, `false`.

#### MatchLengthLessThanOrEquals `static`

```csharp
bool MatchLengthLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string length is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than or equal to the given value; otherwise, `false`.

#### MatchDate `static`

```csharp
bool MatchDate(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 date format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid ISO 8601 date; otherwise, `false`.

#### MatchDateTime `static`

```csharp
bool MatchDateTime(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 offset date-time format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid ISO 8601 offset date-time; otherwise, `false`.

#### MatchDuration `static`

```csharp
bool MatchDuration(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 duration format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid ISO 8601 duration; otherwise, `false`.

#### MatchEmail `static`

```csharp
bool MatchEmail(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid email address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid email address; otherwise, `false`.

#### MatchHostname `static`

```csharp
bool MatchHostname(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid hostname format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid hostname; otherwise, `false`.

#### MatchIdnEmail `static`

```csharp
bool MatchIdnEmail(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid internationalized domain name (IDN) email address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IDN email address; otherwise, `false`.

#### MatchIdnHostname `static`

```csharp
bool MatchIdnHostname(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid internationalized domain name (IDN) hostname format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IDN hostname; otherwise, `false`.

#### MatchIPV4 `static`

```csharp
bool MatchIPV4(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid IPv4 address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IPv4 address; otherwise, `false`.

#### MatchIPV6 `static`

```csharp
bool MatchIPV6(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid IPv6 address format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IPv6 address; otherwise, `false`.

#### MatchIri `static`

```csharp
bool MatchIri(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Internationalized Resource Identifier (IRI) format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IRI; otherwise, `false`.

#### MatchIriReference `static`

```csharp
bool MatchIriReference(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Internationalized Resource Identifier (IRI) reference format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid IRI reference; otherwise, `false`.

#### MatchJsonPointer `static`

```csharp
bool MatchJsonPointer(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid JSON Pointer format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid JSON Pointer; otherwise, `false`.

#### MatchRegex `static`

```csharp
bool MatchRegex(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid ECMAScript regular expression format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid regex; otherwise, `false`.

#### MatchRelativeJsonPointer `static`

```csharp
bool MatchRelativeJsonPointer(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid relative JSON Pointer format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid relative JSON Pointer; otherwise, `false`.

#### MatchTime `static`

```csharp
bool MatchTime(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value conforms to the ISO 8601 offset time format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid ISO 8601 offset time; otherwise, `false`.

#### MatchTypeString `static`

```csharp
bool MatchTypeString(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the string type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the token type matches the string type constraint; otherwise, `false`.

#### MatchUri `static`

```csharp
bool MatchUri(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid URI; otherwise, `false`.

#### MatchUriReference `static`

```csharp
bool MatchUriReference(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI reference format (absolute or relative URI).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid URI reference; otherwise, `false`.

#### MatchUriTemplate `static`

```csharp
bool MatchUriTemplate(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid URI template format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid URI template; otherwise, `false`.

#### MatchUuid `static`

```csharp
bool MatchUuid(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid UUID format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid UUID; otherwise, `false`.

#### MatchBase64String `static`

```csharp
bool MatchBase64String(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Base64-encoded string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid Base64-encoded string; otherwise, `false`.

#### MatchJsonContent `static`

```csharp
bool MatchJsonContent(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value contains valid JSON content.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is valid JSON content; otherwise, `false`.

#### MatchBase64Content `static`

```csharp
bool MatchBase64Content(ReadOnlySpan<byte> value, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a string value is a valid Base64-encoded JSON document.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlySpan<byte>` | The UTF-8 encoded string value to validate. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is a valid Base64-encoded JSON document; otherwise, `false`.

#### SchemaLocationForIndexedKeyword `static`

```csharp
bool SchemaLocationForIndexedKeyword(ReadOnlySpan<byte> keywordSchemaLocation, int index, Span<byte> buffer, ref int written)
```

Creates a schema location for an indexed keyword by appending the index to the base location.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `keywordSchemaLocation` | `ReadOnlySpan<byte>` | The base schema location for the keyword. |
| `index` | `int` | The index to append to the location. |
| `buffer` | `Span<byte>` | The buffer to write the resulting location to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### SchemaLocationForIndexedKeywordWithDependency `static`

```csharp
bool SchemaLocationForIndexedKeywordWithDependency(ReadOnlySpan<byte> keywordSchemaLocation, ReadOnlySpan<byte> dependencyName, int index, Span<byte> buffer, ref int written)
```

Creates a schema location for an indexed keyword by appending the index to the base location and dependency.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `keywordSchemaLocation` | `ReadOnlySpan<byte>` | The base schema location for the keyword. |
| `dependencyName` | `ReadOnlySpan<byte>` | The name of the dependency. |
| `index` | `int` | The index to append to the location. |
| `buffer` | `Span<byte>` | The buffer to write the resulting location to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### TryCopyMessage `static`

```csharp
bool TryCopyMessage(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy a message to the specified buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | `ReadOnlySpan<byte>` | The message to copy. |
| `buffer` | `Span<byte>` | The buffer to copy the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the copy succeeded; otherwise, `false`.

#### TryCopyPath `static`

```csharp
bool TryCopyPath(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, ref int written)
```

Tries to copy the path to the output buffer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `readOnlySpan` | `ReadOnlySpan<byte>` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

The path must be a fully canonical URI.

#### ExpectedType `static`

```csharp
bool ExpectedType(ReadOnlySpan<byte> typeName, Span<byte> buffer, ref int written)
```

Tries to write a message indicating the expected type for a value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `typeName` | `ReadOnlySpan<byte>` | The name of the expected type. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### ExpectedMultipleOfDivisor `static`

```csharp
bool ExpectedMultipleOfDivisor(string divisor, Span<byte> buffer, ref int written)
```

Tries to write a message indicating the expected type for a value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `divisor` | `string` | The integral part of the divisor. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### IgnoredUnrecognizedFormat `static`

```csharp
bool IgnoredUnrecognizedFormat(Span<byte> buffer, ref int written)
```

Tries to write a message indicating that the format was not recognized.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### IgnoredFormatNotAsserted `static`

```csharp
bool IgnoredFormatNotAsserted(Span<byte> buffer, ref int written)
```

Tries to write a message indicating that the format was not asserted.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### MatchTypeArray `static`

```csharp
bool MatchTypeArray(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "array" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is a start array; otherwise, `false`.

#### SchemaLocationForItemIndex `static`

```csharp
bool SchemaLocationForItemIndex(ReadOnlySpan<byte> arraySchemaLocation, int itemIndex, Span<byte> buffer, ref int written)
```

Writes the schema location for an item at a specific index in an array.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `arraySchemaLocation` | `ReadOnlySpan<byte>` | The base schema location for the array. |
| `itemIndex` | `int` | The index of the item within the array. |
| `buffer` | `Span<byte>` | The buffer to write the schema location to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the schema location was successfully written; otherwise, `false`.

#### ExpectedItemCountEqualsValue `static`

```csharp
bool ExpectedItemCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedItemCountNotEqualsValue `static`

```csharp
bool ExpectedItemCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedItemCountGreaterThanValue `static`

```csharp
bool ExpectedItemCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedItemCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedItemCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedItemCountLessThanValue `static`

```csharp
bool ExpectedItemCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedItemCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedItemCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### MatchItemCountEquals `static`

```csharp
bool MatchItemCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchItemCountNotEquals `static`

```csharp
bool MatchItemCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is not equal to the given value; otherwise, `false`.

#### MatchItemCountGreaterThan `static`

```csharp
bool MatchItemCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than the given value; otherwise, `false`.

#### MatchItemCountGreaterThanOrEquals `static`

```csharp
bool MatchItemCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than or equal to the given value; otherwise, `false`.

#### MatchItemCountLessThan `static`

```csharp
bool MatchItemCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than the given value; otherwise, `false`.

#### MatchItemCountLessThanOrEquals `static`

```csharp
bool MatchItemCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a item count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than or equal to the given value; otherwise, `false`.

#### ExpectedContainsCountEqualsValue `static`

```csharp
bool ExpectedContainsCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedContainsCountNotEqualsValue `static`

```csharp
bool ExpectedContainsCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedContainsCountGreaterThanValue `static`

```csharp
bool ExpectedContainsCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedContainsCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedContainsCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedContainsCountLessThanValue `static`

```csharp
bool ExpectedContainsCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedContainsCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedContainsCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### MatchContainsCountEquals `static`

```csharp
bool MatchContainsCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchContainsCountNotEquals `static`

```csharp
bool MatchContainsCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is not equal to the given value; otherwise, `false`.

#### MatchContainsCountGreaterThan `static`

```csharp
bool MatchContainsCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than the given value; otherwise, `false`.

#### MatchContainsCountGreaterThanOrEquals `static`

```csharp
bool MatchContainsCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than or equal to the given value; otherwise, `false`.

#### MatchContainsCountLessThan `static`

```csharp
bool MatchContainsCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than the given value; otherwise, `false`.

#### MatchContainsCountLessThanOrEquals `static`

```csharp
bool MatchContainsCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a contains count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than or equal to the given value; otherwise, `false`.

#### MatchTypeObject `static`

```csharp
bool MatchTypeObject(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "object" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is a start object; otherwise, `false`.

#### MatchPropertyCountEquals `static`

```csharp
bool MatchPropertyCountEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count equals the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is equal to the given value; otherwise, `false`.

#### MatchPropertyCountNotEquals `static`

```csharp
bool MatchPropertyCountNotEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count does not equal the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is not equal to the given value; otherwise, `false`.

#### MatchPropertyCountGreaterThan `static`

```csharp
bool MatchPropertyCountGreaterThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is greater than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than the given value; otherwise, `false`.

#### MatchPropertyCountGreaterThanOrEquals `static`

```csharp
bool MatchPropertyCountGreaterThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is greater than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is greater than or equal to the given value; otherwise, `false`.

#### MatchPropertyCountLessThan `static`

```csharp
bool MatchPropertyCountLessThan(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is less than the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than the given value; otherwise, `false`.

#### MatchPropertyCountLessThanOrEquals `static`

```csharp
bool MatchPropertyCountLessThanOrEquals(int expected, int actual, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Validates that a property count is less than or equal to the given value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expected` | `int` |  |
| `actual` | `int` |  |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The JSON schema validation context. |

**Returns:** `bool`

`true` if the value is less than or equal to the given value; otherwise, `false`.

#### ExpectedPropertyCountEqualsValue `static`

```csharp
bool ExpectedPropertyCountEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedPropertyCountNotEqualsValue `static`

```csharp
bool ExpectedPropertyCountNotEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedPropertyCountGreaterThanValue `static`

```csharp
bool ExpectedPropertyCountGreaterThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedPropertyCountGreaterThanOrEqualsValue `static`

```csharp
bool ExpectedPropertyCountGreaterThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedPropertyCountLessThanValue `static`

```csharp
bool ExpectedPropertyCountLessThanValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedPropertyCountLessThanOrEqualsValue `static`

```csharp
bool ExpectedPropertyCountLessThanOrEqualsValue(int value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `int` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### ExpectedMatchPatternPropertySchemaValue `static`

```csharp
bool ExpectedMatchPatternPropertySchemaValue(string expression, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a property name was intended to match a regular expression.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expression` | `string` | The regular expression that should be matched. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### ExpectedPropertyNameMatchesRegularExpressionValue `static`

```csharp
bool ExpectedPropertyNameMatchesRegularExpressionValue(string expression, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a property name was intended to match a regular expression.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `expression` | `string` | The regular expression that should be matched. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### ExpectedMatchesDependentSchemaValue `static`

```csharp
bool ExpectedMatchesDependentSchemaValue(string propertyName, Span<byte> buffer, ref int written)
```

Tries to write a message indicating that a value was expected to match a schema becaused it contained a specific named property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `string` | The name of the property that caused the schema to mat. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the operation succeeded; otherwise, `false`.

#### RequiredPropertyNotPresent `static`

```csharp
bool RequiredPropertyNotPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, ref int written)
```

Creates a message indicating that a required property is not present.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The name of the missing required property. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the message was successfully written; otherwise, `false`.

#### RequiredPropertyPresent `static`

```csharp
bool RequiredPropertyPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, ref int written)
```

Creates a message indicating that a required property is present.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | `ReadOnlySpan<byte>` | The name of the required property that is present. |
| `buffer` | `Span<byte>` | The buffer to write the message to. |
| `written` | `ref int` | The number of bytes written to the buffer. |

**Returns:** `bool`

`true` if the message was successfully written; otherwise, `false`.

#### MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `divisor` | `ulong` | The significand of the divisor represented as a [`UInt64`](#UInt64). |
| `divisorExponent` | `int` | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | `string` | The string representation of the divisor. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

#### MatchEquals `static`

```csharp
bool MatchEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number equals.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side equals the right hand side.

#### MatchNotEquals `static`

```csharp
bool MatchNotEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number not equals.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side does not equal the right hand side.

#### MatchLessThan `static`

```csharp
bool MatchLessThan(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number less than.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side is less than the right hand side.

#### MatchLessThanOrEquals `static`

```csharp
bool MatchLessThanOrEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number less than or equals.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side is less than or equal to the right hand side.

#### MatchGreaterThan `static`

```csharp
bool MatchGreaterThan(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number greater than.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side is less than the right hand side.

#### MatchGreaterThanOrEquals `static`

```csharp
bool MatchGreaterThanOrEquals(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent, string rightValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number greater than or equals.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | `bool` | Indicates whether the left hand side is negative. |
| `leftIntegral` | `ReadOnlySpan<byte>` | The integral part of the left hand side. |
| `leftFractional` | `ReadOnlySpan<byte>` | The fractional part of the left hand side. |
| `leftExponent` | `int` | The exponent of the left hand side. |
| `rightIsNegative` | `bool` | Indicates whether the right hand side is negative. |
| `rightIntegral` | `ReadOnlySpan<byte>` | The integral part of the right hand side. |
| `rightFractional` | `ReadOnlySpan<byte>` | The fractional part of the right hand side. |
| `rightExponent` | `int` | The exponent of the right hand side. |
| `rightValue` | `string` | The string representation of the right hand side. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the left hand side is less than or equal to the right hand side.

#### MatchMultipleOf `static`

```csharp
bool MatchMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent, string divisorValue, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number as a multiple of the given divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `divisor` | `BigInteger` | The significand of the divisor represented as a [`UInt64`](#UInt64). |
| `divisorExponent` | `int` | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |
| `divisorValue` | `string` | The string representation of the divisor. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation. The divisor is normalized so it provides the integral form of the divisor, with an appropriate exponent. Normalization means the the exponent is the minmax value for the divisor, and the divisor will not be divisible by 10.

#### MatchByte `static`

```csharp
bool MatchByte(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Byte type constraint, validating it as an 8-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Byte; otherwise, `false`.

#### MatchDecimal `static`

```csharp
bool MatchDecimal(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Decimal type constraint, validating it as a decimal floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Decimal; otherwise, `false`.

#### MatchDouble `static`

```csharp
bool MatchDouble(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Double type constraint, validating it as a double-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Double; otherwise, `false`.

#### MatchHalf `static`

```csharp
bool MatchHalf(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Half type constraint, validating it as a half-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Half; otherwise, `false`.

#### MatchInt128 `static`

```csharp
bool MatchInt128(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int128 type constraint, validating it as a 128-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Int128; otherwise, `false`.

#### MatchInt16 `static`

```csharp
bool MatchInt16(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int16 type constraint, validating it as a 16-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Int16; otherwise, `false`.

#### MatchInt32 `static`

```csharp
bool MatchInt32(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int32 type constraint, validating it as a 32-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Int32; otherwise, `false`.

#### MatchInt64 `static`

```csharp
bool MatchInt64(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Int64 type constraint, validating it as a 64-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Int64; otherwise, `false`.

#### MatchSByte `static`

```csharp
bool MatchSByte(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the SByte type constraint, validating it as an 8-bit signed integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid SByte; otherwise, `false`.

#### MatchSingle `static`

```csharp
bool MatchSingle(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the Single type constraint, validating it as a single-precision floating-point number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid Single; otherwise, `false`.

#### MatchTypeNumber `static`

```csharp
bool MatchTypeNumber(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
```

Matches a JSON token type against the "number" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is a number; otherwise, `false`.

#### MatchTypeInteger `static`

```csharp
bool MatchTypeInteger(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, int exponent, ref JsonSchemaContext context)
```

Matches a JSON token type against the "number" type constraint.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | `JsonTokenType` | The JSON token type to validate. |
| `typeKeyword` | `ReadOnlySpan<byte>` | The type keyword being evaluated. |
| `exponent` | `int` | The exponent of the number. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the token type is a number; otherwise, `false`.

#### MatchUInt128 `static`

```csharp
bool MatchUInt128(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt128 type constraint, validating it as a 128-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid UInt128; otherwise, `false`.

#### MatchUInt16 `static`

```csharp
bool MatchUInt16(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt16 type constraint, validating it as a 16-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid UInt16; otherwise, `false`.

#### MatchUInt32 `static`

```csharp
bool MatchUInt32(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt32 type constraint, validating it as a 32-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid UInt32; otherwise, `false`.

#### MatchUInt64 `static`

```csharp
bool MatchUInt64(bool isNegative, ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ReadOnlySpan<byte> keyword, ref JsonSchemaContext context)
```

Matches a JSON number against the UInt64 type constraint, validating it as a 64-bit unsigned integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` | Indicates whether the number is negative. |
| `integral` | `ReadOnlySpan<byte>` | The integral part of the number. |
| `fractional` | `ReadOnlySpan<byte>` | The fractional part of the number. |
| `exponent` | `int` | The exponent of the number. |
| `keyword` | `ReadOnlySpan<byte>` | The keyword being evaluated. |
| `context` | `ref JsonSchemaContext` | The schema validation context. |

**Returns:** `bool`

`true` if the number is a valid UInt64; otherwise, `false`.

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `IgnoredNotTypeNull` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedTypeNull` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedNull` `static` | `JsonSchemaMessageProvider` |  |
| `IgnoredNotTypeBoolean` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedTypeBoolean` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedBooleanTrue` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedBooleanFalse` `static` | `JsonSchemaMessageProvider` |  |
| `IgnoredNotTypeString` `static` | `JsonSchemaMessageProvider` | A message provider for ignored non-string type validation. |
| `ExpectedTypeString` `static` | `JsonSchemaMessageProvider` | A message provider for expected string type validation. |
| `ExpectedStringEquals` `static` | `JsonSchemaMessageProvider<string>` | A message provider for expected string constant validation. |
| `MatchedMoreThanOneSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when more than one schema matches in a composition constraint. |
| `MatchedNoSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when no schema matches in a composition constraint. |
| `MatchedAllSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when all schemas match in a composition constraint. |
| `DidNotMatchAllSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when all schemas do not match in a composition constraint. |
| `MatchedAtLeastOneSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when at least one schema matches in a composition constraint. |
| `MatchedExactlyOneSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when at least one schema matches in a composition constraint. |
| `DidNotMatchAtLeastOneSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when no schemas matched in a composition constraint. |
| `MatchedAtLeastOneConstantValue` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when at least one constant value matches in a composition constraint. |
| `DidNotMatchAtLeastOneConstantValue` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when no constant values matched in a composition constraint. |
| `DidNotMatchNotSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value (correctly) did not match a not schema in a composition constraint. |
| `MatchedNotSchema` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value (incorrectly) matched a not schema in a composition constraint. |
| `MatchedIfForThen` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value matches a binary or ternary if to go on to match a then clause. |
| `DidNotMatchThen` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value did not match the then clause for a binary or ternary if. |
| `MatchedThen` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value matches the corresponding then clause for a binary or ternary if. |
| `MatchedIfForElse` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value does not match a ternary if and so goes on to match an else clause. |
| `DidNotMatchElse` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value does not match a ternary if and then did not match the corresponding else clause. |
| `MatchedElse` `static` | `JsonSchemaMessageProvider` | Message provider for validation errors when a value matches the corresponding then clause for a binary or ternary if. |
| `ExpectedConstant` `static` | `JsonSchemaMessageProvider<string>` |  |
| `EvaluatedSubschema` `static` | `JsonSchemaMessageProvider` |  |
| `IgnoredNotTypeArray` `static` | `JsonSchemaMessageProvider` | Message provider for ignored "not array type" validation messages. |
| `ItemIndex` `static` | `JsonSchemaPathProvider<int>` | Provides a path provider for array item indices in JSON schema validation. |
| `ExpectedTypeArray` `static` | `JsonSchemaMessageProvider` | Message provider for expected "array type" validation messages. |
| `ExpectedUniqueItems` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedItemCountEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedItemCountNotEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedItemCountGreaterThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedItemCountGreaterThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedItemCountLessThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedItemCountLessThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountNotEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountGreaterThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountGreaterThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountLessThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedContainsCountLessThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `IgnoredNotTypeObject` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedTypeObject` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedPropertyCountEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedPropertyCountNotEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedPropertyCountGreaterThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedPropertyCountGreaterThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedPropertyCountLessThan` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedPropertyCountLessThanOrEquals` `static` | `JsonSchemaMessageProvider<int>` |  |
| `ExpectedMatchPatternPropertySchema` `static` | `JsonSchemaMessageProvider<string>` |  |
| `ExpectedPropertyNameMatchesRegularExpression` `static` | `JsonSchemaMessageProvider<string>` |  |
| `ExpectedPropertyNameMatchesSchema` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedPropertyMatchesFallbackSchema` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedMatchesDependentSchema` `static` | `JsonSchemaMessageProvider<string>` |  |
| `IgnoredNotTypeNumber` `static` | `JsonSchemaMessageProvider` |  |
| `IgnoredNotTypeInteger` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedTypeNumber` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedTypeInteger` `static` | `JsonSchemaMessageProvider` |  |
| `ExpectedMultipleOf` `static` | `JsonSchemaMessageProvider<string>` |  |
| `ExpectedEquals` `static` | `JsonSchemaMessageProvider<string>` |  |

---

## JsonSchemaMatcher (delegate)

```csharp
public delegate JsonSchemaMatcher : MulticastDelegate, ICloneable, ISerializable
```

A matcher for a JSON schema.

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaMatcher

```csharp
JsonSchemaMatcher(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
void Invoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonSchemaContext context, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref JsonSchemaContext` |  |
| `result` | `IAsyncResult` |  |

---

## JsonSchemaMatcherWithRequiredBitBuffer (delegate)

```csharp
public delegate JsonSchemaMatcherWithRequiredBitBuffer : MulticastDelegate, ICloneable, ISerializable
```

A matcher for a JSON schema that requires a bit buffer for tracking required properties.

### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

### Constructors

#### JsonSchemaMatcherWithRequiredBitBuffer

```csharp
JsonSchemaMatcherWithRequiredBitBuffer(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

### Methods

#### Invoke `virtual`

```csharp
void Invoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `requiredBitBuffer` | `Span<int>` |  |

#### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` |  |
| `parentDocumentIndex` | `int` |  |
| `context` | `ref JsonSchemaContext` |  |
| `requiredBitBuffer` | `Span<int>` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

#### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonSchemaContext context, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref JsonSchemaContext` |  |
| `result` | `IAsyncResult` |  |

---

## JsonTokenType (enum)

```csharp
public enum JsonTokenType : IComparable, ISpanFormattable, IFormattable, IConvertible
```

This enum defines the various JSON tokens that make up a JSON text and is used by the [`Utf8JsonReader`](#Utf8JsonReader) when moving from one token to the next. The [`Utf8JsonReader`](#Utf8JsonReader) starts at 'None' by default. The 'Comment' enum value is only ever reached in a specific [`Utf8JsonReader`](#Utf8JsonReader) mode and is not reachable by default.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `None` `static` | `JsonTokenType` | Indicates that there is no value (as distinct from [`Null`](#Null)). |
| `StartObject` `static` | `JsonTokenType` | Indicates that the token type is the start of a JSON object. |
| `EndObject` `static` | `JsonTokenType` | Indicates that the token type is the end of a JSON object. |
| `StartArray` `static` | `JsonTokenType` | Indicates that the token type is the start of a JSON array. |
| `EndArray` `static` | `JsonTokenType` | Indicates that the token type is the end of a JSON array. |
| `PropertyName` `static` | `JsonTokenType` | Indicates that the token type is a JSON property name. |
| `Comment` `static` | `JsonTokenType` | Indicates that the token type is the comment string. |
| `String` `static` | `JsonTokenType` | Indicates that the token type is a JSON string. |
| `Number` `static` | `JsonTokenType` | Indicates that the token type is a JSON number. |
| `True` `static` | `JsonTokenType` | Indicates that the token type is the JSON literal `true`. |
| `False` `static` | `JsonTokenType` | Indicates that the token type is the JSON literal `false`. |
| `Null` `static` | `JsonTokenType` | Indicates that the token type is the JSON literal `null`. |

---

## MetadataDb (struct)

```csharp
public readonly struct MetadataDb : IDisposable
```

Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements.

### Inheritance

- Implements: `IDisposable`

### Methods

#### Dispose

```csharp
void Dispose()
```

Releases resources used by the metadata database, returning rented arrays to the pool.

---

## NormalizedJsonNumber (struct)

```csharp
public readonly struct NormalizedJsonNumber
```

Represents a normalized JSON number.

### Constructors

#### NormalizedJsonNumber

```csharp
NormalizedJsonNumber(bool isNegative, byte[] integral, byte[] fractional, int exponent)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | `bool` |  |
| `integral` | `byte[]` |  |
| `fractional` | `byte[]` |  |
| `exponent` | `int` |  |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsNegative` | `bool` | Indicates whether the number is negative. |
| `Integral` | `ReadOnlySpan<byte>` | The normalized integral part of the original JSON representation of the number. |
| `Fractional` | `ReadOnlySpan<byte>` | The normalized fractional part of the original JSON representation of the number. |
| `Exponent` | `int` | The exponent to apply after concatenating the integral and fractional parts. |

---

## ObjectEnumerator (struct)

```csharp
public readonly struct ObjectEnumerator
```

An enumerable and enumerator for the properties of a JSON object.

### Constructors

#### ObjectEnumerator

```csharp
ObjectEnumerator(IJsonDocument targetDocument, int initialIndex)
```

Initializes a new instance of the [`ObjectEnumerator`](#ObjectEnumerator) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | `IJsonDocument` | The target document containing the object to enumerate. |
| `initialIndex` | `int` | The initial index of the object in the document. |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentIndex` | `int` | Gets the current index in the document. |

### Methods

#### Dispose

```csharp
void Dispose()
```

Releases resources used by the enumerator.

#### MoveNext

```csharp
bool MoveNext()
```

Advances the enumerator to the next element of the collection.

**Returns:** `bool`

`true` if the enumerator was successfully advanced to the next element; `false` if the enumerator has passed the end of the collection.

#### Reset

```csharp
void Reset()
```

Sets the enumerator to its initial position, which is before the first element.

---

## PropertySchemaMatchers<T> (class)

```csharp
public class PropertySchemaMatchers<T>
```

A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance.

### Remarks

This class uses a hash-based approach to enable O(1) average-case lookups of property matchers based on property names, while minimizing memory usage through array pooling and efficient data layout. The implementation includes a custom hash function, separate chaining for collision resolution, and optimized key comparison strategies to ensure fast lookups even in the presence of hash collisions.

### Constructors

#### PropertySchemaMatchers

```csharp
PropertySchemaMatchers(List<ValueTuple<PropertySchemaMatchers<T>.UnescapedNameProvider<T>, T>> matchers)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `matchers` | `List<ValueTuple<PropertySchemaMatchers<T>.UnescapedNameProvider<T>, T>>` |  |

### Methods

#### TryGetNamedMatcher

```csharp
bool TryGetNamedMatcher(ReadOnlySpan<byte> unescapedUtf8Name, ref T matcher)
```

Attempts to find the matcher for the named property value in the property map using efficient hash-based lookup.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unescapedUtf8Name` | `ReadOnlySpan<byte>` | The unescaped UTF-8 property name to search for. |
| `matcher` | `ref T` | When this method returns, contains the matcher, otherwise null. |

**Returns:** `bool`

`true` if the property was found; otherwise, `false`.

This method implements an efficient hash table lookup algorithm for property names in JSON objects. The lookup process follows these steps: 1. **Property Map Loading**: Reads the PropertyMap structure from the backing buffer to get metadata including bucket and entry offsets, counts, and sizes. 2. **Hash Calculation**: Computes a hash code for the target property name using an optimized algorithm that varies based on the property name length for maximum distribution. 3. **Bucket Selection**: Uses modulo operation to map the hash code to a specific bucket in the hash table, providing O(1) initial access. 4. **Chain Traversal**: Follows the linked chain of entries in the selected bucket: - Bucket values are 1-based, so the initial index is decremented - Each entry contains a Next field pointing to the next entry in the collision chain - Bounds checking prevents array access violations 5. **Hash and Key Comparison**: For each entry in the chain: - First compares hash codes for fast rejection of non-matches - For hash matches, performs optimized key comparison: * Short keys (< HashLength) with no hash collision bits can skip full comparison * Otherwise, retrieves the actual property name and performs byte-wise comparison 6. **Key Retrieval**: Property names are retrieved differently based on storage: - Simple properties: Read directly from the original JSON data - Escaped properties: Read from the dynamic value buffer after unescaping 7. **Collision Handling**: The algorithm includes safeguards against infinite loops by tracking collision count and ensuring it doesn't exceed the total entry count. This implementation provides O(1) average-case lookup performance with graceful handling of hash collisions through separate chaining, while minimizing memory allocations and cache misses through efficient data layout.

### Nested Types

### PropertySchemaMatchers<T>.UnescapedNameProvider<T> (delegate)

```csharp
public delegate PropertySchemaMatchers<T>.UnescapedNameProvider<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### PropertySchemaMatchers

```csharp
PropertySchemaMatchers(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
ReadOnlySpan<byte> Invoke()
```

**Returns:** `ReadOnlySpan<byte>`

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
ReadOnlySpan<byte> EndInvoke(IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `result` | `IAsyncResult` |  |

**Returns:** `ReadOnlySpan<byte>`

---

---

## RentedBacking (struct)

```csharp
public readonly struct RentedBacking : IDisposable
```

Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](#SimpleTypesBacking).

### Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

### Inheritance

- Implements: `IDisposable`

### Methods

#### Initialize `static`

```csharp
void Initialize<T>(ref RentedBacking backing, int minimumLength, ref T value, RentedBacking.Writer<T> writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `backing` | `ref RentedBacking` |  |
| `minimumLength` | `int` |  |
| `value` | `ref T` |  |
| `writer` | `RentedBacking.Writer<T>` |  |

#### Dispose

```csharp
void Dispose()
```

#### Span

```csharp
ReadOnlySpan<byte> Span()
```

Gets the written value as a span

**Returns:** `ReadOnlySpan<byte>`

The written value.

### Nested Types

### RentedBacking.Writer<T> (delegate)

```csharp
public delegate RentedBacking.Writer<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### RentedBacking.Writer

```csharp
RentedBacking.Writer(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(T value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(T value, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

---

---

## SimpleTypesBacking (struct)

```csharp
public readonly struct SimpleTypesBacking
```

Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](#IJsonElement) creation.

### Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

### Methods

#### Initialize `static`

```csharp
void Initialize<T>(ref SimpleTypesBacking backing, ref T value, SimpleTypesBacking.Writer<T> writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `backing` | `ref SimpleTypesBacking` |  |
| `value` | `ref T` |  |
| `writer` | `SimpleTypesBacking.Writer<T>` |  |

#### Span

```csharp
ReadOnlySpan<byte> Span()
```

Gets the written value as a span

**Returns:** `ReadOnlySpan<byte>`

The written value.

### Nested Types

### SimpleTypesBacking.Writer<T> (delegate)

```csharp
public delegate SimpleTypesBacking.Writer<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### SimpleTypesBacking.Writer

```csharp
SimpleTypesBacking.Writer(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(T value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(T value, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | `Span<byte>` |  |
| `written` | `ref int` |  |
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | `ref int` |  |
| `result` | `IAsyncResult` |  |

---

---

## UniqueItemsHashSet (struct)

```csharp
public readonly struct UniqueItemsHashSet : IDisposable
```

A map that can be built

### Remarks

This class uses a hash-based approach to enable O(1) average-case lookups of property matchers based on property names, while minimizing memory usage through array pooling and efficient data layout. The implementation includes a custom hash function, separate chaining for collision resolution, and optimized key comparison strategies to ensure fast lookups even in the presence of hash collisions.

### Inheritance

- Implements: `IDisposable`

### Constructors

#### UniqueItemsHashSet

```csharp
UniqueItemsHashSet(IJsonDocument parentDocument, int itemsCount, Span<int> buckets, Span<byte> entries)
```

Creates a validator map for efficient property lookup based on the provided matchers.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | `IJsonDocument` | The parent document for the unique items map. |
| `itemsCount` | `int` | The number of items to be added to the map. |
| `buckets` | `Span<int>` |  |
| `entries` | `Span<byte>` | A working buffer for the buckets. |

### Methods

#### AddItemIfNotExists

```csharp
bool AddItemIfNotExists(int parentDocumentIndex)
```

Adds the item identified by the parent document index to the map if it does not already exist, returning true if it was added and false if it already existed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | `int` | The index of the value in the document. |

**Returns:** `bool`

#### GetHashCode

```csharp
int GetHashCode(int documentIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `documentIndex` | `int` |  |

**Returns:** `int`

#### ValueEquals

```csharp
bool ValueEquals(int leftIndex, int rightIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIndex` | `int` |  |
| `rightIndex` | `int` |  |

**Returns:** `bool`

#### Dispose

```csharp
void Dispose()
```

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `StackAllocBucketSize` `static` | `int` | The recommended size for a stack allocated bucket buffer. |
| `StackAllocEntrySize` `static` | `int` | The recommended size for a stack allocated entries buffer. |

### Nested Types

### UniqueItemsHashSet.UnescapedNameProvider (delegate)

```csharp
public delegate UniqueItemsHashSet.UnescapedNameProvider : MulticastDelegate, ICloneable, ISerializable
```

#### Inheritance

- Inherits from: `MulticastDelegate`
- Implements: `ICloneable`
- Implements: `ISerializable`

#### Constructors

##### UniqueItemsHashSet.UnescapedNameProvider

```csharp
UniqueItemsHashSet.UnescapedNameProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | `object` |  |
| `method` | `IntPtr` |  |

#### Methods

##### Invoke `virtual`

```csharp
ReadOnlySpan<byte> Invoke()
```

**Returns:** `ReadOnlySpan<byte>`

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `callback` | `AsyncCallback` |  |
| `object` | `object` |  |

**Returns:** `IAsyncResult`

##### EndInvoke `virtual`

```csharp
ReadOnlySpan<byte> EndInvoke(IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `result` | `IAsyncResult` |  |

**Returns:** `ReadOnlySpan<byte>`

---

---

## Utf8UriComponents (enum)

```csharp
public enum Utf8UriComponents : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the parts of a URI that should be included when retrieving URI components.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Scheme` `static` | `Utf8UriComponents` | The scheme part of the URI. |
| `UserInfo` `static` | `Utf8UriComponents` | The user information part of the URI. |
| `Host` `static` | `Utf8UriComponents` | The host part of the URI. |
| `Port` `static` | `Utf8UriComponents` | The port part of the URI. |
| `Path` `static` | `Utf8UriComponents` | The path part of the URI. |
| `Query` `static` | `Utf8UriComponents` | The query part of the URI. |
| `Fragment` `static` | `Utf8UriComponents` | The fragment part of the URI. |
| `StrongPort` `static` | `Utf8UriComponents` | The port part of the URI, including default ports. |
| `NormalizedHost` `static` | `Utf8UriComponents` | The normalized host part of the URI. |
| `KeepDelimiter` `static` | `Utf8UriComponents` | This will also return respective delimiters for scheme, userinfo or port. Valid only for a single component requests. |
| `SerializationInfoString` `static` | `Utf8UriComponents` | This is used by GetObjectData and can also be used directly. Works for both absolute and relative URIs. |
| `AbsoluteUri` `static` | `Utf8UriComponents` | All components of an absolute URI. |
| `HostAndPort` `static` | `Utf8UriComponents` | The host and port components, including default ports. |
| `StrongAuthority` `static` | `Utf8UriComponents` | The user info, host, and port components, including default ports. |
| `SchemeAndServer` `static` | `Utf8UriComponents` | The scheme, host, and port components. |
| `HttpRequestUrl` `static` | `Utf8UriComponents` | The components typically used in HTTP request URLs. |
| `PathAndQuery` `static` | `Utf8UriComponents` | The path and query components. |

---

## Utf8UriFormat (enum)

```csharp
public enum Utf8UriFormat : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the format options for URI string representation.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `UriEscaped` `static` | `Utf8UriFormat` | The URI is represented with URI escaping applied. |
| `Unescaped` `static` | `Utf8UriFormat` | The URI is completely unescaped. |
| `SafeUnescaped` `static` | `Utf8UriFormat` | The URI is canonically unescaped, allowing the same URI to be reconstructed from the output. If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence. |

---

## Utf8UriKind (enum)

```csharp
public enum Utf8UriKind : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Defines the kind of URI, controlling whether absolute or relative URIs are used.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `RelativeOrAbsolute` `static` | `Utf8UriKind` | The kind of URI is indeterminate. The URI can be either relative or absolute. |
| `Absolute` `static` | `Utf8UriKind` | The URI is an absolute URI. |
| `Relative` `static` | `Utf8UriKind` | The URI is a relative URI. |

---

