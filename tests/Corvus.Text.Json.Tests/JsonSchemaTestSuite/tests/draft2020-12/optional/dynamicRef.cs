using System.Reflection;
using System.Threading.Tasks;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.Optional.DynamicRef;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteDynamicRefSkipsOverIntermediateResourcesPointerReferenceAcrossResourceBoundary : IClassFixture<SuiteDynamicRefSkipsOverIntermediateResourcesPointerReferenceAcrossResourceBoundary.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteDynamicRefSkipsOverIntermediateResourcesPointerReferenceAcrossResourceBoundary(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestIntegerPropertyPasses()
    {
        var dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"bar-item\": { \"content\": 42 } }");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStringPropertyFails()
    {
        var dynamicInstance = _fixture.DynamicJsonType.ParseInstance("{ \"bar-item\": { \"content\": \"value\" } }");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\optional\\dynamicRef.json",
                "{\r\n        \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n        \"$id\": \"https://test.json-schema.org/dynamic-ref-skips-intermediate-resource/optional/main\",\r\n        \"type\": \"object\",\r\n          \"properties\": {\r\n              \"bar-item\": {\r\n                  \"$ref\": \"bar#/$defs/item\"\r\n              }\r\n          },\r\n          \"$defs\": {\r\n              \"bar\": {\r\n                  \"$id\": \"bar\",\r\n                  \"type\": \"array\",\r\n                  \"items\": {\r\n                      \"$ref\": \"item\"\r\n                  },\r\n                  \"$defs\": {\r\n                      \"item\": {\r\n                          \"$id\": \"item\",\r\n                          \"type\": \"object\",\r\n                          \"properties\": {\r\n                              \"content\": {\r\n                                  \"$dynamicRef\": \"#content\"\r\n                              }\r\n                          },\r\n                          \"$defs\": {\r\n                              \"defaultContent\": {\r\n                                  \"$dynamicAnchor\": \"content\",\r\n                                  \"type\": \"integer\"\r\n                              }\r\n                          }\r\n                      },\r\n                      \"content\": {\r\n                          \"$dynamicAnchor\": \"content\",\r\n                          \"type\": \"string\"\r\n                      }\r\n                  }\r\n              }\r\n          }\r\n      }",
                "JsonSchemaTestSuite.Draft202012.Optional.DynamicRef",
                "D:\\source\\mwadams\\Corvus.Text.Json\\JSON-Schema-Test-Suite\\remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: false,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}
