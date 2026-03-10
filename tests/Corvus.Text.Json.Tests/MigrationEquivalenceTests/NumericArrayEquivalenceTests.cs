// Copyright (c) William Adams. All rights reserved.
// Licensed under the MIT License.

namespace Corvus.Text.Json.Tests.MigrationEquivalenceTests;

using Xunit;

using V4 = MigrationModels.V4;
using V5 = MigrationModels.V5;

/// <summary>
/// Verifies that V4 and V5 numeric array (vector) operations produce equivalent results.
/// </summary>
/// <remarks>
/// <para>Both V4 and V5: <c>vector.TryGetNumericValues(Span&lt;int&gt;, out int written)</c></para>
/// <para>V4: <c>Vector.FromValues(ReadOnlySpan&lt;int&gt;)</c> — no V5 equivalent</para>
/// </remarks>
public class NumericArrayEquivalenceTests
{
    private const string VectorJson = """[10,20,30]""";

    [Fact]
    public void V4_TryGetNumericValues()
    {
        V4.MigrationIntVector v4 = V4.MigrationIntVector.Parse(VectorJson);
        Span<int> values = stackalloc int[3];
        Assert.True(v4.TryGetNumericValues(values, out int written));
        Assert.Equal(3, written);
        Assert.Equal(10, values[0]);
        Assert.Equal(20, values[1]);
        Assert.Equal(30, values[2]);
    }

    [Fact]
    public void V4_TryGetNumericValues_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationIntVector> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationIntVector>.Parse(VectorJson);
        V4.MigrationIntVector v4 = parsedV4.Instance;
        Span<int> values = stackalloc int[3];
        Assert.True(v4.TryGetNumericValues(values, out int written));
        Assert.Equal(3, written);
        Assert.Equal(10, values[0]);
        Assert.Equal(20, values[1]);
        Assert.Equal(30, values[2]);
    }

    [Fact]
    public void V5_TryGetNumericValues()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector>.Parse(VectorJson);
        V5.MigrationIntVector v5 = parsedV5.RootElement;
        Span<int> values = stackalloc int[3];
        Assert.True(v5.TryGetNumericValues(values, out int written));
        Assert.Equal(3, written);
        Assert.Equal(10, values[0]);
        Assert.Equal(20, values[1]);
        Assert.Equal(30, values[2]);
    }

    [Fact]
    public void V4_ElementAccess()
    {
        V4.MigrationIntVector v4 = V4.MigrationIntVector.Parse(VectorJson);
        Assert.Equal(10, (int)v4[0]);
        Assert.Equal(20, (int)v4[1]);
        Assert.Equal(30, (int)v4[2]);
    }

    [Fact]
    public void V4_ElementAccess_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationIntVector> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationIntVector>.Parse(VectorJson);
        V4.MigrationIntVector v4 = parsedV4.Instance;
        Assert.Equal(10, (int)v4[0]);
        Assert.Equal(20, (int)v4[1]);
        Assert.Equal(30, (int)v4[2]);
    }

    [Fact]
    public void V5_ElementAccess()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector>.Parse(VectorJson);
        V5.MigrationIntVector v5 = parsedV5.RootElement;
        Assert.Equal(10, (int)v5[0]);
        Assert.Equal(20, (int)v5[1]);
        Assert.Equal(30, (int)v5[2]);
    }

    [Fact]
    public void V4_DimensionAndRank()
    {
        Assert.Equal(1, V4.MigrationIntVector.Rank);
        Assert.Equal(3, V4.MigrationIntVector.Dimension);
        Assert.Equal(3, V4.MigrationIntVector.ValueBufferSize);
    }

    [Fact]
    public void V5_DimensionAndRank()
    {
        Assert.Equal(1, V5.MigrationIntVector.Rank);
        Assert.Equal(3, V5.MigrationIntVector.Dimension);
        Assert.Equal(3, V5.MigrationIntVector.ValueBufferSize);
    }

    [Fact]
    public void V4_GetArrayLength()
    {
        V4.MigrationIntVector v4 = V4.MigrationIntVector.Parse(VectorJson);
        Assert.Equal(3, v4.GetArrayLength());
    }

    [Fact]
    public void V4_GetArrayLength_ParsedValue()
    {
        // Preferred V4 pattern: ParsedValue<T> manages the underlying JsonDocument lifetime.
        using Corvus.Json.ParsedValue<V4.MigrationIntVector> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationIntVector>.Parse(VectorJson);
        V4.MigrationIntVector v4 = parsedV4.Instance;
        Assert.Equal(3, v4.GetArrayLength());
    }

    [Fact]
    public void V5_GetArrayLength()
    {
        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector>.Parse(VectorJson);
        V5.MigrationIntVector v5 = parsedV5.RootElement;
        Assert.Equal(3, v5.GetArrayLength());
    }

    [Fact]
    public void BothEngines_SameNumericValues()
    {
        using Corvus.Json.ParsedValue<V4.MigrationIntVector> parsedV4 = Corvus.Json.ParsedValue<V4.MigrationIntVector>.Parse(VectorJson);
        V4.MigrationIntVector v4 = parsedV4.Instance;

        using Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector> parsedV5 = Corvus.Text.Json.ParsedJsonDocument<V5.MigrationIntVector>.Parse(VectorJson);
        V5.MigrationIntVector v5 = parsedV5.RootElement;

        Span<int> v4Values = stackalloc int[3];
        Span<int> v5Values = stackalloc int[3];

        Assert.True(v4.TryGetNumericValues(v4Values, out int v4Written));
        Assert.True(v5.TryGetNumericValues(v5Values, out int v5Written));

        Assert.Equal(v4Written, v5Written);
        for (int i = 0; i < v4Written; i++)
        {
            Assert.Equal(v4Values[i], v5Values[i]);
        }
    }
}
