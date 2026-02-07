// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    /// <summary>
    /// Message provider for ignored "not array type" validation messages.
    /// </summary>
    public static readonly JsonSchemaMessageProvider IgnoredNotTypeArray = static (buffer, out written) => IgnoredNotType("array"u8, buffer, out written);

    /// <summary>
    /// Provides a path provider for array item indices in JSON schema validation.
    /// </summary>
    public static readonly JsonSchemaPathProvider<int> ItemIndex = static (index, buffer, out written) => AppendIndex(index, buffer, out written);


    /// <summary>
    /// Message provider for expected "array type" validation messages.
    /// </summary>
    public static readonly JsonSchemaMessageProvider ExpectedTypeArray = static (buffer, out written) => ExpectedType("array"u8, buffer, out written);

    /// <summary>
    /// Matches a JSON token type against the "array" type constraint.
    /// </summary>
    /// <param name="tokenType">The JSON token type to validate.</param>
    /// <param name="typeKeyword">The type keyword being evaluated.</param>
    /// <param name="context">The schema validation context.</param>
    /// <returns><see langword="true"/> if the token type is a start array; otherwise, <see langword="false"/>.</returns>
    [CLSCompliant(false)]
    public static bool MatchTypeArray(JsonTokenType tokenType, ReadOnlySpan<byte> typeKeyword, ref JsonSchemaContext context)
    {
        if (tokenType != JsonTokenType.StartArray)
        {
            context.EvaluatedKeyword(false, ExpectedTypeArray, typeKeyword);
            return false;
        }
        else
        {
            context.EvaluatedKeyword(true, ExpectedTypeArray, typeKeyword);
        }

        return true;
    }

    /// <summary>
    /// Writes the schema location for an item at a specific index in an array.
    /// </summary>
    /// <param name="arraySchemaLocation">The base schema location for the array.</param>
    /// <param name="itemIndex">The index of the item within the array.</param>
    /// <param name="buffer">The buffer to write the schema location to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the schema location was successfully written; otherwise, <see langword="false"/>.</returns>
    public static bool SchemaLocationForItemIndex(ReadOnlySpan<byte> arraySchemaLocation, int itemIndex, Span<byte> buffer, out int written)
    {
        if (buffer.Length < arraySchemaLocation.Length)
        {
            written = 0;
            return false;
        }

        arraySchemaLocation.CopyTo(buffer);
        written = arraySchemaLocation.Length;

        if (buffer[written - 1] != (byte)'/')
        {
            if (buffer.Length <= written)
            {
                written = 0;
                return false;
            }

            buffer[written++] = (byte)'/';
        }

        if (!Utf8Formatter.TryFormat(itemIndex, buffer[written..], out int bytesWritten))
        {
            written = 0;
            return false;
        }

        written += bytesWritten;
        return true;
    }

    private static bool AppendIndex(int index, Span<byte> buffer, out int written)
    {
        if (buffer.Length < 2)
        {
            written = 0;
            return false;
        }

        if (!Utf8Formatter.TryFormat(index, buffer, out int bytesWritten))
        {
            written = 0;
            return false;
        }

        written = bytesWritten;
        return true;
    }
}
