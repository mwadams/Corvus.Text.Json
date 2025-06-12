// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Corvus.Text.Json.Internal;
using NodaTime;

namespace Corvus.Text.Json
{
    [CLSCompliant(false)]
    public sealed partial class JsonDocumentBuilder<T> : JsonDocument, IMutableJsonDocument
        where T : struct, IMutableJsonElement<T>
    {
        private readonly JsonWorkspace _workspace;
        private int _parentWorkspaceIndex = -1;
        private ulong _version = 0;

        internal JsonDocumentBuilder(JsonWorkspace workspace)
        {
            _workspace = workspace;
        }

#if DEBUG
        public void EnumerateRows()
        {
            List<DbRow> results = [];
            for (int i = 0; i < _parsedData.Length; i += DbRow.Size)
            {
                results.Add(_parsedData.Get(i));
            }
        }
#endif


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        bool IJsonDocument.IsDisposable => true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMutableJsonDocument.ParentWorkspaceIndex => _parentWorkspaceIndex;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ulong IMutableJsonDocument.Version => _version;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonWorkspace IMutableJsonDocument.Workspace => _workspace;

        public T RootElement
        {
            get
            {
                CheckNotDisposed();
#if NET
                return T.CreateInstance(this, 0);
#else
                return JsonElementHelpers.CreateInstance<T>(this, 0);
#endif
            }
        }

        /// <summary>
        ///  Write the document into the provided writer as a JSON value.
        /// </summary>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException">
        ///   The <paramref name="writer"/> parameter is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   This <see cref="RootElement"/>'s <see cref="JsonElement.ValueKind"/> would result in an invalid JSON.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public void WriteTo(Utf8JsonWriter writer)
        {
            ArgumentNullException.ThrowIfNull(writer);

            RootElement.WriteTo(writer);
        }

        internal void Initialize<TElement>(TElement sourceElement, int parentWorkspaceIndex, bool convertToAlloc)
            where TElement : struct, IJsonElement<TElement>
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;
            sourceElement.CheckValidInstance();
            int metadataDbLength = sourceElement.ParentDocument.BuildRentedMetadataDb(sourceElement.ParentDocumentIndex, _workspace, out byte[] metadataDbBytes);
            _parsedData = MetadataDb.CreateRented(metadataDbBytes, metadataDbLength, convertToAlloc);
        }

        internal void Initialize(int parentWorkspaceIndex, int initialElementCount, int initialValueBufferSize)
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;

            if (initialElementCount >= 0)
            {
                _parsedData = MetadataDb.CreateRented(initialElementCount * DbRow.Size, convertToAlloc: false);
            }

