using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Dependencies;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteDependencies : IClassFixture<SuiteDependencies.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDependencies(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNeither()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNondependant()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestWithDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIgnoresArrays()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"bar\"]");
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
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\"bar\": [\"foo\"]}\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteDependenciesWithEmptyArray : IClassFixture<SuiteDependenciesWithEmptyArray.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDependenciesWithEmptyArray(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestEmptyObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithOneProperty()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\"bar\": []}\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteMultipleDependencies : IClassFixture<SuiteMultipleDependencies.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteMultipleDependencies(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestNeither()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNondependants()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestWithDependencies()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2, \"quux\": 3}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"quux\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingOtherDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 1, \"quux\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMissingBothDependencies()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"quux\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\"quux\": [\"foo\", \"bar\"]}\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteMultipleDependenciesSubschema : IClassFixture<SuiteMultipleDependenciesSubschema.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteMultipleDependenciesSubschema(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"quux\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestWrongType()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"quux\", \"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestWrongTypeOther()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 2, \"bar\": \"quux\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestWrongTypeBoth()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"quux\", \"bar\": \"quux\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\r\n                \"bar\": {\r\n                    \"properties\": {\r\n                        \"foo\": {\"type\": \"integer\"},\r\n                        \"bar\": {\"type\": \"integer\"}\r\n                    }\r\n                }\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteDependenciesWithBooleanSubschemas : IClassFixture<SuiteDependenciesWithBooleanSubschemas.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDependenciesWithBooleanSubschemas(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestObjectWithPropertyHavingSchemaTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectWithPropertyHavingSchemaFalseIsInvalid()
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
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\r\n                \"foo\": true,\r\n                \"bar\": false\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteDependenciesWithEscapedCharacters : IClassFixture<SuiteDependenciesWithEscapedCharacters.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDependenciesWithEscapedCharacters(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestValidObject1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\\nbar\": 1,\r\n                    \"foo\\rbar\": 2\r\n                }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidObject2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\\tbar\": 1,\r\n                    \"a\": 2,\r\n                    \"b\": 3,\r\n                    \"c\": 4\r\n                }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidObject3()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo'bar\": 1,\r\n                    \"foo\\\"bar\": 2\r\n                }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidObject1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\\nbar\": 1,\r\n                    \"foo\": 2\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidObject2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\\tbar\": 1,\r\n                    \"a\": 2\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidObject3()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo'bar\": 1\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidObject4()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\r\n                    \"foo\\\"bar\": 2\r\n                }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"dependencies\": {\r\n                \"foo\\nbar\": [\"foo\\rbar\"],\r\n                \"foo\\tbar\": {\r\n                    \"minProperties\": 4\r\n                },\r\n                \"foo'bar\": {\"required\": [\"foo\\\"bar\"]},\r\n                \"foo\\\"bar\": [\"foo'bar\"]\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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
public class SuiteDependentSubschemaIncompatibleWithRoot : IClassFixture<SuiteDependentSubschemaIncompatibleWithRoot.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDependentSubschemaIncompatibleWithRoot(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMatchesRoot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMatchesDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"bar\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMatchesBoth()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 1, \"bar\": 2}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoDependency()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"baz\": 1}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\dependencies.json",
                "{\r\n            \"properties\": {\r\n                \"foo\": {}\r\n            },\r\n            \"dependencies\": {\r\n                \"foo\": {\r\n                    \"properties\": {\r\n                        \"bar\": {}\r\n                    },\r\n                    \"additionalProperties\": false\r\n                }\r\n            }\r\n        }",
                "JsonSchemaTestSuite.Draft7.Dependencies",
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