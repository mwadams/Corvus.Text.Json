// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   An enumerable and enumerator for the contents of a JSON array.
    /// </summary>
    [DebuggerDisplay("{Current,nq}")]
    public struct ArrayEnumerator : IEnumerable<JsonElement>, IEnumerator<JsonElement>
    {
        private readonly IJsonDocument _targetDocument;
        private readonly int _initialIndex;
        private int _curIdx;
        private readonly int _endIdxOrVersion;

        internal ArrayEnumerator(IJsonDocument targetDocument, int initialIndex)
        {
            _targetDocument = targetDocument;
            _initialIndex = initialIndex;
            _curIdx = -1;

            _endIdxOrVersion = _targetDocument.GetEndIndex(_initialIndex, includeEndElement: false);
        }

        /// <inheritdoc />
        public JsonElement Current
        {
            get
            {
                if (_curIdx < 0)
                {
                    return default;
                }

                return new JsonElement(_targetDocument, _curIdx);
            }
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref="ArrayEnumerator"/> value that can be used to iterate
        ///   through the array.
        /// </returns>
        public ArrayEnumerator GetEnumerator()
        {
            ArrayEnumerator ator = this;
            ator._curIdx = -1;
            return ator;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator<JsonElement> IEnumerable<JsonElement>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Dispose()
        {
            _curIdx = _endIdxOrVersion;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _curIdx = -1;
        }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_curIdx >= _endIdxOrVersion)
            {
                return false;
            }

            if (_curIdx < 0)
            {
                _curIdx = _initialIndex + JsonDocument.DbRow.Size;
            }
            else
            {
                _curIdx = _targetDocument.GetEndIndex(_curIdx, includeEndElement: true);
            }

            return _curIdx < _endIdxOrVersion;
        }
    }
}
