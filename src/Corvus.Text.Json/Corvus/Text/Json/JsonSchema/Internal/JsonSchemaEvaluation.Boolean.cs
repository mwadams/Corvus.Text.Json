// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    public static readonly JsonSchemaMessageProvider IgnoredNotTypeBoolean = static (buffer, out written) => IgnoredNotType("boolean"u8, buffer, out written);
    private static readonly JsonSchemaMessageProvider ExpectedTypeBoolean = static (buffer, out written) => ExpectedType("boolean"u8, buffer, out written);

    /// <summary>
    /// Matches a JSON token type against the "boolean" type constraint.
    /// </summary>
    /// <param name="tokenType">The JSON token type to validate.</param>
    /// <param name="typeKeyword">The type keyword being evaluated.</param>
    /// <param name="context">The schema validation context.</param>
    /// <returns><see langword="true"/> if the token type is a boolean; otherwise, <see langword="false"/>.</returns>
    [CLSCompliant(false)]
    public static bool MatchTypeBoolean(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
    {
        if (tokenType != JsonTokenType.True && tokenType != JsonTokenType.False)
        {
            context.EvaluatedKeyword(false, ExpectedTypeBoolean, typeKeyword);
            return false;
        }
        else
        {
            context.EvaluatedKeyword(true, ExpectedTypeBoolean, typeKeyword);
        }

        return true;
    }
}