            if (initialValueBufferSize > 0)
            {
                _valueBacking = ArrayPool<byte>.Shared.Rent(initialValueBufferSize);
            }
        }

        public void Dispose()
        {
            if (_parentWorkspaceIndex == -1)
            {
                return;
            }

            base.DisposeCore();

            _parentWorkspaceIndex = -1;
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

        bool IJsonDocument.ValueIsEscaped(int index, bool isPropertyName)
        {
            CheckNotDisposed();

            return ValueIsEscapedUnsafe(index, isPropertyName);
        }

        int IJsonDocument.GetArrayLength(int index)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.StartArray, row.TokenType);

            return row.SizeOrLengthOrPropertyMapIndex;
        }

        int IJsonDocument.GetPropertyCount(int index)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.StartObject, row.TokenType);

            return row.SizeOrLengthOrPropertyMapIndex;
        }

        JsonElement IJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex)
        {
            CheckNotDisposed();

            return new JsonElement(this, GetArrayIndexElementUnsafe(currentIndex, arrayIndex));
        }

        JsonElement.Mutable IMutableJsonDocument.GetArrayIndexElement(int currentIndex, int arrayIndex)
        {
            CheckNotDisposed();

            return new JsonElement.Mutable(this, GetArrayIndexElementUnsafe(currentIndex, arrayIndex));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        TElement IJsonDocument.GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex)
        {
            CheckNotDisposed();

#if NET
            return TElement.CreateInstance(this, GetArrayIndexElementUnsafe(currentIndex, arrayIndex));
#else
            return JsonElementHelpers.CreateInstance<TElement>(this, GetArrayIndexElementUnsafe(currentIndex, arrayIndex));
#endif
        }

        int IJsonDocument.GetDbSize(int index, bool includeEndElement)
        {
            CheckNotDisposed();

            return GetDbSizeUnsafe(index, includeEndElement);
        }

        protected override int GetDbSizeUnsafe(int index, bool includeEndElement)
        {
            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetDbSize(row.LocationOrIndex, includeEndElement);
            }

            return base.GetDbSizeUnsafe(index, includeEndElement);
        }

        RawUtf8JsonString IJsonDocument.GetRawValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();
            return GetRawValueUnsafe(index, includeQuotes);
        }

        void IMutableJsonDocument.InsertAndDispose(int complexObjectStartIndex, int index, ref ComplexValueBuilder cvb)
        {
            CheckNotImmutable();
            _version++;
            cvb.InsertAndDispose(complexObjectStartIndex, index, ref _parsedData);
        }

        void IMutableJsonDocument.SetAndDispose(ref ComplexValueBuilder cvb)
        {
            CheckNotImmutable();
            _version++;
            cvb.SetAndDispose(ref _parsedData);
        }

        void IMutableJsonDocument.OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, ref ComplexValueBuilder cvb)
        {
            CheckNotImmutable();
            _version++;
            cvb.OverwriteAndDispose(complexObjectStartIndex, startIndex, endIndex, memberCountToReplace, ref _parsedData);
        }

        private RawUtf8JsonString GetRawValueUnsafe(int index, bool includeQuotes)
        {
            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetRawValue(row.LocationOrIndex, includeQuotes);
            }

            // So we do have a dynamic value. If it is a simple value that means it's
            // a local dynamic value.
            if (row.IsSimpleValue)
            {
                return new(ReadRawSimpleDynamicValue(row.LocationOrIndex, includeQuotes));
            }

            // We have a complex value and it is not a simple slice of a parent
            // buffer somewhere, so we have to render it out to return it.
            // The length of our parsed data is a good guess at the initial size for the buffer (on the usual 12 bytes per token,
            // 12 bytes per row heuristic). It will reallocate if needs be, anyway.
            // In an ideal world, you are not doing this too often; in general you will be acquiring simple values
            // rather than complex ones - except for ToString() and so forth which are not intended to be high-performance
            // scenarios (not least because they allocate strings!)
            Utf8JsonWriter writer = _workspace.RentWriterAndBuffer(_parsedData.Length, out IByteBufferWriter bufferWriter);
            try
            {
                WriteComplexElementToUnsafe(index, writer);
                writer.Flush();
                int length = bufferWriter.WrittenSpan.Length;
                byte[] additionalRentedBytes = ArrayPool<byte>.Shared.Rent(length);
                bufferWriter.WrittenSpan.CopyTo(additionalRentedBytes.AsSpan());
                return new(additionalRentedBytes.AsMemory(0, length));

            }
            finally
            {
                _workspace.ReturnWriterAndBuffer(writer, bufferWriter);
            }
        }

        ReadOnlyMemory<byte> IJsonDocument.GetRawSimpleValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();

            return GetRawSimpleValueUnsafe(index, includeQuotes);
        }

        protected override ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index, bool includeQuotes)
        {
            DbRow row = _parsedData.Get(index);

            Debug.Assert(row.IsSimpleValue);

            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetRawSimpleValue(row.LocationOrIndex, includeQuotes);
            }

            return ReadRawSimpleDynamicValue(row.LocationOrIndex, includeQuotes);
        }

        string? IJsonDocument.GetString(int index, JsonTokenType expectedType)
        {
            CheckNotDisposed();
            return GetStringUnsafe(index, expectedType);
        }

        private string? GetStringUnsafe(int index, JsonTokenType expectedType)
        {
            DbRow row = _parsedData.Get(index);

            JsonTokenType tokenType = row.TokenType;

            if (tokenType == JsonTokenType.Null)
            {
                return null;
            }

            CheckExpectedType(expectedType, tokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            return row.HasComplexChildren
                ? JsonReaderHelper.GetUnescapedString(segment)
                : JsonReaderHelper.TranscodeHelper(segment);
        }

        UnescapedUtf8JsonString IJsonDocument.GetUtf8JsonString(int index, JsonTokenType expectedType)
        {
            CheckNotDisposed();
            return GetUtf8JsonStringUnsafe(index, expectedType);
        }

        private UnescapedUtf8JsonString GetUtf8JsonStringUnsafe(int index, JsonTokenType expectedType)
        {
            DbRow row = _parsedData.Get(index);

            JsonTokenType tokenType = row.TokenType;

            CheckExpectedType(expectedType, tokenType);

            ReadOnlyMemory<byte> segment = GetRawSimpleValueUnsafe(index, false);

            if (row.HasComplexChildren)
            {
                byte[] rentedBytes = ArrayPool<byte>.Shared.Rent(segment.Length);
                try
                {
                    JsonReaderHelper.Unescape(segment.Span, rentedBytes, out int written);
                    return new UnescapedUtf8JsonString(rentedBytes.AsMemory(0, written), rentedBytes);
                }
                catch
                {
                    ArrayPool<byte>.Shared.Return(rentedBytes);
                }
            }

            return new UnescapedUtf8JsonString(segment);
        }

        bool IJsonDocument.TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
        {
            CheckNotDisposed();
            return TextEqualsUnsafe(index, otherText, isPropertyName);
        }

        bool IJsonDocument.TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape)
        {
            CheckNotDisposed();
            return TextEqualsUnsafe(index, otherUtf8Text, isPropertyName, shouldUnescape);
        }

        string IJsonDocument.GetNameOfPropertyValue(int index)
        {
            CheckNotDisposed();
            // The property name is one row before the property value
            return GetStringUnsafe(index - DbRow.Size, JsonTokenType.PropertyName)!;
        }

        ReadOnlySpan<byte> IJsonDocument.GetPropertyNameRaw(int index)
        {
            CheckNotDisposed();
            Debug.Assert(_parsedData.Get(index - DbRow.Size).TokenType is JsonTokenType.PropertyName);

            return GetRawSimpleValueUnsafe(index - DbRow.Size, false).Span;
        }

        bool IJsonDocument.TryGetValue(int index, [NotNullWhen(true)] out byte[]? value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                return JsonReaderHelper.TryGetUnescapedBase64Bytes(segment, out value);
            }

            Debug.Assert(segment.IndexOf(JsonConstants.BackSlash) == -1);
            return JsonReaderHelper.TryDecodeBase64(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out sbyte value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out sbyte tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out byte value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out byte tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out short value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out short tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out ushort value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out ushort tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out int value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out int tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out uint value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out uint tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out long value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out long tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out ulong value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out ulong tmp, out int consumed) &&
                consumed == segment.Length)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out double value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out double tmp, out int bytesConsumed) &&
                segment.Length == bytesConsumed)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out float value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out float tmp, out int bytesConsumed) &&
                segment.Length == bytesConsumed)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out decimal value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (Utf8Parser.TryParse(segment, out decimal tmp, out int bytesConsumed) &&
                segment.Length == bytesConsumed)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

