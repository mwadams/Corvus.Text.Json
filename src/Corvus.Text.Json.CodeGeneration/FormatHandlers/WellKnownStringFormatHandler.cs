// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using System.Collections.Generic;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Handlers for well-known string formats.
/// </summary>
public class WellKnownStringFormatHandler : IStringFormatHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="WellKnownStringFormatHandler"/>.
    /// </summary>
    public static WellKnownStringFormatHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint Priority => 100_000;

    /// <inheritdoc/>
    public bool AppendFormatAssertion(CodeGenerator generator, string format, string formatKeywordProviderExpression, string valueIdentifier, string validationContextIdentifier)
    {
        switch (format)
        {
            case "date":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchDate(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "date-time":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchDateTime(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "time":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchTime(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "duration":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchDuration(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "email":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchEmail(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "idn-email":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIdnEmail(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "hostname":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchHostname(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "idn-hostname":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIdnHostname(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "ipv4":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIPV4(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "ipv6":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIPV6(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "uuid":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchUuid(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "uri":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchUri(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "uri-template":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchUriTemplate(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "uri-reference":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchUriReference(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "iri":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIri(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "iri-reference":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchIriReference(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "json-pointer":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchJsonPointer(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "relative-json-pointer":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchRelativeJsonPointer(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "regex":
                generator.AppendIndent(
                   "JsonSchemaEvaluation.MatchRegex(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;

            case "corvus-base64-content":
                // TODO
                return false;

            case "corvus-base64-content-pre201909":
                // TODO
                return false;

            case "corvus-base64-string":
                // TODO
                return false;

            case "corvus-base64-string-pre201909":
                // TODO
                return false;

            case "corvus-json-content":
                // TODO
                return false;

            case "corvus-json-content-pre201909":
                // TODO
                return false;

            default:
                return false;
        }
    }

    /// <inheritdoc/>
    public bool AppendFormatConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators)
    {
        switch (format)
        {
            case "date":
                if (seenConversionOperators.Add("LocalDate"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator NodaTime.LocalDate(NodaTime.LocalDate value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "date-time":
                if (seenConversionOperators.Add("OffsetDateTime"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator NodaTime.OffsetDateTime(NodaTime.OffsetDateTime value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "time":
                if (seenConversionOperators.Add("OffsetTime"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator NodaTime.OffsetTime(NodaTime.OffsetTime value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "duration":
                if (seenConversionOperators.Add("Period"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator NodaTime.Period(NodaTime.Period value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "ipv4":
                return true;

            case "ipv6":
                return true;

            case "uuid":
                if (seenConversionOperators.Add("Guid"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Guid(Guid value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "uri":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static explicit operator Uri(Uri value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "uri-reference":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static explicit operator Uri(Uri value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "iri":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static explicit operator Uri(Uri value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "iri-reference":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static explicit operator Uri(Uri value) => _parentDocument.TryGetValue(_idx, out byte result) ? result : throw new FormatException();");
                }
                return true;

            case "regex":
                return true;

            default:
                return false;
        }
    }

    /// <inheritdoc/>
    public bool AppendFormatSourceConstructors(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConstructorParameters)
    {
        switch (format)
        {
            case "date":
                if (seenConstructorParameters.Add("LocalDate"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(NodaTime.LocalDate value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatLocalDate(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }
                return true;

            case "date-time":
                if (seenConstructorParameters.Add("OffsetDateTime"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(NodaTime.OffsetDateTime value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatOffsetDateTime(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }

                if (seenConstructorParameters.Add("DateTimeOffset"))
                {
                    generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(DateTimeOffset value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }
                return true;

            case "time":
                if (seenConstructorParameters.Add("OffsetTime"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(NodaTime.OffsetTime value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatOffsetTime(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }
                return true;

            case "duration":
                if (seenConstructorParameters.Add("Period"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(NodaTime.Period value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatPeriod(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }
                return true;

            case "ipv4":
                return true;

            case "ipv6":
                return true;

            case "uuid":
                if (seenConstructorParameters.Add("Guid"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(Guid value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.StringSimpleType; }");
                }
                return true;

            case "uri":
                if (seenConstructorParameters.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(Uri value) { _utf16Backing = value.OriginalString.AsSpan(); _kind = Kind.Utf16String; }");
                }
                return true;

            case "uri-reference":
                if (seenConstructorParameters.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(Uri value) { _utf16Backing = value.OriginalString.AsSpan(); _kind = Kind.Utf16String; }");
                }
                return true;

            case "iri":
                if (seenConstructorParameters.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(Uri value) { _utf16Backing = value.OriginalString.AsSpan(); _kind = Kind.Utf16String; }");
                }
                return true;

            case "iri-reference":
                if (seenConstructorParameters.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                       .AppendLineIndent("private Source(Uri value) { _utf16Backing = value.OriginalString.AsSpan(); _kind = Kind.Utf16String; }");
                }
                return true;

            case "regex":
                return true;

            default:
                return false;
        }
    }

    /// <summary>
    /// Appends format-specific source conversion operators to the generator.
    /// </summary>
    /// <param name="generator">The generator to which to append the conversion operators.</param>
    /// <param name="typeDeclaration">The type declaration for which to append conversion operators.</param>
    /// <param name="format">The format for which to append conversion operators.</param>
    /// <param name="seenConversionOperators">The set of conversion operators that have already been generated.</param>
    /// <returns><see langword="true"/> if the instance handled this format.</returns>
    public bool AppendFormatSourceConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators)
    {
        switch (format)
        {
            case "date":
                if (seenConversionOperators.Add("LocalDate"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(NodaTime.LocalDate value) => new (value);");
                }
                return true;

            case "date-time":
                if (seenConversionOperators.Add("OffsetDateTime"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(NodaTime.OffsetDateTime value) => new (value);");
                }
                return true;

            case "time":
                if (seenConversionOperators.Add("OffsetTime"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(NodaTime.OffsetTime value) => new (value);");
                }
                return true;

            case "duration":
                if (seenConversionOperators.Add("Period"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(NodaTime.Period value) => new (value);");
                }
                return true;

            case "ipv4":
                return true;

            case "ipv6":
                return true;

            case "uuid":
                if (seenConversionOperators.Add("Guid"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(Guid value) => new (value);");
                }
                return true;

            case "uri":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(Uri value) => new (value);");
                }
                return true;

            case "uri-reference":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(Uri value) => new (value);");
                }
                return true;

            case "iri":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(Uri value) => new (value);");
                }
                return true;

            case "iri-reference":
                if (seenConversionOperators.Add("Uri"))
                {
                    generator
                        .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(Uri value) => new (value);");
                }
                return true;

            case "regex":
                return true;

            default:
                return false;
        }
    }

    /// <inheritdoc/>
    public JsonTokenType? GetExpectedTokenType(string format)
    {
        if (HandlesFormat(format))
        {
            return JsonTokenType.String;
        }

        return null;
    }

    /// <summary>
    /// Determines whether the specified format requires simple types backing.
    /// </summary>
    /// <param name="format">The format to check.</param>
    /// <param name="requiresSimpleType">When this method returns, contains <see langword="true"/> if the format requires simple types backing; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if this handler supports the specified format; otherwise, <see langword="false"/>.</returns>
    public bool RequiresSimpleTypesBacking(string format, out bool requiresSimpleType)
    {
        switch (format)
        {
            case "date":
                requiresSimpleType = true;
                return true;

            case "date-time":
                requiresSimpleType = true;
                return true;

            case "time":
                requiresSimpleType = true;
                return true;

            case "duration":
                requiresSimpleType = true;
                return true;

            case "ipv4":
                requiresSimpleType = false;
                return true;

            case "ipv6":
                requiresSimpleType = false;
                return true;

            case "uuid":
                requiresSimpleType = true;
                return true;

            case "uri":
                requiresSimpleType = false;
                return true;

            case "uri-reference":
                requiresSimpleType = false;
                return true;

            case "iri":
                requiresSimpleType = false;
                return true;

            case "iri-reference":
                requiresSimpleType = false;
                return true;

            case "regex":
                requiresSimpleType = false;
                return true;

            default:
                requiresSimpleType = false;
                return false;
        }
    }

    private static bool HandlesFormat(string format)
    {
        return format switch
        {
            "date" => true,
            "date-time" => true,
            "time" => true,
            "duration" => true,
            "email" => true,
            "idn-email" => true,
            "hostname" => true,
            "idn-hostname" => true,
            "ipv4" => true,
            "ipv6" => true,
            "uuid" => true,
            "uri" => true,
            "uri-template" => true,
            "uri-reference" => true,
            "iri" => true,
            "iri-reference" => true,
            "json-pointer" => true,
            "relative-json-pointer" => true,
            "regex" => true,
            "corvus-base64-content" => true,
            "corvus-base64-content-pre201909" => true,
            "corvus-base64-string" => true,
            "corvus-base64-string-pre201909" => true,
            "corvus-json-content" => true,
            "corvus-json-content-pre201909" => true,
            _ => false,
        };
    }
}
