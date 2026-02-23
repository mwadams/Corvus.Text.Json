// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// A UTF-8 IRI reference value that has been parsed from a JSON document.
/// </summary>
/// <remarks>
/// This type should be used in a using declaration to ensure that the underlying memory is released when it is no longer needed.
/// </remarks>
public readonly ref struct Utf8IriReferenceReferenceValue
#if NET
    : IDisposable
#endif
{
    private readonly UnescapedUtf8JsonString _stringBacking;
    private readonly Utf8IriReference _iriReference;

    private Utf8IriReferenceReferenceValue(UnescapedUtf8JsonString stringBacking, Utf8IriReference iriReference)
    {
        _stringBacking = stringBacking;
        _iriReference = iriReference;
    }

    /// <summary>
    /// Gets the UTF-8 IRI reference value.
    /// </summary>
    public Utf8IriReference IriReference => _iriReference;

    /// <summary>
    /// Tries to get the value of the element at the specified index as a <see cref="Utf8IriReferenceReferenceValue"/>.
    /// </summary>
    /// <typeparam name="T">The type of the document.</typeparam>
    /// <param name="index">The index of the element.</param>
    /// <param name="value">The <see cref="Utf8IriReferenceReferenceValue"/> value.</param>
    /// <returns><c>true</c> if the value was retrieved; otherwise, <c>false</c>.</returns>
    [CLSCompliant(false)]
    public static bool TryGetValue<T>(in T jsonDocument, int index, out Utf8IriReferenceReferenceValue value)
        where T : IJsonDocument
    {

        if (jsonDocument.GetJsonTokenType(index) != JsonTokenType.String)
        {
            value = default;
            return false;
        }

        UnescapedUtf8JsonString stringBacking = jsonDocument.GetUtf8JsonString(index, JsonTokenType.String);

        if (!Utf8IriReference.TryCreateIriReference(stringBacking.Span, out Utf8IriReference iri))
        {
            stringBacking.Dispose();
            value = default;
            return false;
        }

        value = new Utf8IriReferenceReferenceValue(stringBacking, iri);
        return true;
    }

    /// <summary>
    /// Disposes the underlying resources used to store the UTF-8 string backing the IRI reference value.
    /// </summary>
    public void Dispose()
    {
        _stringBacking.Dispose();
    }
}
