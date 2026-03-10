// Copyright (c) William Adams. All rights reserved.
// Licensed under the MIT License.

namespace Corvus.Text.Json.Tests.MigrationEquivalenceTests;

using Xunit;

using V4 = MigrationModels.V4;
using V5 = MigrationModels.V5;

/// <summary>
/// Verifies that V4 and V5 closed tuple access produces equivalent results.
/// </summary>
/// <remarks>
/// <para>V4: <c>tuple.Item1</c> (named accessor), <c>tuple.Item2</c>, <c>tuple.Item3</c></para>
/// <para>V5: <c>tuple.Item1</c> (typed property), <c>tuple.Item2</c>, <c>tuple.Item3</c> — or <c>tuple[0]</c> (index accessor)</para>
/// </remarks>
public class TupleEquivalenceTests
{
    private const string TupleJson = """["hello",42,true]""";

    [Fact]
    public void V4_AccessElement0_String()
    {
        V4.MigrationTuple v4 = V4.MigrationTuple.Parse(TupleJson);
        string value = (string)v4.Item1;
        Assert.Equal("hello", value);
    }

    [Fact]
    public void V4_AccessElement0_String_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationTuple> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationTuple>.Parse(TupleJson);
        V4.MigrationTuple v4 = parsedV4.Instance;
        string value = (string)v4.Item1;
        Assert.Equal("hello", value);
    }

    [Fact]
    public void V5_AccessElement0_String()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;
        // V5: typed Item1 property — direct parity with V4
        Assert.True(v5.Item1.TryGetValue(out string? value));
        Assert.Equal("hello", value);
    }

    [Fact]
    public void V4_AccessElement1_Int()
    {
        V4.MigrationTuple v4 = V4.MigrationTuple.Parse(TupleJson);
        int value = (int)v4.Item2;
        Assert.Equal(42, value);
    }

    [Fact]
    public void V4_AccessElement1_Int_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationTuple> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationTuple>.Parse(TupleJson);
        V4.MigrationTuple v4 = parsedV4.Instance;
        int value = (int)v4.Item2;
        Assert.Equal(42, value);
    }

    [Fact]
    public void V5_AccessElement1_Int()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;
        // V5: typed Item2 property with implicit int conversion
        Assert.Equal(42, (int)v5.Item2);
    }

    [Fact]
    public void V4_AccessElement2_Bool()
    {
        V4.MigrationTuple v4 = V4.MigrationTuple.Parse(TupleJson);
        bool value = (bool)v4.Item3;
        Assert.True(value);
    }

    [Fact]
    public void V4_AccessElement2_Bool_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationTuple> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationTuple>.Parse(TupleJson);
        V4.MigrationTuple v4 = parsedV4.Instance;
        bool value = (bool)v4.Item3;
        Assert.True(value);
    }

    [Fact]
    public void V5_AccessElement2_Bool()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;
        // V5: typed Item3 property with TryGetValue
        Assert.True(v5.Item3.TryGetValue(out bool value));
        Assert.True(value);
    }

    [Fact]
    public void V5_AccessViaIndexer()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;
        // V5 also supports int indexer returning JsonElement
        Assert.Equal(Corvus.Text.Json.JsonValueKind.String, v5[0].ValueKind);
        Assert.Equal(Corvus.Text.Json.JsonValueKind.Number, v5[1].ValueKind);
        Assert.Equal(Corvus.Text.Json.JsonValueKind.True, v5[2].ValueKind);
    }

    [Fact]
    public void V4_TupleLength()
    {
        V4.MigrationTuple v4 = V4.MigrationTuple.Parse(TupleJson);
        Assert.Equal(3, v4.GetArrayLength());
    }

    [Fact]
    public void V4_TupleLength_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationTuple> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationTuple>.Parse(TupleJson);
        V4.MigrationTuple v4 = parsedV4.Instance;
        Assert.Equal(3, v4.GetArrayLength());
    }

    [Fact]
    public void V5_TupleLength()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;
        Assert.Equal(3, v5.GetArrayLength());
    }

    [Fact]
    public void BothEngines_SameTupleElements()
    {
        using Corvus.Json.ParsedValue<V4.MigrationTuple> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationTuple>.Parse(TupleJson);
        V4.MigrationTuple v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationTuple>.Parse(TupleJson);
        V5.MigrationTuple v5 = parsedV5.RootElement;

        Assert.Equal((string)v4.Item1, (string)v5.Item1);
        Assert.Equal((int)v4.Item2, (int)v5.Item2);
        Assert.Equal((bool)v4.Item3, (bool)v5.Item3);
    }
}