// <copyright file="WellKnownNumericFormatHandler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;
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
    public JsonValueKind? GetExpectedValueKind(string format)
    {
        if (IsIntegerFormat(format) || IsFloatingPointFormat(format))
        {
            return JsonValueKind.Number;
        }

        return null;
    }

    /// <inheritdoc/>
    public bool AppendFormatSourceConstructors(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConstructorParameters)
    {
        switch (format)
        {
            case "byte":
                if (seenConstructorParameters.Add("byte"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(byte value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "uint16":
                if (seenConstructorParameters.Add("ushort"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(ushort value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "uint32":
                if (seenConstructorParameters.Add("uint"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(uint value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "uint64":
                if (seenConstructorParameters.Add("ulong"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(ulong value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "uint128":
                if (seenConstructorParameters.Add("UInt128"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("private Source(UInt128 value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written)); _kind = Kind.NumericSimpleType; }")
                        .AppendLine("#endif");
                }
                return true;
            case "sbyte":
                if (seenConstructorParameters.Add("sbyte"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(sbyte value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "int16":
                if (seenConstructorParameters.Add("short"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(short value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "int32":
                if (seenConstructorParameters.Add("int"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(int value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "int64":
                if (seenConstructorParameters.Add("long"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(long value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "int128":
                if (seenConstructorParameters.Add("Int128"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("private Source(Int128 value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written)); _kind = Kind.NumericSimpleType; }")
                        .AppendLine("#endif");
                }
                return true;
            case "half":
                if (seenConstructorParameters.Add("Half"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("private Source(Half value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written)); _kind = Kind.NumericSimpleType; }")
                        .AppendLine("#endif");
                }
                return true;
            case "single":
                if (seenConstructorParameters.Add("float"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(float value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "double":
                if (seenConstructorParameters.Add("double"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(double value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            case "decimal":
                if (seenConstructorParameters.Add("decimal"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(decimal value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                }
                return true;
            default:
                return false;
        }
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
        generator.AppendLineIndent("private static ", integralProperty, " => \"", GetTextFromUtf8(integral), "\"u8;");
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

    public bool TryGetNumericTypeName(string format, [NotNullWhen(true)] out string? typeName, out bool isNetOnly, out string? netStandardFallback)
    {
        switch (format)
        {
            case "double":
                typeName = "double";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "decimal":
                typeName = "decimal";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "half":
                typeName = "Half";
                netStandardFallback = "double";
                isNetOnly = true;
                return true;
            case "single":
                typeName = "float";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "byte":
                typeName = "byte";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "int16":
                typeName = "short";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "int32":
                typeName = "int";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "int64":
                typeName = "long";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "int128":
                typeName = "Int128";
                netStandardFallback = "long";
                isNetOnly = true;
                return true;
            case "sbyte":
                typeName = "sbyte";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "uint16":
                typeName = "ushort";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "uint32":
                typeName = "uint";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "uint64":
                typeName = "ulong";
                netStandardFallback = null;
                isNetOnly = false;
                return true;
            case "uint128":
                typeName = "UInt128";
                netStandardFallback = "ulong";
                isNetOnly = true;
                return true;
            default:
                typeName = null;
                netStandardFallback = null;
                isNetOnly = false;
                return false;
        }
        ;
    }

    public bool AppendFormatSourceConversionOperators(CodeGenerator generator, TypeDeclaration typeDeclaration, string format, HashSet<string> seenConversionOperators)
    {
        switch (format)
        {
            case "byte":
                if (seenConversionOperators.Add("byte"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(byte value) => new (value);");
                }
                return true;
            case "uint16":
                if (seenConversionOperators.Add("ushort"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(ushort value) => new (value);");
                }
                return true;
            case "uint32":
                if (seenConversionOperators.Add("uint"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(uint value) => new (value);");
                }
                return true;
            case "uint64":
                if (seenConversionOperators.Add("ulong"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(ulong value) => new (value);");
                }
                return true;
            case "uint128":
                if (seenConversionOperators.Add("UInt128"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(UInt128 value) => new (value);")
                        .AppendLine("#endif");
                }
                return true;
            case "sbyte":
                if (seenConversionOperators.Add("sbyte"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(sbyte value) => new (value);");
                }
                return true;
            case "int16":
                if (seenConversionOperators.Add("short"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(short value) => new (value);");
                }
                return true;
            case "int32":
                if (seenConversionOperators.Add("int"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(int value) => new (value);");
                }
                return true;
            case "int64":
                if (seenConversionOperators.Add("long"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(long value) => new (value);");
                }
                return true;
            case "int128":
                if (seenConversionOperators.Add("Int128"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(Int128 value) => new (value);")
                        .AppendLine("#endif");
                }
                return true;
            case "half":
                if (seenConversionOperators.Add("Half"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(Half value) => new (value);")
                        .AppendLine("#endif");
                }
                return true;
            case "single":
                if (seenConversionOperators.Add("float"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(float value) => new (value);");
                }
                return true;
            case "double":
                if (seenConversionOperators.Add("double"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(double value) => new (value);");
                }
                return true;
            case "decimal":
                if (seenConversionOperators.Add("decimal"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(decimal value) => new (value);");
                }
                return true;
            default:
                return false;
        }
    }
}
