// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Represents the offsets of different components within a UTF-8 URI string.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Utf8UriOffset
{
    /// <summary>
    /// The offset to the start of the scheme component.
    /// </summary>
    public ushort Scheme;

    /// <summary>
    /// The offset to the start of the user component.
    /// </summary>
    public ushort User;

    /// <summary>
    /// The offset to the start of the host component.
    /// </summary>
    public ushort Host;

    /// <summary>
    /// The offset to the start of the port component.
    /// </summary>
    public ushort Port;

    /// <summary>
    /// The numeric value of the port.
    /// </summary>
    public ushort PortValue;

    /// <summary>
    /// The offset to the start of the path component.
    /// </summary>
    public ushort Path;

    /// <summary>
    /// The offset to the start of the query component.
    /// </summary>
    public ushort Query;

    /// <summary>
    /// The offset to the start of the fragment component.
    /// </summary>
    public ushort Fragment;

    /// <summary>
    /// The offset to the end of the URI string.
    /// </summary>
    public ushort End;
};
