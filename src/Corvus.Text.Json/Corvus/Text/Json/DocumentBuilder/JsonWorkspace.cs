// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    /// <summary>
    /// A workspace for manipulating JSON documents.
    /// </summary>
    public class JsonWorkspace : IDisposable
    {
        private static readonly JsonWriterOptions s_internalWriterOptions = new() { Indented = false };

        private IJsonDocument[] _documents;
        private readonly Dictionary<IJsonDocument, int> _documentIndices = [];
        private int _length;
        private bool _rented;

        internal JsonWorkspace(bool rented, int initialDocumentCapacity = 5, JsonWriterOptions? options = null)
        {
            _documents = ArrayPool<IJsonDocument>.Shared.Rent(initialDocumentCapacity);
            _length = 0;
            Options = options ?? s_internalWriterOptions;
            _rented = rented;
        }

        /// <summary>
        /// Gets the JsonWriterOptions
        /// </summary>
        public JsonWriterOptions Options { get; private set; }

        /// <summary>
        /// Creates an instance of a <see cref="JsonWorkspace"/>.
        /// </summary>
        /// <param name="initialDocumentCapacity">The initial document capacity for the workspace.</param>
        /// <param name="options">The ambient <see cref="JsonWriterOptions"/>.</param>
        /// <returns>The <see cref="JsonWorkspace"/>.</returns>
        public static JsonWorkspace Create(int initialDocumentCapacity = 5, JsonWriterOptions? options = null)
        {
            return JsonWorkspaceCache.RentWorkspace(initialDocumentCapacity, options);
        }

        /// <summary>
        /// Creates an instance of a <see cref="JsonWorkspace"/>.
        /// </summary>
        /// <param name="initialDocumentCapacity">The initial document capacity for the workspace.</param>
        /// <param name="options">The ambient <see cref="JsonWriterOptions"/>.</param>
        /// <returns>The <see cref="JsonWorkspace"/>.</returns>
        public static JsonWorkspace CreateUnrented(int initialDocumentCapacity = 5, JsonWriterOptions? options = null)
        {
            return new(false, initialDocumentCapacity, options);
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

#pragma warning disable CA1822 // Mark members as static
        public void ReturnWriterAndBuffer(Utf8JsonWriter writer, IByteBufferWriter bufferWriter)
        {
            Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
        }

        public void ReturnWriter(Utf8JsonWriter writer)
        {
            Utf8JsonWriterCache.ReturnWriter(writer);
        }
#pragma warning restore CA1822 // Mark members as static

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize

        public void Dispose()
        {
            if (_rented)
            {
                JsonWorkspaceCache.ReturnWorkspace(this);
            }
            else
            {
                if (_length > 0)
                {
                    // Dispose the documents
                    foreach (IJsonDocument document in _documents.AsSpan(0, _length))
                    {
                        document.Dispose();
                    }

                    ArrayPool<IJsonDocument>.Shared.Return(_documents);
                    _documentIndices.Clear();
                    _length = -1;
                }
            }
        }

#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize

        [CLSCompliant(false)]
        public JsonDocumentBuilder<TMutableElement> CreateDocumentBuilder<TElement, TMutableElement>(TElement sourceElement)
            where TElement : struct, IJsonElement<TElement>
            where TMutableElement : struct, IMutableJsonElement<TMutableElement>
        {
            JsonDocumentBuilder<TMutableElement> result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(sourceElement, index, convertToAlloc: false);
            return result;
        }

        [CLSCompliant(false)]
        public JsonDocumentBuilder<TElement> CreateDocumentBuilder<TElement>(int initialCapacity = 30, int initialValueBufferSize = 8192)
            where TElement : struct, IMutableJsonElement<TElement>
        {
            JsonDocumentBuilder<TElement> result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(index, initialCapacity, initialValueBufferSize);
            return result;
        }

        internal IJsonDocument GetDocument(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new ArgumentOutOfRangeException(SR.ArgumentOutOfRange_IndexMustBeLess);
            }

            return _documents[index];
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
                ArrayPool<IJsonDocument>.Shared.Return(documentsToReturn);
            }

            int result = _length;
            _documents[_length++] = document;
            _documentIndices.Add(document, result);
            return result;
        }

        internal void Reset(int initialDocumentCapacity, JsonWriterOptions? options)
        {
            Options = options ?? s_internalWriterOptions;
            if (_documents.Length < initialDocumentCapacity)
            {
                ArrayPool<IJsonDocument>.Shared.Return(_documents);
                _documents = ArrayPool<IJsonDocument>.Shared.Rent(initialDocumentCapacity);
            }
            else
            {
                if (_length > 0)
                {
                    Array.Clear(_documents, 0, _length);
                }
            }

            _documentIndices.Clear();
            _length = 0;
        }

        internal void ResetAllStateForCacheReuse()
        {
            if (_length >= 0)
            {
                foreach (IJsonDocument document in _documents.AsSpan(0, _length))
                {
                    document.Dispose();
                }

                Array.Clear(_documents, 0, _length);
                _length = -1;
                _documentIndices.Clear();
                return;
            }

            ThrowHelper.ThrowObjectDisposedException_JsonWorkspace();
        }

        internal static JsonWorkspace CreateEmptyInstanceForCaching() => new(true);
    }
}
