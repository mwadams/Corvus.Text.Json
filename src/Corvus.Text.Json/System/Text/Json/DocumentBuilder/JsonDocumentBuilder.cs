// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Corvus.Text.Json
{
    public sealed partial class JsonDocumentBuilder : JsonDocument, IJsonDocument
    {
        private static readonly JsonWriterOptions InternalWriterOptions = new() {  Indented = false };
        private readonly JsonWorkspace _workspace;
        private int _parentWorkspaceIndex = -1;

        internal JsonDocumentBuilder(JsonWorkspace workspace)
        {
            _workspace = workspace;
        }

        bool IJsonDocument.IsDisposable => true;

        public override JsonElement RootElement => new JsonElement(this, 0);

        internal void Initialize<TElement>(TElement sourceElement, int parentWorkspaceIndex, bool convertToAlloc)
            where TElement : struct, IJsonElement<TElement>
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;
            byte[]? metadataDbBytes = null;
            sourceElement.CheckValidInstance();
            int metadataDbLength = sourceElement.ParentDocument.BuildRentedMetadataDb(sourceElement.ParentDocumentIndex, _workspace, ref metadataDbBytes);
            Debug.Assert(metadataDbBytes is not null);
            _parsedData = MetadataDb.CreateRented(metadataDbBytes, metadataDbLength, convertToAlloc);
        }
        internal void Initialize(int parentWorkspaceIndex, int initialElementCount)
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;
            _parsedData = MetadataDb.CreateRented(initialElementCount * DbRow.Size, convertToAlloc: false);
        }

        void IDisposable.Dispose()
        {
            if (_parentWorkspaceIndex == -1)
            {
                return;
            }

            base.Dispose();

            this._parentWorkspaceIndex = -1;
        }

        JsonTokenType IJsonDocument.GetJsonTokenType(int index)
        {
            CheckNotDisposed();

            return _parsedData.GetJsonTokenType(index);
        }

        void IJsonDocument.EnsurePropertyMap(int index)
        {
            CheckNotDisposed();
            EnsurePropertyMapUnsafe(index);
        }

        bool IJsonDocument.ValueIsEscaped(int index, bool isPropertyName)
        {
            CheckNotDisposed();

            return ValueIsEscapedUnsafe(index, isPropertyName);
        }

        int IJsonDocument.GetArrayLength(int index)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.StartArray, row.TokenType);

            return row.SizeOrLength;
        }

        int IJsonDocument.GetPropertyCount(int index)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.StartObject, row.TokenType);

            return row.SizeOrLength;
        }

        JsonElement IJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex)
        {
            CheckNotDisposed();

            return new JsonElement(this, GetArrayIndexElementUnsafe(currentIndex, arrayIndex));
        }

        int IJsonDocument.GetEndIndex(int index, bool includeEndElement)
        {
            CheckNotDisposed();
            return GetEndIndexUnsafe(index, includeEndElement);
        }

        RawUtf8JsonString IJsonDocument.GetRawValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();
            DbRow row = _parsedData.Get(index);

            // If the row is simple or complex, but it doesn't have a dynamic value, that means that
            // we can just write it as a slice of the parent document.
            if (!row.HasDynamicValue)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetRawValue(row.Location, includeQuotes);
            }

            // So we do have a dynamic value. If it is a simple value that means it's
            // a local dynamic value.
            if (row.IsSimpleValue)
            {
                return new(ReadRawSimpleDynamicValue(row.Location, includeQuotes));
            }

            // We have a complex value and it is not a simple slice of a parent
            // buffer somewhere, so we have to render it out to return it.
            // The length of our parsed data is a good guess at the initial size for the buffer (on the usual 12 bytes per token,
            // 12 bytes per row heuristic). It will reallocate if needs be, anyway.
            // In an ideal world, you are not doing this too often; in general you will be acquiring simple values
            // rather than complex ones - except for ToString() and so forth which are not intended to be high-performance
            // scenarios (not least because they allocate strings!)
            Utf8JsonWriter writer = Utf8JsonWriterCache.RentWriterAndBuffer(InternalWriterOptions, _parsedData.Length, out PooledByteBufferWriter bufferWriter);
            try
            {
                WriteElementToUnsafe(index, writer);
                writer.Flush();
                int length = bufferWriter.WrittenSpan.Length;
                byte[] additionalRentedBytes = ArrayPool<byte>.Shared.Rent(length);
                bufferWriter.WrittenSpan.CopyTo(additionalRentedBytes.AsSpan());
                return new(additionalRentedBytes.AsMemory(0, length));

            }
            finally
            {
                Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
            }
        }

        ReadOnlyMemory<byte> IJsonDocument.GetRawSimpleValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();

            return GetRawSimpleValueUnsafe(index, includeQuotes);
        }

        protected override ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index, bool includeQuotes)
        {
            DbRow row = _parsedData.Get(index);

            Debug.Assert(row.IsSimpleValue);

            if (row.HasDynamicValue)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetRawSimpleValue(row.Location, includeQuotes);
            }

            return ReadRawSimpleDynamicValue(row.Location, includeQuotes);
        }

        void IJsonDocument.WriteElementTo(
            int index,
            Utf8JsonWriter writer)
        {
            CheckNotDisposed();
            WriteElementToUnsafe(index, writer);
        }

        private void WriteElementToUnsafe(
            int index,
            Utf8JsonWriter writer)
        {
            throw new NotImplementedException();
        }

        internal void CompleteAllocations()
        {
            _parsedData.CompleteAllocations();
        }

        int IJsonDocument.BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[]? backing)
        {
            throw new NotImplementedException();
        }

        JsonElement IJsonDocument.CloneElement(int index) => throw new NotImplementedException();
        string IJsonDocument.GetNameOfPropertyValue(int index) => throw new NotImplementedException();
        ReadOnlySpan<byte> IJsonDocument.GetPropertyNameRaw(int index) => throw new NotImplementedException();
        string IJsonDocument.GetPropertyRawValueAsString(int valueIndex) => throw new NotImplementedException();
        string IJsonDocument.GetRawValueAsString(int index) => throw new NotImplementedException();
        string? IJsonDocument.GetString(int index, JsonTokenType expectedType) => throw new NotImplementedException();
        bool IJsonDocument.TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName) => throw new NotImplementedException();
        bool IJsonDocument.TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape) => throw new NotImplementedException();
        bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, [NotNullWhen(true)] out byte[]? value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out sbyte value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out byte value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out short value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out ushort value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out int value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out uint value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out long value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out ulong value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out double value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out float value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out decimal value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out DateTime value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out DateTimeOffset value) => throw new NotImplementedException();
        bool IJsonDocument.TryGetValue(int index, out Guid value) => throw new NotImplementedException();
        void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer) => throw new NotImplementedException();

        private void CheckNotDisposed()
        {
            if (_parentWorkspaceIndex < 0)
            {
                ThrowHelper.ThrowObjectDisposedException_JsonDocument();
            }
        }
    }
}
