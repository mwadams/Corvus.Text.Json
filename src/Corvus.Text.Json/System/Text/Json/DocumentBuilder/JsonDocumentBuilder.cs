// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Corvus.Text.Json
{
    public sealed partial class JsonDocumentBuilder : JsonDocument, IJsonDocument
    {
        private static readonly JsonWriterOptions InternalWriterOptions = new() { Indented = false };
        private readonly JsonWorkspace _workspace;
        private int _parentWorkspaceIndex = -1;

        internal JsonDocumentBuilder(JsonWorkspace workspace)
        {
            _workspace = workspace;
        }

        bool IJsonDocument.IsDisposable => true;

        public override JsonElement RootElement => new JsonElement(this, 0);

        internal void Initialize<TElement>(TElement sourceElement, int parentWorkspaceIndex, bool convertToAlloc)
            where TElement : struct, IJsonElement<TElement>
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;
            byte[] metadataDbBytes;
            sourceElement.CheckValidInstance();
            int metadataDbLength = sourceElement.ParentDocument.BuildRentedMetadataDb(sourceElement.ParentDocumentIndex, _workspace, out metadataDbBytes);
            _parsedData = MetadataDb.CreateRented(metadataDbBytes, metadataDbLength, convertToAlloc);
        }
        internal void Initialize(int parentWorkspaceIndex, int initialElementCount)
        {
            _parentWorkspaceIndex = parentWorkspaceIndex;
            _parsedData = MetadataDb.CreateRented(initialElementCount * DbRow.Size, convertToAlloc: false);
        }

        void IDisposable.Dispose()
        {
            if (_parentWorkspaceIndex == -1)
            {
                return;
            }

            base.Dispose();

            this._parentWorkspaceIndex = -1;
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

        int IJsonDocument.GetEndIndex(int index, bool includeEndElement)
        {
            CheckNotDisposed();
            return GetEndIndexUnsafe(index, includeEndElement);
        }

        RawUtf8JsonString IJsonDocument.GetRawValue(int index, bool includeQuotes)
        {
            CheckNotDisposed();
            return GetRawValueUnsafe(index, includeQuotes);
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
            Utf8JsonWriter writer = Utf8JsonWriterCache.RentWriterAndBuffer(InternalWriterOptions, _parsedData.Length, out PooledByteBufferWriter bufferWriter);
            try
            {
                WriteElementToUnsafe(index, writer);
                writer.Flush();
                int length = bufferWriter.WrittenSpan.Length;
                byte[] additionalRentedBytes = ArrayPool<byte>.Shared.Rent(length);
                bufferWriter.WrittenSpan.CopyTo(additionalRentedBytes.AsSpan());
                return new(additionalRentedBytes.AsMemory(0, length));

            }
            finally
            {
                Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
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

            using RawUtf8JsonString segment = GetRawValueUnsafe(index, includeQuotes: true);
            return JsonReaderHelper.TranscodeHelper(segment.Span);
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
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.GetPropertyRawValueAsString(row.LocationOrIndex);
            }

            Utf8JsonWriter writer = Utf8JsonWriterCache.RentWriterAndBuffer(InternalWriterOptions, _parsedData.Length, out PooledByteBufferWriter bufferWriter);
            try
            {
                // We have to write a property in an object context.
                writer.WriteStartObject();
                WritePropertyName(propertyNameIndex, writer);
                WriteElementToUnsafe(valueIndex, writer);
                // Note that we do not have to write the end object, we are not processing this as JSON
                writer.Flush();
                // Slice off the initial object curly brace; we are in compact form
                // so there should be no whitespace.
                return JsonReaderHelper.TranscodeHelper(bufferWriter.WrittenSpan.Slice(1));
            }
            finally
            {
                Utf8JsonWriterCache.ReturnWriterAndBuffer(writer, bufferWriter);
            }
        }

        JsonElement IJsonDocument.CloneElement(int index)
        {
            return CloneElement(index, false);
        }

        public JsonElement CloneElement(int index, bool addDocumentToWorkspace)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.CloneElement(row.LocationOrIndex);
            }

            using RawUtf8JsonString rawUtf8Json = GetRawValueUnsafe(index, includeQuotes: true);

            ReadOnlyMemory<byte> segmentCopy;
            byte[]? extraRentedArrayPoolBytes = null;
            if (addDocumentToWorkspace)
            {
                segmentCopy = rawUtf8Json.TakeOwnership(out extraRentedArrayPoolBytes);
            }
            else
            {
                segmentCopy = rawUtf8Json.Span.ToArray();
            }

            ParsedJsonDocument newDocument =
                ParsedJsonDocument.Parse(segmentCopy);

            if (addDocumentToWorkspace)
            {
                _workspace.GetDocumentIndex(newDocument);
            }

            return newDocument.RootElement;
        }

        void IJsonDocument.WriteElementTo(
            int index,
            Utf8JsonWriter writer)
        {
            CheckNotDisposed();
            WriteElementToUnsafe(index, writer);
        }

        private void WriteElementToUnsafe(
            int index,
            Utf8JsonWriter writer)
        {
            throw new NotImplementedException();
        }

        void IJsonDocument.WritePropertyName(int index, Utf8JsonWriter writer)
        {
            CheckNotDisposed();

            Debug.Assert(_parsedData.Get(index - DbRow.Size).TokenType == JsonTokenType.PropertyName);
            WritePropertyName(index - DbRow.Size, writer);
        }

        private void WritePropertyName(int index, Utf8JsonWriter writer)
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

        private ReadOnlySpan<byte> UnescapeString(int index, out ArraySegment<byte> rented)
        {
            DbRow row = _parsedData.Get(index);

            Debug.Assert(row.TokenType == JsonTokenType.String || row.TokenType == JsonTokenType.PropertyName);
            int loc = row.LocationOrIndex;
            int length = row.SizeOrLengthOrPropertyMapIndex;
            ReadOnlySpan<byte> text = GetRawSimpleValueUnsafe(index, false).Span;

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

        internal void CompleteAllocations()
        {
            _parsedData.CompleteAllocations();
        }

        bool IJsonDocument.TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value)
        {
            CheckNotDisposed();

            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.TryGetNamedPropertyValue(row.LocationOrIndex, propertyName, out value);
            }

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

            DbRow row = _parsedData.Get(index);

            // If the row is from an external document, we defer to that
            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                return document.TryGetNamedPropertyValue(row.LocationOrIndex, propertyName, out value);
            }

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

        int IJsonDocument.BuildRentedMetadataDb(int index, JsonWorkspace workspace, out byte[] rentedBacking)
        {
            CheckNotDisposed();

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
                estimatedRowCount = row.NumberOfRows + 1;
            }

            MetadataDb db = MetadataDb.CreateRented(estimatedRowCount * DbRow.Size, false);
            AppendLocalElement(index, workspace, ref db, workspaceDocumentIndex);
            // Note we just orphan this db instance, as we are passing the underlying
            // byte array off to the dynamically created document that wants it.
            return db.TakeOwnership(out rentedBacking);
        }

        void IJsonDocument.AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref byte[] data, ref int length) => throw new NotImplementedException();


        private void AppendElement(int index, JsonWorkspace workspace, ref MetadataDb db, int workspaceDocumentIndex)
        {
            DbRow row = _parsedData.Get(index);

            if (row.FromExternalDocument)
            {
                IJsonDocument document = _workspace.GetDocument(row.WorkspaceDocumentId);
                int length = db.TakeOwnership(out byte[] rentedBacking);
                document.AppendElementToMetadataDb(row.LocationOrIndex, workspace, ref rentedBacking, ref length);
                db = MetadataDb.WrapForBuilder(rentedBacking, length);
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
                    db.AppendExternal(row.TokenType, index, 1, workspaceDocumentIndex);
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

            int endIndex = GetEndIndexUnsafe(index, true);

            for (int i = index + DbRow.Size; i < endIndex; i += DbRow.Size)
            {
                AppendElement(i, workspace, ref db, workspaceDocumentIndex);
            }

            complexObjectRow = _parsedData.Get(endIndex);
            db.AppendExternal(complexObjectRow.TokenType, index, complexObjectRow.RawSizeOrLength, workspaceDocumentIndex);
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
                    db.AppendExternal(row.TokenType, index, 1, workspaceDocumentIndex);
                    return;

                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    ProcessComplexObject(index, workspace, ref db, workspaceDocumentIndex);
                    return;
            }

            Debug.Fail($"Unexpected encounter with JsonTokenType {_parsedData.GetJsonTokenType(index)}");
        }

        private void CheckNotDisposed()
        {
            if (_parentWorkspaceIndex < 0)
            {
                ThrowHelper.ThrowObjectDisposedException_JsonDocument();
            }
        }
    }
}
