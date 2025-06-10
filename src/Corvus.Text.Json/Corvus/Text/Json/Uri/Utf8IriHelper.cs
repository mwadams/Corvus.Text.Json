// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace Corvus.Text.Json.Internal
{
    internal class Utf8IriHelper
    {
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInInclusiveRange(uint value, uint min, uint max)
            => (value - min) <= (max - min);
    }
}
