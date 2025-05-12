// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    [CLSCompliant(false)]
    public interface IMutableJsonDocument : IJsonDocument
    {
        new JsonElement.Mutable GetArrayIndexElement(int currentIndex, int arrayIndex);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement.Mutable value);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement.Mutable value);

        int ParentWorkspaceIndex { get; }

        int WriteRawNumberValue(ReadOnlySpan<byte> value);
        int EscapeAndWriteStringValue(ReadOnlySpan<byte> value);
        void WriteValue(Guid value);
        void WriteValue(sbyte value);
        void WriteValue(byte value);
        void WriteValue(int value);
        void WriteValue(uint value);
        void WriteValue(long value);
        void WriteValue(ulong value);
        void WriteValue(short value);
        void WriteValue(ushort value);
        void WriteValue(float value);
        void WriteValue(double value);
        void WriteValue(decimal value);

#if NET
        void WriteValue(Int128 value);
        void WriteValue(UInt128 value);
        void WriteValue(Half value);
#endif


        void SetPropertyRawNumber(int objectIndex, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value);
        void SetPropertyRawString(int objectIndex, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, JsonObjectBuilder.Build objectValue);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, JsonArrayBuilder.Build arrayValue);
        void SetPropertyNull(int objectIndex, ReadOnlySpan<byte> propertyName);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, bool value);
        void SetProperty<T>(int objectIndex, ReadOnlySpan<byte> propertyName, T value)
            where T : struct, IJsonElement<T>;
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, Guid value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, sbyte value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, byte value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, int value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, uint value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, long value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, ulong value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, short value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, ushort value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, float value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, double value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, decimal value);

#if NET
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, Int128 value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, UInt128 value);
        void SetProperty(int objectIndex, ReadOnlySpan<byte> propertyName, Half value);
#endif

        void SetItemRawNumber(int arrayIndex, int itemIndex, ReadOnlySpan<byte> value);
        void SetItemRawString(int arrayIndex, int itemIndex, ReadOnlySpan<byte> value);
        void SetItem(int arrayuIndex, int itemIndex, JsonObjectBuilder.Build objectValue);
        void SetItem(int arrayuIndex, int itemIndex, JsonArrayBuilder.Build arrayValue);
        void SetItemNull(int arrayIndex, int itemIndex);
        void SetItem(int arrayIndex, int itemIndex, bool value);
        void SetItem<T>(int arrayIndex, int itemIndex, T value)
            where T : struct, IJsonElement<T>;
        void SetItem(int arrayIndex, int itemIndex, Guid value);
        void SetItem(int arrayIndex, int itemIndex, sbyte value);
        void SetItem(int arrayIndex, int itemIndex, byte value);
        void SetItem(int arrayIndex, int itemIndex, int value);
        void SetItem(int arrayIndex, int itemIndex, uint value);
        void SetItem(int arrayIndex, int itemIndex, long value);
        void SetItem(int arrayIndex, int itemIndex, ulong value);
        void SetItem(int arrayIndex, int itemIndex, short value);
        void SetItem(int arrayIndex, int itemIndex, ushort value);
        void SetItem(int arrayIndex, int itemIndex, float value);
        void SetItem(int arrayIndex, int itemIndex, double value);
        void SetItem(int arrayIndex, int itemIndex, decimal value);

#if NET
        void SetItem(int arrayIndex, int itemIndex, Int128 value);
        void SetItem(int arrayIndex, int itemIndex, UInt128 value);
        void SetItem(int arrayIndex, int itemIndex, Half value);
#endif
        void InsertAndDispose(ref ComplexValueBuilder cvb);
    }
}
