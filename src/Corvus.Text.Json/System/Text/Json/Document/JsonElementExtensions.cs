// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    public static class JsonElementExtensions
    {
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DeepEquals<TLeft, TRight>(this TLeft left, in TRight right)
            where TLeft : struct, IJsonElement<TLeft>
            where TRight : struct, IJsonElement<TRight>
        {
            return JsonElementHelpers.DeepEquals(left, right);
        }
    }
}
