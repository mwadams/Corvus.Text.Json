// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Collections.Generic;
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

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("bool ", composedIsMatchName, " = false;");


                IReadOnlyCollection<TypeDeclaration> subschemaTypes = subschemaDictionary[keyword];
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

                    ReducedTypeDeclaration reducedType = subschemaType.ReducedTypeDeclaration();
                    string localContextName = generator.GetUniqueVariableNameInScope("Context", prefix: keyword.Keyword, suffix: i.ToString());

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
                        .AppendLineIndent(composedIsMatchName, " = ", composedIsMatchName, " || ", localContextName, ".IsMatch;");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (", localContextName, ".IsMatch)")
                        .AppendLineIndent("{")
                        .PushIndent();

                    generator
                        .AppendLineIndent("if (!", localContextName, ".RequiresEvaluationTracking && !", localContextName, ".HasCollector)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("goto ", shortCircuitSuccessLabel, ";")
                        .PopIndent()
                        .AppendLineIndent("}");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("context.ApplyEvaluated(ref ", localContextName, ");")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("context.CommitChildContext(true, ref ", localContextName, ");");

                    i++;
                }

                string formattedKeyword = SymbolDisplay.FormatLiteral(keyword.Keyword, true);
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
