// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Implemented by JsonElement-derived types.
    /// </summary>
    [CLSCompliant(false)]
    public interface IJsonElement
    {
        /// <summary>
        /// Gets the parent document.
        /// </summary>
        IJsonDocument ParentDocument { get; }

        /// <summary>
        /// Gets the handle identifying the <see cref="IJsonElement"/> in its parent document.
        /// </summary>
        int ParentDocumentIndex { get; }

        /// <summary>
        /// Gets the JSON Token type of the element.
        /// </summary>
        JsonTokenType TokenType { get; }

        /// <summary>
        /// Gets the JSON Value Kind of the element.
        /// </summary>
        JsonValueKind ValueKind { get; }

        /// <summary>
        /// Checks that this instance is valid.
        /// </summary>
        void CheckValidInstance();

        /// <summary>
        /// Writes this element to the specified <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the element.</param>
        void WriteTo(Utf8JsonWriter writer);

        /// <summary>
        /// Evaluates the schema for this element.
        /// </summary>
        /// <param name="resultsCollector">The results collector for schema evaluation (optional).</param>
        /// <returns><c>true</c> if the schema evaluation succeeded; otherwise, <c>false</c>.</returns>
        bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null);
    }
}
