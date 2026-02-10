// Licensed to the .NET Foundation unde7r one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    /// <summary>
    /// Creates a schema location for an indexed keyword by appending the index to the base location.
    /// </summary>
    /// <param name="keywordSchemaLocation">The base schema location for the keyword.</param>
    /// <param name="index">The index to append to the location.</param>
    /// <param name="buffer">The buffer to write the resulting location to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</returns>
    public static bool SchemaLocationForIndexedKeyword(ReadOnlySpan<byte> keywordSchemaLocation, int index, Span<byte> buffer, out int written)
    {
        if (buffer.Length < keywordSchemaLocation.Length)
        {
            written = 0;
            return false;
        }

        TryCopyPath(keywordSchemaLocation, buffer, out written);

        if (buffer[written - 1] != (byte)'/')
        {
            if (buffer.Length <= written)
            {
                written = 0;
                return false;
            }

            buffer[written++] = (byte)'/';
        }

        if (!Utf8Formatter.TryFormat(index, buffer[written..], out int bytesWritten))
        {
            written = 0;
            return false;
        }

        written += bytesWritten;
        return true;
    }

    /// <summary>
    /// Tries to copy a message to the specified buffer.
    /// </summary>
    /// <param name="readOnlySpan">The message to copy.</param>
    /// <param name="buffer">The buffer to copy the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the copy succeeded; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryCopyMessage(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, out int written)
    {
        if (readOnlySpan.Length > buffer.Length)
        {
            written = 0;
            return false;
        }

        readOnlySpan.CopyTo(buffer);
        written = readOnlySpan.Length;
        return true;
    }

    /// <summary>
    /// Tries to copy the path to the output buffer.
    /// </summary>
    /// <remarks>
    /// The path must be a fully canonical URI.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryCopyPath(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, out int written)
    {
        Debug.Assert(Utf8Uri.Validate(readOnlySpan, Utf8UriKind.RelativeOrAbsolute, requireAbsolute: false, allowIri: true, allowUNCPath: false));

        if (readOnlySpan.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer > buffer.Length)
        {
            written = 0;
            return false;
        }

        readOnlySpan.CopyTo(buffer);
        written = readOnlySpan.Length;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendSingleQuotedValue(ReadOnlySpan<byte> value, Span<byte> buffer, ref int written)
    {
        if (value.Length == 0)
        {
            return true;
        }

        if (buffer.Length < written + value.Length + 4)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)' ';
        buffer[written++] = (byte)'\'';
        value.CopyTo(buffer[written..]);
        written += value.Length;
        buffer[written++] = (byte)'\'';
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendSingleQuotedValue(string value, Span<byte> buffer, ref int written)
    {
        if (value.Length == 0)
        {
            return true;
        }

        if (buffer.Length < written + value.Length + 4)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)' ';
        buffer[written++] = (byte)'\'';
        int writtenBytes = JsonReaderHelper.TranscodeHelper(value.AsSpan(), buffer.Slice(written));
        if (writtenBytes == 0)
        {
            return false;
        }

        written += writtenBytes;
        buffer[written++] = (byte)'\'';
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendValueAndExponent(ulong value, int exponent, Span<byte> buffer, ref int written)
    {
        if (buffer.Length < written + 3)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)' ';
        buffer[written++] = (byte)'\'';

        if (!Utf8Formatter.TryFormat(value, buffer[written..], out int bytesWritten))
        {
            written = 0;
            return false;
        }    

        written += bytesWritten;

        if (buffer.Length < written + 3)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)'E';

        if (!Utf8Formatter.TryFormat(exponent, buffer[written..], out bytesWritten))
        {
            written = 0;
            return false;
        }

        written += bytesWritten;

        if (buffer.Length < written + 1)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)'\'';
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendValueAndExponent(BigInteger value, int exponent, Span<byte> buffer, ref int written)
    {
        if (buffer.Length < written + 3)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)' ';
        buffer[written++] = (byte)'\'';

        if (!value.TryFormat(buffer[written..], out int bytesWritten))
        {
            written = 0;
            return false;
        }

        written += bytesWritten;

        if (buffer.Length < written + 3)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)'E';

        if (!Utf8Formatter.TryFormat(exponent, buffer[written..], out bytesWritten))
        {
            written = 0;
            return false;
        }

        written += bytesWritten;

        if (buffer.Length < written + 1)
        {
            written = 0;
            return false;
        }

        buffer[written++] = (byte)'\'';
        return true;
    }

    /// <summary>
    /// Tries to write a message indicating the expected type for a value.
    /// </summary>
    /// <param name="typeName">The name of the expected type.</param>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ExpectedType(ReadOnlySpan<byte> typeName, Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedType.AsSpan(), buffer, out written))
        {
            return false;
        }

        return AppendSingleQuotedValue(typeName, buffer, ref written);
    }

    /// <summary>
    /// Tries to write a message indicating the expected type for a value.
    /// </summary>
    /// <param name="divisor">The integral part of the divisor.</param>
    /// <param name="divisor">The exponent of the divisor.</param>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [CLSCompliant(false)]
    public static bool ExpectedMultipleOfDivisor(string divisor, Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedMultipleOf.AsSpan(), buffer, out written))
        {
            return false;
        }

        return AppendSingleQuotedValue(divisor, buffer, ref written);
    }

    /// <summary>
    /// Tries to write a message indicating that the format was not recognized.
    /// </summary>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IgnoredUnrecognizedFormat(Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_IgnoredUnrecognizedFormat.AsSpan(), buffer, out written))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Tries to write a message indicating that the format was not asserted.
    /// </summary>
    /// <param name="buffer">The buffer to write the message to.</param>
    /// <param name="written">The number of bytes written to the buffer.</param>
    /// <returns><see langword="true"/> if the operation succeeded; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IgnoredFormatNotAsserted(Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_IgnoredFormatNotAsserted.AsSpan(), buffer, out written))
        {
            return false;
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IgnoredNotType(ReadOnlySpan<byte> typeName, Span<byte> buffer, out int written)
    {
        if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_IgnoredNotType.AsSpan(), buffer, out written))
        {
            return false;
        }

        return AppendSingleQuotedValue(typeName, buffer, ref written);
    }
}
