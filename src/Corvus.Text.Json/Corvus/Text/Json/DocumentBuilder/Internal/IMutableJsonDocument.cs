// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    [CLSCompliant(false)]
    public interface IMutableJsonDocument : IJsonDocument
    {
        ulong Version { get; }

        new JsonElement.Mutable GetArrayIndexElement(int currentIndex, int arrayIndex);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement.Mutable value);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement.Mutable value);

        int ParentWorkspaceIndex { get; }

        JsonWorkspace Workspace { get; }

        int StoreRawNumberValue(ReadOnlySpan<byte> value);
        int StoreRawNumberValue(ReadOnlySpan<char> value);
        int StoreNullValue();
        int StoreBooleanValue(bool value);
        int EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, out bool requiredEscaping);
        int EscapeAndStoreRawStringValue(ReadOnlySpan<byte> value, out bool requiredEscaping);
        int StoreRawStringValue(ReadOnlySpan<byte> value);
        int StoreValue(Guid value);
        int StoreValue(DateTime value);
        int StoreValue(DateTimeOffset value);
        int StoreValue(sbyte value);
        int StoreValue(byte value);
        int StoreValue(int value);
        int StoreValue(uint value);
        int StoreValue(long value);
        int StoreValue(ulong value);
        int StoreValue(short value);
        int StoreValue(ushort value);
        int StoreValue(float value);
        int StoreValue(double value);
        int StoreValue(decimal value);

#if NET
        int StoreValue(Int128 value);
        int StoreValue(UInt128 value);
        int StoreValue(Half value);
#endif

        void SetAndDispose(ref ComplexValueBuilder cvb);
        void InsertAndDispose(int complexObjectStartIndex, int index, ref ComplexValueBuilder cvb);
        void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int membersToOverwrite, ref ComplexValueBuilder cvb);
    }
}
