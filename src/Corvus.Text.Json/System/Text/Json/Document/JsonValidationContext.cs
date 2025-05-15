// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses _file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;
#if NET
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#endif
using System.Threading;

namespace Corvus.Text.Json
{
    [CLSCompliant(false)]
    public ref struct JsonValidationContext
#if NET
        : IDisposable
#endif
    {
        private const int BufferSize = 16; // This allows for 127 property/item bits without allocation
        private const int InitialRentedBufferSize = 8192; // This allows for 65,536 property/item bits without reallocation
        private const int MaxComplexValueCount = (BufferSize * 8) - 1; // This is the maximum number of properties/items for which we can store bits without allocation.

        private readonly IJsonValidationResultsCollector? _resultsCollector;

        private byte[]? _rentedBytes;
        private uint _lengthAndUsingFeatures;
        private int _offset;

#if NET
        // If the top bit of the last byte of _localEvaluatedItems is set, it indicates that we are using the buffer
        // for evaluated items and the first four bytes are interpreted as an integer containing the offset
        // into the _rentedBytes where the _localEvaluatedItems bits start with the second four bytes interpreted as
        // an integer containing the bit buffer length.
        // If clear, then the remaining bits represent evaluated item indices.
        private EvaluatedIndexBuffer _localEvaluatedItems;
        // If the top bit of the last byte of _localEvaluatedProperties is set, it indicates that we are using the buffer
        // for evaluated properties, and the first four bytes are interpreted as an integer containing the offset
        // into the _rentedBytes where the _localEvaluatedProperties bytes start with the second four bytes interpreted as
        // an integer containing the bit buffer length.
        // If clear, then the remaining bits represent evaluated property indices.
        private EvaluatedIndexBuffer _localEvaluatedProperties;
        // If the top bit of the last byte of appliedEvaluatedItems is set, it indicates that we are using the buffer
        // for evaluated items, and the first four bytes are interpreted as an integer containing the offset
        // into the _rentedBytes where the _appliedEvaluatedItems bits start with the second four bytes interpreted as
        // an integer containing the bit buffer length.
        // If clear, then the remaining bits represent evaluated item indices.
        private EvaluatedIndexBuffer _appliedEvaluatedItems;
        // If the top bit of the last byte of _appliedEvaluatedProperties is set, it indicates that we are using the buffer
        // for evaluated properties, and the first four bytes are interpreted as an integer containing the offset
        // into the _rentedBytes where the _appliedEvaluatedProperties bytes start with the second four bytes are interpreted as
        // an integer containing the bit buffer length.
        // If clear, then the remaining bits represent evaluated property indices.
        private EvaluatedIndexBuffer _appliedEvaluatedProperties;
#else        
        private int[] _localEvaluatedItems;
        private int[] _localEvaluatedProperties;
        private int[] _appliedEvaluatedItems;
        private int[] _appliedEvaluatedProperties;
#endif

        [Flags]
        private enum UsingFeatures : uint
        {
            EvaluatedProperties = 0b0000_0001_0000_0000_0000_0000_0000_0000,
            EvaluatedItems      = 0b0000_0010_0000_0000_0000_0000_0000_0000,
            Results             = 0b0000_0100_0000_0000_0000_0000_0000_0000,
            Stack               = 0b0000_1000_0000_0000_0000_0000_0000_0000,
            IsMatch             = 0b0001_0000_0000_0000_0000_0000_0000_0000,
            IsDisposable        = 0b0010_0000_0000_0000_0000_0000_0000_0000,
        }

        private JsonValidationContext(byte[]? rentedBytes, uint lengthAndUsingFeatures, int offset, int propertyCount, int arrayLength, IJsonValidationResultsCollector? resultsCollector = null)
        {
            _rentedBytes = rentedBytes;
            _offset = offset;
            _resultsCollector = resultsCollector;
            _lengthAndUsingFeatures =
                lengthAndUsingFeatures
                & ~(uint)UsingFeatures.IsDisposable // Not disposable
                | (uint)UsingFeatures.IsMatch; // But always valid

#if NET
            if (propertyCount > MaxComplexValueCount || arrayLength > MaxComplexValueCount)
            {
                EnsureBitBufferLengths(propertyCount, arrayLength);
            }
#else
            _localEvaluatedItems = ArrayPool<int>.Shared.Rent(InitialRentedBufferSize);
            _localEvaluatedProperties = ArrayPool<int>.Shared.Rent(InitialRentedBufferSize);
            _appliedEvaluatedItems = ArrayPool<int>.Shared.Rent(InitialRentedBufferSize);
            _appliedEvaluatedProperties = ArrayPool<int>.Shared.Rent(InitialRentedBufferSize);
#endif
        }

                // The length is the _lengthAndUsingFeatures union with the top byte masked
        private int Length => unchecked((int)(_lengthAndUsingFeatures & 0x00FF_FFFFU));

        private bool IsDisposable => ((_lengthAndUsingFeatures & (uint)UsingFeatures.IsDisposable) != 0);

        public bool IsMatch => ((_lengthAndUsingFeatures & (uint)UsingFeatures.IsMatch) != 0);

        public bool UseEvaluatedProperties => ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedProperties) != 0);

        public bool UseEvaluatedItems => ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0);

