// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;

#if CORVUS_TEXT_JSON_CODEGENERATION
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.CodeGeneration.Internal
#else
namespace Corvus.Text.Json.Internal
#endif
{
    /// <summary>
    /// Core helper methods for parsing and processing JSON numeric values into their component parts.
    /// </summary>
    public static partial class JsonElementHelpers
    {
        /// <summary>
        /// Parses a JSON number into its component parts using normal-form decimal representation.
        /// </summary>
        /// <param name="span">The UTF-8 encoded span containing the JSON number to parse.</param>
        /// <param name="isNegative">When this method returns, indicates whether the number is negative.</param>
        /// <param name="integral">When this method returns, contains the integral part of the number without leading zeros.</param>
        /// <param name="fractional">When this method returns, contains the fractional part of the number without trailing zeros.</param>
        /// <param name="exponent">When this method returns, contains the exponent value for scientific notation.</param>
        /// <remarks>
        /// The returned components use a normal-form decimal representation:
        /// Number := sign * &lt;integral + fractional&gt; * 10^exponent
        /// where integral and fractional are sequences of digits whose concatenation
        /// represents the significand of the number without leading or trailing zeros.
        /// Two such normal-form numbers are treated as equal if and only if they have
        /// equal signs, significands, and exponents.
        /// </remarks>
        public static void ParseNumber(
           ReadOnlySpan<byte> span,
           out bool isNegative,
           out ReadOnlySpan<byte> integral,
           out ReadOnlySpan<byte> fractional,
           out int exponent)
        {
            // Parses a JSON number into its integral, fractional, and exponent parts.
            // The returned components use a normal-form decimal representation:
            //
            //   Number := sign * <integral + fractional> * 10^exponent
            //
            // where integral and fractional are sequences of digits whose concatenation
            // represents the significand of the number without leading or trailing zeros.
            // Two such normal-form numbers are treated as equal if and only if they have
            // equal signs, significands, and exponents.

            bool neg;
            ReadOnlySpan<byte> intg;
            ReadOnlySpan<byte> frac;
            int exp;

            Debug.Assert(span.Length > 0);

            if (span[0] == '-')
            {
                neg = true;
                span = span.Slice(1);
            }
            else
            {
                Debug.Assert(char.IsDigit((char)span[0]), "leading plus not allowed in valid JSON numbers.");
                neg = false;
            }

            int i = span.IndexOfAny((byte)'.', (byte)'e', (byte)'E');
            if (i < 0)
            {
                intg = span;
                frac = default;
                exp = 0;
                goto Normalize;
            }

            intg = span.Slice(0, i);

            if (span[i] == '.')
            {
                span = span.Slice(i + 1);
                i = span.IndexOfAny((byte)'e', (byte)'E');
                if (i < 0)
                {
                    frac = span;
                    exp = 0;
                    goto Normalize;
                }

                frac = span.Slice(0, i);
            }
            else
            {
                frac = default;
            }

            Debug.Assert(span[i] is (byte)'e' or (byte)'E');
            if (!Utf8Parser.TryParse(span.Slice(i + 1), out exp, out _))
            {
                Debug.Assert(span.Length >= 10);
                ThrowHelper.ThrowArgumentOutOfRangeException_JsonNumberExponentTooLarge(nameof(exponent));
            }

        Normalize: // Calculates the normal form of the number.

            if (IndexOfFirstTrailingZero(frac) is >= 0 and int iz)
            {
                // Trim trailing zeros from the fractional part.
                // e.g. 3.1400 -> 3.14
                frac = frac.Slice(0, iz);
            }

            if (intg[0] == '0')
            {
                Debug.Assert(intg.Length == 1, "Leading zeros not permitted in JSON numbers.");

                if (IndexOfLastLeadingZero(frac) is >= 0 and int lz)
                {
                    // Trim leading zeros from the fractional part
                    // and update the exponent accordingly.
                    // e.g. 0.000123 -> 0.123e-3
                    frac = frac.Slice(lz + 1);
                    exp -= lz + 1;
                }

                // Normalize "0" to the empty span.
                intg = default;
            }

            if (frac.IsEmpty && IndexOfFirstTrailingZero(intg) is >= 0 and int fz)
            {
                // There is no fractional part, trim trailing zeros from
                // the integral part and increase the exponent accordingly.
                // e.g. 1000 -> 1e3
                exp += intg.Length - fz;
                intg = intg.Slice(0, fz);
            }

            // Normalize the exponent by subtracting the length of the fractional part.
            // e.g. 3.14 -> 314e-2
            exp -= frac.Length;

            if (intg.IsEmpty && frac.IsEmpty)
            {
                // Normalize zero representations.
                neg = false;
                exp = 0;
            }

            // Copy to out parameters.
            isNegative = neg;
            integral = intg;
            fractional = frac;
            exponent = exp;

            static int IndexOfLastLeadingZero(ReadOnlySpan<byte> span)
            {
#if NET
                int firstNonZero = span.IndexOfAnyExcept((byte)'0');
                return firstNonZero < 0 ? span.Length - 1 : firstNonZero - 1;
#else
                    for (int i = 0; i < span.Length; i++)
                    {
                        if (span[i] != '0')
                        {
                            return i - 1;
                        }
                    }

                    return span.Length - 1;
#endif
            }

            static int IndexOfFirstTrailingZero(ReadOnlySpan<byte> span)
            {
#if NET
                int lastNonZero = span.LastIndexOfAnyExcept((byte)'0');
                return lastNonZero == span.Length - 1 ? -1 : lastNonZero + 1;
#else
                    if (span.IsEmpty)
                    {
                        return -1;
                    }

                    for (int i = span.Length - 1; i >= 0; i--)
                    {
                        if (span[i] != '0')
                        {
                            return i == span.Length - 1 ? -1 : i + 1;
                        }
                    }

                    return 0;
#endif
            }
        }
    }
}
