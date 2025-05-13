// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// We need to target netstandard2.0, so keep using ref for MemoryMarshal.Write
// CS9191: The 'ref' modifier for argument 2 corresponding to 'in' parameter is equivalent to 'in'. Consider using 'in' instead.
#pragma warning disable CS9191

namespace Corvus.Text.Json
{
    public abstract partial class JsonDocument
    {
        // The database for the parsed structure of a JSON document.
        //
        // Every token from the document gets a row, which has one of the following forms:
        //
        // Number
        // * First int
        //   * Top bit is 0 if this is the token offset in the target document, 1 if it is a dynamic number
        //   * 31 bits for token offset if the top bit is zero, or the dynamic value offset if the top bit is 1
        // * Second int
        //   * Top bit is set if the number uses scientific notation
        //   * 31 bits for the token length
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the index of the workspace document in the workspace for this row
        //
        // String, PropertyName
        // * First int
        //   * Top bit is 0 if this is the token offset in the target document, or 1 if this is a dynamic value
        //   * 31 bits for token offset if the top bit is zero, or the dynamic value offset if the top bit is 1
        // * Second int
        //   * Top bit is set if the string requires unescaping
        //   * 31 bits for the token length
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the index of the workspace document in the workspace for this row
        //
        // Other value types (True, False, Null)
        // * First int
        //   * Top bit is unassigned / always clear
        //   * 31 bits for token offset
        // * Second int
        //   * Top bit is unassigned / always clear
        //   * 31 bits for the token length
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the index of the workspace document in the workspace for this row
        //
        // EndObject
        // * First int
        //   * Top bit is 0 if there are no external or dynamic property values, otherwise 1
        //   * 31 bits for token offset
        // * Second int
        //   * Top bit is 1 if this object has a property map, otherwise 0
        //   * 31 bits - index into the property map buffer if this has a property map backing, otherwise the length of the token
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the number of rows until the previous value (never 0)
        //
        // EndArray
        // * First int
        //   * Top bit is 0 if there are no external or dynamic property values, otherwise 1
        //   * 31 bits for token offset
        // * Second int
        //   * Unassigned / always clear
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the number of rows until the previous value (never 0)
        //
        // StartObject
        // * First int
        //   * Top bit is unassigned / always clear
        //   * 31 bits for token offset
        // * Second int
        //   * Top bit is unassigned / always clear
        //   * 31 bits for the number of properties in this object
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the number of rows until the next value (never 0)
        //
        // StartArray
        // * First int
        //   * Top bit is unassigned / always clear
        //   * 31 bits for token offset
        // * Second int
        //   * Top bit is set if the array contains other arrays or objects ("complex" types)
        //   * 31 bits for the number of elements in this array
        // * Third int
        //   * 4 bits JsonTokenType
        //   * 28 bits for the number of rows until the next value (never 0)
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

            internal static MetadataDb CreateLocked(int payloadLength)
            {
                // Add one row worth of data since we need at least one row for a primitive type.
                int size = payloadLength + DbRow.Size;

                byte[] data = new byte[size];
                return new MetadataDb(data, isLocked: true, convertToAlloc: false);
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

            // This makes a space available to insert the given number of rows into the DB at the given index.
            // It fixes up the next/previous rows in containing complex objects and leaves them available
            // to be set.
            internal void InsertRowsInComplexObject(int index, int rowCountToInsert, int itemCountToInsert, bool hasComplexChildren = false)
            {
                AssertValidIndex(index);

                Debug.Assert(!_isLocked, "Appending to a locked database");

                int lengthToInsert = DbRow.Size * rowCountToInsert;
                // We are going to insert a set of rows inside a complex object.

                // First, fix up the counts, then block copy
                // If we do it in that order, we can just step through the data "as is"
                // with existing offsets
                int currentIndex = index - DbRow.Size;
                while(currentIndex >= 0)
                {
                    JsonTokenType tokenType = GetJsonTokenType(currentIndex);
                    switch(tokenType)
                    {
                        case JsonTokenType.EndObject:
                        case JsonTokenType.EndArray:
                            // Skip past the start object of this end object, and into the previous entry
                            index -= GetStartIndex(currentIndex) + DbRow.Size; 
                            break;
                        case JsonTokenType.StartObject:
                            // This was not skipped by hitting an EndObject/Array,
                            // so it must be the start of a containing object/array
                            // which will need to have its row count updated
                            SetRowAndItemCount(currentIndex, rowCountToInsert, itemCountToInsert, false);
                            currentIndex -= DbRow.Size;
                            break;
                        case JsonTokenType.StartArray:
                            // This was not skipped by hitting an EndObject/Array,
                            // so it must be the start of a containing object/array
                            // which will need to have its row count updated
                            SetRowAndItemCount(currentIndex, rowCountToInsert, itemCountToInsert, hasComplexChildren);
                            currentIndex -= DbRow.Size;
                            break;
                        default:
                            currentIndex -= DbRow.Size;
                            break;
                    }
                }


                if (rowCountToInsert > _data.Length - lengthToInsert)
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
                    Buffer.BlockCopy(toReturn, 0, _data, 0, index);
                    // Then copy the rest of the data with the extra space
                    Buffer.BlockCopy(toReturn, index, _data, index + lengthToInsert, Length - index);

                    // The data in this rented buffer only conveys the positions and
                    // lengths of tokens in a document, but no content; so it does not
                    // need to be cleared.
                    ArrayPool<byte>.Shared.Return(toReturn);
                }
                else
                {
                    // We don't need to reallocate, so just copy the data up
                    Buffer.BlockCopy(_data, index, _data, index + lengthToInsert, Length - index);
                }

                Length += lengthToInsert;

            }

