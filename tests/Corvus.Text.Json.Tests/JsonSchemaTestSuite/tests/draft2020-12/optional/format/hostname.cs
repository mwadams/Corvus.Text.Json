using System.Reflection;
using System.Threading.Tasks;
using Corvus.Text.Json.Validator;
using TestUtilities;
using Xunit;

namespace JsonSchemaTestSuite.Draft202012.Optional.Format.Hostname;

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteValidationOfHostNames : IClassFixture<SuiteValidationOfHostNames.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfHostNames(Fixture fixture)
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
    public void TestAValidHostName()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"www.example.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabel()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostname\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelWithDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"h0stn4me\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelStartingWithDigit()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"1host\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelEndingWithDigit()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostnam3\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEmptyString()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\".\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestLeadingDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\".example\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestTrailingDot()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"example.\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestIdnLabelSeparator()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"example\\uff0ecom\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestSingleLabelWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"host-name\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestStartsWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"-hostname\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestEndsWithHyphen()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"hostname-\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestContainsInThe3rdAnd4thPosition()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"XN--aa---o47jg78q\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestContainsUnderscore()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"host_name\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceedsMaximumOverallLength256()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMaximumLabelLength63()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceedsMaximumLabelLength63()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijkl.com\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\optional\\format\\hostname.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"format\": \"hostname\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Optional.Format.Hostname",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}

[Trait("JsonSchemaTestSuite", "Draft202012")]
public class SuiteValidationOfALabelPunycodeHostNames : IClassFixture<SuiteValidationOfALabelPunycodeHostNames.Fixture>
{
    private readonly Fixture _fixture;
    public SuiteValidationOfALabelPunycodeHostNames(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestInvalidPunycode()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--X\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestAValidHostNameExampleTestInHangul()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--9n2bp8q.xn--9t4b11yi5a\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestContainsIllegalCharU302eHangulSingleDotToneMark()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--07jt112bpxg.xn--9t4b11yi5a\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBeginsWithASpacingCombiningMark()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--hello-txk\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBeginsWithANonspacingMark()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--hello-zed\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestBeginsWithAnEnclosingMark()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--hello-6bf\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceptionsThatArePvalidLeftToRightChars()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--zca29lwxobi7a\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceptionsThatArePvalidRightToLeftChars()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--qmbc\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceptionsThatAreDisallowedRightToLeftChars()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--chb89f\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExceptionsThatAreDisallowedLeftToRightChars()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--07jceefgh4c\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMiddleDotWithNoPrecedingL()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--al-0ea\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMiddleDotWithNothingPreceding()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--l-fda\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMiddleDotWithNoFollowingL()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--la-0ea\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMiddleDotWithNothingFollowing()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--l-gda\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestMiddleDotWithSurroundingLS()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--ll-0ea\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestGreekKeraiaNotFollowedByGreek()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--S-jib3p\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestGreekKeraiaNotFollowedByAnything()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--wva3j\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestGreekKeraiaFollowedByGreek()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--wva3je\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGereshNotPrecededByHebrew()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--A-2hc5h\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGereshNotPrecededByAnything()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--5db1e\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGereshPrecededByHebrew()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--4dbc5h\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGershayimNotPrecededByHebrew()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--A-2hc8h\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGershayimNotPrecededByAnything()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--5db3e\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestHebrewGershayimPrecededByHebrew()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--4dbc8h\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestKatakanaMiddleDotWithNoHiraganaKatakanaOrHan()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--defabc-k64e\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestKatakanaMiddleDotWithNoOtherCharacters()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--vek\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestKatakanaMiddleDotWithHiragana()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--k8j5u\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestKatakanaMiddleDotWithKatakana()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--bck0j\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestKatakanaMiddleDotWithHan()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--vek778f\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestArabicIndicDigitsMixedWithExtendedArabicIndicDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--ngb6iyr\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestArabicIndicDigitsNotMixedWithExtendedArabicIndicDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--ngba1o\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestExtendedArabicIndicDigitsNotMixedWithArabicIndicDigits()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--0-gyc\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroWidthJoinerNotPrecededByVirama()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--11b2er09f\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroWidthJoinerNotPrecededByAnything()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--02b508i\"");
        Assert.False(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroWidthJoinerPrecededByVirama()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--11b2ezcw70k\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroWidthNonJoinerPrecededByVirama()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--11b2ezcs70k\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    [Fact]
    public void TestZeroWidthNonJoinerNotPrecededByViramaButMatchesRegexp()
    {
        DynamicJsonElement dynamicInstance = _fixture.DynamicJsonType.ParseInstance("\"xn--ngba5hb2804a\"");
        Assert.True(dynamicInstance.EvaluateSchema());
    }

    public class Fixture : IAsyncLifetime
    {
        public DynamicJsonType DynamicJsonType { get; private set; }

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            this.DynamicJsonType = await TestJsonSchemaCodeGenerator.GenerateTypeForVirtualFile(
                "tests\\draft2020-12\\optional\\format\\hostname.json",
                "{\r\n            \"$schema\": \"https://json-schema.org/draft/2020-12/schema\",\r\n            \"format\": \"hostname\"\r\n        }",
                "JsonSchemaTestSuite.Draft202012.Optional.Format.Hostname",
                "../../../../../JSON-Schema-Test-Suite/remotes",
                "https://json-schema.org/draft/2020-12/schema",
                validateFormat: true,
                optionalAsNullable: false,
                useImplicitOperatorString: false,
                addExplicitUsings: false,
                Assembly.GetExecutingAssembly());
        }
    }
}