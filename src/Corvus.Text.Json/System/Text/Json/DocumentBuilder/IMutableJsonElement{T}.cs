// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    [CLSCompliant(false)]
    public interface IMutableJsonElement<T> : IJsonElement<T>
        where T : struct, IJsonElement<T>
    {
    }
}
