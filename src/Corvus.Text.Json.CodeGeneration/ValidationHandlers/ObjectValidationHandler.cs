// <copyright file="FormatValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

/// <summary>
/// A validation handler for <see cref="IObjectValidationKeyword"/> capability.
/// </summary>
internal sealed class ObjectValidationHandler : TypeSensitiveKeywordValidationHandlerBase, IObjectKeywordValidationHandler, IJsonSchemaClassSetup
{
    private ObjectValidationHandler()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="ObjectValidationHandler"/>.
    /// </summary>
    public static ObjectValidationHandler Instance { get; } = CreateDefault();

    /// <inheritdoc/>
    public override uint ValidationHandlerPriority => ValidationPriorities.AfterComposition;

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator
             .AppendObjectValidationSetup();
    }

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration, bool validateOnly)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        IReadOnlyCollection<IChildValidationHandler> childHandlers = ChildHandlers;

        generator
            .AppendObjectValidation(this, typeDeclaration, childHandlers, ValidationHandlerPriority, validateOnly);

        return generator;
    }

    /// <inheritdoc/>
    public CodeGenerator AppendJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        foreach (IChildValidationHandler childHandler in ChildHandlers)
        {
            if (childHandler is IJsonSchemaClassSetup classSetup)
            {
                classSetup.AppendJsonSchemaClassSetup(generator, typeDeclaration);
            }
        }

        return generator;
    }

    /// <inheritdoc/>
    public override bool HandlesKeyword(IKeyword keyword)
    {
        return keyword is IObjectValidationKeyword;
    }

    private static ObjectValidationHandler CreateDefault()
    {
        var result = new ObjectValidationHandler();
        result
            .RegisterChildHandlers(
                PropertyCountValidationHandler.Instance,
                PropertiesValidationHandler.Instance,
                PropertyNamesValidationHandler.Instance,
                PatternPropertiesValidationHandler.Instance,
                UnevaluatedPropertyValidationHandler.Instance
                ////DependentRequiredValidationHandler.Instance,
                );
        return result;
    }
}

file static class ObjectValidationHandlerExtensions
{
    public static CodeGenerator AppendObjectValidationSetup(this CodeGenerator generator)
    {
        return generator;
    }

    public static CodeGenerator AppendObjectValidation(
        this CodeGenerator generator,
        IKeywordValidationHandler parentHandler,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> childHandlers,
        uint validationPriority,
        bool validateOnly)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (!validateOnly)
        {
            generator
                .AppendSeparatorLine()
                .AppendStartTokenTypeCheck(typeDeclaration)
                .PushMemberScope("tokenTypeCheck", ScopeType.Method);

        }

        generator
            .AppendSeparatorLine();

        foreach(IChildValidationHandler child in childHandlers)
        {
            child.AppendValidationSetup(generator, typeDeclaration);
        }

        generator
            .PrependChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        if (typeDeclaration.RequiresObjectEnumeration() ||
            typeDeclaration.RequiresPropertyCount())
        {
            generator.ReserveName("objectValidation_propertyCount");

            if (typeDeclaration.RequiresObjectEnumeration())
            {
                generator.AppendLineIndent("int objectValidation_propertyCount = 0;");
            }
            else
            {
                generator.AppendLineIndent("int objectValidation_propertyCount = parentDocument.GetPropertyCount(parentIndex);");
            }
        }

        if (typeDeclaration.RequiresObjectEnumeration())
        {
            generator
                .AppendSeparatorLine()
                .ReserveName("objectValidation_enumerator")
                .AppendLineIndent("var objectValidation_enumerator = new ObjectEnumerator(parentDocument, parentIndex);")
                .AppendLineIndent("while (objectValidation_enumerator.MoveNext())")
                .AppendLineIndent("{")
                .PushIndent()
                    .ReserveName("objectValidation_currentIndex")
                    .AppendLineIndent("int objectValidation_currentIndex = objectValidation_enumerator.CurrentIndex;");

            if (childHandlers
                    .OfType<IChildObjectPropertyValidationHandler>()
                    .Any(child => child.RequiresPropertyNameAsString(typeDeclaration)))
            {
                generator
                    .ReserveName("objectValidation_unescapedPropertyName")
                    .AppendLineIndent("using UnescapedUtf8JsonString objectValidation_unescapedPropertyName = parentDocument.GetPropertyNameUnescaped(objectValidation_currentIndex);");
            }

            foreach (IChildObjectPropertyValidationHandler child in childHandlers.OfType<IChildObjectPropertyValidationHandler>())
            {
                child.AppendObjectPropertyValidationCode(generator, typeDeclaration);
            }

            generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("objectValidation_propertyCount++;")
                .PopIndent()
                .AppendLineIndent("}");
        }

        generator
            .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        if (!validateOnly)
        {
            // We only pop if we were in our own scope
            generator
                .PopMemberScope()
                .AppendEndTokenTypeCheck(typeDeclaration);
        }

        return generator;
    }

    private static CodeGenerator AppendStartTokenTypeCheck(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (tokenType == JsonTokenType.StartObject)")
            .AppendLineIndent("{")
            .PushIndent();
    }

    private static CodeGenerator AppendEndTokenTypeCheck(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        generator
            .PopIndent()
            .AppendLineIndent("}");

        bool appended = false;

        generator
            .TryAppendIgnoredCoreTypeKeywords<IObjectValidationKeyword>(
                typeDeclaration,
                "JsonSchemaEvaluation.IgnoredNotTypeObject",
                static (g, _) =>
                {
                    g
                        .AppendLineIndent("else")
                        .AppendLineIndent("{")
                        .PushIndent();
                },
                ref appended);

        if (appended)
        {
            generator
                .PopIndent()
                .AppendLineIndent("}");
        }
        return generator;
    }
}
