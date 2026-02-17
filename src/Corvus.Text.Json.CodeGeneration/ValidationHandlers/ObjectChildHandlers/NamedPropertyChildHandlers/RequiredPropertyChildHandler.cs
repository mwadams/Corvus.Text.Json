// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration.ValidationHandlers.ObjectChildHandlers;

/// <summary>
/// Handles required and dependent required validation semantics.
/// </summary>
internal class RequiredPropertyChildHandler : INamedPropertyChildHandler
{
    private const string RequirementsAndDependenciesKey = "RequiredPropertyChildHandler_RequirementsAndDependencies";
    private const string RentedRequiredPropertyCountArrayKey = "RequiredPropertyChildHandler_RentedRequiredPropertyCountArray";

    /// <summary>
    /// Gets the singleton instance of the <see cref="RequiredPropertyChildHandler"/>.
    /// </summary>
    public static RequiredPropertyChildHandler Instance { get; } = CreateDefaultInstance();

    private static RequiredPropertyChildHandler CreateDefaultInstance()
    {
        return new();
    }

    /// <inheritdoc/>
    public uint ValidationHandlerPriority => ValidationPriorities.AfterComposition + 100; // We are comparatively cheap, so we should go early


    /// <inheritdoc/>
    public bool EvaluatesProperty(PropertyDeclaration property) => false;

    /// <inheritdoc/>
    public bool AppendJsonSchemaClassSetupForProperty(CodeGenerator generator, TypeDeclaration typeDeclaration, PropertyDeclaration property)
    {
        return (typeDeclaration.DependentRequired()?.Any(dr => dr.Value.Any(d => d.JsonPropertyName == property.JsonPropertyName)) ?? false) || GetRequiredProperties(typeDeclaration).Any(p => p == property);
    }

