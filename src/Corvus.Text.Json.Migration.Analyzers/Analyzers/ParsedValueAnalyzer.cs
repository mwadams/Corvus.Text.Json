// <copyright file="ParsedValueAnalyzer.cs" company="Endjin Limited">
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
/// CVJ002: Detects uses of <c>ParsedValue&lt;T&gt;</c> type name and <c>.Instance</c> property
/// access on <c>ParsedValue&lt;T&gt;</c> instances that should be migrated to
/// <c>ParsedJsonDocument&lt;T&gt;</c> and <c>.RootElement</c> in V5.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ParsedValueAnalyzer : DiagnosticAnalyzer
{
    private const string ParsedValueTypeName = "ParsedValue";
    private const string FullTypeName = "Corvus.Json.ParsedValue";
    private const string InstancePropertyName = "Instance";

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(DiagnosticDescriptors.ParsedValueMigration);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeGenericName, SyntaxKind.GenericName);
        context.RegisterSyntaxNodeAction(AnalyzeMemberAccess, SyntaxKind.SimpleMemberAccessExpression);
    }

    private static void AnalyzeGenericName(SyntaxNodeAnalysisContext context)
    {
        var genericName = (GenericNameSyntax)context.Node;

        if (genericName.Identifier.Text != ParsedValueTypeName)
        {
            return;
        }

        // Verify via the semantic model that this is Corvus.Json.ParsedValue<T>.
        SymbolInfo symbolInfo = context.SemanticModel.GetSymbolInfo(genericName, context.CancellationToken);
        ISymbol? symbol = symbolInfo.Symbol
            ?? (symbolInfo.CandidateSymbols.Length > 0 ? symbolInfo.CandidateSymbols[0] : null);

        if (symbol is null)
        {
            return;
        }

        INamedTypeSymbol? namedType = symbol as INamedTypeSymbol
            ?? (symbol as IMethodSymbol)?.ContainingType;

        if (namedType is null)
        {
            return;
        }

        string fullName = namedType.OriginalDefinition.ToDisplayString();
        if (!fullName.StartsWith(FullTypeName, System.StringComparison.Ordinal))
        {
            return;
        }

        context.ReportDiagnostic(
            Diagnostic.Create(
                DiagnosticDescriptors.ParsedValueMigration,
                genericName.GetLocation()));
    }

    private static void AnalyzeMemberAccess(SyntaxNodeAnalysisContext context)
    {
        var memberAccess = (MemberAccessExpressionSyntax)context.Node;

        if (memberAccess.Name.Identifier.Text != InstancePropertyName)
        {
            return;
        }

        // Check that the expression type is ParsedValue<T>.
        TypeInfo typeInfo = context.SemanticModel.GetTypeInfo(memberAccess.Expression, context.CancellationToken);
        ITypeSymbol? type = typeInfo.Type;

        if (type is not INamedTypeSymbol namedType)
        {
            return;
        }

        string fullName = namedType.OriginalDefinition.ToDisplayString();
        if (!fullName.StartsWith(FullTypeName, System.StringComparison.Ordinal))
        {
            return;
        }

        context.ReportDiagnostic(
            Diagnostic.Create(
                DiagnosticDescriptors.ParsedValueMigration,
                memberAccess.Name.GetLocation()));
    }
}
