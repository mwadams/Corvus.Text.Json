// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated mutable objects with array-typed properties.
    /// Exercises: setting array properties, required/optional IsUndefined guards,
    /// and RemoveXxx for optional array properties.
    /// </summary>
    public class GeneratedObjectWithArrayPropertyTests
    {
        private const string SampleJson =
            """
            {"tags":["a","b","c"],"scores":[1.5,2.5,3.5]}
            """;

        #region Set array properties

        [Fact]
        public void SetTags_WithValidSource_SetsProperty()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ObjectWithArrayProperty> doc = ParsedJsonDocument<ObjectWithArrayProperty>.Parse(SampleJson);
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ObjectWithArrayProperty.TagsEntityArray> tagsDoc =
                ParsedJsonDocument<ObjectWithArrayProperty.TagsEntityArray>.Parse("""["x","y"]""");
            root.SetTags(tagsDoc.RootElement);
            Assert.Equal(2, root.Tags.GetArrayLength());
        }

        #endregion

        #region IsUndefined guards

        [Fact]
        public void SetTags_WithUndefinedSource_ThrowsForRequired()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ObjectWithArrayProperty> doc = ParsedJsonDocument<ObjectWithArrayProperty>.Parse(SampleJson);
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;

            bool threw = false;
            try
            {
                root.SetTags(default(ObjectWithArrayProperty.TagsEntityArray.Source));
            }
            catch (InvalidOperationException)
            {
                threw = true;
            }

            Assert.True(threw);
        }

        [Fact]
        public void SetScores_WithUndefinedSource_RemovesOptional()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ObjectWithArrayProperty> doc = ParsedJsonDocument<ObjectWithArrayProperty>.Parse(SampleJson);
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;
            root.SetScores(default(ObjectWithArrayProperty.ScoresEntityArray.Source));
            Assert.True(root.Scores.IsUndefined());
        }

        #endregion

        #region Remove optional array property

        [Fact]
        public void RemoveScores_WhenPresent_ReturnsTrue()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ObjectWithArrayProperty> doc = ParsedJsonDocument<ObjectWithArrayProperty>.Parse(SampleJson);
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;
            bool removed = root.RemoveScores();

            Assert.True(removed);
            Assert.True(root.Scores.IsUndefined());
        }

        #endregion

        #region Build and CreateBuilder from span (variable-length numeric array)

        [Fact]
        public void ScoresArray_BuildFromSpan()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [1.1, 2.2, 3.3];
            ObjectWithArrayProperty.ScoresEntityArray.Source source =
                ObjectWithArrayProperty.ScoresEntityArray.Build(values);

            using JsonDocumentBuilder<ObjectWithArrayProperty.ScoresEntityArray.Mutable> doc =
                ObjectWithArrayProperty.ScoresEntityArray.CreateBuilder(workspace, source);
            ObjectWithArrayProperty.ScoresEntityArray.Mutable root = doc.RootElement;

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(1.1, (double)root[0]);
            Assert.Equal(2.2, (double)root[1]);
            Assert.Equal(3.3, (double)root[2]);
        }

        [Fact]
        public void ScoresArray_CreateBuilderFromSpan()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [10.0, 20.0, 30.0, 40.0, 50.0];
            using JsonDocumentBuilder<ObjectWithArrayProperty.ScoresEntityArray.Mutable> doc =
                ObjectWithArrayProperty.ScoresEntityArray.CreateBuilder(workspace, values);
            ObjectWithArrayProperty.ScoresEntityArray.Mutable root = doc.RootElement;

            Assert.Equal(5, root.GetArrayLength());
            Assert.Equal(10.0, (double)root[0]);
            Assert.Equal(50.0, (double)root[4]);
        }

        [Fact]
        public void ScoresArray_BuildFromSpan_RoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [1.5, 2.5, 3.5];
            using JsonDocumentBuilder<ObjectWithArrayProperty.ScoresEntityArray.Mutable> doc =
                ObjectWithArrayProperty.ScoresEntityArray.CreateBuilder(workspace, values);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<ObjectWithArrayProperty.ScoresEntityArray> reparsed =
                ParsedJsonDocument<ObjectWithArrayProperty.ScoresEntityArray>.Parse(json);
            Assert.Equal(3, reparsed.RootElement.GetArrayLength());
            Assert.Equal(1.5, (double)reparsed.RootElement[0]);
            Assert.Equal(2.5, (double)reparsed.RootElement[1]);
            Assert.Equal(3.5, (double)reparsed.RootElement[2]);
        }

        [Fact]
        public void ScoresArray_BuildFromEmptySpan()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [];
            using JsonDocumentBuilder<ObjectWithArrayProperty.ScoresEntityArray.Mutable> doc =
                ObjectWithArrayProperty.ScoresEntityArray.CreateBuilder(workspace, values);

            string json = doc.RootElement.ToString();
            Assert.Equal("[]", json);
        }

        [Fact]
        public void ScoresArray_ImplicitConversion_FromSpan()
        {
            ReadOnlySpan<double> values = [9.0, 8.5, 7.0];
            ObjectWithArrayProperty.ScoresEntityArray.Source source = values;

            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<ObjectWithArrayProperty.ScoresEntityArray.Mutable> doc =
                ObjectWithArrayProperty.ScoresEntityArray.CreateBuilder(workspace, source);

            string json = doc.RootElement.ToString();
            Assert.Equal("[9,8.5,7]", json);
        }

        #endregion
    }
}
