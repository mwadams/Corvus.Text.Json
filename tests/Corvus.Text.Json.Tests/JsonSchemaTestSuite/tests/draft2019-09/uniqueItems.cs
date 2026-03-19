using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft201909.UniqueItems;

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsValidation : IClassFixture<SuiteUniqueItemsValidation.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsValidation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUniqueArrayOfIntegersIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfIntegersIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 1]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfMoreThanTwoIntegersIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2, 1]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNumbersAreUniqueIfMathematicallyUnequal()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1.0, 1.00, 1]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseIsNotEqualToZero()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueIsNotEqualToOne()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfStringsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"foo\", \"bar\", \"baz\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfStringsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\"foo\", \"bar\", \"foo\"]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\"}, {\"foo\": \"baz\"}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfObjectsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\"}, {\"foo\": \"bar\"}]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestPropertyOrderOfArrayOfObjectsIsIgnored()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\", \"bar\": \"foo\"}, {\"bar\": \"foo\", \"foo\": \"bar\"}]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfNestedObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : false}}}\r\n                ]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfNestedObjectsIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}}\r\n                ]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfArraysIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[\"foo\"], [\"bar\"]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfArraysIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[\"foo\"], [\"foo\"]]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfMoreThanTwoArraysIsInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[\"foo\"], [\"bar\"], [\"foo\"]]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test1AndTrueAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test0AndFalseAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test1AndTrueAreUnique1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[1], [true]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test0AndFalseAreUnique1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[0], [false]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNested1AndTrueAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[[1], \"foo\"], [[true], \"foo\"]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNested0AndFalseAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[[0], \"foo\"], [[false], \"foo\"]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueHeterogeneousTypesAreValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{}, [1], true, null, 1, \"{}\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueHeterogeneousTypesAreInvalid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{}, [1], true, null, {}, 1]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestDifferentObjectsAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"a\": 1, \"b\": 2}, {\"a\": 2, \"b\": 1}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestObjectsAreNonUniqueDespiteKeyOrder()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"a\": 1, \"b\": 2}, {\"b\": 2, \"a\": 1}]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAFalseAndA0AreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"a\": false}, {\"a\": 0}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestATrueAndA1AreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"a\": true}, {\"a\": 1}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"uniqueItems\": true\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsWithAnArrayOfItems : IClassFixture<SuiteUniqueItemsWithAnArrayOfItems.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsWithAnArrayOfItems(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseFalseFromItemsArrayIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, false]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueTrueFromItemsArrayIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, true]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayExtendedFromFalseTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, \"foo\", \"bar\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayExtendedFromTrueFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false, \"foo\", \"bar\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayExtendedFromFalseTrueIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, \"foo\", \"foo\"]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayExtendedFromTrueFalseIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false, \"foo\", \"foo\"]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"items\": [{\"type\": \"boolean\"}, {\"type\": \"boolean\"}],\r\n            \"uniqueItems\": true\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsWithAnArrayOfItemsAndAdditionalItemsFalse : IClassFixture<SuiteUniqueItemsWithAnArrayOfItemsAndAdditionalItemsFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsWithAnArrayOfItemsAndAdditionalItemsFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseFalseFromItemsArrayIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, false]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueTrueFromItemsArrayIsNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, true]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExtraItemsAreInvalidEvenIfUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, null]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"items\": [{\"type\": \"boolean\"}, {\"type\": \"boolean\"}],\r\n            \"uniqueItems\": true,\r\n            \"additionalItems\": false\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsFalseValidation : IClassFixture<SuiteUniqueItemsFalseValidation.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsFalseValidation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUniqueArrayOfIntegersIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 2]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfIntegersIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, 1]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNumbersAreUniqueIfMathematicallyUnequal()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1.0, 1.00, 1]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseIsNotEqualToZero()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueIsNotEqualToOne()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\"}, {\"foo\": \"baz\"}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{\"foo\": \"bar\"}, {\"foo\": \"bar\"}]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfNestedObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : false}}}\r\n                ]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfNestedObjectsIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}}\r\n                ]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayOfArraysIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[\"foo\"], [\"bar\"]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayOfArraysIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[[\"foo\"], [\"foo\"]]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test1AndTrueAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[1, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test0AndFalseAreUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[0, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueHeterogeneousTypesAreValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{}, [1], true, null, 1]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueHeterogeneousTypesAreValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[{}, [1], true, null, {}, 1]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"uniqueItems\": false\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsFalseWithAnArrayOfItems : IClassFixture<SuiteUniqueItemsFalseWithAnArrayOfItems.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsFalseWithAnArrayOfItems(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayExtendedFromFalseTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, \"foo\", \"bar\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestUniqueArrayExtendedFromTrueFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false, \"foo\", \"bar\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayExtendedFromFalseTrueIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, \"foo\", \"foo\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonUniqueArrayExtendedFromTrueFalseIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false, \"foo\", \"foo\"]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"items\": [{\"type\": \"boolean\"}, {\"type\": \"boolean\"}],\r\n            \"uniqueItems\": false\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteUniqueItemsFalseWithAnArrayOfItemsAndAdditionalItemsFalse : IClassFixture<SuiteUniqueItemsFalseWithAnArrayOfItemsAndAdditionalItemsFalse.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteUniqueItemsFalseWithAnArrayOfItemsAndAdditionalItemsFalse(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestFalseTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestFalseFalseFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, false]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrueTrueFromItemsArrayIsValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[true, true]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExtraItemsAreInvalidEvenIfUnique()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[false, true, null]");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2019-09\\uniqueItems.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"items\": [{\"type\": \"boolean\"}, {\"type\": \"boolean\"}],\r\n            \"uniqueItems\": false,\r\n            \"additionalItems\": false\r\n        }",
                "JsonSchemaTestSuite.Draft201909.UniqueItems",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}