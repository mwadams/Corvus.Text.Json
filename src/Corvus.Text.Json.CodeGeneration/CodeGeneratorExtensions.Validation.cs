// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generation extensions for JSON Schema related functionality.
/// </summary>
internal static partial class CodeGenerationExtensions
{
    /// <summary>
    /// Appends the code to shortcut the return from validation if there is no collector.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="contextName">The name to use for the context (defaults to 'context').</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendNoCollectorShortcutReturn(this CodeGenerator generator, string contextName = "context")
    {
        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (!", contextName, ".HasCollector)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("return;")
            .PopIndent()
            .AppendLineIndent("}");
    }

    /// <summary>
    /// Prepend validation setup code for children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator PrependChildValidationSetup(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority <= parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationSetup(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Append validation setup code for children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendChildValidationSetup(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority > parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationSetup(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Prepend validation code for appropriate children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator PrependChildValidationCode(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority <= parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationCode(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Append validation code for appropriate children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendChildValidationCode(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority > parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationCode(generator, typeDeclaration);
        }

        return generator;
    }
}