            private void SetRowAndItemCount(int startIndex, int rowCountToInsert, int itemCountToInsert, bool hasComplexChildren)
            {
                AssertValidIndex(startIndex);

                int endIndex = GetEndIndex(startIndex);

                AssertValidIndex(endIndex);

                Span<byte> startPos = _data.AsSpan(startIndex + NumberOfRowsOffset);
                uint currentStart = MemoryMarshal.Read<uint>(startPos);

                uint startTokenType = currentStart & 0xF0000000U;

                // Start and end row count are the same value, so we only need to calculate this once
                uint numberOfRows = (currentStart & 0x0FFFFFFFU) + (uint)rowCountToInsert;

                // Persist the most significant nybble and the new row count
                uint updatedValue = startTokenType | numberOfRows;
                MemoryMarshal.Write(startPos, ref updatedValue);

                // Now do the item counts and complex children for the start. We do this now to try and do
                // all the local updates first, to avoid busting the cache.
                startPos = _data.AsSpan(startIndex + SizeOrLengthOffset);
                int currentLength = MemoryMarshal.Read<int>(startPos);
                bool currentlyHasComplexChildren = currentLength < 0;
                int updatedLength = ((currentLength & int.MaxValue) + itemCountToInsert) * ((hasComplexChildren || currentlyHasComplexChildren) ? -1 : 1);
                MemoryMarshal.Write(startPos, ref updatedLength);

                // Now update the end row.
                Span<byte> endPos = _data.AsSpan(endIndex + NumberOfRowsOffset);
                uint currentEnd = MemoryMarshal.Read<uint>(endPos);
                uint endTokenType = currentEnd & 0xF0000000U;
                updatedValue = endTokenType | numberOfRows;
                MemoryMarshal.Write(endPos, ref updatedValue);

            }

            internal void AppendExternal(JsonTokenType tokenType, int externalIndex, int sizeOrLength, int workspaceDocumentIndex)
            {
                // StartArray or StartObject should have length -1, otherwise the length should not be -1.
                Debug.Assert(workspaceDocumentIndex >= 0);

                if (Length >= _data.Length - DbRow.Size)
                {
                    Enlarge();
                }

                DbRow row = new DbRow(tokenType, externalIndex, sizeOrLength, workspaceDocumentIndex);
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
                Debug.Assert(index <= Length - DbRow.Size, $"index {index} is out of bounds");
                Debug.Assert(index % DbRow.Size == 0, $"index {index} is not at a record start position");
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

            private int FindOpenElement(JsonTokenType lookupType)
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

            internal int GetEndIndex(int startIndex)
            {
                Debug.Assert(GetJsonTokenType(startIndex) is JsonTokenType.StartObject or JsonTokenType.StartArray);

                uint union = MemoryMarshal.Read<uint>(_data.AsSpan(startIndex + NumberOfRowsOffset));
                return startIndex + ((int)(union & 0x0FFFFFFFU) * DbRow.Size);
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
}
