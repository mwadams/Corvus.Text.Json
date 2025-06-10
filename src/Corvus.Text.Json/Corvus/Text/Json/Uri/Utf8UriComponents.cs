// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    [Flags]
    public enum Utf8UriComponents
    {
        // Generic parts.
        // ATTN: The values must stay in sync with Uri.Flags.xxxNotCanonical
        Scheme = 0x1,
        UserInfo = 0x2,
        Host = 0x4,
        Port = 0x8,
        Path = 0x10,
        Query = 0x20,
        Fragment = 0x40,

        StrongPort = 0x80,
        NormalizedHost = 0x100,

        // This will also return respective delimiters for scheme, userinfo or port
        // Valid only for a single component requests.
        KeepDelimiter = 0x40000000,

        // This is used by GetObjectData and can also be used directly.
        // Works for both absolute and relative Uris
        SerializationInfoString = unchecked((int)0x80000000),

        // Shortcuts for general cases
        AbsoluteUri = Scheme | UserInfo | Host | Port | Path | Query | Fragment,
        HostAndPort = Host | StrongPort,                //includes port even if default
        StrongAuthority = UserInfo | Host | StrongPort, //includes port even if default
        SchemeAndServer = Scheme | Host | Port,
        HttpRequestUrl = Scheme | Host | Port | Path | Query,
        PathAndQuery = Path | Query,
    }
}
