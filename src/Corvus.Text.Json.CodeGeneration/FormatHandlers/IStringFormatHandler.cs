// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// A format provider for string formats.
/// </summary>
public interface IStringFormatHandler : IFormatHandler
{
    /// <summary>
    /// Append a format assertion to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format assertion.</param>
    /// <param name="format">The format to assert.</param>
    /// <param name="formatKeywordProviderExpression">The expression that produces the JsonSchemaPathProvider for the keyword.</param>
    /// <param name="valueIdentifier">The identifier for the value to test.</param>
    /// <param name="validationContextIdentifier">The identifier for the validation context to update.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatAssertion(
        CodeGenerator generator,
        string format,
        string formatKeywordProviderExpression,
        string valueIdentifier,
        string validationContextIdentifier);

    /// <summary>
    /// Indicates whether the string format requires the simple types backing.
    /// </summary>
    /// <param name="format">The format to test.</param>
    /// <param name="requiresSimpleType"><see langword="true"/> if the format requires the fixed-size simple types backing.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool RequiresSimpleTypesBacking(string format, out bool requiresSimpleType);
}
