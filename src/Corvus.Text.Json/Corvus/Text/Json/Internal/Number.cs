// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
    internal static class Number
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void WriteTwoDigits(uint value, byte* ptr)
        {
            Debug.Assert(value <= 99);

            Unsafe.CopyBlockUnaligned(
                ref *ptr,
                ref Unsafe.Add(ref MemoryMarshal.GetReference(TwoDigitsBytes), (uint)sizeof(byte) * 2 * value),
                (uint)sizeof(byte) * 2);
        }

        /// <summary>
        /// Writes a value [ 0000 .. 9999 ] to the buffer starting at the specified offset.
        /// This method performs best when the starting index is a constant literal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void WriteFourDigits(uint value, byte* ptr)
        {
            Debug.Assert(value <= 9999);

#if NET
            (value, uint remainder) = Math.DivRem(value, 100);
#else
            value = (uint)Math.DivRem((int)value, 100, out int remainder);
#endif
            ref byte charsArray = ref MemoryMarshal.GetReference(TwoDigitsBytes);

            Unsafe.CopyBlockUnaligned(
                ref *ptr,
                ref Unsafe.Add(ref charsArray, (uint)sizeof(byte) * 2 * value),
                (uint)sizeof(byte) * 2);

            Unsafe.CopyBlockUnaligned(
                ref *(ptr + 2),
#if NET
                ref Unsafe.Add(ref charsArray, (uint)sizeof(byte) * 2 * remainder),
#else
                ref Unsafe.Add(ref charsArray, sizeof(byte) * 2 * remainder),
#endif
                (uint)sizeof(byte) * 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe void WriteDigits(uint value, byte* ptr, int count)
        {
            byte* cur;
            for (cur = ptr + count - 1; cur > ptr; cur--)
            {
                uint temp = '0' + value;
                value /= 10;
                *cur = (byte)(temp - (value * 10));
            }

            Debug.Assert(value < 10);
            Debug.Assert(cur == ptr);
            *cur = (byte)('0' + value);
        }

        private static ReadOnlySpan<byte> TwoDigitsBytes =>
                                "00010203040506070809"u8 +
                                "10111213141516171819"u8 +
                                "20212223242526272829"u8 +
                                "30313233343536373839"u8 +
                                "40414243444546474849"u8 +
                                "50515253545556575859"u8 +
                                "60616263646566676869"u8 +
                                "70717273747576777879"u8 +
                                "80818283848586878889"u8 +
                                "90919293949596979899"u8;
    }
}
