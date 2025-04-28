// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Corvus.Text.Json
{
    internal static partial class JsonHelpers
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
        /// Returns the unescaped span for the given reader.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<byte> GetUnescapedSpan(this scoped ref Utf8JsonReader reader)
        {
            Debug.Assert(reader.TokenType is JsonTokenType.String or JsonTokenType.PropertyName);
            ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
            return reader.ValueIsEscaped ? JsonReaderHelper.GetUnescapedSpan(span) : span;
        }

        /// <summary>
        /// Attempts to perform a Read() operation and optionally checks that the full JSON value has been buffered.
        /// The reader will be reset if the operation fails.
        /// </summary>
        /// <param name="reader">The reader to advance.</param>
        /// <param name="requiresReadAhead">If reading a partial payload, read ahead to ensure that the full JSON value has been buffered.</param>
        /// <returns>True if the reader has been buffered with all required data.</returns>
        // AggressiveInlining used since this method is on a hot path and short. The AdvanceWithReadAhead method should not be inlined.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdvanceWithOptionalReadAhead(this scoped ref Utf8JsonReader reader, bool requiresReadAhead)
        {
            // No read-ahead necessary if we're at the final block of JSON data.
            bool readAhead = requiresReadAhead && !reader.IsFinalBlock;
            return readAhead ? TryAdvanceWithReadAhead(ref reader) : reader.Read();
        }

        /// <summary>
        /// Attempts to read ahead to the next root-level JSON value, if it exists.
        /// </summary>
        public static bool TryAdvanceToNextRootLevelValueWithOptionalReadAhead(this scoped ref Utf8JsonReader reader, bool requiresReadAhead, out bool isAtEndOfStream)
        {
            Debug.Assert(reader.AllowMultipleValues, "only supported by readers that support multiple values.");
            Debug.Assert(reader.CurrentDepth == 0, "should only invoked for top-level values.");

            Utf8JsonReader checkpoint = reader;
            if (!reader.Read())
            {
                // If the reader didn't return any tokens and it's the final block,
                // then there are no other JSON values to be read.
                isAtEndOfStream = reader.IsFinalBlock;
                reader = checkpoint;
                return false;
            }

            // We found another JSON value, read ahead accordingly.
            isAtEndOfStream = false;
            if (requiresReadAhead && !reader.IsFinalBlock)
            {
                // Perform full read-ahead to ensure the full JSON value has been buffered.
                reader = checkpoint;
                return TryAdvanceWithReadAhead(ref reader);
            }

            return true;
        }

        private static bool TryAdvanceWithReadAhead(scoped ref Utf8JsonReader reader)
        {
            // When we're reading ahead we always have to save the state
            // as we don't know if the next token is a start object or array.
            Utf8JsonReader restore = reader;

            if (!reader.Read())
            {
                return false;
            }

            // Perform the actual read-ahead.
            JsonTokenType tokenType = reader.TokenType;
            if (tokenType is JsonTokenType.StartObject or JsonTokenType.StartArray)
            {
                // Attempt to skip to make sure we have all the data we need.
                bool complete = reader.TrySkipPartial();

                // We need to restore the state in all cases as we need to be positioned back before
                // the current token to either attempt to skip again or to actually read the value.
                reader = restore;

                if (!complete)
                {
                    // Couldn't read to the end of the object, exit out to get more data in the buffer.
                    return false;
                }

                // Success, requeue the reader to the start token.
                reader.ReadWithVerify();
                Debug.Assert(tokenType == reader.TokenType);
            }

            return true;
        }

#if !NET
        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is a valid Unicode scalar
        /// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidUnicodeScalar(uint value)
        {
            // By XORing the incoming value with 0xD800, surrogate code points
            // are moved to the range [ U+0000..U+07FF ], and all valid scalar
            // values are clustered into the single range [ U+0800..U+10FFFF ],
            // which allows performing a single fast range check.

            return IsInRangeInclusive(value ^ 0xD800U, 0x800U, 0x10FFFFU);
        }
#endif

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is between
        /// <paramref name="lowerBound"/> and <paramref name="upperBound"/>, inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRangeInclusive(uint value, uint lowerBound, uint upperBound)
            => (value - lowerBound) <= (upperBound - lowerBound);

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is between
        /// <paramref name="lowerBound"/> and <paramref name="upperBound"/>, inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRangeInclusive(int value, int lowerBound, int upperBound)
            => (uint)(value - lowerBound) <= (uint)(upperBound - lowerBound);

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is between
        /// <paramref name="lowerBound"/> and <paramref name="upperBound"/>, inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRangeInclusive(long value, long lowerBound, long upperBound)
            => (ulong)(value - lowerBound) <= (ulong)(upperBound - lowerBound);

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is between
        /// <paramref name="lowerBound"/> and <paramref name="upperBound"/>, inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRangeInclusive(JsonTokenType value, JsonTokenType lowerBound, JsonTokenType upperBound)
            => (value - lowerBound) <= (upperBound - lowerBound);

        /// <summary>
        /// Returns <see langword="true"/> if <paramref name="value"/> is in the range [0..9].
        /// Otherwise, returns <see langword="false"/>.
        /// </summary>
        public static bool IsDigit(byte value) => (uint)(value - '0') <= '9' - '0';

        /// <summary>
        /// Perform a Read() with a Debug.Assert verifying the reader did not return false.
        /// This should be called when the Read() return value is not used, such as non-Stream cases where there is only one buffer.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadWithVerify(this ref Utf8JsonReader reader)
        {
            bool result = reader.Read();
            Debug.Assert(result);
        }

        /// <summary>
        /// Performs a TrySkip() with a Debug.Assert verifying the reader did not return false.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipWithVerify(this ref Utf8JsonReader reader)
        {
            bool success = reader.TrySkipPartial(reader.CurrentDepth);
            Debug.Assert(success, "The skipped value should have already been buffered.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TrySkipPartial(this ref Utf8JsonReader reader)
        {
            return reader.TrySkipPartial(reader.CurrentDepth);
        }

        /// <summary>
        /// Calls Encoding.UTF8.GetString that supports netstandard.
        /// </summary>
        /// <param name="bytes">The utf8 bytes to convert.</param>
        /// <returns></returns>
        public static string Utf8GetString(ReadOnlySpan<byte> bytes)
        {
#if NET
            return Encoding.UTF8.GetString(bytes);
#else
            if (bytes.Length == 0)
            {
                return string.Empty;
            }

            unsafe
            {
                fixed (byte* bytesPtr = bytes)
                {
                    return Encoding.UTF8.GetString(bytesPtr, bytes.Length);
                }
            }
#endif
        }

        public static bool TryLookupUtf8Key<TValue>(
            this Dictionary<string, TValue> dictionary,
            ReadOnlySpan<byte> utf8Key,
            [MaybeNullWhen(false)] out TValue result)
        {
#if NET9_0_OR_GREATER
            Debug.Assert(dictionary.Comparer is IAlternateEqualityComparer<ReadOnlySpan<char>, string>);

            Dictionary<string, TValue>.AlternateLookup<ReadOnlySpan<char>> spanLookup =
                dictionary.GetAlternateLookup<ReadOnlySpan<char>>();

            char[]? rentedBuffer = null;

            Span<char> charBuffer = utf8Key.Length <= JsonConstants.StackallocCharThreshold ?
                stackalloc char[JsonConstants.StackallocCharThreshold] :
                (rentedBuffer = ArrayPool<char>.Shared.Rent(utf8Key.Length));

            int charsWritten = Encoding.UTF8.GetChars(utf8Key, charBuffer);
            Span<char> decodedKey = charBuffer[0..charsWritten];

            bool success = spanLookup.TryGetValue(decodedKey, out result);

            if (rentedBuffer != null)
            {
                decodedKey.Clear();
                ArrayPool<char>.Shared.Return(rentedBuffer);
            }

            return success;
#else
            string key = Utf8GetString(utf8Key);
            return dictionary.TryGetValue(key, out result);
#endif
        }

        /// <summary>
        /// Emulates Dictionary(IEnumerable{KeyValuePair}) on netstandard.
        /// </summary>
        public static Dictionary<TKey, TValue> CreateDictionaryFromCollection<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> collection,
            IEqualityComparer<TKey> comparer)
            where TKey : notnull
        {
#if !NET
            var dictionary = new Dictionary<TKey, TValue>(comparer);

            foreach (KeyValuePair<TKey, TValue> item in collection)
            {
                dictionary.Add(item.Key, item.Value);
            }

            return dictionary;
#else
            return new Dictionary<TKey, TValue>(collection: collection, comparer);
#endif
        }

        public static bool IsFinite(double value)
        {
#if NET
            return double.IsFinite(value);
#else
            return !(double.IsNaN(value) || double.IsInfinity(value));
#endif
        }

        public static bool IsFinite(float value)
        {
#if NET
            return float.IsFinite(value);
#else
            return !(float.IsNaN(value) || float.IsInfinity(value));
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateInt32MaxArrayLength(uint length)
        {
            if (length > 0X7FEFFFFF) // prior to .NET 6, max array length for sizeof(T) != 1 (size == 1 is larger)
            {
                ThrowHelper.ThrowOutOfMemoryException(length);
            }
        }

#if !NET8_0_OR_GREATER
        public static bool HasAllSet(this BitArray bitArray)
        {
            for (int i = 0; i < bitArray.Count; i++)
            {
                if (!bitArray[i])
                {
                    return false;
                }
            }

            return true;
        }
#endif

        /// <summary>
        /// Gets a Regex instance for recognizing integer representations of enums.
        /// </summary>
        public static readonly Regex IntegerRegex = CreateIntegerRegex();
        private const string IntegerRegexPattern = @"^\s*(?:\+|\-)?[0-9]+\s*$";
        private const int IntegerRegexTimeoutMs = 200;

#if NET
        [GeneratedRegex(IntegerRegexPattern, RegexOptions.None, matchTimeoutMilliseconds: IntegerRegexTimeoutMs)]
        private static partial Regex CreateIntegerRegex();
#else
        private static Regex CreateIntegerRegex() => new(IntegerRegexPattern, RegexOptions.Compiled, TimeSpan.FromMilliseconds(IntegerRegexTimeoutMs));
#endif

        /// <summary>
        /// Compares two valid UTF-8 encoded JSON numbers for decimal equality.
        /// </summary>
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
        public static bool AreEqualNormalizedJsonNumbers(bool leftIsNegative, ReadOnlySpan<byte> leftIntegral, ReadOnlySpan<byte> leftFractional, int leftExponent, bool rightIsNegative, ReadOnlySpan<byte> rightIntegral, ReadOnlySpan<byte> rightFractional, int rightExponent)
        {
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
        /// Compares two JSON numbers.
        /// </summary>
        /// <param name="left">The left number.</param>
        /// <param name="right">The right number.</param>
        /// <returns>-1 if the LHS is less than the RHS, 0 if they are equal, and 1 if the LHS is greater than the RHS.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CompareJsonNumbers(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
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

            return CompareNormalizedJsonNumbers(leftIsNegative, leftIntegral, leftFractional, leftExponent, rightIsNegative, rightIntegral, rightFractional, rightExponent);
        }

        /// <summary>
        /// Compares two normalized JSON numbers for equality.
        /// </summary>
        /// <param name="leftIsNegative">True if the LHS is negative.</param>
        /// <param name="leftIntegral">When concatenated with <paramref name="leftFractional"/> produces the significand of the LHS number without leading or trailing zeros.</param>
        /// <param name="leftFractional">When concatenated with <paramref name="leftIntegral"/> produces the significand of the LHS number without leading or trailing zeros.</param>
        /// <param name="leftExponent">The LHS exponent.</param>
        /// <param name="rightIntegral">When concatenated with <paramref name="rightFractional"/> produces the significand of the RHS number without leading or trailing zeros.</param>
        /// <param name="rightFractional">When concatenated with <paramref name="rightIntegral"/> produces the significand of the RHS number without leading or trailing zeros.</param>
        /// <param name="rightExponent">The RHS exponent.</param>
        /// <returns>-1 if the LHS is less than the RHS, 0 if the are equal, and 1 if the LHS is greater than the RHS.</returns>
        public static int CompareNormalizedJsonNumbers(
            bool leftIsNegative,
            ReadOnlySpan<byte> leftIntegral,
            ReadOnlySpan<byte> leftFractional,
            int leftExponent,
            bool rightIsNegative,
            ReadOnlySpan<byte> rightIntegral,
            ReadOnlySpan<byte> rightFractional,
            int rightExponent)
        {
            // Step 1: Compare signs
            if (leftIsNegative != rightIsNegative)
            {
                return leftIsNegative ? -1 : 1;
            }

            int signMultiplier = leftIsNegative ? -1 : 1;

            // Step 2: Compare effective magnitudes of the numbers
            int leftEffectiveIntegralLength = leftIntegral.Length + leftExponent;
            int rightEffectiveIntegralLength = rightIntegral.Length + rightExponent;

            if (leftEffectiveIntegralLength != rightEffectiveIntegralLength)
            {
                return (leftEffectiveIntegralLength > rightEffectiveIntegralLength ? 1 : -1) * signMultiplier;
            }

            // Step 3: Compare digits, accounting for exponent difference
            int leftIntegralDigits = Math.Max(-leftExponent, leftIntegral.Length);
            int rightIntegralDigits = Math.Max(-rightExponent, rightIntegral.Length);

            int leftFractionalDigits = Math.Max(leftExponent, leftFractional.Length);
            int rightFractionalDigits = Math.Max(rightExponent, rightFractional.Length);

            int leftDigitLength = leftIntegralDigits + leftFractionalDigits;
            int rightDigitLength = rightIntegralDigits + rightFractionalDigits;

            int leftLeadingZeros = Math.Max(0, leftIntegralDigits - leftIntegral.Length);
            int rightLeadingZeros = Math.Max(0, rightIntegralDigits - rightIntegral.Length);

            int maxDigitLength = Math.Max(leftDigitLength, rightDigitLength);

            // Adjust so we don't bother with matching leading zeros
            if (leftLeadingZeros > rightLeadingZeros)
            {
                leftLeadingZeros -= rightLeadingZeros;
                maxDigitLength -= rightLeadingZeros;
                rightLeadingZeros = 0;
            }
            else
            {
                rightLeadingZeros -= leftLeadingZeros;
                maxDigitLength -= leftLeadingZeros;
                leftLeadingZeros = 0;
            }

            for (int i = 0; i < maxDigitLength; i++)
            {
                byte leftDigit = GetDigitAtPosition(leftIntegral, leftFractional, i - leftLeadingZeros);
                byte rightDigit = GetDigitAtPosition(rightIntegral, rightFractional, i - rightLeadingZeros);

                if (leftDigit != rightDigit)
                {
                    return (leftDigit > rightDigit ? 1 : -1) * signMultiplier;
                }
            }

            // Step 4: Numbers are equal
            return 0;
        }

        /// <summary>
        /// Determines whether a valid UTF-8 JSON number is an exact multiple of the given divisor.
        /// </summary>
        /// <param name="value">The UTF-8 JSON number.</param>
        /// <param name="divisor">The integer value of the divisor.</param>
        /// <param name="divisorExponent">The exponent of the divisor (+ve or -ve).</param>
        /// <returns><see langword="true"/> if the value is an exact multiple of <c>divisor * 10^divisorExponent</c>.</returns>
        /// <remarks>
        /// This will always return <see langword="false"/> if the <paramref name="divisor"/> is <c>0</c> and <see langword="true"/>
        /// if the value is zero.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultipleOf(ReadOnlySpan<byte> value, ulong divisor, int divisorExponent)
        {
            ParseNumber(value,
                out _,
                out ReadOnlySpan<byte> integral,
                out ReadOnlySpan<byte> fractional,
                out int exponent);

            return IsMultipleOf(integral, fractional, exponent, divisor, divisorExponent);
        }

        /// <summary>
        /// Determines whether a valid UTF-8 JSON number is an exact multiple of the given divisor.
        /// </summary>
        /// <param name="value">The UTF-8 JSON number.</param>
        /// <param name="divisor">The integer value of the divisor.</param>
        /// <param name="divisorExponent">The exponent of the divisor (+ve or -ve).</param>
        /// <returns><see langword="true"/> if the value is an exact multiple of <c>divisor * 10^divisorExponent</c>.</returns>
        /// <remarks>
        /// This will always return <see langword="false"/> if the <paramref name="divisor"/> is <c>0</c> and <see langword="true"/>
        /// if the value is zero.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultipleOf(ReadOnlySpan<byte> value, System.Numerics.BigInteger divisor, int divisorExponent)
        {
            ParseNumber(value,
                out _,
                out ReadOnlySpan<byte> integral,
                out ReadOnlySpan<byte> fractional,
                out int exponent);

            return IsMultipleOf(integral, fractional, exponent, divisor, divisorExponent);
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
            if (netExponent < fractional.Length)
            {
                return false;
            }

            // Step 4.
            // Determine if the divisor is one of the common "fast path" divisors and use that (e.g. 1, 2, 5, 10) otherwise use the general purpose
            // algorithm
            switch (divisor)
            {
                case 1:
                    return true; // 0 mod 1 == 0
                case 2:
                    return IsDivisibleByTwo(integral, fractional, integral.Length + netExponent - 1);
                case 3:
                    return IsDivisibleByThree(integral, fractional);
                case 4:
                    return IsDivisibleByFour(integral, fractional, integral.Length + netExponent - 1);
                case 5:
                    return IsDivisibleByFive(integral, fractional, integral.Length + netExponent - 1);
                case 6:
                    return IsDivisibleBySix(integral, fractional, integral.Length + netExponent - 1);
                case 8:
                    return IsDivisibleByEight(integral, fractional, integral.Length + netExponent - 1);
                case 10:
                    return IsDivisibleByTen(integral, fractional, integral.Length + netExponent - 1);
                default:
                    return GeneralPurposeIsMultipleOf(integral, fractional, integral.Length + netExponent - 1, divisor);
            }
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
            if (netExponent < fractional.Length)
            {
                return false;
            }

            // Step 4.
            // Determine if the divisor is one of the common "fast path" divisors and use that (e.g. 1, 2, 5, 10) otherwise use the general purpose
            // algorithm
            if (divisor.IsOne)
            {
                return true; // 0 mod 1 == 0
            }

            if (divisor.Equals(2))
            {
                return IsDivisibleByTwo(integral, fractional, integral.Length + netExponent - 1);
            }


            if (divisor.Equals(3))
            {
                return IsDivisibleByThree(integral, fractional);
            }

            if (divisor.Equals(4))
            {
                return IsDivisibleByFour(integral, fractional, integral.Length + netExponent - 1);
            }

            if (divisor.Equals(5))
            {
                return IsDivisibleByFive(integral, fractional, integral.Length + netExponent - 1);
            }

            if (divisor.Equals(6))
            {
                return IsDivisibleBySix(integral, fractional, integral.Length + netExponent - 1);
            }

            if (divisor.Equals(8))
            {
                return IsDivisibleByEight(integral, fractional, integral.Length + netExponent - 1);
            }

            if (divisor.Equals(10))
            {
                return IsDivisibleByTen(integral, fractional, integral.Length + netExponent - 1);
            }

            return GeneralPurposeIsMultipleOf(integral, fractional, integral.Length + netExponent - 1, divisor);
        }

        public static void ParseNumber(
            ReadOnlySpan<byte> span,
            out bool isNegative,
            out ReadOnlySpan<byte> integral,
            out ReadOnlySpan<byte> fractional,
            out int exponent)
        {
            // Parses a JSON number into its integral, fractional, and exponent parts.
            // The returned components use a normal-form decimal representation:
            //
            //   Number := sign * <integral + fractional> * 10^exponent
            //
            // where integral and fractional are sequences of digits whose concatenation
            // represents the significand of the number without leading or trailing zeros.
            // Two such normal-form numbers are treated as equal if and only if they have
            // equal signs, significands, and exponents.

            bool neg;
            ReadOnlySpan<byte> intg;
            ReadOnlySpan<byte> frac;
            int exp;

            Debug.Assert(span.Length > 0);

            if (span[0] == '-')
            {
                neg = true;
                span = span.Slice(1);
            }
            else
            {
                Debug.Assert(char.IsDigit((char)span[0]), "leading plus not allowed in valid JSON numbers.");
                neg = false;
            }

            int i = span.IndexOfAny((byte)'.', (byte)'e', (byte)'E');
            if (i < 0)
            {
                intg = span;
                frac = default;
                exp = 0;
                goto Normalize;
            }

            intg = span.Slice(0, i);

            if (span[i] == '.')
            {
                span = span.Slice(i + 1);
                i = span.IndexOfAny((byte)'e', (byte)'E');
                if (i < 0)
                {
                    frac = span;
                    exp = 0;
                    goto Normalize;
                }

                frac = span.Slice(0, i);
            }
            else
            {
                frac = default;
            }

            Debug.Assert(span[i] is (byte)'e' or (byte)'E');
            if (!Utf8Parser.TryParse(span.Slice(i + 1), out exp, out _))
            {
                Debug.Assert(span.Length >= 10);
                ThrowHelper.ThrowArgumentOutOfRangeException_JsonNumberExponentTooLarge(nameof(exponent));
            }

        Normalize: // Calculates the normal form of the number.

            if (IndexOfFirstTrailingZero(frac) is >= 0 and int iz)
            {
                // Trim trailing zeros from the fractional part.
                // e.g. 3.1400 -> 3.14
                frac = frac.Slice(0, iz);
            }

            if (intg[0] == '0')
            {
                Debug.Assert(intg.Length == 1, "Leading zeros not permitted in JSON numbers.");

                if (IndexOfLastLeadingZero(frac) is >= 0 and int lz)
                {
                    // Trim leading zeros from the fractional part
                    // and update the exponent accordingly.
                    // e.g. 0.000123 -> 0.123e-3
                    frac = frac.Slice(lz + 1);
                    exp -= lz + 1;
                }

                // Normalize "0" to the empty span.
                intg = default;
            }

            if (frac.IsEmpty && IndexOfFirstTrailingZero(intg) is >= 0 and int fz)
            {
                // There is no fractional part, trim trailing zeros from
                // the integral part and increase the exponent accordingly.
                // e.g. 1000 -> 1e3
                exp += intg.Length - fz;
                intg = intg.Slice(0, fz);
            }

            // Normalize the exponent by subtracting the length of the fractional part.
            // e.g. 3.14 -> 314e-2
            exp -= frac.Length;

            if (intg.IsEmpty && frac.IsEmpty)
            {
                // Normalize zero representations.
                neg = false;
                exp = 0;
            }

            // Copy to out parameters.
            isNegative = neg;
            integral = intg;
            fractional = frac;
            exponent = exp;

            static int IndexOfLastLeadingZero(ReadOnlySpan<byte> span)
            {
#if NET
                int firstNonZero = span.IndexOfAnyExcept((byte)'0');
                return firstNonZero < 0 ? span.Length - 1 : firstNonZero - 1;
#else
                    for (int i = 0; i < span.Length; i++)
                    {
                        if (span[i] != '0')
                        {
                            return i - 1;
                        }
                    }

                    return span.Length - 1;
#endif
            }

            static int IndexOfFirstTrailingZero(ReadOnlySpan<byte> span)
            {
#if NET
                int lastNonZero = span.LastIndexOfAnyExcept((byte)'0');
                return lastNonZero == span.Length - 1 ? -1 : lastNonZero + 1;
#else
                    if (span.IsEmpty)
                    {
                        return -1;
                    }

                    for (int i = span.Length - 1; i >= 0; i--)
                    {
                        if (span[i] != '0')
                        {
                            return i == span.Length - 1 ? -1 : i + 1;
                        }
                    }

                    return 0;
#endif
            }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte GetDigitAtPosition(
            ReadOnlySpan<byte> integral,
            ReadOnlySpan<byte> fractional,
            int integralIndex)
        {
            if (integralIndex < integral.Length)
            {
                // Position is in the integral part
                return integralIndex >= 0 ? integral[integralIndex] : (byte)'0';
            }
            else
            {
                // Position is in the fractional part
                int fractionalIndex = integralIndex - integral.Length;
                return fractionalIndex >= 0 && fractionalIndex < fractional.Length ? fractional[fractionalIndex] : (byte)'0';
            }
        }
    }
}