#if NET
        /// <inheritdoc />
        bool IJsonDocument.TryGetValue(int index, out Int128 value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            
            if (Int128.TryParse(segment, out Int128 tmp))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }

        /// <inheritdoc />
        bool IJsonDocument.TryGetValue(int index, out UInt128 value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;


            if (UInt128.TryParse(segment, out UInt128 tmp))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }

        /// <inheritdoc />
        bool IJsonDocument.TryGetValue(int index, out Half value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.Number, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;


            if (Half.TryParse(segment, out Half tmp))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }
#endif

        bool IJsonDocument.TryGetValue(int index, out DateTime value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (!JsonHelpers.IsValidDateTimeOffsetParseLength(segment.Length))
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                return JsonReaderHelper.TryGetEscapedDateTime(segment, out value);
            }

            Debug.Assert(segment.IndexOf(JsonConstants.BackSlash) == -1);

            if (JsonHelpers.TryParseAsISO(segment, out DateTime tmp))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out DateTimeOffset value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (!JsonHelpers.IsValidDateTimeOffsetParseLength(segment.Length))
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                return JsonReaderHelper.TryGetEscapedDateTimeOffset(segment, out value);
            }

            Debug.Assert(segment.IndexOf(JsonConstants.BackSlash) == -1);

            if (JsonHelpers.TryParseAsISO(segment, out DateTimeOffset tmp))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out OffsetDateTime value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedDateTimeOffsetParseLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                Debug.Assert(segment.Length <= JsonConstants.MaximumEscapedDateTimeOffsetParseLength);
                Span<byte> sourceUnescaped = stackalloc byte[JsonConstants.MaximumEscapedDateTimeOffsetParseLength];

                JsonReaderHelper.Unescape(segment, sourceUnescaped, out int written);
                Debug.Assert(written > 0);

                sourceUnescaped = sourceUnescaped.Slice(0, written);
                Debug.Assert(!sourceUnescaped.IsEmpty);

                return JsonElementHelpers.TryParseOffsetDateTime(segment, out value);
            }

            return JsonElementHelpers.TryParseOffsetDateTime(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out OffsetDate value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedDateTimeOffsetParseLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                Debug.Assert(segment.Length <= JsonConstants.MaximumEscapedDateTimeOffsetParseLength);
                Span<byte> sourceUnescaped = stackalloc byte[JsonConstants.MaximumEscapedDateTimeOffsetParseLength];

                JsonReaderHelper.Unescape(segment, sourceUnescaped, out int written);
                Debug.Assert(written > 0);

                sourceUnescaped = sourceUnescaped.Slice(0, written);
                Debug.Assert(!sourceUnescaped.IsEmpty);

                return JsonElementHelpers.TryParseOffsetDate(segment, out value);
            }

            return JsonElementHelpers.TryParseOffsetDate(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out OffsetTime value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedDateTimeOffsetParseLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                Debug.Assert(segment.Length <= JsonConstants.MaximumEscapedDateTimeOffsetParseLength);
                Span<byte> sourceUnescaped = stackalloc byte[JsonConstants.MaximumEscapedDateTimeOffsetParseLength];

                JsonReaderHelper.Unescape(segment, sourceUnescaped, out int written);
                Debug.Assert(written > 0);

                sourceUnescaped = sourceUnescaped.Slice(0, written);
                Debug.Assert(!sourceUnescaped.IsEmpty);

                return JsonElementHelpers.TryParseOffsetTime(segment, out value);
            }

            return JsonElementHelpers.TryParseOffsetTime(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out LocalDate value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedDateTimeOffsetParseLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                Span<byte> sourceUnescaped = stackalloc byte[JsonConstants.MaximumEscapedDateTimeOffsetParseLength];

                JsonReaderHelper.Unescape(segment, sourceUnescaped, out int written);
                Debug.Assert(written > 0);

                sourceUnescaped = sourceUnescaped.Slice(0, written);
                Debug.Assert(!sourceUnescaped.IsEmpty);

                return JsonElementHelpers.TryParseLocalDate(segment, out value);
            }

            return JsonElementHelpers.TryParseLocalDate(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out Period value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedDateTimeOffsetParseLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                Span<byte> sourceUnescaped = stackalloc byte[JsonConstants.MaximumEscapedDateTimeOffsetParseLength];

                JsonReaderHelper.Unescape(segment, sourceUnescaped, out int written);
                Debug.Assert(written > 0);

                sourceUnescaped = sourceUnescaped.Slice(0, written);
                Debug.Assert(!sourceUnescaped.IsEmpty);

                return Period.TryParse(segment, out value);
            }

            return Period.TryParse(segment, out value);
        }

        bool IJsonDocument.TryGetValue(int index, out Guid value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> segment = GetRawSimpleValueUnsafe(index, false).Span;

            if (segment.Length > JsonConstants.MaximumEscapedGuidLength)
            {
                value = default;
                return false;
            }

            // Segment needs to be unescaped
            if (row.HasComplexChildren)
            {
                return JsonReaderHelper.TryGetEscapedGuid(segment, out value);
            }

            Debug.Assert(segment.IndexOf(JsonConstants.BackSlash) == -1);

            if (segment.Length == JsonConstants.MaximumFormatGuidLength
                && Utf8Parser.TryParse(segment, out Guid tmp, out _, 'D'))
            {
                value = tmp;
                return true;
            }

            value = default;
            return false;
        }

        string IJsonDocument.GetRawValueAsString(int index)
        {
            CheckNotDisposed();

            return GetRawValueAsStringUnsafe(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetRawValueAsStringUnsafe(int index)
        {
            using RawUtf8JsonString segment = GetRawValueUnsafe(index, includeQuotes: true);
            return JsonReaderHelper.TranscodeHelper(segment.Span);
        }

        string IJsonDocument.ToString(int index)
        {
            CheckNotDisposed();

            switch (_parsedData.GetJsonTokenType(index))
            {
                case JsonTokenType.None:
                case JsonTokenType.Null:
                    return string.Empty;
                case JsonTokenType.True:
                    return bool.TrueString;
                case JsonTokenType.False:
                    return bool.FalseString;
                case JsonTokenType.Number:
                case JsonTokenType.StartArray:
                case JsonTokenType.StartObject:
                {
                    // null parent should have hit the None case
                    return GetRawValueAsStringUnsafe(index);
                }
                case JsonTokenType.String:
                    return GetStringUnsafe(index, JsonTokenType.String)!;
                case JsonTokenType.Comment:
                case JsonTokenType.EndArray:
                case JsonTokenType.EndObject:
                default:
                    Debug.Fail($"No handler for {nameof(JsonTokenType)}.{_parsedData.GetJsonTokenType(index)}");
                    return string.Empty;
            }
        }

        string IJsonDocument.GetPropertyRawValueAsString(int valueIndex)
        {
            CheckNotDisposed();

            // The property name is stored one row before the value
            int propertyNameIndex = valueIndex - DbRow.Size;
            DbRow row = _parsedData.Get(propertyNameIndex);
            Debug.Assert(row.TokenType == JsonTokenType.PropertyName);

            DbRow valueRow = _parsedData.Get(valueIndex);

            // These are not values in our document,
            // but they are both in the same external document,
            // so we can just defer processing to that document
            if (row.FromExternalDocument && valueRow.FromExternalDocument &&
                row.WorkspaceDocumentId == valueRow.WorkspaceDocumentId)
            {
                IJsonDocument document = _workspace.GetDocument(valueRow.WorkspaceDocumentId);
                return document.GetPropertyRawValueAsString(valueRow.LocationOrIndex);
            }

            ReadOnlyMemory<byte> name = GetRawSimpleValueUnsafe(propertyNameIndex, includeQuotes: true);
            using RawUtf8JsonString value = GetRawValueUnsafe(valueIndex, includeQuotes: true);
            // quoted name, quoted value and a colon
            int length = name.Length + value.Span.Length + 1;
            byte[]? buffer = null;
            Span<byte> propertySpan =
                length < JsonConstants.StackallocByteThreshold
                    ? stackalloc byte[JsonConstants.StackallocByteThreshold]
                    : (buffer = ArrayPool<byte>.Shared.Rent(length)).AsSpan();

            try
            {
                name.Span.CopyTo(propertySpan);
                propertySpan[name.Length] = JsonConstants.Colon; // colon between name and value
                value.Span.CopyTo(propertySpan.Slice(name.Length + 1));
                propertySpan = propertySpan.Slice(0, length);
                return JsonReaderHelper.TranscodeHelper(propertySpan);
            }
            finally
            {
                if (buffer is not null)
                {
                    propertySpan.Clear();
                    ArrayPool<byte>.Shared.Return(buffer);
                }
            }
        }

        JsonElement IJsonDocument.CloneElement(int index)
        {
            return CloneElement<JsonElement>(index);
        }

        TElement IJsonDocument.CloneElement<TElement>(int index)
        {
            return CloneElement<TElement>(index);
        }

        private TElement CloneElement<TElement>(int index)
            where TElement : struct, IJsonElement<TElement>
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.CloneElement<TElement>(row.LocationOrIndex);
            }

            using RawUtf8JsonString rawUtf8Json = GetRawValueUnsafe(index, includeQuotes: true);

            ReadOnlyMemory<byte> segmentCopy;
                segmentCopy = rawUtf8Json.Span.ToArray();

            ParsedJsonDocument<TElement> newDocument =
                ParsedJsonDocument<TElement>.ParseUnrented(segmentCopy);

            return newDocument.RootElement;
        }

        void IJsonDocument.WriteElementTo(
            int index,
            Utf8JsonWriter writer)
        {
            CheckNotDisposed();
            // Need to look at the element types/deferrals etc
            WriteElementToUnsafe(index, writer);
        }

        private void WriteElementToUnsafe(
            int index,
            Utf8JsonWriter writer)
        {
            DbRow row = _parsedData.Get(index);

            switch (row.TokenType)
            {
                case JsonTokenType.StartObject:
                    WriteComplexElementToUnsafe(index, writer);
                    return;
                case JsonTokenType.StartArray:
                    WriteComplexElementToUnsafe(index, writer);
                    return;
                case JsonTokenType.String:
                    if (row.HasComplexChildren)
                    {
                        using UnescapedUtf8JsonString unescaped = GetUtf8JsonStringUnsafe(index, JsonTokenType.String);
                        writer.WriteStringValue(unescaped.Span);
                    }
                    else
                    {
                        writer.WriteStringValue(GetRawSimpleValueUnsafe(index, false).Span);
                    }
                    return;
                case JsonTokenType.Number:
                    writer.WriteNumberValue(GetRawSimpleValueUnsafe(index, includeQuotes: false).Span);
                    return;
                case JsonTokenType.True:
                    writer.WriteBooleanValue(value: true);
                    return;
                case JsonTokenType.False:
                    writer.WriteBooleanValue(value: false);
                    return;
                case JsonTokenType.Null:
                    writer.WriteNullValue();
                    return;
            }

            Debug.Fail($"Unexpected encounter with JsonTokenType {row.TokenType}");
        }

        private void WriteComplexElementToUnsafe(
            int index,
            Utf8JsonWriter writer)
        {
            int endIndex = index + GetDbSizeUnsafe(index, true);

            for (int i = index; i < endIndex; i += DbRow.Size)
            {
                DbRow row = _parsedData.Get(i);

                // All of the types which don't need the value span
                switch (row.TokenType)
                {
                    case JsonTokenType.String:
                        if (row.HasComplexChildren)
                        {
                            using UnescapedUtf8JsonString unescaped = GetUtf8JsonStringUnsafe(i, JsonTokenType.String);
                            writer.WriteStringValue(unescaped.Span);
                        }
                        else
                        {
                            writer.WriteStringValue(GetRawSimpleValueUnsafe(i, false).Span);
                        }
                        continue;
                    case JsonTokenType.Number:
                        writer.WriteNumberValue(GetRawSimpleValueUnsafe(i, includeQuotes: false).Span);
                        continue;
                    case JsonTokenType.True:
                        writer.WriteBooleanValue(value: true);
                        continue;
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(value: false);
                        continue;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        continue;
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        continue;
                    case JsonTokenType.EndObject:
                        writer.WriteEndObject();
                        continue;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        continue;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        continue;
                    case JsonTokenType.PropertyName:
                        if (row.HasComplexChildren)
                        {
                            using UnescapedUtf8JsonString unescaped = GetUtf8JsonStringUnsafe(i, JsonTokenType.PropertyName);
                            writer.WritePropertyName(unescaped.Span);
                        }
                        else
                        {
                            writer.WritePropertyName(GetRawSimpleValueUnsafe(i, false).Span);
                        }
                        continue;
                }

                Debug.Fail($"Unexpected encounter with JsonTokenType {row.TokenType}");
            }
        }

        void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer)
        {
            CheckNotDisposed();

            Debug.Assert(_parsedData.Get(index - DbRow.Size).TokenType == JsonTokenType.PropertyName);
            WritePropertyNameUnsafe(index - DbRow.Size, writer);
        }

        private void WritePropertyNameUnsafe(int index, Utf8JsonWriter writer)
        {
            bool rowHasComplexChildren = _parsedData.Get(index - DbRow.Size).HasComplexChildren;
            if (rowHasComplexChildren)
            {
                ArraySegment<byte> rented = default;

                try
                {
                    writer.WritePropertyName(UnescapeString(index, out rented));
                }
                finally
                {
                    ClearAndReturn(rented);
                }
            }
            else
            {
                writer.WritePropertyName(GetRawSimpleValueUnsafe(index, false).Span);
            }
        }

        private ReadOnlySpan<byte> UnescapeString(int index, out ArraySegment<byte> rented)
        {
            DbRow row = _parsedData.Get(index);
            Debug.Assert(row.TokenType is JsonTokenType.String or JsonTokenType.PropertyName);
            ReadOnlySpan<byte> text = GetRawSimpleValueUnsafe(index, false).Span;

            if (!row.HasComplexChildren)
            {
                rented = default;
                return text;
            }

            int length = text.Length;
            byte[] rent = ArrayPool<byte>.Shared.Rent(length);
            JsonReaderHelper.Unescape(text, rent, out int written);
            rented = new ArraySegment<byte>(rent, 0, written);
            return rented.AsSpan();
        }

        private static void ClearAndReturn(ArraySegment<byte> rented)
        {
            if (rented.Array != null)
            {
                rented.AsSpan().Clear();
                ArrayPool<byte>.Shared.Return(rented.Array);
            }
        }

        internal void CompleteAllocations()
        {
            _parsedData.CompleteAllocations();
        }

        bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
                value = new JsonElement(this, valueIndex);
                return true;
            }

            value = default;
            return false;
        }


        bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
                value = new JsonElement(this, valueIndex);
                return true;
            }

            value = default;
            return false;
        }

        bool IJsonDocument.TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, out TElement value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
