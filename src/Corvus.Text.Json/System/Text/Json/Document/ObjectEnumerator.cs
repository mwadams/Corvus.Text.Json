// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   An enumerable and enumerator for the properties of a JSON object.
    /// </summary>
    [DebuggerDisplay("{Current,nq}")]
    public struct ObjectEnumerator : IEnumerable<JsonProperty>, IEnumerator<JsonProperty>
    {
        private readonly IJsonDocument _targetDocument;
        private readonly int _initialIndex;
        private int _curIdx;
        private readonly int _endIdxOrVersion;

        internal ObjectEnumerator(IJsonDocument targetDocument, int initialIndex)
        {
            _targetDocument = targetDocument;
            _initialIndex = initialIndex;
            _curIdx = -1;

            _endIdxOrVersion = _targetDocument.GetEndIndex(_initialIndex, includeEndElement: false);
        }

        /// <inheritdoc />
        public JsonProperty Current
        {
            get
            {
                if (_curIdx < 0)
                {
                    return default;
                }

                return new JsonProperty(new JsonElement(_targetDocument, _curIdx));
            }
        }

        /// <summary>
        ///   Returns an enumerator that iterates the properties of an object.
        /// </summary>
        /// <returns>
        ///   An <see cref="ObjectEnumerator"/> value that can be used to iterate
        ///   through the object.
        /// </returns>
        /// <remarks>
        ///   The enumerator will enumerate the properties in the order they are
        ///   declared, and when an object has multiple definitions of a single
        ///   property they will all individually be returned (each in the order
        ///   they appear in the content).
        /// </remarks>
        public ObjectEnumerator GetEnumerator()
        {
            ObjectEnumerator ator = this;
            ator._curIdx = -1;
            return ator;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator<JsonProperty> IEnumerable<JsonProperty>.GetEnumerator() => GetEnumerator();

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

            // _curIdx is now pointing at a property name, move one more to get the value
            _curIdx += JsonDocument.DbRow.Size;

            return _curIdx < _endIdxOrVersion;
        }
    }
}
