// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   Represents the structure of a JSON value in a lightweight, read-only form.
    /// </summary>
    /// <remarks>
    ///   This class utilizes resources from pooled memory to minimize the garbage collector (GC)
    ///   impact in high-usage scenarios. Failure to properly Dispose this object will result in
    ///   the memory not being returned to the pool, which will cause an increase in GC impact across
    ///   various parts of the framework.
    /// </remarks>
    public sealed partial class ParsedJsonDocument : JsonDocument, IJsonDocument, IDisposable
    {
        private ReadOnlyMemory<byte> _utf8Json;
        private bool _isDisposable;
        private byte[]? _extraRentedArrayPoolBytes;
        private PooledByteBufferWriter? _extraPooledByteBufferWriter;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        bool IJsonDocument.IsDisposable => _isDisposable;

        /// <summary>
        ///   The <see cref="JsonElement"/> representing the value of the document.
        /// </summary>
        public JsonElement RootElement => new JsonElement(this, 0);

        private ParsedJsonDocument(
            ReadOnlyMemory<byte> utf8Json,
            MetadataDb parsedData,
            byte[]? extraRentedArrayPoolBytes = null,
            PooledByteBufferWriter? extraPooledByteBufferWriter = null,
            bool isDisposable = true)
        {
            Debug.Assert(!utf8Json.IsEmpty);

            // Both rented values better be null if we're not disposable.
            Debug.Assert(isDisposable ||
                (extraRentedArrayPoolBytes == null && extraPooledByteBufferWriter == null));

            // Both rented values can't be specified.
            Debug.Assert(extraRentedArrayPoolBytes == null || extraPooledByteBufferWriter == null);

            _utf8Json = utf8Json;
            _parsedData = parsedData;
            _extraRentedArrayPoolBytes = extraRentedArrayPoolBytes;
            _extraPooledByteBufferWriter = extraPooledByteBufferWriter;
            _isDisposable = isDisposable;
        }
        
        /// <inheritdoc />
        public void Dispose()
        {
            int length = _utf8Json.Length;
            if (length == 0 || !_isDisposable)
            {
                return;
            }

            DisposeCore();

            _utf8Json = ReadOnlyMemory<byte>.Empty;

            if (_extraRentedArrayPoolBytes != null)
            {
                byte[]? extraRentedBytes = Interlocked.Exchange<byte[]?>(ref _extraRentedArrayPoolBytes, null);

                if (extraRentedBytes != null)
                {
                    // When "extra rented bytes exist" it contains the document,
                    // and thus needs to be cleared before being returned.
                    extraRentedBytes.AsSpan(0, length).Clear();
                    ArrayPool<byte>.Shared.Return(extraRentedBytes);
                }
            }
            else if (_extraPooledByteBufferWriter != null)
            {
                PooledByteBufferWriter? extraBufferWriter = Interlocked.Exchange<PooledByteBufferWriter?>(ref _extraPooledByteBufferWriter, null);
                extraBufferWriter?.Dispose();
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

        JsonTokenType IJsonDocument.GetJsonTokenType(int index)
        {
            CheckNotDisposed();

            return _parsedData.GetJsonTokenType(index);
        }

        void IJsonDocument.EnsurePropertyMap(int index)
        {
            if (_isDisposable)
            {
                CheckNotDisposed();

                EnsurePropertyMapUnsafe(index);
            }
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

        int IJsonDocument.GetEndIndex(int index, bool includeEndElement)
        {
            CheckNotDisposed();
            return GetEndIndexUnsafe(index, includeEndElement);
        }

        RawUtf8JsonString IJsonDocument.GetRawValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();
            return new(GetRawValueUnsafe(index, includeQuotes));
        }

        private ReadOnlyMemory<byte> GetRawValueUnsafe(int index, bool includeQuotes)
        {
            DbRow row = _parsedData.Get(index);

            if (row.IsSimpleValue)
            {
                if (includeQuotes && row.TokenType == JsonTokenType.String)
                {
                    // Start one character earlier than the value (the open quote)
                    // End one character after the value (the close quote)
                    return _utf8Json.Slice(row.LocationOrIndex - 1, row.SizeOrLengthOrPropertyMapIndex + 2);
                }

                return _utf8Json.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);
            }

            int endElementIdx = GetEndIndexUnsafe(index, includeEndElement: false);
            int start = row.LocationOrIndex;
            row = _parsedData.Get(endElementIdx);
            return _utf8Json.Slice(start, row.LocationOrIndex - start + row.SizeOrLengthOrPropertyMapIndex);
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

            if (includeQuotes && row.TokenType == JsonTokenType.String)
            {
                // Start one character earlier than the value (the open quote)
                // End one character after the value (the close quote)
                return _utf8Json.Slice(row.LocationOrIndex - 1, row.SizeOrLengthOrPropertyMapIndex + 2);
            }

            return _utf8Json.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);
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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

            return row.HasComplexChildren
                ? JsonReaderHelper.GetUnescapedString(segment)
                : JsonReaderHelper.TranscodeHelper(segment);
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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

            if (Utf8Parser.TryParse(segment, out decimal tmp, out int bytesConsumed) &&
                segment.Length == bytesConsumed)
            {
                value = tmp;
                return true;
            }

            value = 0;
            return false;
        }

        bool IJsonDocument.TryGetValue(int index, out DateTime value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

        bool IJsonDocument.TryGetValue(int index, out Guid value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            CheckExpectedType(JsonTokenType.String, row.TokenType);

            ReadOnlySpan<byte> data = _utf8Json.Span;
            ReadOnlySpan<byte> segment = data.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex);

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

            ReadOnlyMemory<byte> segment = GetRawValueUnsafe(index, includeQuotes: true);
            return JsonReaderHelper.TranscodeHelper(segment.Span);
        }

        string IJsonDocument.GetPropertyRawValueAsString(int valueIndex)
        {
            CheckNotDisposed();
            // The property name is stored one row before the value
            DbRow row = _parsedData.Get(valueIndex - DbRow.Size);
            Debug.Assert(row.TokenType == JsonTokenType.PropertyName);

            // Subtract one for the open quote.
            int start = row.LocationOrIndex - 1;
            int end;

            row = _parsedData.Get(valueIndex);

            if (row.IsSimpleValue)
            {
                end = row.LocationOrIndex + row.SizeOrLengthOrPropertyMapIndex;

                // If the value was a string, pick up the terminating quote.
                if (row.TokenType == JsonTokenType.String)
                {
                    end++;
                }

                return JsonReaderHelper.TranscodeHelper(_utf8Json.Slice(start, end - start).Span);
            }

            int endElementIdx = GetEndIndexUnsafe(valueIndex, includeEndElement: false);
            row = _parsedData.Get(endElementIdx);
            end = row.LocationOrIndex + row.SizeOrLengthOrPropertyMapIndex;
            return JsonReaderHelper.TranscodeHelper(_utf8Json.Slice(start, end - start).Span);
        }

        JsonElement IJsonDocument.CloneElement(int index)
        {
            CheckNotDisposed();

            int endIndex = GetEndIndexUnsafe(index, true);
            MetadataDb newDb = _parsedData.CopySegment(index, endIndex);
            ReadOnlyMemory<byte> segmentCopy = GetRawValueUnsafe(index, includeQuotes: true).ToArray();

            ParsedJsonDocument newDocument =
                new ParsedJsonDocument(
                    segmentCopy,
                    newDb,
                    extraRentedArrayPoolBytes: null,
                    extraPooledByteBufferWriter: null,
                    isDisposable: false);

            return newDocument.RootElement;
        }

        void IJsonDocument.WriteElementTo(
            int index,
            Utf8JsonWriter writer)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            switch (row.TokenType)
            {
                case JsonTokenType.StartObject:
                    writer.WriteStartObject();
                    WriteComplexElement(index, writer);
                    return;
                case JsonTokenType.StartArray:
                    writer.WriteStartArray();
                    WriteComplexElement(index, writer);
                    return;
                case JsonTokenType.String:
                    WriteString(row, writer);
                    return;
                case JsonTokenType.Number:
                    writer.WriteNumberValue(_utf8Json.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex).Span);
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

        private void WriteComplexElement(int index, Utf8JsonWriter writer)
        {
            int endIndex = GetEndIndexUnsafe(index, true);

            for (int i = index + DbRow.Size; i < endIndex; i += DbRow.Size)
            {
                DbRow row = _parsedData.Get(i);

                // All of the types which don't need the value span
                switch (row.TokenType)
                {
                    case JsonTokenType.String:
                        WriteString(row, writer);
                        continue;
                    case JsonTokenType.Number:
                        writer.WriteNumberValue(_utf8Json.Slice(row.LocationOrIndex, row.SizeOrLengthOrPropertyMapIndex).Span);
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
                        WritePropertyName(row, writer);
                        continue;
                }

                Debug.Fail($"Unexpected encounter with JsonTokenType {row.TokenType}");
            }
        }

        private ReadOnlySpan<byte> UnescapeString(in DbRow row, out ArraySegment<byte> rented)
        {
            Debug.Assert(row.TokenType == JsonTokenType.String || row.TokenType == JsonTokenType.PropertyName);
            int loc = row.LocationOrIndex;
            int length = row.SizeOrLengthOrPropertyMapIndex;
            ReadOnlySpan<byte> text = _utf8Json.Slice(loc, length).Span;

            if (!row.HasComplexChildren)
            {
                rented = default;
                return text;
            }

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

        void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index - DbRow.Size);
            Debug.Assert(row.TokenType == JsonTokenType.PropertyName);
            WritePropertyName(row, writer);
        }

        private void WritePropertyName(in DbRow row, Utf8JsonWriter writer)
        {
            ArraySegment<byte> rented = default;

            try
            {
                writer.WritePropertyName(UnescapeString(row, out rented));
            }
            finally
            {
                ClearAndReturn(rented);
            }
        }

        private void WriteString(in DbRow row, Utf8JsonWriter writer)
        {
            ArraySegment<byte> rented = default;

            try
            {
                writer.WriteStringValue(UnescapeString(row, out rented));
            }
            finally
            {
                ClearAndReturn(rented);
            }
        }

        private static void Parse(
            ReadOnlySpan<byte> utf8JsonSpan,
            JsonReaderOptions readerOptions,
            ref MetadataDb database,
            ref StackRowStack stack)
        {
            bool inArray = false;
            int arrayItemsOrPropertyCount = 0;
            int numberOfRowsForMembers = 0;
            int numberOfRowsForValues = 0;

            Utf8JsonReader reader = new Utf8JsonReader(
                utf8JsonSpan,
                isFinalBlock: true,
                new JsonReaderState(options: readerOptions));

            while (reader.Read())
            {
                JsonTokenType tokenType = reader.TokenType;

                // Since the input payload is contained within a Span,
                // token start index can never be larger than int.MaxValue (i.e. utf8JsonSpan.Length).
                Debug.Assert(reader.TokenStartIndex <= int.MaxValue);
                int tokenStart = (int)reader.TokenStartIndex;

                if (tokenType == JsonTokenType.StartObject)
                {
                    if (inArray)
                    {
                        arrayItemsOrPropertyCount++;
                    }

                    numberOfRowsForValues++;
                    database.Append(tokenType, tokenStart, DbRow.UnknownSize);
                    var row = new StackRow(arrayItemsOrPropertyCount, numberOfRowsForMembers + 1);
                    stack.Push(row);
                    arrayItemsOrPropertyCount = 0;
                    numberOfRowsForMembers = 0;
                }
                else if (tokenType == JsonTokenType.EndObject)
                {
                    int rowIndex = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartObject);

                    numberOfRowsForValues++;
                    numberOfRowsForMembers++;
                    database.SetLength(rowIndex, arrayItemsOrPropertyCount);

                    int newRowIndex = database.Length;
                    database.Append(tokenType, tokenStart, reader.ValueSpan.Length);
                    database.SetNumberOfRows(rowIndex, numberOfRowsForMembers);
                    database.SetNumberOfRows(newRowIndex, numberOfRowsForMembers);

                    StackRow row = stack.Pop();
                    arrayItemsOrPropertyCount = row.SizeOrLength;
                    numberOfRowsForMembers += row.NumberOfRows;
                }
                else if (tokenType == JsonTokenType.StartArray)
                {
                    if (inArray)
                    {
                        arrayItemsOrPropertyCount++;
                    }

                    numberOfRowsForMembers++;
                    database.Append(tokenType, tokenStart, DbRow.UnknownSize);
                    var row = new StackRow(arrayItemsOrPropertyCount, numberOfRowsForValues + 1);
                    stack.Push(row);
                    arrayItemsOrPropertyCount = 0;
                    numberOfRowsForValues = 0;
                }
                else if (tokenType == JsonTokenType.EndArray)
                {
                    int rowIndex = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartArray);

                    numberOfRowsForValues++;
                    numberOfRowsForMembers++;
                    database.SetLength(rowIndex, arrayItemsOrPropertyCount);
                    database.SetNumberOfRows(rowIndex, numberOfRowsForValues);

                    // If the array item count is (e.g.) 12 and the number of rows is (e.g.) 13
                    // then the extra row is just this EndArray item, so the array was made up
                    // of simple values.
                    //
                    // If the off-by-one relationship does not hold, then one of the values was
                    // more than one row, making it a complex object.
                    //
                    // This check is similar to tracking the start array and painting it when
                    // StartObject or StartArray is encountered, but avoids the mixed state
                    // where "UnknownSize" implies "has complex children".
                    if (arrayItemsOrPropertyCount + 1 != numberOfRowsForValues)
                    {
                        database.SetHasComplexChildren(rowIndex);
                    }

                    int newRowIndex = database.Length;
                    database.Append(tokenType, tokenStart, reader.ValueSpan.Length);
                    database.SetNumberOfRows(newRowIndex, numberOfRowsForValues);

                    StackRow row = stack.Pop();
                    arrayItemsOrPropertyCount = row.SizeOrLength;
                    numberOfRowsForValues += row.NumberOfRows;
                }
                else if (tokenType == JsonTokenType.PropertyName)
                {
                    numberOfRowsForValues++;
                    numberOfRowsForMembers++;
                    arrayItemsOrPropertyCount++;

                    // Adding 1 to skip the start quote will never overflow
                    Debug.Assert(tokenStart < int.MaxValue);

                    database.Append(tokenType, tokenStart + 1, reader.ValueSpan.Length);

                    if (reader.ValueIsEscaped)
                    {
                        database.SetHasComplexChildren(database.Length - DbRow.Size);
                    }

                    Debug.Assert(!inArray);
                }
                else
                {
                    Debug.Assert(tokenType >= JsonTokenType.String && tokenType <= JsonTokenType.Null);
                    numberOfRowsForValues++;
                    numberOfRowsForMembers++;

                    if (inArray)
                    {
                        arrayItemsOrPropertyCount++;
                    }

                    if (tokenType == JsonTokenType.String)
                    {
                        // Adding 1 to skip the start quote will never overflow
                        Debug.Assert(tokenStart < int.MaxValue);

                        database.Append(tokenType, tokenStart + 1, reader.ValueSpan.Length);

                        if (reader.ValueIsEscaped)
                        {
                            database.SetHasComplexChildren(database.Length - DbRow.Size);
                        }
                    }
                    else
                    {
                        database.Append(tokenType, tokenStart, reader.ValueSpan.Length);
                    }
                }

                inArray = reader.IsInArray;
            }

            Debug.Assert(reader.BytesConsumed == utf8JsonSpan.Length);
            database.CompleteAllocations();
        }

        private void CheckNotDisposed()
        {
            if (_utf8Json.IsEmpty)
            {
                ThrowHelper.ThrowObjectDisposedException_JsonDocument();
            }
        }

        private static void CheckSupportedOptions(
            JsonReaderOptions readerOptions,
            string paramName)
        {
            // Since these are coming from a valid instance of Utf8JsonReader, the JsonReaderOptions must already be valid
            Debug.Assert(readerOptions.CommentHandling >= 0 && readerOptions.CommentHandling <= JsonCommentHandling.Allow);

            if (readerOptions.CommentHandling == JsonCommentHandling.Allow)
            {
                throw new ArgumentException(SR.JsonDocumentDoesNotSupportComments, paramName);
            }
        }

        int IJsonDocument.BuildRentedMetadataDb(int index, JsonWorkspace workspace, out byte[] rentedBacking)
        {
            CheckNotDisposed();

            int workspaceDocumentIndex = workspace.GetDocumentIndex(this);

            DbRow row = _parsedData.Get(index);
            int estimatedRowCount;
            if (row.IsSimpleValue)
            {
                // Simple values are a single row.
                estimatedRowCount = 1;
            }
            else
            {
                // Number of rows + end row.
                estimatedRowCount = row.NumberOfRows + 1;
            }

            MetadataDb db = MetadataDb.CreateRented(estimatedRowCount * DbRow.Size, false);
            AppendElement(index, ref db, workspaceDocumentIndex);
            // Note we just orphan this db instance, as we are passing the underlying
            // byte array off to the dynamically created document that wants it.
            return db.TakeOwnership(out rentedBacking);
        }

        void IJsonDocument.AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref byte[] data, ref int length)
        {
            CheckNotDisposed();

            int workspaceDocumentIndex = workspace.GetDocumentIndex(this);
            MetadataDb db = MetadataDb.WrapForBuilder(data, length);
            AppendElement(index, ref db, workspaceDocumentIndex);
            length = db.TakeOwnership(out data);
        }

        private void AppendElement(int index, ref MetadataDb db, int workspaceDocumentIndex)
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
                    db.AppendExternal(row.TokenType, index, 1, workspaceDocumentIndex);
                    return;

                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    ProcessComplexObject(index, ref db, workspaceDocumentIndex);
                    return;
            }

            Debug.Fail($"Unexpected encounter with JsonTokenType {_parsedData.GetJsonTokenType(index)}");
        }

        private void ProcessComplexObject(int index, ref MetadataDb db, int workspaceDocumentIndex)
        {
            DbRow complexObjectRow = _parsedData.Get(index);
            db.AppendExternal(complexObjectRow.TokenType, index, complexObjectRow.RawSizeOrLength, workspaceDocumentIndex);

            int endIndex = GetEndIndexUnsafe(index, false);

            for (int i = index + DbRow.Size; i < endIndex; i += DbRow.Size)
            {
                AppendElement(i, ref db, workspaceDocumentIndex);
            }

            complexObjectRow = _parsedData.Get(endIndex);
            db.AppendExternal(complexObjectRow.TokenType, index, complexObjectRow.RawSizeOrLength, workspaceDocumentIndex);
        }
    }
}
