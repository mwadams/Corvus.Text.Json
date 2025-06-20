// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    internal static class ThrowHelper
    {
        public static void ThrowArgumentOutOfRangeException_JsonNumberExponentTooLarge(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, "The JSON number exponent was too large.");
        }
    }
}
