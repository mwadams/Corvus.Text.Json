// <copyright file="GeneratedCompositionApplyTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Corvus.Text.Json;
using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests;

public class GeneratedCompositionApplyTests
{
    #region CompositionAnyOf Apply Tests

    [Fact]
    public void AnyOf_Apply_RequiredKindAndMessage_MergesProperties()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<CompositionAnyOf> doc =
            ParsedJsonDocument<CompositionAnyOf>.Parse("{}");
        using JsonDocumentBuilder<CompositionAnyOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<CompositionAnyOf.RequiredKindAndMessage> variantDoc =
            ParsedJsonDocument<CompositionAnyOf.RequiredKindAndMessage>.Parse("""{"kind":"text","message":"hello"}""");

        CompositionAnyOf.Mutable root = builder.RootElement;
        root.Apply(variantDoc.RootElement);
        string json = root.ToString();

        // Verify via Match that the result matches the RequiredKindAndMessage variant
        using ParsedJsonDocument<CompositionAnyOf> roundTrip = ParsedJsonDocument<CompositionAnyOf>.Parse(json);
        string result = roundTrip.RootElement.Match(
            matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage v) => "text:" + v.Message.ToString(),
            matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind _) => "numeric",
            defaultMatch: static (in CompositionAnyOf _) => "default");

        Assert.Equal("text:hello", result);
    }

    [Fact]
    public void AnyOf_Apply_RequiredCodeAndKind_MergesProperties()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<CompositionAnyOf> doc =
            ParsedJsonDocument<CompositionAnyOf>.Parse("{}");
        using JsonDocumentBuilder<CompositionAnyOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind> variantDoc =
            ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind>.Parse("""{"kind":"numeric","code":42}""");

        CompositionAnyOf.Mutable root = builder.RootElement;
        root.Apply(variantDoc.RootElement);
        string json = root.ToString();

        // Verify via Match that the result matches the RequiredCodeAndKind variant
        using ParsedJsonDocument<CompositionAnyOf> roundTrip = ParsedJsonDocument<CompositionAnyOf>.Parse(json);
        string result = roundTrip.RootElement.Match(
            matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage _) => "text",
            matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind v) => "numeric:" + ((int)v.Code).ToString(),
            defaultMatch: static (in CompositionAnyOf _) => "default");

        Assert.Equal("numeric:42", result);
    }

    [Fact]
    public void AnyOf_Apply_OverwritesExistingProperties()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<CompositionAnyOf> doc =
            ParsedJsonDocument<CompositionAnyOf>.Parse("""{"kind":"text","message":"original"}""");
        using JsonDocumentBuilder<CompositionAnyOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind> variantDoc =
            ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind>.Parse("""{"kind":"numeric","code":99}""");

        CompositionAnyOf.Mutable root = builder.RootElement;
        root.Apply(variantDoc.RootElement);
        string json = root.ToString();

        // After overwrite, kind should be "numeric" and code=99, but message still present
        using ParsedJsonDocument<CompositionAnyOf.RequiredKindAndMessage> asTextVariant =
            ParsedJsonDocument<CompositionAnyOf.RequiredKindAndMessage>.Parse(json);
        Assert.Equal("original", asTextVariant.RootElement.Message.ToString());

        using ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind> asNumericVariant =
            ParsedJsonDocument<CompositionAnyOf.RequiredCodeAndKind>.Parse(json);
        Assert.Equal("numeric", asNumericVariant.RootElement.Kind.ToString());
        Assert.Equal(99, (int)asNumericVariant.RootElement.Code);
    }

    #endregion

    #region AllOfObjectWithProperties Apply Tests

    [Fact]
    public void AllOfWithProperties_Apply_RequiredName_MergesIntoLocalProperties()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<AllOfObjectWithProperties> doc =
            ParsedJsonDocument<AllOfObjectWithProperties>.Parse("""{"email":"a@b.com"}""");
        using JsonDocumentBuilder<AllOfObjectWithProperties.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<AllOfObjectWithProperties.RequiredName> nameDoc =
            ParsedJsonDocument<AllOfObjectWithProperties.RequiredName>.Parse("""{"name":"Bob","age":30}""");

        AllOfObjectWithProperties.Mutable root = builder.RootElement;
        root.Apply(nameDoc.RootElement);
        string json = root.ToString();

        using ParsedJsonDocument<AllOfObjectWithProperties> roundTrip = ParsedJsonDocument<AllOfObjectWithProperties>.Parse(json);
        Assert.Equal("Bob", roundTrip.RootElement.Name.ToString());
        Assert.Equal(30, (int)roundTrip.RootElement.Age);
        Assert.Equal("a@b.com", roundTrip.RootElement.Email.ToString());
    }

    [Fact]
    public void AllOfWithProperties_Apply_OverwritesExistingProperty()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<AllOfObjectWithProperties> doc =
            ParsedJsonDocument<AllOfObjectWithProperties>.Parse("""{"name":"Alice","email":"a@b.com"}""");
        using JsonDocumentBuilder<AllOfObjectWithProperties.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<AllOfObjectWithProperties.RequiredName> nameDoc =
            ParsedJsonDocument<AllOfObjectWithProperties.RequiredName>.Parse("""{"name":"Bob"}""");

        AllOfObjectWithProperties.Mutable root = builder.RootElement;
        root.Apply(nameDoc.RootElement);
        string json = root.ToString();

        using ParsedJsonDocument<AllOfObjectWithProperties> roundTrip = ParsedJsonDocument<AllOfObjectWithProperties>.Parse(json);
        Assert.Equal("Bob", roundTrip.RootElement.Name.ToString());
        Assert.Equal("a@b.com", roundTrip.RootElement.Email.ToString());
    }

    #endregion

    #region CompositionAllOf Additional Apply Tests

    [Fact]
    public void AllOf_Apply_BothComponents_MergesAll()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<CompositionAllOf> doc =
            ParsedJsonDocument<CompositionAllOf>.Parse("{}");
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<CompositionAllOf.AllOf0Entity> allOf0Doc =
            ParsedJsonDocument<CompositionAllOf.AllOf0Entity>.Parse("""{"firstName":"Alice"}""");
        using ParsedJsonDocument<CompositionAllOf.AllOf1Entity> allOf1Doc =
            ParsedJsonDocument<CompositionAllOf.AllOf1Entity>.Parse("""{"lastName":"Smith"}""");

        CompositionAllOf.Mutable root = builder.RootElement;
        root.Apply(allOf0Doc.RootElement);
        root.Apply(allOf1Doc.RootElement);
        string json = root.ToString();

        using ParsedJsonDocument<CompositionAllOf> roundTrip = ParsedJsonDocument<CompositionAllOf>.Parse(json);
        Assert.Equal("Alice", roundTrip.RootElement.FirstName.ToString());
        Assert.Equal("Smith", roundTrip.RootElement.LastName.ToString());
    }

    [Fact]
    public void AllOf_Apply_EmptyComponent_PreservesExisting()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using ParsedJsonDocument<CompositionAllOf> doc =
            ParsedJsonDocument<CompositionAllOf>.Parse("""{"firstName":"Alice","lastName":"Smith"}""");
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

        using ParsedJsonDocument<CompositionAllOf.AllOf0Entity> emptyDoc =
            ParsedJsonDocument<CompositionAllOf.AllOf0Entity>.Parse("{}");

        CompositionAllOf.Mutable root = builder.RootElement;
        root.Apply(emptyDoc.RootElement);
        string json = root.ToString();

        using ParsedJsonDocument<CompositionAllOf> roundTrip = ParsedJsonDocument<CompositionAllOf>.Parse(json);
        Assert.Equal("Alice", roundTrip.RootElement.FirstName.ToString());
        Assert.Equal("Smith", roundTrip.RootElement.LastName.ToString());
    }

    #endregion

    #region CompositionAllOf Empty CreateBuilder Tests (all-optional properties ambiguity check)

    [Fact]
    public void AllOf_AllOptionalProperties_ConvenienceOverloadAsEmpty_CreatesEmptyObject()
    {
        // CompositionAllOf has allOf with two object schemas, both with only optional properties.
        // When all properties are optional, the convenience overload with all-default params
        // subsumes the empty CreateBuilder — calling CreateBuilder(workspace) routes to it
        // with all properties undefined, producing an empty object.
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder =
            CompositionAllOf.CreateBuilder(workspace);

        CompositionAllOf.Mutable mutable = builder.RootElement;

        using var parsedFirst = ParsedJsonDocument<CompositionAllOf.AllOf0Entity>.Parse("""{"firstName":"Alice"}""");
        mutable.Apply(parsedFirst.RootElement);

        using var parsedSecond = ParsedJsonDocument<CompositionAllOf.AllOf1Entity>.Parse("""{"lastName":"Smith"}""");
        mutable.Apply(parsedSecond.RootElement);

        Assert.Equal("""{"firstName":"Alice","lastName":"Smith"}""", mutable.ToString());
    }

    [Fact]
    public void AllOf_AllOptionalProperties_ConvenienceOverloadAsEmpty_ThenApplySingle()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder =
            CompositionAllOf.CreateBuilder(workspace);

        CompositionAllOf.Mutable mutable = builder.RootElement;

        using var parsedFirst = ParsedJsonDocument<CompositionAllOf.AllOf0Entity>.Parse("""{"firstName":"Bob"}""");
        mutable.Apply(parsedFirst.RootElement);

        Assert.Equal("""{"firstName":"Bob"}""", mutable.ToString());
    }

    [Fact]
    public void AllOf_ConvenienceOverload_StillCallableWithNamedParameters()
    {
        // Verify the convenience overload with named parameters is also callable.
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder =
            CompositionAllOf.CreateBuilder(workspace, firstName: "Carol", lastName: "Jones");

        Assert.Equal("""{"firstName":"Carol","lastName":"Jones"}""", builder.RootElement.ToString());
    }

    [Fact]
    public void AllOf_ConvenienceOverloadPartialParams_ThenApply_OverwritesExistingProperties()
    {
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<CompositionAllOf.Mutable> builder =
            CompositionAllOf.CreateBuilder(workspace, firstName: "Original");

        CompositionAllOf.Mutable mutable = builder.RootElement;

        using var updated = ParsedJsonDocument<CompositionAllOf.AllOf0Entity>.Parse("""{"firstName":"Updated"}""");
        mutable.Apply(updated.RootElement);

        Assert.Equal("""{"firstName":"Updated"}""", mutable.ToString());
    }

    #endregion
}
