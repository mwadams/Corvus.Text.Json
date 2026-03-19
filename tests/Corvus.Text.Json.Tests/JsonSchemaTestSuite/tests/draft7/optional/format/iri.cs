using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Optional.Format.Iri;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteValidationOfIrIs : IClassFixture<SuiteValidationOfIrIs.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfIrIs(Fixture fixture)
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
    public void TestAValidIriWithAnchorTag()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://ƒøø.ßår/?∂éœ=πîx#πîüx\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriWithAnchorTagAndParentheses()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://ƒøø.com/blah_(wîkïpédiå)_blah#ßité-1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriWithUrlEncodedStuff()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://ƒøø.ßår/?q=Test%20URL-encoded%20stuff\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriWithManySpecialCharacters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriBasedOnIPv6()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://[2001:0db8:85a3:0000:0000:8a2e:0370:7334]\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIriBasedOnIPv6()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://2001:0db8:85a3:0000:0000:8a2e:0370:7334\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidRelativeIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/abc\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIri()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\\\\\\\\WINDOWS\\\\filëßåré\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIriThoughValidIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"âππ\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\optional\\format\\iri.json",
                "{ \"format\": \"iri\" }",
                "JsonSchemaTestSuite.Draft7.Optional.Format.Iri",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}