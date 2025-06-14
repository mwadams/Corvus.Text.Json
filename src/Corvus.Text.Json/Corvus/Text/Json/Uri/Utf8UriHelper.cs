// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    internal static class Utf8UriHelper
    {
#if NET
        // true for all ASCII letters and digits, as well as the RFC3986 unreserved marks '-', '_', '.', and '~'
        public static readonly SearchValues<char> Unreserved =
            SearchValues.Create("-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz~");
        public static readonly SearchValues<byte> UnreservedBytes =
            SearchValues.Create("-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz~"u8);
#else
        // true for all ASCII letters and digits, as well as the RFC3986 unreserved marks '-', '_', '.', and '~'
        public static ReadOnlySpan<char> Unreserved => "-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz~";
        public static ReadOnlySpan<byte> UnreservedBytes => "-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz~"u8;
#endif
        internal static bool IsLWS(byte b)
        {
            return (b <= (byte)' ') && (b == (byte)' ' || b == (byte)'\n' || b == (byte)'\r' || b == (byte)'\t');
        }

        internal static string AsciiSchemeToLowerInvariantString(ReadOnlySpan<byte> asciiSpan)
        {
            Debug.Assert(asciiSpan.Length < Utf8Uri.c_MaxUriSchemeName);

            Span<char> buffer = stackalloc char[asciiSpan.Length];
            Span<char> buffer2 = stackalloc char[asciiSpan.Length];
            int charsWritten = JsonReaderHelper.TranscodeHelper(asciiSpan, buffer);
            Debug.Assert(charsWritten == buffer.Length);
            charsWritten = buffer.ToLowerInvariant(buffer2);
            Debug.Assert(charsWritten == buffer2.Length);
            return buffer2.ToString();
        }

        /// <summary>
        /// Converts 2 hex chars to a byte (returned in a char), e.g, "0a" becomes (char)0x0A.
        /// <para>If either char is not hex, returns <see cref="Uri.c_DummyChar"/>.</para>
        /// </summary>
        internal static char DecodeHexChars(int first, int second)
        {
            int a = HexConverter.FromChar(first);
            int b = HexConverter.FromChar(second);

            if ((a | b) == 0xFF)
            {
                // either a or b is 0xFF (invalid)
                return Utf8Uri.c_DummyChar;
            }

            return (char)((a << 4) | b);
        }

    }
}
