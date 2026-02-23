// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

#if !NET
using System.Collections.Concurrent;
#endif

using System.Diagnostics;
using System.Runtime.CompilerServices;

#if !NET
using System.Reflection;
using System.Reflection.Emit;
using Corvus.Text.Json.Internal;
#endif

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Helper methods for JSON numeric operations including equality comparisons, divisibility checks, and arithmetic operations.
/// </summary>
public static partial class JsonElementHelpers
{
    private const int MaxExponent = 18;

    // This table is used to quickly look up 10^X for X in [0..18]
    // This corresponds to the max exponent of 18.
    private static readonly ulong[] TenPowTable =
    [
        1UL,
        10UL,
        100UL,
        1000UL,
        10000UL,
        100000UL,
        1000000UL,
        10000000UL,
        100000000UL,
        1000000000UL,
        10000000000UL,
        100000000000UL,
        1000000000000UL,
        10000000000000UL,
        100000000000000UL,
        1000000000000000UL,
        10000000000000000UL,
        100000000000000000UL,
    ];

    private static readonly ulong MaxTenPowExponent = (ulong)10e18;

    /// <summary>
    /// Compares two valid UTF-8 encoded JSON numbers for decimal equality.
    /// </summary>
    /// <param name="left">The UTF-8 encoded bytes representing the left JSON number.</param>
    /// <param name="right">The UTF-8 encoded bytes representing the right JSON number.</param>
    /// <returns><see langword="true"/> if the two JSON numbers are equal; otherwise, <see langword="false"/>.</returns>
    public static bool AreEqualJsonNumbers(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        Debug.Assert(left.Length > 0 && right.Length > 0);

        ParseNumber(left,
            out bool leftIsNegative,
            out ReadOnlySpan<byte> leftIntegral,
            out ReadOnlySpan<byte> leftFractional,
            out int leftExponent);

        ParseNumber(right,
            out bool rightIsNegative,
            out ReadOnlySpan<byte> rightIntegral,
            out ReadOnlySpan<byte> rightFractional,
            out int rightExponent);

        return AreEqualNormalizedJsonNumbers(leftIsNegative, leftIntegral, leftFractional, leftExponent, rightIsNegative, rightIntegral, rightFractional, rightExponent);
    }

