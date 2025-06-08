// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;
using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace Corvus.Text.Json.Tests;

internal class DummyDocument : IJsonDocument
{
    private readonly JsonTokenType _tokenType;

    public bool IsDisposable => false;
    public bool IsImmutable => true;

    public DummyDocument(JsonTokenType tokenType)
    {
        _tokenType = tokenType;
    }

    public void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db) { }

    public int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, out byte[] rentedBacking) { rentedBacking = []; return 0; }
    public JsonElement CloneElement(int index) { return default; }
    public TElement CloneElement<TElement>(int index) where TElement : struct, IJsonElement<TElement> { return default; }
    public void Dispose() { }
    public void EnsurePropertyMap(int index) { }
    public JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex) { return default; }
    public TElement GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex) where TElement : struct, IJsonElement<TElement> { return default; }
    public int GetArrayLength(int index) { return 0; }
    public int GetDbSize(int index, bool includeEndElement) { return 0; }
    public JsonTokenType GetJsonTokenType(int index) { return _tokenType; }
    public string GetNameOfPropertyValue(int index) { return string.Empty; }
    public int GetPropertyCount(int index) { return 0; }
    public ReadOnlySpan<byte> GetPropertyNameRaw(int index) { return default; }
    public string GetPropertyRawValueAsString(int valueIndex) { return string.Empty; }
    public ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes) { return default; }
    public RawUtf8JsonString GetRawValue(int index, bool includeQuotes) { return default; }
    public string GetRawValueAsString(int index) { return string.Empty; }
    public string GetString(int index, JsonTokenType expectedType) { return string.Empty; }
    public UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType) { return default; }
    public bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName) { return false; }
    public bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape) { return false; }
    public bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value) { value = default; return false; }
    public bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value) { value = default; return false; }
    public bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, out TElement value) where TElement : struct, IJsonElement<TElement> { value = default; return false; }
    public bool TryGetValue(int index, [NotNullWhen(true)] out byte[] value) { value = default; return false; }
    public bool TryGetValue(int index, out sbyte value) { value = default; return false; }
    public bool TryGetValue(int index, out byte value) { value = default; return false; }
    public bool TryGetValue(int index, out short value) { value = default; return false; }
    public bool TryGetValue(int index, out ushort value) { value = default; return false; }
    public bool TryGetValue(int index, out int value) { value = default; return false; }
    public bool TryGetValue(int index, out uint value) { value = default; return false; }
    public bool TryGetValue(int index, out long value) { value = default; return false; }
    public bool TryGetValue(int index, out ulong value) { value = default; return false; }
    public bool TryGetValue(int index, out double value) { value = default; return false; }
    public bool TryGetValue(int index, out float value) { value = default; return false; }
    public bool TryGetValue(int index, out decimal value) { value = default; return false; }
    public bool TryGetValue(int index, out DateTime value) { value = default; return false; }
    public bool TryGetValue(int index, out DateTimeOffset value) { value = default; return false; }
    public bool TryGetValue(int index, out OffsetDateTime value) { value = default; return false; }
    public bool TryGetValue(int index, out OffsetDate value) { value = default; return false; }
    public bool TryGetValue(int index, out OffsetTime value) { value = default; return false; }
    public bool TryGetValue(int index, out LocalDate value) { value = default; return false; }
    public bool TryGetValue(int index, out Period value) { value = default; return false; }
    public bool TryGetValue(int index, out Guid value) { value = default; return false; }
#if NET
    public bool TryGetValue(int index, out Int128 value) { value = default; return false; }
    public bool TryGetValue(int index, out UInt128 value) { value = default; return false; }
    public bool TryGetValue(int index, out Half value) { value = default; return false; }
#endif
    public bool ValueIsEscaped(int index, bool isPropertyName) { return false; }
    public void WriteElementTo(int index, Utf8JsonWriter writer) { }
    public void WritePropertyName(int index, Utf8JsonWriter writer) { }
}
