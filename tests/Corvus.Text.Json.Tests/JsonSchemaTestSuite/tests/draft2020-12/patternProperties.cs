using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.PatternProperties;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuitePatternPropertiesValidatesPropertiesMatchingARegex : IClassFixture<SuitePatternPropertiesValidatesPropertiesMatchingARegex.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePatternPropertiesValidatesPropertiesMatchingARegex(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestASingleValidMatchIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMultipleValidMatchesIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"foooooo\" : 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestASingleInvalidMatchIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\", \"fooooo\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMultipleInvalidMatchesIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\", \"foooooo\" : \"baz\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresArrays()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"foo\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresStrings()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
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
                "tests\\draft2020-12\\patternProperties.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"patternProperties\": {\r\n                \"f.*o\": {\"type\": \"integer\"}\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.PatternProperties",
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
public class SuiteMultipleSimultaneousPatternPropertiesAreValidated : IClassFixture<SuiteMultipleSimultaneousPatternPropertiesAreValidated.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteMultipleSimultaneousPatternPropertiesAreValidated(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestASingleValidMatchIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 21}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestASimultaneousMatchIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"aaaa\": 18}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMultipleMatchesIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 21, \"aaaa\": 18}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidDueToOneIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": \"bar\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidDueToTheOtherIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"aaaa\": 31}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidDueToBothIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"aaa\": \"foo\", \"aaaa\": 31}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\patternProperties.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"patternProperties\": {\r\n                \"a*\": {\"type\": \"integer\"},\r\n                \"aaa*\": {\"maximum\": 20}\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.PatternProperties",
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
public class SuiteRegexesAreNotAnchoredByDefaultAndAreCaseSensitive : IClassFixture<SuiteRegexesAreNotAnchoredByDefaultAndAreCaseSensitive.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteRegexesAreNotAnchoredByDefaultAndAreCaseSensitive(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNonRecognizedMembersAreIgnored()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"answer 1\": \"42\" }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestRecognizedMembersAreAccountedFor()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"a31b\": null }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestRegexesAreCaseSensitive()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"a_x_3\": 3 }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestRegexesAreCaseSensitive2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"a_X_3\": 3 }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\patternProperties.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"patternProperties\": {\r\n                \"[0-9]{2,}\": { \"type\": \"boolean\" },\r\n                \"X_\": { \"type\": \"string\" }\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.PatternProperties",
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
public class SuitePatternPropertiesWithBooleanSchemas : IClassFixture<SuitePatternPropertiesWithBooleanSchemas.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePatternPropertiesWithBooleanSchemas(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithPropertyMatchingSchemaTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithPropertyMatchingSchemaFalseIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithBothPropertiesIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithAPropertyMatchingBothTrueAndFalseIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foobar\":1}");
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
                "tests\\draft2020-12\\patternProperties.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"patternProperties\": {\r\n                \"f.*\": true,\r\n                \"b.*\": false\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.PatternProperties",
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
public class SuitePatternPropertiesWithNullValuedInstanceProperties : IClassFixture<SuitePatternPropertiesWithNullValuedInstanceProperties.Fixture>
{
    private readonly Fixture _fixture;
    public SuitePatternPropertiesWithNullValuedInstanceProperties(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAllowsNullValues()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foobar\": null}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\patternProperties.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"patternProperties\": {\r\n                \"^.*bar$\": {\"type\": \"null\"}\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.PatternProperties",
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