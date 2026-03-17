// <copyright file="FunctionalArrayCodeFix.cs" company="Endjin Limited">
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
/// Code fix for CVJ012: renames V4 functional array methods
/// (<c>Add</c>, <c>Insert</c>, <c>SetItem</c>, <c>RemoveAt</c>) to their V5
/// mutable builder equivalents and drops the assignment since V5 mutates in-place.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FunctionalArrayCodeFix))]
[Shared]
public sealed class FunctionalArrayCodeFix : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(DiagnosticDescriptors.FunctionalArrayMigration.Id);

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
            if (node is not IdentifierNameSyntax identifierName)
            {
                continue;
            }

            // The V5 name is in the second message argument.
            string v5Name = diagnostic.Properties.TryGetValue("v5Name", out string? name)
                ? name
                : GetV5Name(identifierName.Identifier.Text);

            InvocationExpressionSyntax? invocation = identifierName
                .FirstAncestorOrSelf<InvocationExpressionSyntax>();
            if (invocation is null)
            {
                continue;
            }

            // If the method name isn't changing and the call is already a
            // standalone expression statement, there's nothing to fix.
            bool nameChanges = v5Name != identifierName.Identifier.Text;
            bool isAlreadyExpressionStatement = invocation.Parent is ExpressionStatementSyntax;
            if (!nameChanges && isAlreadyExpressionStatement)
            {
                continue;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: $"Rename '{identifierName.Identifier.Text}' to '{v5Name}' and drop assignment",
                    createChangedDocument: ct => RenameAndDropAssignmentAsync(
                        context.Document, invocation, identifierName, v5Name, ct),
                    equivalenceKey: DiagnosticDescriptors.FunctionalArrayMigration.Id),
                diagnostic);
        }
    }

    private static string GetV5Name(string v4Name) => v4Name switch
    {
        "Add" => "AddItem",
        "Insert" => "InsertItem",
        _ => v4Name,
    };

    private static async Task<Document> RenameAndDropAssignmentAsync(
        Document document,
        InvocationExpressionSyntax invocation,
        IdentifierNameSyntax identifier,
        string newName,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Rename the method identifier.
        IdentifierNameSyntax newIdentifier = identifier.WithIdentifier(
            SyntaxFactory.Identifier(newName)
                .WithTriviaFrom(identifier.Identifier));

        // Build the renamed invocation as a standalone expression statement.
        InvocationExpressionSyntax renamedInvocation = invocation.ReplaceNode(identifier, newIdentifier);

        StatementSyntax? containingStatement = invocation.FirstAncestorOrSelf<StatementSyntax>();
        if (containingStatement is null)
        {
            return document.WithSyntaxRoot(root.ReplaceNode(identifier, newIdentifier));
        }

        // Get the receiver (e.g., "array" from "array.Add(item)").
        ExpressionSyntax? receiver = null;
        if (renamedInvocation.Expression is MemberAccessExpressionSyntax memberAccess)
        {
            receiver = memberAccess.Expression;
        }

        if (receiver is null)
        {
            return document.WithSyntaxRoot(root.ReplaceNode(identifier, newIdentifier));
        }

        // Build: receiver.newName(args);
        ExpressionStatementSyntax newStatement = SyntaxFactory.ExpressionStatement(renamedInvocation)
            .WithLeadingTrivia(containingStatement.GetLeadingTrivia())
            .WithTrailingTrivia(containingStatement.GetTrailingTrivia());

        return document.WithSyntaxRoot(root.ReplaceNode(containingStatement, newStatement));
    }
}
