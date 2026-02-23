// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// A UTF-8 URI value that has been parsed from a JSON document.
/// </summary>
/// <remarks>
/// This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.
/// </remarks>
public readonly ref struct Utf8UriValue
#if NET
    : IDisposable
#endif
{
    private readonly UnescapedUtf8JsonString _stringBacking;
    private readonly Utf8Uri _uri;

    private Utf8UriValue(UnescapedUtf8JsonString stringBacking, Utf8Uri uri)
    {
        _stringBacking = stringBacking;
        _uri = uri;
    }

    /// <summary>
    /// Gets the UTF-8 URI value.
    /// </summary>
    public Utf8Uri Uri => _uri;

    /// <summary>
    /// Tries to get the value of the element at the specified index as a <see cref="Utf8UriValue"/>.
    /// </summary>
    /// <typeparam name="T">The type of the document.</typeparam>
    /// <param name="index">The index of the element.</param>
    /// <param name="value">The <see cref="Utf8UriValue"/> value.</param>
    /// <returns><c>true</c> if the value was retrieved; otherwise, <c>false</c>.</returns>
    [CLSCompliant(false)]
    public static bool TryGetValue<T>(in T jsonDocument, int index, out Utf8UriValue value)
        where T : IJsonDocument
    {
        value = default;

        if (jsonDocument.GetJsonTokenType(index) != JsonTokenType.String)
        {
            return false;
        }

        UnescapedUtf8JsonString stringBacking = jsonDocument.GetUtf8JsonString(index, JsonTokenType.String);

        if (!Utf8Uri.TryCreateUri(stringBacking.Span, out Utf8Uri uri))
        {
            stringBacking.Dispose();
            return false;
        }

        value = new Utf8UriValue(stringBacking, uri);
        return true;
    }

    /// <summary>
    /// Disposes the underlying resources used to store the UTF-8 string backing the URI value.
    /// </summary>
    public void Dispose()
    {
        _stringBacking.Dispose();
    }
}
