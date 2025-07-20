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
    /// Gets the expected <see cref="JsonValueKind"/> for instances
    /// that support the given format.
    /// </summary>
    /// <param name="format">The format for which to get the value kind.</param>
    /// <returns>The expected <see cref="JsonValueKind"/>, or <see langword="null"/>
    /// if the format was not handled by this instance.</returns>
    JsonValueKind? GetExpectedValueKind(string format);

    /// <summary>
    /// Append format-specific expressions in the body of an <c>Equals&lt;T&gt;</c> method where the comparison values are <c>this</c> and <c>other</c>.
    /// </summary>
    /// <param name="generator">The generator to which to append the format assertion.</param>
    /// <param name="typeDeclaration">The type declaration for which to append equals expressions.</param>
    /// <param name="format">The format for which to append constructors.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatEqualsTBody(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific public static properties to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format properties.</param>
    /// <param name="typeDeclaration">The type declaration for which to append properties.</param>
    /// <param name="format">The format for which to append properties.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPublicStaticProperties(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific public properties to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format properties.</param>
    /// <param name="typeDeclaration">The type declaration for which to append properties.</param>
    /// <param name="format">The format for which to append properties.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPublicProperties(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific conversion operators for the <c>Source</c> to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="seenConversionOperators">Conversion operators that have already been generated, identified by a unique string.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatSourceConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators);

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
    /// Append format-specific conversion operators to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific public static methods to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to append methods.</param>
    /// <param name="format">The format for which to append methods.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPublicStaticMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific public methods to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to append methods.</param>
    /// <param name="format">The format for which to append methods.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPublicMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific private static methods to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to append methods.</param>
    /// <param name="format">The format for which to append methods.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPrivateStaticMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append format-specific private methods to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the format methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to append methods.</param>
    /// <param name="format">The format for which to append methods.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatPrivateMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format);

    /// <summary>
    /// Append a format-specific constant value.
    /// </summary>
    /// <param name="generator">The generator to which to append the constant value.</param>
    /// <param name="keyword">The keyword producing the constant.</param>
    /// <param name="format">The format for which to append the constant value.</param>
    /// <param name="fieldName">The field name for the constant.</param>
    /// <param name="constantValue">The constant value as a <see cref="JsonElement"/>.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    bool AppendFormatConstant(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string format, string fieldName, JsonElement constantValue);
}
