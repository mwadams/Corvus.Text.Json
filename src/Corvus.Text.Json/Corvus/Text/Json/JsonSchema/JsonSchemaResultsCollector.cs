// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    public sealed class JsonSchemaResultsCollector : IJsonSchemaResultsCollector
    {
        // Maximum message length is 1024 bytes
        private const int MaxMessageLength = 1024;
        private const int ResultHeaderSize = 4;
        private const int MaxPathSegmentLength = 1024;

        [StructLayout(LayoutKind.Sequential)]
        internal readonly struct ValueRange
        {
            public readonly int Start;
            public readonly int End;

            public ValueRange(int start, int end)
            {
                Start = start;
                End = end;
            }

            public int Length => End - Start;
        }

        [StructLayout(LayoutKind.Sequential)]
        private readonly struct ValueRangeWithCommitIndex
        {
            public readonly int Start;
            public readonly int End;
            public readonly int CommitIndex;

            public ValueRangeWithCommitIndex(int start, int end, int commitIndex)
            {
                Start = start;
                End = end;
                CommitIndex = commitIndex;
            }

            public int Length => End - Start;
        }

        // We assume an initial estimate of 32 bytes per path segment, and 128 bytes per message
        private const int s_bytesPerPathSegment = 32;
        private const int s_bytesPerMessage = 128;
        private byte[] _utf8StringBacking;
        private int _utf8StringBackingLength;

        private ValueRange _currentEvaluationPathRange;
        private ValueRange _currentDocumentEvaluationPathRange;
        private ValueRange _currentSchemaEvaluationPathRange;

        private byte[] _evaluationPath;
        private byte[] _schemaEvaluationPath;
        private byte[] _documentEvaluationPath;
        private int _evaluationPathLength;
        private int _schemaEvaluationPathLength;
        private int _documentEvaluationPathLength;
        private int _sequenceNumber;

        private readonly bool _rented;
        private readonly JsonSchemaResultsLevel _level;

        // indices for the end of the path stack at each level

        // When pushing items onto a path stack, we just append it if it is an append
        // or push the whole path if it is change of base. We push the previous start/end
        // range onto the corresponding stack, and then update the _currentXYZPathRange.
        ValueStack<ValueRange> _evaluationPathStack;
        ValueStack<ValueRange> _documentEvaluationPathStack;
        ValueStack<ValueRange> _schemaEvaluationPathStack;
        ValueStack<ValueRangeWithCommitIndex> _resultStack;
        ValueStack<ValueRange> _committedResultStack;

        internal JsonSchemaResultsCollector(bool rented, JsonSchemaResultsLevel level, int estimatedCapacity = 30)
        {
            if (estimatedCapacity <= 0)
            {
                // Force to a reasonable basic estimated capacity
                estimatedCapacity = 30;
            }

            _rented = rented;
            _level = level;

            // We will allow an additional "MaxPathSegmentLength" of capacity to avoid
            // enlarging with our max test each time.
            int pathCapacity = (estimatedCapacity * s_bytesPerPathSegment) + MaxPathSegmentLength;

            _evaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);
            _schemaEvaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);
            _documentEvaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);

            if (level == JsonSchemaResultsLevel.Basic)
            {
                _utf8StringBackingLength = -1;
                _utf8StringBacking = [];
            }
            else
            {
                int messageCapacity = estimatedCapacity * s_bytesPerMessage;
                _utf8StringBacking = ArrayPool<byte>.Shared.Rent(messageCapacity);
            }

            // We will just use the default max depth for a JSON document for the evaluation path depth
            _evaluationPathStack = new ValueStack<ValueRange>(JsonDocumentOptions.DefaultMaxDepth);
            _documentEvaluationPathStack = new ValueStack<ValueRange>(JsonDocumentOptions.DefaultMaxDepth);
            _schemaEvaluationPathStack = new ValueStack<ValueRange>(JsonDocumentOptions.DefaultMaxDepth);

            _resultStack = new ValueStack<ValueRangeWithCommitIndex>(JsonDocumentOptions.DefaultMaxDepth);
            _committedResultStack = new ValueStack<ValueRange>(JsonDocumentOptions.DefaultMaxDepth);
        }


        /// <summary>
        /// Creates an instance of a <see cref="JsonWorkspace"/>, rented from the pool.
        /// </summary>
        /// <param name="level">Controls the verbosity of the results output.</param>
        /// <param name="estimatedCapacity">An estimate of the number of results rows that will produce.</param>
        /// <returns>The <see cref="JsonSchemaResultsCollector"/>.</returns>
        public static JsonSchemaResultsCollector Create(JsonSchemaResultsLevel level, int estimatedCapacity = 30)
        {
            return JsonSchemaResultsCollectorCache.RentResultsCollector(level, estimatedCapacity);
        }

        /// <summary>
        /// Creates an instance of a <see cref="JsonWorkspace"/>.
        /// </summary>
        /// <param name="level">Controls the verbosity of the results output.</param>
        /// <param name="estimatedCapacity">An estimate of the number of results rows that will produce.</param>
        /// <returns>The <see cref="JsonSchemaResultsCollector"/>.</returns>
        public static JsonSchemaResultsCollector CreateUnrented(JsonSchemaResultsLevel level, int estimatedCapacity = 30)
        {
            return new(false, level, estimatedCapacity);
        }

        [DebuggerDisplay("{DebuggerDisplay,nq}")]
        public readonly ref struct Result
        {
            private readonly JsonSchemaResultsCollector _collector;
            private readonly ValueRange _evaluationLocation;
            private readonly ValueRange _schemaEvaluationLocation;
            private readonly ValueRange _documentEvaluationLocation;
            private readonly ValueRange _message;

            internal Result(
                JsonSchemaResultsCollector collector,
                bool isMatch,
                ValueRange evaluationLocation,
                ValueRange schemaEvaluationLocation,
                ValueRange documentEvaluationLocation,
                ValueRange message)
            {
                _collector = collector;
                IsMatch = isMatch;
                _evaluationLocation = evaluationLocation;
                _schemaEvaluationLocation = schemaEvaluationLocation;
                _documentEvaluationLocation = documentEvaluationLocation;
                _message = message;
            }

            public bool IsMatch { get; }

            public ReadOnlySpan<byte> Message => _collector.GetResultString(_message);
            public ReadOnlySpan<byte> EvaluationLocation => _collector.GetResultString(_evaluationLocation);
            public ReadOnlySpan<byte> SchemaEvaluationLocation => _collector.GetResultString(_schemaEvaluationLocation);
            public ReadOnlySpan<byte> DocumentEvaluationLocation => _collector.GetResultString(_documentEvaluationLocation);

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string DebuggerDisplay => $"Match: {IsMatch} {JsonReaderHelper.GetTextFromUtf8(Message)}{(Message.Length > 0 ? " " : "")}({JsonReaderHelper.GetTextFromUtf8(EvaluationLocation)}, {JsonReaderHelper.GetTextFromUtf8(DocumentEvaluationLocation)}, {JsonReaderHelper.GetTextFromUtf8(SchemaEvaluationLocation)})";
        }

        /// <summary>
        ///   An enumerable and enumerator for the results.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        [CLSCompliant(false)]
        public struct ResultsEnumerator
        {
            private readonly JsonSchemaResultsCollector _collector;
            private int _curIdx;
            private int _endIdx;

            public ResultsEnumerator(JsonSchemaResultsCollector collector)
            {
                _collector = collector;
                _curIdx = -1;
                _endIdx = collector._committedResultStack.Length;
            }

            /// <inheritdoc />
            public Result Current
            {
                get
                {
                    return _curIdx < _endIdx ? _collector.ReadResult(_curIdx) : default;
                }
            }

            /// <inheritdoc />
            public void Dispose()
            {
                _curIdx = -1;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _curIdx = _endIdx;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                if (_curIdx >= _endIdx)
                {
                    return false;
                }

                _curIdx++;

                return _curIdx < _endIdx;
            }
        }

        [CLSCompliant(false)]
        public ResultsEnumerator EnumerateResults()
        {
            return new(this);
        }

        public void Dispose()
        {
            if (_rented)
            {
                JsonSchemaResultsCollectorCache.ReturnResultsCollector(this);
            }
            else
            {
                // We need to clear all of these buffers as they contain sensitive data
                // The entire buffer needs to be cleared, because we do not track the
                // maximum length we have used as we push and pop path elements
                ArrayPool<byte>.Shared.Return(_documentEvaluationPath, true);
                ArrayPool<byte>.Shared.Return(_schemaEvaluationPath, true);
                ArrayPool<byte>.Shared.Return(_evaluationPath, true);
                if (_utf8StringBacking.Length > 0)
                {
                    // We only need to clear the length we have used because this
                    // is a grow-only buffer
                    _utf8StringBacking.AsSpan(0, _utf8StringBacking.Length).Clear();
                    ArrayPool<byte>.Shared.Return(_utf8StringBacking);
                }

                _evaluationPathStack.Dispose();
                _documentEvaluationPathStack.Dispose();
                _schemaEvaluationPathStack.Dispose();

                _resultStack.Dispose();
                _committedResultStack.Dispose();
            }
        }


        internal void Reset(JsonSchemaResultsLevel level, int estimatedCapacity)
        {
            int pathCapacity = estimatedCapacity * s_bytesPerPathSegment; // we will assume 30 characters per path segment

            if (_documentEvaluationPath.Length < pathCapacity)
            {
                // We need to clear the buffer as it contain sensitive data
                // The entire buffer needs to be cleared, because we do not track the
                // maximum length we have used as we push and pop path elements
                ArrayPool<byte>.Shared.Return(_documentEvaluationPath, true);
                _documentEvaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);
            }

            if (_schemaEvaluationPath.Length < pathCapacity)
            {
                // We need to clear the buffer as it contain sensitive data
                // The entire buffer needs to be cleared, because we do not track the
                // maximum length we have used as we push and pop path elements
                ArrayPool<byte>.Shared.Return(_schemaEvaluationPath, true);
                _schemaEvaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);
            }

            if (_evaluationPath.Length < pathCapacity)
            {
                // We need to clear the buffer as it contain sensitive data
                // The entire buffer needs to be cleared, because we do not track the
                // maximum length we have used as we push and pop path elements
                ArrayPool<byte>.Shared.Return(_evaluationPath, true);
                _evaluationPath = ArrayPool<byte>.Shared.Rent(pathCapacity);
            }


            _documentEvaluationPathLength = 0;
            _schemaEvaluationPathLength = 0;
            _evaluationPathLength = 0;

            if (level == JsonSchemaResultsLevel.Basic)
            {
                if (_utf8StringBackingLength != -1)
                {
                    // We only need to clear the length we have used because this
                    // is a grow-only buffer
                    _utf8StringBacking.AsSpan(0, _utf8StringBacking.Length).Clear();
                    ArrayPool<byte>.Shared.Return(_utf8StringBacking);
                    _utf8StringBackingLength = -1;
                }
            }
            else
            {
                int messageCapacity = estimatedCapacity * s_bytesPerMessage;
                if (_utf8StringBacking.Length < messageCapacity)
                {
                    // We only need to clear the length we have used because this
                    // is a grow-only buffer
                    _utf8StringBacking.AsSpan(0, _utf8StringBacking.Length).Clear();
                    ArrayPool<byte>.Shared.Return(_utf8StringBacking);
                    _utf8StringBacking = ArrayPool<byte>.Shared.Rent(messageCapacity);
                }

                _utf8StringBackingLength = 0;
            }

            // And reset the stacks
            _evaluationPathStack.Length = 0;
            _documentEvaluationPathStack.Length = 0;
            _schemaEvaluationPathStack.Length = 0;
            _resultStack.Length = 0;
            _committedResultStack.Length = 0;
        }

        internal void ResetAllStateForCacheReuse()
        {
            _documentEvaluationPathLength = 0;
            _schemaEvaluationPathLength = 0;
            _evaluationPathLength = 0;
            if (_utf8StringBackingLength >= 0)
            {
                _utf8StringBackingLength = 0;
            }

            _evaluationPathStack.Length = 0;
            _documentEvaluationPathStack.Length = 0;
            _schemaEvaluationPathStack.Length = 0;
            _resultStack.Length = 0;
            _committedResultStack.Length = 0;
        }

        internal static JsonSchemaResultsCollector CreateEmptyInstanceForCaching() => new(true, JsonSchemaResultsLevel.Basic, 30);

        /*
         * Results come as a block of 4 consecutive strings in the _utf8StringBacking array
         * The first string is the result message, the second is the evaluation path,
         * the third is the document evaluation path, and the fourth is the schema evaluation path.
         */
        private void WriteResult(bool match, JsonSchemaMessageProvider? messageProvider)
        {
            bool writeMessage = EnsureCapacityForResult(match);
            int written = 0;

            // We only write out if we both have a message provider *and* we are
            // expecting to write a message given the level settings
            if (messageProvider is not null && writeMessage)
            {
                messageProvider(_utf8StringBacking.AsSpan(_utf8StringBackingLength + ResultHeaderSize), out written);
            }

            WriteHeaderAndPathsAndUpdateResultStack(match, written);
        }

        private void WriteResult<TProviderContext>(bool match, TProviderContext context, JsonSchemaMessageProvider<TProviderContext>? messageProvider)
        {
            bool writeMessage = EnsureCapacityForResult(match);
            int written = 0;

            // We only write out if we both have a message provider *and* we are
            // expecting to write a message given the level settings
            if (messageProvider is not null && writeMessage)
            {
                if (!messageProvider(context, _utf8StringBacking.AsSpan(_utf8StringBackingLength + ResultHeaderSize), out written))
                {
                    ThrowHelper.ThrowArgumentException_DestinationTooShort();
                }
            }

            WriteHeaderAndPathsAndUpdateResultStack(match, written);
        }

        private void WriteHeaderAndPathsAndUpdateResultStack(bool match, int written)
        {
            // We save the top nybble for the match 0b0010 is match true, 0b0001 is match false
            // 0b0000 is reserved for the result path strings
            // This means we have this many bytes free for a message.
            if (written > 0x7000_0000)
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }


            int writtenAndMatch = written | (match ? 0x2000_0000 : 0x1000_0000);