    /// <summary>
    /// Compares two valid normalized JSON numbers for decimal equality.
    /// </summary>
    /// <param name="leftIsNegative">Indicates whether the left number is negative.</param>
    /// <param name="leftIntegral">The integral part of the left number without leading zeros.</param>
    /// <param name="leftFractional">The fractional part of the left number without trailing zeros.</param>
    /// <param name="leftExponent">The exponent of the left number.</param>
    /// <param name="rightIsNegative">Indicates whether the right number is negative.</param>
    /// <param name="rightIntegral">The integral part of the right number without leading zeros.</param>
    /// <param name="rightFractional">The fractional part of the right number without trailing zeros.</param>
    /// <param name="rightExponent">The exponent of the right number.</param>
    /// <returns><see langword="true"/> if the two normalized JSON numbers are equal; otherwise, <see langword="false"/>.</returns>
    public static bool AreEqualNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
    {
        Debug.Assert(leftIntegral.Length == 0 || leftIntegral[0] != (byte)'0');
        Debug.Assert(leftFractional.Length == 0 || leftFractional[^1] != (byte)'0');
        Debug.Assert(rightIntegral.Length == 0 || rightIntegral[0] != (byte)'0');
        Debug.Assert(rightFractional.Length == 0 || rightFractional[^1] != (byte)'0');
        int nDigits;
        if (leftIsNegative != rightIsNegative ||
            leftExponent != rightExponent ||
            (nDigits = (leftIntegral.Length + leftFractional.Length)) !=
                        rightIntegral.Length + rightFractional.Length)
        {
            return false;
        }

        // Need to check that the concatenated integral and fractional parts are equal;
        // break each representation into three parts such that their lengths exactly match.
        ReadOnlySpan<byte> leftFirst;
        ReadOnlySpan<byte> leftMiddle;
        ReadOnlySpan<byte> leftLast;

        ReadOnlySpan<byte> rightFirst;
        ReadOnlySpan<byte> rightMiddle;
        ReadOnlySpan<byte> rightLast;

        int diff = leftIntegral.Length - rightIntegral.Length;
        switch (diff)
        {
            case < 0:
                leftFirst = leftIntegral;
                leftMiddle = leftFractional.Slice(0, -diff);
                leftLast = leftFractional.Slice(-diff);
                int rightOffset = rightIntegral.Length + diff;
                rightFirst = rightIntegral.Slice(0, rightOffset);
                rightMiddle = rightIntegral.Slice(rightOffset);
                rightLast = rightFractional;
                break;

            case 0:
                leftFirst = leftIntegral;
                leftMiddle = default;
                leftLast = leftFractional;
                rightFirst = rightIntegral;
                rightMiddle = default;
                rightLast = rightFractional;
                break;

            case > 0:
                int leftOffset = leftIntegral.Length - diff;
                leftFirst = leftIntegral.Slice(0, leftOffset);
                leftMiddle = leftIntegral.Slice(leftOffset);
                leftLast = leftFractional;
                rightFirst = rightIntegral;
                rightMiddle = rightFractional.Slice(0, diff);
                rightLast = rightFractional.Slice(diff);
                break;
        }

        Debug.Assert(leftFirst.Length == rightFirst.Length);
        Debug.Assert(leftMiddle.Length == rightMiddle.Length);
        Debug.Assert(leftLast.Length == rightLast.Length);
        return leftFirst.SequenceEqual(rightFirst) &&
            leftMiddle.SequenceEqual(rightMiddle) &&
            leftLast.SequenceEqual(rightLast);
    }

    /// <summary>
    /// Determines if a JSON number is an integer.
    /// </summary>
    /// <param name="exponent">The exponent.</param>
    /// 
    /// 
    /// <returns>True if the normalized JSON number represents an integer.</returns>
    public static bool IsIntegerNormalizedJsonNumber(
        int exponent)
    {
        return exponent >= 0;
    }



