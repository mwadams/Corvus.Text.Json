---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber — Corvus.Numerics"
---
```csharp
public readonly struct BigNumber : IEquatable<BigNumber>, IComparable<BigNumber>, IComparable, IFormattable, ISpanFormattable, IUtf8SpanFormattable, INumber<BigNumber>, IParsable<BigNumber>, ISpanParsable<BigNumber>, IAdditionOperators<BigNumber, BigNumber, BigNumber>, IAdditiveIdentity<BigNumber, BigNumber>, IComparisonOperators<BigNumber, BigNumber, bool>, IEqualityOperators<BigNumber, BigNumber, bool>, IDecrementOperators<BigNumber>, IDivisionOperators<BigNumber, BigNumber, BigNumber>, IIncrementOperators<BigNumber>, IModulusOperators<BigNumber, BigNumber, BigNumber>, IMultiplicativeIdentity<BigNumber, BigNumber>, IMultiplyOperators<BigNumber, BigNumber, BigNumber>, INumberBase<BigNumber>, IUtf8SpanParsable<BigNumber>, ISubtractionOperators<BigNumber, BigNumber, BigNumber>, IUnaryNegationOperators<BigNumber, BigNumber>, IUnaryPlusOperators<BigNumber, BigNumber>, ISignedNumber<BigNumber>
```

Represents an arbitrary-precision decimal number using a significand and exponent.

## Remarks

Internally represented as: value = significand × 10^exponent where significand is a `BigInteger` and exponent is a `Int32`. This type provides equivalent functionality to `Decimal` but with arbitrary precision, similar to how `BigInteger` extends integer arithmetic beyond fixed sizes.

## Implements

