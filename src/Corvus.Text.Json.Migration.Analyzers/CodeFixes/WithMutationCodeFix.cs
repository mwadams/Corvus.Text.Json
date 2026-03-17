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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Corvus.Text.Json.Migration.Analyzers;

/// <summary>
/// Code fix for CVJ011: renames <c>With*()</c> to <c>Set*()</c>, unchains
/// fluent calls into separate statements, and collapses nested
/// extract-mutate-reassign patterns into deep setters.
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
                !IsWithMethod(identifierName.Identifier.Text))
            {
                continue;
            }

            InvocationExpressionSyntax? invocation = identifierName
                .FirstAncestorOrSelf<InvocationExpressionSyntax>();
            if (invocation is null)
            {
                continue;
            }

            // Only register on the outermost With*() in a fluent chain.
            InvocationExpressionSyntax outermost = GetOutermostChainedInvocation(invocation);
            if (outermost != invocation)
            {
                continue;
            }

            if (IsInsideArgument(outermost))
            {
                // This With*() is nested inside an argument expression.
                // Only rename the identifier — don't restructure the containing statement.
                string setName = ToSetName(identifierName.Identifier.Text);

                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: $"Rename '{identifierName.Identifier.Text}' to '{setName}'",
                        createChangedDocument: ct => RenameOnlyAsync(
                            context.Document, identifierName, setName, ct),
                        equivalenceKey: DiagnosticDescriptors.WithMutationMigration.Id),
                    diagnostic);
            }
            else if (IsResultFeedingAnotherWith(outermost))
            {
                // This With*() result is used as an argument to another With*().
                // Skip — the outer With*() code fix will collapse the whole pattern.
                continue;
            }
            else
            {
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: "Rename With*() to Set*() and unchain",
                        createChangedDocument: ct => UnchainAndRenameAsync(
                            context.Document, outermost, ct),
                        equivalenceKey: DiagnosticDescriptors.WithMutationMigration.Id),
                    diagnostic);
            }
        }
    }

    private static bool IsWithMethod(string name)
        => name.StartsWith("With", StringComparison.Ordinal) && name.Length > 4;

    private static string ToSetName(string withName)
        => "Set" + withName.Substring(4);

    /// <summary>
    /// Checks whether this invocation is inside an <see cref="ArgumentSyntax"/>.
    /// If so, a full statement replacement would be wrong — only rename.
    /// </summary>
    private static bool IsInsideArgument(InvocationExpressionSyntax invocation)
    {
        SyntaxNode? current = invocation.Parent;

        while (current is not null && current is not StatementSyntax)
        {
            if (current is ArgumentSyntax)
            {
                return true;
            }

            current = current.Parent;
        }

        return false;
    }

    /// <summary>
    /// Checks whether this invocation's result variable is used as an argument
    /// to another <c>With*()</c> call in the same block. If so, the outer
    /// <c>With*()</c> fix should handle the collapse instead.
    /// </summary>
    private static bool IsResultFeedingAnotherWith(InvocationExpressionSyntax invocation)
    {
        StatementSyntax? stmt = invocation.FirstAncestorOrSelf<StatementSyntax>();

        if (stmt is not LocalDeclarationStatementSyntax localDecl ||
            stmt.Parent is not BlockSyntax block)
        {
            return false;
        }

        foreach (VariableDeclaratorSyntax declarator in localDecl.Declaration.Variables)
        {
            if (!ReferenceEquals(declarator.Initializer?.Value, invocation))
            {
                continue;
            }

            string varName = declarator.Identifier.Text;

            foreach (SyntaxNode node in block.DescendantNodes())
            {
                if (node is InvocationExpressionSyntax otherInv &&
                    !ReferenceEquals(otherInv, invocation) &&
                    otherInv.Expression is MemberAccessExpressionSyntax ma &&
                    IsWithMethod(ma.Name.Identifier.Text))
                {
                    foreach (ArgumentSyntax arg in otherInv.ArgumentList.Arguments)
                    {
                        if (arg.Expression is IdentifierNameSyntax id &&
                            id.Identifier.Text == varName)
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private static InvocationExpressionSyntax GetOutermostChainedInvocation(
        InvocationExpressionSyntax invocation)
    {
        SyntaxNode current = invocation;

        while (current.Parent is MemberAccessExpressionSyntax parentAccess &&
               parentAccess.Parent is InvocationExpressionSyntax parentInvocation &&
               IsWithMethod(parentAccess.Name.Identifier.Text))
        {
            current = parentInvocation;
        }

        return (InvocationExpressionSyntax)current;
    }

    private static async Task<Document> RenameOnlyAsync(
        Document document,
        IdentifierNameSyntax identifier,
        string newName,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        IdentifierNameSyntax newIdentifier = identifier.WithIdentifier(
            SyntaxFactory.Identifier(newName)
                .WithTriviaFrom(identifier.Identifier));

        return document.WithSyntaxRoot(root.ReplaceNode(identifier, newIdentifier));
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

        var chain = new List<(string SetName, ArgumentListSyntax Args)>();
        ExpressionSyntax? rootReceiver = CollectChain(outermostInvocation, chain);

        if (rootReceiver is null || chain.Count == 0)
        {
            return document;
        }

        StatementSyntax? containingStatement = outermostInvocation
            .FirstAncestorOrSelf<StatementSyntax>();
        if (containingStatement is null)
        {
            return document;
        }

        BlockSyntax? block = containingStatement.Parent as BlockSyntax;
        SyntaxTriviaList leadingTrivia = containingStatement.GetLeadingTrivia();
        string receiverText = rootReceiver.WithoutTrivia().ToFullString();

        // Track all statements to remove and the replacement statements to insert.
        var statementsToRemove = new HashSet<StatementSyntax> { containingStatement };
        var newStatements = new List<StatementSyntax>();

        foreach ((string setName, ArgumentListSyntax args) in chain)
        {
            // Check if the single argument is a local variable from a nested
            // extract-mutate-reassign pattern.
            if (block is not null &&
                args.Arguments.Count == 1 &&
                args.Arguments[0].Expression is IdentifierNameSyntax argId &&
                TryResolveNestedMutation(
                    block.Statements,
                    argId.Identifier.Text,
                    receiverText,
                    out string? propertyPath,
                    out List<StatementSyntax>? extraRemovals,
                    out List<(string InnerSetName, string InnerArgsText)>? innerMutations))
            {
                foreach (StatementSyntax s in extraRemovals)
                {
                    statementsToRemove.Add(s);
                }

                foreach ((string innerSetName, string innerArgsText) in innerMutations)
                {
                    newStatements.Add(
                        SyntaxFactory.ParseStatement(
                            $"{receiverText}.{propertyPath}.{innerSetName}{innerArgsText};\r\n")
                            .WithLeadingTrivia(leadingTrivia));
                }
            }
            else
            {
                // Simple case — just rename With*() to Set*().
                newStatements.Add(
                    SyntaxFactory.ParseStatement(
                        $"{receiverText}.{setName}{args.WithoutTrivia().ToFullString()};\r\n")
                        .WithLeadingTrivia(leadingTrivia));
            }
        }

        if (block is not null && statementsToRemove.Count > 1)
        {
            // Multiple statements to remove — rebuild the block.
            // Insert the new statements at the position of the first removed statement.
            var newBlockStatements = new List<StatementSyntax>();
            bool inserted = false;

            foreach (StatementSyntax stmt in block.Statements)
            {
                if (statementsToRemove.Contains(stmt))
                {
                    if (!inserted)
                    {
                        newBlockStatements.AddRange(newStatements);
                        inserted = true;
                    }

                    continue;
                }

                newBlockStatements.Add(stmt);
            }

            if (!inserted)
            {
                newBlockStatements.AddRange(newStatements);
            }

            BlockSyntax newBlock = block.WithStatements(SyntaxFactory.List(newBlockStatements));
            return document.WithSyntaxRoot(root.ReplaceNode(block, newBlock));
        }

        return document.WithSyntaxRoot(
            root.ReplaceNode(containingStatement, newStatements));
    }

    /// <summary>
    /// Resolves a nested extract-mutate-reassign pattern.
    /// Given a variable name that holds the result of an inner <c>With*()</c> chain,
    /// traces back to find the property extraction from the outer receiver and
    /// returns the collapsed property path and inner mutations.
    /// </summary>
    private static bool TryResolveNestedMutation(
        SyntaxList<StatementSyntax> statements,
        string variableName,
        string expectedReceiverText,
        out string? propertyPath,
        out List<StatementSyntax>? statementsToRemove,
        out List<(string SetName, string ArgsText)>? mutations)
    {
        propertyPath = null;
        statementsToRemove = null;
        mutations = null;

        // Find: T variableName = expr.WithSomething(...)[.WithOther(...)];
        LocalDeclarationStatementSyntax? mutateStmt = FindLocalAssignment(
            statements, variableName, out InvocationExpressionSyntax? mutateInvocation);

        if (mutateStmt is null || mutateInvocation is null)
        {
            return false;
        }

        // Collect the inner With*() chain.
        var innerChain = new List<(string SetName, ArgumentListSyntax Args)>();
        ExpressionSyntax? innerReceiver = CollectChain(mutateInvocation, innerChain);

        if (innerReceiver is null || innerChain.Count == 0)
        {
            return false;
        }

        // The inner receiver should be a local variable extracted from
        // expectedReceiver.Property.
        if (innerReceiver is not IdentifierNameSyntax innerReceiverId)
        {
            return false;
        }

        LocalDeclarationStatementSyntax? extractStmt = FindPropertyExtraction(
            statements,
            innerReceiverId.Identifier.Text,
            expectedReceiverText,
            out string? extractedProperty);

        if (extractStmt is null || extractedProperty is null)
        {
            return false;
        }

        propertyPath = extractedProperty;
        statementsToRemove = new List<StatementSyntax> { mutateStmt, extractStmt };
        mutations = innerChain
            .Select(c => (c.SetName, c.Args.WithoutTrivia().ToFullString()))
            .ToList();

        return true;
    }

    /// <summary>
    /// Finds a local declaration statement like <c>T name = invocationExpr;</c>
    /// where the initializer is an invocation expression.
    /// </summary>
    private static LocalDeclarationStatementSyntax? FindLocalAssignment(
        SyntaxList<StatementSyntax> statements,
        string variableName,
        out InvocationExpressionSyntax? invocation)
    {
        invocation = null;

        foreach (StatementSyntax stmt in statements)
        {
            if (stmt is not LocalDeclarationStatementSyntax localDecl)
            {
                continue;
            }

            foreach (VariableDeclaratorSyntax declarator in localDecl.Declaration.Variables)
            {
                if (declarator.Identifier.Text == variableName &&
                    declarator.Initializer?.Value is InvocationExpressionSyntax inv)
                {
                    invocation = inv;
                    return localDecl;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Finds a local declaration like <c>T name = receiver.Property;</c> where
    /// the receiver text matches the expected receiver.
    /// </summary>
    private static LocalDeclarationStatementSyntax? FindPropertyExtraction(
        SyntaxList<StatementSyntax> statements,
        string variableName,
        string expectedReceiverText,
        out string? propertyName)
    {
        propertyName = null;

        foreach (StatementSyntax stmt in statements)
        {
            if (stmt is not LocalDeclarationStatementSyntax localDecl)
            {
                continue;
            }

            foreach (VariableDeclaratorSyntax declarator in localDecl.Declaration.Variables)
            {
                if (declarator.Identifier.Text == variableName &&
                    declarator.Initializer?.Value is MemberAccessExpressionSyntax memberAccess)
                {
                    string actualReceiver = memberAccess.Expression.WithoutTrivia().ToFullString();

                    if (actualReceiver == expectedReceiverText)
                    {
                        propertyName = memberAccess.Name.Identifier.Text;
                        return localDecl;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Walks inward through a fluent <c>With*()</c> chain collecting each call
    /// and returning the root receiver expression.
    /// </summary>
    private static ExpressionSyntax? CollectChain(
        InvocationExpressionSyntax invocation,
        List<(string SetName, ArgumentListSyntax Args)> chain)
    {
        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
        {
            return null;
        }

        string methodName = memberAccess.Name.Identifier.Text;

        if (!IsWithMethod(methodName))
        {
            return null;
        }

        string setName = ToSetName(methodName);
        ExpressionSyntax? receiver;

        if (memberAccess.Expression is InvocationExpressionSyntax innerInvocation &&
            innerInvocation.Expression is MemberAccessExpressionSyntax innerAccess &&
            IsWithMethod(innerAccess.Name.Identifier.Text))
        {
            receiver = CollectChain(innerInvocation, chain);
        }
        else
        {
            receiver = memberAccess.Expression;
        }

        chain.Add((setName, invocation.ArgumentList));
        return receiver;
    }
}
