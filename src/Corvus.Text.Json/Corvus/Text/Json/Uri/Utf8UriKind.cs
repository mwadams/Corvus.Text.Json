// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Defines the kind of URI, controlling whether absolute or relative URIs are used.
    /// </summary>
    public enum Utf8UriKind
    {
        /// <summary>
        /// The kind of URI is indeterminate. The URI can be either relative or absolute.
        /// </summary>
        RelativeOrAbsolute = 0,

        /// <summary>
        /// The URI is an absolute URI.
        /// </summary>
        Absolute = 1,

        /// <summary>
        /// The URI is a relative URI.
        /// </summary>
        Relative = 2
    }
}