[`IEquatable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1), [`IComparable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.icomparable-1), [`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable), [`INumber<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.inumber-1), [`IParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iparsable-1), [`ISpanParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.ispanparsable-1), [`IAdditionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iadditionoperators-3), [`IAdditiveIdentity<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iadditiveidentity-2), [`IComparisonOperators<BigNumber, BigNumber, bool>`](https://learn.microsoft.com/dotnet/api/system.numerics.icomparisonoperators-3), [`IEqualityOperators<BigNumber, BigNumber, bool>`](https://learn.microsoft.com/dotnet/api/system.numerics.iequalityoperators-3), [`IDecrementOperators<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.idecrementoperators-1), [`IDivisionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.idivisionoperators-3), [`IIncrementOperators<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iincrementoperators-1), [`IModulusOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imodulusoperators-3), [`IMultiplicativeIdentity<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imultiplicativeidentity-2), [`IMultiplyOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imultiplyoperators-3), [`INumberBase<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.inumberbase-1), [`IUtf8SpanParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iutf8spanparsable-1), [`ISubtractionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.isubtractionoperators-3), [`IUnaryNegationOperators<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iunarynegationoperators-2), [`IUnaryPlusOperators<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iunaryplusoperators-2), [`ISignedNumber<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.isignednumber-1)

## Constructors

### BigNumber

```csharp
BigNumber(BigInteger significand, int exponent)
```

Initializes a new instance of the [`BigNumber`](/api/corvus-numerics-bignumber.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `significand` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The significand. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent (power of 10). |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Significand` | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | Gets the significand of the number. |
| `Exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the exponent (power of 10) of the number. |
| `Zero` `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing zero. |
| `One` `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing one. |
| `MinusOne` `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing minus one. |
| `Radix` `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the radix (base) of the number system. |

## Methods

### Normalize

```csharp
BigNumber Normalize()
```

Returns a normalized copy of this number with trailing zeros removed from the significand.

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

A normalized [`BigNumber`](/api/corvus-numerics-bignumber.html).

### IsInteger

```csharp
bool IsInteger()
```

Determines whether this instance represents an integer value.

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is an integer; otherwise, `false`.

### Equals

```csharp
bool Equals(BigNumber other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | [`BigNumber`](/api/corvus-numerics-bignumber.html) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### CompareTo

```csharp
int CompareTo(BigNumber other)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `other` | [`BigNumber`](/api/corvus-numerics-bignumber.html) |  |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### CompareTo

```csharp
int CompareTo(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### ToString `virtual`

```csharp
string ToString()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

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

### TryGetMinimumFormatBufferLength

```csharp
bool TryGetMinimumFormatBufferLength(ref int minimumLength)
```

Gets the minimum format buffer length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `minimumLength` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minimum length for a text buffer to format the number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the buffer length required for the number can be safely allocated.

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

### TryFormat

```csharp
bool TryFormat(Span<char> destination, ref int charsWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormat

```csharp
bool TryFormat(Span<byte> destination, ref int bytesWritten)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Parse `static`

```csharp
BigNumber Parse(string s, IFormatProvider provider)
```

Parses a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

### Parse `static`

```csharp
BigNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
```

Parses a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. *(optional)* |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

### TryParse `static`

```csharp
bool TryParse(string s, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(string s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### Parse `static`

```csharp
BigNumber Parse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider)
```

Parses UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. *(optional)* |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### Divide `static`

```csharp
BigNumber Divide(BigNumber dividend, BigNumber divisor, int precision)
```

Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with specified precision.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `dividend` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The dividend. |
| `divisor` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The divisor. |
| `precision` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places of precision. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The quotient.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`DivideByZeroException`](https://learn.microsoft.com/dotnet/api/system.dividebyzeroexception) | Thrown when divisor is zero. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when precision is negative. |

### Abs `static`

```csharp
BigNumber Abs(BigNumber value)
```

Returns the absolute value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) |  |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

### Sign `static`

```csharp
int Sign(BigNumber value)
```

Returns the sign of the number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value. |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

-1 for negative, 0 for zero, 1 for positive.

### Pow `static`

```csharp
BigNumber Pow(BigNumber value, int exponent)
```

Raises a BigNumber to an integer power.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The base value. |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The integer exponent. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The value raised to the specified power.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when exponent is negative. |

### Sqrt `static`

```csharp
BigNumber Sqrt(BigNumber value, int precision)
```

Computes the square root of a BigNumber using Newton's method.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to find the square root of. |
| `precision` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places of precision. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The square root.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when value is negative. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when precision is negative. |

### Round `static`

```csharp
BigNumber Round(BigNumber value, int decimals, MidpointRounding mode)
```

Rounds a value to a specified number of decimal places.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to round. |
| `decimals` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of decimal places. |
| `mode` | [`MidpointRounding`](https://learn.microsoft.com/dotnet/api/system.midpointrounding) | The rounding mode. *(optional)* |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The rounded value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when decimals is negative. |

### Floor `static`

```csharp
BigNumber Floor(BigNumber value)
```

Returns the largest integer less than or equal to the specified number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to floor. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The floor of the value.

### Ceiling `static`

```csharp
BigNumber Ceiling(BigNumber value)
```

Returns the smallest integer greater than or equal to the specified number.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to ceiling. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The ceiling of the value.

### Truncate `static`

```csharp
BigNumber Truncate(BigNumber value)
```

Truncates a value to an integer by removing the fractional part.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The value to truncate. |

**Returns:** [`BigNumber`](/api/corvus-numerics-bignumber.html)

The truncated value.

### TryFormatOptimized

```csharp
bool TryFormatOptimized(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

Tries to format this instance into the provided UTF-16 span with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

### TryFormatUtf8Optimized

```csharp
bool TryFormatUtf8Optimized(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

Tries to format this instance into the provided UTF-8 span with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

### TryParseJsonUtf8 `static`

```csharp
bool TryParseJsonUtf8(ReadOnlySpan<byte> utf8Source, ref BigNumber result)
```

Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Source` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed BigNumber. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

This method is optimized for parsing JSON-formatted numbers with InvariantCulture semantics. It expects input in formats like: "123", "-456", "1234E-3", "1234E2", "0". The method parses directly from UTF-8 bytes without conversion to chars, maintaining zero heap allocations for typical numbers.

