// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// A UTF-8 IRI value that has been parsed from a JSON document.
/// </summary>
/// <remarks>
/// This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.
/// </remarks>
public readonly ref struct Utf8IriValue
#if NET
    : IDisposable
#endif
{
    private readonly UnescapedUtf8JsonString _stringBacking;
    private readonly Utf8Iri _iri;

    private Utf8IriValue(UnescapedUtf8JsonString stringBacking, Utf8Iri iri)
    {
        _stringBacking = stringBacking;
        _iri = iri;
    }

    /// <summary>
    /// Gets the UTF-8 IRI value.
    /// </summary>
    public Utf8Iri Iri => _iri;

    /// <summary>
    /// Tries to get the value of the element at the specified index as a <see cref="Utf8IriValue"/>.
    /// </summary>
    /// <typeparam name="T">The type of the document.</typeparam>
    /// <param name="index">The index of the element.</param>
    /// <param name="value">The <see cref="Utf8IriValue"/> value.</param>
    /// <returns><c>true</c> if the value was retrieved; otherwise, <c>false</c>.</returns>
    [CLSCompliant(false)]
    public static bool TryGetValue<T>(in T jsonDocument, int index, out Utf8IriValue value)
        where T : IJsonDocument
    {
        if (jsonDocument.GetJsonTokenType(index) != JsonTokenType.String)
        {
           value = default;
            return false;
        }

        UnescapedUtf8JsonString stringBacking = jsonDocument.GetUtf8JsonString(index, JsonTokenType.String);

        if (!Utf8Iri.TryCreateIri(stringBacking.Span, out Utf8Iri iri))
        {
            stringBacking.Dispose();
            value = default;
            return false;
        }

        value = new Utf8IriValue(stringBacking, iri);
        return true;
    }

    /// <summary>
    /// Disposes the underlying resources used to store the UTF-8 string backing the IRI value.
    /// </summary>
    public void Dispose()
    {
        _stringBacking.Dispose();
    }
}
