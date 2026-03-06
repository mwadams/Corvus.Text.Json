// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using Corvus.Text.Json.Internal;
using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for format-aware ToString() and TryFormat() overloads on generated types
    /// with string format constraints (date, date-time, time, uuid).
    /// Verifies that:
    ///   - a non-null/non-empty format delegates to the typed value (NodaTime / BCL);
    ///   - a null/empty format falls through to the canonical raw-JSON string value.
    /// </summary>
    public class FormatAwareStringFormatTests
    {
        // ====================================================================
        // date — NodaTime.LocalDate for ToString, DateOnly for TryFormat
        // ====================================================================

        [Fact]
        public void DateEntity_ToString_WithNodaTimeFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            // NodaTime LocalDate pattern: literal slashes distinguish from canonical hyphens
            string result = entity.ToString("uuuu'/'MM'/'dd", CultureInfo.InvariantCulture);
            Assert.Equal("2024/03/15", result);
        }

        [Fact]
        public void DateEntity_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            string result = entity.ToString(null, CultureInfo.InvariantCulture);
            Assert.Equal("2024-03-15", result);
        }

        [Fact]
        public void DateEntity_ToString_WithEmptyFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            string result = entity.ToString(string.Empty, CultureInfo.InvariantCulture);
            Assert.Equal("2024-03-15", result);
        }

        [Fact]
        public void DateEntity_Mutable_ToString_WithNodaTimeFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString("uuuu'/'MM'/'dd", CultureInfo.InvariantCulture);
            Assert.Equal("2024/03/15", result);
        }

        [Fact]
        public void DateEntity_Mutable_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString(null, CultureInfo.InvariantCulture);
            Assert.Equal("2024-03-15", result);
        }

#if NET
        [Fact]
        public void DateEntity_TryFormatChar_WithBclFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            // DateOnly "d" with InvariantCulture → MM/dd/yyyy
            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateEntity_TryFormatChar_WithEmptyFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, string.Empty, CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("2024-03-15", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateEntity_TryFormatByte_WithBclFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            var entity = doc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }

        [Fact]
        public void DateEntity_Mutable_TryFormatChar_WithBclFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateEntity_Mutable_TryFormatByte_WithBclFormat_ReturnsFormattedDate()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateEntity>.Parse("\"2024-03-15\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }
#endif

        // ====================================================================
        // date-time — NodaTime.OffsetDateTime for ToString, DateTimeOffset for TryFormat
        // ====================================================================

        [Fact]
        public void DateTimeEntity_ToString_WithNodaTimeFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            var entity = doc.RootElement;

            // NodaTime OffsetDateTime pattern with literal slashes and no offset
            string result = entity.ToString("uuuu'/'MM'/'dd HH:mm:ss", CultureInfo.InvariantCulture);
            Assert.Equal("2024/03/15 10:20:30", result);
        }

        [Fact]
        public void DateTimeEntity_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            var entity = doc.RootElement;

            string result = entity.ToString(null, CultureInfo.InvariantCulture);
            Assert.Equal("2024-03-15T10:20:30Z", result);
        }

        [Fact]
        public void DateTimeEntity_Mutable_ToString_WithNodaTimeFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString("uuuu'/'MM'/'dd HH:mm:ss", CultureInfo.InvariantCulture);
            Assert.Equal("2024/03/15 10:20:30", result);
        }

