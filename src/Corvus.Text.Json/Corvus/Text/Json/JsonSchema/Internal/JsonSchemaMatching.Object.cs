// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Support for JSON Schema matching implementations.
    /// </summary>
    public static partial class JsonSchemaEvaluation
    {
        public static readonly JsonSchemaMessageProvider IgnoredNotTypeObject = static (buffer, out written) => IgnoredNotType("object"u8, buffer, out written);
        private static readonly JsonSchemaMessageProvider ExpectedTypeObject = static (buffer, out written) => ExpectedType("object"u8, buffer, out written);

        [CLSCompliant(false)]
        public static bool MatchTypeObject(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
        {
            if (tokenType != JsonTokenType.StartObject)
            {
                context.EvaluatedKeyword(false, ExpectedTypeObject, typeKeyword);
                return false;
            }
            else
            {
                context.EvaluatedKeyword(true, null, typeKeyword);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RequiredPropertyNotPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, out int written)
        {
            if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_RequiredPropertyNotPresent.AsSpan(), buffer, out written))
            {
                return false;
            }

            return AppendSingleQuotedValue(propertyName, buffer, ref written);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RequiredPropertyPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, out int written)
        {
            if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_RequiredPropertyPresent.AsSpan(), buffer, out written))
            {
                return false;
            }

            return AppendSingleQuotedValue(propertyName, buffer, ref written);
        }
    }
}
