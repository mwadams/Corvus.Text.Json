// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   Represents a specific JSON value within a <see cref="JsonDocument"/>.
    /// </summary>
    public readonly partial struct JsonElementB
    {
        [CLSCompliant(false)]
        public static bool IsValid(IJsonDocument parentDocument, int parentIndex)
        {
            // You're not allowed to ask about non-value-like entities
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray or
                JsonTokenType.PropertyName);

            return true;
        }
    }
}
