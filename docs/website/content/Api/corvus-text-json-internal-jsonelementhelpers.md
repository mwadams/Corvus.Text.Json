---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers — Corvus.Text.Json.Internal"
---
```csharp
public static class JsonElementHelpers
```

Core helper methods for parsing and processing JSON numeric values into their component parts.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElementHelpers**

## Methods

### ParseNumber `static`

```csharp
void ParseNumber(ReadOnlySpan<byte> span, ref bool isNegative, ref ReadOnlySpan<byte> integral, ref ReadOnlySpan<byte> fractional, ref int exponent)
```

Parses a JSON number into its component parts using normal-form decimal representation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded span containing the JSON number to parse. |
| `isNegative` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | When this method returns, indicates whether the number is negative. |
| `integral` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the integral part of the number without leading zeros. |
| `fractional` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the fractional part of the number without trailing zeros. |
| `exponent` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the exponent value for scientific notation. |

The returned components use a normal-form decimal representation: Number := sign * <integral + fractional> * 10^exponent where integral and fractional are sequences of digits whose concatenation represents the significand of the number without leading or trailing zeros. Two such normal-form numbers are treated as equal if and only if they have equal signs, significands, and exponents.

### TryParseNumber `static`

```csharp
bool TryParseNumber(ReadOnlySpan<byte> span, ref bool isNegative, ref ReadOnlySpan<byte> integral, ref ReadOnlySpan<byte> fractional, ref int exponent)
```

