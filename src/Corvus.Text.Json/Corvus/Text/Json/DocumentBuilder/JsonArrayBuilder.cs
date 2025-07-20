// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Numerics;
using Corvus.Text.Json.Internal;
using NodaTime;

namespace Corvus.Text.Json;

/// <summary>
/// Provides a high-performance, low-allocation builder for constructing JSON arrays
/// within an <see cref="IMutableJsonDocument"/>.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="JsonArrayBuilder"/> is a ref struct designed for use in stack-based scenarios,
/// enabling efficient construction of JSON arrays by directly manipulating the underlying metadata database.
/// </para>
/// <para>
/// This builder supports adding items of various types, including primitives, strings, numbers, booleans, nulls,
/// arrays, and complex/nested values. It also provides methods for starting and ending JSON arrays, as well as
/// for integrating with <see cref="IMutableJsonDocument"/> for document mutation.
/// </para>
/// <para>
/// Typical usage involves creating a builder via <see cref="ComplexValueBuilder.Create(IMutableJsonDocument, int)"/>,
/// using <see cref="Add"/> and <see cref="AddArrayValue"/> methods to populate the array,
/// and then finalizing with <see cref="BuildValue"/>.
/// </para>
/// <para>
/// This type is not thread-safe and must not be stored on the heap.
/// </para>
/// </remarks>
public ref struct JsonArrayBuilder()
{
    /// <summary>
    /// Delegate for building a JSON array using a <see cref="JsonArrayBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="JsonArrayBuilder"/> instance to build with.</param>
    public delegate void Build(ref JsonArrayBuilder builder);

    private ComplexValueBuilder _builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonArrayBuilder"/> struct.
    /// </summary>
    /// <param name="builder">The underlying <see cref="ComplexValueBuilder"/> to use.</param>
    internal JsonArrayBuilder(ComplexValueBuilder builder) : this() => _builder = builder;

    /// <summary>
    /// Builds a JSON array value using the provided delegate and value builder.
    /// </summary>
    /// <param name="value">The delegate to build the array.</param>
    /// <param name="valueBuilder">The <see cref="ComplexValueBuilder"/> to use.</param>
    public static void BuildValue(Build value, ref ComplexValueBuilder valueBuilder)
    {
        valueBuilder.StartArray();
        JsonArrayBuilder ovb = new(valueBuilder);
        value(ref ovb);
        valueBuilder = ovb._builder;
        valueBuilder.EndArray();
    }

    /// <summary>
    /// Adds an object to the array using a builder delegate.
    /// </summary>
    /// <param name="value">A delegate that builds the object to add to the array.</param>
    public void Add(JsonObjectBuilder.Build value)
    {
        _builder.AddItem(
            (ref valueBuilder) => JsonObjectBuilder.BuildValue(value, ref valueBuilder));
    }

    /// <summary>
    /// Adds an array to the array using a builder delegate.
    /// </summary>
    /// <param name="value">A delegate that builds the array to add as an item.</param>
    public void Add(Build value)
    {
        _builder.AddItem((ref valueBuilder) => BuildValue(value, ref valueBuilder));
    }

    /// <summary>
    /// Adds a string value to the array.
    /// </summary>
    /// <param name="value">The string value to add.</param>
    public void Add(string value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a character span value to the array.
    /// </summary>
    /// <param name="value">The character span value to add.</param>
    public void Add(ReadOnlySpan<char> value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a UTF-8 byte span value to the array.
    /// </summary>
    /// <param name="utf8String">The UTF-8 byte span value to add.</param>
    public void Add(ReadOnlySpan<byte> utf8String)
    {
        _builder.AddItem(utf8String);
    }

    /// <summary>
    /// Adds a formatted number to the array.
    /// </summary>
    /// <param name="value">The formatted number as a UTF-8 byte span.</param>
    public void AddFormattedNumber(ReadOnlySpan<byte> value)
    {
        _builder.AddItemFormattedNumber(
            value);
    }

    /// <summary>
    /// Adds a raw string value to the array, specifying if unescaping is required.
    /// </summary>
    /// <param name="value">The raw string value as a UTF-8 byte span.</param>
    /// <param name="requiresUnescaping">Whether the value requires unescaping.</param>
    public void AddRawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
    {
        _builder.AddItemRawString(
            value,
            requiresUnescaping);
    }

    /// <summary>
    /// Adds a null value to the array.
    /// </summary>
    public void AddNull()
    {
        _builder.AddItemNull();
    }

    /// <summary>
    /// Adds a boolean value to the array.
    /// </summary>
    /// <param name="value">The boolean value to add.</param>
    public void Add(bool value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a value of type <typeparamref name="T"/> to the array.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to add.</param>
    [CLSCompliant(false)]
    public void Add<T>(T value)
        where T : struct, IJsonElement<T>
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="Guid"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="Guid"/> value to add.</param>
    public void Add(Guid value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="DateTime"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> value to add.</param>
    public void Add(in DateTime value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="DateTimeOffset"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="DateTimeOffset"/> value to add.</param>
    public void Add(in DateTimeOffset value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds an <see cref="OffsetDateTime"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="OffsetDateTime"/> value to add.</param>
    public void Add(in OffsetDateTime value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds an <see cref="OffsetDate"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="OffsetDate"/> value to add.</param>
    public void Add(in OffsetDate value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds an <see cref="OffsetTime"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="OffsetTime"/> value to add.</param>
    public void Add(in OffsetTime value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="LocalDate"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="LocalDate"/> value to add.</param>
    public void Add(in LocalDate value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="Period"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="Period"/> value to add.</param>
    public void Add(in Period value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds an <see cref="sbyte"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="sbyte"/> value to add.</param>
    [CLSCompliant(false)]
    public void Add(sbyte value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="byte"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="byte"/> value to add.</param>
    public void Add(byte value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds an <see cref="int"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="int"/> value to add.</param>
    public void Add(int value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="uint"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="uint"/> value to add.</param>
    [CLSCompliant(false)]
    public void Add(uint value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="long"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="long"/> value to add.</param>
    public void Add(long value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="ulong"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="ulong"/> value to add.</param>
    [CLSCompliant(false)]
    public void Add(ulong value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="short"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="short"/> value to add.</param>
    public void Add(short value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="ushort"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="ushort"/> value to add.</param>
    [CLSCompliant(false)]
    public void Add(ushort value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="float"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="float"/> value to add.</param>
    public void Add(float value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="double"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="double"/> value to add.</param>
    public void Add(double value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="decimal"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="decimal"/> value to add.</param>
    public void Add(decimal value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="BigInteger"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="BigInteger"/> value to add.</param>
    public void Add(in BigInteger value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="BigNumber"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="BigNumber"/> value to add.</param>
    public void Add(in BigNumber value)
    {
        _builder.AddItem(value);
    }

#if NET

    /// <summary>
    /// Adds an <see cref="Int128"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="Int128"/> value to add.</param>
    public void Add(Int128 value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="UInt128"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="UInt128"/> value to add.</param>
    [CLSCompliant(false)]
    public void Add(UInt128 value)
    {
        _builder.AddItem(value);
    }

    /// <summary>
    /// Adds a <see cref="Half"/> value to the array.
    /// </summary>
    /// <param name="value">The <see cref="Half"/> value to add.</param>
    public void Add(Half value)
    {
        _builder.AddItem(value);
    }

#endif

    /// <summary>
    /// Adds an array of <see cref="long"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="long"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<long> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="int"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="int"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<int> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="short"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="short"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<short> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="sbyte"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="sbyte"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<sbyte> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="ulong"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="ulong"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<ulong> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="uint"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="uint"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<uint> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="ushort"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="ushort"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<ushort> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="byte"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="byte"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<byte> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="decimal"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="decimal"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<decimal> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="double"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="double"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<double> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="float"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="float"/> values to add.</param>
    public void AddArrayValue(ReadOnlySpan<float> array)
    {
        _builder.AddItemArrayValue(array);
    }

#if NET

    /// <summary>
    /// Adds an array of <see cref="Int128"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="Int128"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<Int128> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="UInt128"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="UInt128"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<UInt128> array)
    {
        _builder.AddItemArrayValue(array);
    }

    /// <summary>
    /// Adds an array of <see cref="Half"/> values to the array.
    /// </summary>
    /// <param name="array">The array of <see cref="Half"/> values to add.</param>
    [CLSCompliant(false)]
    public void AddArrayValue(ReadOnlySpan<Half> array)
    {
        _builder.AddItemArrayValue(array);
    }

#endif
}
