// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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

        [CLSCompliant(false)]
        public static bool MatchEmail(ReadOnlySpan<byte> value, JsonSchemaPathProvider keyword, ref JsonSchemaContext context)
        {
            if (value.Length > 320 || value.Length < 3)
            {
                // The maximum length of an email address is 320 characters (RFC 5321).
                return false;
            }


#if NET
            Span<char> chars = stackalloc char[JsonConstants.StackallocNonRecursiveCharThreshold];
            ReadOnlySpan<char> segment = chars.Slice(0, JsonReaderHelper.TranscodeHelper(value, chars));
#else
            string segment = JsonReaderHelper.TranscodeHelper(value);
#endif
            if (!EmailPattern.IsMatch(segment))
            {
                context.Matched(false, messageProvider: ExpectedEmail, schemaEvaluationPath: keyword);
                return false;
            }

            context.Matched(true, schemaEvaluationPath: keyword);
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

            int length = Encoding.UTF8.GetMaxCharCount(value.Length);

            Span<char> chars = stackalloc char[JsonConstants.StackallocNonRecursiveCharThreshold];
            ReadOnlySpan<char> segment = chars.Slice(0, JsonReaderHelper.TranscodeHelper(value, chars));

            int atIndex = segment.IndexOf('@');

            if (atIndex < 0)
            {
                return false;
            }

            // Now we need to punycode encode the Domain part of the email address, which is the part after the '@' character.
            // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
            Span<char> punyCodeChars = stackalloc char[254];

            if (!IdnMapping.Default.GetAscii(segment.Slice(atIndex + 1), punyCodeChars, out int written))
            {
                return false;
            }


            int newLength = atIndex + 1 + written;
            System.Diagnostics.Debug.Assert(chars.Length > newLength);
            punyCodeChars.Slice(0, written).CopyTo(chars.Slice(atIndex + 1));
            segment = chars.Slice(0, newLength);

#if NET
            return IdnEmailPattern.IsMatch(segment);
#else
            return IdnEmailPattern.IsMatch(segment.ToString());
#endif
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
            int length = Encoding.UTF8.GetMaxCharCount(value.Length);

            if (length > 254)
            {
                return false;
            }

            // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
            // We pick 256 as it is a likely rentable buffer size
            Span<char> chars = stackalloc char[256];

            ReadOnlySpan<char> segment = chars.Slice(0, JsonReaderHelper.TranscodeHelper(value, chars));

            if (segment.StartsWith("xn--", StringComparison.OrdinalIgnoreCase))
            {
                // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
                // But it might expand with encoding
                Span<char> decodedChars = stackalloc char[256];

                if (!IdnMapping.Default.GetUnicode(segment, decodedChars, out int written))
                {
                    return false;
                }

                segment = decodedChars.Slice(0, written);
            }
            else
            {
                // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
                // But it might expand with encoding
                Span<char> decodedChars = stackalloc char[256];

                // We are only testing that we can decode to ASCII, not using the result
                if (!IdnMapping.Default.GetAscii(segment, decodedChars, out _))
                {
                    return false;
                }
            }

#if NET
            return !InvalidIdnHostNamePattern.IsMatch(segment);
#else
            return !InvalidIdnHostNamePattern.IsMatch(segment.ToString());
#endif
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
            int length = Encoding.UTF8.GetMaxCharCount(value.Length);

            if (length > 254)
            {
                return false;
            }

            // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
            Span<char> chars = stackalloc char[256];

            ReadOnlySpan<char> segment = chars.Slice(0, JsonReaderHelper.TranscodeHelper(value, chars));

            if (segment.StartsWith("xn--", StringComparison.OrdinalIgnoreCase))
            {
                // The resulting value is not permitted to be more than 254 characters (RFC 1034/1035 on DNS).
                Span<char> decodedChars = stackalloc char[256];

                if (!IdnMapping.Default.GetUnicode(segment, decodedChars, out int written))
                {
                    return false;
                }

                segment = decodedChars.Slice(0, written);
            }

#if NET
            return HostnamePattern.IsMatch(segment);
#else
            return HostnamePattern.IsMatch(segment.ToString());
#endif
        }

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

        private static readonly Regex EmailPattern = CreateEmailPattern();
        private static readonly Regex IdnEmailPattern = CreateIdnEmailPattern();
        private static readonly Regex HostnamePattern = CreateHostnamePattern();
        private static readonly Regex InvalidIdnHostNamePattern = CreateInvalidIdnHostNamePattern();


