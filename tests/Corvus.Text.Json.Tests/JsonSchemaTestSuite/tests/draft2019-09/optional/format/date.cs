using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft201909.Optional.Format.Date;

[Trait("JsonSchemaTestSuite", "Draft201909")]
public class SuiteValidationOfDateStrings : IClassFixture<SuiteValidationOfDateStrings.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfDateStrings(Fixture fixture)
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
    public void TestAValidDateString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1963-06-19\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInJanuary()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-01-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInJanuary()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-01-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith28DaysInFebruaryNormal()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2021-02-28\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith29DaysInFebruaryNormal()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2021-02-29\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith29DaysInFebruaryLeap()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-02-29\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith30DaysInFebruaryLeap()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-02-30\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInMarch()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-03-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInMarch()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-03-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith30DaysInApril()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-04-30\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith31DaysInApril()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-04-31\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInMay()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-05-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInMay()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-05-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith30DaysInJune()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-06-30\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith31DaysInJune()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-06-31\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInJuly()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-07-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInJuly()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-07-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInAugust()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-08-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInAugust()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-08-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith30DaysInSeptember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-09-30\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith31DaysInSeptember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-09-31\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInOctober()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-10-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInOctober()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-10-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith30DaysInNovember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-11-30\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith31DaysInNovember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-11-31\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidDateStringWith31DaysInDecember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-12-31\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWith32DaysInDecember()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-12-32\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAInvalidDateStringWithInvalidMonth()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-13-01\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAnInvalidDateString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"06/19/1963\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestOnlyRfc3339NotAllOfIso8601AreValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2013-350\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonPaddedMonthDatesAreNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1998-1-20\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestNonPaddedDayDatesAreNotValid()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1998-01-1\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidMonth()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1998-13-01\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidMonthDayCombination()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1998-04-31\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test2021IsNotALeapYear()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2021-02-29\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void Test2020IsALeapYear()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2020-02-29\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestInvalidNonAscii৪ABengali4()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1963-06-1৪\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIso8601NonRfc3339YyyymmddWithoutDashes20230328()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"20230328\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIso8601NonRfc3339WeekNumberImplicitDayOfWeek20230102()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2023-W01\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIso8601NonRfc3339WeekNumberWithDayOfWeek20230328()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2023-W13-2\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIso8601NonRfc3339WeekNumberRolloverToNextYear20230101()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"2022W527\"");
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
                "tests\\draft2019-09\\optional\\format\\date.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2019-09/schema\",\r\n            \"format\": \"date\"\r\n        }",
                "JsonSchemaTestSuite.Draft201909.Optional.Format.Date",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2019-09/schema",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}