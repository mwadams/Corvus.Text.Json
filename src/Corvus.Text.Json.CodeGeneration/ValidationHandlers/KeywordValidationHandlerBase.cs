// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

internal abstract class KeywordValidationHandlerBase : IKeywordValidationHandler
{
    private readonly ChildValidationHandlerRegistry _childHandlers = new();

    /// <inheritdoc/>
    public abstract uint ValidationHandlerPriority { get; }

    /// <summary>
    /// Gets the collection of registered child handlers.
    /// </summary>
    protected IReadOnlyCollection<IChildValidationHandler> ChildHandlers => _childHandlers.RegisteredHandlers;

    /// <inheritdoc/>
    public abstract CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration);

    /// <inheritdoc/>
    public abstract bool HandlesKeyword(IKeyword keyword);

    /// <summary>
    /// Append the validation code for the keyword.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration containing the keyword.</param>
    /// <returns>The code generator, after the operation has completed.</returns>
    public abstract CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration);

    /// <summary>
    /// Registers child handlers for the validation handler type.
    /// </summary>
    /// <param name="children">The child handlers.</param>
    /// <returns>An instance of the parent <see cref="IKeywordValidationHandler"/> once the operation has completed.</returns>
    /// <remarks>
    /// The registered <see cref="IChildValidationHandler"/> will typically have their setup and validation injected
    /// either before or after the code emitted by <see cref="AppendValidationSetup(CodeGenerator, TypeDeclaration)"/>
    /// and <see cref="AppendValidationCode(CodeGenerator, TypeDeclaration)"/> (respectively), depending on their relative
    /// <see cref="IValidationHandler.ValidationHandlerPriority"/> with their parent.
    /// </remarks>
    /// <inheritdoc/>
    public IKeywordValidationHandler RegisterChildHandlers(params IChildValidationHandler[] children)
    {
        _childHandlers.RegisterValidationHandlers(children);
        return this;
    }
}
