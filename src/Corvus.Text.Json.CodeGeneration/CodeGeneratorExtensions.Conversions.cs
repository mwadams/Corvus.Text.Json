// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Corvus.Json.CodeGeneration;


namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
        /// <summary>
        /// Appends <c>TryGet()</c> methods for composition types.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="rootDeclaration">The type declaration which is the basis of the composition types.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendTryGetAsCompositionTypeMethods(
            this CodeGenerator generator,
            TypeDeclaration rootDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            HashSet<string> visitedTypes = [];

            foreach (TypeDeclaration t in rootDeclaration.CompositionTypeDeclarations())
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (!visitedTypes.Add(t.FullyQualifiedDotnetTypeName()))
                {
                    continue;
                }

                string methodName = generator.GetMethodNameInScope("TryGetAs", suffix: t.DotnetTypeName());
                string typeName = t.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Gets the value as a <see cref=\"", typeName, "\" />.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"result\">The result of the conversions.</param>")
                    .AppendLineIndent("/// <returns><see langword=\"true\" /> if the conversion was valid.</returns>")
                    .AppendLineIndent("public bool ", methodName, "(out ", typeName, " result)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("if (", typeName, ".", generator.JsonSchemaClassName(typeName), ".Evaluate(_parent, _idx))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("result = ", typeName, ".From(this);")
                            .AppendLineIndent("return true;")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("result = default;")
                        .AppendLineIndent("return false;")
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            return generator;
        }

        /// <summary>
        /// Appends conversions from dotnet type of the <paramref name="rootDeclaration"/>
        /// to the composition types.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name"rootDeclaration">The type declaration which is the basis of the conversions.</param>
        /// <param name="forMutable">If <see langword="true"/>, the code should be emitted for a mutable type.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendConversionToCompositionTypes(
        this CodeGenerator generator,
        TypeDeclaration rootDeclaration,
        bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            HashSet<TypeDeclaration> appliedConversions = [];
            Queue<(TypeDeclaration Target, bool AllowsImplicitFrom, bool AllowsImplicitTo)> typesToProcess = [];

            typesToProcess.Enqueue((rootDeclaration, true, true));

            while (typesToProcess.Count > 0)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                (TypeDeclaration subschema, bool allowsImplicitFrom, bool allowsImplicitTo) = typesToProcess.Dequeue();
                AppendConversions(generator, appliedConversions, rootDeclaration, subschema, allowsImplicitFrom, allowsImplicitTo, forMutable);
                AppendCompositionConversions(generator, appliedConversions, typesToProcess, rootDeclaration, subschema, allowsImplicitFrom: allowsImplicitFrom, allowsImplicitTo: allowsImplicitTo, forMutable);
            }

            return generator;

            static void AppendCompositionConversions(
                CodeGenerator generator,
                HashSet<TypeDeclaration> appliedConversions,
                Queue<(TypeDeclaration Target, bool AllowsImplicitFrom, bool AllowsImplicitTo)> typesToProcess,
                TypeDeclaration rootType,
                TypeDeclaration sourceType,
                bool allowsImplicitFrom,
                bool allowsImplicitTo,
                bool forMutable)
            {
                if (generator.IsCancellationRequested)
                {
                    return;
                }

                if (sourceType.AllOfCompositionTypes() is IReadOnlyDictionary<IAllOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> allOf)
                {
                    AppendSubschemaConversions(generator, appliedConversions, typesToProcess, rootType, allOf.SelectMany(k => k.Value).ToList(), isImplicitFrom: false, isImplicitTo: allowsImplicitTo, forMutable: forMutable);
                }

                if (sourceType.AnyOfCompositionTypes() is IReadOnlyDictionary<IAnyOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> anyOf)
                {
                    // Defer any of until all the AllOf have been processed so we prefer an implicit to the allOf types
                    foreach (TypeDeclaration subschema in anyOf.SelectMany(k => k.Value))
                    {
                        if (generator.IsCancellationRequested)
                        {
                            return;
                        }

                        typesToProcess.Enqueue((subschema.ReducedTypeDeclaration().ReducedType, allowsImplicitFrom, false));
                    }
                }

                if (sourceType.OneOfCompositionTypes() is IReadOnlyDictionary<IOneOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> oneOf)
                {
                    // Defer any of until all the AllOf have been processed so we prefer an implicit to the allOf types
                    foreach (TypeDeclaration subschema in oneOf.SelectMany(k => k.Value))
                    {
                        if (generator.IsCancellationRequested)
                        {
                            return;
                        }

                        typesToProcess.Enqueue((subschema.ReducedTypeDeclaration().ReducedType, allowsImplicitFrom, false));
                    }
                }
            }

            static void AppendSubschemaConversions(
                CodeGenerator generator,
                HashSet<TypeDeclaration> appliedConversions,
                Queue<(TypeDeclaration Target, bool AllowsImplicitFrom, bool AllowsImplicitTo)> typesToProcess,
                TypeDeclaration rootDeclaration,
                IReadOnlyCollection<TypeDeclaration> subschemas,
                bool isImplicitFrom,
                bool isImplicitTo,
                bool forMutable)
            {
                foreach (TypeDeclaration candidate in subschemas)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    TypeDeclaration subschema = candidate.ReducedTypeDeclaration().ReducedType;
                    if (!AppendConversions(generator, appliedConversions, rootDeclaration, subschema, isImplicitFrom, isImplicitTo, forMutable))
                    {
                        continue;
                    }

                    // Recurse, which will add more allOfs, and queue up the anyOfs and oneOfs.
                    AppendCompositionConversions(generator, appliedConversions, typesToProcess, rootDeclaration, subschema, isImplicitFrom, isImplicitTo, forMutable);
                }
            }

            static bool AppendConversions(
                CodeGenerator generator,
                HashSet<TypeDeclaration> appliedConversions,
                TypeDeclaration rootDeclaration,
                TypeDeclaration subschema,
                bool isImplicitFrom,
                bool isImplicitTo,
                bool forMutable)
            {
                if (generator.IsCancellationRequested)
                {
                    return false;
                }

                if (rootDeclaration == subschema)
                {
                    return false;
                }

                if (!appliedConversions.Add(subschema) || subschema.DoNotGenerate())
                {
                    // We've already seen it.
                    return false;
                }

                string implicitOrExplicitFrom = isImplicitFrom ? "implicit" : "explicit";
                string implicitOrExplicitTo = isImplicitTo ? "implicit" : "explicit";

                string subschemaTypeName = subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Conversion to <see cref=\"", subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"value\">The value from which to convert.</param>")
                    .AppendIndent("public static ", implicitOrExplicitTo, " operator ", subschemaTypeName, forMutable ? ".Mutable" : "", "(")
                    .Append(forMutable ? "Mutable" : rootDeclaration.DotnetTypeName())
                    .AppendLine(" value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return ", subschemaTypeName, forMutable ? ".Mutable" : "",  ".From(value);")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Conversion from <see cref=\"", subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"value\">The value from which to convert.</param>")
                    .AppendIndent("public static ", implicitOrExplicitFrom, " operator ", forMutable ? "Mutable" : rootDeclaration.DotnetTypeName(), "(")
                    .Append(subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName())
                    .Append(forMutable ? ".Mutable" : "")
                    .AppendLine(" value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return From(value);")
                    .PopIndent()
                    .AppendLineIndent("}");

                return true;
            }
        }


        /// <summary>
        /// Appends the pattern-matching methods.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration to which to append the method.</param>
        /// <param name="forMutable">If <see langword="true"/>, the code should be emitted for a mutable type.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendMatchMethods(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            int matchOverloadIndex = 0;
            if (typeDeclaration.AllOfCompositionTypes() is IReadOnlyDictionary<IAllOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> allOf)
            {
                foreach (IAllOfSubschemaValidationKeyword keyword in allOf.Keys)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    var subschema = allOf[keyword].Distinct().ToList();
                    if (subschema.Count > 1)
                    {
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: true, matchOverloadIndex++, forMutable);
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: false, matchOverloadIndex++, forMutable);
                    }
                }
            }

            if (typeDeclaration.AnyOfCompositionTypes() is IReadOnlyDictionary<IAnyOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> anyOf)
            {
                foreach (IAnyOfSubschemaValidationKeyword keyword in anyOf.Keys)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    var subschema = anyOf[keyword].Distinct().ToList();
                    if (subschema.Count > 1)
                    {
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: true, matchOverloadIndex++, forMutable);
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: false, matchOverloadIndex++, forMutable);
                    }
                }
            }

            if (typeDeclaration.OneOfCompositionTypes() is IReadOnlyDictionary<IOneOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> oneOf)
            {
                foreach (IOneOfSubschemaValidationKeyword keyword in oneOf.Keys)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    var subschema = oneOf[keyword].Distinct().ToList();
                    if (subschema.Count > 1)
                    {
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: true, matchOverloadIndex++, forMutable);
                        AppendMatchCompositionMethod(generator, typeDeclaration, subschema, includeContext: false, matchOverloadIndex++, forMutable);
                    }
                }
            }

            if (typeDeclaration.AnyOfConstantValues() is IReadOnlyDictionary<IAnyOfConstantValidationKeyword, JsonElement[]> anyOfConstant)
            {
                foreach (IAnyOfConstantValidationKeyword keyword in anyOfConstant.Keys)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return generator;
                    }

                    JsonElement[] constantValues = [.. anyOfConstant[keyword].Distinct()];
                    if (constantValues.Length > 1)
                    {
                        AppendMatchConstantMethod(generator, keyword, constantValues, includeContext: true, matchOverloadIndex: matchOverloadIndex++);
                        AppendMatchConstantMethod(generator, keyword, constantValues, includeContext: false, matchOverloadIndex: matchOverloadIndex++);
                    }
                }
            }

            if (typeDeclaration.IfSubschemaType() is SingleSubschemaKeywordTypeDeclaration ifSubschema)
            {
                AppendMatchIfMethod(generator, typeDeclaration, ifSubschema, includeContext: true, matchOverloadIndex++);
                AppendMatchIfMethod(generator, typeDeclaration, ifSubschema, includeContext: false, matchOverloadIndex++);
            }

            return generator;

            static void AppendMatchCompositionMethod(CodeGenerator generator, TypeDeclaration typeDeclaration, IReadOnlyCollection<TypeDeclaration> subschema, bool includeContext, int matchOverloadIndex, bool forMutable)
            {
                if (generator.IsCancellationRequested)
                {
                    return;
                }

                string scopeName = $"Match{matchOverloadIndex}";

                generator
                    .ReserveNameIfNotReserved("Match")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                    """
                /// <summary>
                /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
                /// </summary>
                """);

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <typeparam name=\"TContext\">The immutable context to pass in to the match function.</typeparam>");
                }

                generator
                    .AppendLineIndent("/// <typeparam name=\"TResult\">The result of calling the match function.</typeparam>");

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <param name=\"context\">The context to pass to the match function.</param>")
                        .ReserveNameIfNotReserved("context", childScope: scopeName);
                }

                // Reserve the parameter names we are going to require
                generator
                    .ReserveNameIfNotReserved("defaultMatch", childScope: scopeName);

                string[] parameterNames = new string[subschema.Count];

                int i = 0;
                foreach (TypeDeclaration match in subschema)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    // This is the parameter name for the match match method.
                    string matchTypeName = match.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName();
                    string matchParamName = generator.GetUniqueParameterNameInScope(match.ReducedTypeDeclaration().ReducedType.DotnetTypeName(), childScope: scopeName, prefix: "match");

                    parameterNames[i++] = matchParamName;

                    generator
                        .AppendLineIndent("/// <param name=\"", matchParamName, "\">Match a <see cref=\"", matchTypeName, "\"/>.</param>");
                }

                generator
                    .AppendLineIndent("/// <param name=\"defaultMatch\">Match any other value.</param>")
                    .AppendLineIndent("/// <returns>An instance of the value returned by the match function.</returns>")
                    .AppendLineIndent("public TResult Match<", includeContext ? "TContext, " : string.Empty, "TResult>(")
                    .PushMemberScope(scopeName, ScopeType.Method)
                    .PushIndent();

                if (includeContext)
                {
                    generator
                        .AppendIndent("in TContext context");
                }

                i = 0;
                foreach (TypeDeclaration match in subschema)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    if (i > 0 || includeContext)
                    {
                        generator
                            .AppendLine(",");
                    }

                    generator
                        .AppendIndent(
                            "Matcher<",
                            match.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName(),
                            includeContext ? ", TContext" : string.Empty,
                            ", TResult> ",
                            parameterNames[i++]);
                }

                generator
                    .AppendLine(",")
                    .AppendLineIndent(
                        "Matcher<",
                        typeDeclaration.FullyQualifiedDotnetTypeName(),
                        forMutable ? ".Mutable" : "",
                        includeContext ? ", TContext" : string.Empty,
                        ", TResult> defaultMatch)")
                    .PopIndent()
                    .AppendLineIndent("{")
                    .PushIndent();

                i = 0;
                foreach (TypeDeclaration match in subschema)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    string matchTypeName = match.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (", matchTypeName, ".", generator.JsonSchemaClassName(), ".Evaluate(_parent, _idx))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("return ", parameterNames[i], "(", matchTypeName, ".From(this)", includeContext ? ", context" : string.Empty, ");")
                        .PopIndent()
                        .AppendLineIndent("}");
                    i++;
                }

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("return defaultMatch(this", includeContext ? ", context" : string.Empty, ");")
                    .PopMemberScope()
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            static void AppendMatchConstantMethod(CodeGenerator generator, IAnyOfConstantValidationKeyword keyword, JsonElement[] constValues, bool includeContext, int matchOverloadIndex)
            {
                if (generator.IsCancellationRequested)
                {
                    return;
                }

                string scopeName = $"Match{matchOverloadIndex}";

                generator
                    .ReserveNameIfNotReserved("Match")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                    """
                /// <summary>
                /// Matches the value against the constant values, and returns the result of calling the provided match function for the first match found.
                /// </summary>
                """);

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <typeparam name=\"TContext\">The immutable context to pass in to the match function.</typeparam>");
                }

                generator
                    .AppendLineIndent("/// <typeparam name=\"TResult\">The result of calling the match function.</typeparam>");

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <param name=\"context\">The context to pass to the match function.</param>")
                        .ReserveNameIfNotReserved("context", childScope: scopeName);
                }

                // Reserve the parameter names we are going to require
                generator
                    .ReserveNameIfNotReserved("defaultMatch", childScope: scopeName);

                int count = constValues.Length;
                string[] parameterNames = new string[count];
                string[] constFields = new string[count];

                for (int i = 1; i <= count; ++i)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    JsonElement constValue = constValues[i - 1];

                    string matchParamName = GetUniqueParameterName(generator, scopeName, constValue, i);
                    string constField =
                        generator.GetPropertyNameInScope(
                            keyword.Keyword,
                            rootScope: generator.JsonSchemaClassScope(),
                            suffix: count > 1 ? i.ToString() : null);

                    parameterNames[i - 1] = matchParamName;
                    constFields[i - 1] = constField;

                    generator
                        .AppendIndent("/// <param name=\"", matchParamName, "\">Match ")
                        .AppendOrdinalName(i)
                        .AppendLine(" item.</param>");
                }

                generator
                    .AppendLineIndent("/// <param name=\"defaultMatch\">Match any other value.</param>")
                    .AppendLineIndent("/// <returns>An instance of the value returned by the match function.</returns>")
                    .AppendLineIndent("public TResult Match<", includeContext ? "TContext, " : string.Empty, "TResult>(")
                    .PushMemberScope(scopeName, ScopeType.Method)
                    .PushIndent();

                if (includeContext)
                {
                    generator
                        .AppendIndent("in TContext context");
                }

                for (int i = 0; i < count; ++i)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    if (i > 0 || includeContext)
                    {
                        generator
                            .AppendLine(",");
                    }

                    generator
                        .AppendIndent(
                            "Func<",
                            includeContext ? "TContext, " : string.Empty,
                            "TResult> ",
                            parameterNames[i]);
                }

                generator
                    .AppendLine(",")
                    .AppendLineIndent(
                        "Func<",
                        includeContext ? "TContext, " : string.Empty,
                        "TResult> defaultMatch)")
                    .PopIndent()
                    .AppendLineIndent("{")
                    .PushIndent();

                for (int i = 0; i < count; ++i)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (this.Equals(", generator.JsonSchemaClassName(), ".", constFields[i], "))")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("return ", parameterNames[i], "(", includeContext ? "context);" : ");")
                        .PopIndent()
                        .AppendLineIndent("}");
                }

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("return defaultMatch(", includeContext ? "context" : string.Empty, ");")
                    .PopMemberScope()
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            static string GetUniqueParameterName(CodeGenerator generator, string scopeName, JsonElement constValue, int index)
            {
                if (generator.IsCancellationRequested)
                {
                    return string.Empty;
                }

                return constValue.ValueKind switch
                {
                    JsonValueKind.Object => generator.GetUniqueParameterNameInScope("matchObjectValue", childScope: scopeName, suffix: index.ToString()),
                    JsonValueKind.Array => generator.GetUniqueParameterNameInScope("matchArrayValue", childScope: scopeName, suffix: index.ToString()),
                    JsonValueKind.String => generator.GetUniqueParameterNameInScope(constValue.GetString()!, childScope: scopeName, prefix: "match"),
                    JsonValueKind.Number => generator.GetUniqueParameterNameInScope(constValue.GetRawText().Replace(".", "point"), childScope: scopeName, prefix: "matchNumber"),
                    JsonValueKind.True => generator.GetUniqueParameterNameInScope("matchTrue", childScope: scopeName),
                    JsonValueKind.False => generator.GetUniqueParameterNameInScope("matchFalse", childScope: scopeName),
                    JsonValueKind.Null => generator.GetUniqueParameterNameInScope("matchNull", childScope: scopeName),
                    _ => throw new InvalidOperationException($"Unsupported JsonValueKind: {constValue.ValueKind}"),
                };
            }

            static void AppendMatchIfMethod(CodeGenerator generator, TypeDeclaration typeDeclaration, SingleSubschemaKeywordTypeDeclaration ifSubschema, bool includeContext, int matchOverloadIndex)
            {
                if (generator.IsCancellationRequested)
                {
                    return;
                }

                SingleSubschemaKeywordTypeDeclaration? thenDeclaration = typeDeclaration.ThenSubschemaType();
                SingleSubschemaKeywordTypeDeclaration? elseDeclaration = typeDeclaration.ElseSubschemaType();

                if (thenDeclaration is null && elseDeclaration is null)
                {
                    return;
                }

                string scopeName = $"Match{matchOverloadIndex}";

                generator
                    .ReserveNameIfNotReserved("Match")
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent(
                        "/// Matches the value against the 'if' type, and returns the result of calling the provided match function for");
                if (thenDeclaration is not null)
                {
                    generator
                        .AppendLineIndent("/// the 'then' type if the match is successful", elseDeclaration is not null ? " or" : ".");
                }

                if (elseDeclaration is not null)
                {
                    generator
                        .AppendLineIndent("/// the 'else' type if the match is not successful.");
                }

                generator
                    .AppendLineIndent("/// </summary>");

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <typeparam name=\"TContext\">The immutable context to pass in to the match function.</typeparam>");
                }

                generator
                    .AppendLineIndent("/// <typeparam name=\"TResult\">The result of calling the match function.</typeparam>");

                if (includeContext)
                {
                    generator
                        .AppendLineIndent("/// <param name=\"context\">The context to pass to the match function.</param>")
                        .ReserveNameIfNotReserved("context", childScope: scopeName);
                }

                string? thenMatchParamName = null;

                if (thenDeclaration is SingleSubschemaKeywordTypeDeclaration thenSubschema)
                {
                    // This is the parameter name for the if match method.
                    string? thenMatchTypeName = thenSubschema.ReducedType.FullyQualifiedDotnetTypeName();
                    thenMatchParamName = generator.GetUniqueParameterNameInScope(thenMatchTypeName, childScope: scopeName, prefix: "match");

                    generator
                        .AppendLineIndent("/// <param name=\"", thenMatchParamName, "\">Match a <see cref=\"", thenMatchTypeName, "\"/>.</param>");
                }

                string? elseMatchParamName = null;
                if (elseDeclaration is SingleSubschemaKeywordTypeDeclaration elseSubschema)
                {
                    // This is the parameter name for the if match method.
                    string? elseMatchTypeName = elseSubschema.ReducedType.FullyQualifiedDotnetTypeName();
                    elseMatchParamName = generator.GetUniqueParameterNameInScope(elseMatchTypeName, childScope: scopeName, prefix: "match");

                    generator
                        .AppendLineIndent("/// <param name=\"", elseMatchParamName, "\">Match a <see cref=\"", elseMatchTypeName, "\"/>.</param>");
                }

                if (elseMatchParamName is null)
                {
                    generator
                        .AppendLineIndent("/// <param name=\"defaultMatch\">Default match if the 'if' schema did not match.</param>");
                }

                if (thenMatchParamName is null)
                {
                    generator
                        .AppendLineIndent("/// <param name=\"defaultMatch\">Default match if the 'if' schema matched.</param>");
                }

                generator
                    .AppendLineIndent("/// <returns>An instance of the value returned by the match function.</returns>")
                    .AppendLineIndent("public TResult Match<", includeContext ? "TContext, " : string.Empty, "TResult>(")
                    .PushMemberScope(scopeName, ScopeType.Method)
                    .PushIndent();

                if (includeContext)
                {
                    generator
                        .AppendIndent("in TContext context");
                }

                if (thenDeclaration is SingleSubschemaKeywordTypeDeclaration thenSubschema2 &&
                    thenMatchParamName is string thenMatchParamName2)
                {
                    if (includeContext)
                    {
                        generator
                            .AppendLine(",");
                    }

                    generator
                        .AppendIndent(
                            "Matcher<",
                            thenSubschema2.ReducedType.FullyQualifiedDotnetTypeName(),
                            includeContext ? ", TContext" : string.Empty,
                            ", TResult> ",
                            thenMatchParamName2);
                }

                if (elseDeclaration is SingleSubschemaKeywordTypeDeclaration elseSubschema2 &&
                    elseMatchParamName is string elseMatchParamName2)
                {
                    if (thenDeclaration is not null || includeContext)
                    {
                        generator
                            .AppendLine(",");
                    }

                    generator
                        .AppendIndent(
                            "Matcher<",
                            elseSubschema2.ReducedType.FullyQualifiedDotnetTypeName(),
                            includeContext ? ", TContext" : string.Empty,
                            ", TResult> ",
                            elseMatchParamName2);
                }

                if (thenDeclaration is null || elseDeclaration is null)
                {
                    generator
                        .AppendLine(",")
                        .AppendIndent(
                            "Matcher<",
                            typeDeclaration.DotnetTypeName(),
                            includeContext ? ", TContext" : string.Empty,
                            ", TResult> defaultMatch");
                }

                generator
                    .AppendLine(")")
                    .PopIndent()
                    .AppendLineIndent("{")
                    .PushIndent();

                string matchTypeName = ifSubschema.ReducedType.FullyQualifiedDotnetTypeName();

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent(
                        matchTypeName,
                        " ifValue = this.As<",
                        matchTypeName,
                        ">();");

                if (thenDeclaration is not null)
                {
                    generator
                        .AppendLineIndent("if (ifValue.IsValid())");
                }
                else
                {
                    generator
                        .AppendLineIndent("if (!ifValue.IsValid())");
                }

                if (thenDeclaration is SingleSubschemaKeywordTypeDeclaration thenDeclaration3 &&
                    thenMatchParamName is string thenMatchParam3)
                {
                    generator
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("return ", thenMatchParam3, "(this.As<", thenDeclaration3.ReducedType.FullyQualifiedDotnetTypeName(), ">()", includeContext ? ", context" : string.Empty, ");")
                        .PopIndent()
                        .AppendLineIndent("}");
                }

                if (elseDeclaration is SingleSubschemaKeywordTypeDeclaration elseDeclaration3 &&
                    elseMatchParamName is string elseMatchParam3)
                {
                    if (thenDeclaration is not null)
                    {
                        generator
                            .AppendLineIndent("else");
                    }

                    generator
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("return ", elseMatchParam3, "(this.As<", elseDeclaration3.ReducedType.FullyQualifiedDotnetTypeName(), ">()", includeContext ? ", context" : string.Empty, ");")
                        .PopIndent()
                        .AppendLineIndent("}");
                }

                if (thenDeclaration is null || elseDeclaration is null)
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("return defaultMatch(this", includeContext ? ", context" : string.Empty, ");");
                }

                generator
                    .PopMemberScope()
                    .PopIndent()
                    .AppendLineIndent("}");
            }
        }
    }
}
