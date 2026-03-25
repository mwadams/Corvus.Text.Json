// <copyright file="CodeGeneratorExtensions.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Text.Json.CodeGeneration.Internal;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generation extensions for JSON Schema related functionality.
/// </summary>
internal static partial class CodeGenerationExtensions
{
    private const string NormalizedJsonNumberAppendedKey = "NormalizedJsonNumberAppended";
    private const string NormalizedJsonNumberAppendedInScopeKey = "NormalizedJsonNumberAppendedInScope";
    private const string GetRawSimpleValueAppendedKey = "GetRawSimpleValueAppended";
    private const string GetRawSimpleValueAppendedInScopeKey = "GetRawSimpleValueAppendedInScope";
    private const string UnescapedUtf8JsonStringAppendedKey = "UnescapedUtf8JsonStringAppended";
    private const string UnescapedUtf8JsonStringAppendedInScopeKey = "UnescapedUtf8JsonStringAppendedInScope";
    private const string StringLengthAppendedKey = "StringLengthAppended";
    private const string StringLengthAppendedInScopeKey = "StringLengthAppendedInScope";
    private const string EnumStringSetFieldNameKeyPrefix = "AnyOfConstValidationHandler.EnumStringSetFieldName.";
    private const string OneOfDiscriminatorMapFieldNameKeyPrefix = "OneOfDiscriminator.EnumStringMapFieldName.";
    private const string OneOfDiscriminatorPropertyNameKeyPrefix = "OneOfDiscriminator.PropertyName.";
    private const string OneOfDiscriminatorValuesKeyPrefix = "OneOfDiscriminator.Values.";
    private const int MinEnumValuesForHashSet = 3;

    public static CodeGenerator AppendNormalizedJsonNumberIfNotAppended(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool includeTokenTypeCheck = true)
    {
        if (typeDeclaration.TryGetMetadata(NormalizedJsonNumberAppendedKey, out bool? _))
        {
            return generator;
        }

        typeDeclaration.SetMetadata(NormalizedJsonNumberAppendedKey, true);
        typeDeclaration.SetMetadata(NormalizedJsonNumberAppendedInScopeKey, generator.FullyQualifiedScope);

        return generator
            .AppendGetRawSimpleValueIfNotAppended(typeDeclaration, includeTokenTypeCheck)
            .AppendSeparatorLine()
            .ReserveName("isNegative")
            .ReserveName("integral")
            .ReserveName("fractional")
            .ReserveName("exponent")
            .AppendLineIndent("JsonElementHelpers.TryParseNumber(rawSimpleValue.Span, out bool isNegative,out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);");
    }

    public static CodeGenerator AppendStringLengthIfNotAppended(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool includeTokenTypeCheck = true)
    {
        if (typeDeclaration.TryGetMetadata(StringLengthAppendedKey, out bool? _))
        {
            return generator;
        }

        typeDeclaration.SetMetadata(StringLengthAppendedKey, true);
        typeDeclaration.SetMetadata(StringLengthAppendedInScopeKey, generator.FullyQualifiedScope);

        return generator
            .AppendUnescapedUtf8JsonStringIfNotAppended(typeDeclaration, includeTokenTypeCheck)
            .AppendSeparatorLine()
            .ReserveName("stringLength")
            .AppendLineIndent("int stringLength = JsonElementHelpers.CountRunes(unescapedUtf8JsonString.Span);");
    }

    public static CodeGenerator PopStringLengthIfAppendedInScope(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (typeDeclaration.TryGetMetadata(StringLengthAppendedInScopeKey, out string? scope)
            && scope == generator.FullyQualifiedScope)
        {
            typeDeclaration.RemoveMetadata(StringLengthAppendedInScopeKey);
            typeDeclaration.RemoveMetadata(StringLengthAppendedKey);
        }

        return generator
            .PopUnescapedUtf8JsonStringIfAppendedInScope(typeDeclaration);
    }

