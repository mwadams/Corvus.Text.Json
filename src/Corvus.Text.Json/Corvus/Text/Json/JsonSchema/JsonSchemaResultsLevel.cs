// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

namespace Corvus.Text.Json;

/// <summary>
/// The level of result to collect for an <see cref="IJsonSchemaResultsCollector"/>.
/// </summary>
public enum JsonSchemaResultsLevel
{
    /// <summary>
    /// Includes basic location and message information about schema matching failures.
    /// </summary>
    Basic,

    /// <summary>
    /// Includes detailed location and message information about schema matching failures.
    /// </summary>
    Detailed,

    /// <summary>
    /// Includes full location and message information for schema matching.
    /// </summary>
    Verbose,
}
