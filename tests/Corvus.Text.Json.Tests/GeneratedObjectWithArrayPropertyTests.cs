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
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.BuildDocument(workspace);

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
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.BuildDocument(workspace);

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
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.BuildDocument(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;
            root.SetScores(default(ObjectWithArrayProperty.ScoresEntityArray.Source));
            Assert.Null(root.Scores);
        }

        #endregion

        #region Remove optional array property

        [Fact]
        public void RemoveScores_WhenPresent_ReturnsTrue()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ObjectWithArrayProperty> doc = ParsedJsonDocument<ObjectWithArrayProperty>.Parse(SampleJson);
            using JsonDocumentBuilder<ObjectWithArrayProperty.Mutable> builder = doc.RootElement.BuildDocument(workspace);

            ObjectWithArrayProperty.Mutable root = builder.RootElement;
            bool removed = root.RemoveScores();

            Assert.True(removed);
            Assert.Null(root.Scores);
        }

        #endregion
    }
}
