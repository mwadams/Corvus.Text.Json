// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   An enumerable and enumerator for the contents of a JSON array.
    /// </summary>
    [DebuggerDisplay("{Current,nq}")]
    [CLSCompliant(false)]
    public struct ArrayEnumerator<TItem> : IEnumerable<TItem>, IEnumerator<TItem>
        where TItem : struct, IJsonElement<TItem>
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
        public TItem Current
        {
            get
            {
                if (_curIdx < 0)
                {
                    return default;
                }

#if NET
                return TItem.CreateInstance(_targetDocument, _curIdx);
#else
                return (TItem)Activator.CreateInstance(typeof(TItem), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, binder: null, [_targetDocument, _curIdx], culture: null);
#endif
            }
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref="ArrayEnumerator"/> value that can be used to iterate
        ///   through the array.
        /// </returns>
        public ArrayEnumerator<TItem> GetEnumerator()
        {
            ArrayEnumerator<TItem> ator = this;
            ator._curIdx = -1;
            return ator;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() => GetEnumerator();

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
