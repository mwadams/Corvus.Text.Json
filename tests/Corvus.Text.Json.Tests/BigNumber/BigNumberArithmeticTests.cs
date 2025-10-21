// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Numerics;
using Xunit;

namespace Corvus.Text.Json.Tests.BigNumberTests;

/// <summary>
/// Tests for BigNumber arithmetic operations.
/// </summary>
public class BigNumberArithmeticTests
{
    [Theory]
    [MemberData(nameof(BigNumberTestData.AdditionData), MemberType = typeof(BigNumberTestData))]
    public void Addition_WithVariousInputs_ShouldWorkCorrectly(
        BigInteger s1, int e1,
        BigInteger s2, int e2,
        BigInteger expectedS, int expectedE)
    {
        // Arrange
        var bn1 = new Corvus.Text.Json.BigNumber(s1, e1);
        var bn2 = new Corvus.Text.Json.BigNumber(s2, e2);
        var expected = new Corvus.Text.Json.BigNumber(expectedS, expectedE);

        // Act
        var result = bn1 + bn2;

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(BigNumberTestData.SubtractionData), MemberType = typeof(BigNumberTestData))]
    public void Subtraction_WithVariousInputs_ShouldWorkCorrectly(
        BigInteger s1, int e1,
        BigInteger s2, int e2,
        BigInteger expectedS, int expectedE)
    {
        // Arrange
        var bn1 = new Corvus.Text.Json.BigNumber(s1, e1);
        var bn2 = new Corvus.Text.Json.BigNumber(s2, e2);
        var expected = new Corvus.Text.Json.BigNumber(expectedS, expectedE);

        // Act
        var result = bn1 - bn2;

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(BigNumberTestData.MultiplicationData), MemberType = typeof(BigNumberTestData))]
    public void Multiplication_WithVariousInputs_ShouldWorkCorrectly(
        BigInteger s1, int e1,
        BigInteger s2, int e2,
        BigInteger expectedS, int expectedE)
    {
        // Arrange
        var bn1 = new Corvus.Text.Json.BigNumber(s1, e1);
        var bn2 = new Corvus.Text.Json.BigNumber(s2, e2);
        var expected = new Corvus.Text.Json.BigNumber(expectedS, expectedE);

        // Act
        var result = bn1 * bn2;

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(BigNumberTestData.DivisionData), MemberType = typeof(BigNumberTestData))]
    public void Division_WithVariousInputs_ShouldWorkCorrectly(
        BigInteger s1, int e1,
        BigInteger s2, int e2,
        int precision,
        BigInteger expectedS, int expectedE)
    {
        // Arrange
        var bn1 = new Corvus.Text.Json.BigNumber(s1, e1);
        var bn2 = new Corvus.Text.Json.BigNumber(s2, e2);
        var expected = new Corvus.Text.Json.BigNumber(expectedS, expectedE);

        // Act
        var result = Corvus.Text.Json.BigNumber.Divide(bn1, bn2, precision);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Division_ByZero_ShouldThrow()
    {
        // Arrange
        var bn1 = new Corvus.Text.Json.BigNumber(1, 0);
        var bn2 = new Corvus.Text.Json.BigNumber(0, 0);

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => bn1 / bn2);
    }
}