    /// <summary>
    /// Determines whether the normalized JSON number is an exact multiple of the given integer divisor.
    /// </summary>
    /// <param name="integral">When concatenated with <paramref name="fractional"/> produces the significand of the number without leading or trailing zeros.</param>
    /// <param name="fractional">When concatenated with <paramref name="integral"/> produces the significand of the number without leading or trailing zeros.</param>
    /// <param name="exponent">The exponent of the number.</param>
    /// <param name="divisor">The significand of the divisor represented as a <see cref="UInt64"/>.</param>
    /// <param name="divisorExponent">The exponent of the divisor. This will be non-zero if the divisor had a fractional component.</param>
    /// <returns>True if the normalized JSON number is a multiple of the divisor (i.e. <c>n mod D == 0</c>).</returns>
    /// <remarks>We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.</remarks>
    [CLSCompliant(false)]
    public static bool IsMultipleOf(
        ReadOnlySpan<byte> integral,
        ReadOnlySpan<byte> fractional,
        int exponent,
        ulong divisor,
        int divisorExponent)
    {
        // Note that when calculating the divisor we should ensure
        // a) that it is a positive integer
        // b) that we normalize to remove trailing zeros and apply them to the exponent
        // c) that we normalize to remove any fractional component and apply them to the exponent

        // Step 1.
        // Check for a divisor of zero, then check for a number that is trivially zero by length
        // Calculate the length of the significand of the number

        if (divisor == 0)
        {
            // Never true for a divisor of 0
            return false;
        }

        if (integral.Length == 0 && fractional.Length == 0)
        {
            // Always return true for a value of 0
            return true;
        }

        // Step 2.
        // Sum the exponent and the negated divisor exponent (i.e. exponent - divisorExponent) to get the net exponent for the number
        // Why?
        // If the divisor had a fractional value, and had to be multiplied by e.g. 100 to produce an integer,
        // then divisor's exponent will be e.g. -2.
        // Basic algebra tells us that the number must be multiplied by the same factor of e.g. 100 to produce a correct result.
        // The net exponent for the number is therefore the exponent of the number minus the exponent of the divisor.
        int netExponent = exponent - divisorExponent;

        // Step 3.
        // Determine if that significand has a fractional component. If so, return false as it cannot be an exact multiple of an integer
        // Note that this test encompasses the pathological case of netExponent < 0, which makes some component of the integral part
        // fractional.
        if (netExponent < 0)
        {
            return false;
        }

        int totalLength = integral.Length + fractional.Length;

        // Step 4.
        // Determine if the divisor is one of the common "fast path" divisors and use that (e.g. 1, 2, 5, 10) otherwise use the general purpose
        // algorithm
        switch (divisor)
        {
            case 1:
                return true; // 0 mod 1 == 0
            case 2:
                return IsDivisibleByTwo(integral, fractional, totalLength + netExponent - 1);

            case 3:
                return IsDivisibleByThree(integral, fractional);

            case 4:
                return IsDivisibleByFour(integral, fractional, totalLength + netExponent - 1);

            case 5:
                return IsDivisibleByFive(integral, fractional, totalLength + netExponent - 1);

            case 6:
                return IsDivisibleBySix(integral, fractional, totalLength + netExponent - 1);

            case 8:
                return IsDivisibleByEight(integral, fractional, totalLength + netExponent - 1);

            case 10:
                return IsDivisibleByTen(integral, fractional, totalLength + netExponent - 1);

            default:
                return GeneralPurposeIsMultipleOf(integral, fractional, totalLength + netExponent - 1, divisor);
        }
    }

