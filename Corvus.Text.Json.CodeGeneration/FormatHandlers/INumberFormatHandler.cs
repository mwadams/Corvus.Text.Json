// <copyright file="INumberFormatHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// A format handler for number formats.
/// </summary>
public interface INumberFormatHandler : IFormatHandler
{
    /// <summary>
    /// Append a format assertion to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format assertion.</param>
    /// <param name="format">The format to assert.</param>
    /// <param name="formatKeywordProviderExpression">The expression that produces the JsonSchemaPathProvider for the keyword.</param>
    /// <param name="isNegativeIdentifier">The identifier that contains the isNegative value of the normalized JSON number.</param>
    /// <param name="integralIdentifier">The identifier that contains the integral value of the normalized JSON number.</param>
    /// <param name="fractionalIdentifier">The identifier that contains the fractional value of the normalized JSON number.</param>
    /// <param name="exponentIdentifier">The identifier that contains the exponent value of the normalized JSON number.</param>
    /// <param name="validationContextIdentifier">The identifier for the validation context to update.</param>
    /// <param name="formatKeyword">The format keyword, or <see langword="null"/> if no format keyword is applied.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatAssertion(
        CodeGenerator generator,
        string format,
        string formatKeywordProviderExpression,
        string isNegativeIdentifier,
        string integralIdentifier,
        string fractionalIdentifier,
        string exponentIdentifier,
        string validationContextIdentifier,
        IKeyword? formatKeyword);

    /// <summary>
    /// Gets the .NET BCL type name for the given C# numeric langword, or BCL type name.
    /// </summary>
    /// <param name="langword">The .NET numeric langword.</param>
    /// <returns>The JSON string form suffix (e.g. <see langword="long"/> becomes <c>Int64</c>.</returns>
    string? GetTypeNameForNumericLangwordOrTypeName(string langword);
}
