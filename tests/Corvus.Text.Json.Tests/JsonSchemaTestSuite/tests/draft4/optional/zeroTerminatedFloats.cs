using System.Reflection;
using System.Threading.Tasks;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft4.Optional.ZeroTerminatedFloats;

[Trait("JsonSchemaTestSuite", "Draft4")]
public class SuiteSomeLanguagesDoNotDistinguishBetweenDifferentTypesOfNumericValue : IClassFixture<SuiteSomeLanguagesDoNotDistinguishBetweenDifferentTypesOfNumericValue.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteSomeLanguagesDoNotDistinguishBetweenDifferentTypesOfNumericValue(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestAFloatIsNotAnIntegerEvenWithoutFractionalPart()
    {
        var dynamicInstance = _fixture.DynamicJsonType.ParseInstance("1.0");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft4\\optional\\zeroTerminatedFloats.json",
                "{\r\n            \"type\": \"integer\"\r\n        }",
                "JsonSchemaTestSuite.Draft4.Optional.ZeroTerminatedFloats",
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
