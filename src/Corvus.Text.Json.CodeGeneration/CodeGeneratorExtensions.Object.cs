// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
        public static CodeGenerator AppendApplyObjectCompositionTypes(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            HashSet<TypeDeclaration> seenTypes = [];

            string applyMethodName = generator.GetUniqueMethodNameInScope("Apply");

            foreach (TypeDeclaration? type in typeDeclaration.AllOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (type is TypeDeclaration t && seenTypes.Add(t))
                {
                    AppendApply(generator, t, applyMethodName);
                }
            }

            foreach (TypeDeclaration? type in typeDeclaration.AnyOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (type is TypeDeclaration t && seenTypes.Add(t))
                {
                    AppendApply(generator, t, applyMethodName);
                }
            }


            foreach (TypeDeclaration? type in typeDeclaration.OneOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (type is TypeDeclaration t && seenTypes.Add(t))
                {
                    AppendApply(generator, t, applyMethodName);
                }
            }

            return generator;

            static CodeGenerator AppendApply(CodeGenerator generator, TypeDeclaration typeDeclaration, string applyMethodName)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0 || typeDeclaration.DoNotGenerate())
                {
                    return generator;
                }


                string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();
                return generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Apply a composed value.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <remarks>")
                    .AppendLineIndent("/// This will add or update any property values provided by the <paramref name=\"value\"/>.")
                    .AppendLineIndent("/// </remarks>")
                    .AppendLineIndent("public void ", applyMethodName, "(in ", fqdtn, " value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("CheckValidInstance();")
                        .AppendLineIndent("")
                        .AppendLineIndent("foreach (var property in value.EnumerateObject())")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("JsonElementHelpers.SetPropertyUnsafe(this, property);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendLineIndent("")
                        .AppendLineIndent("_documentVersion = _parent.Version;")
                    .PopIndent()
                    .AppendLineIndent("}");
            }
        }


        /// <summary>
        /// Append EnumerateObject() method.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <param name="forMutable">Indicates that the value is intended for a mutable instance.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendEnumerateObject(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
            {
                return generator;
            }

            string fqdtn;

            if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType objectPropertyType)
            {
                if (objectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = objectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localObjectPropertyType)
            {
                if (localObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = localObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedObjectPropertyType)
            {
                if (localAndAppliedObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = localAndAppliedObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else
            {
                fqdtn = WellKnownTypeDeclarations.JsonAny.DotnetTypeName();
            }

            if (forMutable)
            {
                fqdtn = fqdtn + ".Mutable";
            }

            return generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Enumerates the object.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an object.</exception>")
                .AppendLineIndent("public ObjectEnumerator<", fqdtn, "> EnumerateObject()")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendLineIndent("return EnumeratorCreator.CreateObjectEnumerator<", fqdtn, ">(_parent, _idx);")
                .PopIndent()
                .AppendLineIndent("}");
        }

        public static CodeGenerator AppendJsonPropertyNames(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (!typeDeclaration.HasPropertyDeclarations)
            {
                return generator;
            }

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Provides UTF8 and string versions of the JSON property names on the object.")
                .AppendLineIndent("/// </summary>")
                .BeginPublicStaticClassDeclaration(generator.JsonPropertyNamesClassName());

            int i = 0;
            foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (i > 0)
                {
                    generator
                        .AppendLine();
                }

                generator
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Gets the JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent(
                        "public const string ",
                        property.DotnetPropertyName(),
                        " = ",
                        SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                        ";");
                i++;
            }

            foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (i > 0)
                {
                    generator
                        .AppendLine();
                }

                generator
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Gets the JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent(
                        "public static ReadOnlySpan<byte> ",
                        property.DotnetPropertyName(),
                        "Utf8 => ",
                        SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                        "u8;");
                i++;
            }

            return generator
                .EndClassStructOrEnumDeclaration();
        }

        public static CodeGenerator AppendJsonPropertyNamesEscaped(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (!typeDeclaration.HasPropertyDeclarations)
            {
                return generator;
            }

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Provides encoded UTF8 versions of the JSON property names on the object.")
                .AppendLineIndent("/// </summary>")
                .BeginPrivateStaticClassDeclaration(generator.JsonPropertyNamesEscapedClassName());

            int i = 0;

            foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (i > 0)
                {
                    generator
                        .AppendLine();
                }

                string encodedName = JavaScriptEncoder.Default.Encode(property.JsonPropertyName);

                generator
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Gets the encoded JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent(
                        "public static ReadOnlySpan<byte> ",
                        property.DotnetPropertyName(),
                        " => ",
                        SymbolDisplay.FormatLiteral(encodedName, true),
                        "u8;");
                i++;
            }

            return generator
                .EndClassStructOrEnumDeclaration();

        }

        /// <summary>
        /// Append object indexer properties.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <param name="forMutable">Whether to emit the indexers for the mutable element.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendObjectIndexerProperties(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
            {
                return generator;
            }

            string fqdtn;

            if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType objectPropertyType)
            {
                if (objectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = objectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localObjectPropertyType)
            {
                if (localObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = localObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedObjectPropertyType)
            {
                if (localAndAppliedObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = localAndAppliedObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else
            {
                fqdtn = WellKnownTypeDeclarations.JsonAny.DotnetTypeName();
            }

            AppendPropertyIndexer(generator, fqdtn, "ReadOnlySpan<byte>", forMutable);
            AppendPropertyIndexer(generator, fqdtn, "ReadOnlySpan<char>", forMutable);
            AppendPropertyIndexer(generator, fqdtn, "string", forMutable);

            return generator;

            static void AppendPropertyIndexer(CodeGenerator generator, string fqdtn, string propertyNameType, bool forMutable) => generator
                                .AppendSeparatorLine()
                                .AppendBlockIndent(
                                """
                                /// <summary>
                                /// Gets the value of the property with the given name.
                                /// </summary>
                                /// <param name="propertyName">The name of the property.</param>
                                /// <returns>The value of the property with the given name.</returns>
                                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                                """)
                                .AppendLineIndent("public ", fqdtn, forMutable ? ".Mutable" : "", " this[", propertyNameType, " propertyName]")
                                .AppendLineIndent("{")
                                .PushIndent()
                                    .AppendLineIndent("get")
                                    .AppendLineIndent("{")
                                    .PushIndent()
                                        .AppendLineIndent("CheckValidInstance();")
                                        .AppendLineIndent("if (!_parent.TryGetNamedPropertyValue(_idx, propertyName, out ", fqdtn, forMutable ? ".Mutable" : "", " value))")
                                        .AppendLineIndent("{")
                                        .PushIndent()
                                            .AppendLineIndent("return default;")
                                        .PopIndent()
                                        .AppendLineIndent("}")
                                        .AppendSeparatorLine()
                                        .AppendLineIndent("return value;")
                                    .PopIndent()
                                    .AppendLineIndent("}")
                                .PopIndent()
                                .AppendLineIndent("}");
        }

        /// <summary>
        /// Append GetPropertyCount() method.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendGetPropertyCount(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
            {
                return generator;
            }

            return generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Gets the number of properties in the object.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an object.</exception>")
                .AppendLineIndent("public int GetPropertyCount()")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendLineIndent("return _parent.GetPropertyCount(_idx);")
                .PopIndent()
                .AppendLineIndent("}");
        }
    }
}
