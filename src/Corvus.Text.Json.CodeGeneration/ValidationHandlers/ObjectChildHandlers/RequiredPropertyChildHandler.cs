// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

internal class RequiredPropertyChildHandler : INamedPropertyChildHandler
{
    private const string RentedRequiredPropertyCountArrayKey = "RequiredPropertyChildHandler_RentedRequiredPropertyCountArray";
    private const string BitMaskListKey = "RequiredPropertyChildHandler_BitMaskOffsetList";
    private const string PropertyOffsetListKey = "RequiredPropertyChildHandler_PropertyOffsetList";
    private const string BitMaskByPropertyKey = "RequiredPropertyChildHandler_BitMaskByProperty";

    /// <summary>
    /// Gets the singleton instance of the <see cref="RequiredPropertyChildHandler"/>.
    /// </summary>
    public static RequiredPropertyChildHandler Instance { get; } = CreateDefaultInstance();

    private static RequiredPropertyChildHandler CreateDefaultInstance()
    {
        return new();
    }

    /// <inheritdoc/>
    public uint ValidationHandlerPriority => ValidationPriorities.AfterComposition + 1000; // We are comparatively expensive, so we should go later

    /// <inheritdoc/>
    public bool AppendJsonSchemaClassSetupForProperty(CodeGenerator generator, TypeDeclaration typeDeclaration, PropertyDeclaration property)
    {
        return property.LocalOrComposed == LocalOrComposed.Local && property.RequiredOrOptional == RequiredOrOptional.Required;
    }

    public void AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
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

    }

    /// <inheritdoc/>
    public void AppendObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration, PropertyDeclaration property)
    {
        if (!typeDeclaration.TryGetMetadata(BitMaskByPropertyKey, out Dictionary<PropertyDeclaration, (string OffsetName, string BitMaskName)>? bitMasksByProperty) ||
            bitMasksByProperty is null ||
            !bitMasksByProperty.TryGetValue(property, out (string OffsetName, string BitMaskName) bitMaskInfo))
        {
            return;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("requiredBitBuffer[", bitMaskInfo.OffsetName, "] |= ", bitMaskInfo.BitMaskName, ";");

    }

    /// <inheritdoc/>
    public void AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(BitMaskListKey, out List<string>? bitmaskOffsetList))
        {
            return;
        }

        if (!typeDeclaration.TryGetMetadata(PropertyOffsetListKey, out List<(string OffsetName, string RequiredPropertyPresent, string RequiredPropertyNotPresent, string RequiredSchemaEvaluationPathName)>? propertyOffsetList))
        {
            return;
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
            foreach (var bitmaskOffset in bitmaskOffsetList)
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

                for (int j = i; j < Math.Min(i + 32, propertyOffsetList.Count); ++j)
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
    }

    /// <inheritdoc/>
    public void AppendValidatorArguments(CodeGenerator generator, TypeDeclaration typeDeclaration) {}

    /// <inheritdoc/>
    public void BeginJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        List<PropertyDeclaration> properties = typeDeclaration.ExplicitProperties()?.Where(p => p.LocalOrComposed == LocalOrComposed.Local && p.RequiredOrOptional == RequiredOrOptional.Required)?.ToList() ?? [];

        if (properties.Count == 0)
        {
            return;
        }

        Dictionary<PropertyDeclaration, (string OffsetName, string BitMaskName)> bitmasksByProperty = [];

        List<(string OffsetName, string RequiredPropertyPresent, string RequiredPropertyNotPresent, string RequiredSchemaEvaluationPathName)> propertyOffsetList = [];

        int requiredOffset = 0;
        int requiredBit = 0b0000_0000_0000_0001;
        List<string> bitmasks = new(32);
        Dictionary<string, string> seenKeywords = [];

        string currentBitMaskOffsetName = generator.GetStaticReadOnlyFieldNameInScope($"BitMaskOffset{requiredOffset}");

        foreach (PropertyDeclaration property in properties)
        {           
            string? offsetName = null;
            string? bitMask = null;

            string propertyName = property.DotnetPropertyName();
            offsetName = generator.GetStaticReadOnlyFieldNameInScope("RequiredOffset", prefix: propertyName);
            bitMask = generator.GetStaticReadOnlyFieldNameInScope("RequiredBitMask", prefix: propertyName);

            bitmasksByProperty.Add(property, (offsetName, bitMask));

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
                AppendBitMaskOffset(generator, currentBitMaskOffsetName, requiredOffset, bitmasks);
                generator
                    .AppendSeparatorLine();

                bitmasks.Clear();
                requiredOffset++;
                requiredBit = 0b0000_0000_0000_0001;
                currentBitMaskOffsetName = generator.GetStaticReadOnlyFieldNameInScope($"BitMaskOffset{requiredOffset}");
            }
            else
            {
                requiredBit <<= 1;
            }
        }

        if (bitmasks.Count > 0)
        {
            AppendBitMaskOffset(generator, currentBitMaskOffsetName, requiredOffset, bitmasks);
        }


        if (bitmasksByProperty.Count > 0)
        {
            typeDeclaration.SetMetadata(BitMaskListKey, bitmasksByProperty);
            typeDeclaration.SetMetadata(PropertyOffsetListKey, propertyOffsetList);
        }
    }

    private static void AppendBitMaskOffset(CodeGenerator generator, string bitMaskOffsetName, int requiredOffset, List<string> bitMasks)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("private const int ", bitMaskOffsetName, " =")
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

    /// <inheritdoc/>
    public void EndJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration) {}

    /// <inheritdoc/>
    public IEnumerable<ObjectPropertyValidatorParameter> GetNamedPropertyValidatorParameters(TypeDeclaration typeDeclaration) => [];

    /// <inheritdoc/>
    public bool WillEmitCodeFor(TypeDeclaration typeDeclaration) => typeDeclaration.ExplicitProperties()?.Any(p => p.LocalOrComposed == LocalOrComposed.Local && p.RequiredOrOptional == RequiredOrOptional.Required) ?? false;
}
