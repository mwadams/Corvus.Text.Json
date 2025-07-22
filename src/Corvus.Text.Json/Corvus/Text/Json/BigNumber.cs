// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Numerics;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// An arbitrary precision number represented as a significand and an exponent.
/// </summary>
public readonly struct BigNumber : IEquatable<BigNumber>
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
            return this;
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
        JsonElementHelpers.ParseNumber(
            segment,
            out bool isNegative,
            out ReadOnlySpan<byte> integral,
            out ReadOnlySpan<byte> fractional,
            out int exponent);

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

    /// <inheritdoc/>
    public bool Equals(BigNumber other) => Exponent.Equals(other.Exponent) && Significand.Equals(other.Significand);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Significand, Exponent);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => base.Equals(obj);

    /// <inheritdoc/>
    public override string ToString() => $"{Significand}{(Exponent != 0 ? "E" : "")}{(Exponent != 0 ? Exponent : "")}";

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
}
