// <copyright file="FormatValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

/// <summary>
/// A validation handler for <see cref="ITernaryIfValidationKeyword"/> capability.
/// </summary>
internal sealed class TernaryIfValidationHandler : KeywordValidationHandlerBase
{
    private TernaryIfValidationHandler()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="TernaryIfValidationHandler"/>.
    /// </summary>
    public static TernaryIfValidationHandler Instance { get; } = CreateDefault();

    /// <inheritdoc/>
    public override uint ValidationHandlerPriority => ValidationPriorities.Composition;

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        // If we require string value validation, then we need to run the type validation after all the string value validation handlers have run, so that we can ignore the type validation if any of those handlers are present.
        return generator
             .PrependChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority)
             .AppendTernaryIfValidationSetup()
             .AppendChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority);
    }

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        IReadOnlyCollection<IChildValidationHandler> childHandlers = ChildHandlers;

        generator
            .AppendTernaryIfValidation(this, typeDeclaration, childHandlers, ValidationHandlerPriority);

        return generator;
    }

    /// <inheritdoc/>
    public override bool HandlesKeyword(IKeyword keyword)
    {
        return keyword is IOneOfValidationKeyword;
    }

    private static TernaryIfValidationHandler CreateDefault()
    {
        return new TernaryIfValidationHandler();
    }
}

file static class TernaryIfValidationHandlerExtensions
{
    public static CodeGenerator AppendTernaryIfValidationSetup(this CodeGenerator generator)
    {
        return generator;
    }

    public static CodeGenerator AppendTernaryIfValidation(
        this CodeGenerator generator,
        IKeywordValidationHandler parentHandler,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> childHandlers,
        uint validationPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        generator
            .PrependChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        ////if (typeDeclaration.IfSubschemaType() is SingleSubschemaKeywordTypeDeclaration ifType)
        ////{
        ////    AppendIf(generator, ifType, ifContext);

        ////    if (typeDeclaration.ThenSubschemaType() is SingleSubschemaKeywordTypeDeclaration thenType)
        ////    {
        ////        AppendThen(generator, thenType, ifContext);
        ////    }

        ////    if (typeDeclaration.ElseSubschemaType() is SingleSubschemaKeywordTypeDeclaration elseType)
        ////    {
        ////        AppendElse(generator, elseType, ifContext);
        ////    }
        ////}

        generator
            .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        return generator;
    }
}
