// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    public static readonly JsonSchemaMessageProvider IgnoredNotTypeNull = static (buffer, out written) => IgnoredNotType("null"u8, buffer, out written);
    public static readonly JsonSchemaMessageProvider ExpectedTypeNull = static (buffer, out written) => ExpectedType("null"u8, buffer, out written);

    /// <summary>
    /// Matches a JSON token type against the "null" type constraint.
    /// </summary>
    /// <param name="tokenType">The JSON token type to validate.</param>
    /// <param name="typeKeyword">The type keyword being evaluated.</param>
    /// <param name="context">The schema validation context.</param>
    /// <returns><see langword="true"/> if the token type is null; otherwise, <see langword="false"/>.</returns>
    [CLSCompliant(false)]
    public static bool MatchTypeNull(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
    {
        if (tokenType != JsonTokenType.Null)
        {
            context.EvaluatedKeyword(false, ExpectedTypeNull, typeKeyword);
            return false;
        }
        else
        {
            context.EvaluatedKeyword(true, ExpectedTypeNull, typeKeyword);
        }

        return true;
    }
}
