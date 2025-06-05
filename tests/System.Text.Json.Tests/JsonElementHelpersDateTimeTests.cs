// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;
using NodaTime;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public class JsonElementHelpersDateTimeTests
    {
        [Fact]
        public void TryFormatLocalDate_RoundTrip()
        {
            var date = new LocalDate(2024, 6, 7);
            Span<byte> buffer = stackalloc byte[16];
            Assert.True(JsonElementHelpers.TryFormatLocalDate(date, buffer, out int written));
            Assert.True(JsonElementHelpers.TryParseLocalDate(buffer[..written], out var parsed));
            Assert.Equal(date, parsed);
        }

        [Fact]
        public void TryFormatOffsetDate_RoundTrip()
        {
            var date = new OffsetDate(new LocalDate(2024, 6, 7), Offset.FromHours(2));
            Span<byte> buffer = stackalloc byte[32];
            Assert.True(JsonElementHelpers.TryFormatOffsetDate(date, buffer, out int written));
            Assert.True(JsonElementHelpers.TryParseOffsetDate(buffer[..written], out var parsed));
            Assert.Equal(date, parsed);
        }

        [Fact]
        public void TryFormatOffsetDateTime_RoundTrip()
        {
            var dt = new OffsetDateTime(new LocalDateTime(2024, 6, 7, 12, 34, 56, 789), Offset.FromHours(-3));
            Span<byte> buffer = stackalloc byte[40];
            Assert.True(JsonElementHelpers.TryFormatOffsetDateTime(dt, buffer, out int written));
            Assert.True(JsonElementHelpers.TryParseOffsetDateTime(buffer[..written], out var parsed));
            Assert.Equal(dt, parsed);
        }

        [Fact]
        public void TryFormatOffsetTime_RoundTrip()
        {
            var t = new OffsetTime(new LocalTime(12, 34, 56, 789), Offset.FromHours(1));
            Span<byte> buffer = stackalloc byte[32];
            Assert.True(JsonElementHelpers.TryFormatOffsetTime(t, buffer, out int written));
            Assert.True(JsonElementHelpers.TryParseOffsetTime(buffer[..written], out var parsed));
            Assert.Equal(t, parsed);
        }

        [Fact]
        public void TryFormatPeriod_RoundTrip()
        {
            var period = Period.FromDays(5) + Period.FromHours(3) + Period.FromMinutes(2);
            Span<byte> buffer = stackalloc byte[90];
            Assert.True(JsonElementHelpers.TryFormatPeriod(period, buffer, out int written));
            Assert.True(JsonElementHelpers.TryParsePeriod(buffer[..written], out var parsed));
            Assert.Equal(period.Normalize(), parsed.Normalize());
        }

        [Fact]
        public void ParsePeriod_ThrowsOnInvalid()
        {
            var invalid = Encoding.UTF8.GetBytes("notaperiod");
            Assert.Throws<FormatException>(() => JsonElementHelpers.ParsePeriod(invalid));
        }

        [Fact]
        public void TryParsePeriod_ValidAndInvalid()
        {
            var valid = Encoding.UTF8.GetBytes("P1D");
            Assert.True(JsonElementHelpers.TryParsePeriod(valid, out var period));
            Assert.Equal(Period.FromDays(1), period);

            var invalid = Encoding.UTF8.GetBytes("notaperiod");
            Assert.False(JsonElementHelpers.TryParsePeriod(invalid, out _));
        }

        [Fact]
        public void ParseLocalDate_ThrowsOnInvalid()
        {
            var invalid = Encoding.UTF8.GetBytes("2024-13-40");
            Assert.Throws<FormatException>(() => JsonElementHelpers.ParseLocalDate(invalid));
        }

        [Fact]
        public void TryParseLocalDate_ValidAndInvalid()
        {
            var valid = Encoding.UTF8.GetBytes("2024-06-07");
            Assert.True(JsonElementHelpers.TryParseLocalDate(valid, out var date));
            Assert.Equal(new LocalDate(2024, 6, 7), date);

            var invalid = Encoding.UTF8.GetBytes("2024-13-40");
            Assert.False(JsonElementHelpers.TryParseLocalDate(invalid, out _));
        }

        [Fact]
        public void ParseOffsetTime_ThrowsOnInvalid()
        {
            var invalid = Encoding.UTF8.GetBytes("25:00:00+01:00");
            Assert.Throws<FormatException>(() => JsonElementHelpers.ParseOffsetTime(invalid));
        }

        [Fact]
        public void TryParseOffsetTime_ValidAndInvalid()
        {
            var valid = Encoding.UTF8.GetBytes("12:34:56.7890000+01:00");
            Assert.True(JsonElementHelpers.TryParseOffsetTime(valid, out var t));
            Assert.Equal(new OffsetTime(new LocalTime(12, 34, 56, 789), Offset.FromHours(1)), t);

            var invalid = Encoding.UTF8.GetBytes("25:00:00+01:00");
            Assert.False(JsonElementHelpers.TryParseOffsetTime(invalid, out _));
        }

        [Fact]
        public void CreateOffsetTimeCore_ProducesExpected()
        {
            var t = JsonElementHelpers.CreateOffsetTimeCore(12, 34, 56, 789, 0, 0, 3600);
            Assert.Equal(new OffsetTime(new LocalTime(12, 34, 56, 789), Offset.FromHours(1)), t);
        }

        [Fact]
        public void CreateOffsetTimeCore_WithoutMicroNano()
        {
            var t = JsonElementHelpers.CreateOffsetTimeCore(12, 34, 56, 789, 3600);
            Assert.Equal(new OffsetTime(new LocalTime(12, 34, 56, 789), Offset.FromHours(1)), t);
        }

        [Fact]
        public void ParseOffsetDateTime_ThrowsOnInvalid()
        {
            var invalid = Encoding.UTF8.GetBytes("2024-06-07T25:00:00+01:00");
            Assert.Throws<FormatException>(() => JsonElementHelpers.ParseOffsetDateTime(invalid));
        }

        [Fact]
        public void TryParseOffsetDateTime_ValidAndInvalid()
        {
            var valid = Encoding.UTF8.GetBytes("2024-06-07T12:34:56.7890000+01:00");
            Assert.True(JsonElementHelpers.TryParseOffsetDateTime(valid, out var dt));
            Assert.Equal(new OffsetDateTime(new LocalDateTime(2024, 6, 7, 12, 34, 56, 789), Offset.FromHours(1)), dt);

            var invalid = Encoding.UTF8.GetBytes("2024-06-07T25:00:00+01:00");
            Assert.False(JsonElementHelpers.TryParseOffsetDateTime(invalid, out _));
        }

        [Fact]
        public void CreateOffsetDateTimeCore_ProducesExpected()
        {
            var dt = JsonElementHelpers.CreateOffsetDateTimeCore(2024, 6, 7, 12, 34, 56, 789, 0, 0, 3600);
            Assert.Equal(new OffsetDateTime(new LocalDateTime(2024, 6, 7, 12, 34, 56, 789), Offset.FromHours(1)), dt);
        }

        [Fact]
        public void CreateOffsetDateTimeCore_WithoutMicroNano()
        {
            var dt = JsonElementHelpers.CreateOffsetDateTimeCore(2024, 6, 7, 12, 34, 56, 789, 3600);
            Assert.Equal(new OffsetDateTime(new LocalDateTime(2024, 6, 7, 12, 34, 56, 789), Offset.FromHours(1)), dt);
        }

        [Fact]
        public void ParseOffsetDate_ThrowsOnInvalid()
        {
            var invalid = Encoding.UTF8.GetBytes("2024-13-40+01:00");
            Assert.Throws<FormatException>(() => JsonElementHelpers.ParseOffsetDate(invalid));
        }

        [Fact]
        public void TryParseOffsetDate_ValidAndInvalid()
        {
            var valid = Encoding.UTF8.GetBytes("2024-06-07+01:00");
            Assert.True(JsonElementHelpers.TryParseOffsetDate(valid, out var date));
            Assert.Equal(new OffsetDate(new LocalDate(2024, 6, 7), Offset.FromHours(1)), date);

            var invalid = Encoding.UTF8.GetBytes("2024-13-40+01:00");
            Assert.False(JsonElementHelpers.TryParseOffsetDate(invalid, out _));
        }
    }
}
