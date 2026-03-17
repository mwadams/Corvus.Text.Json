// <copyright file="JsonValueConverterAnalyzer.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

namespace Corvus.Text.Json.Migration.Analyzers;

using System.Collections.Immutable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

/// <summary>
/// CVJ017: Detects [JsonConverter(typeof(JsonValueConverter&lt;T&gt;))] attributes
/// that are not needed in V5.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class JsonValueConverterAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(DiagnosticDescriptors.JsonValueConverterMigration);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(
            AnalyzeAttribute,
            SyntaxKind.Attribute);
    }

    private static void AnalyzeAttribute(SyntaxNodeAnalysisContext context)
    {
        var attribute = (AttributeSyntax)context.Node;

        string attributeName = GetUnqualifiedName(attribute.Name);

        if (attributeName is not "JsonConverter" and not "JsonConverterAttribute")
        {
            return;
        }

        if (attribute.ArgumentList is null || attribute.ArgumentList.Arguments.Count == 0)
        {
            return;
        }

        // Look for typeof(JsonValueConverter<T>)
        AttributeArgumentSyntax firstArg = attribute.ArgumentList.Arguments[0];

        if (firstArg.Expression is TypeOfExpressionSyntax typeOfExpr &&
            typeOfExpr.Type is GenericNameSyntax genericName &&
            genericName.Identifier.Text == "JsonValueConverter" &&
            genericName.TypeArgumentList.Arguments.Count == 1)
        {
            string typeArg = genericName.TypeArgumentList.Arguments[0].ToString();

            context.ReportDiagnostic(
                Diagnostic.Create(
                    DiagnosticDescriptors.JsonValueConverterMigration,
                    attribute.GetLocation(),
                    typeArg));
        }
    }

    private static string GetUnqualifiedName(NameSyntax name)
    {
        return name switch
        {
            SimpleNameSyntax simple => simple.Identifier.Text,
            QualifiedNameSyntax qualified => qualified.Right.Identifier.Text,
            AliasQualifiedNameSyntax alias => alias.Name.Identifier.Text,
            _ => name.ToString(),
        };
    }
}
