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
            .AppendCoreTypeValidation(this, typeDeclaration, childHandlers, ValidationHandlerPriority, keyword, typeDeclaration.AllowedCoreTypes())
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
        IKeywordValidationHandler parentHandler,
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

        if ((allowedTypes & (CoreTypes.Integer | CoreTypes.Number)) != 0)
        {
            bool isInteger = (allowedTypes & CoreTypes.Integer) != 0;
            string ignoredMessageProviderName = isInteger ? "JsonSchemaEvaluation.IgnoredNotTypeInteger" : "JsonSchemaEvaluation.IgnoredNotTypeNumber";
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNumber(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, ignoredMessageProviderName)
                    .AppendIgnoredCoreTypeNumberFormatKeywords(typeDeclaration, ignoredMessageProviderName)
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<INumberKeywordValidationHandler>(
                    parentHandler,
                    typeDeclaration,
                    (generator, typeDeclaration, createdElseClause) => generator.AppendEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, createdElseClause, CoreTypes.Number));
        }

        if ((allowedTypes & CoreTypes.String) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeString(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString")
                    .AppendIgnoredCoreTypeStringFormatKeywords(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IStringKeywordValidationHandler>(
                    parentHandler,
                    typeDeclaration,
                    (generator, typeDeclaration, createdElseClause) => generator.AppendEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, createdElseClause, CoreTypes.String));
        }

        if ((allowedTypes & CoreTypes.Boolean) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeBoolean(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IBooleanKeywordValidationHandler>(parentHandler, typeDeclaration);
        }

        if ((allowedTypes & CoreTypes.Null) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNull(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<INullKeywordValidationHandler>(parentHandler, typeDeclaration);
        }

        if ((allowedTypes & CoreTypes.Object) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeObject(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IObjectKeywordValidationHandler>(parentHandler, typeDeclaration);
        }

        if ((allowedTypes & CoreTypes.Array) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeArray(typeValidationHandler_tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                .AppendLineIndent("{")
                .PushIndent()
                    .ConditionallyAppend(allowedCoreTypeCount == 1, static c => c.AppendNoCollectorShortcutReturn())
                    .AppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendElseEvaluateCoreTypeKeywords<IArrayKeywordValidationHandler>(parentHandler, typeDeclaration);
        }

        return generator
            .ConditionallyAppend(allowedCoreTypeCount > 1, g => g.AppendNoCollectorNoMatchShortcutReturn())
            .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);
    }

    public static CodeGenerator AppendElseEvaluateCoreTypeKeywords<T>(
        this CodeGenerator generator,
        IKeywordValidationHandler parentHandler,
        TypeDeclaration typeDeclaration,
        Func<CodeGenerator, TypeDeclaration, bool, bool>? additionalWork = null)
        where T : ITypeSensitiveKeywordValidationHandler
    {
        bool createdElseClause = false;

        foreach (T keywordHandler in
                typeDeclaration
                    .OrderedValidationHandlers<T>(generator.LanguageProvider)
                    .Where(
                        h =>
                            h.ValidationHandlerPriority >= parentHandler.ValidationHandlerPriority &&
                            !parentHandler.Equals(h)))
        {

            // We cannot do this if there are other handlers in between the parent and this one.
            if (typeDeclaration.HasHigherPriorityHandler(generator.LanguageProvider, parentHandler, keywordHandler))
            {
                continue;
            }

            typeDeclaration.ExecuteValidationHandler(keywordHandler, k =>
            {
                if (!createdElseClause)
                {
                    generator
                        .BeginElseClause();
                    createdElseClause = true;
                }

                k.AppendValidationCode(generator, typeDeclaration, validateOnly: true);
            });
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

        return generator;
    }

    public static bool HasHigherPriorityHandler<T>(this TypeDeclaration typeDeclaration, ILanguageProvider languageProvider, IKeywordValidationHandler parentHandler, T keywordHandler)
        where T : IKeywordValidationHandler
    {
        return typeDeclaration
                        .OrderedValidationHandlers(languageProvider)
                        .Any(
                            h =>
                                !typeDeclaration.IsHandled(h) &&
                                h.ValidationHandlerPriority >= parentHandler.ValidationHandlerPriority &&
                                h.ValidationHandlerPriority < keywordHandler.ValidationHandlerPriority);
    }

    public static CodeGenerator BeginElseClause(this CodeGenerator generator)
    {
        return generator
        .AppendLineIndent("else")
        .AppendLineIndent("{")
        .PushIndent();
    }

    public static bool AppendEvaluateCoreTypeFormatKeywords(this CodeGenerator generator, IKeywordValidationHandler parentHandler, TypeDeclaration typeDeclaration, bool createdElseClause, CoreTypes coreTypes)
    {
        foreach (IFormatKeywordValidationHandler keywordHandler in
                typeDeclaration
                    .OrderedValidationHandlers<IFormatKeywordValidationHandler>(generator.LanguageProvider)
                    .Where(
                        h =>
                            h.ValidationHandlerPriority >= parentHandler.ValidationHandlerPriority &&
                            !parentHandler.Equals(h)))
        {

            // We cannot do this if there are other handlers in between the parent and this one.
            if (typeDeclaration.HasHigherPriorityHandler(generator.LanguageProvider, parentHandler, keywordHandler))
            {
                continue;
            }

            if (keywordHandler.HandlesCoreTypes(typeDeclaration, coreTypes))
            {
                typeDeclaration.ExecuteValidationHandler(keywordHandler, k =>
                {
                    if (!createdElseClause)
                    {
                        generator
                            .BeginElseClause();
                        createdElseClause = true;
                    }

                    keywordHandler.AppendValidationCode(generator, typeDeclaration, forCoreTypes: coreTypes, validateOnly: true);
                });
            }
        }

        return createdElseClause;
    }

    public static CodeGenerator AppendIgnoredCoreTypeStringFormatKeywords(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
    {
        return AppendIgnoredCoreTypeFormatKeywords(generator, typeDeclaration, ignoredMessageProviderName, CoreTypes.String);
    }

    public static CodeGenerator AppendIgnoredCoreTypeNumberFormatKeywords(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
    {
        return generator
            .AppendIgnoredCoreTypeFormatKeywords(typeDeclaration, ignoredMessageProviderName, CoreTypes.Number | CoreTypes.Integer);
    }

    public static CodeGenerator AppendIgnoredCoreTypeFormatKeywords(this CodeGenerator generator, TypeDeclaration typeDeclaration, string ignoredMessageProviderName, CoreTypes coreType)
    {
        IEnumerable<IFormatProviderKeyword> ignoredKeywords =
            typeDeclaration
                .Keywords()
                .OfType<IFormatProviderKeyword>();

        foreach (IFormatProviderKeyword keyword in ignoredKeywords)
        {
            if (((keyword.ImpliesCoreTypes(typeDeclaration) & coreType) != 0) &&
                typeDeclaration.AddIgnoredKeyword(keyword))
            {
                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
            }
        }

        return generator;
    }

    public static CodeGenerator AppendIgnoredCoreTypeKeywords<T>(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
            where T : IValidationKeyword
    {
        IEnumerable<T> keywordsToIgnore =
            typeDeclaration
                .Keywords()
                .OfType<T>();

        foreach (T keyword in keywordsToIgnore)
        {
            if (typeDeclaration.AddIgnoredKeyword(keyword))
            {
                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
            }
        }

        return generator;
    }
}
