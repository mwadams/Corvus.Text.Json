// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.Json;
using NodaTime;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public static class JsonElementSourceCoverageTests
    {
        [Fact]
        public static void SourceConstructorAndImplicitOperator_Byte()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            byte value = 42;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetByte());
            
            // Validate JSON string representation
            string json = doc.RootElement.GetRawText();
            Assert.Equal("42", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_SByte()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            sbyte value = -42;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetSByte());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("-42", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Short()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            short value = -1234;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetInt16());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("-1234", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_UShort()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            ushort value = 12345;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetUInt16());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("12345", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Int()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            int value = -123456;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetInt32());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("-123456", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_UInt()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            uint value = 123456u;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetUInt32());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("123456", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Long()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            long value = -123456789012345L;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetInt64());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("-123456789012345", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_ULong()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            ulong value = 123456789012345UL;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetUInt64());
            
            string json = doc.RootElement.GetRawText();
            Assert.Equal("123456789012345", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Float()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            float value = 3.14159f;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetSingle());
            
            // Validate the number was written
            string json = doc.RootElement.GetRawText();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.True(float.TryParse(json, out float parsed));
            Assert.Equal(value, parsed);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Double()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            double value = 3.141592653589793;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetDouble(), precision: 10);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Decimal()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            decimal value = 123456.789m;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetDecimal());
            
            string json = doc.RootElement.GetRawText();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.True(decimal.TryParse(json, out decimal parsed));
            Assert.Equal(value, parsed);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_DateTime()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            DateTime value = new DateTime(2023, 7, 15, 10, 30, 45, DateTimeKind.Utc);
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            // Parse and validate the DateTime value - verify it round-trips correctly
            // Note: DateTime.ToString() may convert to local time, so we verify the serialization
            // is valid and contains the expected date components
            DateTime parsed = DateTime.Parse(json, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(2023, parsed.Year);
            Assert.Equal(7, parsed.Month);
            Assert.Equal(15, parsed.Day);
            // Time components: verify hour/minute/second are present (may be in local timezone)
            Assert.True(parsed.Hour >= 0 && parsed.Hour < 24);
            Assert.Equal(30, parsed.Minute);
            Assert.Equal(45, parsed.Second);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_DateTimeOffset()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            DateTimeOffset value = new DateTimeOffset(2023, 7, 15, 10, 30, 45, TimeSpan.FromHours(2));
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            // Parse and validate the full DateTimeOffset value using invariant culture
            DateTimeOffset parsed = DateTimeOffset.Parse(json, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(value.Year, parsed.Year);
            Assert.Equal(value.Month, parsed.Month);
            Assert.Equal(value.Day, parsed.Day);
            Assert.Equal(value.Hour, parsed.Hour);
            Assert.Equal(value.Minute, parsed.Minute);
            Assert.Equal(value.Second, parsed.Second);
            Assert.Equal(value.Offset, parsed.Offset);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Guid()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            Guid value = Guid.Parse("12345678-1234-1234-1234-123456789012");
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            Assert.Equal(value, doc.RootElement.GetGuid());
            
            string json = doc.RootElement.GetString();
            Assert.Equal("12345678-1234-1234-1234-123456789012", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Uri()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            Uri value = new Uri("https://example.com/path?query=value");
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            string result = doc.RootElement.GetString();
            Assert.Equal("https://example.com/path?query=value", result);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_String()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            string value = "Hello, World!";
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            string result = doc.RootElement.GetString();
            Assert.Equal(value, result);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_ReadOnlySpanChar()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            string expectedValue = "Test String";
            ReadOnlySpan<char> value = expectedValue.AsSpan();
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            string result = doc.RootElement.GetString();
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_OffsetDateTime()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            OffsetDateTime value = new OffsetDateTime(
                new LocalDateTime(2023, 7, 15, 10, 30, 45),
                Offset.FromHours(2));
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            // Parse and validate the full OffsetDateTime value
            var pattern = NodaTime.Text.OffsetDateTimePattern.ExtendedIso;
            var parseResult = pattern.Parse(json);
            Assert.True(parseResult.Success, $"Failed to parse: {json}");
            OffsetDateTime parsed = parseResult.Value;
            Assert.Equal(value.Year, parsed.Year);
            Assert.Equal(value.Month, parsed.Month);
            Assert.Equal(value.Day, parsed.Day);
            Assert.Equal(value.Hour, parsed.Hour);
            Assert.Equal(value.Minute, parsed.Minute);
            Assert.Equal(value.Second, parsed.Second);
            Assert.Equal(value.Offset, parsed.Offset);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_OffsetDate()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            OffsetDate value = new OffsetDate(
                new LocalDate(2023, 7, 15),
                Offset.FromHours(2));
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            // Parse and validate the full OffsetDate value
            var pattern = NodaTime.Text.OffsetDatePattern.GeneralIso;
            var parseResult = pattern.Parse(json);
            Assert.True(parseResult.Success, $"Failed to parse: {json}");
            OffsetDate parsed = parseResult.Value;
            Assert.Equal(value.Year, parsed.Year);
            Assert.Equal(value.Month, parsed.Month);
            Assert.Equal(value.Day, parsed.Day);
            Assert.Equal(value.Offset, parsed.Offset);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_OffsetTime()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            OffsetTime value = new OffsetTime(
                new LocalTime(10, 30, 45),
                Offset.FromHours(2));
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            // Parse and validate the full OffsetTime value
            var pattern = NodaTime.Text.OffsetTimePattern.ExtendedIso;
            var parseResult = pattern.Parse(json);
            Assert.True(parseResult.Success, $"Failed to parse: {json}");
            OffsetTime parsed = parseResult.Value;
            Assert.Equal(value.Hour, parsed.Hour);
            Assert.Equal(value.Minute, parsed.Minute);
            Assert.Equal(value.Second, parsed.Second);
            Assert.Equal(value.Offset, parsed.Offset);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_LocalDate()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            LocalDate value = new LocalDate(2023, 7, 15);
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.Equal("2023-07-15", json);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Period()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            Period value = Period.FromYears(1) + Period.FromMonths(2) + Period.FromDays(3);
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.String, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetString();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.Equal("P1Y2M0W3D", json);
        }

#if NET
        [Fact]
        public static void SourceConstructorAndImplicitOperator_Int128()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            Int128 value = new Int128(0, 123456789012345678UL);
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetRawText();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.True(Int128.TryParse(json, out Int128 parsed));
            Assert.Equal(value, parsed);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_UInt128()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            UInt128 value = new UInt128(0, 123456789012345678UL);
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetRawText();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.True(UInt128.TryParse(json, out UInt128 parsed));
            Assert.Equal(value, parsed);
        }

        [Fact]
        public static void SourceConstructorAndImplicitOperator_Half()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            Half value = (Half)3.14;
            
            using var doc = JsonElement.CreateDocumentBuilder(workspace, value);
            Assert.Equal(JsonValueKind.Number, doc.RootElement.ValueKind);
            
            string json = doc.RootElement.GetRawText();
            Assert.False(string.IsNullOrEmpty(json));
            Assert.True(Half.TryParse(json, out Half parsed));
            // Use approximate comparison for floating point
            Assert.True(Math.Abs((double)(value - parsed)) < 0.01);
        }
