// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;
using NodaTime;

namespace Corvus.Text.Json
{
    /// <summary>
    /// Provides a builder for constructing JSON arrays in a mutable and efficient manner.
    /// </summary>
    public ref struct JsonArrayBuilder()
    {
        /// <summary>
        /// Delegate for building a JSON array using a <see cref="JsonArrayBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="JsonArrayBuilder"/> instance to build with.</param>
        public delegate void Build(ref JsonArrayBuilder builder);

        private ComplexValueBuilder _builder;

        internal JsonArrayBuilder(ComplexValueBuilder builder) : this() => _builder = builder;

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
        /// <param name="value">The object builder delegate.</param>
        public void Add(JsonObjectBuilder.Build value)
        {
            _builder.AddItem(
                (ref valueBuilder) => JsonObjectBuilder.BuildValue(value, ref valueBuilder));
        }

        /// <summary>
        /// Adds an array to the array using a builder delegate.
        /// </summary>
        /// <param name="value">The array builder delegate.</param>
        public void Add(Build value)
        {
            _builder.AddItem((ref valueBuilder) => BuildValue(value, ref valueBuilder));
        }

        /// <summary>
        /// Adds a string value to the array.
        /// </summary>
        /// <param name="value">The string value.</param>
        public void Add(string value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a character span value to the array.
        /// </summary>
        /// <param name="value">The character span value.</param>
        public void Add(ReadOnlySpan<char> value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a UTF-8 byte span value to the array.
        /// </summary>
        /// <param name="utf8String">The UTF-8 byte span value.</param>
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
        /// <param name="value">The boolean value.</param>
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
        /// <param name="value">The <see cref="Guid"/> value.</param>
        public void Add(Guid value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="DateTime"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value.</param>
        public void Add(in DateTime value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="DateTimeOffset"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> value.</param>
        public void Add(in DateTimeOffset value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds an <see cref="OffsetDateTime"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="OffsetDateTime"/> value.</param>
        public void Add(in OffsetDateTime value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds an <see cref="OffsetDate"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="OffsetDate"/> value.</param>
        public void Add(in OffsetDate value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds an <see cref="OffsetTime"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="OffsetTime"/> value.</param>
        public void Add(in OffsetTime value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="LocalDate"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="LocalDate"/> value.</param>
        public void Add(in LocalDate value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="Period"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="Period"/> value.</param>
        public void Add(in Period value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds an <see cref="sbyte"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value.</param>
        [CLSCompliant(false)]
        public void Add(sbyte value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="byte"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value.</param>
        public void Add(byte value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds an <see cref="int"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value.</param>
        public void Add(int value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="uint"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value.</param>
        [CLSCompliant(false)]
        public void Add(uint value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="long"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value.</param>
        public void Add(long value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="ulong"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value.</param>
        [CLSCompliant(false)]
        public void Add(ulong value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="short"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value.</param>
        public void Add(short value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="ushort"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value.</param>
        [CLSCompliant(false)]
        public void Add(ushort value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="float"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value.</param>
        public void Add(float value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="double"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value.</param>
        public void Add(double value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="decimal"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value.</param>
        public void Add(decimal value)
        {
            _builder.AddItem(value);
        }

#if NET
        /// <summary>
        /// Adds an <see cref="Int128"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="Int128"/> value.</param>
        public void Add(Int128 value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="UInt128"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="UInt128"/> value.</param>
        [CLSCompliant(false)]
        public void Add(UInt128 value)
        {
            _builder.AddItem(value);
        }

        /// <summary>
        /// Adds a <see cref="Half"/> value to the array.
        /// </summary>
        /// <param name="value">The <see cref="Half"/> value.</param>
        public void Add(Half value)
        {
            _builder.AddItem(value);
        }
#endif
    }
}