#if NET

        [GeneratedRegex("^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[ \\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-z0-9])?|\\[(((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|IPv6:(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])))\\])$", RegexOptions.Compiled)]
        private static partial Regex CreateEmailPattern();

        [GeneratedRegex("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.Compiled)]
        private static partial Regex CreateIdnEmailPattern();

        [GeneratedRegex("^(?=.{1,255}$)((?!_)\\w)((((?!_)\\w)|\\b-){0,61}((?!_)\\w))?(\\.((?!_)\\w)((((?!_)\\w)|\\b-){0,61}((?!_)\\w))?)*\\.?$", RegexOptions.Compiled)]
        private static partial Regex CreateHostnamePattern();

        [GeneratedRegex("(^[\\p{Mn}\\p{Mc}\\p{Me}\\u302E\\u00b7])|.*\\u302E.*|.*[^l]\\u00b7.*|.*\\u00b7[^l].*|.*\\u00b7$|\\u0374$|\\u0375$|\\u0374[^\\p{IsGreekandCoptic}]|\\u0375[^\\p{IsGreekandCoptic}]|^\\u05F3|[^\\p{IsHebrew}]\\u05f3|^\\u05f4|[^\\p{IsHebrew}]\\u05f4|[\\u0660-\\u0669][\\u06F0-\\u06F9]|[\\u06F0-\\u06F9][\\u0660-\\u0669]|^\\u200D|[^\\uA953\\u094d\\u0acd\\u0c4d\\u0d3b\\u09cd\\u0a4d\\u0b4d\\u0bcd\\u0ccd\\u0d4d\\u1039\\u0d3c\\u0eba\\ua8f3\\ua8f4]\\u200D|^\\u30fb$|[^\\p{IsHiragana}\\p{IsKatakana}\\p{IsCJKUnifiedIdeographs}]\\u30fb|\\u30fb[^\\p{IsHiragana}\\p{IsKatakana}\\p{IsCJKUnifiedIdeographs}]|[\\u0640\\u07fa\\u3031\\u3032\\u3033\\u3034\\u3035\\u302e\\u302f\\u303b]|..--", RegexOptions.Compiled)]
        private static partial Regex CreateInvalidIdnHostNamePattern();
#else
        private static Regex CreateEmailPattern() => new("^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[ \\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|IPv6:(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])))\\])$", RegexOptions.Compiled);
        private static Regex CreateIdnEmailPattern() => new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.Compiled);
        private static Regex CreateHostnamePattern() => new("^(?=.{1,255}$)((?!_)\\w)((((?!_)\\w)|\\b-){0,61}((?!_)\\w))?(\\.((?!_)\\w)((((?!_)\\w)|\\b-){0,61}((?!_)\\w))?)*\\.?$", RegexOptions.Compiled);
        private static Regex CreateInvalidIdnHostNamePattern() => new("(^[\\p{Mn}\\p{Mc}\\p{Me}\\u302E\\u00b7])|.*\\u302E.*|.*[^l]\\u00b7.*|.*\\u00b7[^l].*|.*\\u00b7$|\\u0374$|\\u0375$|\\u0374[^\\p{IsGreekandCoptic}]|\\u0375[^\\p{IsGreekandCoptic}]|^\\u05F3|[^\\p{IsHebrew}]\\u05f3|^\\u05f4|[^\\p{IsHebrew}]\\u05f4|[\\u0660-\\u0669][\\u06F0-\\u06F9]|[\\u06F0-\\u06F9][\\u0660-\\u0669]|^\\u200D|[^\\uA953\\u094d\\u0acd\\u0c4d\\u0d3b\\u09cd\\u0a4d\\u0b4d\\u0bcd\\u0ccd\\u0d4d\\u1039\\u0d3c\\u0eba\\ua8f3\\ua8f4]\\u200D|^\\u30fb$|[^\\p{IsHiragana}\\p{IsKatakana}\\p{IsCJKUnifiedIdeographs}]\\u30fb|\\u30fb[^\\p{IsHiragana}\\p{IsKatakana}\\p{IsCJKUnifiedIdeographs}]|[\\u0640\\u07fa\\u3031\\u3032\\u3033\\u3034\\u3035\\u302e\\u302f\\u303b]|..--", RegexOptions.Compiled);
#endif
    }
}
