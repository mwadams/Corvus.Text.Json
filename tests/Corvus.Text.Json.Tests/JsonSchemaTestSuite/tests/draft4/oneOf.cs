using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft4.OneOf;

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOf : IClassFixture<SuiteOneOf.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOf(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFirstOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2.5");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNeitherOneOfValid()
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
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"oneOf\": [\r\n                {\r\n                    \"type\": \"integer\"\r\n                },\r\n                {\r\n                    \"minimum\": 2\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOfWithBaseSchema : IClassFixture<SuiteOneOfWithBaseSchema.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOfWithBaseSchema(Fixture fixture)
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
    public void TestOneOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foobar\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothOneOfValid()
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
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"type\": \"string\",\r\n            \"oneOf\" : [\r\n                {\r\n                    \"minLength\": 2\r\n                },\r\n                {\r\n                    \"maxLength\": 4\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOfComplexTypes : IClassFixture<SuiteOneOfComplexTypes.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOfComplexTypes(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFirstOneOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondOneOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"baz\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothOneOfValidComplex()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"baz\", \"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNeitherOneOfValidComplex()
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
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"oneOf\": [\r\n                {\r\n                    \"properties\": {\r\n                        \"bar\": {\"type\": \"integer\"}\r\n                    },\r\n                    \"required\": [\"bar\"]\r\n                },\r\n                {\r\n                    \"properties\": {\r\n                        \"foo\": {\"type\": \"string\"}\r\n                    },\r\n                    \"required\": [\"foo\"]\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOfWithEmptySchema : IClassFixture<SuiteOneOfWithEmptySchema.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOfWithEmptySchema(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestOneValidValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothValidInvalid()
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
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"oneOf\": [\r\n                { \"type\": \"number\" },\r\n                {}\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOfWithRequired : IClassFixture<SuiteOneOfWithRequired.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOfWithRequired(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestBothInvalidInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFirstValidValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondValidValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"baz\": 3}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothValidInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2, \"baz\" : 3}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"type\": \"object\",\r\n            \"oneOf\": [\r\n                { \"required\": [\"foo\", \"bar\"] },\r\n                { \"required\": [\"foo\", \"baz\"] }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteOneOfWithMissingOptionalProperty : IClassFixture<SuiteOneOfWithMissingOptionalProperty.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteOneOfWithMissingOptionalProperty(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFirstOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 8}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSecondOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"foo\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBothOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"foo\", \"bar\": 8}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNeitherOneOfValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"baz\": \"quux\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"oneOf\": [\r\n                {\r\n                    \"properties\": {\r\n                        \"bar\": {},\r\n                        \"baz\": {}\r\n                    },\r\n                    \"required\": [\"bar\"]\r\n                },\r\n                {\r\n                    \"properties\": {\r\n                        \"foo\": {}\r\n                    },\r\n                    \"required\": [\"foo\"]\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteNestedOneOfToCheckValidationSemantics : IClassFixture<SuiteNestedOneOfToCheckValidationSemantics.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNestedOneOfToCheckValidationSemantics(Fixture fixture)
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
                "tests\\draft4\\oneOf.json",
                "{\r\n            \"oneOf\": [\r\n                {\r\n                    \"oneOf\": [\r\n                        {\r\n                            \"type\": \"null\"\r\n                        }\r\n                    ]\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft4.OneOf",
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