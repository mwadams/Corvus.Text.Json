using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.PropertyNames;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesValidation : IClassFixture<SuitePropertyNamesValidation.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesValidation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAllPropertyNamesValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"f\": {},\r\n                    \"foo\": {}\r\n                }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSomePropertyNamesInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\": {},\r\n                    \"foobar\": {}\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithoutPropertiesIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresArrays()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2, 3, 4]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresStrings()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foobar\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresOtherNonObjects()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("12");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\r\n            \"propertyNames\": {\"maxLength\": 3}\r\n        }",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesValidationWithPattern : IClassFixture<SuitePropertyNamesValidationWithPattern.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesValidationWithPattern(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMatchingPropertyNamesValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"a\": {},\r\n                    \"aa\": {},\r\n                    \"aaa\": {}\r\n                }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonMatchingPropertyNameIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"aaA\": {}\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithoutPropertiesIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\r\n            \"propertyNames\": { \"pattern\": \"^a+$\" }\r\n        }",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesWithBooleanSchemaTrue : IClassFixture<SuitePropertyNamesWithBooleanSchemaTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesWithBooleanSchemaTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithAnyPropertiesIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\"propertyNames\": true}",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesWithBooleanSchemaFalse : IClassFixture<SuitePropertyNamesWithBooleanSchemaFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesWithBooleanSchemaFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithAnyPropertiesIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\"propertyNames\": false}",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesWithConst : IClassFixture<SuitePropertyNamesWithConst.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesWithConst(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithPropertyFooIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithAnyOtherPropertyIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\"propertyNames\": {\"const\": \"foo\"}}",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuitePropertyNamesWithEnum : IClassFixture<SuitePropertyNamesWithEnum.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePropertyNamesWithEnum(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithPropertyFooIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithPropertyFooAndBarIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithAnyOtherPropertyIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"baz\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\propertyNames.json",
                "{\"propertyNames\": {\"enum\": [\"foo\", \"bar\"]}}",
                "JsonSchemaTestSuite.Draft7.PropertyNames",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}