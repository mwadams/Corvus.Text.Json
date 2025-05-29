// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
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

        public void AddFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddPropertyFormattedNumber(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void AddRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddPropertyRawString(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping,
                valueRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Build value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                (ref ComplexValueBuilder valueBuilder) => BuildValue(value, ref valueBuilder),
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, JsonArrayBuilder.Build value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                (ref ComplexValueBuilder valueBuilder) => JsonArrayBuilder.BuildValue(value, ref valueBuilder),
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                utf8String,
                escapeName,
                true,
                nameRequiresUnescaping,
                false);
        }

        public void AddNull(ReadOnlySpan<byte> propertyName, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddPropertyNull(propertyName, escapeName, nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, bool value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName = true, bool nameRequiresUnescaping = false)
            where T : struct, IJsonElement<T>
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, byte value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, int value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, uint value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, long value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, short value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, float value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, double value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

#if NET
        public void Add(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        [CLSCompliant(false)]
        public void Add(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }

        public void Add(ReadOnlySpan<byte> propertyName, Half value, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            Debug.Assert((escapeName && !nameRequiresUnescaping) || (!escapeName));
            _builder.AddProperty(
                propertyName,
                value,
                escapeName,
                nameRequiresUnescaping);
        }
#endif
    }
}
