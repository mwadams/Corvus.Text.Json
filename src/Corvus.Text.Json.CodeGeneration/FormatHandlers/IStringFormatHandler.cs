// <copyright file="IStringFormatHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

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
}
