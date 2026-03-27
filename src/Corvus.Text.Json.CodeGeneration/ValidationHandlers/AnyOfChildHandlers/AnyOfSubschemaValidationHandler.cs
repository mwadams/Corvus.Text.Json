// <copyright file="AnyOfSubschemaValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.AnyOfChildHandlers;

/// <summary>
/// A validation handler for any-of subschema semantics.
/// </summary>
public class AnyOfSubschemaValidationHandler : IChildValidationHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="AnyOfSubschemaValidationHandler"/>.
    /// </summary>
    public static AnyOfSubschemaValidationHandler Instance { get; } = new();

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

        if (typeDeclaration.AnyOfCompositionTypes() is IReadOnlyDictionary<IAnyOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> subschemaDictionary)
        {
            foreach (IAnyOfSubschemaValidationKeyword keyword in subschemaDictionary.Keys)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                string composedIsMatchName = generator.GetUniqueVariableNameInScope("ComposedIsMatch", prefix: keyword.Keyword);
                string shortCircuitSuccessLabel = generator.GetUniqueVariableNameInScope("ShortCircuitSuccess", prefix: keyword.Keyword);
                string formattedKeyword = SymbolDisplay.FormatLiteral(keyword.Keyword, true);

                IReadOnlyCollection<TypeDeclaration> subschemaTypes = subschemaDictionary[keyword];

                // Pre-compute per-branch info for both discriminator fast path and sequential path
                TypeDeclaration[] branchTypes = subschemaTypes.ToArray();
                string[] contextNames = new string[branchTypes.Length];
                string[] evalPathProperties = new string[branchTypes.Length];
                string[] targetTypeNames = new string[branchTypes.Length];
                string[] jsonSchemaClassNames = new string[branchTypes.Length];

                for (int b = 0; b < branchTypes.Length; b++)
                {
                    ReducedTypeDeclaration reducedType = branchTypes[b].ReducedTypeDeclaration();
                    contextNames[b] = generator.GetUniqueVariableNameInScope("Context", prefix: keyword.Keyword, suffix: b.ToString());
                    evalPathProperties[b] = generator.GetPropertyNameInScope($"{keyword.Keyword}{b}SchemaEvaluationPath");
                    targetTypeNames[b] = reducedType.ReducedType.FullyQualifiedDotnetTypeName();
                    jsonSchemaClassNames[b] = generator.JsonSchemaClassName(targetTypeNames[b]);
                }

                // Try discriminator fast path
                if (typeDeclaration.TryGetAnyOfDiscriminatorMetadata(
                        keyword.Keyword,
                        out string? discriminatorPropertyName,
                        out List<(string Value, int BranchIndex)>? discriminatorValues,
                        out string? mapFieldName))
                {
                    generator.AppendAnyOfDiscriminatorFastPath(
                        discriminatorPropertyName,
                        discriminatorValues,
                        mapFieldName,
                        formattedKeyword,
                        contextNames,
                        evalPathProperties,
                        targetTypeNames,
                        jsonSchemaClassNames);
                }

                // Sequential evaluation path (used when collector is present, or no discriminator)
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("bool ", composedIsMatchName, " = false;");

                int i = 0;
                foreach (TypeDeclaration subschemaType in subschemaTypes)
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

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("JsonSchemaContext ", contextNames[i], " =")
                        .PushIndent()
                        .AppendLineIndent(targetTypeNames[i], ".", jsonSchemaClassNames[i], ".PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: ", evalPathProperties[i], ");")
                        .PopIndent()
                        .AppendLineIndent(targetTypeNames[i], ".", jsonSchemaClassNames[i], ".Evaluate(parentDocument, parentIndex, ref ", contextNames[i], ");")
                        .AppendLineIndent(composedIsMatchName, " = ", composedIsMatchName, " || ", contextNames[i], ".IsMatch;");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (", contextNames[i], ".IsMatch)")
                        .AppendLineIndent("{")
                        .PushIndent();

                    generator
                        .AppendLineIndent("if (!", contextNames[i], ".RequiresEvaluationTracking && !", contextNames[i], ".HasCollector)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
                        .PopIndent()
                        .AppendLineIndent("}");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("context.ApplyEvaluated(ref ", contextNames[i], ");")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("context.CommitChildContext(true, ref ", contextNames[i], ");");

                    i++;
                }

                generator
                    .AppendSeparatorLine()
                    .PopIndent()
                    .AppendLineIndent(shortCircuitSuccessLabel, ":")
                    .PushIndent()
                    .AppendLineIndent("context.EvaluatedKeyword(", composedIsMatchName, ", ", composedIsMatchName, "  ? JsonSchemaEvaluation.MatchedAtLeastOneSchema : JsonSchemaEvaluation.DidNotMatchAtLeastOneSchema, ", formattedKeyword, "u8);");
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

file static class AnyOfSubschemaValidationHandlerExtensions
{
    public static CodeGenerator AppendAnyOfDiscriminatorFastPath(
        this CodeGenerator generator,
        string discriminatorPropertyName,
        List<(string Value, int BranchIndex)> discriminatorValues,
        string? mapFieldName,
        string formattedKeyword,
        string[] contextNames,
        string[] evalPathProperties,
        string[] targetTypeNames,
        string[] jsonSchemaClassNames)
    {
        string quotedPropertyName = SymbolDisplay.FormatLiteral(discriminatorPropertyName, true);

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (!context.HasCollector)")
            .AppendLineIndent("{")
            .PushIndent();

        // Find the discriminator property in the instance
        generator
            .AppendLineIndent("int anyOfDiscriminatorBranch = -1;")
            .AppendLineIndent("var anyOfDiscriminatorEnum = new ObjectEnumerator(parentDocument, parentIndex);")
            .AppendLineIndent("while (anyOfDiscriminatorEnum.MoveNext())")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("using (UnescapedUtf8JsonString anyOfDiscriminatorPropName = parentDocument.GetPropertyNameUnescaped(anyOfDiscriminatorEnum.CurrentIndex))")
                .AppendLineIndent("{")
                .PushIndent()
                .AppendLineIndent("if (anyOfDiscriminatorPropName.Span.SequenceEqual(", quotedPropertyName, "u8))")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("if (parentDocument.GetJsonTokenType(anyOfDiscriminatorEnum.CurrentIndex) == JsonTokenType.String)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("using UnescapedUtf8JsonString discriminatorValue = parentDocument.GetUtf8JsonString(anyOfDiscriminatorEnum.CurrentIndex, JsonTokenType.String);");

        // Map value to branch index
        // Both hash map (TryGetValue returns 0-based insertion index) and SequenceEqual
        // paths produce a 0-based case index that aligns with the switch statement below.
        if (mapFieldName is not null)
        {
            generator
                        .AppendLineIndent("if (", mapFieldName, ".TryGetValue(discriminatorValue.Span, out anyOfDiscriminatorBranch))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("break;")
                        .PopIndent()
                        .AppendLineIndent("}");
        }
        else
        {
            int caseIndex = 0;
            foreach ((string value, _) in discriminatorValues)
            {
                string quotedValue = SymbolDisplay.FormatLiteral(value, true);
                generator
                        .AppendLineIndent("if (discriminatorValue.Span.SequenceEqual(", quotedValue, "u8))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("anyOfDiscriminatorBranch = ", caseIndex.ToString(), ";")
                            .AppendLineIndent("break;")
                        .PopIndent()
                        .AppendLineIndent("}");
                caseIndex++;
            }
        }

        generator
                    .PopIndent()
                    .AppendLineIndent("}")  // close: if (GetJsonTokenType == String)
                    .AppendSeparatorLine()
                    .AppendLineIndent("break;")  // found the discriminator property, stop iterating
                .PopIndent()
                .AppendLineIndent("}")  // close: if (propName.SequenceEqual)
            .PopIndent()
            .AppendLineIndent("}")  // close: using (propName)
            .PopIndent()
            .AppendLineIndent("}");  // close: while (MoveNext)

        // Dispatch to the matching branch
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("switch (anyOfDiscriminatorBranch)")
            .AppendLineIndent("{");

        int switchCaseIndex = 0;
        foreach ((_, int branchIndex) in discriminatorValues)
        {
            string ctx = generator.GetUniqueVariableNameInScope("DiscriminatorContext", suffix: branchIndex.ToString());
            generator
                .PushIndent()
                .AppendLineIndent("case ", switchCaseIndex.ToString(), ":")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("JsonSchemaContext ", ctx, " =")
                    .PushIndent()
                    .AppendLineIndent(targetTypeNames[branchIndex], ".", jsonSchemaClassNames[branchIndex], ".PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: ", evalPathProperties[branchIndex], ");")
                    .PopIndent()
                    .AppendLineIndent(targetTypeNames[branchIndex], ".", jsonSchemaClassNames[branchIndex], ".Evaluate(parentDocument, parentIndex, ref ", ctx, ");")
                    .AppendLineIndent("if (", ctx, ".IsMatch)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("context.ApplyEvaluated(ref ", ctx, ");")
                        .AppendLineIndent("context.CommitChildContext(true, ref ", ctx, ");")
                        .AppendLineIndent("context.EvaluatedKeyword(true, JsonSchemaEvaluation.MatchedAtLeastOneSchema, ", formattedKeyword, "u8);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendLineIndent("else")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("context.CommitChildContext(false, ref ", ctx, ");")
                        .AppendLineIndent("context.EvaluatedKeyword(false, JsonSchemaEvaluation.DidNotMatchAtLeastOneSchema, ", formattedKeyword, "u8);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendSeparatorLine()
                    .AppendLineIndent("return;")
                .PopIndent()
                .AppendLineIndent("}")
                .PopIndent();
            switchCaseIndex++;
        }

        // Default: discriminator value not recognized or property not found → fall through to sequential
        generator
            .PushIndent()
            .AppendLineIndent("default:")
            .PushIndent()
                .AppendLineIndent("break;")
            .PopIndent()
            .PopIndent()
            .AppendLineIndent("}")
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }
}