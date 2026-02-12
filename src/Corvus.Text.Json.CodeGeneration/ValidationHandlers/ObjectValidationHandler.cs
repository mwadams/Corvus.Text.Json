// <copyright file="FormatValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;
using Corvus.Text.Json.CodeGeneration.ValidationHandlers.StringChildHandlers;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

/// <summary>
/// A validation handler for <see cref="IObjectValidationKeyword"/> capability.
/// </summary>
internal sealed class ObjectValidationHandler : TypeSensitiveKeywordValidationHandlerBase, IObjectKeywordValidationHandler
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
             .PrependChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority)
             .AppendObjectValidationSetup()
             .AppendChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority);
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
    public override bool HandlesKeyword(IKeyword keyword)
    {
        return keyword is IObjectValidationKeyword;
    }

    private static ObjectValidationHandler CreateDefault()
    {
        var result = new ObjectValidationHandler();
        result
            .RegisterChildHandlers(
                PropertyCountValidationHandler.Instance
                ////DependentRequiredValidationHandler.Instance,
                ////DependentSchemasValidationHandler.Instance,
                ////PropertyNamesValidationHandler.Instance,
                ////PatternPropertiesValidationHandler.Instance,
                ////PropertiesValidationHandler.Instance,
                ////RequiredValidationHandler.Instance
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

        generator
            .PrependChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        int requiredPropertyCount = typeDeclaration.ExplicitRequiredProperties().Count;

        int requiredPropertyIntCount = (int)Math.Ceiling(requiredPropertyCount / 32.0);
        bool rentedRequiredPropertyCountArray = requiredPropertyIntCount >= 256;
        if (requiredPropertyIntCount > 0)
        {
            generator
                .ReserveName("objectValidation_seenItems")
                .ReserveName("objectValidation_seenItemsByteArray")
                .ConditionallyAppend(!rentedRequiredPropertyCountArray, g => g.AppendLineIndent("Span<int> objectValidation_seenItems = stackalloc int[", requiredPropertyCount.ToString(), "];")
                .ConditionallyAppend(rentedRequiredPropertyCountArray, g => {
                    return g
                        .AppendLineIndent("int[]? objectValidation_seenItemsByteArray = ArrayPool<int>.Shared.Rent(", requiredPropertyCount.ToString(), ");")
                        .AppendLineIndent("Span<int> objectValidation_seenItems = objectValidation_seenItemsByteArray.Slice(0, requiredPropertyCount);");
                }));
        }

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
                .AppendLineIndent("while (enumerator.MoveNext())")
                .AppendLineIndent("{")
                .PushIndent();

            if (childHandlers
                    .OfType<IChildObjectPropertyValidationHandler>()
                    .Any(child => child.RequiresPropertyNameAsString(typeDeclaration)))
            {
                generator
                    .ReserveName("objectValidation_currentIndex")
                    .ReserveName("objectValidation_rawPropertyName")
                    .AppendLineIndent("int objectValidation_currentIndex = objectValidation_enumerator.CurrentIndex;")
                    .AppendLineIndent("ReadOnlySpan<byte> propertyName = parentDocument.GetPropertyNameRaw(objectValidation_rawPropertyName);");
            }

            generator
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
