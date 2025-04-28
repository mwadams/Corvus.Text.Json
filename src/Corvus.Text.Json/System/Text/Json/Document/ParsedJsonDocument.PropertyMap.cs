// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections;
using System.Diagnostics;

#if !NET
using BitConverter = Corvus.BitConverterEx;
#endif

namespace Corvus.Text.Json
{
    public sealed partial class ParsedJsonDocument
    {
        private byte[]? _propertyMapBacking;
        private int[]? _bucketsBacking;
        private byte[]? _entriesBacking;
        private byte[]? _valueBuffer;
        private int _propertyMapOffset;
        private int _bucketOffset;
        private int _entryOffset;
        private int _valueBufferOffset;

        void IJsonDocument.EnsurePropertyMap(int index)
        {
            if (_isDisposable)
            {
                CheckNotDisposed();

                DbRow row = _parsedData.Get(index);
                int endIndex = checked((row.NumberOfRows * DbRow.Size) + index);
                row = _parsedData.Get(endIndex);

                if (!row.HasPropertyMap)
                {
                    int propertyMapIndex = CreatePropertyMap(index);
                    _parsedData.SetPropertyMapIndex(index, propertyMapIndex);
                }
            }
        }

        private int CreatePropertyMap(int startObjectIndex)
        {
            DbRow startObjectRow = _parsedData.Get(startObjectIndex);
            int endIndex = checked((startObjectRow.NumberOfRows * DbRow.Size) + startObjectIndex);
            DbRow endObjectRow = _parsedData.Get(endIndex);

            int lengthOfEnd = endObjectRow.SizeOrLength;
            int propertyCount = startObjectRow.SizeOrLength;
            int size = HashHelpers.GetPrime(propertyCount);
            int entriesSize = size * PropertyMap.Entry.Size;

            // Make sure we have space for the buckets
            if (_bucketsBacking is null)
            {
                _bucketsBacking = ArrayPool<int>.Shared.Rent(size);
            }
            else
            {
                Enlarge(_bucketOffset + size, ref _bucketsBacking);
            }

            // Make sure we have space for the property map
            if (_propertyMapBacking is null)
            {
                // We will start with 10
                _propertyMapBacking = ArrayPool<byte>.Shared.Rent(PropertyMap.Size * 10);
            }
            else
            {
                Enlarge(_propertyMapOffset + PropertyMap.Size, ref _propertyMapBacking);
            }

            // Make sure we have space for the entries
            if (_entriesBacking is null)
            {
                _entriesBacking = ArrayPool<byte>.Shared.Rent(entriesSize);
            }
            else
            {
                Enlarge(_entryOffset + entriesSize, ref _entriesBacking);
            }

            Span<int> buckets = _bucketsBacking.AsSpan(_bucketOffset, size);
            Span<byte> entries = _entriesBacking.AsSpan(_entryOffset, entriesSize);
            buckets.Clear();
            entries.Clear();

            Span<byte> buffer = stackalloc byte[JsonConstants.StackallocByteThreshold];

            int propertyIndex = 0;

            // Move to the row before the EndObject
            int index = startObjectIndex + DbRow.Size;

            while (index < endIndex)
            {
                DbRow propertyRow = _parsedData.Get(index);
                index += DbRow.Size;
                DbRow row = _parsedData.Get(index);

                Debug.Assert(propertyRow.TokenType == JsonTokenType.PropertyName, "The row must be a property name");

                if (propertyRow.HasComplexChildren)
                {
                    Debug.Assert(propertyRow.Location >= 0, "The property must be local if it has complex children");

                    ReadOnlyMemory<byte> rawName = GetRawValueCore(index, false);
                    ReadOnlySpan<byte> unescapedName = UnescapeAndWriteDynamicValue(rawName.Span, out int dynamicValueOffset);
                    ulong hashCode = PropertyMap.GetHashCode(unescapedName);
                    ref int bucket = ref PropertyMap.GetBucket(buckets, hashCode, size);
                    int entryIndex = propertyIndex * PropertyMap.Entry.Size;
                    PropertyMap.Entry.Write(entries.Slice(entryIndex, PropertyMap.Entry.Size), hashCode, bucket - 1, index, dynamicValueOffset);
                    propertyIndex++;
                    bucket = propertyIndex; // Value in buckets is 1-based
                }
                else
                {
                    ReadOnlyMemory<byte> rawName = GetRawValueCore(index, false);
                    ulong hashCode = PropertyMap.GetHashCode(rawName.Span);
                    ref int bucket = ref PropertyMap.GetBucket(buckets, hashCode, size);
                    int entryIndex = propertyIndex * PropertyMap.Entry.Size;
                    PropertyMap.Entry.Write(entries.Slice(entryIndex, PropertyMap.Entry.Size), hashCode, bucket - 1, index);
                    propertyIndex++;
                    bucket = propertyIndex; // Value in buckets is 1-based
                }

                if (row.IsSimpleValue)
                {
                    index += DbRow.Size;
                }
                else
                {
                    Debug.Assert(row.NumberOfRows > 0, "There must be at least one row in a non-simple value.");
                    index += DbRow.Size * (row.NumberOfRows + 1);
                }
            }

            PropertyMap.Write(_bucketOffset, _entryOffset, size, propertyCount, _propertyMapBacking.AsSpan(_propertyMapOffset), lengthOfEnd);

            int propertyMapIndex = _propertyMapOffset;

            // Move the pointers for the next property map.
            _propertyMapOffset += PropertyMap.Size;
            _bucketOffset += size;
            _entryOffset += entriesSize;

            return propertyMapIndex;
        }

