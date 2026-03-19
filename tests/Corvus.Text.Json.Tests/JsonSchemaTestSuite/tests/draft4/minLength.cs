using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft4.MinLength;

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteMinLengthValidation : IClassFixture<SuiteMinLengthValidation.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteMinLengthValidation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestLongerIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExactLengthIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"fo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTooShortIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"f\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresNonStrings()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOneGraphemeIsNotLongEnough()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\\uD83D\\uDCA9\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft4\\minLength.json",
                "{\"minLength\": 2}",
                "JsonSchemaTestSuite.Draft4.MinLength",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-04/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}