    public void AppendValidationSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(RequirementsAndDependenciesKey, out RequirementsAndDependencies? requirementsAndDependencies) ||
            requirementsAndDependencies is null ||
            requirementsAndDependencies.RequirementsByRequiredPropertyName.Count == 0)
        {
            return;
        }

        int requiredPropertyIntCount = (int)Math.Ceiling(requirementsAndDependencies.RequirementsByRequiredPropertyName.Count / 32.0);
        bool rentedRequiredPropertyCountArray = requiredPropertyIntCount >= 256;

        typeDeclaration.SetMetadata(RentedRequiredPropertyCountArrayKey, rentedRequiredPropertyCountArray);

        string requiredPropertyIntCountAsString = requiredPropertyIntCount.ToString();

        generator
            .ReserveName("requiredPropertyChildHandler_seenItems")
            .ReserveName("requiredPropertyChildHandler_seenItemsByteArray")
            .ConditionallyAppend(!rentedRequiredPropertyCountArray, g => g.AppendLineIndent("Span<int> requiredPropertyChildHandler_seenItems = stackalloc int[", requiredPropertyIntCountAsString, "];")
            .ConditionallyAppend(rentedRequiredPropertyCountArray, g =>
            {
                return g
                    .AppendLineIndent("int[]? requiredPropertyChildHandler_seenItemsByteArray = ArrayPool<int>.Shared.Rent(", requiredPropertyIntCountAsString, ");")
                    .AppendLineIndent("Span<int> requiredPropertyChildHandler_seenItems = requiredPropertyChildHandler_seenItemsByteArray.Slice(0, requiredPropertyCount);");
            }));
    }

    /// <inheritdoc/>
    public void AppendObjectPropertyValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration, PropertyDeclaration property)
    {
        if (!typeDeclaration.TryGetMetadata(RequirementsAndDependenciesKey, out RequirementsAndDependencies? requirementsAndDependencies) ||
            requirementsAndDependencies is null ||
            !requirementsAndDependencies.RequirementsByRequiredPropertyName.TryGetValue(property.JsonPropertyName, out Requirement requirement))
        {
            return;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("requiredBitBuffer[", requirement.OffsetForPropertyName, "] |= ", requirement.BitForPropertyName, ";");

    }

    /// <inheritdoc/>
    public void AppendValidationCode(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(RequirementsAndDependenciesKey, out RequirementsAndDependencies? requirementsAndDependencies) ||
            requirementsAndDependencies is null ||
            requirementsAndDependencies.RequirementsByRequiredPropertyName.Count == 0)
        {
            return;
        }

        foreach (PropertyDependencies propertyDependencies in requirementsAndDependencies.Dependencies)
        {
            AppendPropertyDependenciesValidation(generator, typeDeclaration, propertyDependencies);
        }

        if (typeDeclaration.TryGetMetadata(RentedRequiredPropertyCountArrayKey, out bool? rentedRequiredPropertyCountArray))
        {
            if (rentedRequiredPropertyCountArray.HasValue && rentedRequiredPropertyCountArray.Value)
            {
                generator
                    .AppendLineIndent("ArrayPool<int>.Shared.Return(requiredPropertyChildHandler_seenItemsByteArray);");
            }
        }
    }

    private static void AppendPropertyDependenciesValidation(CodeGenerator generator, TypeDeclaration typeDeclaration, PropertyDependencies propertyDependencies)
    {
        if (!propertyDependencies.Dependencies.Any(d => d.Requirements.Count > 0))
        {
            return;
        }

        if (propertyDependencies.PropertyName is not null)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("if ((requiredPropertyChildHandler_seenItems[", propertyDependencies.OffsetForPropertyName.ToString(), "] & ", propertyDependencies.BitForPropertyName.ToString(), ") != 0)")
                .AppendLineIndent("{")
                .PushIndent();
        }

        foreach (var propertyDependency in propertyDependencies.Dependencies)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("// Do a quick test to see if we have all of the required bits set in each element")
                .AppendLineIndent("if ((~(requiredPropertyChildHandler_seenItems[", propertyDependency.OffsetForBitMask.ToString(), "]) & ", propertyDependency.BitmaskMaskName, ") == 0)")
                .AppendLineIndent("{")
                .PushIndent();

            foreach (Requirement requirement in propertyDependency.Requirements)
            {
                Debug.Assert(requirement.RequiredSchemaEvaluationPathName is not null);
                Debug.Assert(requirement.IndexForEvaluationProvider is not null);
                Debug.Assert(requirement.RequiredPropertyMessageProviderNames is not null);

                generator
                    .AppendLineIndent("context.EvaluatedKeywordPath(true, ", requirement.IndexForEvaluationProvider!.Value.ToString(), ", ", requirement.RequiredPropertyMessageProviderNames.RequiredPropertyPresent, ", ", requirement.RequiredSchemaEvaluationPathName!, ");");
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

            foreach(Requirement requirement in propertyDependency.Requirements)
            {
                Debug.Assert(requirement.RequiredSchemaEvaluationPathName is not null);
                Debug.Assert(requirement.IndexForEvaluationProvider is not null);
                Debug.Assert(requirement.RequiredPropertyMessageProviderNames is not null);

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("if ((requiredPropertyChildHandler_seenItems[", requirement.OffsetForPropertyName, "] & ", requirement.BitForPropertyName, ") == 0)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("context.EvaluatedKeywordPath(false, ", requirement.IndexForEvaluationProvider!.Value.ToString(), ", ", requirement.RequiredPropertyMessageProviderNames.RequiredPropertyNotPresent, ", ", requirement.RequiredSchemaEvaluationPathName!, ");")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendLineIndent("else")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("context.EvaluatedKeywordPath(true, ", requirement.IndexForEvaluationProvider!.Value.ToString(), ", ", requirement.RequiredPropertyMessageProviderNames.RequiredPropertyPresent, ", ", requirement.RequiredSchemaEvaluationPathName!, ");")
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            generator
                .PopIndent()
                .AppendLineIndent("}");
        }

        if (propertyDependencies.PropertyName is not null)
        {
            generator
                .PopIndent()
                .AppendLineIndent("}");
        }


    }

    /// <inheritdoc/>
    public void AppendValidatorArguments(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(RequirementsAndDependenciesKey, out RequirementsAndDependencies? requirementsAndDependencies) ||
            requirementsAndDependencies is null ||
            requirementsAndDependencies.RequirementsByRequiredPropertyName.Count == 0)
        {
            return;
        }

        generator
            .Append(", requiredPropertyChildHandler_seenItems");
    }

    /// <inheritdoc/>
    public void BeginJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        RequirementsAndDependencies requirementsAndDependencies = GatherRequirements(generator, typeDeclaration.DependentRequired(), GetRequiredProperties(typeDeclaration).ToList());
        typeDeclaration.SetMetadata(RequirementsAndDependenciesKey, requirementsAndDependencies);
    }

    /// <inheritdoc/>
    public void EndJsonSchemaClassSetup(CodeGenerator generator, TypeDeclaration typeDeclaration) { }

    /// <inheritdoc/>
    public IEnumerable<ObjectPropertyValidatorParameter> GetNamedPropertyValidatorParameters(TypeDeclaration typeDeclaration)
    {
        if (!typeDeclaration.TryGetMetadata(RequirementsAndDependenciesKey, out RequirementsAndDependencies? requirementsAndDependencies) ||
            requirementsAndDependencies is null ||
            requirementsAndDependencies.RequirementsByRequiredPropertyName.Count == 0)
        {
            return [];
        }

        return [
            new ObjectPropertyValidatorParameter("Span<int>", "requiredBitBuffer")
        ];
    }

    /// <inheritdoc/>
    public bool WillEmitCodeFor(TypeDeclaration typeDeclaration) => (typeDeclaration.DependentRequired()?.Any() ?? false) || GetRequiredProperties(typeDeclaration).Any();

    private static IEnumerable<PropertyDeclaration> GetRequiredProperties(TypeDeclaration typeDeclaration)
    {
        return typeDeclaration.PropertyDeclarations.Where(p => p.RequiredOrOptional == RequiredOrOptional.Required && p.LocalOrComposed == LocalOrComposed.Local);
    }

    private static RequirementsAndDependencies GatherRequirements(CodeGenerator generator, IReadOnlyDictionary<IObjectDependentRequiredValidationKeyword, IReadOnlyCollection<DependentRequiredDeclaration>>? requiredByKeyword, List<PropertyDeclaration> requiredPropertyDeclarations)
    {
        Dictionary<string, Requirement> requirementsByRequirementPropertyName = [];
        List<PropertyDependencies> dependenciesForProperties = [];
        Dictionary<(IKeyword, string?), string> keywordsToSchemaEvaluationPath = [];

        int currentOffset = 0;
        int currentBitLeftShift = 0;

        AddForDependentRequired(
            generator,
            requiredByKeyword,
            requirementsByRequirementPropertyName,
            dependenciesForProperties,
            keywordsToSchemaEvaluationPath,
            ref currentOffset,
            ref currentBitLeftShift);

        AddForRequired(
            generator,
            requiredPropertyDeclarations,
            requirementsByRequirementPropertyName,
            dependenciesForProperties,
            keywordsToSchemaEvaluationPath,
            ref currentOffset,
            ref currentBitLeftShift);


        // Add the additional requirements for the property dependencies themselves
        foreach (PropertyDependencies propertyDependencies in dependenciesForProperties)
        {
            propertyDependencies.AddRequirement(generator, requirementsByRequirementPropertyName, ref currentOffset, ref currentBitLeftShift);
        }

        return new RequirementsAndDependencies(requirementsByRequirementPropertyName, dependenciesForProperties);
    }

    private static void AddForRequired(
        CodeGenerator generator,
        List<PropertyDeclaration> requiredPropertyDeclarations,
        Dictionary<string, Requirement> requirementsByRequirementPropertyName,
        List<PropertyDependencies> dependenciesForProperties,
        Dictionary<(IKeyword, string?), string> keywordsToSchemaEvaluationPath,
        ref int currentOffset,
        ref int currentBitLeftShift)
    {
        foreach (IGrouping<IObjectRequiredPropertyValidationKeyword?, PropertyDeclaration> propertiesByKeyword in requiredPropertyDeclarations.GroupBy(k => k.RequiredKeyword))
        {
            IKeyword keyword = propertiesByKeyword.Key ?? throw new InvalidOperationException("The required keyword must not be null on a required propertiesByKeyword.");

            PropertyDependencies propertyDependencies = new(null, keyword);

            Dependency currentDependency = propertyDependencies.AddDependency(generator, currentOffset);

            int index = 0;
            foreach (string requirementName in propertiesByKeyword.Select(p => p.JsonPropertyName))
            {
                if (!requirementsByRequirementPropertyName.TryGetValue(requirementName, out Requirement? requirement))
                {
                    if (!keywordsToSchemaEvaluationPath.TryGetValue((keyword, null), out string? requiredSchemaEvaluationPathName))
                    {
                        requiredSchemaEvaluationPathName = AppendSchemaEvaluationPathForKeyword(generator, keyword, null);

                        keywordsToSchemaEvaluationPath.Add((keyword, null), requiredSchemaEvaluationPathName);
                    }

                    string requiredPropertyPresent = generator.GetStaticReadOnlyFieldNameInScope(requirementName, prefix: "RequiredProperty", suffix: "Present");
                    string requiredPropertyNotPresent = generator.GetStaticReadOnlyFieldNameInScope(requirementName, prefix: "RequiredProperty", suffix: "NotPresent");

                    requirement = CreateRequirement(generator, requirementsByRequirementPropertyName, currentOffset, currentBitLeftShift, requirementName, requiredSchemaEvaluationPathName, index, new(requiredPropertyPresent, requiredPropertyNotPresent));

                    currentBitLeftShift++;
                    if (currentBitLeftShift == 32)
                    {
                        currentBitLeftShift = 0;
                        currentOffset++;
                        currentDependency = propertyDependencies.AddDependency(generator, currentOffset);
                    }

                    index++;
                }

                currentDependency.Requirements.Add(requirement);
            }

            currentDependency.AppendSchemaContent(generator);

            dependenciesForProperties.Add(propertyDependencies);
        }
    }

    private static void AddForDependentRequired(
        CodeGenerator generator,
        IReadOnlyDictionary<IObjectDependentRequiredValidationKeyword, IReadOnlyCollection<DependentRequiredDeclaration>>? requiredByKeyword,
        Dictionary<string, Requirement> requirementsByRequirementPropertyName,
        List<PropertyDependencies> dependenciesForProperties,
        Dictionary<(IKeyword, string?), string> keywordsToSchemaEvaluationPath,
        ref int currentOffset,
        ref int currentBitLeftShift)
    {
        if (requiredByKeyword is IReadOnlyDictionary<IObjectDependentRequiredValidationKeyword, IReadOnlyCollection<DependentRequiredDeclaration>> drbk)
        {
            foreach (KeyValuePair<IObjectDependentRequiredValidationKeyword, IReadOnlyCollection<DependentRequiredDeclaration>> declarationsByKeyword in drbk)
            {
                IObjectDependentRequiredValidationKeyword keyword = declarationsByKeyword.Key;

                foreach (DependentRequiredDeclaration declaration in declarationsByKeyword.Value)
                {
                    PropertyDependencies propertyDependencies = new(declaration.JsonPropertyName, keyword);

                    Dependency currentDependency = propertyDependencies.AddDependency(generator, currentOffset);

                    int index = 0;
                    foreach (string requirementName in declaration.Dependencies)
                    {
                        if (!requirementsByRequirementPropertyName.TryGetValue(requirementName, out Requirement? requirement))
                        {
                            if (!keywordsToSchemaEvaluationPath.TryGetValue((keyword, declaration.JsonPropertyName), out string? requiredSchemaEvaluationPathName))
                            {
                                requiredSchemaEvaluationPathName = AppendSchemaEvaluationPathForKeyword(generator, keyword, declaration.JsonPropertyName);

                                keywordsToSchemaEvaluationPath.Add((keyword, declaration.JsonPropertyName), requiredSchemaEvaluationPathName);
                            }

                            string requiredPropertyPresent = generator.GetStaticReadOnlyFieldNameInScope(requirementName, prefix: "RequiredProperty", suffix: "Present");
                            string requiredPropertyNotPresent = generator.GetStaticReadOnlyFieldNameInScope(requirementName, prefix: "RequiredProperty", suffix: "NotPresent");

                            requirement = CreateRequirement(generator, requirementsByRequirementPropertyName, currentOffset, currentBitLeftShift, requirementName, requiredSchemaEvaluationPathName, index, new(requiredPropertyPresent, requiredPropertyNotPresent));

                            currentBitLeftShift++;
                            if (currentBitLeftShift == 32)
                            {
                                currentBitLeftShift = 0;
                                currentOffset++;
                                currentDependency = propertyDependencies.AddDependency(generator, currentOffset);
                            }
                            index++;
                        }

                        currentDependency.Requirements.Add(requirement);
                    }

                    currentDependency.AppendSchemaContent(generator);

                    dependenciesForProperties.Add(propertyDependencies);
                }
            }
        }
    }

    private static string AppendSchemaEvaluationPathForKeyword(CodeGenerator generator, IKeyword keyword, string? propertyName)
    {
        string requiredSchemaEvaluationPathName;
        if (propertyName is string pn)
        {
            requiredSchemaEvaluationPathName = generator.GetStaticReadOnlyFieldNameInScope("SchemaEvaluationPathFor", prefix: keyword.Keyword, suffix: propertyName);
            generator
                .AppendSeparatorLine()
                .AppendLineIndent(
                    "private static readonly JsonSchemaPathProvider<int> ",
                    requiredSchemaEvaluationPathName,
                    " = static (evaluationPathIndex, buffer, out written) => JsonSchemaEvaluation.SchemaLocationForIndexedKeywordWithDependency(", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, ", SymbolDisplay.FormatLiteral(pn, true), "u8, evaluationPathIndex, buffer, out written);");
       }
        else
        {
            requiredSchemaEvaluationPathName = generator.GetStaticReadOnlyFieldNameInScope("SchemaEvaluationPath", prefix: keyword.Keyword);
            generator
                .AppendSeparatorLine()
                .AppendLineIndent(
                    "private static readonly JsonSchemaPathProvider<int> ",
                    requiredSchemaEvaluationPathName,
                    " = static (evaluationPathIndex, buffer, out written) => JsonSchemaEvaluation.SchemaLocationForIndexedKeyword(", SymbolDisplay.FormatLiteral(keyword.Keyword, true), "u8, evaluationPathIndex, buffer, out written);");
        }

        return requiredSchemaEvaluationPathName;
    }

    private static Requirement CreateRequirement(CodeGenerator generator, Dictionary<string, Requirement> requirementsByRequirementPropertyName, int currentOffset, int currentBitLeftShift, string propertyName, string? requiredSchemaEvaluationPathName = null, int? evaluationPathIndex = null, RequiredPropertyMessageProviderNames? requiredPropertyMessageProviderNames = null)
    {
        Requirement requirement;
        string offsetForPropertyName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("RequiredOffsetFor", suffix: propertyName, rootScope: generator.JsonSchemaClassScope());
        string bitForPropertyName = generator.GetUniqueStaticReadOnlyPropertyNameInScope("RequiredBitFor", suffix: propertyName, rootScope: generator.JsonSchemaClassScope());

        requirement = new Requirement(
            propertyName,
            currentOffset,
            1 << currentBitLeftShift,
            offsetForPropertyName,
            bitForPropertyName,
            requiredSchemaEvaluationPathName,
            evaluationPathIndex,
            requiredPropertyMessageProviderNames);

        requirement.AppendSchemaContent(generator);
        requirementsByRequirementPropertyName.Add(propertyName, requirement);

        return requirement;
    }

    /// <summary>
    /// The dependencies for a particular property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Any property which appears in the required list for a dependent
    /// property sets a bit in our "required" memory when it is seen.
    /// </para>
    /// <para>
    /// For each property with dependencies, we then apply a bitmask to the "required"
    /// memory to determine whether all of the properties have been seen.
    /// </para>
    /// <para>
    /// We choose to do this in blocks of int32, so that we can use bitwise operations
    /// to determine whether all dependencies have been met.
    /// </para>
    /// <para>
    /// This means that we also require an offset into the memory for each bit/bitmask,
    /// so that we can apply the bitmask to the correct part of the memory.
    /// </para>
    /// <para>
    /// This information is stored in the <see cref="Dependency"/> and its list of
    /// <see cref="Requirement"/>s.
    /// </para>
    /// <para>
    /// To test that all the bits set in A correspond to the bits set
    /// in the mask M:
    /// <code>
    /// [<![CDATA[
    /// (¬A ^ M) == 0 => all bits set
    ///          != 0 => not al bits set
    ///
    /// M      =    1010
    /// Example 1
    /// A      =    1101
    /// ¬A     =    0010
    /// ¬A ^ M =    0010 != 0 [fail]
    /// 
    /// Example 2
    /// A      =    1110
    /// ¬A     =    0001
    /// ¬A ^ M =    0000 == 0 [pass]
    /// ]]>
    /// </code>
    /// </para>
    /// </remarks>
    private class PropertyDependencies
    {
        private Requirement? _requirement;

        public PropertyDependencies(string? propertyName, IKeyword keyword)
        {
            PropertyName = propertyName;
            Keyword = keyword;
            _requirement = null;
        }

        /// <summary>
        /// Gets the property name for which we are tracking dependencies.
        /// </summary>
        /// <remarks>
        /// If this is null, it implies that we are tracking the required properties for the entire object, rather than for a specific property.
        /// </remarks>
        public string? PropertyName { get; }        

        public IKeyword Keyword { get; }

        public int OffsetForProperty => _requirement?.OffsetForProperty ?? -1;
        public int BitForProperty => _requirement?.BitForProperty ?? -1;
        public string? BitForPropertyName => _requirement?.BitForPropertyName;
        public string? OffsetForPropertyName => _requirement?.OffsetForPropertyName;

        /// <summary>
        /// Gets the list of dependencies for this property.
        /// </summary>
        public List<Dependency> Dependencies { get; } = [];

        public Dependency AddDependency(CodeGenerator generator, int currentOffset)
        {
            
            string currentBitmaskName =
                PropertyName is string p
                    ? generator.GetUniqueStaticReadOnlyPropertyNameInScope($"RequiredBitMask{currentOffset}For", suffix: p, rootScope: generator.JsonSchemaClassScope())
                    : generator.GetUniqueStaticReadOnlyPropertyNameInScope($"RequiredBitMask{currentOffset}", rootScope: generator.JsonSchemaClassScope());
            Dependency currentDependency = new(currentOffset, currentBitmaskName);
            Dependencies.Add(currentDependency);
            return currentDependency;
        }

        public void AddRequirement(CodeGenerator generator, Dictionary<string, Requirement> requirementsByRequirementPropertyName, ref int currentOffset, ref int currentBitLeftShift)
        {
            if (Dependencies.Count == 0)
            {
                return;
            }

            if (PropertyName is string propertyName)
            {
                if (!requirementsByRequirementPropertyName.TryGetValue(propertyName, out Requirement? requirement))
                {
                    requirement = CreateRequirement(generator, requirementsByRequirementPropertyName, currentOffset, currentBitLeftShift, propertyName);

                    currentBitLeftShift++;
                    if (currentBitLeftShift == 32)
                    {
                        currentBitLeftShift = 0;
                        currentOffset++;
                    }
                }

                _requirement = requirement;
            }
        }
    }

    /// <summary>
    /// The requirements for a given property, at a specific offset in the bitmask.
    /// </summary>
    private class Dependency
    {
        public Dependency(int offsetForBitMask, string bitmaskMaskName)
        {
            OffsetForBitMask = offsetForBitMask;
            BitmaskMaskName = bitmaskMaskName;
        }

        public int OffsetForBitMask { get; }
        public string BitmaskMaskName { get; }
        public List<Requirement> Requirements { get; } = [];

        public void AppendSchemaContent(CodeGenerator generator)
        {
            if (Requirements.Count == 0)
            {
                return;
            }

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private const int ", BitmaskMaskName, " =")
                .PushIndent();

            int count = 0;

            bool needsAppendLine = false;
            foreach (Requirement item in Requirements)
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
                           .AppendIndent(item.BitForPropertyName);
                        break;
                    case 3:
                        generator
                           .Append(" | ")
                           .Append(item.BitForPropertyName);
                        needsAppendLine = true;
                        break;
                    default:
                        generator
                           .Append(" | ")
                           .Append(item.BitForPropertyName);
                        break;
                }

                count++;
            }

            generator
                .AppendLine(";")
                .PopIndent();
        }
    }

    private class RequiredPropertyMessageProviderNames
    {
        public RequiredPropertyMessageProviderNames(string requiredPropertyPresent, string requiredPropertyNotPresent)
        {
            RequiredPropertyPresent = requiredPropertyPresent;
            RequiredPropertyNotPresent = requiredPropertyNotPresent;
        }

        public string RequiredPropertyPresent { get; }
        public string RequiredPropertyNotPresent { get; }
    }

    private class Requirement
    {
        public string PropertyName { get; }
        public int OffsetForProperty { get; }
        public int BitForProperty { get; }
        public string BitForPropertyName { get; }
        public string OffsetForPropertyName { get; }

        public int? IndexForEvaluationProvider { get; }

        public RequiredPropertyMessageProviderNames? RequiredPropertyMessageProviderNames { get; }

        public string? RequiredSchemaEvaluationPathName { get; }


        public Requirement(string propertyName, int offsetForProperty, int bitForProperty, string offsetForPropertyName, string bitForPropertyName, string? requiredSchemaEvaluationPathName, int? indexForEvaluationProvider, RequiredPropertyMessageProviderNames? requiredPropertyMessageProviderNames)
        {
            PropertyName = propertyName;
            OffsetForProperty = offsetForProperty;
            BitForProperty = bitForProperty;
            OffsetForPropertyName = offsetForPropertyName;
            BitForPropertyName = bitForPropertyName;
            IndexForEvaluationProvider = indexForEvaluationProvider;
            RequiredSchemaEvaluationPathName = requiredSchemaEvaluationPathName;
            RequiredPropertyMessageProviderNames = requiredPropertyMessageProviderNames;
        }

        public void AppendSchemaContent(CodeGenerator generator) =>
            generator
                .AppendSeparatorLine()
                .ConditionallyAppend(RequiredPropertyMessageProviderNames is not null, g=> g.AppendLineIndent(
                    "private static readonly JsonSchemaMessageProvider<int> ",
                    RequiredPropertyMessageProviderNames.RequiredPropertyPresent,
                    " = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyPresent(",
                    SymbolDisplay.FormatLiteral(PropertyName, true),
                    "u8, buffer, out written);"))
                .ConditionallyAppend(RequiredPropertyMessageProviderNames is not null, g => g.AppendLineIndent(
                    "private static readonly JsonSchemaMessageProvider<int> ",
                    RequiredPropertyMessageProviderNames.RequiredPropertyNotPresent,
                    " = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyNotPresent(",
                    SymbolDisplay.FormatLiteral(PropertyName, true),
                    "u8, buffer, out written);"))
                .AppendSeparatorLine()
                .AppendLineIndent("private const int ", OffsetForPropertyName, " = ", OffsetForProperty.ToString(), ";")
                .AppendLineIndent("private const int ", BitForPropertyName, " = 0b", BitForProperty.ToString("b32"), ";");
    }

    private class RequirementsAndDependencies
    {
        public RequirementsAndDependencies(IReadOnlyDictionary<string, Requirement> requirementsByRequiredPropertyName, IReadOnlyList<PropertyDependencies> dependencies)
        {
            RequirementsByRequiredPropertyName = requirementsByRequiredPropertyName;
            Dependencies = dependencies;
        }

        public IReadOnlyDictionary<string, Requirement> RequirementsByRequiredPropertyName { get; }
        public IReadOnlyList<PropertyDependencies> Dependencies { get; }
    }
}
