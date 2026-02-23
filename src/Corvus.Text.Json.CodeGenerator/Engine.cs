// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

namespace Corvus.Text.Json.CodeGenerator;

/// <summary>
/// Represents the available code generation engines.
/// </summary>
public enum Engine
{
    /// <summary>
    /// The V4 engine using Corvus.Json.ExtendedTypes.
    /// </summary>
    V4,

    /// <summary>
    /// The V5 engine using Corvus.Text.Json.
    /// </summary>
    V5,
}
