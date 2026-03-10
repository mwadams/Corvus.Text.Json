// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated mutable array types with typed items.
    /// Exercises: SetItem, InsertItem, Remove, RemoveRange, RemoveWhere,
    /// IsUndefined guards (SetItem→remove, InsertItem→no-op),
    /// GetArrayLength, and EnumerateArray.
    /// </summary>
    public class GeneratedArrayMutationTests
    {
        private const string SampleJson =
            """
            [{"id":1,"label":"first"},{"id":2,"label":"second"},{"id":3,"label":"third"}]
            """;

        #region SetItem

        [Fact]
        public void SetItem_AtValidIndex_ReplacesItem()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ArrayOfItems.RequiredId> itemDoc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":99,"label":"replaced"}""");
            root.SetItem(1, itemDoc.RootElement);

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(99, (int)root[1].Id);
        }

        [Fact]
        public void SetItem_AtArrayLength_AppendsItem()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ArrayOfItems.RequiredId> itemDoc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":4,"label":"fourth"}""");
            root.SetItem(3, itemDoc.RootElement);

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(4, (int)root[3].Id);
        }

        [Fact]
        public void SetItem_WithUndefinedSource_RemovesItem()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.SetItem(1, default(ArrayOfItems.RequiredId.Source));
            Assert.Equal(2, root.GetArrayLength());
            Assert.Equal(1, (int)root[0].Id);
            Assert.Equal(3, (int)root[1].Id);
        }

        #endregion

        #region InsertItem

        [Fact]
        public void InsertItem_AtIndex_InsertsItem()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ArrayOfItems.RequiredId> itemDoc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":0,"label":"inserted"}""");
            root.InsertItem(1, itemDoc.RootElement);

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(1, (int)root[0].Id);
            Assert.Equal(0, (int)root[1].Id);
            Assert.Equal(2, (int)root[2].Id);
        }

        [Fact]
        public void InsertItem_WithUndefinedSource_IsNoOp()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.InsertItem(1, default(ArrayOfItems.RequiredId.Source));
            Assert.Equal(3, root.GetArrayLength());
        }

        #endregion

        #region AddItem

        [Fact]
        public void AddItem_AppendsItemToEnd()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ArrayOfItems.RequiredId> itemDoc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":4,"label":"fourth"}""");
            root.AddItem(itemDoc.RootElement);

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(4, (int)root[3].Id);
            Assert.Equal("fourth", (string)root[3].Label);
        }

        [Fact]
        public void AddItem_MultipleAppends_PreservesOrder()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;

            using ParsedJsonDocument<ArrayOfItems.RequiredId> item4Doc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":4,"label":"fourth"}""");
            using ParsedJsonDocument<ArrayOfItems.RequiredId> item5Doc = ParsedJsonDocument<ArrayOfItems.RequiredId>.Parse("""{"id":5,"label":"fifth"}""");
            root.AddItem(item4Doc.RootElement);
            root.AddItem(item5Doc.RootElement);

            Assert.Equal(5, root.GetArrayLength());
            Assert.Equal(4, (int)root[3].Id);
            Assert.Equal(5, (int)root[4].Id);
        }

        [Fact]
        public void AddItem_WithUndefinedSource_IsNoOp()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.AddItem(default(ArrayOfItems.RequiredId.Source));
            Assert.Equal(3, root.GetArrayLength());
        }

        #endregion

        #region Remove, RemoveRange, RemoveWhere

        [Fact]
        public void Remove_AtIndex_RemovesItem()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.RemoveAt(0);
            Assert.Equal(2, root.GetArrayLength());
            Assert.Equal(2, (int)root[0].Id);
        }

        [Fact]
        public void RemoveRange_RemovesMultipleItems()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.RemoveRange(0, 2);
            Assert.Equal(1, root.GetArrayLength());
            Assert.Equal(3, (int)root[0].Id);
        }

        [Fact]
        public void RemoveWhere_RemovesMatchingItems()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            root.RemoveWhere(static (in ArrayOfItems.RequiredId item) => (int)item.Id > 1);
            Assert.Equal(1, root.GetArrayLength());
            Assert.Equal(1, (int)root[0].Id);
        }

        #endregion

        #region GetArrayLength and EnumerateArray

        [Fact]
        public void GetArrayLength_ReturnsCorrectCount()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            Assert.Equal(3, root.GetArrayLength());
        }

        [Fact]
        public void EnumerateArray_IteratesAllItems()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using ParsedJsonDocument<ArrayOfItems> doc = ParsedJsonDocument<ArrayOfItems>.Parse(SampleJson);
            using JsonDocumentBuilder<ArrayOfItems.Mutable> builder = doc.RootElement.CreateBuilder(workspace);

            ArrayOfItems.Mutable root = builder.RootElement;
            int count = 0;
            foreach (ArrayOfItems.RequiredId.Mutable item in root.EnumerateArray())
            {
                count++;
            }

            Assert.Equal(3, count);
        }

        #endregion
    }
}
