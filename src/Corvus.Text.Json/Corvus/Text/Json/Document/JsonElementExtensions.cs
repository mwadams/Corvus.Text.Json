// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    /// <summary>
    /// Extension methods for <see cref="IJsonElement"/>.
    /// </summary>
    public static class JsonElementExtensions
    {
        /// <summary>
        /// Performs a deep equality comparison between two <see cref="IJsonElement{T}"/> instance.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left <see cref="IJsonElement{T}"/>.</typeparam>
        /// <typeparam name="TRight">The type of the right <see cref="IJsonElement{T}"/>.</typeparam>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns><see langword="true"/> if the elements are equal.</returns>
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
