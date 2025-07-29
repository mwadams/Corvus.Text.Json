// <copyright file="JsonElement.MutableRemoveWhereTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Text.Json.Tests
{
    using System;
    using Corvus.Text.Json;
    using Corvus.Text.Json.Internal;
    using Xunit;

    /// <summary>
    /// Tests for <see cref="JsonElement.Mutable.RemoveWhere{T}(JsonPredicate{T})"/>.
    /// </summary>
    public static class JsonElementMutableRemoveWhereTests
    {
        #region Basic Functionality Tests

        [Fact]
        public static void RemoveWhere_EmptyArray_NoChanges()
        {
            // Arrange
            using var doc = ParsedJsonDocument<JsonElement>.Parse("[]");
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = doc.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => true);

            // Assert
            Assert.Equal(0, mutableArray.GetArrayLength());
        }

        [Fact]
        public static void RemoveWhere_RemoveAllElements_EmptyArray()
        {
            // Arrange
            using var doc = ParsedJsonDocument<JsonElement>.Parse("[1, 2, 3, 4, 5]");
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = doc.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => true);

            // Assert
            Assert.Equal(0, mutableArray.GetArrayLength());
        }

        [Fact]
        public static void RemoveWhere_RemoveNoElements_NoChanges()
        {
            // Arrange
            const string json = "[1, 2, 3, 4, 5]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;
            string originalJson = mutableArray.GetRawText();

            // Act
            mutableArray.RemoveWhere((in element) => false);

            // Assert
            Assert.Equal(5, mutableArray.GetArrayLength());
            Assert.Equal(originalJson, mutableArray.GetRawText());
        }

        [Fact]
        public static void RemoveWhere_RemoveEvenNumbers_Success()
        {
            // Arrange
            const string json = "[1, 2, 3, 4, 5, 6]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() % 2 == 0);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(3, mutableArray[1].GetInt32());
            Assert.Equal(5, mutableArray[2].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_RemoveFirstElement_Success()
        {
            // Arrange
            const string json = "[\"first\", \"second\", \"third\"]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.String && element.GetString() == "first");

            // Assert
            Assert.Equal(2, mutableArray.GetArrayLength());
            Assert.Equal("second", mutableArray[0].GetString());
            Assert.Equal("third", mutableArray[1].GetString());
        }

        [Fact]
        public static void RemoveWhere_RemoveLastElement_Success()
        {
            // Arrange
            const string json = "[\"first\", \"second\", \"third\"]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.String && element.GetString() == "third");

            // Assert
            Assert.Equal(2, mutableArray.GetArrayLength());
            Assert.Equal("first", mutableArray[0].GetString());
            Assert.Equal("second", mutableArray[1].GetString());
        }

        [Fact]
        public static void RemoveWhere_RemoveMiddleElement_Success()
        {
            // Arrange
            const string json = "[\"first\", \"second\", \"third\"]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.String && element.GetString() == "second");

            // Assert
            Assert.Equal(2, mutableArray.GetArrayLength());
            Assert.Equal("first", mutableArray[0].GetString());
            Assert.Equal("third", mutableArray[1].GetString());
        }

        #endregion

        #region Consecutive Elements Tests

        [Fact]
        public static void RemoveWhere_ConsecutiveElementsAtStart_Success()
        {
            // Arrange
            const string json = "[1, 2, 3, 10, 11, 12]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove elements less than 10
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() < 10);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(10, mutableArray[0].GetInt32());
            Assert.Equal(11, mutableArray[1].GetInt32());
            Assert.Equal(12, mutableArray[2].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_ConsecutiveElementsAtEnd_Success()
        {
            // Arrange
            const string json = "[1, 2, 3, 10, 11, 12]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove elements greater than 5
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() > 5);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(2, mutableArray[1].GetInt32());
            Assert.Equal(3, mutableArray[2].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_ConsecutiveElementsInMiddle_Success()
        {
            // Arrange
            const string json = "[1, 10, 11, 12, 2]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove elements greater than 5
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() > 5);

            // Assert
            Assert.Equal(2, mutableArray.GetArrayLength());
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(2, mutableArray[1].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_MultipleConsecutiveRanges_Success()
        {
            // Arrange
            const string json = "[1, 2, 5, 6, 9, 10]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove even numbers
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() % 2 == 0);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(5, mutableArray[1].GetInt32());
            Assert.Equal(9, mutableArray[2].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_AlternatingPattern_Success()
        {
            // Arrange
            const string json = "[1, 2, 3, 4, 5, 6, 7, 8]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove even numbers (alternating pattern)
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() % 2 == 0);

            // Assert
            Assert.Equal(4, mutableArray.GetArrayLength());
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(3, mutableArray[1].GetInt32());
            Assert.Equal(5, mutableArray[2].GetInt32());
            Assert.Equal(7, mutableArray[3].GetInt32());
        }

        #endregion

        #region Type-Based Tests

        [Fact]
        public static void RemoveWhere_RemoveAllStrings_Success()
        {
            // Arrange
            const string json = "[\"hello\", 42, \"world\", true, \"test\", null]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => element.ValueKind == JsonValueKind.String);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(42, mutableArray[0].GetInt32());
            Assert.True(mutableArray[1].GetBoolean());
            Assert.Equal(JsonValueKind.Null, mutableArray[2].ValueKind);
        }

        [Fact]
        public static void RemoveWhere_RemoveAllNumbers_Success()
        {
            // Arrange
            const string json = "[\"hello\", 42, \"world\", 3.14, \"test\", 0]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => element.ValueKind == JsonValueKind.Number);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal("hello", mutableArray[0].GetString());
            Assert.Equal("world", mutableArray[1].GetString());
            Assert.Equal("test", mutableArray[2].GetString());
        }

        [Fact]
        public static void RemoveWhere_RemoveNullValues_Success()
        {
            // Arrange
            const string json = "[\"hello\", null, \"world\", null, \"test\"]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => element.ValueKind == JsonValueKind.Null);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal("hello", mutableArray[0].GetString());
            Assert.Equal("world", mutableArray[1].GetString());
            Assert.Equal("test", mutableArray[2].GetString());
        }

        #endregion

        #region Complex Object Tests

        [Fact]
        public static void RemoveWhere_ComplexObjects_RemoveByProperty()
        {
            // Arrange
            const string json = """
                [
                    {"name": "Alice", "age": 30},
                    {"name": "Bob", "age": 25},
                    {"name": "Charlie", "age": 35}
                ]
                """;
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove objects where age > 30
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Object &&
                element.TryGetProperty("age", out JsonElement age) &&
                age.GetInt32() > 30);

            // Assert
            Assert.Equal(2, mutableArray.GetArrayLength());
            Assert.Equal("Alice", mutableArray[0].GetProperty("name").GetString());
            Assert.Equal("Bob", mutableArray[1].GetProperty("name").GetString());
        }

        [Fact]
        public static void RemoveWhere_NestedArrays_RemoveEmptyArrays()
        {
            // Arrange
            const string json = """
                [
                    [1, 2, 3],
                    [],
                    [4, 5],
                    [],
                    [6]
                ]
                """;
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove empty arrays
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Array && element.GetArrayLength() == 0);

            // Assert
            Assert.Equal(3, mutableArray.GetArrayLength());
            Assert.Equal(3, mutableArray[0].GetArrayLength());
            Assert.Equal(2, mutableArray[1].GetArrayLength());
            Assert.Equal(1, mutableArray[2].GetArrayLength());
        }

        #endregion

        #region Edge Cases

        [Fact]
        public static void RemoveWhere_SingleElement_RemoveIt()
        {
            // Arrange
            const string json = "[42]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => element.ValueKind == JsonValueKind.Number);

            // Assert
            Assert.Equal(0, mutableArray.GetArrayLength());
            Assert.Equal("[]", mutableArray.GetRawText());
        }

        [Fact]
        public static void RemoveWhere_SingleElement_KeepIt()
        {
            // Arrange
            const string json = "[42]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act
            mutableArray.RemoveWhere((in element) => element.ValueKind == JsonValueKind.String);

            // Assert
            Assert.Equal(1, mutableArray.GetArrayLength());
            Assert.Equal(42, mutableArray[0].GetInt32());
        }

        [Fact]
        public static void RemoveWhere_LargeArray_PerformanceTest()
        {
            // Arrange - Create an array with 1000 elements
            var jsonBuilder = new System.Text.StringBuilder("[");
            for (int i = 0; i < 1000; i++)
            {
                if (i > 0) jsonBuilder.Append(", ");
                jsonBuilder.Append(i);
            }
            jsonBuilder.Append("]");

            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(jsonBuilder.ToString());
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act - Remove even numbers
            mutableArray.RemoveWhere((in element) =>
                element.ValueKind == JsonValueKind.Number && element.GetInt32() % 2 == 0);

            // Assert
            Assert.Equal(500, mutableArray.GetArrayLength());
            // Verify first few odd numbers remain
            Assert.Equal(1, mutableArray[0].GetInt32());
            Assert.Equal(3, mutableArray[1].GetInt32());
            Assert.Equal(5, mutableArray[2].GetInt32());
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public static void RemoveWhere_NullPredicate_ThrowsArgumentNullException()
        {
            // Arrange
            const string json = "[1, 2, 3]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                mutableArray.RemoveWhere(null!));
        }

        [Fact]
        public static void RemoveWhere_NotAnArray_ThrowsInvalidOperationException()
        {
            // Arrange
            const string json = "\"not an array\"";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableElement = builderDoc.RootElement;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                mutableElement.RemoveWhere((in element) => true));
        }

        [Fact]
        public static void RemoveWhere_ObjectInsteadOfArray_ThrowsInvalidOperationException()
        {
            // Arrange
            const string json = "{\"key\": \"value\"}";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableElement = builderDoc.RootElement;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                mutableElement.RemoveWhere((in element) => true));
        }

        [Fact]
        public static void RemoveWhere_NullValue_ThrowsInvalidOperationException()
        {
            // Arrange
            const string json = "null";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableElement = builderDoc.RootElement;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                mutableElement.RemoveWhere((in element) => true));
        }

        #endregion

        #region Predicate Exception Tests

        [Fact]
        public static void RemoveWhere_PredicateThrowsException_PropagatesException()
        {
            // Arrange
            const string json = "[1, 2, 3]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                mutableArray.RemoveWhere((in element) =>
                    throw new InvalidOperationException("Test exception")));
        }

        [Fact]
        public static void RemoveWhere_PredicateThrowsOnSecondElement_PartialProcessing()
        {
            // Arrange
            const string json = "[1, 2, 3]";
            using ParsedJsonDocument<JsonElement> document = ParsedJsonDocument<JsonElement>.Parse(json);
            using var workspace = JsonWorkspace.Create();
            using JsonDocumentBuilder<JsonElement.Mutable> builderDoc = document.RootElement.CreateDocumentBuilder(workspace);
            JsonElement.Mutable mutableArray = builderDoc.RootElement;
            int callCount = 0;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                mutableArray.RemoveWhere((in element) =>
                {
                    callCount++;
                    if (callCount == 2)
                        throw new InvalidOperationException("Test exception");
                    return false;
                }));

            // The array should remain unchanged due to the exception
            Assert.Equal(3, mutableArray.GetArrayLength());
        }

        #endregion
    }
}

