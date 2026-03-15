// <copyright file="FormatValidationHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.ValidationHandlers.OneOfChildHandlers;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

/// <summary>
/// A validation handler for <see cref="ICompositionOneOfValidationKeyword"/> capability.
/// </summary>
internal sealed class CompositionOneOfValidationHandler : KeywordValidationHandlerBase
{
    private CompositionOneOfValidationHandler()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="CompositionOneOfValidationHandler"/>.
    /// </summary>
    public static CompositionOneOfValidationHandler Instance { get; } = CreateDefault();

    /// <inheritdoc/>
    public override uint ValidationHandlerPriority => ValidationPriorities.Composition;

    /// <inheritdoc/>
    public override CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        // If we require string value validation, then we need to run the type validation after all the string value validation handlers have run, so that we can ignore the type validation if any of those handlers are present.
        return generator
             .PrependChildValidationSetup(typeDeclaration, ChildHandlers, ValidationHandlerPriority)
             .AppendCompositionOneOfValidationSetup()
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
            .AppendCompositionOneOfValidation(this, typeDeclaration, childHandlers, ValidationHandlerPriority);

        return generator;
    }

    /// <inheritdoc/>
    public override bool HandlesKeyword(IKeyword keyword)
    {
        return keyword is IOneOfValidationKeyword;
    }

    private static CompositionOneOfValidationHandler CreateDefault()
    {
        var result = new CompositionOneOfValidationHandler();
        result
            .RegisterChildHandlers(
                OneOfSubschemaValidationHandler.Instance);

        return result;
    }
}

file static class CompositionOneOfValidationHandlerExtensions
{
    public static CodeGenerator AppendCompositionOneOfValidationSetup(this CodeGenerator generator)
    {
        return generator;
    }

    public static CodeGenerator AppendCompositionOneOfValidation(
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
            .PrependChildValidationCode(typeDeclaration, childHandlers, validationPriority)
            .AppendChildValidationCode(typeDeclaration, childHandlers, validationPriority);

        return generator;
    }
}