using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft6.BooleanSchema;

[Trait("JsonSchemaTestSuite", "Draft6")]
public class SuiteBooleanSchemaTrue : IClassFixture<SuiteBooleanSchemaTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteBooleanSchemaTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNumberIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStringIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"foo\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft6\\boolean_schema.json",
                "true",
                "JsonSchemaTestSuite.Draft6.BooleanSchema",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-06/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft6")]
public class SuiteBooleanSchemaFalse : IClassFixture<SuiteBooleanSchemaFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteBooleanSchemaFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNumberIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStringIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanTrueIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanFalseIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestArrayIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"foo\"]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyArrayIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft6\\boolean_schema.json",
                "false",
                "JsonSchemaTestSuite.Draft6.BooleanSchema",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-06/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}