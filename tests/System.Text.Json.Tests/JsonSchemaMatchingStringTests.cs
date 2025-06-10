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
    [InlineData("(allows leading comment)user@example.com", true)]
    [InlineData("user(allows trailing comment)@example.com", true)]
    [InlineData("(allows leading comment)user(and allows trailing comment)@example.com", true)]
    [InlineData("(user@example.com", false)]
    [InlineData("user(akdjsd@example.com", false)]
    [InlineData("u:ser@example.com", false)]
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
    [InlineData("jo@\u0640\u07fa", false)]
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
    [InlineData("xn--X", false)] // invalid punycode
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
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchHostname(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
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
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchIdnHostname(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("::1", true)]
    [InlineData("12345::", false)]
    [InlineData("::abef", true)]
    [InlineData(":abcef", false)]
    [InlineData("1:1:1:1:1:1:1:1:1:1:1:1:1:1:1:1", false)]
    [InlineData(":laptop", false)]
    [InlineData("::", true)]
    [InlineData("::42:ff:1", true)]
    [InlineData("d6::", true)]
    [InlineData(":2:3:4:5:6:7:8", false)]
    [InlineData("1:2:3:4:5:6:7:", false)]
    [InlineData(":2:3:4::8", false)]
    [InlineData("1:d6::42", true)]
    [InlineData("1::d6::42", false)]
    [InlineData("1::d6:192.168.0.1", true)]
    [InlineData("1:2::192.168.0.1", true)]
    [InlineData("1::2:192.168.256.1", false)]
    [InlineData("1::2:192.168.ff.1", false)]
    [InlineData("::ffff:192.168.0.1", true)]
    [InlineData("1:2:3:4:5:::8", false)]
    [InlineData("1:2:3:4:5:6:7:8", true)]
    [InlineData("1:2:3:4:5:6:7", false)]
    [InlineData("1", false)]
    [InlineData("127.0.0.1", false)]
    [InlineData("1:2:3:4:1.2.3", false)]
    [InlineData("  ::1", false)]
    [InlineData("::1  ", false)]
    [InlineData("fe80::/64", false)]
    [InlineData("fe80::a%eth1", false)]
    [InlineData("1000:1000:1000:1000:1000:1000:255.255.255.255", true)]
    [InlineData("100:100:100:100:100:100:255.255.255.255.255", false)]
    [InlineData("100:100:100:100:100:100:100:255.255.255.255", false)]
    [InlineData("1:2:3:4:5:6:7:৪", false)]
    [InlineData("1:2::192.16৪.0.1", false)]
    public void MatchIPV6_ValidatesIPV6(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchIPV6(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("192.168.0.1", true)]
    [InlineData("127.0.0.0.1", false)]
    [InlineData("256.256.256.256", false)]
    [InlineData("127.0", false)]
    [InlineData("0x7f000001", false)]
    [InlineData("2130706433", false)]
    [InlineData("087.10.0.1", false)]
    [InlineData("87.10.0.1", true)]
    [InlineData("1২7.0.0.1", false)]
    [InlineData("192.168.1.0/24", false)]

    public void MatchIPV4_ValidatesIPV4(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchIPV4(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }


    [Theory]
    [InlineData("2EB8AA08-AA98-11EA-B4AA-73B441D16380", true)]
    [InlineData("2eb8aa08-aa98-11ea-b4aa-73b441d16380", true)]
    [InlineData("2eb8aa08-AA98-11ea-B4Aa-73B441D16380", true)]
    [InlineData("00000000-0000-0000-0000-000000000000", true)]
    [InlineData("2eb8aa08-aa98-11ea-b4aa-73b441d1638", false)]
    [InlineData("2eb8aa08-aa98-11ea-73b441d16380", false)]
    [InlineData("2eb8aa08-aa98-11ea-b4ga-73b441d16380", false)]
    [InlineData("2eb8aa08aa9811eab4aa73b441d16380", false)]
    [InlineData("2eb8aa08aa98-11ea-b4aa73b441d16380", false)]
    [InlineData("2eb8-aa08-aa98-11ea-b4aa73b44-1d16380", false)]
    [InlineData("2eb8aa08aa9811eab4aa73b441d16380----", false)]
    [InlineData("98d80576-482e-427f-8434-7f86890ab222", true)]
    [InlineData("99c17cbb-656f-564a-940f-1a4568f03487", true)]
    [InlineData("99c17cbb-656f-664a-940f-1a4568f03487", true)]
    [InlineData("99c17cbb-656f-f64a-940f-1a4568f03487", true)]
    public void MatchUuid_ValidatesUuid(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchUuid(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://foo.bar/?baz=qux#quux", true)]
    [InlineData("http://foo.com/blah_(wikipedia)_blah#cite-1", true)]
    [InlineData("http://foo.bar/?q=Test%20URL-encoded%20stuff", true)]
    [InlineData("http://xn--nw2a.xn--j6w193g/", true)]
    [InlineData("http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com", true)]
    [InlineData("http://223.255.255.254", true)]
    [InlineData("ftp://ftp.is.co.za/rfc/rfc1808.txt", true)]
    [InlineData("http://www.ietf.org/rfc/rfc2396.txt", true)]
    [InlineData("ldap://[2001:db8::7]/c=GB?objectClass?one", true)]
    [InlineData("mailto:John.Doe@example.com", true)]
    [InlineData("news:comp.infosystems.www.servers.unix", true)]
    [InlineData("tel:+1-816-555-1212", true)]
    [InlineData("urn:oasis:names:specification:docbook:dtd:xml:4.1.2", true)]
    [InlineData("//foo.bar/?baz=qux#quux", false)]
    [InlineData("/abc", false)]
    [InlineData("\\\\WINDOWS\\fileshare", false)]
    [InlineData("abc", false)]
    [InlineData("http:// shouldfail.com", false)]
    [InlineData(":// should fail", false)]
    [InlineData("bar,baz:foo", false)]
    public void MatchUri_ValidatesUri(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchUri(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }
}
