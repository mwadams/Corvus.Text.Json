// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// We need to target netstandard2.0, so keep using ref for MemoryMarshal.Write
// CS9191: The 'ref' modifier for argument 2 corresponding to 'in' parameter is equivalent to 'in'. Consider using 'in' instead.
#pragma warning disable CS9191

namespace Corvus.Text.Json.Internal
{
    // The database for the parsed structure of a JSON document.
    //
    // Every token from the document gets a row, which has one of the following forms:
    //
    // Number
    // * First int
    //   * Top bit is 0 if this is the local token offset, 1 if it is an external document
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is set if the number uses scientific notation
    //   * 31 bits for the token length
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the index of the workspace document in the workspace for this row
    //
    // String, PropertyName
    // * First int
    //   * Top bit is 0 if this is the local token offset, 1 if it is an external document
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is set if the string requires unescaping
    //   * 31 bits for the token length
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the index of the workspace document in the workspace for this row
    //
    // Other value types (True, False, Null)
    // * First int
    //   * Top bit is 0 if this is the local token offset, 1 if it is an external document
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is unassigned / always clear
    //   * 31 bits for the token length
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the index of the workspace document in the workspace for this row
    //
    // EndObject
    // * First int
    //   * Top bit is unassigned / always clear
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is 1 if this object has a property map, otherwise 0
    //   * 31 bits - index into the property map buffer if this has a property map backing, otherwise the length of the token
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the number of rows until the previous value (never 0)
    //
    // EndArray
    // * First int
    //   * Top bit is unassigned / always clear
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Unassigned / always clear
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the number of rows until the previous value (never 0)
    //
    // StartObject
    // * First int
    //   * Top bit is 0 if this is the local token offset, 1 if it is an external document
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is unassigned / always clear
    //   * 31 bits for the number of properties in this object
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the number of rows until the next value (never 0) if this is a local value,
    //     or the index of the workspace document in the workspace for this row if this is an external value.
    //
    // StartArray
    // * First int
    //   * Top bit is 0 if this is the local token offset, 1 if it is an external document
    //   * 31 bits for token offset if the top bit is zero, or the external document index if
    //     the top bit is 1
    // * Second int
    //   * Top bit is set if the array contains other arrays or objects ("complex" types)
    //   * 31 bits for the number of elements in this array
    // * Third int
    //   * 4 bits JsonTokenType
    //   * 28 bits for the number of rows until the next value (never 0) if this is a local value,
    //     or the index of the workspace document in the workspace for this row if this is an external value.
    public struct MetadataDb : IDisposable
    {
        private const int SizeOrLengthOffset = 4;
        private const int NumberOfRowsOffset = 8;

        internal int Length { get; private set; }
        private byte[] _data;

        private bool _convertToAlloc; // Convert the rented data to an alloc when complete.
        private bool _isLocked; // Is the array the correct fixed size.
                                // _isLocked _convertToAlloc truth table:
                                // false     false  Standard flow. Size is not known and renting used throughout lifetime.
                                // true      false  Used by JsonElement.ParseValue() for primitives and JsonDocument.Clone(). Size is known and no renting.
                                // false     true   Used by JsonElement.ParseValue() for arrays and objects. Renting used until size is known.
                                // true      true   not valid

        private MetadataDb(byte[] initialDb, bool isLocked, bool convertToAlloc, int length = 0)
        {
            _data = initialDb;
            _isLocked = isLocked;
            _convertToAlloc = convertToAlloc;
            Length = length;
        }

        internal MetadataDb(byte[] completeDb)
        {
            _data = completeDb;
            _isLocked = true;
            _convertToAlloc = false;
            Length = completeDb.Length;
        }

        // If the instance is "default", _data can be null
        internal bool IsInitialized => _data is not null;

        internal static MetadataDb CreateRented(byte[] data, int length, bool convertToAlloc)
        {
            return new MetadataDb(data, isLocked: false, convertToAlloc, length);
        }