#if NET
                value = TElement.CreateInstance(this, valueIndex);
#else
                value = JsonElementHelpers.CreateInstance<TElement>(this, valueIndex);
#endif
                return true;
            }

            value = default;
            return false;
        }

        bool IMutableJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement.Mutable value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
                value = new JsonElement.Mutable(this, valueIndex);
                return true;
            }

            value = default;
            return false;

        }

        // TODO: figure out how to bridge from the non-mutable to mutable document in this deferral case
        bool IMutableJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement.Mutable value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
                value = new JsonElement.Mutable(this, valueIndex);
                return true;
            }

            value = default;
            return false;
        }

        bool IJsonDocument.TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<char> propertyName, out TElement value)
        {
            CheckNotDisposed();

            if (TryGetNamedPropertyValueUnsafe(
                index,
                propertyName,
                out int valueIndex))
            {
#if NET
                value = TElement.CreateInstance(this, valueIndex);
#else
                value = JsonElementHelpers.CreateInstance<TElement>(this, valueIndex);
#endif
                return true;
            }

            value = default;
            return false;
        }

        int IJsonDocument.GetHashCode(int index)
        {
            CheckNotDisposed();
            return GetHashCodeUnsafe(index);
        }

        int IJsonDocument.BuildRentedMetadataDb(int index, JsonWorkspace workspace, out byte[] rentedBacking)
        {
            CheckNotDisposed();
            CheckImmutable();

            int workspaceDocumentIndex = workspace.GetDocumentIndex(this);

            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.BuildRentedMetadataDb(row.LocationOrIndex, workspace, out rentedBacking);
            }

            int estimatedRowCount;
            if (row.IsSimpleValue)
            {
                // Simple values are a single row.
                estimatedRowCount = 1;
            }
            else
            {
                // Number of rows + end row.
                estimatedRowCount = GetDbSizeUnsafe(index, true);
            }

            MetadataDb db = MetadataDb.CreateRented(estimatedRowCount * DbRow.Size, false);
            AppendLocalElement(index, workspace, ref db, workspaceDocumentIndex);
            // Note we just orphan this db instance, as we are passing the underlying
            // byte array off to the dynamically created document that wants it.
            return db.TakeOwnership(out rentedBacking);
        }

        void IJsonDocument.AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db)
        {
            CheckNotDisposed();
            CheckNotImmutable();

            int workspaceDocumentIndex = workspace.GetDocumentIndex(this);
            AppendElement(index, workspace, ref db, workspaceDocumentIndex);
        }


        private void AppendElement(int index, JsonWorkspace workspace, ref MetadataDb db, int workspaceDocumentIndex)
        {
            DbRow row = _parsedData.Get(index);

            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                document.AppendElementToMetadataDb(row.LocationOrIndex, workspace, ref db);
                return;
            }

            switch (row.TokenType)
            {
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.Null:
                case JsonTokenType.Number:
                case JsonTokenType.String:
                case JsonTokenType.PropertyName:
                    db.AppendExternal(row.TokenType, index, row.RawSizeOrLength, workspaceDocumentIndex);
                    return;

                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    ProcessComplexObject(index, workspace, ref db, workspaceDocumentIndex);
                    return;
            }

            Debug.Fail($"Unexpected encounter with JsonTokenType {_parsedData.GetJsonTokenType(index)}");
        }

        private void ProcessComplexObject(int index, JsonWorkspace workspace, ref MetadataDb db, int workspaceDocumentIndex)
        {
            DbRow complexObjectRow = _parsedData.Get(index);
            db.AppendExternal(complexObjectRow.TokenType, index, complexObjectRow.RawSizeOrLength, workspaceDocumentIndex);

            int endIndex = index + GetDbSizeUnsafe(index, false);

            for (int i = index + DbRow.Size; i < endIndex; i += DbRow.Size)
            {
                int currentLength = db.Length;
                AppendElement(i, workspace, ref db, workspaceDocumentIndex);
                i += db.Length - currentLength - DbRow.Size;
            }

            complexObjectRow = _parsedData.Get(endIndex);
            int entityLength = complexObjectRow.HasPropertyMap ? GetLengthOfEndToken(complexObjectRow.SizeOrLengthOrPropertyMapIndex) : complexObjectRow.RawSizeOrLength;
            db.AppendExternal(complexObjectRow.TokenType, index, entityLength, workspaceDocumentIndex);
        }

        private void AppendLocalElement(int index, JsonWorkspace workspace, ref MetadataDb db, int workspaceDocumentIndex)
        {
            switch (_parsedData.GetJsonTokenType(index))
            {
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.Null:
                case JsonTokenType.Number:
                case JsonTokenType.String:
                case JsonTokenType.PropertyName:
                    DbRow row = _parsedData.Get(index);
                    db.AppendExternal(row.TokenType, index, row.RawSizeOrLength, workspaceDocumentIndex);
                    return;

                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    ProcessComplexObject(index, workspace, ref db, workspaceDocumentIndex);
                    return;
            }

            Debug.Fail($"Unexpected encounter with JsonTokenType {_parsedData.GetJsonTokenType(index)}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckNotDisposed()
        {
            if (_parentWorkspaceIndex < 0)
            {
                ThrowHelper.ThrowObjectDisposedException_JsonDocument();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckNotImmutable()
        {
            if (_isImmutable)
            {
                ThrowHelper.ThrowInvalidOperationException(SR.CannotModifyAnImmutableDocument);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckImmutable()
        {
            if (!_isImmutable)
            {
                ThrowHelper.ThrowInvalidOperationException(SR.CannotCreateBuilderFromMutableDocument);
            }
        }


        int IMutableJsonDocument.StoreBooleanValue(bool value) => StoreBooleanValue(value);
        int IMutableJsonDocument.StoreNullValue() => StoreNullValue();
        int IMutableJsonDocument.StoreRawNumberValue(ReadOnlySpan<byte> value) => StoreRawNumberValue(value);
        int IMutableJsonDocument.EscapeAndStoreRawStringValue(ReadOnlySpan<byte> value, out bool requiredEscaping) => EscapeAndStoreRawStringValue(value, out requiredEscaping, _workspace.Options.Encoder);
        int IMutableJsonDocument.EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, out bool requiredEscaping) => EscapeAndStoreRawStringValue(value, out requiredEscaping, _workspace.Options.Encoder);
        int IMutableJsonDocument.StoreRawStringValue(ReadOnlySpan<byte> value) => StoreRawStringValue(value);
        int IMutableJsonDocument.StoreValue(Guid value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in DateTime value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in DateTimeOffset value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in OffsetDateTime value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in OffsetDate value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in OffsetTime value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in LocalDate value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(in Period value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(sbyte value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(byte value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(int value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(uint value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(long value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(ulong value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(short value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(ushort value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(float value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(double value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(decimal value) => StoreValue(value);
#if NET
        int IMutableJsonDocument.StoreValue(Int128 value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(UInt128 value) => StoreValue(value);
        int IMutableJsonDocument.StoreValue(Half value) => StoreValue(value);
#endif
    }
}