#if NET
            BitConverter.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), writtenAndMatch);
#else
            BitConverterEx.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), writtenAndMatch);
#endif
            _utf8StringBackingLength += written + ResultHeaderSize;

            // Pop the current context
            ValueRangeWithCommitIndex valueRange = _resultStack.Pop();
            // And push it back with the updated end
            _resultStack.Append(new ValueRangeWithCommitIndex(valueRange.Start, _utf8StringBackingLength, valueRange.CommitIndex));

            // Finally, write the paths to the results - first the header containing the length,
            // then the rest of the string
#if NET
            BitConverter.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentEvaluationPathRange.Length);
#else
            BitConverterEx.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentEvaluationPathRange.Length);
#endif
            _evaluationPath.AsSpan(_currentEvaluationPathRange.Start, _currentEvaluationPathRange.Length)
                .CopyTo(_utf8StringBacking.AsSpan(_utf8StringBackingLength + ResultHeaderSize));
            _utf8StringBackingLength += _currentEvaluationPathRange.Length + ResultHeaderSize;

#if NET
            BitConverter.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentDocumentEvaluationPathRange.Length);
#else
            BitConverterEx.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentDocumentEvaluationPathRange.Length);
#endif
            _documentEvaluationPath.AsSpan(_currentDocumentEvaluationPathRange.Start, _currentDocumentEvaluationPathRange.Length)
                .CopyTo(_utf8StringBacking.AsSpan(_utf8StringBackingLength + ResultHeaderSize));
            _utf8StringBackingLength += _currentDocumentEvaluationPathRange.Length + ResultHeaderSize;

