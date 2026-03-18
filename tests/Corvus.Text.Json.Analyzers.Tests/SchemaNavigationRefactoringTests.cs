// <copyright file="SchemaNavigationRefactoringTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

using Xunit;

namespace Corvus.Text.Json.Analyzers.Tests;

/// <summary>
/// Tests for CTJ-NAV: Navigate to JSON Schema source.
/// </summary>
public class SchemaNavigationRefactoringTests
{
    private const string SimpleSchemaJson = @"{
  ""$schema"": ""https://json-schema.org/draft/2020-12/schema"",
  ""type"": ""object"",
  ""properties"": {
    ""name"": { ""type"": ""string"" },
    ""address"": {
      ""type"": ""object"",
      ""properties"": {
        ""city"": { ""type"": ""string"" },
        ""zipCode"": { ""type"": ""string"" }
      }
    }
  },
  ""allOf"": [
    {
      ""type"": ""object"",
      ""properties"": {
        ""extra"": { ""type"": ""string"" }
      }
    }
  ]
}";

    private const string AttributeAndInterfaceStubs = @"
using System;

namespace Corvus.Text.Json
{
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class JsonSchemaTypeGeneratorAttribute : Attribute
    {
        public JsonSchemaTypeGeneratorAttribute(string schemaPath) { }
    }
}

namespace Corvus.Text.Json.Internal
{
    public interface IJsonElement { }

    public interface IJsonElement<T> : IJsonElement
        where T : struct, IJsonElement<T>
    {
    }

