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
        private IJsonDocument[] _documents;
        private Dictionary<IJsonDocument, int> _documentIndices = [];
        private int _length;

        public JsonWorkspace(int initialDocumentCapacity = 5)
        {
            _documents = ArrayPool<IJsonDocument>.Shared.Rent(initialDocumentCapacity);
            _length = 0;
        }

        [CLSCompliant(false)]
        public IJsonDocument GetDocument(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new ArgumentOutOfRangeException(SR.ArgumentOutOfRange_IndexMustBeLess);
            }

            return _documents[index];
        }

        public void Dispose()
        {
            if (_length >= 0)
            {
                ArrayPool<IJsonDocument>.Shared.Return(_documents);
               _length = -1;
            }

            ThrowHelper.ThrowObjectDisposedException_JsonWorkspace();
        }

        [CLSCompliant(false)]
        public JsonDocumentBuilder CreateBuilder<TElement>(TElement sourceElement)
            where TElement : struct, IJsonElement<TElement>
        {
            JsonDocumentBuilder result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(sourceElement, index, convertToAlloc: false);
            return result;
        }

        [CLSCompliant(false)]
        public JsonDocumentBuilder CreateBuilder(int initialCapacity = 30)
        {
            JsonDocumentBuilder result = new(this);
            int index = GetDocumentIndex(result);
            result.Initialize(index, initialCapacity);
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
