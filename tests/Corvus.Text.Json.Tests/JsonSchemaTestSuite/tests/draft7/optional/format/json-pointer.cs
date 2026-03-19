using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Optional.Format.JsonPointer;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteValidationOfJsonPointersJsonStringRepresentation : IClassFixture<SuiteValidationOfJsonPointersJsonStringRepresentation.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfJsonPointersJsonStringRepresentation(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAllStringFormatsIgnoreIntegers()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("12");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreFloats()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("13.7");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreObjects()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{}");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreArrays()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("[]");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreBooleans()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("false");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAllStringFormatsIgnoreNulls()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("null");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidJsonPointer()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/bar~0/baz~1/%a\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerNotEscaped()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/bar~\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerWithEmptySegment()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo//bar\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerWithTheLastEmptySegment()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/bar/\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69011()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69012()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69013()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/0\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69014()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69015()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/a~1b\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69016()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/c%d\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69017()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/e^f\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69018()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/g|h\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc69019()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/i\\\\j\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc690110()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/k\\\"l\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc690111()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/ \"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerAsStatedInRfc690112()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/m~0n\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerUsedAddingToTheLastArrayPosition()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/-\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerUsedAsObjectMemberName()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/foo/-/bar\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerMultipleEscapedCharacters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~1~0~0~1~1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerEscapedWithFractionPart1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~1.1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestValidJsonPointerEscapedWithFractionPart2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~0.1\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerUriFragmentIdentifier1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"#\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerUriFragmentIdentifier2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"#/\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerUriFragmentIdentifier3()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"#a\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerSomeEscapedButNotAll1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~0~\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerSomeEscapedButNotAll2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~0/~\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerWrongEscapeCharacter1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~2\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerWrongEscapeCharacter2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~-1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerMultipleCharactersNotEscaped()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"/~~\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerIsnTEmptyNorStartsWith1()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"a\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerIsnTEmptyNorStartsWith2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"0\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNotAValidJsonPointerIsnTEmptyNorStartsWith3()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"a/a\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\optional\\format\\json-pointer.json",
                "{ \"format\": \"json-pointer\" }",
                "JsonSchemaTestSuite.Draft7.Optional.Format.JsonPointer",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "http://json-schema.org/draft-07/schema#",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}