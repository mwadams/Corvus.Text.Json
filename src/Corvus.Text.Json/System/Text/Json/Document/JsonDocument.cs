// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;


#if NET
using System.Globalization;
#endif

using System.Threading;

namespace Corvus.Text.Json
{
    public abstract partial class JsonDocument
    {
        [CLSCompliant(false)]
        protected const ulong HashMask = 0xFFUL << 56;
        protected const int HashLength = 8;

        [CLSCompliant(false)]
        protected byte[]? _propertyMapBacking;
        [CLSCompliant(false)]
        protected int[]? _bucketsBacking;
        [CLSCompliant(false)]
        protected byte[]? _entriesBacking;
        [CLSCompliant(false)]
        protected byte[]? _valueBacking;
        [CLSCompliant(false)]
        protected int _propertyMapOffset;
        [CLSCompliant(false)]
        protected int _bucketOffset;
        [CLSCompliant(false)]
        protected int _entryOffset;
        [CLSCompliant(false)]
        protected int _valueOffset;
        [CLSCompliant(false)]
        protected MetadataDb _parsedData;

        // These are the indices of the one-and-only instances of the "null", "true", and "false" text in this document.
        private int _nullIndex = -1;
        private int _trueIndex = -1;
        private int _falseIndex = -1;

        protected abstract ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index, bool includeQuotes);

        protected static void CheckExpectedType(JsonTokenType expected, JsonTokenType actual)
        {
            if (expected != actual)
            {
                ThrowHelper.ThrowJsonElementWrongTypeException(expected, actual);
            }
        }

        protected virtual int GetDbSizeUnsafe(int index, bool includeEndElement)
        {
            DbRow row = _parsedData.Get(index);

            if (row.IsSimpleValue)
            {
                return DbRow.Size;
            }

            int endIndex = DbRow.Size * row.NumberOfRows;

            if (includeEndElement)
            {
                endIndex += DbRow.Size;
            }

            return endIndex;
        }

        protected bool TextEqualsUnsafe(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
        {
            byte[]? otherUtf8TextArray = null;

            int length = checked(otherText.Length * JsonConstants.MaxExpansionFactorWhileTranscoding);
            Span<byte> otherUtf8Text = length <= JsonConstants.StackallocByteThreshold ?
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
                result = TextEqualsUnsafe(index, otherUtf8Text.Slice(0, written), isPropertyName, shouldUnescape: true);
            }

            if (otherUtf8TextArray != null)
            {
                otherUtf8Text.Slice(0, written).Clear();
                ArrayPool<byte>.Shared.Return(otherUtf8TextArray);
            }

            return result;
        }

