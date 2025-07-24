// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;
using Xunit;

namespace Corvus.Text.Json.Tests;

public class JsonSchemaMatchingStringTests
{
    [Theory]
    [InlineData("2023-06-01", true)]
    [InlineData("not-a-date", false)]
    public void MatchDate_ValidatesDate(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchDate(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchDateTime(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchDuration(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
    [InlineData("用户@例子.广告", false)]
    public void MatchEmail_ValidatesEmail(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchEmail(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
    [InlineData("실례.테스트", false)]
    public void MatchHostname_ValidatesHostname(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchHostname(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("用户@例子.广告", true)]
    [InlineData("(allows leading comment)用户@例子.广告", true)]
    [InlineData("用户(allows trailing comment)@例子.广告", true)]
    [InlineData("(allows leading comment)用户(and allows trailing comment)@例子.广告", true)]
    [InlineData("(用户@例子.广告", false)]
    [InlineData("用户(sdk@例子.广告", false)]
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
        bool result = JsonSchemaEvaluation.MatchIdnEmail(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchIdnHostname(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchIPV4(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchIPV6(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://ƒøø.ßår/?∂éœ=πîx#πîüx", true)]
    [InlineData("http://ƒøø.com/blah_(wîkïpédiå)_blah#ßité-1", true)]
    [InlineData("http://ƒøø.ßår/?q=Test%20URL-encoded%20stuff", true)]
    [InlineData("http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com", true)]
    [InlineData("http://[2001:0db8:85a3:0000:0000:8a2e:0370:7334]", true)]
    [InlineData("http://2001:0db8:85a3:0000:0000:8a2e:0370:7334", false)]
    [InlineData("/abc", false)]
    [InlineData("\\\\WINDOWS\\filëßåré", false)]
    [InlineData("âππ", false)]
    public void MatchIri_ValidatesIri(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchIri(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://ƒøø.ßår/?∂éœ=πîx#πîüx", true)]
    [InlineData("//ƒøø.ßår/?∂éœ=πîx#πîüx", true)]
    [InlineData("/âππ", true)]
    [InlineData("\\\\WINDOWS\\filëßåré", false)]
    [InlineData("âππ", true)]
    [InlineData("#ƒrägmênt", true)]
    [InlineData("#ƒräg\\mênt", false)]
    public void MatchIriReference_ValidatesIriReference(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchIriReference(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("/foo/bar~0/baz~1/%a", true)]
    [InlineData("/foo/bar~", false)]
    [InlineData("/foo//bar", true)]
    [InlineData("/foo/bar/", true)]
    [InlineData("", true)]
    [InlineData("/foo", true)]
    [InlineData("/foo/0", true)]
    [InlineData("/", true)]
    [InlineData("/a~1b", true)]
    [InlineData("/c%d", true)]
    [InlineData("/e^f", true)]
    [InlineData("/g|h", true)]
    [InlineData("/i\\j", true)]
    [InlineData("/k\"l", true)]
    [InlineData("/ ", true)]
    [InlineData("/m~0n", true)]
    [InlineData("/foo/-", true)]
    [InlineData("/foo/-/bar", true)]
    [InlineData("/~1~0~0~1~1", true)]
    [InlineData("/~1.1", true)]
    [InlineData("/~0.1", true)]
    [InlineData("#", false)]
    [InlineData("#/", false)]
    [InlineData("#a", false)]
    [InlineData("/~0~", false)]
    [InlineData("/~0/~", false)]
    [InlineData("/~2", false)]
    [InlineData("/~-1", false)]
    [InlineData("/~~", false)]
    [InlineData("a", false)]
    [InlineData("0", false)]
    [InlineData("a/a", false)]
    public void MatchJsonPointer_ValidatesJsonPointer(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchJsonPointer(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("([abc])+\\s+$", true)]
    [InlineData("^(abc]", false)]
    public void MatchRegex_ValidatesRegex(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchRegex(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("1", true)]
    [InlineData("0/foo/bar", true)]
    [InlineData("2/0/baz/1/zip", true)]
    [InlineData("0#", true)]
    [InlineData("/foo/bar", false)]
    [InlineData("-1/foo/bar", false)]
    [InlineData("+1/foo/bar", false)]
    [InlineData("0##", false)]
    [InlineData("01/a", false)]
    [InlineData("01#", false)]
    [InlineData("", false)]
    [InlineData("120/foo/bar", true)]
    public void MatchRelativeJsonPointer_ValidatesRelativeJsonPointer(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchRelativeJsonPointer(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchTime(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData(JsonTokenType.String, true)]
    [InlineData(JsonTokenType.Number, false)]
    public void MatchTypeString_ValidatesTokenType(JsonTokenType tokenType, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchTypeString(tokenType, "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://foo.bar/?baz=qux#quux", true)]
    [InlineData("http://foo.bar/?baz=qux#qu\\ux", false)] // Non-canonical fragment
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
    [InlineData("http://ƒøø.ßår/?∂éœ=πîx#πîüx", false)]
    public void MatchUri_ValidatesUri(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchUri(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://foo.bar/?baz=qux#quux", true)]
    [InlineData("//foo.bar/?baz=qux#quux", true)]
    [InlineData("/abc", true)]
    [InlineData("\\\\WINDOWS\\fileshare", false)]
    [InlineData("abc", true)]
    [InlineData("#fragment", true)]
    [InlineData("#frag\\ment", false)]
    [InlineData("#ƒrägmênt", false)]
    public void MatchUriReference_ValidatesUriReference(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchUriReference(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("http://example.com/dictionary/{term:1}/{term}", true)]
    [InlineData("http://example.com/dictionary/{term:1}/{term", false)]
    [InlineData("http://example.com/dictionary", true)]
    [InlineData("dictionary/{term:1}/{term}", true)]
    [InlineData("map?{x,y}", true)]
    [InlineData("{x,hello,y}", true)]
    [InlineData("{+x,hello,y}", true)]
    [InlineData("{+path,x}/here", true)]
    [InlineData("{#x,hello,y}", true)]
    [InlineData("{#path,x}/here", true)]
    [InlineData("X{.var}", true)]
    [InlineData("X{.x,y}", true)]
    [InlineData("{/var}", true)]
    [InlineData("{/var,x}/here", true)]
    [InlineData("{;x,y}", true)]
    [InlineData("{;x,y,empty}", true)]
    [InlineData("{?x,y}", true)]
    [InlineData("{?x,y,empty}", true)]
    [InlineData("?fixed=yes{&x}", true)]
    [InlineData("{&x,y,empty}", true)]
    [InlineData("{var:3}", true)]
    [InlineData("{var:30}", true)]
    [InlineData("{list}", true)]
    [InlineData("{list*}", true)]
    [InlineData("{keys}", true)]
    [InlineData("{keys*}", true)]
    [InlineData("{+path:6}/here", true)]
    [InlineData("{+list}", true)]
    [InlineData("{+list*}", true)]
    [InlineData("{+keys}", true)]
    [InlineData("{+keys*}", true)]
    [InlineData("{#path:6}/here", true)]
    [InlineData("{#list}", true)]
    [InlineData("{#list*}", true)]
    [InlineData("{#keys}", true)]
    [InlineData("X{.var:3}", true)]
    [InlineData("X{.list}", true)]
    [InlineData("X{.list*}", true)]
    [InlineData("X{.keys}", true)]
    [InlineData("{/var:1,var}", true)]
    [InlineData("{/list}", true)]
    [InlineData("{/list*}", true)]
    [InlineData("{/list*,path:4}", true)]
    [InlineData("{/keys}", true)]
    [InlineData("{/keys*}", true)]
    [InlineData("{;hello:5}", true)]
    [InlineData("{;list}", true)]
    [InlineData("{;list*}", true)]
    [InlineData("{;keys}", true)]
    [InlineData("{;keys*}", true)]
    [InlineData("{?var:3}", true)]
    [InlineData("{?list}", true)]
    [InlineData("{?list*}", true)]
    [InlineData("{?keys}", true)]
    [InlineData("{?keys*}", true)]
    [InlineData("{&var:3}", true)]
    [InlineData("{&list}", true)]
    [InlineData("{&list*}", true)]
    [InlineData("{&keys}", true)]
    [InlineData("{&keys*}", true)]
    [InlineData("{+var}", true)]
    [InlineData("{+hello}", true)]
    [InlineData("{+path}/here", true)]
    [InlineData("here?ref={+path}", true)]
    [InlineData("{var}", true)]
    [InlineData("'{var}'", false)]
    [InlineData("{hello}", true)]
    [InlineData("http://ƒøø.ßår/?∂éœ={var}#πîüx", true)]
    [InlineData("#ƒräg\\mênt/{var}", false)]
    public void MatchUriTemplate_ValidatesUriTemplate(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaEvaluation.MatchUriTemplate(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
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
        bool result = JsonSchemaEvaluation.MatchUuid(Encoding.UTF8.GetBytes(value), "dummy"u8, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    private JsonSchemaContext CreateContext(DummyResultsCollector collector, JsonTokenType tokenType)
    {
        return JsonSchemaContext.BeginContext(new DummyDocument(tokenType), 0, false, false, collector);
    }
}
