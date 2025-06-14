// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
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
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Gets the value as a <see cref=\"", t.FullyQualifiedDotnetTypeName(), "\" />.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"result\">The result of the conversions.</param>")
                    .AppendLineIndent("/// <returns><see langword=\"true\" /> if the conversion was valid.</returns>")
                    .AppendLineIndent("public bool ", methodName, "(out ", t.FullyQualifiedDotnetTypeName(), " result)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("result = ", t.FullyQualifiedDotnetTypeName(), ".From(this);")
                        .AppendLineIndent("return result.IsSchemaMatch();")
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
        /// <param name="rootDeclaration">The type declaration which is the basis of the conversions.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendConversionToCompositionTypes(
        this CodeGenerator generator,
        TypeDeclaration rootDeclaration)
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
                AppendConversions(generator, appliedConversions, rootDeclaration, subschema, allowsImplicitFrom, allowsImplicitTo);
                AppendCompositionConversions(generator, appliedConversions, typesToProcess, rootDeclaration, subschema, allowsImplicitFrom: allowsImplicitFrom, allowsImplicitTo: allowsImplicitTo);
            }

            return generator;

            static void AppendCompositionConversions(
                CodeGenerator generator,
                HashSet<TypeDeclaration> appliedConversions,
                Queue<(TypeDeclaration Target, bool AllowsImplicitFrom, bool AllowsImplicitTo)> typesToProcess,
                TypeDeclaration rootType,
                TypeDeclaration sourceType,
                bool allowsImplicitFrom,
                bool allowsImplicitTo)
            {
                if (generator.IsCancellationRequested)
                {
                    return;
                }

                if (sourceType.AllOfCompositionTypes() is IReadOnlyDictionary<IAllOfSubschemaValidationKeyword, IReadOnlyCollection<TypeDeclaration>> allOf)
                {
                    AppendSubschemaConversions(generator, appliedConversions, typesToProcess, rootType, allOf.SelectMany(k => k.Value).ToList(), isImplicitFrom: false, isImplicitTo: allowsImplicitTo);
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
                bool isImplicitTo)
            {
                foreach (TypeDeclaration candidate in subschemas)
                {
                    if (generator.IsCancellationRequested)
                    {
                        return;
                    }

                    TypeDeclaration subschema = candidate.ReducedTypeDeclaration().ReducedType;
                    if (!AppendConversions(generator, appliedConversions, rootDeclaration, subschema, isImplicitFrom, isImplicitTo))
                    {
                        continue;
                    }

                    // Recurse, which will add more allOfs, and queue up the anyOfs and oneOfs.
                    AppendCompositionConversions(generator, appliedConversions, typesToProcess, rootDeclaration, subschema, isImplicitFrom, isImplicitTo);
                }
            }

            static bool AppendConversions(
                CodeGenerator generator,
                HashSet<TypeDeclaration> appliedConversions,
                TypeDeclaration rootDeclaration,
                TypeDeclaration subschema,
                bool isImplicitFrom,
                bool isImplicitTo)
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

                string implictOrExplicitFrom = isImplicitFrom ? "implicit" : "explicit";
                string implictOrExplicitTo = isImplicitTo ? "implicit" : "explicit";

                string subschemaTypeName = subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Conversion to <see cref=\"", subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"value\">The value from which to convert.</param>")
                    .AppendIndent("public static ", implictOrExplicitTo, " operator ", subschemaTypeName, "(")
                    .Append(rootDeclaration.DotnetTypeName())
                    .AppendLine(" value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return ", subschemaTypeName, "From(value);")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Conversion from <see cref=\"", subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"value\">The value from which to convert.</param>")
                    .AppendIndent("public static ", implictOrExplicitFrom, " operator ", rootDeclaration.DotnetTypeName(), "(")
                    .Append(subschema.ReducedTypeDeclaration().ReducedType.FullyQualifiedDotnetTypeName())
                    .AppendLine(" value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return From(value);")
                    .PopIndent()
                    .AppendLineIndent("}");

                return true;
            }
        }
    }
}
