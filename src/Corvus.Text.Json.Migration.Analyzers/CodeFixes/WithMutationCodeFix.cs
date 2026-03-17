// <copyright file="WithMutationCodeFix.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System;
using System.Collections.Generic;
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
/// Code fix for CVJ011: renames <c>With*()</c> to <c>Set*()</c> and unchains
/// fluent calls into separate statements, since V5 <c>Set*()</c> mutates in place.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(WithMutationCodeFix))]
[Shared]
public sealed class WithMutationCodeFix : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(DiagnosticDescriptors.WithMutationMigration.Id);

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

            if (node is not IdentifierNameSyntax identifierName ||
                !identifierName.Identifier.Text.StartsWith("With", StringComparison.Ordinal) ||
                identifierName.Identifier.Text.Length <= 4)
            {
                continue;
            }

            // Walk up to the outermost chained invocation to avoid
            // offering the fix multiple times for the same chain.
            InvocationExpressionSyntax? invocation = identifierName
                .FirstAncestorOrSelf<InvocationExpressionSyntax>();
            if (invocation is null)
            {
                continue;
            }

            InvocationExpressionSyntax outermost = GetOutermostChainedInvocation(invocation);

            // Only register once — on the outermost With*() in the chain.
            if (outermost != invocation)
            {
                continue;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Rename With*() to Set*() and unchain",
                    createChangedDocument: ct => UnchainAndRenameAsync(
                        context.Document, outermost, ct),
                    equivalenceKey: DiagnosticDescriptors.WithMutationMigration.Id),
                diagnostic);
        }
    }

    private static InvocationExpressionSyntax GetOutermostChainedInvocation(
        InvocationExpressionSyntax invocation)
    {
        // Walk up: if the parent is a MemberAccess whose parent is an Invocation
        // with a With*() name, that's a higher link in the chain.
        SyntaxNode current = invocation;

        while (current.Parent is MemberAccessExpressionSyntax parentAccess &&
               parentAccess.Parent is InvocationExpressionSyntax parentInvocation &&
               parentAccess.Name.Identifier.Text.StartsWith("With", StringComparison.Ordinal) &&
               parentAccess.Name.Identifier.Text.Length > 4)
        {
            current = parentInvocation;
        }

        return (InvocationExpressionSyntax)current;
    }

    private static async Task<Document> UnchainAndRenameAsync(
        Document document,
        InvocationExpressionSyntax outermostInvocation,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Collect the chain: walk inward collecting (methodName, arguments).
        var chain = new List<(string SetName, ArgumentListSyntax Args)>();
        ExpressionSyntax? rootReceiver = CollectChain(outermostInvocation, chain);

        if (rootReceiver is null || chain.Count == 0)
        {
            return document;
        }

        // Find the containing statement.
        StatementSyntax? containingStatement = outermostInvocation
            .FirstAncestorOrSelf<StatementSyntax>();
        if (containingStatement is null)
        {
            return document;
        }

        SyntaxTriviaList leadingTrivia = containingStatement.GetLeadingTrivia();
        string receiverText = rootReceiver.WithoutTrivia().ToFullString();

        // Build replacement statements: one per Set*() call.
        var newStatements = new List<StatementSyntax>();
        foreach ((string setName, ArgumentListSyntax args) in chain)
        {
            StatementSyntax setStatement = SyntaxFactory.ParseStatement(
                $"{receiverText}.{setName}{args.WithoutTrivia().ToFullString()};\r\n")
                .WithLeadingTrivia(leadingTrivia);

            newStatements.Add(setStatement);
        }

        SyntaxNode newRoot = root.ReplaceNode(
            containingStatement,
            newStatements);

        return document.WithSyntaxRoot(newRoot);
    }

    private static ExpressionSyntax? CollectChain(
        InvocationExpressionSyntax invocation,
        List<(string SetName, ArgumentListSyntax Args)> chain)
    {
        // Recurse inward through the chain collecting With*() calls.
        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
        {
            return null;
        }

        string methodName = memberAccess.Name.Identifier.Text;

        if (methodName.StartsWith("With", StringComparison.Ordinal) && methodName.Length > 4)
        {
            string setName = "Set" + methodName.Substring(4);
            ExpressionSyntax? receiver;

            // Is the receiver itself a With*() invocation? (chained)
            if (memberAccess.Expression is InvocationExpressionSyntax innerInvocation &&
                innerInvocation.Expression is MemberAccessExpressionSyntax innerAccess &&
                innerAccess.Name.Identifier.Text.StartsWith("With", StringComparison.Ordinal) &&
                innerAccess.Name.Identifier.Text.Length > 4)
            {
                receiver = CollectChain(innerInvocation, chain);
            }
            else
            {
                // Base case — this is the root receiver.
                receiver = memberAccess.Expression;
            }

            chain.Add((setName, invocation.ArgumentList));
            return receiver;
        }

        return null;
    }
}
