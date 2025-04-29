// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
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
        /// The handle identifying the IJsonElement in
        /// its parent document.
        /// </summary>
        int ParentDocumentIndex { get; }

        /// <summary>
        /// The JSON Token type of the element.
        /// </summary>
        JsonTokenType TokenType { get; }

        /// <summary>
        /// The JSON Value Kind of the element.
        /// </summary>
        JsonValueKind ValueKind { get; }

        void CheckValidInstance();
    }
}
