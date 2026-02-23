// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

internal partial struct ValueStack<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Peek()
    {
        return Span[_pos - 1];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        _pos--;
        return Span[_pos];
    }
}
