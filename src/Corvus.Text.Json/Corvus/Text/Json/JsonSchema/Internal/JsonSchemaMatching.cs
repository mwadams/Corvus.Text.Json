// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Support for JSON Schema matching implementations.
    /// </summary>
    public static partial class JsonSchemaEvaluation
    {
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
        private static bool IgnoredNotType(ReadOnlySpan<byte> typeName, Span<byte> buffer, out int written)
        {
            if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_IgnoredNotType.AsSpan(), buffer, out written))
            {
                return false;
            }

            return AppendSingleQuotedValue(typeName, buffer, ref written);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ExpectedType(ReadOnlySpan<byte> typeName, Span<byte> buffer, out int written)
        {
            if (!JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_ExpectedType.AsSpan(), buffer, out written))
            {
                return false;
            }

            return AppendSingleQuotedValue(typeName, buffer, ref written);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool AppendSingleQuotedValue(ReadOnlySpan<byte> value, Span<byte> buffer, ref int written)
        {
            if (buffer.Length < written + value.Length + 4)
            {
                written = 0;
                return false;
            }

            buffer[written++] = (byte)' ';
            buffer[written++] = (byte)'\'';
            value.CopyTo(buffer);
            written += value.Length;
            buffer[written++] = (byte)'\'';
            return true;
        }
    }
}
