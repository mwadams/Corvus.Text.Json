// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Implemented by JsonElement-derived types.
/// </summary>
/// <typeparam name="T">The type implementing the interface.</typeparam>
[CLSCompliant(false)]
public interface IJsonElement<T> : IJsonElement
    where T : struct, IJsonElement<T>
{
#if NET
    /// <summary>
    /// Creates an instance of the element from the parent document and the handle of
    /// the element in the parent document.
    /// </summary>
    /// <param name="parentDocument">The parent document instance.</param>
    /// <param name="parentDocumentIndex">The handle of the element in the parent document.</param>
    /// <returns>An instance of the implementing element type.</returns>
    static abstract T CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex);
#endif
}
