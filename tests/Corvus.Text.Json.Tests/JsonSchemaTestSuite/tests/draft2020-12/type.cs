using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.Type;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteIntegerTypeMatchesIntegers : IClassFixture<SuiteIntegerTypeMatchesIntegers.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteIntegerTypeMatchesIntegers(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatWithZeroFractionalPartIsAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsStillNotAnIntegerEvenIfItLooksLikeOne()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"integer\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteNumberTypeMatchesNumbers : IClassFixture<SuiteNumberTypeMatchesNumbers.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNumberTypeMatchesNumbers(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatWithZeroFractionalPartIsANumberAndAnInteger()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsStillNotANumberEvenIfItLooksLikeOne()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsNotANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"number\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteStringTypeMatchesStrings : IClassFixture<SuiteStringTypeMatchesStrings.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteStringTypeMatchesStrings(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test1IsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsStillAStringEvenIfItLooksLikeANumber()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnEmptyStringIsStillAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotAString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"string\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteObjectTypeMatchesObjects : IClassFixture<SuiteObjectTypeMatchesObjects.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteObjectTypeMatchesObjects(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotAnObject()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"object\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteArrayTypeMatchesArrays : IClassFixture<SuiteArrayTypeMatchesArrays.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteArrayTypeMatchesArrays(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotAnArray()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"array\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteBooleanTypeMatchesBooleans : IClassFixture<SuiteBooleanTypeMatchesBooleans.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteBooleanTypeMatchesBooleans(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnEmptyStringIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueIsABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseIsABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNotABoolean()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"boolean\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteNullTypeMatchesOnlyTheNullObject : IClassFixture<SuiteNullTypeMatchesOnlyTheNullObject.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNullTypeMatchesOnlyTheNullObject(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnEmptyStringIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseIsNotNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsNull()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": \"null\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteMultipleTypesCanBeSpecifiedInAnArray : IClassFixture<SuiteMultipleTypesCanBeSpecifiedInAnArray.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteMultipleTypesCanBeSpecifiedInAnArray(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAnIntegerIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAStringIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFloatIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnObjectIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnArrayIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestABooleanIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": [\"integer\", \"string\"]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteTypeAsArrayWithOneItem : IClassFixture<SuiteTypeAsArrayWithOneItem.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteTypeAsArrayWithOneItem(Fixture fixture)
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
    public void TestNumberIsInvalid()
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
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": [\"string\"]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteTypeArrayOrObject : IClassFixture<SuiteTypeArrayOrObject.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteTypeArrayOrObject(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1,2,3]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 123}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNumberIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("123");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStringIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"foo\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": [\"array\", \"object\"]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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
public class SuiteTypeArrayObjectOrNull : IClassFixture<SuiteTypeArrayObjectOrNull.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteTypeArrayObjectOrNull(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1,2,3]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": 123}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNullIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNumberIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("123");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStringIsInvalid()
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
                "tests\\draft2020-12\\type.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"type\": [\"array\", \"object\", \"null\"]\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Type",
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