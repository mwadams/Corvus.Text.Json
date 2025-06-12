// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
    internal static class StringHashCodePolyfills
    {
        extension(String)
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int GetHashCode(ReadOnlySpan<char> value)
            {
                ulong seed = Marvin.DefaultSeed;

                // Multiplication below will not overflow since going from positive Int32 to UInt32.
                return Marvin.ComputeHash32(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(value)), (uint)value.Length * 2 /* in bytes, not chars */, (uint)seed, (uint)(seed >> 32));
            }
        }

        public static void AddBytes(this HashCode hashCode, ReadOnlySpan<byte> value)
        {
            // Add them in blocks of ulongs
            int longs = value.Length / sizeof(ulong);
            int initialLength = longs * sizeof(ulong);
            var uLongBuffer = MemoryMarshal.Cast<byte, ulong>(value.Slice(0, initialLength));
            for (int i = 0; i < longs; i++)
            {
                hashCode.Add(uLongBuffer[i]);
            }

            // Then add the left-over bytes as bytes
            int remainingBytes = value.Length % sizeof(ulong);
            for (int i = initialLength; i < value.Length; i++)
            {
                hashCode.Add(value[i]);
            }
        }
    }
}
