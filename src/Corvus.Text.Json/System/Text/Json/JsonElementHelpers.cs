// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Buffers.Text;


#if !NET
using System.Collections.Concurrent;
#endif

using System.Diagnostics;
using System.Runtime.CompilerServices;

#if !NET
using System.Reflection;
using System.Reflection.Emit;
#endif

namespace Corvus.Text.Json
{
    /// <summary>
    /// Extension methods for <see cref="IJsonElement"/>.
    /// </summary>
    public static class JsonElementHelpers
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

        public static JsonValueKind ToValueKind(this JsonTokenType tokenType)
        {
            switch (tokenType)
            {
                case JsonTokenType.None:
                    return JsonValueKind.Undefined;
                case JsonTokenType.StartArray:
                    return JsonValueKind.Array;
                case JsonTokenType.StartObject:
                    return JsonValueKind.Object;
                case JsonTokenType.String:
                case JsonTokenType.Number:
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.Null:
                    // This is the offset between the set of literals within JsonValueType and JsonTokenType
                    // Essentially: JsonTokenType.Null - JsonValueType.Null
                    return (JsonValueKind)((byte)tokenType - 4);
                default:
                    Debug.Fail($"No mapping for token type {tokenType}");
                    return JsonValueKind.Undefined;
            }
        }

#if !NET
        // Creation delegate
        private delegate T CreateJsonElementInstance<T>(IJsonDocument document, int index) where T : struct, IJsonElement<T>;

        private static readonly ConcurrentDictionary<Type, object> Creators = [];

        [CLSCompliant(false)]
        public static T CreateInstance<T>(IJsonDocument parentDocument, int parentDocumentIndex)
            where T : struct, IJsonElement<T>
        {
            CreateJsonElementInstance<T> creator = (CreateJsonElementInstance<T>)Creators.GetOrAdd(typeof(T), BuildCreator);
            return creator(parentDocument, parentDocumentIndex);

            static CreateJsonElementInstance<T> BuildCreator(Type type)
            {
                Type[] parameters = [typeof(IJsonDocument), typeof(int)];
                ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, parameters, null)
                    ??  throw new InvalidOperationException(SR.Format(SR.TypeDoesNotHaveAConstructorWithTheRequiredSignature, type));

                var dynamic = new DynamicMethod(
                    $"Corvus.Text.Json.IJsonElement.Create_{type.FullName}",
                    typeof(T),
                    parameters,
                    true);

                ILGenerator il = dynamic.GetILGenerator();

                // Emit code to call the WriteNumberValue method
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Newobj, constructor);
                il.Emit(OpCodes.Ret);

                return (CreateJsonElementInstance<T>)dynamic.CreateDelegate(typeof(CreateJsonElementInstance<T>));
            }
        }
