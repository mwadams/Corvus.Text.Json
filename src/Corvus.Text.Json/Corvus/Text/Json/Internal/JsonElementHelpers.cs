// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;


#if !NET
using System.Collections.Concurrent;
#endif

using System.Diagnostics;

#if !NET
using System.Reflection;
using System.Reflection.Emit;
using Corvus.Text.Json.Internal;
#endif

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Extension methods for <see cref="IJsonElement"/>.
    /// </summary>
    public static partial class JsonElementHelpers
    {
        public static JsonValueKind ToValueKind(this JsonTokenType tokenType)
        {
            switch (tokenType)
            {
                case JsonTokenType.None:
                    return JsonValueKind.Undefined;
                case JsonTokenType.StartArray:
                    return JsonValueKind.Array;
                case JsonTokenType.StartObject:
                    return JsonValueKind.Object;
                case JsonTokenType.String:
                case JsonTokenType.Number:
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.Null:
                    // This is the offset between the set of literals within JsonValueType and JsonTokenType
                    // Essentially: JsonTokenType.Null - JsonValueType.Null
                    return (JsonValueKind)((byte)tokenType - 4);
                default:
                    Debug.Fail($"No mapping for token type {tokenType}");
                    return JsonValueKind.Undefined;
            }
        }
        public static int GetUtf8StringLength(ReadOnlySpan<byte> span)
        {
            if (span.Length == 0)
            {
                return 0;
            }

            int length = 0;
            ReadOnlySpan<byte> currentSpan = span;
            do
            {
                OperationStatus status = Rune.DecodeFromUtf8(currentSpan, out _, out int bytesConsumed);
                if (status != OperationStatus.Done)
                {
                    ThrowHelper.ThrowArgumentException_InvalidUTF8(span);
                }

                currentSpan = currentSpan.Slice(bytesConsumed);
                length++;
            }
            while (currentSpan.Length > 0);

            return length;
        }

        [CLSCompliant(false)]
        public static (IJsonDocument parentDocument, int parentDocumentIndex) GetParentDocumentAndIndex<TElement>(TElement value)
            where TElement : struct, IJsonElement<TElement>
        {
            value.CheckValidInstance();
            return (value.ParentDocument, value.ParentDocumentIndex);
        }
    }
}
