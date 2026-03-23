// <copyright file="StandaloneEvaluatorGenerator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.Keywords;
using Corvus.Text.Json.CodeGeneration.Internal;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Generates a standalone static evaluator class that performs full JSON Schema
/// validation and annotation collection, independent of generated types.
/// This partial class handles the structural aspects: file header, class declaration,
/// entry points, and schema tree walking. Keyword-specific emission is handled
/// by other partial class files.
/// </summary>
internal static partial class StandaloneEvaluatorGenerator
{
    /// <summary>
    /// Generates a standalone evaluator for the given root type declaration.
    /// </summary>
    /// <param name="rootType">The root type declaration (before reduction).</param>
    /// <param name="options">The code generation options.</param>
    /// <param name="lineEnd">The line ending sequence.</param>
    /// <returns>A generated code file containing the evaluator, or <see langword="null"/> if generation is not applicable.</returns>
    public static GeneratedCodeFile? Generate(
        TypeDeclaration rootType,
        CSharpLanguageProvider.Options options,
        string lineEnd = "\r\n")
    {
        string evaluatorClassName = GetEvaluatorClassName(rootType);
        string ns = options.GetNamespace(rootType);
        string schemaLocation = rootType.LocatedSchema.Location.ToString();

        var ctx = new GenerationContext(lineEnd);

        // Pass 1: collect all subschema info (method names, paths, type declarations).
        var subschemas = new Dictionary<string, SubschemaInfo>();
        CollectSubschemas(rootType, subschemas, "#", "EvaluateRoot");

        EmitFileHeader(ctx, options);
        EmitNamespaceOpen(ctx, ns);
        EmitClassOpen(ctx, evaluatorClassName);

        // Emit static fields (path providers for root and all subschemas).
        EmitSchemaLocationField(ctx, schemaLocation);
        EmitPathProviderFields(ctx, subschemas);

        // Emit public Evaluate<TElement> entry point.
        EmitPublicEvaluateMethod(ctx, rootType);

        // Pass 2: emit evaluation methods for root and all subschemas.
        foreach (KeyValuePair<string, SubschemaInfo> kvp in subschemas)
        {
            ctx.AppendLine();
            EmitSchemaEvaluationMethod(ctx, kvp.Value.TypeDeclaration, kvp.Value.MethodName, subschemas);
        }

        EmitClassClose(ctx);

        string content = ctx.ToString();
        string fileName = evaluatorClassName + ".Evaluator";

        return new GeneratedCodeFile(fileName + options.FileExtension, content);
    }

