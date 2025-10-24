// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Numerics;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// An arbitrary precision number represented as a significand and an exponent.
/// </summary>
#if NET
public readonly struct BigNumber : IEquatable<BigNumber>, IComparable<BigNumber>, IAdditionOperators<BigNumber, BigNumber, BigNumber>, ISubtractionOperators<BigNumber, BigNumber, BigNumber>, IMultiplyOperators<BigNumber, BigNumber, BigNumber>, IDivisionOperators<BigNumber, BigNumber, BigNumber>
#else
public readonly struct BigNumber : IEquatable<BigNumber>, IComparable<BigNumber>
#endif
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BigNumber"/> struct.
    /// </summary>
    /// <param name="significand">The significand of the number.</param>
    /// <param name="exponent">The exponent of the number.</param>
    public BigNumber(BigInteger significand, int exponent)
    {
        Significand = significand;
        Exponent = exponent;
    }

    /// <summary>
    /// Gets the significand of the number.
    /// </summary>
    public BigInteger Significand { get; }

    /// <summary>
    /// Gets the exponent of the number.
    /// </summary>
    public int Exponent { get; }

    /// <summary>
    /// Ensures that the significand is normalized, meaning that it has no trailing zeros.
    /// </summary>
    /// <returns>The normalized <see cref="BigNumber"/>.</returns>
    /// <remarks>
    /// Note that operations on the <see cref="BigNumber"/> require normalization to ensure
    /// consistency. Numbers parsed from JSON documents are automatically normalized.
    /// </remarks>
    public BigNumber Normalize()
    {
        BigInteger significand = Significand;

        if (significand.IsZero)
        {
            return default;
        }

        int exponent = Exponent;
        while (true)
        {
            BigInteger quotient = BigInteger.DivRem(significand, 10, out BigInteger remainder);
            if (remainder == 0)
            {
                significand = quotient;
                exponent++;
            }
            else
            {
                break;
            }
        }

        return new(significand, exponent);
    }

#if NET

    /// <summary>
    /// Gets the minimum format buffer length.
    /// </summary>
    /// <param name="minimumLength">The minimum length for a text buffer to format the number.</param>
    /// <returns><see langword="true"/> if the buffer length required for the number can be safely allocated.</returns>
    public bool TryGetMinimumFormatBufferLength(out int minimumLength)
    {
        // Up to two characters per nybble
        // So divide by 4 and multiply by 2 => divide by 2 => shift left 1
        long value = Significand.GetBitLength() << 1;

        if (Significand.Sign < 0)
        {
            // One for the sign
            value++;
        }

        if (Exponent != 0)
        {
            // One for E and then the exponent
            value += JsonConstants.MaximumFormatUInt32Length + 1;
        }

        if (value > Array.MaxLength)
        {
            minimumLength = 0;
            return false;
        }

        minimumLength = (int)value;
        return true;
    }

