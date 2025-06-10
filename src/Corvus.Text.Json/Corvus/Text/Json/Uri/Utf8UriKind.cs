// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    // Used to control whether absolute or relative URIs are used
    public enum Utf8UriKind
    {
        RelativeOrAbsolute = 0,
        Absolute = 1,
        Relative = 2
    }
}
