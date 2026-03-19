using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Const;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteConstValidation : IClassFixture<SuiteConstValidation.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstValidation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestSameValueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnotherValueIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("5");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnotherTypeIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"a\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": 2}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithObject : IClassFixture<SuiteConstWithObject.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithObject(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestSameObjectIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\", \"baz\": \"bax\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSameObjectWithDifferentPropertyOrderIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"baz\": \"bax\", \"foo\": \"bar\"}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnotherObjectIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"foo\": \"bar\"}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnotherTypeIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": {\"foo\": \"bar\", \"baz\": \"bax\"}}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithArray : IClassFixture<SuiteConstWithArray.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithArray(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestSameArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\"}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnotherArrayItemIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[2]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestArrayWithAdditionalItemsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2, 3]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": [{ \"foo\": \"bar\" }]}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithNull : IClassFixture<SuiteConstWithNull.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithNull(Fixture fixture)
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
    public void TestNotNullIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": null}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithFalseDoesNotMatch0 : IClassFixture<SuiteConstWithFalseDoesNotMatch0.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithFalseDoesNotMatch0(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIntegerZeroIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatZeroIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0.0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": false}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithTrueDoesNotMatch1 : IClassFixture<SuiteConstWithTrueDoesNotMatch1.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithTrueDoesNotMatch1(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIntegerOneIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatOneIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": true}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithFalseDoesNotMatch01 : IClassFixture<SuiteConstWithFalseDoesNotMatch01.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithFalseDoesNotMatch01(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test0IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test00IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0.0]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": [false]}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithTrueDoesNotMatch11 : IClassFixture<SuiteConstWithTrueDoesNotMatch11.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithTrueDoesNotMatch11(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test1IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test10IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1.0]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": [true]}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithAFalseDoesNotMatchA0 : IClassFixture<SuiteConstWithAFalseDoesNotMatchA0.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithAFalseDoesNotMatchA0(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": false}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestA0IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 0}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestA00IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 0.0}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": {\"a\": false}}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWithATrueDoesNotMatchA1 : IClassFixture<SuiteConstWithATrueDoesNotMatchA1.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWithATrueDoesNotMatchA1(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestATrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": true}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestA1IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 1}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestA10IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{\"a\": 1.0}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": {\"a\": true}}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWith0DoesNotMatchOtherZeroLikeTypes : IClassFixture<SuiteConstWith0DoesNotMatchOtherZeroLikeTypes.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWith0DoesNotMatchOtherZeroLikeTypes(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIntegerZeroIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatZeroIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("0.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyObjectIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyArrayIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyStringIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": 0}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWith1DoesNotMatchTrue : IClassFixture<SuiteConstWith1DoesNotMatchTrue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWith1DoesNotMatchTrue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestTrueIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("true");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIntegerOneIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatOneIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": 1}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteConstWith20MatchesIntegerAndFloatTypes : IClassFixture<SuiteConstWith20MatchesIntegerAndFloatTypes.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteConstWith20MatchesIntegerAndFloatTypes(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestInteger2IsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-2");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInteger2IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloat20IsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-2.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloat20IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("2.0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloat200001IsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("-2.00001");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": -2.0}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteFloatAndIntegersAreEqualUpTo64BitRepresentationLimits : IClassFixture<SuiteFloatAndIntegersAreEqualUpTo64BitRepresentationLimits.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteFloatAndIntegersAreEqualUpTo64BitRepresentationLimits(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestIntegerIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("9007199254740992");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIntegerMinusOneIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("9007199254740991");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("9007199254740992.0");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFloatMinusOneIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("9007199254740991.0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\"const\": 9007199254740992}",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteNulCharactersInStrings : IClassFixture<SuiteNulCharactersInStrings.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteNulCharactersInStrings(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestMatchStringWithNul()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hello\\u0000there\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestDoNotMatchStringLackingNul()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hellothere\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{ \"const\": \"hello\\u0000there\" }",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteCharactersWithTheSameVisualRepresentationButDifferentCodepoint : IClassFixture<SuiteCharactersWithTheSameVisualRepresentationButDifferentCodepoint.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteCharactersWithTheSameVisualRepresentationButDifferentCodepoint(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestCharacterUsesTheSameCodepoint()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"μ\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestCharacterLooksTheSameButUsesADifferentCodepoint()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"µ\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\r\n            \"const\": \"μ\",\r\n            \"$comment\": \"U+03BC\"\r\n        }",
                "JsonSchemaTestSuite.Draft7.Const",
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
public class SuiteCharactersWithTheSameVisualRepresentationButDifferentNumberOfCodepoints : IClassFixture<SuiteCharactersWithTheSameVisualRepresentationButDifferentNumberOfCodepoints.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteCharactersWithTheSameVisualRepresentationButDifferentNumberOfCodepoints(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestCharacterUsesTheSameCodepoint()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"ä\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestCharacterLooksTheSameButUsesCombiningMarks()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"ä\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\const.json",
                "{\r\n            \"const\": \"ä\",\r\n            \"$comment\": \"U+00E4\"\r\n        }",
                "JsonSchemaTestSuite.Draft7.Const",
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