// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    public static class EnumeratorCreator
    {
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ObjectEnumerator<T> CreateObjectEnumerator<T>(IJsonDocument parent, int index)
            where T : struct, IJsonElement<T>
        {
            return new ObjectEnumerator<T>(parent, index);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayEnumerator<T> CreateArrayEnumerator<T>(IJsonDocument parent, int index)
            where T : struct, IJsonElement<T>
        {
            return new ArrayEnumerator<T>(parent, index);
        }

    }
}
