// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public abstract partial class JsonDocument
    {
        public abstract JsonElement RootElement { get; }

        public abstract void WriteTo(Utf8JsonWriter writer);
    }
}
