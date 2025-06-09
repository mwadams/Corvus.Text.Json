// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Corvus.Globalization;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Support for JSON Schema matching implementations.
    /// </summary>
    public static partial class JsonSchemaMatching
    {
        public static readonly JsonSchemaMessageProvider IgnoredNotTypeString = static (buffer, out written) => IgnoredNotType("string"u8, buffer, out written);

        private static readonly JsonSchemaMessageProvider ExpectedTypeString = static (buffer, out written) => ExpectedType("string"u8, buffer, out written);

        private static readonly JsonSchemaMessageProvider ExpectedDate = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIso8601Date.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedDateTime = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIso8601OffsetDateTime.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedTime = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIso8601OffsetTime.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedDuration = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIso8601Duration.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedEmail = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedEmail.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedIdnEmail = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIdnEmail.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedHostname = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedHostname.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedIdnHostname = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIdnHostname.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedIPV4 = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIPV4.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedIPV6 = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedIPV6.AsSpan(), buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedUuid = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedUuid.AsSpan(), buffer, out written);

        [CLSCompliant(false)]
        public static bool MatchTypeString(JsonTokenType tokenType, JsonSchemaPathProvider typeKeyword, ref JsonSchemaContext context)
        {
            if (tokenType != JsonTokenType.String)
            {
                context.Matched(false, ExpectedTypeString, schemaEvaluationPath: typeKeyword);
                return false;
            }
            else
            {
                context.Matched(true, schemaEvaluationPath: typeKeyword);
            }

            return true;
        }

        [CLSCompliant(false)]
        public static bool MatchDate(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!JsonElementHelpers.TryParseLocalDate(value, out _))
            {
                context.Matched(false, messageProvider: ExpectedDate, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [CLSCompliant(false)]
        public static bool MatchDateTime(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!JsonElementHelpers.TryParseOffsetDateTime(value, out _))
            {
                context.Matched(false, messageProvider: ExpectedDateTime, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }


        [CLSCompliant(false)]
        public static bool MatchTime(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!JsonElementHelpers.TryParseOffsetTime(value, out _))
            {
                context.Matched(false, messageProvider: ExpectedTime, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [CLSCompliant(false)]
        public static bool MatchDuration(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!JsonElementHelpers.TryParsePeriod(value, out _))
            {
                context.Matched(false, messageProvider: ExpectedDuration, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        private static ReadOnlySpan<byte> AllowedLocalCharacters => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&'*+-/=?^_`{|}~"u8;



        [CLSCompliant(false)]
        public static bool MatchEmail(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchEmail(value))
            {
                context.Matched(false, messageProvider: ExpectedEmail, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }


        internal static bool MatchEmail(ReadOnlySpan<byte> value)
        {
            if (value.Length > 320 || value.Length < 3)
            {
                // The maximum length of an email address is 320 characters (RFC 5321).
                return false;
            }

            int atIndex = value.IndexOf((byte)'@');
            if (atIndex <= 0 || atIndex == value.Length - 1)
            {
                return false;
            }

            // Local part
            ReadOnlySpan<byte> segment = value.Slice(0, atIndex);

            if (!MatchEmailLocalPart(segment))
            {
                return false;
            }

            // Domain part
            segment = value.Slice(atIndex + 1);

            if (!MatchHostname(segment))
            {
                return false;
            }

            return true;

        }

        private static bool MatchEmailLocalPart(ReadOnlySpan<byte> segment)
        {
            if (segment.Length > 64)
            {
                return false;
            }

            // Skip an opening comment
            if (segment[0] == (byte)'(')
            {
                int closeBracket = segment.IndexOf((byte)')');
                if (closeBracket < 0)
                {
                    return false;
                }

                segment = segment.Slice(closeBracket + 1);

                if (segment.Length == 0)
                {
                    return false;
                }
            }

            int lastDot = -1;
            for (int i = 0; i < segment.Length; i++)
            {
                byte c = segment[i];
                if (c == (byte)'.')
                {
                    if (i == 0 || i == segment.Length - 1 || lastDot == i - 1)
                    {
                        // Dot at the start or end, or two dots in a row
                        return false;
                    }

                    lastDot = i;
                }
                else if (c == (byte)'(')
                {
                    // This is an end comment.
                    int closeBracket = segment.IndexOf((byte)')');
                    if (closeBracket < 0 || closeBracket != segment.Length - 1)
                    {
                        return false;
                    }

                    return true;
                }
                else if (AllowedLocalCharacters.IndexOf(c) < 0)
                {
                    // Invalid character in local part
                    return false;
                }
            }

            return true;
        }

        private static bool MatchEmailLocalPartUnicode(ReadOnlySpan<byte> segment)
        {
            if (segment.Length > 64)
            {
                return false;
            }

            // Skip an opening comment
            if (segment[0] == (byte)'(')
            {
                int closeBracket = segment.IndexOf((byte)')');
                if (closeBracket < 0)
                {
                    return false;
                }

                segment = segment.Slice(closeBracket + 1);

                if (segment.Length == 0)
                {
                    return false;
                }
            }

            int lastDot = -1;
            for (int i = 0; i < segment.Length; i++)
            {
                byte c = segment[i];
                if (c == (byte)'.')
                {
                    if (i == 0 || i == segment.Length - 1 || lastDot == i - 1)
                    {
                        // Dot at the start or end, or two dots in a row
                        return false;
                    }

                    lastDot = i;
                }
                else if (c == (byte)'(')
                {
                    // This is an end comment.
                    int closeBracket = segment.IndexOf((byte)')');
                    if (closeBracket < 0 || closeBracket != segment.Length - 1)
                    {
                        return false;
                    }

                    return true;
                }
                else if (AllowedLocalCharacters.IndexOf(c) < 0)
                {
                    // This could be a unicode character, so let's check
                    Rune.DecodeFromUtf8(segment.Slice(i), out Rune rune, out int bytesConsumed);
                    if(!Rune.IsLetterOrDigit(rune))
                    {
                        System.Globalization.UnicodeCategory category = Rune.GetUnicodeCategory(rune);
                        if (i == 0 ||
                            (category != System.Globalization.UnicodeCategory.SpacingCombiningMark &&
                             category != System.Globalization.UnicodeCategory.EnclosingMark &&
                             category != System.Globalization.UnicodeCategory.NonSpacingMark))
                        {
                            return false;
                        }
                    }

                    i += bytesConsumed - 1; // Adjust i to account for the bytes consumed by the rune
                }
            }

            return true;
        }


        [CLSCompliant(false)]
        public static bool MatchIdnEmail(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchIdnEmail(value))
            {
                context.Matched(false, messageProvider: ExpectedIdnEmail, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchIdnEmail(ReadOnlySpan<byte> value)
        {
            if (value.Length > 320 || value.Length < 3)
            {
                // The maximum length of an email address is 320 characters (RFC 5321).
                return false;
            }

            int atIndex = value.IndexOf((byte)'@');

            // Local part
            ReadOnlySpan<byte> segment = value.Slice(0, atIndex);

            if (!MatchEmailLocalPartUnicode(segment))
            {
                return false;
            }

            // Domain part
            segment = value.Slice(atIndex + 1);

            if (!MatchIdnHostname(segment))
            {
                return false;
            }

            return true;
        }

        [CLSCompliant(false)]
        public static bool MatchIdnHostname(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchIdnHostname(value))
            {
                context.Matched(false, messageProvider: ExpectedIdnHostname, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchIdnHostname(ReadOnlySpan<byte> value)
        {
            if (value.Length > 254)
            {
                return false;
            }

            Span<byte> decoded = stackalloc byte[256];

            if (!IdnMapping.Default.GetUnicode(value, decoded, out int written))
            {
                return false;
            }

            scoped ReadOnlySpan<byte> segment = decoded.Slice(0, written);

            return MatchDecodedHostname(segment);
        }

        [CLSCompliant(false)]
        public static bool MatchHostname(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchHostname(value))
            {
                context.Matched(false, messageProvider: ExpectedHostname, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchHostname(ReadOnlySpan<byte> value)
        {
            if (value.Length > 253)
            {
                return false;
            }

            Span<byte> decoded = stackalloc byte[256];
            int i = 0;
            int characterCount = 0;
            byte lastAscii = 0;
            bool decodePunicode = false;
            while (i < value.Length)
            {
                if (value[i] > 0x7F)
                {
                    // This is not ASCII, so give up
                    return false;
                }

                if (lastAscii == (byte)'-' && value[i] == (byte)'-')
                {
                    // Look for punicode signature

                    if (characterCount != 3 ||
                        !((value[i - 3] == (byte)'x' || value[i - 3] == (byte)'X') &&
                          (value[i - 2] == (byte)'n' || value[i - 2] == (byte)'N')))
                    {
                        // Disallow "--" for non-punicode signature
                        return false;
                    }

                    decodePunicode = true;
                    break;
                }

                lastAscii = value[i];

                if (lastAscii == (byte)'.')
                {
                    if (characterCount > 63)
                    {
                        return false;
                    }

                    characterCount = 0;
                    i++;
                    continue;
                }

                if (!char.IsLetterOrDigit((char)lastAscii) && !(characterCount != 0 && lastAscii == (byte)'-'))
                {
                    return false;
                }

                characterCount++;
                i++;
            }

            if (decodePunicode)
            {
                if (!IdnMapping.Default.GetUnicode(value, decoded, out int written))
                {
                    return false;
                }

                scoped ReadOnlySpan<byte> segment = decoded.Slice(0, written);

                return MatchDecodedHostname(segment);
            }

            if (characterCount > 63)
            {
                return false;
            }

            if (lastAscii == '-')
            {
                return false;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchDecodedHostname(ReadOnlySpan<byte> value)
        {
            bool wasLastDot = false;
            int i = 0;
            Rune previousRune = default;
            bool hasHiraganaKatakanaOrHan = false;
            bool hasKatakankaMiddleDot = false;
            bool hasArabicIndicDigits = false;
            bool hasExtendedArabicIndicDigits = false;

            while (i < value.Length)
            {
                byte byteValue = value[i];
                Rune.DecodeFromUtf8(value.Slice(i), out Rune rune, out int bytesConsumed);

                if (i == 0)
                {
                    System.Globalization.UnicodeCategory category = Rune.GetUnicodeCategory(rune);
                    if (category == System.Globalization.UnicodeCategory.SpacingCombiningMark ||
                        category == System.Globalization.UnicodeCategory.EnclosingMark ||
                        category == System.Globalization.UnicodeCategory.NonSpacingMark)
                    {
                        return false;
                    }
                }

                i += bytesConsumed;

                hasHiraganaKatakanaOrHan |= IsHiraganaKatakanaOrHanNotMiddleDot(rune.Value);
                hasArabicIndicDigits |= IsArabicIndicDigit(rune.Value);
                hasExtendedArabicIndicDigits |= IsExtendedArabicIndicDigit(rune.Value);

                if (wasLastDot)
                {
                    if (!Rune.IsLetter(rune))
                    {
                        return false;
                    }
                }

                if (DisallowedIdn.IndexOf(rune.Value) >= 0)
                {
                    // Disallowed characters in IDN
                    return false;
                }

                if (!Rune.IsLetterOrDigit(rune))
                {
                    if (byteValue == (byte)'.' || rune.Value == 0x3002 || rune.Value == 0xFF0E || rune.Value == 0xFF61)
                    {
                        if (hasKatakankaMiddleDot && !hasHiraganaKatakanaOrHan)
                        {
                            // If we have a Katakana middle dot, it must be have a Hiragana, Katakana or Han character.
                            return false;
                        }

                        if (hasArabicIndicDigits && hasExtendedArabicIndicDigits)
                        {
                            // You are not permitted both arabic indic AND extended arabic indic
                            return false;
                        }

                        hasHiraganaKatakanaOrHan = false;
                        hasKatakankaMiddleDot = false;
                        hasArabicIndicDigits = false;
                        hasExtendedArabicIndicDigits = false;
                        wasLastDot = true;
                        previousRune = rune;
                        continue;
                    }

                    hasKatakankaMiddleDot |= (rune.Value == 0x30FB);

                    // First we do all the items that are allowed at the first character

                    Rune lookahead = default;

                    if (rune.Value == 0x0375)
                    {
                        // If we have a Greek Keraia, it must be followed by a Greek character.

                        // If we are the last character, that's a fail
                        if (i >= value.Length)
                        {
                            return false;
                        }

                        Rune.DecodeFromUtf8(value.Slice(i), out lookahead, out _);
                        // If the next character is not Greek, that's a fail
                        if (!IsGreek(lookahead.Value))
                        {
                            return false;
                        }

                        wasLastDot = false;
                        previousRune = rune;
                        continue;
                    }

                    // Middle dot
                    if (rune.Value == 0x00B7)
                    {
                        if (previousRune.Value != 0x006C)
                        {
                            return false;
                        }

                        if (lookahead.Value == 0)
                        {
                            Rune.DecodeFromUtf8(value.Slice(i), out lookahead, out _);
                            if (lookahead.Value != 0x006C)
                            {
                                return false;
                            }
                        }
                    }

                    // These are all the tests which require preceding characters
                    if (byteValue == (byte)'-')
                    {
                        if (i == bytesConsumed || i >= value.Length)
                        {
                            return false;
                        }

                        wasLastDot = false;
                        previousRune = rune;
                        continue;
                    }

                    // ZERO WIDTH JOINER not preceded by Virama
                    if (rune.Value == 0x200D && !IsVirama(previousRune.Value))
                    {
                        return false;
                    }

                    // If we are Geresh or Gershayim, the previous rune must be Hebrew
                    if ((rune.Value == 0x05F3 || rune.Value == 0x05F4) && !IsHebrew(previousRune.Value))
                    {
                        return false;
                    }
                }

                wasLastDot = false;
                previousRune = rune;
            }

            if (hasKatakankaMiddleDot && !hasHiraganaKatakanaOrHan)
            {
                // If we have a Katakana middle dot, it must be have a Hiragana, Katakana or Han character.
                return false;
            }

            if (hasArabicIndicDigits && hasExtendedArabicIndicDigits)
            {
                // You are not permitted both Arabic Indic AND extended Arabic Indic
                return false;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsHiraganaKatakanaOrHanNotMiddleDot(int value)
        {
            // Don't allow middle dot
            if (value == 0x30FB)
            {
                return false;
            }

            return
                (value >= 0x30A0 && value <= 0x30FF) ||
                (value >= 0x3040 && value <= 0x309F) ||
                (value >= 0x3400 && value <= 0x4DB5) ||
                (value >= 0x4E00 && value <= 0x9FCB) ||
                (value >= 0xF900 && value <= 0xFA6A);
        }

        private static ReadOnlySpan<int> DisallowedIdn =>
            [0x0640, 0x07FA, 0x302E, 0x302F,
            0x3031, 0x3032, 0x3033, 0x3034,
            0x3035, 0x303B];

        private static ReadOnlySpan<int> ViramaTable =>
            [0x094D, 0x09CD, 0x0A4D, 0x0ACD,
            0x0B4D, 0x0BCD, 0x0C4D, 0x0CCD,
            0x0D3B, 0x0D3C, 0x0D4D, 0x0DCA,
            0x0E3A, 0x0EBA, 0x0F84, 0x1039,
            0x103A, 0x1714, 0x1715, 0x1734,
            0x17D2, 0x1A60, 0x1B44, 0x1BAA,
            0x1BAB, 0x1BF2, 0x1BF3, 0x2D7F,
            0xA806, 0xA82C, 0xA8C4, 0xA953,
            0xA9C0, 0xAAF6, 0xABED, 0x10A3F,
            0x11046, 0x11070, 0x1107F, 0x110B9,
            0x11133, 0x11134, 0x111C0, 0x11235,
            0x112EA, 0x1134D, 0x11442, 0x114C2,
            0x115BF, 0x1163F, 0x116B6, 0x1172B,
            0x11839, 0x1193D, 0x1193E, 0x119E0,
            0x11A34, 0x11A47, 0x11A99, 0x11C3F,
            0x11D44, 0x11D45, 0x11D97];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsHebrew(int value) => (value >= 0x0590 && value <= 0x05FF);
        private static bool IsGreek(int value) => (value >= 0x0370 && value <= 0x03FF) || (value >= 0x1F00 && value <= 0x1FFF);

        private static bool IsArabicIndicDigit(int value) => (value >= 0x0660 && value <= 0x0669);
        private static bool IsExtendedArabicIndicDigit(int value) => (value >= 0x06F0 && value <= 0x06F9);
        private static bool IsVirama(int value) => ViramaTable.IndexOf(value) >= 0;

        [CLSCompliant(false)]
        public static bool MatchIPV4(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchIPV4(value))
            {
                context.Matched(false, messageProvider: ExpectedIPV4, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchIPV4(ReadOnlySpan<byte> value)
        {
            if (value.Length > IPAddressParser.MaxIPv4StringLength)
            {
                return false;
            }

            return IPAddressParser.IsValidIPV4(value);
        }

        [CLSCompliant(false)]
        public static bool MatchIPV6(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchIPV6(value))
            {
                context.Matched(false, messageProvider: ExpectedIPV6, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchIPV6(ReadOnlySpan<byte> value)
        {

            if (value.Length > IPAddressParser.MaxIPv6StringLength)
            {
                return false;
            }

            return IPAddressParser.IsValidIPV6(value);
        }

        [CLSCompliant(false)]
        public static bool MatchUuid(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (!MatchUuid(value))
            {
                context.Matched(false, messageProvider: ExpectedUuid, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MatchUuid(ReadOnlySpan<byte> value)
        {
            return Utf8Parser.TryParse(value, out Guid _, out _);
        }
    }
}