    /// <summary>
    /// Determines whether the normalized JSON number is an exact multiple of the given integer divisor.
    /// </summary>
    /// <param name="integral">When concatenated with <paramref name="fractional"/> produces the significand of the number without leading or trailing zeros.</param>
    /// <param name="fractional">When concatenated with <paramref name="integral"/> produces the significand of the number without leading or trailing zeros.</param>
    /// <param name="exponent">The exponent of the number.</param>
    /// <param name="divisor">The significand of the divisor represented as a <see cref="System.Numerics.BigInteger"/>.</param>
    /// <param name="divisorExponent">The exponent of the divisor. This will be non-zero if the divisor had a fractional component.</param>
    /// <returns>True if the normalized JSON number is a multiple of the divisor (i.e. <c>n mod D == 0</c>).</returns>
    /// <remarks>We do not need to pass the sign of the JSON number as it is irrelevant to the calculation.</remarks>
    public static bool IsMultipleOf(
        ReadOnlySpan<byte> integral,
        ReadOnlySpan<byte> fractional,
        int exponent,
        System.Numerics.BigInteger divisor,
        int divisorExponent)
    {
        // Note that when calculating the divisor we should ensure
        // a) that it is a positive integer
        // b) that we normalize to remove trailing zeros and apply them to the exponent
        // c) that we normalize to remove any fractional component and apply them to the exponent

        // Step 1.
        // Check for a divisor of zero, then check for a number that is trivially zero by length
        // Calculate the length of the significand of the number

        if (divisor == 0)
        {
            // Never true for a divisor of 0
            return false;
        }

        if (integral.Length == 0 && fractional.Length == 0)
        {
            // Always return true for a value of 0
            return true;
        }

        // Step 2.
        // Sum the exponent and the negated divisor exponent (i.e. exponent - divisorExponent) to get the net exponent for the number
        // Why?
        // If the divisor had a fractional value, and had to be multiplied by e.g. 100 to produce an integer,
        // then divisor's exponent will be e.g. -2.
        // Basic algebra tells us that the number must be multiplied by the same factor of e.g. 100 to produce a correct result.
        // The net exponent for the number is therefore the exponent of the number minus the exponent of the divisor.
        int netExponent = exponent - divisorExponent;

        // Step 3.
        // Determine if that significand has a fractional component. If so, return false as it cannot be an exact multiple of an integer
        // Note that this test encompasses the pathological case of netExponent < 0, which makes some component of the integral part
        // fractional.
        if (netExponent < 0)
        {
            return false;
        }

        int totalLength = integral.Length + fractional.Length;

        // Step 4.
        // Determine if the divisor is one of the common "fast path" divisors and use that (e.g. 1, 2, 5, 10) otherwise use the general purpose
        // algorithm
        if (divisor.IsOne)
        {
            return true; // 0 mod 1 == 0
        }

        if (divisor.Equals(2))
        {
            return IsDivisibleByTwo(integral, fractional, totalLength + netExponent - 1);
        }

        if (divisor.Equals(3))
        {
            return IsDivisibleByThree(integral, fractional);
        }

        if (divisor.Equals(4))
        {
            return IsDivisibleByFour(integral, fractional, totalLength + netExponent - 1);
        }

        if (divisor.Equals(5))
        {
            return IsDivisibleByFive(integral, fractional, totalLength + netExponent - 1);
        }

        if (divisor.Equals(6))
        {
            return IsDivisibleBySix(integral, fractional, totalLength + netExponent - 1);
        }

        if (divisor.Equals(8))
        {
            return IsDivisibleByEight(integral, fractional, totalLength + netExponent - 1);
        }

        if (divisor.Equals(10))
        {
            return IsDivisibleByTen(integral, fractional, totalLength + netExponent - 1);
        }

        return GeneralPurposeIsMultipleOf(integral, fractional, totalLength + netExponent - 1, divisor);
    }