#if NET
            BitConverter.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentSchemaEvaluationPathRange.Length);
#else
            BitConverterEx.TryWriteBytes(_utf8StringBacking.AsSpan(0, 4), _currentSchemaEvaluationPathRange.Length);
#endif
            _schemaEvaluationPath.AsSpan(_currentSchemaEvaluationPathRange.Start, _currentSchemaEvaluationPathRange.Length)
                .CopyTo(_utf8StringBacking.AsSpan(_utf8StringBackingLength + ResultHeaderSize));
            _utf8StringBackingLength += _currentSchemaEvaluationPathRange.Length + ResultHeaderSize;
        }

        private Result ReadResult(int index)
        {
            Debug.Assert(index >= 0 && index < _committedResultStack.Length);

            ValueRange resultRange = _committedResultStack[index];
            int curIndex = resultRange.Start;

            // First, read the initial header
            int header = BitConverter.ToInt32(_utf8StringBacking, curIndex);
            bool isMatch = (header & 0x3000_0000) == 0x2000_0000; // 0b0010 is match true, 0b0001 is match false
            int length = header & 0x7FFF_FFFF;

            ValueRange messageRange = new(curIndex + 4, curIndex + 4 + length);
            curIndex += 4 + length;

            header = BitConverter.ToInt32(_utf8StringBacking, curIndex);
            length = header & 0x7FFF_FFFF;
            ValueRange evaluationLocationRange = new(curIndex + 4, curIndex + 4 + length);
            curIndex += 4 + length;

            header = BitConverter.ToInt32(_utf8StringBacking, curIndex);
            length = header & 0x7FFF_FFFF;
            ValueRange documentEvaluationLocationRange = new(curIndex + 4, curIndex + 4 + length);
            curIndex += 4 + length;

            header = BitConverter.ToInt32(_utf8StringBacking, curIndex);
            length = header & 0x7FFF_FFFF;
            ValueRange schemaEvaluationLocationRange = new(curIndex + 4, curIndex + 4 + length);
            curIndex += 4 + length;

            Debug.Assert(curIndex == resultRange.End);

            return new(this, isMatch, messageRange, evaluationLocationRange, schemaEvaluationLocationRange, documentEvaluationLocationRange);
        }

        private ReadOnlySpan<byte> GetResultString(ValueRange message) => message.Start >= 0 && message.Length < _utf8StringBacking.Length ? _utf8StringBacking.AsSpan(message.Start, message.Length) : default;

        private bool EnsureCapacityForResult(bool match)
        {
            int messageLength = 0;
            if (_level == JsonSchemaResultsLevel.Verbose || (match && _level >= JsonSchemaResultsLevel.Detailed))
            {
                // we are only writing messages if we are either verbose, or detailed and we have a match.
                messageLength = MaxMessageLength;
            }

            // 32 = metadata for 4 strings [the result with message + the 3 path strings]
            // Then we need a max message length plus the actual path lengths
            int totalLength = _utf8StringBackingLength + messageLength + 32 + _currentEvaluationPathRange.Length + _currentDocumentEvaluationPathRange.Length + _currentSchemaEvaluationPathRange.Length;

            if (_utf8StringBacking.Length < totalLength)
            {
                Enlarge(totalLength, ref _utf8StringBacking, _utf8StringBackingLength);
            }

            return messageLength > 0;
        }

        private static void Enlarge(int additionalLength, ref byte[] backing, int usedLength)
        {
            byte[] toReturn = backing;

            // Allow the data to grow up to maximum possible capacity (~2G bytes) before encountering overflow.
            // Note: Array.MaxLength exists only on .NET 6 or greater,
            // so for the other versions value is hardcoded
            const int MaxArrayLength = 0x7FFFFFC7;
#if NET
            Debug.Assert(MaxArrayLength == Array.MaxLength);
#endif

            // Double the base length and add the additional capacity
            int newCapacity = (toReturn.Length * 2) + additionalLength;

            // Note that this check works even when newCapacity overflowed thanks to the (uint) cast
            if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;

            // If the maximum capacity has already been reached,
            // then set the new capacity to be larger than what is possible
            // so that ArrayPool.Rent throws an OutOfMemoryException for us.
            if (newCapacity == toReturn.Length) newCapacity = int.MaxValue;

            backing = ArrayPool<byte>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, backing, 0, toReturn.Length);

            // This could be security sensitive, so we clear the array
            toReturn.AsSpan(0, usedLength).Clear();
            ArrayPool<byte>.Shared.Return(toReturn);
        }

        private void AppendToEvaluationPath(JsonSchemaPathProvider path)
        {
            if (_evaluationPathLength + MaxPathSegmentLength > _evaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _evaluationPath, _evaluationPathLength);
            }

            if (!path(_evaluationPath.AsSpan(_evaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _evaluationPathLength += written;
            _currentEvaluationPathRange = new ValueRange(_currentEvaluationPathRange.Start, _evaluationPathLength);
        }

        private void AppendToEvaluationPath<T>(T context, JsonSchemaPathProvider<T> path)
        {
            if (_evaluationPathLength + MaxPathSegmentLength > _evaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _evaluationPath, _evaluationPathLength);
            }

            if (!path(context, _evaluationPath.AsSpan(_evaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _evaluationPathLength += written;
            _currentEvaluationPathRange = new ValueRange(_currentEvaluationPathRange.Start, _evaluationPathLength);
        }

        private void AppendToSchemaEvaluationPath(JsonSchemaPathProvider path)
        {
            if (_schemaEvaluationPathLength + MaxPathSegmentLength > _schemaEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!path(_schemaEvaluationPath.AsSpan(_schemaEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _schemaEvaluationPathLength += written;
            _currentSchemaEvaluationPathRange = new ValueRange(_currentSchemaEvaluationPathRange.Start, _schemaEvaluationPathLength);
        }

        private void AppendToSchemaEvaluationPath<T>(T context, JsonSchemaPathProvider<T> path)
        {
            if (_schemaEvaluationPathLength + MaxPathSegmentLength > _schemaEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!path(context, _schemaEvaluationPath.AsSpan(_schemaEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _schemaEvaluationPathLength += written;
            _currentSchemaEvaluationPathRange = new ValueRange(_currentSchemaEvaluationPathRange.Start, _schemaEvaluationPathLength);
        }

        private void AppendToDocumentEvaluationPath(JsonSchemaPathProvider path)
        {
            if (_documentEvaluationPathLength + MaxPathSegmentLength > _documentEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _documentEvaluationPath, _documentEvaluationPathLength);
            }

            if (!path(_documentEvaluationPath.AsSpan(_documentEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _documentEvaluationPathLength += written;
            _currentDocumentEvaluationPathRange = new ValueRange(_currentDocumentEvaluationPathRange.Start, _documentEvaluationPathLength);
        }

        private void AppendToDocumentEvaluationPath<T>(T context, JsonSchemaPathProvider<T> path)
        {
            if (_documentEvaluationPathLength + MaxPathSegmentLength > _documentEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _documentEvaluationPath, _documentEvaluationPathLength);
            }

            if (!path(context, _documentEvaluationPath.AsSpan(_documentEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _documentEvaluationPathLength += written;
            _currentDocumentEvaluationPathRange = new ValueRange(_currentDocumentEvaluationPathRange.Start, _documentEvaluationPathLength);
        }

        private void UnescapeEncodeAndAppendToDocumentEvaluationPath(ReadOnlySpan<byte> escapedAndUnencodedPropertyName)
        {
            int length = (escapedAndUnencodedPropertyName.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer);

            if (_documentEvaluationPathLength + length > _documentEvaluationPath.Length)
            {
                Enlarge(length, ref _documentEvaluationPath, _documentEvaluationPathLength);
            }


            if (!JsonReaderHelper.TryUnescapeAndEncodePointer(escapedAndUnencodedPropertyName, _documentEvaluationPath.AsSpan(_documentEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _documentEvaluationPathLength += written;
            _currentDocumentEvaluationPathRange = new ValueRange(_currentDocumentEvaluationPathRange.Start, _documentEvaluationPathLength);
        }

        private void EncodeAndAppendToDocumentEvaluationPath(ReadOnlySpan<byte> unencodedPropertyName)
        {
            int length = (unencodedPropertyName.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer);

            if (_documentEvaluationPathLength + length > _documentEvaluationPath.Length)
            {
                Enlarge(length, ref _documentEvaluationPath, _documentEvaluationPathLength);
            }

            if (!JsonReaderHelper.TryEncodePointer(unencodedPropertyName, _documentEvaluationPath.AsSpan(_documentEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _documentEvaluationPathLength += written;
            _currentDocumentEvaluationPathRange = new ValueRange(_currentDocumentEvaluationPathRange.Start, _documentEvaluationPathLength);
        }

        private void EncodeAndAppendToSchemaEvaluationPath(ReadOnlySpan<byte> unencodedPropertyName)
        {
            int length = (unencodedPropertyName.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer);

            if (_schemaEvaluationPathLength + length > _schemaEvaluationPath.Length)
            {
                Enlarge(length, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!JsonReaderHelper.TryEncodePointer(unencodedPropertyName, _schemaEvaluationPath.AsSpan(_schemaEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _schemaEvaluationPathLength += written;
            _currentSchemaEvaluationPathRange = new ValueRange(_currentSchemaEvaluationPathRange.Start, _schemaEvaluationPathLength);
        }

        private void EncodeAndAppendToEvaluationPath(ReadOnlySpan<byte> unencodedPropertyName)
        {
            int length = (unencodedPropertyName.Length * JsonConstants.MaxExpansionFactorWhileEncodingPointer);

            if (_schemaEvaluationPathLength + length > _schemaEvaluationPath.Length)
            {
                Enlarge(length, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!JsonReaderHelper.TryEncodePointer(unencodedPropertyName, _schemaEvaluationPath.AsSpan(_schemaEvaluationPathLength), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _schemaEvaluationPathLength += written;
            _currentEvaluationPathRange = new ValueRange(_currentEvaluationPathRange.Start, _schemaEvaluationPathLength);
        }


        int IJsonSchemaResultsCollector.BeginChildContext(JsonSchemaPathProvider? evaluationPath, JsonSchemaPathProvider? documentEvaluationPath)
        {
            IsConsistent(_sequenceNumber);

            // Push the paths onto the stack
            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

            if (evaluationPath is not null)
            {
                AppendToSchemaEvaluationPath(evaluationPath);
                AppendToEvaluationPath(evaluationPath);
            }

            if (documentEvaluationPath is not null)
            {
                AppendToDocumentEvaluationPath(documentEvaluationPath);
            }

            // There are no current results for this context (hence our result stack has 0 length)
            // But we also record the committed result stack at this point, in case we wish to pop and unwind it later.
            _resultStack.Append(
                new ValueRangeWithCommitIndex(_utf8StringBackingLength, _utf8StringBackingLength, _committedResultStack.Length));

            _sequenceNumber++;
            return _sequenceNumber;
        }

        int IJsonSchemaResultsCollector.BeginChildContext<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext>? evaluationPath, JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath)
        {
            IsConsistent(_sequenceNumber);

            // Push the paths onto the stack
            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

            if (evaluationPath is not null)
            {
                AppendToSchemaEvaluationPath(providerContext, evaluationPath);
                AppendToEvaluationPath(providerContext, evaluationPath);
            }

            if (documentEvaluationPath is not null)
            {
                AppendToDocumentEvaluationPath(providerContext, documentEvaluationPath);
            }

            // There are no current results for this context (hence our result stack has 0 length)
            // But we also record the committed result stack at this point, in case we wish to pop and unwind it later.
            _resultStack.Append(
                new ValueRangeWithCommitIndex(_utf8StringBackingLength, _utf8StringBackingLength, _committedResultStack.Length));

            _sequenceNumber++;
            return _sequenceNumber;
        }

        int IJsonSchemaResultsCollector.BeginChildContext(ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider? evaluationPath)
        {
            IsConsistent(_sequenceNumber);

            // Push the paths onto the stack
            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

            if (evaluationPath is not null)
            {
                AppendToSchemaEvaluationPath(evaluationPath);
                AppendToEvaluationPath(evaluationPath);
            }

            UnescapeEncodeAndAppendToDocumentEvaluationPath(escapedPropertyName);

            // There are no current results for this context (hence our result stack has 0 length)
            // But we also record the committed result stack at this point, in case we wish to pop and unwind it later.
            _resultStack.Append(
                new ValueRangeWithCommitIndex(_utf8StringBackingLength, _utf8StringBackingLength, _committedResultStack.Length));

            _sequenceNumber++;
            return _sequenceNumber;
        }

        int IJsonSchemaResultsCollector.BeginChildContextUnescaped(ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider? evaluationPath)
        {
            IsConsistent(_sequenceNumber);

            // Push the paths onto the stack
            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

            if (evaluationPath is not null)
            {
                AppendToSchemaEvaluationPath(evaluationPath);
                AppendToEvaluationPath(evaluationPath);
            }

            EncodeAndAppendToDocumentEvaluationPath(unescapedPropertyName);

            // There are no current results for this context (hence our result stack has 0 length)
            // But we also record the committed result stack at this point, in case we wish to pop and unwind it later.
            _resultStack.Append(
                new ValueRangeWithCommitIndex(_utf8StringBackingLength, _utf8StringBackingLength, _committedResultStack.Length));

            _sequenceNumber++;
            return _sequenceNumber;
        }

        void IJsonSchemaResultsCollector.CommitChildContext(int sequenceNumber, bool isMatch, JsonSchemaMessageProvider? messageProvider)
        {
            IsConsistent(sequenceNumber);
            WriteResult(isMatch, messageProvider);

            // Commit the results
            ValueRangeWithCommitIndex range = _resultStack.Pop();
            _committedResultStack.Append(new ValueRange(range.Start, range.End));

            // Pop the paths off the stack
            _currentEvaluationPathRange = _evaluationPathStack.Pop();
            _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();
            _sequenceNumber--;
        }

        void IJsonSchemaResultsCollector.CommitChildContext<TProviderContext>(int sequenceNumber, bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider)
        {
            IsConsistent(sequenceNumber);
            WriteResult(isMatch, providerContext, messageProvider);

            // Commit the results
            ValueRangeWithCommitIndex range = _resultStack.Pop();
            _committedResultStack.Append(new ValueRange(range.Start, range.End));

            // Pop the paths off the stack
            _currentEvaluationPathRange = _evaluationPathStack.Pop();
            _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();
            _sequenceNumber--;
        }

        void IJsonSchemaResultsCollector.PopChildContext(int sequenceNumber)
        {
            IsConsistent(sequenceNumber);

            // Pop the paths off the stack
            _currentEvaluationPathRange = _evaluationPathStack.Pop();
            _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();

            // Also, pop the results off the stack
            ValueRangeWithCommitIndex range = _resultStack.Pop();
            // And ensure we roll back any commits
            _committedResultStack.Length = range.CommitIndex;
            _sequenceNumber--;
        }

        void IJsonSchemaResultsCollector.IgnoredKeyword(JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (_level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);

                WriteResult(match: true, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (_level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);

                WriteResult(match: true, providerContext, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeyword (bool isMatch, JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);
                EncodeAndAppendToSchemaEvaluationPath(unescapedKeyword);

                WriteResult(match: isMatch, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);
                EncodeAndAppendToSchemaEvaluationPath(unescapedKeyword);

                WriteResult(match: isMatch, providerContext, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider keywordPath)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                AppendToEvaluationPath(keywordPath);
                AppendToSchemaEvaluationPath(keywordPath);

                WriteResult(match: isMatch, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> keywordPath)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);

                AppendToEvaluationPath(providerContext, keywordPath);
                AppendToSchemaEvaluationPath(providerContext, keywordPath);

                WriteResult(match: isMatch, providerContext, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);
                _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);
                EncodeAndAppendToSchemaEvaluationPath(unescapedKeyword);
                EncodeAndAppendToDocumentEvaluationPath(propertyName);

                WriteResult(match: isMatch, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
                _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                _evaluationPathStack.Append(_currentEvaluationPathRange);
                _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);
                _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);

                EncodeAndAppendToEvaluationPath(unescapedKeyword);
                EncodeAndAppendToSchemaEvaluationPath(unescapedKeyword);
                EncodeAndAppendToDocumentEvaluationPath(propertyName);

                WriteResult(match: isMatch, providerContext, messageProvider);

                _currentEvaluationPathRange = _evaluationPathStack.Pop();
                _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
                _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider? messageProvider)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                WriteResult(match: isMatch, messageProvider);
            }
        }

        void IJsonSchemaResultsCollector.EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider)
        {
            if (!isMatch || _level == JsonSchemaResultsLevel.Verbose)
            {
                WriteResult(match: isMatch, providerContext, messageProvider);
            }
        }

        void IJsonSchemaResultsCollector.PopSchemaLocation()
        {
            _currentEvaluationPathRange = _evaluationPathStack.Pop();
            _currentSchemaEvaluationPathRange = _schemaEvaluationPathStack.Pop();
            _currentDocumentEvaluationPathRange = _documentEvaluationPathStack.Pop();
        }

        void IJsonSchemaResultsCollector.PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation)
        {
            int start = _currentSchemaEvaluationPathRange.Start + _currentSchemaEvaluationPathRange.Length;
            if (start + MaxPathSegmentLength > _schemaEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!relativeOrAbsoluteSchemaLocation(_schemaEvaluationPath.AsSpan(start), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);
            _currentSchemaEvaluationPathRange = new(start, start + written);
        }


        void IJsonSchemaResultsCollector.PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocation)
        {
            int start = _currentSchemaEvaluationPathRange.Start + _currentSchemaEvaluationPathRange.Length;
            if (start + MaxPathSegmentLength > _schemaEvaluationPath.Length)
            {
                Enlarge(MaxPathSegmentLength, ref _schemaEvaluationPath, _schemaEvaluationPathLength);
            }

            if (!relativeOrAbsoluteSchemaLocation(providerContext, _schemaEvaluationPath.AsSpan(start), out int written))
            {
                ThrowHelper.ThrowArgumentException_DestinationTooShort();
            }

            _evaluationPathStack.Append(_currentEvaluationPathRange);
            _documentEvaluationPathStack.Append(_currentDocumentEvaluationPathRange);
            _schemaEvaluationPathStack.Append(_currentSchemaEvaluationPathRange);
            _currentSchemaEvaluationPathRange = new(start, start + written);
        }


        [Conditional("DEBUG")]
        private void IsConsistent(int sequenceNumber)
        {
            // Ensure the path stacks are consistent
            Debug.Assert(
                (_evaluationPathStack.Length == 0 && _documentEvaluationPathStack.Length == 0 && _schemaEvaluationPathStack.Length == 0)
                || (_evaluationPathStack.Length == _documentEvaluationPathStack.Length && _evaluationPathStack.Length == _schemaEvaluationPathStack.Length));
            Debug.Assert(sequenceNumber == _sequenceNumber, "A context has been completed out-of-order");
        }
    }
}
