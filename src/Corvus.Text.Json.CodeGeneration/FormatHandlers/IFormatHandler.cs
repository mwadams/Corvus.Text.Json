// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Text.Json;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Support for well-known format types.
/// </summary>
public interface IFormatHandler
{
    /// <summary>
    /// Gets the priority of the handler.
    /// </summary>
    /// <remarks>
    /// Handlers will be executed in priority order.
    /// </remarks>
    uint Priority { get; }

    /// <summary>
    /// Append format-specific conversion operators to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <param name="seenConversionOperators">Conversion operators that have already been generated, identified by a unique string.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators);

    /// <summary>
    /// Append format-specific constructors for the <c>Source</c> to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <param name="seenConstructorParameters">Constructors that have already been generated, identified by a unique string.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    /// <remarks>
    /// Typically, the <paramref name="seenConstructorParameters"/> would be a space separated list of the appropriately
    /// qualified names of the parameter types.
    /// </remarks>
    bool AppendFormatSourceConstructors(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConstructorParameters);

    /// <summary>
    /// Append format-specific conversion operators for the <c>Source</c> to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <param name="seenConversionOperators">Conversion operators that have already been generated, identified by a unique string.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatSourceConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators);

    /// <summary>
    /// Gets the expected <see cref="JsonTokenType"/> for instances
    /// that support the given format.
    /// </summary>
    /// <param name="format">The format for which to get the value kind.</param>
    /// <returns>The expected <see cref="JsonTokenType"/>, or <see langword="null"/>
    /// if the format was not handled by this instance.</returns>
    JsonTokenType? GetExpectedTokenType(string format);
}