#if NET
        [Fact]
        public void DateTimeEntity_TryFormatChar_WithBclFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            var entity = doc.RootElement;

            // DateTimeOffset "d" with InvariantCulture → short date MM/dd/yyyy
            Span<char> dest = stackalloc char[100];
            bool success = entity.TryFormat(dest, out int charsWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateTimeEntity_TryFormatChar_WithEmptyFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            var entity = doc.RootElement;

            Span<char> dest = stackalloc char[100];
            bool success = entity.TryFormat(dest, out int charsWritten, string.Empty, CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("2024-03-15T10:20:30Z", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateTimeEntity_TryFormatByte_WithBclFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            var entity = doc.RootElement;

            Span<byte> dest = stackalloc byte[100];
            bool success = entity.TryFormat(dest, out int bytesWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }

        [Fact]
        public void DateTimeEntity_Mutable_TryFormatChar_WithBclFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<char> dest = stackalloc char[100];
            bool success = entity.TryFormat(dest, out int charsWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void DateTimeEntity_Mutable_TryFormatByte_WithBclFormat_ReturnsFormattedDateTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DateTimeEntity>.Parse("\"2024-03-15T10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<byte> dest = stackalloc byte[100];
            bool success = entity.TryFormat(dest, out int bytesWritten, "d", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("03/15/2024", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }
#endif

        // ====================================================================
        // time — NodaTime.OffsetTime for ToString, TimeOnly for TryFormat
        // ====================================================================

        [Fact]
        public void TimeEntity_ToString_WithNodaTimeFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            var entity = doc.RootElement;

            // NodaTime OffsetTime pattern with literal dots distinguishes from canonical colons
            string result = entity.ToString("HH'.'mm'.'ss", CultureInfo.InvariantCulture);
            Assert.Equal("10.20.30", result);
        }

        [Fact]
        public void TimeEntity_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            var entity = doc.RootElement;

            string result = entity.ToString(null, CultureInfo.InvariantCulture);
            Assert.Equal("10:20:30Z", result);
        }

        [Fact]
        public void TimeEntity_Mutable_ToString_WithNodaTimeFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString("HH'.'mm'.'ss", CultureInfo.InvariantCulture);
            Assert.Equal("10.20.30", result);
        }

#if NET
        [Fact]
        public void TimeEntity_TryFormatChar_WithBclFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            var entity = doc.RootElement;

            // TimeOnly "HH:mm" → drops seconds and offset that appear in canonical "10:20:30Z"
            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "HH:mm", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("10:20", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void TimeEntity_TryFormatChar_WithEmptyFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            var entity = doc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, string.Empty, CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("10:20:30Z", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void TimeEntity_TryFormatByte_WithBclFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            var entity = doc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "HH:mm", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("10:20", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }

        [Fact]
        public void TimeEntity_Mutable_TryFormatChar_WithBclFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "HH:mm", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("10:20", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void TimeEntity_Mutable_TryFormatByte_WithBclFormat_ReturnsFormattedTime()
        {
            using var doc = ParsedJsonDocument<FormatTypes.TimeEntity>.Parse("\"10:20:30Z\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "HH:mm", CultureInfo.InvariantCulture);
            Assert.True(success);
            Assert.Equal("10:20", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }
#endif

        // ====================================================================
        // uuid — Guid for all overloads (works on all framework targets)
        // ====================================================================

        [Fact]
        public void UuidEntity_ToString_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            var entity = doc.RootElement;

            // "N" format → 32 hex digits with no hyphens
            string result = entity.ToString("N", null);
            Assert.Equal("12345678123456781234567812345678", result);
        }

        [Fact]
        public void UuidEntity_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            var entity = doc.RootElement;

            string result = entity.ToString(null, null);
            Assert.Equal("12345678-1234-5678-1234-567812345678", result);
        }

        [Fact]
        public void UuidEntity_Mutable_ToString_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString("N", null);
            Assert.Equal("12345678123456781234567812345678", result);
        }

        [Fact]
        public void UuidEntity_Mutable_ToString_WithNullFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString(null, null);
            Assert.Equal("12345678-1234-5678-1234-567812345678", result);
        }

#if NET
        [Fact]
        public void UuidEntity_TryFormatChar_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            var entity = doc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "N", null);
            Assert.True(success);
            Assert.Equal("12345678123456781234567812345678", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void UuidEntity_TryFormatChar_WithEmptyFormat_ReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            var entity = doc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, string.Empty, null);
            Assert.True(success);
            Assert.Equal("12345678-1234-5678-1234-567812345678", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void UuidEntity_TryFormatByte_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            var entity = doc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "N", null);
            Assert.True(success);
            Assert.Equal("12345678123456781234567812345678", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }

        [Fact]
        public void UuidEntity_Mutable_TryFormatChar_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<char> dest = stackalloc char[50];
            bool success = entity.TryFormat(dest, out int charsWritten, "N", null);
            Assert.True(success);
            Assert.Equal("12345678123456781234567812345678", dest.Slice(0, charsWritten).ToString());
        }

        [Fact]
        public void UuidEntity_Mutable_TryFormatByte_WithGuidFormat_ReturnsNoHyphens()
        {
            using var doc = ParsedJsonDocument<FormatTypes.UuidEntity>.Parse("\"12345678-1234-5678-1234-567812345678\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            Span<byte> dest = stackalloc byte[50];
            bool success = entity.TryFormat(dest, out int bytesWritten, "N", null);
            Assert.True(success);
            Assert.Equal("12345678123456781234567812345678", JsonReaderHelper.TranscodeHelper(dest.Slice(0, bytesWritten)));
        }
#endif

        // ====================================================================
        // duration — no format handler; all overloads always fall through to canonical
        // ====================================================================

        [Fact]
        public void DurationEntity_ToString_WithAnyFormat_AlwaysReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DurationEntity>.Parse("\"P1Y2M3DT4H5M6S\"");
            var entity = doc.RootElement;

            // Duration handler returns false; the non-null format still produces the raw value
            string result = entity.ToString("G", CultureInfo.InvariantCulture);
            Assert.Equal("P1Y2M3DT4H5M6S", result);
        }

        [Fact]
        public void DurationEntity_Mutable_ToString_WithAnyFormat_AlwaysReturnsCanonical()
        {
            using var doc = ParsedJsonDocument<FormatTypes.DurationEntity>.Parse("\"P1Y2M3DT4H5M6S\"");
            using var workspace = JsonWorkspace.Create();
            using var mutableDoc = doc.RootElement.BuildDocument(workspace);
            var entity = mutableDoc.RootElement;

            string result = entity.ToString("G", CultureInfo.InvariantCulture);
            Assert.Equal("P1Y2M3DT4H5M6S", result);
        }
    }
}
