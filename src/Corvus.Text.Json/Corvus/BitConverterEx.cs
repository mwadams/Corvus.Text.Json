// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Corvus;

/// <summary>
/// Provides polyfills for <see cref="System.BitConverter"/> methods for .NET Standard 2.0, enabling conversion between primitive types and byte arrays or spans.
/// </summary>
[CLSCompliant(false)]
public static class BitConverterEx
{
    /// <summary>
    /// Returns the specified 64-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The 64-bit unsigned integer to convert.</param>
    /// <returns>An array of bytes with length 8 representing the value.</returns>
    public static byte[] GetBytes(ulong value)
    {
        byte[] bytes = new byte[sizeof(ulong)];
        Unsafe.As<byte, ulong>(ref bytes[0]) = value;
        return bytes;
    }

    /// <summary>
    /// Returns the specified single-precision floating point value as an array of bytes.
    /// </summary>
    /// <param name="value">The single-precision floating point value to convert.</param>
    /// <returns>An array of bytes with length 4 representing the value.</returns>
    public static byte[] GetBytes(float value)
    {
        byte[] bytes = new byte[sizeof(float)];
        Unsafe.As<byte, float>(ref bytes[0]) = value;
        return bytes;
    }

    /// <summary>
    /// Returns the specified double-precision floating point value as an array of bytes.
    /// </summary>
    /// <param name="value">The double-precision floating point value to convert.</param>
    /// <returns>An array of bytes with length 8 representing the value.</returns>
    public static byte[] GetBytes(double value)
    {
        byte[] bytes = new byte[sizeof(double)];
        Unsafe.As<byte, double>(ref bytes[0]) = value;
        return bytes;
    }

    /// <summary>
    /// Converts a <see cref="bool"/> value into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted Boolean.</param>
    /// <param name="value">The Boolean value to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, bool value)
    {
        if (destination.Length < sizeof(byte))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value ? (byte)1 : (byte)0);
        return true;
    }

    /// <summary>
    /// Converts a <see cref="char"/> value into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted character.</param>
    /// <param name="value">The character to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, char value)
    {
        if (destination.Length < sizeof(char))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }

    /// <summary>
    /// Converts a 16-bit signed integer (<see cref="short"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The 16-bit signed integer to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, short value)
    {
        if (destination.Length < sizeof(short))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }

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
    /// Converts a 64-bit signed integer (<see cref="long"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The 64-bit signed integer to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, long value)
    {
        if (destination.Length < sizeof(long))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }

    /// <summary>
    /// Converts a 16-bit unsigned integer (<see cref="ushort"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The 16-bit unsigned integer to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, ushort value)
    {
        if (destination.Length < sizeof(ushort))
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

    /// <summary>
    /// Converts a 64-bit unsigned integer (<see cref="ulong"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The 64-bit unsigned integer to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, ulong value)
    {
        if (destination.Length < sizeof(ulong))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }

    /// <summary>
    /// Converts a single-precision floating-point value (<see cref="float"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The single-precision floating-point value to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, float value)
    {
        if (destination.Length < sizeof(float))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }

    /// <summary>
    /// Converts a double-precision floating-point value (<see cref="double"/>) into a span of bytes.
    /// </summary>
    /// <param name="destination">The span to receive the bytes representing the converted value.</param>
    /// <param name="value">The double-precision floating-point value to convert.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryWriteBytes(Span<byte> destination, double value)
    {
        if (destination.Length < sizeof(double))
        {
            return false;
        }

        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
        return true;
    }
}
