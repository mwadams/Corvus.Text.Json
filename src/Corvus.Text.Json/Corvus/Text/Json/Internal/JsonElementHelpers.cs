// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;

#if !NET
using System.Collections.Concurrent;
#endif

using System.Diagnostics;

#if !NET
using System.Reflection;
using System.Reflection.Emit;
using Corvus.Text.Json.Internal;
#endif

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides helper methods and utilities for working with JSON elements, including property manipulation,
/// type conversions, string operations, and element metadata retrieval.
/// </summary>
public static partial class JsonElementHelpers
{
    /// <summary>
    /// Sets a property value on a target element.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target element.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="targetElement">The target element instance.</param>
    /// <param name="property">The property to set.</param>
    [CLSCompliant(false)]
    public static void SetPropertyUnsafe<TTarget, TValue>(TTarget targetElement, JsonProperty<TValue> property)
        where TTarget : struct, IMutableJsonElement<TTarget>
        where TValue : struct, IJsonElement<TValue>
    {
        using UnescapedUtf8JsonString name = property.NameSpan;
        IMutableJsonDocument targetParentDocument = (IMutableJsonDocument)targetElement.ParentDocument;
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(targetParentDocument, 30);
        if (targetElement.ParentDocument.TryGetNamedPropertyValue(targetElement.ParentDocumentIndex, name.Span, out TValue value))
        {
            // We are going to replace just the value
            cvb.AddItem(property.Value);
            targetParentDocument.OverwriteAndDispose(
                targetElement.ParentDocumentIndex,
                value.ParentDocumentIndex,
                value.ParentDocumentIndex + value.ParentDocument.GetDbSize(value.ParentDocumentIndex, true),
                1,
                ref cvb);
        }
        else
        {
            cvb.AddProperty(name.Span, property.Value, escapeName: true, nameRequiresUnescaping: false);
            int endIndex = targetElement.ParentDocumentIndex + targetParentDocument.GetDbSize(targetElement.ParentDocumentIndex, false);
            targetParentDocument.InsertAndDispose(targetElement.ParentDocumentIndex, endIndex, ref cvb);
        }
    }

    /// <summary>
    /// Removes a range of items from an array element.
    /// </summary>
    /// <typeparam name="TArray">The type of the array element.</typeparam>
    /// <param name="arrayElement">The array element instance.</param>
    /// <param name="startIndex">The zero-based index at which to begin removing items.</param>
    /// <param name="count">The number of items to remove.</param>
    /// <exception cref="InvalidOperationException">
    ///   The element's <see cref="JsonValueKind"/> is not <see cref="JsonValueKind.Array"/>,
    ///   or the element reference is stale due to document mutations.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="startIndex"/> is negative or greater than the current array length,
    ///   or <paramref name="count"/> is negative or causes the operation to exceed the array bounds.
    /// </exception>
    [CLSCompliant(false)]
    public static void RemoveRangeUnsafe<TArray>(TArray arrayElement, int startIndex, int count)
        where TArray : struct, IMutableJsonElement<TArray>
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (count == 0)
        {
            return; // Nothing to remove
        }

        IMutableJsonDocument parentDocument = (IMutableJsonDocument)arrayElement.ParentDocument;
        int arrayLength = parentDocument.GetArrayLength(arrayElement.ParentDocumentIndex);

        if (startIndex < 0 || startIndex > arrayLength)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (startIndex + count > arrayLength)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        // Get the first element in the range to determine the start index
        parentDocument.GetArrayIndexElement(arrayElement.ParentDocumentIndex, startIndex, out _, out int rangeStartIndex);

        // Get the last element in the range to determine the end index
        parentDocument.GetArrayIndexElement(arrayElement.ParentDocumentIndex, startIndex + count - 1, out IJsonDocument lastElementDoc, out int lastElementIndex);
        int rangeEndIndex = lastElementIndex + lastElementDoc.GetDbSize(lastElementIndex, true);

