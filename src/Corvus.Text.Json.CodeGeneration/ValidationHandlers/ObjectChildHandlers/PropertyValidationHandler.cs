// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

/// <summary>
/// A property validation handler.
/// </summary>
public class PropertyValidationHandler : IChildObjectPropertyValidationHandler, IJsonSchemaClassSetup
{
    private const string RentedRequiredPropertyCountArrayKey = "PropertyValidationHandler_RentedRequiredPropertyCountArray";
    private const string BitMaskListKey = "PropertyValidationHandler_BitMaskOffsetList";
    private const string PropertyOffsetListKey = "PropertyValidationHandler_PropertyOffsetList";

    /// <summary>
    /// Gets the singleton instance of the <see cref="PropertyValidationHandler"/>.
    /// </summary>
    public static PropertyValidationHandler Instance { get; } = new();

    /// <inheritdoc/>
    public uint ValidationHandlerPriority { get; } = ValidationPriorities.AfterComposition + 1;


    public CodeGenerator AppendObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        bool hasSeenItems = typeDeclaration.TryGetMetadata(BitMaskListKey, out List<string>? _);

        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("if (TryGetNamedMatcher(objectValidation_unescapedPropertyName.Span, out ", hasSeenItems ? "JsonSchemaMatcherWithRequiredBitBuffer" : "JsonSchemaMatcher", "? validator))")
            .AppendLineIndent("{")
            .PushIndent()
            .AppendLineIndent("context.AddLocalEvaluatedProperty(objectValidation_propertyCount);")
            .AppendLineIndent("validator(parentDocument, objectValidation_currentIndex, ref context", hasSeenItems ? ", objectValidation_seenItems" : "", ");")
            .AppendNoCollectorNoMatchShortcutReturn()
            .PopIndent()
            .AppendLineIndent("}");
    }

    public CodeGenerator AppendValidateMethodSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        return generator;
    }

    public CodeGenerator AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(BitMaskListKey, out List<string>? bitmaskOffsetList))
        {
            return generator;
        }

        if (!typeDeclaration.TryGetMetadata(PropertyOffsetListKey, out List<(string OffsetName, string RequiredPropertyPresent, string RequiredPropertyNotPresent, string RequiredSchemaEvaluationPathName)>? propertyOffsetList))
        {
            return generator;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("// Do a quick test to see if we have all of the required bits set in each element")
            .AppendLineIndent("if (")
            .PushIndent();

        int i = 0;
        foreach (string bitmaskOffset in bitmaskOffsetList)
        {
            generator
                .AppendIndent("((objectValidation_seenItems[", i.ToString(), "] ^ ", bitmaskOffset, ") == 0)")
                .ConditionallyAppend(i > 0 && i < (bitmaskOffsetList.Count - 1), g => g.AppendLine(" &&"))
                .ConditionallyAppend(i == 0 && i < (bitmaskOffsetList.Count - 1), g => g.AppendLine())
                .ConditionallyAppend(i == (bitmaskOffsetList.Count - 1), g => g.AppendLine(")"));
            i++;
        }

        generator
            .PopIndent()
            .AppendLineIndent("{")
            .PushIndent();
        
        for (i = 0; i < propertyOffsetList.Count; ++i)
        {
            generator
                .AppendLineIndent("context.EvaluatedKeywordPath(true, ", i.ToString(), ", ", propertyOffsetList[i].RequiredPropertyPresent, ", ", propertyOffsetList[i].RequiredSchemaEvaluationPathName, ");");

        }

        generator
            .PopIndent()
            .AppendLineIndent("}")
            .AppendLineIndent("else if (!context.HasCollector)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("context.EvaluatedBooleanSchema(false);")
                .AppendLineIndent("return;")
            .PopIndent()
            .AppendLineIndent("}")
            .AppendLineIndent("else")
            .AppendLineIndent("{")
            .PushIndent();

        i = 0;

        while (i < propertyOffsetList.Count)
        {
            int bitmaskOffsetIndex = 0;
            foreach(var bitmaskOffset in bitmaskOffsetList)
            {
                if (bitmaskOffsetList.Count > 1)
                {
                    // We don't need to do this test again if we have only 1 item in the array => < 32 required properties.
                    // (Which is typical for most JSON object schema)
                    generator
                        .AppendLineIndent("if ((objectValidation_seenItems[", bitmaskOffsetIndex.ToString(), "] ^ ", bitmaskOffset, ") != 0)")
                        .AppendLineIndent("{")
                        .PushIndent();
                }

                for(int j = i; j < Math.Min(i + 32, propertyOffsetList.Count); ++j)
                {
                    var propertyOffset = propertyOffsetList[j];
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if ((objectValidation_seenItems[", bitmaskOffsetIndex.ToString(), "] & ", propertyOffset.OffsetName, ") == 0)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("context.EvaluatedKeywordPath(false, ", j.ToString(), ", ", propertyOffset.RequiredPropertyNotPresent, ", ", propertyOffset.RequiredSchemaEvaluationPathName, ");")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendLineIndent("else")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("context.EvaluatedKeywordPath(true, ", j.ToString(), ", ", propertyOffset.RequiredPropertyPresent, ", ", propertyOffset.RequiredSchemaEvaluationPathName, ");")
                        .PopIndent()
                        .AppendLineIndent("}");

                }

                if (bitmaskOffsetList.Count > 1)
                {
                    generator
                        .PopIndent()
                        .AppendLineIndent("}");
                }

                i += 32;
                bitmaskOffsetIndex++;
            }
        }

        generator
            .PopIndent()
            .AppendLineIndent("}");

        if (typeDeclaration.TryGetMetadata(RentedRequiredPropertyCountArrayKey, out bool? rentedRequiredPropertyCountArray))
        {
            if (rentedRequiredPropertyCountArray.HasValue && rentedRequiredPropertyCountArray.Value)
            {
                generator
                    .AppendLineIndent("ArrayPool<int>.Shared.Return(objectValidation_seenItemsByteArray);");
            }
        }

        return generator;
    }

    public CodeGenerator AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        int requiredPropertyCount = typeDeclaration.ExplicitRequiredProperties()?.Count(p => p.LocalOrComposed == LocalOrComposed.Local) ?? 0;

        int requiredPropertyIntCount = (int)Math.Ceiling(requiredPropertyCount / 32.0);
        bool rentedRequiredPropertyCountArray = requiredPropertyIntCount >= 256;

        typeDeclaration.SetMetadata(RentedRequiredPropertyCountArrayKey, rentedRequiredPropertyCountArray);

        if (requiredPropertyIntCount > 0)
        {
            generator
                .ReserveName("objectValidation_seenItems")
                .ReserveName("objectValidation_seenItemsByteArray")
                .ConditionallyAppend(!rentedRequiredPropertyCountArray, g => g.AppendLineIndent("Span<int> objectValidation_seenItems = stackalloc int[", requiredPropertyCount.ToString(), "];")
                .ConditionallyAppend(rentedRequiredPropertyCountArray, g =>
                {
                    return g
                        .AppendLineIndent("int[]? objectValidation_seenItemsByteArray = ArrayPool<int>.Shared.Rent(", requiredPropertyCount.ToString(), ");")
                        .AppendLineIndent("Span<int> objectValidation_seenItems = objectValidation_seenItemsByteArray.Slice(0, requiredPropertyCount);");
                }));
        }

        return generator;
    }


    public bool RequiresPropertyNameAsString(TypeDeclaration typeDeclaration) => true;


    public CodeGenerator AppendJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        int requiredOffset = 0;
        int requiredBit = 0b0000_0000_0000_0001;
        List<string> bitmasks = new(32);

        List<PropertyDeclaration> properties = typeDeclaration.ExplicitProperties()?.Where(p => p.LocalOrComposed == LocalOrComposed.Local)?.ToList() ?? [];
        List<(string, string)> propertyAndMethodNames = [];

        string jsonPropertyNamesClassName = generator.JsonPropertyNamesClassName();

        List<string> bitmaskList = [];
        List<(string OffsetName, string RequiredPropertyPresent, string RequiredPropertyNotPresent, string RequiredSchemaEvaluationPathName)> propertyOffsetList = [];

        Dictionary<string, string> seenKeywords = [];

        bool hasRequiredProperties = typeDeclaration.ExplicitRequiredProperties()?.Any(e => e.LocalOrComposed == LocalOrComposed.Local) ?? false;

        foreach (PropertyDeclaration property in properties)
        {
            string propertyName = property.DotnetPropertyName();

            string methodName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("Match", suffix: propertyName);

            propertyAndMethodNames.Add((propertyName, methodName));

            string propertyClassName = property.ReducedPropertyType.FullyQualifiedDotnetTypeName();
            string jsonSchemaClassName = generator.JsonSchemaClassName(propertyClassName);
            string evaluationPathProperty = generator.GetPropertyNameInScope($"{property.DotnetPropertyName()}SchemaEvaluationPath");

            string? offsetName = null;
            string? bitMask = null;

            if (property.RequiredOrOptional == RequiredOrOptional.Required)
            {
                offsetName = generator.GetStaticReadOnlyFieldNameInScope("RequiredOffset", prefix: propertyName);
                bitMask = generator.GetStaticReadOnlyFieldNameInScope("RequiredBitMask", prefix: propertyName);

                string keyword = property.RequiredKeyword.Keyword;
                string keywordPathModifier = property.KeywordPathModifier;


                if (!seenKeywords.TryGetValue(keyword, out string requiredSchemaEvaluationPathName))
                {
                    requiredSchemaEvaluationPathName = generator.GetStaticReadOnlyFieldNameInScope("SchemaEvaluationPath", prefix: keyword);
                    seenKeywords.Add(keyword, requiredSchemaEvaluationPathName);
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "private static readonly JsonSchemaPathProvider<int> ",
                            requiredSchemaEvaluationPathName,
                            " = static (index, buffer, out written) => JsonSchemaEvaluation.SchemaLocationForIndexedKeyword(", SymbolDisplay.FormatLiteral(keyword, true), "u8, index, buffer, out written);");
                }

                string requiredPropertyPresent = generator.GetStaticReadOnlyFieldNameInScope(property.DotnetPropertyName(), prefix: "RequiredProperty", suffix: "Present");
                string requiredPropertyNotPresent = generator.GetStaticReadOnlyFieldNameInScope(property.DotnetPropertyName(), prefix: "RequiredProperty", suffix: "NotPresent");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent(
                        "private static readonly JsonSchemaMessageProvider<int> ",
                        requiredPropertyPresent,
                        " = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyPresent(",
                        SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                        "u8, buffer, out written);")
                    .AppendLineIndent(
                        "private static readonly JsonSchemaMessageProvider<int> ",
                        requiredPropertyNotPresent,
                        " = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyNotPresent(",
                        SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                        "u8, buffer, out written);")
                    .AppendSeparatorLine()
                    .AppendLineIndent("private const int ", offsetName, " = ", requiredOffset.ToString(), ";")
                    .AppendLineIndent("private const int ", bitMask, " = 0b", requiredBit.ToString("b32"), ";");

                bitmasks.Add(bitMask);
                propertyOffsetList.Add((offsetName, requiredPropertyPresent, requiredPropertyNotPresent, requiredSchemaEvaluationPathName));

                if (bitmasks.Count == 32)
                {
                    AppendBitMaskOffset(generator, requiredOffset, bitmasks, bitmaskList);

                    generator
                        .AppendSeparatorLine();

                    bitmasks.Clear();
                    requiredOffset++;
                    requiredBit = 0b0000_0000_0000_0001;
                }
                else
                {
                    requiredBit <<= 1;
                }
            }

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private static void ", methodName, "(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context", hasRequiredProperties ? ", Span<int> requiredBitBuffer" : "", ")")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("JsonSchemaContext childContext =")
                    .PushIndent()
                        .AppendLineIndent(propertyClassName, ".", jsonSchemaClassName, ".PushChildContextUnescaped(")
                        .PushIndent()
                            .AppendLineIndent("parentDocument,")
                            .AppendLineIndent("parentDocumentIndex,")
                            .AppendLineIndent("ref context,")
                            .AppendLineIndent(jsonPropertyNamesClassName, ".", propertyName, "Utf8,")
                            .AppendLineIndent("evaluationPath: ", evaluationPathProperty, ");")
                        .PopIndent()
                    .PopIndent()
                    .AppendSeparatorLine()
                    .AppendLineIndent(propertyClassName, ".", jsonSchemaClassName, ".Evaluate(parentDocument, parentDocumentIndex, ref childContext);")
                    .AppendLineIndent("context.CommitChildContext(childContext.IsMatch, ref childContext);")
                    .ConditionallyAppend(offsetName is not null && bitMask is not null, g => g.AppendLineIndent("requiredBitBuffer[", offsetName!, "] |= ", bitMask!, ";"))
                .PopIndent()
                .AppendLineIndent("}");

        }

        if (bitmasks.Count > 0)
        {
            AppendBitMaskOffset(generator, requiredOffset, bitmasks, bitmaskList);
        }


        if (bitmaskList.Count > 0)
        {
            typeDeclaration.SetMetadata(BitMaskListKey, bitmaskList);
            typeDeclaration.SetMetadata(PropertyOffsetListKey, propertyOffsetList);
        }

        const int MinPropertiesForMap = 1;

        if (propertyAndMethodNames.Count > MinPropertiesForMap)
        {
            string mapName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("Matchers");
            string builderName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("MatchersBuilder");

            // We are building the map.
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private static PropertySchemaMatchers ", builderName, "()")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("return new PropertySchemaMatchers([")
                    .PushIndent();

            foreach ((string propertyName, string methodName) in propertyAndMethodNames)
            {
                string formattedPropertyName = SymbolDisplay.FormatLiteral(propertyName, true);
                generator
                        .AppendLineIndent("(static () => ", jsonPropertyNamesClassName, ".", propertyName, "Utf8, ", methodName, "),");
            }

            generator
                    .PopIndent()
                    .AppendLineIndent("]);")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendSeparatorLine()
                .AppendLineIndent("private static PropertySchemaMatchers ", mapName, " { get; } = ", builderName, "();")
                .AppendSeparatorLine()
                .ReserveName("TryGetNamedMatcher")
                .AppendLineIndent("private static bool TryGetNamedMatcher(ReadOnlySpan<byte> span, [NotNullWhen(true)] out ", hasRequiredProperties ? "JsonSchemaMatcherWithRequiredBitBuffer" : "JsonSchemaMatcher", "? matcher)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("return ", mapName, ".TryGetNamedMatcher(span, out matcher);")
                .PopIndent()
                .AppendLineIndent("}");
        }
        else
        {
            generator
                .AppendSeparatorLine()
                .ReserveName("TryGetNamedMatcher")
                .AppendLineIndent("private static bool TryGetNamedMatcher(ReadOnlySpan<byte> span, [NotNullWhen(true)] out ", hasRequiredProperties ? "JsonSchemaMatcherWithRequiredBitBuffer" : "JsonSchemaMatcher", "? matcher)")
                .AppendLineIndent("{")
                .PushIndent();


            foreach ((string propertyName, string methodName) in propertyAndMethodNames)
            {
                generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (span.SequenceEqual(", jsonPropertyNamesClassName, ".", propertyName, "Utf8))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("matcher = ", methodName, ";")
                            .AppendLineIndent("return true;")
                        .PopIndent()
                        .AppendLineIndent("}");
            }

            generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("matcher = default;")
                    .AppendLineIndent("return false;")
                .PopIndent()
                .AppendLineIndent("}");
        }


        return generator;
    }

    private static void AppendBitMaskOffset(CodeGenerator generator, int requiredOffset, List<string> bitMasks, List<string> bitMasksList)
    {
        string bitMaskOffset = generator.GetStaticReadOnlyFieldNameInScope($"BitMaskOffset{requiredOffset}");

        bitMasksList.Add(bitMaskOffset);

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("private const int ", bitMaskOffset, " =")
            .PushIndent();

        int count = 0;

        bool needsAppendLine = false;
        foreach (var item in bitMasks)
        {
            if (needsAppendLine)
            {
                generator
                    .AppendLine(" |");
                needsAppendLine = false;
            }

            switch (count % 4)
            {
                case 0:
                    generator
                       .AppendIndent(item);
                    break;
                case 3:
                    generator
                       .Append(" | ")
                       .Append(item);
                    needsAppendLine = true;
                    break;
                default:
                    generator
                       .Append(" | ")
                       .Append(item);
                    break;
            }

            count++;
        }

        generator.AppendLine(";");
    }
}

public static class PropertyValidationExtensions
{
}
