// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

/// <summary>
/// A pattern-properties validation handler.
/// </summary>
public class PatternPropertiesValidationHandler : IChildObjectPropertyValidationHandler2, IJsonSchemaClassSetup
{
    private const string EvaluationPathPropertiesKey = "PatternPropertiesValidationHandler_EvaluationPathProperties";

    /// <summary>
    /// Gets the singleton instance of the <see cref="PatternPropertiesValidationHandler"/>.
    /// </summary>
    public static PatternPropertiesValidationHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint ValidationHandlerPriority { get; } = ValidationPriorities.AfterComposition + 100; // We are not so cheap!

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
        if (typeDeclaration.TryGetMetadata(EvaluationPathPropertiesKey, out Dictionary<string, List<string>>? evaluationPathProperties) &&
            evaluationPathProperties is not null &&
            typeDeclaration.PatternProperties() is IReadOnlyDictionary<IObjectPatternPropertyValidationKeyword, IReadOnlyCollection<PatternPropertyDeclaration>> patternProperties)
        {
            foreach (IReadOnlyCollection<PatternPropertyDeclaration> patternPropertyCollection in patternProperties.Values)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                int index = 1;
                bool hasIndex = patternPropertyCollection.Count > 1;
                foreach (PatternPropertyDeclaration patternProperty in patternPropertyCollection)
                {
                    generator
                        .AppendPatternPropertyValidation(typeDeclaration, patternProperty, hasIndex ? index : null, evaluationPathProperties);
                    ++index;
                }
            }
        }

        return generator;
    }

    public bool RequiresPropertyNameAsString(TypeDeclaration typeDeclaration) => typeDeclaration.PatternProperties() is not null;

    public CodeGenerator AppendJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (typeDeclaration.PatternProperties() is IReadOnlyDictionary<IObjectPatternPropertyValidationKeyword, IReadOnlyCollection<PatternPropertyDeclaration>> patternProperties)
        {
            Dictionary<string, List<string>> evaluationPathProperties = [];

            foreach (KeyValuePair<IObjectPatternPropertyValidationKeyword, IReadOnlyCollection<PatternPropertyDeclaration>> patternPropertyForKeyword in patternProperties)
            {
                int index = 1;
                int count = patternPropertyForKeyword.Value.Count;
                foreach (PatternPropertyDeclaration value in patternPropertyForKeyword.Value)
                {
                    string schemaPath = value.KeywordPathModifier;
                    string evaluationPathProperty = generator.GetPropertyNameInScope($"{value.Keyword.Keyword}{(count > 1 ? index.ToString() : "")}SchemaEvaluationPath");
                    index++;
                    AddEvaluationPathProperty(evaluationPathProperties, value.Keyword.Keyword, evaluationPathProperty);
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "private static readonly JsonSchemaPathProvider ",
                            evaluationPathProperty,
                            " = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath(", SymbolDisplay.FormatLiteral(value.KeywordPathModifier, true), "u8, buffer, out written);");
                }
            }

            typeDeclaration.SetMetadata(EvaluationPathPropertiesKey, evaluationPathProperties);
        }

        return generator;

        static void AddEvaluationPathProperty(Dictionary<string, List<string>> evaluationPathProperties, string keyword, string evaluationPathProperty)
        {
            if (!evaluationPathProperties.TryGetValue(keyword, out List<string>? propertiesForKeyword))
            {
                propertiesForKeyword = [];
                evaluationPathProperties.Add(keyword, propertiesForKeyword);
            }

            propertiesForKeyword.Add(evaluationPathProperty);
        }
    }

    /// <inheritdoc/>
    public bool WillEmitCodeFor(TypeDeclaration typeDeclaration) => typeDeclaration.PatternProperties() is not null;
}

file static class PatternPropertiesValidationExtensions
{
    public static CodeGenerator AppendPatternPropertyValidation(this CodeGenerator generator, TypeDeclaration typeDeclaration, PatternPropertyDeclaration property, int? index, Dictionary<string, List<string>> evaluationPathProperties)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        string regexAccessor =
            generator.GetStaticReadOnlyFieldNameInScope(
                property.Keyword.Keyword,
                rootScope: generator.JsonSchemaClassScope(),
                suffix: index?.ToString());


        string keywordString = SymbolDisplay.FormatLiteral(property.Keyword.Keyword, true);
        string propertyClassName = property.ReducedPatternPropertyType.FullyQualifiedDotnetTypeName();
        string jsonSchemaClassName = generator.JsonSchemaClassName(propertyClassName);
        string childContextName = generator.GetUniqueVariableNameInScope("childContext");
        string pattern = SymbolDisplay.FormatLiteral(property.Pattern, true);

        string evaluationPathProperty = evaluationPathProperties[property.Keyword.Keyword][index.HasValue ? index.Value - 1 : 0];

        return generator
            .AppendSeparatorLine()
            .AppendLineIndent(
                "if (JsonSchemaEvaluation.MatchRegularExpression(objectValidation_unescapedPropertyName.Span, ", regexAccessor, "))")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("context.AddLocalEvaluatedProperty(objectValidation_propertyCount);")
                .AppendLineIndent("JsonSchemaContext ", childContextName, " =")
                .PushIndent()
                    .AppendLineIndent("PushChildContextUnescaped(")
                    .PushIndent()
                        .AppendLineIndent("parentDocument,")
                        .AppendLineIndent("objectValidation_currentIndex,")
                        .AppendLineIndent("ref context,")
                        .AppendLineIndent("objectValidation_unescapedPropertyName.Span,")
                        .AppendLineIndent("evaluationPath: ", evaluationPathProperty, ");")
                    .PopIndent()
                .PopIndent()
                .AppendSeparatorLine()
                .AppendLineIndent(propertyClassName, ".", jsonSchemaClassName, ".Evaluate(parentDocument, objectValidation_currentIndex, ref ", childContextName, ");")
                .AppendLineIndent("context.EvaluatedKeyword(context.IsMatch, ", pattern, ", messageProvider: JsonSchemaEvaluation.ExpectedMatchPatternPropertySchema, ", keywordString, "u8);")
                .AppendLineIndent("context.CommitChildContext(", childContextName, ".IsMatch, ref ", childContextName, ");")

            .PopIndent()
            .AppendLineIndent("}");
    }
}
