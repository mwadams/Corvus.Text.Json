// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides URI parsing functionality for UTF-8 URI strings.
/// </summary>
internal partial class Utf8UriParser
{
    private const Utf8UriSyntaxFlags SchemeOnlyFlags = Utf8UriSyntaxFlags.MayHavePath;

    /// <summary>
    /// Gets the default port for this parser's scheme.
    /// </summary>
    internal int DefaultPort
    {
        get
        {
            return _port;
        }
    }

    /// <summary>
    /// Gets the scheme name for this parser.
    /// </summary>
    internal string SchemeName
    {
        get
        {
            return _scheme;
        }
    }
}
