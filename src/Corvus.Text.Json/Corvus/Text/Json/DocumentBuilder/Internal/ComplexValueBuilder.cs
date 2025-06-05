// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using NodaTime;

namespace Corvus.Text.Json.Internal
{
    public ref struct ComplexValueBuilder
    {
        public delegate void ValueBuilderAction(ref ComplexValueBuilder builder);

        private IMutableJsonDocument _parentDocument;
        private MetadataDb _parsedData;
        private int _memberCount;
        private int _rowCount;

        private ComplexValueBuilder(IMutableJsonDocument parentDocument, MetadataDb parsedData)
        {
            _parentDocument = parentDocument;
            _parsedData = parsedData;
            _memberCount = 0;
            _rowCount = 0;
        }

        internal int Length => _parsedData.Length;

        public int MemberCount => _memberCount;

        [CLSCompliant(false)]
        public static ComplexValueBuilder Create(IMutableJsonDocument parentDocument, int initialElementCount)
        {
            return new(parentDocument, MetadataDb.CreateRented(initialElementCount * DbRow.Size, convertToAlloc: false));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ValueBuilderAction createComplexValue)
        {
            AddProperty(propertyName, createComplexValue, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, ValueBuilderAction createComplexValue, bool escapeName, bool nameRequiresUnescaping)
        {
            int currentMemberCount = _memberCount;
            int currentRowCount = _rowCount;
            _memberCount = 0;
            _rowCount = 0;
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            createComplexValue(ref this);
            _memberCount = currentMemberCount + 1;
            _rowCount = currentRowCount + _rowCount + 1;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, ValueBuilderAction createComplexValue)
        {
            int currentMemberCount = _memberCount;
            int currentRowCount = _rowCount;
            _memberCount = 0;
            _rowCount = 0;
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            createComplexValue(ref this);
            _memberCount = currentMemberCount + 1;
            _rowCount = currentRowCount + _rowCount + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
        {
            AddProperty(propertyName, utf8String, escapeName: true, escapeValue: true, false, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            AddStringValue(JsonTokenType.String, utf8String, escapeValue, valueRequiresUnescaping);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            AddStringValue(JsonTokenType.String, value);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
        {
            AddPropertyFormattedNumber(propertyName, value, true, false);
        }

        public void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreRawNumberValue(value), requiresUnescapingOrHasExponent: value.IndexOfAny((byte)'e', (byte)'E') >= 0);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddPropertyRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            AddStringValue(JsonTokenType.String, value, escape: false, ifNotEscapeRequiresUenscaping: valueRequiresUnescaping);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddPropertyNull(ReadOnlySpan<byte> propertyName)
        {
            AddPropertyNull(propertyName, true, false);
        }

        public void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Null, _parentDocument.StoreNullValue(), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddPropertyNull(ReadOnlySpan<char> propertyName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Null, _parentDocument.StoreNullValue(), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(value ? JsonTokenType.True : JsonTokenType.False, _parentDocument.StoreBooleanValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, bool value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(value ? JsonTokenType.True : JsonTokenType.False, _parentDocument.StoreBooleanValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<byte> propertyName, in T value)
            where T : struct, IJsonElement<T>
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
            where T : struct, IJsonElement<T>
        {
            int currentLength = Length;
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            value.ParentDocument.AppendElementToMetadataDb(value.ParentDocumentIndex, _parentDocument.Workspace, ref _parsedData);
            _memberCount += 1;
            _rowCount += (Length - currentLength) / DbRow.Size;
        }

        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
            where T : struct, IJsonElement<T>
        {
            int currentLength = Length;
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            value.ParentDocument.AppendElementToMetadataDb(value.ParentDocumentIndex, _parentDocument.Workspace, ref _parsedData);
            _memberCount += 1;
            _rowCount += (Length - currentLength) / DbRow.Size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
        {
            AddProperty(propertyName, value, true, false);
        }
       
        public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in DateTime value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in DateTime value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in DateTime value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in DateTimeOffset value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in DateTimeOffset value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetDateTime value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in OffsetDateTime value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetTime value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in OffsetTime value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetDate value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in OffsetDate value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in LocalDate value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in LocalDate value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in LocalDate value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, in Period value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, in Period value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, in Period value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, byte value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, int value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, int value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<char> propertyName, uint value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, long value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, long value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, short value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, short value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, float value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, float value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, double value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, double value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

#if NET
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
        {
            AddProperty(propertyName, value, true, false);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
        {
            AddProperty(propertyName, value, true, false);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName, nameRequiresUnescaping);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }

        public void AddProperty(ReadOnlySpan<char> propertyName, Half value)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount += 2;
        }
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddItem(ReadOnlySpan<byte> utf8String)
        {
            AddItem(utf8String, true, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddItem(string value)
        {
            AddItem(value.AsSpan());
        }

        public void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue, bool requiresUnescaping)
        {
            AddStringValue(JsonTokenType.String, utf8String, escapeValue, requiresUnescaping);
            _memberCount += 1;
            _rowCount += 1;
        }

        public void AddItem(ReadOnlySpan<char> value)
        {
            AddStringValue(JsonTokenType.String, value);
            _memberCount += 1;
            _rowCount += 1;
        }

        public void AddItemRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
        {
            AddStringValue(JsonTokenType.String, value, false, requiresUnescaping);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(ValueBuilderAction createValue)
        {
            int currentMemberCount = _memberCount;
            int currentRowCount = _rowCount;
            _memberCount = 0;
            _rowCount = 0;
            createValue(ref this);
            _memberCount = currentMemberCount + 1;
            _rowCount += currentRowCount;
        }

        public void AddItemNull()
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Null, _parentDocument.StoreNullValue(), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(bool value)
        {
            _parsedData.AppendDynamicSimpleValue(value ? JsonTokenType.True : JsonTokenType.False, _parentDocument.StoreBooleanValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItemFormattedNumber(ReadOnlySpan<byte> value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreRawNumberValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem<T>(in T value)
            where T : struct, IJsonElement<T>
        {
            int currentLength = Length;
            value.ParentDocument.AppendElementToMetadataDb(value.ParentDocumentIndex, _parentDocument.Workspace, ref _parsedData);
            _memberCount += 1;
            _rowCount += (Length - currentLength) / DbRow.Size;
        }

        public void AddItem(Guid value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in DateTime value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in DateTimeOffset value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in OffsetDateTime value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in OffsetDate value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in OffsetTime value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in LocalDate value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(in Period value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem(sbyte value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(byte value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(int value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem(uint value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(long value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem(ulong value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(short value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem(ushort value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(float value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(double value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(decimal value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

#if NET
        public void AddItem(Int128 value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void AddItem(UInt128 value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }

        public void AddItem(Half value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
            _rowCount++;
        }
#endif
        public void StartObject()
        {
            _parsedData.Append(JsonTokenType.StartObject, 0, -1);
            _rowCount++;
        }

        [CLSCompliant(false)]
        public void StartArray()
        {
            _parsedData.Append(JsonTokenType.StartArray, 0, -1);
            _rowCount++;
        }

        public void EndObject()
        {
            int startRowIndex = Length - (_rowCount * DbRow.Size);
            _parsedData.Append(JsonTokenType.EndObject, 0, 1);
            _parsedData.SetLength(startRowIndex, _memberCount);
            _parsedData.SetNumberOfRows(startRowIndex, _rowCount);
            _parsedData.SetNumberOfRows(_parsedData.Length - DbRow.Size, _rowCount);

            // Now increment for the parent
            _rowCount++;
        }

        public void EndArray()
        {
            int startRowIndex = Length - (_rowCount * DbRow.Size);
            _parsedData.Append(JsonTokenType.EndArray, 0, 1);
            _parsedData.SetLength(startRowIndex, _memberCount);

            // If the array item count is (e.g.) 12 and the number of rows is (e.g.) 13
            // then the extra row is just the EndArray item, so the array was made up
            // of simple values.
            //
            // If the off-by-one relationship does not hold, then one of the values was
            // more than one row, making it a complex object.
            //
            // This check is similar to tracking the start array and painting it when
            // StartObject or StartArray is encountered, but avoids the mixed state
            // where "UnknownSize" implies "has complex children".
            if (_memberCount + 1 != _rowCount)
            {
                _parsedData.SetHasComplexChildren(startRowIndex);
            }

            _parsedData.SetNumberOfRows(startRowIndex, _rowCount);
            _parsedData.SetNumberOfRows(_parsedData.Length - DbRow.Size, _rowCount);

            // Now increment for the parent
            _rowCount++;
        }

        public void SetAndDispose(ref MetadataDb targetData)
        {
            // We don't need to initialize the metadata DB if we are creating a whole document
            // This allows us to hand off the parsed data rather than writing it in.
            Debug.Assert(!targetData.IsInitialized);
            targetData = _parsedData;
        }

        public void InsertAndDispose(int complexObjectStartIndex, int targetIndex, ref MetadataDb targetData)
        {
            targetData.InsertRowsInComplexObject(_parentDocument, complexObjectStartIndex, targetIndex, _rowCount, _memberCount);
            _parsedData.Overwrite(ref targetData, targetIndex);
        }

        public void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int memberCountToReplace, ref MetadataDb targetData)
        {
            targetData.ReplaceRowsInComplexObject(_parentDocument, complexObjectStartIndex, startIndex, endIndex, memberCountToReplace, _rowCount, _memberCount);
            _parsedData.Overwrite(ref targetData, startIndex);
        }

        private void AddStringValue(JsonTokenType tokenType, ReadOnlySpan<byte> stringValue, bool escape, bool ifNotEscapeRequiresUenscaping)
        {
            Debug.Assert(tokenType is JsonTokenType.PropertyName or JsonTokenType.String);

            if (!escape)
            {
                int location = _parentDocument.StoreRawStringValue(stringValue);
                _parsedData.AppendDynamicSimpleValue(tokenType, location, requiresUnescapingOrHasExponent: ifNotEscapeRequiresUenscaping);
            }
            else
            {
                int location = _parentDocument.EscapeAndStoreRawStringValue(stringValue, out bool requiredEscaping);
                _parsedData.AppendDynamicSimpleValue(tokenType, location, requiresUnescapingOrHasExponent: requiredEscaping);
            }
        }

        private void AddStringValue(JsonTokenType tokenType, ReadOnlySpan<char> stringValue)
        {
            Debug.Assert(tokenType is JsonTokenType.PropertyName or JsonTokenType.String);

            int location = _parentDocument.EscapeAndStoreRawStringValue(stringValue, out bool requiredEscaping);
            _parsedData.AppendDynamicSimpleValue(tokenType, location, requiresUnescapingOrHasExponent: requiredEscaping);
        }

    }
}