    private static void CollectSubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath,
        string methodName)
    {
        string location = typeDeclaration.LocatedSchema.Location.ToString();

        if (subschemas.ContainsKey(location))
        {
            return;
        }

        subschemas[location] = new SubschemaInfo(
            methodName,
            schemaPath,
            typeDeclaration,
            typeDeclaration.RequiresItemsEvaluationTracking(),
            typeDeclaration.RequiresPropertyEvaluationTracking());

        if (typeDeclaration.LocatedSchema.IsBooleanSchema)
        {
            return;
        }

        // IHidesSiblingsKeyword check: if $ref hides siblings (draft4-7), only collect the $ref target.
        if (typeDeclaration.HasSiblingHidingKeyword())
        {
            CollectCompositionSubschemas(typeDeclaration, subschemas, schemaPath);
            return;
        }

        CollectCompositionSubschemas(typeDeclaration, subschemas, schemaPath);
        CollectConditionalSubschemas(typeDeclaration, subschemas, schemaPath);
        CollectNotSubschema(typeDeclaration, subschemas, schemaPath);
        CollectPropertySubschemas(typeDeclaration, subschemas, schemaPath);
        CollectArraySubschemas(typeDeclaration, subschemas, schemaPath);
        CollectFallbackSubschemas(typeDeclaration, subschemas, schemaPath);
    }

    private static void CollectCompositionSubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        if (typeDeclaration.AllOfCompositionTypes() is { } allOf)
        {
            foreach (var kvp in allOf)
            {
                int index = 0;
                foreach (TypeDeclaration subschemaType in kvp.Value)
                {
                    string path = $"{schemaPath}/{kvp.Key.Keyword}/{index}";
                    string method = MakeMethodName($"AllOf{index}", schemaPath);
                    CollectSubschemas(subschemaType, subschemas, path, method);
                    index++;
                }
            }
        }

        if (typeDeclaration.AnyOfCompositionTypes() is { } anyOf)
        {
            foreach (var kvp in anyOf)
            {
                int index = 0;
                foreach (TypeDeclaration subschemaType in kvp.Value)
                {
                    string path = $"{schemaPath}/{kvp.Key.Keyword}/{index}";
                    string method = MakeMethodName($"AnyOf{index}", schemaPath);
                    CollectSubschemas(subschemaType, subschemas, path, method);
                    index++;
                }
            }
        }

        if (typeDeclaration.OneOfCompositionTypes() is { } oneOf)
        {
            foreach (var kvp in oneOf)
            {
                int index = 0;
                foreach (TypeDeclaration subschemaType in kvp.Value)
                {
                    string path = $"{schemaPath}/{kvp.Key.Keyword}/{index}";
                    string method = MakeMethodName($"OneOf{index}", schemaPath);
                    CollectSubschemas(subschemaType, subschemas, path, method);
                    index++;
                }
            }
        }
    }

    private static void CollectConditionalSubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        if (typeDeclaration.IfSubschemaType() is SingleSubschemaKeywordTypeDeclaration ifType)
        {
            string path = $"{schemaPath}/{ifType.Keyword.Keyword}";
            CollectSubschemas(ifType.UnreducedType, subschemas, path, MakeMethodName("If", schemaPath));
        }

        if (typeDeclaration.ThenSubschemaType() is SingleSubschemaKeywordTypeDeclaration thenType)
        {
            string path = $"{schemaPath}/{thenType.Keyword.Keyword}";
            CollectSubschemas(thenType.UnreducedType, subschemas, path, MakeMethodName("Then", schemaPath));
        }

        if (typeDeclaration.ElseSubschemaType() is SingleSubschemaKeywordTypeDeclaration elseType)
        {
            string path = $"{schemaPath}/{elseType.Keyword.Keyword}";
            CollectSubschemas(elseType.UnreducedType, subschemas, path, MakeMethodName("Else", schemaPath));
        }
    }

    private static void CollectNotSubschema(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        foreach (INotValidationKeyword keyword in typeDeclaration.Keywords().OfType<INotValidationKeyword>())
        {
            if (keyword.TryGetNotType(typeDeclaration, out ReducedTypeDeclaration? notType) &&
                notType is ReducedTypeDeclaration notDecl)
            {
                string path = $"{schemaPath}/{keyword.Keyword}";
                CollectSubschemas(notDecl.ReducedType, subschemas, path, MakeMethodName("Not", schemaPath));
            }
        }
    }

    private static void CollectPropertySubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        foreach (PropertyDeclaration prop in typeDeclaration.PropertyDeclarations)
        {
            if (prop.LocalOrComposed == LocalOrComposed.Local && prop.Keyword is IObjectPropertyValidationKeyword propKw)
            {
                string pathMod = propKw.GetPathModifier(prop);
                string path = $"{schemaPath}/{pathMod}";
                string safeName = MakeSafeIdentifier(prop.JsonPropertyName);
                CollectSubschemas(prop.ReducedPropertyType, subschemas, path, MakeMethodName($"Prop{safeName}", schemaPath));
            }
        }

        // propertyNames subschema
        foreach (IObjectPropertyNameSubschemaValidationKeyword keyword in typeDeclaration.Keywords().OfType<IObjectPropertyNameSubschemaValidationKeyword>())
        {
            if (keyword.TryGetPropertyNameDeclaration(typeDeclaration, out TypeDeclaration? propertyNamesType) &&
                propertyNamesType is not null)
            {
                string path = $"{schemaPath}/{keyword.Keyword}";
                CollectSubschemas(propertyNamesType, subschemas, path, MakeMethodName("PropertyNames", schemaPath));
            }
        }
    }

    private static void CollectArraySubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        // Non-tuple items
        foreach (IArrayItemsTypeProviderKeyword keyword in typeDeclaration.Keywords().OfType<IArrayItemsTypeProviderKeyword>())
        {
            if (keyword.TryGetArrayItemsType(typeDeclaration, out ArrayItemsTypeDeclaration? itemsType) &&
                itemsType is ArrayItemsTypeDeclaration items)
            {
                string path = $"{schemaPath}/{keyword.GetPathModifier(items)}";
                CollectSubschemas(items.ReducedType, subschemas, path, MakeMethodName("Items", schemaPath));
            }
        }

        // Tuple items (prefixItems)
        foreach (ITupleTypeProviderKeyword keyword in typeDeclaration.Keywords().OfType<ITupleTypeProviderKeyword>())
        {
            if (keyword.TryGetTupleType(typeDeclaration, out TupleTypeDeclaration? tupleType) &&
                tupleType is TupleTypeDeclaration tuple)
            {
                int index = 0;
                foreach (ReducedTypeDeclaration item in tuple.ItemsTypes)
                {
                    string path = $"{schemaPath}/{keyword.GetPathModifier(item, index)}";
                    CollectSubschemas(item.ReducedType, subschemas, path, MakeMethodName($"PrefixItems{index}", schemaPath));
                    index++;
                }
            }
        }

        // Contains
        foreach (IArrayContainsValidationKeyword keyword in typeDeclaration.Keywords().OfType<IArrayContainsValidationKeyword>())
        {
            if (keyword.TryGetContainsItemType(typeDeclaration, out ArrayItemsTypeDeclaration? containsType) &&
                containsType is ArrayItemsTypeDeclaration contains)
            {
                string path = $"{schemaPath}/{keyword.Keyword}";
                CollectSubschemas(contains.ReducedType, subschemas, path, MakeMethodName("Contains", schemaPath));
            }
        }
    }

    private static void CollectFallbackSubschemas(
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas,
        string schemaPath)
    {
        // additionalProperties
        foreach (IFallbackObjectPropertyTypeProviderKeyword keyword in typeDeclaration.Keywords().OfType<IFallbackObjectPropertyTypeProviderKeyword>())
        {
            if (keyword.TryGetFallbackObjectPropertyType(typeDeclaration, out FallbackObjectPropertyType? fallbackType) &&
                fallbackType is FallbackObjectPropertyType fallback)
            {
                string path = $"{schemaPath}/{keyword.GetPathModifier()}";
                CollectSubschemas(fallback.ReducedType, subschemas, path, MakeMethodName("AdditionalProperties", schemaPath));
            }
        }

        // unevaluatedProperties
        foreach (ILocalEvaluatedPropertyValidationKeyword keyword in typeDeclaration.Keywords().OfType<ILocalEvaluatedPropertyValidationKeyword>())
        {
            if (keyword.TryGetFallbackObjectPropertyType(typeDeclaration, out FallbackObjectPropertyType? fallbackType) &&
                fallbackType is FallbackObjectPropertyType fallback)
            {
                string path = $"{schemaPath}/{((IKeyword)keyword).Keyword}";
                CollectSubschemas(fallback.ReducedType, subschemas, path, MakeMethodName("UnevaluatedProperties", schemaPath));
            }
        }

        // unevaluatedItems
        foreach (IArrayItemsTypeProviderKeyword keyword in typeDeclaration.Keywords().OfType<IArrayItemsTypeProviderKeyword>())
        {
            // Only collect if it is specifically for unevaluated items.
            if (keyword is IKeyword kw && kw.Keyword == "unevaluatedItems" &&
                keyword.TryGetArrayItemsType(typeDeclaration, out ArrayItemsTypeDeclaration? unevalItems) &&
                unevalItems is ArrayItemsTypeDeclaration unevalItemsType)
            {
                string path = $"{schemaPath}/unevaluatedItems";
                CollectSubschemas(unevalItemsType.ReducedType, subschemas, path, MakeMethodName("UnevaluatedItems", schemaPath));
            }
        }
    }

    private static string MakeMethodName(string suffix, string basePath)
    {
        if (basePath == "#")
        {
            return $"Evaluate{suffix}";
        }

        return $"Evaluate{suffix}";
    }

    private static void EmitSchemaLocationField(GenerationContext ctx, string schemaLocation)
    {
        ctx.AppendLine($"private static readonly JsonSchemaPathProvider SchemaLocationProvider = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath({FormatUtf8Literal(schemaLocation)}, buffer, out written);");
        ctx.AppendLine();
    }

    private static void EmitPathProviderFields(GenerationContext ctx, Dictionary<string, SubschemaInfo> subschemas)
    {
        foreach (KeyValuePair<string, SubschemaInfo> kvp in subschemas)
        {
            if (kvp.Value.MethodName == "EvaluateRoot")
            {
                continue;
            }

            string fieldName = kvp.Value.MethodName.Replace("Evaluate", string.Empty) + "SchemaEvaluationPath";
            kvp.Value.PathFieldName = fieldName;
            ctx.AppendLine($"private static readonly JsonSchemaPathProvider {fieldName} = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath({FormatUtf8Literal(kvp.Value.SchemaPath)}, buffer, out written);");
        }

        ctx.AppendLine();
    }

    private static void EmitPublicEvaluateMethod(GenerationContext ctx, TypeDeclaration rootType)
    {
        bool useEvaluatedItems = rootType.RequiresItemsEvaluationTracking();
        bool useEvaluatedProperties = rootType.RequiresPropertyEvaluationTracking();

        ctx.AppendLine("/// <summary>");
        ctx.AppendLine("/// Evaluates the given JSON element against this schema.");
        ctx.AppendLine("/// </summary>");
        ctx.AppendLine("/// <typeparam name=\"TElement\">The type of JSON element.</typeparam>");
        ctx.AppendLine("/// <param name=\"instance\">The instance to evaluate.</param>");
        ctx.AppendLine("/// <param name=\"resultsCollector\">The optional results collector.</param>");
        ctx.AppendLine("/// <returns><see langword=\"true\"/> if the instance is valid against the schema.</returns>");
        ctx.AppendLine("public static bool Evaluate<TElement>(");
        ctx.PushIndent();
        ctx.AppendLine("in TElement instance,");
        ctx.AppendLine("IJsonSchemaResultsCollector? resultsCollector = null)");
        ctx.PopIndent();
        ctx.PushIndent();
        ctx.AppendLine("where TElement : struct, IJsonElement<TElement>");
        ctx.PopIndent();
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("JsonSchemaContext context = JsonSchemaContext.BeginContext(");
        ctx.PushIndent();
        ctx.AppendLine("instance.ParentDocument,");
        ctx.AppendLine("instance.ParentDocumentIndex,");
        ctx.AppendLine($"usingEvaluatedItems: {BoolLiteral(useEvaluatedItems)},");
        ctx.AppendLine($"usingEvaluatedProperties: {BoolLiteral(useEvaluatedProperties)},");
        ctx.AppendLine("resultsCollector: resultsCollector);");
        ctx.PopIndent();
        ctx.AppendLine();
        ctx.AppendLine("try");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("EvaluateRoot(instance.ParentDocument, instance.ParentDocumentIndex, ref context);");
        ctx.AppendLine("context.EndContext();");
        ctx.AppendLine("return context.IsMatch;");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("finally");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("context.Dispose();");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine();
    }

    private static void EmitSchemaEvaluationMethod(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        string methodName,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        if (typeDeclaration.LocatedSchema.IsBooleanSchema)
        {
            EmitBooleanSchemaMethod(ctx, typeDeclaration, methodName);
            return;
        }

        ctx.AppendLine($"private static void {methodName}(");
        ctx.PushIndent();
        ctx.AppendLine("IJsonDocument parentDocument,");
        ctx.AppendLine("int parentIndex,");
        ctx.AppendLine("ref JsonSchemaContext context)");
        ctx.PopIndent();
        ctx.AppendLine("{");
        ctx.PushIndent();

        bool needsTokenType = RequiresTokenType(typeDeclaration);
        if (needsTokenType)
        {
            ctx.AppendLine("JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);");
            ctx.AppendLine();
        }

        ctx.AppendLine("Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not");
        ctx.PushIndent();
        ctx.AppendLine("(JsonTokenType.None or");
        ctx.AppendLine("JsonTokenType.EndObject or");
        ctx.AppendLine("JsonTokenType.EndArray));");
        ctx.PopIndent();

        // Check for IHidesSiblingsKeyword ($ref in draft4-7 that hides all siblings).
        if (typeDeclaration.HasSiblingHidingKeyword())
        {
            EmitHidesSiblingsRef(ctx, typeDeclaration, subschemas);
            ctx.PopIndent();
            ctx.AppendLine("}");
            return;
        }

        // Emit keyword handlers in priority order.

        // Priority: CoreType (1000) — type validation
        EmitTypeValidation(ctx, typeDeclaration);
        EmitShortCircuit(ctx);

        // Priority: Default (~2^31) — const, enum, string, number, format
        EmitConstValidation(ctx, typeDeclaration);
        EmitEnumValidation(ctx, typeDeclaration);
        EmitStringValidation(ctx, typeDeclaration);
        EmitNumberValidation(ctx, typeDeclaration);
        EmitFormatValidation(ctx, typeDeclaration);
        EmitShortCircuit(ctx);

        // Priority: Composition (~2^31+1000) — allOf, anyOf, oneOf, not, if/then/else
        EmitCompositionValidation(ctx, typeDeclaration, subschemas);
        EmitIfThenElseValidation(ctx, typeDeclaration, subschemas);
        EmitShortCircuit(ctx);

        // Priority: AfterComposition (~2^31+2000) — object, array
        EmitObjectValidation(ctx, typeDeclaration, subschemas);
        EmitArrayValidation(ctx, typeDeclaration, subschemas);
        EmitShortCircuit(ctx);

        // Priority: Last — unevaluated
        EmitUnevaluatedValidation(ctx, typeDeclaration, subschemas);

        // After all validation — annotations
        EmitAnnotations(ctx, typeDeclaration);

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitBooleanSchemaMethod(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        string methodName)
    {
        bool isTrue = typeDeclaration.LocatedSchema.Schema.ValueKind == JsonValueKind.True;

        ctx.AppendLine($"private static void {methodName}(");
        ctx.PushIndent();
        ctx.AppendLine("IJsonDocument parentDocument,");
        ctx.AppendLine("int parentIndex,");
        ctx.AppendLine("ref JsonSchemaContext context)");
        ctx.PopIndent();
        ctx.AppendLine("{");
        ctx.PushIndent();

        if (!isTrue)
        {
            ctx.AppendLine("context.EvaluatedBooleanSchema(false);");
        }

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitHidesSiblingsRef(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        // Find the $ref target via allOf composition (IReferenceKeyword implements IAllOfSubschemaValidationKeyword).
        if (typeDeclaration.AllOfCompositionTypes() is { } allOf)
        {
            foreach (var kvp in allOf)
            {
                foreach (TypeDeclaration subschemaType in kvp.Value)
                {
                    string subLoc = subschemaType.LocatedSchema.Location.ToString();
                    if (subschemas.TryGetValue(subLoc, out SubschemaInfo? info))
                    {
                        ctx.AppendLine();
                        ctx.AppendLine($"{info.MethodName}(parentDocument, parentIndex, ref context);");
                    }
                }
            }
        }
    }

    private static void EmitShortCircuit(GenerationContext ctx)
    {
        ctx.AppendLine();
        ctx.AppendLine("if (!context.HasCollector && !context.IsMatch)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("return;");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static bool RequiresTokenType(TypeDeclaration typeDeclaration)
    {
        return typeDeclaration.Keywords().Any(k =>
            k is ICoreTypeValidationKeyword or
                 IObjectValidationKeyword or
                 IArrayValidationKeyword or
                 IStringValidationKeyword or
                 INumberValidationKeyword or
                 IFormatProviderKeyword);
    }

    private static void EmitTypeValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        CoreTypes allowedTypes = typeDeclaration.AllowedCoreTypes();
        if (allowedTypes == CoreTypes.None || allowedTypes == CoreTypes.Any)
        {
            return;
        }

        if (!TryGetSingleCoreType(allowedTypes, out CoreTypes singleType))
        {
            // Multiple types: individual keyword handlers have their own type guards.
            return;
        }

        string matchMethod = GetMatchMethodName(singleType);
        string ignoredField = GetIgnoredNotTypeName(singleType);
        string typeKeywordLiteral = GetTypeKeywordLiteral(typeDeclaration);

        ctx.AppendLine();

        if (singleType == CoreTypes.Integer)
        {
            ctx.AppendLine("int integerTypeExponent = 0;");
            ctx.AppendLine("if (tokenType == JsonTokenType.Number)");
            ctx.AppendLine("{");
            ctx.PushIndent();
            ctx.AppendLine("ReadOnlyMemory<byte> typeCheckRawValue = parentDocument.GetRawSimpleValue(parentIndex);");
            ctx.AppendLine("JsonElementHelpers.TryParseNumber(typeCheckRawValue.Span, out _, out _, out _, out integerTypeExponent);");
            ctx.PopIndent();
            ctx.AppendLine("}");
            ctx.AppendLine();
            ctx.AppendLine($"if (!JsonSchemaEvaluation.{matchMethod}(tokenType, {typeKeywordLiteral}, integerTypeExponent, ref context))");
        }
        else
        {
            ctx.AppendLine($"if (!JsonSchemaEvaluation.{matchMethod}(tokenType, {typeKeywordLiteral}, ref context))");
        }

        ctx.AppendLine("{");
        ctx.PushIndent();

        ctx.AppendLine("if (!context.HasCollector)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("return;");
        ctx.PopIndent();
        ctx.AppendLine("}");

        List<string> sensitiveKeywords = GetTypeSensitiveKeywordNames(typeDeclaration, singleType);
        foreach (string kw in sensitiveKeywords)
        {
            ctx.AppendLine();
            ctx.AppendLine($"context.IgnoredKeyword(JsonSchemaEvaluation.{ignoredField}, {FormatUtf8Literal(kw)});");
        }

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitConstValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        ISingleConstantValidationKeyword? constKw = typeDeclaration.Keywords().OfType<ISingleConstantValidationKeyword>().FirstOrDefault();
        if (constKw is null || !constKw.TryGetConstantValue(typeDeclaration, out JsonElement constantValue))
        {
            return;
        }

        string formattedKeyword = FormatUtf8Literal(constKw.Keyword);

        ctx.AppendLine();

        switch (constantValue.ValueKind)
        {
            case JsonValueKind.String:
                EmitStringConstValidation(ctx, constKw, constantValue, formattedKeyword);
                break;
            case JsonValueKind.Number:
                EmitNumberConstValidation(ctx, constantValue, formattedKeyword);
                break;
            case JsonValueKind.True:
                EmitBooleanConstValidation(ctx, true, formattedKeyword);
                break;
            case JsonValueKind.False:
                EmitBooleanConstValidation(ctx, false, formattedKeyword);
                break;
            case JsonValueKind.Null:
                EmitNullConstValidation(ctx, formattedKeyword);
                break;
            case JsonValueKind.Object:
            case JsonValueKind.Array:
                EmitComplexConstValidation(ctx, constantValue, formattedKeyword);
                break;
        }
    }

    private static void EmitStringConstValidation(GenerationContext ctx, ISingleConstantValidationKeyword constKw, JsonElement constantValue, string formattedKeyword)
    {
        string quotedValue = SymbolDisplay.FormatLiteral(constantValue.GetString()!, true);

        ctx.AppendLine("if (tokenType == JsonTokenType.String)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("using UnescapedUtf8JsonString constUnescaped = parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String);");
        ctx.AppendLine($"JsonSchemaEvaluation.MatchStringConstantValue(constUnescaped.Span, {quotedValue}u8, {quotedValue}, {formattedKeyword}, ref context);");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("else");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(false, {quotedValue}, messageProvider: JsonSchemaEvaluation.ExpectedStringEquals, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitNumberConstValidation(GenerationContext ctx, JsonElement constantValue, string formattedKeyword)
    {
        string rawText = constantValue.GetRawText();
        JsonElementHelpers.ParseNumber(System.Text.Encoding.UTF8.GetBytes(rawText), out bool isNeg, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exp);

        string isNegStr = BoolLiteral(isNeg);
        string integralStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(integral.ToArray()), true);
        string fractionalStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(fractional.ToArray()), true);
        string expStr = exp.ToString();
        string rawValueStr = SymbolDisplay.FormatLiteral(rawText, true);

        ctx.AppendLine("if (tokenType == JsonTokenType.Number)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("ReadOnlyMemory<byte> constRawValue = parentDocument.GetRawSimpleValue(parentIndex);");
        ctx.AppendLine("JsonElementHelpers.TryParseNumber(constRawValue.Span, out bool constIsNeg, out ReadOnlySpan<byte> constIntegral, out ReadOnlySpan<byte> constFractional, out int constExponent);");
        ctx.AppendLine($"JsonSchemaEvaluation.MatchEquals(constIsNeg, constIntegral, constFractional, constExponent, {isNegStr}, {integralStr}u8, {fractionalStr}u8, {expStr}, {rawValueStr}, {formattedKeyword}, ref context);");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("else");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(false, {rawValueStr}, messageProvider: JsonSchemaEvaluation.ExpectedEquals, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitBooleanConstValidation(GenerationContext ctx, bool expectation, string formattedKeyword)
    {
        string tokenName = expectation ? "True" : "False";
        ctx.AppendLine($"if (tokenType == JsonTokenType.{tokenName})");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(true, messageProvider: JsonSchemaEvaluation.ExpectedBoolean{tokenName}, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("else");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(false, messageProvider: JsonSchemaEvaluation.ExpectedBoolean{tokenName}, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitNullConstValidation(GenerationContext ctx, string formattedKeyword)
    {
        ctx.AppendLine("if (tokenType == JsonTokenType.Null)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(true, messageProvider: JsonSchemaEvaluation.ExpectedNull, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("else");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(false, messageProvider: JsonSchemaEvaluation.ExpectedNull, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitComplexConstValidation(GenerationContext ctx, JsonElement constantValue, string formattedKeyword)
    {
        string quotedRawText = SymbolDisplay.FormatLiteral(constantValue.GetRawText(), true);

        ctx.AppendLine($"if (JsonElementHelpers.DeepEqualsNoParentDocumentCheck({quotedRawText}, tokenType, parentDocument, parentIndex))");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(true, {quotedRawText}, messageProvider: JsonSchemaEvaluation.ExpectedConstant, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine("else");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine($"context.EvaluatedKeyword(false, {quotedRawText}, messageProvider: JsonSchemaEvaluation.ExpectedConstant, {formattedKeyword});");
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitEnumValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        IAnyOfConstantValidationKeyword? enumKw = typeDeclaration.Keywords().OfType<IAnyOfConstantValidationKeyword>().FirstOrDefault();
        if (enumKw is null || !enumKw.TryGetValidationConstants(typeDeclaration, out JsonElement[]? constants))
        {
            return;
        }

        string formattedKeyword = FormatUtf8Literal(enumKw.Keyword);

        ctx.AppendLine();

        bool hasStringValues = constants.Any(c => c.ValueKind == JsonValueKind.String);
        bool hasNumberValues = constants.Any(c => c.ValueKind == JsonValueKind.Number);
        bool hasBoolValues = constants.Any(c => c.ValueKind is JsonValueKind.True or JsonValueKind.False);
        bool hasNullValues = constants.Any(c => c.ValueKind == JsonValueKind.Null);
        bool hasComplexValues = constants.Any(c => c.ValueKind is JsonValueKind.Object or JsonValueKind.Array);

        if (hasStringValues)
        {
            ctx.AppendLine("if (tokenType == JsonTokenType.String)");
            ctx.AppendLine("{");
            ctx.PushIndent();
            ctx.AppendLine("using UnescapedUtf8JsonString enumUnescaped = parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String);");
            ctx.AppendLine();
            foreach (JsonElement c in constants.Where(c => c.ValueKind == JsonValueKind.String))
            {
                string val = SymbolDisplay.FormatLiteral(c.GetString()!, true);
                ctx.AppendLine($"if (enumUnescaped.Span.SequenceEqual({val}u8))");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("goto enumShortCircuitSuccess;");
                ctx.PopIndent();
                ctx.AppendLine("}");
                ctx.AppendLine();
            }

            ctx.PopIndent();
            ctx.AppendLine("}");
        }

        if (hasNumberValues)
        {
            ctx.AppendLine();
            ctx.AppendLine("if (tokenType == JsonTokenType.Number)");
            ctx.AppendLine("{");
            ctx.PushIndent();
            ctx.AppendLine("ReadOnlyMemory<byte> enumRaw = parentDocument.GetRawSimpleValue(parentIndex);");
            ctx.AppendLine("JsonElementHelpers.TryParseNumber(enumRaw.Span, out bool enumIsNeg, out ReadOnlySpan<byte> enumIntegral, out ReadOnlySpan<byte> enumFractional, out int enumExponent);");
            ctx.AppendLine();
            foreach (JsonElement c in constants.Where(c => c.ValueKind == JsonValueKind.Number))
            {
                string rawText = c.GetRawText();
                byte[] rawBytes = System.Text.Encoding.UTF8.GetBytes(rawText);
                JsonElementHelpers.ParseNumber(rawBytes, out bool isNeg, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exp);
                string isNegStr = BoolLiteral(isNeg);
                string integralStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(integral.ToArray()), true);
                string fractionalStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(fractional.ToArray()), true);
                string expStr = exp.ToString();

                ctx.AppendLine($"if (JsonElementHelpers.CompareNormalizedJsonNumbers(enumIsNeg, enumIntegral, enumFractional, enumExponent, {isNegStr}, {integralStr}u8, {fractionalStr}u8, {expStr}) == 0)");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("goto enumShortCircuitSuccess;");
                ctx.PopIndent();
                ctx.AppendLine("}");
                ctx.AppendLine();
            }

            ctx.PopIndent();
            ctx.AppendLine("}");
        }

        if (hasBoolValues)
        {
            foreach (JsonElement c in constants.Where(c => c.ValueKind is JsonValueKind.True or JsonValueKind.False))
            {
                string tokenName = c.ValueKind == JsonValueKind.True ? "True" : "False";
                ctx.AppendLine();
                ctx.AppendLine($"if (tokenType == JsonTokenType.{tokenName})");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("goto enumShortCircuitSuccess;");
                ctx.PopIndent();
                ctx.AppendLine("}");
            }
        }

        if (hasNullValues)
        {
            ctx.AppendLine();
            ctx.AppendLine("if (tokenType == JsonTokenType.Null)");
            ctx.AppendLine("{");
            ctx.PushIndent();
            ctx.AppendLine("goto enumShortCircuitSuccess;");
            ctx.PopIndent();
            ctx.AppendLine("}");
        }

        if (hasComplexValues)
        {
            foreach (JsonElement c in constants.Where(c => c.ValueKind is JsonValueKind.Object or JsonValueKind.Array))
            {
                string quotedRaw = SymbolDisplay.FormatLiteral(c.GetRawText(), true);
                ctx.AppendLine();
                ctx.AppendLine($"if (JsonElementHelpers.DeepEqualsNoParentDocumentCheck({quotedRaw}, tokenType, parentDocument, parentIndex))");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("goto enumShortCircuitSuccess;");
                ctx.PopIndent();
                ctx.AppendLine("}");
            }
        }

        ctx.AppendLine();
        ctx.AppendLine($"context.EvaluatedKeyword(false, messageProvider: JsonSchemaEvaluation.DidNotMatchAtLeastOneConstantValue, {formattedKeyword});");
        ctx.AppendLine();
        ctx.AppendLine("if (!context.HasCollector)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("return;");
        ctx.PopIndent();
        ctx.AppendLine("}");
        ctx.AppendLine();
        ctx.AppendLine("goto enumAfterFailure;");
        ctx.AppendLine();
        ctx.AppendLine("enumShortCircuitSuccess:");
        ctx.AppendLine($"context.EvaluatedKeyword(true, messageProvider: JsonSchemaEvaluation.MatchedAtLeastOneConstantValue, {formattedKeyword});");
        ctx.AppendLine();
        ctx.AppendLine("enumAfterFailure:;");
    }

    private static void EmitStringValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        var lengthKeywords = typeDeclaration.Keywords().OfType<IStringLengthConstantValidationKeyword>().ToList();
        var regexKeywords = typeDeclaration.Keywords().OfType<IStringRegexValidationProviderKeyword>().ToList();

        if (lengthKeywords.Count == 0 && regexKeywords.Count == 0)
        {
            return;
        }

        ctx.AppendLine();
        ctx.AppendLine("if (tokenType == JsonTokenType.String)");
        ctx.AppendLine("{");
        ctx.PushIndent();

        if (lengthKeywords.Count > 0)
        {
            ctx.AppendLine("int stringLength = parentDocument.GetStringLength(parentIndex);");

            foreach (IStringLengthConstantValidationKeyword keyword in lengthKeywords)
            {
                if (!keyword.TryGetOperator(typeDeclaration, out Operator op) || op == Operator.None)
                {
                    continue;
                }

                if (!keyword.TryGetValidationConstants(typeDeclaration, out JsonElement[]? constants) || constants.Length == 0)
                {
                    continue;
                }

                int expected = (int)constants[0].GetDecimal();
                string opFunc = GetStringLengthOperatorFunction(op);

                ctx.AppendLine($"{opFunc}({expected}, stringLength, {FormatUtf8Literal(keyword.Keyword)}, ref context);");
                ctx.AppendLine();
                ctx.AppendLine("if (!context.HasCollector && !context.IsMatch)");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("return;");
                ctx.PopIndent();
                ctx.AppendLine("}");
            }
        }

        if (regexKeywords.Count > 0)
        {
            ctx.AppendLine("using UnescapedUtf8JsonString patternUnescaped = parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String);");

            foreach (IStringRegexValidationProviderKeyword keyword in regexKeywords)
            {
                if (!keyword.TryGetValidationRegularExpressions(typeDeclaration, out IReadOnlyList<string>? expressions) || expressions.Count == 0)
                {
                    continue;
                }

                string regex = SymbolDisplay.FormatLiteral(expressions[0], true);
                string fieldName = "PatternRegex_" + MakeSafeIdentifier(keyword.Keyword);

                ctx.AppendLine($"JsonSchemaEvaluation.MatchRegularExpression(patternUnescaped.Span, {fieldName}, {regex}, {FormatUtf8Literal(keyword.Keyword)}, ref context);");
                ctx.AppendLine();
                ctx.AppendLine("if (!context.HasCollector && !context.IsMatch)");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine("return;");
                ctx.PopIndent();
                ctx.AppendLine("}");
            }
        }

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static string GetStringLengthOperatorFunction(Operator op)
    {
        return op switch
        {
            Operator.Equals => "JsonSchemaEvaluation.MatchLengthEquals",
            Operator.NotEquals => "JsonSchemaEvaluation.MatchLengthNotEquals",
            Operator.LessThan => "JsonSchemaEvaluation.MatchLengthLessThan",
            Operator.LessThanOrEquals => "JsonSchemaEvaluation.MatchLengthLessThanOrEquals",
            Operator.GreaterThan => "JsonSchemaEvaluation.MatchLengthGreaterThan",
            Operator.GreaterThanOrEquals => "JsonSchemaEvaluation.MatchLengthGreaterThanOrEquals",
            _ => throw new System.InvalidOperationException($"Unsupported string length operator: {op}"),
        };
    }

    private static void EmitNumberValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        var numberKeywords = typeDeclaration.Keywords().OfType<INumberConstantValidationKeyword>().ToList();
        if (numberKeywords.Count == 0)
        {
            return;
        }

        ctx.AppendLine();
        ctx.AppendLine("if (tokenType == JsonTokenType.Number)");
        ctx.AppendLine("{");
        ctx.PushIndent();
        ctx.AppendLine("ReadOnlyMemory<byte> numRawValue = parentDocument.GetRawSimpleValue(parentIndex);");
        ctx.AppendLine("JsonElementHelpers.TryParseNumber(numRawValue.Span, out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);");

        foreach (INumberConstantValidationKeyword keyword in numberKeywords)
        {
            if (!keyword.TryGetOperator(typeDeclaration, out Operator op) || op == Operator.None)
            {
                continue;
            }

            if (!keyword.TryGetValidationConstants(typeDeclaration, out JsonElement[]? constants) || constants.Length == 0)
            {
                continue;
            }

            ctx.AppendLine();

            string rawText = constants[0].GetRawText();
            byte[] rawBytes = System.Text.Encoding.UTF8.GetBytes(rawText);
            JsonElementHelpers.ParseNumber(rawBytes, out bool isNeg, out ReadOnlySpan<byte> intPart, out ReadOnlySpan<byte> fracPart, out int expVal);

            string isNegStr = BoolLiteral(isNeg);
            string integralStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(intPart.ToArray()), true);
            string fractionalStr = SymbolDisplay.FormatLiteral(System.Text.Encoding.UTF8.GetString(fracPart.ToArray()), true);
            string expStr = expVal.ToString();
            string rawValueStr = SymbolDisplay.FormatLiteral(rawText, true);

            if (op == Operator.MultipleOf)
            {
                string divisor = System.Text.Encoding.UTF8.GetString(intPart.ToArray()) + System.Text.Encoding.UTF8.GetString(fracPart.ToArray());
                ctx.AppendLine($"JsonSchemaEvaluation.MatchMultipleOf(integral, fractional, exponent, {divisor}, {expStr}, {rawValueStr}, {FormatUtf8Literal(keyword.Keyword)}, ref context);");
            }
            else
            {
                string opFunc = GetNumberOperatorFunction(op);
                ctx.AppendLine($"{opFunc}(isNegative, integral, fractional, exponent, {isNegStr}, {integralStr}u8, {fractionalStr}u8, {expStr}, {rawValueStr}, {FormatUtf8Literal(keyword.Keyword)}, ref context);");
            }

            ctx.AppendLine();
            ctx.AppendLine("if (!context.HasCollector && !context.IsMatch)");
            ctx.AppendLine("{");
            ctx.PushIndent();
            ctx.AppendLine("return;");
            ctx.PopIndent();
            ctx.AppendLine("}");
        }

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static string GetNumberOperatorFunction(Operator op)
    {
        return op switch
        {
            Operator.Equals => "JsonSchemaEvaluation.MatchEquals",
            Operator.NotEquals => "JsonSchemaEvaluation.MatchNotEquals",
            Operator.LessThan => "JsonSchemaEvaluation.MatchLessThan",
            Operator.LessThanOrEquals => "JsonSchemaEvaluation.MatchLessThanOrEquals",
            Operator.GreaterThan => "JsonSchemaEvaluation.MatchGreaterThan",
            Operator.GreaterThanOrEquals => "JsonSchemaEvaluation.MatchGreaterThanOrEquals",
            _ => throw new System.InvalidOperationException($"Unsupported number operator: {op}"),
        };
    }

    private static void EmitFormatValidation(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        IFormatProviderKeyword? formatKw = typeDeclaration.Keywords().OfType<IFormatProviderKeyword>().FirstOrDefault();
        if (formatKw is null)
        {
            return;
        }

        // Format is emitted as an annotation via EmitAnnotations when not asserted.
        // When asserted (IFormatValidationKeyword), it validates the format.
        if (formatKw is not IFormatValidationKeyword)
        {
            return;
        }

        // Format assertion: delegated to the existing format validation.
        // The standalone evaluator emits a format check using the format name.
        if (!formatKw.TryGetFormat(typeDeclaration, out string? formatName))
        {
            return;
        }

        string formattedKeyword = FormatUtf8Literal(formatKw.Keyword);
        string quotedFormat = SymbolDisplay.FormatLiteral(formatName, true);

        ctx.AppendLine();
        ctx.AppendLine($"JsonSchemaEvaluation.ValidateFormat(parentDocument, parentIndex, tokenType, {quotedFormat}, {formattedKeyword}, ref context);");
    }

    private static void EmitCompositionValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        EmitAllOfValidation(ctx, typeDeclaration, subschemas);
        EmitAnyOfValidation(ctx, typeDeclaration, subschemas);
        EmitOneOfValidation(ctx, typeDeclaration, subschemas);
        EmitNotValidation(ctx, typeDeclaration, subschemas);
    }

    private static void EmitIfThenElseValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        // Stub: will be implemented in StandaloneEvaluatorGenerator.Conditional.cs
    }

    private static void EmitObjectValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        // Stub: will be implemented in StandaloneEvaluatorGenerator.Object.cs
    }

    private static void EmitArrayValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        // Stub: will be implemented in StandaloneEvaluatorGenerator.Array.cs
    }

    private static void EmitUnevaluatedValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        // Stub: will be implemented in StandaloneEvaluatorGenerator.Unevaluated.cs
    }

    private static void EmitAnnotations(GenerationContext ctx, TypeDeclaration typeDeclaration)
    {
        var annotations = new List<(string Keyword, string JsonValue)>();

        foreach (IKeyword keyword in typeDeclaration.Keywords())
        {
            if (keyword is IAnnotationProducingKeyword annKw &&
                annKw.TryGetAnnotationJsonValue(typeDeclaration, out string rawJsonValue) &&
                annKw.AnnotationPreconditionsMet(typeDeclaration))
            {
                annotations.Add((keyword.Keyword, rawJsonValue));
            }
        }

        if (annotations.Count == 0)
        {
            return;
        }

        ctx.AppendLine();
        ctx.AppendLine("if (context.HasCollector)");
        ctx.AppendLine("{");
        ctx.PushIndent();

        foreach (var (keyword, jsonValue) in annotations)
        {
            string valueUtf8 = FormatUtf8Literal(jsonValue);
            ctx.AppendLine($"context.IgnoredKeyword(static (buffer, out written) => JsonSchemaEvaluation.TryCopyMessage({valueUtf8}, buffer, out written), {FormatUtf8Literal(keyword)});");
        }

        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    private static void EmitAllOfValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        if (typeDeclaration.AllOfCompositionTypes() is not { } allOf)
        {
            return;
        }

        bool useItems = typeDeclaration.RequiresItemsEvaluationTracking();
        bool useProps = typeDeclaration.RequiresPropertyEvaluationTracking();
        int groupIdx = 0;

        foreach (var kvp in allOf)
        {
            string keywordName = kvp.Key.Keyword;
            List<SubschemaInfo> entries = ResolveSubschemaInfos(kvp.Value, subschemas);

            if (entries.Count == 0)
            {
                groupIdx++;
                continue;
            }

            string suffix = groupIdx > 0 ? groupIdx.ToString() : string.Empty;
            string composedVar = $"allOfComposedIsMatch{suffix}";
            string endLabel = $"allOfEnd{suffix}";
            bool needsLabel = entries.Count > 1;

            ctx.AppendLine();
            ctx.AppendLine($"bool {composedVar} = true;");

            for (int i = 0; i < entries.Count; i++)
            {
                SubschemaInfo info = entries[i];
                string contextVar = $"allOfCtx{suffix}_{i}";
                string pathField = info.PathFieldName ?? "null";

                ctx.AppendLine();
                ctx.AppendLine($"JsonSchemaContext {contextVar} =");
                ctx.PushIndent();
                ctx.AppendLine($"context.PushChildContext(parentDocument, parentIndex, useEvaluatedItems: {BoolLiteral(useItems)}, useEvaluatedProperties: {BoolLiteral(useProps)}, evaluationPath: {pathField});");
                ctx.PopIndent();
                ctx.AppendLine($"{info.MethodName}(parentDocument, parentIndex, ref {contextVar});");
                ctx.AppendLine($"{composedVar} = {composedVar} && {contextVar}.IsMatch;");
                ctx.AppendLine($"context.ApplyEvaluated(ref {contextVar});");
                ctx.AppendLine($"context.CommitChildContext({contextVar}.IsMatch, ref {contextVar});");

                if (needsLabel && i < entries.Count - 1)
                {
                    ctx.AppendLine();
                    ctx.AppendLine($"if (!context.HasCollector && !{composedVar})");
                    ctx.AppendLine("{");
                    ctx.PushIndent();
                    ctx.AppendLine($"goto {endLabel};");
                    ctx.PopIndent();
                    ctx.AppendLine("}");
                }
            }

            if (needsLabel)
            {
                ctx.AppendLine();
                ctx.AppendLine($"{endLabel}:");
            }

            ctx.AppendLine($"context.EvaluatedKeyword({composedVar}, {composedVar} ? JsonSchemaEvaluation.MatchedAllSchema : JsonSchemaEvaluation.DidNotMatchAllSchema, {FormatUtf8Literal(keywordName)});");

            groupIdx++;
        }
    }

    private static void EmitAnyOfValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        if (typeDeclaration.AnyOfCompositionTypes() is not { } anyOf)
        {
            return;
        }

        bool useItems = typeDeclaration.RequiresItemsEvaluationTracking();
        bool useProps = typeDeclaration.RequiresPropertyEvaluationTracking();
        int groupIdx = 0;

        foreach (var kvp in anyOf)
        {
            string keywordName = kvp.Key.Keyword;
            List<SubschemaInfo> entries = ResolveSubschemaInfos(kvp.Value, subschemas);

            if (entries.Count == 0)
            {
                groupIdx++;
                continue;
            }

            string suffix = groupIdx > 0 ? groupIdx.ToString() : string.Empty;
            string composedVar = $"anyOfComposedIsMatch{suffix}";
            string endLabel = $"anyOfEnd{suffix}";
            bool needsLabel = entries.Count > 1;

            ctx.AppendLine();
            ctx.AppendLine($"bool {composedVar} = false;");

            for (int i = 0; i < entries.Count; i++)
            {
                SubschemaInfo info = entries[i];
                string contextVar = $"anyOfCtx{suffix}_{i}";
                string pathField = info.PathFieldName ?? "null";

                ctx.AppendLine();
                ctx.AppendLine($"JsonSchemaContext {contextVar} =");
                ctx.PushIndent();
                ctx.AppendLine($"context.PushChildContext(parentDocument, parentIndex, useEvaluatedItems: {BoolLiteral(useItems)}, useEvaluatedProperties: {BoolLiteral(useProps)}, evaluationPath: {pathField});");
                ctx.PopIndent();
                ctx.AppendLine($"{info.MethodName}(parentDocument, parentIndex, ref {contextVar});");
                ctx.AppendLine($"{composedVar} = {composedVar} || {contextVar}.IsMatch;");
                ctx.AppendLine($"if ({contextVar}.IsMatch)");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine($"context.ApplyEvaluated(ref {contextVar});");
                ctx.PopIndent();
                ctx.AppendLine("}");
                ctx.AppendLine();
                ctx.AppendLine($"context.CommitChildContext({contextVar}.IsMatch, ref {contextVar});");

                if (needsLabel && i < entries.Count - 1)
                {
                    ctx.AppendLine();
                    ctx.AppendLine($"if (!context.HasCollector && {composedVar})");
                    ctx.AppendLine("{");
                    ctx.PushIndent();
                    ctx.AppendLine($"goto {endLabel};");
                    ctx.PopIndent();
                    ctx.AppendLine("}");
                }
            }

            if (needsLabel)
            {
                ctx.AppendLine();
                ctx.AppendLine($"{endLabel}:");
            }

            ctx.AppendLine($"context.EvaluatedKeyword({composedVar}, {composedVar} ? JsonSchemaEvaluation.MatchedAtLeastOneSchema : JsonSchemaEvaluation.DidNotMatchAtLeastOneSchema, {FormatUtf8Literal(keywordName)});");

            groupIdx++;
        }
    }

    private static void EmitOneOfValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        if (typeDeclaration.OneOfCompositionTypes() is not { } oneOf)
        {
            return;
        }

        bool useItems = typeDeclaration.RequiresItemsEvaluationTracking();
        bool useProps = typeDeclaration.RequiresPropertyEvaluationTracking();
        int groupIdx = 0;

        foreach (var kvp in oneOf)
        {
            string keywordName = kvp.Key.Keyword;
            List<SubschemaInfo> entries = ResolveSubschemaInfos(kvp.Value, subschemas);

            if (entries.Count == 0)
            {
                groupIdx++;
                continue;
            }

            string suffix = groupIdx > 0 ? groupIdx.ToString() : string.Empty;
            string countVar = $"oneOfMatchedCount{suffix}";
            string endLabel = $"oneOfEnd{suffix}";
            bool needsLabel = entries.Count > 1;

            ctx.AppendLine();
            ctx.AppendLine($"int {countVar} = 0;");

            for (int i = 0; i < entries.Count; i++)
            {
                SubschemaInfo info = entries[i];
                string contextVar = $"oneOfCtx{suffix}_{i}";
                string pathField = info.PathFieldName ?? "null";

                ctx.AppendLine();
                ctx.AppendLine($"JsonSchemaContext {contextVar} =");
                ctx.PushIndent();
                ctx.AppendLine($"context.PushChildContext(parentDocument, parentIndex, useEvaluatedItems: {BoolLiteral(useItems)}, useEvaluatedProperties: {BoolLiteral(useProps)}, evaluationPath: {pathField});");
                ctx.PopIndent();
                ctx.AppendLine($"{info.MethodName}(parentDocument, parentIndex, ref {contextVar});");
                ctx.AppendLine($"if ({contextVar}.IsMatch)");
                ctx.AppendLine("{");
                ctx.PushIndent();
                ctx.AppendLine($"{countVar}++;");
                ctx.AppendLine($"context.ApplyEvaluated(ref {contextVar});");
                ctx.PopIndent();
                ctx.AppendLine("}");
                ctx.AppendLine();
                ctx.AppendLine($"context.CommitChildContext({contextVar}.IsMatch, ref {contextVar});");

                if (needsLabel && i < entries.Count - 1)
                {
                    ctx.AppendLine();
                    ctx.AppendLine($"if (!context.HasCollector && {countVar} > 1)");
                    ctx.AppendLine("{");
                    ctx.PushIndent();
                    ctx.AppendLine($"goto {endLabel};");
                    ctx.PopIndent();
                    ctx.AppendLine("}");
                }
            }

            if (needsLabel)
            {
                ctx.AppendLine();
                ctx.AppendLine($"{endLabel}:");
            }

            string isMatchVar = $"oneOfIsMatch{suffix}";
            ctx.AppendLine($"bool {isMatchVar} = {countVar} == 1;");
            ctx.AppendLine($"context.EvaluatedKeyword({isMatchVar}, {countVar} == 0 ? JsonSchemaEvaluation.MatchedNoSchema : {countVar} == 1 ? JsonSchemaEvaluation.MatchedExactlyOneSchema : JsonSchemaEvaluation.MatchedMoreThanOneSchema, {FormatUtf8Literal(keywordName)});");

            groupIdx++;
        }
    }

    private static void EmitNotValidation(
        GenerationContext ctx,
        TypeDeclaration typeDeclaration,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        foreach (INotValidationKeyword notKeyword in typeDeclaration.Keywords().OfType<INotValidationKeyword>())
        {
            if (!notKeyword.TryGetNotType(typeDeclaration, out ReducedTypeDeclaration? notType) ||
                notType is not ReducedTypeDeclaration notDecl)
            {
                continue;
            }

            string subLoc = notDecl.ReducedType.LocatedSchema.Location.ToString();
            if (!subschemas.TryGetValue(subLoc, out SubschemaInfo? info))
            {
                continue;
            }

            string keywordName = notKeyword.Keyword;
            string pathField = info.PathFieldName ?? "null";

            ctx.AppendLine();
            ctx.AppendLine("JsonSchemaContext notContext =");
            ctx.PushIndent();
            ctx.AppendLine($"context.PushChildContext(parentDocument, parentIndex, useEvaluatedItems: false, useEvaluatedProperties: false, evaluationPath: {pathField});");
            ctx.PopIndent();
            ctx.AppendLine($"{info.MethodName}(parentDocument, parentIndex, ref notContext);");
            ctx.AppendLine("bool notIsMatch = !notContext.IsMatch;");
            ctx.AppendLine("context.CommitChildContext(notIsMatch, ref notContext);");
            ctx.AppendLine($"context.EvaluatedKeyword(notIsMatch, notIsMatch ? JsonSchemaEvaluation.MatchedNotSchema : JsonSchemaEvaluation.DidNotMatchNotSchema, {FormatUtf8Literal(keywordName)});");
        }
    }

    private static List<SubschemaInfo> ResolveSubschemaInfos(
        IReadOnlyCollection<TypeDeclaration> subTypes,
        Dictionary<string, SubschemaInfo> subschemas)
    {
        var result = new List<SubschemaInfo>();
        foreach (TypeDeclaration subType in subTypes)
        {
            string subLoc = subType.LocatedSchema.Location.ToString();
            if (subschemas.TryGetValue(subLoc, out SubschemaInfo? info))
            {
                result.Add(info);
            }
        }

        return result;
    }

    private static bool TryGetSingleCoreType(CoreTypes types, out CoreTypes singleType)
    {
        singleType = CoreTypes.None;
        int count = 0;

        foreach (CoreTypes candidate in new[]
        {
            CoreTypes.Object,
            CoreTypes.Array,
            CoreTypes.String,
            CoreTypes.Number,
            CoreTypes.Integer,
            CoreTypes.Boolean,
            CoreTypes.Null,
        })
        {
            if ((types & candidate) != 0)
            {
                singleType = candidate;
                count++;
                if (count > 1)
                {
                    return false;
                }
            }
        }

        return count == 1;
    }

    private static string GetMatchMethodName(CoreTypes type)
    {
        return type switch
        {
            CoreTypes.Object => "MatchTypeObject",
            CoreTypes.Array => "MatchTypeArray",
            CoreTypes.String => "MatchTypeString",
            CoreTypes.Number => "MatchTypeNumber",
            CoreTypes.Integer => "MatchTypeInteger",
            CoreTypes.Boolean => "MatchTypeBoolean",
            CoreTypes.Null => "MatchTypeNull",
            _ => throw new System.InvalidOperationException($"Unexpected core type: {type}"),
        };
    }

    private static string GetIgnoredNotTypeName(CoreTypes type)
    {
        return type switch
        {
            CoreTypes.Object => "IgnoredNotTypeObject",
            CoreTypes.Array => "IgnoredNotTypeArray",
            CoreTypes.String => "IgnoredNotTypeString",
            CoreTypes.Number => "IgnoredNotTypeNumber",
            CoreTypes.Integer => "IgnoredNotTypeInteger",
            CoreTypes.Boolean => "IgnoredNotTypeBoolean",
            CoreTypes.Null => "IgnoredNotTypeNull",
            _ => throw new System.InvalidOperationException($"Unexpected core type: {type}"),
        };
    }

    private static string GetTypeKeywordLiteral(TypeDeclaration typeDeclaration)
    {
        foreach (IKeyword kw in typeDeclaration.Keywords())
        {
            if (kw is ICoreTypeValidationKeyword)
            {
                return FormatUtf8Literal(kw.Keyword);
            }
        }

        return FormatUtf8Literal("type");
    }

    private static List<string> GetTypeSensitiveKeywordNames(TypeDeclaration typeDeclaration, CoreTypes targetType)
    {
        var names = new List<string>();

        foreach (IKeyword keyword in typeDeclaration.Keywords())
        {
            bool isSensitive = targetType switch
            {
                CoreTypes.Object => keyword is IObjectValidationKeyword,
                CoreTypes.Array => keyword is IArrayValidationKeyword,
                CoreTypes.String => keyword is IStringValidationKeyword,
                CoreTypes.Number or CoreTypes.Integer => keyword is INumberValidationKeyword,
                CoreTypes.Boolean => keyword is IBooleanValidationKeyword,
                CoreTypes.Null => keyword is INullValidationKeyword,
                _ => false,
            };

            if (isSensitive)
            {
                names.Add(keyword.Keyword);
            }
        }

        return names;
    }

    private static string GetEvaluatorClassName(TypeDeclaration rootType)
    {
        if (rootType.TryGetDotnetTypeName(out string? typeName))
        {
            return typeName + "Evaluator";
        }

        string location = rootType.LocatedSchema.Location.ToString();
        string safeName = MakeSafeIdentifier(location);
        return safeName + "Evaluator";
    }

    private static string MakeSafeIdentifier(string input)
    {
        var sb = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
            else if (sb.Length > 0 && sb[sb.Length - 1] != '_')
            {
                sb.Append('_');
            }
        }

        if (sb.Length == 0 || !char.IsLetter(sb[0]))
        {
            sb.Insert(0, "Schema");
        }

        return sb.ToString().TrimEnd('_');
    }

    private static string FormatUtf8Literal(string value)
    {
        return SymbolDisplay.FormatLiteral(value, true) + "u8";
    }

    private static string BoolLiteral(bool value)
    {
        return value ? "true" : "false";
    }

    private static void EmitFileHeader(GenerationContext ctx, CSharpLanguageProvider.Options options)
    {
        ctx.AppendLine("// <auto-generated/>");
        ctx.AppendLine("#nullable enable");
        ctx.AppendLine();

        if (options.AddExplicitUsings)
        {
            ctx.AppendLine("using System;");
        }

        ctx.AppendLine("using System.Diagnostics;");
        ctx.AppendLine("using System.Diagnostics.CodeAnalysis;");
        ctx.AppendLine("using System.Buffers;");
        ctx.AppendLine("using System.Buffers.Text;");
        ctx.AppendLine("using System.Runtime.CompilerServices;");
        ctx.AppendLine("using Corvus.Text.Json;");
        ctx.AppendLine("using Corvus.Text.Json.Internal;");
        ctx.AppendLine();
    }

    private static void EmitNamespaceOpen(GenerationContext ctx, string ns)
    {
        ctx.AppendLine($"namespace {ns};");
        ctx.AppendLine();
    }

    private static void EmitClassOpen(GenerationContext ctx, string className)
    {
        ctx.AppendLine("/// <summary>");
        ctx.AppendLine($"/// Standalone schema evaluator for the <c>{className.Replace("Evaluator", string.Empty)}</c> schema.");
        ctx.AppendLine("/// </summary>");
        ctx.AppendLine($"public static class {className}");
        ctx.AppendLine("{");
        ctx.PushIndent();
    }

    private static void EmitClassClose(GenerationContext ctx)
    {
        ctx.PopIndent();
        ctx.AppendLine("}");
    }

    /// <summary>
    /// Tracks information about a subschema for code generation.
    /// </summary>
    internal sealed class SubschemaInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubschemaInfo"/> class.
        /// </summary>
        /// <param name="methodName">The evaluation method name.</param>
        /// <param name="schemaPath">The schema evaluation path.</param>
        /// <param name="typeDeclaration">The type declaration for this subschema.</param>
        /// <param name="useEvaluatedItems">Whether items evaluation tracking is needed.</param>
        /// <param name="useEvaluatedProperties">Whether property evaluation tracking is needed.</param>
        public SubschemaInfo(
            string methodName,
            string schemaPath,
            TypeDeclaration typeDeclaration,
            bool useEvaluatedItems,
            bool useEvaluatedProperties)
        {
            this.MethodName = methodName;
            this.SchemaPath = schemaPath;
            this.TypeDeclaration = typeDeclaration;
            this.UseEvaluatedItems = useEvaluatedItems;
            this.UseEvaluatedProperties = useEvaluatedProperties;
        }

        /// <summary>
        /// Gets the evaluation method name (e.g. "EvaluateAllOf0").
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// Gets the schema evaluation path (e.g. "#/allOf/0").
        /// </summary>
        public string SchemaPath { get; }

        /// <summary>
        /// Gets the type declaration for this subschema.
        /// </summary>
        public TypeDeclaration TypeDeclaration { get; }

        /// <summary>
        /// Gets a value indicating whether items evaluation tracking is needed.
        /// </summary>
        public bool UseEvaluatedItems { get; }

        /// <summary>
        /// Gets a value indicating whether property evaluation tracking is needed.
        /// </summary>
        public bool UseEvaluatedProperties { get; }

        /// <summary>
        /// Gets or sets the path provider field name (set during field emission).
        /// </summary>
        public string? PathFieldName { get; set; }
    }

    /// <summary>
    /// Lightweight code builder with indentation support.
    /// </summary>
    internal sealed class GenerationContext
    {
        private readonly StringBuilder builder = new();
        private readonly string lineEnd;
        private int indentLevel;
        private string currentIndent = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerationContext"/> class.
        /// </summary>
        /// <param name="lineEnd">The line ending sequence.</param>
        public GenerationContext(string lineEnd)
        {
            this.lineEnd = lineEnd;
        }

        /// <summary>
        /// Increases the indentation level by one.
        /// </summary>
        public void PushIndent()
        {
            this.indentLevel++;
            this.currentIndent = new string(' ', this.indentLevel * 4);
        }

        /// <summary>
        /// Decreases the indentation level by one.
        /// </summary>
        public void PopIndent()
        {
            this.indentLevel--;
            this.currentIndent = this.indentLevel > 0
                ? new string(' ', this.indentLevel * 4)
                : string.Empty;
        }

        /// <summary>
        /// Appends an empty line (line ending only, no indent).
        /// </summary>
        public void AppendLine()
        {
            this.builder.Append(this.lineEnd);
        }

        /// <summary>
        /// Appends a line at the current indent level, followed by a line ending.
        /// </summary>
        /// <param name="line">The text content of the line.</param>
        public void AppendLine(string line)
        {
            this.builder.Append(this.currentIndent);
            this.builder.Append(line);
            this.builder.Append(this.lineEnd);
        }

        /// <summary>
        /// Appends a line at the current indent level, followed by a line ending.
        /// Equivalent to <see cref="AppendLine(string)"/>; provides a self-documenting
        /// call site when the string is already logically indented content.
        /// </summary>
        /// <param name="line">The text content of the line.</param>
        public void AppendLineIndent(string line)
        {
            this.AppendLine(line);
        }

        /// <summary>
        /// Appends raw text inline (no indent, no line ending).
        /// </summary>
        /// <param name="text">The raw text to append.</param>
        public void AppendRaw(string text)
        {
            this.builder.Append(text);
        }

        /// <summary>
        /// Appends text without a line ending (no indent prefix).
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void Append(string text)
        {
            this.builder.Append(text);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.builder.ToString();
        }
    }
}