        // Remove the range using the document's RemoveRange method
        parentDocument.RemoveRange(arrayElement.ParentDocumentIndex, rangeStartIndex, rangeEndIndex, count);
    }


    internal static void RemoveWhereUnsafe<TArray, T>(TArray arrayElement, JsonPredicate<T> predicate)
        where TArray : struct, IMutableJsonElement<TArray>
        where T : struct, IJsonElement<T>
    {
        if (predicate is null)
        {
            ThrowHelper.ThrowArgumentNullException(nameof(predicate));
        }

        IMutableJsonDocument parentDocument = (IMutableJsonDocument)arrayElement.ParentDocument;
        int arrayLength = parentDocument.GetArrayLength(arrayElement.ParentDocumentIndex);
        
        if (arrayLength == 0)
        {
            return; // Nothing to process
        }

        // Enumerate backwards through the array
        ArrayReverseEnumerator enumerator = new(parentDocument, arrayElement.ParentDocumentIndex);
        
        int consecutiveBlockStartIndex = -1; // Start index of first item in consecutive block
        int consecutiveBlockEndIndex = -1;   // End index of last item in consecutive block
        int consecutiveCount = 0;
        
        while (enumerator.MoveNext())
        {
#if NET
            T currentElement = T.CreateInstance(parentDocument, enumerator.CurrentIndex);
#else
            T currentElement = JsonElementHelpers.CreateInstance<T>(parentDocument, enumerator.CurrentIndex);
#endif
            
            if (predicate(in currentElement))
            {
                // This element should be removed
                int currentStartIndex = enumerator.CurrentIndex;
                int currentEndIndex;
                
                if (consecutiveCount == 0)
                {
                    // Start of a new consecutive block
                    consecutiveBlockStartIndex = currentStartIndex;
                    // For the end index, we need the end of this element
                    currentEndIndex = enumerator.CurrentEndIndex + DbRow.Size;
                    consecutiveBlockEndIndex = currentEndIndex;
                    consecutiveCount = 1;
                }
                else
                {
                    // Check if this element is consecutive with the previous block
                    currentEndIndex = enumerator.CurrentEndIndex + DbRow.Size;

                    Debug.Assert(currentEndIndex == consecutiveBlockStartIndex,"The element must be consecutive with the previous block.");
                    consecutiveBlockStartIndex = currentStartIndex;
                    consecutiveCount++;
                }
            }
            else
            {
                // This element should not be removed
                if (consecutiveCount > 0)
                {
                    // Remove the accumulated consecutive block
                    int elementsInBlock = consecutiveCount;
                    parentDocument.RemoveRange(arrayElement.ParentDocumentIndex, consecutiveBlockStartIndex, consecutiveBlockEndIndex, elementsInBlock);
                    consecutiveCount = 0;
                }
            }
        }
        
        // Handle any remaining consecutive block at the end
        if (consecutiveCount > 0)
        {
            int elementsInBlock = consecutiveCount;
            parentDocument.RemoveRange(arrayElement.ParentDocumentIndex, consecutiveBlockStartIndex, consecutiveBlockEndIndex, elementsInBlock);
        }
    }
    /// <summary>
    /// Converts a <see cref="JsonTokenType"/> to its corresponding <see cref="JsonValueKind"/>.
    /// </summary>
    /// <param name="tokenType">The token type to convert.</param>
    /// <returns>The corresponding value kind.</returns>
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

    /// <summary>
    /// Gets the length of a UTF-8 encoded string in characters (not bytes).
    /// </summary>
    /// <param name="span">The UTF-8 encoded byte span.</param>
    /// <returns>The number of Unicode characters in the string.</returns>
    /// <exception cref="ArgumentException">Thrown when the span contains invalid UTF-8 sequences.</exception>
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

    /// <summary>
    /// Gets the parent document and document index for a JSON element.
    /// </summary>
    /// <typeparam name="TElement">The type of the JSON element.</typeparam>
    /// <param name="value">The JSON element value.</param>
    /// <returns>A tuple containing the parent document and the document index.</returns>
    [CLSCompliant(false)]
    public static (IJsonDocument parentDocument, int parentDocumentIndex) GetParentDocumentAndIndex<TElement>(TElement value)
        where TElement : struct, IJsonElement<TElement>
    {
        value.CheckValidInstance();
        return (value.ParentDocument, value.ParentDocumentIndex);
    }
}
