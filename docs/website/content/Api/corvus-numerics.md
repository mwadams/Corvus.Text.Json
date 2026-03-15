---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Numerics Namespace"
---
# Corvus.Numerics Namespace

| Type | Kind | Description |
|------|------|-------------|
| [BigNumber](#bignumber) | struct | Represents an arbitrary-precision decimal number using a significand and exponent. |

## BigNumber (struct)

```csharp
public readonly struct BigNumber : IEquatable<BigNumber>, IComparable<BigNumber>, IComparable, IFormattable, ISpanFormattable, IUtf8SpanFormattable, INumber<BigNumber>, IParsable<BigNumber>, ISpanParsable<BigNumber>, IAdditionOperators<BigNumber, BigNumber, BigNumber>, IAdditiveIdentity<BigNumber, BigNumber>, IComparisonOperators<BigNumber, BigNumber, bool>, IEqualityOperators<BigNumber, BigNumber, bool>, IDecrementOperators<BigNumber>, IDivisionOperators<BigNumber, BigNumber, BigNumber>, IIncrementOperators<BigNumber>, IModulusOperators<BigNumber, BigNumber, BigNumber>, IMultiplicativeIdentity<BigNumber, BigNumber>, IMultiplyOperators<BigNumber, BigNumber, BigNumber>, INumberBase<BigNumber>, IUtf8SpanParsable<BigNumber>, ISubtractionOperators<BigNumber, BigNumber, BigNumber>, IUnaryNegationOperators<BigNumber, BigNumber>, IUnaryPlusOperators<BigNumber, BigNumber>, ISignedNumber<BigNumber>
```

Represents an arbitrary-precision decimal number using a significand and exponent.

### Remarks

Internally represented as: value = significand × 10^exponent where significand is a [`BigInteger`](#BigInteger) and exponent is a [`Int32`](#Int32). This type provides equivalent functionality to [`Decimal`](#Decimal) but with arbitrary precision, similar to how [`BigInteger`](#BigInteger) extends integer arithmetic beyond fixed sizes.

### Inheritance

- Implements: `IEquatable<BigNumber>`
- Implements: `IComparable<BigNumber>`
- Implements: `IComparable`
- Implements: `IFormattable`
- Implements: `ISpanFormattable`
- Implements: `IUtf8SpanFormattable`
- Implements: `INumber<BigNumber>`
- Implements: `IParsable<BigNumber>`
- Implements: `ISpanParsable<BigNumber>`
- Implements: `IAdditionOperators<BigNumber, BigNumber, BigNumber>`
- Implements: `IAdditiveIdentity<BigNumber, BigNumber>`
- Implements: `IComparisonOperators<BigNumber, BigNumber, bool>`
- Implements: `IEqualityOperators<BigNumber, BigNumber, bool>`
- Implements: `IDecrementOperators<BigNumber>`
- Implements: `IDivisionOperators<BigNumber, BigNumber, BigNumber>`
- Implements: `IIncrementOperators<BigNumber>`
- Implements: `IModulusOperators<BigNumber, BigNumber, BigNumber>`
- Implements: `IMultiplicativeIdentity<BigNumber, BigNumber>`
- Implements: `IMultiplyOperators<BigNumber, BigNumber, BigNumber>`
- Implements: `INumberBase<BigNumber>`
- Implements: `IUtf8SpanParsable<BigNumber>`
- Implements: `ISubtractionOperators<BigNumber, BigNumber, BigNumber>`
- Implements: `IUnaryNegationOperators<BigNumber, BigNumber>`
- Implements: `IUnaryPlusOperators<BigNumber, BigNumber>`
- Implements: `ISignedNumber<BigNumber>`

### Constructors

#### BigNumber

```csharp
BigNumber(BigInteger significand, int exponent)
```

Initializes a new instance of the [`BigNumber`](#BigNumber) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `significand` | `BigInteger` | The significand. |
| `exponent` | `int` | The exponent (power of 10). |

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Significand` | `BigInteger` | Gets the significand of the number. |
| `Exponent` | `int` | Gets the exponent (power of 10) of the number. |
| `Zero` `static` | `BigNumber` | Gets a value representing zero. |
| `One` `static` | `BigNumber` | Gets a value representing one. |
| `MinusOne` `static` | `BigNumber` | Gets a value representing minus one. |
| `Radix` `static` | `int` | Gets the radix (base) of the number system. |

### Methods

#### Normalize

```csharp
BigNumber Normalize()
```

Returns a normalized copy of this number with trailing zeros removed from the significand.

**Returns:** `BigNumber`

A normalized [`BigNumber`](#BigNumber).

#### IsInteger

```csharp
bool IsInteger()
```

Determines whether this instance represents an integer value.

**Returns:** `bool`

`true` if the value is an integer; otherwise, `false`.

#### Equals

```csharp
bool Equals(BigNumber other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `BigNumber` |  |

**Returns:** `bool`

#### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `bool`

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** `int`

#### CompareTo

```csharp
int CompareTo(BigNumber other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | `BigNumber` |  |

**Returns:** `int`

#### CompareTo

```csharp
int CompareTo(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `int`

#### ToString `virtual`

```csharp
string ToString()
```

**Returns:** `string`

#### ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `format` | `string` |  |
| `formatProvider` | `IFormatProvider` |  |

**Returns:** `string`

#### TryGetMinimumFormatBufferLength

```csharp
bool TryGetMinimumFormatBufferLength(ref int minimumLength)
```

Gets the minimum format buffer length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minimumLength` | `ref int` | The minimum length for a text buffer to format the number. |

**Returns:** `bool`

`true` if the buffer length required for the number can be safely allocated.

#### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormat

```csharp
bool TryFormat(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |
| `format` | `ReadOnlySpan<char>` |  |
| `provider` | `IFormatProvider` |  |

**Returns:** `bool`

#### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` |  |
| `charsWritten` | `ref int` |  |

**Returns:** `bool`

#### TryFormat

```csharp
bool TryFormat(Span<byte> destination, ref int bytesWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<byte>` |  |
| `bytesWritten` | `ref int` |  |

**Returns:** `bool`

#### Parse `static`

```csharp
BigNumber Parse(string s, IFormatProvider provider)
```

Parses a string into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `string` | The string to parse. |
| `provider` | `IFormatProvider` | Format provider. *(optional)* |

**Returns:** `BigNumber`

The parsed number.

#### Parse `static`

```csharp
BigNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
```

Parses a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<char>` | The span to parse. |
| `style` | `NumberStyles` | Number styles. *(optional)* |
| `provider` | `IFormatProvider` | Format provider. *(optional)* |

**Returns:** `BigNumber`

The parsed number.

#### TryParse `static`

```csharp
bool TryParse(string s, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `string` | The string to parse. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(string s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `string` | The string to parse. |
| `provider` | `IFormatProvider` | Format provider. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<char>` | The span to parse. |
| `provider` | `IFormatProvider` | Format provider. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<char>` | The span to parse. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<byte>` | The span to parse. |
| `provider` | `IFormatProvider` | Format provider. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<byte>` | The span to parse. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | `ReadOnlySpan<char>` | The span to parse. |
| `style` | `NumberStyles` | Number styles. |
| `provider` | `IFormatProvider` | Format provider. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### Parse `static`

```csharp
BigNumber Parse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider)
```

Parses UTF-8 bytes into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` | The UTF-8 bytes to parse. |
| `style` | `NumberStyles` | Number styles. *(optional)* |
| `provider` | `IFormatProvider` | Format provider. *(optional)* |

**Returns:** `BigNumber`

The parsed number.

#### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse UTF-8 bytes into a [`BigNumber`](#BigNumber).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | `ReadOnlySpan<byte>` | The UTF-8 bytes to parse. |
| `style` | `NumberStyles` | Number styles. |
| `provider` | `IFormatProvider` | Format provider. |
| `result` | `ref BigNumber` | The parsed number. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

#### Divide `static`

```csharp
BigNumber Divide(BigNumber dividend, BigNumber divisor, int precision)
```

Divides one [`BigNumber`](#BigNumber) by another with specified precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `dividend` | `BigNumber` | The dividend. |
| `divisor` | `BigNumber` | The divisor. |
| `precision` | `int` | The number of decimal places of precision. |

**Returns:** `BigNumber`

The quotient.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.DivideByZeroException` | Thrown when divisor is zero. |
| `System.ArgumentOutOfRangeException` | Thrown when precision is negative. |

#### Abs `static`

```csharp
BigNumber Abs(BigNumber value)
```

Returns the absolute value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` |  |

**Returns:** `BigNumber`

#### Sign `static`

```csharp
int Sign(BigNumber value)
```

Returns the sign of the number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value. |

**Returns:** `int`

-1 for negative, 0 for zero, 1 for positive.

#### Pow `static`

```csharp
BigNumber Pow(BigNumber value, int exponent)
```

Raises a BigNumber to an integer power.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The base value. |
| `exponent` | `int` | The integer exponent. |

**Returns:** `BigNumber`

The value raised to the specified power.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentOutOfRangeException` | Thrown when exponent is negative. |

#### Sqrt `static`

```csharp
BigNumber Sqrt(BigNumber value, int precision)
```

Computes the square root of a BigNumber using Newton's method.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value to find the square root of. |
| `precision` | `int` | The number of decimal places of precision. |

**Returns:** `BigNumber`

The square root.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentException` | Thrown when value is negative. |
| `System.ArgumentOutOfRangeException` | Thrown when precision is negative. |

#### Round `static`

```csharp
BigNumber Round(BigNumber value, int decimals, MidpointRounding mode)
```

Rounds a value to a specified number of decimal places.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value to round. |
| `decimals` | `int` | The number of decimal places. |
| `mode` | `MidpointRounding` | The rounding mode. *(optional)* |

**Returns:** `BigNumber`

The rounded value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| `System.ArgumentOutOfRangeException` | Thrown when decimals is negative. |

#### Floor `static`

```csharp
BigNumber Floor(BigNumber value)
```

Returns the largest integer less than or equal to the specified number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value to floor. |

**Returns:** `BigNumber`

The floor of the value.

#### Ceiling `static`

```csharp
BigNumber Ceiling(BigNumber value)
```

Returns the smallest integer greater than or equal to the specified number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value to ceiling. |

**Returns:** `BigNumber`

The ceiling of the value.

#### Truncate `static`

```csharp
BigNumber Truncate(BigNumber value)
```

Truncates a value to an integer by removing the fractional part.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `BigNumber` | The value to truncate. |

**Returns:** `BigNumber`

The truncated value.

#### TryFormatOptimized

```csharp
bool TryFormatOptimized(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

Tries to format this instance into the provided UTF-16 span with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | `Span<char>` | The destination span. |
| `charsWritten` | `ref int` | The number of characters written. |
| `format` | `ReadOnlySpan<char>` | The format string. |
| `provider` | `IFormatProvider` | The format provider. |

**Returns:** `bool`

`true` if formatting succeeded; otherwise, `false`.

#### TryFormatUtf8Optimized

```csharp
bool TryFormatUtf8Optimized(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

Tries to format this instance into the provided UTF-8 span with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | `Span<byte>` | The destination span. |
| `bytesWritten` | `ref int` | The number of bytes written. |
| `format` | `ReadOnlySpan<char>` | The format string. |
| `provider` | `IFormatProvider` | The format provider. |

**Returns:** `bool`

`true` if formatting succeeded; otherwise, `false`.

#### TryParseJsonUtf8 `static`

```csharp
bool TryParseJsonUtf8(ReadOnlySpan<byte> utf8Source, ref BigNumber result)
```

Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Source` | `ReadOnlySpan<byte>` | The UTF-8 bytes to parse. |
| `result` | `ref BigNumber` | The parsed BigNumber. |

**Returns:** `bool`

`true` if parsing succeeded; otherwise, `false`.

This method is optimized for parsing JSON-formatted numbers with InvariantCulture semantics. It expects input in formats like: "123", "-456", "1234E-3", "1234E2", "0". The method parses directly from UTF-8 bytes without conversion to chars, maintaining zero heap allocations for typical numbers.

---

