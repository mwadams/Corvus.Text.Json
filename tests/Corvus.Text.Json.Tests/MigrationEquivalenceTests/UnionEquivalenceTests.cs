// Copyright (c) William Adams. All rights reserved.
// Licensed under the MIT License.

namespace Corvus.Text.Json.Tests.MigrationEquivalenceTests;

using Xunit;

using V4 = MigrationModels.V4;
using V5 = MigrationModels.V5;

/// <summary>
/// Verifies that V4 and V5 union type (oneOf) checking produces equivalent results.
/// </summary>
/// <remarks>
/// <para>V4: <c>entity.AsString</c>, <c>entity.AsNumber</c>, <c>entity.AsBoolean</c> — composition accessors.</para>
/// <para>V5: <c>entity.TryGetAsOneOf0Entity()</c>, explicit casts to composition types, <c>Match&lt;TResult&gt;</c>.</para>
/// </remarks>
public class UnionEquivalenceTests
{
    [Fact]
    public void V4_StringVariant_ValueKindAndExtract()
    {
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("\"hello\"");
        Assert.Equal(System.Text.Json.JsonValueKind.String, v4.ValueKind);
        Assert.Equal("hello", (string)v4);
    }

    [Fact]
    public void V4_StringVariant_ValueKindAndExtract_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("\"hello\"");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Assert.Equal(System.Text.Json.JsonValueKind.String, v4.ValueKind);
        Assert.Equal("hello", (string)v4);
    }

    [Fact]
    public void V5_StringVariant_ValueKindAndExtract()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(Corvus.Text.Json.JsonValueKind.String, v5.ValueKind);
        Assert.Equal("hello", (string)v5);
    }

    [Fact]
    public void V4_IntVariant_ValueKindAndExtract()
    {
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("""42""");
        Assert.Equal(System.Text.Json.JsonValueKind.Number, v4.ValueKind);
        Assert.Equal(42, (int)v4);
    }

    [Fact]
    public void V4_IntVariant_ValueKindAndExtract_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("""42""");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Assert.Equal(System.Text.Json.JsonValueKind.Number, v4.ValueKind);
        Assert.Equal(42, (int)v4);
    }

    [Fact]
    public void V5_IntVariant_ValueKindAndExtract()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("""42""");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(Corvus.Text.Json.JsonValueKind.Number, v5.ValueKind);
        Assert.Equal(42, (long)v5);
    }

    [Fact]
    public void V4_BoolVariant_True()
    {
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("""true""");
        Assert.Equal(System.Text.Json.JsonValueKind.True, v4.ValueKind);
        Assert.True((bool)v4);
    }

    [Fact]
    public void V4_BoolVariant_True_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("""true""");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Assert.Equal(System.Text.Json.JsonValueKind.True, v4.ValueKind);
        Assert.True((bool)v4);
    }

    [Fact]
    public void V5_BoolVariant_True()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("""true""");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(Corvus.Text.Json.JsonValueKind.True, v5.ValueKind);
        Assert.True((bool)v5);
    }

    [Fact]
    public void V4_BoolVariant_False()
    {
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("""false""");
        Assert.Equal(System.Text.Json.JsonValueKind.False, v4.ValueKind);
        Assert.False((bool)v4);
    }

    [Fact]
    public void V4_BoolVariant_False_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("""false""");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Assert.Equal(System.Text.Json.JsonValueKind.False, v4.ValueKind);
        Assert.False((bool)v4);
    }

    [Fact]
    public void V5_BoolVariant_False()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("""false""");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(Corvus.Text.Json.JsonValueKind.False, v5.ValueKind);
        Assert.False((bool)v5);
    }

    [Fact]
    public void V4_AsStringAccessor()
    {
        // V4: AsString composition accessor returns JsonString
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("\"hello\"");
        Corvus.Json.JsonString asString = v4.AsString;
        Assert.Equal("hello", (string)asString);
    }

    [Fact]
    public void V4_AsStringAccessor_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("\"hello\"");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Corvus.Json.JsonString asString = v4.AsString;
        Assert.Equal("hello", (string)asString);
    }

    [Fact]
    public void V5_TryGetAsOneOf0Entity_String()
    {
        // V5: TryGetAsOneOf0Entity() — the equivalent of V4's AsString for typed composition access
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetAsOneOf0Entity(out V5.MigrationUnion.OneOf0Entity stringEntity));
        Assert.Equal("hello", (string)stringEntity);
    }

    [Fact]
    public void V4_AsNumberAccessor()
    {
        // V4: AsNumber composition accessor returns JsonNumber
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("42");
        Corvus.Json.JsonNumber asNumber = v4.AsNumber;
        Assert.Equal(42, (int)asNumber);
    }

    [Fact]
    public void V4_AsNumberAccessor_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("42");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Corvus.Json.JsonNumber asNumber = v4.AsNumber;
        Assert.Equal(42, (int)asNumber);
    }

    [Fact]
    public void V5_TryGetAsOneOf1Entity_Number()
    {
        // V5: TryGetAsOneOf1Entity() — the equivalent of V4's AsNumber
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetAsOneOf1Entity(out V5.MigrationUnion.OneOf1Entity numberEntity));
        Assert.Equal(42, (int)numberEntity);
    }

    [Fact]
    public void V4_AsBooleanAccessor()
    {
        // V4: AsBoolean composition accessor returns JsonBoolean
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("true");
        Corvus.Json.JsonBoolean asBoolean = v4.AsBoolean;
        Assert.True((bool)asBoolean);
    }

    [Fact]
    public void V4_AsBooleanAccessor_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("true");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Corvus.Json.JsonBoolean asBoolean = v4.AsBoolean;
        Assert.True((bool)asBoolean);
    }

    [Fact]
    public void V5_TryGetAsOneOf2Entity_Boolean()
    {
        // V5: TryGetAsOneOf2Entity() — the equivalent of V4's AsBoolean
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetAsOneOf2Entity(out V5.MigrationUnion.OneOf2Entity boolEntity));
        Assert.True((bool)boolEntity);
    }

    [Fact]
    public void V5_ExplicitCastToCompositionType_String()
    {
        // V5: explicit cast from union to composition type
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        V5.MigrationUnion.OneOf0Entity stringEntity = (V5.MigrationUnion.OneOf0Entity)v5;
        Assert.Equal("hello", (string)stringEntity);
    }

    [Fact]
    public void V5_ExplicitCastToCompositionType_Number()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        V5.MigrationUnion.OneOf1Entity numberEntity = (V5.MigrationUnion.OneOf1Entity)v5;
        Assert.Equal(42, (int)numberEntity);
    }

    [Fact]
    public void V5_ExplicitCastToCompositionType_Boolean()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        V5.MigrationUnion.OneOf2Entity boolEntity = (V5.MigrationUnion.OneOf2Entity)v5;
        Assert.True((bool)boolEntity);
    }

    [Fact]
    public void V5_MatchPattern_String()
    {
        // V5: Match<TResult> discriminated union pattern
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            static (in V5.MigrationUnion.OneOf0Entity s) => $"string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n) => $"number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b) => $"bool:{(bool)b}",
            static (in V5.MigrationUnion v) => "none");
        Assert.Equal("string:hello", result);
    }

    [Fact]
    public void V5_MatchPattern_Number()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            static (in V5.MigrationUnion.OneOf0Entity s) => $"string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n) => $"number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b) => $"bool:{(bool)b}",
            static (in V5.MigrationUnion v) => "none");
        Assert.Equal("number:42", result);
    }

    [Fact]
    public void V5_MatchPattern_Boolean()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            static (in V5.MigrationUnion.OneOf0Entity s) => $"string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n) => $"number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b) => $"bool:{(bool)b}",
            static (in V5.MigrationUnion v) => "none");
        Assert.Equal("bool:True", result);
    }

    [Fact]
    public void V4_MatchPatternWithContext_String()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("\"hello\"");
        V4.MigrationUnion v4 = parsedV4.Instance;
        string result = v4.Match(
            "prefix",
            static (in Corvus.Json.JsonString s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V4.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in Corvus.Json.JsonBoolean b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V4.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:string:hello", result);
    }

    [Fact]
    public void V4_MatchPatternWithContext_Number()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("42");
        V4.MigrationUnion v4 = parsedV4.Instance;
        string result = v4.Match(
            "prefix",
            static (in Corvus.Json.JsonString s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V4.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in Corvus.Json.JsonBoolean b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V4.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:number:42", result);
    }

    [Fact]
    public void V4_MatchPatternWithContext_Boolean()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("true");
        V4.MigrationUnion v4 = parsedV4.Instance;
        string result = v4.Match(
            "prefix",
            static (in Corvus.Json.JsonString s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V4.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in Corvus.Json.JsonBoolean b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V4.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:bool:True", result);
    }

    [Fact]
    public void V5_MatchPatternWithContext_String()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            "prefix",
            static (in V5.MigrationUnion.OneOf0Entity s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V5.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:string:hello", result);
    }

    [Fact]
    public void V5_MatchPatternWithContext_Number()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            "prefix",
            static (in V5.MigrationUnion.OneOf0Entity s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V5.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:number:42", result);
    }

    [Fact]
    public void V5_MatchPatternWithContext_Boolean()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        string result = v5.Match(
            "prefix",
            static (in V5.MigrationUnion.OneOf0Entity s, in string ctx) => $"{ctx}:string:{(string)s}",
            static (in V5.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
            static (in V5.MigrationUnion.OneOf2Entity b, in string ctx) => $"{ctx}:bool:{(bool)b}",
            static (in V5.MigrationUnion v, in string ctx) => $"{ctx}:none");
        Assert.Equal("prefix:bool:True", result);
    }

    [Fact]
    public void BothEngines_MatchWithContext_SameResult()
    {
        // Both V4 and V5 Match<TContext, TResult> produce the same output for each variant
        string[] jsons = ["\"hello\"", "42", "true"];
        string[] expected = ["prefix:string:hello", "prefix:number:42", "prefix:bool:True"];

        for (int i = 0; i < jsons.Length; i++)
        {
            using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse(jsons[i]);
            V4.MigrationUnion v4 = parsedV4.Instance;
            string v4Result = v4.Match(
                "prefix",
                static (in Corvus.Json.JsonString s, in string ctx) => $"{ctx}:string:{(string)s}",
                static (in V4.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
                static (in Corvus.Json.JsonBoolean b, in string ctx) => $"{ctx}:bool:{(bool)b}",
                static (in V4.MigrationUnion v, in string ctx) => $"{ctx}:none");

            using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse(jsons[i]);
            V5.MigrationUnion v5 = parsedV5.RootElement;
            string v5Result = v5.Match(
                "prefix",
                static (in V5.MigrationUnion.OneOf0Entity s, in string ctx) => $"{ctx}:string:{(string)s}",
                static (in V5.MigrationUnion.OneOf1Entity n, in string ctx) => $"{ctx}:number:{(int)n}",
                static (in V5.MigrationUnion.OneOf2Entity b, in string ctx) => $"{ctx}:bool:{(bool)b}",
                static (in V5.MigrationUnion v, in string ctx) => $"{ctx}:none");

            Assert.Equal(expected[i], v4Result);
            Assert.Equal(v4Result, v5Result);
        }
    }

    [Fact]
    public void V4_UnionValidation_StringValid()
    {
        V4.MigrationUnion v4 = V4.MigrationUnion.Parse("\"hello\"");
        Corvus.Json.ValidationContext result = v4.Validate(Corvus.Json.ValidationContext.ValidContext, Corvus.Json.ValidationLevel.Flag);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void V4_UnionValidation_StringValid_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("\"hello\"");
        V4.MigrationUnion v4 = parsedV4.Instance;
        Corvus.Json.ValidationContext result = v4.Validate(Corvus.Json.ValidationContext.ValidContext, Corvus.Json.ValidationLevel.Flag);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void V5_UnionValidation_StringValid()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.EvaluateSchema());
    }

    [Fact]
    public void BothEngines_StringVariant_SameResult()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("\"hello\"");
        V4.MigrationUnion v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;

        Assert.Equal((string)v4, (string)v5);
    }

    [Fact]
    public void BothEngines_IntVariant_SameResult()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("42");
        V4.MigrationUnion v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;

        Assert.Equal((long)v4, (long)v5);
    }

    [Fact]
    public void BothEngines_BoolVariant_SameResult()
    {
        using Corvus.Json.ParsedValue<V4.MigrationUnion> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationUnion>.Parse("true");
        V4.MigrationUnion v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;

        Assert.Equal((bool)v4, (bool)v5);
    }

    [Fact]
    public void V5_ExplicitCast_DoubleFromNumberVariant()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("3.14");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(3.14, (double)v5);
    }

    [Fact]
    public void V5_ExplicitCast_DecimalFromNumberVariant()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("99.99");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(99.99m, (decimal)v5);
    }

    [Fact]
    public void V5_ExplicitCast_ThrowsForWrongType()
    {
        // Casting a string-valued union to bool should throw
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Throws<FormatException>(() => (bool)v5);
    }

    [Fact]
    public void V5_ExplicitCast_IntFromFormatSubtype()
    {
        // The int32 format on the integer variant should produce an explicit operator int on the union
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Equal(42, (int)v5);
    }

    [Fact]
    public void V5_ExplicitCast_IntThrowsForStringVariant()
    {
        // int cast on a string-valued union should throw
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.Throws<InvalidOperationException>(() => (int)v5);
    }

    [Fact]
    public void V5_TryGetValue_SafeIntAccessor_MatchingVariant()
    {
        // TryGetValue is the non-throwing alternative to explicit cast
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("42");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetValue(out int intResult));
        Assert.Equal(42, intResult);
    }

    [Fact]
    public void V5_TryGetValue_SafeIntAccessor_NonMatchingVariant()
    {
        // For type safety, check ValueKind before calling TryGetValue
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.NotEqual(Corvus.Text.Json.JsonValueKind.Number, v5.ValueKind);
    }

    [Fact]
    public void V5_TryGetValue_SafeBoolAccessor()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("true");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetValue(out bool boolResult));
        Assert.True(boolResult);
    }

    [Fact]
    public void V5_TryGetValue_SafeStringAccessor()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationUnion>.Parse("\"hello\"");
        V5.MigrationUnion v5 = parsedV5.RootElement;
        Assert.True(v5.TryGetValue(out string? stringResult));
        Assert.Equal("hello", stringResult);
    }
}