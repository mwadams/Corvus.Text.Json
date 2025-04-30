// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Threading;

namespace Corvus.Text.Json
{
    /// <summary>
    /// Represents a raw UTF-8 JSON string.
    /// </summary>
    /// <remarks>
    /// This may use a rented buffer to back the string, so it is disposable.
    /// </remarks>
    public ref struct RawUtf8JsonString
#if NET
        : IDisposable
#endif
    {
        ReadOnlyMemory<byte> _utf8Bytes;
        byte[]? _extraRentedArrayPoolBytes;

        public readonly ReadOnlyMemory<byte> Memory => _utf8Bytes;
        public readonly ReadOnlySpan<byte> Span => _utf8Bytes.Span;

        public RawUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[]? extraRentedArrayPoolBytes = null)
        {
            _utf8Bytes = utf8Bytes;
            _extraRentedArrayPoolBytes = extraRentedArrayPoolBytes;
        }

        public void Dispose()
        {
            if (_extraRentedArrayPoolBytes != null)
            {
                byte[]? extraRentedBytes = Interlocked.Exchange<byte[]?>(ref _extraRentedArrayPoolBytes, null);

                if (extraRentedBytes != null)
                {
                    // When "extra rented bytes exist" it contains the document,
                    // and thus needs to be cleared before being returned.
                    extraRentedBytes.AsSpan(0, _utf8Bytes.Length).Clear();
                    ArrayPool<byte>.Shared.Return(extraRentedBytes);
                }
            }
        }
    }
}