        protected bool TextEqualsUnsafe(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
        {
            int matchIndex = isPropertyName ? index - DbRow.Size : index;

            DbRow row = _parsedData.Get(matchIndex);

            CheckExpectedType(
                isPropertyName ? JsonTokenType.PropertyName : JsonTokenType.String,
                row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(matchIndex, includeQuotes: false).Span;

            if (otherUtf8Text.Length > segment.Length || (!shouldUnescape && otherUtf8Text.Length != segment.Length))
            {
                return false;
            }

            if (row.HasComplexChildren && shouldUnescape)
            {
                if (otherUtf8Text.Length < segment.Length / JsonConstants.MaxExpansionFactorWhileEscaping)
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

        protected int GetArrayIndexElementUnsafe(int currentIndex, int arrayIndex)
        {
            DbRow row = _parsedData.Get(currentIndex);

            CheckExpectedType(JsonTokenType.StartArray, row.TokenType);

            int arrayLength = row.SizeOrLengthOrPropertyMapIndex;

            if ((uint)arrayIndex >= (uint)arrayLength)
            {
                throw new IndexOutOfRangeException();
            }

            if (!row.HasComplexChildren)
            {
                // Since we wouldn't be here without having completed the document parse, and we
                // already vetted the index against the length, this new index will always be
                // within the table.
                return currentIndex + ((arrayIndex + 1) * DbRow.Size);
            }

            int elementCount = 0;
            int objectOffset = currentIndex + DbRow.Size;

            for (; objectOffset < _parsedData.Length; objectOffset += DbRow.Size)
            {
                if (arrayIndex == elementCount)
                {
                    return objectOffset;
                }

                row = _parsedData.Get(objectOffset);

                if (!row.IsSimpleValue)
                {
                    objectOffset = objectOffset + GetDbSizeUnsafe(objectOffset, includeEndElement: false);
                }

                elementCount++;
            }

            Debug.Fail(
                $"Ran out of database searching for array index {arrayIndex} from {currentIndex} when length was {arrayLength}");
            throw new IndexOutOfRangeException();
        }

        protected bool ValueIsEscapedUnsafe(int index, bool isPropertyName)
        {
            int matchIndex = isPropertyName ? index - DbRow.Size : index;
            DbRow row = _parsedData.Get(matchIndex);
            Debug.Assert(!isPropertyName || row.TokenType is JsonTokenType.PropertyName);

            return row.HasComplexChildren;
        }

        protected void Enlarge(int v, [NotNull] ref byte[]? byteArray)
        {
            if (byteArray is null)
            {
                byteArray = ArrayPool<byte>.Shared.Rent(Math.Max(16384, v));
                return;
            }

            if (byteArray.Length > v)
            {
                return;
            }

            byte[] toReturn = byteArray;

            // Allow the data to grow up to maximum possible capacity (~2G bytes) before encountering overflow.
            // Note: Array.MaxLength exists only on .NET 6 or greater,
            // so for the other versions value is hardcoded
            const int MaxArrayLength = 0x7FFFFFC7;
#if NET
            Debug.Assert(MaxArrayLength == Array.MaxLength);
#endif

            int newCapacity = toReturn.Length * 2;

            // Note that this check works even when newCapacity overflowed thanks to the (uint) cast
            if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;

            // If the maximum capacity has already been reached,
            // then set the new capacity to be larger than what is possible
            // so that ArrayPool.Rent throws an OutOfMemoryException for us.
            if (newCapacity == toReturn.Length) newCapacity = int.MaxValue;

            byteArray = ArrayPool<byte>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, byteArray, 0, toReturn.Length);

            // The data in this rented buffer only conveys the positions and
            // lengths of tokens in a document, but no content; so it does not
            // need to be cleared.
            ArrayPool<byte>.Shared.Return(toReturn);
        }

        protected void Enlarge(int v, ref int[] intArray)
        {
            int[] toReturn = intArray;

            // Allow the data to grow up to maximum possible capacity (~2G bytes) before encountering overflow.
            // Note: Array.MaxLength exists only on .NET 6 or greater,
            // so for the other versions value is hardcoded
            const int MaxArrayLength = 0x7FFFFFC7;
#if NET
            Debug.Assert(MaxArrayLength == Array.MaxLength);
#endif

            int newCapacity = toReturn.Length * 2;

            // Note that this check works even when newCapacity overflowed thanks to the (uint) cast
            if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;

            // If the maximum capacity has already been reached,
            // then set the new capacity to be larger than what is possible
            // so that ArrayPool.Rent throws an OutOfMemoryException for us.
            if (newCapacity == toReturn.Length) newCapacity = int.MaxValue;

            intArray = ArrayPool<int>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, intArray, 0, toReturn.Length * sizeof(int));

            // The data in this rented buffer only conveys the positions and
            // lengths of tokens in a document, but no content; so it does not
            // need to be cleared.
            ArrayPool<int>.Shared.Return(toReturn);
        }

        protected int StoreBooleanValue(bool value)
        {
            ref int valueIndex = ref _falseIndex;

            if (value)
            {
                valueIndex = ref _trueIndex;
            }

            if (valueIndex >= 0)
            {
                return valueIndex;
            }

            ReadOnlySpan<byte> valueUtf8 = value ? JsonConstants.TrueValue : JsonConstants.FalseValue;
            int offset = _valueOffset;
            int length = valueUtf8.Length;
            Enlarge(length, ref _valueBacking);

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Boolean);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Boolean);
#endif

            valueIndex = offset;

            offset += 4;
            valueUtf8.CopyTo(_valueBacking.AsSpan(offset));
            _valueOffset = offset + length;
            return valueIndex;
        }

        protected int StoreNullValue()
        {
            if (_nullIndex >= 0)
            {
                return _nullIndex;
            }

            int offset = _valueOffset;
            int length = JsonConstants.NullValue.Length;
            Enlarge(length, ref _valueBacking);

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Null);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Null);
#endif

            _nullIndex = offset;

            offset += 4;
            JsonConstants.NullValue.CopyTo(_valueBacking.AsSpan(offset));
            _valueOffset = offset + length;
            return _nullIndex;
        }

        protected int StoreValue(Guid value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatGuidLength + 2;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            _valueBacking[offset++] = JsonConstants.Quote;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

            _valueBacking[offset++] = JsonConstants.Quote;

            length += 2;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.QuotedUtf8String);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.QuotedUtf8String);
