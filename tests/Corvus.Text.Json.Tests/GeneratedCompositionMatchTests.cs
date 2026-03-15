// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated Match() and Apply() patterns on composition types.
    /// Exercises: anyOf Match, oneOf Match, allOf Match + Apply,
    /// both with and without context parameters.
    /// </summary>
    public class GeneratedCompositionMatchTests
    {
        #region anyOf Match

        [Fact]
        public void AnyOf_Match_WhenTextObject_CallsTextMatcher()
        {
            using ParsedJsonDocument<CompositionAnyOf> doc =
                ParsedJsonDocument<CompositionAnyOf>.Parse("""{"kind":"text","message":"hello"}""");

            string result = doc.RootElement.Match(
                matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage v) => "text:" + v.Message.ToString(),
                matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind _) => "numeric",
                defaultMatch: static (in CompositionAnyOf _) => "default");

            Assert.Equal("text:hello", result);
        }

        [Fact]
        public void AnyOf_Match_WhenNumericObject_CallsNumericMatcher()
        {
            using ParsedJsonDocument<CompositionAnyOf> doc =
                ParsedJsonDocument<CompositionAnyOf>.Parse("""{"kind":"numeric","code":42}""");

            string result = doc.RootElement.Match(
                matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage _) => "text",
                matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind v) => "numeric:" + ((int)v.Code).ToString(),
                defaultMatch: static (in CompositionAnyOf _) => "default");

            Assert.Equal("numeric:42", result);
        }

        [Fact]
        public void AnyOf_Match_WhenNeither_CallsDefaultMatcher()
        {
            using ParsedJsonDocument<CompositionAnyOf> doc =
                ParsedJsonDocument<CompositionAnyOf>.Parse("""{"other":"value"}""");

            string result = doc.RootElement.Match(
                matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage _) => "text",
                matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind _) => "numeric",
                defaultMatch: static (in CompositionAnyOf _) => "default");

            Assert.Equal("default", result);
        }

        [Fact]
        public void AnyOf_MatchWithContext_PassesContext()
        {
            using ParsedJsonDocument<CompositionAnyOf> doc =
                ParsedJsonDocument<CompositionAnyOf>.Parse("""{"kind":"text","message":"hello"}""");

            string result = doc.RootElement.Match(
                "prefix",
                matchRequiredKindAndMessage: static (in CompositionAnyOf.RequiredKindAndMessage v, in string ctx) => ctx + ":" + v.Message.ToString(),
                matchRequiredCodeAndKind: static (in CompositionAnyOf.RequiredCodeAndKind _, in string _2) => "numeric",
                defaultMatch: static (in CompositionAnyOf _, in string _2) => "default");

            Assert.Equal("prefix:hello", result);
        }

        #endregion

        #region oneOf Match

        [Fact]
        public void OneOf_Match_WhenString_CallsStringMatcher()
        {
            using ParsedJsonDocument<CompositionOneOf> doc =
                ParsedJsonDocument<CompositionOneOf>.Parse("\"hello\"");

            string result = doc.RootElement.Match(
                matchJsonString: static (in JsonString v) => "string:" + v.ToString(),
                matchJsonInt32: static (in JsonInt32 _) => "number",
                matchJsonBoolean: static (in JsonBoolean _) => "boolean",
                defaultMatch: static (in CompositionOneOf _) => "default");

            Assert.Equal("string:hello", result);
        }

        [Fact]
        public void OneOf_Match_WhenNumber_CallsNumberMatcher()
        {
            using ParsedJsonDocument<CompositionOneOf> doc =
                ParsedJsonDocument<CompositionOneOf>.Parse("42");

            string result = doc.RootElement.Match(
                matchJsonString: static (in JsonString _) => "string",
                matchJsonInt32: static (in JsonInt32 v) => "number:" + ((int)v).ToString(),
                matchJsonBoolean: static (in JsonBoolean _) => "boolean",
                defaultMatch: static (in CompositionOneOf _) => "default");

            Assert.Equal("number:42", result);
        }

        [Fact]
        public void OneOf_Match_WhenBoolean_CallsBooleanMatcher()
        {
            using ParsedJsonDocument<CompositionOneOf> doc =
                ParsedJsonDocument<CompositionOneOf>.Parse("true");

            string result = doc.RootElement.Match(
                matchJsonString: static (in JsonString _) => "string",
                matchJsonInt32: static (in JsonInt32 _) => "number",
                matchJsonBoolean: static (in JsonBoolean v) => "boolean:" + ((bool)v).ToString(),
                defaultMatch: static (in CompositionOneOf _) => "default");

            Assert.StartsWith("boolean:", result);
        }

        #endregion

        #region allOf Match + Apply

        [Fact]
        public void AllOf_Apply_MergesProperties()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<CompositionAllOf> doc =
                ParsedJsonDocument<CompositionAllOf>.Parse("""{"firstName":"Alice"}""");
            using JsonDocumentBuilder<CompositionAllOf.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            using ParsedJsonDocument<CompositionAllOf.AllOf1Entity> allOf1Doc =
                ParsedJsonDocument<CompositionAllOf.AllOf1Entity>.Parse("""{"lastName":"Smith"}""");

            CompositionAllOf.Mutable root = builder.RootElement;
            root.Apply(allOf1Doc.RootElement);
            string json = root.ToString();

            using ParsedJsonDocument<CompositionAllOf> roundTrip = ParsedJsonDocument<CompositionAllOf>.Parse(json);
            Assert.Equal("Alice", roundTrip.RootElement.FirstName.ToString());
            Assert.Equal("Smith", roundTrip.RootElement.LastName.ToString());
        }

        #endregion
    }
}