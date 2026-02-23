// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers;

internal interface IJsonSchemaClassSetup
{
    /// <summary>
    /// Append code which can add members to the JsonSchema class.
    /// </summary>
    /// <param name="generator">The code generator to which to append the validation code.</param>
    /// <param name="typeDeclaration">The type declaration for which to append the validation code.</param>
    /// <returns>A reference to the generator after the operation has completed.</returns>
    CodeGenerator AppendJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration);
}