#endif

            _valueOffset = offset;
            return result;

        }

        [CLSCompliant(false)]
        protected int StoreValue(sbyte value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(byte value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatUInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(int value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        [CLSCompliant(false)]
        protected int StoreValue(uint value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatUInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(long value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        [CLSCompliant(false)]
        protected int StoreValue(ulong value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatUInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(short value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        [CLSCompliant(false)]
        protected int StoreValue(ushort value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatUInt64Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(float value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatSingleLength;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(double value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatDoubleLength;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(decimal value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatDecimalLength;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = Utf8Formatter.TryFormat(value, _valueBacking.AsSpan(offset), out length);
            Debug.Assert(success);
            offset += length;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);
#endif

            _valueOffset = offset;
            return result;
        }

#if NET
        protected int StoreValue(Int128 value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatInt128Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = value.TryFormat(_valueBacking.AsSpan(offset), out length, provider: CultureInfo.InvariantCulture);
            Debug.Assert(success);
            offset += length;

            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);

            _valueOffset = offset;
            return result;
        }

        [CLSCompliant(false)]
        protected int StoreValue(UInt128 value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatUInt128Length;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = value.TryFormat(_valueBacking.AsSpan(offset), out length, provider: CultureInfo.InvariantCulture);
            Debug.Assert(success);
            offset += length;

            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);

            _valueOffset = offset;
            return result;
        }

        protected int StoreValue(Half value)
        {
            int offset = _valueOffset;
            int result = offset;
            int length = JsonConstants.MaximumFormatHalfLength;
            Enlarge(length, ref _valueBacking);

            offset += 4;

            bool success = value.TryFormat(_valueBacking.AsSpan(offset), out length, provider: CultureInfo.InvariantCulture);
            Debug.Assert(success);
            offset += length;

            BitConverter.TryWriteBytes(_valueBacking.AsSpan(_valueOffset), (uint)(length << 4) | (uint)DynamicValueType.Number);

            _valueOffset = offset;
            return result;
        }
#endif

        protected ReadOnlySpan<byte> UnescapeAndStoreUnescapedStringValue(ReadOnlySpan<byte> escapedPropertyName, out int dynamicValueOffset)
        {
            int index = escapedPropertyName.IndexOf(JsonConstants.BackSlash);
            Debug.Assert(index >= 0);
            int maxRequiredLength = escapedPropertyName.Length + 4;
            Enlarge(maxRequiredLength, ref _valueBacking);

            int offset = _valueOffset;
            int length = index;
            int valueOffset = offset + 4;
            if (index > 0)
            {
                // Copy the unescaped portion
                escapedPropertyName.CopyTo(_valueBacking.AsSpan(valueOffset));
            }

            // Unescape the rest into the destination
            JsonReaderHelper.Unescape(escapedPropertyName.Slice(index), _valueBacking.AsSpan(valueOffset + index), 0, out int written);
            length += written;

            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(), (uint)(length << 4) | (uint)DynamicValueType.UnescapedUtf8String);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(), (uint)(length << 4) | (uint)DynamicValueType.UnescapedUtf8String);
#endif
            _valueOffset += length;
            dynamicValueOffset = offset;
            return _valueBacking.AsSpan(valueOffset, length);
        }

        protected int StoreUnescapedStringValue(ReadOnlySpan<byte> unescapedString)
        {
            int offset = _valueOffset;
            // We write the value buffer offset here, to save doing it again later.
            _valueOffset += unescapedString.Length + 4;

            Enlarge(_valueOffset, ref _valueBacking);

            uint length = (uint)unescapedString.Length;
            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.UnescapedUtf8String;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#endif
            unescapedString.CopyTo(_valueBacking.AsSpan(offset + 4));

            return offset;
        }


        protected int EscapeAndStoreRawStringValue(ReadOnlySpan<byte> utf8Value, out bool requiredEscaping, JavaScriptEncoder? encoder)
        {
            int offset = _valueOffset;

            int valueIdx = JsonWriterHelper.NeedsEscaping(utf8Value, encoder);

            Debug.Assert(valueIdx >= -1 && valueIdx < utf8Value.Length);

            int maxRequiredSize = valueIdx == -1 ? utf8Value.Length + 2 + 4 : JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, valueIdx) + 2 + 4;

            Enlarge(_valueOffset + maxRequiredSize, ref _valueBacking);

            int written;

            int index = offset + 4;

            _valueBacking[index++] = JsonConstants.Quote;

            if (valueIdx != -1)
            {
                requiredEscaping = true;
                JsonWriterHelper.EscapeString(utf8Value, _valueBacking.AsSpan(index), valueIdx, encoder, out written);
                index += written;
            }
            else
            {
                requiredEscaping = false;
                utf8Value.CopyTo(_valueBacking.AsSpan(index));
                written = utf8Value.Length;
                index += written;
            }

            _valueBacking[index++] = JsonConstants.Quote;

            // Then write the type information.

            uint length = (uint)(written + 2);
            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.QuotedUtf8String;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#endif
            _valueOffset = index;
            return offset;
        }

        protected int EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, out bool requiredEscaping, JavaScriptEncoder? encoder)
        {
            int offset = _valueOffset;

            int valueIdx = JsonWriterHelper.NeedsEscaping(value, encoder);

            int valueLength = value.Length;
            Debug.Assert(valueIdx >= -1 && valueIdx < valueLength);

            int maxRequiredSize = valueIdx == -1 ? valueLength + 2 + 4 : JsonWriterHelper.GetMaxEscapedLength(valueLength, valueIdx) + 2 + 4;

            Enlarge(_valueOffset + maxRequiredSize, ref _valueBacking);

            int written;

            int index = offset + 4;

            _valueBacking[index++] = JsonConstants.Quote;

            if (valueIdx != -1)
            {
                requiredEscaping = true;

                char[]? buffer = null;
                Span<char> escapedBuffer = valueLength <= JsonConstants.StackallocCharThreshold ? stackalloc char[JsonConstants.StackallocCharThreshold] : (buffer = ArrayPool<char>.Shared.Rent(valueLength)).AsSpan();

                JsonWriterHelper.EscapeString(value, buffer, valueIdx, encoder, out written);
                JsonWriterHelper.ToUtf8(escapedBuffer.Slice(0, written), _valueBacking.AsSpan(index), out written);
                index += written;
            }
            else
            {
                requiredEscaping = false;
                JsonWriterHelper.ToUtf8(value, _valueBacking.AsSpan(index), out written);
                written = valueLength;
                index += written;
            }

            _valueBacking[index++] = JsonConstants.Quote;

            // Then write the type information.

            uint length = (uint)(written + 2);
            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.QuotedUtf8String;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#endif
            _valueOffset = index;
            return offset;
        }

        protected int StoreRawStringValue(ReadOnlySpan<byte> escapedString)
        {
            int offset = _valueOffset;
            // We write the value buffer offset here, to save doing it again later.
            _valueOffset += escapedString.Length + 6;

            Enlarge(_valueOffset, ref _valueBacking);

            uint length = (uint)escapedString.Length + 2;
            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.QuotedUtf8String;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#endif
            int index = offset + 4;
            _valueBacking[index++] = JsonConstants.Quote;
            escapedString.CopyTo(_valueBacking.AsSpan(index));
            index += escapedString.Length;
            _valueBacking[index++] = JsonConstants.Quote;
            return offset;
        }

        protected int StoreRawNumberValue(ReadOnlySpan<byte> unescapedNumberValue)
        {
            JsonWriterHelper.ValidateNumber(unescapedNumberValue);
            int offset = _valueOffset;
            // We write the value buffer offset here, to save doing it again later.
            _valueOffset += unescapedNumberValue.Length + 4;

            Enlarge(_valueOffset, ref _valueBacking);

            uint length = (uint)unescapedNumberValue.Length;
            if (length > 0x0FFFFFFF)
            {
                ThrowHelper.ThrowArgumentException_ValueTooLarge(length);
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.Number;

#if NET
            BitConverter.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#else
            BitConverterEx.TryWriteBytes(_valueBacking.AsSpan(offset), length);
#endif
            unescapedNumberValue.CopyTo(_valueBacking.AsSpan(offset + 4));

            return offset;
        }

        protected int StoreRawNumberValue(ReadOnlySpan<char> unescapedNumberValueChars)
        {
            // This is a number, so it is UTF-8 compatible.
            int utf8Length = Encoding.UTF8.GetMaxByteCount(unescapedNumberValueChars.Length);
            byte[]? utf8Buffer = null;
            Span<byte> unescapedNumberValue = utf8Length <= JsonConstants.StackallocByteThreshold ?
                stackalloc byte[JsonConstants.StackallocByteThreshold] :
                (utf8Buffer = ArrayPool<byte>.Shared.Rent(utf8Length)).AsSpan();

            try
            {
                unescapedNumberValue = unescapedNumberValue.Slice(0, JsonReaderHelper.TranscodeHelper(unescapedNumberValueChars, unescapedNumberValue));
                return StoreRawNumberValue(unescapedNumberValue);
            }
            finally
            {
                if (utf8Buffer is not null)
                {
                    unescapedNumberValue.Clear();
                    ArrayPool<byte>.Shared.Return(utf8Buffer);
                }
            }
        }

        protected ReadOnlyMemory<byte> ReadDynamicUnescapedUtf8String(int offset)
        {
            // The first 4 bytes are the type and length
            uint length = BitConverter.ToUInt32(_valueBacking!, offset);

            Debug.Assert((DynamicValueType)(length & 0xF) == DynamicValueType.UnescapedUtf8String, $"Expected Unescaped UTF8 string at {offset}");

            length >>= 4;

            return _valueBacking.AsMemory(offset + 4, (int)length);
        }

        protected ReadOnlyMemory<byte> ReadRawSimpleDynamicValue(int offset, bool includeQuotes)
        {
            // The first 4 bytes are the type and length
            uint length = BitConverter.ToUInt32(_valueBacking!, offset);

            DynamicValueType valueType = (DynamicValueType)(length & 0xF);
            Debug.Assert(valueType is DynamicValueType.QuotedUtf8String or DynamicValueType.Number or DynamicValueType.Boolean or DynamicValueType.Null, $"Expected simple value at {offset}");

            length >>= 4;

            int start;

            if (!includeQuotes && valueType == DynamicValueType.QuotedUtf8String)
            {
                start = offset + 5;
                length -= 2;
            }
            else
            {
                start = offset + 4;
            }

            return _valueBacking.AsMemory(start, (int)length);
        }

        protected bool TryGetNamedPropertyValueUnsafe(int index, ReadOnlySpan<char> propertyName, out int valueIndex)
        {
            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.StartObject, row.TokenType);

            // Only one row means it was EndObject.
            if (!row.FromExternalDocument && row.NumberOfRows == 1)
            {
                valueIndex = -1;
                return false;
            }

            int maxBytes = JsonReaderHelper.s_utf8Encoding.GetMaxByteCount(propertyName.Length);


            byte[]? byteBuffer = null;

            Span<byte> utf8Name =
                maxBytes < JsonConstants.StackallocByteThreshold
                    ? stackalloc byte[JsonConstants.StackallocByteThreshold]
                    : (byteBuffer = ArrayPool<byte>.Shared.Rent(maxBytes)).AsSpan();

            try
            {
                int len = JsonReaderHelper.GetUtf8FromText(propertyName, utf8Name);
                utf8Name = utf8Name.Slice(0, len);

                return TryGetNamedPropertyValueUnsafe(
                    index,
                    utf8Name,
                    out valueIndex);
            }
            finally
            {
                if (byteBuffer is byte[] b)
                {
                    ArrayPool<byte>.Shared.Return(b, clearArray: true);
                }
            }
        }

        protected bool TryGetNamedPropertyValueUnsafe(
            int startIndex,
            ReadOnlySpan<byte> propertyName,
            out int valueIndex)
        {
            DbRow row = _parsedData.Get(startIndex);

            CheckExpectedType(JsonTokenType.StartObject, row.TokenType);

            // Only one row means it was EndObject.
            if (!row.FromExternalDocument && row.NumberOfRows == 1)
            {
                valueIndex = -1;
                return false;
            }

            int endIndex = startIndex + GetDbSizeUnsafe(startIndex, false);// checked(row.NumberOfRows * DbRow.Size + startIndex);

            DbRow endObjectRow = _parsedData.Get(endIndex);
            int propertyMapIndex = endObjectRow.SizeOrLengthOrPropertyMapIndex;

            if (endObjectRow.HasPropertyMap)
            {
                return TryGetNamedPropertyValueFromPropertyMap(endObjectRow.SizeOrLengthOrPropertyMapIndex, propertyName, out valueIndex);
            }

            Span<byte> utf8UnescapedStack = stackalloc byte[JsonConstants.StackallocByteThreshold];

            // Move to the row before the EndObject
            int index = endIndex - DbRow.Size;

            while (index > startIndex)
            {
                row = _parsedData.Get(index);
                Debug.Assert(row.TokenType != JsonTokenType.PropertyName);

                // Move before the value
                if (row.IsSimpleValue)
                {
                    index -= DbRow.Size;
                }
                else
                {
                    Debug.Assert(row.NumberOfRows > 0);
                    index -= DbRow.Size * (row.NumberOfRows + 1);
                }

                row = _parsedData.Get(index);

                Debug.Assert(row.TokenType == JsonTokenType.PropertyName);

                ReadOnlySpan<byte> currentPropertyName = GetRawSimpleValueUnsafe(index, false).Span;

                if (row.HasComplexChildren)
                {
                    // An escaped property name will be longer than an unescaped candidate, so only unescape
                    // when the lengths are compatible.
                    if (currentPropertyName.Length > propertyName.Length)
                    {
                        int idx = currentPropertyName.IndexOf(JsonConstants.BackSlash);
                        Debug.Assert(idx >= 0);

                        // If everything up to where the property name has a backslash matches, keep going.
                        if (propertyName.Length > idx &&
                            currentPropertyName.Slice(0, idx).SequenceEqual(propertyName.Slice(0, idx)))
                        {
                            int remaining = currentPropertyName.Length - idx;
                            int written = 0;
                            byte[]? rented = null;

                            try
                            {
                                Span<byte> utf8Unescaped = remaining <= utf8UnescapedStack.Length ?
                                    utf8UnescapedStack :
                                    (rented = ArrayPool<byte>.Shared.Rent(remaining));

                                // Only unescape the part we haven't processed.
                                JsonReaderHelper.Unescape(currentPropertyName.Slice(idx), utf8Unescaped, 0, out written);

                                // If the unescaped remainder matches the input remainder, it's a match.
                                if (utf8Unescaped.Slice(0, written).SequenceEqual(propertyName.Slice(idx)))
                                {
                                    // If the property name is a match, the answer is the next element.
                                    valueIndex = index + DbRow.Size;
                                    return true;
                                }
                            }
                            finally
                            {
                                if (rented != null)
                                {
                                    rented.AsSpan(0, written).Clear();
                                    ArrayPool<byte>.Shared.Return(rented);
                                }
                            }
                        }
                    }
                }
                else if (currentPropertyName.SequenceEqual(propertyName))
                {
                    // If the property name is a match, the answer is the next element.
                    valueIndex = index + DbRow.Size;
                    return true;
                }

                // Move to the previous value
                index -= DbRow.Size;
            }

            valueIndex = -1;
            return false;
        }


        protected void DisposeCore()
        {
            _parsedData.Dispose();

            if (_propertyMapBacking != null)
            {
                // The property map is a rented array, so we need to return it to the pool.
                byte[]? propertyMapBacking = Interlocked.Exchange(ref _propertyMapBacking, null);
                if (propertyMapBacking != null)
                {
                    // It does not need to be cleared as it contains no sensitive data
                    ArrayPool<byte>.Shared.Return(propertyMapBacking);
                }
            }

            if (_bucketsBacking != null)
            {
                // The buckets are a rented array, so we need to return it to the pool.
                int[]? bucketsBacking = Interlocked.Exchange(ref _bucketsBacking, null);
                if (bucketsBacking != null)
                {
                    // It does not need to be cleared as it contains no sensitive data
                    ArrayPool<int>.Shared.Return(bucketsBacking);
                }
            }

            if (_entriesBacking != null)
            {
                byte[]? entriesBacking = Interlocked.Exchange(ref _entriesBacking, null);
                if (entriesBacking != null)
                {
                    // It does not need to be cleared as it contains no sensitive data
                    ArrayPool<byte>.Shared.Return(entriesBacking);
                }
            }

            if (_valueBacking != null)
            {
                byte[]? valueBacking = Interlocked.Exchange(ref _valueBacking, null);
                if (valueBacking != null)
                {
                    valueBacking.AsSpan(0, _valueOffset).Clear();
                    ArrayPool<byte>.Shared.Return(valueBacking);
                }
            }
        }
    }
}
