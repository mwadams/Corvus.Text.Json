// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

/// <summary>
/// A dependent schemas validation handler.
/// </summary>
public class DependentSchemasValidationHandler : IChildObjectPropertyValidationHandler, IJsonSchemaClassSetup
{
    internal const string EvaluationPathPropertiesKey = "DependentSchemasValidationHandler_EvaluationPathProperties";

    /// <summary>
    /// Gets the singleton instance of the <see cref="DependentSchemasValidationHandler"/>.
    /// </summary>
    public static DependentSchemasValidationHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint ValidationHandlerPriority { get; } = ValidationPriorities.AfterComposition + 1000; // We are quite expensive so push ourselves down the pile

    /// <inheritdoc/>
    public CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator;
    }

    /// <inheritdoc/>
    public CodeGenerator AppendValidateMethodSetup(CodeGenerator generator, TypeDeclaration typeDeclaration) => throw new NotImplementedException();

    /// <inheritdoc/>
    public CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator;
    }

    public CodeGenerator AppendObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.DependentSchemasSubschemaTypes()
            is IReadOnlyDictionary<IObjectPropertyDependentSchemasValidationKeyword, IReadOnlyCollection<DependentSchemaDeclaration>> dependentSchemas)
        {
            bool needsElse = false;

            foreach (IObjectPropertyDependentSchemasValidationKeyword keyword in dependentSchemas.Keys)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                foreach (DependentSchemaDeclaration dependentSchema in dependentSchemas[keyword])
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    string quotedPropertyName = SymbolDisplay.FormatLiteral(dependentSchema.JsonPropertyName, true);
                    generator
                        .ConditionallyAppend(!needsElse, g => g.AppendSeparatorLine())
                        .AppendIndent(needsElse ? "else " : "")
                        .AppendLine("if (objectValidation_unescapedPropertyName.Span.SequenceEqual(", quotedPropertyName, "u8))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendDependentSchemasValidation(typeDeclaration, dependentSchema)
                        .PopIndent()
                        .AppendLineIndent("}");

                    needsElse = true;
                }
            }
        }

        return generator;
    }

    public bool RequiresPropertyNameAsString(TypeDeclaration typeDeclaration) => true;

    public CodeGenerator AppendJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.DependentSchemasSubschemaTypes()
           is IReadOnlyDictionary<IObjectPropertyDependentSchemasValidationKeyword, IReadOnlyCollection<DependentSchemaDeclaration>> dependentSchemas)
        {
            Dictionary<DependentSchemaDeclaration, string> evaluationPathProperties = [];

            foreach (IObjectPropertyDependentSchemasValidationKeyword keyword in dependentSchemas.Keys)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                int i = 0;

                foreach (DependentSchemaDeclaration dependentSchema in dependentSchemas[keyword])
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    string evaluationPathProperty = generator.GetUniqueStaticReadOnlyPropertyNameInScope($"{dependentSchema.Keyword.Keyword}{i++}", suffix: "SchemaEvaluationPath");
                    string keywordPathProperty = SymbolDisplay.FormatLiteral(dependentSchema.KeywordPathModifier, true);
                    evaluationPathProperties.Add(dependentSchema, evaluationPathProperty);
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "private static readonly JsonSchemaPathProvider ",
                            evaluationPathProperty,
                            " = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath(", keywordPathProperty, "u8, buffer, out written);");
                }
            }

            typeDeclaration.SetMetadata(EvaluationPathPropertiesKey, evaluationPathProperties);
        }

        return generator;
    }
}

file static class DependentSchemasValidationExtensions
{
    public static CodeGenerator AppendDependentSchemasValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, DependentSchemaDeclaration declaration)
    {
        string keywordAsQuotedString = SymbolDisplay.FormatLiteral(declaration.Keyword.Keyword, true);
        string propertyClassName = declaration.ReducedDepdendentSchemaType.FullyQualifiedDotnetTypeName();
        string jsonSchemaClassName = generator.JsonSchemaClassName(propertyClassName);
        string childContextName = generator.GetUniqueVariableNameInScope("childContext");
        string schemaEvaluationPathProviderName = GetSchemaEvaluationProviderName(typeDeclaration, declaration);
        string quotedPropertyName = SymbolDisplay.FormatLiteral(declaration.JsonPropertyName, true);

        return generator
            .AppendLineIndent("JsonSchemaContext ", childContextName, " = ", propertyClassName, ".", jsonSchemaClassName, ".PushChildContext(")
            .PushIndent()
                .AppendLineIndent("parentDocument,")
                .AppendLineIndent("objectValidation_currentIndex,")
                .AppendLineIndent("ref context,")
                .AppendLineIndent("schemaEvaluationPath: ", schemaEvaluationPathProviderName, ");")
            .PopIndent()
            .AppendSeparatorLine()
            .AppendLineIndent(propertyClassName, ".", jsonSchemaClassName, ".Evaluate(parentDocument, parentIndex, ref ", childContextName, ");")
            .AppendSeparatorLine()
            .AppendLineIndent("if (!", childContextName, ".IsMatch)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("context.CommitChildContext(false, ref ", childContextName, ");")
                .AppendLineIndent("context.EvaluatedKeyword(false, ", quotedPropertyName, ", messageProvider: JsonSchemaEvaluation.ExpectedMatchesDependentSchema, ", keywordAsQuotedString, "u8);")
            .PopIndent()
            .AppendLineIndent("}")
            .AppendLineIndent("else")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("context.ApplyEvaluated(ref ", childContextName, ");")
                .AppendLineIndent("context.CommitChildContext(true, ref ", childContextName, ");")
                .AppendLineIndent("context.EvaluatedKeyword(true, ", quotedPropertyName, ", messageProvider: JsonSchemaEvaluation.ExpectedMatchesDependentSchema, ", keywordAsQuotedString, "u8);")
            .PopIndent()
            .AppendLineIndent("}");

        static string GetSchemaEvaluationProviderName(TypeDeclaration typeDeclaration, DependentSchemaDeclaration declaration)
        {
            if (typeDeclaration.TryGetMetadata(DependentSchemasValidationHandler.EvaluationPathPropertiesKey, out Dictionary<DependentSchemaDeclaration, string>? evaluationPathProperties))
            {
                if (evaluationPathProperties.TryGetValue(declaration, out var providerName))
                {
                    return providerName;
                }
            }

            throw new InvalidOperationException("Unable to find schema evaluation path provider for dependent schema.");
        }
    }
}
