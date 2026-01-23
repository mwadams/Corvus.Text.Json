// <copyright file="TypeValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

/// <summary>
/// A validation handler for <see cref="ICoreTypeValidationKeyword"/> capability.
/// </summary>
internal sealed class TypeValidationHandler : KeywordValidationHandlerBase
{
    private TypeValidationHandler()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="TypeValidationHandler"/>.
    /// </summary>
    public static TypeValidationHandler Instance { get; } = new();

    /// <inheritdoc/>
    public override uint ValidationHandlerPriority => ValidationPriorities.Default / 2;

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator
             .PrependChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority)
             .AppendCoreTypeValidationSetup()
             .AppendChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority);
    }

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        IKeyword keyword = typeDeclaration.Keywords().OfType<ICoreTypeValidationKeyword>().First();

        IReadOnlyCollection<IChildValidationHandler> childHandlers = ChildHandlers;

        generator
            .PrependChildValidationCode(typeDeclaration, childHandlers, ValidationHandlerPriority)
            .AppendCoreTypeValidation(typeDeclaration, childHandlers, ValidationHandlerPriority, keyword, typeDeclaration.AllowedCoreTypes())
            .AppendChildValidationCode(typeDeclaration, childHandlers, ValidationHandlerPriority);

        return generator;
    }

    /// <inheritdoc/>
    public override bool HandlesKeyword(IKeyword keyword)
    {
        return keyword is ICoreTypeValidationKeyword;
    }
}

file static class TypeValidationHandlerExtensions
{
    public static CodeGenerator AppendCoreTypeValidationSetup(this CodeGenerator generator)
    {
        return generator
            .AppendSeparatorLine()
            .ReserveName("typeValidationHandler_tokenType")
            .AppendLineIndent("JsonTokenType typeValidationHandler_tokenType = parentDocument.GetJsonTokenType(parentIndex);");
    }

    public static CodeGenerator AppendCoreTypeValidation(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> childHandlers,
        uint validationPriority,
        IKeyword keyword,
        CoreTypes allowedTypes)
    {
        int allowedCoreTypeCount = allowedTypes.CountTypes();

        if (allowedCoreTypeCount == 0)
        {
            return generator;
        }

        generator
            .PrependChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        if ((allowedTypes & CoreTypes.Object) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeObject(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", validationPriority)
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, validationPriority);


        }

        if ((allowedTypes & CoreTypes.Array) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeArray(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", validationPriority)
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, validationPriority);
        }


        if ((allowedTypes & (CoreTypes.Integer | CoreTypes.Number)) != 0)
        {
            bool isInteger = (allowedTypes & CoreTypes.Integer) != 0;
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNumber(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, isInteger ? "JsonSchemaEvaluation.IgnoredNotTypeInteger" : "JsonSchemaEvaluation.IgnoredNotTypeNumber", validationPriority)
                ////.AppendIgnoredCoreTypeNumericFormatKeywords(typeDeclaration, validationPriority, isInteger)
                .PopIndent()
                .AppendLineIndent("}");
                ////.AppendElseEvaluateCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, validationPriority, static (generator, typeDeclaration, createdElseClause) => generator.EvaluateNumberFormatKeywords(typeDeclaration, createdElseClause));
        }

        if ((allowedTypes & CoreTypes.String) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeString(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", validationPriority)
                ////.AppendIgnoredCoreTypeStringFormatKeywords(typeDeclaration, validationPriority)
                .PopIndent()
                .AppendLineIndent("}");
                ////.AppendElseEvaluateCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, validationPriority, static (generator, typeDeclaration, createdElseClause) => generator.EvaluateStringFormatKeywords(typeDeclaration, createdElseClause));
        }

        if ((allowedTypes & CoreTypes.Boolean) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeBoolean(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", validationPriority)
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, validationPriority);
        }

        if ((allowedTypes & CoreTypes.Null) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNull(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", validationPriority)
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, validationPriority);
        }

        return generator
            .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);
    }

    public static CodeGenerator AppendElseEvaluateCoreTypeKeywords<T>(
    this CodeGenerator generator,
    TypeDeclaration typeDeclaration,
    uint validationPriority,
    Func<CodeGenerator, TypeDeclaration, bool, bool>? additionalWork = null)
    where T : IValidationKeyword
    {
        IEnumerable<T> keywords =
            typeDeclaration
                .Keywords()
                .OfType<T>();

        bool createdElseClause = false;

        foreach (T keyword in keywords)
        {
            // If the keyword's validation priority is equal to our validation priority,
            // or the keyword's validation priority is greater than our validation priority,
            // and there are no other keywords with a greater validation priority than our
            // validation priority, but less than the keyword's validation priority
            // then we can short circuit and process this now.
            if (keyword.ValidationPriority == validationPriority ||
                (keyword.ValidationPriority > validationPriority &&
                !typeDeclaration.Keywords()
                    .OfType<IValidationKeyword>()
                    .Where(k => !typeof(T).IsAssignableFrom(k.GetType()))
                    .Any(k => !ReferenceEquals(k, keyword)
                            && k.ValidationPriority > validationPriority
                            && k.ValidationPriority < keyword.ValidationPriority)))
            {
                ////if (typeDeclaration.TryGetKeywordHandlerFor(keyword, out KeywordValidationHandlerBase? keywordHandler) &&
                ////     typeDeclaration.AddProcessedCoreTypeDependentKeyword(keywordHandler))
                ////{
                ////    if (!createdElseClause)
                ////    {
                ////        generator
                ////            .BeginElseClause();
                ////        createdElseClause = true;
                ////    }

                ////    keywordHandler.AppendValidationCode(generator, typeDeclaration);
                ////}
            }

            if (additionalWork is not null)
            {
                createdElseClause = additionalWork(generator, typeDeclaration, createdElseClause);
            }

            if (createdElseClause)
            {
                generator
                    .PopIndent()
                    .AppendLineIndent("}");
            }
        }

        return generator;
    }

    public static CodeGenerator BeginElseClause(this CodeGenerator generator)
    {
        return generator
        .AppendLineIndent("else")
        .AppendLineIndent("{")
        .PushIndent();
    }


    public static CodeGenerator AppendIgnoredCoreTypeKeywords<T>(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName,
        uint validationPriority)
            where T : IValidationKeyword
    {
        IEnumerable<T> ignoredKeywords =
            typeDeclaration
                .Keywords()
                .OfType<T>();

        foreach (T keyword in ignoredKeywords)
        {
            ////if (typeDeclaration.AddIgnoredCoreTypeDependentKeyword(keyword))
            ////{
            ////    // We only add the ignore if it wasn't already processed
            ////    generator
            ////        .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
            ////}
        }

        return generator;
    }
}