Parses a JSON number into its component parts using normal-form decimal representation.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded span containing the JSON number to parse. |
| `isNegative` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | When this method returns, indicates whether the number is negative. |
| `integral` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the integral part of the number without leading zeros. |
| `fractional` | [`ref ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When this method returns, contains the fractional part of the number without trailing zeros. |
| `exponent` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the exponent value for scientific notation. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was parsed successfully, otherwise `false`.

The returned components use a normal-form decimal representation: Number := sign * <integral + fractional> * 10^exponent where integral and fractional are sequences of digits whose concatenation represents the significand of the number without leading or trailing zeros. Two such normal-form numbers are treated as equal if and only if they have equal signs, significands, and exponents.

### CompareNormalizedJsonNumbers `static`

```csharp
int CompareNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

Compares two normalized JSON numbers for equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True if the LHS is negative. |
| `leftIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `leftFractional` produces the significand of the LHS number without leading or trailing zeros. |
| `leftFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `leftIntegral` produces the significand of the LHS number without leading or trailing zeros. |
| `leftExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The LHS exponent. |
| `rightIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True if the RHS is negative. |
| `rightIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `rightFractional` produces the significand of the RHS number without leading or trailing zeros. |
| `rightFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `rightIntegral` produces the significand of the RHS number without leading or trailing zeros. |
| `rightExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The RHS exponent. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

-1 if the LHS is less than the RHS, 0 if the are equal, and 1 if the LHS is greater than the RHS.

### ParseValue `static`

```csharp
T ParseValue<T>(ReadOnlySpan<byte> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

**Returns:** `T`

A [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) representing the value (and nested values) read from the span.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the span. |

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

### ParseValue `static`

```csharp
T ParseValue<T>(ReadOnlySpan<char> span, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided span.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

**Returns:** `T`

A JsonElement representing the value (and nested values) read from the span.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the reader. |

This method makes a copy of the data the reader acted on, so there is no caller requirement to maintain data integrity beyond the return of this method.

### ParseValue `static`

```csharp
T ParseValue<T>(string text, JsonDocumentOptions options)
```

Parses one JSON value (including objects or arrays) from the provided text.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to read. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | The [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) for reading. *(optional)* |

**Returns:** `T`

A JsonElement representing the value (and nested values) read from the text.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | A value could not be read from the text. |

This method makes a copy of the data, so there is no caller requirement to maintain data integrity beyond the return of this method.

### ParseValue `static`

```csharp
T ParseValue<T>(ref Utf8JsonReader reader)
```

Parses one JSON value (including objects or arrays) from the provided reader.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) | The reader to read. |

**Returns:** `T`

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
bool TryParseValue<T>(ref Utf8JsonReader reader, ref Nullable<T> element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `reader` | [`ref Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) |  |
| `element` | [`ref Nullable<T>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### CountRunes `static`

```csharp
int CountRunes(ReadOnlySpan<byte> utf8String)
```

Count the runes in a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 string for which to count the runes. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of runes in the UTF-8 string.

### ParseDateCore `static`

```csharp
bool ParseDateCore(ReadOnlySpan<byte> text, ref int year, ref int month, ref int day)
```

Parses a date string in ISO 8601 format (YYYY-MM-DD) and extracts the year, month, and day components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the date string to parse. |
| `year` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the year component of the date. |
| `month` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the month component of the date (1-12). |
| `day` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the day component of the date (1-31). |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was successfully parsed; otherwise, `false`.

### ParseOffsetTimeCore `static`

```csharp
bool ParseOffsetTimeCore(ReadOnlySpan<byte> text, ref int hours, ref int minutes, ref int seconds, ref int milliseconds, ref int microseconds, ref int nanoseconds, ref int offsetSeconds)
```

Parses a time string with optional offset in ISO 8601 format and extracts the time and offset components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the time string to parse. |
| `hours` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the hours component of the time (0-23). |
| `minutes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the minutes component of the time (0-59). |
| `seconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the seconds component of the time (0-59). |
| `milliseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the milliseconds component of the time (0-999). |
| `microseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the microseconds component of the time (0-999). |
| `nanoseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the nanoseconds component of the time (0-999). |
| `offsetSeconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the timezone offset in seconds from UTC. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the time was successfully parsed; otherwise, `false`.

### ParseOffsetCore `static`

```csharp
bool ParseOffsetCore(ReadOnlySpan<byte> text, ref int offsetSeconds)
```

Parses a timezone offset string in ISO 8601 format (±HH:MM or Z) and extracts the offset in seconds.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the offset string to parse. |
| `offsetSeconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the timezone offset in seconds from UTC. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the offset was successfully parsed; otherwise, `false`.

### ParseTimeCore `static`

```csharp
bool ParseTimeCore(ReadOnlySpan<byte> text, ref int hours, ref int minutes, ref int seconds, ref int milliseconds, ref int microseconds, ref int nanoseconds)
```

Parses a time string in ISO 8601 format (HH:MM:SS[.nnnnnnnnn]) and extracts the time components.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text containing the time string to parse. |
| `hours` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the hours component of the time (0-23). |
| `minutes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the minutes component of the time (0-59). |
| `seconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the seconds component of the time (0-59). |
| `milliseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the milliseconds component of the time (0-999). |
| `microseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the microseconds component of the time (0-999). |
| `nanoseconds` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the nanoseconds component of the time (0-999). |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the time was successfully parsed; otherwise, `false`.

### SetPropertyUnsafe `static`

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
| `property` | [`JsonProperty<TValue>`](/api/corvus-text-json-jsonproperty-tvalue.html) | The property to set. |

### RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<char> propertyName)
```

Removes a property value from a target element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

### RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<byte> propertyName)
```

Removes a property value from a target element.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

### RemoveRangeUnsafe `static`

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
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The zero-based index at which to begin removing items. |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of items to remove. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html), or the element reference is stale due to document mutations. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

### RemoveFirstUnsafe `static`

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

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if an element was found and removed; otherwise, `false`.

### RemoveWhereUnsafe `static`

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
| `predicate` | [`JsonPredicate<T>`](/api/corvus-text-json-jsonpredicate-t.html) | The predicate to apply to each element to determine if it should be removed. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html), or the element reference is stale due to document mutations. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `startIndex` is negative or greater than the current array length, or `count` is negative or causes the operation to exceed the array bounds. |

