// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides validation functionality for URI Templates as defined in RFC 6570.
/// </summary>
internal static class Utf8UriTemplate
{
    /// <summary>
    /// Validates whether the specified byte span represents a valid URI template.
    /// </summary>
    /// <param name="uriTemplate">The URI template to validate.</param>
    /// <returns><see langword="true"/> if the URI template is valid; otherwise, <see langword="false"/>.</returns>
    public static bool Validate(ReadOnlySpan<byte> uriTemplate)
    {
        int start = 0;
        int templateLength = uriTemplate.Length;

        while (start < templateLength)
        {
            // Find a variable section (all '{' denote variable section; they have to be % encoded)
            int length = uriTemplate.Slice(start).IndexOf((byte)'{');
            if (length == -1)
            {
                length = uriTemplate.Length - start; // Can't find an opening brace, take the rest of the string
            }

            if (length > 0)
            {
                // Check that the first character is a valid URI character
                if (!Utf8Uri.ValidatePathQueryAndFragmentSegment(uriTemplate.Slice(start, length), true))
                {
                    return false;
                }
            }

            start += length;

            if (start >= templateLength)
            {
                return true; // No opening brace found, so that's that.
            }

            start++; // Move past the '{' character

            if (start >= templateLength)
            {
                return false; // No space for a closing brace!
            }

            length = uriTemplate.Slice(start).IndexOf((byte)'}');

            if (length == -1)
            {
                return false; // No closing brace found
            }

            if (!ValidateVariableSpecification(uriTemplate.Slice(start, length)))
            {
                return false; // Invalid variable specification
            }

            start += length + 1; // move past the '}' character
        }

        return true;
    }

    /// <summary>
    /// Validates a variable specification within a URI template.
    /// </summary>
    /// <param name="span">The byte span containing the variable specification to validate.</param>
    /// <returns><see langword="true"/> if the variable specification is valid; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// Validates variable specifications according to RFC 6570, including:
    /// - Optional operators (+, #, ., /, ;, ?, &, =, ,, !, @, |)
    /// - Variable names with optional dot-separated segments
    /// - Modifiers (: for prefix, * for explode)
    /// - Multiple variables separated by commas
    /// </remarks>
    private static bool ValidateVariableSpecification(ReadOnlySpan<byte> span)
    {
        int i = 0;
        int length = span.Length;

        // 1. Optional operator
        if (i < length)
        {
            byte b = span[i];
            if (b is (byte)'+' or (byte)'#' or (byte)'.' or (byte)'/' or (byte)';' or (byte)'?' or (byte)'&'
                or (byte)'=' or (byte)',' or (byte)'!' or (byte)'@' or (byte)'|')
            {
                i++;
            }
        }

        bool expectVar = true;
        while (i < length)
        {
            if (!expectVar)
            {
                // Expect comma separator
                if (span[i] != (byte)',')
                {
                    return false;
                }
                i++;
                if (i >= length) return false; // Trailing comma not allowed
            }

            // Parse varspec: varname [modifier]
            int varStart = i;
            // varname: varchar *( ["."] varchar )
            while (i < length)
            {
                int varnameStart = i;
                // varchar: ALPHA / DIGIT / "_" / pct-encoded
                if (IsAlpha(span[i]) || IsDigit(span[i]) || span[i] == (byte)'_')
                {
                    i++;
                }
                else if (span[i] == (byte)'%')
                {
                    // pct-encoded: %XX where X is HEXDIG
                    if (i + 2 >= length || !IsHex(span[i + 1]) || !IsHex(span[i + 2]))
                    {
                        return false;
                    }
                    i += 3;
                }
                else
                {
                    break;
                }

                // Handle dot-separated segments
                if (i < length && span[i] == (byte)'.')
                {
                    i++;
                    if (i >= length) return false; // Dot cannot be last
                    continue;
                }
            }

            if (i == varStart) return false; // No varname found

            // Optional modifier
            if (i < length)
            {
                if (span[i] == (byte)':')
                {
                    // prefix: ":" max-length
                    i++;
                    int prefixStart = i;
                    if (i >= length || !IsNonZeroDigit(span[i])) return false; // max-length must start with 1-9
                    i++;
                    int digits = 1;
                    while (i < length && IsDigit(span[i]) && digits < 4)
                    {
                        i++;
                        digits++;
                    }
                    // max 4 digits, already checked
                }
                else if (span[i] == (byte)'*')
                {
                    // explode: "*"
                    i++;
                }
            }

            expectVar = false;
            // If next is comma, continue; else break
            if (i < length && span[i] == (byte)',')
            {
                expectVar = false;
                continue;
            }
            else
            {
                break;
            }
        }

        // Should have consumed all input
        return i == length;

        // Helper methods
        static bool IsAlpha(byte b) => (b >= (byte)'A' && b <= (byte)'Z') || (b >= (byte)'a' && b <= (byte)'z');
        static bool IsDigit(byte b) => b >= (byte)'0' && b <= (byte)'9';
        static bool IsNonZeroDigit(byte b) => b >= (byte)'1' && b <= (byte)'9';
        static bool IsHex(byte b) =>
            (b >= (byte)'0' && b <= (byte)'9') ||
            (b >= (byte)'A' && b <= (byte)'F') ||
            (b >= (byte)'a' && b <= (byte)'f');
    }
}
