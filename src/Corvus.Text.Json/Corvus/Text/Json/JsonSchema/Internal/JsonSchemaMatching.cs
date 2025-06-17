// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryCopyPath(ReadOnlySpan<byte> readOnlySpan, Span<byte> buffer, out int written)
        {
            if (readOnlySpan.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer > buffer.Length)
            {
                written = 0;
                return false;
            }

            int index = readOnlySpan.IndexOfAny("~/"u8);
            if (index < 0)
            {
                readOnlySpan.CopyTo(buffer);
                written = readOnlySpan.Length;
            }
            else
            {
                written = 0;
                if (index > 0)
                {
                    readOnlySpan[..index].CopyTo(buffer);
                    written = index;
                }

                written = written + EncodePointer(readOnlySpan[index..], buffer[index..]);
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

        /// <summary>
        /// Encodes the ~ encoding in a pointer.
        /// </summary>
        /// <param name="unencodedFragment">The encoded fragment.</param>
        /// <param name="fragment">The span into which to write the result.</param>
        /// <returns>The length of the decoded fragment.</returns>
        private static int EncodePointer(ReadOnlySpan<byte> unencodedFragment, Span<byte> fragment)
        {
            int readIndex = 0;
            int writeIndex = 0;

            while (readIndex < unencodedFragment.Length)
            {
                if (unencodedFragment[readIndex] == (byte)'~')
                {
                    fragment[writeIndex] = (byte)'~';
                    fragment[writeIndex + 1] = (byte)'0';
                    readIndex += 1;
                    writeIndex += 2;
                }
                else if (unencodedFragment[readIndex] == '/')
                {
                    fragment[writeIndex] = (byte)'~';
                    fragment[writeIndex + 1] = (byte)'1';
                    readIndex += 1;
                    writeIndex += 2;
                }
                else
                {
                    fragment[writeIndex] = unencodedFragment[readIndex];
                    readIndex++;
                    writeIndex++;
                }
            }

            return writeIndex;
        }
    }
}
