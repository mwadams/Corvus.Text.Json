// <copyright file="StandardDateFormat.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NodaTime;
using NodaTime.Calendars;

namespace Corvus.Text.Json.Internal;

public static partial class JsonElementHelpers
{
    /// <summary>
    /// Format a date as a UTF-8 string.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <param name="output">The output buffer.</param>
    /// <param name="bytesWritten">The number of bytes written to the output buffer.</param>
    /// <returns><see langword="true"/> if the date was formatted successfully.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFormatLocalDate(in LocalDate value, Span<byte> output, out int bytesWritten)
    {
        return TryFormat(value, output, out bytesWritten);
    }

    /// <summary>
    /// Format a date as a UTF-8 string.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <param name="output">The output buffer.</param>
    /// <param name="bytesWritten">The number of bytes written to the output buffer.</param>
    /// <returns><see langword="true"/> if the date was formatted successfully.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFormatOffsetDate(in OffsetDate value, Span<byte> output, out int bytesWritten)
    {
        return TryFormat(value, output, out bytesWritten);
    }

    /// <summary>
    /// Format an offset date time as a UTF-8 string.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <param name="output">The output buffer.</param>
    /// <param name="bytesWritten">The number of bytes written to the output buffer.</param>
    /// <returns><see langword="true"/> if the date was formatted successfully.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFormatOffsetDateTime(in OffsetDateTime value, Span<byte> output, out int bytesWritten)
    {
        return TryFormat(value, output, out bytesWritten);
    }

    /// <summary>
    /// Format a time as a UTF-8 string.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <param name="output">The output buffer.</param>
    /// <param name="bytesWritten">The number of bytes written to the output buffer.</param>
    /// <returns><see langword="true"/> if the time was formatted successfully.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFormatOffsetTime(in OffsetTime value, Span<byte> output, out int bytesWritten)
    {
        return TryFormat(value, output, out bytesWritten);
    }