    public static CodeGenerator AppendUnescapedUtf8JsonStringIfNotAppended(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool includeTokenTypeCheck = true)
    {
        if (typeDeclaration.TryGetMetadata(UnescapedUtf8JsonStringAppendedKey, out bool? _))
        {
            return generator;
        }

        typeDeclaration.SetMetadata(UnescapedUtf8JsonStringAppendedKey, true);
        typeDeclaration.SetMetadata(UnescapedUtf8JsonStringAppendedInScopeKey, generator.FullyQualifiedScope);

        generator
            .AppendSeparatorLine()
            .ReserveName("unescapedUtf8JsonString");

        if (includeTokenTypeCheck)
        {
            generator
                .AppendLineIndent("using UnescapedUtf8JsonString unescapedUtf8JsonString = tokenType is JsonTokenType.String ? parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String) : default;");
        }
        else
        {
            generator
                .AppendLineIndent("using UnescapedUtf8JsonString unescapedUtf8JsonString = parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String);");
        }

        return generator;
    }

    public static CodeGenerator PopUnescapedUtf8JsonStringIfAppendedInScope(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (typeDeclaration.TryGetMetadata(UnescapedUtf8JsonStringAppendedInScopeKey, out string? scope)
            && scope == generator.FullyQualifiedScope)
        {
            typeDeclaration.RemoveMetadata(UnescapedUtf8JsonStringAppendedInScopeKey);
            typeDeclaration.RemoveMetadata(UnescapedUtf8JsonStringAppendedKey);
        }

        return generator;
    }

    public static CodeGenerator PopNormalizedJsonNumberIfAppendedInScope(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (typeDeclaration.TryGetMetadata(NormalizedJsonNumberAppendedInScopeKey, out string? scope)
            && scope == generator.FullyQualifiedScope)
        {
            typeDeclaration.RemoveMetadata(NormalizedJsonNumberAppendedInScopeKey);
            typeDeclaration.RemoveMetadata(NormalizedJsonNumberAppendedKey);
        }

        return generator
            .PopGetRawSimpleValueIfAppendedInScope(typeDeclaration);
    }

    public static CodeGenerator AppendGetRawSimpleValueIfNotAppended(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool includeTokenTypeCheck = true)
    {
        if (typeDeclaration.TryGetMetadata(GetRawSimpleValueAppendedKey, out bool? _))
        {
            return generator;
        }

        typeDeclaration.SetMetadata(GetRawSimpleValueAppendedKey, true);
        typeDeclaration.SetMetadata(GetRawSimpleValueAppendedInScopeKey, generator.FullyQualifiedScope);

        generator
            .AppendSeparatorLine()
            .ReserveName("rawSimpleValue");

        if (includeTokenTypeCheck)
        {
            generator
                .AppendLineIndent("ReadOnlyMemory<byte> rawSimpleValue = tokenType is JsonTokenType.Number or JsonTokenType.String ? parentDocument.GetRawSimpleValue(parentIndex) : default;");
        }
        else
        {
            generator
                .AppendLineIndent("ReadOnlyMemory<byte> rawSimpleValue = parentDocument.GetRawSimpleValue(parentIndex);");
        }

        return generator;
    }

