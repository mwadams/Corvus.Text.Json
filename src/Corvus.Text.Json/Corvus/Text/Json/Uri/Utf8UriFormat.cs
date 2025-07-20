// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Specifies the format options for URI string representation.
    /// </summary>
    public enum Utf8UriFormat
    {
        /// <summary>
        /// The URI is represented with URI escaping applied.
        /// </summary>
        UriEscaped = 1,

        /// <summary>
        /// The URI is completely unescaped.
        /// </summary>
        Unescaped = 2,

        /// <summary>
        /// The URI is canonically unescaped, allowing the same URI to be reconstructed from the output.
        /// If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence.
        /// </summary>
        SafeUnescaped = 3

        // This value is reserved for the default ToString() format that is historically none of the above.
        // V1ToStringUnescape = 0x7FFF
    }
}
