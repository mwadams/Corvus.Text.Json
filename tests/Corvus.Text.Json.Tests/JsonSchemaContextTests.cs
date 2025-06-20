// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using Corvus.Text.Json.Internal;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public static class JsonSchemaContextTests
    {
        private static ParsedJsonDocument<JsonElement> CreateLargeArrayDocument()
        {
            string largeArray = "[" + string.Join(
                ",",
                Enumerable.Range(0, 65536).Select(i => i.ToString())) + "]";

            return ParsedJsonDocument<JsonElement>.Parse(largeArray);
        }

        private static ParsedJsonDocument<JsonElement> CreateLargeObjectDocument()
        {
            string largeArray = "{" + string.Join(
                ",",
                Enumerable.Range(0, 65536).Select(i => "\"" + i.ToString() + "\":" + i.ToString())) + "}";

            return ParsedJsonDocument<JsonElement>.Parse(largeArray);
        }

        private static ParsedJsonDocument<JsonElement> CreateSmallArrayDocument()
        {
            string largeArray = "[" + string.Join(
                ",",
                Enumerable.Range(0, 255).Select(i => i.ToString())) + "]";

            return ParsedJsonDocument<JsonElement>.Parse(largeArray);
        }

        private static ParsedJsonDocument<JsonElement> CreateSmallObjectDocument()
        {
            string largeArray = "{" + string.Join(
                ",",
                Enumerable.Range(0, 255).Select(i => "\"" + i.ToString() + "\":" + i.ToString())) + "}";

            return ParsedJsonDocument<JsonElement>.Parse(largeArray);
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1,2,3 }, new int[] { 0, 4 }, true)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(false, true, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(false, true, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedItems(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeArrayDocument() : CreateSmallArrayDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach(int item in evaluateIndices)
            {
                context.AddLocalEvaluatedItem(item);
            }

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedItem(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedItem(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(true, false, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(true, false, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedProperties(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeObjectDocument() : CreateSmallObjectDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedProperty(item);
            }

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(false, true, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(false, true, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedItemsFromChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeArrayDocument() : CreateSmallArrayDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach (int item in evaluateIndices)
            {
                childContext.AddLocalEvaluatedItem(item);
            }

            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(evaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(true, false, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(true, false, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedPropertiesFromChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeObjectDocument() : CreateSmallObjectDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach (int item in evaluateIndices)
            {
                childContext.AddLocalEvaluatedProperty(item);
            }

            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(evaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(false, true, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(false, true, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedItemsAfterUnchangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeArrayDocument() : CreateSmallArrayDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);


            // Act
            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);
            // NOP
            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedItem(item);
            }

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedItem(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedItem(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(true, false, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(true, false, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedPropertiesAfterUnchangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeObjectDocument() : CreateSmallObjectDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);
            // NOP
            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedProperty(item);
            }

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(false, true, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(false, true, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedItemsWithBeforeUnchangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeArrayDocument() : CreateSmallArrayDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);


            // Act
            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedItem(item);
            }

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);
            // NOP
            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);


            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedItem(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedItem(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(true, false, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(true, false, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedPropertiesBeforeUnchangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeObjectDocument() : CreateSmallObjectDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedProperty(item);
            }

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);
            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(false, true, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(false, true, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(false, true, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(false, true, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedItemsWithChangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeArrayDocument() : CreateSmallArrayDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);


            // Act
            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedItem(item);
            }

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);
            foreach (int item in evaluateIndices)
            {
                childContext.AddLocalEvaluatedItem(item);
            }
            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);


            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedItem(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedItem(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedItem(i)));
        }

        [Theory]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, true)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, true)]
        [InlineData(true, false, new int[] { 65536 }, new int[] { 65536 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130, 65535 }, true)]
        [InlineData(false, false, new int[] { 1, 2, 3 }, new int[0], new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(true, false, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 0, 4 }, false)]
        [InlineData(true, false, new int[] { 66, 129 }, new int[] { 66, 129 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        [InlineData(true, false, new int[] { 255 }, new int[] { 255 }, new int[] { 0, 1, 2, 3, 4, 63, 64, 65, 67, 68, 126, 127, 128, 130 }, false)]
        public static void EvaluatedPropertiesWithChangedChildContext(bool usingEvaluatedProperties, bool usingEvaluatedItems, int[] evaluateIndices, int[] evaluatedIndices, int[] notEvaluatedIndices, bool useLargeDocument)
        {
            // Arrange
            using ParsedJsonDocument<JsonElement> document = useLargeDocument ? CreateLargeObjectDocument() : CreateSmallObjectDocument();
            (IJsonDocument parentDocument, int parentIndex) = JsonElementHelpers.GetParentDocumentAndIndex(document.RootElement);
            using JsonSchemaContext context = JsonSchemaContext.BeginContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            // Act
            foreach (int item in evaluateIndices)
            {
                context.AddLocalEvaluatedProperty(item);
            }

            JsonSchemaContext childContext = context.PushChildContext(parentDocument, parentIndex, usingEvaluatedProperties, usingEvaluatedItems);

            foreach (int item in evaluateIndices)
            {
                childContext.AddLocalEvaluatedProperty(item);
            }

            context.CommitChildContext(true, ref childContext);
            context.ApplyEvaluated(ref childContext);

            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(evaluatedIndices, i => Assert.True(context.HasLocalEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalOrAppliedEvaluatedProperty(i)));
            Assert.All(notEvaluatedIndices, i => Assert.False(context.HasLocalEvaluatedProperty(i)));
        }
    }
}
