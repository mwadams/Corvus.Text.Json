// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for tuple types composed via allOf/$ref alongside additional constraints
    /// such as contains, items, or unevaluatedItems.
    /// </summary>
    public class GeneratedComposedTupleTests
    {
        #region RefTupleWithContains — allOf/$ref pure tuple + contains

        [Fact]
        public void RefTupleWithContains_Parse_Succeeds()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            Assert.Equal(2, doc.RootElement.GetArrayLength());
        }

        [Fact]
        public void RefTupleWithContains_IndexAccess_ReturnsCorrectValues()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            Assert.Equal("hello", doc.RootElement[0].ToString());
            Assert.Equal("42", doc.RootElement[1].ToString());
        }

        [Fact]
        public void RefTupleWithContains_TryGetAsBaseTuple_Succeeds()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            Assert.True(doc.RootElement.TryGetAsBaseTuple(out RefTupleWithContains.BaseTuple baseTuple));
            Assert.Equal(2, baseTuple.GetArrayLength());
        }

        [Fact]
        public void RefTupleWithContains_PrefixItems_ViaBaseTuple()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            Assert.True(doc.RootElement.TryGetAsBaseTuple(out RefTupleWithContains.BaseTuple baseTuple));

            RefTupleWithContains.BaseTuple.PrefixItems0Entity item0 =
                RefTupleWithContains.BaseTuple.PrefixItems0Entity.From(baseTuple[0]);
            Assert.Equal("hello", (string)item0);

            RefTupleWithContains.BaseTuple.PrefixItems1Entity item1 =
                RefTupleWithContains.BaseTuple.PrefixItems1Entity.From(baseTuple[1]);
            Assert.Equal(42, (int)item1);
        }

        [Fact]
        public void RefTupleWithContains_EnumerateArray_IteratesAllItems()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            int count = 0;
            foreach (JsonElement item in doc.RootElement.EnumerateArray())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        [Fact]
        public void RefTupleWithContains_Build_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefTupleWithContains.Source source = RefTupleWithContains.Build(
                static (ref RefTupleWithContains.Builder builder) =>
                {
                    builder.Add("world");
                    builder.Add(99);
                });

            using JsonDocumentBuilder<RefTupleWithContains.Mutable> builder =
                RefTupleWithContains.BuildDocument(workspace, source);
            RefTupleWithContains.Mutable root = builder.RootElement;

            Assert.Equal(2, root.GetArrayLength());
            Assert.Equal("world", root[0].ToString());
            Assert.Equal("99", root[1].ToString());
        }

        [Fact]
        public void RefTupleWithContains_Mutable_SetItem()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithContains.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithContains.Mutable root = builderDoc.RootElement;
            root.SetItem(0, "replaced");

            Assert.Equal("replaced", root[0].ToString());
            Assert.Equal("42", root[1].ToString());
        }

        [Fact]
        public void RefTupleWithContains_Mutable_Remove()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithContains.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithContains.Mutable root = builderDoc.RootElement;
            root.Remove(0);

            Assert.Equal(1, root.GetArrayLength());
            Assert.Equal("42", root[0].ToString());
        }

        [Fact]
        public void RefTupleWithContains_RoundTrip()
        {
            using ParsedJsonDocument<RefTupleWithContains> doc =
                ParsedJsonDocument<RefTupleWithContains>.Parse("""["hello",42]""");

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<RefTupleWithContains> roundTrip =
                ParsedJsonDocument<RefTupleWithContains>.Parse(json);
            Assert.Equal(2, roundTrip.RootElement.GetArrayLength());
            Assert.Equal("hello", roundTrip.RootElement[0].ToString());
            Assert.Equal("42", roundTrip.RootElement[1].ToString());
        }

        #endregion

        #region RefTupleWithAdditionalItems — allOf/$ref tuple + items: boolean

        [Fact]
        public void RefTupleWithAdditionalItems_Parse_Succeeds()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");

            Assert.Equal(4, doc.RootElement.GetArrayLength());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_IndexAccess_ReturnsTypedItems()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");

            // Indexer returns ItemsEntity
            Assert.Equal("hello", doc.RootElement[0].ToString());
            Assert.Equal("42", doc.RootElement[1].ToString());
            Assert.Equal("True", doc.RootElement[2].ToString());
            Assert.Equal("False", doc.RootElement[3].ToString());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_TryGetAsBaseTuple_Succeeds()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");

            Assert.True(doc.RootElement.TryGetAsBaseTuple(out RefTupleWithAdditionalItems.BaseTuple baseTuple));
            Assert.Equal(4, baseTuple.GetArrayLength());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_PrefixItems_ViaBaseTuple()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true]""");

            Assert.True(doc.RootElement.TryGetAsBaseTuple(out RefTupleWithAdditionalItems.BaseTuple baseTuple));

            RefTupleWithAdditionalItems.BaseTuple.PrefixItems0Entity item0 =
                RefTupleWithAdditionalItems.BaseTuple.PrefixItems0Entity.From(baseTuple[0]);
            Assert.Equal("hello", (string)item0);

            RefTupleWithAdditionalItems.BaseTuple.PrefixItems1Entity item1 =
                RefTupleWithAdditionalItems.BaseTuple.PrefixItems1Entity.From(baseTuple[1]);
            Assert.Equal(42, (int)item1);
        }

        [Fact]
        public void RefTupleWithAdditionalItems_EnumerateArray_IteratesAllItems()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");

            int count = 0;
            foreach (RefTupleWithAdditionalItems.ItemsEntity item in doc.RootElement.EnumerateArray())
            {
                count++;
            }

            Assert.Equal(4, count);
        }

        [Fact]
        public void RefTupleWithAdditionalItems_Build_CreatesValidSource()
        {
            // Builder.Add takes ItemsEntity.Source (boolean) — no CreateTuple on composed types
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefTupleWithAdditionalItems.Source source = RefTupleWithAdditionalItems.Build(
                static (ref RefTupleWithAdditionalItems.Builder builder) =>
                {
                    builder.Add(true);
                    builder.Add(false);
                });

            using JsonDocumentBuilder<RefTupleWithAdditionalItems.Mutable> builder =
                RefTupleWithAdditionalItems.BuildDocument(workspace, source);
            RefTupleWithAdditionalItems.Mutable root = builder.RootElement;

            Assert.Equal(2, root.GetArrayLength());
            Assert.Equal("True", root[0].ToString());
            Assert.Equal("False", root[1].ToString());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_Mutable_SetItem()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithAdditionalItems.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithAdditionalItems.Mutable root = builderDoc.RootElement;
            root.SetItem(2, false);

            Assert.Equal("False", root[2].ToString());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_Mutable_InsertItem()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithAdditionalItems.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithAdditionalItems.Mutable root = builderDoc.RootElement;
            root.InsertItem(2, false);

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal("False", root[2].ToString());
            Assert.Equal("True", root[3].ToString());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_Mutable_Remove()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithAdditionalItems.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithAdditionalItems.Mutable root = builderDoc.RootElement;
            root.Remove(3);

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal("True", root[2].ToString());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_Mutable_SetItemUndefined_Removes()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<RefTupleWithAdditionalItems.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            RefTupleWithAdditionalItems.Mutable root = builderDoc.RootElement;
            root.SetItem(3, default(RefTupleWithAdditionalItems.ItemsEntity.Source));

            Assert.Equal(3, root.GetArrayLength());
        }

        [Fact]
        public void RefTupleWithAdditionalItems_RoundTrip()
        {
            using ParsedJsonDocument<RefTupleWithAdditionalItems> doc =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse("""["hello",42,true,false]""");

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<RefTupleWithAdditionalItems> roundTrip =
                ParsedJsonDocument<RefTupleWithAdditionalItems>.Parse(json);
            Assert.Equal(4, roundTrip.RootElement.GetArrayLength());
            Assert.Equal("hello", roundTrip.RootElement[0].ToString());
        }

        #endregion

        #region AllOfInlineTupleWithUnevaluated — inline prefixItems in allOf + unevaluatedItems

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Parse_Succeeds()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true]""");

            Assert.Equal(3, doc.RootElement.GetArrayLength());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_IndexAccess_ReturnsUnevaluatedItemsEntity()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true,false]""");

            Assert.Equal("hello", doc.RootElement[0].ToString());
            Assert.Equal("3.14", doc.RootElement[1].ToString());
            Assert.Equal("True", doc.RootElement[2].ToString());
            Assert.Equal("False", doc.RootElement[3].ToString());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_TryGetAsAllOf0Entity_Succeeds()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true]""");

            Assert.True(doc.RootElement.TryGetAsAllOf0Entity(out AllOfInlineTupleWithUnevaluated.AllOf0Entity entity));
            Assert.Equal(3, entity.GetArrayLength());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_PrefixItems_ViaAllOf0Entity()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true]""");

            Assert.True(doc.RootElement.TryGetAsAllOf0Entity(out AllOfInlineTupleWithUnevaluated.AllOf0Entity entity));

            AllOfInlineTupleWithUnevaluated.AllOf0Entity.PrefixItems0Entity item0 =
                AllOfInlineTupleWithUnevaluated.AllOf0Entity.PrefixItems0Entity.From(entity[0]);
            Assert.Equal("hello", (string)item0);

            AllOfInlineTupleWithUnevaluated.AllOf0Entity.PrefixItems1Entity item1 =
                AllOfInlineTupleWithUnevaluated.AllOf0Entity.PrefixItems1Entity.From(entity[1]);
            Assert.Equal(3.14, (double)item1, 2);
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_EnumerateArray_IteratesAllItems()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true,false]""");

            int count = 0;
            foreach (AllOfInlineTupleWithUnevaluated.UnevaluatedItemsEntity item in doc.RootElement.EnumerateArray())
            {
                count++;
            }

            Assert.Equal(4, count);
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Build_CreatesValidSource()
        {
            // Builder.Add takes UnevaluatedItemsEntity.Source (boolean) — no CreateTuple on composed types
            using JsonWorkspace workspace = JsonWorkspace.Create();

            AllOfInlineTupleWithUnevaluated.Source source = AllOfInlineTupleWithUnevaluated.Build(
                static (ref AllOfInlineTupleWithUnevaluated.Builder builder) =>
                {
                    builder.Add(true);
                    builder.Add(false);
                });

            using JsonDocumentBuilder<AllOfInlineTupleWithUnevaluated.Mutable> builder =
                AllOfInlineTupleWithUnevaluated.BuildDocument(workspace, source);
            AllOfInlineTupleWithUnevaluated.Mutable root = builder.RootElement;

            Assert.Equal(2, root.GetArrayLength());
            Assert.Equal("True", root[0].ToString());
            Assert.Equal("False", root[1].ToString());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Mutable_SetItem()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<AllOfInlineTupleWithUnevaluated.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            AllOfInlineTupleWithUnevaluated.Mutable root = builderDoc.RootElement;
            root.SetItem(2, false);

            Assert.Equal("False", root[2].ToString());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Mutable_InsertItem()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<AllOfInlineTupleWithUnevaluated.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            AllOfInlineTupleWithUnevaluated.Mutable root = builderDoc.RootElement;
            root.InsertItem(2, true);

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal("True", root[2].ToString());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Mutable_Remove()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true,false]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<AllOfInlineTupleWithUnevaluated.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            AllOfInlineTupleWithUnevaluated.Mutable root = builderDoc.RootElement;
            root.Remove(3);

            Assert.Equal(3, root.GetArrayLength());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_Mutable_RemoveWhere()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true,false]""");
            using JsonWorkspace workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<AllOfInlineTupleWithUnevaluated.Mutable> builderDoc =
                doc.RootElement.BuildDocument(workspace);

            AllOfInlineTupleWithUnevaluated.Mutable root = builderDoc.RootElement;
            root.RemoveWhere(static (in AllOfInlineTupleWithUnevaluated.UnevaluatedItemsEntity item) =>
                item.ToString() == "True");

            Assert.Equal(3, root.GetArrayLength());
        }

        [Fact]
        public void AllOfInlineTupleWithUnevaluated_RoundTrip()
        {
            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> doc =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse("""["hello",3.14,true,false]""");

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<AllOfInlineTupleWithUnevaluated> roundTrip =
                ParsedJsonDocument<AllOfInlineTupleWithUnevaluated>.Parse(json);
            Assert.Equal(4, roundTrip.RootElement.GetArrayLength());
            Assert.Equal("hello", roundTrip.RootElement[0].ToString());
        }

        #endregion
    }
}
