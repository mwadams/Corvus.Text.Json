// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualBasic;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generation extensions for JSON Schema related functionality.
/// </summary>
internal static partial class CodeGenerationExtensions
{
    /// <summary>
    /// Appends the code to shortcut the return from validation if there is no collector.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="contextName">The name to use for the context (defaults to 'context').</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendNoCollectorShortcutReturn(this CodeGenerator generator, string contextName = "context")
    {
        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (!", contextName, ".HasCollector)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("return;")
            .PopIndent()
            .AppendLineIndent("}");
    }

    /// <summary>
    /// Appends the code to shortcut the return from validation if there is no collector.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="contextName">The name to use for the context (defaults to 'context').</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendNoCollectorNoMatchShortcutReturn(this CodeGenerator generator, string contextName = "context")
    {
        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (!", contextName, ".HasCollector && !", contextName, ".IsMatch)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("return;")
            .PopIndent()
            .AppendLineIndent("}");
    }

    /// <summary>
    /// Prepend validation setup code for children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator PrependChildValidationSetup(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority <= parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationSetup(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Append validation setup code for children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendChildValidationSetup(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority > parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationSetup(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Prepend validation code for appropriate children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator PrependChildValidationCode(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority <= parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationCode(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Append validation code for appropriate children.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration which requires validation.</param>
    /// <param name="children">The child handlers for the <see cref="IKeywordValidationHandler"/>.</param>
    /// <param name="parentHandlerPriority">The parent validation handler priority.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendChildValidationCode(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        IReadOnlyCollection<IChildValidationHandler> children,
        uint parentHandlerPriority)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority > parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            child.AppendValidationCode(generator, typeDeclaration);
        }

        return generator;
    }

    /// <summary>
    /// Appends the contants nested class containing property name constants.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the property names class.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendConstantsClass(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.ValidationConstants() is not IReadOnlyDictionary<IValidationConstantProviderKeyword, JsonElement[]> constants
            || constants.Count == 0)
        {
            return generator;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Provides accesors for enumerated values")
            .AppendLineIndent("/// </summary>")
            .BeginPrivateStaticClassDeclaration(generator.ConstantsClassName());

        foreach (KeyValuePair<IValidationConstantProviderKeyword, JsonElement[]> constant in constants.OrderBy(k => k.Key.Keyword))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            int count = constant.Value.Length;

            if (count > 0)
            {
                generator.AppendSeparatorLine();

                int? i = count == 1 ? null : 1;
                foreach (JsonElement value in constant.Value)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    switch (value.ValueKind)
                    {
                        case JsonValueKind.Array:
                            generator.AppendArrayValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        case JsonValueKind.Null:
                            generator.AppendNullValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        case JsonValueKind.String:
                            generator.AppendStringValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        case JsonValueKind.Number:
                            generator.AppendNumberValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        case JsonValueKind.Object:
                            generator.AppendObjectValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            generator.AppendBooleanValidationConstantField(typeDeclaration, constant.Key, i, value);
                            break;

                        default:
                            break;
                    }

                    if (count > 1)
                    {
                        i++;
                    }
                }
            }
        }

        return generator
            .EndClassStructOrEnumDeclaration();
    }

    private static CodeGenerator AppendArrayValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.Array, "The value must be an array.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(memberName)
            .Append(" = ")
            .Append(typeDeclaration.DotnetTypeName())
            .Append(".ParseValue(")
            .AppendSerializedArrayStringLiteral(value)
            .AppendLine(");");

        return generator;
    }

    private static CodeGenerator AppendObjectValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.Object, "The value must be an object.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(memberName)
            .Append(" = ")
            .Append(typeDeclaration.DotnetTypeName())
            .Append(".ParseValue(")
            .AppendSerializedObjectStringLiteral(value)
            .AppendLine(");");

        return generator;
    }

    private static CodeGenerator AppendNullValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.Null, "The value must be null.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(memberName)
            .AppendLine(" = ParsedJsonDocument<", typeDeclaration.DotnetTypeName(), ">.Null;");

        return generator;
    }

    private static CodeGenerator AppendBooleanValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.True || value.ValueKind == JsonValueKind.False, "The value must be a boolean.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(memberName)
            .AppendLine(" = ParsedJsonDocument<", typeDeclaration.DotnetTypeName(), ">.", value.ValueKind == JsonValueKind.True ? "True" : "False", ";");

        return generator;
    }

    private static CodeGenerator AppendStringValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.String, "The value must be a string.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());
        string jsonMemberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: $"Json{index?.ToString()}");

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly byte[] ")
            .Append(memberName)
            .AppendLine(" = ", SymbolDisplay.FormatLiteral(value.GetString()!, true), "u8.ToArray();");

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(jsonMemberName)
            .AppendLine(" = ParsedJsonDocument<", typeDeclaration.DotnetTypeName(), ">.StringConstant([..", SymbolDisplay.FormatLiteral(value.GetString()!, true), "u8]);");

        return generator;
    }

    private static CodeGenerator AppendNumberValidationConstantField(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeyword keyword, int? index, in JsonElement value)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        Debug.Assert(value.ValueKind == JsonValueKind.Number, "The value must be a number.");

        string memberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: index?.ToString());
        string jsonMemberName = generator.GetStaticReadOnlyFieldNameInScope(keyword.Keyword, suffix: $"Json{index?.ToString()}");

        JsonElementHelpers.ParseNumber(JsonMarshal.GetRawUtf8Value(value), out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly NormalizedJsonNumber ")
            .Append(memberName)
            .AppendLine(" = new(", isNegative ? "true" : "false", ", [..\"", Encoding.UTF8.GetString(integral.ToArray()), "\"u8], [..\"", Encoding.UTF8.GetString(fractional.ToArray()), "\"u8], ", exponent.ToString(), ");");

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// A constant for the <c>", keyword.Keyword, "</c> keyword.")
            .AppendLineIndent("/// </summary>")
            .AppendIndent("public static readonly ", typeDeclaration.DotnetTypeName(), " ")
            .Append(jsonMemberName)
            .AppendLine(" = ParsedJsonDocument<", typeDeclaration.DotnetTypeName(), ">.NumberConstant([..", SymbolDisplay.FormatLiteral(value.GetRawText(), true), "u8]);");

        return generator;
    }
}

