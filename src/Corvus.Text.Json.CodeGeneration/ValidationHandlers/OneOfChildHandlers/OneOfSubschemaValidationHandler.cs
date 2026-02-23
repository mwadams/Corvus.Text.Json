// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

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

                string matchedCount = generator.GetUniqueVariableNameInScope("MatchedCount", prefix: keyword.Keyword);

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("int ", matchedCount, " = 0;");

                string formattedKeyword = SymbolDisplay.FormatLiteral(keyword.Keyword, true);

                IReadOnlyCollection<TypeDeclaration> subschemaTypes = subschemaDictionary[keyword];
                int i = 0;
                List<string> contexts = [];

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

                    ReducedTypeDeclaration reducedType = subschemaType.ReducedTypeDeclaration();
                    string localContextName = generator.GetUniqueVariableNameInScope("Context", prefix: keyword.Keyword, suffix: i.ToString());
                    contexts.Insert(0, localContextName);
                    string evaluationPathProperty = generator.GetPropertyNameInScope($"{keyword.Keyword}{i}SchemaEvaluationPath");
                    string targetTypeName = reducedType.ReducedType.FullyQualifiedDotnetTypeName();
                    string jsonSchemaClassName = generator.JsonSchemaClassName(targetTypeName);
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("JsonSchemaContext ", localContextName, " =")
                        .PushIndent()
                        .AppendLineIndent(targetTypeName, ".", jsonSchemaClassName, ".PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: ", evaluationPathProperty, ");")
                        .PopIndent()
                        .AppendLineIndent(targetTypeName, ".", jsonSchemaClassName, ".Evaluate(parentDocument, parentIndex, ref ", localContextName, ");")
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (", localContextName, ".IsMatch)")
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
                            .AppendLineIndent("context.ApplyEvaluated(ref ", localContextName, ");")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent();

                    i++;
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
}
