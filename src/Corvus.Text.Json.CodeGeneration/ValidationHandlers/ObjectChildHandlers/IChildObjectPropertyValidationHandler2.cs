// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

internal interface IChildObjectPropertyValidationHandler2 : IChildObjectPropertyValidationHandler
{
    /// <summary>
    /// Indicates whether the object property handler will emit code for the given type declaration.
    /// </summary>
    /// <param name="typeDeclaration"></param>
    /// <returns></returns>
    bool WillEmitCodeFor(TypeDeclaration typeDeclaration);
}
