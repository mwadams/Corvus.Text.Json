// <copyright file="ValidateAnalyzer.cs" company="Endjin Limited">
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
/// CVJ003: Detects V4 <c>.IsValid()</c> and <c>.Validate(ValidationContext.ValidContext, ...)</c>
/// calls that should be replaced with <c>.EvaluateSchema()</c> in V5.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ValidateAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(DiagnosticDescriptors.ValidateMigration);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
        var invocation = (InvocationExpressionSyntax)context.Node;

        if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
        {
            string methodName = memberAccess.Name.Identifier.ValueText;

            if (methodName == "IsValid")
            {
                // .IsValid() with no arguments
                if (invocation.ArgumentList.Arguments.Count == 0)
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        DiagnosticDescriptors.ValidateMigration,
                        invocation.GetLocation(),
                        "IsValid()",
                        string.Empty));
                }
            }
            else if (methodName == "Validate")
            {
                string additionalContext = invocation.ArgumentList.Arguments.Count > 1
                    ? " and use a JsonSchemaResultsCollector for detailed results"
                    : string.Empty;

                context.ReportDiagnostic(Diagnostic.Create(
                    DiagnosticDescriptors.ValidateMigration,
                    invocation.GetLocation(),
                    "Validate(...)",
                    additionalContext));
            }
        }
    }
}