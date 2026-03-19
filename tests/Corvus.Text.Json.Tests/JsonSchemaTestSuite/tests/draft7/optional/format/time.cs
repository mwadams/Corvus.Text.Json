using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft7.Optional.Format.Time;

[Trait("JsonSchemaTestSuite", "Draft7")]
public class SuiteValidationOfTimeStrings : IClassFixture<SuiteValidationOfTimeStrings.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfTimeStrings(Fixture fixture)
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
    public void TestAValidTimeString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06Z\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidTimeStringWithExtraLeadingZeros()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"008:030:006Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidTimeStringWithNoLeadingZeroForSingleDigit()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"8:3:6Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHourMinuteSecondMustBeTwoDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"8:0030:6Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidTimeStringWithSecondFraction()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"23:20:50.52Z\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidTimeStringWithPreciseSecondFraction()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06.283185Z\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidTimeStringWithPlusOffset()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06+00:20\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidTimeStringWithMinusOffset()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06-08:00\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHourMinuteInTimeOffsetMustBeTwoDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06-8:000\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidTimeStringWithCaseInsensitiveZ()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06z\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidHour()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"24:00:00Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidMinute()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"00:60:00Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidSecond()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"00:00:61Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidTimeNumoffsetHour()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"01:02:03+24:00\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidTimeNumoffsetMinute()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"01:02:03+00:60\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringWithInvalidTimeWithBothZAndNumoffset()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"01:02:03Z+00:30\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidOffsetIndicator()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06 PST\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOnlyRfc3339NotAllOfIso8601AreValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"01:01:01,1111\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoTimeOffset()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"12:00:00\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNoTimeOffsetWithSecondFraction()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"12:00:00.52\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidNonAscii২ABengali2()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1২:00:00Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOffsetNotStartingWithPlusOrMinus()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"08:30:06#00:20\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestContainsLetters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"ab:cd:ef\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidTimeStringInDateTimeFormat()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-11-28T23:55:45Z\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft7\\optional\\format\\time.json",
                "{ \"format\": \"time\" }",
                "JsonSchemaTestSuite.Draft7.Optional.Format.Time",
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