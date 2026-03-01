// <copyright file="BigNumber.OptimizedFormatting.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Buffers;
using System.Buffers.Text;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Corvus.Numerics;

/// <summary>
/// Zero-allocation formatting methods for <see cref="BigNumber"/>.
/// </summary>
public readonly partial struct BigNumber
{
    /// <summary>
    /// Tries to format this instance into the provided UTF-16 span with zero allocations.
    /// </summary>
    /// <param name="destination">The destination span.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <param name="format">The format string.</param>
    /// <param name="provider">The format provider.</param>
    /// <returns><c>true</c> if formatting succeeded; otherwise, <c>false</c>.</returns>
    public bool TryFormatOptimized(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        // Fast path: InvariantCulture (90%+ of usage, especially JSON scenarios)
        if (provider == null || provider == CultureInfo.InvariantCulture ||
            ReferenceEquals(NumberFormatInfo.GetInstance(provider), NumberFormatInfo.InvariantInfo))
        {
            return TryFormatInvariant(destination, out charsWritten, format);
        }

        // Culture-specific formatting path
        return TryFormatCultureSpecific(destination, out charsWritten, format, provider);
    }

    /// <summary>
    /// Fast path for InvariantCulture formatting with hardcoded separators.
    /// </summary>
    private bool TryFormatInvariant(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
    {
        // Fast path: Zero
        if (this.Significand.IsZero)
        {
            return TryFormatZero(destination, out charsWritten, format, CultureInfo.InvariantCulture);
        }

        // Fast path: No format = raw representation
        if (format.IsEmpty)
        {
            return TryFormatRaw(destination, out charsWritten, CultureInfo.InvariantCulture);
        }

        // Fast path: Single-digit precision (F2, E3, N4, etc.)
        if (format.Length == 2)
        {
            char formatType = char.ToUpperInvariant(format[0]);
            int digit = format[1];

            if (digit >= '0' && digit <= '9')
            {
                int precision = digit - '0';

                return formatType switch
                {
                    'F' => TryFormatFixedPoint(destination, out charsWritten, precision, NumberFormatInfo.InvariantInfo),
                    'E' => TryFormatExponential(destination, out charsWritten, precision,
                        char.IsLower(format[0]) ? 'e' : 'E', NumberFormatInfo.InvariantInfo),
                    'N' => TryFormatNumber(destination, out charsWritten, precision, NumberFormatInfo.InvariantInfo),
                    'G' => TryFormatGeneral(destination, out charsWritten, precision,
                        char.IsLower(format[0]) ? 'e' : 'E', NumberFormatInfo.InvariantInfo),
                    'C' => TryFormatCurrency(destination, out charsWritten, precision, NumberFormatInfo.InvariantInfo),
                    'P' => TryFormatPercent(destination, out charsWritten, precision, NumberFormatInfo.InvariantInfo),
                    _ => TryFormatGeneralPath(destination, out charsWritten, format, CultureInfo.InvariantCulture)
                };
            }
        }

        // General implementation for InvariantCulture
        return TryFormatGeneralPath(destination, out charsWritten, format, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Culture-specific formatting path (non-InvariantCulture).
    /// </summary>
    private bool TryFormatCultureSpecific(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        // Fast path: Zero
        if (this.Significand.IsZero)
        {
            return TryFormatZero(destination, out charsWritten, format, provider);
        }

        // Fast path: No format = raw representation
        if (format.IsEmpty)
        {
            return TryFormatRaw(destination, out charsWritten, provider);
        }

        // Fast path: Single-digit precision (F2, E3, N4, etc.)
        if (format.Length == 2)
        {
            char formatType = char.ToUpperInvariant(format[0]);
            int digit = format[1];

            if (digit >= '0' && digit <= '9')
            {
                int precision = digit - '0';
                NumberFormatInfo formatInfo = NumberFormatInfo.GetInstance(provider);

                return formatType switch
                {
                    'F' => TryFormatFixedPoint(destination, out charsWritten, precision, formatInfo),
                    'E' => TryFormatExponential(destination, out charsWritten, precision,
                        char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
                    'N' => TryFormatNumber(destination, out charsWritten, precision, formatInfo),
                    'G' => TryFormatGeneral(destination, out charsWritten, precision,
                        char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
                    'C' => TryFormatCurrency(destination, out charsWritten, precision, formatInfo),
                    'P' => TryFormatPercent(destination, out charsWritten, precision, formatInfo),
                    _ => TryFormatGeneralPath(destination, out charsWritten, format, provider)
                };
            }
        }

        // General implementation
        return TryFormatGeneralPath(destination, out charsWritten, format, provider);
    }

    private bool TryFormatGeneralPath(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        NumberFormatInfo formatInfo = NumberFormatInfo.GetInstance(provider);
        char formatType = char.ToUpperInvariant(format[0]);
        int precision = -1;

        if (format.Length > 1)
        {
            if (!TryParseInt32(format.Slice(1), out precision))
            {
                charsWritten = 0;
                return false;
            }
        }

        return formatType switch
        {
            'G' => TryFormatGeneral(destination, out charsWritten, precision, char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
            'F' => TryFormatFixedPoint(destination, out charsWritten, precision >= 0 ? precision : formatInfo.NumberDecimalDigits, formatInfo),
            'N' => TryFormatNumber(destination, out charsWritten, precision >= 0 ? precision : formatInfo.NumberDecimalDigits, formatInfo),
            'E' => TryFormatExponential(destination, out charsWritten, precision >= 0 ? precision : 6, char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
            'C' => TryFormatCurrency(destination, out charsWritten, precision >= 0 ? precision : formatInfo.CurrencyDecimalDigits, formatInfo),
            'P' => TryFormatPercent(destination, out charsWritten, precision >= 0 ? precision : formatInfo.PercentDecimalDigits, formatInfo),
            _ => TryFormatRaw(destination, out charsWritten, provider)
        };
    }

    /// <summary>
    /// Tries to format this instance into the provided UTF-8 span with zero allocations.
    /// </summary>
    /// <param name="utf8Destination">The destination span.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <param name="format">The format string.</param>
    /// <param name="provider">The format provider.</param>
    /// <returns><c>true</c> if formatting succeeded; otherwise, <c>false</c>.</returns>
    public bool TryFormatUtf8Optimized(Span<byte> utf8Destination, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        // Fast path: JSON format (empty format or 'G' with InvariantCulture)
        if ((format.IsEmpty || (format.Length == 1 && (format[0] == 'G' || format[0] == 'g'))) &&
            (provider == null || provider == CultureInfo.InvariantCulture || ReferenceEquals(NumberFormatInfo.GetInstance(provider), NumberFormatInfo.InvariantInfo)))
        {
            return TryFormatJsonUtf8(utf8Destination, out bytesWritten);
        }

        if (this.Significand.IsZero)
        {
            return TryFormatZeroUtf8(utf8Destination, out bytesWritten, format, provider);
        }

        if (format.IsEmpty)
        {
            return TryFormatRawUtf8(utf8Destination, out bytesWritten, provider);
        }

        NumberFormatInfo formatInfo = NumberFormatInfo.GetInstance(provider);
        char formatType = char.ToUpperInvariant(format[0]);
        int precision = -1;

        if (format.Length > 1)
        {
            if (!TryParseInt32(format.Slice(1), out precision))
            {
                bytesWritten = 0;
                return false;
            }
        }

        return formatType switch
        {
            'G' => TryFormatGeneralUtf8(utf8Destination, out bytesWritten, precision, char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
            'F' => TryFormatFixedPointUtf8(utf8Destination, out bytesWritten, precision >= 0 ? precision : formatInfo.NumberDecimalDigits, formatInfo),
            'N' => TryFormatNumberUtf8(utf8Destination, out bytesWritten, precision >= 0 ? precision : formatInfo.NumberDecimalDigits, formatInfo),
            'E' => TryFormatExponentialUtf8(utf8Destination, out bytesWritten, precision >= 0 ? precision : 6, char.IsLower(format[0]) ? 'e' : 'E', formatInfo),
            'C' => TryFormatCurrencyUtf8(utf8Destination, out bytesWritten, precision >= 0 ? precision : formatInfo.CurrencyDecimalDigits, formatInfo),
            'P' => TryFormatPercentUtf8(utf8Destination, out bytesWritten, precision >= 0 ? precision : formatInfo.PercentDecimalDigits, formatInfo),
            _ => TryFormatRawUtf8(utf8Destination, out bytesWritten, provider)
        };
    }

    /// <summary>
    /// Highly-optimized fast path for JSON formatting: culture-invariant 'G' format.
    /// Produces output like: 1234E-3, 1234E2, 1234, 0, -1234E-3, -1234E2, -1234
    /// </summary>
    /// <param name="utf8Destination">The destination UTF-8 buffer.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><c>true</c> if formatting succeeded; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryFormatJsonUtf8(Span<byte> utf8Destination, out int bytesWritten)
    {
        // Fast path: Zero
        if (this.Significand.IsZero)
        {
            if (utf8Destination.Length < 1)
            {
                bytesWritten = 0;
                return false;
            }
            utf8Destination[0] = (byte)'0';
            bytesWritten = 1;
            return true;
        }

        // Normalize to get canonical form
        BigNumber normalized = this.Normalize();

        // Fast path: No exponent (e.g., "1234", "-5678")
        if (normalized.Exponent == 0)
        {
            return TryFormatBigIntegerUtf8(normalized.Significand, utf8Destination, out bytesWritten);
        }

        // Format significand
        if (!TryFormatBigIntegerUtf8(normalized.Significand, utf8Destination, out int sigBytes))
        {
            bytesWritten = 0;
            return false;
        }

        // Add 'E'
        utf8Destination[sigBytes] = (byte)'E';
        int position = sigBytes + 1;

        // Format exponent
        if (!TryFormatInt64Utf8(normalized.Exponent, utf8Destination.Slice(position), out int expBytes))
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = position + expBytes;
        return true;
    }

    /// <summary>
    /// Formats a BigInteger to UTF-8 bytes (ASCII digits only).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryFormatBigIntegerUtf8(BigInteger value, Span<byte> destination, out int bytesWritten)
    {
        // Use a small stack buffer for the char representation
        Span<char> charBuffer = stackalloc char[128];

        if (!value.TryFormat(charBuffer, out int charsWritten, default, CultureInfo.InvariantCulture))
        {
            // Number too large for stack buffer, use larger buffer
            char[] rentedBuffer = ArrayPool<char>.Shared.Rent(256);
            try
            {
                if (!value.TryFormat(rentedBuffer, out charsWritten, default, CultureInfo.InvariantCulture))
                {
                    bytesWritten = 0;
                    return false;
                }

                return TryConvertAsciiToUtf8(rentedBuffer.AsSpan(0, charsWritten), destination, out bytesWritten);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(rentedBuffer);
            }
        }

        return TryConvertAsciiToUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    /// <summary>
    /// Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations.
    /// </summary>
    /// <param name="utf8Source">The UTF-8 bytes to parse.</param>
    /// <param name="result">The parsed BigNumber.</param>
    /// <returns><c>true</c> if parsing succeeded; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// <para>
    /// This method is optimized for parsing JSON-formatted numbers with InvariantCulture semantics.
    /// It expects input in formats like: "123", "-456", "1234E-3", "1234E2", "0".
    /// </para>
    /// <para>
    /// The method parses directly from UTF-8 bytes without conversion to chars,
    /// maintaining zero heap allocations for typical numbers.
    /// </para>
    /// </remarks>
    public static bool TryParseJsonUtf8(ReadOnlySpan<byte> utf8Source, out BigNumber result)
    {
        // Fast path: Empty input
        if (utf8Source.IsEmpty)
        {
            result = Zero;
            return false;
        }

        // Fast path: Single zero
        if (utf8Source.Length == 1 && utf8Source[0] == (byte)'0')
        {
            result = Zero;
            return true;
        }

        // Parse directly from UTF-8 bytes
        return TryParseUtf8Core(utf8Source, out result);
    }

    /// <summary>
    /// Core UTF-8 parsing logic that operates directly on UTF-8 bytes.
    /// </summary>
    private static bool TryParseUtf8Core(ReadOnlySpan<byte> utf8Source, out BigNumber result)
    {
        int position = 0;

        // Skip leading whitespace
        while (position < utf8Source.Length && IsWhitespace(utf8Source[position]))
        {
            position++;
        }

        if (position >= utf8Source.Length)
        {
            result = Zero;
            return false;
        }

        // Parse sign
        bool isNegative = false;
        if (utf8Source[position] == (byte)'-')
        {
            isNegative = true;
            position++;
        }
        else if (utf8Source[position] == (byte)'+')
        {
            position++;
        }

        if (position >= utf8Source.Length)
        {
            result = Zero;
            return false;
        }

        // Parse significand (integer and decimal parts)
        BigInteger significand = BigInteger.Zero;
        int exponent = 0;
        bool hasDigits = false;
        bool inDecimalPart = false;
        int decimalPlaces = 0;

        // Parse digits before and after decimal point
        while (position < utf8Source.Length)
        {
            byte b = utf8Source[position];

            if (b >= (byte)'0' && b <= (byte)'9')
            {
                hasDigits = true;
                int digit = b - (byte)'0';
                significand = significand * 10 + digit;

                if (inDecimalPart)
                {
                    decimalPlaces++;
                }

                position++;
            }
            else if (b == (byte)'.' && !inDecimalPart)
            {
                inDecimalPart = true;
                position++;
            }
            else
            {
                break;
            }
        }

        if (!hasDigits)
        {
            result = Zero;
            return false;
        }

        // Account for decimal places
        exponent -= decimalPlaces;

        // Parse exponent if present
        if (position < utf8Source.Length && (utf8Source[position] == (byte)'E' || utf8Source[position] == (byte)'e'))
        {
            position++;

            if (position >= utf8Source.Length)
            {
                result = Zero;
                return false;
            }

            // Parse exponent sign
            bool expNegative = false;
            if (utf8Source[position] == (byte)'-')
            {
                expNegative = true;
                position++;
            }
            else if (utf8Source[position] == (byte)'+')
            {
                position++;
            }

            if (position >= utf8Source.Length)
            {
                result = Zero;
                return false;
            }

            // Parse exponent digits
            int parsedExponent = 0;
            bool hasExpDigits = false;

            while (position < utf8Source.Length)
            {
                byte b = utf8Source[position];

                if (b >= (byte)'0' && b <= (byte)'9')
                {
                    hasExpDigits = true;
                    parsedExponent = parsedExponent * 10 + (b - (byte)'0');
                    position++;
                }
                else
                {
                    break;
                }
            }

            if (!hasExpDigits)
            {
                result = Zero;
                return false;
            }

            if (expNegative)
            {
                parsedExponent = -parsedExponent;
            }

            exponent += parsedExponent;
        }

        // Skip trailing whitespace
        while (position < utf8Source.Length && IsWhitespace(utf8Source[position]))
        {
            position++;
        }

        // Check for unconsumed input
        if (position != utf8Source.Length)
        {
            result = Zero;
            return false;
        }

        // Apply sign
        if (isNegative)
        {
            significand = -significand;
        }

        result = new BigNumber(significand, exponent);
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsWhitespace(byte b)
    {
        // JSON whitespace: space, tab, newline, carriage return
        return b == (byte)' ' || b == (byte)'\t' || b == (byte)'\n' || b == (byte)'\r';
    }

    /// <summary>
    /// Formats a long to UTF-8 bytes (ASCII digits only).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryFormatInt64Utf8(long value, Span<byte> destination, out int bytesWritten)
    {
        Span<char> charBuffer = stackalloc char[20]; // long.MinValue is 20 chars

        if (!value.TryFormat(charBuffer, out int charsWritten, default, CultureInfo.InvariantCulture))
        {
            bytesWritten = 0;
            return false;
        }

        return TryConvertAsciiToUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    /// <summary>
    /// Converts ASCII-only chars to UTF-8 bytes (direct copy for ASCII).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryConvertAsciiToUtf8(ReadOnlySpan<char> source, Span<byte> destination, out int bytesWritten)
    {
        if (source.Length > destination.Length)
        {
            bytesWritten = 0;
            return false;
        }

        // Direct conversion for ASCII characters (0-127)
        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            // All numeric output is ASCII (digits, minus, E)
            if (c > 127)
            {
                bytesWritten = 0;
                return false;
            }

            destination[i] = (byte)c;
        }

        bytesWritten = source.Length;
        return true;
    }
    
    /// <summary>
    /// Estimates the number of digits needed for a long.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int NumberOfDigits(int value)
    {
        if (value == 0)
            return 1;

        int digits = value < 0 ? 1 : 0; // Sign
        value = Math.Abs(value);

        // Fast digit count
        return value switch
        {
            < 10 => digits + 1,
            < 100 => digits + 2,
            < 1000 => digits + 3,
            < 10000 => digits + 4,
            < 100000 => digits + 5,
            < 1000000 => digits + 6,
            < 10000000 => digits + 7,
            < 100000000 => digits + 8,
            < 1000000000 => digits + 9,
            _ => digits + 10
        };
    }

    #region UTF-16 Format Implementations

    private bool TryFormatZero(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        if (format.IsEmpty)
        {
            if (destination.Length < 1)
            {
                charsWritten = 0;
                return false;
            }
            destination[0] = '0';
            charsWritten = 1;
            return true;
        }

        NumberFormatInfo formatInfo = NumberFormatInfo.GetInstance(provider);
        char formatType = char.ToUpperInvariant(format[0]);
        int precision = -1;

        if (format.Length > 1 && !TryParseInt32(format.Slice(1), out precision))
        {
            if (destination.Length < 1)
            {
                charsWritten = 0;
                return false;
            }
            destination[0] = '0';
            charsWritten = 1;
            return true;
        }

        return formatType switch
        {
            'G' => WriteString(destination, out charsWritten, "0"),
            'F' or 'N' => TryFormatZeroFixedPoint(destination, out charsWritten, precision >= 0 ? precision : formatInfo.NumberDecimalDigits, formatInfo),
            'E' => TryFormatZeroExponential(destination, out charsWritten, precision >= 0 ? precision : 6, format[0], formatInfo),
            'C' => TryFormatZeroCurrency(destination, out charsWritten, precision >= 0 ? precision : formatInfo.CurrencyDecimalDigits, formatInfo),
            'P' => TryFormatZeroPercent(destination, out charsWritten, precision >= 0 ? precision : formatInfo.PercentDecimalDigits, formatInfo),
            _ => WriteString(destination, out charsWritten, "0")
        };
    }

    private bool TryFormatRaw(Span<char> destination, out int charsWritten, IFormatProvider? provider)
    {
        BigNumber normalized = this.Normalize();

        if (!normalized.Significand.TryFormat(destination, out int sigChars, default, CultureInfo.InvariantCulture))
        {
            charsWritten = 0;
            return false;
        }

        if (normalized.Exponent == 0)
        {
            charsWritten = sigChars;
            return true;
        }


        if (sigChars == destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        int pos = sigChars;
        destination[pos++] = 'E';
        if (normalized.Exponent.TryFormat(destination.Slice(pos), out int expChars, default, CultureInfo.InvariantCulture))
        {
            charsWritten = pos + expChars;
            return true;
        }

        charsWritten = 0;
        return false;
    }

    private bool TryFormatGeneral(Span<char> destination, out int charsWritten, int precision, char exponentChar, NumberFormatInfo formatInfo)
    {
        BigNumber value = this;

        if (precision > 0)
        {
            value = RoundToSignificantDigits(this, precision);
        }

        BigNumber normalized = value.Normalize();


        bool isNegative = normalized.Significand.Sign < 0;
        int pos = 0;

        if (isNegative)
        {
            formatInfo.NegativeSign.AsSpan().CopyTo(destination.Slice(pos));
            pos += formatInfo.NegativeSign.Length;
        }

        if (!BigInteger.Abs(normalized.Significand).TryFormat(destination.Slice(pos), out int sigChars, default, formatInfo))
        {
            charsWritten = 0;
            return false;
        }

        pos += sigChars;

        if (normalized.Exponent != 0)
        {
            if (pos == destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            destination[pos++] = exponentChar;

            if (normalized.Exponent < 0)
            {
                formatInfo.NegativeSign.AsSpan().CopyTo(destination.Slice(pos));
                pos += formatInfo.NegativeSign.Length;
            }

            if (!Math.Abs(normalized.Exponent).TryFormat(destination.Slice(pos), out int expChars, default, formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            pos += expChars;
        }

        charsWritten = pos;
        return true;
    }

    private bool TryFormatFixedPoint(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        return TryFormatFixedPointWithSeparator(destination, out charsWritten, precision, formatInfo.NumberDecimalSeparator, formatInfo);
    }

    private bool TryFormatFixedPointWithSeparator(Span<char> destination, out int charsWritten, int precision, string decimalSeparator, NumberFormatInfo formatInfo)
    {
        BigNumber scaled = this;
        if (this.Exponent < -precision)
        {
            scaled = RoundToPrecision(this, precision);
        }

        long totalExponent = scaled.Exponent + precision;
        BigInteger integerPart = scaled.Significand;

        if (totalExponent != 0)
        {
            if (totalExponent > 0)
            {
                integerPart = scaled.Significand * BigInteger.Pow(10, (int)totalExponent);
            }
            else
            {
                BigInteger divisor = BigInteger.Pow(10, (int)(-totalExponent));
                integerPart = BigInteger.DivRem(scaled.Significand, divisor, out BigInteger remainder);

                if (BigInteger.Abs(remainder) * 2 >= divisor)
                {
                    integerPart += scaled.Significand.Sign;
                }
            }
        }

        char[]? bufferChars = null;
        Span<char> buffer = destination.Length < StackAllocThreshold
            ? stackalloc char[StackAllocThreshold]
            : (bufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

        try
        {
            if (!BigInteger.Abs(integerPart).TryFormat(buffer, out int chars, default, formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            bool isNegative = integerPart.Sign < 0;

            // Handle small fractions where all digits are after decimal point
            bool isSmallFraction = chars < precision;
            int intPartLen = isSmallFraction ? 0 : (precision == 0 ? chars : Math.Max(1, chars - precision));
            int fracPartLen = isSmallFraction ? chars : (precision == 0 ? 0 : Math.Min(precision, chars - intPartLen));

            int requiredLength = (intPartLen > 0 ? intPartLen : 1) + (isNegative ? formatInfo.NegativeSign.Length : 0); // At least "0"
            if (precision > 0)
            {
                requiredLength += decimalSeparator.Length + precision;
            }

            if (requiredLength > destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            int pos = 0;

            if (isNegative)
            {
                formatInfo.NegativeSign.AsSpan().CopyTo(destination.Slice(pos));
                pos += formatInfo.NegativeSign.Length;
            }

            // Write integer part (or "0" if small fraction)
            if (intPartLen > 0)
            {
                buffer.Slice(0, intPartLen).CopyTo(destination.Slice(pos));
                pos += intPartLen;
            }
            else
            {
                destination[pos++] = '0';
            }

            if (precision > 0)
            {
                decimalSeparator.AsSpan().CopyTo(destination.Slice(pos));
                pos += decimalSeparator.Length;

                // Add leading zeros for small fractions
                if (isSmallFraction)
                {
                    int leadingZeros = precision - chars;
                    for (int i = 0; i < leadingZeros; i++)
                    {
                        destination[pos++] = '0';
                    }
                }

                // Write fractional part
                if (fracPartLen > 0)
                {
                    int fracStart = isSmallFraction ? 0 : intPartLen;
                    buffer.Slice(fracStart, fracPartLen).CopyTo(destination.Slice(pos));
                    pos += fracPartLen;
                }

                // Add trailing zeros if needed
                int zerosNeeded = isSmallFraction ? 0 : (precision - fracPartLen);
                for (int i = 0; i < zerosNeeded; i++)
                {
                    destination[pos++] = '0';
                }
            }

            charsWritten = pos;
            return true;
        }
        finally
        {
            if (bufferChars is char[] bc)
            {
                ArrayPool<char>.Shared.Return(bc);
            }
        }
    }

    private bool TryFormatNumber(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        // Format with thousands grouping separators
        int effectivePrecision = precision >= 0 ? precision : formatInfo.NumberDecimalDigits;

        // First, format without grouping to a temporary buffer
        char[]? bufferChars = null;
        Span<char> buffer = destination.Length < StackAllocThreshold
            ? stackalloc char[StackAllocThreshold]
            : (bufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

        try
        {
            if (!TryFormatFixedPoint(buffer, out int tempChars, effectivePrecision, formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            // Now add thousands separators
            ReadOnlySpan<char> formatted = buffer.Slice(0, tempChars);
            return TryApplyGrouping(formatted, destination, out charsWritten, formatInfo.NumberGroupSeparator, formatInfo.NumberGroupSizes, formatInfo.NumberDecimalSeparator);
        }
        finally
        {
            if (bufferChars is char[] bc)
            {
                ArrayPool<char>.Shared.Return(bc);
            }
        }
    }

    private bool TryFormatExponential(Span<char> destination, out int charsWritten, int precision, char exponentChar, NumberFormatInfo formatInfo)
    {
        if (this.Significand.IsZero)
        {
            return TryFormatZeroExponential(destination, out charsWritten, precision, exponentChar, formatInfo);
        }

        BigNumber normalized = this.Normalize();

        char[]? bufferChars = null;
        Span<char> buffer = destination.Length < StackAllocThreshold
            ? stackalloc char[StackAllocThreshold]
            : (bufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

        try
        {
            if (!BigInteger.Abs(normalized.Significand).TryFormat(buffer, out int sigChars, default, formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            long actualExponent = normalized.Exponent + sigChars - 1;
            bool isNegative = normalized.Significand.Sign < 0;

            int requiredLength = (isNegative ? formatInfo.NegativeSign.Length : 0) + 1;
            if (precision > 0)
            {
                requiredLength += formatInfo.NumberDecimalSeparator.Length + precision;
            }
            requiredLength += 2 + 3; // E + sign + 3 digits minimum

            if (requiredLength > destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            int pos = 0;
            if (isNegative)
            {
                formatInfo.NegativeSign.AsSpan().CopyTo(destination.Slice(pos));
                pos += formatInfo.NegativeSign.Length;
            }

            destination[pos++] = buffer[0];

            if (precision > 0)
            {
                formatInfo.NumberDecimalSeparator.AsSpan().CopyTo(destination.Slice(pos));
                pos += formatInfo.NumberDecimalSeparator.Length;

                int available = Math.Min(sigChars - 1, precision);
                if (available > 0)
                {
                    buffer.Slice(1, available).CopyTo(destination.Slice(pos));
                    pos += available;
                }

                for (int i = available; i < precision; i++)
                {
                    destination[pos++] = '0';
                }
            }

            destination[pos++] = exponentChar;

            if (actualExponent >= 0)
            {
                destination[pos++] = '+';
            }
            else
            {
                formatInfo.NegativeSign.AsSpan().CopyTo(destination.Slice(pos));
                pos += formatInfo.NegativeSign.Length;
            }

            long absExponent = Math.Abs(actualExponent);
            if (!absExponent.TryFormat(destination.Slice(pos), out int expChars, "D3", formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            pos += expChars;

            charsWritten = pos;
            return true;
        }
        finally
        {
            if (bufferChars is char[] bc)
            {
                ArrayPool<char>.Shared.Return(bc);
            }
        }
    }

    private bool TryFormatCurrency(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        // Format with currency grouping separators
        int effectivePrecision = precision >= 0 ? precision : formatInfo.CurrencyDecimalDigits;
        bool isNegative = this.Significand.Sign < 0;

        // Format the absolute value (we'll apply negative pattern later)
        BigNumber absValue = isNegative ? new BigNumber(BigInteger.Abs(this.Significand), this.Exponent) : this;

        // Create a temporary NumberFormatInfo for currency decimal separator
        char[]? bufferChars = null;
        char[]? groupedBufferChars = null;

        Span<char> buffer = destination.Length < StackAllocThreshold
            ? stackalloc char[StackAllocThreshold]
            : (bufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

        try
        {
            // Manually format fixed point with currency decimal separator
            if (!absValue.TryFormatFixedPointWithSeparator(buffer, out int tempChars, effectivePrecision, formatInfo.CurrencyDecimalSeparator, formatInfo))
            {
                charsWritten = 0;
                return false;
            }

            // Apply currency grouping
            Span<char> groupedBuffer = destination.Length < StackAllocThreshold
                ? stackalloc char[StackAllocThreshold]
                : (groupedBufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

            if (!TryApplyGrouping(buffer.Slice(0, tempChars), groupedBuffer, out int groupedChars, formatInfo.CurrencyGroupSeparator, formatInfo.CurrencyGroupSizes, formatInfo.CurrencyDecimalSeparator))
            {
                charsWritten = 0;
                return false;
            }

            // Apply currency symbol and pattern
            return TryApplyCurrencyPattern(groupedBuffer.Slice(0, groupedChars), destination, out charsWritten, formatInfo, isNegative);
        }
        finally
        {
            if (bufferChars is char[] bc)
            {
                ArrayPool<char>.Shared.Return(bc);
            }
            if (groupedBufferChars is char[] gbc)
            {
                ArrayPool<char>.Shared.Return(gbc);
            }
        }
    }

    private bool TryFormatPercent(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        BigNumber percentValue = this * new BigNumber(100, 0);

        if (!percentValue.TryFormatFixedPoint(destination, out int tempChars, precision, formatInfo))
        {
            charsWritten = 0;
            return false;
        }

        int symbolLength = formatInfo.PercentSymbol.Length;
        int requiredLength = tempChars + 1 + symbolLength;

        if (requiredLength > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        Span<char> temp = stackalloc char[tempChars];
        destination.Slice(0, tempChars).CopyTo(temp);
        temp.CopyTo(destination);
        destination[tempChars] = ' ';
        formatInfo.PercentSymbol.AsSpan().CopyTo(destination.Slice(tempChars + 1));

        charsWritten = requiredLength;
        return true;
    }

    #endregion

    #region UTF-16 Helper Methods

    private bool TryFormatZeroFixedPoint(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        int requiredLength = 1 + (precision > 0 ? formatInfo.NumberDecimalSeparator.Length + precision : 0);

        if (requiredLength > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        int pos = 0;
        destination[pos++] = '0';

        if (precision > 0)
        {
            formatInfo.NumberDecimalSeparator.AsSpan().CopyTo(destination.Slice(pos));
            pos += formatInfo.NumberDecimalSeparator.Length;

            for (int i = 0; i < precision; i++)
            {
                destination[pos++] = '0';
            }
        }

        charsWritten = pos;
        return true;
    }

    private bool TryFormatZeroExponential(Span<char> destination, out int charsWritten, int precision, char exponentChar, NumberFormatInfo formatInfo)
    {
        int requiredLength = 1 + (precision > 0 ? formatInfo.NumberDecimalSeparator.Length + precision : 0) + 5; // E+000

        if (requiredLength > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        int pos = 0;
        destination[pos++] = '0';

        if (precision > 0)
        {
            formatInfo.NumberDecimalSeparator.AsSpan().CopyTo(destination.Slice(pos));
            pos += formatInfo.NumberDecimalSeparator.Length;

            for (int i = 0; i < precision; i++)
            {
                destination[pos++] = '0';
            }
        }

        destination[pos++] = exponentChar;
        destination[pos++] = '+';
        destination[pos++] = '0';
        destination[pos++] = '0';
        destination[pos++] = '0';

        charsWritten = pos;
        return true;
    }

    private bool TryFormatZeroCurrency(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        return TryFormatZeroFixedPoint(destination, out charsWritten, precision, formatInfo);
    }

    private bool TryFormatZeroPercent(Span<char> destination, out int charsWritten, int precision, NumberFormatInfo formatInfo)
    {
        if (!TryFormatZeroFixedPoint(destination, out int tempChars, precision, formatInfo))
        {
            charsWritten = 0;
            return false;
        }

        int symbolLength = formatInfo.PercentSymbol.Length;
        int requiredLength = tempChars + 1 + symbolLength;

        if (requiredLength > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        Span<char> temp = stackalloc char[tempChars];
        destination.Slice(0, tempChars).CopyTo(temp);
        temp.CopyTo(destination);
        destination[tempChars] = ' ';
        formatInfo.PercentSymbol.AsSpan().CopyTo(destination.Slice(tempChars + 1));

        charsWritten = requiredLength;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool WriteString(Span<char> destination, out int charsWritten, ReadOnlySpan<char> value)
    {
        if (value.Length > destination.Length)
        {
            charsWritten = 0;
            return false;
        }
        value.CopyTo(destination);
        charsWritten = value.Length;
        return true;
    }

    #endregion

    #region UTF-8 Format Implementations

    private bool TryFormatZeroUtf8(Span<byte> destination, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        if (format.IsEmpty)
        {
            if (destination.Length < 1)
            {
                bytesWritten = 0;
                return false;
            }
            destination[0] = (byte)'0';
            bytesWritten = 1;
            return true;
        }

        // Use UTF-16 then convert
        Span<char> charBuffer = stackalloc char[256];
        if (!TryFormatZero(charBuffer, out int charsWritten, format, provider))
        {
            bytesWritten = 0;
            return false;
        }

        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatRawUtf8(Span<byte> destination, out int bytesWritten, IFormatProvider? provider)
    {
        BigNumber normalized = this.Normalize();

        char[]? bufferChars = null;
        Span<char> buffer = destination.Length < StackAllocThreshold
            ? stackalloc char[StackAllocThreshold]
            : (bufferChars = ArrayPool<char>.Shared.Rent(destination.Length));

        try
        {
            if (!normalized.Significand.TryFormat(buffer, out int pos, default, CultureInfo.InvariantCulture))
            {
                bytesWritten = 0;
                return false;
            }

            if (normalized.Exponent == 0)
            {
                return TryEncodeUtf8(buffer.Slice(0, pos), destination, out bytesWritten);
            }

            if (!TryEncodeUtf8(buffer.Slice(pos), destination, out pos))
            {
                bytesWritten = 0;
                return false;
            }

            if (destination.Length == pos)
            {
                bytesWritten = 0;
                return false;
            }

            destination[pos++] = (byte)'E';


            if (Utf8Formatter.TryFormat(normalized.Exponent, destination.Slice(pos), out int expBytes))
            {
                bytesWritten = 0;
                return false;
            }

            bytesWritten = pos + expBytes;
            return true;
        }
        finally
        {
            if (bufferChars is char[] bc)
            {
                ArrayPool<char>.Shared.Return(bc);
            }
        }
    }

    private bool TryFormatGeneralUtf8(Span<byte> destination, out int bytesWritten, int precision, char exponentChar, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatGeneral(charBuffer, out int charsWritten, precision, exponentChar, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatFixedPointUtf8(Span<byte> destination, out int bytesWritten, int precision, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatFixedPoint(charBuffer, out int charsWritten, precision, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatNumberUtf8(Span<byte> destination, out int bytesWritten, int precision, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatNumber(charBuffer, out int charsWritten, precision, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatExponentialUtf8(Span<byte> destination, out int bytesWritten, int precision, char exponentChar, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatExponential(charBuffer, out int charsWritten, precision, exponentChar, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatCurrencyUtf8(Span<byte> destination, out int bytesWritten, int precision, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatCurrency(charBuffer, out int charsWritten, precision, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    private bool TryFormatPercentUtf8(Span<byte> destination, out int bytesWritten, int precision, NumberFormatInfo formatInfo)
    {
        Span<char> charBuffer = stackalloc char[512];
        if (!TryFormatPercent(charBuffer, out int charsWritten, precision, formatInfo))
        {
            bytesWritten = 0;
            return false;
        }
        return TryEncodeUtf8(charBuffer.Slice(0, charsWritten), destination, out bytesWritten);
    }

    #endregion

    #region UTF-8 Helper Methods

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryEncodeUtf8(ReadOnlySpan<char> source, Span<byte> destination, out int bytesWritten)
    {
        int requiredBytes = Encoding.UTF8.GetByteCount(source);
        if (requiredBytes > destination.Length)
        {
            bytesWritten = 0;
            return false;
        }
        bytesWritten = Encoding.UTF8.GetBytes(source, destination);
        return true;
    }

    #endregion

    #region Utility Methods

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ReadOnlySpan<char> GetNegativeSign(NumberFormatInfo formatInfo)
    {
        // Fast path for invariant culture (most common case)
        if (ReferenceEquals(formatInfo, NumberFormatInfo.InvariantInfo))
        {
            return "-";
        }

        return formatInfo.NegativeSign.AsSpan();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetNegativeSignLength(NumberFormatInfo formatInfo)
    {
        return ReferenceEquals(formatInfo, NumberFormatInfo.InvariantInfo)
            ? 1
            : formatInfo.NegativeSign.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryParseInt32(ReadOnlySpan<char> span, out int value)
    {
#if NET
        return int.TryParse(span, NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
#else
        return ParsingPolyfills.TryParseInt32Invariant(span, out value);
#endif
    }

    private static BigNumber RoundToSignificantDigits(BigNumber value, int significantDigits)
    {
        if (value.Significand.IsZero || significantDigits <= 0)
        {
            return value;
        }

        BigInteger absSignificand = BigInteger.Abs(value.Significand);
        int digits = (int)BigInteger.Log10(absSignificand) + 1;
        if (digits <= significantDigits)
        {
            return value;
        }

        int digitsToRemove = digits - significantDigits;
        BigInteger divisor = GetPowerOf10(digitsToRemove);
        BigInteger quotient = BigInteger.DivRem(value.Significand, divisor, out BigInteger remainder);

        // Round to nearest, ties to even
        BigInteger halfDivisor = divisor / 2;
        BigInteger absRemainder = BigInteger.Abs(remainder);
        if (absRemainder > halfDivisor ||
            absRemainder == halfDivisor && !quotient.IsEven)
        {
            quotient += value.Significand.Sign;
        }

        return new BigNumber(quotient, value.Exponent + digitsToRemove);
    }

    #endregion

    #region Grouping Support

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryApplyGrouping(
        ReadOnlySpan<char> source,
        Span<char> destination,
        out int charsWritten,
        string groupSeparator,
        int[] groupSizes,
        string decimalSeparator)
    {
        charsWritten = 0;

        // Find the decimal separator position (if any)
        int decimalPos = source.IndexOf(decimalSeparator.AsSpan());
        ReadOnlySpan<char> integerPart = decimalPos >= 0 ? source.Slice(0, decimalPos) : source;
        ReadOnlySpan<char> decimalPart = decimalPos >= 0 ? source.Slice(decimalPos) : ReadOnlySpan<char>.Empty;

        // Handle negative sign
        bool isNegative = integerPart.Length > 0 && integerPart[0] == '-';
        ReadOnlySpan<char> digits = isNegative ? integerPart.Slice(1) : integerPart;

        // Fast path: No grouping needed
        if (groupSizes == null || groupSizes.Length == 0 || groupSizes[0] == 0 ||
            digits.Length <= groupSizes[0]) // Too small for grouping
        {
            if (source.Length > destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            source.CopyTo(destination);
            charsWritten = source.Length;
            return true;
        }

        // Calculate positions for group separators (working from right to left)
        int digitCount = digits.Length;
        int groupSeparatorLength = groupSeparator.Length;

        // Build insertion positions from right to left
        Span<int> separatorPositions = stackalloc int[32]; // Max 32 separators should be enough
        int separatorCount = 0;
        int position = digitCount;
        int groupIndex = 0;
        int currentGroupSize = groupSizes[0];

        while (position > currentGroupSize && separatorCount < 32)
        {
            position -= currentGroupSize;
            separatorPositions[separatorCount++] = position;

            // Move to next group size or stay on last one
            if (groupIndex < groupSizes.Length - 1 && groupSizes[groupIndex + 1] > 0)
            {
                groupIndex++;
                currentGroupSize = groupSizes[groupIndex];
            }
        }

        // Calculate required space
        int requiredSpace = (isNegative ? 1 : 0) + digitCount + (separatorCount * groupSeparatorLength) + decimalPart.Length;
        if (requiredSpace > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        // Build the result
        int destPos = 0;

        // Write negative sign if needed
        if (isNegative)
        {
            destination[destPos++] = '-';
        }

        // Write digits with separators
        int nextSeparatorIndex = separatorCount - 1; // Process separators from left to right
        for (int i = 0; i < digitCount; i++)
        {
            // Check if we need a separator before this position
            if (nextSeparatorIndex >= 0 && i == separatorPositions[nextSeparatorIndex])
            {
                groupSeparator.AsSpan().CopyTo(destination.Slice(destPos));
                destPos += groupSeparatorLength;
                nextSeparatorIndex--;
            }

            destination[destPos++] = digits[i];
        }

        // Copy decimal part if present
        if (decimalPart.Length > 0)
        {
            decimalPart.CopyTo(destination.Slice(destPos));
            destPos += decimalPart.Length;
        }

        charsWritten = destPos;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryApplyCurrencyPattern(
        ReadOnlySpan<char> numberPart,
        Span<char> destination,
        out int charsWritten,
        NumberFormatInfo formatInfo,
        bool isNegative)
    {
        string symbol = formatInfo.CurrencySymbol;
        int pattern = isNegative ? formatInfo.CurrencyNegativePattern : formatInfo.CurrencyPositivePattern;

        // Pattern reference:
        // Positive: 0=$n, 1=n$, 2=$ n, 3=n $
        // Negative: 0=($n), 1=-$n, 2=$-n, 3=$n-, 4=(n$), 5=-n$, 6=n-$, 7=n$-, 8=-n $, 9=- $n, 10=n $-, 11=$ n-, 12=$ -n, 13=n- $, 14=($ n), 15=(n $)

        charsWritten = 0;

        if (!isNegative)
        {
            switch (pattern)
            {
                case 0: // $n
                    return WriteString(destination, out charsWritten, symbol.AsSpan())
                        && AppendString(destination, ref charsWritten, numberPart);

                case 1: // n$
                    return WriteString(destination, out charsWritten, numberPart)
                        && AppendString(destination, ref charsWritten, symbol.AsSpan());

                case 2: // $ n
                    return WriteString(destination, out charsWritten, symbol.AsSpan())
                        && AppendChar(destination, ref charsWritten, ' ')
                        && AppendString(destination, ref charsWritten, numberPart);

                case 3: // n $
                    return WriteString(destination, out charsWritten, numberPart)
                        && AppendChar(destination, ref charsWritten, ' ')
                        && AppendString(destination, ref charsWritten, symbol.AsSpan());
            }
        }
        else
        {
            // Handle negative sign from numberPart
            ReadOnlySpan<char> absNumberPart = numberPart[0] == '-' ? numberPart.Slice(1) : numberPart;

            switch (pattern)
            {
                case 0: // ($n)
                    return WriteChar(destination, out charsWritten, '(')
                        && AppendString(destination, ref charsWritten, symbol.AsSpan())
                        && AppendString(destination, ref charsWritten, absNumberPart)
                        && AppendChar(destination, ref charsWritten, ')');

                case 1: // -$n
                    return WriteChar(destination, out charsWritten, '-')
                        && AppendString(destination, ref charsWritten, symbol.AsSpan())
                        && AppendString(destination, ref charsWritten, absNumberPart);

                case 2: // $-n
                    return WriteString(destination, out charsWritten, symbol.AsSpan())
                        && AppendChar(destination, ref charsWritten, '-')
                        && AppendString(destination, ref charsWritten, absNumberPart);

                case 3: // $n-
                    return WriteString(destination, out charsWritten, symbol.AsSpan())
                        && AppendString(destination, ref charsWritten, absNumberPart)
                        && AppendChar(destination, ref charsWritten, '-');

                case 5: // -n$
                    return WriteChar(destination, out charsWritten, '-')
                        && AppendString(destination, ref charsWritten, absNumberPart)
                        && AppendString(destination, ref charsWritten, symbol.AsSpan());

                case 8: // -n $
                    return WriteChar(destination, out charsWritten, '-')
                        && AppendString(destination, ref charsWritten, absNumberPart)
                        && AppendChar(destination, ref charsWritten, ' ')
                        && AppendString(destination, ref charsWritten, symbol.AsSpan());

                case 9: // -$ n
                    return WriteChar(destination, out charsWritten, '-')
                        && AppendString(destination, ref charsWritten, symbol.AsSpan())
                        && AppendChar(destination, ref charsWritten, ' ')
                        && AppendString(destination, ref charsWritten, absNumberPart);

                // Default for other patterns: fall back to simple format
                default:
                    return WriteString(destination, out charsWritten, symbol.AsSpan())
                        && AppendString(destination, ref charsWritten, numberPart);
            }
        }

        // Fallback
        return WriteString(destination, out charsWritten, numberPart);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool WriteChar(Span<char> destination, out int charsWritten, char c)
    {
        if (destination.Length < 1)
        {
            charsWritten = 0;
            return false;
        }

        destination[0] = c;
        charsWritten = 1;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendChar(Span<char> destination, ref int position, char c)
    {
        if (position >= destination.Length)
        {
            return false;
        }

        destination[position++] = c;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool AppendString(Span<char> destination, ref int position, ReadOnlySpan<char> value)
    {
        if (position + value.Length > destination.Length)
        {
            return false;
        }

        value.CopyTo(destination.Slice(position));
        position += value.Length;
        return true;
    }

    #endregion
}
