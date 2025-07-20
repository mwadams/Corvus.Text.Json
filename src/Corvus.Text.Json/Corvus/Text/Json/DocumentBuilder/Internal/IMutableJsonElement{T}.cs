// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Represents a mutable JSON element of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type implementing the interface.</typeparam>
/// <remarks>
/// Note that mutable elements are ephemeral. If their underlying document is modified, they may no longer be valid, and their behaviour is undefined.
/// </remarks>
[CLSCompliant(false)]
public interface IMutableJsonElement<T> : IJsonElement<T>
    where T : struct, IJsonElement<T>
{
}
