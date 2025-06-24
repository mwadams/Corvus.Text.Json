// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Provides a fixed-size backing structure for storing simple numeric, null and boolean values.
    /// for <see cref="IJsonElement"/> creation.
    /// </summary>
    /// <remarks>
    /// This is typically used as a backing field in a <c>[MyJsonElementType].Builder.Source</c> struct.
    /// </remarks>
    public ref struct SimpleTypesBacking
    {
        public delegate void Writer<T>(T value, Span<byte> buffer, out int written);

        private FixedSizeSimpleTypesBuffer _buffer;
        private int _length;

        public static void Initialize<T>(ref SimpleTypesBacking backing, in T value, Writer<T> writer)
        {
            writer(value, backing._buffer.AsSpan(), out backing._length);
        }

        /// <summary>
        /// Gets the written value as a span
        /// </summary>
        /// <returns>The written value.</returns>
        public ReadOnlySpan<byte> Span()
        {
            return _buffer.AsSpan(0, _length);
        }

        private unsafe struct FixedSizeSimpleTypesBuffer
        {
            public fixed byte _buffer[JsonConstants.StackallocByteThreshold];

            public Span<byte> AsSpan(int start, int length)
            {
                Debug.Assert(start >= 0 && (start + length) <= JsonConstants.StackallocByteThreshold);
                fixed (byte* pBuffer = _buffer)
                {
                    return new Span<byte>(pBuffer + start, length);
                }
            }

            public Span<byte> AsSpan()
            {
                fixed (byte* pBuffer = _buffer)
                {
                    return new Span<byte>(pBuffer, JsonConstants.StackallocByteThreshold);
                }
            }
        }
    }
}
