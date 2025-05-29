// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// An interface implemented by mutable JSON elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// Note that immutable elements are ephemeral. If their
    /// underlying document is modified, they may no longer be valid,
    /// and their behaviour is undefined.
    /// </remarks>
    [CLSCompliant(false)]
    public interface IMutableJsonElement<T> : IJsonElement<T>
        where T : struct, IJsonElement<T>
    {
    }
}
