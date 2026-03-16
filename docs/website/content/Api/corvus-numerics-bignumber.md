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
| [BigNumber(BigInteger, int)](/api/corvus-numerics-bignumber.ctor.html#bignumber-biginteger-int) | Initializes a new instance of the [`BigNumber`](/api/corvus-numerics-bignumber.html) struct. |

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
| [Abs(BigNumber)](/api/corvus-numerics-bignumber.abs.html#abs-bignumber) `static` | Returns the absolute value. |
| [Ceiling(BigNumber)](/api/corvus-numerics-bignumber.ceiling.html#ceiling-bignumber) `static` | Returns the smallest integer greater than or equal to the specified number. |
| [CompareTo](/api/corvus-numerics-bignumber.compareto.html) | Compares this instance with another [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| [Divide(BigNumber, BigNumber, int)](/api/corvus-numerics-bignumber.divide.html#divide-bignumber-bignumber-int) `static` | Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with specified precision. |
| [Equals](/api/corvus-numerics-bignumber.equals.html) | Determines whether the specified [`BigNumber`](/api/corvus-numerics-bignumber.html) is equal to this instance. |
| [Floor(BigNumber)](/api/corvus-numerics-bignumber.floor.html#floor-bignumber) `static` | Returns the largest integer less than or equal to the specified number. |
| [GetHashCode()](/api/corvus-numerics-bignumber.gethashcode.html#gethashcode) | Returns a hash code for this instance. |
| [IsInteger()](/api/corvus-numerics-bignumber.isinteger.html#isinteger) | Determines whether this instance represents an integer value. |
| [Normalize()](/api/corvus-numerics-bignumber.normalize.html#normalize) | Returns a normalized copy of this number with trailing zeros removed from the significand. |
| [Parse](/api/corvus-numerics-bignumber.parse.html) `static` | Parses a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Pow(BigNumber, int)](/api/corvus-numerics-bignumber.pow.html#pow-bignumber-int) `static` | Raises a BigNumber to an integer power. |
| [Round(BigNumber, int, MidpointRounding)](/api/corvus-numerics-bignumber.round.html#round-bignumber-int-midpointrounding) `static` | Rounds a value to a specified number of decimal places. |
| [Sign(BigNumber)](/api/corvus-numerics-bignumber.sign.html#sign-bignumber) `static` | Returns the sign of the number. |
| [Sqrt(BigNumber, int)](/api/corvus-numerics-bignumber.sqrt.html#sqrt-bignumber-int) `static` | Computes the square root of a BigNumber using Newton's method. |
| [ToString](/api/corvus-numerics-bignumber.tostring.html) | Returns the string representation of this [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| [Truncate(BigNumber)](/api/corvus-numerics-bignumber.truncate.html#truncate-bignumber) `static` | Truncates a value to an integer by removing the fractional part. |
| [TryFormat](/api/corvus-numerics-bignumber.tryformat.html) | Tries to format this [`BigNumber`](/api/corvus-numerics-bignumber.html) value into the provided character span. |
| [TryFormatOptimized(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformatoptimized.html#tryformatoptimized-span-char-ref-int-readonlyspan-char-iformatprovider) | Tries to format this instance into the provided UTF-16 span with zero allocations. |
| [TryFormatUtf8Optimized(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-numerics-bignumber.tryformatutf8optimized.html#tryformatutf8optimized-span-byte-ref-int-readonlyspan-char-iformatprovider) | Tries to format this instance into the provided UTF-8 span with zero allocations. |
| [TryGetMinimumFormatBufferLength(ref int)](/api/corvus-numerics-bignumber.trygetminimumformatbufferlength.html#trygetminimumformatbufferlength-ref-int) | Gets the minimum format buffer length. |
| [TryParse](/api/corvus-numerics-bignumber.tryparse.html) `static` | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParseJsonUtf8(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](/api/corvus-numerics-bignumber.tryparsejsonutf8.html#tryparsejsonutf8-readonlyspan-byte-ref-bignumber) `static` | Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator +(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-addition.html#operator-bignumber-bignumber) | Adds two [`BigNumber`](/api/corvus-numerics-bignumber.html) values. |
| [operator --(BigNumber)](/api/corvus-numerics-bignumber.op-decrement.html#operator-bignumber) | Decrements a value by one. |
| [operator /(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-division.html#operator-bignumber-bignumber) | Divides one [`BigNumber`](/api/corvus-numerics-bignumber.html) by another with default precision. |
| [operator ==(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-equality.html#operator-bignumber-bignumber) | Determines whether two [`BigNumber`](/api/corvus-numerics-bignumber.html) values are equal. |
| [Explicit](/api/corvus-numerics-bignumber.op-explicit.html) | Explicitly converts a [`BigNumber`](/api/corvus-numerics-bignumber.html) to a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [operator &gt;(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-greaterthan.html#operator-bignumber-bignumber) | Determines whether one value is greater than another. |
| [operator &gt;=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-greaterthanorequal.html#operator-bignumber-bignumber) | Determines whether one value is greater than or equal to another. |
| [Implicit](/api/corvus-numerics-bignumber.op-implicit.html) | Converts an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) to a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [operator ++(BigNumber)](/api/corvus-numerics-bignumber.op-increment.html#operator-bignumber) | Increments a value by one. |
| [operator !=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-inequality.html#operator-bignumber-bignumber) | Determines whether two [`BigNumber`](/api/corvus-numerics-bignumber.html) values are not equal. |
| [operator &lt;(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-lessthan.html#operator-bignumber-bignumber) | Determines whether one value is less than another. |
| [operator &lt;=(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-lessthanorequal.html#operator-bignumber-bignumber) | Determines whether one value is less than or equal to another. |
| [operator %(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-modulus.html#operator-bignumber-bignumber) | Computes the remainder of division. |
| [operator *(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-multiply.html#operator-bignumber-bignumber) | Multiplies two [`BigNumber`](/api/corvus-numerics-bignumber.html) values. |
| [operator -(BigNumber, BigNumber)](/api/corvus-numerics-bignumber.op-subtraction.html#operator-bignumber-bignumber) | Subtracts one [`BigNumber`](/api/corvus-numerics-bignumber.html) from another. |
| [operator -(BigNumber)](/api/corvus-numerics-bignumber.op-unarynegation.html#operator-bignumber) | Negates a value. |
| [operator +(BigNumber)](/api/corvus-numerics-bignumber.op-unaryplus.html#operator-bignumber) | Returns the value unchanged (unary plus). |

