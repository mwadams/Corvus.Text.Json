// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides helper methods for working with IRI (Internationalized Resource Identifier) Unicode ranges.
/// </summary>
internal class Utf8IriHelper
{
    /// <summary>
    /// Checks if a Unicode value is within the valid IRI Unicode range.
    /// </summary>
    /// <param name="value">The Unicode value to check.</param>
    /// <param name="isQuery">A value indicating whether this is for a query component.</param>
    /// <returns><see langword="true"/> if the value is within the valid IRI Unicode range; otherwise, <see langword="false"/>.</returns>
    internal static bool CheckIriUnicodeRange(uint value, bool isQuery)
    {
        if (value <= 0xFFFF)
        {
            return IsInInclusiveRange(value, '\u00A0', '\uD7FF')
                || IsInInclusiveRange(value, '\uF900', '\uFDCF')
                || IsInInclusiveRange(value, '\uFDF0', '\uFFEF')
                || (isQuery && IsInInclusiveRange(value, '\uE000', '\uF8FF'));
        }
        else
        {
            return ((value & 0xFFFF) < 0xFFFE)
                && !IsInInclusiveRange(value, 0xE0000, 0xE0FFF)
                && (isQuery || value < 0xF0000);
        }
    }

    /// <summary>
    /// Determines whether a value is within the specified inclusive range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum value of the range (inclusive).</param>
    /// <param name="max">The maximum value of the range (inclusive).</param>
    /// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInInclusiveRange(uint value, uint min, uint max)
        => (value - min) <= (max - min);
}
