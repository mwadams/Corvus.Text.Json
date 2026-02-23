// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ArrayChildHandlers;

internal interface IChildArrayItemValidationHandler2 : IChildArrayItemValidationHandler
{
    /// <summary>
    /// Indicates whether the array item handler will emit code for the given type declaration.
    /// </summary>
    /// <param name="typeDeclaration"></param>
    /// <returns></returns>
    bool WillEmitCodeFor(TypeDeclaration typeDeclaration);

    /// <summary>
    /// Gets the priority for the item handler, as opposed to the outer
    /// validation handler.
    /// </summary>
    uint ItemHandlerPriority { get; }
}