#endif
        /// <summary>
        /// Compares the values of two <see cref="IJsonElement"/> values for equality, including the values of all descendant elements.
        /// </summary>
        /// <typeparam name="TLeft">The type of the first <see cref="IJsonElement"/>.</typeparam>
        /// <typeparam name="TLeft">The type of the first <see cref="IJsonElement"/>.</typeparam>
        /// <param name="element1">The first <see cref="IJsonElement"/> to compare.</param>
        /// <param name="element2">The second <see cref="IJsonElement"/> to compare.</param>
        /// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// Deep equality of two JSON values is defined as follows:
        /// <list type="bullet">
        /// <item>JSON values of different kinds are not equal.</item>
        /// <item>JSON constants <see langword="null"/>, <see langword="false"/>, and <see langword="true"/> only equal themselves.</item>
        /// <item>JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used.</item>
        /// <item>JSON strings are equal if and only if they are equal using ordinal string comparison.</item>
        /// <item>JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal.</item>
        /// <item>
        ///     JSON objects are equal if and only if they have the same number of properties and each property in the first object
        ///     has a corresponding property in the second object with the same name and equal value. The order of properties is not
        ///     significant. Repeated properties are not supported, though they will resolve each value in the second instance to the
        ///     last value in the first instance.
        /// </item>
        /// </list>
        /// </remarks>
        [CLSCompliant(false)]
        public static bool DeepEquals<TLeft, TRight>(in TLeft element1, in TRight element2)
            where TLeft : struct, IJsonElement
            where TRight : struct, IJsonElement
        {
            // We check valid instances once at the top, and then use the document directly throughout
            element1.CheckValidInstance();
            element2.CheckValidInstance();

            JsonValueKind kind = element1.ValueKind;
            if (kind != element2.ValueKind)
            {
                return false;
            }

            switch (kind)
            {
                case JsonValueKind.Null or JsonValueKind.False or JsonValueKind.True:
                    return true;

                case JsonValueKind.Number:
                {
                    IJsonDocument element1ParentDocument = element1.ParentDocument;
                    IJsonDocument element2ParentDocument = element2.ParentDocument;
                    int element1ParentDocumentIndex = element1.ParentDocumentIndex;
                    int element2ParentDocumentIndex = element2.ParentDocumentIndex;
                    return AreEqualJsonNumbers(
                        element1ParentDocument.GetRawSimpleValue(element1ParentDocumentIndex, includeQuotes: false).Span,
                        element2ParentDocument.GetRawSimpleValue(element2ParentDocumentIndex, includeQuotes: false).Span);
                }

                case JsonValueKind.String:
                {
                    IJsonDocument element1ParentDocument = element1.ParentDocument;
                    IJsonDocument element2ParentDocument = element2.ParentDocument;
                    int element1ParentDocumentIndex = element1.ParentDocumentIndex;
                    int element2ParentDocumentIndex = element2.ParentDocumentIndex;
                    if (element2ParentDocument.ValueIsEscaped(element2ParentDocumentIndex, isPropertyName: false))
                    {
                        if (element1ParentDocument.ValueIsEscaped(element1ParentDocumentIndex, isPropertyName: false))
                        {
                            // Need to unescape and compare both inputs.
                            return JsonReaderHelper.UnescapeAndCompareBothInputs(
                                element1ParentDocument.GetRawSimpleValue(element1ParentDocumentIndex, includeQuotes: false).Span,
                                element2ParentDocument.GetRawSimpleValue(element2ParentDocumentIndex, includeQuotes: false).Span);
                        }

                        // Note that we do not require the TokenType null test of the JsonElement ValueEquals, as this is TokenType string
                        // Swap values so that unescaping is handled by the LHS.
                        return element2ParentDocument.TextEquals(
                            element2ParentDocumentIndex,
                            element1ParentDocument.GetRawSimpleValue(element1ParentDocumentIndex, includeQuotes: false).Span,
                            isPropertyName: false,
                            shouldUnescape: true);
                    }

                    // As above, note that we do not require the TokenType null test of the JsonElement ValueEquals, as this is TokenType string
                    return element1ParentDocument.TextEquals(
                        element1ParentDocumentIndex,
                        element2ParentDocument.GetRawSimpleValue(element2ParentDocumentIndex, includeQuotes: false).Span,
                        isPropertyName: false,
                        shouldUnescape: true);
                }

                case JsonValueKind.Array:
                {
                    IJsonDocument element1ParentDocument = element1.ParentDocument;
                    IJsonDocument element2ParentDocument = element2.ParentDocument;
                    int element1ParentDocumentIndex = element1.ParentDocumentIndex;
                    int element2ParentDocumentIndex = element2.ParentDocumentIndex;

                    if (element1ParentDocument.GetArrayLength(element1ParentDocumentIndex) != element2ParentDocument.GetArrayLength(element2ParentDocumentIndex))
                    {
                        return false;
                    }

                    ArrayEnumerator<JsonElement> arrayEnumerator2 = new(element2ParentDocument, element2ParentDocumentIndex);
                    foreach (JsonElement e1 in new ArrayEnumerator<JsonElement>(element1ParentDocument, element1ParentDocumentIndex))
                    {
                        bool success = arrayEnumerator2.MoveNext();
                        Debug.Assert(success, "enumerators must have matching length");

                        if (!DeepEquals(e1, arrayEnumerator2.Current))
                        {
                            return false;
                        }
                    }

                    Debug.Assert(!arrayEnumerator2.MoveNext());
                    return true;
                }

                default:
                {
                    Debug.Assert(kind is JsonValueKind.Object);
                    IJsonDocument element1ParentDocument = element1.ParentDocument;
                    IJsonDocument element2ParentDocument = element2.ParentDocument;
                    int element1ParentDocumentIndex = element1.ParentDocumentIndex;
                    int element2ParentDocumentIndex = element2.ParentDocumentIndex;

                    int count = element1ParentDocument.GetPropertyCount(element1ParentDocumentIndex);
                    if (count != element2ParentDocument.GetPropertyCount(element2ParentDocumentIndex))
                    {
                        return false;
                    }

                    ObjectEnumerator<JsonElement> objectEnumerator1 = new(element1ParentDocument, element1ParentDocumentIndex);
                    ObjectEnumerator<JsonElement> objectEnumerator2 = new(element2ParentDocument, element2ParentDocumentIndex);

                    // Two JSON objects are considered equal if they define the same set of properties.
                    // Start optimistically with pairwise comparison, but fall back to unordered
                    // comparison as soon as a mismatch is encountered.

                    while (objectEnumerator1.MoveNext())
                    {
                        bool success = objectEnumerator2.MoveNext();
                        Debug.Assert(success, "enumerators should have matching lengths");

                        JsonProperty<JsonElement> prop1 = objectEnumerator1.Current;
                        JsonProperty<JsonElement> prop2 = objectEnumerator2.Current;

                        if (!NameEquals(prop1, prop2))
                        {
                            // We have our first mismatch, fall back to unordered comparison.
                            return UnorderedObjectDeepEquals(element1ParentDocument, element1ParentDocumentIndex, ref objectEnumerator2);
                        }

                        if (!DeepEquals(prop1.Value, prop2.Value))
                        {
                            return false;
                        }

                        count--;
                    }

                    Debug.Assert(!objectEnumerator2.MoveNext());
                    return true;
                }
            }

            static bool UnorderedObjectDeepEquals(IJsonDocument element1ParentDocument, int element1ParentDocumentIndex, ref ObjectEnumerator<JsonElement> objectEnumerator2)
            {
                // JsonElement objects allow duplicate property names, which is optional per the JSON RFC.
                // Even though this implementation of equality does not take property ordering into account,
                // duplicate, out of order properties resolve the value in the second instance to the last value
                // in the first instance. This differs from the System.Text.Json.JsonElement implementation, which supports duplicate
                // property names, if they are in order.
                //
                // Note that this is because we *do not* support duplicate property names in our JSON Schema implementation.
                element1ParentDocument.EnsurePropertyMap(element1ParentDocumentIndex);

                Span<byte> buffer = stackalloc byte[JsonConstants.StackallocByteThreshold];

                do
                {
                    JsonProperty<JsonElement> right = objectEnumerator2.Current;
                    JsonElement leftValue;
                    if (right.NameIsEscaped)
                    {
                        ReadOnlySpan<byte> rightNameSpan = right.RawNameSpan;
                        int index = rightNameSpan.IndexOf(JsonConstants.BackSlash);
                        Debug.Assert(index >= 0, "the name is not escaped");

                        byte[]? unescapedRightNameArray = null;

                        Span<byte> unescapedRightNameSpan = rightNameSpan.Length <= JsonConstants.StackallocByteThreshold ?
                            buffer :
                            (unescapedRightNameArray = ArrayPool<byte>.Shared.Rent(rightNameSpan.Length));

                        JsonReaderHelper.Unescape(rightNameSpan, unescapedRightNameSpan, index, out int written);
                        unescapedRightNameSpan = unescapedRightNameSpan.Slice(0, written);
                        Debug.Assert(!unescapedRightNameSpan.IsEmpty);


                        try
                        {
                            if (!element1ParentDocument.TryGetNamedPropertyValue(element1ParentDocumentIndex, unescapedRightNameSpan, out leftValue) ||
                                !DeepEquals(leftValue, right.Value))
                            {
                                return false;
                            }
                        }
                        finally
                        {
                            if (unescapedRightNameArray != null)
                            {
                                unescapedRightNameSpan.Clear();
                                ArrayPool<byte>.Shared.Return(unescapedRightNameArray);
                            }
                        }
                    }
                    else
                    {
                        if (!element1ParentDocument.TryGetNamedPropertyValue(element1ParentDocumentIndex, right.RawNameSpan, out leftValue) ||
                            !DeepEquals(leftValue, right.Value))
                        {
                            return false;
                        }
                    }


                }
                while (objectEnumerator2.MoveNext());

                return true;
            }

            static bool NameEquals(JsonProperty<JsonElement> left, JsonProperty<JsonElement> right)
            {
                if (right.NameIsEscaped)
                {
                    if (left.NameIsEscaped)
                    {
                        // Need to unescape and compare both inputs.
                        return JsonReaderHelper.UnescapeAndCompareBothInputs(left.RawNameSpan, right.RawNameSpan);
                    }

                    // Swap values so that unescaping is handled by the LHS
                    (left, right) = (right, left);
                }

                return left.NameEquals(right.RawNameSpan);
            }
        }

        public static int GetUtf8StringLength(ReadOnlySpan<byte> span)
        {
            if (span.Length == 0)
            {
                return 0;
            }

            int length = 0;
            ReadOnlySpan<byte> currentSpan = span;
            do
            {
                OperationStatus status = Rune.DecodeFromUtf8(currentSpan, out _, out int bytesConsumed);
                if (status != OperationStatus.Done)
                {
                    ThrowHelper.ThrowArgumentException_InvalidUTF8(span);
                }

                currentSpan = currentSpan.Slice(bytesConsumed);
                length++;
            }
            while (currentSpan.Length > 0);

            return length;
        }

        [CLSCompliant(false)]
        public static (IJsonDocument parentDocument, int parentDocumentIndex) GetParentDocumentAndIndex<TElement>(TElement value)
            where TElement : struct, IJsonElement<TElement>
        {
            value.CheckValidInstance();
            return (value.ParentDocument, value.ParentDocumentIndex);
        }

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
        /// Determines if a JSON number is an integer.
        /// </summary>
        /// <param name="integral">When concatenated with <paramref name="fractional"/> produces the significand of the number without leading or trailing zeros.</param>
        /// <param name="fractional">When concatenated with <paramref name="integral"/> produces the significand of the number without leading or trailing zeros.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>True if the normalized JSON number represents an integer.</returns>
        public static bool IsIntegerNormalizedJsonNumber(
            ReadOnlySpan<byte> integral,
            ReadOnlySpan<byte> fractional,
            int exponent)
        {
            return (integral.Length == 0 && fractional.Length == 0) || exponent >= fractional.Length;
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
        [CLSCompliant(false)]
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
