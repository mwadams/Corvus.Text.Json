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

Internally represented as: value = significand × 10^exponent where significand is a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) and exponent is a [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). This type provides equivalent functionality to [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) but with arbitrary precision, similar to how [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) extends integer arithmetic beyond fixed sizes.

## Implements

[`IEquatable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iequatable-1), [`IComparable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.icomparable-1), [`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable), [`INumber<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.inumber-1), [`IParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iparsable-1), [`ISpanParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.ispanparsable-1), [`IAdditionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iadditionoperators-3), [`IAdditiveIdentity<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iadditiveidentity-2), [`IComparisonOperators<BigNumber, BigNumber, bool>`](https://learn.microsoft.com/dotnet/api/system.numerics.icomparisonoperators-3), [`IEqualityOperators<BigNumber, BigNumber, bool>`](https://learn.microsoft.com/dotnet/api/system.numerics.iequalityoperators-3), [`IDecrementOperators<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.idecrementoperators-1), [`IDivisionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.idivisionoperators-3), [`IIncrementOperators<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iincrementoperators-1), [`IModulusOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imodulusoperators-3), [`IMultiplicativeIdentity<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imultiplicativeidentity-2), [`IMultiplyOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.imultiplyoperators-3), [`INumberBase<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.inumberbase-1), [`IUtf8SpanParsable<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.iutf8spanparsable-1), [`ISubtractionOperators<BigNumber, BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.isubtractionoperators-3), [`IUnaryNegationOperators<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iunarynegationoperators-2), [`IUnaryPlusOperators<BigNumber, BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.iunaryplusoperators-2), [`ISignedNumber<BigNumber>`](https://learn.microsoft.com/dotnet/api/system.numerics.isignednumber-1)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [BigNumber(BigInteger, int)](/api/corvus-numerics-bignumber.ctor.html#bignumber-biginteger-significand-int-exponent) | Initializes a new instance of the [`BigNumber`](/api/corvus-numerics-bignumber.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Exponent](/api/corvus-numerics-bignumber.exponent.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the exponent (power of 10) of the number. |
| [MinusOne](/api/corvus-numerics-bignumber.minusone.html) `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing minus one. |
| [One](/api/corvus-numerics-bignumber.one.html) `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing one. |
| [Radix](/api/corvus-numerics-bignumber.radix.html) `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the radix (base) of the number system. |
| [Significand](/api/corvus-numerics-bignumber.significand.html) | [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | Gets the significand of the number. |
| [Zero](/api/corvus-numerics-bignumber.zero.html) `static` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | Gets a value representing zero. |

## Methods

| Method | Description |
|--------|-------------|
| [Abs(BigNumber)](/api/corvus-numerics-bignumber.abs.html#bignumber-abs-bignumber-value) `static` | Returns the absolute value. |
| [Ceiling(BigNumber)](/api/corvus-numerics-bignumber.ceiling.html#bignumber-ceiling-bignumber-value) `static` | Returns the smallest integer greater than or equal to the specified number. |
| [CompareTo(BigNumber)](/api/corvus-numerics-bignumber.compareto.html#int-compareto-bignumber-other) |  |
| [CompareTo(object)](/api/corvus-numerics-bignumber.compareto.html#int-compareto-object-obj) |  |
| [Divide(BigNumber, BigNumber, int)](/api/corvus-numerics-bignumber.divide.html#bignumber-divide-bignumber-dividend-bignumber-divisor-int-precision) `static` | Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with specified precision. |
| [Equals(BigNumber)](/api/corvus-numerics-bignumber.equals.html#bool-equals-bignumber-other) |  |
| [Equals(object)](/api/corvus-numerics-bignumber.equals.html#bool-equals-object-obj) |  |
| [Floor(BigNumber)](/api/corvus-numerics-bignumber.floor.html#bignumber-floor-bignumber-value) `static` | Returns the largest integer less than or equal to the specified number. |
| [GetHashCode()](/api/corvus-numerics-bignumber.gethashcode.html#int-gethashcode) |  |
| [IsInteger()](/api/corvus-numerics-bignumber.isinteger.html#bool-isinteger) | Determines whether this instance represents an integer value. |
| [Normalize()](/api/corvus-numerics-bignumber.normalize.html#bignumber-normalize) | Returns a normalized copy of this number with trailing zeros removed from the significand. |
| [Parse(string, IFormatProvider)](/api/corvus-numerics-bignumber.parse.html#bignumber-parse-string-s-iformatprovider-provider) `static` | Parses a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Parse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider)](/api/corvus-numerics-bignumber.parse.html#bignumber-parse-readonlyspan-char-s-numberstyles-style-iformatprovider-provider) `static` | Parses a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Parse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider)](/api/corvus-numerics-bignumber.parse.html#bignumber-parse-readonlyspan-byte-utf8text-numberstyles-style-iformatprovider-provider) `static` | Parses UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Pow(BigNumber, int)](/api/corvus-numerics-bignumber.pow.html#bignumber-pow-bignumber-value-int-exponent) `static` | Raises a BigNumber to an integer power. |
| [Round(BigNumber, int, MidpointRounding)](/api/corvus-numerics-bignumber.round.html#bignumber-round-bignumber-value-int-decimals-midpointrounding-mode) `static` | Rounds a value to a specified number of decimal places. |
| [Sign(BigNumber)](/api/corvus-numerics-bignumber.sign.html#int-sign-bignumber-value) `static` | Returns the sign of the number. |
| [Sqrt(BigNumber, int)](/api/corvus-numerics-bignumber.sqrt.html#bignumber-sqrt-bignumber-value-int-precision) `static` | Computes the square root of a BigNumber using Newton's method. |
| [ToString()](/api/corvus-numerics-bignumber.tostring.html#string-tostring) |  |
| [ToString(string, IFormatProvider)](/api/corvus-numerics-bignumber.tostring.html#string-tostring-string-format-iformatprovider-formatprovider) |  |
| [Truncate(BigNumber)](/api/corvus-numerics-bignumber.truncate.html#bignumber-truncate-bignumber-value) `static` | Truncates a value to an integer by removing the fractional part. |
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformat.html#bool-tryformat-span-char-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformat.html#bool-tryformat-span-byte-utf8destination-ref-int-byteswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryFormat(Span&lt;char&gt;, ref int)](/api/corvus-numerics-bignumber.tryformat.html#bool-tryformat-span-char-destination-ref-int-charswritten) |  |
| [TryFormat(Span&lt;byte&gt;, ref int)](/api/corvus-numerics-bignumber.tryformat.html#bool-tryformat-span-byte-destination-ref-int-byteswritten) |  |
| [TryFormatOptimized(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformatoptimized.html#bool-tryformatoptimized-span-char-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-provider) | Tries to format this instance into the provided UTF-16 span with zero allocations. |
| [TryFormatUtf8Optimized(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformatutf8optimized.html#bool-tryformatutf8optimized-span-byte-utf8destination-ref-int-byteswritten-readonlyspan-char-format-iformatprovider-provider) | Tries to format this instance into the provided UTF-8 span with zero allocations. |
| [TryGetMinimumFormatBufferLength(ref int)](/api/corvus-numerics-bignumber.trygetminimumformatbufferlength.html#bool-trygetminimumformatbufferlength-ref-int-minimumlength) | Gets the minimum format buffer length. |
| [TryParse(string, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-string-s-ref-bignumber-result) `static` | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(string, IFormatProvider, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-string-s-iformatprovider-provider-ref-bignumber-result) `static` | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, IFormatProvider, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-char-s-iformatprovider-provider-ref-bignumber-result) `static` | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-char-s-ref-bignumber-result) `static` | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, IFormatProvider, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-byte-s-iformatprovider-provider-ref-bignumber-result) `static` | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-byte-s-ref-bignumber-result) `static` | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-char-s-numberstyles-style-iformatprovider-provider-ref-bignumber-result) `static` | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider, ref BigNumber)](/api/corvus-numerics-bignumber.tryparse.html#bool-tryparse-readonlyspan-byte-utf8text-numberstyles-style-iformatprovider-provider-ref-bignumber-result) `static` | Attempts to parse UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParseJsonUtf8(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](/api/corvus-numerics-bignumber.tryparsejsonutf8.html#bool-tryparsejsonutf8-readonlyspan-byte-utf8source-ref-bignumber-result) `static` | Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator +(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-addition.html#static-bignumber-operator-bignumber-left-bignumber-right) | Adds two [`BigNumber`](/api/corvus-numerics-bignumber.html) values. |
| [operator --(BigNumber)](/api/corvus-numerics-bignumber.op-decrement.html#static-bignumber-operator-bignumber-value) | Decrements a value by one. |
| [operator /(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-division.html#static-bignumber-operator-bignumber-dividend-bignumber-divisor) | Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with default precision. |
| [operator ==(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-equality.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether two [`BigNumber`](/api/corvus-numerics-bignumber.html) values are equal. |
| [explicit operator decimal(BigNumber)](/api/corvus-numerics-bignumber.op-explicit.html#static-explicit-operator-decimal-bignumber-value) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [explicit operator double(BigNumber)](/api/corvus-numerics-bignumber.op-explicit.html#static-explicit-operator-double-bignumber-value) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [explicit operator float(BigNumber)](/api/corvus-numerics-bignumber.op-explicit.html#static-explicit-operator-float-bignumber-value) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [explicit operator long(BigNumber)](/api/corvus-numerics-bignumber.op-explicit.html#static-explicit-operator-long-bignumber-value) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [explicit operator ulong(BigNumber)](/api/corvus-numerics-bignumber.op-explicit.html#static-explicit-operator-ulong-bignumber-value) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [operator &gt;(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-greaterthan.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether one value is greater than another. |
| [operator &gt;=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-greaterthanorequal.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether one value is greater than or equal to another. |
| [implicit operator BigNumber(int)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-int-value) | Converts an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [implicit operator BigNumber(long)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-long-value) | Converts a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [implicit operator BigNumber(ulong)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-ulong-value) | Converts a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [implicit operator BigNumber(BigInteger)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-biginteger-value) | Converts a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [implicit operator BigNumber(decimal)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-decimal-value) | Converts a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [implicit operator BigNumber(double)](/api/corvus-numerics-bignumber.op-implicit.html#static-implicit-operator-bignumber-double-value) | Converts a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [operator ++(BigNumber)](/api/corvus-numerics-bignumber.op-increment.html#static-bignumber-operator-bignumber-value) | Increments a value by one. |
| [operator !=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-inequality.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether two [`BigNumber`](/api/corvus-numerics-bignumber.html) values are not equal. |
| [operator &lt;(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-lessthan.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether one value is less than another. |
| [operator &lt;=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-lessthanorequal.html#static-bool-operator-bignumber-left-bignumber-right) | Determines whether one value is less than or equal to another. |
| [operator %(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-modulus.html#static-bignumber-operator-bignumber-left-bignumber-right) | Computes the remainder of division. |
| [operator *(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-multiply.html#static-bignumber-operator-bignumber-left-bignumber-right) | Multiplies two [`BigNumber`](/api/corvus-numerics-bignumber.html) values. |
| [operator -(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-subtraction.html#static-bignumber-operator-bignumber-left-bignumber-right) | Subtracts one [`BigNumber`](/api/corvus-numerics-bignumber.html) from another. |
| [operator -(BigNumber)](/api/corvus-numerics-bignumber.op-unarynegation.html#static-bignumber-operator-bignumber-value) | Negates a value. |
| [operator +(BigNumber)](/api/corvus-numerics-bignumber.op-unaryplus.html#static-bignumber-operator-bignumber-value) | Returns the value unchanged (unary plus). |

