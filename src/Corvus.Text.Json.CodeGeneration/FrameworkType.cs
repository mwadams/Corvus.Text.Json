// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Specifies a framework type for conditionally code generation.
/// </summary>
public enum FrameworkType
{
    /// <summary>
    /// The code is never emitted.
    /// </summary>
    NotEmitted,

    /// <summary>
    /// The code is for all framework types.
    /// </summary>
    All,

    /// <summary>
    /// The code is for anything prior to net80.
    /// </summary>
    PreNet80,

    /// <summary>
    /// The code is specifically for net80.
    /// </summary>
    Net80,

    /// <summary>
    /// The code is for net80 or later.
    /// </summary>
    Net80OrGreater,

    /// <summary>
    /// The code is for net90 or later.
    /// </summary>
    Net90OrGreater,
}
