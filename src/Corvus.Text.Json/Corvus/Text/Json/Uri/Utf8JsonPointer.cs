// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

public readonly ref struct Utf8JsonPointer
{
    private readonly ReadOnlySpan<byte> _jsonPointer;

    private Utf8JsonPointer(ReadOnlySpan<byte> jsonPointer)
    {
        _jsonPointer = jsonPointer;
        IsValid = Utf8JsonPointerTools.Validate(jsonPointer);
    }

    /// <summary>
    /// Gets a value indicating whether this is a valid IRI.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Tries to create a new UTF-8 JSON Pointer from the specified UTF-8 bytes.
    /// </summary>
    /// <param name="jsonPointer">The UTF-8 bytes from which to create the UTF-8 JSON Pointer.</param>
    /// <param name="utf8JsonPointer">When this method returns, contains the created UTF-8 JSON Pointer if successful; otherwise, the default value.</param>
    /// <returns><see langword="true"/> if the UTF-8 JSON Pointer was created successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryCreateJsonPointer(ReadOnlySpan<byte> jsonPointer, out Utf8JsonPointer utf8JsonPointer)
    {
        utf8JsonPointer = new(jsonPointer);
        return utf8JsonPointer.IsValid;
    }

    /// <summary>
    /// Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the value at that path if it exists.
    /// </summary>
    /// <typeparam name="T">The type of the element at the root of the path.</typeparam>
    /// <typeparam name="TResult">The type of the element at the target.</typeparam>
    /// <param name="jsonElement">The element at the root of the path.</param>
    /// <param name="value">The value at the target path if it exists.</param>
    /// <returns><see langword="true"/> if the value was resolved successfully; otherwise, <see langword="false"/>.</returns>
    [CLSCompliant(false)]
    public bool TryResolve<T, TResult>(in T jsonElement, out TResult value)
        where T : struct, IJsonElement<T>
        where TResult : struct, IJsonElement<TResult>
    {
        if (!IsValid)
        {
            value = default;
            return false;
        }

        jsonElement.CheckValidInstance();

        return jsonElement.ParentDocument.TryResolveJsonPointer(_jsonPointer, jsonElement.ParentDocumentIndex, out value);
    }
}
