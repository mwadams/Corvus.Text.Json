// Copyright (c) William Adams. All rights reserved.
// Licensed under the MIT License.

namespace Corvus.Text.Json.Tests.MigrationEquivalenceTests;

using Corvus.Json;
using Xunit;

using V4 = MigrationModels.V4;
using V5 = MigrationModels.V5;

/// <summary>
/// Verifies that V4 and V5 enum value handling produces equivalent results.
/// </summary>
/// <remarks>
/// <para>V4: <c>MigrationStatusEnum.EnumValues.Active</c> (public named constants)</para>
/// <para>V5: Constants are private; use <c>ParseValue()</c> with the literal value</para>
/// </remarks>
public class EnumConstEquivalenceTests
{
    [Fact]
    public void V4_ParseValidEnumValue()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"active\"");
        Assert.Equal(System.Text.Json.JsonValueKind.String, v4.ValueKind);
        Assert.Equal("active", (string)v4);
    }

    [Fact]
    public void V4_ParseValidEnumValue_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        Assert.Equal(System.Text.Json.JsonValueKind.String, v4.ValueKind);
        Assert.Equal("active", (string)v4);
    }

    [Fact]
    public void V5_ParseValidEnumValue()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        Assert.Equal(Corvus.Text.Json.JsonValueKind.String, v5.ValueKind);
        Assert.Equal("active", (string)v5);
    }

    [Fact]
    public void V4_AllEnumValuesValid()
    {
        foreach (string enumValue in new[] { "active", "inactive", "pending" })
        {
            V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse($"\"{enumValue}\"");
            ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
            Assert.True(result.IsValid, $"Expected '{enumValue}' to be valid in V4");
        }
    }

    [Fact]
    public void V4_AllEnumValuesValid_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        foreach (string enumValue in new[] { "active", "inactive", "pending" })
        {
            using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse($"\"{enumValue}\"");
            V4.MigrationStatusEnum v4 = parsedV4.Instance;
            ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
            Assert.True(result.IsValid, $"Expected '{enumValue}' to be valid in V4");
        }
    }

    [Fact]
    public void V5_AllEnumValuesValid()
    {
        foreach (string enumValue in new[] { "active", "inactive", "pending" })
        {
            using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse($"\"{enumValue}\"");
            V5.MigrationStatusEnum v5 = parsedV5.RootElement;
            Assert.True(v5.EvaluateSchema(), $"Expected '{enumValue}' to be valid in V5");
        }
    }

    [Fact]
    public void V4_InvalidEnumValue()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"unknown\"");
        ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void V4_InvalidEnumValue_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"unknown\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void V5_InvalidEnumValue()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"unknown\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        Assert.False(v5.EvaluateSchema());
    }

    [Fact]
    public void V4_ExtractStringValue()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"pending\"");
        string extracted = (string)v4;
        Assert.Equal("pending", extracted);
    }

    [Fact]
    public void V4_ExtractStringValue_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"pending\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        string extracted = (string)v4;
        Assert.Equal("pending", extracted);
    }

    [Fact]
    public void V5_ExtractStringValue()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"pending\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        string extracted = (string)v5;
        Assert.Equal("pending", extracted);
    }

    [Fact]
    public void V4_WrongType_IsInvalid()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("""42""");
        ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void V4_WrongType_IsInvalid_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("""42""");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        ValidationContext result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void V5_WrongType_IsInvalid()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("""42""");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        Assert.False(v5.EvaluateSchema());
    }

    [Fact]
    public void BothEngines_ParseValidEnum_SameResult()
    {
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;

        Assert.Equal((string)v4, (string)v5);
    }

    [Fact]
    public void BothEngines_InvalidEnum_SameValidationResult()
    {
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"unknown\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        ValidationContext v4Result = v4.Validate(ValidationContext.ValidContext, ValidationLevel.Flag);

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"unknown\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;

        Assert.Equal(v4Result.IsValid, v5.EvaluateSchema());
    }

    [Fact]
    public void V4_NamedEnumValues()
    {
        // V4: named static properties for each enum value in the EnumValues nested class.
        Assert.Equal("active", (string)V4.MigrationStatusEnum.EnumValues.Active);
        Assert.Equal("inactive", (string)V4.MigrationStatusEnum.EnumValues.Inactive);
        Assert.Equal("pending", (string)V4.MigrationStatusEnum.EnumValues.Pending);
    }

    [Fact]
    public void V5_NamedEnumValues()
    {
        // V5: enum values are not exposed as named static properties.
        // Verify by parsing and extracting the string value.
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedActive = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        Assert.Equal("active", (string)parsedActive.RootElement);

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedInactive = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"inactive\"");
        Assert.Equal("inactive", (string)parsedInactive.RootElement);

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedPending = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"pending\"");
        Assert.Equal("pending", (string)parsedPending.RootElement);
    }

    [Fact]
    public void V4_EnumMatch()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"active\"");
        string result = v4.Match(
            () => "is-active",
            () => "is-inactive",
            () => "is-pending",
            () => "unknown");
        Assert.Equal("is-active", result);
    }

    [Fact]
    public void V4_EnumMatch_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        string result = v4.Match(
            () => "is-active",
            () => "is-inactive",
            () => "is-pending",
            () => "unknown");
        Assert.Equal("is-active", result);
    }

    [Fact]
    public void V5_EnumMatch()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        string result = v5.Match(
            () => "is-active",
            () => "is-inactive",
            () => "is-pending",
            () => "unknown");
        Assert.Equal("is-active", result);
    }

    [Fact]
    public void V4_GetString()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"active\"");
        string? value = v4.GetString();
        Assert.Equal("active", value);
    }

    [Fact]
    public void V4_GetString_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        string? value = v4.GetString();
        Assert.Equal("active", value);
    }

    [Fact]
    public void V5_GetString_ViaExplicitCast()
    {
        // V5: use explicit cast to extract string — equivalent to V4 GetString().
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        string value = (string)v5;
        Assert.Equal("active", value);
    }

    [Fact]
    public void V4_TryGetString()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"active\"");
        Assert.True(v4.TryGetString(out string? value));
        Assert.Equal("active", value);
    }

    [Fact]
    public void V4_TryGetString_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        Assert.True(v4.TryGetString(out string? value));
        Assert.Equal("active", value);
    }

    [Fact]
    public void V4_ConstructFromString()
    {
        // V4: implicit operator converts string to enum type.
        V4.MigrationStatusEnum v4 = (V4.MigrationStatusEnum)"active";
        Assert.Equal("active", (string)v4);
    }

    [Fact]
    public void V5_ConstructFromString()
    {
        // V5: use Parse() to construct from a JSON string literal.
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        V5.MigrationStatusEnum v5 = parsedV5.RootElement;
        Assert.Equal("active", (string)v5);
    }

    [Fact]
    public void V4_EqualsString()
    {
        V4.MigrationStatusEnum v4 = V4.MigrationStatusEnum.Parse("\"active\"");
        Assert.True(v4.EqualsString("active"));
        Assert.False(v4.EqualsString("inactive"));
    }

    [Fact]
    public void V4_EqualsString_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationStatusEnum> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationStatusEnum>.Parse("\"active\"");
        V4.MigrationStatusEnum v4 = parsedV4.Instance;
        Assert.True(v4.EqualsString("active"));
        Assert.False(v4.EqualsString("inactive"));
    }

    [Fact]
    public void V5_EqualsString_ViaEquals()
    {
        // V5: use Equals<T>() for comparison — equivalent to V4 EqualsString().
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5A = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5B = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"active\"");
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum> parsedV5C = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationStatusEnum>.Parse("\"inactive\"");

        Assert.True(parsedV5A.RootElement.Equals(parsedV5B.RootElement));
        Assert.False(parsedV5A.RootElement.Equals(parsedV5C.RootElement));
    }
}