### ApplyUnsafe `static`

```csharp
void ApplyUnsafe<TTarget, TSource>(TTarget targetElement, ref TSource sourceElement)
```

Applies all properties from a source JSON object element to a target JSON object element.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TTarget` | The type of the target element implementing [`IMutableJsonElement`](/api/corvus-text-json-internal-imutablejsonelement-t.html). |
| `TSource` | The type of the source element implementing [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetElement` | `TTarget` | The target JSON object element to which properties will be applied. |
| `sourceElement` | `ref TSource` | The source JSON object element from which properties will be copied. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The source element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html). |

This method performs a merge of properties from the source JSON object to the target JSON object. Each property from the source object is copied to the target object, replacing any existing properties with the same name. The source element must be a JSON object element. The target element is assumed to be valid and is not validated by this method. This method is not CLS-compliant due to its generic constraint requirements.

### ToValueKind `static`

```csharp
JsonValueKind ToValueKind(JsonTokenType tokenType)
```

Converts a [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) to its corresponding [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The token type to convert. |

**Returns:** [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html)

The corresponding value kind.

### GetUtf8StringLength `static`

```csharp
int GetUtf8StringLength(ReadOnlySpan<byte> span)
```

Gets the length of a UTF-8 encoded string in characters (not bytes).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded byte span. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of Unicode characters in the string.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the span contains invalid UTF-8 sequences. |

### GetParentDocumentAndIndex `static`

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

**Returns:** [`ValueTuple<IJsonDocument, int>`](https://learn.microsoft.com/dotnet/api/system.valuetuple-2)

A tuple containing the parent document and the document index.

### AreEqualJsonNumbers `static`

```csharp
bool AreEqualJsonNumbers(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
```

Compares two valid UTF-8 encoded JSON numbers for decimal equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `left` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded bytes representing the left JSON number. |
| `right` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded bytes representing the right JSON number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two JSON numbers are equal; otherwise, `false`.

### AreEqualNormalizedJsonNumbers `static`

```csharp
bool AreEqualNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
```

Compares two valid normalized JSON numbers for decimal equality.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the left number is negative. |
| `leftIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the left number without leading zeros. |
| `leftFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the left number without trailing zeros. |
| `leftExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the left number. |
| `rightIsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the right number is negative. |
| `rightIntegral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The integral part of the right number without leading zeros. |
| `rightFractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The fractional part of the right number without trailing zeros. |
| `rightExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the right number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two normalized JSON numbers are equal; otherwise, `false`.

### IsIntegerNormalizedJsonNumber `static`

```csharp
bool IsIntegerNormalizedJsonNumber(int exponent)
```

Determines if a JSON number is an integer.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number represents an integer.

### IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, ulong divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The significand of the divisor represented as a `UInt64`. |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

### IsMultipleOf `static`

```csharp
bool IsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int exponent, BigInteger divisor, int divisorExponent)
```

Determines whether the normalized JSON number is an exact multiple of the given integer divisor.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `fractional` produces the significand of the number without leading or trailing zeros. |
| `fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | When concatenated with `integral` produces the significand of the number without leading or trailing zeros. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the number. |
| `divisor` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The significand of the divisor represented as a `BigInteger`. |
| `divisorExponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent of the divisor. This will be non-zero if the divisor had a fractional component. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number is a multiple of the divisor (i.e. `n mod D == 0`).

We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.

### TryFormatNumberAsString `static`

```csharp
bool TryFormatNumberAsString(ReadOnlySpan<byte> span, ReadOnlySpan<char> format, IFormatProvider provider, ref string value)
```

Format the number as a string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 representation of the number. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format to apply. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The (optional) format provider. |
| `value` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | The result if formatting succeeds, otherwise `null`. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeds, otherwise `false`.

This will always return `false` if the formatted result exceeds 2048 characters in size.

### TryFormatNumber `static`

```csharp
bool TryFormatNumber(ReadOnlySpan<byte> span, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatNumber `static`

```csharp
bool TryFormatNumber(ReadOnlySpan<byte> span, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatUri `static`

```csharp
bool TryFormatUri(Utf8Uri uri, bool isDisplay, ref string result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatUri `static`

```csharp
bool TryFormatUri(Utf8Uri uri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`Utf8Uri`](/api/corvus-text-json-utf8uri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatUriReference `static`

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, ref string result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatUriReference `static`

```csharp
bool TryFormatUriReference(Utf8UriReference uriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatIri `static`

```csharp
bool TryFormatIri(Utf8Iri iri, bool isDisplay, ref string result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatIri `static`

```csharp
bool TryFormatIri(Utf8Iri iri, bool isDisplay, Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`Utf8Iri`](/api/corvus-text-json-utf8iri.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatIriReference `static`

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, ref string result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormatIriReference `static`

```csharp
bool TryFormatIriReference(Utf8IriReference iriReference, bool isDisplay, Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `isDisplay` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### DeepEquals `static`

```csharp
bool DeepEquals<TLeft, TRight>(ref TLeft element1, ref TRight element2)
```

Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |
| `TRight` | The type of the second [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |
| `element2` | `ref TRight` | The second [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

### DeepEqualsNoParentDocumentCheck `static`

```csharp
bool DeepEqualsNoParentDocumentCheck<TLeft>(ref TLeft element1, JsonTokenType element2TokenType, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `TLeft` | The type of the first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1` | `ref TLeft` | The first [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) to compare. |
| `element2TokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The token type of the second JSON element. |
| `element2ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the second JSON element within its parent document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

### DeepEqualsNoParentDocumentCheck `static`

```csharp
bool DeepEqualsNoParentDocumentCheck(IJsonDocument element1ParentDocument, int element1ParentDocumentIndex, IJsonDocument element2ParentDocument, int element2ParentDocumentIndex)
```

Compares the values of two JSON values for equality, including the values of all descendant elements.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element1ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the first JSON element. |
| `element1ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the first JSON element within its parent document. |
| `element2ParentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document containing the second JSON element. |
| `element2ParentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the second JSON element within its parent document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two values are equal; otherwise, `false`.

Deep equality of two JSON values is defined as follows: - JSON values of different kinds are not equal. - JSON constants `null`, `false`, and `true` only equal themselves. - JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used. - JSON strings are equal if and only if they are equal using ordinal string comparison. - JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal. - JSON objects are equal if and only if they have the same number of properties and each property in the first object has a corresponding property in the second object with the same name and equal value. The order of properties is not significant. Repeated properties are not supported, though they will resolve each value in the second instance to the last value in the first instance.

### TryFormatLocalDate `static`

```csharp
bool TryFormatLocalDate(ref LocalDate value, Span<byte> output, ref int bytesWritten)
```

Format a date as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref LocalDate` | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was formatted successfully.

### TryFormatOffsetDate `static`

```csharp
bool TryFormatOffsetDate(ref OffsetDate value, Span<byte> output, ref int bytesWritten)
```

Format a date as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDate` | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was formatted successfully.

### TryFormatOffsetDateTime `static`

```csharp
bool TryFormatOffsetDateTime(ref OffsetDateTime value, Span<byte> output, ref int bytesWritten)
```

Format an offset date time as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetDateTime` | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date was formatted successfully.

### TryFormatOffsetTime `static`

```csharp
bool TryFormatOffsetTime(ref OffsetTime value, Span<byte> output, ref int bytesWritten)
```

Format a time as a UTF-8 string.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref OffsetTime` | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the time was formatted successfully.

### TryFormatPeriod `static`

```csharp
bool TryFormatPeriod(ref Period value, Span<byte> output, ref int bytesWritten)
```

Format a period as a UTF-8 string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The value to format. |
| `output` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The output buffer. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the output buffer. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the period was formatted successfully.

### ParsePeriod `static`

```csharp
Period ParsePeriod(ReadOnlySpan<byte> text)
```

Parse a period from a UTF-8 encoded string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

**Returns:** [`Period`](/api/corvus-text-json-period.html)

The resulting period.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid period. |

### TryParsePeriod `static`

```csharp
bool TryParsePeriod(ReadOnlySpan<byte> text, ref Period value)
```

Parse a period from a string for the `duration` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The resulting duration. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the duration could be parsed.

### ParseLocalDate `static`

```csharp
LocalDate ParseLocalDate(ReadOnlySpan<byte> text)
```

Parse a local date from a UTF-8 encoded string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

**Returns:** `LocalDate`

The resulting local date.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid date. |

### TryParseLocalDate `static`

```csharp
bool TryParseLocalDate(ReadOnlySpan<byte> text, ref LocalDate value)
```

Parse a date from a string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | `ref LocalDate` | The resulting date. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date could be parsed.

### ParseOffsetTime `static`

```csharp
OffsetTime ParseOffsetTime(ReadOnlySpan<byte> text)
```

Parse an offset time from a UTF-8 encoded string for the `time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

**Returns:** `OffsetTime`

The resulting offset time.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid time. |

### TryParseOffsetTime `static`

```csharp
bool TryParseOffsetTime(ReadOnlySpan<byte> text, ref OffsetTime value)
```

Parse a time from a string for the `time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | `ref OffsetTime` | The resulting time. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the time could be parsed.

### CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset time from its individual components including nanosecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `microseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The microseconds component (0-999). |
| `nanoseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The nanoseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

**Returns:** `OffsetTime`

The constructed offset time.

### CreateOffsetTimeCore `static`

```csharp
OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset time from its individual components with millisecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

**Returns:** `OffsetTime`

The constructed offset time.

### ParseOffsetDateTime `static`

```csharp
OffsetDateTime ParseOffsetDateTime(ReadOnlySpan<byte> text)
```

Parse an offset date time from a UTF-8 encoded string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

**Returns:** `OffsetDateTime`

The resulting offset date time.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid date time. |

### TryParseOffsetDateTime `static`

```csharp
bool TryParseOffsetDateTime(ReadOnlySpan<byte> text, ref OffsetDateTime value)
```

Parse a date time from a string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | `ref OffsetDateTime` | The resulting date time. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date could be parsed.

### CreateOffsetDateTimeCore `static`

```csharp
OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
```

Creates an offset date time from its individual components including nanosecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The year component. |
| `month` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The month component (1-12). |
| `day` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The day component (1-31). |
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `microseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The microseconds component (0-999). |
| `nanoseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The nanoseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

**Returns:** `OffsetDateTime`

The constructed offset date time.

### CreateOffsetDateTimeCore `static`

```csharp
OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
```

Creates an offset date time from its individual components with millisecond precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The year component. |
| `month` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The month component (1-12). |
| `day` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The day component (1-31). |
| `hours` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The hours component (0-23). |
| `minutes` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minutes component (0-59). |
| `seconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The seconds component (0-59). |
| `milliseconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The milliseconds component (0-999). |
| `offsetSeconds` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The offset from UTC in seconds. |

**Returns:** `OffsetDateTime`

The constructed offset date time.

### ParseOffsetDate `static`

```csharp
OffsetDate ParseOffsetDate(ReadOnlySpan<byte> text)
```

Parse an offset date from a UTF-8 encoded string for the `date` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

**Returns:** `OffsetDate`

The resulting offset date.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid date. |

### TryParseOffsetDate `static`

```csharp
bool TryParseOffsetDate(ReadOnlySpan<byte> text, ref OffsetDate value)
```

Parse a date time from a string for the `date-time` format.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | `ref OffsetDate` | The resulting date time. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the date could be parsed.

