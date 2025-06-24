// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Provides a fixed-size, rented backing structure for storing longer string values that
    /// will not fit in a <see cref="SimpleTypesBacking"/>.
    /// </summary>
    /// <remarks>
    /// This is typically used as a backing field in a <c>[MyJsonElementType].Builder.Source</c> struct.
    /// </remarks>
    public ref struct RentedBacking
#if NET
        : IDisposable
#endif
    {
        public delegate void Writer<T>(T value, Span<byte> buffer, out int written);

        private byte[] _buffer;
        private int _length;

        /// <summary>
        /// Initializes an instance of the rented backing.
        /// </summary>
        public static void Initialize<T>(ref RentedBacking backing, int minimumLength, in T value, Writer<T> writer)
        {
            backing._buffer = ArrayPool<byte>.Shared.Rent(minimumLength);
            writer(value, backing._buffer.AsSpan(), out backing._length);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer);
                _buffer = null!;
                _length = 0;
            }
        }

        /// <summary>
        /// Gets the written value as a span
        /// </summary>
        /// <returns>The written value.</returns>
        public ReadOnlySpan<byte> Span()
        {
            if(_buffer == null)
            {
                throw new ObjectDisposedException(nameof(RentedBacking));
            }

            return _buffer.AsSpan(0, _length);
        }
    }
}
