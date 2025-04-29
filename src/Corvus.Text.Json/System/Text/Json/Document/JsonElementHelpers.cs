// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;

namespace Corvus.Text.Json
{
    /// <summary>
    /// Extension methods for <see cref="IJsonElement"/>.
    /// </summary>
    public static class JsonElementHelpers
    {
        /// <summary>
        /// Compares the values of two <see cref="JsonElement"/> values for equality, including the values of all descendant elements.
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
        ///     significant, with the exception of repeated properties that must be specified in the same order (with interleaving allowed).
        /// </item>
        /// </list>
        /// </remarks>
        [CLSCompliant(false)]
        public static bool DeepEquals<TLeft, TRight>(TLeft element1, TRight element2)
            where TLeft : struct, IJsonElement
            where TRight : struct, IJsonElement
        {
            if (!StackHelper.TryEnsureSufficientExecutionStack())
            {
                ThrowHelper.ThrowInsufficientExecutionStackException_JsonElementDeepEqualsInsufficientExecutionStack();
            }

            // We check valid instances once at the top, and then use the document directly throughout
            element1.CheckValidInstance();
            element2.CheckValidInstance();

            JsonValueKind kind = element1.ValueKind;
            if (kind != element2.ValueKind)
            {
                return false;
            }

            IJsonDocument element1ParentDocument = element1.ParentDocument;
            IJsonDocument element2ParentDocument = element2.ParentDocument;
            int element1ParentDocumentHandle = element1.ParentDocumentHandle;
            int element2ParentDocumentHandle = element2.ParentDocumentHandle;
            switch (kind)
            {
                case JsonValueKind.Null or JsonValueKind.False or JsonValueKind.True:
                    return true;

                case JsonValueKind.Number:
                    return JsonHelpers.AreEqualJsonNumbers(
                        element1ParentDocument.GetRawValue(element1ParentDocumentHandle, includeQuotes: false).Span,
                        element2ParentDocument.GetRawValue(element2ParentDocumentHandle, includeQuotes: false).Span);

                case JsonValueKind.String:
                    if (element2ParentDocument.ValueIsEscaped(element2ParentDocumentHandle, isPropertyName: false))
                    {
                        if (element1ParentDocument.ValueIsEscaped(element1ParentDocumentHandle, isPropertyName: false))
                        {
                            // Need to unescape and compare both inputs.
                            return JsonReaderHelper.UnescapeAndCompareBothInputs(
                                element1ParentDocument.GetRawValue(element1ParentDocumentHandle, includeQuotes: false).Span,
                                element2ParentDocument.GetRawValue(element2ParentDocumentHandle, includeQuotes: false).Span);
                        }

                        // Note that we do not require the TokenType null test of the JsonElement ValueEquals, as this is TokenType string
                        // Swap values so that unescaping is handled by the LHS.
                        return element2ParentDocument.TextEquals(
                            element2ParentDocumentHandle,
                            element1ParentDocument.GetRawValue(element1ParentDocumentHandle, includeQuotes: false).Span,
                            isPropertyName: false,
                            shouldUnescape: true);                            
                    }

                    // As above, note that we do not require the TokenType null test of the JsonElement ValueEquals, as this is TokenType string
                    return element1ParentDocument.TextEquals(
                        element1ParentDocumentHandle,
                        element2ParentDocument.GetRawValue(element2ParentDocumentHandle, includeQuotes: false).Span,
                        isPropertyName: false,
                        shouldUnescape: true);

                case JsonValueKind.Array:
                    if (element1ParentDocument.GetArrayLength(element1ParentDocumentHandle) != element2ParentDocument.GetArrayLength(element2ParentDocumentHandle))
                    {
                        return false;
                    }

                    ArrayEnumerator arrayEnumerator2 = new(element2ParentDocument, element2ParentDocumentHandle);
                    foreach (JsonElement e1 in new ArrayEnumerator(element1ParentDocument, element1ParentDocumentHandle))
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

                default:
                    Debug.Assert(kind is JsonValueKind.Object);

                    int count = element1ParentDocument.GetPropertyCount(element1ParentDocumentHandle);
                    if (count != element2ParentDocument.GetPropertyCount(element2ParentDocumentHandle))
                    {
                        return false;
                    }

                    ObjectEnumerator objectEnumerator1 = new (element1ParentDocument, element1ParentDocumentHandle);
                    ObjectEnumerator objectEnumerator2 = new (element2ParentDocument, element2ParentDocumentHandle);

                    // Two JSON objects are considered equal if they define the same set of properties.
                    // Start optimistically with pairwise comparison, but fall back to unordered
                    // comparison as soon as a mismatch is encountered.

                    while (objectEnumerator1.MoveNext())
                    {
                        bool success = objectEnumerator2.MoveNext();
                        Debug.Assert(success, "enumerators should have matching lengths");

                        JsonProperty prop1 = objectEnumerator1.Current;
                        JsonProperty prop2 = objectEnumerator2.Current;

                        if (!NameEquals(prop1, prop2))
                        {
                            // We have our first mismatch, fall back to unordered comparison.
                            return UnorderedObjectDeepEquals(element1ParentDocument, element1ParentDocumentHandle, ref objectEnumerator2);
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

            static bool UnorderedObjectDeepEquals(IJsonDocument element1ParentDocument, int element1ParentDocumentHandle, ref ObjectEnumerator objectEnumerator2)
            {
                // JsonElement objects allow duplicate property names, which is optional per the JSON RFC.
                // Even though this implementation of equality does not take property ordering into account,
                // duplicate, out of order properties resolve the value in the second instance to the last value
                // in the first instance. This differs from the JsonElement implementation, which supports duplicate
                // property names, if they are in order.
                // Note that this is because we *do not* support duplicate property names in our JSON Schema implementation.
                element1ParentDocument.EnsurePropertyMap(element1ParentDocumentHandle);

                Span<byte> buffer = stackalloc byte[JsonConstants.StackallocByteThreshold];

                do
                {
                    JsonProperty right = objectEnumerator2.Current;
                    JsonElement leftValue;
                    if (right.NameIsEscaped)
                    {
                        ReadOnlySpan<byte> rightNameSpan = right.NameSpan;
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
                            if (!element1ParentDocument.TryGetNamedPropertyValue(element1ParentDocumentHandle, unescapedRightNameSpan, out leftValue) ||
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
                        if (!element1ParentDocument.TryGetNamedPropertyValue(element1ParentDocumentHandle, right.NameSpan, out leftValue) ||
                            !DeepEquals(leftValue, right.Value))
                        {
                            return false;
                        }
                    }


                }
                while (objectEnumerator2.MoveNext());

                return true;
            }

            static bool NameEquals(JsonProperty left, JsonProperty right)
            {
                if (right.NameIsEscaped)
                {
                    if (left.NameIsEscaped)
                    {
                        // Need to unescape and compare both inputs.
                        return JsonReaderHelper.UnescapeAndCompareBothInputs(left.NameSpan, right.NameSpan);
                    }

                    // Swap values so that unescaping is handled by the LHS
                    (left, right) = (right, left);
                }

                return left.NameEquals(right.NameSpan);
            }
        }
    }
}
