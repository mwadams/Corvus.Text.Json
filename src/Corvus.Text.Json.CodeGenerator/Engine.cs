// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
