// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
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
            int length = Encoding.UTF8.GetMaxCharCount(value.Length);

#if NET
            char[]? charBuffer = null;
            Span<char> chars =
                length < JsonConstants.StackallocCharThreshold
                    ? stackalloc char[JsonConstants.StackallocCharThreshold]
                    : (charBuffer = ArrayPool<char>.Shared.Rent(length)).AsSpan();

            ReadOnlySpan<char> segment = chars.Slice(0, JsonReaderHelper.TranscodeHelper(value, chars));
#else
            string segment = JsonReaderHelper.TranscodeHelper(value);
#endif
            try
            {
                if (EmailPattern.IsMatch(segment))
                {
                    context.Matched(false, messageProvider: ExpectedEmail, schemaEvaluationPath: keyword);
                    return false;
                }

                context.Matched(true, schemaEvaluationPath: keyword);
                return true;
            }
            finally
            {
#if NET
                if (charBuffer is not null)
                {
                    chars.Clear();
                    ArrayPool<char>.Shared.Return(charBuffer);
                }
#endif
            }

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
            int length = Encoding.UTF8.GetMaxCharCount(value.Length);

            char[]? charBuffer = null;
            Span<char> chars =
                length < JsonConstants.StackallocCharThreshold
                    ? stackalloc char[JsonConstants.StackallocCharThreshold]
                    : (charBuffer = ArrayPool<char>.Shared.Rent(length)).AsSpan();

            try
            {

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
                if (chars.Length < newLength)
                {
                    // This is an unusual case, but we are going to have to reallocate the chars array to accommodate the punycode encoded
                    // domain

                    char[]? bytesToReturn = charBuffer;

                    charBuffer = ArrayPool<char>.Shared.Rent(newLength);
                    chars = charBuffer.AsSpan(0, newLength);
                    segment.Slice(0, atIndex + 1).CopyTo(chars);
                    punyCodeChars.Slice(0, written).CopyTo(chars.Slice(atIndex + 1));
                    segment = chars;
                    if (bytesToReturn is not null)
                    {
                        ArrayPool<char>.Shared.Return(bytesToReturn);
                    }
                }

#if NET
                return IdnEmailPattern.IsMatch(segment);
#else
                return IdnEmailPattern.IsMatch(segment.ToString());
#endif
            }
            finally
            {
                if (charBuffer is not null)
                {
                    chars.Clear();
                    ArrayPool<char>.Shared.Return(charBuffer);
                }
            }
        }

        private static readonly Regex EmailPattern = CreateEmailPattern();
        private static readonly Regex IdnEmailPattern = CreateIdnEmailPattern();

#if NET

        [GeneratedRegex("^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[ \\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-z0-9])?|\\[(((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|IPv6:(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])))\\])$", RegexOptions.Compiled)]
        private static partial Regex CreateEmailPattern();

        [GeneratedRegex("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.Compiled)]
        private static partial Regex CreateIdnEmailPattern();
#else
        private static Regex CreateEmailPattern() => new("^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[ \\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|IPv6:(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])))\\])$", RegexOptions.Compiled);
        private static Regex CreateIdnEmailPattern() => new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.Compiled);
#endif
    }
}
