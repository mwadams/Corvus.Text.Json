// <copyright file="ValidateCodeFix.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Collections.Immutable;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Corvus.Text.Json.Migration.Analyzers;

/// <summary>
/// Code fix for CVJ003: replaces <c>.IsValid()</c> and <c>.Validate(...)</c>
/// with <c>.EvaluateSchema()</c>, inserting a <c>JsonSchemaResultsCollector</c>
/// when the original call used a non-Flag validation level.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp)]
[Shared]
public sealed class ValidateCodeFix : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(DiagnosticDescriptors.ValidateMigration.Id);

    /// <inheritdoc/>
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc/>
    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        SyntaxNode? root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return;
        }

        foreach (Diagnostic diagnostic in context.Diagnostics)
        {
            SyntaxNode? node = root.FindNode(diagnostic.Location.SourceSpan);
            if (node is not InvocationExpressionSyntax invocation)
            {
                invocation = node.FirstAncestorOrSelf<InvocationExpressionSyntax>();
            }

            if (invocation?.Expression is not MemberAccessExpressionSyntax memberAccess)
            {
                continue;
            }

            // Check if the diagnostic carries a ResultsLevel property
            // (Basic/Detailed/Verbose). If so, we need to create a collector.
            diagnostic.Properties.TryGetValue("ResultsLevel", out string? resultsLevel);

            if (resultsLevel is not null)
            {
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: $"Replace with JsonSchemaResultsCollector + EvaluateSchema()",
                        createChangedDocument: ct => ReplaceWithCollectorAndEvaluateSchemaAsync(
                            context.Document, invocation, memberAccess, resultsLevel, ct),
                        equivalenceKey: "CVJ003_EvaluateSchemaWithCollector"),
                    diagnostic);
            }
            else
            {
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: "Replace with EvaluateSchema()",
                        createChangedDocument: ct => ReplaceWithEvaluateSchemaAsync(
                            context.Document, invocation, memberAccess, ct),
                        equivalenceKey: "CVJ003_EvaluateSchema"),
                    diagnostic);
            }
        }
    }

    private static async Task<Document> ReplaceWithEvaluateSchemaAsync(
        Document document,
        InvocationExpressionSyntax invocation,
        MemberAccessExpressionSyntax memberAccess,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Replace method name with EvaluateSchema and clear the argument list.
        MemberAccessExpressionSyntax newMemberAccess = memberAccess
            .WithName(SyntaxFactory.IdentifierName("EvaluateSchema"));

        InvocationExpressionSyntax newInvocation = invocation
            .WithExpression(newMemberAccess)
            .WithArgumentList(SyntaxFactory.ArgumentList())
            .WithTriviaFrom(invocation);

        SyntaxNode newRoot = root.ReplaceNode(invocation, newInvocation);
        return document.WithSyntaxRoot(newRoot);
    }

    private static async Task<Document> ReplaceWithCollectorAndEvaluateSchemaAsync(
        Document document,
        InvocationExpressionSyntax invocation,
        MemberAccessExpressionSyntax memberAccess,
        string resultsLevel,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Find the containing statement (the one with the Validate call).
        StatementSyntax? containingStatement = invocation.FirstAncestorOrSelf<StatementSyntax>();
        if (containingStatement is null)
        {
            // Fallback to simple replacement if we can't find the statement.
            return await ReplaceWithEvaluateSchemaAsync(document, invocation, memberAccess, cancellationToken)
                .ConfigureAwait(false);
        }

        // Build: using var collector = JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.{Level});
        StatementSyntax collectorStatement = SyntaxFactory.ParseStatement(
            $"using var collector = JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.{resultsLevel});\r\n")
            .WithLeadingTrivia(containingStatement.GetLeadingTrivia());

        // Replace the Validate call with .EvaluateSchema(collector)
        MemberAccessExpressionSyntax newMemberAccess = memberAccess
            .WithName(SyntaxFactory.IdentifierName("EvaluateSchema"));

        InvocationExpressionSyntax newInvocation = invocation
            .WithExpression(newMemberAccess)
            .WithArgumentList(SyntaxFactory.ArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.Argument(SyntaxFactory.IdentifierName("collector")))));

        // Replace the invocation within the containing statement.
        StatementSyntax newStatement = containingStatement.ReplaceNode(invocation, newInvocation);

        // Insert the collector statement before the modified statement.
        SyntaxNode newRoot = root.ReplaceNode(
            containingStatement,
            new SyntaxNode[] { collectorStatement, newStatement });

        return document.WithSyntaxRoot(newRoot);
    }
}