        private ReadOnlySpan<byte> UnescapeAndWriteDynamicValue(ReadOnlySpan<byte> escapedPropertyName, out int dynamicValueOffset)
        {
            int index = escapedPropertyName.IndexOf(JsonConstants.BackSlash);
            Debug.Assert(index >= 0);
            int maxRequiredLength = escapedPropertyName.Length + 4;
            if (_valueBuffer is null)
            {
                _valueBuffer = ArrayPool<byte>.Shared.Rent(maxRequiredLength);
            }
            else
            {
                Enlarge(maxRequiredLength, ref _valueBuffer);
            }

            int offset = _valueBufferOffset;
            int length = index;
            int valueOffset = offset + 4;
            if (index > 0)
            {
                // Copy the unescaped portion
                escapedPropertyName.CopyTo(_valueBuffer.AsSpan(valueOffset));
            }

            // Unescape the rest into the destination
            JsonReaderHelper.Unescape(escapedPropertyName.Slice(index), _valueBuffer.AsSpan(valueOffset + index), 0, out int written);
            length += written;

            if (length > 0x0FFFFFFF)
            {
                throw new InvalidOperationException("String too long");
            }

            BitConverter.TryWriteBytes(_valueBuffer.AsSpan(), (uint)(length << 4) | (uint)DynamicValueType.Utf8String);
            _valueBufferOffset += length;
            dynamicValueOffset = offset;
            return _valueBuffer.AsSpan(valueOffset, length);
        }

        private int WriteDynamicValue(ReadOnlySpan<byte> unescapedPropertyName)
        {
            int offset = _valueBufferOffset;
            // We write the value buffer offset here, to save doing it again later.
            _valueBufferOffset += unescapedPropertyName.Length + 4;

            if (_valueBuffer is null)
            {
                _valueBuffer = ArrayPool<byte>.Shared.Rent(_valueBufferOffset);
            }
            else
            {
                Enlarge(_valueBufferOffset, ref _valueBuffer);
            }

            uint length = (uint)unescapedPropertyName.Length;
            if (length > 0x0FFFFFFF)
            {
                throw new InvalidOperationException("String too long");
            }

            // Shift it and OR in the value type.
            length <<= 4;
            length |= (uint)DynamicValueType.Utf8String;

            BitConverter.TryWriteBytes(_valueBuffer.AsSpan(offset), length);
            unescapedPropertyName.CopyTo(_valueBuffer.AsSpan(offset + 4));

            return offset;
        }

        private void Enlarge(int v, ref byte[] byteArray)
        {                        
            Debug.Assert(_isDisposable, "Appending to a fixed document.");

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

        private void Enlarge(int v, ref int[] intArray)
        {
            Debug.Assert(_isDisposable, "Appending to a fixed document.");

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
    }
}
