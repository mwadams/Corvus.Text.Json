// <copyright file="Document.PropertyMap.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// Derived from code:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Buffers;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
#pragma warning disable CS9191 // This is the warning about in/ref params; we disable it because we target netstandard2.0

    public abstract partial class JsonDocument
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct PropertyMap
        {
            public int BucketCount; // The BucketCount of our bucket set.
            public int Count; // The number of entries in the map.
            public int BucketOffset; // The offset into the buckets buffer where our buckets start.
            public int EntryOffset; // The offset into the entries buffer where our entries start.
            public int LengthOfEndToken; // The length of the end token

            internal const int LengthOfEndTokenOffset = 16; // The offset of the length of the end token in the property map

            internal const int Size = 20;

#if DEBUG
            static unsafe PropertyMap()
            {
                Debug.Assert(sizeof(PropertyMap) == Size, "Size");
            }
#endif

            internal static void Write(int bucketOffset, int entryOffset, int bucketCount, int count, Span<byte> destination, int lengthOfEndToken)
            {
                var propertyMap = new PropertyMap() { BucketCount = bucketCount, Count = count, BucketOffset = bucketOffset, EntryOffset = entryOffset, LengthOfEndToken = lengthOfEndToken };
                MemoryMarshal.Write(destination, ref propertyMap);
            }

            internal static int GetLengthOfEndToken(Span<byte> propertyMap)
            {
                return MemoryMarshal.Read<int>(propertyMap.Slice(LengthOfEndTokenOffset));
            }

            internal static ulong GetHashCode(in ReadOnlySpan<byte> key)
            {
                int length = key.Length;

                return length switch
                {
                    7 => MemoryMarshal.Read<uint>(key.Slice(0, 4))
                            + ((ulong)key[4] << 32)
                            + ((ulong)key[5] << 40)
                            + ((ulong)key[6] << 48),
                    6 => MemoryMarshal.Read<uint>(key.Slice(0, 4))
                            + ((ulong)key[4] << 32)
                            + ((ulong)key[5] << 40),
                    5 => MemoryMarshal.Read<uint>(key.Slice(0, 4))
                            + ((ulong)key[4] << 32),
                    4 => MemoryMarshal.Read<uint>(key.Slice(0, 4)),
                    3 => ((ulong)key[2] << 16)
                            + ((ulong)key[1] << 8)
                            + key[0],
                    2 => ((ulong)key[1] << 8)
                            + key[0],
                    1 => key[0],
                    0 => 0,
                    _ => ((ulong)((length + key[7] + key[key.Length - 1]) % 256) << 56)
                            + MemoryMarshal.Read<uint>(key.Slice(0, 4))
                            + ((ulong)key[4] << 32)
                            + ((ulong)key[5] << 40)
                            + ((ulong)key[6] << 48),
                };
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static ref int GetBucket(Span<int> buckets, ulong hashCode, int size)
            {
                return ref buckets[(int)(hashCode % (ulong)size)];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static int GetBucket(ReadOnlySpan<int> buckets, ulong hashCode, int size)
            {
                return buckets[(int)(hashCode % (ulong)size)];
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct Entry
            {
                public const int Size = 24;

                public int Next;
                public int ValueIndex;
                public ulong HashCode;
                private int keyOffsetForDynamicUnescapedKey; // Top bit is 1 if the value , and the rest == offset into the key buffer if the name is escaped; otherwise all 0

#if DEBUG
                static unsafe Entry()
                {
                    Debug.Assert(sizeof(Entry) == Size, "Size");
                }
#endif

                public readonly bool HasDynamicUnescapedKey => this.keyOffsetForDynamicUnescapedKey >= 0;

                public readonly int KeyOffset => this.keyOffsetForDynamicUnescapedKey & int.MaxValue;

                /// <summary>
                /// This write is used when the entry does not require unescaping
                /// and the key is in the raw JSON data (the most common case).
                /// </summary>
                /// <param name="destination">The destination span to write to.</param>
                /// <param name="hashCode">The hash code of the entry.</param>
                /// <param name="next">The next index in the bucket.</param>
                /// <param name="valueIndex">The value index in the source meta db.</param>
                public static void Write(
                    Span<byte> destination,
                    ulong hashCode,
                    int next,
                    int valueIndex)
                {
                    var entry = new Entry
                    {
                        HashCode = hashCode,
                        Next = next,
                        ValueIndex = valueIndex,
                        keyOffsetForDynamicUnescapedKey = -1,
                    };

                    MemoryMarshal.Write(destination, ref entry);
                }

                /// <summary>
                /// This write is used when the entry requires unescaping
                /// in which case the keyOffset is the offset into the
                /// dynamic value buffer.
                /// </summary>
                /// <param name="destination">The destination span to write to.</param>
                /// <param name="hashCode">The hash code of the entry.</param>
                /// <param name="next">The next index in the bucket.</param>
                /// <param name="valueIndex">The value index in the source meta db.</param>
                /// <param name="keyOffset">The offset of the key name in the dynamic value backing in the workspace.</param>
                public static void Write(
                    Span<byte> destination,
                    ulong hashCode,
                    int next,
                    int valueIndex,
                    int keyOffset)
                {
                    var entry = new Entry
                    {
                        HashCode = hashCode,
                        Next = next,
                        ValueIndex = valueIndex,
                        keyOffsetForDynamicUnescapedKey = keyOffset,
                    };

                    MemoryMarshal.Write(destination, ref entry);
                }
            }
        }

        protected void EnsurePropertyMapUnsafe(int index)
        {
            DbRow row = _parsedData.Get(index);
            Debug.Assert(row.TokenType != JsonTokenType.StartObject);
            int endIndex = checked((row.NumberOfRows * DbRow.Size) + index);
            row = _parsedData.Get(endIndex);

            if (!row.HasPropertyMap)
            {
                int propertyMapIndex = CreatePropertyMap(index);
                _parsedData.SetPropertyMapIndex(endIndex, propertyMapIndex);
            }
        }

        private int CreatePropertyMap(int startObjectIndex)
        {
            DbRow startObjectRow = _parsedData.Get(startObjectIndex);
            int endIndex = checked((startObjectRow.NumberOfRows * DbRow.Size) + startObjectIndex);
            DbRow endObjectRow = _parsedData.Get(endIndex);

            int lengthOfEnd = endObjectRow.SizeOrLengthOrPropertyMapIndex;
            int propertyCount = startObjectRow.SizeOrLengthOrPropertyMapIndex;
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
                int valueIndex = index + DbRow.Size;
                DbRow row = _parsedData.Get(valueIndex);
                Debug.Assert(propertyRow.TokenType == JsonTokenType.PropertyName, "The row must be a property name");

                if (propertyRow.HasComplexChildren)
                {
                    Debug.Assert(propertyRow.LocationOrIndex >= 0, "The property must be local if it has complex children");

                    ReadOnlyMemory<byte> rawName = GetRawSimpleValueUnsafe(index, false);
                    ReadOnlySpan<byte> unescapedName = UnescapeAndStoreUnescapedStringValue(rawName.Span, out int dynamicValueOffset);
                    ulong hashCode = PropertyMap.GetHashCode(unescapedName);
                    ref int bucket = ref PropertyMap.GetBucket(buckets, hashCode, size);
                    int entryIndex = propertyIndex * PropertyMap.Entry.Size;
                    PropertyMap.Entry.Write(entries.Slice(entryIndex, PropertyMap.Entry.Size), hashCode, bucket - 1, valueIndex, dynamicValueOffset);
                    propertyIndex++;
                    bucket = propertyIndex; // Value in buckets is 1-based
                }
                else
                {
                    ReadOnlyMemory<byte> rawName = GetRawSimpleValueUnsafe(index, false);
                    ulong hashCode = PropertyMap.GetHashCode(rawName.Span);
                    ref int bucket = ref PropertyMap.GetBucket(buckets, hashCode, size);
                    int entryIndex = propertyIndex * PropertyMap.Entry.Size;
                    PropertyMap.Entry.Write(entries.Slice(entryIndex, PropertyMap.Entry.Size), hashCode, bucket - 1, valueIndex);
                    propertyIndex++;
                    bucket = propertyIndex; // Value in buckets is 1-based
                }

                if (row.IsSimpleValue)
                {
                    index = valueIndex + DbRow.Size;
                }
                else
                {
                    Debug.Assert(row.NumberOfRows > 0, "There must be at least one row in a non-simple value.");
                    index = valueIndex + (DbRow.Size * (row.NumberOfRows + 1));
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

        protected bool TryGetNamedPropertyValueFromPropertyMap(int propertyMapBufferIndex, ReadOnlySpan<byte> unescapedUtf8Name, out int valueIndex)
        {
            PropertyMap propertyMap = MemoryMarshal.Read<PropertyMap>(_propertyMapBacking.AsSpan(propertyMapBufferIndex, PropertyMap.Size));
            Span<int> buckets = _bucketsBacking.AsSpan(propertyMap.BucketOffset, propertyMap.BucketCount);
            Span<byte> entries = _entriesBacking.AsSpan(propertyMap.EntryOffset, propertyMap.Count * PropertyMap.Entry.Size);

            ulong hashCode = PropertyMap.GetHashCode(unescapedUtf8Name);
            int i = PropertyMap.GetBucket(buckets, hashCode, propertyMap.BucketCount);
            uint collisionCount = 0;
            PropertyMap.Entry entry;

            i--; // Value in _buckets is 1-based; subtract 1 from i. We do it here so it fuses with the following conditional.
            do
            {
                int offset = i * PropertyMap.Entry.Size;

                // Test in if to drop range check for following array access
                if ((uint)offset >= (uint)entries.Length)
                {
                    goto ReturnNotFound;
                }

                entry = MemoryMarshal.Read<PropertyMap.Entry>(entries.Slice(offset));
                if (entry.HashCode == hashCode &&
                        (((unescapedUtf8Name.Length < HashLength) &&
                            ((hashCode & HashMask) == 0)) ||
                        GetKey(ref entry).SequenceEqual(unescapedUtf8Name)))
                {
                    goto ReturnFound;
                }

                i = entry.Next;

                collisionCount++;
            }
            while (collisionCount <= propertyMap.Count);

            Debug.Fail("Possible infinite loop in PropertyMap.FindValue.");

        ReturnFound:
            valueIndex = entry.ValueIndex;
            return true;
        ReturnNotFound:
            valueIndex = -1;
            return false;
        }

        private ReadOnlySpan<byte> GetKey(ref PropertyMap.Entry entry)
        {
            if (entry.HasDynamicUnescapedKey)
            {
                return ReadDynamicUnescapedUtf8String(entry.KeyOffset).Span;
            }
            else
            {
                return GetRawSimpleValueUnsafe(entry.ValueIndex - DbRow.Size, false).Span;
            }
        }
    }
}
