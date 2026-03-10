// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.AnyOfChildHandlers;

/// <summary>
/// A validation handler for any-of const semantics.
/// </summary>
public class AnyOfConstValidationHandler : IChildValidationHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="AnyOfConstValidationHandler"/>.
    /// </summary>
    public static AnyOfConstValidationHandler Instance { get; } = new();

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

        if (typeDeclaration.AnyOfConstantValues() is IReadOnlyDictionary<IAnyOfConstantValidationKeyword, JsonElement[]> constDictionary)
        {
            bool requiresShortCut = false;

            foreach (IAnyOfConstantValidationKeyword keyword in constDictionary.Keys)
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

                requiresShortCut = true;

                string formattedKeyword = SymbolDisplay.FormatLiteral(keyword.Keyword, true); 

                var orderedElements = constDictionary[keyword];

                int elementIndex = 1;
                List<(int, JsonElement)> orderedElementWithIndex = [];
                foreach (var element in orderedElements)
                {
                    orderedElementWithIndex.Add((elementIndex++, element));
                }


                Dictionary<JsonValueKind, (int, JsonElement)[]> constValues =
                    orderedElementWithIndex
                        .OrderBy(k => k.Item2.ValueKind)
                        .GroupBy(k => k.Item2.ValueKind)
                        .ToDictionary(k => k.Key, k => k.ToArray());

                string shortCircuitSuccessLabel = generator.GetUniqueVariableNameInScope("ShortCircuitSuccess", prefix: keyword.Keyword);
                string afterFailureLabel = generator.GetUniqueVariableNameInScope("AfterFailure", prefix: keyword.Keyword);

                bool addSuffix = orderedElements.Length > 1;

                foreach (KeyValuePair<JsonValueKind, (int, JsonElement)[]> item in constValues)
                {
                    switch (item.Key)
                    {
                        case JsonValueKind.Array:
                            generator
                                .AppendComplexValueConstantValidation(typeDeclaration, keyword, item.Value, "JsonTokenType.StartArray", shortCircuitSuccessLabel, addSuffix);
                            break;
                        case JsonValueKind.Object:
                            generator
                                .AppendComplexValueConstantValidation(typeDeclaration, keyword, item.Value, "JsonTokenType.StartObject", shortCircuitSuccessLabel, addSuffix);
                            break;
                        case JsonValueKind.Null:
                            generator
                                .AppendNullConstantValidation(typeDeclaration, shortCircuitSuccessLabel);
                            break;
                        case JsonValueKind.True:
                            generator
                                .AppendBooleanConstantValidation(typeDeclaration, true, shortCircuitSuccessLabel);
                            break;
                        case JsonValueKind.False:
                            generator
                                .AppendBooleanConstantValidation(typeDeclaration, false, shortCircuitSuccessLabel);
                            break;
                        case JsonValueKind.String:
                            generator
                                .AppendStringConstantValidation(typeDeclaration, item.Value, shortCircuitSuccessLabel);
                            break;
                        case JsonValueKind.Number:
                            generator
                                .AppendNumberConstantValidation(typeDeclaration, item.Value, shortCircuitSuccessLabel);
                            break;
                        default:
                            throw new InvalidOperationException("Unexpected value kind.");
                    }
                }

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("context.EvaluatedKeyword(false, messageProvider: JsonSchemaEvaluation.DidNotMatchAtLeastOneConstantValue, ", formattedKeyword, "u8);")
                    .AppendNoCollectorShortcutReturn()
                    .AppendSeparatorLine()
                    .AppendLineIndent("goto ", afterFailureLabel, ";")
                    .AppendSeparatorLine()
                    .AppendLine(shortCircuitSuccessLabel, ":")
                    .AppendLineIndent("context.EvaluatedKeyword(true, messageProvider: JsonSchemaEvaluation.MatchedAtLeastOneConstantValue, \", formattedKeyword, \"u8);")
                    .AppendSeparatorLine()
                    .AppendLine(afterFailureLabel, ":;");
            }
        }

        return generator;
    }

    public CodeGenerator AppendValidateMethodSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        // Not expected to be called
        throw new InvalidOperationException();
    }
}

