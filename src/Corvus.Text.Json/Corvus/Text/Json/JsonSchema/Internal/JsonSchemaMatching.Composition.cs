// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Support for JSON Schema matching implementations.
    /// </summary>
    public static partial class JsonSchemaMatching
    {
        public static readonly JsonSchemaMessageProvider MatchedMoreThanOneSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedMoreThanOneSchema.AsSpan(), buffer, out written);
        public static readonly JsonSchemaMessageProvider MatchedNoSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedNoSchema.AsSpan(), buffer, out written);
    }
}
