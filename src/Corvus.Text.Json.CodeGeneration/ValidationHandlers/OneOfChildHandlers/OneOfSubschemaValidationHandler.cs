// <copyright file="OneOfSubschemaValidationHandler.cs" company="Endjin Limited">
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

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.OneOfChildHandlers;

/// <summary>
/// A validation handler for one-of subschema semantics.
/// </summary>
public class OneOfSubschemaValidationHandler : IChildValidationHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="OneOfSubschemaValidationHandler"/>.
    /// </summary>
    public static OneOfSubschemaValidationHandler Instance { get; } = new();

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

        if (typeDeclaration.OneOfCompositionTypes() is IReadOnlyDictionary<IOneOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> subschemaDictionary)
        {
            foreach (IOneOfSubschemaValidationKeyword keyword in subschemaDictionary.Keys)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

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
                if (typeDeclaration.TryGetOneOfDiscriminatorMetadata(
                        keyword.Keyword,
                        out string? discriminatorPropertyName,
                        out List<(string Value, int BranchIndex)>? discriminatorValues,
                        out string? mapFieldName))
                {
                    generator.AppendOneOfDiscriminatorFastPath(
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
                string matchedCount = generator.GetUniqueVariableNameInScope("MatchedCount", prefix: keyword.Keyword);

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("int ", matchedCount, " = 0;");

                List<string> contexts = [];

                for (int i = 0; i < branchTypes.Length; i++)
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

                    contexts.Insert(0, contextNames[i]);
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("JsonSchemaContext ", contextNames[i], " =")
                        .PushIndent()
                        .AppendLineIndent(targetTypeNames[i], ".", jsonSchemaClassNames[i], ".PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: ", evalPathProperties[i], ");")
                        .PopIndent()
                        .AppendLineIndent(targetTypeNames[i], ".", jsonSchemaClassNames[i], ".Evaluate(parentDocument, parentIndex, ref ", contextNames[i], ");")
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (", contextNames[i], ".IsMatch)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent(matchedCount, "++;")
                            .AppendLineIndent("if (", matchedCount, " > 1 && !context.HasCollector)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("context.EvaluatedKeyword(false, JsonSchemaEvaluation.MatchedMoreThanOneSchema, ", formattedKeyword, "u8);")
                                .AppendLineIndent("return;")
                            .PopIndent()
                            .AppendLineIndent("}")
                            .AppendSeparatorLine()
                            .AppendLineIndent("context.ApplyEvaluated(ref ", contextNames[i], ");")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent();
                }

                generator
                    .AppendSeparatorLine()
                    .CommitChildContexts(contexts, keyword, matchedCount)
                    .AppendLineIndent(
                        "context.EvaluatedKeyword(", matchedCount, " == 1, ",
                        matchedCount, " == 0 ? JsonSchemaEvaluation.MatchedNoSchema : ", matchedCount, " == 1 ? JsonSchemaEvaluation.MatchedExactlyOneSchema : JsonSchemaEvaluation.MatchedMoreThanOneSchema, ",
                        formattedKeyword, "u8);");
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

file static class OneOfSubschemaHandlerExtensions
{
    public static CodeGenerator CommitChildContexts(this CodeGenerator generator, List<string> childContexts, IOneOfSubschemaValidationKeyword keyword, string matchedCount)
    {
        foreach (string childContextName in childContexts)
        {
            generator
                .AppendLineIndent("context.CommitChildContext(", matchedCount, " == 1, ref ", childContextName, ");");
        }

        return generator;
    }

    /// <summary>
    /// Emits the discriminator-based fast path for oneOf evaluation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This emits a guarded block that only executes when there is no collector.
    /// It reads the discriminator property from the instance, maps its value to a
    /// branch index, evaluates only that branch, and returns.
    /// </para>
    /// </remarks>
    public static CodeGenerator AppendOneOfDiscriminatorFastPath(
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
            .AppendLineIndent("int oneOfDiscriminatorBranch = -1;")
            .AppendLineIndent("var oneOfDiscriminatorEnum = new ObjectEnumerator(parentDocument, parentIndex);")
            .AppendLineIndent("while (oneOfDiscriminatorEnum.MoveNext())")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("using (UnescapedUtf8JsonString oneOfDiscriminatorPropName = parentDocument.GetPropertyNameUnescaped(oneOfDiscriminatorEnum.CurrentIndex))")
                .AppendLineIndent("{")
                .PushIndent()
                .AppendLineIndent("if (oneOfDiscriminatorPropName.Span.SequenceEqual(", quotedPropertyName, "u8))")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("if (parentDocument.GetJsonTokenType(oneOfDiscriminatorEnum.CurrentIndex) == JsonTokenType.String)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("using UnescapedUtf8JsonString discriminatorValue = parentDocument.GetUtf8JsonString(oneOfDiscriminatorEnum.CurrentIndex, JsonTokenType.String);");

        // Map value to branch index
        if (mapFieldName is not null)
        {
            // Hash-based lookup for 4+ branches
            generator
                        .AppendLineIndent("if (", mapFieldName, ".TryGetValue(discriminatorValue.Span, out oneOfDiscriminatorBranch))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("break;")
                        .PopIndent()
                        .AppendLineIndent("}");
        }
        else
        {
            // Sequential SequenceEqual for <= 3 branches
            foreach ((string value, int branchIndex) in discriminatorValues)
            {
                string quotedValue = SymbolDisplay.FormatLiteral(value, true);
                generator
                        .AppendLineIndent("if (discriminatorValue.Span.SequenceEqual(", quotedValue, "u8))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("oneOfDiscriminatorBranch = ", branchIndex.ToString(), ";")
                            .AppendLineIndent("break;")
                        .PopIndent()
                        .AppendLineIndent("}");
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
            .AppendLineIndent("switch (oneOfDiscriminatorBranch)")
            .AppendLineIndent("{");

        foreach ((_, int branchIndex) in discriminatorValues)
        {
            string ctx = generator.GetUniqueVariableNameInScope("DiscriminatorContext", suffix: branchIndex.ToString());
            generator
                .PushIndent()
                .AppendLineIndent("case ", branchIndex.ToString(), ":")
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
                        .AppendLineIndent("context.EvaluatedKeyword(true, JsonSchemaEvaluation.MatchedExactlyOneSchema, ", formattedKeyword, "u8);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendLineIndent("else")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("context.CommitChildContext(false, ref ", ctx, ");")
                        .AppendLineIndent("context.EvaluatedKeyword(false, JsonSchemaEvaluation.MatchedNoSchema, ", formattedKeyword, "u8);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendSeparatorLine()
                    .AppendLineIndent("return;")
                .PopIndent()
                .AppendLineIndent("}")
                .PopIndent();
        }

        // Default: discriminator value not recognized or property not found → fail
        generator
            .PushIndent()
            .AppendLineIndent("default:")
            .PushIndent()
                .AppendLineIndent("context.EvaluatedKeyword(false, JsonSchemaEvaluation.MatchedNoSchema, ", formattedKeyword, "u8);")
                .AppendLineIndent("return;")
            .PopIndent()
            .PopIndent()
            .AppendLineIndent("}")
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }
}