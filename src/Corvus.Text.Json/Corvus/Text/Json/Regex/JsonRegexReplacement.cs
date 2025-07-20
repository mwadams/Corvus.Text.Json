// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides constants for JSON regular expression replacement operations.
/// </summary>
internal static class JsonRegexReplacement
{
    /// <summary>
    /// Represents the portion of the input string to the left of the match.
    /// </summary>
    public const int LeftPortion = -1;

    /// <summary>
    /// Represents the portion of the input string to the right of the match.
    /// </summary>
    public const int RightPortion = -2;

    /// <summary>
    /// Represents the last captured group in the match.
    /// </summary>
    public const int LastGroup = -3;

    /// <summary>
    /// Represents the entire input string.
    /// </summary>
    public const int WholeString = -4;
}
