// <copyright file="WithMutationAnalyzer.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Collections.Immutable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Corvus.Text.Json.Migration.Analyzers;

/// <summary>
/// CVJ011: Detects V4 With*() mutation methods that should be replaced with Set*() via a JsonWorkspace builder in V5.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class WithMutationAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(DiagnosticDescriptors.WithMutationMigration);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(
            AnalyzeInvocation,
            SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
        var invocation = (InvocationExpressionSyntax)context.Node;

        if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
        {
            string methodName = memberAccess.Name.Identifier.Text;

            if (methodName.StartsWith("With") && methodName.Length > 4 && char.IsUpper(methodName[4]))
            {
                if (memberAccess.Expression is { } receiverExpression)
                {
                    ITypeSymbol? receiverType = context.SemanticModel.GetTypeInfo(receiverExpression, context.CancellationToken).Type;
                    if (!V4TypeHelper.ImplementsIJsonValue(receiverType, context.SemanticModel.Compilation))
                    {
                        return;
                    }
                }

                string propertyName = methodName.Substring(4);

                context.ReportDiagnostic(
                    Diagnostic.Create(
                        DiagnosticDescriptors.WithMutationMigration,
                        memberAccess.Name.GetLocation(),
                        methodName,
                        propertyName));
            }
        }
    }
}