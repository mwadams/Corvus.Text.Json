// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct Year : IJsonElement<Year>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal Year(IJsonDocument parent, int idx)
    {
        // parent is usually not null, but the Current property
        // on the enumerators (when initialized as `default`) can
        // get here with a null.
        Debug.Assert(idx >= 0);

        _parent = parent;
        _idx = idx;
    }

    /// <summary>
    ///   The <see cref="JsonValueKind"/> that the value is.
    /// </summary>
    /// <exception cref="ObjectDisposedException">
    ///   The parent <see cref="JsonDocument"/> has been disposed.
    /// </exception>
    public JsonValueKind ValueKind => TokenType.ToValueKind();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private JsonTokenType TokenType
    {
        get
        {
            return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
        }
    }

    public static implicit operator int(Year year)
    {
        year.CheckValidInstance();

        if (!year._parent.TryGetValue(year._idx, out int result))
        {
            CodeGenThrowHelper.ThrowFormatException(CodeGenNumericType.Int32);
        }

        return result;
    }

    public static Year From<T>(in T instance)
    where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1, -1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.AddItem(year);
        Debug.Assert(cvb.MemberCount == 1);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
    {
        return workspace.CreateDocument<Year, Mutable>(this);
    }

    /// <summary>
    ///   Write the element into the provided writer as a JSON value.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <exception cref="ArgumentNullException">
    ///   The <paramref name="writer"/> parameter is <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///   This value's <see cref="ValueKind"/> is <see cref="JsonValueKind.Undefined"/>.
    /// </exception>
    /// <exception cref="ObjectDisposedException">
    ///   The parent <see cref="JsonDocument"/> has been disposed.
    /// </exception>
    public void WriteTo(Utf8JsonWriter writer)
    {
        ////ArgumentNullException.ThrowIfNull(writer);

        CheckValidInstance();

        _parent.WriteElementTo(_idx, writer);
    }

    /// <summary>
    ///   Gets a string representation for the current value appropriate to the value type.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     For JsonElement built from <see cref="JsonDocument"/>:
    ///   </para>
    ///
    ///   <para>
    ///     For <see cref="JsonValueKind.Null"/>, <see cref="string.Empty"/> is returned.
    ///   </para>
    ///
    ///   <para>
    ///     For <see cref="JsonValueKind.True"/>, <see cref="bool.TrueString"/> is returned.
    ///   </para>
    ///
    ///   <para>
    ///     For <see cref="JsonValueKind.False"/>, <see cref="bool.FalseString"/> is returned.
    ///   </para>
    ///
    ///   <para>
    ///     For <see cref="JsonValueKind.String"/>, the value of <see cref="GetString"/>() is returned.
    ///   </para>
    ///
    ///   <para>
    ///     For other types, the value of <see cref="GetRawText"/>() is returned.
    ///   </para>
    /// </remarks>
    /// <returns>
    ///   A string representation for the current value appropriate to the value type.
    /// </returns>
    /// <exception cref="ObjectDisposedException">
    ///   The parent <see cref="JsonDocument"/> has been disposed.
    /// </exception>
    public override string ToString()
    {
        switch (TokenType)
        {
            case JsonTokenType.None:
            case JsonTokenType.Null:
                return string.Empty;
            case JsonTokenType.True:
                return bool.TrueString;
            case JsonTokenType.False:
                return bool.FalseString;
            case JsonTokenType.Number:
            case JsonTokenType.StartArray:
            case JsonTokenType.StartObject:
            {
                // null parent should have hit the None case
                return _parent.GetRawValueAsString(_idx);
            }
            case JsonTokenType.String:
                return _parent.GetString(_idx, JsonTokenType.String)!;
            case JsonTokenType.Comment:
            case JsonTokenType.EndArray:
            case JsonTokenType.EndObject:
            default:
                Debug.Fail($"No handler for {nameof(JsonTokenType)}.{TokenType}");
                return string.Empty;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSchemaMatch(IJsonSchemaResultsCollector? resultsCollector = null)
    {
        return JsonSchema.IsMatch(_parent, _idx, resultsCollector);
    }

    private void CheckValidInstance()
    {
        if (_parent == null)
        {
            throw new InvalidOperationException();
        }
    }

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static Year IJsonElement<Year>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Year: ValueKind = {ValueKind} : \"{ToString()}\"";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IJsonDocument IJsonElement.ParentDocument => _parent;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    int IJsonElement.ParentDocumentIndex => _idx;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonTokenType IJsonElement.TokenType => TokenType;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonValueKind IJsonElement.ValueKind => ValueKind;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public readonly struct Mutable : IMutableJsonElement<Mutable>
    {
        private readonly IJsonDocument _parent;
        private readonly int _idx;

        internal Mutable(IJsonDocument parent, int idx)
        {
            // parent is usually not null, but the Current property
            // on the enumerators (when initialized as `default`) can
            // get here with a null.
            Debug.Assert(idx >= 0);

            _parent = parent;
            _idx = idx;
        }

        /// <summary>
        ///   The <see cref="JsonValueKind"/> that the value is.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public JsonValueKind ValueKind => TokenType.ToValueKind();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private JsonTokenType TokenType
        {
            get
            {
                return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
            }
        }

        public static explicit operator Mutable(Year year)
        {
            if (year._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, year._idx);

        }

        public static implicit operator Year(Mutable year)
        {
            return new(year._parent, year._idx);
        }

        public static implicit operator int(Mutable year)
        {
            year.CheckValidInstance();

            if (!year._parent.TryGetValue(year._idx, out int result))
            {
                CodeGenThrowHelper.ThrowFormatException(CodeGenNumericType.Int32);
            }

            return result;
        }

        public static Mutable From<T>(in T instance)
        where T : struct, IMutableJsonElement<T>
        {
            return new(instance.ParentDocument, instance.ParentDocumentIndex);
        }

        private void CheckValidInstance()
        {
            if (_parent == null)
            {
                throw new InvalidOperationException();
            }
        }

        void IJsonElement.CheckValidInstance() => CheckValidInstance();

        /// <summary>
        ///   Write the element into the provided writer as a JSON value.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <exception cref="ArgumentNullException">
        ///   The <paramref name="writer"/> parameter is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is <see cref="JsonValueKind.Undefined"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public void WriteTo(Utf8JsonWriter writer)
        {
            ////ArgumentNullException.ThrowIfNull(writer);

            CheckValidInstance();

            _parent.WriteElementTo(_idx, writer);
        }

        /// <summary>
        ///   Gets a string representation for the current value appropriate to the value type.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     For JsonElement built from <see cref="JsonDocument"/>:
        ///   </para>
        ///
        ///   <para>
        ///     For <see cref="JsonValueKind.Null"/>, <see cref="string.Empty"/> is returned.
        ///   </para>
        ///
        ///   <para>
        ///     For <see cref="JsonValueKind.True"/>, <see cref="bool.TrueString"/> is returned.
        ///   </para>
        ///
        ///   <para>
        ///     For <see cref="JsonValueKind.False"/>, <see cref="bool.FalseString"/> is returned.
        ///   </para>
        ///
        ///   <para>
        ///     For <see cref="JsonValueKind.String"/>, the value of <see cref="GetString"/>() is returned.
        ///   </para>
        ///
        ///   <para>
        ///     For other types, the value of <see cref="GetRawText"/>() is returned.
        ///   </para>
        /// </remarks>
        /// <returns>
        ///   A string representation for the current value appropriate to the value type.
        /// </returns>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public override string ToString()
        {
            switch (TokenType)
            {
                case JsonTokenType.None:
                case JsonTokenType.Null:
                    return string.Empty;
                case JsonTokenType.True:
                    return bool.TrueString;
                case JsonTokenType.False:
                    return bool.FalseString;
                case JsonTokenType.Number:
                case JsonTokenType.StartArray:
                case JsonTokenType.StartObject:
                {
                    // null parent should have hit the None case
                    return _parent.GetRawValueAsString(_idx);
                }
                case JsonTokenType.String:
                    return _parent.GetString(_idx, JsonTokenType.String)!;
                case JsonTokenType.Comment:
                case JsonTokenType.EndArray:
                case JsonTokenType.EndObject:
                default:
                    Debug.Fail($"No handler for {nameof(JsonTokenType)}.{TokenType}");
                    return string.Empty;
            }
        }

#if NET
        static Mutable IJsonElement<Mutable>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => $"Year.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonValueKind IJsonElement.ValueKind => ValueKind;
    }


    public ref struct Builder
    {
        public readonly ref struct Source
        {
            public Year Instance { get; }

            public int Int32Value { get; }

            public Source(Year instance)
            {
                Instance = instance;
                Int32Value = default;
            }

            public Source(int int32Value)
            {
                Instance = default;
                Int32Value = int32Value;
            }

            public static implicit operator Source(Year instance) => new(instance);
            public static implicit operator Source(int instance) => new(instance);

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Instance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddItem(Instance);
                }
                else
                {
                    valueBuilder.AddItem(Int32Value);
                }
            }

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder)
            {
                if (Instance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddProperty(utf8Name, Instance);
                }
                else
                {
                    valueBuilder.AddProperty(utf8Name, Int32Value);
                }
            }
        }
    }

    public static class JsonSchema
    {
        public static ReadOnlySpan<byte> SchemaLocation() => "#/$defs/Age"u8;
        private static ReadOnlySpan<byte> ExpectedANumberValue() => "Expected a number value."u8;
        private static ReadOnlySpan<byte> ExpectedAnIntegerValue() => "Expected an integer value."u8;
        private static ReadOnlySpan<byte> OutOfRangeInt32() => "Out of range for Int32."u8;
        private static ReadOnlySpan<byte> IgnoredBecauseTheValueWasNotOfTypeNumber() => "Ignored because the value was not of type 'number'."u8;
        private static ReadOnlySpan<byte> EscapedTypeKeyword() => "type"u8;
        private static ReadOnlySpan<byte> EscapedFormatKeyword() => "format"u8;

        private static bool minimumIsNegative => true;
        private static ReadOnlySpan<byte> minimumIntegral => "2147483648"u8;
        private static ReadOnlySpan<byte> minimumFractional => ""u8;
        private static int minimumExponent = 0;

        private static bool maximumIsNegative => false;
        private static ReadOnlySpan<byte> maximumIntegral => "2147483647"u8;
        private static ReadOnlySpan<byte> maximumFractional => ""u8;
        private static int maximumExponent = 0;

        /// <summary>
        /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
        /// </summary>
        /// <param name="parentDocument">The parent document.</param>
        /// <param name="parentIndex">The parent index.</param>
        /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
        internal static void ApplyJsonSchema(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
        {
            // You're not allowed to ask about non-value-like entities
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray or
                JsonTokenType.PropertyName);

            context.PushSchemaLocation(SchemaLocation);

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);

            if (tokenType != JsonTokenType.Number)
            {
                context.Matched(false, ExpectedANumberValue, schemaEvaluationPath: EscapedTypeKeyword);
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                context.Ignored(IgnoredBecauseTheValueWasNotOfTypeNumber, schemaEvaluationPath: EscapedFormatKeyword);
                context.PopSchemaLocation();
                return;
            }

            ReadOnlyMemory<byte> number = parentDocument.GetRawSimpleValue(parentIndex, false);
            JsonElementHelpers.ParseNumber(number.Span, out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);

            if (!JsonElementHelpers.IsIntegerNormalizedJsonNumber(integral, fractional, exponent))
            {
                context.Matched(false, ExpectedAnIntegerValue, schemaEvaluationPath: EscapedFormatKeyword);
                context.PopSchemaLocation();
                return;
            }

            if (JsonElementHelpers.CompareNormalizedJsonNumbers(
                isNegative,
                integral,
                fractional,
                exponent,
                minimumIsNegative,
                minimumIntegral,
                minimumFractional,
                minimumExponent) < 0)
            {
                context.Matched(false, messageProvider: OutOfRangeInt32, schemaEvaluationPath: EscapedFormatKeyword);
                context.PopSchemaLocation();
                return;
            }

            if (JsonElementHelpers.CompareNormalizedJsonNumbers(
                isNegative,
                integral,
                fractional,
                exponent,
                maximumIsNegative,
                maximumIntegral,
                maximumFractional,
                maximumExponent) > 0)
            {
                context.Matched(false, messageProvider: OutOfRangeInt32, schemaEvaluationPath: EscapedFormatKeyword);
                context.PopSchemaLocation();
                return;
            }

            context.Matched(true, schemaEvaluationPath: EscapedFormatKeyword);
            context.PopSchemaLocation();
        }

        internal static bool IsMatch(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            JsonSchemaContext context = JsonSchemaContext.BeginContext(
                parentDocument,
                parentIndex,
                usingEvaluatedProperties: false,
                usingEvaluatedItems: false,
                resultsCollector: resultsCollector);

            try
            {
                ApplyJsonSchema(parentDocument, parentIndex, ref context);
                return context.IsMatch;
            }
            finally
            {
                context.Dispose();
            }
        }

        internal static JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            JsonSchemaPathProvider? schemaEvaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }

        internal static JsonSchemaContext PushChildContext<TContext>(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            TContext providerContext,
            JsonSchemaPathProvider<TContext>? schemaEvaluationPath = null,
            JsonSchemaPathProvider<TContext>? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath,
                    providerContext: providerContext);
        }

    }
}
