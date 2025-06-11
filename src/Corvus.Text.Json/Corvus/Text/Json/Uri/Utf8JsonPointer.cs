// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    internal static class Utf8JsonPointer
    {
        public static bool Validate(ReadOnlySpan<byte> span)
        {
            int i = 0;
            int length = span.Length;

            // An empty string is a valid JSON pointer (root)
            if (length == 0)
            {
                return true;
            }

            while (i < length)
            {
                // Each reference-token must be prefixed by '/'
                if (span[i] != (byte)'/')
                {
                    return false;
                }

                i++;

                // reference-token: *( unescaped / escaped )
                while (i < length && span[i] != (byte)'/')
                {
                    if (span[i] == (byte)'~')
                    {
                        // escaped: "~" ("0" / "1")
                        if (i + 1 >= length)
                        {
                            return false;
                        }
                        byte next = span[i + 1];
                        if (next != (byte)'0' && next != (byte)'1')
                        {
                            return false;
                        }

                        i += 2;
                    }
                    else
                    {
                        // unescaped: %x00-2E / %x30-7D / %x7F-10FFFF
                        byte b = span[i];
                        if ((b >= 0x00 && b <= 0x2E) ||
                            (b >= 0x30 && b <= 0x7D) ||
                            (b == 0x7F))
                        {
                            i++;
                        }
                        else if (b >= 0x80)
                        {
                            if (Rune.DecodeFromUtf8(span.Slice(i), out _, out int runeLen) != System.Buffers.OperationStatus.Done)
                            {
                                return false;
                            }

                            if (runeLen == 0 || i + runeLen > length)
                            {
                                return false;
                            }

                            i += runeLen;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
