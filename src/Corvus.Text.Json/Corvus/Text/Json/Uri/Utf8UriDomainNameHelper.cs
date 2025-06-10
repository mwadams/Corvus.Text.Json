// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NET
using System.Buffers;
using System.Runtime.CompilerServices;
#endif

namespace Corvus.Text.Json.Internal
{
    // This does the a similar job to MatchIdnHostname but it doesn't punycode decode and validate the resulting address.
    internal class Utf8UriDomainNameHelper
    {
#if NET
        // Takes into account the additional legal domain name characters '-' and '_'
        // Note that '_' char is formally invalid but is historically in use, especially on corpnets
        private static readonly SearchValues<byte> s_validChars =
            SearchValues.Create("-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz."u8);

        // For IRI, we're accepting anything non-ascii (except 0x80-0x9F), so invert the condition to search for invalid ascii characters.
        private static readonly SearchValues<byte> s_iriInvalidChars = SearchValues.Create(
            [0x0000, 0x0001, 0x0002, 0x0003, 0x0004, 0x0005, 0x0006, 0x0007, 0x0008, 0x0009, 0x000A, 0x000B, 0x000C, 0x000D, 0x000E, 0x000F,
            0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015, 0x0016, 0x0017, 0x0018, 0x0019, 0x001A, 0x001B, 0x001C, 0x001D, 0x001E, 0x001F,
            (byte)' ', (byte)'!', (byte)'\\', (byte)'\"', (byte)'#', (byte)'$', (byte)'%', (byte)'&', (byte)'\'', (byte)'(', (byte)')', (byte)'*',
            (byte)'+', (byte)',', (byte)'/', (byte)':', (byte)';', (byte)'<', (byte)'=', (byte)'>', (byte)'?', (byte)'@', (byte)'[', (byte)']',
            (byte)'^', (byte)'`', (byte)'{', (byte)'|', (byte)'}', (byte)'~', 0x007F,
            0x0080, 0x0081, 0x0082, 0x0083, 0x0084, 0x0085, 0x0086, 0x0087, 0x0088, 0x0089, 0x008A, 0x008B, 0x008C, 0x008D, 0x008E, 0x008F,
            0x0090, 0x0091, 0x0092, 0x0093, 0x0094, 0x0095, 0x0096, 0x0097, 0x0098, 0x0099, 0x009A, 0x009B, 0x009C, 0x009D, 0x009E, 0x009F]);
#else
        // Takes into account the additional legal domain name characters '-' and '_'
        // Note that '_' char is formally invalid but is historically in use, especially on corpnets
        private static ReadOnlySpan<byte> s_validChars => "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz."u8;

        // For IRI, we're accepting anything non-ascii (except 0x80-0x9F), so invert the condition to search for invalid ascii characters.
        private static ReadOnlySpan<byte> s_iriInvalidChars =>
            [0x0000, 0x0001, 0x0002, 0x0003, 0x0004, 0x0005, 0x0006, 0x0007, 0x0008, 0x0009, 0x000A, 0x000B, 0x000C, 0x000D, 0x000E, 0x000F,
            0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015, 0x0016, 0x0017, 0x0018, 0x0019, 0x001A, 0x001B, 0x001C, 0x001D, 0x001E, 0x001F,
            (byte)' ', (byte)'!', (byte)'\\', (byte)'\"', (byte)'#', (byte)'$', (byte)'%', (byte)'&', (byte)'\'', (byte)'(', (byte)')', (byte)'*',
            (byte)'+', (byte)',', (byte)'/', (byte)':', (byte)';', (byte)'<', (byte)'=', (byte)'>', (byte)'?', (byte)'@', (byte)'[', (byte)']',
            (byte)'^', (byte)'`', (byte)'{', (byte)'|', (byte)'}', (byte)'~', 0x007F,
            0x0080, 0x0081, 0x0082, 0x0083, 0x0084, 0x0085, 0x0086, 0x0087, 0x0088, 0x0089, 0x008A, 0x008B, 0x008C, 0x008D, 0x008E, 0x008F,
            0x0090, 0x0091, 0x0092, 0x0093, 0x0094, 0x0095, 0x0096, 0x0097, 0x0098, 0x0099, 0x009A, 0x009B, 0x009C, 0x009D, 0x009E, 0x009F];
#endif
        public static bool IsValid(ReadOnlySpan<byte> hostname, bool iri, bool notImplicitFile, out int length)
        {
            int invalidCharOrDelimiterIndex = iri
                ? hostname.IndexOfAny(s_iriInvalidChars)
                : Utf8Uri.IndexOfAnyExcept(hostname, s_validChars);

            if (invalidCharOrDelimiterIndex >= 0)
            {
                byte c = hostname[invalidCharOrDelimiterIndex];

                if (c is (byte)'/' or (byte)'\\' || (notImplicitFile && (c is (byte)':' or (byte)'?' or (byte)'#')))
                {
                    hostname = hostname.Slice(0, invalidCharOrDelimiterIndex);
                }
                else
                {
                    length = 0;
                    return false;
                }
            }

            length = hostname.Length;

            if (length == 0)
            {
                return false;
            }

            //  Determines whether a string is a valid domain name label. In keeping
            //  with RFC 1123, section 2.1, the requirement that the first character
            //  of a label be alphabetic is dropped. Therefore, Domain names are
            //  formed as:
            //
            //      <label> -> <alphanum> [<alphanum> | <hyphen> | <underscore>] * 62

            // We already verified the content, now verify the lengths of individual labels
            while (true)
            {
                byte firstChar = hostname[0];
                if ((!iri || firstChar < 0xA0) && !Utf8Uri.IsAsciiLetterOrDigit(firstChar))
                {
                    return false;
                }

                int dotIndex = iri
                    ? IndexOfIriDot(hostname)
                    : hostname.IndexOf((byte)'.');

                int labelLength = dotIndex < 0 ? hostname.Length : dotIndex;

                if (iri)
                {
                    ReadOnlySpan<byte> label = hostname.Slice(0, labelLength);
                    if (!Ascii.IsValid(label))
                    {
                        // Account for the ACE prefix ("xn--")
                        labelLength += 4;

                        foreach (char c in label)
                        {
                            if (c > 0xFF)
                            {
                                // counts for two octets
                                labelLength++;
                            }
                        }
                    }
                }

                if (!IsInInclusiveRange((uint)labelLength, 1, 63))
                {
                    return false;
                }

                if (dotIndex < 0)
                {
                    // We validated the last label
                    return true;
                }

                hostname = hostname.Slice(dotIndex + 1);

                if (hostname.IsEmpty)
                {
                    // Hostname ended with a dot
                    return true;
                }
            }
        }

        private static int IndexOfIriDot(ReadOnlySpan<byte> hostname)
        {
            for (int i = 0; i < hostname.Length;)
            {
                if (hostname[i] == (byte)'.')
                {
                    return i;
                }

                if (Utf8Uri.IsAscii((char)hostname[i]))
                {
                    i++;
                    continue;
                }

                Rune.DecodeFromUtf8(hostname.Slice(i), out Rune result, out int bytesConsumed);
                if (Globalization.IdnMapping.IsDot((char)result.Value))
                {
                    return i;
                }

            }

            return -1;
        }

        private static bool IsInInclusiveRange(uint value, uint min, uint max)
                => (value - min) <= (max - min);
    }
}