    public static CodeGenerator PopGetRawSimpleValueIfAppendedInScope(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (typeDeclaration.TryGetMetadata(GetRawSimpleValueAppendedInScopeKey, out string? scope)
            && scope == generator.FullyQualifiedScope)
        {
            typeDeclaration.RemoveMetadata(GetRawSimpleValueAppendedKey);
            typeDeclaration.RemoveMetadata(GetRawSimpleValueAppendedInScopeKey);
        }

        return generator;
    }

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
    public static CodeGenerator AppendNoCollectorBooleanFalseShortcutReturn(this CodeGenerator generator, string contextName = "context")
    {
        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (!", contextName, ".HasCollector)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent(contextName, ".EvaluatedBooleanSchema(false);")
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
    /// Appends the code to shortcut the return from validation if there is no collector.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="contextName">The name to use for the context (defaults to 'context').</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendConditionalNoCollectorNoMatchShortcutReturn(this CodeGenerator generator, TypeDeclaration typeDeclaration, IKeywordValidationHandler handler, string contextName = "context")
    {
        bool hasMoreHandlers = typeDeclaration
            .OrderedValidationHandlers(generator.LanguageProvider)
            .TakeWhile(h => h != handler)
            .Skip(1)
            .Any();

        if (hasMoreHandlers)
        {
            return AppendNoCollectorNoMatchShortcutReturn(generator, contextName);
        }

        return generator;
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

        bool appendShortcut = false;

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority <= parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            int initialLength = generator.Length;

            if (appendShortcut)
            {
                generator.AppendNoCollectorNoMatchShortcutReturn();
            }

            int length = generator.Length;

            child.AppendValidationCode(generator, typeDeclaration);

            if (length != generator.Length)
            {
                appendShortcut = true;
            }
            else
            {
                // Trim off the shortcut we appended
                // if we didn't append any validation code
                generator.Length = initialLength;
            }
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

        bool appendShortcut = false;

        foreach (IChildValidationHandler child in children
            .Where(c => c.ValidationHandlerPriority > parentHandlerPriority)
            .OrderBy(c => c.ValidationHandlerPriority))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            int initialLength = generator.Length;

            if (appendShortcut)
            {
                generator.AppendNoCollectorNoMatchShortcutReturn();
            }

            int length = generator.Length;

            child.AppendValidationCode(generator, typeDeclaration);

            if (length != generator.Length)
            {
                appendShortcut = true;
            }
            else
            {
                // Trim off the shortcut we appended
                // if we didn't append any validation code
                generator.Length = initialLength;
            }
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

        var requiredConstants = constants.Where(k => !IsNotRequiredInConstantsClass(k.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        if (requiredConstants.Count == 0)
        {
            return generator;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Provides accesors for enumerated values")
            .AppendLineIndent("/// </summary>")
            .BeginPrivateStaticClassDeclaration(generator.ConstantsClassName());

        foreach (KeyValuePair<IValidationConstantProviderKeyword, JsonElement[]> constant in requiredConstants.OrderBy(k => k.Key.Keyword))
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

    /// <summary>
    /// Appends a public <c>EnumValues</c> class containing named properties for each constant
    /// defined by any-of constant validation keywords (e.g. <c>enum</c>).
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendEnumValuesClass(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.AnyOfConstantValues() is not IReadOnlyDictionary<IAnyOfConstantValidationKeyword, JsonElement[]> anyOfConstants
            || anyOfConstants.Count == 0)
        {
            return generator;
        }

        // Only emit if we actually have values with derivable names.
        bool hasNameableValues = false;
        foreach (KeyValuePair<IAnyOfConstantValidationKeyword, JsonElement[]> kvp in anyOfConstants)
        {
            if (kvp.Value.Length > 0)
            {
                hasNameableValues = true;
                break;
            }
        }

        if (!hasNameableValues)
        {
            return generator;
        }

        string constantsClassName = generator.ConstantsClassName();
        string constantsScope = generator.ConstantsScope();
        string enumValuesScope = generator.EnumValuesScope();
        string dotnetTypeName = typeDeclaration.DotnetTypeName();

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Provides named constants for enum values.")
            .AppendLineIndent("/// </summary>")
            .BeginPublicStaticClassDeclaration(generator.EnumValuesClassName());

        foreach (KeyValuePair<IAnyOfConstantValidationKeyword, JsonElement[]> kvp in anyOfConstants.OrderBy(k => k.Key.Keyword))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            JsonElement[] values = kvp.Value;
            int count = values.Length;
            if (count == 0)
            {
                continue;
            }

            string keywordName = kvp.Key.Keyword;
            bool addSuffix = count > 1;

            int elementIndex = 1;
            foreach (JsonElement value in values)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                string? suffix = addSuffix ? elementIndex.ToString() : null;

                AppendEnumValueProperty(generator, typeDeclaration, value, keywordName, suffix, constantsClassName, constantsScope, enumValuesScope, dotnetTypeName);

                elementIndex++;
            }
        }

        return generator
            .EndClassStructOrEnumDeclaration();

        static void AppendEnumValueProperty(
            CodeGenerator generator,
            TypeDeclaration typeDeclaration,
            JsonElement value,
            string keywordName,
            string? suffix,
            string constantsClassName,
            string constantsScope,
            string enumValuesScope,
            string dotnetTypeName)
        {
            // Compute the Constants field names by looking up names in the Constants scope.
            string utf8FieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: suffix);

            switch (value.ValueKind)
            {
                case JsonValueKind.String:
                {
                    string jsonFieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: $"Json{suffix}");
                    string propertyBaseName = value.GetString()!;
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope(propertyBaseName, rootScope: enumValuesScope);
                    string utf8PropertyName = generator.GetStaticReadOnlyPropertyNameInScope(propertyBaseName, rootScope: enumValuesScope, suffix: "Utf8");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the string ", SymbolDisplay.FormatLiteral(propertyBaseName, true))
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", jsonFieldName, ";");

                    generator
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the string ", SymbolDisplay.FormatLiteral(propertyBaseName, true))
                        .AppendLineIndent("/// as a UTF8 byte array.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ReadOnlySpan<byte> ")
                        .Append(utf8PropertyName)
                        .AppendLine(" => ", constantsClassName, ".", utf8FieldName, ";");
                }

                break;

                case JsonValueKind.Number:
                {
                    string jsonFieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: $"Json{suffix}");
                    string rawText = value.GetRawText();
                    string propertyBaseName = rawText.Replace(".", "Point").Replace("-", "Minus");
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope(propertyBaseName, rootScope: enumValuesScope, prefix: "Number");

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the number ", rawText)
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", jsonFieldName, ";");
                }

                break;

                case JsonValueKind.True:
                {
                    string fieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: suffix);
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope("True", rootScope: enumValuesScope);

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the boolean <c>true</c>")
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", fieldName, ";");
                }

                break;

                case JsonValueKind.False:
                {
                    string fieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: suffix);
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope("False", rootScope: enumValuesScope);

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the boolean <c>false</c>")
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", fieldName, ";");
                }