file static class AnyOfConstValidationHandlerExtensions
{
    public static CodeGenerator AppendStringConstantValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, (int, JsonElement)[] constantValues, string shortCircuitSuccessLabel)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == JsonTokenType.String)")
            .PushMemberScope("constantValidation", ScopeType.Method)
            .AppendLineIndent("{")
            .PushIndent()
                .AppendUnescapedUtf8JsonStringIfNotAppended(typeDeclaration, false);

        foreach ((_, JsonElement constantValue) in constantValues)
        {
            string quotedStringValue = SymbolDisplay.FormatLiteral(constantValue.GetString()!, true);

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (unescapedUtf8JsonString.Span.SequenceEqual(", quotedStringValue, "u8))")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
                .PopIndent()
                .AppendLineIndent("}");
        }

        generator
            .PopMemberScope()
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }

    public static CodeGenerator AppendNumberConstantValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, (int, JsonElement)[] constantValues, string shortCircuitSuccessLabel)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == JsonTokenType.Number)")
            .PushMemberScope("constantValidation", ScopeType.Method)
            .AppendLineIndent("{")
            .PushIndent()
            .AppendNormalizedJsonNumberIfNotAppended(typeDeclaration, false);

        foreach ((_, JsonElement constantValue) in constantValues)
        {
#if BUILDING_SOURCE_GENERATOR
            ReadOnlySpan<byte> rawValue = Encoding.UTF8.GetBytes(constantValue.GetRawText());
#else
            ReadOnlySpan<byte> rawValue = JsonMarshal.GetRawUtf8Value(constantValue);
#endif

            JsonElementHelpers.ParseNumber(rawValue, out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);
            string isNegativeString = isNegative ? "true" : "false";
            string integralString = SymbolDisplay.FormatLiteral(Formatting.GetTextFromUtf8(integral), true);
            string fractionalString = SymbolDisplay.FormatLiteral(Formatting.GetTextFromUtf8(fractional), true);
            string exponentString = exponent.ToString();
            string rawValueString = SymbolDisplay.FormatLiteral(Formatting.GetTextFromUtf8(rawValue), true);


            generator
                .AppendSeparatorLine()
                .AppendLineIndent(
                    "if (JsonElementHelpers.AreEqualNormalizedJsonNumbers(",
                    isNegativeString, ", ", integralString, "u8, ", fractionalString, "u8, ", exponentString, ",",
                    "isNegative, integral, fractional, exponent))")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
                .PopIndent()
                .AppendLineIndent("}");
        }

        generator
            .PopMemberScope()
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }

    public static CodeGenerator AppendBooleanConstantValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool expectation, string shortCircuitSuccessLabel)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == JsonTokenType.", expectation ? "True" : "False", ")")
            .AppendLineIndent("{")
            .PushIndent()
                    .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
            .PopIndent()
            .AppendLineIndent("}");
        return generator;
    }

    public static CodeGenerator AppendNullConstantValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, string shortCircuitSuccessLabel)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == JsonTokenType.Null)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
            .PopIndent()
            .AppendLineIndent("}");
        return generator;
    }

    public static CodeGenerator AppendComplexValueConstantValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, (int, JsonElement)[] constantValues, string requiredTokenType, string shortCircuitSuccessLabel, bool addSuffix)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == ", requiredTokenType, ")")
            .AppendLineIndent("{")
            .PushIndent();

        foreach ((int index, JsonElement constantValue) in constantValues)
        {
            Debug.Assert(constantValue.ValueKind is JsonValueKind.Object or JsonValueKind.Array);

            string quotedConstantValue = SymbolDisplay.FormatLiteral(constantValue.GetRawText(), true);

            string constPropertyName =
                      generator.GetPropertyNameInScope(
                          keyword.Keyword,
                          rootScope: generator.ConstantsScope(),
                          suffix: addSuffix ? index.ToString() : null);

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (JsonElementHelpers.DeepEqualsNoParentDocumentCheck(", generator.ConstantsClassName(), ".", constPropertyName, ", tokenType, parentDocument, parentIndex))")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
                .PopIndent()
                .AppendLineIndent("}");
        }

        generator
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }
}
