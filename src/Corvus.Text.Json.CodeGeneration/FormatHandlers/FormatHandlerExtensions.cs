// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Text.Json;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

internal static class FormatHandlerExtensions
{
    /// <summary>
    /// Append format-specific constructors for the <c>Source</c>.
    /// </summary>
    /// <typeparam name="T">The type of the format handler.</typeparam>
    /// <param name="handlers">The handlers which may append expressions.</param>
    /// <param name="generator">The generator to which to append the format expressions.</param>
    /// <param name="typeDeclaration">The type declaration for which to append expressions.</param>
    /// <param name="format">The format for which to append expressions.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    public static bool AppendFormatSourceConstructors<T>(this IEnumerable<T> handlers, CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConstructorParameters)
        where T : notnull, IFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (generator.IsCancellationRequested)
            {
                return false;
            }

            if (handler.AppendFormatSourceConstructors(generator, typeDeclaration, format, seenConstructorParameters))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Append format-specific conversion operators for the <c>Source</c>.
    /// </summary>
    /// <typeparam name="T">The type of the format handler.</typeparam>
    /// <param name="handlers">The handlers which may append expressions.</param>
    /// <param name="generator">The generator to which to append the format expressions.</param>
    /// <param name="typeDeclaration">The type declaration for which to append expressions.</param>
    /// <param name="format">The format for which to append expressions.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    public static bool AppendFormatSourceConversionOperators<T>(this IEnumerable<T> handlers, CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators)
        where T : notnull, IFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (generator.IsCancellationRequested)
            {
                return false;
            }

            if (handler.AppendFormatSourceConversionOperators(generator, typeDeclaration, format, seenConversionOperators))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the format requires a simple types backing
    /// </summary>
    /// <typeparam name="T">The type of the format handler.</typeparam>
    /// <param name="handlers">The handlers which may determine whether the format requires a simple types backing.</param>
    /// <param name="format">The format for which to determine whether it requires a simple types backing.</param>
    /// <param name="requiresSimpleType"><see langword="true"/> if the format requires the fixed-size simple types backing.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    public static bool RequiresSimpleTypesBacking<T>(this IEnumerable<T> handlers, string format, out bool requiresSimpleType)
        where T : notnull, IStringFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (handler.RequiresSimpleTypesBacking(format, out requiresSimpleType))
            {
                return true;
            }
        }

        requiresSimpleType = false;
        return false;
    }

    /// <summary>
    /// Get the preferred numeric type for a format.
    /// </summary>
    /// <typeparam name="T">The type of the format handler.</typeparam>
    /// <param name="handlers">The handlers which may determine the preferred numeric type.</param>
    /// <param name="format">The format for which to determine the preferred numeric type.</param>
    /// <param name="typeName">The name of the preferred numeric type.</param>
    /// <param name="isNetOnly"><see langword="true"/> if the format is for .NET only (not available on netstandard2.0).</param>
    /// <param name="netStandardFallback">The name of the netstandard fallback type, if <paramref name="isNetOnly"/> is <see langword="true"/>.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    public static bool TryGetNumericTypeName<T>(this IEnumerable<T> handlers, string format, [NotNullWhen(true)] out string? typeName, out bool isNetOnly, out string? netStandardFallback)
        where T : notnull, INumberFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (handler.TryGetNumericTypeName(format, out typeName, out isNetOnly, out netStandardFallback))
            {
                return true;
            }
        }

        typeName = null;
        isNetOnly = false;
        netStandardFallback = null;
        return false;
    }

    public static bool AppendFormatAssertion<T>(
        this IEnumerable<T> handlers,
        CodeGenerator generator,
        string format,
        string formatKeywordProviderExpression,
        string valueIdentifier,
        string validationContextIdentifier)
        where T : notnull, IStringFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (handler.AppendFormatAssertion(generator, format, formatKeywordProviderExpression, valueIdentifier, validationContextIdentifier))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AppendFormatAssertion<T>(
        this IEnumerable<T> handlers,
        CodeGenerator generator,
        string format,
        string formatKeywordProviderExpression,
        string isNegativeIdentifier,
        string integralIdentifier,
        string fractionalIdentifier,
        string exponentIdentifier,
        string validationContextIdentifier)
        where T : notnull, INumberFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (handler.AppendFormatAssertion(
                    generator,
                    format,
                    formatKeywordProviderExpression,
                    isNegativeIdentifier,
                    integralIdentifier,
                    fractionalIdentifier,
                    exponentIdentifier,
                    validationContextIdentifier))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Gets the expected <see cref="JsonTokenType"/> for instances
    /// that support the given format.
    /// </summary>
    /// <typeparam name="T">The type of the format handler.</typeparam>
    /// <param name="handlers">The handlers to test.</param>
    /// <param name="format">The format for which to get the value kind.</param>
    /// <returns>The expected <see cref="JsonTokenType"/>, or <see langword="null"/>
    /// if no value kind is expected for the format.</returns>
    public static JsonTokenType? GetExpectedTokenType<T>(this IEnumerable<T> handlers, string format)
        where T : notnull, IFormatHandler
    {
        foreach (T handler in handlers)
        {
            if (handler.GetExpectedTokenType(format) is JsonTokenType result)
            {
                return result;
            }
        }

        return null;
    }
}
