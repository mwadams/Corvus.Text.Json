using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Optional.Format.IdnEmail;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteValidationOfAnInternationalizedEMailAddresses : IClassFixture<SuiteValidationOfAnInternationalizedEMailAddresses.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfAnInternationalizedEMailAddresses(Fixture fixture)
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
    public void TestAValidIdnEMailExampleExampleTestInHangul()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"실례@실례.테스트\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidIdnEMailAddress()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2962\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidEMailAddress()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"joe.bloggs@example.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidEMailAddress()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2962\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\optional\\format\\idn-email.json",
                "{ \"format\": \"idn-email\" }",
                "JsonSchemaTestSuite.Draft7.Optional.Format.IdnEmail",
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