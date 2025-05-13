// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

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

        public void AddProperty(ReadOnlySpan<byte> utf8PropertyName, ValueBuilderAction createComplexValue)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            createComplexValue(ref this);
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8String)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddPropertyNull(ReadOnlySpan<byte> propertyName)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value)
            where T : struct, IJsonElement<T>
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, int value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, long value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, short value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, float value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, double value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

#if NET
        public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

#endif

        public void AddItem(ReadOnlySpan<byte> utf8String)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
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
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(bool value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem<T>(T value)
            where T : struct, IJsonElement<T>
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(Guid value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem(sbyte value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(byte value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(int value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem(uint value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(long value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem(ulong value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(short value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem(ushort value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(float value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(double value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(decimal value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

#if NET
        public void AddItem(Int128 value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        [CLSCompliant(false)]
        public void AddItem(UInt128 value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }

        public void AddItem(Half value)
        {
            int currentMemberCount = _memberCount;
            _memberCount = 0;
            // TODO: Add value
            _memberCount = currentMemberCount + 1;
        }
#endif
        public void StartObject()
        {
            _parsedData.Append(JsonTokenType.StartObject, _targetIndex, -1);
        }

        [CLSCompliant(false)]
        public void StartArray()
        {
            _parsedData.Append(JsonTokenType.StartObject, _targetIndex, -1);
        }

        public void EndObject()
        {
            int length = _parsedData.Length;
            _parsedData.Append(JsonTokenType.EndObject, _targetIndex + Length, 1);
            _parsedData.SetLength(_targetIndex, _memberCount);
            _parsedData.SetNumberOfRows(_targetIndex, length);
            _parsedData.SetNumberOfRows(_parsedData.Length - JsonDocument.DbRow.Size, length);
        }

        public void EndArray()
        {
            int length = _parsedData.Length;
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
            // We don't need to initialize the metadatadb if we are creating a whole document
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
    }
}
