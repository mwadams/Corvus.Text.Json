// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal;

public static class EnumeratorCreator
{
    /// <summary>
    /// Creates an enumerator for the items of a JSON array.
    /// </summary>
    /// <typeparam name="T">The type of the JSON element.</typeparam>
    /// <param name="parent">The parent JSON document.</param>
    /// <param name="index">The index of the array in the document.</param>
    /// <returns>An <see cref="ArrayEnumerator{T}"/> for the array.</returns>
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArrayEnumerator<T> CreateArrayEnumerator<T>(IJsonDocument parent, int index)
        where T : struct, IJsonElement<T>
    {
        return new ArrayEnumerator<T>(parent, index);
    }

    /// <summary>
    /// Creates an enumerator for the properties of a JSON object.
    /// </summary>
    /// <typeparam name="T">The type of the JSON element.</typeparam>
    /// <param name="parent">The parent JSON document.</param>
    /// <param name="index">The index of the object in the document.</param>
    /// <returns>An <see cref="ObjectEnumerator{T}"/> for the object.</returns>
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ObjectEnumerator<T> CreateObjectEnumerator<T>(IJsonDocument parent, int index)
        where T : struct, IJsonElement<T>
    {
        return new ObjectEnumerator<T>(parent, index);
    }
}