                break;

                case JsonValueKind.Null:
                {
                    string fieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: suffix);
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope("Null", rootScope: enumValuesScope);

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the <c>null</c> value")
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", fieldName, ";");
                }

                break;

                case JsonValueKind.Array:
                case JsonValueKind.Object:
                {
                    string fieldName = generator.GetStaticReadOnlyFieldNameInScope(keywordName, rootScope: constantsScope, suffix: suffix);
                    string propertyBaseName = value.ValueKind == JsonValueKind.Array ? "ArrayValue" : "ObjectValue";
                    string propertyName = generator.GetStaticReadOnlyPropertyNameInScope(propertyBaseName, rootScope: enumValuesScope, suffix: suffix);

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("/// <summary>")
                        .AppendLineIndent("/// Gets the ", value.ValueKind == JsonValueKind.Array ? "array" : "object", " value")
                        .AppendLineIndent("/// as a <see cref=\"", dotnetTypeName, "\"/>.")
                        .AppendLineIndent("/// </summary>")
                        .AppendIndent("public static ")
                        .Append(dotnetTypeName)
                        .Append(" ")
                        .Append(propertyName)
                        .AppendLine(" { get; } = ", constantsClassName, ".", fieldName, ";");
                }

                break;

                default:
                    break;
            }
        }
    }

    private static bool IsNotRequiredInConstantsClass(IValidationConstantProviderKeyword key)
    {
        // We do not require the various numeric constants for validation.
        return key is
            INumberConstantValidationKeyword or IIntegerConstantValidationKeyword or
            IStringLengthConstantValidationKeyword or
            IPropertyCountConstantValidationKeyword or
            IArrayLengthConstantValidationKeyword or IArrayContainsCountConstantValidationKeyword;
    }

    public static CodeGenerator AppendIgnoredCoreTypeStringFormatKeywords(
    this CodeGenerator generator,
    TypeDeclaration typeDeclaration,
    string ignoredMessageProviderName)
    {
        return AppendIgnoredCoreTypeFormatKeywords(generator, typeDeclaration, ignoredMessageProviderName, CoreTypes.String);
    }

    public static CodeGenerator AppendIgnoredCoreTypeNumberFormatKeywords(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
    {
        return generator
            .AppendIgnoredCoreTypeFormatKeywords(typeDeclaration, ignoredMessageProviderName, CoreTypes.Number | CoreTypes.Integer);
    }

    public static CodeGenerator ElseAppendIgnoredCoreTypeStringFormatKeywords(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
    {
        return AppendIgnoredCoreTypeFormatKeywords(generator, typeDeclaration, ignoredMessageProviderName, CoreTypes.String, includeElse: true);
    }

    public static CodeGenerator ElseAppendIgnoredCoreTypeNumberFormatKeywords(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
    {
        return generator
            .AppendIgnoredCoreTypeFormatKeywords(typeDeclaration, ignoredMessageProviderName, CoreTypes.Number | CoreTypes.Integer, includeElse: true);
    }

    public static CodeGenerator AppendIgnoredCoreTypeFormatKeywords(this CodeGenerator generator, TypeDeclaration typeDeclaration, string ignoredMessageProviderName, CoreTypes coreType, bool includeElse = false)
    {
        IEnumerable<IFormatProviderKeyword> ignoredKeywords =
            typeDeclaration
                .Keywords()
                .OfType<IFormatProviderKeyword>();

        bool hasElse = false;

        foreach (IFormatProviderKeyword keyword in ignoredKeywords)
        {
            if (((keyword.ImpliesCoreTypes(typeDeclaration) & coreType) != 0))
            {
                typeDeclaration.AddIgnoredKeyword(keyword);

                if (includeElse && !hasElse)
                {
                    hasElse = true;
                    generator
                        .AppendLineIndent("else")
                        .AppendLineIndent("{")
                        .PushIndent();
                }

                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
            }
        }

        if (hasElse)
        {
            generator
                .PopIndent()
                .AppendLineIndent("}");
        }

        return generator;
    }

    public static CodeGenerator AppendIgnoredCoreTypeKeywords<T>(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName)
            where T : IValidationKeyword
    {
        IEnumerable<T> keywordsToIgnore =
            typeDeclaration
                .Keywords()
                .OfType<T>();

        foreach (T keyword in keywordsToIgnore)
        {
            if (typeDeclaration.AddIgnoredKeyword(keyword))
            {
                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
            }
        }

        return generator;
    }

    public static bool HasIgnoredCoreTypeKeywords<T>(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration)
    {
        return typeDeclaration
        .Keywords()
        .OfType<T>()
        .Any();
    }

    public static CodeGenerator TryAppendIgnoredCoreTypeKeywords<T>(
        this CodeGenerator generator,
        TypeDeclaration typeDeclaration,
        string ignoredMessageProviderName,
        Action<CodeGenerator, TypeDeclaration>? preAppendAction,
        ref bool appended)
        where T : IValidationKeyword
    {
        IEnumerable<T> keywordsToIgnore =
            typeDeclaration
                .Keywords()
                .OfType<T>();

        foreach (T keyword in keywordsToIgnore)
        {
            if (typeDeclaration.AddIgnoredKeyword(keyword))
            {
                if (!appended)
                {
                    preAppendAction?.Invoke(generator, typeDeclaration);
                }

                generator
                    .AppendLineIndent("context.IgnoredKeyword(", ignoredMessageProviderName, ", ", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8);");
                appended |= true;
            }
        }

        return generator;
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
            .AppendLine(" = ParsedJsonDocument<", typeDeclaration.DotnetTypeName(), ">.StringConstant([..", SymbolDisplay.FormatLiteral(value.GetRawText(), true), "u8]);");

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

#if BUILDING_SOURCE_GENERATOR
        JsonElementHelpers.ParseNumber(Encoding.UTF8.GetBytes(value.GetRawText()), out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);
#else
        JsonElementHelpers.ParseNumber(JsonMarshal.GetRawUtf8Value(value), out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);
#endif
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

    /// <summary>
    /// Emits a static <c>EnumStringMap</c> field for oneOf discriminator-based dispatch
    /// when a discriminator property has been detected for the given type declaration.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the fields.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    /// <remarks>
    /// <para>
    /// This is called at JsonSchema class scope so the emitted field is a class-level static.
    /// The field name, discriminator property name, and discriminator values are stored in type
    /// metadata so that the oneOf validation handler can reference them.
    /// </para>
    /// </remarks>
    public static CodeGenerator AppendOneOfDiscriminatorMapFields(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.OneOfCompositionTypes() is not { } oneOf)
        {
            return generator;
        }

        foreach (KeyValuePair<IOneOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> kvp in oneOf)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            IOneOfSubschemaValidationKeyword keyword = kvp.Key;
            IReadOnlyCollection<TypeDeclaration> subschemaTypes = kvp.Value;

            if (!TryGetOneOfDiscriminator(subschemaTypes, out string? discriminatorPropertyName, out List<(string Value, int BranchIndex)>? discriminatorValues))
            {
                continue;
            }

            // Store discriminator metadata for the validation handler to use
            typeDeclaration.SetMetadata(OneOfDiscriminatorPropertyNameKeyPrefix + keyword.Keyword, discriminatorPropertyName);
            typeDeclaration.SetMetadata(OneOfDiscriminatorValuesKeyPrefix + keyword.Keyword, discriminatorValues);

            // Only emit a hash map field when there are enough branches to justify it
            if (discriminatorValues.Count > MinEnumValuesForHashSet)
            {
                string fieldName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("OneOfDiscriminatorMap");
                string builderName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("BuildOneOfDiscriminatorMap");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private static EnumStringMap ", builderName, "()")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return new EnumStringMap([")
                        .PushIndent();

                foreach ((string value, _) in discriminatorValues)
                {
                    string quotedValue = SymbolDisplay.FormatLiteral(value, true);
                    generator
                        .AppendLineIndent("static () => ", quotedValue, "u8,");
                }

                generator
                        .PopIndent()
                        .AppendLineIndent("]);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendSeparatorLine()
                    .AppendLineIndent("private static EnumStringMap ", fieldName, " { get; } = ", builderName, "();");

                typeDeclaration.SetMetadata(OneOfDiscriminatorMapFieldNameKeyPrefix + keyword.Keyword, fieldName);
            }
        }

        return generator;
    }

    /// <summary>
    /// Tries to get the discriminator metadata for a oneOf keyword.
    /// </summary>
    /// <param name="typeDeclaration">The type declaration.</param>
    /// <param name="keywordName">The keyword name (e.g. "oneOf").</param>
    /// <param name="discriminatorPropertyName">When successful, the JSON property name of the discriminator.</param>
    /// <param name="discriminatorValues">When successful, the list of (value, branchIndex) pairs.</param>
    /// <param name="mapFieldName">When successful and a hash map was emitted, the field name; otherwise <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if discriminator metadata was found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetOneOfDiscriminatorMetadata(
        this TypeDeclaration typeDeclaration,
        string keywordName,
        [NotNullWhen(true)] out string? discriminatorPropertyName,
        [NotNullWhen(true)] out List<(string Value, int BranchIndex)>? discriminatorValues,
        out string? mapFieldName)
    {
        discriminatorPropertyName = null;
        discriminatorValues = null;
        mapFieldName = null;

        if (!typeDeclaration.TryGetMetadata(OneOfDiscriminatorPropertyNameKeyPrefix + keywordName, out string? propName) ||
            propName is null ||
            !typeDeclaration.TryGetMetadata(OneOfDiscriminatorValuesKeyPrefix + keywordName, out List<(string Value, int BranchIndex)>? values) ||
            values is null)
        {
            return false;
        }

        discriminatorPropertyName = propName;
        discriminatorValues = values;
        typeDeclaration.TryGetMetadata(OneOfDiscriminatorMapFieldNameKeyPrefix + keywordName, out mapFieldName);
        return true;
    }

    /// <summary>
    /// Emits static <see cref="EnumStringSet"/> fields for any-of constant validation keywords
    /// that have more than <see cref="MinEnumValuesForHashSet"/> string enum values.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the fields.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    /// <remarks>
    /// This is called at JsonSchema class scope so the emitted fields are class-level statics.
    /// The field names are stored in type metadata so that the validation code can reference them.
    /// </remarks>
    public static CodeGenerator AppendEnumStringSetFields(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (typeDeclaration.AnyOfConstantValues() is not IReadOnlyDictionary<IAnyOfConstantValidationKeyword, JsonElement[]> constDictionary)
        {
            return generator;
        }

        foreach (KeyValuePair<IAnyOfConstantValidationKeyword, JsonElement[]> entry in constDictionary)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            IAnyOfConstantValidationKeyword keyword = entry.Key;
            JsonElement[] elements = entry.Value;

            JsonElement[] stringValues = elements.Where(e => e.ValueKind == JsonValueKind.String).ToArray();

            if (stringValues.Length <= MinEnumValuesForHashSet)
            {
                continue;
            }

            string fieldName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("EnumStringSet");
            string builderName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("BuildEnumStringSet");

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private static EnumStringSet ", builderName, "()")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("return new EnumStringSet([")
                    .PushIndent();

            foreach (JsonElement value in stringValues)
            {
                string quotedValue = SymbolDisplay.FormatLiteral(value.GetString()!, true);
                generator
                    .AppendLineIndent("static () => ", quotedValue, "u8,");
            }

            generator
                    .PopIndent()
                    .AppendLineIndent("]);")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendSeparatorLine()
                .AppendLineIndent("private static EnumStringSet ", fieldName, " { get; } = ", builderName, "();");

            typeDeclaration.SetMetadata(EnumStringSetFieldNameKeyPrefix + keyword.Keyword, fieldName);
        }

        return generator;
    }

    /// <summary>
    /// Tries to get the name of the <see cref="EnumStringSet"/> field that was emitted for the
    /// given keyword, if one was generated.
    /// </summary>
    /// <param name="typeDeclaration">The type declaration.</param>
    /// <param name="keywordName">The keyword name (e.g. "enum").</param>
    /// <param name="fieldName">When this method returns <see langword="true"/>, contains the field name.</param>
    /// <returns><see langword="true"/> if a hash set field was emitted; otherwise <see langword="false"/>.</returns>
    public static bool TryGetEnumStringSetFieldName(this TypeDeclaration typeDeclaration, string keywordName, [NotNullWhen(true)] out string? fieldName)
    {
        return typeDeclaration.TryGetMetadata(EnumStringSetFieldNameKeyPrefix + keywordName, out fieldName);
    }

    /// <summary>
    /// Tries to detect a discriminator property across oneOf subschemas.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A discriminator is a property that is (1) present in ALL oneOf branches,
    /// (2) required in every branch, (3) has a single string constant value in each
    /// branch (either <c>const: "X"</c> or <c>enum: ["X"]</c>), and (4) all values
    /// are distinct across branches.
    /// </para>
    /// </remarks>
    /// <param name="subschemaTypes">The oneOf branch type declarations.</param>
    /// <param name="discriminatorPropertyName">When successful, the JSON property name of the discriminator.</param>
    /// <param name="discriminatorValues">When successful, a list of (utf8Value, branchIndex) pairs in branch order.</param>
    /// <returns><see langword="true"/> if a discriminator was detected; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetOneOfDiscriminator(
        IReadOnlyCollection<TypeDeclaration> subschemaTypes,
        [NotNullWhen(true)] out string? discriminatorPropertyName,
        [NotNullWhen(true)] out List<(string Value, int BranchIndex)>? discriminatorValues)
    {
        discriminatorPropertyName = null;
        discriminatorValues = null;

        if (subschemaTypes.Count < 2)
        {
            return false;
        }

        // Collect property declarations for each branch
        TypeDeclaration[] branches = subschemaTypes.ToArray();

        // Get candidate property names from the first branch
        IReadOnlyList<PropertyDeclaration> firstBranchProps = branches[0].PropertyDeclarations;

        foreach (PropertyDeclaration candidateProp in firstBranchProps)
        {
            if (candidateProp.RequiredOrOptional == RequiredOrOptional.Optional)
            {
                continue;
            }

            string candidateName = candidateProp.JsonPropertyName;

            // Try to extract a single string constant from this candidate in the first branch
            if (!TryGetSingleStringConstant(candidateProp, out string? firstValue))
            {
                continue;
            }

            // Now check all remaining branches
            var values = new List<(string Value, int BranchIndex)>(branches.Length)
            {
                (firstValue, 0),
            };

            HashSet<string> seenValues = [firstValue];
            bool isDiscriminator = true;

            for (int i = 1; i < branches.Length; i++)
            {
                PropertyDeclaration? matchingProp = FindPropertyByName(branches[i].PropertyDeclarations, candidateName);

                if (matchingProp is null ||
                    matchingProp.RequiredOrOptional == RequiredOrOptional.Optional ||
                    !TryGetSingleStringConstant(matchingProp, out string? branchValue) ||
                    !seenValues.Add(branchValue))
                {
                    isDiscriminator = false;
                    break;
                }

                values.Add((branchValue, i));
            }

            if (isDiscriminator)
            {
                discriminatorPropertyName = candidateName;
                discriminatorValues = values;
                return true;
            }
        }

        return false;
    }

    private static bool TryGetSingleStringConstant(PropertyDeclaration prop, [NotNullWhen(true)] out string? value)
    {
        value = null;
        TypeDeclaration propType = prop.UnreducedPropertyType;

        // Check const keyword first
        JsonElement constValue = propType.SingleConstantValue();
        if (constValue.ValueKind == JsonValueKind.String)
        {
            value = constValue.GetString()!;
            return true;
        }

        // Check enum keyword for single-value string enum (e.g. enum: ["Point"])
        if (propType.AnyOfConstantValues() is IReadOnlyDictionary<IAnyOfConstantValidationKeyword, JsonElement[]> constDict)
        {
            foreach (KeyValuePair<IAnyOfConstantValidationKeyword, JsonElement[]> entry in constDict)
            {
                JsonElement[] stringElements = entry.Value.Where(e => e.ValueKind == JsonValueKind.String).ToArray();
                if (stringElements.Length == 1 && entry.Value.Length == 1)
                {
                    value = stringElements[0].GetString()!;
                    return true;
                }
            }
        }

        return false;
    }

    private static PropertyDeclaration? FindPropertyByName(IReadOnlyList<PropertyDeclaration> properties, string jsonPropertyName)
    {
        foreach (PropertyDeclaration prop in properties)
        {
            if (prop.JsonPropertyName == jsonPropertyName)
            {
                return prop;
            }
        }

        return null;
    }
}