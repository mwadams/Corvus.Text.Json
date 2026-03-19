using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft4.Optional.Format.Hostname;

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteValidationOfHostNames : IClassFixture<SuiteValidationOfHostNames.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfHostNames(Fixture fixture)
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
    public void TestAValidHostName()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"www.example.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidPunycodedIdnHostname()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--4gbwdl.xn--wgbh1c\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAHostNameStartingWithAnIllegalCharacter()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"-a-host-name-that-starts-with--\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAHostNameContainingIllegalCharacters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"not_a_valid_host_name\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAHostNameWithAComponentTooLong()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"a-vvvvvvvvvvvvvvvveeeeeeeeeeeeeeeerrrrrrrrrrrrrrrryyyyyyyyyyyyyyyy-long-host-name-component\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStartsWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"-hostname\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEndsWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostname-\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStartsWithUnderscore()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"_hostname\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEndsWithUnderscore()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostname_\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestContainsUnderscore()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"host_name\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMaximumLabelLength()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceedsMaximumLabelLength()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijkl.com\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabel()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostname\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"host-name\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelWithDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"h0stn4me\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelEndingWithDigit()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostnam3\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\".\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestLeadingDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\".example\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailingDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"example.\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIdnLabelSeparator()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"example\\uff0ecom\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft4\\optional\\format\\hostname.json",
                "{ \"format\": \"hostname\" }",
                "JsonSchemaTestSuite.Draft4.Optional.Format.Hostname",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-04/schema#",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}