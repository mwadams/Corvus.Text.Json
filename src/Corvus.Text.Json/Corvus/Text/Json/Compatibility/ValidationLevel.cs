// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

namespace Corvus.Text.Json.Compatibility;

/// <summary>
/// The validation level.
/// </summary>
public enum ValidationLevel
{
    /// <summary>
    /// 10.4.1. Flag.
    /// </summary>
    Flag,

    /// <summary>
    /// 10.4.2. Basic.
    /// </summary>
    Basic,

    /// <summary>
    /// 10.4.3. Detailed.
    /// </summary>
    Detailed,

    /// <summary>
    /// 10.4.4. Verbose.
    /// </summary>
    Verbose,
}
