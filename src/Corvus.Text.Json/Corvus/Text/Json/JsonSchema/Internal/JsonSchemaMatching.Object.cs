// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    public static readonly JsonSchemaMessageProvider IgnoredNotTypeObject = static (buffer, out written) => IgnoredNotType("object"u8, buffer, out written);
    private static readonly JsonSchemaMessageProvider ExpectedTypeObject = static (buffer, out written) => ExpectedType("object"u8, buffer, out written);

    /// <summary>
    /// Matches a JSON token type against the "object" type constraint.
    /// </summary>
    /// <param name="tokenType">The JSON token type to validate.</param>
    /// <param name="typeKeyword">The type keyword being evaluated.</param>
    /// <param name="context">The schema validation context.</param>
    /// <returns><see langword="true"/> if the token type is a start object; otherwise, <see langword="false"/>.</returns>
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
            context.EvaluatedKeyword(true, ExpectedTypeObject, typeKeyword);
        }

        return true;
    }

    /// <summary>
    /// Creates a message indicating that a required property is not present.
    /// </summary>
    /// <param name="propertyName">The name of the missing required property.</param>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the message was successfully written; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RequiredPropertyNotPresent(ReadOnlySpan<byte> propertyName, Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_RequiredPropertyNotPresent.AsSpan(), buffer, out written))
        {
            return false;
        }

        return AppendSingleQuotedValue(propertyName, buffer, ref written);
    }

    /// <summary>
    /// Creates a message indicating that a required property is present.
    /// </summary>
    /// <param name="propertyName">The name of the required property that is present.</param>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the message was successfully written; otherwise, <see langword="false"/>.</returns>
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