    public interface IMutableJsonElement<T> : IJsonElement<T>
        where T : struct, IJsonElement<T>
    {
    }
}
";

    #region Basic navigation tests

    [Fact]
    public async Task TypeDeclarationWithSchemaAttribute_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
    }

    class Test
    {
        void M()
        {
            Widget w = default;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "Widget",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    [Fact]
    public async Task TypeWithoutSchemaAttribute_DoesNotOfferNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
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

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "PlainType",
            useLastIdentifier: true);

        Assert.Empty(actions);
    }

    #endregion

    #region JSON Pointer resolution tests

    [Fact]
    public async Task TypeWithSchemaLocation_ShowsPointerInTitle()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
        public readonly partial struct NameEntity : Corvus.Text.Json.Internal.IJsonElement<NameEntity>
        {
            public static partial class JsonSchema
            {
                public const string SchemaLocation = ""widget.json#/properties/name"";
            }
        }
    }

    class Test
    {
        void M()
        {
            Widget.NameEntity n = default;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "NameEntity",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("#/properties/name", actions[0].Title);
    }

    [Fact]
    public async Task TopLevelType_NoPointerInTitle()
    {
        // Top-level types have SchemaLocation like "widget.json" with no pointer fragment.
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
        public static partial class JsonSchema
        {
            public const string SchemaLocation = ""widget.json"";
        }
    }

    class Test
    {
        void M()
        {
            Widget w = default;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "Widget",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("widget.json", actions[0].Title);
        Assert.DoesNotContain("#", actions[0].Title);
    }

    [Theory]
    [InlineData("/properties/name", 4)]
    [InlineData("/properties/address", 5)]
    [InlineData("/properties/address/properties/city", 8)]
    [InlineData("/properties/address/properties/zipCode", 9)]
    public void ResolveJsonPointer_FindsCorrectLine(string pointer, int expectedLine)
    {
        int? line = SchemaNavigationRefactoring.ResolveJsonPointerToLine(SimpleSchemaJson, pointer);
        Assert.NotNull(line);
        Assert.Equal(expectedLine, line!.Value);
    }

    [Fact]
    public void ResolveJsonPointer_NullPointer_ReturnsNull()
    {
        int? line = SchemaNavigationRefactoring.ResolveJsonPointerToLine(SimpleSchemaJson, null!);
        Assert.Null(line);
    }

    [Fact]
    public void ResolveJsonPointer_EmptyPointer_ReturnsNull()
    {
        int? line = SchemaNavigationRefactoring.ResolveJsonPointerToLine(SimpleSchemaJson, "");
        Assert.Null(line);
    }

    [Fact]
    public void ResolveJsonPointer_RootSlash_ReturnsNull()
    {
        int? line = SchemaNavigationRefactoring.ResolveJsonPointerToLine(SimpleSchemaJson, "/");
        Assert.Null(line);
    }

    [Fact]
    public void ResolveJsonPointer_NonExistentProperty_ReturnsNull()
    {
        int? line = SchemaNavigationRefactoring.ResolveJsonPointerToLine(SimpleSchemaJson, "/properties/nonExistent");
        Assert.Null(line);
    }

    #endregion

    #region IJsonElement<T> / IMutableJsonElement<T> unwrapping tests

    [Fact]
    public async Task IJsonElementVariable_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
    }

    class Test
    {
        void M()
        {
            Corvus.Text.Json.Internal.IJsonElement<Widget> w = default(Widget);
        }
    }
}";

        // The cursor is on IJsonElement — the type should unwrap to Widget.
        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "IJsonElement",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    [Fact]
    public async Task IMutableJsonElementVariable_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IMutableJsonElement<Widget>
    {
    }

    class Test
    {
        void M()
        {
            Corvus.Text.Json.Internal.IMutableJsonElement<Widget> w = default(Widget);
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "IMutableJsonElement",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    [Fact]
    public async Task NonGenericIJsonElement_DoesNotOfferNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    class Test
    {
        void M(Corvus.Text.Json.Internal.IJsonElement e)
        {
            _ = e;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "IJsonElement",
            useLastIdentifier: true);

        Assert.Empty(actions);
    }

    [Fact]
    public async Task IJsonElementParameter_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
    }

    class Test
    {
        void M(Corvus.Text.Json.Internal.IJsonElement<Widget> param)
        {
            _ = param;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForIdentifier(
            code,
            "IJsonElement",
            useLastIdentifier: true,
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    #endregion

    #region Variable and parameter declaration tests

    [Fact]
    public async Task VariableDeclarator_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
    }

    class Test
    {
        void M()
        {
            Widget myWidget = default;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForNode(
            code,
            findNode: root => root.DescendantNodes()
                .OfType<VariableDeclaratorSyntax>()
                .First(v => v.Identifier.Text == "myWidget"),
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    [Fact]
    public async Task ParameterSyntax_OffersNavigation()
    {
        string code = AttributeAndInterfaceStubs + @"
namespace TestApp
{
    [Corvus.Text.Json.JsonSchemaTypeGenerator(""Schemas/widget.json"")]
    public readonly partial struct Widget : Corvus.Text.Json.Internal.IJsonElement<Widget>
    {
    }

    class Test
    {
        void M(Widget w)
        {
            _ = w;
        }
    }
}";

        List<CodeAction> actions = await GetRefactoringsForNode(
            code,
            findNode: root => root.DescendantNodes()
                .OfType<ParameterSyntax>()
                .First(p => p.Identifier.Text == "w"),
            additionalFilePath: "Schemas/widget.json",
            additionalFileContent: SimpleSchemaJson);

        Assert.NotEmpty(actions);
        Assert.Contains("Go to schema", actions[0].Title);
    }

    #endregion

    #region Helpers

    private static async Task<List<CodeAction>> GetRefactoringsForIdentifier(
        string code,
        string identifierName,
        bool useLastIdentifier,
        string? additionalFilePath = null,
        string? additionalFileContent = null)
    {
        return await GetRefactoringsForNode(
            code,
            findNode: root =>
            {
                var candidates = root.DescendantNodes()
                    .Where(n =>
                        (n is IdentifierNameSyntax id && id.Identifier.Text == identifierName) ||
                        (n is GenericNameSyntax gn && gn.Identifier.Text == identifierName))
                    .ToList();

                Assert.NotEmpty(candidates);
                return useLastIdentifier ? candidates.Last() : candidates.First();
            },
            additionalFilePath,
            additionalFileContent);
    }

    private static async Task<List<CodeAction>> GetRefactoringsForNode(
        string code,
        Func<SyntaxNode, SyntaxNode> findNode,
        string? additionalFilePath = null,
        string? additionalFileContent = null)
    {
        var workspace = new Microsoft.CodeAnalysis.AdhocWorkspace();
        var project = workspace.AddProject("TestProject", LanguageNames.CSharp);
        var refs = await ReferenceAssemblies.Net.Net80.ResolveAsync(
                LanguageNames.CSharp, default);
        project = project.AddMetadataReferences(refs);
        var document = project.AddDocument("Test.cs", SourceText.From(code), filePath: "Test.cs");

        if (additionalFilePath is not null && additionalFileContent is not null)
        {
            project = document.Project.AddAdditionalDocument(
                System.IO.Path.GetFileName(additionalFilePath),
                SourceText.From(additionalFileContent),
                folders: null,
                filePath: additionalFilePath).Project;
            document = project.GetDocument(document.Id)!;
        }
        else
        {
            document = document.Project.GetDocument(document.Id)!;
        }

        var tree = await document.GetSyntaxTreeAsync();
        var root = await tree!.GetRootAsync();

        var target = findNode(root!);

        var provider = new SchemaNavigationRefactoring();
        var actions = new List<CodeAction>();
        var context = new CodeRefactoringContext(
            document,
            target.Span,
            a => actions.Add(a),
            default);

        await provider.ComputeRefactoringsAsync(context);

        return actions;
    }

    #endregion
}
