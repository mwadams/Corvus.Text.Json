// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// The interface explicitly implemented by JSON Document providers
    /// for internal use only.
    /// </summary>
    [CLSCompliant(false)]
    public interface IJsonDocument : IDisposable
    {
        void EnsurePropertyMap(int index);

        bool IsDisposable { get; }

        bool IsImmutable { get; }

        JsonTokenType GetJsonTokenType(int index);
        JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex);
        TElement GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex) where TElement : struct, IJsonElement<TElement>;
        int GetArrayLength(int index);
        int GetPropertyCount(int index);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value);
        bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, out TElement value) where TElement : struct, IJsonElement<TElement>;
        string? GetString(int index, JsonTokenType expectedType);
        UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType);
        bool TryGetValue(int index, [NotNullWhen(true)] out byte[]? value);
        bool TryGetValue(int index, out sbyte value);
        bool TryGetValue(int index, out byte value);
        bool TryGetValue(int index, out short value);
        bool TryGetValue(int index, out ushort value);
        bool TryGetValue(int index, out int value);
        bool TryGetValue(int index, out uint value);
        bool TryGetValue(int index, out long value);
        bool TryGetValue(int index, out ulong value);
        bool TryGetValue(int index, out double value);
        bool TryGetValue(int index, out float value);
        bool TryGetValue(int index, out decimal value);
        bool TryGetValue(int index, out DateTime value);
        bool TryGetValue(int index, out DateTimeOffset value);
        bool TryGetValue(int index, out Guid value);
#if NET
        bool TryGetValue(int index, out Int128 value);
        bool TryGetValue(int index, out UInt128 value);
        bool TryGetValue(int index, out Half value);
#endif
        string GetNameOfPropertyValue(int index);
        ReadOnlySpan<byte> GetPropertyNameRaw(int index);
        string GetRawValueAsString(int index);
        string GetPropertyRawValueAsString(int valueIndex);
        RawUtf8JsonString GetRawValue(int index, bool includeQuotes);
        ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes);
        bool ValueIsEscaped(int index, bool isPropertyName);
        bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName);
        bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape);
        void WriteElementTo(int index, Utf8JsonWriter writer);
        void WritePropertyName(int index, Utf8JsonWriter writer);
        JsonElement CloneElement(int index);
        TElement CloneElement<TElement>(int index) where TElement : struct, IJsonElement<TElement>;
        int GetDbSize(int index, bool includeEndElement);
        int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, out byte[] rentedBacking);
        void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db);
    }
}
