// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Corvus.Text.Json
{
    public sealed partial class JsonDocumentBuilder : JsonDocument, IJsonDocument
    {
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
            this._parentWorkspaceIndex = -1;
            base.Dispose();
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

        internal void CompleteAllocations()
        {
            _parsedData.CompleteAllocations();
        }

        int IJsonDocument.BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, ref byte[]? backing)
        {
            throw new NotImplementedException();
        }

        JsonElement IJsonDocument.CloneElement(int index) => throw new NotImplementedException();
        JsonElement IJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex) => throw new NotImplementedException();
        int IJsonDocument.GetArrayLength(int index) => throw new NotImplementedException();
        int IJsonDocument.GetEndIndex(int index, bool includeEndElement) => throw new NotImplementedException();
        string IJsonDocument.GetNameOfPropertyValue(int index) => throw new NotImplementedException();
        int IJsonDocument.GetPropertyCount(int index) => throw new NotImplementedException();
        ReadOnlySpan<byte> IJsonDocument.GetPropertyNameRaw(int index) => throw new NotImplementedException();
        string IJsonDocument.GetPropertyRawValueAsString(int valueIndex) => throw new NotImplementedException();
        ReadOnlyMemory<byte> IJsonDocument.GetRawValue(int index, bool includeQuotes) => throw new NotImplementedException();
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
        bool IJsonDocument.ValueIsEscaped(int index, bool isPropertyName) => throw new NotImplementedException();
        void IJsonDocument.WriteElementTo(int index, Utf8JsonWriter writer) => throw new NotImplementedException();
        void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer) => throw new NotImplementedException();

        protected override ReadOnlyMemory<byte> GetRawValueUnsafe(int index, bool includeQuotes) => throw new NotImplementedException();

        private void CheckNotDisposed()
        {
            if (_parentWorkspaceIndex < 0)
            {
                ThrowHelper.ThrowObjectDisposedException_JsonDocument();
            }
        }
    }
}
