// <copyright file="WellKnownStringFormatHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.Internal;
using Microsoft.CodeAnalysis.CSharp;
using static System.Net.Mime.MediaTypeNames;

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
    public bool AppendFormatConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return format switch
        {
            ////"date" => generator.AppendDateFormatConversionOperators(typeDeclaration),
            ////"date-time" => generator.AppendDateTimeFormatConversionOperators(typeDeclaration),
            ////"time" => generator.AppendTimeFormatConversionOperators(typeDeclaration),
            ////"duration" => generator.AppendDurationFormatConversionOperators(typeDeclaration),
            ////"ipv4" => generator.AppendIpV4FormatConversionOperators(typeDeclaration),
            ////"ipv6" => generator.AppendIpV6FormatConversionOperators(typeDeclaration),
            ////"uuid" => generator.AppendUuidFormatConversionOperators(typeDeclaration),
            ////"uri" => generator.AppendUriFormatConversionOperators(typeDeclaration),
            ////"uri-reference" => generator.AppendUriReferenceFormatConversionOperators(typeDeclaration),
            ////"iri" => generator.AppendIriFormatConversionOperators(typeDeclaration),
            ////"iri-reference" => generator.AppendIriReferenceFormatConversionOperators(typeDeclaration),
            ////"regex" => generator.AppendRegexFormatConversionOperators(typeDeclaration),
            _ => false,
        };
    }

    /// <inheritdoc/>
    public bool AppendFormatEqualsTBody(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return format switch
        {
            ////"date" => generator.AppendDateFormatEqualsTBody(typeDeclaration),
            ////"date-time" => generator.AppendDateTimeFormatEqualsTBody(typeDeclaration),
            ////"time" => generator.AppendTimeFormatEqualsTBody(typeDeclaration),
            ////"duration" => generator.AppendDurationFormatEqualsTBody(typeDeclaration),
            ////"uuid" => generator.AppendUuidFormatEqualsTBody(typeDeclaration),
            ////"corvus-json-content" => generator.AppendJsonContentFormatEqualsTBody(typeDeclaration),
            ////"corvus-json-content-pre201909" => generator.AppendJsonContentFormatEqualsTBody(typeDeclaration),
            _ => false,
        };
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicStaticMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return format switch
        {
            ////"date" => generator.AppendDateFormatPublicMethods(typeDeclaration),
            ////"date-time" => generator.AppendDateTimeFormatPublicMethods(typeDeclaration),
            ////"time" => generator.AppendTimeFormatPublicMethods(typeDeclaration),
            ////"duration" => generator.AppendDurationFormatPublicMethods(typeDeclaration),
            ////"ipv4" => generator.AppendIpV4FormatPublicMethods(typeDeclaration),
            ////"ipv6" => generator.AppendIpV6FormatPublicMethods(typeDeclaration),
            ////"uuid" => generator.AppendUuidFormatPublicMethods(typeDeclaration),
            ////"uri" => generator.AppendUriFormatPublicMethods(typeDeclaration),
            ////"uri-reference" => generator.AppendUriReferenceFormatPublicMethods(typeDeclaration),
            ////"iri" => generator.AppendIriFormatPublicMethods(typeDeclaration),
            ////"iri-reference" => generator.AppendIriReferenceFormatPublicMethods(typeDeclaration),
            ////"uri-template" => generator.AppendUriTemplateFormatPublicMethods(typeDeclaration),
            ////"regex" => generator.AppendRegexFormatPublicMethods(typeDeclaration),
            ////"corvus-base64-string" => generator.AppendBase64StringFormatPublicMethods(typeDeclaration),
            ////"corvus-base64-string-pre201909" => generator.AppendBase64StringFormatPublicMethods(typeDeclaration),
            ////"corvus-json-content" => generator.AppendJsonContentFormatPublicMethods(typeDeclaration),
            ////"corvus-json-content-pre201909" => generator.AppendJsonContentFormatPublicMethods(typeDeclaration),
            ////"corvus-base64-content" => generator.AppendBase64ContentFormatPublicMethods(typeDeclaration),
            ////"corvus-base64-content-pre201909" => generator.AppendBase64ContentFormatPublicMethods(typeDeclaration),
            _ => false,
        };
    }

    /// <inheritdoc/>
    public bool AppendFormatPrivateStaticMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPrivateMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicStaticProperties(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicProperties(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatAssertion(CodeGenerator generator, string format, string formatKeywordProviderExpression, string valueIdentifier, string validationContextIdentifier)
    {
        switch (format)
        {
            case "date":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchDate(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "date-time":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchDateTime(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "time":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchTime(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "duration":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchDuration(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "email":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchEmail(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "idn-email":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIdnEmail(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "hostname":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchHostname(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "idn-hostname":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIdnHostname(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "ipv4":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIPV4(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "ipv6":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIPV6(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "uuid":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchUuid(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "uri":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchUri(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "uri-template":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchUriTemplate(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "uri-reference":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchUriReference(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "iri":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIri(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "iri-reference":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchIriReference(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "json-pointer":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchJsonPointer(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "relative-json-pointer":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchRelativeJsonPointer(",
                   valueIdentifier, ", ",
                   formatKeywordProviderExpression, ", ",
                   "ref ", validationContextIdentifier, ")");
                return true;
            case "regex":
                generator.AppendIndent(
                   "JsonSchemaMatching.MatchRegex(",
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
    public JsonValueKind? GetExpectedValueKind(string format)
    {
        if (HandlesFormat(format))
        {
            return JsonValueKind.String;
        }

        return null;
    }

    /// <inheritdoc/>
    public bool AppendFormatConstant(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string format, string staticFieldName, JsonElement constantValue)
    {
        if (constantValue.ValueKind != JsonValueKind.String)
        {
            return false;
        }

        return format switch
        {
            "date" => AppendDate(generator, keyword, staticFieldName, constantValue),
            "date-time" => AppendDateTime(generator, keyword, staticFieldName, constantValue),
            "time" => AppendTime(generator, keyword, staticFieldName, constantValue),
            "duration" => AppendDuration(generator, keyword, staticFieldName, constantValue),
            "ipv4" => AppendIpV4(generator, keyword, staticFieldName, constantValue),
            "ipv6" => AppendIpV6(generator, keyword, staticFieldName, constantValue),
            "uuid" => AppendUuid(generator, keyword, staticFieldName, constantValue),
            "uri" => AppendUri(generator, keyword, staticFieldName, constantValue),
            "uri-reference" => AppendUriReference(generator, keyword, staticFieldName, constantValue),
            "iri" => AppendIri(generator, keyword, staticFieldName, constantValue),
            "iri-reference" => AppendIriReference(generator, keyword, staticFieldName, constantValue),
            //// "regex" => We don't support regex here; there is a custom regex support with IValidationRegexProviderKeyword,
            _ => false,
        };
    }

    private static bool AppendIriReference(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Uri ",
                staticFieldName,
                " = new Uri(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ", UriKind.RelativeOrAbsolute).GetUri();");

        return true;
    }

    private static bool AppendIri(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Uri ",
                staticFieldName,
                " = new Uri(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ", UriKind.RelativeOrAbsolute).GetUri();");

        return true;
    }

    private static bool AppendUriReference(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Uri ",
                staticFieldName,
                " = new Uri(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ", UriKind.RelativeOrAbsolute).GetUri();");

        return true;
    }

    private static bool AppendUri(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Uri ",
                staticFieldName,
                " = new Uri(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ", UriKind.RelativeOrAbsolute).GetUri();");

        return true;
    }

    private static bool AppendUuid(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Guid ",
                staticFieldName,
                " = new Guid(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ");");

        return true;
    }

    private static bool AppendIpV6(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly System.Net.IPAddress ",
                staticFieldName,
                " = IPAddress.TryParse(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ");");

        return true;
    }

    private static bool AppendIpV4(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
            "public static readonly System.Net.IPAddress ",
            staticFieldName,
            " = IPAddress.TryParse(",
            SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
            ");");

        return true;
    }

    private static bool AppendDuration(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly Period ",
                staticFieldName,
                " = Period.Parse(",
                SymbolDisplay.FormatLiteral(constantValue.GetString()!, true),
                ");");

        return true;
    }

    private static bool AppendTime(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        if (!JsonElementHelpers.ParseOffsetTimeCore(
            Encoding.UTF8.GetBytes(constantValue.GetString()!).AsSpan(),
            out int hours,
            out int minutes,
            out int seconds,
            out int milliseconds,
            out int microseconds,
            out int nanoseconds,
            out int offSetSeconds))
        {
            return false;
        }

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent(
                "public static readonly NodaTime.OffsetTime ",
                staticFieldName,
                " = JsonElementHelpers.CreateOffsetTimeCore(",
                hours.ToString(),
                ", ",
                minutes.ToString(),
                ", ",
                seconds.ToString(),
                ", ",
                milliseconds.ToString(),
                ", ");

        if (microseconds != 0 || nanoseconds != 0)
        {
            generator
                .AppendIndent(microseconds.ToString(), ", ", nanoseconds.ToString(), ", ");
        }

        generator.AppendLineIndent(
                offSetSeconds.ToString(),
                ");");

        return true;
    }

    private static bool AppendDateTime(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        ReadOnlySpan<byte> utf8Bytes = Encoding.UTF8.GetBytes(constantValue.GetString()!).AsSpan();

        if (!JsonElementHelpers.ParseDateCore(
            utf8Bytes,
            out int year,
            out int month,
            out int day))
        {
            return false;
        }

        if (!JsonElementHelpers.ParseOffsetTimeCore(
            utf8Bytes,
            out int hours,
            out int minutes,
            out int seconds,
            out int milliseconds,
            out int microseconds,
            out int nanoseconds,
            out int offSetSeconds))
        {
            return false;
        }

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent(
                "public static readonly NodaTime.OffsetDateTime ",
                staticFieldName,
                " = JsonElementHelpers.CreateOffsetDateTimeCore(",
                year.ToString(),
                ", ",
                month.ToString(),
                ", ",
                day.ToString(),
                ", ",
                hours.ToString(),
                ", ",
                minutes.ToString(),
                ", ",
                seconds.ToString(),
                ", ",
                milliseconds.ToString(),
                ", ");

        if (microseconds != 0 || nanoseconds != 0)
        {
            generator
                .AppendIndent(microseconds.ToString(), ", ", nanoseconds.ToString(), ", ");
        }

        generator.AppendLineIndent(
                offSetSeconds.ToString(),
                ");");

        return true;
    }

    private static bool AppendDate(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string staticFieldName, JsonElement constantValue)
    {
        ReadOnlySpan<byte> utf8Bytes = Encoding.UTF8.GetBytes(constantValue.GetString()!).AsSpan();

        if (!JsonElementHelpers.ParseDateCore(
            utf8Bytes,
            out int year,
            out int month,
            out int day))
        {
            return false;
        }

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent(
                "public static readonly NodaTime.LocalDate ",
                staticFieldName,
                " = new(",
                year.ToString(),
                ", ",
                month.ToString(),
                ", ",
                day.ToString(),
                ");");

        return true;
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
