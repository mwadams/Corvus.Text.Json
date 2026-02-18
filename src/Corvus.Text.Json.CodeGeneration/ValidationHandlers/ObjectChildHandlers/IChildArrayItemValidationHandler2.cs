// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
}
