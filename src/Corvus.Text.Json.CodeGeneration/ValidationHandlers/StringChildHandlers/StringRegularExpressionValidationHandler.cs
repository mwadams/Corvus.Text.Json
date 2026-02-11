// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.StringChildHandlers;

/// <summary>
/// A string regular expression validation handler.
/// </summary>
public class StringRegularExpressionValidationHandler : IChildValidationHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="StringRegularExpressionValidationHandler"/>.
    /// </summary>
    public static StringRegularExpressionValidationHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint ValidationHandlerPriority { get; } = ValidationPriorities.Default;

    /// <inheritdoc/>
    public CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator;
    }

    /// <inheritdoc/>
    public CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        bool requiresShortCut = false;

        foreach (IStringRegexValidationProviderKeyword keyword in typeDeclaration.Keywords().OfType<IStringRegexValidationProviderKeyword>())
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (requiresShortCut)
            {
                generator
                    .AppendNoCollectorNoMatchShortcutReturn();
            }

            generator.
                AppendStringRegularExpressionMatch(typeDeclaration, keyword);

            requiresShortCut = true;
        }

        return generator;
    }

    public CodeGenerator AppendValidateMethodSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        // Not expected to be called
        throw new InvalidOperationException();
    }
}

public static class StringRegularExpressionValidationExtensions
{
    public static CodeGenerator AppendStringRegularExpressionMatch(this CodeGenerator generator, TypeDeclaration typeDeclaration, IStringRegexValidationProviderKeyword keyword)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (!keyword.TryGetValidationRegularExpressions(typeDeclaration, out IReadOnlyList<string> expressions))
        {
            throw new InvalidOperationException("Unable to get validation constants for keyword.");
        }

        Debug.Assert(expressions.Count == 1, "Expected exactly one regular expression for keyword.");

        string regularExpression = SymbolDisplay.FormatLiteral(expressions[0], true);
        string regularExpressionMemberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword);

        return generator
            .AppendSeparatorLine()
            .AppendUnescapedUtf8JsonStringIfNotAppended(typeDeclaration, false)
            .AppendLineIndent(
                "JsonSchemaEvaluation.MatchRegularExpression(unescapedUtf8JsonString.Span, ",
                regularExpressionMemberName, ",",
                regularExpression, ", ",
                SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context);");
    }
}
