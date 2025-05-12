// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public sealed partial class ParsedJsonDocument<T>
    {
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
    }
}
