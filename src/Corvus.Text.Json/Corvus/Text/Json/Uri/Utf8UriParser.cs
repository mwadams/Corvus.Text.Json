// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    internal partial class Utf8UriParser
    {
        internal string SchemeName
        {
            get
            {
                return _scheme;
            }
        }
        internal int DefaultPort
        {
            get
            {
                return _port;
            }
        }

        private const Utf8UriSyntaxFlags SchemeOnlyFlags = Utf8UriSyntaxFlags.MayHavePath;
    }
}
