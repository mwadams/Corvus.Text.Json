// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    public ref struct JsonArrayBuilder()
    {
        public delegate void Build(ref JsonArrayBuilder builder);

        private ComplexValueBuilder _builder;

        internal JsonArrayBuilder(ComplexValueBuilder builder) : this() => _builder = builder;

        internal static JsonArrayBuilder Create(IMutableJsonDocument parentDocument, int targetIndex, int initialElementCount)
        {
            ComplexValueBuilder builder = ComplexValueBuilder.Create(parentDocument, initialElementCount);
            return new JsonArrayBuilder(builder);
        }

        internal static void BuildValue(Build value, ref ComplexValueBuilder valueBuilder)
        {
            valueBuilder.StartArray();
            JsonArrayBuilder ovb = new(valueBuilder);
            value(ref ovb);
            valueBuilder = ovb._builder;
            valueBuilder.EndArray();
        }

        public void Add(JsonObjectBuilder.Build value)
        {
            _builder.AddItem(
                (ref ComplexValueBuilder valueBuilder) => JsonObjectBuilder.BuildValue(value, ref valueBuilder));
        }

        public void Add(Build value)
        {
            _builder.AddItem((ref ComplexValueBuilder valueBuilder) => BuildValue(value, ref valueBuilder));
        }

        public void Add(ReadOnlySpan<byte> utf8String)
        {
            _builder.AddItem(utf8String);
        }

        public void AddNull()
        {
            _builder.AddNullItem();
        }

        public void Add(bool value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add<T>(T value)
            where T : struct, IJsonElement<T>
        {
            _builder.AddItem(value);
        }

        public void Add(Guid value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add(sbyte value)
        {
            _builder.AddItem(value);
        }

        public void Add(byte value)
        {
            _builder.AddItem(value);
        }

        public void Add(int value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add(uint value)
        {
            _builder.AddItem(value);
        }

        public void Add(long value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add(ulong value)
        {
            _builder.AddItem(value);
        }

        public void Add(short value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add(ushort value)
        {
            _builder.AddItem(value);
        }

        public void Add(float value)
        {
            _builder.AddItem(value);
        }

        public void Add(double value)
        {
            _builder.AddItem(value);
        }

        public void Add(decimal value)
        {
            _builder.AddItem(value);
        }


#if NET
        public void Add(Int128 value)
        {
            _builder.AddItem(value);
        }

        [CLSCompliant(false)]
        public void Add(UInt128 value)
        {
            _builder.AddItem(value);
        }

        public void Add(Half value)
        {
            _builder.AddItem(value);
        }
#endif
    }
}
