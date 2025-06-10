// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;

namespace Corvus.Text.Json.Internal
{
    internal static class Utf8UriUncNameHelper
    {
        public const int MaximumInternetNameLength = 256;

        //
        // IsValid
        //
        //
        //   ATTN: This class has been re-designed as to conform to XP+ UNC hostname format
        //         It is now similar to DNS name but can contain Unicode characters as well
        //         This class will be removed and replaced by IDN specification later,
        //         but for now we violate URI RFC cause we never escape Unicode characters on the wire
        //         For the same reason we never unescape UNC host names since we never accept
        //         them in escaped format.
        //
        //
        //      Valid UNC server name chars:
        //          a Unicode Letter    (not allowed as the only in a segment)
        //          a Latin-1 digit
        //          '-'    45 0x2D
        //          '.'    46 0x2E    (only as a host domain delimiter)
        //          '_'    95 0x5F
        //
        //
        // Assumption is the caller will check on the resulting name length
        // Remarks:  MUST NOT be used unless all input indexes are verified and trusted.
        public static unsafe bool IsValid(byte* name, int start, ref int returnedEnd, bool notImplicitFile)
        {
            int end = returnedEnd;

            if (start == end)
                return false;
            //
            // First segment could consist of only '_' or '-' but it cannot be all digits or empty
            //
            bool validShortName = false;
            int i = start;
            for (; i < end; ++i)
            {
                if (name[i] == (byte)'/' || name[i] == (byte)'\\' || (notImplicitFile && (name[i] == (byte)':' || name[i] == (byte)'?' || name[i] == (byte)'#')))
                {
                    end = i;
                    break;
                }
                else if (name[i] == (byte)'.')
                {
                    ++i;
                    break;
                }

                if (Rune.DecodeFromUtf8(new ReadOnlySpan<byte>(name + i, end - i), out Rune currentRune, out int bytesConsumed) != OperationStatus.Done)
                {
                    return false;
                }

                if (Rune.IsLetter(currentRune) || name[i] == (byte)'-' || name[i] == (byte)'_')
                {
                    validShortName = true;
                }
                else if (!Utf8Uri.IsAsciiDigit(name[i]))
                {
                    return false;
                }

                // Skip over the multibyte element
                i += bytesConsumed - 1;
            }

            if (!validShortName)
                return false;

            //
            // Subsequent segments must start with a letter or a digit
            //

            for (; i < end; ++i)
            {
                if (Rune.DecodeFromUtf8(new ReadOnlySpan<byte>(name + i, end - i), out Rune currentRune, out int bytesConsumed) != OperationStatus.Done)
                {
                    return false;
                }

                if (name[i] == (byte)'/' || name[i] == (byte)'\\' || (notImplicitFile && (name[i] == (byte)':' || name[i] == (byte)'?' || name[i] == (byte)'#')))
                {
                    end = i;
                    break;
                }
                else if (name[i] == (byte)'.')
                {
                    if (!validShortName || ((i - 1) >= start && name[i - 1] == (byte)'.'))
                        return false;

                    validShortName = false;
                }
                else if (name[i] == (byte)'-' || name[i] == (byte)'_')
                {
                    if (!validShortName)
                        return false;
                }
                else if (Rune.IsLetter(currentRune) || Utf8Uri.IsAsciiDigit(name[i]))
                {
                    if (!validShortName)
                        validShortName = true;
                }
                else
                    return false;
            }

            // last segment can end with the dot
            if (((i - 1) >= start && name[i - 1] == (byte)'.'))
                validShortName = true;

            if (!validShortName)
                return false;

            //  caller must check for (end - start <= MaximumInternetNameLength)

            returnedEnd = end;
            return true;
        }
    }
}