    /// <summary>
    /// Format a period as a UTF-8 string for the <c>duration</c> format.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <param name="output">The output buffer.</param>
    /// <param name="bytesWritten">The number of bytes written to the output buffer.</param>
    /// <returns><see langword="true"/> if the period was formatted successfully.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryFormatPeriod(in Period value, Span<byte> output, out int bytesWritten)
    {
        return TryFormat(value, output, out bytesWritten);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Period ParsePeriod(ReadOnlySpan<byte> text)
    {
        if (!TryParsePeriod(text, out Period value))
        {
            ThrowHelper.ThrowFormatException(DataType.Period);
        }

        return value;
    }
    /// <summary>
    /// Parse a period from a string for the <c>duration</c> format.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="value">The resulting duration.</param>
    /// <returns><see langword="true"/> if the duration could be parsed.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParsePeriod(ReadOnlySpan<byte> text, out Period value)
    {
        return Period.TryParse(text,out value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LocalDate ParseLocalDate(ReadOnlySpan<byte> text)
    {
        if (!TryParseLocalDate(text, out LocalDate value))
        {
            ThrowHelper.ThrowFormatException(DataType.LocalDate);
        }

        return value;
    }       
    /// <summary>
    /// Parse a date from a string for the <c>date</c> format.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="value">The resulting date.</param>
    /// <returns><see langword="true"/> if the date could be parsed.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseLocalDate(ReadOnlySpan<byte> text, out LocalDate value)
    {
        if (text.Length != 10)
        {
            value = default;
            return false;
        }

        if (!ParseDateCore(text, out int year, out int month, out int day) || !GregorianYearMonthDayCalculator.TryValidateGregorianYearMonthDay(year, month, day))
        {
            value = default;
            return false;
        }

        value = new LocalDate(year, month, day);
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OffsetTime ParseOffsetTime(ReadOnlySpan<byte> text)
    {
        if (!TryParseOffsetTime(text, out OffsetTime value))
        {
            ThrowHelper.ThrowFormatException(DataType.OffsetTime);
        }

        return value;
    }

    /// <summary>
    /// Parse a time from a string for the <c>time</c> format.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="value">The resulting time.</param>
    /// <returns><see langword="true"/> if the time could be parsed.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseOffsetTime(ReadOnlySpan<byte> text, out OffsetTime value)
    {
        if (text.Length < JsonConstants.MinimumTimeParseLength)
        {
            value = default;
            return false;
        }

        if (!ParseOffsetTimeCore(text, out int hours, out int minutes, out int seconds, out int milliseconds, out int microseconds, out int nanoseconds, out int offsetSeconds))
        {
            value = default;
            return false;
        }

        value = CreateOffsetTimeCore(hours, minutes, seconds, milliseconds, microseconds, nanoseconds, offsetSeconds);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
    {
        OffsetTime value;
        var localTime = new LocalTime(hours, minutes, seconds, milliseconds);

        if (microseconds != 0 || nanoseconds != 0)
        {
            localTime = localTime.PlusNanoseconds((microseconds * 1000) + nanoseconds);
        }

        value = new OffsetTime(
            localTime,
            Offset.FromSeconds(offsetSeconds));
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OffsetTime CreateOffsetTimeCore(int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
    {
        OffsetTime value;
        var localTime = new LocalTime(hours, minutes, seconds, milliseconds);

        value = new OffsetTime(
            localTime,
            Offset.FromSeconds(offsetSeconds));
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OffsetDateTime ParseOffsetDateTime(ReadOnlySpan<byte> text)
    {
        if (!TryParseOffsetDateTime(text, out OffsetDateTime value))
        {
            ThrowHelper.ThrowFormatException(DataType.OffsetTime);
        }

        return value;
    }

    /// <summary>
    /// Parse a date time from a string for the <c>date-time</c> format.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="value">The resulting date time.</param>
    /// <returns><see langword="true"/> if the date could be parsed.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseOffsetDateTime(ReadOnlySpan<byte> text, out OffsetDateTime value)
    {
        if (text.Length < JsonConstants.MinimumDateTimeParseLength)
        {
            value = default;
            return false;
        }

        // We allow lower case T in the middle which is not strictly
        // permissible, but tested for by the standard json-schema test suite.
        if (text[10] != 'T' && text[10] != 't')
        {
            value = default;
            return false;
        }

        if (!ParseDateCore(text, out int year, out int month, out int day) || !GregorianYearMonthDayCalculator.TryValidateGregorianYearMonthDay(year, month, day))
        {
            value = default;
            return false;
        }

        if (!ParseOffsetTimeCore(text[11..], out int hours, out int minutes, out int seconds, out int milliseconds, out int microseconds, out int nanoseconds, out int offsetSeconds))
        {
            value = default;
            return false;
        }

        value = CreateOffsetDateTimeCore(year, month, day, hours, minutes, seconds, milliseconds, microseconds, nanoseconds, offsetSeconds);

        return true;
    }

    public static OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int microseconds, int nanoseconds, int offsetSeconds)
    {
        OffsetDateTime value = new OffsetDateTime(
            new LocalDateTime(year, month, day, hours, minutes, seconds, milliseconds),
            Offset.FromSeconds(offsetSeconds));
        if (microseconds != 0 || nanoseconds != 0)
        {
            value = value.PlusNanoseconds((microseconds * 1000) + nanoseconds);
        }

        return value;
    }

    public static OffsetDateTime CreateOffsetDateTimeCore(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds, int offsetSeconds)
    {
        OffsetDateTime value = new OffsetDateTime(
            new LocalDateTime(year, month, day, hours, minutes, seconds, milliseconds),
            Offset.FromSeconds(offsetSeconds));

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OffsetDate ParseOffsetDate(ReadOnlySpan<byte> text)
    {
        if (!TryParseOffsetDate(text, out OffsetDate value))
        {
            ThrowHelper.ThrowFormatException(DataType.OffsetTime);
        }

        return value;
    }

    /// <summary>
    /// Parse a date time from a string for the <c>date-time</c> format.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="value">The resulting date time.</param>
    /// <returns><see langword="true"/> if the date could be parsed.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseOffsetDate(ReadOnlySpan<byte> text, out OffsetDate value)
    {
        if (text.Length < JsonConstants.MinimumDateParseLength)
        {
            value = default;
            return false;
        }

        if (!ParseDateCore(text, out int year, out int month, out int day)|| !GregorianYearMonthDayCalculator.TryValidateGregorianYearMonthDay(year, month, day))
        {
            value = default;
            return false;
        }

        if (!ParseOffsetCore(text[10..], out int offsetSeconds))
        {
            value = default;
            return false;
        }

        value = new OffsetDate(
            new LocalDate(year, month, day),
            Offset.FromSeconds(offsetSeconds));

        return true;
    }

    // Roundtrippable format. One of
    //   012345678901234567890123456789012
    //   ---------------------------------
    //   2017-06-12T05:30:45.7680000-07:00
    //   2017-06-12T05:30:45.7680000Z           (Z is short for "+00:00")
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool TryFormat(in OffsetDateTime dateTime, Span<byte> destination, out int bytesWritten)
    {
        int bytesRequired = JsonConstants.MaximumFormatDateTimeOffsetLength;

        if (destination.Length < bytesRequired)
        {
            bytesWritten = 0;
            return false;
        }
        bytesWritten = bytesRequired;

        fixed (byte* dest = &MemoryMarshal.GetReference(destination))
        {
            Number.WriteFourDigits((uint)dateTime.Year, dest);
            dest[4] = (byte)'-';
            Number.WriteTwoDigits((uint)dateTime.Month, dest + 5);
            dest[7] = (byte)'-';
            Number.WriteTwoDigits((uint)dateTime.Day, dest + 8);
            dest[10] = (byte)'T';

            Number.WriteTwoDigits((uint)dateTime.Hour, dest + 11);
            dest[13] = (byte)':';
            Number.WriteTwoDigits((uint)dateTime.Minute, dest + 14);
            dest[16] = (byte)':';
            Number.WriteTwoDigits((uint)dateTime.Second, dest + 17);
            dest[19] = (byte)'.';
            Number.WriteDigits((uint)dateTime.TickOfSecond, dest + 20, 7);

            if (dateTime.Offset == Offset.Zero)
            {
                dest[27] = (byte)'Z';
            }
            else
            {
                int offsetTotalMinutes = (int)(dateTime.Offset.Ticks / TimeSpan.TicksPerMinute);

                char sign = '+';
                if (offsetTotalMinutes < 0)
                {
                    sign = '-';
                    offsetTotalMinutes = -offsetTotalMinutes;
                }

#if NET
                (int offsetHours, int offsetMinutes) = Math.DivRem(offsetTotalMinutes, 60);
#else
                int offsetHours = Math.DivRem(offsetTotalMinutes, 60, out int offsetMinutes);
#endif
                dest[27] = (byte)sign;
                Number.WriteTwoDigits((uint)offsetHours, dest + 28);
                dest[30] = (byte)':';
                Number.WriteTwoDigits((uint)offsetMinutes, dest + 31);
            }
        }

        return true;
    }

    // Roundtrippable format. One of
    //   012345678901234567890123456789012
    //   ---------------------------------
    //   2017-06-12-07:00
    //   2017-06-12Z           (Z is short for "+00:00")
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool TryFormat(in OffsetDate date, Span<byte> destination, out int bytesWritten)
    {
        int bytesRequired = JsonConstants.MaximumFormatOffsetDateLength;

        if (destination.Length < bytesRequired)
        {
            bytesWritten = 0;
            return false;
        }

        fixed (byte* dest = &MemoryMarshal.GetReference(destination))
        {
            Number.WriteFourDigits((uint)date.Year, dest);
            dest[4] = (byte)'-';
            Number.WriteTwoDigits((uint)date.Month, dest + 5);
            dest[7] = (byte)'-';
            Number.WriteTwoDigits((uint)date.Day, dest + 8);

            if (date.Offset == Offset.Zero)
            {
                dest[10] = (byte)'Z';
                bytesWritten = 11;
            }
            else
            {
                int offsetTotalMinutes = (int)(date.Offset.Ticks / TimeSpan.TicksPerMinute);

                char sign = '+';
                if (offsetTotalMinutes < 0)
                {
                    sign = '-';
                    offsetTotalMinutes = -offsetTotalMinutes;
                }

#if NET
                (int offsetHours, int offsetMinutes) = Math.DivRem(offsetTotalMinutes, 60);
#else
                int offsetHours = Math.DivRem(offsetTotalMinutes, 60, out int offsetMinutes);
#endif
                dest[10] = (byte)sign;
                Number.WriteTwoDigits((uint)offsetHours, dest + 11);
                dest[13] = (byte)':';
                Number.WriteTwoDigits((uint)offsetMinutes, dest + 14);
                bytesWritten = 16;
            }
        }

        return true;
    }

    // Roundtrippable format.
    //   0123456789
    //   ----------
    //   2017-06-12
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool TryFormat(in LocalDate date, Span<byte> destination, out int bytesWritten)
    {
        int bytesRequired = JsonConstants.MaximumFormatDateLength;

        if (destination.Length < bytesRequired)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = bytesRequired;

        fixed (byte* dest = &MemoryMarshal.GetReference(destination))
        {
            Number.WriteFourDigits((uint)date.Year, dest);
            dest[4] = (byte)'-';
            Number.WriteTwoDigits((uint)date.Month, dest + 5);
            dest[7] = (byte)'-';
            Number.WriteTwoDigits((uint)date.Day, dest + 8);
        }

        return true;
    }

    // Roundtrippable format. One of
    //   0123456789012345678901
    //   ----------------------
    //   05:30:45.7680000-07:00
    //   05:30:45.7680000Z           (Z is short for "+00:00" but also distinguishes DateTimeKind.Utc from DateTimeKind.Local)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool TryFormat(in OffsetTime offsetTime, Span<byte> destination, out int bytesWritten)
    {
        int bytesRequired = JsonConstants.MaximumFormatOffsetTimeLength;

        if (destination.Length < bytesRequired)
        {
            bytesWritten = 0;
            return false;
        }

        fixed (byte* dest = &MemoryMarshal.GetReference(destination))
        {
            Number.WriteTwoDigits((uint)offsetTime.Hour, dest);
            dest[2] = (byte)':';
            Number.WriteTwoDigits((uint)offsetTime.Minute, dest + 3);
            dest[5] = (byte)':';
            Number.WriteTwoDigits((uint)offsetTime.Second, dest + 6);
            dest[8] = (byte)'.';
            Number.WriteDigits((uint)offsetTime.TickOfSecond, dest + 9, 7);

            if (offsetTime.Offset == Offset.Zero)
            {
                dest[16] = (byte)'Z';
                bytesWritten = 17;
            }
            else
            {
                int offsetTotalMinutes = (int)(offsetTime.Offset.Ticks / TimeSpan.TicksPerMinute);

                char sign = '+';
                if (offsetTotalMinutes < 0)
                {
                    sign = '-';
                    offsetTotalMinutes = -offsetTotalMinutes;
                }

#if NET
                (int offsetHours, int offsetMinutes) = Math.DivRem(offsetTotalMinutes, 60);
#else
                int offsetHours = Math.DivRem(offsetTotalMinutes, 60, out int offsetMinutes);
#endif
                dest[16] = (byte)sign;
                Number.WriteTwoDigits((uint)offsetHours, dest + 17);
                dest[19] = (byte)':';
                Number.WriteTwoDigits((uint)offsetMinutes, dest + 20);
                bytesWritten = 22;
            }
        }

        return true;
    }

    // Roundtrippable format. One of
    //   012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
    //   ------------------------------------------------------------------------------------------
    //   P2147483647Y2147483647M2147483647W2147483647DT2147483647H2147483647M-2147483647.123456789S
    //   P2147483647Y2147483647M2147483647W2147483647D
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool TryFormat(in Period incomingPeriod, Span<byte> destination, out int bytesWritten)
    {
        int bytesRequired = JsonConstants.MaximumFormatPeriodLength;

        if (destination.Length < bytesRequired)
        {
            bytesWritten = 0;
            return false;
        }

        Period period = incomingPeriod.Normalize();

        if (period.Equals(Period.Zero))
        {
            "P0D"u8.CopyTo(destination);
            bytesWritten = 3;
            return true;
        }

        int index = 0;
        int localWritten;

        destination[index++] = (byte)'P';
        if (!Utf8Formatter.TryFormat(period.Years, destination.Slice(index), out localWritten))
        {
            bytesWritten = 0;
            return false;
        }

        index += localWritten;
        destination[index++] = (byte)'Y';


        if (!Utf8Formatter.TryFormat(period.Months, destination.Slice(index), out localWritten))
        {
            bytesWritten = 0;
            return false;
        }

        index += localWritten;
        destination[index++] = (byte)'M';

        if (!Utf8Formatter.TryFormat(period.Weeks, destination.Slice(index), out localWritten))
        {
            bytesWritten = 0;
            return false;
        }

        index += localWritten;
        destination[index++] = (byte)'W';

        if (!Utf8Formatter.TryFormat(period.Days, destination.Slice(index), out localWritten))
        {
            bytesWritten = 0;
            return false;
        }

        index += localWritten;
        destination[index++] = (byte)'D';


        if (period.HasTimeComponent)
        {
            destination[index++] = (byte)'T';
            if (!Utf8Formatter.TryFormat(period.Hours, destination.Slice(index), out localWritten))
            {
                bytesWritten = 0;
                return false;
            }

            index += localWritten;
            destination[index++] = (byte)'H';
            if (!Utf8Formatter.TryFormat(period.Minutes, destination.Slice(index), out localWritten))
            {
                bytesWritten = 0;
                return false;
            }

            index += localWritten;
            destination[index++] = (byte)'M';
            long integral = period.Milliseconds * 1000000 + period.Ticks * 100 + period.Nanoseconds;
            long fractional = period.Seconds;
            if (integral != 0L || fractional != 0L)
            {
                if (integral < 0 || fractional < 0)
                {
                    destination[index++] = (byte)'-';
                    integral = -integral;
                    fractional = -fractional;
                }

                if (!Utf8Formatter.TryFormat(fractional, destination.Slice(index), out localWritten))
                {
                    bytesWritten = 0;
                    return false;
                }

                if (integral != 0L)
                {
                    destination[index++] = (byte)'.';
                    fixed (byte* dest = &MemoryMarshal.GetReference(destination))
                    {
                        Number.WriteDigits((uint)integral, dest + index, 9);
                    }

                    index += 9;
                }

                destination[index++] = (byte)'S';
            }
        }

        bytesWritten = index;
        return true;
    }
}
