// <copyright file="Document.PropertyMap.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// Derived from code:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus.Text.Json
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
    }
}
