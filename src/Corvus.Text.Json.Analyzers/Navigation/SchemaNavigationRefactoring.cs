// <copyright file="SchemaNavigationRefactoring.cs" company="Endjin Limited">
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
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Corvus.Text.Json.Analyzers;

/// <summary>
/// CTJ-NAV: Provides a "Go to Schema Definition" refactoring for types generated
/// from JSON Schema via <c>JsonSchemaTypeGeneratorAttribute</c>.
/// </summary>
[ExportCodeRefactoringProvider(LanguageNames.CSharp, Name = nameof(SchemaNavigationRefactoring))]
[Shared]
public sealed class SchemaNavigationRefactoring : CodeRefactoringProvider
{
    private const string GeneratorAttributeName = "JsonSchemaTypeGeneratorAttribute";
    private const string GeneratorAttributeShortName = "JsonSchemaTypeGenerator";

    /// <inheritdoc/>
    public override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
    {
        SyntaxNode? root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return;
        }

        // Find the node under the cursor.
        SyntaxNode? node = root.FindNode(context.Span);
        if (node is null)
        {
            return;
        }

        // We're looking for type name identifiers.
        IdentifierNameSyntax? identifier = node as IdentifierNameSyntax
            ?? node.Parent as IdentifierNameSyntax;

        if (identifier is null)
        {
            // Also handle qualified names like V5Example.Model.Person
            if (node is QualifiedNameSyntax qualifiedName)
            {
                identifier = qualifiedName.Right as IdentifierNameSyntax;
            }
        }

        if (identifier is null)
        {
            return;
        }

        SemanticModel? semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
        if (semanticModel is null)
        {
            return;
        }

        // Resolve the symbol.
        SymbolInfo symbolInfo = semanticModel.GetSymbolInfo(identifier, context.CancellationToken);
        ISymbol? symbol = symbolInfo.Symbol ?? symbolInfo.CandidateSymbols.FirstOrDefault();

        // If the symbol is a local/parameter/field of a generated type, get the type.
        ITypeSymbol? typeSymbol = symbol switch
        {
            ITypeSymbol t => t,
            ILocalSymbol l => l.Type,
            IParameterSymbol p => p.Type,
            IFieldSymbol f => f.Type,
            IPropertySymbol prop => prop.Type,
            IMethodSymbol m => m.ReturnType,
            _ => null,
        };

        if (typeSymbol is not INamedTypeSymbol namedType)
        {
            return;
        }

        // Find the JsonSchemaTypeGeneratorAttribute on the type.
        SchemaInfo? schemaInfo = FindSchemaInfo(namedType, context.Document.Project, context.CancellationToken);
        if (schemaInfo is null)
        {
            return;
        }

        string title = $"Go to schema: {Path.GetFileName(schemaInfo.Value.FilePath)}";

