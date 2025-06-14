// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Utf8UriOffset
    {
        public ushort Scheme;
        public ushort User;
        public ushort Host;
        public ushort Port;
        public ushort PortValue;
        public ushort Path;
        public ushort Query;
        public ushort Fragment;
        public ushort End;
    };
}
