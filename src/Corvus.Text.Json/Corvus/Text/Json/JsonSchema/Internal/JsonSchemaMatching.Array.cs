// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Support for JSON Schema matching implementations.
    /// </summary>
    public static partial class JsonSchemaEvaluation
    {
        public static readonly JsonSchemaPathProvider<int> ItemIndex = static (index, buffer, out written) => AppendIndex(index, buffer, out written);

        private static bool AppendIndex(int index, Span<byte> buffer, out int written)
        {
            if (buffer.Length < 2)
            {
                written = 0;
                return false;
            }

            
            buffer[0] = (byte)'/';
            if (!Utf8Formatter.TryFormat(index, buffer[1..], out int bytesWritten))
            {
                written = 0;
                return false;
            }

            written = bytesWritten + 1;
            return true;
        }

        public static readonly JsonSchemaMessageProvider IgnoredNotTypeArray = static (buffer, out written) => IgnoredNotType("array"u8, buffer, out written);

        private static readonly JsonSchemaMessageProvider ExpectedTypeArray = static (buffer, out written) => ExpectedType("array"u8, buffer, out written);

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
                context.EvaluatedKeyword(true, null, typeKeyword);
            }

            return true;
        }

        /// <summary>
        /// Write the schema location for an item index.
        /// </summary>
        /// <param name="arraySchemaLocation"></param>
        /// <param name="itemIndex"></param>
        /// <param name="buffer"></param>
        /// <param name="written"></param>
        /// <returns></returns>
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
    }
}
