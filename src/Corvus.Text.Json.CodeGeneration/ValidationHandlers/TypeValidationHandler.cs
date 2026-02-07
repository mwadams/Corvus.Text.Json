// <copyright file="TypeValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.Keywords;
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
        // If we require string value validation, then we need to run the type validation after all the string value validation handlers have run, so that we can ignore the type validation if any of those handlers are present.
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
        return generator;
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

        if (allowedCoreTypeCount == 1)
        {
            if ((allowedTypes & (CoreTypes.Integer | CoreTypes.Number)) != 0)
            {
                bool isInteger = (allowedTypes & CoreTypes.Integer) != 0;
                string ignoredMessageProviderName = isInteger ? "JsonSchemaEvaluation.IgnoredNotTypeInteger" : "JsonSchemaEvaluation.IgnoredNotTypeNumber";
                generator
                    .AppendSeparatorLine();

                if (isInteger)
                {
                    generator
                        .AppendNormalizedJsonNumberIfNotAppended(typeDeclaration)
                        .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeInteger(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, exponent, ref context))");
                }
                else
                {
                    generator
                        .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNumber(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))");
                }


                generator
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, ignoredMessageProviderName)
                        .AppendIgnoredCoreTypeNumberFormatKeywords(typeDeclaration, ignoredMessageProviderName)
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<INumberKeywordValidationHandler>(
                        parentHandler,
                        typeDeclaration,
                        isInteger ? CoreTypes.Integer : CoreTypes.Number,
                        (generator, typeDeclaration, createdElseClause) => generator.AppendElseEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, createdElseClause, isInteger ? CoreTypes.Integer : CoreTypes.Number));
            }
            else if ((allowedTypes & CoreTypes.String) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeString(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString")
                        .AppendIgnoredCoreTypeStringFormatKeywords(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<IStringKeywordValidationHandler>(
                        parentHandler,
                        typeDeclaration,
                        CoreTypes.String,
                        (generator, typeDeclaration, createdElseClause) => generator.AppendElseEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, createdElseClause, CoreTypes.String));
            }
            else if ((allowedTypes & CoreTypes.Boolean) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeBoolean(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<IBooleanKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Boolean);
            }
            else if ((allowedTypes & CoreTypes.Null) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeNull(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<INullKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Null);
            }
            else if ((allowedTypes & CoreTypes.Object) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeObject(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<IObjectKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Object);
            }
            else if ((allowedTypes & CoreTypes.Array) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if (!JsonSchemaEvaluation.MatchTypeArray(tokenType,", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ref context))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNoCollectorShortcutReturn()
                        .AppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendElseEvaluateCoreTypeKeywords<IArrayKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Array);
            }
        }
        else
        {
            StringBuilder allowedTypesBuilder = new();

            // More than one core type
            generator
                .ReserveName("typeValidationHandler_foundType)")
                .AppendLineIndent("bool typeValidationHandler_foundType = false;")
                .AppendSeparatorLine();

            bool hasTypes = false;

            if ((allowedTypes & CoreTypes.Array) != 0)
            {
                allowedTypesBuilder.Append("[\"array\"");
                generator
                    .AppendLineIndent("if (tokenType == JsonTokenType.StartArray)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<IArrayKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Array)
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.Object) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"object\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType == JsonTokenType.StartObject)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<IObjectKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Object)
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.Null) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"null\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType == JsonTokenType.Null)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<INullKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Null)
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.Boolean) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"boolean\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType is JsonTokenType.True or JsonTokenType.False)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<IBooleanKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Boolean)
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.Number) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"number\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType == JsonTokenType.Number)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<INumberKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Number,
                            (generator, typeDeclaration) => generator.AppendEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, CoreTypes.Number))
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.Integer) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"integer\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType == JsonTokenType.Number)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendNormalizedJsonNumberIfNotAppended(typeDeclaration)
                        .AppendLineIndent("if (JsonElementHelpers.IsIntegerNormalizedJsonNumber(exponent))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("typeValidationHandler_foundType = true;")
                            .AppendEvaluateCoreTypeKeywords<INumberKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.Integer,
                            (generator, typeDeclaration) => generator.AppendEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, CoreTypes.Integer))
                        .PopIndent()
                        .AppendLineIndent("}")
                        .PopNormalizedJsonNumberIfAppendedInScope(typeDeclaration)
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            if ((allowedTypes & CoreTypes.String) != 0)
            {
                AppendArrayStartOrSeparator(allowedTypesBuilder, hasTypes);
                allowedTypesBuilder.Append("\"string\"");

                generator
                    .ConditionallyAppend(hasTypes, g => g.AppendIndent("else "))
                    .ConditionallyAppend(!hasTypes, g => g.AppendIndent(string.Empty))
                    .AppendLine("if (tokenType == JsonTokenType.String)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("typeValidationHandler_foundType = true;")
                        .AppendEvaluateCoreTypeKeywords<IStringKeywordValidationHandler>(parentHandler, typeDeclaration, CoreTypes.String,
                            (generator, typeDeclaration) => generator.AppendEvaluateCoreTypeFormatKeywords(parentHandler, typeDeclaration, CoreTypes.String))
                    .PopIndent()
                    .AppendLineIndent("}");

                hasTypes = true;
            }

            allowedTypesBuilder.Append(']');

            generator
                .AppendSeparatorLine()
                .AppendLineIndent(
                    "context.EvaluatedKeyword(typeValidationHandler_foundType, static (buffer, out written) => JsonSchemaEvaluation.ExpectedType(",
                    SymbolDisplay.FormatLiteral(allowedTypesBuilder.ToString(), true),
                    "u8, buffer, out written), ",
                    SymbolDisplay.FormatLiteral(keyword.Keyword, true),
                    "u8);");
        }

        if (childHandlers.Count > 0)
        {
            return generator
                .ConditionallyAppend(allowedCoreTypeCount > 1, g => g.AppendNoCollectorNoMatchShortcutReturn())
                .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);
        }

        return generator;

        static void AppendArrayStartOrSeparator(StringBuilder allowedTypesBuilder, bool hasTypes)
        {
            if (hasTypes)
            {
                allowedTypesBuilder.Append(", ");
            }
            else
            {
                allowedTypesBuilder.Append('[');

            }
        }
    }

    public static CodeGenerator AppendElseEvaluateCoreTypeKeywords<T>(
        this CodeGenerator generator,
        IKeywordValidationHandler parentHandler,
        TypeDeclaration typeDeclaration,
        CoreTypes coreType,
        Func<CodeGenerator, TypeDeclaration, bool, bool>? additionalWork = null)
        where T : ITypeSensitiveKeywordValidationHandler
    {
        bool createdElseClause = false;

        AppendIgnoredTypes(generator, typeDeclaration, coreType, (_, _) =>
        {
            generator
                .BeginElseClause();
            createdElseClause = true;
        });


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

    public static CodeGenerator AppendEvaluateCoreTypeKeywords<T>(
    this CodeGenerator generator,
    IKeywordValidationHandler parentHandler,
    TypeDeclaration typeDeclaration,
    CoreTypes coreType,
    Action<CodeGenerator, TypeDeclaration>? additionalWork = null)
    where T : ITypeSensitiveKeywordValidationHandler
    {
        AppendIgnoredTypes(generator, typeDeclaration, coreType);

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
                k.AppendValidationCode(generator, typeDeclaration, validateOnly: true);
            });
        }

        if (additionalWork is not null)
        {
            additionalWork(generator, typeDeclaration);
        }

        return generator;
    }

    private static bool AppendIgnoredTypes(CodeGenerator generator, TypeDeclaration typeDeclaration, CoreTypes coreType, Action<CodeGenerator, TypeDeclaration>? preAppendAction = null)
    {
        bool appended = false;
        switch (coreType)
        {
            case CoreTypes.String:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNumber", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended);
                break;

            case CoreTypes.Number:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended);
                break;

            case CoreTypes.Integer:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended);
                break;

            case CoreTypes.Boolean:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNumber", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended);
                break;

            case CoreTypes.Null:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNumber", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended);
                break;

            case CoreTypes.Object:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNumber", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IArrayValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeArray", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended);
                break;

            case CoreTypes.Array:
                generator
                    .TryAppendIgnoredCoreTypeKeywords<IStringValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeString", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INullValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNull", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<INumberValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeNumber", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeObject", preAppendAction, ref appended)
                    .TryAppendIgnoredCoreTypeKeywords<IBooleanValidationKeyword>(typeDeclaration, "JsonSchemaEvaluation.IgnoredNotTypeBoolean", preAppendAction, ref appended);
                break;

            default:
                throw new InvalidOperationException();
        }

        return appended;
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

    public static bool AppendElseEvaluateCoreTypeFormatKeywords(this CodeGenerator generator, IKeywordValidationHandler parentHandler, TypeDeclaration typeDeclaration, bool createdElseClause, CoreTypes coreTypes)
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

    public static CodeGenerator AppendEvaluateCoreTypeFormatKeywords(this CodeGenerator generator, IKeywordValidationHandler parentHandler, TypeDeclaration typeDeclaration, CoreTypes coreTypes)
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
                    keywordHandler.AppendValidationCode(generator, typeDeclaration, forCoreTypes: coreTypes, validateOnly: true);
                });
            }
        }

        return generator;
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

    public static CodeGenerator TryAppendIgnoredCoreTypeKeywords<T>(
    this CodeGenerator generator,
    TypeDeclaration typeDeclaration,
    string ignoredMessageProviderName,
    Action<CodeGenerator, TypeDeclaration>? preAppendAction,
    ref bool appended)
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
                if (!appended)
                {
                    preAppendAction?.Invoke(generator, typeDeclaration);
                }

                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
                appended |= true;
            }
        }

        return generator;
    }
}
