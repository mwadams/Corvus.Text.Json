// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;

namespace Corvus.Text.Json
{
    /// <summary>
    /// A workspace for manipulating JSON documents.
    /// </summary>
    public class JsonWorkspace
        : IDisposable
    {
        private static readonly JsonWriterOptions InternalWriterOptions = new() { Indented = false };

        private IJsonDocument[] _documents;
        private Dictionary<IJsonDocument, int> _documentIndices = [];
        private int _length;

        public JsonWorkspace(int initialDocumentCapacity = 5, JsonWriterOptions? options = null)
        {
            _documents = ArrayPool<IJsonDocument>.Shared.Rent(initialDocumentCapacity);
            _length = 0;
            Options = options ?? InternalWriterOptions;
        }

        public JsonWriterOptions Options { get; }

        [CLSCompliant(false)]
        public IJsonDocument GetDocument(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new ArgumentOutOfRangeException(SR.ArgumentOutOfRange_IndexMustBeLess);
            }

            return _documents[index];
        }

        public Utf8JsonWriter RentWriterAndBuffer(int defaultBufferSize, out IByteBufferWriter bufferWriter)
        {
            Utf8JsonWriter result = Utf8JsonWriterCache.RentWriterAndBuffer(Options, defaultBufferSize, out PooledByteBufferWriter writer);
            bufferWriter = writer;
            return result;
        }

        public Utf8JsonWriter RentWriter(IBufferWriter<byte> bufferWriter)
        {
            return Utf8JsonWriterCache.RentWriter(Options, bufferWriter);
        }

        public void ReturnWriterAndBuffer(Utf8JsonWriter writer, IByteBufferWriter bufferWriter)
        {
            Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
        }

        public void ReturnWriter(Utf8JsonWriter writer)
        {
            Utf8JsonWriterCache.ReturnWriter(writer);
        }

        public void Dispose()
        {
            if (_length >= 0)
            {
                ArrayPool<IJsonDocument>.Shared.Return(_documents);
               _length = -1;
                return;
            }

            ThrowHelper.ThrowObjectDisposedException_JsonWorkspace();
        }

        [CLSCompliant(false)]
        public JsonDocumentBuilder<TMutableElement> CreateDocument<TElement, TMutableElement>(TElement sourceElement)
            where TElement : struct, IJsonElement<TElement>
            where TMutableElement : struct, IMutableJsonElement<TMutableElement>
        {
            JsonDocumentBuilder<TMutableElement> result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(sourceElement, index, convertToAlloc: false);
            return result;
        }

        [CLSCompliant(false)]
        public JsonDocumentBuilder<TElement> CreateDocument<TElement>(int initialCapacity = 30, int initialValueBufferSize = 8192)
            where TElement : struct, IMutableJsonElement<TElement>
        {
            JsonDocumentBuilder<TElement> result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(index, initialCapacity, initialValueBufferSize);
            return result;
        }

        internal int GetDocumentIndex(IJsonDocument document)
        {
            if (_documentIndices.TryGetValue(document, out int index))
            {
                return index;
            }

            if (_documents.Length == _length)
            {
                IJsonDocument[] newDocuments = ArrayPool<IJsonDocument>.Shared.Rent(_length * 2);
                Array.Copy(_documents, newDocuments, _length);
                IJsonDocument[] documentsToReturn = _documents;
                _documents = newDocuments;
                ArrayPool<IJsonDocument>.Shared.Return(_documents);
            }

            int result = _length;
            _documents[_length++] = document;
            _documentIndices.Add(document, result);
            return result;
        }
    }
}
