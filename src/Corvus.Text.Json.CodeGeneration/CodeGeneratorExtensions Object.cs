// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Encodings.Web;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
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
    }
}
