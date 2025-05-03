// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    [CLSCompliant(false)]
    public interface IMutableJsonDocument : IJsonDocument
    {
        new MutableJsonElement GetArrayIndexElement(int currentIndex, int arrayIndex);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out MutableJsonElement value);
        bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out MutableJsonElement value);
    }
}
