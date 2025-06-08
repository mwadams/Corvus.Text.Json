// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.Tests;

public class JsonSchemaMatchingStringTests
{
    private JsonSchemaContext CreateContext(DummyResultsCollector collector, JsonTokenType tokenType)
    {
        return JsonSchemaContext.BeginContext(new DummyDocument(tokenType), 0, false, false, collector);
    }

    [Theory]
    [InlineData(JsonTokenType.String, true)]
    [InlineData(JsonTokenType.Number, false)]
    public void MatchTypeString_ValidatesTokenType(JsonTokenType tokenType, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchTypeString(tokenType, DummyPathProvider, ref context);
        Assert.Equal(expected, result);        
        collector.AssertState();
        context.Dispose();
    }

    private bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

    [Theory]
    [InlineData("2023-06-01", true)]
    [InlineData("not-a-date", false)]
    public void MatchDate_ValidatesDate(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDate(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("2023-06-01T12:34:56+00:00", true)]
    [InlineData("not-a-datetime", false)]
    public void MatchDateTime_ValidatesDateTime(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDateTime(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("12:34:56+00:00", true)]
    [InlineData("not-a-time", false)]
    public void MatchTime_ValidatesTime(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchTime(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("P1D", true)] // ISO 8601 duration
    [InlineData("not-a-duration", false)]
    public void MatchDuration_ValidatesDuration(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDuration(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("user@example.com", true)]
    [InlineData("invalid-email", false)]
    public void MatchEmail_ValidatesEmail(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchEmail(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("用户@例子.广告", true)]
    [InlineData("ಬೆಂಬಲ@ಡೇಟಾಮೇಲ್.ಭಾರತ", true)]
    [InlineData("अजय@डाटा.भारत", true)]
    [InlineData("квіточка@пошта.укр", true)]
    [InlineData("χρήστης@παράδειγμα.ελ", true)]
    [InlineData("Dörte@Sörensen.example.com", true)]
    [InlineData("مثال@موقع.عر", true)]
    public void MatchIdnEmail_ValidatesIdnEmail(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchIdnEmail(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("example.com", true)]
    [InlineData("sub.domain.example.com", true)]
    [InlineData("xn--4gbwdl.xn--wgbh1c", true)] // Punycode
    [InlineData("-a-host-name-that-starts-with--", false)] 
    [InlineData("not_a_valid_host_name", false)] 
    [InlineData("a-vvvvvvvvvvvvvvvveeeeeeeeeeeeeeeerrrrrrrrrrrrrrrryyyyyyyyyyyyyyyy-long-host-name-component", false)]
    [InlineData("-hostname", false)]
    [InlineData("hostname-", false)]
    [InlineData("_hostname", false)]
    [InlineData("hostname_", false)]
    [InlineData("host_name", false)]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com", true)]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijkl.com", false)]
    [InlineData("hostname", true)]
    [InlineData("host-name", true)]
    [InlineData("h0stn4me", true)]
    [InlineData("1host", true)]
    [InlineData("hostnam3", true)]
    public void MatchHostname_ValidatesHostname(string value, bool expected)
    {
        bool result = JsonSchemaMatching.MatchHostname(Encoding.UTF8.GetBytes(value));
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("실례.테스트", true)]
    [InlineData("〮실례.테스트", false)]
    [InlineData("실〮례.테스트", false)]
    [InlineData("실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실실례례테스트례례례례례례례례례례례례례례례례례테스트례례례례례례례례례례례례례례례례례례례테스트례례례례례례례례례례례례테스트례례실례.테스트", false)]
    [InlineData("-> $1.00 <--", false)]
    [InlineData("xn--ihqwcrb4cv8a8dqg056pqjye", true)]
    [InlineData("xn--X", false)]
    [InlineData("XN--aa---o47jg78q", false)]
    [InlineData("-hello", false)]
    [InlineData("hello-", false)]
    [InlineData("-hello-", false)]
    [InlineData("\u0903hello", false)]
    [InlineData("\u0300hello", false)]
    [InlineData("\u0488hello", false)]
    [InlineData("\u00df\u03c2\u0f0b\u3007", true)]
    [InlineData("\u06fd\u06fe", true)]
    [InlineData("\u0640\u07fa", false)]
    [InlineData("\u3031\u3032\u3033\u3034\u3035\u302e\u302f\u303b", false)]
    [InlineData("a\u00b7l", false)]
    [InlineData("\u00b7l", false)]
    [InlineData("l\u00b7a", false)]
    [InlineData("l\u00b7", false)]
    [InlineData("l\u00b7l", true)]
    [InlineData("\u03b1\u0375S", false)]
    [InlineData("\u03b1\u0375", false)]
    [InlineData("\u03b1\u0375\u03b2", true)]
    [InlineData("A\u05f3\u05d1", false)]
    [InlineData("\u05f3\u05d1", false)]
    [InlineData("\u05d0\u05f3\u05d1", true)]
    [InlineData("A\u05f4\u05d1", false)]
    [InlineData("\u05f4\u05d1", false)]
    [InlineData("\u05d0\u05f4\u05d1", true)]
    [InlineData("def\u30fbabc", false)]
    [InlineData("\u30fb", false)]
    [InlineData("\u30fb\u3041", true)]
    [InlineData("\u30fb\u30a1", true)]
    [InlineData("\u30fb\u4e08", true)]
    [InlineData("\u0628\u0660\u06f0", false)]
    [InlineData("\u0628\u0660\u0628", true)]
    [InlineData("\u06f00", true)]
    [InlineData("\u0915\u200d\u0937", false)]
    [InlineData("\u200d\u0937", false)]
    [InlineData("\u0915\u094d\u200d\u0937", true)]
    [InlineData("\u0915\u094d\u200c\u0937", true)]
    [InlineData("\u0628\u064a\u200c\u0628\u064a", true)]
    [InlineData("hostname", true)]
    [InlineData("host-name", true)]
    [InlineData("h0stn4me", true)]
    [InlineData("1host", true)]
    [InlineData("hostnam3", true)]
    public void MatchIdnHostname_ValidatesIdnHostname(string value, bool expected)
    {
        bool result = JsonSchemaMatching.MatchIdnHostname(Encoding.UTF8.GetBytes(value));
        Assert.Equal(expected, result);
    }
}
