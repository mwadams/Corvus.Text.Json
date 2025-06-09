// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;

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

        // This is a "scheme-only" base parser, everything after the scheme is
        // returned as the path component.
        // The user parser will need to do the majority of the work itself.
        //
        // However when the ctor is called from OnCreateUri context the calling parser
        // settings will later override the result on the base class
        //
        protected Utf8UriParser() : this(SchemeOnlyFlags) { }

        //
        // Static Registration methods
        //
        //
        // Registers a custom Uri parser based on a scheme string
        //
        public static void Register(Utf8UriParser uriParser, string schemeName, int defaultPort)
        {
            ArgumentNullException.ThrowIfNull(uriParser);
            ArgumentNullException.ThrowIfNull(schemeName);

            if (schemeName.Length == 1)
            {
                throw new ArgumentOutOfRangeException(nameof(schemeName));
            }

            if (!Uri.CheckSchemeName(schemeName))
                throw new ArgumentOutOfRangeException(nameof(schemeName));

            if ((uint)defaultPort > 0xFFFF && defaultPort != -1)
                throw new ArgumentOutOfRangeException(nameof(defaultPort));

            schemeName = schemeName.ToLowerInvariant();
            FetchSyntax(uriParser, schemeName, defaultPort);
        }

        //
        // Is a Uri scheme known to System.Uri?
        //
        public static bool IsKnownScheme(string schemeName)
        {
            ArgumentNullException.ThrowIfNull(schemeName);

            if (!Uri.CheckSchemeName(schemeName))
                throw new ArgumentOutOfRangeException(nameof(schemeName));

            Utf8UriParser? syntax = Utf8UriParser.GetSyntax(schemeName.ToLowerInvariant());
            return syntax != null && syntax.NotAny(Utf8UriSyntaxFlags.V1_UnknownUri);
        }

        // Is called whenever a parser gets registered with some scheme
        // The base implementation is a nop.
        //
        protected virtual void OnRegister(string schemeName, int defaultPort)
        {
        }
    }
}
