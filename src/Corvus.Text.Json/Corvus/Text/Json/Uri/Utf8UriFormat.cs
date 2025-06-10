// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    public enum Utf8UriFormat
    {
        UriEscaped = 1,
        Unescaped = 2,      // Completely unescaped.
        SafeUnescaped = 3   // Canonical unescaped.  Allows same uri to be reconstructed from the output.
        // If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence.

        // This value is reserved for the default ToString() format that is historically none of the above.
        // V1ToStringUnescape = 0x7FFF
    }
}
