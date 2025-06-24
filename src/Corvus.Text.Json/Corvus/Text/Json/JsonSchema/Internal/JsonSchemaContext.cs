// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses _file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;
#if NET
using System.Numerics;
#endif
using System.Runtime.CompilerServices;
#if NET
using System.Runtime.InteropServices;
#endif
using System.Threading;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// The context for a JSON schema evaluation.
    /// </summary>
    [CLSCompliant(false)]
    public struct JsonSchemaContext
        : IDisposable
    {
        private const int InitialRentedBufferSize = 8192; // This allows for 65,536 property/item bits without reallocation

#if NET
        // This allows for 255 property/item bits without allocation, and is exactly one 256Bit Vector in size so merging values will be as simple a SIMD instruction as possible
        // on the most common processors at the time of writing.
        private const int BufferSize = 8;
        private const int BitsInAnInt = sizeof(int) * 8;
        // This is the maximum number of properties/items for which we can store bits without allocation.
        private const int MaxComplexValueCount = (BufferSize * BitsInAnInt) - 1;
#endif

        private readonly IJsonSchemaResultsCollector? _resultsCollector;
        private readonly int _offset;
        private readonly int _sequenceNumber;

        private int[]? _rentedBuffer;
        private uint _lengthAndUsingFeatures;

#if NET
        // If the top bit of the last byte of _localEvaluated is set, it indicates that we are using the rented buffer
        // for local evaluated bits and the first int is interpreted as the offset into the _rentedBuffer where the
        // local evaluated bits start with the second int interpreted as the bit buffer length.
        // If clear, then the remaining bits represent local evaluated indices.
        private EvaluatedIndexBuffer _localEvaluated;
        // If the top bit of the last byte of _appliedEvaluated is set, it indicates that we are using the rented buffer
        // for applied evaluated bits, and the first int is interpreted as the offset into the _rentedBuffer where the
        // applied evaluated bits start with the second int interpreted as the bit buffer length.
        // If clear, then the remaining bits represent applied evaluated indices.
        private EvaluatedIndexBuffer _appliedEvaluated;
#else
        private readonly int _localEvaluatedOffset;
        private readonly int _localEvaluatedLength;
        private readonly int _appliedEvaluatedOffset;
        private readonly int _appliedEvaluatedLength;
#endif

        [Flags]
        private enum UsingFeatures : uint
        {
            EvaluatedProperties = 0b0001_0000_0000_0000_0000_0000_0000_0000,
            EvaluatedItems = 0b0010_0000_0000_0000_0000_0000_0000_0000,
            IsMatch = 0b0100_0000_0000_0000_0000_0000_0000_0000,
            IsDisposable = 0b1000_0000_0000_0000_0000_0000_0000_0000,

            EvaluatedPropertiesOrItems = EvaluatedProperties | EvaluatedItems
        }


        private JsonSchemaContext(int sequenceNumber, int[]? rentedBuffer, uint lengthAndUsingFeatures, int offset, int evaluatedCount, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            _sequenceNumber = sequenceNumber;
            _rentedBuffer = rentedBuffer;
            _offset = offset;
            _resultsCollector = resultsCollector;
            _lengthAndUsingFeatures =
                lengthAndUsingFeatures
                | (uint)UsingFeatures.IsMatch; // But always  valid

#if NET
            if (evaluatedCount > MaxComplexValueCount)
            {
                int bitBufferLength = EnsureBitBufferLengths(evaluatedCount);
                _localEvaluated[^1] = 0b1000_0000; // Set the top bit to indicate that we are using the buffer for evaluated items
                _appliedEvaluated[^1] = 0b1000_0000; // Set the top bit to indicate that we are using the buffer for evaluated items
                _localEvaluated[0] = _offset;
                _localEvaluated[1] = bitBufferLength;
                _appliedEvaluated[0] = _offset + bitBufferLength;
                _appliedEvaluated[1] = bitBufferLength;
                _lengthAndUsingFeatures = (_lengthAndUsingFeatures & 0xF000_0000U) | unchecked((uint)(bitBufferLength * 2));
            }
#else
            if (evaluatedCount > 0)
            {
                int bitBufferLength = EnsureBitBufferLengths(evaluatedCount);
                _localEvaluatedOffset = offset;
                _localEvaluatedLength = bitBufferLength;
                _appliedEvaluatedOffset = offset + bitBufferLength;
                _appliedEvaluatedLength = bitBufferLength;
                _lengthAndUsingFeatures = (_lengthAndUsingFeatures & 0xF000_0000U) | unchecked((uint)(bitBufferLength * 2));
            }
#endif
        }

        /// <summary>
        /// Gets a value indicating whether the context represents a match.
        /// </summary>
        public readonly bool IsMatch => ((_lengthAndUsingFeatures & (uint)UsingFeatures.IsMatch) != 0);

        /// <summary>
        /// Gets a value indicating whether this context has a <see cref="IJsonSchemaResultsCollector"/>.
        /// </summary>
        public readonly bool HasCollector => _resultsCollector is not null;

        // The length is the _lengthAndUsingFeatures union with the top nybble masked
        private readonly int Length => unchecked((int)(_lengthAndUsingFeatures & 0x0FFF_FFFFU));

        private readonly bool IsDisposable => ((_lengthAndUsingFeatures & (uint)UsingFeatures.IsDisposable) != 0);

        private readonly bool UseEvaluatedProperties => ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedProperties) != 0);

        private readonly bool UseEvaluatedItems => ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0);

        private Span<int> LocalEvaluated
        {
#pragma warning disable IDE0251 //Member can be made 'readonly'
            get
            {
#if NET
                if ((_localEvaluated[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref _localEvaluated[0], BufferSize);
                }
                else
                {
                    return _rentedBuffer.AsSpan(_localEvaluated[0], _localEvaluated[1]);
                }
#else
                return _rentedBuffer.AsSpan(_localEvaluatedOffset,_localEvaluatedLength);
#endif
            }
#pragma warning  restore IDE0251
        }

        private Span<int> AppliedEvaluated
        {
#pragma warning disable IDE0251 //Member can be made 'readonly'
            get
            {
#if NET
                if ((_appliedEvaluated[^1] & 0b1000_0000) == 0)
                {
                    return MemoryMarshal.CreateSpan(ref _appliedEvaluated[0], BufferSize);
                }
                else
                {
                    return _rentedBuffer.AsSpan(_appliedEvaluated[0], _appliedEvaluated[1]);
                }
#else
                return _rentedBuffer.AsSpan(_appliedEvaluatedOffset,_appliedEvaluatedLength);
#endif
            }
#pragma warning  restore IDE0251
        }

        /// <summary>
        /// Begin a context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentDocument"></param>
        /// <param name="parentDocumentIndex"></param>
        /// <param name="usingEvaluatedItems"></param>
        /// <param name="usingEvaluatedProperties"></param>
        /// <param name="resultsCollector"></param>
        /// <returns></returns>
        public static JsonSchemaContext BeginContext<T>(
            T parentDocument,
            int parentDocumentIndex,
            bool usingEvaluatedItems,
            bool usingEvaluatedProperties,
            IJsonSchemaResultsCollector? resultsCollector = null)
            where T : IJsonDocument
        {
            int sequenceNumber = resultsCollector?.BeginChildContext() ?? 0;

            uint usingFeatures = usingEvaluatedProperties ? (uint)UsingFeatures.EvaluatedProperties : 0;
            usingFeatures |= usingEvaluatedItems ? (uint)UsingFeatures.EvaluatedItems : 0;
            usingFeatures |= (uint)UsingFeatures.IsMatch | (uint)UsingFeatures.IsDisposable;

            JsonTokenType valueKind = parentDocument.GetJsonTokenType(parentDocumentIndex);
            if (usingEvaluatedProperties && valueKind == JsonTokenType.StartObject)
            {
                return new JsonSchemaContext(
                    sequenceNumber,
                    null,
                    usingFeatures,
                    offset: 0,
                    evaluatedCount: parentDocument.GetPropertyCount(parentDocumentIndex),
                    resultsCollector);
            }

            if (usingEvaluatedItems && valueKind == JsonTokenType.StartArray)
            {
                return new JsonSchemaContext(
                    sequenceNumber,
                    null,
                    usingFeatures,
                    offset: 0,
                    evaluatedCount: parentDocument.GetArrayLength(parentDocumentIndex),
                    resultsCollector);
            }

            return new JsonSchemaContext(
                sequenceNumber,
                null,
                usingFeatures,
                offset: 0,
                evaluatedCount: -1,
                resultsCollector);
        }


        /// <summary>
        /// Push a schema location without starting a child context.
        /// </summary>
        /// <param name="relativeOrAbsoluteSchemaLocation"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void PushSchemaLocation(
            JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation)
        {
            _resultsCollector?.PushSchemaLocation(relativeOrAbsoluteSchemaLocation);
        }

        /// <summary>
        /// If you have pushed a schema location without starting a child context,
        /// this pops the location.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void PopSchemaLocation()
        {
            _resultsCollector?.PopSchemaLocation();
        }

        public readonly JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            bool useEvaluatedItems,
            bool useEvaluatedProperties,
            JsonSchemaPathProvider? schemaEvaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null)
        {
            int sequenceNumber = _resultsCollector?.BeginChildContext(schemaEvaluationPath, documentEvaluationPath) ?? 0;

            return PushChildContextCore(sequenceNumber, parentDocument, parentDocumentIndex, useEvaluatedItems, useEvaluatedProperties);
        }

        public readonly JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            bool useEvaluatedItems,
            bool useEvaluatedProperties,
            ReadOnlySpan<byte> escapedPropertyName,
            JsonSchemaPathProvider? reducedEvaluationPath = null)
        {
            int sequenceNumber = _resultsCollector?.BeginChildContext(escapedPropertyName, reducedEvaluationPath) ?? 0;

            return PushChildContextCore(sequenceNumber, parentDocument, parentDocumentIndex, useEvaluatedItems, useEvaluatedProperties);
        }

        public readonly JsonSchemaContext PushChildContextUnescaped(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            bool useEvaluatedItems,
            bool useEvaluatedProperties,
            ReadOnlySpan<byte> unescapedPropertyName,
            JsonSchemaPathProvider? reducedEvaluationPath = null)
        {
            int sequenceNumber = _resultsCollector?.BeginChildContextUnescaped(unescapedPropertyName, reducedEvaluationPath) ?? 0;

            return PushChildContextCore(sequenceNumber, parentDocument, parentDocumentIndex, useEvaluatedItems, useEvaluatedProperties);
        }

        public readonly JsonSchemaContext PushChildContext<TProviderContext>(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            bool useEvaluatedItems,
            bool useEvaluatedProperties,
            TProviderContext providerContext,
            JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath = null,
            JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath = null)
        {
            int sequenceNumber = _resultsCollector?.BeginChildContext(providerContext, schemaEvaluationPath, documentEvaluationPath) ?? 0;

            return PushChildContextCore(sequenceNumber, parentDocument, parentDocumentIndex, useEvaluatedItems, useEvaluatedProperties);
        }

        /// <summary>
        /// Commits the most recently pushed child context.
        /// </summary>
        /// <remarks>
        /// Note that this does not apply the evaluated properties/items from the child context
        /// to the parent context, but is expected to merge any messages produced in the
        /// child context.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CommitChildContext<TProviderContext>(bool isMatch, ref readonly JsonSchemaContext childContext, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider = null)
        {
            _resultsCollector?.CommitChildContext(childContext._sequenceNumber, parentIsMatch: isMatch, childIsMatch: childContext.IsMatch, providerContext, messageProvider);
            _rentedBuffer = childContext._rentedBuffer;
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        /// <summary>
        /// Commits the most recently pushed child context.
        /// </summary>
        /// <remarks>
        /// Note that this does not apply the evaluated properties/items from the child context
        /// to the parent context, but is expected to merge any messages produced in the
        /// child context.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CommitChildContext(bool isMatch, ref readonly JsonSchemaContext childContext, JsonSchemaMessageProvider? messageProvider = null)
        {
            _resultsCollector?.CommitChildContext(childContext._sequenceNumber, parentIsMatch: isMatch, childIsMatch: childContext.IsMatch, messageProvider);
            _rentedBuffer = childContext._rentedBuffer;
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedBooleanSchema(bool isMatch)
        {
            _resultsCollector?.EvaluatedBooleanSchema(isMatch, null);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeyword(
            bool isMatch,
            JsonSchemaMessageProvider? messageProvider,
            ReadOnlySpan<byte> unescapedKeyword)
        {
            _resultsCollector?.EvaluatedKeyword(isMatch, messageProvider, unescapedKeyword);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeyword<TProviderContext>(
            bool isMatch,
            TProviderContext providerContext,
            JsonSchemaMessageProvider<TProviderContext>? messageProvider,
             ReadOnlySpan<byte> unescapedKeyword)
        {
            _resultsCollector?.EvaluatedKeyword(isMatch, providerContext, messageProvider, unescapedKeyword);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeywordForProperty(
            bool isMatch,
            JsonSchemaMessageProvider? messageProvider,
            ReadOnlySpan<byte> propertyName,
            ReadOnlySpan<byte> unescapedKeyword)
        {
            _resultsCollector?.EvaluatedKeywordForProperty(isMatch, messageProvider, propertyName, unescapedKeyword);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeywordForProperty<TProviderContext>(
            bool isMatch,
            TProviderContext providerContext,
            JsonSchemaMessageProvider<TProviderContext>? messageProvider,
            ReadOnlySpan<byte> propertyName,
            ReadOnlySpan<byte> unescapedKeyword)
        {
            _resultsCollector?.EvaluatedKeywordForProperty(isMatch, providerContext, messageProvider, propertyName, unescapedKeyword);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeywordPath(
            bool isMatch,
            JsonSchemaMessageProvider messageProvider,
            JsonSchemaPathProvider keywordPath)
        {
            _resultsCollector?.EvaluatedKeywordPath(isMatch, messageProvider, keywordPath);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EvaluatedKeywordPath<TProviderContext>(
            bool isMatch,
            TProviderContext providerContext,
            JsonSchemaMessageProvider<TProviderContext> messageProvider,
            JsonSchemaPathProvider<TProviderContext> keywordPath)
        {
            _resultsCollector?.EvaluatedKeywordPath(isMatch, providerContext, messageProvider, keywordPath);
            if (!isMatch)
            {
                _lengthAndUsingFeatures &= ~(uint)UsingFeatures.IsMatch;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void IgnoredKeyword(
            JsonSchemaMessageProvider? messageProvider,
            ReadOnlySpan<byte> encodedKeyword)
        {
            _resultsCollector?.IgnoredKeyword(messageProvider, encodedKeyword);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void IgnoredKeyword<TProviderContext>(
            TProviderContext providerContext,
            JsonSchemaMessageProvider<TProviderContext>? messageProvider,
            ReadOnlySpan<byte> unescapedKeyword)
        {
            _resultsCollector?.IgnoredKeyword(providerContext, messageProvider, unescapedKeyword);
        }

        /// <summary>
        /// Pops the most recently pushed child context without committing changes.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PopChildContext(ref readonly JsonSchemaContext childContext)
        {
            _resultsCollector?.PopChildContext(childContext._sequenceNumber);
            _rentedBuffer = childContext._rentedBuffer;
        }

        public bool HasLocalEvaluatedItem(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                return (LocalEvaluated[intOffset] & bit) != 0;
            }

            return false;
        }

        public bool HasLocalEvaluatedProperty(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedProperties) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                return (LocalEvaluated[intOffset] & bit) != 0;
            }

            return false;
        }

        public bool HasLocalOrAppliedEvaluatedItem(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                return (LocalEvaluated[intOffset] & bit) != 0 || (AppliedEvaluated[intOffset] & bit) != 0;
            }

            return false;
        }

        public bool HasLocalOrAppliedEvaluatedProperty(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedProperties) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                return (LocalEvaluated[intOffset] & bit) != 0 || (AppliedEvaluated[intOffset] & bit) != 0;
            }

            return false;
        }

        /// <summary>
        /// Applies the evaluated properties/items from the child context
        /// to this (parent) context, if appropriate.
        /// </summary>
        /// <param name="childContext">The child context from which to apply evaluated properties/items</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyEvaluated(ref readonly JsonSchemaContext childContext)
        {
            if ((childContext.UseEvaluatedItems && UseEvaluatedItems) || (childContext.UseEvaluatedProperties && UseEvaluatedProperties))
            {
                Span<int> childLocalEvaluated = childContext.LocalEvaluated;
                Span<int> childAppliedEvaluated = childContext.AppliedEvaluated;
                Span<int> evaluatedItems = AppliedEvaluated;

                // Ensure that we are all the same length - which we should be because we
                // must be talking about the same object!
                Debug.Assert(childLocalEvaluated.Length == childAppliedEvaluated.Length);
                Debug.Assert(evaluatedItems.Length == childAppliedEvaluated.Length);

#if NET
                int vectorSize = Vector<int>.Count;
                int length = evaluatedItems.Length;
                int vectorCount = length / vectorSize;
                int vectorizedLength = vectorCount * vectorSize;

                Span<Vector<int>> vEvaluatedItems = MemoryMarshal.Cast<int, Vector<int>>(evaluatedItems.Slice(0, vectorizedLength));
                Span<Vector<int>> vChildLocal = MemoryMarshal.Cast<int, Vector<int>>(childLocalEvaluated.Slice(0, vectorizedLength));
                Span<Vector<int>> vChildApplied = MemoryMarshal.Cast<int, Vector<int>>(childAppliedEvaluated.Slice(0, vectorizedLength));

                for (int i = 0; i < vEvaluatedItems.Length; i++)
                {
                    vEvaluatedItems[i] = vEvaluatedItems[i] | vChildLocal[i] | vChildApplied[i];
                }

                // Scalar loop for remaining elements
                for (int i = vectorizedLength; i < length; i++)
                {
                    evaluatedItems[i] |= childLocalEvaluated[i] | childAppliedEvaluated[i];
                }
#else
                for (int i = 0; i < childLocalEvaluated.Length; i++)
                {
                    evaluatedItems[i] |= childLocalEvaluated[i] | childAppliedEvaluated[i];
                }
#endif
            }
        }

        public void Dispose()
        {
            if (_rentedBuffer != null && IsDisposable)
            {
                int[]? bufferToReturn = Interlocked.Exchange(ref _rentedBuffer, null);
                if (bufferToReturn != null)
                {
                    // Clear the entire buffer as they may contain actual data
                    bufferToReturn.AsSpan().Clear();
                    ArrayPool<int>.Shared.Return(bufferToReturn);
                }
            }
        }

        public void AddLocalEvaluatedItem(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedItems) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                LocalEvaluated[intOffset] |= bit;
            }
        }

        public void AddLocalEvaluatedProperty(int index)
        {
            if ((_lengthAndUsingFeatures & (uint)UsingFeatures.EvaluatedProperties) != 0)
            {
                // Calculate the offset into the array
                int intOffset = index >> 5; // divide by 32 ==> shift right 5
                int bitOffset = index & 0b1_1111; // remainder of dividing by 32
                int bit = 1 << bitOffset;
                Debug.Assert(intOffset < LocalEvaluated.Length);
                LocalEvaluated[intOffset] |= bit;
            }
        }

        private readonly JsonSchemaContext PushChildContextCore(int sequenceNumber, IJsonDocument parentDocument, int parentDocumentIndex, bool useEvaluatedItems, bool useEvaluatedProperties)
        {
            bool usesEvaluatedProperties = UseEvaluatedProperties || useEvaluatedProperties;
            bool usesEvaluatedItems = UseEvaluatedItems || useEvaluatedItems;

            uint usingFeatures = usesEvaluatedProperties ? (uint)UsingFeatures.EvaluatedProperties : 0;
            usingFeatures |= usesEvaluatedItems ? (uint)UsingFeatures.EvaluatedItems : 0;

            // If we are creating a child context, we have to ensure we are using new buffers
            if (usesEvaluatedItems || usesEvaluatedProperties)
            {
                JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentDocumentIndex);
                if (usesEvaluatedProperties && tokenType == JsonTokenType.StartObject)
                {
                    return new JsonSchemaContext(
                        sequenceNumber,
                        _rentedBuffer,
                        _lengthAndUsingFeatures | usingFeatures & ~(uint)UsingFeatures.IsDisposable,
                        offset: Length,
                        evaluatedCount: parentDocument.GetPropertyCount(parentDocumentIndex),
                        resultsCollector: _resultsCollector);
                }

                if (usesEvaluatedItems && tokenType == JsonTokenType.StartArray)
                {
                    return new JsonSchemaContext(
                        sequenceNumber,
                        _rentedBuffer,
                        _lengthAndUsingFeatures | usingFeatures & ~(uint)UsingFeatures.IsDisposable,
                        offset: Length,
                        evaluatedCount: parentDocument.GetArrayLength(parentDocumentIndex),
                        resultsCollector: _resultsCollector);
                }
            }

            return new JsonSchemaContext(
                sequenceNumber,
                _rentedBuffer,
                _lengthAndUsingFeatures & ~(uint)UsingFeatures.IsDisposable,
                offset: Length,
                evaluatedCount: -1,
                resultsCollector: _resultsCollector);
        }
        private int EnsureBitBufferLengths(int count)
        {
            Debug.Assert(count != 0);

            // Required property buffer length
            int bitBufferLength = (count >> 5) + 1; // Divide by 32 (>> 5) gives offset, add 1 to give length
            int propertyRemainder = count & 0b1_1111; // Remainder is the bottom 5 bits (0 > 31)
            bitBufferLength += (propertyRemainder == 0 ? 0 : 1);

            if (bitBufferLength > 0)
            {
                if ((_rentedBuffer is null || bitBufferLength > _rentedBuffer.Length - _offset - Length))
                {
                    Enlarge(bitBufferLength * 2); // We double the required length in order to support local and applied bitBuffers
                }
                else
                {
                    // Clear our bit of the buffer
                    _rentedBuffer.AsSpan(_offset, bitBufferLength * 2).Clear();
                }
            }

            return bitBufferLength;
        }

        private void Enlarge(int required)
        {
            if (_rentedBuffer == null)
            {
                _rentedBuffer = ArrayPool<int>.Shared.Rent(InitialRentedBufferSize);
                _rentedBuffer.AsSpan().Clear();
                return;
            }

            int[] toReturn = _rentedBuffer;

            // Allow the data to grow up to maximum possible capacity (~2G bytes) before encountering overflow.
            // Note: Array.MaxLength exists only on .NET 6 or greater,
            // so for the other versions value is hardcoded
            const int MaxArrayLength = 0x7FFFFFC7;

#if NET
            Debug.Assert(MaxArrayLength == Array.MaxLength);
#endif

            // We will double the length, or use required
            int newCapacity = Math.Max(toReturn.Length * 2, toReturn.Length + required);

            // Note that this check works even when newCapacity overflowed thanks to the (uint) cast
            if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;

            // If the maximum capacity has already been reached,
            // then set the new capacity to be larger than what is possible
            // so that ArrayPool.Rent throws an OutOfMemoryException for us.
            if (newCapacity == toReturn.Length) newCapacity = int.MaxValue;

            _rentedBuffer = ArrayPool<int>.Shared.Rent(newCapacity);
            Buffer.BlockCopy(toReturn, 0, _rentedBuffer, 0, toReturn.Length * sizeof(int));
            // Clear the new buffer bits
            _rentedBuffer.AsSpan(toReturn.Length).Clear();

            // The data in this rented buffer only conveys the
            // index of items or properties in a complex value, but no content;
            // so it does not need to be cleared.
            ArrayPool<int>.Shared.Return(toReturn);
        }

#if NET
        [InlineArray(BufferSize)]
        public struct EvaluatedIndexBuffer
        {
            private int _element0;
        }
#endif
    }
}
