// <copyright file="SchemaNavigationRefactoringTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

using Xunit;

using RefactoringTest = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeRefactoringTest<
    Corvus.Text.Json.Analyzers.SchemaNavigationRefactoring,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

namespace Corvus.Text.Json.Analyzers.Tests;

/// <summary>
/// Tests for CTJ-NAV: Navigate to JSON Schema source.
/// </summary>
public class SchemaNavigationRefactoringTests
{
    private const string SchemaJson = @"{
  ""$schema"": ""https://json-schema.org/draft/2020-12/schema"",
  ""type"": ""object"",
  ""properties"": {
    ""name"": { ""type"": ""string"" }
  }
}";

    private const string AttributeStub = @"
using System;

namespace Corvus.Text.Json
{
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class JsonSchemaTypeGeneratorAttribute : Attribute
    {
        public JsonSchemaTypeGeneratorAttribute(string schemaPath) { }
    }
}
";

    [Fact]
    public async Task TypeDeclarationWithSchemaAttribute_OffersNavigation()
    {
        string code = AttributeStub + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget { }

    class Test
    {
        void M()
        {
            Widget w = default;
        }
    }
}";

        var workspace = new Microsoft.CodeAnalysis.AdhocWorkspace();
        var project = workspace.AddProject("TestProject", LanguageNames.CSharp);
        var refs = await Microsoft.CodeAnalysis.Testing.ReferenceAssemblies.Net.Net80.ResolveAsync(
                LanguageNames.CSharp, default);
        project = project.AddMetadataReferences(refs);
        var document = project.AddDocument("Test.cs", SourceText.From(code), filePath: "Test.cs");
        project = document.Project.AddAdditionalDocument(
            "widget.json",
            SourceText.From(SchemaJson),
            folders: null,
            filePath: "Schemas/widget.json").Project;
        document = project.GetDocument(document.Id)!;

        var tree = await document.GetSyntaxTreeAsync();
        var root = await tree!.GetRootAsync();

        // Find "Widget" in "Widget w = default;" (the last IdentifierNameSyntax named Widget)
        var identifiers = root!.DescendantNodes()
            .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax>()
            .Where(i => i.Identifier.Text == "Widget")
            .ToList();

        var target = identifiers.Last();
        var span = target.Span;

        // Invoke the refactoring provider
        var provider = new SchemaNavigationRefactoring();
        var actions = new System.Collections.Generic.List<CodeAction>();
        var context = new CodeRefactoringContext(
            document,
            span,
            a => actions.Add(a),
            default);

        await provider.ComputeRefactoringsAsync(context);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    [Fact]
    public async Task ManualVerify_RefactoringFindsAttribute()
    {
        // Manual test: create a workspace, add the code, invoke the provider.
        string code = AttributeStub + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget { }

    class Test
    {
        void M()
        {
            Widget w = default;
        }
    }
}";

        var workspace = new Microsoft.CodeAnalysis.AdhocWorkspace();
        var project = workspace.AddProject("TestProject", LanguageNames.CSharp);
        var refs = await Microsoft.CodeAnalysis.Testing.ReferenceAssemblies.Net.Net80.ResolveAsync(
                LanguageNames.CSharp, default);
        project = project.AddMetadataReferences(refs);
        var document = project.AddDocument("Test.cs", SourceText.From(code), filePath: "Test.cs");
        project = document.Project.AddAdditionalDocument(
            "widget.json",
            SourceText.From(SchemaJson),
            folders: null,
            filePath: "Schemas/widget.json").Project;
        document = project.GetDocument(document.Id)!;

        var tree = await document.GetSyntaxTreeAsync();
        var root = await tree!.GetRootAsync();
        var model = await document.GetSemanticModelAsync();

        // Find "Widget" identifier in "Widget w = default;"
        var identifiers = root!.DescendantNodes()
            .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax>()
            .Where(i => i.Identifier.Text == "Widget")
            .ToList();

        // Check the last identifier (in the method body, not the struct declaration)
        var target = identifiers.Last();
        var symbolInfo = model!.GetSymbolInfo(target);

        Assert.NotNull(symbolInfo.Symbol);
        Assert.IsAssignableFrom<INamedTypeSymbol>(symbolInfo.Symbol);

        var typeSymbol = (INamedTypeSymbol)symbolInfo.Symbol!;
        var attrs = typeSymbol.GetAttributes();

        Assert.NotEmpty(attrs);
        Assert.Equal("JsonSchemaTypeGeneratorAttribute", attrs[0].AttributeClass!.Name);
        Assert.Equal("Schemas/widget.json", attrs[0].ConstructorArguments[0].Value);
    }

    [Fact]
    public async Task TypeWithoutSchemaAttribute_DoesNotOfferNavigation()
    {
        string code = AttributeStub + @"
namespace TestApp
{
    public readonly struct PlainType { }

    class Test
    {
        void M()
        {
            PlainType p = default;
        }
    }
}";

        var workspace = new Microsoft.CodeAnalysis.AdhocWorkspace();
        var project = workspace.AddProject("TestProject", LanguageNames.CSharp);
        var refs = await Microsoft.CodeAnalysis.Testing.ReferenceAssemblies.Net.Net80.ResolveAsync(
                LanguageNames.CSharp, default);
        project = project.AddMetadataReferences(refs);
        var document = project.AddDocument("Test.cs", SourceText.From(code), filePath: "Test.cs");
        document = document.Project.GetDocument(document.Id)!;

        var tree = await document.GetSyntaxTreeAsync();
        var root = await tree!.GetRootAsync();

        var target = root!.DescendantNodes()
            .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax>()
            .Where(i => i.Identifier.Text == "PlainType")
            .Last();

        var provider = new SchemaNavigationRefactoring();
        var actions = new System.Collections.Generic.List<CodeAction>();
        var context = new CodeRefactoringContext(
            document,
            target.Span,
            a => actions.Add(a),
            default);

        await provider.ComputeRefactoringsAsync(context);

        Assert.Empty(actions);
    }
}
