// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;

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
                    return JsonHelpers.AreEqualJsonNumbers(
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
                        if (!element1ParentDocument.TryGetNamedPropertyValue(element1ParentDocumentIndex, right.NameSpan, out leftValue) ||
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
                        return JsonReaderHelper.UnescapeAndCompareBothInputs(left.NameSpan, right.NameSpan);
                    }

                    // Swap values so that unescaping is handled by the LHS
                    (left, right) = (right, left);
                }

                return left.NameEquals(right.NameSpan);
            }
        }

        /////// <summary>
        /////// Compares the values of two <see cref="IJsonElement"/> values for equality, including the values of all descendant elements.
        /////// </summary>
        /////// <param name="element1">The first <see cref="JsonElement"/> to compare.</param>
        /////// <param name="element2">The second <see cref="JsonElement"/> to compare.</param>
        /////// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
        /////// <remarks>
        /////// Deep equality of two JSON values is defined as follows:
        /////// <list type="bullet">
        /////// <item>JSON values of different kinds are not equal.</item>
        /////// <item>JSON constants <see langword="null"/>, <see langword="false"/>, and <see langword="true"/> only equal themselves.</item>
        /////// <item>JSON numbers are equal if and only if they have they have equivalent decimal representations, with no rounding being used.</item>
        /////// <item>JSON strings are equal if and only if they are equal using ordinal string comparison.</item>
        /////// <item>JSON arrays are equal if and only if they are of equal length and each of their elements are pairwise equal.</item>
        /////// <item>
        ///////     JSON objects are equal if and only if they have the same number of properties and each property in the first object
        ///////     has a corresponding property in the second object with the same name and equal value. The order of properties is not
        ///////     significant. Repeated properties are not supported, though they will resolve each value in the second instance to the
        ///////     last value in the first instance.
        /////// </item>
        /////// </list>
        /////// </remarks>
        ////[CLSCompliant(false)]
        ////[MethodImpl(MethodImplOptions.AggressiveInlining)]
        ////public static bool DeepEquals(in JsonElement element1, in JsonElement element2)
        ////{
        ////    return JsonElement.DeepEquals(element1, element2);
        ////}
    }
}
