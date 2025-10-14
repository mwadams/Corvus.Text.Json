// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generator extensions providing general code generation utilities.
/// </summary>
internal static partial class CodeGeneratorExtensions
{
    /// <inheritdoc/>
    public static bool AppendFormatConstant(this CodeGenerator generator, string baseName, JsonElement constantValue)
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



        static string GetTextFromUtf8(ReadOnlySpan<byte> utf8Text)
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
    }
}
