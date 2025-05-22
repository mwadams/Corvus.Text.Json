// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    public ref struct ComplexValueBuilder
    {
        public delegate void ValueBuilderAction(ref ComplexValueBuilder builder);

        private IMutableJsonDocument _parentDocument;
        private JsonDocument.MetadataDb _parsedData;
        private int _targetIndex;
        private int _memberCount;

        private ComplexValueBuilder(IMutableJsonDocument parentDocument, int targetIndex, JsonDocument.MetadataDb parsedData)
        {
            _parentDocument = parentDocument;
            _parsedData = parsedData;
            _targetIndex = targetIndex;
            _memberCount = 0;
        }


        internal int Length => _parsedData.Length;

        public int MemberCount => _memberCount;

        [CLSCompliant(false)]
        public static ComplexValueBuilder Create(IMutableJsonDocument parentDocument, int targetIndex, int initialElementCount)
        {
            return new(parentDocument, targetIndex, JsonDocument.MetadataDb.CreateRented(initialElementCount * JsonDocument.DbRow.Size, convertToAlloc: false));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ValueBuilderAction createComplexValue)
        {
            AddProperty(propertyName, createComplexValue, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, ValueBuilderAction createComplexValue, bool escapeName)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;

            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            createComplexValue(ref this);

            _memberCount = currentMemberCount + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
        {
            AddProperty(propertyName, utf8String, escapeName: true, escapeValue: true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            AddStringValue(JsonTokenType.String, utf8String, escapeValue);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddPropertyNull(ReadOnlySpan<byte> propertyName)
        {
            AddPropertyNull(propertyName, true);
        }

        public void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Null, _parentDocument.StoreNullValue(), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(value ? JsonTokenType.True : JsonTokenType.False, _parentDocument.StoreBooleanValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value)
            where T : struct, IJsonElement<T>
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName)
            where T : struct, IJsonElement<T>
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);

            value.ParentDocument.AppendElementToMetadataDb(value.ParentDocumentIndex, _parentDocument.Workspace, ref _parsedData);

            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.String, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, int value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, long value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, short value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, float value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, double value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

#if NET
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
        {
            AddProperty(propertyName, value, true);
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
        {
            AddProperty(propertyName, value, true);
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName)
        {
            AddStringValue(JsonTokenType.PropertyName, propertyName, escapeName);
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddItem(ReadOnlySpan<byte> utf8String)
        {
            AddItem(utf8String, true);
        }

        public void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue)
        {
            AddStringValue(JsonTokenType.String, utf8String, escapeValue);
            _memberCount += 1;
        }

        public void AddItem(ValueBuilderAction createValue)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            createValue(ref this);
            _memberCount = currentMemberCount + 1;
        }

        public void AddNullItem()
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Null, _parentDocument.StoreNullValue(), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(bool value)
        {
            _parsedData.AppendDynamicSimpleValue(value ? JsonTokenType.True : JsonTokenType.False, _parentDocument.StoreBooleanValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem<T>(T value)
            where T : struct, IJsonElement<T>
        {
            value.ParentDocument.AppendElementToMetadataDb(value.ParentDocumentIndex, _parentDocument.Workspace, ref _parsedData);
            _memberCount += 1;
        }

        public void AddItem(Guid value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem(sbyte value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(byte value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(int value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem(uint value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(long value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem(ulong value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(short value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem(ushort value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(float value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(double value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(decimal value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

#if NET
        public void AddItem(Int128 value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        [CLSCompliant(false)]
        public void AddItem(UInt128 value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }

        public void AddItem(Half value)
        {
            _parsedData.AppendDynamicSimpleValue(JsonTokenType.Number, _parentDocument.StoreValue(value), requiresUnescapingOrHasExponent: false);
            _memberCount += 1;
        }
#endif
        public void StartObject()
        {
            _parsedData.Append(JsonTokenType.StartObject, _targetIndex, -1);
        }

        [CLSCompliant(false)]
        public void StartArray()
        {
            _parsedData.Append(JsonTokenType.StartArray, _targetIndex, -1);
        }

        public void EndObject()
        {
            int length = _parsedData.Length / JsonDocument.DbRow.Size;
            // This must be an exact multiple of the number of rows
            Debug.Assert(_parsedData.Length % JsonDocument.DbRow.Size == 0);

            _parsedData.Append(JsonTokenType.EndObject, _targetIndex + Length, 1);
            _parsedData.SetLength(_targetIndex, _memberCount);
            _parsedData.SetNumberOfRows(_targetIndex, length);
            _parsedData.SetNumberOfRows(_parsedData.Length - JsonDocument.DbRow.Size, length);
        }

        public void EndArray()
        {
            int length = _parsedData.Length / JsonDocument.DbRow.Size;
            // This must be an exact multiple of the number of rows
            Debug.Assert(_parsedData.Length % JsonDocument.DbRow.Size == 0);
            _parsedData.Append(JsonTokenType.EndArray, _targetIndex + Length, 1);
            _parsedData.SetLength(_targetIndex, _memberCount);
            _parsedData.SetNumberOfRows(_targetIndex, length);

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
            if (_memberCount + 1 != length)
            {
                _parsedData.SetHasComplexChildren(_targetIndex);
            }

            _parsedData.SetNumberOfRows(_parsedData.Length - JsonDocument.DbRow.Size, length);
        }

        public void InsertAndDispose(ref JsonDocument.MetadataDb targetData)
        {
            // We don't need to initialize the metadata DB if we are creating a whole document
            // This allows us to hand off the parsed data rather than writing it in.
            if (!targetData.IsInitialized)
            {
                // The target index must be 0 for an uninitialized target.
                Debug.Assert(_targetIndex == 0);
                targetData = _parsedData;
            }
            else
            {
                _parsedData.Overwrite(ref targetData, _targetIndex);
                _parsedData.Dispose();
            }
        }

        private void AddStringValue(JsonTokenType tokenType, ReadOnlySpan<byte> stringValue, bool escape)
        {
            Debug.Assert(tokenType is JsonTokenType.PropertyName or JsonTokenType.String);

            if (!escape)
            {
                int location = _parentDocument.StoreRawStringValue(stringValue);
                _parsedData.AppendDynamicSimpleValue(tokenType, location, requiresUnescapingOrHasExponent: stringValue.IndexOf(JsonConstants.Quote) >= 0);
            }
            else
            {
                int location = _parentDocument.EscapeAndStoreRawStringValue(stringValue, out bool requiredEscaping);
                _parsedData.AppendDynamicSimpleValue(tokenType, location, requiresUnescapingOrHasExponent: requiredEscaping);
            }
        }
    }
}
