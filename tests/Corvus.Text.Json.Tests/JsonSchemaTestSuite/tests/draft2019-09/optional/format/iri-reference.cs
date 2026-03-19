using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft201909.Optional.Format.IriReference;

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteValidationOfIriReferences : IClassFixture<SuiteValidationOfIriReferences.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfIriReferences(Fixture fixture)
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
    public void TestAValidIri()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"http://ƒøø.ßår/?∂éœ=πîx#πîüx\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidProtocolRelativeIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"//ƒøø.ßår/?∂éœ=πîx#πîüx\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidRelativeIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/âππ\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\\\\\\\\WINDOWS\\\\filëßåré\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriReference()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"âππ\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidIriFragment()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"#ƒrägmênt\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIriFragment()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"#ƒräg\\\\mênt\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\optional\\format\\iri-reference.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"format\": \"iri-reference\"\r\n        }",
                "JsonSchemaTestSuite.Draft201909.Optional.Format.IriReference",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}