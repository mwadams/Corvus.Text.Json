// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    public ref struct JsonObjectBuilder()
    {
        public delegate void Build(ref JsonObjectBuilder builder);

        private ComplexValueBuilder _builder;

        internal JsonObjectBuilder(ComplexValueBuilder builder) : this() => _builder = builder;

        internal static JsonObjectBuilder Create(IMutableJsonDocument parentDocument, int targetIndex, int initialElementCount)
        {
            ComplexValueBuilder builder = ComplexValueBuilder.Create(parentDocument, initialElementCount);
            return new JsonObjectBuilder(builder);
        }

        internal static void BuildValue(Build value, ref ComplexValueBuilder valueBuilder)
        {
            valueBuilder.StartObject();
            JsonObjectBuilder objectBuilder = new(valueBuilder);
            value(ref objectBuilder);
            valueBuilder = objectBuilder._builder;
            valueBuilder.EndObject();
        }

        public void AddFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
        {
            _builder.AddPropertyFormattedNumber(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Build value)
        {
            _builder.AddProperty(
                propertyName,
                (ref ComplexValueBuilder valueBuilder) => BuildValue(value, ref valueBuilder));
        }

        public void Add(ReadOnlySpan<byte> propertyName, JsonArrayBuilder.Build value)
        {
            _builder.AddProperty(
                propertyName,
                (ref ComplexValueBuilder valueBuilder) => JsonArrayBuilder.BuildValue(value, ref valueBuilder));
        }

        public void Add(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
        {
            _builder.AddProperty(
                propertyName,
                utf8String);
        }

        public void AddNull(ReadOnlySpan<byte> propertyName)
        {
            _builder.AddPropertyNull(propertyName);
        }

        public void Add(ReadOnlySpan<byte> propertyName, bool value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add<T>(ReadOnlySpan<byte> propertyName, T value)
            where T : struct, IJsonElement<T>
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Guid value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, sbyte value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, byte value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, int value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, uint value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, long value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, ulong value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, short value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, ushort value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, float value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, double value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, decimal value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

#if NET
        public void Add(ReadOnlySpan<byte> propertyName, Int128 value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, UInt128 value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Half value)
        {
            _builder.AddProperty(
                propertyName,
                value);
        }
#endif
    }
}