        internal static MetadataDb CreateRented(int payloadLength, bool convertToAlloc)
        {
            int initialSize = CalculateInitialSize(payloadLength);

            byte[] data = ArrayPool<byte>.Shared.Rent(initialSize);
            return new MetadataDb(data, isLocked: false, convertToAlloc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalculateInitialSize(int payloadLength)
        {
            // Assume that a token happens approximately every 12 bytes.
            // int estimatedTokens = payloadLength / 12
            // now acknowledge that the number of bytes we need per token is 12.
            // So that's just the payload length.
            //
            // Add one row worth of data since we need at least one row for a primitive type.
            int initialSize = payloadLength + DbRow.Size;

            // Stick with ArrayPool's rent/return range if it looks feasible.
            // If it's wrong, we'll just grow and copy as we would if the tokens
            // were more frequent anyways.
            const int OneMegabyte = 1024 * 1024;

            if (initialSize > OneMegabyte && initialSize <= 4 * OneMegabyte)
            {
                initialSize = OneMegabyte;
            }

            return initialSize;
        }

        internal static MetadataDb CreateLocked(int payloadLength, bool convertToAlloc = false)
        {
            // Add one row worth of data since we need at least one row for a primitive type.
            int size = payloadLength + DbRow.Size;

            byte[] data = new byte[size];
            return new MetadataDb(data, isLocked: true, convertToAlloc: convertToAlloc);
        }

        public void Dispose()
        {
            byte[]? data = Interlocked.Exchange(ref _data, null!);
            if (data == null)
            {
                return;
            }

            Debug.Assert(!_isLocked, "Dispose called on a locked database");

            // The data in this rented buffer only conveys the positions and
            // lengths of tokens in a document, but no content; so it does not
            // need to be cleared.
            ArrayPool<byte>.Shared.Return(data);
            Length = 0;
        }

        /// <summary>
        /// If using array pools, trim excess if necessary.
        /// If not using array pools, release the temporary array pool and alloc.
        /// </summary>
        internal void CompleteAllocations()
        {
            if (!_isLocked)
            {
                if (_convertToAlloc)
                {
                    Debug.Assert(_data != null);
                    byte[] returnBuf = _data;
                    _data = _data.AsSpan(0, Length).ToArray();
                    _isLocked = true;
                    _convertToAlloc = false;

                    // The data in this rented buffer only conveys the positions and
                    // lengths of tokens in a document, but no content; so it does not
                    // need to be cleared.
                    ArrayPool<byte>.Shared.Return(returnBuf);
                }
                else
                {
                    // There's a chance that the size we have is the size we'd get for this
                    // amount of usage (particularly if Enlarge ever got called); and there's
                    // the small copy-cost associated with trimming anyways. "Is half-empty" is
                    // just a rough metric for "is trimming worth it?".
                    if (Length <= _data.Length / 2)
                    {
                        byte[] newRent = ArrayPool<byte>.Shared.Rent(Length);
                        byte[] returnBuf = newRent;

                        if (newRent.Length < _data.Length)
                        {
                            Buffer.BlockCopy(_data, 0, newRent, 0, Length);
                            returnBuf = _data;
                            _data = newRent;
                        }

                        // The data in this rented buffer only conveys the positions and
                        // lengths of tokens in a document, but no content; so it does not
                        // need to be cleared.
                        ArrayPool<byte>.Shared.Return(returnBuf);
                    }
                }
            }
        }

        internal void Append(JsonTokenType tokenType, int startLocation, int length)
        {
            // StartArray or StartObject should have length -1, otherwise the length should not be -1.
            Debug.Assert(
                (tokenType == JsonTokenType.StartArray || tokenType == JsonTokenType.StartObject) ==
                (length == DbRow.UnknownSize));

            if (Length >= _data.Length - DbRow.Size)
            {
                Enlarge();
            }

            DbRow row = new DbRow(tokenType, startLocation, length);
            MemoryMarshal.Write(_data.AsSpan(Length), ref row);
            Length += DbRow.Size;
        }

        internal void AppendDynamicSimpleValue(JsonTokenType tokenType, int location, bool requiresUnescapingOrHasExponent)
        {
            Debug.Assert(tokenType >= JsonTokenType.PropertyName);

            if (Length >= _data.Length - DbRow.Size)
            {
                Enlarge();
            }

            DbRow row = new DbRow(tokenType, location, requiresUnescapingOrHasExponent ? -1 : 1);
            MemoryMarshal.Write(_data.AsSpan(Length), ref row);
            Length += DbRow.Size;
        }

        internal void ReplaceRowsInComplexObject(IMutableJsonDocument parentDocument, int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, int rowCountToInsert, int memberCountToInsert)
        {
            // First, we need to figure out how many rows we are replacing.
            int rowCountToAddOrRemove = rowCountToInsert - ((endIndex - startIndex) / DbRow.Size);
            int memberCountToAddOrRemove = memberCountToInsert - memberCountToReplace;

            InsertOrRemoveRowsInComplexObject(parentDocument, complexObjectStartIndex, startIndex, endIndex, rowCountToAddOrRemove, memberCountToAddOrRemove);
        }

        internal void InsertRowsInComplexObject(IMutableJsonDocument parentDocument, int complexObjectStartIndex, int startIndex, int rowCountToInsert, int memberCountToInsert)
        {
            InsertOrRemoveRowsInComplexObject(parentDocument, complexObjectStartIndex, startIndex, startIndex, rowCountToInsert, memberCountToInsert);
        }

        // This makes a space available to insert the given number of rows into the DB at the given index.
        // It fixes up the next/previous rows in containing complex objects and leaves them available
        // to be set.
        // The startIndex is the start of the range where we are inserting or removing
        // endIndex is the same as startIndex if we are inserting, or the end of the range that we are removing, if removing
        private void InsertOrRemoveRowsInComplexObject(IMutableJsonDocument parentDocument, int complexObjectStartIndex, int startIndex, int endIndex, int rowCountToInsert, int memberCountToInsert)
        {
            AssertValidIndex(startIndex);
            AssertValidIndex(complexObjectStartIndex);

            Debug.Assert(!_isLocked, "Appending to a locked database");
            Debug.Assert(GetJsonTokenType(complexObjectStartIndex) is JsonTokenType.StartArray or JsonTokenType.StartObject);

            // First, fix up the counts, then block copy
            // If we do it in that order, we can just step through the data "as is"
            // with existing offsets
            int currentIndex = complexObjectStartIndex;
            while (currentIndex >= 0)
            {
                JsonTokenType tokenType = GetJsonTokenType(currentIndex);
                switch (tokenType)
                {
                    case JsonTokenType.EndObject:
                    case JsonTokenType.EndArray:
                        // Skip past the start object of this end object, and into the previous entry
                        currentIndex = GetStartIndex(currentIndex) - DbRow.Size;
                        break;
                    case JsonTokenType.StartObject:
                        // This was not skipped by hitting an EndObject/Array,
                        // so it must be the start of a containing object/array
                        // which will need to have its row count updated
                        SetRowAndMemberCount(currentIndex, currentIndex + parentDocument.GetDbSize(currentIndex, false), rowCountToInsert, memberCountToInsert);
                        // No more members to insert once we move out of our object, just rows.
                        memberCountToInsert = 0;
                        currentIndex -= DbRow.Size;
                        break;
                    case JsonTokenType.StartArray:
                        // This was not skipped by hitting an EndObject/Array,
                        // so it must be the start of a containing object/array
                        // which will need to have its row count updated
                        SetRowAndMemberCount(currentIndex, currentIndex + parentDocument.GetDbSize(currentIndex, false), rowCountToInsert, memberCountToInsert, isArray: true);
                        // No more members to insert once we move out of our array, just rows.
                        memberCountToInsert = 0;
                        currentIndex -= DbRow.Size;
                        break;
                    default:
                        currentIndex -= DbRow.Size;
                        break;
                }
            }

            int lengthToInsert = DbRow.Size * rowCountToInsert;

            if (lengthToInsert == 0)
            {
                return;
            }

            if (lengthToInsert > _data.Length - Length)
            {
                // We will need to reallocate
                byte[] toReturn = _data;

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

                _data = ArrayPool<byte>.Shared.Rent(newCapacity);
                // Block copy up to index
                Buffer.BlockCopy(toReturn, 0, _data, 0, startIndex);
                // Then copy the rest of the data with the extra space
                Buffer.BlockCopy(toReturn, endIndex, _data, endIndex + lengthToInsert, Length - endIndex);

                // The data in this rented buffer only conveys the positions and
                // lengths of tokens in a document, but no content; so it does not
                // need to be cleared.
                ArrayPool<byte>.Shared.Return(toReturn);
            }
            else
            {
                // We don't need to reallocate, so just copy the data up
                // This is also the code path if lengthToInsert is negative. We will be
                // copying the data down.
                Buffer.BlockCopy(_data, endIndex, _data, endIndex + lengthToInsert, Length - endIndex);
            }

            Length += lengthToInsert;
        }

        private void SetRowAndMemberCount(int startIndex, int endIndex, int rowCountToInsertOrRemove, int memberCountToInsertOrRemove, bool isArray = false)
        {
            AssertValidIndex(startIndex);
            AssertValidIndex(endIndex);

            Span<byte> endNumberOfRowsUnionPos = _data.AsSpan(endIndex + NumberOfRowsOffset);
            uint endNumberOfRowsUnion = MemoryMarshal.Read<uint>(endNumberOfRowsUnionPos);

            // Start and end row count are the same value, so we only need to calculate this once
            int numberOfRows = (int)(endNumberOfRowsUnion & 0x0FFFFFFFU) + rowCountToInsertOrRemove;

            Debug.Assert(numberOfRows >= 0);
            Debug.Assert(numberOfRows <= 0x0FFFFFFF);

            // Now update the end row.
            uint endTokenType = endNumberOfRowsUnion & 0xF0000000U;
            uint updatedValue = endTokenType | unchecked((uint)numberOfRows);
            MemoryMarshal.Write(endNumberOfRowsUnionPos, ref updatedValue);

            // And we aren't in an external document
            Span<byte> target = _data.AsSpan(endIndex, sizeof(int));
            MemoryMarshal.Cast<byte, int>(target)[0] = 0;

            // Now we will do the start positions
            // We have reversed the order from the usual so we update end first, then start
            // because we need the info from the end tgo calculate the number of rows
            // and this should help avoid busting the cache so often

            // Set the token offset to 0 - this makes it a local item in the builder document
            // as we no longer directly apply the target backing
            target = _data.AsSpan(startIndex, sizeof(int));
            MemoryMarshal.Cast<byte, int>(target)[0] = 0;

            // Persist the most significant nybble and the new row count
            Span<byte> startNumberOfRowsUnionPos = _data.AsSpan(startIndex + NumberOfRowsOffset);
            uint startNumberOfRowsUnion = MemoryMarshal.Read<uint>(startNumberOfRowsUnionPos);
            uint startTokenType = startNumberOfRowsUnion & 0xF0000000U;
            updatedValue = startTokenType | unchecked((uint)numberOfRows);
            MemoryMarshal.Write(startNumberOfRowsUnionPos, ref updatedValue);

            // Now do the item counts and complex children for the start. We do this now to try and do
            // all the local updates first, to avoid busting the cache.
            Span<byte> startSizeOrLengthUnion = _data.AsSpan(startIndex + SizeOrLengthOffset);
            int currentLength = (int)(MemoryMarshal.Read<uint>(startSizeOrLengthUnion) & 0x7FFF_FFFFU);
            currentLength += memberCountToInsertOrRemove;

            if (isArray)
            {
                // If the array item count is (e.g.) 12 and the number of rows is (e.g.) 13
                // then the extra row is just the EndArray item, so the array was made up
                // of simple values.
                //
                // If the off-by-one relationship does not hold, then one of the values was
                // more than one row, making it a complex object. This is indicated by setting
                // the top bit of currentLenght (which, handily, is just negating the value).
                // The current length must be greater than zero, as we must have at least
                // one row for this condition to hold.
                if (currentLength + 1 != numberOfRows)
                {
                    currentLength = (int)((uint)currentLength | 0x8000_0000U);
                }
            }

            MemoryMarshal.Write(startSizeOrLengthUnion, ref currentLength);
        }

        internal void AppendExternal(JsonTokenType tokenType, int externalIndex, int sizeOrLength, int workspaceDocumentIndexOrNumberOfRows)
        {
            if (Length >= _data.Length - DbRow.Size)
            {
                Enlarge();
            }

            DbRow row = new DbRow(tokenType, externalIndex, sizeOrLength, workspaceDocumentIndexOrNumberOfRows);
            MemoryMarshal.Write(_data.AsSpan(Length), ref row);
            Length += DbRow.Size;
        }

        private void Enlarge()
        {
            Debug.Assert(!_isLocked, "Appending to a locked database");

            byte[] toReturn = _data;

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

            _data = ArrayPool<byte>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, _data, 0, toReturn.Length);

            // The data in this rented buffer only conveys the positions and
            // lengths of tokens in a document, but no content; so it does not
            // need to be cleared.
            ArrayPool<byte>.Shared.Return(toReturn);
        }

        [Conditional("DEBUG")]
        private void AssertValidIndex(int index)
        {
            Debug.Assert(index >= 0);
            Debug.Assert(index <= Length - DbRow.Size, $"startIndex {index} is out of bounds");
            Debug.Assert(index % DbRow.Size == 0, $"startIndex {index} is not at a record start position");
        }

        internal void SetLength(int index, int length)
        {
            AssertValidIndex(index);
            Debug.Assert(length >= 0);
            Span<byte> destination = _data.AsSpan(index + SizeOrLengthOffset);
            MemoryMarshal.Write(destination, ref length);
        }

        internal void SetNumberOfRows(int index, int numberOfRows)
        {
            AssertValidIndex(index);
            Debug.Assert(numberOfRows >= 1 && numberOfRows <= 0x0FFFFFFF);

            Span<byte> dataPos = _data.AsSpan(index + NumberOfRowsOffset);
            int current = MemoryMarshal.Read<int>(dataPos);

            // Persist the most significant nybble
            int value = (current & unchecked((int)0xF0000000)) | numberOfRows;
            MemoryMarshal.Write(dataPos, ref value);
        }

        internal void SetPropertyMapIndex(int index, int propertyMapIndex)
        {
            this.AssertValidIndex(index);
            uint pmi = (uint)propertyMapIndex | 0x8000_0000U;

            Span<byte> destination = _data.AsSpan(index + SizeOrLengthOffset);

            MemoryMarshal.Write(destination, ref pmi);
        }

        internal void SetHasComplexChildren(int index)
        {
            AssertValidIndex(index);

            // The HasComplexChildren bit is the most significant bit of "SizeOrLength"
            Span<byte> dataPos = _data.AsSpan(index + SizeOrLengthOffset);
            int current = MemoryMarshal.Read<int>(dataPos);

            int value = current | unchecked((int)0x80000000);
            MemoryMarshal.Write(dataPos, ref value);
        }

        internal int FindIndexOfFirstUnsetSizeOrLength(JsonTokenType lookupType)
        {
            Debug.Assert(lookupType == JsonTokenType.StartObject || lookupType == JsonTokenType.StartArray);
            return FindOpenElement(lookupType);
        }

        internal int FindOpenElement(JsonTokenType lookupType)
        {
            Span<byte> data = _data.AsSpan(0, Length);

            for (int i = Length - DbRow.Size; i >= 0; i -= DbRow.Size)
            {
                DbRow row = MemoryMarshal.Read<DbRow>(data.Slice(i));

                if (row.IsUnknownSize && row.TokenType == lookupType)
                {
                    return i;
                }
            }

            // We should never reach here.
            Debug.Fail($"Unable to find expected {lookupType} token");
            return -1;
        }

        internal DbRow Get(int index)
        {
            AssertValidIndex(index);
            return MemoryMarshal.Read<DbRow>(_data.AsSpan(index));
        }

        internal JsonTokenType GetJsonTokenType(int index)
        {
            AssertValidIndex(index);
            uint union = MemoryMarshal.Read<uint>(_data.AsSpan(index + NumberOfRowsOffset));

            return (JsonTokenType)(union >> 28);
        }

        internal int GetStartIndex(int endIndex)
        {
            Debug.Assert(GetJsonTokenType(endIndex) is JsonTokenType.EndObject or JsonTokenType.EndArray);

            uint union = MemoryMarshal.Read<uint>(_data.AsSpan(endIndex + NumberOfRowsOffset));
            return endIndex - ((int)(union & 0x0FFFFFFFU) * DbRow.Size);
        }

        internal MetadataDb CopySegment(int startIndex, int endIndex)
        {
            Debug.Assert(
                endIndex > startIndex,
                $"endIndex={endIndex} was at or before startIndex={startIndex}");

            AssertValidIndex(startIndex);
            Debug.Assert(endIndex <= Length);

            DbRow start = Get(startIndex);
#if DEBUG
            DbRow end = Get(endIndex - DbRow.Size);

            if (start.TokenType == JsonTokenType.StartObject)
            {
                Debug.Assert(
                    end.TokenType == JsonTokenType.EndObject,
                    $"StartObject paired with {end.TokenType}");
            }
            else if (start.TokenType == JsonTokenType.StartArray)
            {
                Debug.Assert(
                    end.TokenType == JsonTokenType.EndArray,
                    $"StartArray paired with {end.TokenType}");
            }
            else
            {
                Debug.Assert(
                    startIndex + DbRow.Size == endIndex,
                    $"{start.TokenType} should have been one row");
            }
#endif

            int length = endIndex - startIndex;

            byte[] newDatabase = new byte[length];
            _data.AsSpan(startIndex, length).CopyTo(newDatabase);

            Span<int> newDbInts = MemoryMarshal.Cast<byte, int>(newDatabase.AsSpan());
            int locationOffset = newDbInts[0];

            // Need to nudge one forward to account for the hidden quote on the string.
            if (start.TokenType == JsonTokenType.String)
            {
                locationOffset--;
            }

            for (int i = (length - DbRow.Size) / sizeof(int); i >= 0; i -= DbRow.Size / sizeof(int))
            {
                Debug.Assert(newDbInts[i] >= locationOffset);
                newDbInts[i] -= locationOffset;
            }

            return new MetadataDb(newDatabase);
        }

        internal int TakeOwnership(out byte[] rentedBacking)
        {
            byte[]? data = Interlocked.Exchange(ref _data, null!);
            Debug.Assert(data != null);
            rentedBacking = data;
            int length = Length;
            Length = 0;
            return length;
        }

        internal void Overwrite(ref MetadataDb destination, int targetIndex)
        {
            Debug.Assert(Length <= destination.Length - targetIndex);
            Buffer.BlockCopy(_data, 0, destination._data, targetIndex, Length);
        }
    }
}
