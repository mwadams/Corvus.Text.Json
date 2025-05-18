// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    ///   An enumerable and enumerator for the properties of a JSON object.
    /// </summary>
    [DebuggerDisplay("{CurrentIndex,nq}")]
    [CLSCompliant(false)]
    public struct ObjectEnumerator
    {
        private readonly IJsonDocument _targetDocument;
        private readonly int _initialIndex;
        private int _curIdx;
        private readonly int _endIdxOrVersion;

        public ObjectEnumerator(IJsonDocument targetDocument, int initialIndex)
        {
            _targetDocument = targetDocument;
            _initialIndex = initialIndex;
            _curIdx = -1;

            _endIdxOrVersion = _targetDocument.GetEndIndex(_initialIndex, includeEndElement: false);
        }

        /// <inheritdoc />
        public int CurrentIndex
        {
            get
            {
                return _curIdx;
            }
        }

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