    // Optimizations based on the https://en.wikipedia.org/wiki/Divisibility_rule rules.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByTwo(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        byte value = GetValueAtPosition(integral, fractional, maxSignificandIndex);
        return value % 2 == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByThree(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional)
    {
        int accumulator = 0;
        int maxSignificandIndex = integral.Length + fractional.Length;
        for (int i = 0; i < maxSignificandIndex; ++i)
        {
            switch (GetDigitAtPosition(integral, fractional, i))
            {
                case (byte)'1':
                case (byte)'4':
                case (byte)'7':
                    accumulator += 1;
                    break;

                case (byte)'2':
                case (byte)'5':
                case (byte)'8':
                    accumulator -= 1;
                    break;
            }
        }

        return accumulator % 3 == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByFour(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        return (GetValueAtPosition(integral, fractional, maxSignificandIndex) +
               (GetValueAtPosition(integral, fractional, maxSignificandIndex - 1) * 2))
               % 4 == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByFive(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        byte value = GetValueAtPosition(integral, fractional, maxSignificandIndex);
        return value == 0 || value == 5;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleBySix(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        byte value = GetValueAtPosition(integral, fractional, maxSignificandIndex);
        if (value % 2 != 0)
        {
            return false;
        }

        int accumulator = 0;
        int realMaxSignificandIndex = integral.Length + fractional.Length;
        for (int i = 0; i < realMaxSignificandIndex; ++i)
        {
            switch (GetDigitAtPosition(integral, fractional, i))
            {
                case (byte)'1':
                case (byte)'4':
                case (byte)'7':
                    accumulator += 1;
                    break;

                case (byte)'2':
                case (byte)'5':
                case (byte)'8':
                    accumulator -= 1;
                    break;
            }
        }

        return accumulator % 3 == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByEight(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        return (GetValueAtPosition(integral, fractional, maxSignificandIndex) +
               (GetValueAtPosition(integral, fractional, maxSignificandIndex - 1) * 2) +
               (GetValueAtPosition(integral, fractional, maxSignificandIndex - 2) * 4))
               % 8 == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDivisibleByTen(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        byte value = GetValueAtPosition(integral, fractional, maxSignificandIndex);
        return value == 0;
    }

    private static bool GeneralPurposeIsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex, ulong divisor)
    {
        // Step 5.
        // for each index i, from 0 to the length of the significand, accumulate the remainder using the mod of the divisor
        // i.e. remainder = (remainder * 10 + digitValue) % divisor;
        // Use the GetDigitAtPosition() method to get the digit value using the integral and fractional parts, and the net exponent.
        // Return remainder == 0.
        // By using a ulong for the divisor, we support ~19 digits of precision in the divisor

        ulong remainder = 0;

        int maxRealSignificandIndex = integral.Length + fractional.Length;

        for (int i = 0; i < maxRealSignificandIndex; ++i)
        {
            remainder = (remainder * 10 + GetValueAtPosition(integral, fractional, i)) % divisor;
        }

        // Now, we need to work on the remaining exponent that is the right-padded zeros
        // We need to do this in chunks, as 10^exponent may be larger than ulong.MaxValue
        int remainingExponent = maxSignificandIndex - maxRealSignificandIndex;
        if (remainingExponent > 0)
        {
            int count = Math.DivRem(remainingExponent, MaxExponent, out int lastExponent);
            for (int i = 0; i < count; ++i)
            {
                remainder = (remainder * (MaxTenPowExponent % divisor)) % divisor;
            }

            if (lastExponent > 0)
            {
                remainder = (remainder * (TenPowTable[lastExponent] % divisor)) % divisor;
            }
        }

        // Note that the remainder is not the *true* remainder - we have not corrected for any initial
        // exponent scaling; however, this is not necessary as we are only interested in the comparison with zero.
        return remainder == 0;
    }

    private static bool GeneralPurposeIsMultipleOf(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex, System.Numerics.BigInteger divisor)
    {
        // Step 5.
        // for each index i, from 0 to the length of the significand, accumulate the remainder using the mod of the divisor
        // i.e. remainder = (remainder * 10 + digitValue) % divisor;
        // Use the GetDigitAtPosition() method to get the digit value using the integral and fractional parts, and the net exponent.
        // Return remainder == 0.
        // By using a ulong for the divisor, we support ~19 digits of precision in the divisor

        System.Numerics.BigInteger remainder = 0;

        int maxRealSignificandIndex = integral.Length + fractional.Length;

        for (int i = 0; i < maxRealSignificandIndex; ++i)
        {
            remainder = (remainder * 10 + GetValueAtPosition(integral, fractional, i)) % divisor;
        }

        // Now, we need to work on the remaining exponent that is the right-padded zeros
        // We need to do this in chunks, as 10^exponent may be larger than ulong.MaxValue
        int remainingExponent = maxSignificandIndex - maxRealSignificandIndex;
        if (remainingExponent > 0)
        {
            int count = Math.DivRem(remainingExponent, MaxExponent, out int lastExponent);
            for (int i = 0; i < count; ++i)
            {
                remainder = (remainder * (MaxTenPowExponent % divisor)) % divisor;
            }

            if (lastExponent > 0)
            {
                remainder = (remainder * (TenPowTable[lastExponent] % divisor)) % divisor;
            }
        }

        // Note that the remainder is not the *true* remainder - we have not corrected for any initial
        // exponent scaling; however, this is not necessary as we are only interested in the comparison with zero.
        return remainder == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte GetValueAtPosition(ReadOnlySpan<byte> integral, ReadOnlySpan<byte> fractional, int maxSignificandIndex)
    {
        return (byte)(GetDigitAtPosition(integral, fractional, maxSignificandIndex) - (byte)'0');
    }
}
