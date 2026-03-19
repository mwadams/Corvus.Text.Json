using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.IfThenElse;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteIgnoreIfWithoutThenOrElse : IClassFixture<SuiteIgnoreIfWithoutThenOrElse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIgnoreIfWithoutThenOrElse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidWhenValidAgainstLoneIf()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidWhenInvalidAgainstLoneIf()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hello\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": {\r\n                \"const\": 0\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIgnoreThenWithoutIf : IClassFixture<SuiteIgnoreThenWithoutIf.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIgnoreThenWithoutIf(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidWhenValidAgainstLoneThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidWhenInvalidAgainstLoneThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hello\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"then\": {\r\n                \"const\": 0\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIgnoreElseWithoutIf : IClassFixture<SuiteIgnoreElseWithoutIf.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIgnoreElseWithoutIf(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidWhenValidAgainstLoneElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidWhenInvalidAgainstLoneElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hello\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"else\": {\r\n                \"const\": 0\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIfAndThenWithoutElse : IClassFixture<SuiteIfAndThenWithoutElse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIfAndThenWithoutElse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidThroughThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidThroughThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-100");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidWhenIfTestFails()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": {\r\n                \"exclusiveMaximum\": 0\r\n            },\r\n            \"then\": {\r\n                \"minimum\": -10\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIfAndElseWithoutThen : IClassFixture<SuiteIfAndElseWithoutThen.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIfAndElseWithoutThen(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidWhenIfTestPasses()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidThroughElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("4");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidThroughElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": {\r\n                \"exclusiveMaximum\": 0\r\n            },\r\n            \"else\": {\r\n                \"multipleOf\": 2\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteValidateAgainstCorrectBranchThenVsElse : IClassFixture<SuiteValidateAgainstCorrectBranchThenVsElse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidateAgainstCorrectBranchThenVsElse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidThroughThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidThroughThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-100");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidThroughElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("4");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidThroughElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": {\r\n                \"exclusiveMaximum\": 0\r\n            },\r\n            \"then\": {\r\n                \"minimum\": -10\r\n            },\r\n            \"else\": {\r\n                \"multipleOf\": 2\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteNonInterferenceAcrossCombinedSchemas : IClassFixture<SuiteNonInterferenceAcrossCombinedSchemas.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNonInterferenceAcrossCombinedSchemas(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidButWouldHaveBeenInvalidThroughThen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-100");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidButWouldHaveBeenInvalidThroughElse()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("3");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"allOf\": [\r\n                {\r\n                    \"if\": {\r\n                        \"exclusiveMaximum\": 0\r\n                    }\r\n                },\r\n                {\r\n                    \"then\": {\r\n                        \"minimum\": -10\r\n                    }\r\n                },\r\n                {\r\n                    \"else\": {\r\n                        \"multipleOf\": 2\r\n                    }\r\n                }\r\n            ]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIfWithBooleanSchemaTrue : IClassFixture<SuiteIfWithBooleanSchemaTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIfWithBooleanSchemaTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestBooleanSchemaTrueInIfAlwaysChoosesTheThenPathValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"then\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanSchemaTrueInIfAlwaysChoosesTheThenPathInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"else\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": true,\r\n            \"then\": { \"const\": \"then\" },\r\n            \"else\": { \"const\": \"else\" }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIfWithBooleanSchemaFalse : IClassFixture<SuiteIfWithBooleanSchemaFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIfWithBooleanSchemaFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestBooleanSchemaFalseInIfAlwaysChoosesTheElsePathInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"then\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBooleanSchemaFalseInIfAlwaysChoosesTheElsePathValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"else\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"if\": false,\r\n            \"then\": { \"const\": \"then\" },\r\n            \"else\": { \"const\": \"else\" }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteIfAppearsAtTheEndWhenSerializedKeywordProcessingSequence : IClassFixture<SuiteIfAppearsAtTheEndWhenSerializedKeywordProcessingSequence.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIfAppearsAtTheEndWhenSerializedKeywordProcessingSequence(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestYesRedirectsToThenAndPasses()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"yes\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOtherRedirectsToElseAndPasses()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"other\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoRedirectsToThenAndFails()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"no\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidRedirectsToElseAndFails()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"invalid\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"then\": { \"const\": \"yes\" },\r\n            \"else\": { \"const\": \"other\" },\r\n            \"if\": { \"maxLength\": 4 }\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteThenFalseFailsWhenConditionMatches : IClassFixture<SuiteThenFalseFailsWhenConditionMatches.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteThenFalseFailsWhenConditionMatches(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMatchesIfThenFalseInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestDoesNotMatchIfThenIgnoredValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"if\": { \"const\": 1 },\r\n            \"then\": false\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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
public class SuiteElseFalseFailsWhenConditionDoesNotMatch : IClassFixture<SuiteElseFalseFailsWhenConditionDoesNotMatch.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteElseFalseFailsWhenConditionDoesNotMatch(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMatchesIfElseIgnoredValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestDoesNotMatchIfElseExecutesInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\if-then-else.json",
                "{\r\n            \"if\": { \"const\": 1 },\r\n            \"else\": false\r\n        }",
                "JsonSchemaTestSuite.Draft202012.IfThenElse",
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