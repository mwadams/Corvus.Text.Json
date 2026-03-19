using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.AnyOf;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOf : IClassFixture<SuiteAnyOf.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOf(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFirstAnyOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondAnyOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2.5");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothAnyOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNeitherAnyOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.5");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [\r\n                {\r\n                    \"type\": \"integer\"\r\n                },\r\n                {\r\n                    \"minimum\": 2\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfWithBaseSchema : IClassFixture<SuiteAnyOfWithBaseSchema.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfWithBaseSchema(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMismatchBaseSchema()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOneAnyOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foobar\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothAnyOfInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"string\",\r\n            \"anyOf\" : [\r\n                {\r\n                    \"maxLength\": 2\r\n                },\r\n                {\r\n                    \"minLength\": 4\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfWithBooleanSchemasAllTrue : IClassFixture<SuiteAnyOfWithBooleanSchemasAllTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfWithBooleanSchemasAllTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnyValueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [true, true]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfWithBooleanSchemasSomeTrue : IClassFixture<SuiteAnyOfWithBooleanSchemasSomeTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfWithBooleanSchemasSomeTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnyValueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [true, false]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfWithBooleanSchemasAllFalse : IClassFixture<SuiteAnyOfWithBooleanSchemasAllFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfWithBooleanSchemasAllFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnyValueIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [false, false]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfComplexTypes : IClassFixture<SuiteAnyOfComplexTypes.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfComplexTypes(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFirstAnyOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondAnyOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"baz\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothAnyOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"baz\", \"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNeitherAnyOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 2, \"bar\": \"quux\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [\r\n                {\r\n                    \"properties\": {\r\n                        \"bar\": {\"type\": \"integer\"}\r\n                    },\r\n                    \"required\": [\"bar\"]\r\n                },\r\n                {\r\n                    \"properties\": {\r\n                        \"foo\": {\"type\": \"string\"}\r\n                    },\r\n                    \"required\": [\"foo\"]\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteAnyOfWithOneEmptySchema : IClassFixture<SuiteAnyOfWithOneEmptySchema.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteAnyOfWithOneEmptySchema(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestStringIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNumberIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("123");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [\r\n                { \"type\": \"number\" },\r\n                {}\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteNestedAnyOfToCheckValidationSemantics : IClassFixture<SuiteNestedAnyOfToCheckValidationSemantics.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNestedAnyOfToCheckValidationSemantics(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNullIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnythingNonNullIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("123");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\anyOf.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"anyOf\": [\r\n                {\r\n                    \"anyOf\": [\r\n                        {\r\n                            \"type\": \"null\"\r\n                        }\r\n                    ]\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.AnyOf",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}