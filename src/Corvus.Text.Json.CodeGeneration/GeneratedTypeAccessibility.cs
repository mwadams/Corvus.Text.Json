// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Defines the accessibility of the generated types.
/// </summary>
public enum GeneratedTypeAccessibility
{
    /// <summary>
    /// The generated types should be <see langword="public"/>.
    /// </summary>
    Public,

    /// <summary>
    /// The generated types should be <see langword="internal"/>.
    /// </summary>
    Internal,

    /// <summary>
    /// The generated types should be <see langword="private"/>.
    /// </summary>
    Private
}
