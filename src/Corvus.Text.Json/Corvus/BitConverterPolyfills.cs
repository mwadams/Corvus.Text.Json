// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus;

/// <summary>
/// Provides polyfills for <see cref="System.BitConverter"/> methods for .NET Standard 2.0, enabling conversion between primitive types and byte arrays or spans.
/// </summary>
[CLSCompliant(false)]
public static class BitConverterPolyfills
{
    extension(BitConverter)
    {
        /// <summary>
        /// Converts a 32-bit signed integer (<see cref="int"/>) into a span of bytes.
        /// </summary>
        /// <param name="destination">The span to receive the bytes representing the converted value.</param>
        /// <param name="value">The 32-bit signed integer to convert.</param>
        /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryWriteBytes(Span<byte> destination, int value)
        {
            if (destination.Length < sizeof(int))
            {
                return false;
            }

            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
            return true;
        }

        /// <summary>
        /// Converts a 32-bit unsigned integer (<see cref="uint"/>) into a span of bytes.
        /// </summary>
        /// <param name="destination">The span to receive the bytes representing the converted value.</param>
        /// <param name="value">The 32-bit unsigned integer to convert.</param>
        /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryWriteBytes(Span<byte> destination, uint value)
        {
            if (destination.Length < sizeof(uint))
            {
                return false;
            }

            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
            return true;
        }
    }
}