#endif

        [Fact]
        public static void SourceAddAsProperty_WithUtf8Name_AllTypes()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            
            Guid guidValue = Guid.Parse("12345678-1234-1234-1234-123456789012");
            DateTime dateTimeValue = new DateTime(2023, 7, 15, 10, 30, 45, DateTimeKind.Utc);
            DateTimeOffset dateTimeOffsetValue = new DateTimeOffset(2023, 7, 15, 10, 30, 45, TimeSpan.FromHours(2));
            LocalDate localDateValue = new LocalDate(2023, 7, 15);
            Period periodValue = Period.FromYears(1) + Period.FromMonths(2);
            
            JsonElement.Source source = new JsonElement.Source(new JsonElement.ObjectBuilder.Build((ref JsonElement.ObjectBuilder builder) =>
            {
                builder.Add("byte"u8, (byte)42);
                builder.Add("sbyte"u8, (sbyte)-42);
                builder.Add("short"u8, (short)-1234);
                builder.Add("ushort"u8, (ushort)1234);
                builder.Add("int"u8, -123456);
                builder.Add("uint"u8, 123456u);
                builder.Add("long"u8, -123456789L);
                builder.Add("ulong"u8, 123456789UL);
                builder.Add("float"u8, 3.14f);
                builder.Add("double"u8, 3.14159);
                builder.Add("decimal"u8, 123.456m);
                builder.Add("guid"u8, guidValue);
                builder.Add("datetime"u8, dateTimeValue);
                builder.Add("datetimeoffset"u8, dateTimeOffsetValue);
                builder.Add("localdate"u8, localDateValue);
                builder.Add("offsetdate"u8, new OffsetDate(new LocalDate(2023, 7, 15), Offset.FromHours(2)));
                builder.Add("offsettime"u8, new OffsetTime(new LocalTime(10, 30), Offset.FromHours(2)));
                builder.Add("offsetdatetime"u8, new OffsetDateTime(new LocalDateTime(2023, 7, 15, 10, 30), Offset.FromHours(2)));
                builder.Add("period"u8, periodValue);
            }));

            using var doc = JsonElement.CreateDocumentBuilder(workspace, source);
            
            Assert.Equal(JsonValueKind.Object, doc.RootElement.ValueKind);
            
            // Validate each property exists and has the correct value
            Assert.True(doc.RootElement.TryGetProperty("byte"u8, out var byteProp));
            Assert.Equal(42, byteProp.GetByte());
            
            Assert.True(doc.RootElement.TryGetProperty("sbyte"u8, out var sbyteProp));
            Assert.Equal(-42, sbyteProp.GetSByte());
            
            Assert.True(doc.RootElement.TryGetProperty("short"u8, out var shortProp));
            Assert.Equal(-1234, shortProp.GetInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("int"u8, out var intProp));
            Assert.Equal(-123456, intProp.GetInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("uint"u8, out var uintProp));
            Assert.Equal(123456u, uintProp.GetUInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("long"u8, out var longProp));
            Assert.Equal(-123456789L, longProp.GetInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("ulong"u8, out var ulongProp));
            Assert.Equal(123456789UL, ulongProp.GetUInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("ushort"u8, out var ushortProp));
            Assert.Equal(1234, ushortProp.GetUInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("float"u8, out var floatProp));
            Assert.Equal(3.14f, floatProp.GetSingle());
            
            Assert.True(doc.RootElement.TryGetProperty("double"u8, out var doubleProp));
            Assert.Equal(3.14159, doubleProp.GetDouble(), precision: 10);
            
            Assert.True(doc.RootElement.TryGetProperty("decimal"u8, out var decimalProp));
            Assert.Equal(123.456m, decimalProp.GetDecimal());
            
            Assert.True(doc.RootElement.TryGetProperty("guid"u8, out var guidProp));
            Assert.Equal(guidValue, guidProp.GetGuid());
            
            Assert.True(doc.RootElement.TryGetProperty("datetime"u8, out var dateTimeProp));
            string dateTimeStr = dateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeStr));
            DateTime parsedDateTime = DateTime.Parse(dateTimeStr, System.Globalization.CultureInfo.InvariantCulture);
            // DateTime serialization may use local timezone - verify date and time components
            Assert.Equal(2023, parsedDateTime.Year);
            Assert.Equal(7, parsedDateTime.Month);
            Assert.Equal(15, parsedDateTime.Day);
            Assert.True(parsedDateTime.Hour >= 0 && parsedDateTime.Hour < 24);
            Assert.Equal(30, parsedDateTime.Minute);
            Assert.Equal(45, parsedDateTime.Second);
            
            Assert.True(doc.RootElement.TryGetProperty("datetimeoffset"u8, out var dateTimeOffsetProp));
            string dateTimeOffsetStr = dateTimeOffsetProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeOffsetStr));
            DateTimeOffset parsedDateTimeOffset = DateTimeOffset.Parse(dateTimeOffsetStr, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(dateTimeOffsetValue.Year, parsedDateTimeOffset.Year);
            Assert.Equal(dateTimeOffsetValue.Month, parsedDateTimeOffset.Month);
            Assert.Equal(dateTimeOffsetValue.Day, parsedDateTimeOffset.Day);
            Assert.Equal(dateTimeOffsetValue.Hour, parsedDateTimeOffset.Hour);
            Assert.Equal(dateTimeOffsetValue.Minute, parsedDateTimeOffset.Minute);
            Assert.Equal(dateTimeOffsetValue.Second, parsedDateTimeOffset.Second);
            Assert.Equal(dateTimeOffsetValue.Offset, parsedDateTimeOffset.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("localdate"u8, out var localDateProp));
            Assert.Equal("2023-07-15", localDateProp.GetString());
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdate"u8, out var offsetDateProp));
            string offsetDateStr = offsetDateProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateStr));
            var offsetDatePattern = NodaTime.Text.OffsetDatePattern.GeneralIso;
            var offsetDateResult = offsetDatePattern.Parse(offsetDateStr);
            Assert.True(offsetDateResult.Success, $"Failed to parse OffsetDate: {offsetDateStr}");
            OffsetDate parsedOffsetDate = offsetDateResult.Value;
            Assert.Equal(2023, parsedOffsetDate.Year);
            Assert.Equal(7, parsedOffsetDate.Month);
            Assert.Equal(15, parsedOffsetDate.Day);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDate.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsettime"u8, out var offsetTimeProp));
            string offsetTimeStr = offsetTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetTimeStr));
            var offsetTimePattern = NodaTime.Text.OffsetTimePattern.ExtendedIso;
            var offsetTimeResult = offsetTimePattern.Parse(offsetTimeStr);
            Assert.True(offsetTimeResult.Success, $"Failed to parse OffsetTime: {offsetTimeStr}");
            OffsetTime parsedOffsetTime = offsetTimeResult.Value;
            Assert.Equal(10, parsedOffsetTime.Hour);
            Assert.Equal(30, parsedOffsetTime.Minute);
            Assert.Equal(0, parsedOffsetTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdatetime"u8, out var offsetDateTimeProp));
            string offsetDateTimeStr = offsetDateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateTimeStr));
            var offsetDateTimePattern = NodaTime.Text.OffsetDateTimePattern.ExtendedIso;
            var offsetDateTimeResult = offsetDateTimePattern.Parse(offsetDateTimeStr);
            Assert.True(offsetDateTimeResult.Success, $"Failed to parse OffsetDateTime: {offsetDateTimeStr}");
            OffsetDateTime parsedOffsetDateTime = offsetDateTimeResult.Value;
            Assert.Equal(2023, parsedOffsetDateTime.Year);
            Assert.Equal(7, parsedOffsetDateTime.Month);
            Assert.Equal(15, parsedOffsetDateTime.Day);
            Assert.Equal(10, parsedOffsetDateTime.Hour);
            Assert.Equal(30, parsedOffsetDateTime.Minute);
            Assert.Equal(0, parsedOffsetDateTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDateTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("period"u8, out var periodProp));
            Assert.Equal("P1Y2M0W0D", periodProp.GetString());
        }

        [Fact]
        public static void SourceAddAsProperty_WithStringName_AllTypes()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            
            Guid guidValue = Guid.Parse("abcdef12-3456-7890-abcd-ef1234567890");
            DateTime dateTimeValue = new DateTime(2023, 7, 15, 10, 30, 45, DateTimeKind.Utc);
            DateTimeOffset dateTimeOffsetValue = new DateTimeOffset(2023, 7, 15, 10, 30, 45, TimeSpan.FromHours(2));
            LocalDate localDateValue = new LocalDate(2023, 7, 15);
            Period periodValue = Period.FromYears(1) + Period.FromMonths(2);
            
            JsonElement.Source source = new JsonElement.Source(new JsonElement.ObjectBuilder.Build((ref JsonElement.ObjectBuilder builder) =>
            {
                builder.Add("byte", (byte)42);
                builder.Add("sbyte", (sbyte)-42);
                builder.Add("short", (short)-1234);
                builder.Add("ushort", (ushort)1234);
                builder.Add("int", -123456);
                builder.Add("uint", 123456u);
                builder.Add("long", -123456789L);
                builder.Add("ulong", 123456789UL);
                builder.Add("float", 3.14f);
                builder.Add("double", 3.14159);
                builder.Add("decimal", 123.456m);
                builder.Add("guid", guidValue);
                builder.Add("datetime", dateTimeValue);
                builder.Add("datetimeoffset", dateTimeOffsetValue);
                builder.Add("localdate", localDateValue);
                builder.Add("offsetdate", new OffsetDate(new LocalDate(2023, 7, 15), Offset.FromHours(2)));
                builder.Add("offsettime", new OffsetTime(new LocalTime(10, 30), Offset.FromHours(2)));
                builder.Add("offsetdatetime", new OffsetDateTime(new LocalDateTime(2023, 7, 15, 10, 30), Offset.FromHours(2)));
                builder.Add("period", periodValue);
            }));

            using var doc = JsonElement.CreateDocumentBuilder(workspace, source);
            
            Assert.Equal(JsonValueKind.Object, doc.RootElement.ValueKind);
            
            // Validate all properties with correct values
            Assert.True(doc.RootElement.TryGetProperty("byte", out var byteProp));
            Assert.Equal(42, byteProp.GetByte());
            
            Assert.True(doc.RootElement.TryGetProperty("sbyte", out var sbyteProp));
            Assert.Equal(-42, sbyteProp.GetSByte());
            
            Assert.True(doc.RootElement.TryGetProperty("int", out var intProp));
            Assert.Equal(-123456, intProp.GetInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("uint", out var uintProp));
            Assert.Equal(123456u, uintProp.GetUInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("decimal", out var decimalProp));
            Assert.Equal(123.456m, decimalProp.GetDecimal());
            
            Assert.True(doc.RootElement.TryGetProperty("long", out var longProp));
            Assert.Equal(-123456789L, longProp.GetInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("ulong", out var ulongProp));
            Assert.Equal(123456789UL, ulongProp.GetUInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("short", out var shortProp));
            Assert.Equal(-1234, shortProp.GetInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("ushort", out var ushortProp));
            Assert.Equal(1234, ushortProp.GetUInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("float", out var floatProp));
            Assert.Equal(3.14f, floatProp.GetSingle());
            
            Assert.True(doc.RootElement.TryGetProperty("double", out var doubleProp));
            Assert.Equal(3.14159, doubleProp.GetDouble(), precision: 10);
            
            Assert.True(doc.RootElement.TryGetProperty("guid", out var guidProp));
            Assert.Equal(guidValue, guidProp.GetGuid());
            
            Assert.True(doc.RootElement.TryGetProperty("datetime", out var dateTimeProp));
            string dateTimeStr = dateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeStr));
            DateTime parsedDateTime = DateTime.Parse(dateTimeStr, System.Globalization.CultureInfo.InvariantCulture);
            // DateTime serialization may use local timezone - verify date and time components
            Assert.Equal(2023, parsedDateTime.Year);
            Assert.Equal(7, parsedDateTime.Month);
            Assert.Equal(15, parsedDateTime.Day);
            Assert.True(parsedDateTime.Hour >= 0 && parsedDateTime.Hour < 24);
            Assert.Equal(30, parsedDateTime.Minute);
            Assert.Equal(45, parsedDateTime.Second);
            
            Assert.True(doc.RootElement.TryGetProperty("datetimeoffset", out var dateTimeOffsetProp));
            string dateTimeOffsetStr = dateTimeOffsetProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeOffsetStr));
            DateTimeOffset parsedDateTimeOffset = DateTimeOffset.Parse(dateTimeOffsetStr, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(dateTimeOffsetValue.Year, parsedDateTimeOffset.Year);
            Assert.Equal(dateTimeOffsetValue.Month, parsedDateTimeOffset.Month);
            Assert.Equal(dateTimeOffsetValue.Day, parsedDateTimeOffset.Day);
            Assert.Equal(dateTimeOffsetValue.Hour, parsedDateTimeOffset.Hour);
            Assert.Equal(dateTimeOffsetValue.Minute, parsedDateTimeOffset.Minute);
            Assert.Equal(dateTimeOffsetValue.Second, parsedDateTimeOffset.Second);
            Assert.Equal(dateTimeOffsetValue.Offset, parsedDateTimeOffset.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("localdate", out var localDateProp));
            Assert.Equal("2023-07-15", localDateProp.GetString());
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdate", out var offsetDateProp));
            string offsetDateStr = offsetDateProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateStr));
            var offsetDatePattern = NodaTime.Text.OffsetDatePattern.GeneralIso;
            var offsetDateResult = offsetDatePattern.Parse(offsetDateStr);
            Assert.True(offsetDateResult.Success, $"Failed to parse OffsetDate: {offsetDateStr}");
            OffsetDate parsedOffsetDate = offsetDateResult.Value;
            Assert.Equal(2023, parsedOffsetDate.Year);
            Assert.Equal(7, parsedOffsetDate.Month);
            Assert.Equal(15, parsedOffsetDate.Day);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDate.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsettime", out var offsetTimeProp));
            string offsetTimeStr = offsetTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetTimeStr));
            var offsetTimePattern = NodaTime.Text.OffsetTimePattern.ExtendedIso;
            var offsetTimeResult = offsetTimePattern.Parse(offsetTimeStr);
            Assert.True(offsetTimeResult.Success, $"Failed to parse OffsetTime: {offsetTimeStr}");
            OffsetTime parsedOffsetTime = offsetTimeResult.Value;
            Assert.Equal(10, parsedOffsetTime.Hour);
            Assert.Equal(30, parsedOffsetTime.Minute);
            Assert.Equal(0, parsedOffsetTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdatetime", out var offsetDateTimeProp));
            string offsetDateTimeStr = offsetDateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateTimeStr));
            var offsetDateTimePattern = NodaTime.Text.OffsetDateTimePattern.ExtendedIso;
            var offsetDateTimeResult = offsetDateTimePattern.Parse(offsetDateTimeStr);
            Assert.True(offsetDateTimeResult.Success, $"Failed to parse OffsetDateTime: {offsetDateTimeStr}");
            OffsetDateTime parsedOffsetDateTime = offsetDateTimeResult.Value;
            Assert.Equal(2023, parsedOffsetDateTime.Year);
            Assert.Equal(7, parsedOffsetDateTime.Month);
            Assert.Equal(15, parsedOffsetDateTime.Day);
            Assert.Equal(10, parsedOffsetDateTime.Hour);
            Assert.Equal(30, parsedOffsetDateTime.Minute);
            Assert.Equal(0, parsedOffsetDateTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDateTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("period", out var periodProp));
            Assert.Equal("P1Y2M0W0D", periodProp.GetString());
        }

        [Fact]
        public static void SourceAddAsProperty_WithReadOnlySpanChar_AllTypes()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();
            
            Guid guidValue = Guid.Parse("abcdef12-3456-7890-abcd-ef1234567890");
            DateTime dateTimeValue = new DateTime(2023, 7, 15, 10, 30, 45, DateTimeKind.Utc);
            DateTimeOffset dateTimeOffsetValue = new DateTimeOffset(2023, 7, 15, 10, 30, 45, TimeSpan.FromHours(2));
            LocalDate localDateValue = new LocalDate(2023, 7, 15);
            Period periodValue = Period.FromYears(1) + Period.FromMonths(2);
            
            JsonElement.Source source = new JsonElement.Source(new JsonElement.ObjectBuilder.Build((ref JsonElement.ObjectBuilder builder) =>
            {
                builder.Add("byte".AsSpan(), (byte)42);
                builder.Add("sbyte".AsSpan(), (sbyte)-42);
                builder.Add("short".AsSpan(), (short)-1234);
                builder.Add("ushort".AsSpan(), (ushort)1234);
                builder.Add("int".AsSpan(), -123456);
                builder.Add("uint".AsSpan(), 123456u);
                builder.Add("long".AsSpan(), -123456789L);
                builder.Add("ulong".AsSpan(), 123456789UL);
                builder.Add("float".AsSpan(), 3.14f);
                builder.Add("double".AsSpan(), 3.14159);
                builder.Add("decimal".AsSpan(), 123.456m);
                builder.Add("guid".AsSpan(), guidValue);
                builder.Add("datetime".AsSpan(), dateTimeValue);
                builder.Add("datetimeoffset".AsSpan(), dateTimeOffsetValue);
                builder.Add("localdate".AsSpan(), localDateValue);
                builder.Add("offsetdate".AsSpan(), new OffsetDate(new LocalDate(2023, 7, 15), Offset.FromHours(2)));
                builder.Add("offsettime".AsSpan(), new OffsetTime(new LocalTime(10, 30), Offset.FromHours(2)));
                builder.Add("offsetdatetime".AsSpan(), new OffsetDateTime(new LocalDateTime(2023, 7, 15, 10, 30), Offset.FromHours(2)));
                builder.Add("period".AsSpan(), periodValue);
            }));

            using var doc = JsonElement.CreateDocumentBuilder(workspace, source);
            
            Assert.Equal(JsonValueKind.Object, doc.RootElement.ValueKind);
            
            // Validate all properties with correct values
            Assert.True(doc.RootElement.TryGetProperty("byte", out var byteProp));
            Assert.Equal(42, byteProp.GetByte());
            
            Assert.True(doc.RootElement.TryGetProperty("sbyte", out var sbyteProp));
            Assert.Equal(-42, sbyteProp.GetSByte());
            
            Assert.True(doc.RootElement.TryGetProperty("int", out var intProp));
            Assert.Equal(-123456, intProp.GetInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("uint", out var uintProp));
            Assert.Equal(123456u, uintProp.GetUInt32());
            
            Assert.True(doc.RootElement.TryGetProperty("decimal", out var decimalProp));
            Assert.Equal(123.456m, decimalProp.GetDecimal());
            
            Assert.True(doc.RootElement.TryGetProperty("long", out var longProp));
            Assert.Equal(-123456789L, longProp.GetInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("ulong", out var ulongProp));
            Assert.Equal(123456789UL, ulongProp.GetUInt64());
            
            Assert.True(doc.RootElement.TryGetProperty("short", out var shortProp));
            Assert.Equal(-1234, shortProp.GetInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("ushort", out var ushortProp));
            Assert.Equal(1234, ushortProp.GetUInt16());
            
            Assert.True(doc.RootElement.TryGetProperty("float", out var floatProp));
            Assert.Equal(3.14f, floatProp.GetSingle());
            
            Assert.True(doc.RootElement.TryGetProperty("double", out var doubleProp));
            Assert.Equal(3.14159, doubleProp.GetDouble(), precision: 10);
            
            Assert.True(doc.RootElement.TryGetProperty("guid", out var guidProp));
            Assert.Equal(guidValue, guidProp.GetGuid());
            
            Assert.True(doc.RootElement.TryGetProperty("datetime", out var dateTimeProp));
            string dateTimeStr = dateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeStr));
            DateTime parsedDateTime = DateTime.Parse(dateTimeStr, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(2023, parsedDateTime.Year);
            Assert.Equal(7, parsedDateTime.Month);
            Assert.Equal(15, parsedDateTime.Day);
            Assert.True(parsedDateTime.Hour >= 0 && parsedDateTime.Hour < 24);
            Assert.Equal(30, parsedDateTime.Minute);
            Assert.Equal(45, parsedDateTime.Second);
            
            Assert.True(doc.RootElement.TryGetProperty("datetimeoffset", out var dateTimeOffsetProp));
            string dateTimeOffsetStr = dateTimeOffsetProp.GetString();
            Assert.False(string.IsNullOrEmpty(dateTimeOffsetStr));
            DateTimeOffset parsedDateTimeOffset = DateTimeOffset.Parse(dateTimeOffsetStr, System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(dateTimeOffsetValue.Year, parsedDateTimeOffset.Year);
            Assert.Equal(dateTimeOffsetValue.Month, parsedDateTimeOffset.Month);
            Assert.Equal(dateTimeOffsetValue.Day, parsedDateTimeOffset.Day);
            Assert.Equal(dateTimeOffsetValue.Hour, parsedDateTimeOffset.Hour);
            Assert.Equal(dateTimeOffsetValue.Minute, parsedDateTimeOffset.Minute);
            Assert.Equal(dateTimeOffsetValue.Second, parsedDateTimeOffset.Second);
            Assert.Equal(dateTimeOffsetValue.Offset, parsedDateTimeOffset.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("localdate", out var localDateProp));
            Assert.Equal("2023-07-15", localDateProp.GetString());
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdate", out var offsetDateProp));
            string offsetDateStr = offsetDateProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateStr));
            var offsetDatePattern = NodaTime.Text.OffsetDatePattern.GeneralIso;
            var offsetDateResult = offsetDatePattern.Parse(offsetDateStr);
            Assert.True(offsetDateResult.Success, $"Failed to parse OffsetDate: {offsetDateStr}");
            OffsetDate parsedOffsetDate = offsetDateResult.Value;
            Assert.Equal(2023, parsedOffsetDate.Year);
            Assert.Equal(7, parsedOffsetDate.Month);
            Assert.Equal(15, parsedOffsetDate.Day);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDate.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsettime", out var offsetTimeProp));
            string offsetTimeStr = offsetTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetTimeStr));
            var offsetTimePattern = NodaTime.Text.OffsetTimePattern.ExtendedIso;
            var offsetTimeResult = offsetTimePattern.Parse(offsetTimeStr);
            Assert.True(offsetTimeResult.Success, $"Failed to parse OffsetTime: {offsetTimeStr}");
            OffsetTime parsedOffsetTime = offsetTimeResult.Value;
            Assert.Equal(10, parsedOffsetTime.Hour);
            Assert.Equal(30, parsedOffsetTime.Minute);
            Assert.Equal(0, parsedOffsetTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("offsetdatetime", out var offsetDateTimeProp));
            string offsetDateTimeStr = offsetDateTimeProp.GetString();
            Assert.False(string.IsNullOrEmpty(offsetDateTimeStr));
            var offsetDateTimePattern = NodaTime.Text.OffsetDateTimePattern.ExtendedIso;
            var offsetDateTimeResult = offsetDateTimePattern.Parse(offsetDateTimeStr);
            Assert.True(offsetDateTimeResult.Success, $"Failed to parse OffsetDateTime: {offsetDateTimeStr}");
            OffsetDateTime parsedOffsetDateTime = offsetDateTimeResult.Value;
            Assert.Equal(2023, parsedOffsetDateTime.Year);
            Assert.Equal(7, parsedOffsetDateTime.Month);
            Assert.Equal(15, parsedOffsetDateTime.Day);
            Assert.Equal(10, parsedOffsetDateTime.Hour);
            Assert.Equal(30, parsedOffsetDateTime.Minute);
            Assert.Equal(0, parsedOffsetDateTime.Second);
            Assert.Equal(Offset.FromHours(2), parsedOffsetDateTime.Offset);
            
            Assert.True(doc.RootElement.TryGetProperty("period", out var periodProp));
            Assert.Equal("P1Y2M0W0D", periodProp.GetString());
        }
    }
}
