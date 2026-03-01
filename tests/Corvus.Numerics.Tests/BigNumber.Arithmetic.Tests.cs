// <copyright file="BigNumber.Arithmetic.Tests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Corvus.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Numerics;

namespace Corvus.Numerics.Tests;

[TestClass]
public class BigNumberArithmeticTests
{
    [TestMethod]
    public void Addition_SameExponent_ReturnsCorrectSum()
    {
        BigNumber left = new(123, 0);
        BigNumber right = new(456, 0);

        BigNumber result = left + right;

        result.ShouldBe(new BigNumber(579, 0));
    }

    [TestMethod]
    public void Addition_DifferentExponent_ReturnsCorrectSum()
    {
        BigNumber left = new(123, -2);  // 1.23
        BigNumber right = new(456, -1);  // 45.6

        BigNumber result = left + right;
        BigNumber expected = BigNumber.Parse("46.83");

        result.ShouldBe(expected);
    }

    [TestMethod]
    public void Addition_WithZero_ReturnsOriginal()
    {
        BigNumber value = new(123, -2);

        BigNumber result = value + BigNumber.Zero;

        result.ShouldBe(value);
    }

    [TestMethod]
    public void Subtraction_SameExponent_ReturnsCorrectDifference()
    {
        BigNumber left = new(456, 0);
        BigNumber right = new(123, 0);

        BigNumber result = left - right;

        result.ShouldBe(new BigNumber(333, 0));
    }

    [TestMethod]
    public void Subtraction_DifferentExponent_ReturnsCorrectDifference()
    {
        BigNumber left = new(456, -1);   // 45.6
        BigNumber right = new(123, -2);  // 1.23

        BigNumber result = left - right;
        BigNumber expected = BigNumber.Parse("44.37");

        result.ShouldBe(expected);
    }

    [TestMethod]
    public void Subtraction_ResultingInZero_ReturnsZero()
    {
        BigNumber value = new(123, -2);

        BigNumber result = value - value;

        result.ShouldBe(BigNumber.Zero);
    }

    [TestMethod]
    public void Multiplication_Simple_ReturnsCorrectProduct()
    {
        BigNumber left = new(123, 0);
        BigNumber right = new(456, 0);

        BigNumber result = left * right;

        result.ShouldBe(new BigNumber(56088, 0));
    }

    [TestMethod]
    public void Multiplication_WithExponents_ReturnsCorrectProduct()
    {
        BigNumber left = new(12, 1);   // 120
        BigNumber right = new(34, 1);  // 340

        BigNumber result = left * right;

        result.ShouldBe(new BigNumber(408, 2));  // 40800
    }

    [TestMethod]
    public void Multiplication_ByZero_ReturnsZero()
    {
        BigNumber value = new(123, -2);

        BigNumber result = value * BigNumber.Zero;

        result.ShouldBe(BigNumber.Zero);
    }

    [TestMethod]
    public void Multiplication_ByOne_ReturnsOriginal()
    {
        BigNumber value = new(123, -2);

        BigNumber result = value * BigNumber.One;

        result.ShouldBe(value);
    }

    [TestMethod]
    public void Division_Simple_ReturnsCorrectQuotient()
    {
        BigNumber dividend = new(100, 0);
        BigNumber divisor = new(4, 0);

        BigNumber result = dividend / divisor;
        BigNumber expected = BigNumber.Parse("25");

        result.ShouldBe(expected);
    }

    [TestMethod]
    public void Division_WithPrecision_ReturnsCorrectQuotient()
    {
        BigNumber dividend = new(10, 0);
        BigNumber divisor = new(3, 0);

        BigNumber result = BigNumber.Divide(dividend, divisor, 10);

        double resultDouble = (double)result;
        resultDouble.ShouldBe(10.0 / 3.0, tolerance: 0.0000000001);
    }

    [TestMethod]
    public void Division_ByZero_ThrowsDivideByZeroException()
    {
        BigNumber dividend = new(100, 0);

        Should.Throw<DivideByZeroException>(() => dividend / BigNumber.Zero);
    }

    [TestMethod]
    public void Division_ZeroByNonZero_ReturnsZero()
    {
        BigNumber divisor = new(123, -2);

        BigNumber result = BigNumber.Zero / divisor;

        result.ShouldBe(BigNumber.Zero);
    }

    [TestMethod]
    public void Modulo_Simple_ReturnsCorrectRemainder()
    {
        BigNumber dividend = new(17, 0);
        BigNumber divisor = new(5, 0);

        BigNumber result = dividend % divisor;
        BigNumber expected = new(2, 0);

        result.ShouldBe(expected);
    }

    [TestMethod]
    public void Modulo_WithZeroDivisor_ThrowsDivideByZeroException()
    {
        BigNumber dividend = new(100, 0);

        Should.Throw<DivideByZeroException>(() => dividend % BigNumber.Zero);
    }

    [TestMethod]
    public void Negation_PositiveNumber_ReturnsNegative()
    {
        BigNumber value = new(123, -2);

        BigNumber result = -value;

        result.ShouldBe(new BigNumber(-123, -2));
    }

    [TestMethod]
    public void Negation_NegativeNumber_ReturnsPositive()
    {
        BigNumber value = new(-123, -2);

        BigNumber result = -value;

        result.ShouldBe(new BigNumber(123, -2));
    }

    [TestMethod]
    public void Negation_Zero_ReturnsZero()
    {
        BigNumber result = -BigNumber.Zero;

        result.ShouldBe(BigNumber.Zero);
    }

    [TestMethod]
    public void UnaryPlus_ReturnsOriginalValue()
    {
        BigNumber value = new(123, -2);

        BigNumber result = +value;

        result.ShouldBe(value);
    }

    [TestMethod]
    public void Increment_IncrementsByOne()
    {
        BigNumber value = new(10, 0);

        BigNumber result = ++value;

        result.ShouldBe(new BigNumber(11, 0));
    }

    [TestMethod]
    public void Decrement_DecrementsByOne()
    {
        BigNumber value = new(10, 0);

        BigNumber result = --value;

        result.ShouldBe(new BigNumber(9, 0));
    }

    [TestMethod]
    public void Abs_PositiveNumber_ReturnsOriginal()
    {
        BigNumber value = new(123, -2);

        BigNumber result = BigNumber.Abs(value);

        result.ShouldBe(value);
    }

    [TestMethod]
    public void Abs_NegativeNumber_ReturnsPositive()
    {
        BigNumber value = new(-123, -2);

        BigNumber result = BigNumber.Abs(value);

        result.ShouldBe(new BigNumber(123, -2));
    }

    [TestMethod]
    public void Abs_Zero_ReturnsZero()
    {
        BigNumber result = BigNumber.Abs(BigNumber.Zero);

        result.ShouldBe(BigNumber.Zero);
    }

    [TestMethod]
    public void Sign_PositiveNumber_ReturnsOne()
    {
        BigNumber value = new(123, -2);

        int sign = BigNumber.Sign(value);

        sign.ShouldBe(1);
    }

    [TestMethod]
    public void Sign_NegativeNumber_ReturnsMinusOne()
    {
        BigNumber value = new(-123, -2);

        int sign = BigNumber.Sign(value);

        sign.ShouldBe(-1);
    }

    [TestMethod]
    public void Sign_Zero_ReturnsZero()
    {
        int sign = BigNumber.Sign(BigNumber.Zero);

        sign.ShouldBe(0);
    }
}
