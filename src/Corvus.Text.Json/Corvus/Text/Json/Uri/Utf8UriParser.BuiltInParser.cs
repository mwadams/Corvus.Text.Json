// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{

    internal partial class Utf8UriParser
    {
        private sealed class BuiltInUriParser : Utf8UriParser
        {
            //
            // All BuiltIn parsers use that ctor. They are marked with "simple" and "built-in" flags
            //
            internal BuiltInUriParser(string lwrCaseScheme, int defaultPort, Utf8UriSyntaxFlags syntaxFlags)
                : base(syntaxFlags | Utf8UriSyntaxFlags.SimpleUserSyntax)
            {
                _scheme = lwrCaseScheme;
                _port = defaultPort;
            }
        }
    }
}
