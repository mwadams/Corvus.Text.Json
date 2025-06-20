// <copyright file="WellKnownNumericFormatHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Handlers for well-known numeric formats.
/// </summary>
public class WellKnownNumericFormatHandler : INumberFormatHandler
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="WellKnownNumericFormatHandler"/>.
    /// </summary>
    public static WellKnownNumericFormatHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint Priority => 100_000;

    /// <inheritdoc/>
    public bool AppendFormatAssertion(
        CodeGenerator generator,
        string format,
        string formatKeywordProviderExpression,
        string isNegativeIdentifier,
        string integralIdentifier,
        string fractionalIdentifier,
        string exponentIdentifier,
        string validationContextIdentifier,
        IKeyword? formatKeyword)
    {
        switch (format)
        {
            case "byte":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchByte(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;

            case "uint16":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt16(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "uint32":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt32(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "uint64":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt64(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "uint128":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt128(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "sbyte":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchSByte(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "int16":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchInt16(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "int32":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchInt32(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "int64":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt64(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "int128":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchUInt128(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "half":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchHalf(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "single":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchSingle(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "double":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchDouble(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            case "decimal":
                generator.AppendIndent(
                    "JsonSchemaMatching.MatchDecimal(",
                    isNegativeIdentifier, ", ",
                    integralIdentifier, ", ",
                    fractionalIdentifier, ", ",
                    exponentIdentifier, ", ",
                    formatKeywordProviderExpression, ", ",
                    "ref ", validationContextIdentifier, ")");
                return true;
            default:
                return false;
        }
    }

    /// <inheritdoc/>
    public string? GetTypeNameForNumericLangwordOrTypeName(string langword)
    {
        return langword switch
        {
            "byte" => "Byte",
            "decimal" => "Decimal",
            "double" => "Double",
            "short" => "Int16",
            "int" => "Int32",
            "long" => "Int64",
            "Int128" => "Int128",
            "sbyte" => "SByte",
            "Half" => "Half",
            "float" => "Single",
            "ushort" => "UInt16",
            "uint" => "UInt32",
            "ulong" => "UInt64",
            "UInt128" => "UInt128",
            _ => null,
        };
    }

    /// <inheritdoc/>
    public JsonValueKind? GetExpectedValueKind(string format)
    {
        if (IsIntegerFormat(format) || IsFloatingPointFormat(format))
        {
            return JsonValueKind.Number;
        }

        return null;
    }

    /// <inheritdoc/>
    public bool AppendFormatConstructors(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
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
    public bool AppendFormatConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicStaticMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatPublicMethods(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
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
    public bool AppendFormatEqualsTBody(CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
    {
        return false;
    }

    /// <inheritdoc/>
    public bool AppendFormatConstant(CodeGenerator generator, ITypedValidationConstantProviderKeyword keyword, string format, string baseName, JsonElement constantValue)
    {
        if (constantValue.ValueKind != JsonValueKind.Number)
        {
            return false;
        }

        string isNegativeField = generator.GetUniqueStaticReadOnlyFieldNameInScope(baseName, suffix: "IsNegative");
        string integralProperty = generator.GetUniqueStaticReadOnlyPropertyNameInScope(baseName, suffix: "Integral");
        string fractionalProperty = generator.GetUniqueStaticReadOnlyPropertyNameInScope(baseName, suffix: "Fractional");
        string exponentField = generator.GetUniqueStaticReadOnlyFieldNameInScope(baseName, suffix: "Exponent");

        // Get the normalized JSON number for the constant
        ReadOnlySpan<byte> number = JsonMarshal.GetRawUtf8Value(constantValue);
        JsonElementHelpers.ParseNumber(number, out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);

        generator.AppendLineIndent("private const bool ", isNegativeField, " = ", isNegative ? "true" : "false", ";");
        generator.AppendLineIndent("private static ", integralProperty, " => \"", GetTextFromUtf8(integral) ,"\"u8;");
        generator.AppendLineIndent("private static ", fractionalProperty, " => \"", GetTextFromUtf8(fractional), "\"u8;");
        generator.AppendLineIndent("private const int ", exponentField, " = ", exponent.ToString(), ";");

        return true;
    }

    private static string GetTextFromUtf8(ReadOnlySpan<byte> utf8Text)
    {
#if NET
        return Encoding.UTF8.GetString(utf8Text);
#else
            if (utf8Text.IsEmpty)
            {
                return string.Empty;
            }

            unsafe
            {
                fixed (byte* bytePtr = utf8Text)
                {
                    return Encoding.UTF8.GetString(bytePtr, utf8Text.Length);
                }
            }
#endif
    }

    /// <inheritdoc/>
    private static bool IsIntegerFormat(string format)
    {
        return format switch
        {
            "byte" => true,
            "uint16" => true,
            "uint32" => true,
            "uint64" => true,
            "uint128" => true,
            "sbyte" => true,
            "int16" => true,
            "int32" => true,
            "int64" => true,
            "int128" => true,
            _ => false,
        };
    }

    /// <inheritdoc/>
    private static bool IsFloatingPointFormat(string format)
    {
        return format switch
        {
            "half" => true,
            "single" => true,
            "double" => true,
            "decimal" => true,
            _ => false,
        };
    }
}
