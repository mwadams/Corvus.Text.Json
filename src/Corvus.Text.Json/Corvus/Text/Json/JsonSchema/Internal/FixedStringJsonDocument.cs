// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Represents a JSON document based on a fixed string value.
/// </summary>
/// <typeparam name="T">The type of the root element in the document.</typeparam>
/// <remarks>
/// This type uses an internal cache to avoid allocations for evaluatoin of string
/// values that have not originated in a regular JSON document (e.g. property names,
/// or external strings.)
/// </remarks>
[CLSCompliant(false)]
public sealed class FixedStringJsonDocument<T> : IJsonDocument
    where T : struct, IJsonElement<T>
{
    private ReadOnlyMemory<byte> _rawJsonStringValue;
    private bool _requiresUnescaping;

    internal FixedStringJsonDocument(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
    {
        _rawJsonStringValue = rawJsonStringValue;
        _requiresUnescaping = requiresUnescaping;
    }

    bool IJsonDocument.IsDisposable => true;

    bool IJsonDocument.IsImmutable => true;


    /// <summary>
    /// Parse an instance of the fixed string to a document, using caching.
    /// </summary>
    /// <param name="rawJsonStringValue">The raw JSON string value, including quotes.</param>
    /// <returns>A fixed string document representing the value, from the cache.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedStringJsonDocument<T> Parse(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
    {
        return Cache.Rent(rawJsonStringValue, requiresUnescaping);
    }

#if NET
    public T RootElement => T.CreateInstance(this, 0);
#else
    public T RootElement => JsonElementHelpers.CreateInstance<T>(this, 0);
#endif

    void IJsonDocument.AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db) { throw new NotSupportedException();  }
    int IJsonDocument.BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, out byte[] rentedBacking) { throw new NotSupportedException(); }
    JsonElement IJsonDocument.CloneElement(int index) => new(this, 0);
    TElement IJsonDocument.CloneElement<TElement>(int index)
    {
#if NET
        return TElement.CreateInstance(this, 0);
#else
        return JsonElementHelpers.CreateInstance<TElement>(this, 0);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IDisposable.Dispose() => Cache.ReturnDocument(this);

    void IJsonDocument.EnsurePropertyMap(int index) { }

    JsonElement IJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, JsonTokenType.String);
        return default;
    }

    TElement IJsonDocument.GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, JsonTokenType.String);
        return default;
    }

    void IJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex, out IJsonDocument parentDocument, out int parentDocumentIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, JsonTokenType.String);
        parentDocument = default;
        parentDocumentIndex = default;
    }

    int IJsonDocument.GetArrayInsertionIndex(int currentIndex, int arrayIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, JsonTokenType.String);
        return default;
    }

    int IJsonDocument.GetArrayLength(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, JsonTokenType.String);
        return default;
    }

    int IJsonDocument.GetDbSize(int index, bool includeEndElement)
    {
        Debug.Assert(index == 0);
        return 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int IJsonDocument.GetHashCode(int index) => JsonDocument.GetHashCodeForString(_rawJsonStringValue.Span[1..^1]);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    JsonTokenType IJsonDocument.GetJsonTokenType(int index)
    {
        Debug.Assert(index == 0);
        return JsonTokenType.String;
    }

    string IJsonDocument.GetNameOfPropertyValue(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    int IJsonDocument.GetPropertyCount(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    JsonElement IJsonDocument.GetPropertyName(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    ReadOnlySpan<byte> IJsonDocument.GetPropertyNameRaw(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }
    ReadOnlyMemory<byte> IJsonDocument.GetPropertyNameRaw(int index, bool includeQuotes)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    UnescapedUtf8JsonString IJsonDocument.GetPropertyNameUnescaped(int index)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    string IJsonDocument.GetPropertyRawValueAsString(int valueIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ReadOnlyMemory<byte> IJsonDocument.GetRawSimpleValue(int index, bool includeQuotes)
    {
        Debug.Assert(index == 0);
        if (includeQuotes)
        {
            return _rawJsonStringValue;
        }

        return _rawJsonStringValue[1..^1];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ReadOnlyMemory<byte> IJsonDocument.GetRawSimpleValue(int index)
    {
        Debug.Assert(index == 0);
        return _rawJsonStringValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ReadOnlyMemory<byte> IJsonDocument.GetRawSimpleValueUnsafe(int index)
    {
        Debug.Assert(index == 0);
        return _rawJsonStringValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    RawUtf8JsonString IJsonDocument.GetRawValue(int index, bool includeQuotes)
    {
        Debug.Assert(index == 0);
        if (includeQuotes)
        {
            return new(_rawJsonStringValue);
        }

        return new(_rawJsonStringValue[1..^1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    string IJsonDocument.GetRawValueAsString(int index)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TranscodeHelper(_rawJsonStringValue.Span);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int IJsonDocument.GetStartIndex(int endIndex)
    {
        Debug.Assert(endIndex == 0);
        return 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    string? IJsonDocument.GetString(int index, JsonTokenType expectedType)
    {
        Debug.Assert(index == 0 && expectedType == JsonTokenType.String);
        return JsonReaderHelper.TranscodeHelper(_rawJsonStringValue.Span[1..^1]);
    }

    UnescapedUtf8JsonString IJsonDocument.GetUtf8JsonString(int index, JsonTokenType expectedType)
    {
        Debug.Assert(index == 0 && expectedType == JsonTokenType.String);

        if (_requiresUnescaping)
        {
            int segmentLength = _rawJsonStringValue.Length;
            byte[] rentedBytes = ArrayPool<byte>.Shared.Rent(segmentLength);
            try
            {
                JsonReaderHelper.Unescape(_rawJsonStringValue.Span, rentedBytes, out int written);
                return new UnescapedUtf8JsonString(rentedBytes.AsMemory(0, written), rentedBytes);
            }
            catch
            {
                ArrayPool<byte>.Shared.Return(rentedBytes);
            }
        }

        return new UnescapedUtf8JsonString(_rawJsonStringValue);
    }

    bool IJsonDocument.TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
    {
        byte[]? otherUtf8TextArray = null;

        int length = checked(otherText.Length * JsonConstants.MaxExpansionFactorWhileTranscoding);
        // Use unsigned comparison for efficient stackalloc threshold check
        Span<byte> otherUtf8Text = (uint)length <= (uint)JsonConstants.StackallocByteThreshold ?
            stackalloc byte[JsonConstants.StackallocByteThreshold] :
            (otherUtf8TextArray = ArrayPool<byte>.Shared.Rent(length));

        OperationStatus status = JsonWriterHelper.ToUtf8(otherText, otherUtf8Text, out int written);
        Debug.Assert(status != OperationStatus.DestinationTooSmall);
        bool result;
        if (status == OperationStatus.InvalidData)
        {
            result = false;
        }
        else
        {
            Debug.Assert(status == OperationStatus.Done);
            result = TextEqualsUnsafe(otherUtf8Text.Slice(0, written), shouldUnescape: true);
        }

        if (otherUtf8TextArray != null)
        {
            otherUtf8Text.Slice(0, written).Clear();
            ArrayPool<byte>.Shared.Return(otherUtf8TextArray);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
    {
        Debug.Assert(index == 0 && !isPropertyName);

        return TextEqualsUnsafe(otherUtf8Text, shouldUnescape);
    }

    private bool TextEqualsUnsafe(ReadOnlySpan<byte> otherUtf8Text, bool shouldUnescape)
    {
        ReadOnlySpan<byte> segment = _rawJsonStringValue.Span[1..^1];

        // Use unsigned comparison to optimize length checks
        if ((uint)otherUtf8Text.Length > (uint)segment.Length || (!shouldUnescape && otherUtf8Text.Length != segment.Length))
        {
            return false;
        }

        if (_requiresUnescaping && shouldUnescape)
        {
            // Use unsigned comparison for length validation
            if ((uint)otherUtf8Text.Length < (uint)(segment.Length / JsonConstants.MaxExpansionFactorWhileEscaping))
            {
                return false;
            }

            int idx = segment.IndexOf(JsonConstants.BackSlash);
            Debug.Assert(idx != -1);

            if (!otherUtf8Text.StartsWith(segment.Slice(0, idx)))
            {
                return false;
            }

            return JsonReaderHelper.UnescapeAndCompare(segment.Slice(idx), otherUtf8Text.Slice(idx));
        }

        return segment.SequenceEqual(otherUtf8Text);
    }

    string IJsonDocument.ToString(int index)
    {
        Debug.Assert(index == 0);
        return _requiresUnescaping
            ? JsonReaderHelper.GetUnescapedString(_rawJsonStringValue.Span[1..^1])
            : JsonReaderHelper.TranscodeHelper(_rawJsonStringValue.Span[1..^1]);
    }

    bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, out TElement value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<char> propertyName, out TElement value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out IJsonDocument? elementParent, out int elementIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        elementParent = default;
        elementIndex = default;
        return false;
    }

    bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, [NotNullWhen(true)] out IJsonDocument? elementParent, out int elementIndex)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, JsonTokenType.String);
        elementParent = default;
        elementIndex = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, [NotNullWhen(true)] out byte[]? value)
    {
        Debug.Assert(index == 0);

        ReadOnlySpan<byte> segment = _rawJsonStringValue.Span[1..^1];

        // Segment needs to be unescaped
        if (_requiresUnescaping)
        {
            return JsonReaderHelper.TryGetUnescapedBase64Bytes(segment, out value);
        }

        Debug.Assert(segment.IndexOf(JsonConstants.BackSlash) == -1);
        return JsonReaderHelper.TryDecodeBase64(segment, out value);
    }

    bool IJsonDocument.TryGetValue(int index, out sbyte value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out byte value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out short value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out ushort value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out int value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out uint value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out long value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out ulong value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out double value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out float value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out decimal value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out BigInteger value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out BigNumber value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out DateTime value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out DateTimeOffset value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out OffsetDateTime value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out OffsetDate value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out OffsetTime value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out LocalDate value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out Period value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.TryGetValue(int index, out Guid value)
    {
        Debug.Assert(index == 0);
        return JsonReaderHelper.TryGetValue(_rawJsonStringValue.Span[1..^1], _requiresUnescaping, out value);
    }


#if NET
    bool IJsonDocument.TryGetValue(int index, out Int128 value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out UInt128 value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }

    bool IJsonDocument.TryGetValue(int index, out Half value)
    {
        ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.Number, JsonTokenType.String);
        value = default;
        return false;
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    bool IJsonDocument.ValueIsEscaped(int index, bool isPropertyName)
    {
        Debug.Assert(index == 0);
        return _requiresUnescaping;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IJsonDocument.WriteElementTo(int index, Utf8JsonWriter writer)
    {
        Debug.Assert(index == 0);
        writer.WriteRawValue(_rawJsonStringValue.Span);
    }

    void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer) => Debug.Assert(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Reset(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
    {
        _rawJsonStringValue = rawJsonStringValue;
        _requiresUnescaping = requiresUnescaping;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ResetAllStateForCacheReuse()
    {
        _rawJsonStringValue = ReadOnlyMemory<byte>.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static FixedStringJsonDocument<T> CreateEmptyInstanceForCaching()
    {
        return new FixedStringJsonDocument<T>(ReadOnlyMemory<byte>.Empty, requiresUnescaping: false);
    }

    /// <summary>
    /// Defines a thread-local cache for us to store reusable FixedString document instances.
    /// </summary>
    private static class Cache
    {
        [ThreadStatic]
        private static ThreadLocalState? t_threadLocalState;

        /// <summary>
        /// Rents a fixed string document from the thread-local cache or creates a new one.
        /// </summary>
        /// <param name="rawUtf8StringValue">The raw UTF-8 string value for the document.</param>
        /// <param name="requiresUnescaping">Indicates whether the string has complex children (i.e. requires unescaping).</param>
        /// <returns>A document instance from the cache or a new instance.</returns>
        public static FixedStringJsonDocument<T> Rent(ReadOnlyMemory<byte> rawUtf8StringValue, bool requiresUnescaping)
        {
            ThreadLocalState state = t_threadLocalState ??= new();
            FixedStringJsonDocument<T> document;

            if (state.RentedDocuments++ == 0)
            {
                // First call in the stack -- initialize & return the cached instance.
                document = state.Document;
                document.Reset(rawUtf8StringValue, requiresUnescaping);
            }
            else
            {
                // We've created a second workspace, so we're going to create another instance.
                document = new FixedStringJsonDocument<T>(rawUtf8StringValue, requiresUnescaping);
            }

            return document;
        }

        /// <summary>
        /// Returns a document to the thread-local cache for reuse.
        /// </summary>
        /// <param name="document">The document to return to the cache.</param>
        public static void ReturnDocument(FixedStringJsonDocument<T> document)
        {
            Debug.Assert(t_threadLocalState != null);
            ThreadLocalState state = t_threadLocalState;

            document.ResetAllStateForCacheReuse();

            int rentedDocuments = --state.RentedDocuments;
            Debug.Assert((rentedDocuments == 0) == ReferenceEquals(state.Document, document));
        }

        private sealed class ThreadLocalState
        {
            public readonly FixedStringJsonDocument<T> Document;
            public int RentedDocuments;

            public ThreadLocalState()
            {
                Document = FixedStringJsonDocument<T>.CreateEmptyInstanceForCaching();
            }
        }
    }

}
