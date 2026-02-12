// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

internal interface IChildObjectPropertyValidationHandler2 : IChildValidationHandler
{
    /// <summary>
    /// Prepend validation code for an individual object property.
    /// </summary>
    /// <param name="generator">The code generator to which to append the validation code.</param>
    /// <param name="typeDeclaration">The type declaration for which to append the validation code.</param>
    /// <returns>A reference to the generator after the operation has completed.</returns>
    CodeGenerator PrependObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration);

    /// <summary>
    /// Append validation code for an individual object property.
    /// </summary>
    /// <param name="generator">The code generator to which to append the validation code.</param>
    /// <param name="typeDeclaration">The type declaration for which to append the validation code.</param>
    /// <returns>A reference to the generator after the operation has completed.</returns>
    CodeGenerator AppendObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration);

    /// <summary>
    /// Append validation code to perform setup work at the start of property validation.
    /// </summary>
    /// <param name="generator">The code generator to which to append the validation code.</param>
    /// <param name="typeDeclaration">The type declaration for which to append the validation code.</param>
    /// <returns>A reference to the generator after the operation has completed.</returns>
    CodeGenerator AppendObjectPropertyValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration);
}