#endif

    /// <summary>
    /// Attempts to format the value of the current instance into the provided span of characters.
    /// </summary>
    /// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
    /// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination"/>.</param>
    /// <returns><c>true</c> if the formatting was successful; otherwise, <c>false</c>.</returns>
    public bool TryFormat(Span<char> destination, out int charsWritten)
    {
        if (!Significand.TryFormat(destination, out int valueBytesWritten))
        {
            charsWritten = 0;
            return false;
        }

        int result = valueBytesWritten;
        if (Exponent != 0)
        {
            if (destination.Length <= result + 1)
            {
                charsWritten = 0;
                return false;
            }

            destination[result++] = 'E';

#if NET
            if (!Exponent.TryFormat(destination.Slice(result), out int exponentBytesWritten))
            {
                charsWritten = 0;
                return false;
            }

            result += exponentBytesWritten;
#else
            int exp = Exponent;
            bool isNegative = exp < 0;
            if (isNegative)
            {
                if (result < destination.Length)
                {
                    destination[result++] = '-';
                    exp = -exp;
                }
                else
                {
                    charsWritten = 0;
                    return false;
                }
            }

            int start = result;
            // Write digits in reverse order
            do
            {
                if (result >= destination.Length)
                {
                    charsWritten = 0;
                    return false;
                }

                destination[result++] = (char)('0' + (exp % 10));
                exp /= 10;
            }
            while (exp != 0);

            // Reverse the digits to correct order
            int end = result - 1;
            while (start < end)
            {
                char tmp = destination[start];
                destination[start] = destination[end];
                destination[end] = tmp;
                start++;
                end--;
            }
#endif
        }

        charsWritten = result;
        return true;
    }

    /// <summary>
    /// Attempts to format the value of the current instance into the provided span of bytes.
    /// </summary>
    /// <param name="destination">The span in which to write this instance's value formatted as a span of bytes.</param>
    /// <param name="charsWritten">When this method returns, contains the number of bytes that were written in <paramref name="destination"/>.</param>
    /// <returns><c>true</c> if the formatting was successful; otherwise, <c>false</c>.</returns>
    public bool TryFormat(Span<byte> destination, out int charsWritten)
    {
        if (!Significand.TryFormat(destination, out int valueBytesWritten))
        {
            charsWritten = 0;
            return false;
        }

        int result = valueBytesWritten;
        if (Exponent != 0)
        {
            if (destination.Length <= result + 1)
            {
                charsWritten = 0;
                return false;
            }

            destination[result++] = (byte)'E';

#if NET
            if (!Exponent.TryFormat(destination.Slice(result), out int exponentBytesWritten))
            {
                charsWritten = 0;
                return false;
            }

            result += exponentBytesWritten;
#else
            int exp = Exponent;
            bool isNegative = exp < 0;
            if (isNegative)
            {
                if (result < destination.Length)
                {
                    destination[result++] = (byte)'-';
                    exp = -exp;
                }
                else
                {
                    charsWritten = 0;
                    return false;
                }
            }

            int start = result;
            // Write digits in reverse order
            do
            {
                if (result >= destination.Length)
                {
                    charsWritten = 0;
                    return false;
                }

                destination[result++] = (byte)('0' + (exp % 10));
                exp /= 10;
            }
            while (exp != 0);

            // Reverse the digits to correct order
            int end = result - 1;
            while (start < end)
            {
                byte tmp = destination[start];
                destination[start] = destination[end];
                destination[end] = tmp;
                start++;
                end--;
            }
#endif
        }

        charsWritten = result;
        return true;
    }

    /// <summary>
    /// Parse a big number from a span.
    /// </summary>
    /// <param name="segment">The UTF8 JSON number from which to try to parse the value.</param>
    /// <param name="value">The resulting number.</param>
    /// <returns><see langword="true"/> if the value is parsed successfully.</returns>
    public static bool TryParse(ReadOnlySpan<byte> segment, out BigNumber value)
    {
        if (JsonElementHelpers.TryParseNumber(
            segment,
            out bool isNegative,
            out ReadOnlySpan<byte> integral,
            out ReadOnlySpan<byte> fractional,
            out int exponent))
        {

            if (integral.Length == 0 && fractional.Length == 0)
            {
                value = new BigNumber(BigInteger.Zero, 0);
                return true;
            }

            int requiredLength = integral.Length + fractional.Length + (isNegative ? 1 : 0);

            char[]? charBuffer = null;
            Span<char> significand =
                requiredLength < JsonConstants.StackallocCharThreshold
                    ? stackalloc char[requiredLength] : (charBuffer = ArrayPool<char>.Shared.Rent(requiredLength));

            int written = 0;
            if (isNegative)
            {
                significand[written] = '-';
                written++;
            }

            try
            {
                if (!JsonReaderHelper.TryGetTextFromUtf8(integral, significand.Slice(written), out int writtenIntegral))
                {
                    value = default;
                    return false;
                }

                written += writtenIntegral;

                if (!JsonReaderHelper.TryGetTextFromUtf8(fractional, significand.Slice(written), out int writtenFractional))
                {
                    value = default;
                    return false;
                }

                written += writtenFractional;

                if (BigInteger.TryParse(significand.Slice(0, written), out BigInteger bigSignificand))
                {
                    value = new(bigSignificand, exponent);
                    return true;
                }

                value = default;
                return false;
            }
            finally
            {
                if (charBuffer is char[] b)
                {
                    // Clear as may be sensitive data.
                    significand.Slice(0, written).Clear();
                    ArrayPool<char>.Shared.Return(b);
                }
            }
        }

        value = default;
        return false;
    }

    /// <inheritdoc/>
    public int CompareTo(BigNumber other)
    {
        // Normalize to remove trailing zeros for a consistent comparison.
        BigNumber left = this.Normalize();
        BigNumber right = other.Normalize();

        if (left.Significand.IsZero)
        {
            return right.Significand.IsZero ? 0 : -right.Significand.Sign;
        }

        if (right.Significand.IsZero)
        {
            return left.Significand.Sign;
        }

        // Different signs are easy
        if (left.Significand.Sign != right.Significand.Sign)
        {
            return left.Significand.Sign > right.Significand.Sign ? 1 : -1;
        }

        // Same sign, so we can compare absolute values and then apply the sign.
        int exponentDiff = left.Exponent - right.Exponent;
        BigInteger s1 = left.Significand;
        BigInteger s2 = right.Significand;

        // To compare, we need to align the exponents.
        // Instead of scaling up, which can cause OutOfMemoryException for large exponent differences,
        // we can approximate by comparing the number of digits.
#if NET
        long s1Digits = s1.GetBitLength() * 3L / 10L; // Fast approximation of log10
        long s2Digits = s2.GetBitLength() * 3L / 10L;
#else
        long s1Digits = (long)BigInteger.Log10(BigInteger.Abs(s1));
        long s2Digits = (long)BigInteger.Log10(BigInteger.Abs(s2));
#endif

        long effectiveDigits1 = s1Digits + left.Exponent;
        long effectiveDigits2 = s2Digits + right.Exponent;

        if (effectiveDigits1 != effectiveDigits2)
        {
            return effectiveDigits1 > effectiveDigits2 ? left.Significand.Sign : -left.Significand.Sign;
        }

        // If the number of digits is the same, we have to do the expensive scaling.
        if (exponentDiff > 0)
        {
            s1 *= BigInteger.Pow(10, exponentDiff);
        }
        else if (exponentDiff < 0)
        {
            s2 *= BigInteger.Pow(10, -exponentDiff);
        }

        return s1.CompareTo(s2);
    }

    /// <inheritdoc/>
    public bool Equals(BigNumber other) => Exponent.Equals(other.Exponent) && Significand.Equals(other.Significand);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Significand, Exponent);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => base.Equals(obj);

    /// <inheritdoc/>
    public override string ToString() => $"{Significand}{(Exponent != 0 ? "E" : "")}{(Exponent != 0 ? Exponent : "")}";

    /// <summary>
    /// Explicitly converts a <see cref="BigNumber"/> to a <see cref="decimal"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator decimal(BigNumber value)
    {
        BigInteger significand = value.Significand;
        int exponent = value.Exponent;

        // Fast path for zero
        if (significand.IsZero)
        {
            return decimal.Zero;
        }

        // Adjust exponent to be within a manageable range for decimal
        // This might lose precision for very large or small exponents, which is acceptable for an explicit conversion.
        const int maxDecimalExponent = 28;
        const int minDecimalExponent = -28;

        if (exponent > maxDecimalExponent)
        {
            significand *= BigInteger.Pow(10, exponent - maxDecimalExponent);
            exponent = maxDecimalExponent;
        }
        else if (exponent < minDecimalExponent)
        {
            significand /= BigInteger.Pow(10, -exponent + minDecimalExponent);
            exponent = minDecimalExponent;
        }

        decimal result = (decimal)significand;

        if (exponent > 0)
        {
            result *= (decimal)Math.Pow(10, exponent);
        }
        else if (exponent < 0)
        {
            result /= (decimal)Math.Pow(10, -exponent);
        }

        return result;
    }

    /// <summary>
    /// Explicitly converts a <see cref="BigNumber"/> to a <see cref="double"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator double(BigNumber value)
    {
        // This conversion can lose precision, which is expected for an explicit cast.
        return (double)value.Significand * Math.Pow(10, value.Exponent);
    }

    /// <summary>
    /// Explicitly converts a <see cref="BigNumber"/> to a <see cref="float"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator float(BigNumber value)
    {
        // This conversion can lose precision, which is expected for an explicit cast.
        return (float)((double)value.Significand * Math.Pow(10, value.Exponent));
    }

    /// <summary>
    /// Explicitly converts a <see cref="BigNumber"/> to a <see cref="long"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator long(BigNumber value)
    {
        BigInteger result = value.Significand;
        if (value.Exponent > 0)
        {
            result *= BigInteger.Pow(10, value.Exponent);
        }
        else if (value.Exponent < 0)
        {
            result /= BigInteger.Pow(10, -value.Exponent);
        }
        return (long)result;
    }

    /// <summary>
    /// Explicitly converts a <see cref="BigNumber"/> to a <see cref="ulong"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    [CLSCompliant(false)]
    public static explicit operator ulong(BigNumber value)
    {
        BigInteger result = value.Significand;
        if (value.Exponent > 0)
        {
            result *= BigInteger.Pow(10, value.Exponent);
        }
        else if (value.Exponent < 0)
        {
            result /= BigInteger.Pow(10, -value.Exponent);
        }
        return (ulong)result;
    }

    /// <summary>
    /// Implicitly converts a <see cref="long"/> to a <see cref="BigNumber"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator BigNumber(long value) => new(value, 0);

    /// <summary>
    /// Implicitly converts a <see cref="ulong"/> to a <see cref="BigNumber"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    [CLSCompliant(false)]
    public static implicit operator BigNumber(ulong value) => new(value, 0);

    /// <summary>
    /// Implicitly converts a <see cref="double"/> to a <see cref="BigNumber"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator BigNumber(double value)
    {
        Span<byte> valueBytes = stackalloc byte[32]; // Max length for a double is around 24 chars, 32 is safe.
        if (!System.Buffers.Text.Utf8Formatter.TryFormat(value, valueBytes, out int bytesWritten, new System.Buffers.StandardFormat('G', 17)))
        {
            // This should not happen with a buffer of 32 bytes.
            throw new FormatException($"Unable to format double '{value}' for BigNumber conversion.");
        }

        if (TryParse(valueBytes.Slice(0, bytesWritten), out BigNumber result))
        {
            return result;
        }

        throw new FormatException($"Unable to convert double '{value}' to BigNumber.");
    }

    /// <summary>
    /// Implicitly converts a <see cref="float"/> to a <see cref="BigNumber"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator BigNumber(float value)
    {
        Span<byte> valueBytes = stackalloc byte[32]; // Max length for a float is around 15 chars, 32 is safe.
        if (!System.Buffers.Text.Utf8Formatter.TryFormat(value, valueBytes, out int bytesWritten, new System.Buffers.StandardFormat('G', 9)))
        {
            // This should not happen with a buffer of 32 bytes.
            throw new FormatException($"Unable to format float '{value}' for BigNumber conversion.");
        }

        if (TryParse(valueBytes.Slice(0, bytesWritten), out BigNumber result))
        {
            return result;
        }

        throw new FormatException($"Unable to convert float '{value}' to BigNumber.");
    }

    /// <summary>
    /// Determines whether two <see cref="BigNumber"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the two instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(BigNumber left, BigNumber right) => left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="BigNumber"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the two instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(BigNumber left, BigNumber right) => !(left == right);

    /// <summary>
    /// The default precision for division operations.
    /// </summary>
    public const int DefaultDivisionPrecision = 50;

    /// <summary>
    /// Adds two <see cref="BigNumber"/> instances.
    /// </summary>
    /// <param name="left">The first operand.</param>
    /// <param name="right">The second operand.</param>
    /// <returns>The sum of the two numbers.</returns>
    public static BigNumber operator +(BigNumber left, BigNumber right)
    {
        BigInteger s1 = left.Significand;
        int e1 = left.Exponent;
        BigInteger s2 = right.Significand;
        int e2 = right.Exponent;

        if (e1 > e2)
        {
            s1 *= BigInteger.Pow(10, e1 - e2);
        }
        else if (e2 > e1)
        {
            s2 *= BigInteger.Pow(10, e2 - e1);
        }

        return new BigNumber(s1 + s2, Math.Min(e1, e2)).Normalize();
    }

    /// <summary>
    /// Subtracts two <see cref="BigNumber"/> instances.
    /// </summary>
    /// <param name="left">The first operand.</param>
    /// <param name="right">The second operand.</param>
    /// <returns>The difference of the two numbers.</returns>
    public static BigNumber operator -(BigNumber left, BigNumber right)
    {
        BigInteger s1 = left.Significand;
        int e1 = left.Exponent;
        BigInteger s2 = right.Significand;
        int e2 = right.Exponent;

        if (e1 > e2)
        {
            s1 *= BigInteger.Pow(10, e1 - e2);
        }
        else if (e2 > e1)
        {
            s2 *= BigInteger.Pow(10, e2 - e1);
        }

        return new BigNumber(s1 - s2, Math.Min(e1, e2)).Normalize();
    }

    /// <summary>
    /// Multiplies two <see cref="BigNumber"/> instances.
    /// </summary>
    /// <param name="left">The first operand.</param>
    /// <param name="right">The second operand.</param>
    /// <returns>The product of the two numbers.</returns>
    public static BigNumber operator *(BigNumber left, BigNumber right)
    {
        return new BigNumber(left.Significand * right.Significand, left.Exponent + right.Exponent).Normalize();
    }

    /// <summary>
    /// Divides two <see cref="BigNumber"/> instances.
    /// </summary>
    /// <param name="left">The dividend.</param>
    /// <param name="right">The divisor.</param>
    /// <returns>The result of the division.</returns>
    /// <remarks>The division is performed with a default precision of 50 decimal places.</remarks>
    public static BigNumber operator /(BigNumber left, BigNumber right)
    {
        return Divide(left, right, DefaultDivisionPrecision);
    }

    /// <summary>
    /// Divides two <see cref="BigNumber"/> instances with a specified precision.
    /// </summary>
    /// <param name="left">The dividend.</param>
    /// <param name="right">The divisor.</param>
    /// <param name="precision">The number of decimal places in the result.</param>
    /// <returns>The result of the division.</returns>
    public static BigNumber Divide(BigNumber left, BigNumber right, int precision)
    {
        if (right.Significand.IsZero)
        {
            throw new DivideByZeroException();
        }

        if (left.Significand.IsZero)
        {
            return default;
        }

        BigInteger scaledS1 = left.Significand * BigInteger.Pow(10, precision);
        BigInteger newSignificand = scaledS1 / right.Significand;
        int newExponent = left.Exponent - right.Exponent - precision;

        return new BigNumber(newSignificand, newExponent).Normalize();
    }

    /// <summary>
    /// Determines whether one <see cref="BigNumber"/> is greater than another.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the first instance is greater than the second; otherwise, <c>false</c>.</returns>
    public static bool operator >(BigNumber left, BigNumber right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Determines whether one <see cref="BigNumber"/> is less than another.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the first instance is less than the second; otherwise, <c>false</c>.</returns>
    public static bool operator <(BigNumber left, BigNumber right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Determines whether one <see cref="BigNumber"/> is greater than or equal to another.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the first instance is greater than or equal to the second; otherwise, <c>false</c>.</returns>
    public static bool operator >=(BigNumber left, BigNumber right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// Determines whether one <see cref="BigNumber"/> is less than or equal to another.
    /// </summary>
    /// <param name="left">The first <see cref="BigNumber"/> to compare.</param>
    /// <param name="right">The second <see cref="BigNumber"/> to compare.</param>
    /// <returns><c>true</c> if the first instance is less than or equal to the second; otherwise, <c>false</c>.</returns>
    public static bool operator <=(BigNumber left, BigNumber right) => left.CompareTo(right) <= 0;
}
