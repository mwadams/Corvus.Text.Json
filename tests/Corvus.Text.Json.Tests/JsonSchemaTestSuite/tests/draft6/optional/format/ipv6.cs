using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft6.Optional.Format.Ipv6;

[Trait("JsonSchemaTestSuite", "Draft6")]
public class SuiteValidationOfIPv6Addresses : IClassFixture<SuiteValidationOfIPv6Addresses.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfIPv6Addresses(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAllStringFormatsIgnoreIntegers()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("12");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreFloats()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("13.7");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreObjects()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreArrays()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreBooleans()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreNulls()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIPv6Address()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnIPv6AddressWithOutOfRangeValues()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"12345::\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailing4HexSymbolsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::abef\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailing5HexSymbolsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::abcef\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnIPv6AddressWithTooManyComponents()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:1:1:1:1:1:1:1:1:1:1:1:1:1:1:1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnIPv6AddressContainingIllegalCharacters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::laptop\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoDigitsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestLeadingColonsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::42:ff:1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailingColonsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"d6::\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingLeadingOctetIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\":2:3:4:5:6:7:8\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingTrailingOctetIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:5:6:7:\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingLeadingOctetWithOmittedOctetsLater()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\":2:3:4::8\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleSetOfDoubleColonsInTheMiddleIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:d6::42\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTwoSetsOfDoubleColonsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1::d6::42\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMixedFormatWithTheIpv4SectionAsDecimalOctets()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1::d6:192.168.0.1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMixedFormatWithDoubleColonsBetweenTheSections()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2::192.168.0.1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMixedFormatWithIpv4SectionWithOctetOutOfRange()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1::2:192.168.256.1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMixedFormatWithIpv4SectionWithAHexOctet()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1::2:192.168.ff.1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMixedFormatWithLeadingDoubleColonsIpv4MappedIpv6Address()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::ffff:192.168.0.1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTripleColonsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:5:::8\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test8Octets()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:5:6:7:8\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInsufficientOctetsWithoutDoubleColons()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:5:6:7\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoColonsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIpv4IsNotIpv6()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"127.0.0.1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIpv4SegmentMustHave4Octets()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:1.2.3\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestLeadingWhitespaceIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"  ::1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailingWhitespaceIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"::1  \"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNetmaskIsNotAPartOfIpv6Address()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"fe80::/64\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZoneIdIsNotAPartOfIpv6Address()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"fe80::a%eth1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestALongValidIpv6()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1000:1000:1000:1000:1000:1000:255.255.255.255\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestALongInvalidIpv6BelowLengthLimitFirst()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"100:100:100:100:100:100:255.255.255.255.255\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestALongInvalidIpv6BelowLengthLimitSecond()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"100:100:100:100:100:100:100:255.255.255.255\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidNonAscii৪ABengali4()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2:3:4:5:6:7:৪\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidNonAscii৪ABengali4InTheIPv4Portion()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1:2::192.16৪.0.1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft6\\optional\\format\\ipv6.json",
                "{ \"format\": \"ipv6\" }",
                "JsonSchemaTestSuite.Draft6.Optional.Format.Ipv6",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-06/schema#",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}