        context.RegisterRefactoring(
            new NavigateToSchemaAction(
                title,
                schemaInfo.Value.FilePath,
                schemaInfo.Value.DocumentId));
    }

    private static SchemaInfo? FindSchemaInfo(
        INamedTypeSymbol typeSymbol,
        Project project,
        CancellationToken cancellationToken)
    {
        // Walk up through containing types to find the one with the attribute.
        INamedTypeSymbol? current = typeSymbol;
        while (current is not null)
        {
            string? schemaPath = GetSchemaPathFromAttribute(current);
            if (schemaPath is not null)
            {
                string? resolvedPath = ResolveSchemaPath(current, schemaPath, project);
                if (resolvedPath is not null)
                {
                    // Find matching additional document.
                    DocumentId? docId = FindAdditionalDocument(project, resolvedPath);
                    return new SchemaInfo(resolvedPath, docId);
                }
            }

            current = current.ContainingType;
        }

        return null;
    }

    private static string? GetSchemaPathFromAttribute(INamedTypeSymbol typeSymbol)
    {
        foreach (AttributeData attribute in typeSymbol.GetAttributes())
        {
            string? attrName = attribute.AttributeClass?.Name;
            if (attrName == GeneratorAttributeName || attrName == GeneratorAttributeShortName)
            {
                if (attribute.ConstructorArguments.Length > 0 &&
                    attribute.ConstructorArguments[0].Value is string path)
                {
                    return path;
                }
            }
        }

        return null;
    }

    private static string? ResolveSchemaPath(
        INamedTypeSymbol typeSymbol,
        string schemaRelativePath,
        Project project)
    {
        string normalizedRelative = schemaRelativePath.Replace('\\', '/');

        // Resolve relative to the source file containing the attribute declaration.
        foreach (SyntaxReference syntaxRef in typeSymbol.DeclaringSyntaxReferences)
        {
            string? sourceFilePath = syntaxRef.SyntaxTree.FilePath;
            if (string.IsNullOrEmpty(sourceFilePath))
            {
                continue;
            }

            string? sourceDir = Path.GetDirectoryName(sourceFilePath);
            if (sourceDir is null)
            {
                continue;
            }

            string resolved = Path.GetFullPath(Path.Combine(sourceDir, schemaRelativePath));

            // Verify the resolved path matches an AdditionalDocument.
            foreach (TextDocument doc in project.AdditionalDocuments)
            {
                if (doc.FilePath is not null &&
                    Path.GetFullPath(doc.FilePath).Equals(resolved, StringComparison.OrdinalIgnoreCase))
                {
                    return resolved;
                }
            }
        }

        // Fallback: search additional documents whose path ends with the schema path.
        foreach (TextDocument doc in project.AdditionalDocuments)
        {
            if (doc.FilePath is null)
            {
                continue;
            }

            string docPathNormalized = doc.FilePath.Replace('\\', '/');
            if (docPathNormalized.EndsWith(normalizedRelative, StringComparison.OrdinalIgnoreCase) ||
                Path.GetFileName(doc.FilePath).Equals(
                    Path.GetFileName(schemaRelativePath), StringComparison.OrdinalIgnoreCase))
            {
                return doc.FilePath;
            }
        }

        return null;
    }

    private static DocumentId? FindAdditionalDocument(Project project, string filePath)
    {
        string normalizedPath = Path.GetFullPath(filePath);

        foreach (TextDocument doc in project.AdditionalDocuments)
        {
            if (doc.FilePath is not null &&
                Path.GetFullPath(doc.FilePath).Equals(normalizedPath, StringComparison.OrdinalIgnoreCase))
            {
                return doc.Id;
            }
        }

        return null;
    }

    private readonly struct SchemaInfo
    {
        public SchemaInfo(string filePath, DocumentId? documentId)
        {
            this.FilePath = filePath;
            this.DocumentId = documentId;
        }

        public string FilePath { get; }

        public DocumentId? DocumentId { get; }
    }

    /// <summary>
    /// A code action that navigates to the JSON Schema file. In Visual Studio,
    /// this opens the file in the editor. In other environments, the action title
    /// shows the schema path for reference.
    /// </summary>
    private sealed class NavigateToSchemaAction : CodeAction
    {
        private readonly string _title;
        private readonly string _filePath;
        private readonly DocumentId? _documentId;

        public NavigateToSchemaAction(string title, string filePath, DocumentId? documentId)
        {
            this._title = title;
            this._filePath = filePath;
            this._documentId = documentId;
        }

        /// <inheritdoc/>
        public override string Title => this._title;

        /// <inheritdoc/>
        public override string? EquivalenceKey => "CTJ-NAV";

        /// <inheritdoc/>
        protected override Task<IEnumerable<CodeActionOperation>> ComputeOperationsAsync(
            CancellationToken cancellationToken)
        {
            var operations = new List<CodeActionOperation>
            {
                new OpenSchemaFileOperation(this._filePath, this._documentId),
            };

            return Task.FromResult<IEnumerable<CodeActionOperation>>(operations);
        }
    }

    /// <summary>
    /// A <see cref="CodeActionOperation"/> that attempts to open a schema file
    /// in the host workspace. In Visual Studio this opens the document in the editor.
    /// </summary>
    private sealed class OpenSchemaFileOperation : CodeActionOperation
    {
        private readonly string _filePath;
        private readonly DocumentId? _documentId;

        public OpenSchemaFileOperation(string filePath, DocumentId? documentId)
        {
            this._filePath = filePath;
            this._documentId = documentId;
        }

        /// <inheritdoc/>
        public override string Title => $"Open {Path.GetFileName(this._filePath)}";

        /// <inheritdoc/>
        public override void Apply(Workspace workspace, CancellationToken cancellationToken)
        {
            // Try to open the file as a regular document if it exists in the solution.
            if (this._documentId is not null)
            {
                // AdditionalDocuments can be opened in VS via the workspace.
                // This is a best-effort call — in non-VS environments it may be a no-op.
                try
                {
                    workspace.OpenDocument(this._documentId);
                }
                catch (NotSupportedException)
                {
                    // Not all workspace implementations support OpenDocument.
                }
            }
        }
    }
}