#if NET
        private Span<byte> RentedBytes
        {
            get
            {
                Debug.Assert(_rentedBytes is not null);
                return _rentedBytes.AsSpan(_offset, Length);
            }
        }
#endif

        private Span<int> LocalEvaluatedItems
        {
            get
            {
#if NET
                if ((_localEvaluatedItems[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref Unsafe.As<EvaluatedIndexBuffer, int>(ref _localEvaluatedItems), BufferSize); ;
                }
                else
                {
                    return MemoryMarshal.Cast<byte, int>(RentedBytes).Slice(
                        MemoryMarshal.Read<int>(_localEvaluatedItems),
                        MemoryMarshal.Read<int>(MemoryMarshal.CreateSpan(ref Unsafe.As<byte, byte>(ref _localEvaluatedItems[4]), 4)));
                }
#else
                return _localEvaluatedItems.AsSpan();
#endif
            }
        }

        private Span<int> LocalEvaluatedProperties
        {
            get
            {
#if NET
                if ((_localEvaluatedProperties[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref Unsafe.As<EvaluatedIndexBuffer, int>(ref _localEvaluatedProperties), BufferSize); ;
                }
                else
                {
                    Debug.Assert(_rentedBytes is not null);
                    return MemoryMarshal.Cast<byte, int>(RentedBytes).Slice(
                        MemoryMarshal.Read<int>(_localEvaluatedProperties),
                        MemoryMarshal.Read<int>(MemoryMarshal.CreateSpan(ref Unsafe.As<byte, byte>(ref _localEvaluatedProperties[4]), 4)));
                }
#else
                return _localEvaluatedItems.AsSpan();
#endif
            }
        }

        private Span<int> AppliedEvaluatedItems
        {
            get
            {
#if NET
                if ((_appliedEvaluatedItems[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref Unsafe.As<EvaluatedIndexBuffer, int>(ref _appliedEvaluatedItems), BufferSize); ;
                }
                else
                {
                    return MemoryMarshal.Cast<byte, int>(RentedBytes).Slice(
                        MemoryMarshal.Read<int>(_appliedEvaluatedItems),
                        MemoryMarshal.Read<int>(MemoryMarshal.CreateSpan(ref Unsafe.As<byte, byte>(ref _appliedEvaluatedItems[4]), 4)));
                }
#else
                return _appliedEvaluatedItems.AsSpan();
#endif
            }
        }

        private Span<int> AppliedEvaluatedProperties
        {
            get
            {
#if NET
                if ((_appliedEvaluatedProperties[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref Unsafe.As<EvaluatedIndexBuffer, int>(ref _appliedEvaluatedProperties), BufferSize); ;
                }
                else
                {
                    Debug.Assert(_rentedBytes is not null);
                    return MemoryMarshal.Cast<byte, int>(RentedBytes).Slice(
                        MemoryMarshal.Read<int>(_appliedEvaluatedProperties),
                        MemoryMarshal.Read<int>(MemoryMarshal.CreateSpan(ref Unsafe.As<byte, byte>(ref _appliedEvaluatedProperties[4]), 4)));
                }
#else
                return _appliedEvaluatedItems.AsSpan();
#endif
            }
        }

        public JsonValidationContext CreateChildContextFor<TElement>(
            in TElement element,
            bool useEvaluatedItems,
            bool useEvaluatedProperties,
            PathProvider relativeOrAbsoluteSchemaLocation,
            PathProvider relativeSchemaPath,
            PathProvider relativeDocumentPath)
            where TElement : struct, IJsonElement<TElement>
        {

            _resultsCollector?.BeginChildContext(relativeOrAbsoluteSchemaLocation, relativeSchemaPath, relativeDocumentPath);

            bool usesEvaluatedProperties = UseEvaluatedProperties || useEvaluatedProperties;
            bool usesEvaluatedItems = UseEvaluatedItems || useEvaluatedItems;

            // If we are creating a child context, we have to ensure we are using new buffers
            if (usesEvaluatedItems || usesEvaluatedProperties)
            {
                JsonValueKind valueKind = element.ValueKind;
                if (usesEvaluatedProperties && valueKind == JsonValueKind.Object)
                {
                    return new JsonValidationContext(
                        _rentedBytes,
                        _lengthAndUsingFeatures | (uint)UsingFeatures.EvaluatedProperties,
                        offset: Length,
                        propertyCount: element.ParentDocument.GetPropertyCount(element.ParentDocumentIndex),
                        arrayLength: 0);
                }

                if (usesEvaluatedItems && valueKind == JsonValueKind.Array)
                {
                    return new JsonValidationContext(
                        _rentedBytes,
                        _lengthAndUsingFeatures | (uint)UsingFeatures.EvaluatedProperties,
                        offset: Length,
                        propertyCount: 0,
                        arrayLength: element.ParentDocument.GetArrayLength(element.ParentDocumentIndex));
                }
            }

            return new JsonValidationContext(
                _rentedBytes,
                _lengthAndUsingFeatures,
                offset: Length,
                propertyCount: -1,
                arrayLength: -1);
        }

        public void Dispose()
        {
#if !NET
            ArrayPool<int>.Shared.Return(_localEvaluatedItems);
            ArrayPool<int>.Shared.Return(_localEvaluatedProperties);
            ArrayPool<int>.Shared.Return(_appliedEvaluatedItems);
            ArrayPool<int>.Shared.Return(_appliedEvaluatedProperties);
#endif
            if (_rentedBytes != null && IsDisposable)
            {
                byte[]? bytesToReturn = Interlocked.Exchange(ref _rentedBytes, null);
                if (bytesToReturn != null)
                {
                    // Clear the bytes as they may contain actual data
                    bytesToReturn.AsSpan(0, Length).Clear();
                    ArrayPool<byte>.Shared.Return(bytesToReturn);
                }
            }
        }

        public void AddLocalEvaluatedItem(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Span<int> localEvaluatedItems = LocalEvaluatedItems;
                Debug.Assert(intOffset < localEvaluatedItems.Length);
                localEvaluatedItems[intOffset] |= bit;
            }
        }

        public void AddLocalEvaluatedProperty(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Span<int> localEvaluatedProperties = LocalEvaluatedProperties;
                Debug.Assert(intOffset < localEvaluatedProperties.Length);
                localEvaluatedProperties[intOffset] |= bit;
            }
        }


#if NET
        private void EnsureBitBufferLengths(int propertyCount, int arrayLength)
        {
            Debug.Assert((propertyCount != 0 && arrayLength == 0) || (propertyCount == 0 && arrayLength != 0), "Only one of propertyCount or arrayLength should be non-zero.");

            int requiredLength = 0;

            if (propertyCount > 0)
            {
                int propertyBitBufferLength = 0;

                // Required property buffer length
                propertyBitBufferLength = (propertyCount >> 5) + 1; // Divide by 32 (>> 5) gives offset, add 1 to give length
                int propertyRemainder = propertyCount & 0b1_1111; // Remainder is the bottom 5 bits (0 > 31)
                requiredLength += propertyBitBufferLength + (propertyRemainder == 0 ? 0 : 1);

                if (requiredLength > 0 && requiredLength > _rentedBytes?.Length - _offset - Length)
                {
                    Enlarge(requiredLength * 2);
                }

                return;
            }

            int itemBitBufferLength = 0;
            // Required property buffer length
            itemBitBufferLength = (propertyCount >> 5) + 1; // Divide by 32 (>> 5) gives offset, add 1 to give length
            int itemRemainder = propertyCount & 0b1_1111; // Remainder is the bottom 5 bits (0 > 31)
            requiredLength += itemBitBufferLength + (itemRemainder == 0 ? 0 : 1);

            if (requiredLength > 0 && requiredLength > _rentedBytes?.Length - _offset - Length)
            {
                Enlarge(requiredLength * 2);
            }
        }

        private void Enlarge(int required)
        {
            if(_rentedBytes == null)
            {
                _rentedBytes = ArrayPool<byte>.Shared.Rent(InitialRentedBufferSize);
                return;
            }

            byte[] toReturn = _rentedBytes;

            // Allow the data to grow up to maximum possible capacity (~2G bytes) before encountering overflow.
            // Note: Array.MaxLength exists only on .NET 6 or greater,
            // so for the other versions value is hardcoded
            const int MaxArrayLength = 0x7FFFFFC7;
            Debug.Assert(MaxArrayLength == Array.MaxLength);

            // We will double the length, or use required
            int newCapacity = Math.Max(toReturn.Length * 2, toReturn.Length + required);

            // Note that this check works even when newCapacity overflowed thanks to the (uint) cast
            if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;

            // If the maximum capacity has already been reached,
            // then set the new capacity to be larger than what is possible
            // so that ArrayPool.Rent throws an OutOfMemoryException for us.
            if (newCapacity == toReturn.Length) newCapacity = int.MaxValue;

            _rentedBytes = ArrayPool<byte>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, _rentedBytes, 0, toReturn.Length);

            // The data in this rented buffer only conveys the
            // index of items or properties in a complex value, but no content;
            // so it does not need to be cleared.
            ArrayPool<byte>.Shared.Return(toReturn);
        }

        [InlineArray(BufferSize)]
        public struct EvaluatedIndexBuffer
        {
            private byte _element0;
        }
#endif
    }
}
